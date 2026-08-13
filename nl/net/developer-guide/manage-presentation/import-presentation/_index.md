---
title: Importeer presentaties vanuit PDF of HTML in .NET
linktitle: Importer presentatie
type: docs
weight: 60
url: /nl/net/import-presentation/
keywords:
- importeer presentatie
- importeer dia
- importeer PDF
- importeer HTML
- PDF naar presentatie
- PDF naar PPT
- PDF naar PPTX
- PDF naar ODP
- HTML naar presentatie
- HTML naar PPT
- HTML naar PPTX
- HTML naar ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Importeer moeiteloos PDF- en HTML-documenten naar PowerPoint- en OpenDocument-presentaties in .NET met Aspose.Slides voor een naadloze, hoogwaardige dia-verwerking."
---
## **Inleiding**

Met Aspose.Slides kunt u presentaties importeren vanuit bestanden in andere formaten. Aspose.Slides biedt de [SlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/slidecollection/) klasse, die het mogelijk maakt presentaties te importeren vanuit PDF‑ en HTML‑documenten.

## **Importeer PowerPoint vanuit PDF**

In dit geval converteert u een PDF naar een PowerPoint‑presentatie.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.  
2. Roep de [AddFromPdf](https://reference.aspose.com/slides/nl/net/aspose.slides.slidecollection/addfrompdf/methods/1) methode aan en geef het PDF‑bestand door.  
3. Gebruik de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides.presentation/save/methods/5) methode om het bestand op te slaan in PowerPoint‑formaat.

Deze C#‑code toont de PDF‑naar‑PowerPoint‑operatie:

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

U kunt de **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/nl/import/pdf-to-powerpoint) web‑app bekijken, want die biedt een live‑implementatie van het hier beschreven proces. 

{{% /alert %}} 

## **Importeer PowerPoint vanuit HTML**

In dit geval converteert u een HTML‑document naar een PowerPoint‑presentatie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.  
2. Roep de [AddFromHtml](https://reference.aspose.com/slides/nl/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) methode aan en geef het HTML‑bestand door.  
3. Gebruik de [Save](https://apireference.aspose.com/slides/nl/net/aspose.slides.presentation/save/methods/5) methode om het bestand op te slaan als een PowerPoint‑document.

Deze C#‑code toont de HTML‑naar‑PowerPoint‑operatie: 

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

### Worden tabellen behouden bij het importeren van een PDF, en kan hun detectie worden verbeterd?

Tabellen kunnen tijdens het importeren worden gedetecteerd; [PdfImportOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.import/pdfimportoptions/) bevat een [DetectTables](https://reference.aspose.com/slides/nl/net/aspose.slides.import/pdfimportoptions/detecttables/)‑parameter die tabelherkenning inschakelt. De effectiviteit hangt af van de structuur van de PDF.

{{% alert title="Note" color="warning" %}} 

U kunt bovendien Aspose.Slides gebruiken om HTML naar andere populaire bestandsformaten te converteren: 

* [HTML to image](https://products.aspose.com/slides/nl/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/nl/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/nl/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/nl/net/conversion/html-to-tiff/)

{{% /alert %}}