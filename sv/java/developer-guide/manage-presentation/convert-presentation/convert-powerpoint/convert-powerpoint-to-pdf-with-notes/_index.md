---
title: Konvertera PowerPoint-presentationer till PDF med noteringar i Java
linktitle: PowerPoint till PDF med noteringar
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
- PDF med noteringar
- Java
- Aspose.Slides
description: "Konvertera format PPT och PPTX till PDF med noteringar med hjälp av Aspose.Slides för Java. Bevara layouter och talarnoter för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med talarnoter med hjälp av Aspose.Slides. Den här guiden täcker de nödvändiga stegen och ger kodexempel för att hjälpa dig att utföra denna uppgift effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som talarnoterna bevaras.
- Anpassa den genererade PDF-filen för att säkerställa att talarnoterna inkluderas och formateras enligt dina krav.

För att ställa in notssidans dimensioner och orientering innan export, se [Notssidans storlek](/slides/sv/java/notes-size/).

## **Konvertera PowerPoint till PDF med noter**

Metoden `save` i klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) kan användas för att konvertera en PPT- eller PPTX-presentation till en PDF med talarnoter. Med Aspose.Slides laddar du bara presentationen, konfigurerar layoutalternativen med hjälp av klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notescommentslayoutingoptions/) för att inkludera talarnoter, och sparar sedan filen som en PDF. Följande kodsnutt demonstrerar hur man konverterar en exempelpresentation till en PDF i Noter‑bild‑vy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Konfigurera PDF-alternativ för att rendera talarnoter.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Rendera talarnoter under bilden.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Obs" %}}
Du kanske vill titta på Aspose [Online PowerPoint till PDF-konverterare](https://products.aspose.app/slides/sv/conversion).
{{% /alert %}}