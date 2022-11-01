


myMap();
var g_input, g_in_servicearea = false;

function SwitchTab(go_to_tab_number) {
    //sessionStorage.setItem('go_to_tab_number', go_to_tab_number);
    //alert(sessionStorage.getItem('go_to_tab_number'));
    document.cookie = "go_to_tab_number=" + go_to_tab_number;
    document.location.reload();
}

function myMap() {
    var marker;

    //===========================Init Map========================================
    var mapProp = {
        center: new google.maps.LatLng(50.44285294234484, 30.52048967989053),
        zoom: 10,
    };
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    //===========================================================================


   


    // Define the LatLng coordinates for the polygon's path.
    const triangleCoords = [
        { lat: 50.564924943046435, lng: 30.084073511835975 },
        { lat: 50.25732384367605, lng: 30.303971568886155 },
        { lat: 50.34478192289761, lng: 30.946815480026583 },
        { lat: 50.68747095052475, lng: 30.85165127565836 },
        { lat: 50.68747095052475, lng: 30.85165127565836 },
        { lat: 50.564924943046435, lng: 30.084073511835975 },

    ];

    var coords_2d_mas = [];

  
    
    for (let i = 0; i < triangleCoords.length; i++) {
        coords_2d_mas.push([triangleCoords[i].lat, triangleCoords[i].lng]);
    }
 



    //Create polygon
    const mapsTriangle = new google.maps.Polygon({
        paths: triangleCoords,
        strokeColor: "#FF0000",
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: "#FF0000",
        fillOpacity: 0.35,
        clickable:true,
    });

    mapsTriangle.setMap(map);




    //Open-source function. Credentials:  https://gist.github.com/isedgar/1f5c5b4cf34a43d4db15f9b4fe58b04f
    function ray_casting(point, polygon) {
        var n = polygon.length,
            is_in = false,
            x = point[0],
            y = point[1],
            x1, x2, y1, y2;

        for (var i = 0; i < n - 1; ++i) {
            x1 = polygon[i][0];
            x2 = polygon[i + 1][0];
            y1 = polygon[i][1];
            y2 = polygon[i + 1][1];
            if (y < y1 != y < y2 && x < (x2 - x1) * (y - y1) / (y2 - y1) + x1) {
                is_in = !is_in;
            }
        }

        return is_in;
    }

   

    //=========================Click listener to place markers===================
    var physical_address = "1";

    //Listen if clicked on the MAP
    google.maps.event.addListener(mapsTriangle, 'click', function (event) {
        placeMarker(event.latLng);
    });

    //Listen if clicked on the POLYGON
    google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(event.latLng);
    });

    

    let text_input = document.getElementById("address_text_input");
    text_input.addEventListener("input", function () {
        if (text_input.value == "") {



            document.getElementById("check_address_button").classList.add('button_disabled');
            document.getElementById("check_address_button").replaceWith(document.getElementById("check_address_button").cloneNode(true));

        }
        else {
          
            document.getElementById("check_address_button").addEventListener("click", function () {
                convertAddressToCoords();
            });
            document.getElementById("check_address_button").classList.remove('button_disabled');
        }
    })
  




    
    function placeMarker(location) {

        g_input = true;

        if (marker == null) marker = new google.maps.Marker({
            position: location,
            map: map
        });
        else {
            marker.setPosition(location);
        }

        let lat_coord, lon_coord;
        lat_coord = new String(marker.position);
        lat_coord = lat_coord.substring(1, lat_coord.indexOf(","));
        lon_coord = new String(marker.position);
        lon_coord = lon_coord.substring(lon_coord.indexOf(",") + 2, lon_coord.length - 2);


        //alert("["+marker.position+"]");
        //alert("[" + lat_coord + "]");
        //alert("[" + lon_coord + "]");
        //alert([parseFloat(lat_coord), parseFloat(lon_coord)]);
        let info_block = document.getElementById("in_out_service_area_block");
        if (ray_casting([parseFloat(lat_coord), parseFloat(lon_coord)], coords_2d_mas)) {
            info_block.innerHTML = "YOU’RE WITHIN OUR SERVICE AREA";
            info_block.classList.remove("warning");
            g_in_servicearea = true;
            document.getElementById("second_tab_next_button").classList.remove("button_disabled");
            document.getElementById("second_tab_next_button").addEventListener("click", function() {
                SwitchTab(3);
            });

        }
        else {
            info_block.innerHTML = "YOU’RE OUT OF OUR SERVICE AREA";
            info_block.classList.add("warning");
            g_in_servicearea = false;
            document.getElementById("second_tab_next_button").classList.add("button_disabled");
            document.getElementById("second_tab_next_button").replaceWith(document.getElementById("second_tab_next_button").cloneNode(true));
        }

        convertCoordsToAddress(parseFloat(lat_coord), parseFloat(lon_coord));
        //document.getElementById("second_tab_next_button").classList.remove("button_disabled");

    }

    function convertAddressToCoords() {

        address = document.getElementById('address_text_input').value;
        fetch("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + '&key=' + "AIzaSyDa4AqYfhBt-3OjKVHdIissUR5EkwBUpik")
            .then(response => response.json())
            .then(data => {
                const latitude = data.results[0].geometry.location.lat;
                const longitude = data.results[0].geometry.location.lng;
                //console.log({ latitude, longitude })
                let latlng = new google.maps.LatLng(latitude, longitude);

                placeMarker(latlng);
                //document.getElementById("second_tab_next_button").classList.remove("button_disabled");
            })
    }




    
}


function convertCoordsToAddress(lat, lng) {
    var latlng = new google.maps.LatLng(lat, lng);
    // This is making the Geocode request
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'latLng': latlng }, (results, status) => {
        if (status !== google.maps.GeocoderStatus.OK) {
            //alert(status);
        }
        // This is checking to see if the Geoeode Status is OK before proceeding
        if (status == google.maps.GeocoderStatus.OK) {
            //console.log(results);
            address = (results[0].formatted_address);
            document.getElementById('address_text_input').value = address;

        }
    });

}




