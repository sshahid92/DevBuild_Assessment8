var isGoingExists = document.getElementById("isGoing");
if (isGoingExists != null) {
    document.getElementById("isGoing").style.display = "none";
    document.getElementById("guestInfo").style.display = "none";
}


function validateName(name) {
    var pattern = /^[A-Za-z ']+$/;
    return pattern.test(String(name));
}

function validateDish(dish) {
    var pattern = /^[A-Za-z ',]+$/;
    return pattern.test(String(dish));
}

function validateEmail(email) {
    var pattern = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return pattern.test(String(email).toLowerCase());
}

function validatePhone(phone) {
    var pattern = /^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$/;
    return pattern.test(String(phone));
}



function validate() {
    var fnMessage = $("#fnMessage");
    var firstname = $("#firstname").val();
    fnMessage.text("");

    var lnMessage = $("#lnMessage");
    var lastname = $("#lastname").val();
    lnMessage.text("");

    var emailMessage = $("#emailMessage");
    var email = $("#email").val();
    emailMessage.text("");

    var isGoingMessage = $("#isGoingMessage");
    isGoingMessage.text("");


    if (!validateName(firstname)) {
        fnMessage.text(firstname + " is not a valid name");
        fnMessage.css("color", "red");
        return false;
    }
    if (!validateName(lastname)) {
        lnMessage.text(lastname + " is not a valid name");
        lnMessage.css("color", "red");
        return false;
    }

    if (!validateEmail(email)) {
        emailMessage.text(email + " is not a valid email");
        emailMessage.css("color", "red");
        return false;
    }
    if (!document.getElementById("yes").checked && !document.getElementById("no").checked) {
        isGoingMessage.text("Please check whether your are going.");
        isGoingMessage.css("color", "red");
        return false;
    }

    if (document.getElementById("yes").checked) {
        $("#isGoingMessage").text("");
        var dateMessage = $("#dateMessage");
        dateMessage.text("");

        var guestMessage = $("#guestMessage");
        guestMessage.text("");

        var guestNameMessage = $("#guestNameMessage");
        var guestName = $("#guestName").val();
        guestNameMessage.text("");
                
        if (!document.getElementById("date1").checked && !document.getElementById("date2").checked) {
            dateMessage.text("Please select a date.");
            dateMessage.css("color", "red");
            return false;
        }
        if (!document.getElementById("guestYes").checked && !document.getElementById("guestNo").checked) {
            guestMessage.text("Please check whether you are bringing a guest.");
            guestMessage.css("color", "red");
            return false;
        }
        if (document.getElementById("guestYes").checked) {
            if (!validateName(guestName)) {
                guestNameMessage.text(guestName + " is not a valid name");
                guestNameMessage.css("color", "red");
                return false;
            }
        }
        
    }
    return true;
}

$("#rsvp").bind("click", validate);


function validateDish() {
    var nameMessage = $("#nameMessage");
    var name = $("#name").val();
    nameMessage.text("");

    var phoneMessage = $("#phoneMessage");
    var phone = $("#phone").val();
    phoneMessage.text("");

    var dishnameMessage = $("#dishnameMessage");
    var dishname = $("#dishname").val();
    dishnameMessage.text("");

    var dishdesMessage = $("#dishdesMessage");
    var dishdes = $("#dishdes")
    dishdesMessage.text("");


    if (!validateName(name)) {
        nameMessage.text(name + " is not a valid name");
        nameMessage.css("color", "red");
        return false;
    }
    if (!validatePhone(phone)) {
        phoneMessage.text(phone + " is not a valid phone number");
        phoneMessage.css("color", "red");
        return false;
    }

    if (!validateDish(dishname)) {
        dishnameMessage.text(dishname + " is not a valid dish name");
        dishnameMessage.css("color", "red");
        return false;
    }
    if (!validateDish(dishdes)) {
        dishnameMessage.text(dishdes + " is not a valid description");
        dishnameMessage.css("color", "red");
        return false;
    }
    
    return true;
}

$("#submitDish").bind("click", validateDish);



function isGoing() {
    var x = document.getElementById("isGoing");
    if (document.getElementById("yes").checked) {
        x.style.display = "block";
    } else if (document.getElementById("no").checked) {
        x.style.display = "none";
    }
}

function isBringGuest() {
    var x = document.getElementById("guestInfo");
    if (document.getElementById("guestYes").checked) {
        x.style.display = "block";
    } else if (document.getElementById("guestNo").checked) {
        x.style.display = "none";
    }
}

if (document.getElementById("guest") == null) {
    document.getElementById("guest").style.display = "none";
}


