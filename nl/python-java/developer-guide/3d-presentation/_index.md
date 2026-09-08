---
title: 3D‑effecten maken in presentaties met Python
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D presentatie
- 3D rotatie
- 3D diepte
- 3D extrusie
- 3D verloop
- 3D tekst
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas 3D‑effecten toe en render ze voor PowerPoint‑vormen en -tekst in Python via Java met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D‑tekst."
---
## **Overzicht**

Aspose.Slides for Python via Java kan PowerPoint‑achtige 3D‑opmaak voor vormen en tekst maken, bewerken, behouden en renderen. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, afschuiningen, verlichting, materiaal, verloop‑ of afbeeldingvullingen en 3D‑tekst.

{{% alert color="info" title="Opmerking" %}}

Dit artikel gaat over 3D‑opmaakeffecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van zelfstandige 3D‑modelfiles. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.

{{% /alert %}}

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides`, start de JVM indien nodig, en importeert vervolgens de API. Het voorbeeld met een afbeelding‑vulling vereist een bestand `image.jpg` in de werkmap.

## **3D‑Opmaakconcepten**

Gebruik [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getThreeDFormat) om 3D‑opmaak op een vorm toe te passen. Het geretourneerde format‑object beheert de 3D‑scene voor die vorm.

Voor tekst gebruikt u [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#getThreeDFormat). Hiermee wordt 3D‑opmaak op het tekstframe toegepast in plaats van op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het beheert | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getCamera) | Kijkpunt, vooringestelde cameratype, rotatie, zoom en perspectief. | Het object roteren in de 3D‑ruimte of een PowerPoint‑3D‑rotatie‑preset gebruiken. |
| [getLightRig](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getLightRig) | Lichtpreset, richting en lichtrotatie. | De manier aanpassen waarop highlights en schaduwen op het 3D‑oppervlak verschijnen. |
| [getMaterial](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getMaterial) en [setMaterial](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setMaterial) | Oppervlakmateriaal, zoals vlak, mat, plastic of metaal. | Hetzelfde object er vlakker, zachter, glanzender of metaalachtig laten uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getExtrusionHeight) en [setExtrusionHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Hoe ver de vorm achter de voorzijde uitsteekt. | Een platte vorm omzetten naar een duidelijk dikke 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getExtrusionColor) | Kleur van de geëxtrudeerde zijkanten. | Diepte zichtbaar maken of de zijkleur afstemmen op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getDepth) en [setDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setDepth) | Extra 3D‑diepte die PowerPoint‑3D‑opmaak gebruikt. | Diepte fijnafstellen voor vormen of tekst, vooral in combinatie met afschuining en materiaal. |
| [getBevelTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getBevelTop) en [getBevelBottom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getBevelBottom) | Verhoogde of afgeronde randen op de voor‑ en achterkant. | Een verzachte of gevormde rand toevoegen in plaats van een scherpe platte vlak. |
| [getContourColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getContourWidth) en [setContourWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setContourWidth) | Omtrek rond het 3D‑object. | De objectgrens benadrukken in de gerenderde output. |

## **Een 3D‑Vorm Maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D uitziet:

- Camerainstellingen, want het standaardfrontbeeld kan de extrusie verbergen.
- Verlichtingsinstellingen, want verlichting maakt de vlakken en zijden leesbaar.
- Materiaalinstellingen, want het oppervlak beïnvloedt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, want een platte vorm heeft dikte nodig.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde, past 3D‑opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG‑afbeelding.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blokken:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Een Vorm Roteren met de Camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D‑Rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

In Aspose.Slides stelt u het cameratype en de rotatie in via het 3D‑formaat dat wordt geretourneerd door [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getThreeDFormat):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Gebruik de camera wanneer u wilt veranderen hoe de kijker het object ziet. Het verandert niet de 2D‑geometrie van de vorm op de dia. Het wijzigt het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en Diepte Toevoegen**

Extrusie laat een vorm dikker lijken door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑regelaar deze zichtbare dikte, en de kleurregelaar bepaalt de kleur van de zijvlakken.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Stel de extrusie‑hoogte in voor de dikte en de extrusie‑kleur voor de zijkleur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Gebruik de diepte‑instelling wanneer u rechtstreeks met de PowerPoint‑diepte‑waarde wilt werken of diepte wilt combineren met afschuining, materiaal en teksteffecten. In veel vormen is extrusie‑hoogte de duidelijkere instelling omdat deze direct de zichtbare extrusie uitdrukt.

## **Verloop‑ of Afbeeldingsvullingen Met 3D‑Effecten Gebruiken**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingvulling op de voorzijde toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een gradientvulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

De gerenderde output behoudt het verloop op de voorzijde en rendert de extrusie afzonderlijk:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Om een afbeeldingvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

De afbeelding wordt op de voorzijde gerenderd, terwijl de extrusie wordt weergegeven als het 3D‑zijvlak:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **3D‑Opmaak Toepassen op Tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstframe. Dit is nuttig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroonvulling, past een WordArt‑transformatie toe en configureert 3D‑instellingen op [TextFrameFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De tekst wordt gerenderd als gebogen, geëxtrudeerde 3D‑letters:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Export‑ en Rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑lay‑out‑formaten wordt de 3D‑scene gerasterd of getekend in de output als een 2D‑resultaat. Dit geldt wanneer u dia’s rendert naar PNG, exporteert naar PDF, exporteert naar HTML of frames genereert voor video‑conversie.

Houd de volgende punten in gedachten:

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtset, materiaal, extrusie, vulling en dia‑schaling.
- Als u geërfde of themagebaseerde opmaakwaarden wilt inspecteren, gebruikt u de effectieve opmaak‑API.
- Sommige uitvoerformaten kunnen bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt niet van geëxporteerde afbeeldingen, PDF’s of HTML‑pagina’s interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint waar het format het ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, afschuining, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal stelt u een camera‑rotatie en ofwel extrusie of diepte in. In de praktijk stelt u ook een lichtset en materiaal in zodat de gerenderde vlakken duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getThreeDFormat) voor het vormlichaam en [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#getThreeDFormat) voor tekst.

**Zien 3D‑effecten er uit bij export naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat er erfelijkheid en themainstellingen zijn toegepast?**

Ja. Gebruik [ThreeDFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getEffective) om de definitieve camera-, lichtset‑, afschuining‑ en gerelateerde 3D‑waarden te lezen.