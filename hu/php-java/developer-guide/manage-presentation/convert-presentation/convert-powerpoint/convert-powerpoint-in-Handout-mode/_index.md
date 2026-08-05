---
title: PowerPoint prezentációk konvertálása kézikönyv módban PHP használatával
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/php-java/convert-powerpoint-in-handout-mode/
keywords:
  - PowerPoint konvertálása
  - prezentáció konvertálása
  - kézikönyv mód
  - kézikönyv
  - PPT
  - PPTX
  - PowerPoint
  - prezentáció
  - PHP
  - Aspose.Slides
description: "Prezentációk konvertálása kézikönyvekké PHP-ban. Állítsa be az oldalankénti diák számát, tartsa meg a jegyzeteket, exportáljon PDF-re vagy képekre az Aspose.Slides for PHP segítségével, minta kóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a prezentációk különböző formátumokra történő konvertálását, beleértve a kézikönyvek létrehozását a Handout mód nyomtatásához. Ez a mód lehetővé teszi, hogy beállítsa, hogyan jelennek meg több dia egyetlen oldalon, ami hasznos konferenciák, szemináriumok és egyéb események számára. Engedélyezheti ezt a módot a `setSlidesLayoutOptions` metódus beállításával a [PdfOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/), és [TiffOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/) osztályokban.

## **Kézikönyv mód exportálása**

A Kézikönyv mód beállításához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egyetlen oldalra és egyéb megjelenítési paramétereket.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan konvertáljon egy prezentációt PDF-re Kézikönyv módban.

```php
// Töltsön be egy prezentációt.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // diák számának nyomtatása
$slidesLayoutOptions->setPrintFrameSlide(true);                      // keret nyomtatása a diák köré
$slidesLayoutOptions->setPrintComments(false);                       // nincs megjegyzés

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Vedd figyelembe, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, és képként történő renderelés esetén.
{{% /alert %}} 

## **GYIK**

**Mi a maximális diákatumbók száma oldalanként a Kézikönyv módban?**

Az Aspose.Slides [előre beállított](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handouttype/) lehetőségeket támogat, amelyek legfeljebb 9 miniaturát tesznek lehetővé oldalanként, vízszintes vagy függőleges elrendezéssel: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egyedi rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A miniaturák számát és sorrendjét szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handouttype/) osztály határozza meg; tetszőleges elrendezések nem támogatottak.

**Tartalmazhatok rejtett diákat a Kézikönyv kimenetben?**

Igen. A rejtett diákat engedélyezheti a `setShowHiddenSlides` metódus használatával az exportálási beállításokban a célformátumhoz, például a [PdfOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/), vagy a [TiffOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/) esetén.