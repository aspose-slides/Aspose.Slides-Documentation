---
title: PowerPoint előadások konvertálása kézikönyv módban PHP használatával
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/php-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- előadás konvertálása
- kézikönyv mód
- kézikönyv
- PPT
- PPTX
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Konvertálja az előadásokat kézikönyvekké PHP-ben. Állítsa be az oldalankénti diákat, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekbe az Aspose.Slides for PHP segítségével, mintapéldával. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a bemutatók különböző formátumokra történő konvertálását, beleértve a kézikönyvek létrehozását a Handout mód nyomtatásához. Ez a mód lehetővé teszi, hogy beállítsa, hogyan jelennek meg több dia egyetlen oldalon, ami konferenciák, szemináriumok és egyéb események esetén hasznos. A mód engedélyezhető a `setSlidesLayoutOptions` metódus beállításával a [PdfOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) és [TiffOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/) osztályokban.

A kézikönyv oldal méreteinek és tájolásának exportálás előtt történő beállításához lásd a [Jegyzetoldal mérete](/slides/hu/php-java/notes-size/).

## **Handout mód exportálása**

A Handout mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egyetlen oldalra, valamint egyéb megjelenítési paramétereket.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan konvertálhat egy bemutatót PDF-re Handout módban.

```php
// Töltsön be egy bemutatót.
$presentation = new Presentation("sample.pptx");

// Állítsa be az exportálási beállításokat.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // nyomtassa a dia számait
$slidesLayoutOptions->setPrintFrameSlide(true);                      // nyomtasson keretet a diák köré
$slidesLayoutOptions->setPrintComments(false);                       // nincsenek megjegyzések

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Exportálja a bemutatót PDF-be a kiválasztott elrendezéssel.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
Ne feledje, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, valamint képként történő renderelés esetén.
{{% /alert %}} 

## **GYIK**

**Mi a legnagyobb számú dia bélyegkép egy oldalon a Handout módban?**

Az Aspose.Slides a [preseteket](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handouttype/) támogatja, amelyek legfeljebb 9 bélyegképet biztosítanak oldalanként vízszintes vagy függőleges sorrendben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyedi rácsot, például 5 vagy 8 dia oldalanként?**

Nem. A bélyegképek száma és sorrendje szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handouttype/) osztály által van meghatározva; tetszőleges elrendezések nem támogatottak.

**Tartalmazhatok rejtett diákat a Handout kimenetben?**

Igen. Engedélyezheti a rejtett diák megjelenítését a `setShowHiddenSlides` metódus segítségével a célformátum exportálási beállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/) esetén.