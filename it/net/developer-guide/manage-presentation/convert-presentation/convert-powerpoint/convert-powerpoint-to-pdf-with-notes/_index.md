---
title: Converti presentazioni PowerPoint in PDF con note in .NET
linktitle: PowerPoint in PDF con note
type: docs
weight: 50
url: /it/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in PDF
- presentazione in PDF
- diapositiva in PDF
- PPT in PDF
- PPTX in PDF
- salva presentazione come PDF
- salva PPT come PDF
- salva PPTX come PDF
- esporta PPT in PDF
- esporta PPTX in PDF
- note del relatore
- PDF con note
- .NET
- C#
- Aspose.Slides
description: "Converti i formati PPT e PPTX in PDF con note usando Aspose.Slides per .NET. Conserva layout e note del relatore per presentazioni professionali."
---
## **Panoramica**

In questo articolo imparerai a convertire le presentazioni PowerPoint in formato PDF con le note del relatore utilizzando Aspose.Slides. Questa guida coprirà i passaggi necessari e fornirà esempi di codice per aiutarti a svolgere questa attività in modo efficiente. Alla fine di questo articolo sarai in grado di:

- Implementare il processo di conversione per trasformare le diapositive PowerPoint in documenti PDF preservando le note del relatore.
- Personalizzare il PDF di output per garantire che le note del relatore siano incluse e formattate secondo le proprie esigenze.

## **Convertire PowerPoint in PDF con le note**

Il metodo `Save` nella classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) può essere utilizzato per convertire una presentazione PPT o PPTX in un PDF con le note del relatore. Con Aspose.Slides, devi semplicemente caricare la presentazione, configurare le opzioni di layout utilizzando la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/notescommentslayoutingoptions/) per includere le note del relatore, quindi salvare il file come PDF. Il frammento di codice seguente dimostra come convertire una presentazione di esempio in un PDF nella visualizzazione Note diapositiva.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Configura le opzioni PDF per il rendering delle note del relatore.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Renderizza le note del relatore sotto la diapositiva.
        }
    };

    // Salva la presentazione in PDF con le note del relatore.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 

Potresti voler dare un'occhiata al [Convertitore online PowerPoint in PDF](https://products.aspose.app/slides/it/conversion) di Aspose. 

{{% /alert %}}