---
title: Render Presentatie Dia's als SVG-afbeeldingen in Python via Java
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG-exportopties
- interactieve SVG
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in Python via Java en beheer lettertypes, tekst, afbeeldingen, ID's en events met Aspose.Slides."
---
## **Overview**

SVG is een schaalbaar, op XML gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, slide‑viewers, toegankelijkheidsprocessen en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een apart SVG‑bestand en stelt u in staat hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden geschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Export a Slide as SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/), selecteer een dia, en schrijf deze naar een stream met [Slide.writeAsSvg](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/). De voorbeelden vereisen een bestaand `presentation.pptx`‑bestand. Elk voorbeeld start de JVM indien nodig en sluit zijn output‑streams. Het onderstaande voorbeeld exporteert elke dia in een presentatie naar een apart SVG‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

De bestandsnaam gebruikt [Slide.getSlideNumber](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getSlideNumber) in plaats van de lus‑index. U kunt ook een afzonderlijke vorm exporteren met [Shape.writeAsSvg](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/) wanneer een slide‑viewer of webpagina alleen die vorm nodig heeft.

## **Configure SVG Output**

[SVGOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/) regelt de SVG‑rendering. Voor tekstframes zorgt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setUseFrameSize) ervoor dat het tekstframe in het rendergebied wordt opgenomen, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setUseFrameRotation) bepaalt of de rotatie van het frame wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) in op `True` wanneer tekst moet worden gerenderd zonder ligaturen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Control Text and Fonts**

### **Vectorize All Text**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setVectorizeText) in op `True` om alle dia‑tekst als vectorafbeeldingen te schrijven. Dit elimineert afhankelijkheden van lettertypen en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Choose How External Fonts Are Handled**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om naar afzonderlijke lettertypebestanden te verwijzen, `Embed` om lettertype‑data in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als grafieken te renderen. Controleer de licentie van het lettertype voordat u lettertypen insluit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Reduce Embedded Image Size**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setPicturesCompression) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) om bijgesneden bron‑gebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setJpegQuality) om de JPEG‑coderingskwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van beeld‑fidelity of behouden afbeeldingsdata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Assign Stable IDs to Shapes and Text**

Gebruik een Python‑formatteercontroller die via `jpype.JProxy` is geregistreerd om [SvgShape.setId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgshape/#setId)‑waarden toe te wijzen aan vormen en [SvgTSpan.setId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgtspan/#setId)‑waarden aan tekst‑`tspan`‑elementen. Ken de proxy toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

De volgende controller maakt gebruik van [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getOfficeInteropShapeId), die stabiel is gedurende de levensduur van de vorm, en een herhaalbare teller voor de tekstdelen. Dit maakt de gegenereerde ID’s geschikt voor nabewerking van een ongewijzigde presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Add SVG Event Handlers**

In een Python‑formatteercontroller, roep [SvgShape.setEventHandler](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgshape/#setEventHandler) aan met een [SvgEvent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgevent/)‑waarde om een JavaScript‑event‑handler toe te voegen aan een geëxporteerde vorm. Registreer de controller via `jpype.JProxy` en ken deze toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

De host‑pagina kan de JavaScript‑functie definiëren waar de handler naar verwijst. Het toewijzen van ID’s en event‑handlers maakt slide‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑processen mogelijk.

## **FAQ**

**When should I use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgoptions/#setVectorizeText) instead of [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Gebruik [SVGOptions.setVectorizeText] wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize] wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar grafieken.

**What is the best way to make an SVG smaller?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en kies gekoppelde lettertypebestanden wanneer de doelomgeving ze kan serveren. Test het resultaat omdat een lagere afbeeldingresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteit‑ en grootte‑afwegingen hebben.

**Can I modify exported SVG elements after export?**

Ja. Wijs ID’s toe via een formatteercontroller, en selecteer vervolgens de overeenkomstige SVG‑elementen in uw nabewerkings‑tool of browserscript.