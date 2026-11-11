---
title: Render presentatiedia's als SVG-afbeeldingen in Python
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG-exportopties
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in Python en beheer lettertypen, tekst en afbeeldingen met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML‑gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, diavoorstellingen, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een apart SVG‑bestand en stelt u in staat om te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden geschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) wanneer de geëxporteerde SVG compact, voorspelbaar in verschillende browsers of klaar voor interactief gebruik moet zijn.

## **Exporteren van een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) aan, selecteer een dia en schrijf deze naar een stream. Het volgende voorbeeld exporteert elke dia in een presentatie naar een apart SVG‑bestand.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

De bestandsnaam gebruikt [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) in plaats van de lus‑index. U kunt ook een afzonderlijke vorm exporteren met [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) wanneer een diaviewer of webpagina alleen die vorm nodig heeft.

## **SVG‑output configureren**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) regelt de weergave van SVG. Voor tekstkaders omvat [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) het tekstkader in het weergave‑gebied, en [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) bepaalt of de kadrorotatie wordt toegepast. Stel [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) in op `True` wanneer tekst zonder ligaturen moet worden gerenderd.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Tekst en lettertypen beheren**

Bij het exporteren van dia's naar SVG kunt u bepalen of tekst als tekst behouden blijft of wordt omgezet naar vector‑graphics, en hoe externe lettertypen worden opgenomen of gerefereerd. De volgende opties helpen u de visuele consistentie, tekstselectie en lettertype‑afhankelijkheden in de geëxporteerde SVG in balans te brengen.

### **Alle tekst vectoriseren**

Stel [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) in op `True` om alle dia‑tekst als vector‑graphics te schrijven. Dit verwijdert lettertype‑afhankelijkheden en maakt het visuele resultaat consistenter tussen browsers, maar de tekst kan niet langer worden geselecteerd of doorzocht als SVG‑tekst.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Kies hoe externe lettertypen worden behandeld**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `ADD_LINKS_TO_FONT_FILES` om te verwijzen naar afzonderlijke lettertypebestanden, `EMBED` om lettertype‑data op te nemen in de SVG, of `VECTORIZE` om alleen tekst die externe lettertypen gebruikt als graphics te renderen. Controleer de licentie van lettertypen voordat u ze inbedt.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Ingesloten afbeeldingsgrootte verkleinen**

Gebruik [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) om bijgesneden brongebieden weg te laten, en [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) om de JPEG‑coderingskwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de afbeeldings‑fidelity of behouden afbeeldingsdata.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Resolutie van metabestand rasterisatie beheren**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) stelt de onderste resolutielimiet in voor het rasteriseren van metabestanden tijdens SVG‑export. Gebruik dit om detail en bestandsgrootte in balans te brengen wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor de SVG en dwingt niet elk object op de dia om een rasterafbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), dat een EMF‑afbeelding bevat met dicht op elkaar staande diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia op drie rasterisatie‑resoluties via [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Alle andere exportinstellingen blijven identiek zodat de resultaten kunnen worden vergeleken.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

In de output is de EMF omgezet naar één ingesloten PNG in elke SVG. De volgende metingen zijn voor de meegeleverde presentatie; ze vormen geen algemene formule voor het omrekenen van DPI naar pixelafmetingen.

| Metabestand rasterisatie DPI | Ingesloten PNG‑afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De onderstaande vergelijking toont hetzelfde gebied van de ingesloten rasterafbeelding op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelvorming bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG‑bestand groeit. Het verhogen van de waarde verbetert niet noodzakelijk elk detail of verandert elke geëxporteerde afbeelding.

![Detail van vergrote diagonale lijn bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) beheert de vermindering van de afbeeldingsresolutie en kan het effect van het wijzigen van de rasterisatie‑resolutie van metafiles maskeren. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) regelt de JPEG‑coderingskwaliteit, niet de rasterisatie‑resolutie van metafiles.

## **FAQ**

**Wanneer moet ik [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) gebruiken in plaats van [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Gebruik [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar graphics.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en het kiezen van gekoppelde lettertypebestanden wanneer de doelomgeving deze kan leveren. Test het resultaat omdat een lagere afbeeldingsresolutie, een lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteit‑ en grootte‑afwegingen hebben.