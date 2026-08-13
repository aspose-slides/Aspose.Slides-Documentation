---
title: Importa presentazioni da PDF o HTML in .NET
linktitle: Importa presentazione
type: docs
weight: 60
url: /it/net/import-presentation/
keywords:
- importare presentazione
- importare diapositiva
- importare PDF
- importare HTML
- PDF a presentazione
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentazione
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Importa facilmente documenti PDF e HTML in presentazioni PowerPoint e OpenDocument in .NET con Aspose.Slides per una elaborazione diapositive fluida e ad alte prestazioni."
---
## **Introduzione**

Utilizzando Aspose.Slides, è possibile importare presentazioni da file in altri formati. Aspose.Slides fornisce la classe [SlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/slidecollection/) che consente di importare presentazioni da documenti PDF e HTML.

## **Importa PowerPoint da PDF**

In questo caso, si tratta di convertire un PDF in una presentazione PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). 
2. Chiamare il metodo [AddFromPdf](https://reference.aspose.com/slides/it/net/aspose.slides.slidecollection/addfrompdf/methods/1) e passare il file PDF. 
3. Utilizzare il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides.presentation/save/methods/5) per salvare il file nel formato PowerPoint.

Questo codice C# dimostra l'operazione di conversione da PDF a PowerPoint:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 
Potresti voler provare l'app Web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/it/import/pdf-to-powerpoint) perché è un'implementazione live del processo descritto qui. 
{{% /alert %}} 

## **Importa PowerPoint da HTML**

In questo caso, si tratta di convertire un documento HTML in una presentazione PowerPoint.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) . 
2. Chiamare il metodo [AddFromHtml](https://reference.aspose.com/slides/it/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) e passare il file HTML. 
3. Utilizzare il metodo [Save](https://apireference.aspose.com/slides/it/net/aspose.slides.presentation/save/methods/5) per salvare il file come documento PowerPoint.

Questo codice C# dimostra l'operazione di conversione da HTML a PowerPoint: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Le tabelle vengono conservate durante l'importazione di un PDF e la loro rilevazione può essere migliorata?

Le tabelle possono essere rilevate durante l'importazione; [PdfImportOptions](https://reference.aspose.com/slides/it/net/aspose.slides.import/pdfimportoptions/) include un parametro [DetectTables](https://reference.aspose.com/slides/it/net/aspose.slides.import/pdfimportoptions/detecttables/) che abilita il riconoscimento delle tabelle. L'efficacia dipende dalla struttura del PDF.

{{% alert title="Note" color="warning" %}} 
Puoi anche usare Aspose.Slides per convertire HTML in altri formati di file popolari: 

* [HTML to image](https://products.aspose.com/slides/it/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/it/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/it/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/it/net/conversion/html-to-tiff/)

{{% /alert %}}