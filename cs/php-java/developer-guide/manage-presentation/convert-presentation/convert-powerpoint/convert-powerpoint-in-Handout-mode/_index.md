---
title: Převod PowerPoint prezentací do režimu Handout pomocí PHP
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/php-java/convert-powerpoint-in-handout-mode/
keywords:
- převod PowerPoint
- převod prezentace
- režim podkladů
- podklad
- PPT
- PPTX
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Převádějte prezentace na podklady v PHP. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides pro PHP s ukázkovým kódem. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim vám umožňuje nakonfigurovat, jak se na jedné stránce zobrazí více snímků, což je užitečné pro konference, semináře a další akce. Tento režim můžete povolit nastavením metody `setSlidesLayoutOptions` ve třídách [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/) a [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/).

Pro nastavení rozměrů a orientace stránky podkladu před exportem, viz [Velikost stránky poznámek](/slides/cs/php-java/notes-size/).

## **Export v režimu Handout**

Pro konfiguraci režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/handoutlayoutingoptions/), který určuje, kolik snímků je umístěno na jedné stránce a další parametry zobrazení.

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

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
Uvědomte si, že metoda `setSlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při vykreslování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránce v režimu Handout?**

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/php-java/aspose.slides/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur jsou řízeny striktně třídou [HandoutType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/handouttype/); libovolná rozvržení nejsou podporována.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Skryté snímky můžete povolit pomocí metody `setShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/).