---
title: Converti le presentazioni PowerPoint in SWF Flash in Python
linktitle: PowerPoint a SWF Flash
type: docs
weight: 80
url: /it/python-net/convert-powerpoint-to-swf-flash/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- PowerPoint in SWF
- presentazione in SWF
- diapositiva in SWF
- PPT in SWF
- PPTX in SWF
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Converti PowerPoint (PPT/PPTX) in SWF Flash in Python con Aspose.Slides. Esempi di codice passo-passo, output veloce e di alta qualità, senza automazione di PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in SWF utilizzando Aspose.Slides. Mostra come salvare una presentazione come file SWF con il metodo [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) e come configurare l'esportazione con [SwfOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/swfoptions/), includendo le impostazioni del visualizzatore e il layout di note o commenti.

## **Converti le presentazioni in Flash**

Il metodo [save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) può essere utilizzato per convertire l'intera presentazione in un documento SWF. Puoi anche includere commenti nello SWF generato utilizzando la classe [SWFOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/swfoptions/) e la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/). L'esempio seguente mostra come convertire una presentazione in un documento SWF usando le opzioni fornite dalla classe SWFOptions.

```py
import aspose.slides as slides

# Istanzia un oggetto Presentation che rappresenta un file di presentazione
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Salvataggio della presentazione e delle pagine delle note
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **FAQ**

**Posso includere diapositive nascoste nello SWF?**

Sì. Abilita l'opzione [show_hidden_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) in [SwfOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/swfoptions/). Per impostazione predefinita, le diapositive nascoste non vengono esportate.

**Come posso controllare la compressione e la dimensione finale dello SWF?**

Usa il flag [compressed](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/swfoptions/compressed/) (abilitato per impostazione predefinita) e regola [jpeg_quality](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/swfoptions/jpeg_quality/) per bilanciare la dimensione del file e la fedeltà dell'immagine.

**A cosa serve 'viewer_included' e quando dovrei disabilitarlo?**

[viewer_included](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/swfoptions/viewer_included/) aggiunge un'interfaccia player incorporata (controlli di navigazione, pannelli, ricerca). Disabilitalo se prevedi di utilizzare un tuo player o hai bisogno di un frame SWF minimale senza UI.

**Cosa succede se un font sorgente manca sulla macchina di esportazione?**

Aspose.Slides sostituirà il font specificato tramite [default_regular_font](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/swfoptions/default_regular_font/) in [SwfOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/swfoptions/) per evitare un fallback non desiderato.