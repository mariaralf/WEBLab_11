//=====================FILE DRAG&DROP FUNCTIONALITY=================================

let files_attached = false;
const dropZone = document.getElementById('fileUploadForm');
const content = document.getElementById('content');

dropZone.addEventListener('dragover', event => {
    event.stopPropagation();
    event.preventDefault();
    event.dataTransfer.dropEffect = 'copy';
});


dropZone.addEventListener('drop', event => {
    event.preventDefault();
    // Get the files
    const files_drag = event.dataTransfer.files;
  
    if (files_drag.length > 2) alert("Only up to 2 files are accepted!")
    else {
        let dragged_file_names = "";
        for (let i = 0; i < files_drag.length; i++) {
            // получаем сам файл
            current_file = files_drag.item(i);

            let filename = new String(current_file.name);

            if (filename.includes("png") || filename.includes("jpg") || filename.includes("jpeg") || filename.includes("webp")) {
                dragged_file_names += current_file.name + " ";
                document.getElementById("fileUpload").files = event.dataTransfer.files;
                //alert(current_file.name);

            }

        }
        RevealNextButton();
        imageName.innerText = dragged_file_names;
    }

   
    // Now we can do everything possible to show the
    // file content in an HTML element like, DIV
});
//==========================================================================================




function RevealNextButton() {
    files_attached = true;
    document.getElementById("next_input").classList.remove("button_disabled");
    document.getElementById("next_input").addEventListener("click", function () {
        SwitchTab(5);
    })
}



//=====================FILE CLICK UPLOAD FUNCTIONALITY=================================
let input_button = document.getElementById("fake_file_upload_button");
let imageName = document.getElementById("imageName")

input_button.addEventListener("change", () => {

    let attached_file_names = "";
   
    let files = document.querySelector("input[type=file]").files;
    if (files.length > 2 && files.length!=0) {
        alert("Only up to 2 files are accepted!");
        SwitchTab(4);

    }
    else {
        for (var i = 0; i < files.length; i++) {
            // получаем сам файл
            file = files.item(i);
           
            let filename = new String(file.name);
            
            if (filename.includes("png") || filename.includes("jpg") || filename.includes("jpeg") || filename.includes("webp"))
            attached_file_names += file.name + " ";
        }
        RevealNextButton();
        imageName.innerText = attached_file_names;
    }
})
//==========================================================================================