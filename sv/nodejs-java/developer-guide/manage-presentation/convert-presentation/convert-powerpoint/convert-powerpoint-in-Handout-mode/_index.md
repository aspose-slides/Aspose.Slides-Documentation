---
title: Konvertera PowerPoint-presentationer i utdelningsläge med JavaScript
linktitle: Utdelningsläge
type: docs
weight: 150
url: /sv/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- utdelningsläge
- utdelning
- PPT
- PPTX
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera presentationer till utdelningar. Ställ in antal bilder per sida, behåll anteckningar, exportera till PDF eller bilder med Aspose.Slides för Node.js, med exempel kod. Prova gratis."
---
## **Introduktion**

Aspose.Slides erbjuder möjligheten att konvertera presentationer till olika format, inklusive att skapa utdelningar för utskrift i Handout‑läge. Detta läge låter dig konfigurera hur flera bilder visas på en enda sida, vilket gör det användbart för konferenser, seminarier och andra evenemang. Du kan aktivera detta läge genom att ange metoden `setSlidesLayoutOptions` i klasserna [PdfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/htmloptions/) och [TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/).

## **Export av Handout‑läge**

För att konfigurera Handout‑läge, använd objektet [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/handoutlayoutingoptions/), som bestämmer hur många bilder som placeras på en enda sida samt andra visningsparametrar.

Nedan visas ett kodexempel som visar hur man konverterar en presentation till PDF i Handout‑läge.

```js
// Ladda en presentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Ställ in exportalternativen.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 bilder på en sida horisontellt
slidesLayoutOptions.setPrintSlideNumbers(true);                                // skriv ut bildnummer
slidesLayoutOptions.setPrintFrameSlide(true);                                  // skriv ut en ram runt bilderna
slidesLayoutOptions.setPrintComments(false);                                   // inga kommentarer

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Tänk på att metoden `setSlidesLayoutOptions` endast är tillgänglig för vissa utdataformat, såsom PDF, HTML, TIFF, och vid rendering som bilder.
{{% /alert %}} 

## **FAQ**

**Vad är det maximala antalet bildminiatyrer per sida i Handout‑läge?**

Aspose.Slides stöder [presets](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/handouttype/) upp till 9 miniatyrer per sida med horisontell eller vertikal ordning: 1, 2, 3, 4 (horisontell/vertikal), 6 (horisontell/vertikal) och 9 (horisontell/vertikal).

**Kan jag definiera ett anpassat rutnät, till exempel 5 eller 8 bilder per sida?**

Nej. Antalet och ordningen på miniatyrerna styrs strikt av uppräkningen [HandoutType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/handouttype/); godtyckliga layouter stöds inte.

**Kan jag inkludera dolda bilder i Handout‑utdata?**

Ja. Använd metoden `setShowHiddenSlides` i exportinställningarna för målformatet, såsom [PdfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/htmloptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/).