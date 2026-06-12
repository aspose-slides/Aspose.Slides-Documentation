---
title: Converti le presentazioni PowerPoint in SWF Flash in PHP
linktitle: PowerPoint in SWF
type: docs
weight: 80
url: /it/php-java/convert-powerpoint-to-swf-flash/
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
- PHP
- Aspose.Slides
description: "Converti PowerPoint (PPT/PPTX) in SWF Flash con PHP e Aspose.Slides. Esempi di codice passo‑passo, output veloce e di qualità, senza automazione di PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in SWF utilizzando Aspose.Slides. Mostra come salvare una presentazione come file SWF con il metodo [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/save/) e come configurare l'esportazione con [SwfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/swfoptions/), includendo le impostazioni del visualizzatore e il layout di note o commenti.

## **Converti le presentazioni in Flash**

Il metodo [save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/save/) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) può essere usato per convertire l'intera presentazione in un documento **SWF**. L'esempio seguente mostra come convertire una presentazione in un documento **SWF** utilizzando le opzioni fornite dalla classe [SWFOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/swfoptions/). È anche possibile includere i commenti nello SWF generato usando la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Salvataggio della presentazione
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso includere le diapositive nascoste nello SWF?**

Sì. Abilita le diapositive nascoste utilizzando il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/swfoptions/setshowhiddenslides/) nella classe [SwfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/swfoptions/). Per impostazione predefinita, le diapositive nascoste non vengono esportate.

**Come posso controllare la compressione e la dimensione finale dello SWF?**

Usa il metodo [setCompressed](https://reference.aspose.com/slides/it/php-java/aspose.slides/swfoptions/setcompressed/) e [adjust JPEG quality](https://reference.aspose.com/slides/it/php-java/aspose.slides/swfoptions/setjpegquality/) per bilanciare la dimensione del file e la fedeltà delle immagini.

**A cosa serve 'setViewerIncluded' e quando dovrei disabilitarlo?**

[setViewerIncluded](https://reference.aspose.com/slides/it/php-java/aspose.slides/swfoptions/setviewerincluded/) aggiunge un'interfaccia utente del lettore incorporata (controlli di navigazione, pannelli, ricerca). Disabilitalo se prevedi di utilizzare un lettore personalizzato o se hai bisogno di un semplice frame SWF senza UI.

**Cosa succede se un carattere sorgente è mancante sulla macchina di esportazione?**

Aspose.Slides sostituirà il carattere che specifichi tramite [setDefaultRegularFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [SwfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/swfoptions/) per evitare un fallback non intenzionale.