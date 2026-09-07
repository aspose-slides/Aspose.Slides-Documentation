---
title: Converti presentazioni PowerPoint in SWF Flash in Python via Java
linktitle: PowerPoint in SWF
type: docs
weight: 80
url: /it/python-java/convert-powerpoint-to-swf-flash/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
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
- Python
- Java
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in SWF Flash in Python via Java con Aspose.Slides. Configura il visualizzatore, le note, le diapositive nascoste, la compressione e i font."
---
## **Panoramica**

Aspose.Slides for Python via Java consente di convertire presentazioni PowerPoint in SWF senza Microsoft PowerPoint. Utilizza [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) per esportare la presentazione e [SwfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/swfoptions/) per configurare le impostazioni del visualizzatore, la qualità delle immagini e il layout di note o commenti.

## **Converti le presentazioni in Flash**

Carica il file di origine con [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), configura [SwfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/swfoptions/), e salvalo utilizzando [SaveFormat.Swf](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Swf).

L'esempio seguente esporta `presentation.pptx` in `presentation.swf`. Disattiva il visualizzatore incorporato con [setViewerIncluded](https://reference.aspose.com/slides/it/python-java/aspose.slides/swfoptions/#setViewerIncluded) e include le note del relatore sotto le diapositive usando [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Prima di eseguire l'esempio, [install Aspose.Slides for Python via Java](/slides/it/python-java/installation/) e posiziona `presentation.pptx` nella directory di lavoro. La JVM viene avviata una volta per processo Python.

L'esempio applica [NotesPositions.BottomFull](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/#BottomFull) tramite [setNotesPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) e passa il layout a [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Per includere anche i commenti, configura [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) prima dell'esportazione.

## **Domande frequenti**

**Posso includere diapositive nascoste nello SWF?**

Sì. Chiama [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) con `True`. Per impostazione predefinita, le diapositive nascoste non vengono esportate.

**Come posso controllare la compressione e la dimensione finale dello SWF?**

Utilizza [SwfOptions.setCompressed](https://reference.aspose.com/slides/it/python-java/aspose.slides/swfoptions/#setCompressed) per abilitare o disabilitare la compressione e [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/it/python-java/aspose.slides/swfoptions/#setJpegQuality) per regolare la qualità delle immagini JPEG. Una qualità JPEG più bassa può ridurre le dimensioni del file a scapito della fedeltà dell'immagine.

**A cosa serve il visualizzatore incorporato e quando dovrei disabilitarlo?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/it/python-java/aspose.slides/swfoptions/#setViewerIncluded) controlla se lo SWF generato include il visualizzatore. Passa `False` quando hai bisogno delle diapositive esportate senza il visualizzatore incorporato, come nell'esempio sopra.

**Cosa succede se un font di origine manca nella macchina di esportazione?**

Puoi specificare un font regolare predefinito con [setDefaultRegularFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), ereditato da [SwfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/swfoptions/). Scegli un font disponibile per il processo di esportazione; la sostituzione dei font può modificare l'aspetto del testo e il layout.