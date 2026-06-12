---
title: Convertire presentazioni in PDF con note in Python
linktitle: Presentazione in PDF con note
type: docs
weight: 50
url: /it/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- converti PPT
- converti PPTX
- converti ODP
- PowerPoint in PDF
- OpenDocument in PDF
- presentazione in PDF
- PPT in PDF
- PPTX in PDF
- ODP in PDF
- note del relatore
- PDF con note
- Python
- Aspose.Slides
description: "Converti i formati PPT, PPTX e ODP in PDF con note utilizzando Aspose.Slides per Python. Conserva layout e note del relatore per presentazioni professionali."
---
## **Panoramica**

In questo articolo imparerai come convertire le presentazioni PowerPoint in formato PDF con le note del relatore utilizzando Aspose.Slides. Questa guida coprirà i passaggi necessari e fornirà esempi di codice per aiutarti a completare questa attività in modo efficiente. Alla fine di questo articolo, sarai in grado di:

- Implementare il processo di conversione per trasformare le diapositive PowerPoint in documenti PDF preservando le note del relatore.
- Personalizzare il PDF di output per garantire che le note del relatore siano incluse e formattate secondo le tue esigenze.

## **Convertire PowerPoint in PDF con Note**

Il metodo `save` nella classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) può essere utilizzato per convertire una presentazione PPT o PPTX in un PDF con le note del relatore. Con Aspose.Slides, devi semplicemente caricare la presentazione, configurare le opzioni di layout usando la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/) per includere le note del relatore, e quindi salvare il file come PDF. Il seguente frammento di codice dimostra come convertire una presentazione di esempio in un PDF in visualizzazione Note della diapositiva.

```py
with slides.Presentation("sample.pptx") as presentation:

    # Configura le opzioni PDF per il rendering delle note del relatore.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Salva la presentazione in PDF con le note del relatore.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
Potresti voler dare un'occhiata al [Convertitore online PowerPoint in PDF di Aspose](https://products.aspose.app/slides/it/conversion). 
{{% /alert %}}