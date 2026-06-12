---
title: Converti le presentazioni PowerPoint in SWF Flash su Android
linktitle: PowerPoint in SWF
type: docs
weight: 80
url: /it/androidjava/convert-powerpoint-to-swf-flash/
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
- Android
- Java
- Aspose.Slides
description: "Converti PowerPoint (PPT/PPTX) in SWF Flash in Java con Aspose.Slides per Android. Esempi di codice passo-a-passo, output veloce di alta qualità, senza automazione di PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in SWF utilizzando Aspose.Slides. Mostra come salvare una presentazione come file SWF con il metodo [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) e come configurare l'esportazione con [SwfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/swfoptions/), inclusi le impostazioni del visualizzatore e il layout di note o commenti.

## **Convertire PPT(X) in SWF**
Il metodo [Save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) può essere utilizzato per convertire l'intera presentazione in un documento **SWF**. L'esempio seguente mostra come convertire una presentazione in un documento **SWF** utilizzando le opzioni fornite dalla classe [**SWFOptions**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SwfOptions). È inoltre possibile includere i commenti nello SWF generato usando la classe [**ISWFOptions**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISwfOptions) e l'interfaccia [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

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

**Posso includere le diapositive nascoste nello SWF?**

Sì. Abilita le diapositive nascoste usando il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) in [SwfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/swfoptions/). Per impostazione predefinita, le diapositive nascoste non vengono esportate.

**Come posso controllare la compressione e la dimensione finale dello SWF?**

Usa il metodo [setCompressed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) e [adjust JPEG quality](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) per bilanciare la dimensione del file e la fedeltà dell'immagine.

**A cosa serve 'setViewerIncluded' e quando dovrei disabilitarlo?**

[setViewerIncluded](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) aggiunge un'interfaccia utente player incorporata (controlli di navigazione, pannelli, ricerca). Disabilitalo se prevedi di usare un tuo player o se ti serve un file SWF senza UI.

**Cosa succede se un font sorgente manca sulla macchina di esportazione?**

Aspose.Slides sostituirà il font specificato tramite [setDefaultRegularFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [SwfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/swfoptions/) per evitare un fallback non intenzionale.