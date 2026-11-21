---
title: "Konvertera PowerPoint-presentationer till PDF med noteringar i JavaScript"
linktitle: "PowerPoint till PDF med noteringar"
type: docs
weight: 50
url: /sv/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- "konvertera PowerPoint"
- "konvertera presentation"
- "konvertera bild"
- "konvertera PPT"
- "konvertera PPTX"
- "PowerPoint till PDF"
- "presentation till PDF"
- "bild till PDF"
- "PPT till PDF"
- "PPTX till PDF"
- "spara presentation som PDF"
- "spara PPT som PDF"
- "spara PPTX som PDF"
- "exportera PPT till PDF"
- "exportera PPTX till PDF"
- "talarnoteringar"
- "PDF med noteringar"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Konvertera formaten PPT och PPTX till PDF med noteringar i JavaScript med Aspose.Slides för Node.js. Bevara layouter och talarnoteringar för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med talarnoteringar med hjälp av Aspose.Slides. Denna guide täcker de nödvändiga stegen och ger kodexempel för att hjälpa dig att utföra uppgiften effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som talarnoteringarna bevaras.
- Anpassa den genererade PDF-filen så att talarnoteringarna inkluderas och formateras enligt dina krav.

För att ställa in notssidans mått och orientering före export, se [Notes Page Size](/slides/sv/nodejs-java/notes-size/).

## **Konvertera PowerPoint till PDF med noteringar**

Metoden `save` i klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) kan användas för att konvertera en PPT- eller PPTX-presentation till en PDF med talarnoteringar. Med Aspose.Slides laddar du helt enkelt presentationen, konfigurerar layoutalternativen med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notescommentslayoutingoptions/) för att inkludera talarnoteringar, och sparar sedan filen som en PDF. Följande kodsnutt visar hur du konverterar en exempelpresentation till en PDF i vy för notssidor.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Konfigurera PDF-alternativ för rendering av talarnoteringar.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Rendera talarnoteringar under bilden.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Spara presentationen till PDF med talarnoteringar.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Du kanske vill titta på Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion).
{{% /alert %}}