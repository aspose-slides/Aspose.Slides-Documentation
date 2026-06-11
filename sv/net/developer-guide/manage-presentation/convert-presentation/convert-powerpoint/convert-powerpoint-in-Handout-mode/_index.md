---
title: Konvertera PowerPoint-presentationer i Handout-läge i .NET
linktitle: Handout-läge
type: docs
weight: 150
url: /sv/net/convert-powerpoint-in-handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- handout-läge
- handout
- PowerPoint
- presentation
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Konvertera presentationer till handouts i .NET. Ställ in antal bilder per sida, behåll anteckningar, exportera till PDF eller bilder med Aspose.Slides, med exempel på C#-kod. Prova gratis."
---
## **Introduktion**

Aspose.Slides låter dig konvertera presentationer till utdataformat som stödjer Handout‑läge. I detta läge ordnas flera bilder på en enda sida, vilket är användbart för att skriva ut presentationsmaterial för konferenser, seminarier och liknande evenemang.

Handout‑läget konfigureras via egenskapen `SlidesLayoutOptions`, som finns i [IPdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ihtmloptions/) och [ITiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/itiffoptions/). För att definiera handout‑layouten, använd objektet [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/handoutlayoutingoptions/) .

## **Export av Handout‑läge**

För att exportera en presentation i Handout‑läge, ange egenskapen `SlidesLayoutOptions` för målets exportalternativ och tilldela en [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/handoutlayoutingoptions/)‑instans som definierar antalet bilder per sida samt relaterade visningsparametrar.

Nedan är ett kodexempel som visar hur man konverterar en presentation till PDF i Handout‑läge.

```c#
 // Läs in en presentation.
 using var presentation = new Presentation("sample.pptx");

 // Ställ in exportalternativen.
 var pdfOptions = new PdfOptions
 {
     SlidesLayoutOptions = new HandoutLayoutingOptions
     {
         Handout = HandoutType.Handouts4Horizontal,  // 4 bilder på en sida horisontellt
         PrintSlideNumbers = true,                   // skriv ut bildnummer
         PrintFrameSlide = true,                     // skriv ut en ram runt bilderna
         PrintComments = false                       // inga kommentarer
     }
 };

 // Exportera presentationen till PDF med vald layout.
 presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Kom ihåg att egenskapen `SlidesLayoutOptions` endast är tillgänglig för vissa utdataformat, såsom PDF, HTML, TIFF, och vid rendering som bilder.
{{% /alert %}} 

## **FAQ**

**Vad är det maximala antalet bildminiatyrer per sida i Handout‑läge?**

Aspose.Slides stödjer [presets](https://reference.aspose.com/slides/sv/net/aspose.slides.export/handouttype/) upp till 9 miniatyrer per sida med horisontell eller vertikal ordning: 1, 2, 3, 4 (horisontell/vertikal), 6 (horisontell/vertikal) och 9 (horisontell/vertikal).

**Kan jag definiera ett anpassat rutnät, t.ex. 5 eller 8 bilder per sida?**

Nej. Antalet och ordningen på miniatyrerna styrs strikt av uppräkningen [HandoutType](https://reference.aspose.com/slides/sv/net/aspose.slides.export/handouttype/) ; godtyckliga layouter stöds inte.

**Kan jag inkludera dolda bilder i Handout‑utdata?**

Ja. Aktivera alternativet `ShowHiddenSlides` i exportinställningarna för målformatet, till exempel [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmloptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/tiffoptions/).