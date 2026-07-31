---
title: Konvertera PowerPoint-presentationer i handout-läge på Android
linktitle: Handout-läge
type: docs
weight: 150
url: /sv/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- handout-läge
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Konvertera presentationer till handouts i Java. Ange bilder per sida, behåll anteckningar, exportera till PDF eller bilder med Aspose.Slides för Android, med exempel kod. Prova gratis."
---
## **Introduktion**

Aspose.Slides tillhandahåller möjligheten att konvertera presentationer till olika format, inklusive att skapa handouts för utskrift i Handout‑läge. Detta läge låter dig konfigurera hur flera bilder visas på en enda sida, vilket är användbart för konferenser, seminarier och andra evenemang. Du kan aktivera detta läge genom att ange metoden `setSlidesLayoutOptions` i gränssnitten [IPdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihtmloptions/) och [ITiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiffoptions/) .

## **Export av Handout‑läge**

För att konfigurera Handout‑läge, använd objektet [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/handoutlayoutingoptions/) som bestämmer hur många bilder som placeras på en enda sida och andra visningsparametrar.

Nedan följer ett kodexempel som visar hur man konverterar en presentation till PDF i Handout‑läge.

```java
// Ladda en presentation.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Ange exportalternativen.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 bilder på en sida horisontellt
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // skriv ut bildnummer
	slidesLayoutOptions.setPrintFrameSlide(true);                     // skriv ut en ram runt bilderna
	slidesLayoutOptions.setPrintComments(false);                      // inga kommentarer

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exportera presentationen till PDF med vald layout.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
Kom ihåg att metoden `setSlidesLayoutOptions` endast är tillgänglig för vissa utdataformat, såsom PDF, HTML, TIFF, och vid rendering som bilder. 
{{% /alert %}} 

## **FAQ**

**Vad är det maximala antalet bildminiatyrer per sida i Handout‑läge?**

Aspose.Slides stöder [presets](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/handouttype/) upp till 9 miniatyrer per sida med horisontell eller vertikal ordning: 1, 2, 3, 4 (horisontell/vertikal), 6 (horisontell/vertikal) och 9 (horisontell/vertikal).

**Kan jag definiera ett eget rutnät, t.ex. 5 eller 8 bilder per sida?**

Nej. Antalet och ordningen på miniatyrerna styrs strikt av klassen [HandoutType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/handouttype/) ; godtyckliga layouter stöds inte.

**Kan jag inkludera dolda bilder i Handout‑utdata?**

Ja. Aktivera dolda bilder med metoden `setShowHiddenSlides` i exportinställningarna för målformatet, t.ex. [PdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmloptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/).