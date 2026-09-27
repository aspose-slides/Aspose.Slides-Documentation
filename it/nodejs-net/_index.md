---
title: Aspose.Slides per Node.js via .NET
second_title: Aspose.Slides per Node.js
type: docs
weight: 47
url: /it/nodejs-net/
keywords:
- documentazione
- elaborazione delle presentazioni
- conversione delle presentazioni
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per Node.js via .NET, crea una prima presentazione e trova le guide per attività comuni, licenze, riferimento API e supporto."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides per Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides per Node.js via .NET è una libreria per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument in applicazioni Node.js, senza Microsoft PowerPoint o Office Automation. Esegue Aspose.Slides per .NET tramite il bridge edge‑js, quindi la sua API JavaScript replica l'API .NET, con nomi dei membri in camelCase.

Carica e salva PPT, PPTX, PPS, POT e ODP, incluse le varianti con macro e i modelli, ed esporta in PDF, XPS, HTML, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>PRIMI PASSI</p>
<ul>
<li><a href="/slides/it/nodejs-net/installation/">Installazione</a></li>
<li><a href="/slides/it/nodejs-net/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/nodejs-net/developer-guide/">Guida per sviluppatori</a></li>
</ul>
<p>VALUTA</p>
<ul>
<li><a href="/slides/it/nodejs-net/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/nodejs-net/licensing/">Licenza</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>ATTIVITÀ COMUNI</p>
<ul>
<li><a href="/slides/it/nodejs-net/open-presentation/">Apri e salva una presentazione</a></li>
<li><a href="/slides/it/nodejs-net/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/nodejs-net/convert-slide/">Renderizza le diapositive come immagini</a></li>
<li><a href="/slides/it/nodejs-net/manage-text/">Modifica testo</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento e Supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Riferimento API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Note di rilascio</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Download</a></li>
</ul>
<p>SUPPORTO</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

## **La tua prima presentazione**

Hai bisogno di Node.js 22 o 24 e del .NET SDK 8 o successivo; Linux richiede anche alcuni pacchetti di sistema. [Installation](/slides/it/nodejs-net/installation/) elenca tutto e le piattaforme testate. Crea un progetto, aggiungi un override che indica a npm quale versione di edge‑js installare e installa il pacchetto:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Una volta per macchina, ripristina i pacchetti .NET da cui dipende la libreria. Salva il file `deps.csproj` da [Restore the .NET Dependencies](/slides/it/nodejs-net/installation/#restore-the-net-dependencies) in una cartella `deps` all'interno della cartella del progetto, quindi esegui:

```sh
dotnet restore deps/deps.csproj
```

Salva questo codice come *hello.js* nella cartella del progetto:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Una nuova presentazione contiene una diapositiva vuota.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La posizione e le dimensioni sono in punti (1/72 di pollice): x, y, larghezza, altezza.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Rilascia l'oggetto .NET che supporta la presentazione.
    presentation.dispose();
}
```

Eseguilo dalla cartella del progetto:

```sh
node hello.js
```

Lo script stampa `Saved hello.pptx` e salva *hello.pptx* con una diapositiva contenente un rettangolo con il testo. Senza licenza, il file salvato contiene un marchio di valutazione — vedi [Licensing](/slides/it/nodejs-net/licensing/). Per altri modi di creare e compilare una presentazione, vedi [Create a Presentation](/slides/it/nodejs-net/create-presentation/).