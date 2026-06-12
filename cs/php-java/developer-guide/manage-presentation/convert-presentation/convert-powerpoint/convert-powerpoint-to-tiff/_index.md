---
title: Převod PowerPoint prezentací do TIFF v PHP
titlelink: PowerPoint do TIFF
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
- PowerPoint do TIFF
- prezentace do TIFF
- snímek do TIFF
- PPT do TIFF
- PPTX do TIFF
- uložit PPT jako TIFF
- uložit PPTX jako TIFF
- exportovat PPT do TIFF
- exportovat PPTX do TIFF
- PHP
- Aspose.Slides
description: "Zjistěte, jak snadno převést PowerPoint (PPT, PPTX) prezentace na vysoce kvalitní TIFF obrázky pomocí Aspose.Slides pro PHP přes Java, včetně příkladů kódu."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný, bezztrátový rastrový formát obrázků známý pro svou výjimečnou kvalitu a detailní zachování grafiky. Designéři, fotografové a desktopoví vydavatelé často volí TIFF pro zachování vrstev, přesnosti barev a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a OpenDocument snímky (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace si zachovají maximální vizuální věrnost.

## **Převod prezentace na TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save), kterou poskytuje třída [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), můžete rychle převést celou PowerPoint prezentaci do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

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

## **Převod prezentace na černobílý TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#setBwConversionMode) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení platí pouze tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#getCompressionType) nastavena na `CCITT4` nebo `CCITT3`.

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

## **Převod prezentace na TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#getImageSize) vám umožní definovat velikost výsledného obrázku.

Tento kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázky s vlastní velikostí:

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Nastavte typ komprese.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Typy komprese:
        Default - Určuje výchozí kompresní schéma (LZW).
        None - Určuje žádnou kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka závisí na typu komprese a nelze ji nastavit ručně.

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

## **Převod prezentace na TIFF s vlastním pixelovým formátem obrázku**

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#getPixelFormat) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) můžete určit preferovaný pixelový formát pro výsledný TIFF obrázek.

Tento kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázek s vlastním pixelovým formátem:

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

    // Uložte prezentaci jako TIFF se zadanou velikostí obrázku.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Vyzkoušejte bezplatný konvertor PowerPoint na plakát od Aspose [Bezplatný konvertor PowerPoint na plakát](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek namísto celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides vám umožňuje převádět jednotlivé snímky z PowerPoint i OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zachovávají se animace a přechodové efekty PowerPointu při převodu snímků do TIFF?**

Ne, TIFF je statický formát obrázku. Proto nejsou animace a přechodové efekty zachovány; exportovány jsou pouze statické snímky snímků.