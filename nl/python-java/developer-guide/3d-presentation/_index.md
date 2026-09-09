---
title: Creëer 3D-effecten in presentaties met Python
linktitle: 3D presentatie
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
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in Python via Java met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for Python via Java kan vormen en tekst maken, bewerken, behouden en weergeven met PowerPoint‑achtige 3D‑opmaak. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, verloop‑ of afbeeldingvullingen en 3D‑tekst.

{{% alert color="info" title="Opmerking" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en tekst. Het gaat niet over het invoegen of bewerken van losse 3D‑modelbestanden. Wanneer je een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides`, start de JVM indien nodig, en importeert vervolgens de API. Het voorbeeld met een afbeeldingvulling vereist een `image.jpg`‑bestand in de werkmap.

## **Concepten voor 3D‑opmaak**

Gebruik [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getThreeDFormat) om 3D‑opmaak op een vorm toe te passen. Het geretourneerde format‑object beheert de 3D‑scene voor die vorm.

Voor tekst gebruik je [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#getThreeDFormat). Hiermee wordt 3D‑opmaak op het tekstframe toegepast in plaats van op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getCamera) | Gezichtsstandpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in 3D‑ruimte of stem overeen met een vooraf ingestelde 3D‑rotatie in PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getLightRig) | Lichtvoorinstelling, richting en rotatie van het licht. | Wijzig hoe hooglichten en schaduwen verschijnen op het 3D‑oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getMaterial) en [setMaterial](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setMaterial) | Oppervlaktermateriaal, zoals vlak, mat, plastic of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metaalachtig uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getExtrusionHeight) en [setExtrusionHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Hoe ver de vorm naar achteren uitstrekt vanaf het voorste vlak. | Verander een platte vorm in een duidelijk dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getExtrusionColor) | Kleur van de uitgeschoven zijkanten. | Maak diepte zichtbaar of stem de kleur van de zijkant af op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getDepth) en [setDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setDepth) | Extra 3D‑diepte die door PowerPoint‑3D‑opmaak wordt gebruikt. | Fijn afstemmen van de diepte voor vormen of tekst, vooral in combinatie met schuine randen en materiaal. |
| [getBevelTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getBevelTop) en [getBevelBottom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getBevelBottom) | Verhoogde of afgeronde randen op de voor- en achtervlakken. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte kant. |
| [getContourColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getContourWidth) en [setContourWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#setContourWidth) | Omtrek rond het 3D‑object. | Benadruk de rand van het object in de gerenderde output. |

## **Maak een 3D‑vorm**

Een vorm vereist meestal vier soorten instellingen voordat deze overtuigend 3D lijkt:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Licht‑instellingen, omdat verlichting de vlakken en zijkanten leesbaar maakt.
- Materiaal‑instellingen, omdat het oppervlak bepaalt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan het voorste vlak, past 3D‑opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG‑afbeelding.

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

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op het voorste vlak](img_01_01.png)

## **Draai een vorm met de camera**

In PowerPoint wordt 3D‑rotatie ingesteld via het 3‑D‑Rotatie‑venster. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die je via de camera‑API instelt.

![PowerPoint 3‑D‑Rotatie‑venster met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides stel je het cameratype en de rotatie in via het 3D‑format dat wordt geretourneerd door [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getThreeDFormat):

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

Gebruik de camera wanneer je wilt wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑viewpoint dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Voeg extrusie en diepte toe**

Extrusie maakt een vorm dikker door deze achter het voorste vlak uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en bepaalt de kleur‑instelling de kleur van de zijkanten.

![PowerPoint diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel de extrusiehoogte in voor de dikte en de extrusiekleur voor de kleur van de zijkanten:

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

Gebruik de diepte‑instelling wanneer je direct met de diepte‑waarde van PowerPoint wilt werken of diepte wilt combineren met schuine randen, materiaal en teksteffecten. In veel vormscenario's is extrusiehoogte de duidelijkere instelling omdat die direct de zichtbare extrusie uitdrukt.

## **Gebruik verloop‑ of afbeeldingvullingen met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. Je kunt een effen kleur, verloop, patroon of afbeeldingvulling op het voorste vlak toepassen en toch dezelfde camera-, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een verloopvulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

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

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voeg je de afbeelding toe aan de presentatie en wijs je deze toe aan de vormvulling:

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

![Gerenderde 3D‑rechthoek met een foto­vulling op het voorste vlak en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstframe. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

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

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Export‑ en render‑gedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan in PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer je dia’s rendert naar PNG, exporteert naar PDF, exporteert naar HTML, of frames genereert voor video‑conversie.

Houd de volgende punten in gedachten:

- Geëxporteerde afbeeldingen en PDF's zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtopstelling, materiaal, extrusie, vulling en dia‑schaling.
- Als je geërfde of themagebaseerde opmaakwaarden wilt inspecteren, gebruik dan de API voor effectieve opmaak.
- Sommige uitvoerformaten kunnen geen bewerkbare PowerPoint‑3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF's of HTML‑pagina's interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een apart 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die op een gewone PowerPoint‑vorm of tekst wordt toegepast, zoals rotatie, extrusie, schuine rand, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet je een camera‑rotatie en ofwel extrusie of diepte instellen. In de praktijk stel je ook een lichtopstelling en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getThreeDFormat) voor het vormlichaam en [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#getThreeDFormat) voor tekst.

**Zullen 3D‑effecten verschijnen bij het exporteren naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat overerving en themainstellingen zijn toegepast?**

Ja. Gebruik [ThreeDFormat.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getEffective) om de uiteindelijke camera-, lichtopstelling-, schuine‑rand‑ en gerelateerde 3D‑waarden te lezen.