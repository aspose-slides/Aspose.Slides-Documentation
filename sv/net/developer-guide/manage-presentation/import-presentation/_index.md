---
title: Importera presentationer från PDF eller HTML i .NET
linktitle: Importera presentation
type: docs
weight: 60
url: /sv/net/import-presentation/
keywords:
- importera presentation
- importera bild
- importera PDF
- importera HTML
- PDF till presentation
- PDF till PPT
- PDF till PPTX
- PDF till ODP
- HTML till presentation
- HTML till PPT
- HTML till PPTX
- HTML till ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Importera PDF- och HTML-dokument enkelt till PowerPoint- och OpenDocument-presentationer i .NET med Aspose.Slides för sömlös, högpresterande bildbehandling."
---
## **Introduktion**

Med Aspose.Slides kan du importera presentationer från filer i andra format. Aspose.Slides tillhandahåller klassen [SlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/slidecollection/) som gör att du kan importera presentationer från PDF- och HTML-dokument.

## **Importera PowerPoint från PDF**

I det här fallet konverterar du en PDF till en PowerPoint-presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen. 
2. Anropa metoden [AddFromPdf](https://reference.aspose.com/slides/sv/net/aspose.slides.slidecollection/addfrompdf/methods/1) och skicka PDF‑filen. 
3. Använd [Save](https://reference.aspose.com/slides/sv/net/aspose.slides.presentation/save/methods/5)‑metoden för att spara filen i PowerPoint‑format.

Den här C#‑koden demonstrerar PDF‑till‑PowerPoint‑operationen:

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

Du kanske vill kolla in **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint)‑webbapp eftersom den är en levande implementering av processen som beskrivs här. 

{{% /alert %}} 

## **Importera PowerPoint från HTML**

I det här fallet konverterar du ett HTML‑dokument till en PowerPoint-presentation.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen. 
2. Anropa metoden [AddFromHtml](https://reference.aspose.com/slides/sv/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) och skicka HTML‑filen. 
3. Använd [Save](https://apireference.aspose.com/slides/sv/net/aspose.slides.presentation/save/methods/5)‑metoden för att spara filen som ett PowerPoint‑dokument.

Den här C#‑koden demonstrerar HTML‑till‑PowerPoint‑operationen: 

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

## **Vanliga frågor**

### Behålls tabeller när man importerar en PDF, och kan deras detektering förbättras?

Tabeller kan upptäckas under import; [PdfImportOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.import/pdfimportoptions/) innehåller en [DetectTables](https://reference.aspose.com/slides/sv/net/aspose.slides.import/pdfimportoptions/detecttables/)‑parameter som möjliggör tabelligenkänning. Effektiviteten beror på PDF:ens struktur.

{{% alert title="Note" color="warning" %}} 

Du kan även använda Aspose.Slides för att konvertera HTML till andra populära filformat: 

* [HTML till bild](https://products.aspose.com/slides/sv/net/conversion/html-to-image/)
* [HTML till JPG](https://products.aspose.com/slides/sv/net/conversion/html-to-jpg/)
* [HTML till XML](https://products.aspose.com/slides/sv/net/conversion/html-to-xml/)
* [HTML till TIFF](https://products.aspose.com/slides/sv/net/conversion/html-to-tiff/)

{{% /alert %}}