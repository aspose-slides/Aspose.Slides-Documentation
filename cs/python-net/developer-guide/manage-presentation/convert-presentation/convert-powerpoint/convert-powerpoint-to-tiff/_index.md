---
title: Převod prezentací PowerPoint do TIFF v Pythonu
titlelink: PowerPoint na TIFF
type: docs
weight: 90
url: /cs/python-net/convert-powerpoint-to-tiff/
keywords:
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- převést snímek
- PowerPoint na TIFF
- OpenDocument na TIFF
- prezentace na TIFF
- snímek na TIFF
- PPT na TIFF
- PPTX na TIFF
- ODP na TIFF
- Python
- Aspose.Slides
description: "Naučte se snadno převést prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) do vysoce kvalitních TIFF obrázků pomocí Aspose.Slides pro Python na .NET. Krok za krokem průvodce s ukázkovým kódem."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, známý pro svou vynikající kvalitu a podrobnou zachování grafiky. Designéři, fotografové a desktopoví vydavatelé často volí TIFF k zachování vrstev, přesnosti barev a původních nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace zachovají maximální vizuální věrnost.

## **Převod prezentace na TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/#methods), kterou poskytuje třída [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), můžete rychle převést celou prezentaci PowerPoint na TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento Python kód ukazuje, jak převést prezentaci PowerPoint na TIFF:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
with slides.Presentation("presentation.pptx") as presentation:
    # Uložte prezentaci jako TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **Převod prezentace na černobílý TIFF**

Vlastnost [bw_conversion_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/) umožňuje určit algoritmus používaný při převodu barevného snímku nebo obrázku na černobílý TIFF. Všimněte si, že toto nastavení se použije pouze tehdy, když je vlastnost [compression_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/compression_type/) nastavena na `CCITT4` nebo `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) je nastavení na úrovni exportu, které vybírá algoritmus pixelové konverze pro celý TIFF obrázek. Chcete-li definovat, jak má vypadat jednotlivý tvar při aktivovaném režimu černobílého zobrazení, použijte [Shape.black_white_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/black_white_mode/). Viz [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes) pro příklady.
{{% /alert %}}

Řekněme, že máme soubor „sample.pptx“ s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento Python kód ukazuje, jak převést barevný snímek na černobílý TIFF:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Výsledek:

![Černobílý TIFF](TIFF_black_and_white.png)

## **Převod prezentace na TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí vlastností dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/). Například vlastnost [image_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/image_size/) vám umožní definovat velikost výsledného obrázku.

Tento Python kód ukazuje, jak převést prezentaci PowerPoint na TIFF obrázky s vlastní velikostí:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # Nastavte typ komprese.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # Nastavte DPI obrázku.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # Nastavte velikost obrázku.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # Uložte prezentaci jako TIFF s určenou velikostí.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Převod prezentace na TIFF s vlastním formátem pixelů obrázku**

Pomocí vlastnosti [pixel_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/pixel_format/) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/) můžete zadat preferovaný formát pixelů pro výsledný TIFF obrázek.

Tento Python kód ukazuje, jak převést prezentaci PowerPoint na TIFF obrázek s vlastním formátem pixelů:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # Uložte prezentaci jako TIFF s určeným formátem pixelů.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="info" %}}
Podívejte se na [ZDARMA konvertor PowerPoint na poster od Aspose](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé prezentace PowerPoint na TIFF?**

Ano. Aspose.Slides umožňuje převádět jednotlivé snímky z prezentací PowerPoint a OpenDocument do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace na TIFF?**

Ne, Aspose.Slides nekladí žádná omezení na počet snímků. Můžete převádět prezentace jakékoli velikosti do formátu TIFF.

**Jsou animační a přechodové efekty PowerPointu zachovány při převodu snímků na TIFF?**

Ne, TIFF je statický obrazový formát. Proto nejsou zachovány animace a přechodové efekty; exportovány jsou pouze statické snímky snímků.