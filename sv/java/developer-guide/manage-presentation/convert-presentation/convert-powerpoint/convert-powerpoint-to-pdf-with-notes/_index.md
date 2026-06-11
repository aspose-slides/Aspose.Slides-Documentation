---
title: Konvertera PowerPoint-presentationer till PDF med anteckningar i Java
linktitle: PowerPoint till PDF med anteckningar
type: docs
weight: 50
url: /sv/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: "Konvertera formaten PPT och PPTX till PDF med anteckningar med hjälp av Aspose.Slides för Java. Bevara layouter och talarnoter för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med talarnoter med hjälp av Aspose.Slides. Denna guide täcker de nödvändiga stegen och ger kodexempel för att hjälpa dig utföra uppgiften effektivt. När du läst färdigt artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som talarnoterna bevaras.
- Anpassa den genererade PDF-filen så att talarnoterna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med anteckningar**

`save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) kan användas för att konvertera en PPT‑ eller PPTX‑presentation till en PDF med talarnoter. Med Aspose.Slides laddar du bara presentationen, konfigurerar layoutalternativen med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notescommentslayoutingoptions/) för att inkludera talarnoter och sparar sedan filen som PDF. Följande kodexempel visar hur du konverterar en exempelpresentation till en PDF i Notes‑Slide‑vyn.

```java
Presentation presentation = new Presentation("sample.pptx");

// Konfigurera PDF-alternativ för att rendera talarnoter.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Rendera talarnoter under bilden.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Spara presentationen som PDF med talarnoter.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 

Du kanske vill testa Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion). 

{{% /alert %}}