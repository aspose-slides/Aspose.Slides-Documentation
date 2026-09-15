---
title: Maak een presentatieweergave in Python via Java
linktitle: Presentatieviewer
type: docs
weight: 50
url: /nl/python-java/presentation-viewer/
keywords:
  - presentatie bekijken
  - presentatieviewer
  - presentatieviewer maken
  - PPT bekijken
  - PPTX bekijken
  - ODP bekijken
  - PowerPoint
  - OpenDocument
  - presentatie
  - Python
  - Java
  - Aspose.Slides
description: "Maak een aangepaste presentatieviewer in Python via Java met Aspose.Slides. Bekijk eenvoudig PowerPoint- en OpenDocument-bestanden zonder Microsoft PowerPoint."
---
## **Inleiding**

Aspose.Slides voor Python via Java wordt gebruikt om presentatiebestanden met dia's te maken. Deze dia's kunnen bijvoorbeeld worden bekeken door de presentatie te openen in Microsoft PowerPoint. Soms moeten ontwikkelaars de dia's echter als afbeeldingen bekijken in hun favoriete afbeeldingsviewer of hun eigen presentatieweergave maken. In dergelijke gevallen stelt Aspose.Slides u in staat om een individuele dia als afbeelding te exporteren. Dit artikel beschrijft hoe u dit doet.

## **Genereer een SVG-afbeelding van een dia**

Om een SVG-afbeelding van een presentatiedia te genereren met Aspose.Slides, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
1. Haal de dia-referentie op via de index.
1. Open een byte‑stroom.
1. Sla de dia op als een SVG‑afbeelding naar de stream en schrijf deze naar een bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Genereer een SVG met een aangepaste vorm‑ID**

Aspose.Slides kan worden gebruikt om een [SVG](https://docs.fileformat.com/page-description-language/svg/) te genereren van een dia met een aangepaste vorm‑ID. Gebruik hiervoor de [SvgShape.setId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgshape/#setId)‑methode van [SvgShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` kan worden gebruikt om de vorm‑ID in te stellen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Maak een miniatuurafbeelding van een dia**

Aspose.Slides helpt u miniatuurafbeeldingen van dia's te genereren. Om een miniatuur van een dia te genereren met Aspose.Slides, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
1. Haal de dia-referentie op via de index.
1. Haal de miniatuurafbeelding van de verwijzende dia op met een gedefinieerde schaal.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Maak een miniatuur van een dia met gebruikers‑gedefinieerde afmetingen**

Om een miniatuurafbeelding van een dia met door de gebruiker opgegeven afmetingen te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
1. Haal de dia-referentie op via de index.
1. Haal de miniatuurafbeelding van de verwijzende dia op met de opgegeven afmetingen.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Maak een miniatuur van een dia met presentatienotities**

Om de miniatuur van een dia met presentatienotities te genereren met Aspose.Slides, volgt u de onderstaande stappen:

1. Maak een instantie van de [RenderingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/renderingoptions/) klasse aan.
1. Gebruik de [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions)‑methode om de positie van de presentatienotities in te stellen.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
1. Haal de dia-referentie op via de index.
1. Haal de miniatuurafbeelding van de verwijzende dia op met de weergave‑opties.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingsformaat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Live‑voorbeeld**

U kunt de gratis app [**Aspose.Slides Viewer**](https://products.aspose.app/slides/nl/viewer/) proberen om te zien wat u kunt implementeren met de Aspose.Slides‑API:

![Online PowerPoint viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kan ik een presentatieviewer inbedden in een webapplicatie?**

Ja. U kunt Aspose.Slides aan de serverzijde gebruiken om dia's te renderen als afbeeldingen of HTML en deze in de browser weer te geven. Navigatie‑ en zoomfuncties kunnen met JavaScript worden geïmplementeerd voor een interactieve ervaring.

**Wat is de beste manier om dia's weer te geven in een aangepaste viewer?**

De aanbevolen aanpak is om elke dia als afbeelding (bijv. PNG of SVG) te renderen of deze te converteren naar HTML met Aspose.Slides, en vervolgens de output weer te geven in een picture‑box (voor desktop) of HTML‑container (voor het web).

**Hoe ga ik om met grote presentaties met veel dia's?**

Voor grote presentaties kunt u overwegen om dia's lazy te laden of on‑demand te renderen. Dit betekent dat de inhoud van een dia alleen wordt gegenereerd wanneer de gebruiker ernaartoe navigeert, waardoor geheugen- en laadtijd worden verminderd.