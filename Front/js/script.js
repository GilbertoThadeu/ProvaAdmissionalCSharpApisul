function Requisicao(ordem) {

	var url = "https://localhost:5001/elevador/" + ordem;
	var xhr = new XMLHttpRequest();

	xhr.open(`GET`, url, true);

	xhr.onerror = function () {
		console.error('ERRO', xhr.readyState);
	}

	xhr.onreadystatechange = function () {
		if (this.readyState == 4) {
			if (this.status == 200) {
				var resultado = JSON.parse(this.responseText);
				if (ordem.indexOf("percentual") > -1)
					resultado = resultado + " %";
				document.getElementById(ordem).innerHTML =
					"<h4 class='card-title'>" + resultado + "</h4>";
			}
			else if (this.status == 500) {
				var erro = JSON.parse(this.responseText);
				console.log(erro.message);
				console.log(erro.exceptionMessage);
			}
		}

	}

	xhr.send();
}