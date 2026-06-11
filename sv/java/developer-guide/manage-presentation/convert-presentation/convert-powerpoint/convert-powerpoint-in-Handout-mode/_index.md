---
title: Konvertera PowerPoint-presentationer i handout-läge med Java
linktitle: Handout-läge
type: docs
weight: 150
url: /sv/java/convert-powerpoint-in-Handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- handout-läge
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Konvertera presentationer till handouts i Java. Ställ in bilder per sida, behåll anteckningar, exportera till PDF eller bilder med Aspose.Slides, med exempel på Java-kod. Prova gratis."
---
## **Introduktion**

Aspose.Slides låter dig konvertera presentationer till utdataformat som stöder handout-läge. I detta läge ordnas flera bilder på en enda sida, vilket är användbart för att skriva ut presentationsmaterial för konferenser, seminarier och liknande evenemang.

Handout-läget konfigureras via metoden `setSlidesLayoutOptions`, som finns i [IPdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ihtmloptions/) och [ITiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiffoptions/). För att definiera handout‑layouten, använd objektet [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handoutlayoutingoptions/).

## **Export av Handout-läge**

För att exportera en presentation i Handout-läge, anropa metoden `setSlidesLayoutOptions` för de önskade exportalternativen och tilldela en [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handoutlayoutingoptions/)‑instans som definierar antalet bilder per sida samt relaterade visningsparametrar.

Nedan följer ett kodexempel som visar hur du konverterar en presentation till PDF i Handout-läge.

```java
// Ladda en presentation.
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
Kom ihåg att metoden `setSlidesLayoutOptions` endast är tillgänglig för vissa utdataformat, såsom PDF, HTML, TIFF, samt vid rendering som bilder.
{{% /alert %}} 

## **FAQ**

**Vad är det maximala antalet bildminiaturer per sida i Handout-läge?**

Aspose.Slides stöder [presets](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handouttype/) upp till 9 miniaturer per sida med horisontell eller vertikal ordning: 1, 2, 3, 4 (horisontell/vertikal), 6 (horisontell/vertikal) och 9 (horisontell/vertikal).

**Kan jag definiera ett eget rutnät, t.ex. 5 eller 8 bilder per sida?**

Nej. Antalet och ordningen på miniaturerna styrs strikt av klassen [HandoutType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handouttype/); godtyckliga layouter stöds inte.

**Kan jag inkludera dolda bilder i Handout-utdata?**

Ja. Aktivera dolda bilder genom att använda metoden `setShowHiddenSlides` i exportinställningarna för målformatet, såsom [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/htmloptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tiffoptions/).