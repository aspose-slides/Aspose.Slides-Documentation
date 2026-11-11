---
title: Render presentatiedia's als SVG-afbeeldingen in Python via Java
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
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in Python via Java en beheer lettertypen, tekst, afbeeldingen, ID's en gebeurtenissen met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML‑gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, diavoorlichters, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een afzonderlijk SVG‑bestand en stelt u in staat te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Exporteer een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream met [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). De voorbeelden vereisen een bestaand bestand `presentation.pptx`. Elk voorbeeld start de JVM indien nodig en sluit zijn outputstreams. Het onderstaande voorbeeld exporteert elke dia in een presentatie naar een afzonderlijk SVG‑bestand.

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

De bestandsnaam gebruikt [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) in plaats van de lusindex. U kunt ook een individueel object exporteren met [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) wanneer een diavoorleider of webpagina alleen dat object nodig heeft.

## **Configureer SVG‑output**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) regelt de SVG‑weergave. Voor tekstkaders omvat [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) het tekstkader in het rendergebied, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) bepaalt of de kadrorotatie wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) in op `True` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Beheer afsnijden van lijnuiteinden bij pijlpunt**

SVG 1.1 heeft geen instelling voor marker‑inzet om te bepalen waar een lijn moet stoppen onder een pijlpunt. Standaard verkort Aspose.Slides de geëxporteerde lijn zodat de streep niet door de marker heen steekt. Roep [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) aan met `True` om de streep helemaal tot het oorspronkelijke eindpunt van de lijn te tekenen. Deze instelling heeft alleen effect op de SVG‑output. De lijn behoudt zijn positie en lengte op de dia.

Het voorbeeld tekent driehoek‑ en diamantenpijlpunt op lijnen van respectievelijk 2 en 10 punten breed. Het exporteert dezelfde dia twee keer, waarbij alleen de afsnij‑optie wordt aangepast.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

De vergelijking toont de driehoekige pijlpunt op de 10‑punten lijn. Met afsnijden ingeschakeld is de punt scherp. Met afsnijden uitgeschakeld steekt de streep door de schuine zijden van de marker en blijft er een stompe punt over.

![Vergrote 10‑punten driehoek met een scherpe punt wanneer afsnijden is ingeschakeld en een stompe punt wanneer afsnijden is uitgeschakeld](line-end-cropping.png)

In de overige lijnen uit het voorbeeld is de uitsteekende streep minder zichtbaar op de 2‑punten driehoek. Het gevulde diamant dekt het einde van de streep af bij beide breedtes.

## **Beheer tekst en lettertypen**

Bij het exporteren van dia's naar SVG kunt u bepalen of tekst behouden blijft als tekst of wordt omgezet naar vectorafbeeldingen, en hoe externe lettertypen worden opgenomen of gerefereerd. De volgende opties helpen u visuele consistentie, tekstselectie en lettertype‑afhankelijkheden in de geëxporteerde SVG in balans te brengen.

### **Vectoriseer alle tekst**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) in op `True` om alle dia‑tekst als vectorafbeeldingen te schrijven. Dit verwijdert lettertype‑afhankelijkheden en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet meer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

### **Kies hoe externe lettertypen worden verwerkt**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om te verwijzen naar afzonderlijke fontbestanden, `Embed` om fontgegevens in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als afbeeldingen weer te geven. Controleer de licentie van het lettertype vóór het insluiten van fonts.

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

## **Verminder de grootte van ingesloten afbeeldingen**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) om de JPEG‑codeerkwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van afbeeldingsfidelity of behouden afbeeldingsgegevens.

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

## **Beheer resolutie van metafile‑rasterisatie**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) stelt de ondergrens voor de resolutie van het rasteren van metafiles in tijdens SVG‑export. Gebruik dit om detail en bestandsgrootte in balans te brengen wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor de SVG en dwingt niet elk object op de dia om een rasterafbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), die een EMF‑afbeelding bevat met dicht op elkaar staande diagonale lijnen. Het onderstaande voorbeeld exporteert de eerste dia op drie rasterisatie‑resoluties via [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Alle andere exportinstellingen blijven gelijk zodat de resultaten kunnen worden vergeleken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

In de output werd de EMF één ingesloten PNG in elke SVG. De volgende metingen gelden voor de meegeleverde presentatie; ze vormen geen algemene formule om DPI om te rekenen naar pixelafmetingen.

| Metafile‑rasterisatie DPI | Ingesloten PNG‑afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De vergelijking hieronder toont hetzelfde gebied van de ingesloten raster op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG‑bestand groeit. Het verhogen van de waarde verbetert niet per se elk detail of wijzigt elke geëxporteerde afbeelding.

![Vergrote details van diagonale lijnen bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) regelt de verlaging van de beeldresolutie en kan het effect van het wijzigen van de metafile‑rasterisatie‑resolutie maskeren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) regelt de JPEG‑codeerkwaliteit, niet de metafile‑rasterisatie‑resolutie.

## **Wijs stabiele ID's toe aan objecten en tekst**

Gebruik een Python‑opmaakcontroller die is geregistreerd via `jpype.JProxy` om [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId)‑waarden toe te wijzen aan objecten en [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId)‑waarden aan tekst‑`tspan`‑elementen. Ken de proxy toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

De volgende controller gebruikt [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), die gedurende de levensduur van het object stabiel is, en een herhaalbare teller voor de tekst‑spans. Dit maakt de gegenereerde ID's geschikt voor nabewerking van een onveranderde presentatie.

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

## **Voeg SVG‑gebeurtenishandlers toe**

In een Python‑opmaakcontroller, roep [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) aan met een [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/)‑waarde om een JavaScript‑gebeurtenishandler toe te voegen aan een geëxporteerd object. Registreer de controller via `jpime.JProxy` en wijs deze toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

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

De host‑pagina kan de JavaScript‑functie definiëren die door de handler wordt gerefereerd. Het toewijzen van ID's en gebeurtenishandlers maakt diavoorlichters, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows mogelijk.

## **Veelgestelde vragen**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) wanneer alleen tekst die externe lettertypen gebruikt, moet worden omgezet naar afbeeldingen.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en het kiezen van gekoppelde fontbestanden wanneer de doenomgeving ze kan leveren. Test het resultaat omdat een lagere afbeeldingsresolutie, een lagere JPEG‑kwaliteit en vectorisatie van tekst elk verschillende kwaliteit‑en‑grootte‑afwegingen hebben.

**Kan ik geëxporteerde SVG‑elementen na de export wijzigen?**

Ja. Ken ID's toe via een opmaakcontroller, en selecteer vervolgens de overeenkomende SVG‑elementen in uw nabewerkingstool of browserscript.