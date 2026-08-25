---
title: Převod PowerPoint prezentací do TIFF v Javě
titlelink: PowerPoint na TIFF
type: docs
weight: 90
url: /cs/java/convert-powerpoint-to-tiff/
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
- Java
- Aspose.Slides
description: "Zjistěte, jak snadno převést PowerPoint (PPT, PPTX) prezentace na vysoce kvalitní TIFF obrázky pomocí Aspose.Slides pro Javu, s ukázkami kódu."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, známý pro svou výjimečnou kvalitu a podrobné zachování grafiky. Návrháři, fotografové a desktopeři často volí TIFF k zachování vrstev, barevné přesnosti a původních nastavení ve svých obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a snímky OpenDocument (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace zachovají maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [uložit](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento kód demonstruje, jak převést PowerPoint prezentaci do TIFF:

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

Metoda [setBwConversionMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/) umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení platí pouze tehdy, když je metoda [setCompressionType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Poznámka" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) je nastavení na úrovni exportu, které vybírá algoritmus konverze pixelů pro celý TIFF obrázek. Pro definování, jak má vypadat jednotlivý tvar při aktivním černobílém režimu zobrazení, použijte [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Viz [Řízení černobílého vykreslování pro tvary](/slides/cs/java/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.
{{% /alert %}}

Řekněme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento kód demonstruje, jak převést barevný snímek na černobílý TIFF:

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

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí metod dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/). Například metoda [setImageSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) umožňuje definovat velikost výsledného obrázku.

Tento kód demonstruje, jak převést PowerPoint prezentaci na TIFF obrázky s vlastní velikostí:

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

## **Převod prezentace do TIFF s vlastní pixlovou formou obrázku**

Pomocí metody [setPixelFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/) můžete určit preferovaný formát pixelů pro výsledný TIFF obrázek.

Tento kód demonstruje, jak převést PowerPoint prezentaci na TIFF obrázek s vlastním formátem pixelů:

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
Podívejte se na [ZDARMA konvertor PowerPoint na poster](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online) od Aspose.
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides vám umožňuje převádět jednotlivé snímky z PowerPoint i OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit na počet snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides neklade žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Zachovají se při převodu snímků do TIFF animace a přechodové efekty PowerPointu?**

Ne, TIFF je statický formát obrázku. Animace a přechodové efekty tedy nejsou zachovány; jsou exportovány pouze statické snímky snímků.