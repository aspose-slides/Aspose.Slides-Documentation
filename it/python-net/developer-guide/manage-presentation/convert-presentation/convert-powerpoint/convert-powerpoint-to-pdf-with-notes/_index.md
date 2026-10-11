---
title: Convertire le presentazioni in PDF con note in Python
linktitle: Presentazione in PDF con note
type: docs
weight: 50
url: /it/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertire PowerPoint
- convertire OpenDocument
- convertire presentazione
- convertire PPT
- convertire PPTX
- convertire ODP
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
description: "Converti i formati PPT, PPTX e ODP in PDF con note usando Aspose.Slides per Python. Conserva layout e note del relatore per presentazioni professionali."
---
## **Panoramica**

In questo articolo imparerai come convertire le presentazioni PowerPoint in formato PDF con note del relatore usando Aspose.Slides. Questa guida coprirà i passaggi necessari e fornirà esempi di codice per aiutarti a completare l'operazione in modo efficiente. Alla fine dell'articolo sarai in grado di:

- Implementare il processo di conversione per trasformare le diapositive PowerPoint in documenti PDF mantenendo le note del relatore.
- Personalizzare il PDF di output per garantire che le note del relatore siano incluse e formattate secondo le tue esigenze.

Per impostare le dimensioni e l'orientamento della pagina delle note prima dell'esportazione, consulta [Dimensione della pagina delle note](/slides/it/python-net/notes-size/).

## **Converti PowerPoint in PDF con note**

Il metodo `save` nella classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) può essere usato per convertire una presentazione PPT o PPTX in un PDF con le note del relatore. Con Aspose.Slides, basta caricare la presentazione, configurare le opzioni di layout usando la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/) per includere le note del relatore, e quindi salvare il file come PDF. Il frammento di codice seguente dimostra come convertire una presentazione di esempio in un PDF nella visualizzazione Note Slide.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Configura le opzioni PDF per il rendering delle note del relatore.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Salva la presentazione in PDF con le note del relatore.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Potresti voler provare l'[Convertitore online PowerPoint in PDF di Aspose](https://products.aspose.app/slides/it/conversion).
{{% /alert %}}