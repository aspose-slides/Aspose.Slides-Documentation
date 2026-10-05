---
title: Converti presentazioni in HTML5 in JavaScript
linktitle: Presentazione in HTML5
type: docs
weight: 40
url: /it/nodejs-java/export-to-html5/
keywords:
- PowerPoint in HTML5
- OpenDocument in HTML5
- presentazione in HTML5
- diapositiva in HTML5
- PPT in HTML5
- PPTX in HTML5
- ODP in HTML5
- salva PPT come HTML5
- salva PPTX come HTML5
- salva ODP come HTML5
- esporta PPT in HTML5
- esporta PPTX in HTML5
- esporta ODP in HTML5
- Node.js
- JavaScript
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 reattivo con Aspose.Slides per Node.js. Mantieni formattazione, animazioni e interattività."
---
## **Panoramica**

Questo articolo spiega come convertire presentazioni PowerPoint in HTML5 utilizzando Aspose.Slides per Node.js tramite Java. Copre l'esportazione di base, il controllo delle animazioni delle forme e delle transizioni delle diapositive, e il layout dei commenti. Confronta inoltre l'output HTML5 con l'output basato su SVG dell'esportazione HTML standard.

## **Esporta PowerPoint in HTML5**

L'esempio seguente carica una presentazione dalla directory di lavoro e la salva nel formato HTML5. Utilizza le impostazioni di esportazione predefinite; l'esempio successivo mostra come controllare esplicitamente la riproduzione delle animazioni. Sostituire il percorso di input con il percorso della propria presentazione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Oltre al documento HTML, l'esportazione scrive file CSS e JavaScript di supporto per lo stile delle diapositive, le animazioni, gli effetti e la navigazione. Conservare questi file con il documento HTML quando si sposta o si pubblica l'output. La pagina generata carica anche jQuery e Anime.js da CDN pubblici; senza di essi, la navigazione delle diapositive e le animazioni non funzionano.
{{% /alert %}}

Per esportare senza riprodurre le animazioni delle forme o le transizioni delle diapositive, passare `false` a [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) e [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) in [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Queste impostazioni sono indipendenti, quindi è possibile abilitarne una e disabilitarne l'altra. L'esempio esporta la presentazione con entrambi i tipi di animazione disabilitati nella pagina generata.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Esporta PowerPoint in HTML**

L'esportazione HTML standard utilizza un approccio di rendering diverso: il contenuto delle diapositive è rappresentato da SVG all'interno di una pagina HTML. L'esempio seguente converte una presentazione in un documento HTML utilizzando questo approccio di rendering.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Il markup semplificato di seguito illustra la struttura della pagina generata. L'elemento SVG contiene il contenuto della diapositiva renderizzato; il testo segnaposto rappresenta quel contenuto e non è l'output letterale dell'esportazione.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
L'esportazione basata su SVG non espone le forme PowerPoint come singoli elementi HTML. Utilizzare l'esportazione HTML5 quando sono necessarie le opzioni di animazione delle forme e di transizione delle diapositive illustrate in questo articolo.
{{% /alert %}}

## **Esporta PowerPoint in Visualizzazione Diapositiva HTML5**

L'esportazione HTML5 produce una pagina per visualizzare e navigare le diapositive della presentazione in un browser. Questo esempio abilita sia [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) sia [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) affinché la visualizzazione della diapositiva esportata possa riprodurre gli effetti della presentazione originale.

Utilizzare una presentazione che contenga già animazioni delle forme e transizioni delle diapositive per vedere l'effetto di queste impostazioni. Abilitandole non si aggiungono nuovi effetti alle diapositive che ne sono prive. Dopo l'esportazione, aprire il documento HTML5 generato in un browser con i relativi file di supporto disponibili.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Converti una Presentazione in un Documento HTML5 con Commenti**

È possibile includere i commenti delle diapositive esistenti nell'output HTML5 in modo che i lettori possano vedere i feedback accanto al contenuto della diapositiva. L'esempio in questa sezione si aspetta che la presentazione di origine contenga commenti, come illustrato di seguito. Esporta quei commenti; non crea nuovi commenti.

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Passare un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) al metodo [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) di [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Utilizzare [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) per selezionare `Right` dalla enumerazione [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) al fine di posizionare i commenti a destra di ogni diapositiva.

L'esempio seguente esporta la presentazione in HTML5 con questo layout dei commenti. Una presentazione senza commenti non avrà alcun testo di commento da visualizzare.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

L'immagine seguente mostra il documento HTML5 esportato con i commenti visualizzati accanto alla diapositiva.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **Escludi Iperlink JavaScript Durante l'Esportazione**

Supponiamo che `hyperlinks.pptx` contenga testo collegato con un target `javascript:alert('Hello')` e un normale link `https://example.com/`. Per escludere l'iperlink JavaScript durante l'esportazione, passare `true` a [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Il valore predefinito è `false`, quindi questi link non vengono filtrati a meno che non si attivi l'opzione.

L'esempio seguente carica la presentazione dalla directory di lavoro e la esporta utilizzando [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Il file esportato omette l'iperlink JavaScript mantenendo il suo testo e il normale link HTTPS. La presentazione di origine rimane invariata.

Questa opzione filtra gli iperlink JavaScript; non rimuove tutti gli script o altri contenuti attivi, né garantisce la conformità CSP. Ad esempio, l'output HTML5 include ancora script per la navigazione delle diapositive e le animazioni.

## **FAQ**

**Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?**

Sì, l'esportazione HTML5 fornisce opzioni separate per abilitare o disabilitare le [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) e le [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**I commenti sono supportati e dove possono essere posizionati rispetto alla diapositiva?**

Sì, i commenti esistenti possono essere inclusi nell'output HTML5 e posizionati (ad esempio, a destra della diapositiva) tramite le [impostazioni di layout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) per note e commenti.

**Posso ignorare i link che invocano JavaScript per motivi di sicurezza o CSP?**

Sì, il [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) consente di saltare gli iperlink con chiamate JavaScript durante il salvataggio. Il valore predefinito è `false`. Vedi [Escludi Iperlink JavaScript Durante l'Esportazione](/slides/it/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) per un esempio di esportazione HTML5 e l'ambito del filtro. Questa impostazione non rimuove il JavaScript utilizzato dal visualizzatore HTML5 per la navigazione e le animazioni.