// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
let lattitude, longtitude = "" 

if (navigator.geolocation){
    navigator.geolocation.getCurrentPosition(onSucces, onError);
}
else{
    alert("Cannot get your location details.")
}
// Write your JavaScript code.

function onSucces(position){
    lattitude = (position.coords.latitude);
    longtitude = (position.coords.longitude);
    
    initMap()
}
function onError(error){
    if(error.code == 1){
        alert("location services disable")
    }
    else{
        alert("Bug has been happened")
    }
}

let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {center: {lat:lattitude, lng:longtitude}, zoom:20});
    const marker = new google.maps.Marker({position:{lat:lattitude, lng:longtitude} , map:map, });
}


