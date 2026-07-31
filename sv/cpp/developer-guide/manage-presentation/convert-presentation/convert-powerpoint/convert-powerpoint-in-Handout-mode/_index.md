---
title: Konvertera PowerPoint-presentationer i handout‑läge med C++
linktitle: Handout‑läge
type: docs
weight: 150
url: /sv/cpp/convert-powerpoint-in-handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- handout‑läge
- handutskrift
- PPT
- PPTX
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Konvertera presentationer till handouts i C++. Ställ in antalet bilder per sida, behåll anteckningar, exportera till PDF eller bilder med Aspose.Slides, med exempelcode. Prova gratis."
---
## **Introduktion**

Aspose.Slides erbjuder möjligheten att konvertera presentationer till olika format, inklusive att skapa handouts för utskrift i Handout‑läge. Detta läge låter dig konfigurera hur flera bilder visas på en enda sida, vilket är användbart för konferenser, seminarier och andra evenemang. Du kan aktivera detta läge genom att ange `set_SlidesLayoutOptions`‑metoden i gränssnitten [IPdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ihtmloptions/), och [ITiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/itiffoptions/).

## **Export av Handout‑läge**

För att konfigurera Handout‑läge, använd objektet [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/handoutlayoutingoptions/), som bestämmer hur många bilder som placeras på en enda sida samt andra visningsparametrar.

Nedan är ett kodexempel som visar hur man konverterar en presentation till PDF i Handout‑läge.

```cpp
// Läs in en presentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ställ in exportalternativen.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 bilder på en sida horisontellt
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // skriv ut bildnummer
slidesLayoutOptions->set_PrintFrameSlide(true);                      // skriv ut en ram runt bilderna
slidesLayoutOptions->set_PrintComments(false);                       // inga kommentarer

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exportera presentationen till PDF med det valda layoutet.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Tänk på att `set_SlidesLayoutOptions`‑metoden endast är tillgänglig för vissa output‑format, såsom PDF, HTML, TIFF, och vid rendering som bilder.
{{% /alert %}} 

## **FAQ**

**Vad är det maximala antalet bildminiatyrer per sida i Handout‑läge?**

Aspose.Slides stödjer [presets](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/handouttype/) upp till 9 miniatyrer per sida med horisontell eller vertikal ordning: 1, 2, 3, 4 (horisontell/vertikal), 6 (horisontell/vertikal) och 9 (horisontell/vertikal).

**Kan jag definiera ett eget rutnät, till exempel 5 eller 8 bilder per sida?**

Nej. Antalet och ordningen på miniatyrerna styrs strikt av uppräkningen [HandoutType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/handouttype/); godtyckliga layouter stöds inte.

**Kan jag inkludera dolda bilder i Handout‑utdata?**

Ja. Använd `set_ShowHiddenSlides`‑metoden i exportinställningarna för målformatet, såsom [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmloptions/), eller [TiffOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/).