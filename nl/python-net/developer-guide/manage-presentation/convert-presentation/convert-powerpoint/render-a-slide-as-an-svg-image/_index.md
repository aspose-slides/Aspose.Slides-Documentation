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

SVG is een schaalbaar XML‑gebaseerd afbeeldingformaat dat goed werkt voor webpublicatie, diaweergave, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een afzonderlijk SVG‑bestand en geeft u controle over hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/) wanneer het geëxporteerde SVG‑bestand compact, voorspelbaar in verschillende browsers, of klaar voor interactief gebruik moet zijn.

## **Dia exporteren als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan, selecteer een dia en schrijf deze naar een stream. Het volgende voorbeeld exporteert elke dia in een presentatie naar een afzonderlijk SVG‑bestand.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

De bestandsnaam gebruikt [Slide.slide_number](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/slide_number/) in plaats van de lusindex. U kunt ook een individuele vorm exporteren met [Shape.write_as_svg](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/write_as_svg/) wanneer een dia‑viewer of webpagina alleen die vorm nodig heeft.

## **SVG‑output configureren**

[SVGOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/) regelt de weergave van SVG. Voor tekstruimtes zorgt [SVGOptions.use_frame_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/use_frame_size/) ervoor dat het tekstruimte‑gebied in het rendergebied wordt opgenomen, en [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) bepaalt of de rotatie van het frame wordt toegepast. Stel [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) in op `True` wanneer tekst moet worden gerenderd zonder ligaturen.

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

### **Alle tekst vectoriseren**

Stel [SVGOptions.vectorize_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/vectorize_text/) in op `True` om alle dia‑tekst als vectorafbeeldingen weg te schrijven. Dit verwijdert afhankelijkheden van lettertypen en maakt het visuele resultaat consistenter over browsers heen, maar de tekst kan niet meer worden geselecteerd of doorzocht als SVG‑tekst.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Kies hoe externe lettertypen worden behandeld**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `ADD_LINKS_TO_FONT_FILES` om naar afzonderlijke lettertypebestanden te verwijzen, `EMBED` om lettertypegegevens in de SVG op te nemen, of `VECTORIZE` om alleen tekst die externe lettertypen gebruikt als grafische weergave te renderen. Controleer de licenties van lettertypen voordat u ze embed.

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

Gebruik [SVGOptions.pictures_compression](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/pictures_compression/) om de resolutie van ingesloten afbeeldingen te verminderen, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) om bijgesneden brongebieden weg te laten, en [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/jpeg_quality/) om de JPEG‑coderingskwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de beeldkwaliteit of de bewaarde afbeeldingsgegevens.

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

## **Veelgestelde vragen**

**Wanneer moet ik [SVGOptions.vectorize_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/vectorize_text/) gebruiken in plaats van [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Gebruik [SVGOptions.vectorize_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/vectorize_text/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt naar grafieken moet worden geconverteerd.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden en het kiezen van gekoppelde lettertypebestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere afbeeldingsresolutie, lagere JPEG‑kwaliteit en vectoriseerde tekst elk verschillende kwaliteits‑ en grootte‑afwegingen hebben.