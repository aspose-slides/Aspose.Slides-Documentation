---
title: Converti presentazioni PowerPoint in SWF Flash con JavaScript
linktitle: PowerPoint a SWF
type: docs
weight: 80
url: /it/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint a SWF
- presentazione a SWF
- diapositiva a SWF
- PPT a SWF
- PPTX a SWF
- PowerPoint a Flash
- presentazione a Flash
- diapositiva a Flash
- PPT a Flash
- PPTX a Flash
- salva PPT come SWF
- salva PPTX come SWF
- esporta PPT in SWF
- esporta PPTX in SWF
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti PowerPoint (PPT/PPTX) in SWF Flash con Aspose.Slides per Node.js. Esempi di codice passo a passo, output di alta qualità e veloce, senza automazione di PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire presentazioni PowerPoint in SWF utilizzando Aspose.Slides. Mostra come salvare una presentazione come file SWF con il metodo [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) e come configurare l'esportazione con [SwfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/swfoptions/), incluse le impostazioni del visualizzatore e il layout di note o commenti.

## **Converti PPT(X) in SWF**
Il metodo [save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) può essere utilizzato per convertire l'intera presentazione in un documento **SWF**. L'esempio seguente mostra come convertire una presentazione in documento **SWF** usando le opzioni fornite dalla classe [**SWFOptions**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SwfOptions). È inoltre possibile includere i commenti nello SWF generato usando la classe [**SWFOptions**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SwfOptions) e la classe [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Salvataggio della presentazione
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso includere diapositive nascoste nello SWF?**

Sì. Usa il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) in [SwfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/swfoptions/). Per impostazione predefinita, le diapositive nascoste non vengono esportate.

**Come posso controllare la compressione e la dimensione finale dello SWF?**

Usa i metodi [setCompressed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/swfoptions/setcompressed/) e [setJpegQuality](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/swfoptions/setjpegquality/) per bilanciare la dimensione del file e la fedeltà delle immagini.

**A cosa serve 'setViewerIncluded' e quando dovrei usarlo?**

[setViewerIncluded](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) aggiunge un'interfaccia utente del lettore incorporata (controlli di navigazione, pannelli, ricerca). Usala se prevedi di utilizzare un lettore personalizzato o se ti serve un semplice frame SWF senza UI.

**Cosa succede se un carattere sorgente manca sulla macchina di esportazione?**

Aspose.Slides sostituirà il carattere specificato tramite [setDefaultRegularFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [SwfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/swfoptions/) per evitare un ricorso non previsto.