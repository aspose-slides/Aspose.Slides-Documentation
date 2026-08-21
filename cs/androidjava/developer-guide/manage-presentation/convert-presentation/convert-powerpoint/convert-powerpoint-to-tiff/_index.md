---
title: Převod prezentací PowerPoint do TIFF na Androidu
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /cs/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Naučte se snadno převádět prezentace PowerPoint (PPT, PPTX) do vysoce kvalitních TIFF obrázků pomocí Aspose.Slides pro Android, s příklady kódu v jazyce Java."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, známý svou vynikající kvalitou a podrobným zachováním grafiky. Návrháři, fotografové i deskontní vydavatelé často volí TIFF pro zachování vrstev, přesnosti barev a původních nastavení ve svých obrázcích.

Pomocí Aspose.Slides můžete snadno převést své snímky PowerPointu (PPT, PPTX) a snímky OpenDocument (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte maximální vizuální věrnost prezentací. 

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) můžete rychle převést celou prezentaci PowerPointu do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento kód ukazuje, jak převést prezentaci PowerPointu do TIFF:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Uložte prezentaci jako TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Převod prezentace do černobílého TIFF**

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/) umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku do černobílého TIFF. Všimněte si, že toto nastavení platí pouze tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Note" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) je nastavení na úrovni exportu, které vybírá algoritmus převodu pixelů pro celý TIFF obrázek. Pro definování, jak by měl vypadat konkrétní tvar při aktivovaném černobílém režimu zobrazení, použijte [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Viz [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.

{{% /alert %}}

Řekněme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento kód ukazuje, jak převést barevný snímek do černobílého TIFF:

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

## **Převod prezentace do TIFF se vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) umožňuje definovat velikost výsledného obrázku.

Tento kód ukazuje, jak převést prezentaci PowerPointu do TIFF obrázků s vlastní velikostí:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

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

    // Nastavte velikost obrázku.
    tiffOptions.setImageSize(new Size(1728, 1078));

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

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/) můžete určit preferovaný formát pixelů pro výsledný TIFF obrázek.

Tento kód ukazuje, jak převést prezentaci PowerPointu do TIFF obrázku s vlastním formátem pixelů:

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

Podívejte se na bezplatný konvertor PowerPoint na plakát od Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé prezentace PowerPoint do TIFF?**

Ano. Aspose.Slides umožňuje převádět jednotlivé snímky z prezentací PowerPoint i OpenDocument do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zachovají se animace a přechodové efekty PowerPointu při převodu snímků do TIFF?**

Ne, TIFF je statický formát obrázku. Animace a přechodové efekty tedy nejsou zachovány; jsou exportovány pouze statické snímky slidů.