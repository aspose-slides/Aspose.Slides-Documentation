---
title: Converti le presentazioni PowerPoint in SWF Flash con Java
linktitle: PowerPoint in SWF
type: docs
weight: 80
url: /it/java/convert-powerpoint-to-swf-flash/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in SWF
- presentazione in SWF
- diapositiva in SWF
- PPT in SWF
- PPTX in SWF
- PowerPoint in Flash
- presentazione in Flash
- diapositiva in Flash
- PPT in Flash
- PPTX in Flash
- salva PPT come SWF
- salva PPTX come SWF
- esporta PPT in SWF
- esporta PPTX in SWF
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Converti PowerPoint (PPT/PPTX) in SWF Flash con Java e Aspose.Slides. Esempi di codice passo‑a‑passo, output rapido e di alta qualità, senza automazione di PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in SWF utilizzando Aspose.Slides. Mostra come salvare una presentazione come file SWF con il metodo [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) e come configurare l'esportazione con [SwfOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/swfoptions/), includendo le impostazioni del visualizzatore e il layout di note o commenti.

## **Converti le presentazioni in Flash**

Il metodo [save](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) può essere usato per convertire l'intera presentazione in un documento **SWF**. L'esempio seguente mostra come convertire una presentazione in un documento **SWF** utilizzando le opzioni fornite dalla classe [**SWFOptions**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SwfOptions). È anche possibile includere commenti nello SWF generato usando la classe [**ISWFOptions**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISwfOptions) e l'interfaccia [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/it/java/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Salvataggio della presentazione
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso includere diapositive nascoste nello SWF?**

Sì. Abilita le diapositive nascoste usando il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) in [SwfOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/swfoptions/). Per impostazione predefinita, le diapositive nascoste non vengono esportate.

**Come posso controllare la compressione e la dimensione finale dello SWF?**

Usa il metodo [setCompressed](https://reference.aspose.com/slides/it/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) e [adjust JPEG quality](https://reference.aspose.com/slides/it/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) per bilanciare la dimensione del file e la fedeltà delle immagini.

**A cosa serve 'setViewerIncluded' e quando dovrei disabilitarlo?**

[setViewerIncluded](https://reference.aspose.com/slides/it/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) aggiunge un'interfaccia utente del lettore incorporata (controlli di navigazione, pannelli, ricerca). Disabilitalo se intendi usare il tuo lettore o se ti serve un SWF minimale senza UI.

**Cosa succede se un font di origine è mancante sulla macchina di esportazione?**

Aspose.Slides sostituirà il font specificato tramite [setDefaultRegularFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [SwfOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/swfoptions/) per evitare un fallback non intenzionato.