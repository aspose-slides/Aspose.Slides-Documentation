---
title: Skapa och tillämpa WordArt-effekter i Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /sv/python-java/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt-mall
- WordArt-effekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- WordArt-transformation
- 3D-effekt
- yttre skuggeffekt
- inre skuggeffekt
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa och anpassa WordArt-effekter i Aspose.Slides för Python via Java. Denna steg-för-steg-guide hjälper utvecklare att förbättra presentationer med professionell text i Python via Java."
---
## **Översikt**

WordArt‑effekter låter dig lägga till visuellt tilltalande, stiliserad text i dina PowerPoint‑presentationer. Med Aspose.Slides kan utvecklare programatiskt skapa, anpassa och hantera WordArt precis som i Microsoft PowerPoint—utan att behöva ha Office installerat. Den här artikeln ger en översikt över hur du arbetar med WordArt, inklusive hur du tillämpar texttransformeringar, fyllningsstilar, konturer, skuggor och andra formateringsalternativ för att göra ditt presentationsinnehåll mer uttrycksfullt och engagerande. WordArt låter dig behandla text som ett grafiskt objekt. Det består av effekter eller speciella modifieringar som appliceras på text för att göra den mer attraktiv eller märkbar.

## **Skapa en enkel WordArt‑mall och tillämpa den på text**

**Använda Aspose.Slides**

Först skapar vi enkel text med denna Python‑kod:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Därefter ökar vi teckenstorleken för att göra effekten mer märkbar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Använda Microsoft PowerPoint**

Gå till WordArt‑effektmenyn i Microsoft PowerPoint:

![WordArt‑effektmeny i PowerPoint](image-20200930113926-1.png)

I menyn till höger kan du välja en fördefinierad WordArt‑effekt. I menyn till vänster kan du ange inställningarna för ny WordArt.

Detta är några av de tillgängliga parametrarna eller alternativen:

![WordArt‑formateringsalternativ](image-20200930114015-3.png)

**Använda Aspose.Slides**

