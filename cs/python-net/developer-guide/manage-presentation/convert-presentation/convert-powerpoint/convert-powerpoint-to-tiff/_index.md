---
title: Převod prezentací PowerPoint do TIFF v Pythonu
titlelink: PowerPoint do TIFF
type: docs
weight: 90
url: /cs/python-net/convert-powerpoint-to-tiff/
keywords:
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- převést snímek
- PowerPoint do TIFF
- OpenDocument do TIFF
- prezentaci do TIFF
- snímek do TIFF
- PPT do TIFF
- PPTX do TIFF
- ODP do TIFF
- Python
- Aspose.Slides
description: "Zjistěte, jak snadno převést prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) do vysoce kvalitních TIFF obrázků pomocí Aspose.Slides pro Python přes .NET. Průvodce krok za krokem s ukázkovými kódy."
---
## **Úvod**

TIFF (**Tagged Image File Format**) je široce používaný bezztrátový rastrový formát obrázků, známý pro výjimečnou kvalitu a podrobnou zachování grafiky. Návrháři, fotografové a desktopoví vydavatelé často volí TIFF pro zachování vrstev, přesnosti barev a původního nastavení v jejich obrázcích.

Pomocí Aspose.Slides můžete snadno převést své PowerPoint snímky (PPT, PPTX) a snímky OpenDocument (ODP) přímo na vysoce kvalitní TIFF obrázky, čímž zajistíte, že vaše prezentace si zachovají maximální vizuální věrnost.

## **Převod prezentace do TIFF**

Pomocí metody [save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/#methods) poskytované třídou [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) můžete rychle převést celou PowerPoint prezentaci do TIFF. Výsledné TIFF obrázky odpovídají výchozí velikosti snímku.

Tento Python kód ukazuje, jak převést PowerPoint prezentaci do TIFF:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace (PPT, PPTX, ODP atd.).
with slides.Presentation("presentation.pptx") as presentation:
    # Uložte prezentaci jako TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **Převod prezentace do černobílého TIFF**

Vlastnost [bw_conversion_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/) vám umožňuje určit algoritmus použitý při převodu barevného snímku nebo obrázku do černobílého TIFF. Všimněte si, že toto nastavení platí pouze tehdy, když je vlastnost [compression_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/compression_type/) nastavena na `CCITT4` nebo `CCITT3`.

Předpokládejme, že máme soubor "sample.pptx" s následujícím snímkem:

![Snímek prezentace](slide_black_and_white.png)

Tento Python kód ukazuje, jak převést barevný snímek do černobílého TIFF:

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

## **Převod prezentace do TIFF s vlastní velikostí**

Pokud potřebujete TIFF obrázek s konkrétními rozměry, můžete nastavit požadované hodnoty pomocí vlastností dostupných ve třídě [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/). Například vlastnost [image_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/image_size/) vám umožní definovat velikost výsledného obrázku.

Tento Python kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázky s vlastní velikostí:

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

## **Převod prezentace do TIFF s vlastním formátem pixelů obrazu**

Pomocí vlastnosti [pixel_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/pixel_format/) ze třídy [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/) můžete určit preferovaný formát pixelů pro výsledný TIFF obrázek.

Tento Python kód ukazuje, jak převést PowerPoint prezentaci na TIFF obrázek s vlastním formátem pixelů:

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

    # Uložte prezentaci jako TIFF s určenou velikostí obrázku.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="primary" %}}
Vyzkoušejte bezplatný konvertér PowerPoint na plakát od Aspose.[BEZPLATNÝ konvertér PowerPoint na plakát](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu převést jednotlivý snímek místo celé PowerPoint prezentace do TIFF?**

Ano. Aspose.Slides umožňuje převádět jednotlivé snímky z PowerPoint a OpenDocument prezentací do TIFF obrázků samostatně.

**Existuje nějaký limit počtu snímků při převodu prezentace do TIFF?**

Ne, Aspose.Slides nekladá žádná omezení na počet snímků. Můžete převádět prezentace libovolné velikosti do formátu TIFF.

**Jsou animace a přechodové efekty PowerPointu zachovány při převodu snímků do TIFF?**

Ne, TIFF je statický formát obrázku. Proto nejsou animace a přechodové efekty zachovány; jsou exportovány pouze statické snímky snímků.