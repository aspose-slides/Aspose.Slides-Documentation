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
- föreläsarnoter
- PDF med anteckningar
- .NET
- C#
- Aspose.Slides
description: "Konvertera formaten PPT och PPTX till PDF med anteckningar med Aspose.Slides för .NET. Bevara layouter och föreläsarnoter för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint‑presentationer till PDF‑format med föreläsarnoter med hjälp av Aspose.Slides. Denna guide kommer att täcka de nödvändiga stegen och ge kodexempel för att hjälpa dig att utföra uppgiften effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint‑bilder till PDF‑dokument samtidigt som föreläsarnoterna bevaras.
- Anpassa den resulterande PDF‑filen för att säkerställa att föreläsarnoterna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med anteckningar**

`Save`‑metoden i [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-klassen kan användas för att konvertera en PPT‑ eller PPTX‑presentation till en PDF med föreläsarnoter. Med Aspose.Slides laddar du helt enkelt presentationen, konfigurerar layoutalternativen med hjälp av [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notescommentslayoutingoptions/)-klassen för att inkludera föreläsarnoter och sparar sedan filen som en PDF. Följande kodexempel visar hur du konverterar en exempelpresentation till en PDF i anteckningssida‑vy.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Konfigurera PDF-alternativ för rendering av föreläsarnoter.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Rendera föreläsarnoter under bilden.
        }
    };

    // Spara presentationen till PDF med föreläsarnoter.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Du kanske vill kolla in Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion). 
{{% /alert %}}