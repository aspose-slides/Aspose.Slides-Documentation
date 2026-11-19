---
title: Skapa 3D-effekter i presentationer med Python
linktitle: 3D-presentation
type: docs
weight: 232
url: /sv/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentation
- 3D-rotation
- 3D-djup
- 3D-extrusion
- 3D-gradient
- 3D-text
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Tillämpa och rendera 3D-effekter för PowerPoint-former och -text i Python via Java med Aspose.Slides. Konfigurera kamera, belysning, material, extrusion, fyllningar och 3D-text."
---
## **Översikt**

Aspose.Slides för Python via Java kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Den här artikeln täcker 3D‑effekter såsom rotation, extrusion, fasader, belysning, material, gradient‑ eller bildfyllningar och 3D‑text.

{{% alert color="info" title="Note" %}}
Den här artikeln handlar om 3D‑formateringseffekter på PowerPoint‑former och -text. Den behandlar inte infogning eller redigering av fristående 3D‑modelfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd metoden [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) för att tillämpa 3D‑formatering på en form. Metoden returnerar [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), som styr 3D‑scenen för den formen.

För text, använd metoden [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Detta tillämpar 3D‑formatering på textramen istället för formkroppen.

De viktigaste API‑medlemmarna är:

| API‑medlem | Vad den styr | När den ska användas |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Vypunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑utrymme eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Belysningsförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) och [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Ytmaterial, såsom platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) och [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Hur långt formen sträcker sig bakåt från sin främre yta. | Förvandla en platt form till ett synligt tjockt 3D‑objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidfärgen med frontfyllningen. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) och [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djupet för former eller text, särskilt tillsammans med fasad‑ och materialinställningar. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) och [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Upphöjda eller avrundade kanter på fram- och baksidorna. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) och [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) och [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Kontur runt 3D‑objektet. | Betona objektets gräns i den renderade utdata. |

## **Skapa en 3D‑form**

En form brukar behöva fyra typer av inställningar innan den ser övertygande 3D‑ut:

- Kamera‑inställningar, eftersom standardframsidan kan dölja extrusionen.
- Ljus‑inställningar, eftersom belysning gör ytor och sidor läsbara.
- Material‑inställningar, eftersom ytan påverkar hur ljuset renderas.
- Extrusion‑ eller djup‑inställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess främre yta och tillämpar 3D‑formatering. Kamerarotationsvärdena är i grader och extrusionens höjd är 100 punkter. Exemplet renderar bilden till en PNG‑fil med dubbla standardmått och sparar presentationen som PPTX.

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

Den renderade bildfilen visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på den främre ytan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från panelen 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du ställer in via kamerans API.

![PowerPoint‑panelen 3‑D‑Rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides får du åtkomst till kameran via [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). Detta exempel skapar en rektangel, väljer en ortografisk framvy och sätter dess X‑, Y‑ och Z‑rotationer till 20, 30 respektive 40 grader. Det konfigurerar formen i minnet utan att spara en fil:

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

Använd kameran när du behöver ändra hur betraktaren ser objektet. Den ändrar inte den 2D‑geometri som formen har på bilden. Den ändrar 3D‑vy‑punkten som används av PowerPoint och av Aspose.Slides vid rendering.

### **Kopiera kamerariktning från en mallform**

För att matcha riktningen på en mallform, läs dess kamera‑förinställning med [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) och dess rotationsvinklar med [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). Exemplet öppnar `template.pptx` och kopierar kamerariktningen från den första formen på den första bilden till den andra formen. Båda formerna har redan 3D‑belysning, och den andra formen har ingen explicit kamerarotation.

Vinklarna är i grader. Index `0` är latitud, index `1` är longitud och index `2` är rotation. Skicka dem till [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) i den ordningen. Om källan returnerar `None` har den ingen explicit rotation, så lämna den andra formens vinklar oinställda. En explicit rotation på `(0, 0, 0)` returnerar tre nollor och bör kopieras.

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

När du öppnar `camera-copy.pptx` i PowerPoint har pilen till höger samma kamera‑förinställning och rotation som rektangeln till vänster. Båda formerna använder samma belysning och extrusion‑djup.

![En blå 3D‑rektangel och en högerpil med matchande kameraorientering, sedd ovanifrån och från höger](camera-orientation.png)

## **Lägg till extrusion och djup**

Extrusion får en form att se tjock ut genom att förlänga den bakom den främre ytan. I PowerPoint styr djup‑kontrollen detta synliga tjocklek, och färg‑kontrollen anger färgen på sidoytorna.

![PowerPoint‑djupkontroller kopplade till extrusionens färg‑ och höjdogenskaper](img_02_02.png)

Använd [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) för att ange tjockleken och [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) för att komma åt sidfärgen. Detta exempel ger en rektangel en extrusion på 100 punkter med lila sidor och roterar kameran för att visa dess tjocklek. Det konfigurerar formen i minnet utan att spara en fil:

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

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth)-metoden sätter djupet för en 3D‑form. [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight)-metoden styr extrusionens höjd, som visas i detta exempel.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en solid färg, gradient, mönster eller bildfyllning på den främre ytan och ändå använda samma kamera‑, ljus‑, material‑ och extrusion‑inställningar.

Detta exempel applicerar en blå‑till‑orange gradient på den främre ytan och en mörk orange färg på 150‑punkters extrusionen. Gradientstopp vid 0 och 100 markerar början och slutet på gradienten. Kamerarotationsvärdena är i grader. Bilden renderas till en PNG‑fil med dubbla standardmått:

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

Den renderade utdata behåller gradienten på den främre ytan och renderar extrusionen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrusion](img_02_03.png)

