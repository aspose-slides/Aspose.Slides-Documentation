---
title: Skapa och tillämpa WordArt‑effekter i Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /sv/python-java/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt‑mall
- WordArt‑effekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- WordArt‑transformation
- 3D‑effekt
- yttre skuggeffekt
- inre skuggeffekt
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för Python via Java. Denna steg‑för‑steg‑guide hjälper utvecklare att förbättra presentationer med professionell text i Python via Java."
---
## **Översikt**

WordArt‑effekter låter dig formatera text med fyllningar, konturer, skuggor, reflektioner, glöd, transformationer och 3D‑formatering. Denna artikel förklarar hur du skapar och anpassar dessa effekter i PowerPoint‑presentationer med Aspose.Slides för Python via Java, utan att Microsoft Office är installerat.

## **Skapa en enkel WordArt-mall och tillämpa den på text**

Följande exempel skapar en enkel WordArt‑stil genom att ange text, teckensnitt, mönsterfyllning och kontur.

Varje exempel skapar en ny presentation och lägger till en rektangel på den första bilden; ingen indatafil krävs. Det första exemplet sätter texten till "Aspose.Slides". Formens position och dimensioner mäts i punkter:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Ställ in teckensnittet till Arial Black med 36 punkter för att göra formateringen mer märkbar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Applicera ett [SmallGrid](https://reference.aspose.com/slides/sv/python-java/aspose.slides/patternstyle/#SmallGrid)-mönster med en mörk orange förgrund och en vit bakgrund, lägg sedan till en svart textkontur med en bredd på 1 punkt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Den resulterande texten:

![The simple WordArt template](WordArt_template.png)

## **Tillämpa andra WordArt-effekter**

Följande exempel visar hur du tillämpar skuggor, reflektioner, glöd, transformationer och 3D‑effekter på text.

### **Applicera yttre skuggeffekter**

En yttre skugga ger djup genom att placera en skugga bakom texten. Du kan anpassa dess färg, riktning, avstånd, oskärpedjup, skala och skevning.

Detta exempel anropar [enableOuterShadowEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) och ställer in en svart skugga med en oskärpedjup på 4 punkter, en riktning på 230 grader och ett avstånd på 30 punkter. Skalvärden på 100 bevarar skuggans storlek, medan horisontell skevning lutande den 20 grader. Alfa‑transformen sätter dess opacitet till 32 %:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Den resulterande texten:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- När yttre och förinställda skuggor används tillsammans, appliceras endast den yttre skuggan.
- Om yttre och inre skuggor används samtidigt beror den resulterande effekten på vilken PowerPoint‑version som används. Till exempel, i PowerPoint 2013 fördubblas effekten, medan i PowerPoint 2007 appliceras endast den yttre skuggan.
{{% /alert %}}

### **Applicera reflektionseffekter**

En reflektion skapar en spegelkopiering av texten. Justera dess position, skala, oskärpa och opacitet för att kontrollera dess utseende.

Detta exempel anropar [enableReflectionEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effectformat/#enableReflectionEffect) och vänder reflektionen vertikalt med en skala på -100 %. Det använder en oskärpedjup på 0,5 punkt och ett avstånd på 4,72 punkt. Opaciteten minskar från 60 % till 0,9 % mellan positionerna 0 % och 60 % längs reflektionen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

Den resulterande texten:

![The Reflection effect](reflection_effect.png)

### **Applicera glödeffekter**

En glöd lägger till en mjuk färgad kontur runt texten. Justera dess färg, opacitet och radie för att kontrollera effekten.

Detta exempel anropar [enableGlowEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effectformat/#enableGlowEffect) och applicerar en röd glöd med 54 % opacitet och en radie på 7 punkter:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

Den resulterande texten:

![The Glow effect](glow_effect.png)

### **Tillämpa WordArt-transformationer**

WordArt‑transformationer böjer, sträcker eller vrider en textblock.

Använd [setTransform](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setTransform) till [ArchUpPour](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textshapetype/#ArchUpPour) för att kröka hela textramen uppåt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Den resulterande texten:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides för Python via Java tillhandahåller en uppsättning fördefinierade [transformationstyper](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Tillämpa 3D-effekter på former och text**

Du kan applicera 3D‑effekter på en form eller på dess text. Avfasningar, extrusion, belysning och kamerainställningar styr det resulterande utseendet.

Det följande exemplet använder [ThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/) för att lägga till cirkulära avfasningar, orange extrusion och en mörkröd kontur på rektangeln. Avfasningsdimensioner, extrusionhöjd, konturbredd och djup mäts i punkter. Ett plastmaterial, balanserad belysning roterad 40 grader runt Z‑axeln, och en perspektivkamera definierar dess utseende:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Den resulterande formen:

![The shape 3D effect](shape_3D_effect.png)

Detta exempel applicerar liknande 3D‑formatering på texten via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#getThreeDFormat). Små avfasningar formar bokstavens kanter, medan extrusion och belysning ger texten djup:

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

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Den resulterande texten:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Appliceringen av 3D‑effekter på text eller dess former — och interaktionen mellan dessa effekter — styrs av specifika regler. Tänk på en scen som involverar både text och den form som innehåller den. En 3D‑effekt inkluderar objektets 3D‑representation och den scen där det placeras.

- Om en scen är angiven både för formen och för texten, har formens scen prioritet och textens scen ignoreras.
- Om formen saknar egen scen men har en 3D‑representation, används textens scen.
- Om formen helt saknar 3D‑effekt behandlas den som platt, och 3D‑effekten appliceras endast på texten.

Detta beteende är relaterat till metoderna [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getLightRig) och [ThreeDFormat.getCamera](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

För att hålla texten platt och läsbar samtidigt som du behåller formens 3D‑formatering, se [Keep Text Flat on a 3D Shape](/slides/sv/python-java/3d-presentation/) för en jämförelse av båda inställningarna och ett komplett Python‑exempel.

## **Vanliga frågor**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. arabiska, kinesiska)?**

Ja, Aspose.Slides för Python via Java stödjer Unicode och fungerar med alla större teckensnitt och skript. WordArt‑effekter såsom skugga, fyllning och kontur kan appliceras oavsett språk, även om teckensnittstillgänglighet och rendering kan bero på systemets teckensnitt.

**Kan jag applicera WordArt‑effekter på master‑slide‑element?**

Ja, du kan applicera WordArt‑effekter på former på master‑slides, inklusive titelplatshållare, sidfot eller bakgrundstext. Ändringar gjorda i master‑layouten kommer att reflekteras i alla associerade slides.

**Påverkar WordArt‑effekter presentationsfilens storlek?**

Lite. WordArt‑effekter såsom skuggor, glöd och gradientfyllningar kan öka filstorleken något på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbart.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera slides som innehåller WordArt till bilder (t.ex. PNG, JPEG) med hjälp av [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage), eller rendera enskilda former med [Shape.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.