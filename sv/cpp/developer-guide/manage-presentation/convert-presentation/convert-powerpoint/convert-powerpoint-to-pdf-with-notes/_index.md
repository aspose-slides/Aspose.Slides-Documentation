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
- talaranteckningar
- PDF med anteckningar
- C++
- Aspose.Slides
description: "Konvertera formaten PPT och PPTX till PDF med anteckningar med hjälp av Aspose.Slides för C++. Bevara layouter och talaranteckningar för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med talaranteckningar med hjälp av Aspose.Slides. Denna guide täcker de nödvändiga stegen och ger kodexempel för att hjälpa dig att utföra uppgiften effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som talaranteckningarna bevaras.
- Anpassa den resulterande PDF-filen så att talaranteckningarna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med anteckningar**

`Save`-metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) kan användas för att konvertera en PPT- eller PPTX-presentation till en PDF med talaranteckningar. Med Aspose.Slides laddar du helt enkelt presentationen, konfigurerar layoutalternativen med hjälp av klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/) för att inkludera talaranteckningar och sparar sedan filen som en PDF. Följande kodexempel visar hur du konverterar en exempelpresentation till en PDF i visningsläget Noter.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Konfigurera PDF-alternativ för renderering av talaranteckningar.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Rendera talaranteckningarna under bilden.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Spara presentationen som PDF med talaranteckningar.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Du kanske vill kolla in Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion). 
{{% /alert %}}