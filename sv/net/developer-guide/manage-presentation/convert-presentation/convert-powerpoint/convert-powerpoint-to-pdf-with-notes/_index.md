---
title: Konvertera PowerPoint-presentationer till PDF med anteckningar i .NET
linktitle: PowerPoint till PDF med anteckningar
type: docs
weight: 50
url: /sv/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PDF
- presentation till PDF
- bild till PDF
- PPT till PDF
- PPTX till PDF
- spara presentation som PDF
- spara PPT som PDF
- spara PPTX som PDF
- exportera PPT till PDF
- exportera PPTX till PDF
- talarnoter
- PDF med anteckningar
- .NET
- C#
- Aspose.Slides
description: "Konvertera format PPT och PPTX till PDF med anteckningar med hjälp av Aspose.Slides för .NET. Bevara layouter och talarnoter för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med talarnoter med hjälp av Aspose.Slides. Den här guiden täcker de nödvändiga stegen och ger kodexempel för att hjälpa dig att utföra uppgiften effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som talarnoter bevaras.
- Anpassa den exporterade PDF-filen så att talarnoterna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med anteckningar**

`Save`-metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) kan användas för att konvertera en PPT- eller PPTX-presentation till en PDF med talarnoter. Med Aspose.Slides laddar du bara presentationen, konfigurerar layoutalternativen med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notescommentslayoutingoptions/) för att inkludera talarnoter och sparar sedan filen som en PDF. Följande kodexempel visar hur du konverterar en exempelpresentation till en PDF i anteckningssidor-vyn.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Konfigurera PDF-alternativ för att rendera talarnoter.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Rendera talarnoter under bilden.
        }
    };

    // Spara presentationen till PDF med talarnoter.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
Du kanske vill kolla in Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion). 
{{% /alert %}}