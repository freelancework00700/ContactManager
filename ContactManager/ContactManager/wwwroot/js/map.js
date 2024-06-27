function initMap() {
    // Initialize Leaflet map
    const map = L.map('map').setView([0, 0], 13); // Default center at (0, 0) with zoom level 13

    // Add OpenStreetMap tile layer
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    // Initialize geocoder with Nominatim provider
    const geocoder = L.Control.Geocoder.nominatim();

    // Function to perform geocoding
    function performGeocode(address) {
        geocoder.geocode(address, function (results) {
            if (results.length > 0) {
                const latLng = results[0].center;
                map.setView(latLng, 15); // Set map view to the geocoded location with zoom level 15

                // Clear previous markers
                map.eachLayer(function (layer) {
                    if (layer instanceof L.Marker) {
                        map.removeLayer(layer);
                    }
                });

                // Add marker to the map
                L.marker(latLng).addTo(map)
                    .bindPopup(address)
                    .openPopup();
            }
        });
    }

    // Handle input change event (live filter)
    const addressInput = document.getElementById('Address');
    addressInput.addEventListener('input', function () {
        const address = addressInput.value.trim();
        if (address !== '') {
            performGeocode(address);
        }
    });
}

function showAddress(address) {
    // Initialize Leaflet map
    const map = L.map('map').setView([0, 0], 13); // Default center at (0, 0) with zoom level 13

    // Add OpenStreetMap tile layer
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    // Initialize geocoder with Nominatim provider
    const geocoder = L.Control.Geocoder.nominatim();

    // Perform geocoding
    geocoder.geocode(address, function (results) {
        if (results.length > 0) {
            const latLng = results[0].center;
            map.setView(latLng, 15); // Set map view to the geocoded location with zoom level 15

            // Clear previous markers
            map.eachLayer(function (layer) {
                if (layer instanceof L.Marker) {
                    map.removeLayer(layer);
                }
            });

            // Add marker to the map
            L.marker(latLng).addTo(map)
                .bindPopup(address)
                .openPopup();
        } else {
            alert('Address not found: ' + address);
        }
    });
}
