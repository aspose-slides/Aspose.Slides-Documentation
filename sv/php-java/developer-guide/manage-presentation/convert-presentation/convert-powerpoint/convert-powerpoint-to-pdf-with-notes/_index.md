---
title: Konvertera PowerPoint-presentationer till PDF med noter i PHP
linktitle: PowerPoint till PDF med noter
type: docs
weight: 50
url: /sv/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PDF med noter
- PHP
- Aspose.Slides
description: "Konvertera formaten PPT och PPTX till PDF med noter med hjälp av Aspose.Slides för PHP via Java. Bevara layouter och talarnoter för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med talarnoter med hjälp av Aspose.Slides. Denna guide kommer att täcka de nödvändiga stegen och ge kodexempel för att hjälpa dig att utföra denna uppgift effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som talarnoterna bevaras.
- Anpassa den genererade PDF-filen så att talarnoterna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med noter**

Metoden `save` i klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) kan användas för att konvertera en PPT- eller PPTX-presentation till en PDF med talarnoter. Med Aspose.Slides laddar du helt enkelt presentationen, konfigurerar layoutalternativen med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/) för att inkludera talarnoter, och sparar sedan filen som en PDF. Följande kodsnutt visar hur du konverterar en exempelpresentation till en PDF i vyn Noter-bild.

```php
$presentation = new Presentation("sample.pptx");

// Konfigurera PDF-alternativ för renderering av talarnoter.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Rendera talarnoter under bilden.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Spara presentationen som PDF med talarnoter.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
Du kanske vill titta på Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion). 
{{% /alert %}}