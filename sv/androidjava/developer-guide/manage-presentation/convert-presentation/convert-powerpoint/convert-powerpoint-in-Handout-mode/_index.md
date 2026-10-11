---
title: Konvertera PowerPoint-presentationer i handout‑läge på Android
linktitle: Handout‑läge
type: docs
weight: 150
url: /sv/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- handout‑läge
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Konvertera presentationer till handouts i Java. Ställ in bilder per sida, behåll anteckningar, exportera till PDF eller bilder med Aspose.Slides för Android, med exempelkod. Prova gratis."
---
## **Introduktion**

Aspose.Slides erbjuder möjligheten att konvertera presentationer till olika format, inklusive att skapa handouts för utskrift i Handout‑läge. Detta läge låter dig konfigurera hur flera bilder visas på en enda sida, vilket gör det användbart för konferenser, seminarier och andra evenemang. Du kan aktivera detta läge genom att ange `setSlidesLayoutOptions`‑metoden i gränssnitten [IPdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipdfoptions/),[IRenderingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/irenderingoptions/),[IHtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihtmloptions/), och [ITiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiffoptions/) .

För att ställa in handout‑sidans dimensioner och orientering före export, se [Notes‑sidans storlek](/slides/sv/androidjava/notes-size/).

## **Export av Handout‑läge**

För att konfigurera Handout‑läge, använd objektet [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/handoutlayoutingoptions/), som bestämmer hur många bilder som placeras på en enda sida samt andra visningsparametrar.

Nedan följer ett kodexempel som visar hur man konverterar en presentation till PDF i Handout‑läge.

```java
import com.aspose.slides.*;

// Läs in en presentation.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Ställ in exportalternativen.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 bilder på en sida horisontellt
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // skriv ut bildnummer
	slidesLayoutOptions.setPrintFrameSlide(true);                     // skriv ut en ram runt bilderna
	slidesLayoutOptions.setPrintComments(false);                      // inga kommentarer

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exportera presentationen till PDF med den valda layouten.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Tänk på att `setSlidesLayoutOptions`‑metoden endast är tillgänglig för vissa utdataformat, såsom PDF, HTML, TIFF, och vid rendering som bilder.
{{% /alert %}} 

## **FAQ**

**Vad är det maximala antalet bild‑miniatyrer per sida i Handout‑läge?**

Aspose.Slides stödjer [presets](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/handouttype/) upp till 9 miniatyrer per sida med horisontell eller vertikal ordning: 1, 2, 3, 4 (horisontell/vertikal), 6 (horisontell/vertikal) och 9 (horisontell/vertikal).

**Kan jag definiera ett eget rutnät, exempelvis 5 eller 8 bilder per sida?**

Nej. Antalet och ordningen av miniatyrerna styrs strikt av klassen [HandoutType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/handouttype/), godtyckliga layouter stöds inte.

**Kan jag inkludera dolda bilder i Handout‑utdata?**

Ja. Aktivera dolda bilder med `setShowHiddenSlides`‑metoden i exportinställningarna för målformatet, exempelvis [PdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/),[HtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmloptions/), eller [TiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/).