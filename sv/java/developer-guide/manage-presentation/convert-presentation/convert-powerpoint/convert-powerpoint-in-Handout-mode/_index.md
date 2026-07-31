---
title: Konvertera PowerPoint-presentationer i handoutläge med Java
linktitle: Handoutläge
type: docs
weight: 150
url: /sv/java/convert-powerpoint-in-handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- handoutläge
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Konvertera presentationer till handouts i Java. Ställ in bilder per sida, behåll anteckningar, exportera till PDF eller bilder med Aspose.Slides, med exempel på Java‑kod. Prova gratis."
---
## **Introduktion**

Aspose.Slides låter dig konvertera presentationer till utskriftsformat som stöder handout‑läge. I detta läge placeras flera bilder på en enda sida, vilket är användbart för utskrift av presentationsmaterial för konferenser, seminarier och liknande evenemang.

Handout‑läge konfigureras via metoden `setSlidesLayoutOptions`, som finns i [IPdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ihtmloptions/) och [ITiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiffoptions/). För att definiera layouten för handout, använd objektet [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handoutlayoutingoptions/).

## **Export av handout‑läge**

För att exportera en presentation i handout‑läge, ange metoden `setSlidesLayoutOptions` för de önskade exportalternativen och tilldela en [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handoutlayoutingoptions/)-instans som definierar antalet bilder per sida samt relaterade visningsparametrar.

Nedan följer ett kodexempel som visar hur man konverterar en presentation till PDF i handout‑läge.

```java
// Laddar en presentation.
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

{{% alert color="warning" %}} 
Kom ihåg att metoden `setSlidesLayoutOptions` endast är tillgänglig för vissa utskriftsformat, såsom PDF, HTML, TIFF, och vid rendering som bilder.
{{% /alert %}} 

## **Vanliga frågor**

**Vad är det maximala antalet bildminiatyrer per sida i handout‑läge?**

Aspose.Slides stöder [presets](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handouttype/) upp till 9 miniatyrer per sida med horisontell eller vertikal ordning: 1, 2, 3, 4 (horisontell/vertikal), 6 (horisontell/vertikal) och 9 (horisontell/vertikal).

**Kan jag definiera ett anpassat rutnät, till exempel 5 eller 8 bilder per sida?**

Nej. Antalet och ordningen på miniatyrerna styrs strikt av klassen [HandoutType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handouttype/); godtyckliga layouter stöds inte.

**Kan jag inkludera dolda bilder i handout‑utdata?**

Ja. Aktivera dolda bilder med metoden `setShowHiddenSlides` i exportinställningarna för det valda formatet, såsom [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/htmloptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tiffoptions/).