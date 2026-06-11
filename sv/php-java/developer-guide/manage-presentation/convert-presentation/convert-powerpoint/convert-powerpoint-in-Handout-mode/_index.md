---
title: Konvertera PowerPoint-presentationer i handout-läge med PHP
linktitle: Handout-läge
type: docs
weight: 150
url: /sv/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- konvertera PowerPoint
- konvertera presentation
- handout-läge
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Konvertera presentationer till handouts i PHP. Ställ in antal bilder per sida, behåll anteckningar, exportera till PDF eller bilder med Aspose.Slides för PHP, med exempel kod. Prova gratis."
---
## **Introduktion**

Aspose.Slides erbjuder möjlighet att konvertera presentationer till olika format, inklusive att skapa handouts för utskrift i Handout-läge. Detta läge låter dig konfigurera hur flera bilder visas på en enda sida, vilket är användbart för konferenser, seminarier och andra evenemang. Du kan aktivera detta läge genom att ställa in `setSlidesLayoutOptions`-metoden i klasserna [PdfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/) och [TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/).

## **Export av Handout-läge**

För att konfigurera Handout-läge, använd objektet [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/handoutlayoutingoptions/) som bestämmer hur många bilder som placeras på en enda sida samt andra visningsparametrar.

Nedan följer ett kodexempel som visar hur man konverterar en presentation till PDF i Handout-läge.

```php
// Läs in en presentation.
$presentation = new Presentation("sample.pptx");

// Ställ in exportalternativen.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 bilder på en sida horisontellt
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // skriv ut bildnummer
$slidesLayoutOptions->setPrintFrameSlide(true);                      // skriv ut en ram runt bilderna
$slidesLayoutOptions->setPrintComments(false);                       // inga kommentarer

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Exportera presentationen till PDF med den valda layouten.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Kom ihåg att `setSlidesLayoutOptions`-metoden endast är tillgänglig för vissa utdataformat, såsom PDF, HTML, TIFF och vid rendering som bilder.
{{% /alert %}} 

## **Vanliga frågor**

**Vad är det maximala antalet bildminiatyrer per sida i Handout-läge?**  
Aspose.Slides stöder [förinställningar](https://reference.aspose.com/slides/sv/php-java/aspose.slides/handouttype/) upp till 9 miniatyrer per sida med horisontell eller vertikal ordning: 1, 2, 3, 4 (horisontell/vertikal), 6 (horisontell/vertikal) och 9 (horisontell/vertikal).

**Kan jag definiera ett eget rutnät, till exempel 5 eller 8 bilder per sida?**  
Nej. Antalet och ordningen på miniatyrerna styrs strikt av klassen [HandoutType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/handouttype/); godtyckliga layouter stöds inte.

**Kan jag inkludera dolda bilder i Handout-utdata?**  
Ja. Aktivera de dolda bilderna med `setShowHiddenSlides`-metoden i exportinställningarna för målformatet, såsom [PdfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/).