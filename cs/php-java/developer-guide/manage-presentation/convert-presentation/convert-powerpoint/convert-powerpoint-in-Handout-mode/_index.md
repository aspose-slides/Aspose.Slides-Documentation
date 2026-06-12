---
title: Převod PowerPoint prezentací do režimu Handout pomocí PHP
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim Handout
- podklad
- PPT
- PPTX
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Převádějte prezentace na podklady v PHP. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides pro PHP, s ukázkovým kódem. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim umožňuje nastavit, jak se na jedné stránce zobrazí více snímků, což je užitečné pro konference, semináře a další akce. Tento režim můžete povolit nastavením metody `setSlidesLayoutOptions` ve třídách [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/) a [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/).

## **Export v režimu Handout**

Pro nastavení režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/handoutlayoutingoptions/), který určuje, kolik snímků se umístí na jednu stránku a další parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

```php
// Načíst prezentaci.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 snímky na jedné stránce horizontálně
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // vytisknout čísla snímků
$slidesLayoutOptions->setPrintFrameSlide(true);                      // vytisknout rámeček kolem snímků
$slidesLayoutOptions->setPrintComments(false);                       // žádné komentáře

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Exportovat prezentaci do PDF s vybraným rozložením.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Mějte na paměti, že metoda `setSlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při renderování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu Handout?**

Aspose.Slides podporuje [presets](https://reference.aspose.com/slides/cs/php-java/aspose.slides/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) a 9 (horizontal/vertical).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur je přísně řízen třídou [HandoutType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/handouttype/); libovolná rozložení nejsou podporována.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Skryté snímky povolíte pomocí metody `setShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/).