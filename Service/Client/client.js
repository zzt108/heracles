const app = document.getElementById('root');

function UserGetAction() {
        var xhttp = new XMLHttpRequest();
        xhttp.open("GET", "http://localhost:8080/tax/vilnius/2016/1/1", true);
        xhttp.setRequestHeader("Content-type", "application/json");
        xhttp.onload = function () {

        // Begin accessing JSON data here
        var data = JSON.parse(this.response);
        if (xhttp.status >= 200 && xhttp.status < 400) {
            const card = document.createElement('div');

            const h1 = document.createElement('h1');
            h1.textContent = 'Result';

            const p = document.createElement('p');
            p.textContent = `${data}...`;

            container.appendChild(card);
            card.appendChild(h1);
            card.appendChild(p);
        } else {
            const errorMessage = document.createElement('marquee');
            errorMessage.textContent = `Gah, it's not working!`;
            app.appendChild(errorMessage);
        }
        }
        xhttp.onerror = function(){
        const errorMessage = document.createElement('marquee');
        errorMessage.textContent = `Gah, No API`;
        app.appendChild(errorMessage);
        }
        xhttp.send();

}
