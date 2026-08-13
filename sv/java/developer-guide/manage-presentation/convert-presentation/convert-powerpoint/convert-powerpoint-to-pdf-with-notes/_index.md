---
title: Konvertera PowerPoint-presentationer till PDF med notiser i Java
linktitle: PowerPoint till PDF med notiser
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
- talarnotiser
- PDF med notiser
- Java
- Aspose.Slides
description: "Konvertera formaten PPT och PPTX till PDF med notiser med hjälp av Aspose.Slides för Java. Bevara layouter och talarnotiser för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med talarnotis med Aspose.Slides. Den här guiden täcker de nödvändiga stegen och ger kodexempel för att hjälpa dig att utföra uppgiften effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som talarnotiserna bevaras.
- Anpassa den genererade PDF-filen så att talarnotiserna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med notiser**

`save`-metoden i [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassen kan användas för att konvertera en PPT‑ eller PPTX‑presentation till en PDF med talarnotiser. Med Aspose.Slides laddar du helt enkelt presentationen, konfigurerar layoutalternativen med hjälp av klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notescommentslayoutingoptions/) för att inkludera talarnotiser, och sparar sedan filen som en PDF. Följande kodsnutt visar hur du konverterar en exempelpresentation till en PDF i Notiser‑bildläge.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Konfigurera PDF-alternativ för att rendera talarnotiser.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Rendera talarnotiser under bilden.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Spara presentationen som PDF med talarnotiser.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
Du kanske vill testa Aspose [Online PowerPoint till PDF‑konverterare](https://products.aspose.app/slides/sv/conversion). 
{{% /alert %}}