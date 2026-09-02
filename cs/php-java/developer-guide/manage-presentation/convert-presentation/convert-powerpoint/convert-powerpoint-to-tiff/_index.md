---
title: Převod prezentací PowerPoint do formátu TIFF v PHP
titlelink: PowerPoint na TIFF
type: docs
weight: 90
url: /cs/php-java/convert-powerpoint-to-tiff/
keywords:
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na TIFF
- prezentace na TIFF
- snímek na TIFF
- PPT na TIFF
- PPTX na TIFF
- uložit PPT jako TIFF
- uložit PPTX jako TIFF
- exportovat PPT do TIFF
- exportovat PPTX do TIFF
- PHP
- Aspose.Slides
description: "Naučte se snadno převádět prezentace PowerPoint (PPT, PPTX) do vysoce kvalitních TIFF obrázků pomocí Aspose.Slides pro PHP přes Java, s příklady kódu."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, který je známý svou vynikající kvalitou a podrobným zachováním grafiky. Designéři, fotografové a desktopoví vydavatelé často volí TIFF k zachování vrstev, přesnosti barev a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své snímky PowerPointu (PPT, PPTX) a snímky OpenDocument (ODP) přímo na vysoce kvalitní TIFF obrázky, což zajistí, že vaše prezentace si zachovají maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) můžete rychle převést celou prezentaci PowerPointu do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
$presentation = new Presentation("presentation.pptx");
try {
    // Uložte prezentaci jako TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Převod prezentace do černobílého TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#setBwConversionMode) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se použije pouze tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#getCompressionType) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#setBwConversionMode) je nastavení na úrovni exportu, které vybírá algoritmus konverze pixelů pro celý TIFF obrázek. Pro definování, jak by měl vypadat jednotlivý tvar, když je aktivní černobílý režim zobrazení, použijte [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#setBlackWhiteMode). Viz [Control Black-and-White Rendering for Shapes](/slides/cs/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.
{{% /alert %}}

Řekněme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento kód ukazuje, jak převést barevný snímek na černobílý TIFF:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#getImageSize) umožňuje definovat velikost výsledného obrázku.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Nastavte typ komprese.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Typy komprese:
        Default - Udává výchozí kompresní schéma (LZW).
        None - Udává, že není použita komprese.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka závisí na typu komprese a nemůže být nastavena ručně.

    // Nastavte DPI obrázku.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Nastavte velikost obrázku.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Uložte prezentaci jako TIFF se zadanou velikostí.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Převod prezentace do TIFF s vlastním formátem pixelů obrazu**

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#getPixelFormat) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) můžete určit preferovaný formát pixelů pro výsledný TIFF obrázek.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
        Format1bppIndexed - 1 bit na pixel, indexovaný.
        Format4bppIndexed - 4 bity na pixel, indexovaný.
        Format8bppIndexed - 8 bitů na pixel, indexovaný.
        Format24bppRgb    - 24 bitů na pixel, RGB.
        Format32bppArgb   - 32 bitů na pixel, ARGB.
    */

    // Uložte prezentaci jako TIFF s určenou velikostí obrázku.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="info" %}}
Vyzkoušejte [ZDARMA konvertor PowerPoint na poster](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé prezentace PowerPoint do TIFF?**

Ano. Aspose.Slides vám umožňuje převádět jednotlivé snímky z prezentací PowerPoint a OpenDocument do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zůstávají při převodu snímků do TIFF zachovány animace a přechodové efekty PowerPointu?**

Ne, TIFF je formát statického obrázku. Proto nejsou animace a přechodové efekty zachovány; exportovány jsou pouze statické snímky snímků.