För att istället använda en bildfyllning, lägg till bilden i presentationen och tilldela den till formens fyllning. Detta exempel kräver en befintlig fil med namnet "image.jpg" i arbetskatalogen. Den sträcker bilden för att fylla rektangeln, applicerar en extrusion på 150 punkter och sätter kamerarotationen i grader. Det konfigurerar formen i minnet utan att spara eller rendera en fil:

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

Bilden renderas på den främre ytan, medan extrusionen renderas som 3D‑sidoytan:

![Renderad 3D‑rektangel med ett foto på den främre ytan och orange extrusion](img_02_04.png)

## **Applicera 3D‑formatering på text**

Formens 3D‑formatering påverkar formens kropp. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrusion, material, belysning och kamerainställningar.

Följande exempel skapar text med ett orange‑och‑vitt rutmönster, applicerar en uppåtriktad båge och konfigurerar 3D‑inställningarna via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Extrusionens höjd och djup är i punkter och ljusrotationen i grader. Formens fyllning och kontur är dolda så att endast texten är synlig. Exemplet renderar en PNG‑fil med dubbla standardmått och sparar presentationen som PPTX:

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

Texten renderas som böjd, extruderad 3D‑bokstavstext:

![Renderad 3D‑text med en böjd WordArt‑transformering, orange mönsterfyllning och mörk extrusion](img_02_05.png)

## **Behåll text platt på en 3D‑form**

För att hålla text läsbar samtidigt som du bevarar formens 3D‑utseende, anropa [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) via [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). När värdet är `True` förblir texten utanför 3D‑scenen. När det är `False` deltar texten i scenen och följer dess 3D‑orientering.

Den här inställningen tar inte bort formens 3D‑formatering: dess kamera, belysning, material och extrusion förblir konfigurerade via [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). Den skiljer sig också från vanlig rotation. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) roterar formen i bildens plan, medan [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) styr textens anpassade rotation inom dess omgivningsruta. Att hålla text utanför 3D‑scenen återställer inte någon av dessa vinklar.

Följande fristående exempel skapar en blå rektangel med text och klonar den bredvid originalet. Båda formerna har samma 3D‑formatering; endast textinställningen skiljer sig: `False` till vänster och `True` till höger. Kameravinklarna är i grader och extrusionens höjd är 40 punkter. Exemplet sparar presentationen som PPTX och renderar jämförelsesidan till PNG med dubbla standardmått.

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

Till vänster följer texten 3D‑orienteringen. Till höger förblir den platt och lättare att läsa. Båda rektanglarna behåller samma synliga extrusion och 3D‑orientering.

![Sida‑vid‑sida 3D‑rektanglar: text följer 3D‑orienteringen till vänster och förblir platt till höger](keep_text_flat.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när du sparar till PowerPoint‑format som PPTX. Vid rendering eller export till fasta layout‑format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/python-java/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/python-java/convert-powerpoint-to-html/), eller genererar ramar för [videokonvertering](/slides/sv/python-java/convert-powerpoint-to-video/).

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutliga utseendet beror på kombinationen av kamera, ljusanordning, material, extrusion, fyllning och bildskalning.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs [effektiva formegenskaper](/slides/sv/python-java/shape-effective-properties/).
- Vissa outputformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet snarare än att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Den gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stödjer det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrusion, fasad, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Minst, ställ in en kamerarotation och antingen extrusion eller djup. I praktiken bör du också ange en ljusanordning och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag applicera 3D‑effekter på både former och text?**

Ja. Använd [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) för formkroppen och [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videoramar?**

Ja. Aspose.Slides renderar 3D‑effekter när du skapar bildbilder, PDF‑utdata, HTML‑utdata och ramar som används för videokonvertering. Den exporterade utdata innehåller det renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API‑erna som beskrivs i [Effektiva formegenskaper](/slides/sv/python-java/shape-effective-properties/) för att läsa de slutgiltiga kamerans, ljusanordningens, fasadens och relaterade 3D‑värden.