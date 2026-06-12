---
title: Converteer PowerPoint-presentaties naar TIFF in Python
titlelink: PowerPoint naar TIFF
type: docs
weight: 90
url: /nl/python-net/convert-powerpoint-to-tiff/
keywords:
- converteer PowerPoint
- converteer OpenDocument
- converteer presentatie
- converteer dia
- PowerPoint naar TIFF
- OpenDocument naar TIFF
- presentatie naar TIFF
- dia naar TIFF
- PPT naar TIFF
- PPTX naar TIFF
- ODP naar TIFF
- Python
- Aspose.Slides
description: "Leer hoe u eenvoudig PowerPoint‑presentaties (PPT, PPTX) en OpenDocument‑presentaties (ODP) kunt omzetten naar hoogwaardige TIFF‑afbeeldingen met Aspose.Slides voor Python via .NET. Stapsgewijze handleiding met voorbeeldcode inbegrepen."
---
## **Inleiding**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktop‑publishers kiezen vaak TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen van hun afbeeldingen te behouden.

Met Aspose.Slides kun je moeiteloos je PowerPoint‑dia’s (PPT, PPTX) en OpenDocument‑dia’s (ODP) rechtstreeks omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat je presentaties hun maximale visuele getrouwheid behouden.

## **Een presentatie naar TIFF converteren**

Met de [save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/#methods)‑methode die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse, kun je snel een volledige PowerPoint‑presentatie naar TIFF omzetten. De gegenereerde TIFF‑afbeeldingen volgen de standaarddia‑grootte.

De volgende Python‑code laat zien hoe je een PowerPoint‑presentatie naar TIFF converteert:

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
with slides.Presentation("presentation.pptx") as presentation:
    # Sla de presentatie op als TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **Een presentatie naar zwart‑wit TIFF converteren**

De eigenschap [bw_conversion_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) in de [TiffOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/)‑klasse stelt je in staat het algoritme te kiezen dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart‑wit TIFF. Merk op dat deze instelling alleen van toepassing is wanneer de eigenschap [compression_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/compression_type/) is ingesteld op `CCITT4` of `CCITT3`.

Stel dat we een bestand “sample.pptx” hebben met de volgende dia:

![Een presentatiedia](slide_black_and_white.png)

De onderstaande Python‑code laat zien hoe je de gekleurde dia naar een zwart‑wit TIFF converteert:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Het resultaat:

![Zwart‑wit TIFF](TIFF_black_and_white.png)

## **Een presentatie naar TIFF converteren met aangepaste grootte**

Als je een TIFF‑afbeelding nodig hebt met specifieke afmetingen, kun je de gewenste waarden instellen via de eigenschappen die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/). Bijvoorbeeld, de eigenschap [image_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/image_size/) maakt het mogelijk de grootte van de resulterende afbeelding te definiëren.

De volgende Python‑code toont hoe je een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte converteert:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # Stel het compressietype in.
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

    # Stel de DPI van de afbeelding in.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # Stel de afbeeldingsgrootte in.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # Sla de presentatie op als TIFF met de opgegeven grootte.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Een presentatie naar TIFF converteren met aangepast pixelindeling van de afbeelding**

Met de eigenschap [pixel_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/pixel_format/) van de [TiffOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/)‑klasse kun je het gewenste pixelformaat voor de resulterende TIFF‑afbeelding opgeven.

De onderstaande Python‑code laat zien hoe je een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixelformaat converteert:

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
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

    # Sla de presentatie op als TIFF met de opgegeven afbeeldingsgrootte.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="primary" %}}

Bekijk de gratis PowerPoint‑naar‑poster‑converter van Aspose op [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/nl/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik een enkele dia in plaats van de volledige PowerPoint‑presentatie naar TIFF converteren?**

Ja. Aspose.Slides stelt je in staat om individuele dia’s uit PowerPoint‑ en OpenDocument‑presentaties afzonderlijk naar TIFF‑afbeeldingen te converteren.

**Zijn er beperkingen in het aantal dia’s bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides legt geen limiet op aan het aantal dia’s. Je kunt presentaties van elke omvang naar TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia’s naar TIFF?**

Nee, TIFF is een statisch beeldformaat. Animaties en overgangseffecten worden niet bewaard; alleen statische snapshots van de dia’s worden geëxporteerd.