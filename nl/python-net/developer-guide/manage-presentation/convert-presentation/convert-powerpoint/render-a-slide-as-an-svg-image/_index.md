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

SVG is een schaalbaar XML-gebaseerd afbeeldingformaat dat goed werkt voor webpublicatie, presentatie-viewers, toegankelijkheids-workflows en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een apart SVG-bestand en geeft u controle over hoe tekst, lettertypen, afbeeldingen en SVG-elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) wanneer het geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Een dia exporteren als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream. Het volgende voorbeeld exporteert elke dia in een presentatie als een afzonderlijk SVG-bestand.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

De bestandsnaam gebruikt [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) in plaats van de lus-index. U kunt ook een afzonderlijke vorm exporteren met [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) wanneer een presentatie-viewer of webpagina alleen die vorm nodig heeft.

## **SVG-output configureren**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) beheert de weergave van SVG. Voor tekstframes zorgt [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) ervoor dat het tekstframe wordt meegenomen in het weergavegebied, en [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) bepaalt of de rotatie van het frame wordt toegepast. Stel [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) in op `True` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Lijneinde-bijsnijden bij pijlpunt regelen**

SVG 1.1 heeft geen instelling voor marker-inset om te specificeren waar een lijn moet stoppen onder een pijlpunt. Standaard verkort Aspose.Slides de geëxporteerde lijn zodat de streek niet door de marker heen steekt. Stel [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) in op `True` om de streek helemaal tot aan het oorspronkelijke eindpunt van de lijn te tekenen. Deze instelling heeft alleen invloed op de SVG-output. De lijn behoudt zijn positie en lengte op de dia.

Het voorbeeld tekent driehoek- en ruit-pijlpuntjes op lijnen van 2 en 10 punten breed. Het exporteert dezelfde dia twee keer, waarbij alleen de bijsnijdingsoptie wordt gewijzigd.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

De vergelijking toont de driehoek-pijlpunt op de 10-punten-lijn. Met bijsnijden ingeschakeld is de punt scherp. Met bijsnijden uitgeschakeld steekt de streek door de schuine zijden van de marker en heeft een platte punt.

![Vergrote 10-punten-driehoek met een scherpe punt wanneer bijsnijden is ingeschakeld en een platte punt wanneer bijsnijden is uitgeschakeld](line-end-cropping.png)

In de andere lijnen van het voorbeeld is de uitstulpende streek minder zichtbaar op de 2-punten-driehoek. Het gevulde ruit-vormige figuur bedekt het einde van de streek bij beide breedtes.

## **Tekst en lettertypen beheren**

Bij het exporteren van dia’s naar SVG kunt u bepalen of tekst behouden blijft als tekst of wordt omgezet naar vectorafbeeldingen, en hoe externe lettertypen worden opgenomen of verwezen. De volgende opties helpen u om visuele consistentie, tekstselectie en lettertype-afhankelijkheden in de geëxporteerde SVG in balans te brengen.

### **Alle tekst vectoriseren**

Stel [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) in op `True` om alle dia-tekst weg te schrijven als vectorafbeeldingen. Dit elimineert afhankelijkheden van lettertypen en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG-tekst.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Kies hoe externe lettertypen worden behandeld**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) waarde voor lettertypen die extern worden geladen. Kies `ADD_LINKS_TO_FONT_FILES` om te verwijzen naar afzonderlijke lettertypebestanden, `EMBED` om lettertype-data op te nemen in de SVG, of `VECTORIZE` om alleen tekst die externe lettertypen gebruikt als afbeeldingen weer te geven. Controleer de licentie van het lettertype vóór het insluiten van lettertypen.

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

Gebruik [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) om bijgesneden brongebieden weg te laten, en [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) om de JPEG-compressiekwaliteit te regelen. Deze instellingen verminderen de bestandsgrootte ten koste van afbeeldingskwaliteit of bewaarde afbeeldingsdata.

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

## **Resolutie van metafile-rasterisatie beheren**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) bepaalt de ondergrens van de resolutie voor het rasteriseren van metafiles tijdens SVG-export. Gebruik dit om details en bestandsgrootte in balans te brengen wanneer een EMF- of WMF-afbeelding wordt gerasterd. Het definieert geen globale DPI voor de SVG en dwingt niet af dat elk object op de dia een rasterafbeelding wordt.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), dat een EMF-afbeelding bevat met nauw op elkaar staande diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia met drie rasterisatie-resoluties via [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Alle overige exportinstellingen blijven identiek zodat de resultaten kunnen worden vergeleken.

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

In de uitvoer is de EMF omgezet naar één ingesloten PNG in elke SVG. De volgende metingen hebben betrekking op de meegeleverde presentatie; ze vormen geen algemene formule om DPI om te rekenen naar pixelafmetingen.

| Metafile rasterisatie DPI | Ingesloten PNG-afmetingen | SVG-bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De vergelijking hieronder toont hetzelfde gebied van de ingesloten raster-afbeelding op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen duidelijke pixelvorming bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG-bestand groter wordt. Het verhogen van de waarde verbetert niet per se elk detail of verandert elke geëxporteerde afbeelding.

![Vergrote detail van diagonale lijnen bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) regelt de vermindering van de beeldresolutie en kan het effect maskeren van het wijzigen van de resolutie van metafile-rasterisatie. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) regelt de JPEG-compressiekwaliteit, niet de resolutie van metafile-rasterisatie.

## **FAQ**

**Wanneer moet ik [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) gebruiken in plaats van [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Gebruik [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt, moet worden omgezet naar afbeeldingen.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden beeldgebieden, en het kiezen van gekoppelde lettertypebestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere beeldresolutie, lagere JPEG-kwaliteit en vectorisatie van tekst elk andere kwaliteit- en grootte-afwegingen met zich meebrengen.