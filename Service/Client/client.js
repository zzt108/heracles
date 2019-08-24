const app = document.getElementById('root');

function UserGetAction(numberId, resultContainerId) {
    var number = document.getElementById(numberId).value;
    var xhttp = new XMLHttpRequest();
    xhttp.onload = function () {
        
        app.removeChild(document.getElementById(resultContainerId));
        const result = document.createElement('div');
        result.setAttribute('id', resultContainerId);
        
        if (xhttp.status >= 200 && xhttp.status < 400) {
            const card = document.createElement('div');
            
            const h1 = document.createElement('h1');
            h1.textContent = 'Result';
            
            const p = document.createElement('p');
            p.setAttribute('id', 'aidResult')
            p.textContent = `${this.response}`;
            
            
            
            app.appendChild(result);
            result.appendChild(card);
            card.appendChild(h1);
            card.appendChild(p);
        } else {
            const errorMessage = document.createElement('p');
            errorMessage.setAttribute('id', 'aidError')
            errorMessage.textContent = this.response;
            result.appendChild(errorMessage);
            app.appendChild(result);
        }
    }
    xhttp.onerror = function () {
        const errorMessage = document.createElement('p');
        errorMessage.textContent = `No API Error`;
        errorMessage.setAttribute('id', 'aidError')
        result.appendChild(errorMessage);
        app.appendChild(result);
    }

    xhttp.open("GET", `http://localhost:8080/format/money/${number}`, true);
    xhttp.setRequestHeader("Content-type", "*/*");
    xhttp.send();

}
