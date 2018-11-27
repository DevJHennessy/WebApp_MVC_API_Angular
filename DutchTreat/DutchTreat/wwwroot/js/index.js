$(document).ready(function () {

    console.log("Hello World!");

    var theForm = $("#theForm");
    theForm.hide();

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("Buying Item");
    })

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You've clicked on " + $(this).text());
    })

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form")

    $loginToggle.on("click", function () {
        $popupForm.slideToggle(500);
    })

});
