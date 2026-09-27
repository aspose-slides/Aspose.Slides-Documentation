---
title: Aspose.Slides per Node.js tramite Java
second_title: Aspose.Slides per Node.js
type: docs
weight: 47
url: /it/nodejs-java/
keywords:
- documentazione
- elaborazione presentazioni
- conversione presentazioni
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per Node.js tramite Java, crea una prima presentazione e trova le guide per le attività comuni, il riferimento API e il supporto."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides per Node.js tramite Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides per Node.js tramite Java è una libreria per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument in applicazioni Node.js, senza Microsoft PowerPoint.

Carica e salva file PPT, PPTX, PPS, POT e ODP, comprese le varianti con macro e modello, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>INIZIARE</p>
<ul>
<li><a href="/slides/it/nodejs-java/installation/">Installazione</a></li>
<li><a href="/slides/it/nodejs-java/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/nodejs-java/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTARE</p>
<ul>
<li><a href="/slides/it/nodejs-java/supported-file-formats/">Formati di file supportati</a></li>
<li><a href="/slides/it/nodejs-java/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/nodejs-java/licensing/">Licenze</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Costruisci con Slides</b></p>
<hr>
<p>COMPITI COMUNI</p>
<ul>
<li><a href="/slides/it/nodejs-java/open-presentation/">Apri una presentazione</a></li>
<li><a href="/slides/it/nodejs-java/save-presentation/">Salva una presentazione</a></li>
<li><a href="/slides/it/nodejs-java/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/nodejs-java/convert-slide/">Renderizza diapositive come immagini</a></li>
<li><a href="/slides/it/nodejs-java/manage-text/">Modifica testo e forme</a></li>
</ul>
<p>FLUSSI DI LAVORO DI SLIDES</p>
<ul>
<li><a href="/slides/it/nodejs-java/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/nodejs-java/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/nodejs-java/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/nodejs-java/presentation-design/">Design delle diapositive</a></li>
<li><a href="/slides/it/nodejs-java/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/nodejs-java/examples/">Esempi per elemento della diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento &amp; Supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/it/nodejs-java/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/it/nodejs-java/release-notes/">Note di rilascio</a></li>
<li><a href="/slides/it/nodejs-java/known-issues/">Problemi noti</a></li>
<li><a href="https://releases.aspose.com/slides/it/nodejs-java/">Download</a></li>
</ul>
<p>SUPPORTO</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/it/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

## **La tua prima presentazione**

Oltre a Node.js 20 o versioni successive, il pacchetto richiede un Java Development Kit (JDK), Python e un toolchain di compilazione C++, perché npm compila il suo bridge `java` durante l'installazione. Vedi [Installazione](/slides/it/nodejs-java/installation/) per i passaggi su ogni sistema operativo. Quindi crea un progetto e installa il pacchetto da npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Salva questo codice come *hello.js* nella cartella del progetto:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides gira in una macchina virtuale Java che mantiene Node.js in esecuzione, quindi termina esplicitamente il processo.
process.exit(0);
```

Eseguilo con `node hello.js`. Lo script salva *hello.pptx* con una diapositiva contenente una casella di testo. Senza licenza, il file salvato contiene un marchio di valutazione — vedi [Licenze](/slides/it/nodejs-java/licensing/). Per ulteriori modi di creare e popolare una presentazione, vedi [Crea Presentazioni](/slides/it/nodejs-java/create-presentation/).