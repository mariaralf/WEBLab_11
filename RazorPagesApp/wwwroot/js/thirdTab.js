function ChooseSystemType(number) {
    let second_number = 0;
    if (number == 1) second_number = 2
    else second_number = 1;

    let chosen_block = document.getElementById("system_type_" + number);
    let not_chosen_block = document.getElementById("system_type_" + second_number);   
    document.cookie = "saved_info=" + "system_type=" + number;
    chosen_block.style.border = "3px solid #680404";
    document.getElementById("third_tab_next_button").classList.remove("button_disabled");
    document.getElementById("third_tab_next_button").addEventListener("click", function () {
        SwitchTab(4);
    })
    
    not_chosen_block.style.border = "";
}