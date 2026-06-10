---
title: PowerPoint bemutatók konvertálása kézikönyv módban PHP használatával
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertálás
- bemutató konvertálás
- kézikönyv mód
- kézikönyv
- PPT
- PPTX
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Konvertálja a bemutatókat kézikönyvekké PHP-ben. Állítsa be a diaszámot oldalanként, tartsa meg a jegyzeteket, exportáljon PDF vagy képek formátumba az Aspose.Slides for PHP segítségével, minta kóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a bemutatók különböző formátumokra történő konvertálását, beleértve a kézikönyvek létrehozását a Kézikönyv mód nyomtatásához. Ez a mód lehetővé teszi, hogy konfigurálja, hogyan jelennek meg több dia egyetlen oldalon, ami hasznos konferenciákon, szemináriumokon és egyéb eseményeken. Ezt a módot a `setSlidesLayoutOptions` metódus beállításával engedélyezheti a [PdfOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) és [TiffOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/) osztályokban.

## **Kézikönyv módú exportálás**

A Kézikönyv mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handoutlayoutingoptions/) objektumot, amely meghatározza, hogy hány dia kerül egy oldalra, valamint egyéb megjelenítési paramétereket.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan konvertálhat egy bemutatót PDF-be Kézikönyv módban.

```php
// Töltsön be egy bemutatót.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // dia számok nyomtatása
$slidesLayoutOptions->setPrintFrameSlide(true);                      // keret nyomtatása a diák körül
$slidesLayoutOptions->setPrintComments(false);                       // nincsenek megjegyzések

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Fontos megjegyezni, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF esetén, illetve képként való rendereléskor.
{{% /alert %}} 

## **GYIK**

**Mi a maximális dia bélyegkép száma oldalanként a Kézikönyv módban?**

Az Aspose.Slides [előre beállított lehetőségeket](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handouttype/) támogat, amelyek legfeljebb 9 bélyegképet engedélyeznek oldalanként vízszintes vagy függőleges elrendezésben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyedi rácsot, például 5 vagy 8 dia oldalanként?**

Nem. A bélyegképek száma és elrendezése szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/handouttype/) osztály által van szabályozva; tetszőleges elrendezések nem támogatottak.

**Tárhatok rejtett diákat a Kézikönyv kimenetben?**

Igen. A rejtett diákat engedélyezheti a `setShowHiddenSlides` metódus használatával a célformátum exportálási beállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/) osztályokban.