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
function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 12,
        center: { lat: lattitude, lng: longtitude }, 
    });

    // Fetch ChargerLocation data from the server
    fetch('/Controller/ChargerLocations')
        .then(response => response.json())
        .then(data => {
            // Process the data and create markers
            data.forEach(location => {
                if (location.OccupationStatus === 0) {
                    const marker = new google.maps.Marker({
                        position: { lat: location.Latitude, lng: location.Longitude },
                        map: map,
                        title: "OccupationStatus: 0",
                    });
                }
            });
        })
        .catch(error => {
            console.error("Error fetching charger locations:", error);
        });
}
