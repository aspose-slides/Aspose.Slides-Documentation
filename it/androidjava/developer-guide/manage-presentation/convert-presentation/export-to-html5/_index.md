---
title: Converti le presentazioni in HTML5 su Android
linktitle: Presentazione in HTML5
type: docs
weight: 40
url: /it/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 reattivo con Aspose.Slides per Android tramite Java. Conserva formattazione, animazioni e interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 utilizzando Aspose.Slides. Copre l’esportazione HTML5 di base senza estensioni web o dipendenze aggiuntive, nonché le opzioni per controllare le animazioni delle forme e le transizioni delle diapositive. L’articolo mostra anche il processo standard di esportazione da PowerPoint a HTML, spiega come generare output HTML5 in modalità visualizzazione slide e dimostra come includere i commenti nel documento esportato configurandone il layout.

## **Esporta PowerPoint in HTML5**

Questo codice Java mostra come esportare una presentazione in HTML5 senza estensioni web né dipendenze:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
In questo caso, ottieni HTML pulito. 
{{% /alert %}}

Puoi specificare le impostazioni per le animazioni delle forme e le transizioni delle diapositive in questo modo:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Esporta PowerPoint in HTML**

Questo Java dimostra il processo standard di esportazione da PowerPoint a HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

In questo caso, il contenuto della presentazione viene renderizzato tramite SVG in una forma simile a questa:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Quando utilizzi questo metodo per esportare PowerPoint in HTML, a causa del rendering SVG, non potrai applicare stili o animare elementi specifici. 
{{% /alert %}}

## **Esporta PowerPoint in Visualizzazione Slide HTML5**

**Aspose.Slides** consente di convertire una presentazione PowerPoint in un documento HTML5 in cui le diapositive sono presentate in modalità visualizzazione slide. In questo caso, quando apri il file HTML5 risultante in un browser, visualizzi la presentazione in modalità visualizzazione slide su una pagina web. 

Questo codice Java dimostra il processo di esportazione da PowerPoint a Visualizzazione Slide HTML5:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Converti una Presentazione in un Documento HTML5 con Commenti**

I commenti in PowerPoint sono uno strumento che permette agli utenti di lasciare note o feedback sulle diapositive della presentazione. Sono particolarmente utili nei progetti collaborativi, dove più persone possono aggiungere suggerimenti o osservazioni a elementi specifici delle diapositive senza modificare il contenuto principale. Ogni commento mostra il nome dell’autore, facilitando l’individuazione di chi ha lasciato l’osservazione.

Supponiamo di avere la seguente presentazione PowerPoint salvata nel file "sample.pptx".

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Quando converti una presentazione PowerPoint in un documento HTML5, puoi specificare facilmente se includere i commenti della presentazione nel documento di output. Per farlo, devi impostare i parametri di visualizzazione dei commenti nel metodo `getNotesCommentsLayouting` della classe [Html5Options](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/html5options/).

Il seguente esempio di codice converte una presentazione in un documento HTML5 con i commenti visualizzati a destra delle diapositive.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Il documento "output.html" è mostrato nell'immagine seguente.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **FAQ**

**Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?**

Sì, HTML5 offre opzioni separate per abilitare o disabilitare le [animazioni delle forme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e le [transizioni delle diapositive](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Il supporto per l’output dei commenti è presente e dove è possibile posizionarli rispetto alla diapositiva?**

Sì, i commenti possono essere aggiunti in HTML5 e posizionati (ad esempio, a destra della diapositiva) tramite le [impostazioni di layout](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) per note e commenti.

**Posso saltare i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?**

Sì, esiste una [impostazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) che consente di ignorare i collegamenti ipertestuali con chiamate JavaScript durante il salvataggio. Questo aiuta a rispettare politiche di sicurezza rigorose.