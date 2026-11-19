---
title: 3D-effecten maken in presentaties met Python
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentatie
- 3D-rotatie
- 3D-diepte
- 3D-extrusie
- 3D-verloop
- 3D-tekst
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in Python via Java met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides voor Python via Java kan 3D‑opmaak in PowerPoint‑stijl voor vormen en tekst maken, bewerken, behouden en renderen. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, afgeschuinde randen, verlichting, materiaal, verloop‑ of afbeeldingsvullingen en 3D‑tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van op zichzelf staande 3D‑modelbestanden. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik de [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) methode om 3D‑opmaak toe te passen op een vorm. De methode retourneert [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) methode. Hiermee wordt 3D‑opmaak toegepast op het tekstkader in plaats van op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Gezichtsveld, voorinstelling cameratype, rotatie, zoom en perspectief. | Draai het object in 3D‑ruimte of stem overeen met een PowerPoint‑3D‑rotatie‑preset. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Licht‑preset, richting en rotatie van het licht. | Verander hoe hooglichten en schaduwen verschijnen op het 3D‑oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Oppervlaktmateriaal, zoals vlak, mat, kunststof of metaal. | Laat dezelfde geometrie er platter, zachter, glanzender of metalen uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Hoe ver de vorm naar achteren uitstrekt vanaf de voorzijde. | Verander een vlakke vorm in een duidelijk dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Kleur van de geëxtrudeerde zijvlakken. | Maak diepte zichtbaar of stem de kleur van de zijkanten af op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Aanvullende 3D‑diepte die gebruikt wordt door PowerPoint‑3D‑opmaak. | Fijnstel de diepte voor vormen of tekst, vooral in combinatie met afgeschuinde randen en materiaalinstellingen. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe vlakke kant. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Contour rond het 3D‑object. | Benadruk de objectgrens in de gerenderde output. |

## **Maak een 3D‑vorm**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D uitziet:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Licht‑instellingen, omdat verlichting de gezichten en zijvlakken leesbaar maakt.
- Materiaal‑instellingen, omdat het oppervlak beïnvloedt hoe licht wordt gerenderd.
- Extrusie‑ of diepte‑instellingen, omdat een vlakke vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De camerarotatiewaarden staan in graden en de extrusiehoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

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

De gerenderde dia‑afbeelding toont de rechthoek als een dik 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Draai een vorm met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het venster 3‑D‑rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint‑venster 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides krijgt u via [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) toegang tot de camera. Dit voorbeeld maakt een rechthoek, selecteert een orthografisch vooraanzicht en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

Gebruik de camera wanneer u de manier wilt wijzigen waarop de kijker het object ziet. Het verandert de 2D‑vormgeometrie op de dia niet. Het wijzigt het 3D‑viewpoint dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

### **Kopieer de camera‑oriëntatie van een sjabloonvorm**

Om de oriëntatie van een sjabloonvorm te evenaren, leest u de camera‑preset met [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) en de rotatiehoeken met [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). Het voorbeeld opent `template.pptx` en kopieert de camera‑oriëntatie van de eerste vorm op de eerste dia naar de tweede vorm. Beide vormen hebben al 3D‑verlichting, en de tweede vorm heeft geen expliciete camera‑rotatie.

De hoeken staan in graden. Index `0` is breedtegraad, index `1` is lengtegraad, en index `2` is omwenteling. Geef ze in die volgorde door aan [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation). Als de bron `None` retourneert, heeft deze geen expliciete rotatie, dus laat de hoeken van de tweede vorm oningesteld. Een expliciete rotatie van `(0, 0, 0)` levert drie nullen op en moet gekopieerd worden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wanneer u `camera-copy.pptx` opnieuw opent in PowerPoint, heeft de pijl aan de rechterkant dezelfde camera‑preset en rotatie als de rechthoek aan de linkerkant. Beide vormen gebruiken dezelfde verlichting en extrusiediepte.

![Een blauwe 3D‑rechthoek en een rechtse pijl met overeenkomende camera‑oriëntatie, bekeken van boven en van rechts](camera-orientation.png)

## **Voeg extrusie en diepte toe**

Extrusie maakt een vorm dikker door deze achter de voorzijde uit te breiden. In PowerPoint stelt de diepte‑instelling deze zichtbare dikte in, en de kleur‑instelling bepaalt de kleur van de zijvlakken.

![PowerPoint-diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Gebruik [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) om de dikte in te stellen en [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) om de kantkleur op te vragen. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en draait de camera om de dikte te onthullen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

De methode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) stelt de diepte van een 3D‑vorm in. De methode [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) regelt de hoogte van het extrusie‑effect, zoals in dit voorbeeld wordt getoond.

## **Gebruik verloop‑ of afbeeldingsvullingen met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingsvulling toepassen op de voorzijde en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorzijde en een donkeroranje kleur op de 150‑punt extrusie. De verloopstops op 0 en 100 geven het begin en einde van het verloop aan. De camerarotatiewaarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

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

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingsvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand met de naam "image.jpg" in de werkmap. Het strekt de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camerarotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstkader. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑witte rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). De extrusiehoogte en diepte staan in punten en de lichtrotatie in graden. De vormvulling en -contour zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

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

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Houd tekst plat op een 3D‑vorm**

Om tekst leesbaar te houden terwijl de 3D‑uitstraling van een vorm behouden blijft, roept u [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) aan via [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). Wanneer de waarde `True` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `False` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). Het verschilt ook van gewone rotatie. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) roteert de vorm in het dia‑vlak, terwijl [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) de aangepaste rotatie van de tekst binnen zijn omhullende regelt. Tekst buiten de 3D‑scene houden reset geen van beide hoeken.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstinstelling verschilt: `False` links en `True` rechts. De camera‑hoeken staan in graden en de extrusiehoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op het dubbele van de standaardafmetingen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

![Zij‑aan‑zij 3D‑rechthoeken: tekst volgt de 3D‑oriëntatie links en blijft plat rechts](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑opmaakformaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer u dia's rendert naar [PNG](/slides/nl/python-java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/python-java/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/python-java/convert-powerpoint-to-video/).

- Geëxporteerde afbeeldingen en PDF‑bestanden zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtinstallatie, materiaal, extrusie, vulling en schaal van de dia.
- Als u geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effective shape properties](/slides/nl/python-java/shape-effective-properties/).
- Sommige outputformaten kunnen geen bewerkbare PowerPoint‑3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt van geëxporteerde afbeeldingen, PDF‑bestanden of HTML‑pagina's geen interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die op een gewone PowerPoint‑vorm of -tekst wordt toegepast, zoals rotatie, extrusie, afgeschuinde randen, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

U moet minimaal een camera‑rotatie en ofwel extrusie of diepte instellen. In de praktijk stelt u ook een lichtinstallatie en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) voor het vormlichaam en [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) voor tekst.

**Zullen 3D‑effecten verschijnen bij het exporteren naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die gebruikt worden voor videoconversie. De geëxporteerde output bevat het gerenderde uiterlijk, geen bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat er erfelijkheid en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API's die beschreven worden in [Shape Effective Properties](/slides/nl/python-java/shape-effective-properties/) om de uiteindelijke camera-, lichtinstallatie-, afgeschuinde‑rand‑ en gerelateerde 3D‑waarden te lezen.