Här applicerar vi [PatternStyle.SmallGrid](https://reference.aspose.com/slides/sv/python-java/aspose.slides/patternstyle/#SmallGrid) mönsterfyllning på texten och lägger till en svart textkant med denna kod:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Den resulterande texten:

![Text med mönsterfyllning och svart kontur](image-20200930114108-4.png)

## **Tillämpa andra WordArt‑effekter**

**Använda Microsoft PowerPoint**

Från programmets gränssnitt kan du applicera dessa effekter på text, ett textblock, en form eller ett liknande element:

![Text‑ och formeffekter i PowerPoint](image-20200930114129-5.png)

Till exempel kan skugga‑, reflekterings‑ och glödeffekter appliceras på text; 3D‑format‑ och 3D‑rotations‑effekter kan appliceras på ett textblock; mjuka kanter‑effekten kan appliceras på en form (den har fortfarande en effekt när ingen 3D‑formateffekt är inställd).

### **Applicera skuggeffekter**

Följande Python‑kod applicerar en skuggeffekt enbart på text:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Aspose.Slides‑API stöder tre typer av skuggor: [OuterShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/innershadow/) och [PresetShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presetshadow/).

Med [PresetShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presetshadow/) kan du applicera en skugga på text med förinställda värden.

**Använda Microsoft PowerPoint**

I PowerPoint kan du använda en typ av skugga. Här är ett exempel:

![Skugginställningar i PowerPoint](image-20200930114225-6.png)

**Använda Aspose.Slides**

Aspose.Slides låter faktiskt dig applicera två typer av skuggor samtidigt: [InnerShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/innershadow/) och [PresetShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presetshadow/).

Obs:
- När [OuterShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/outershadow/) och [PresetShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presetshadow/) används tillsammans, appliceras endast [OuterShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/outershadow/)‑effekten.
- Om [OuterShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/outershadow/) och [InnerShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/innershadow/) används samtidigt beror den resulterande eller tillämpade effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 fördubblas effekten. Men i PowerPoint 2007 appliceras [OuterShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/outershadow/)‑effekten.

### **Applicera reflektion på text**

Vi lägger till en reflektion på texten via detta kodexempel i Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Applicera glödeffekt på text**

Vi applicerar glödeffekten på texten för att få den att glänsa eller sticka ut med hjälp av den här koden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

Resultatet av operationen:

![Text med glödeffekt](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
Du kan ändra parametrarna för skugga, reflektion och glöd. Effektens egenskaper sätts för varje del av texten separat.
{{% /alert %}}

### **Använda transformationer i WordArt**

Använd [TextFrameFormat.setTransform](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setTransform) för att transformera hela textblocket:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Resultatet:

![Text med bågformad transformation](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Både Microsoft PowerPoint och Aspose.Slides för Python via Java tillhandahåller ett visst antal fördefinierade transformationstyper.
{{% /alert %}}

**Använda PowerPoint**

För att komma åt fördefinierade transformationstyper, gå till: **Format** -> **TextEffect** -> **Transform**

**Använda Aspose.Slides**

För att välja en transformationstyp, använd enum‑typen [TextShapeType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textshapetype/).

### **Applicera 3D‑effekter på text och former**

Vi applicerar en 3D‑effekt på en textform med detta exempel på kod:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Den resulterande texten och dess form:

![Textform med 3D‑effekter](image-20200930114816-9.png)

Vi applicerar en 3D‑effekt på texten med denna Python‑kod:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Resultatet av operationen:

![Text med 3D‑effekter](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
Tillämpningen av 3D‑effekter på text eller dess former samt interaktioner mellan effekter baseras på vissa regler.

Tänk på en scen för texten och formen som innehåller texten. 3D‑effekten innehåller en 3D‑objektrepresentation och scenen där objektet placeras.

- När scenen är inställd för både formen och texten, har formens scen prioritet – textscenen ignoreras.
- När formen saknar egen scen men har en 3D‑representation, används textscenen.
- Annars – när formen ursprungligen inte har någon 3D‑effekt – är formen platt och 3D‑effekten appliceras bara på texten.

Dessa regler relaterar till metoderna [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getLightRig) och [ThreeDFormat.getCamera](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Applicera yttre skuggeffekter på text**

Aspose.Slides för Python via Java tillhandahåller klasserna [OuterShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/outershadow/) och [InnerShadow](https://reference.aspose.com/slides/sv/python-java/aspose.slides/innershadow/) som låter dig applicera skuggeffekter på text i en [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/). Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta referensen till en bild genom att använda dess index.
3. Lägg till en rektangulär form på bilden.
4. Få åtkomst till textramen som är associerad med formen.
5. Inaktivera formens fyllning.
6. Aktivera den yttre skuggeffekten.
7. Ställ in suddradius för skuggan.
8. Ställ in skuggans riktning.
9. Ställ in skuggans avstånd.
10. Justera skuggan till övre vänstra hörnet.
11. Ställ in skuggans färg till svart.
12. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

Detta exempel på kod i Python via Java—en implementering av stegen ovan—visar hur du applicerar den yttre skuggeffekten på text:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Hämta referens till bilden
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en AutoShape av rektangeltyp
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Lägg till TextFrame till rektangeln
    auto_shape.addTextFrame("Aspose TextBox")

    # Inaktivera formfyllning ifall vi vill få skugga av texten
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Lägg till yttre skugga och sätt alla nödvändiga parametrar
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Spara presentationen till disk
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Applicera inre skuggeffekt på former**

Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till bilden.
3. Lägg till en rektangulär form.
4. Aktivera den inre skuggeffekten.
5. Ställ in alla nödvändiga parametrar.
6. Ställ in skuggans färgtyp för att använda en temafärg.
7. Ställ in temafärgen.
8. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

Detta exempel på kod (baserat på stegen ovan) visar hur du applicerar den inre skuggeffekten på texten i en form i Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Hämta referens till bilden
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en AutoShape av rektangeltyp
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Lägg till TextFrame till rektangeln
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Aktivera InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Ställ in alla nödvändiga parametrar
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Ange ColorType som Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Ange Scheme Color
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Spara presentationen
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag använda WordArt‑effekter med olika typsnitt eller skript (t.ex. Arabiska, Kinesiska)?**

Ja, Aspose.Slides stödjer Unicode och fungerar med alla större typsnitt och skript. WordArt‑effekter som skugga, fyllning och kontur kan appliceras oavsett språk, även om typsnittstillgänglighet och rendering kan bero på systemets typsnitt.

**Kan jag applicera WordArt‑effekter på element i bildbakgrund (master)?**

Ja, du kan applicera WordArt‑effekter på former i master‑bilder, inklusive titel‑platshållare, sidfötter eller bakgrundstext. Ändringar i master‑layouten kommer att återspeglas i alla associerade bilder.

**Påverkar WordArt‑effekter presentationsfilens storlek?**

Lite grann. WordArt‑effekter såsom skuggor, glöd och gradientfyllningar kan något öka filstorleken på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bilder (t.ex. PNG, JPEG) med hjälp av [Shape.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) eller [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.