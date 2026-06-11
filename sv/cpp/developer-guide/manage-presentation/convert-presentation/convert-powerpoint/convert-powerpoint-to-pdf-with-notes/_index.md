---
title: Konvertera PowerPoint-presentationer till PDF med anteckningar i C++
linktitle: PowerPoint till PDF med anteckningar
type: docs
weight: 50
url: /sv/cpp/convert-powerpoint-to-pdf-with-notes/
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
- föreläsaranteckningar
- PDF med anteckningar
- C++
- Aspose.Slides
description: "Konvertera format PPT och PPTX till PDF med anteckningar med hjälp av Aspose.Slides för C++. Bevara layouter och föreläsaranteckningar för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med föreläsaranteckningar med hjälp av Aspose.Slides. Denna guide täcker de nödvändiga stegen och ger kodexempel för att du ska kunna utföra uppgiften effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som du bevarar föreläsaranteckningarna.
- Anpassa den genererade PDF-filen så att föreläsaranteckningarna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med anteckningar**

Metoden `Save` i klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) kan användas för att konvertera en PPT- eller PPTX-presentation till en PDF med föreläsaranteckningar. Med Aspose.Slides laddar du bara presentationen, konfigurerar layoutalternativen med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/) för att inkludera föreläsaranteckningar och sparar sedan filen som en PDF. Följande kodexempel visar hur du konverterar en exempelpresentation till en PDF i Anteckningssidläge.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Konfigurera PDF-alternativ för att rendera föreläsaranteckningar.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Rendera föreläsaranteckningar under bilden.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Spara presentationen som PDF med föreläsaranteckningar.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 
Du kanske vill testa Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion). 
{{% /alert %}}