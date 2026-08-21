---
title: Převod prezentací PowerPoint do TIFF v Javě
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /cs/java/convert-powerpoint-to-tiff/
keywords:
- převod PowerPoint
- převod OpenDocument
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint do TIFF
- prezentace do TIFF
- snímek do TIFF
- PPT do TIFF
- PPTX do TIFF
- uložit PPT jako TIFF
- uložit PPTX jako TIFF
- exportovat PPT do TIFF
- exportovat PPTX do TIFF
- Java
- Aspose.Slides
description: "Naučte se snadno převádět prezentace PowerPoint (PPT, PPTX) na vysoce kvalitní TIFF obrázky pomocí Aspose.Slides pro Javu, včetně ukázek kódu."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát snímků známý pro svou vynikající kvalitu a detailní zachování grafiky. Návrháři, fotografové a desktopoví vydavatelé často volí TIFF pro zachování vrstev, barevné přesnosti a původního nastavení svých obrázků.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a OpenDocument snímky (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace si udrží maximální vizuální věrnost. 

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP, atd.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Uložte prezentaci jako TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do černobílého TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/) umožňuje určit algoritmus použitý při převodu barevného snímku nebo obrázku do černobílého TIFF. Všimněte si, že toto nastavení platí pouze tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) je nastavení na úrovni exportu, které vybírá algoritmus konverze pixelů pro celý TIFF obrázek. Pro definování, jak má vypadat konkrétní tvar při aktivním režimu černobílého zobrazení, použijte [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Viz [Control Black-and-White Rendering for Shapes](/java/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.
{{% /alert %}}

Předpokládejme, že máme soubor „sample.pptx“ s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento kód ukazuje, jak převést barevný snímek na černobílý TIFF:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převod prezentace do TIFF s vlastním rozměrem**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) umožňuje definovat velikost výsledného obrázku.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Nastavte typ komprese.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Typy komprese:
        Default - Určuje výchozí schéma komprese (LZW).
        None - Určuje žádnou kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka závisí na typu komprese a nemůže být nastavena ručně.

    // Nastavte DPI obrázku.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Nastavte rozměry obrázku.
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Uložte prezentaci jako TIFF s určenou velikostí.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do TIFF s vlastním formátem pixelů obrázku**

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/) můžete zadat preferovaný formát pixelů pro výsledný TIFF obrázek.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
        Format1bppIndexed - 1 bit na pixel, indexovaný.
        Format4bppIndexed - 4 bity na pixel, indexovaný.
        Format8bppIndexed - 8 bitů na pixel, indexovaný.
        Format24bppRgb    - 24 bitů na pixel, RGB.
        Format32bppArgb   - 32 bitů na pixel, ARGB.
    */
    
    // Uložte prezentaci jako TIFF s určeným formátem pixelů.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Vyzkoušejte bezplatný konvertor Aspose [PowerPoint na poster](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides umožňuje převádět jednotlivé snímky z PowerPoint a OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides nekladí žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Jsou při převodu snímků do TIFF zachovány animace a přechodové efekty PowerPointu?**

Ne, TIFF je statický formát obrázku. Proto nejsou animace a přechodové efekty zachovány; exportují se jen statické snímky.