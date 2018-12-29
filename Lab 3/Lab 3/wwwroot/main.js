
var prices = [2.50, 6.00, 3.50, 6.50, 2.00];

function display() {
    //Selected Index
    var x = document
        .getElementById("BeverageSelect")
        .selectedIndex;
    //Selected Value
    var y = document
        .getElementById("BeverageSelect")
        .options;
    var itemPrice = prices[x];
    //Item Info
    var name = document
        .getElementById("CustomerName")
        .value;
    var cardOrderDisplay = document.getElementById("order-display");
    var cardUnderageDisplay = document.getElementById("underage-display");
    var dateDisplay = document.getElementById("Date");
    var quantity = document
        .getElementById("Quantity")
        .value;
    var itemSelected = y[x].text
    var total = itemPrice * quantity;
    //Age Info
    var age = document
        .getElementById("Bday")
        .value;
    var customerAge = moment(age);
    console.log(customerAge);
    var ageRequired = moment().subtract(21, 'years');
    var ageDisplay = ageRequired.calendar();

    console.log(ageDisplay);

    cardOrderDisplay.innerHTML = "Customer: " + name + "<br />  " + quantity + " " +
            itemSelected + " @ $" + itemPrice + "<br />Total Due: $" + total;
    cardOrderDisplay.style.display = "block";

    if (itemSelected == "Beer" || itemSelected == "Wine") {
        cardOrderDisplay.innerHTML = "Please Enter Age to Order, Then submit again";
        dateDisplay.style.display = "block";
        if (customerAge < ageRequired) {
            cardUnderageDisplay.style.display = "none";
            cardOrderDisplay.innerHTML = "Customer: " + name + "<br />  " + quantity + " " +
                    itemSelected + " @ $" + itemPrice + "<br />Total Due: $" + total;
            cardOrderDisplay.style.display = "block";
        }else if (customerAge > ageRequired){
            cardOrderDisplay.style.display = "none";
            cardUnderageDisplay.innerHTML = "You are NOT old enough to purchase alcohol!" + "<br />" + "You must be born before or on: "+ ageDisplay + " to purchase alcohol.";
            cardUnderageDisplay.style.display = "block";
        };
    }
}