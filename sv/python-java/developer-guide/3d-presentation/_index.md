---
title: Skapa 3D‑effekter i presentationer med Python
linktitle: 3D‑presentation
type: docs
weight: 232
url: /sv/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑presentation
- 3D‑rotation
- 3D‑djup
- 3D‑extrudering
- 3D‑gradient
- 3D‑text
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Applicera och rendera 3D‑effekter för PowerPoint‑former och text i Python via Java med Aspose.Slides. Konfigurera kamera, belysning, material, extrudering, fyllningar och 3D‑text."
---
## **Översikt**

Aspose.Slides för Python via Java kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel täcker 3D‑effekter såsom rotation, extrudering, avfasningar, belysning, material, gradient‑ eller bildfyllning och 3D‑text.

{{% alert color="info" title="Note" %}}
Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och -text. Den handlar inte om att infoga eller redigera fristående 3D‑modellfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utmatningen.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd metoden [Shape.getThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getThreeDFormat) för att tillämpa 3D‑formatering på en form. Metoden returnerar [ThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/), som styr 3D‑scenen för den formen.

För text, använd metoden [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#getThreeDFormat). Detta tillämpar 3D‑formatering på textramen istället för formens kropp.

De viktigaste API‑medlemmarna är:

| API‑medlem | Vad den kontrollerar | När den ska användas |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getCamera) | Visningspunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rum eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [getLightRig](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getLightRig) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [getMaterial](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getMaterial) och [setMaterial](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#setMaterial) | Ytmaterial, såsom platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glänsande eller metallisk ut. |
| [getExtrusionHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getExtrusionHeight) och [setExtrusionHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Hur långt formen sträcker sig bakåt från dess främre yta. | Gör en platt form till ett synligt tjockt 3D‑objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getExtrusionColor) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidans färg med frontfyllningen. |
| [getDepth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getDepth) och [setDepth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#setDepth) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djupet för former eller text, särskilt i kombination med avfasning och materialinställningar. |
| [getBevelTop](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getBevelTop) och [getBevelBottom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getBevelBottom) | Upphöjda eller avrundade kanter på främre och bakre ytor. | Lägg till en mjukare eller formad kant istället för en skarp plan yta. |
| [getContourColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getContourColor) och [getContourWidth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getContourWidth) och [setContourWidth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#setContourWidth) | Kontur runt 3D‑objektet. | Markera objektets gräns i den renderade utmatningen. |

## **Skapa en 3D‑form**

En form behöver vanligtvis fyra typer av inställningar innan den ser övertygande 3D‑ut.

- Kamerainställningar, eftersom standardframsidan kan dölja extruderingen.
- Ljusinställningar, eftersom belysning gör ansiktena och sidorna läsbara.
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.
- Extruderings- eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess främre yta och tillämpar 3D‑formatering. Kamerarotationsvärdena är i grader, och extruderingshöjden är 100 punkter. Exemplet renderar bilden till en PNG‑fil med dubbla sina standardmått och sparar presentationen som PPTX.

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

Den renderade bilden visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på den främre ytan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från panelen 3‑D‑rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du anger via kamera‑API‑et.

![PowerPoint‑panelen 3‑D‑rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides får du åtkomst till kameran via [ThreeDFormat.getCamera](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getCamera). Detta exempel skapar en rektangel, väljer en ortografisk frontvy och sätter dess X‑, Y‑ och Z‑rotationer till 20, 30 respektive 40 grader. Det konfigurerar formen i minnet utan att spara en fil:

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

Använd kameran när du behöver ändra hur betraktaren ser objektet. Den ändrar inte den 2D‑geometri som formen har på bilden. Den ändrar 3D‑vypunkt som används av PowerPoint och av Aspose.Slides vid rendering.

## **Lägg till extrudering och djup**

Extrudering får en form att se tjock ut genom att den sträcks bakom den främre ytan. I PowerPoint sätter djupkontrollen denna synliga tjocklek och färgkontrollen sätter färgen på sidoytorna.

![PowerPoint‑djupkontroller kopplade till extruderingsfärg‑ och extruderingshöjdsegenskaper](img_02_02.png)

Använd [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#setExtrusionHeight) för att ange tjockleken och [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getExtrusionColor) för att komma åt sidofärgen. Detta exempel ger en rektangel en extrudering på 100 punkter med lila sidor och roterar kameran för att visa dess tjocklek. Det konfigurerar formen i minnet utan att spara en fil:

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

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#setDepth)‑metoden sätter djupet för en 3D‑form. [setExtrusionHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#setExtrusionHeight)‑metoden styr höjden på extruderings‑effekten, som visas i detta exempel.

## **Använd gradient‑ eller bildfyllning med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan tillämpa en solid färg, gradient, mönster eller bildfyllning på den främre ytan och ändå använda samma kamera-, ljus-, material- och extruderingsinställningar.

Detta exempel tillämpar en blå‑till‑orange gradient på den främre ytan och en mörkorange färg på den 150‑punkts extruderingen. Gradientstopp vid 0 och 100 markerar början och slutet på gradienten. Kamerarotationsvärdena är i grader. Bilden renderas till en PNG‑fil med dubbla sina standardmått:

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

Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrudering:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrudering](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den som formens fyllning. Detta exempel kräver en befintlig fil med namnet "image.jpg" i arbetskatalogen. Den sträcker bilden för att fylla rektangeln, tillämpar en extrudering på 150 punkter och sätter kamerarotationen i grader. Den konfigurerar formen i minnet utan att spara eller rendera en fil:

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

Renderad 3D‑rektangel med ett foto på den främre ytan och orange extrudering:

![Renderad 3D‑rektangel med ett foto på den främre ytan och orange extrudering](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

3D‑formatering av en form påverkar formens kropp. 3D‑formatering av text påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrudering, material, belysning och kamerainställningar.

Följande exempel skapar text med ett orange‑och‑vitt rutmönster, applicerar en uppåtriktad båge och konfigurerar 3D‑inställningarna via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#getThreeDFormat). Extruderingshöjden och djupet är i punkter och ljusrotationen i grader. Formens fyllning och kontur är dolda så att endast texten är synlig. Exemplet renderar en PNG‑fil med dubbla standardmått för bilden och sparar presentationen som PPTX:

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

Renderad 3D‑text med en böjd WordArt‑transformering, orange mönsterfyllning och mörk extrudering:

![Renderad 3D‑text med en böjd WordArt‑transformering, orange mönsterfyllning och mörk extrudering](img_02_05.png)

## **Behåll text platt på en 3D‑form**

För att hålla text läsbar samtidigt som en forms 3D‑utseende bevaras, anropa [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setKeepTextFlat) via [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#getTextFrameFormat). När värdet är `True` hålls texten utanför 3D‑scenen. När det är `False` deltar texten i scenen och följer dess 3D‑orientering.

Denna inställning tar inte bort formens 3D‑formatering: dess kamera, belysning, material och extrudering förblir konfigurerade via [Shape.getThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getThreeDFormat). Det skiljer sig också från vanlig rotation. [Shape.setRotation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setRotation) roterar formen i bildplanet, medan [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setRotationAngle) styr textens anpassade rotation inom dess begränsningsruta. Att hålla texten utanför 3D‑scenen återställer inte någon av dessa vinklar.

Det följande självständiga exemplet skapar en blå rektangel med text och klonar den bredvid originalet. Båda formerna har samma 3D‑formatering; endast textinställningen skiljer sig: `False` till vänster och `True` till höger. Kameravinklarna är i grader och extruderingshöjden är 40 punkter. Exemplet sparar presentationen som PPTX och renderar jämförelsesliden till PNG med dubbla standardmått.

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

Sida‑vid‑sida 3D‑rektanglar: text följer 3D‑orienteringen till vänster och förblir platt till höger:

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering vid sparning till PowerPoint‑format såsom PPTX. Vid rendering eller export till format med fast layout rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/python-java/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/python-java/convert-powerpoint-to-html/), eller genererar bildrutor för [video conversion](/slides/sv/python-java/convert-powerpoint-to-video/).

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrudering, fyllning och bildskalning.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs [effektiva formegenskaper](/slides/sv/python-java/shape-effective-properties/).
- Vissa exportformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stöder det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrudering, avfasning, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum måste du ange en kamerarotation samt antingen extrudering eller djup. I praktiken bör du också ange en ljusrigg och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag tillämpa 3D‑effekter på både former och text?**

Ja. Använd [Shape.getThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getThreeDFormat) för formkroppen och [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#getThreeDFormat) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videobildrutor?**

Ja. Aspose.Slides renderar 3D‑effekter när du skapar bildbilder, PDF‑utdata, HTML‑utdata och bildrutor för videokonvertering. Den exporterade utdata innehåller den renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API‑erna som beskrivs i [Shape Effective Properties](/slides/sv/python-java/shape-effective-properties/) för att läsa slutgiltiga kamera-, ljusrigg‑, avfasnings‑ och relaterade 3D‑värden.