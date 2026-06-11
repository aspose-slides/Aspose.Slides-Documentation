---
title: Konvertera PowerPoint-presentationer till PDF med noter i JavaScript
linktitle: PowerPoint till PDF med noter
type: docs
weight: 50
url: /sv/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera formaten PPT och PPTX till PDF med noter i JavaScript med Aspose.Slides för Node.js. Bevara layouter och talarnoter för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint-presentationer till PDF-format med talarnoter med Aspose.Slides. Denna guide täcker de nödvändiga stegen och ger kodexempel för att hjälpa dig att utföra uppgiften effektivt. När du har läst klart artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint-bilder till PDF-dokument samtidigt som talarnoterna bevaras.
- Anpassa den resulterande PDF-filen så att talarnoterna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med noter**

`save`‑metoden i [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑klassen kan användas för att konvertera en PPT‑ eller PPTX‑presentation till PDF med talarnoter. Med Aspose.Slides laddar du bara presentationen, konfigurerar layoutalternativen med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notescommentslayoutingoptions/) för att inkludera talarnoter och sparar sedan filen som PDF. Följande kodsnutt visar hur du konverterar en exempelpresentation till PDF i visning med notersida.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// Konfigurera PDF-alternativ för att rendera talarnoter.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Rendera talarnoter under bilden.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Spara presentationen som PDF med talarnoter.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 

Du kanske vill prova Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/sv/conversion). 

{{% /alert %}}