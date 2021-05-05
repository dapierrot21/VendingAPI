$(document).ready(function () {

    //Initial State.
    loadItems();

    //Click to get item #.
    $('.sq').click(function() {
        selectedItem($(this).attr('id'));
    });

    //Button click to get totals.
    $('#add-dollar, #add-quarter, #add-dime, #add-nickel').click(function () {
        addedAmount($(this).attr('id'));
    });

    //Button click to make purchase.
    $('#makePurchase').click(function() {
        makePurchase(parseFloat($('#total-in').val()).toFixed(2), $('#item').val());
    });

    //Button click to change return.
    $('#changeReturn').click(function() {
        changeReturn();
    });


});

//This function takes the id clicked square and display it in the Item label.
function selectedItem(input) {
        //Set item input to an empty string.
        $('#item').val('');
        //Finds the id of the item
        var itemTableId = $("#" + input).find('[id*="item"]').attr('id');
        //takes the first child element..
        var itemTableFirstRowId = "#" + itemTableId + " tr:first";
        //returns the text content of the selected element.
        var itemId = $(itemTableFirstRowId).text();
        //sets the input value.
        $('#item').val(itemId);
}

//This function takes the assigned amount of each button clicked and returns the sum.
function addedAmount(input) {
       var addButton = input;
       //Forces user to use the Add * button.
       $('#total-in').prop("readonly", false);
       //Parse the value or set the value.
       var currentTotal = parseFloat($('#total-in').val()) || 0.00;
       var finalTotal = currentTotal;
       switch (addButton) {
           case "add-dollar":
                finalTotal += 1.00;
                break;
           case "add-quarter":
                finalTotal += 0.25;
                break;
           case "add-dime":
                finalTotal += 0.10;
                break;
           case "add-nickel":
                finalTotal += 0.05;
                break;
           default:
                finalTotal += 0.00;
       }
       //assign parsed value with a fixed-point.
       $('#total-in').val(parseFloat(finalTotal).toFixed(2));
       $('#total-in').prop("readonly", true);
}

// This function loads items in the opens squares.
function loadItems() {
    // we need to clear the previous content so we don't append to it
    clearItemTables();

    var itemTable = [];
    // loops thru tbody element that will hold the rows of item information
    for (var i = 1;i < 100;i++) {
        itemTable[i] = $('#item' + i);
    }
    
    $.ajax ({
        type: 'GET',
        url: 'https://tsg-vending.herokuapp.com/items',
        success: function (data, status) {
            $.each(data, function (index, item) {
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var row = '<tr align="left"><td>' + id + '</td></tr>';
                    row += '<tr><td>' + name + '</td></tr>';
                    row += '<tr><td>' + '$' + parseFloat(price).toFixed(2) + '</td></tr>';
                    row += '<tr><td>' + 'Quantity Left: ' + quantity + '</td></tr>';

                itemTable[index + 1].append(row);
                row = '';
            });
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
            $('#bodyContent, #endingRule').hide();
        }
    });
}

// This function takes the total-in and the item and make a POST call to subtract that item from the API.
// Upon success of this call. The remaining balance if any, is displayed.
function makePurchase(money, item) {

    $.ajax ({
        type: 'POST',
        url: 'https://tsg-vending.herokuapp.com/money/' + money + '/item/' + item,
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        success: function(data) {
              $('#messages').val('Thank You!!!');
              var balance = '';
              if(data.quarters > 0) {
                    balance += data.quarters + ' Quarter(s) ';
              }
              if(data.dimes > 0) {
                    balance += data.dimes + ' Dime(s) ';
              }
              if(data.nickels > 0) {
                    balance += data.nickels + ' Nickel(s) ';
              }
              if(data.pennies > 0) {
                    balance += data.pennies + ' Penny(s) ';
              }
              $('#change').val(balance);
              $('#change').prop("readonly", true);
          },
        error: function(xhr, errorThrown) {
            if((errorThrown == "Unprocessable Entity") || (xhr.status == "422")) {
                // Will tell user either SOLD OUT!! or Enter a certain amount.
                //Parses the JSON error and converts it into human-readable description of the error.
                $('#messages').val((jQuery.parseJSON(xhr.responseText)).message);
            }
            else {
                $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
                $('#bodyContent, #endingRule').hide();
            }
        }
    });

   //Load the current data;
   loadItems();
}

// This function takes the change label value and return the remaining amount and clears the inputs.
function changeReturn() {
        var currentTotal = 0.00;

        var quarter = 0.25;
        var dime    = 0.10;
        var nickel  = 0.05;
        var penny   = 0.01;

        // clears the amount after return change button is clicked.
        var quarters = '', dimes = '', nickels = '', pennies = '', balance = '';
        //Remaining quarters after purchase.
        var quarters = parseInt(currentTotal / quarter);
        console.log(quarters);
        currentTotal = parseFloat(currentTotal % quarter).toFixed(2);
        console.log(currentTotal);
        //Remaining dimes after purchase.
        var dimes = parseInt(currentTotal / dime);
        currentTotal = parseFloat(currentTotal % dime).toFixed(2);
        //Remaining nickels after purchase.
        var nickels = parseInt(currentTotal / nickel);
        currentTotal = parseFloat(currentTotal % nickel).toFixed(2);
        //Remaining pennies after purchase.
        var pennies = parseInt(currentTotal / pennies);
        currentTotal = parseFloat(currentTotal % pennies).toFixed(2);

        if(quarters < 0) {
            balance += quarters + ' Quarter(s) ';
            console.log(balance);
        }
        if(dimes < 0) {
            balance += dimes + ' Dime(s) ';
        }
        if(nickels < 0) {
            balance += nickels + ' Nickel(s) ';
        }
        if(pennies < 0) {
            balance += pennies + ' Penny(s) ';
        }
        //Gets the property value for only the first element in the matched set. set it to readonly.
       $('#total-in, #messages, #change').prop("readonly", false);
       //Sets the value to an empty string.
       $('#total-in, #messages, #item').val('');
       //#change value is set to balance.
       $('#change').val(balance);
       $('#total-in, #messages, #change').prop("readonly", true);
       //Load the current data;
       loadItems();
}

// This function clears the items in the tables.
function clearItemTables() {
    for (var i = 1;i < 10;i++) {
        $('#item' + i).empty();
    }
}
