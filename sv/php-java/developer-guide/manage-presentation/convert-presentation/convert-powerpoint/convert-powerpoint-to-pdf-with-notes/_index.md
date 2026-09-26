---
title: Konvertera PowerPoint-presentationer till PDF med anteckningar i PHP
linktitle: PowerPoint till PDF med anteckningar
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
- talaranteckningar
- PDF med anteckningar
- PHP
- Aspose.Slides
description: "Konvertera formaten PPT och PPTX till PDF med anteckningar med hjälp av Aspose.Slides för PHP via Java. Bevara layouter och talaranteckningar för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint‑presentationer till PDF‑format med talaranteckningar med hjälp av Aspose.Slides. Denna guide täcker de nödvändiga stegen och ger kodexempel för att du ska kunna utföra uppgiften på ett effektivt sätt. När du har läst färdigt artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint‑bilder till PDF‑dokument samtidigt som du bevarar talaranteckningarna.
- Anpassa den resulterande PDF‑filen så att talaranteckningarna inkluderas och formateras enligt dina krav.

För att ställa in notssidans dimensioner och orientering före export, se [Notssidans storlek](/slides/sv/php-java/notes-size/).

## **Konvertera PowerPoint till PDF med anteckningar**

`save`‑metoden i [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑klassen kan användas för att konvertera en PPT‑ eller PPTX‑presentation till en PDF med talaranteckningar. Med Aspose.Slides laddar du bara presentationen, konfigurerar layoutalternativen med hjälp av [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/)-klassen för att inkludera talaranteckningar och sparar sedan filen som en PDF. Följande kodsnutt visar hur du konverterar en exempel­presentation till en PDF i Antecknings‑bild‑vyn.

```php
$presentation = new Presentation("sample.pptx");

// Konfigurera PDF-alternativ för att rendera talaranteckningar.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Rendera talaranteckningar under bilden.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Save the presentation to PDF with speaker notes.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
Du kanske vill testa Aspose [Online PowerPoint till PDF-konverterare](https://products.aspose.app/slides/sv/conversion).
{{% /alert %}}