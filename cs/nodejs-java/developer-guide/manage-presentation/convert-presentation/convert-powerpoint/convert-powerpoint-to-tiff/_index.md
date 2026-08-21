---
title: Převod prezentací PowerPoint do TIFF v JavaScriptu
titlelink: PowerPoint na TIFF
type: docs
weight: 90
url: /cs/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se snadno převádět prezentace PowerPoint (PPT, PPTX) na vysoce kvalitní TIFF obrázky pomocí Aspose.Slides pro Node.js s příklady kódu v JavaScriptu."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrazu známý pro výjimečnou kvalitu a detailní zachování grafiky. Designéři, fotografové a deskoví vydavatelé často volí TIFF pro udržení vrstev, přesnosti barev a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své snímky PowerPointu (PPT, PPTX) a snímky OpenDocument (ODP) přímo na vysoce kvalitní TIFF obrázky, což zajistí, že vaše prezentace zachová maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) můžete rychle převést celou prezentaci PowerPoint do TIFF. Vzniklé TIFF obrázky odpovídají výchozí velikosti snímku.

Tento JavaScriptový kód ukazuje, jak převést prezentaci PowerPoint do TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Uložte prezentaci jako TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do černobílého TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) vám umožňuje určit algoritmus použité při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se používá pouze, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) je nastavení úrovně exportu, které vybírá algoritmus konverze pixelů pro celý TIFF obrázek. Pro definování, jak by se měla jednotlivá tvarová položka zobrazovat v režimu černobílého zobrazení, použijte [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Viz [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.
{{% /alert %}}

Předpokládejme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento JavaScriptový kód ukazuje, jak převést barevný snímek na černobílý TIFF:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných v [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setImageSize) vám umožňuje definovat velikost výsledného obrázku.

Tento JavaScriptový kód ukazuje, jak převést prezentaci PowerPoint na TIFF obrázky s vlastní velikostí:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Nastavte typ komprese.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Typy komprese:
        Default - Určuje výchozí kompresní schéma (LZW).
        None - Určuje žádnou kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka barev je řízena formátem pixelů (viz příklad níže); CCITT3 a CCITT4 vždy produkují 1 bit na pixel.

    // Nastavte DPI obrázku.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Nastavte velikost obrázku.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Uložte prezentaci jako TIFF se zadanou velikostí.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do TIFF s vlastním formátem pixelů obrazu**

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) můžete specifikovat požadovaný formát pixelů pro výsledný TIFF obrázek.

Tento JavaScriptový kód ukazuje, jak převést prezentaci PowerPoint na TIFF obrázek s vlastním formátem pixelů:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
        Format1bppIndexed - 1 bit na pixel, indexováno.
        Format4bppIndexed - 4 bity na pixel, indexováno.
        Format8bppIndexed - 8 bitů na pixel, indexováno.
        Format24bppRgb    - 24 bitů na pixel, RGB.
        Format32bppArgb   - 32 bitů na pixel, ARGB.
    */

    /// Uložte prezentaci jako TIFF se zadanou velikostí obrázku.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Vyzkoušejte bezplatný konvertor PowerPoint na plakát od Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé prezentace PowerPoint do TIFF?**

Ano. Aspose.Slides vám umožňuje převádět jednotlivé snímky z PowerPoint a OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides nekladí žádná omezení na počet snímků. Můžete převádět prezentace jakékoli velikosti do formátu TIFF.

**Zachovají se animace a přechodové efekty PowerPointu při převodu snímků do TIFF?**

Ne, TIFF je formát statického obrázku. Animace a přechodové efekty nejsou zachovány; exportované jsou pouze statické snímky snímků.