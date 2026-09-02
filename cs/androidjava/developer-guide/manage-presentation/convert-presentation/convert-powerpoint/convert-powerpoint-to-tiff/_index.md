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
description: "Naučte se snadno převádět prezentace PowerPoint (PPT, PPTX) do vysoce kvalitních TIFF obrázků pomocí Aspose.Slides pro Android s ukázkami kódu v Java."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, známý pro výjimečnou kvalitu a detailní zachování grafiky. Návrháři, fotografové i desktopoví vydavatelé často volí TIFF k zachování vrstev, barevné přesnosti a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a OpenDocument snímky (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace zachovají maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

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

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/) umožňuje určit algoritmus použitý při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se použije jen tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Poznámka" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) je nastavení na úrovni exportu, které vybírá algoritmus konverze pixelů pro celý TIFF obrázek. Pro definování, jak má jednotlivý tvar vypadat, když je aktivní režim černobílého zobrazení, použijte [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Viz [Control Black-and-White Rendering for Shapes](/slides/cs/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.

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

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) umožňuje definovat velikost výsledného obrázku.

Tento kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázky s vlastní velikostí:

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
        Default - Určuje výchozí kompresní schéma (LZW).
        None - Určuje žádnou kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Hloubka závisí na typu komprese a nelze ji nastavit ručně.

    // Nastavte DPI obrázku.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Nastavte velikost obrázku.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Uložte prezentaci jako TIFF se zadanou velikostí.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Převod prezentace do TIFF s vlastním formátem pixelů obrázku**

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/) můžete určit požadovaný formát pixelů pro výsledný TIFF obrázek.

Tento kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázek s vlastním formátem pixelů:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat obsahuje následující hodnoty (jak je uvedeno v dokumentaci):
        Format1bppIndexed - 1 bit na pixel, indexováno.
        Format4bppIndexed - 4 bity na pixel, indexováno.
        Format8bppIndexed - 8 bitů na pixel, indexováno.
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

Vyzkoušejte bezplatný převodník Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides umožňuje převádět jednotlivé snímky z PowerPoint i OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides nekladou žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zachovají se animace a přechodové efekty PowerPointu při převodu snímků do TIFF?**

Ne, TIFF je statický formát obrázku. Animace a přechodové efekty tedy nejsou zachovány; exportují se pouze statické snímky.