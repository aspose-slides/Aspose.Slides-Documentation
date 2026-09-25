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

Aspose.Slides for Python via Java kan vormen en tekst maken, bewerken, bewaren en weergeven met PowerPoint-achtige 3D-opmaak. Dit artikel behandelt 3D-effecten zoals draaien, extrusie, schuine randen, verlichting, materiaal, verloop- of afbeeldingsvullingen en 3D-tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D-opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van afzonderlijke 3D‑modellen. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik de [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getThreeDFormat)‑methode om 3D‑opmaak toe te passen op een vorm. De methode retourneert [ThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#getThreeDFormat)‑methode. Deze past 3D‑opmaak toe op het tekstkader in plaats van op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Waar het/ze controleert | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getCamera) | Standpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in de 3D‑ruimte of stem het af op een PowerPoint‑3D‑rotatie‑preset. |
| [getLightRig](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getLightRig) | Licht‑preset, richting en lichtrotatie. | Pas aan hoe hooglichten en schaduwen verschijnen op het 3D‑oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setMaterial) | Oppervlakte‑materiaal, zoals plat, mat, kunststof of metaal. | Laat dezelfde geometrie er platter, zachter, glanzender of metallischer uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Hoe ver de vorm naar achteren uitsteekt vanaf de voorzijde. | Verander een platte vorm in een duidelijk dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getExtrusionColor) | Kleur van de geëxtrudeerde zijkanten. | Maak de diepte zichtbaar of stem de kleur van de zijkanten af op de vulling van de voorkant. |
| [getDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setDepth) | Aanvullende 3D‑diepte die door PowerPoint‑3D‑opmaak wordt gebruikt. | Stel de diepte nauwkeurig af voor vormen of tekst, vooral in combinatie met schuine randen en materiaalinstellingen. |
| [getBevelTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getBevelBottom) | Verhoogde of afgeronde randen op de voor‑ en achtervlakken. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte flank. |
| [getContourColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setContourWidth) | Omtrek rondom het 3D‑object. | Benadruk de objectrand in de gerenderde uitvoer. |

## **Maak een 3D‑vorm**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D oogt:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Licht‑instellingen, omdat verlichting de vlakken en zijkanten leesbaar maakt.
- Materiaal‑instellingen, omdat het oppervlak invloed heeft op hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De cameradraai‑waarden staan in graden en de extrusiehoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

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

In PowerPoint wordt 3D‑rotatie geconfigureerd via het 3‑D‑Rotatie‑venster. De X-, Y- en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint‑venster 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides krijgt u de camera via [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getCamera). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch frontaanzicht en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

Gebruik de camera wanneer u de weergave van het object voor de kijker wilt aanpassen. Het wijzigt niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑viewpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Voeg extrusie en diepte toe**

Extrusie laat een vorm dikker lijken door deze achter de voorzijde uit te strekken. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte en de kleur‑instelling bepaalt de kleur van de zijkanten.

![PowerPoint‑diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Gebruik [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setExtrusionHeight) om de dikte in te stellen en [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getExtrusionColor) om de kleur van de zijkanten op te halen. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en draait de camera om de dikte te tonen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

De [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setDepth)‑methode stelt de diepte van een 3D‑vorm in. De [setExtrusionHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setExtrusionHeight)‑methode bepaalt de hoogte van het extrusie‑effect, zoals getoond in dit voorbeeld.

## **Gebruik verloop‑ of afbeeldingsvullingen met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeelding op de voorzijde toepassen en toch dezelfde camera-, licht-, materiaal- en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauwe‑naar‑oranje verloop toe op de voorzijde en een donkeroranje kleur op de 150‑punt extrusie. De verloopstops op 0 en 100 geven het begin en einde van het verloop aan. De cameradraai‑waarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

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

De gerenderde output behoudt het verloop op de voorzijde en rendert de extrusie apart:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om een afbeeldingsvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand met de naam "image.jpg" in de werkmap. Het rekent de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de cameradraai in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

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

De afbeelding wordt gerenderd op de voorzijde, terwijl de extrusie wordt gerenderd als het 3D‑zijkantoppervlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm heeft invloed op het vormlichaam. 3D‑opmaak van tekst heeft invloed op het tekstkader. Dit is nuttig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑witte rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#getThreeDFormat). De extrusiehoogte en diepte staan in punten en de lichtrotatie in graden. De vormvulling en omlijning zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

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

De tekst wordt gerenderd als gebogen, geëxtrudeerde 3D‑lettering:

![Gerenderde 3D‑tekst met een boogvormige WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Houd tekst plat op een 3D‑vorm**

Om de tekst leesbaar te houden terwijl de 3D‑uitstraling van een vorm behouden blijft, roept u [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setKeepTextFlat) aan via [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getTextFrameFormat). Wanneer de waarde `True` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `False` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getThreeDFormat). Het verschilt ook van gewone rotatie. [Shape.setRotation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setRotation) roteert de vorm in het dia‑vlak, terwijl [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setRotationAngle) de aangepaste rotatie van de tekst binnen de omhullende doos regelt. Het buiten de 3D‑scene houden van de tekst zet geen van die hoeken terug.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstinstelling verschilt: `False` links en `True` rechts. De camerahoeken staan in graden en de extrusiehoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de comparatiedia naar PNG op het dubbele van de standaardafmetingen.

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

Links volgt de tekst de 3D‑oriëntatie. Rechts blijft hij plat en makkelijker leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Zij‑aan‑zij 3D‑rechthoeken: tekst volgt de 3D‑oriëntatie links en blijft plat rechts](keep_text_flat.png)

## **Export‑ en render‑gedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑lay‑out‑formaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit gebeurt wanneer u dia’s rendert naar [PNG](/slides/nl/python-java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/python-java/convert-powerpoint-to-html/), of frames genereert voor [video‑conversie](/slides/nl/python-java/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Exportte afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden gedraaid.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtset, materiaal, extrusie, vulling en dia‑schaling.
- Als u geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/python-java/shape-effective-properties/).
- Sommige uitvoerformaten kunnen bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF‑s of HTML‑pagina's tot interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint op plaatsen waar het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, schuine rand, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet u een cameradraai instellen en ofwel extrusie of diepte. In de praktijk stelt u bovendien een lichtset en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getThreeDFormat) voor het vormlichaam en [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#getThreeDFormat) voor tekst.

**Zullen 3D‑effecten verschijnen bij exporteren naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het maken van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat erfelijkheid en themainstellingen zijn toegepast?**

Ja. Gebruik de API's voor effectieve opmaak beschreven in [Effectieve vormeigenschappen](/slides/nl/python-java/shape-effective-properties/) om de uiteindelijke camera-, lichtset‑, schuine‑rand‑ en gerelateerde 3D‑waarden uit te lezen.