---
title: Maak en pas WordArt‑effecten toe in Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /nl/python-java/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt‑sjabloon
- WordArt‑effect
- schaduw‑effect
- reflectie‑effect
- gloed‑effect
- WordArt‑transformatie
- 3D‑effect
- buiten‑schaduw‑effect
- binnen‑schaduw‑effect
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak en pas WordArt‑effecten aan in Aspose.Slides voor Python via Java. Deze stapsgewijze handleiding helpt ontwikkelaars presentaties te verbeteren met professionele tekst in Python via Java."
---
## **Overzicht**

WordArt‑effecten stellen u in staat om visueel aantrekkelijke, gestileerde tekst toe te voegen aan uw PowerPoint‑presentaties. Met Aspose.Slides kunnen ontwikkelaars programmatiche WordArt aanmaken, aanpassen en beheren, net zoals in Microsoft PowerPoint — zonder dat Office geïnstalleerd hoeft te zijn. Dit artikel geeft een overzicht van het werken met WordArt, inclusief hoe u teksttransformaties, vullingsstijlen, contouren, schaduwen en andere opmaakopties toepast om de inhoud van uw presentatie expressiever en boeiender te maken. WordArt laat u tekst behandelen als een grafisch object. Het bestaat uit effecten of speciale aanpassingen die op tekst worden toegepast om deze aantrekkelijker of opvallender te maken.

## **Maak een eenvoudige WordArt‑sjabloon en pas deze toe op tekst**

**Met Aspose.Slides**

Eerst maken we eenvoudige tekst met deze Python‑code:

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
Vervolgens vergroten we de lettergrootte om het effect beter zichtbaar te maken:

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

**Met Microsoft PowerPoint**

Ga naar het WordArt‑effectenmenu in Microsoft PowerPoint:

![WordArt effects menu in PowerPoint](image-20200930113926-1.png)

Van het menu aan de rechterkant kunt u een vooraf gedefinieerd WordArt‑effect kiezen. Van het menu aan de linkerkant kunt u de instellingen voor nieuw WordArt specificeren.

Dit zijn enkele van de beschikbare parameters of opties:

![WordArt formatting options](image-20200930114015-3.png)

**Met Aspose.Slides**

Hier passen we de [PatternStyle.SmallGrid](https://reference.aspose.com/slides/nl/python-java/aspose.slides/patternstyle/#SmallGrid) patroonvulling toe op de tekst en voegen we een zwarte tekstrand toe met deze code:

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

De resulterende tekst:

![Text with a pattern fill and black outline](image-20200930114108-4.png)

## **Andere WordArt‑effecten toepassen**

**Met Microsoft PowerPoint**

Via de interface van het programma kunt u deze effecten toepassen op tekst, een tekstblok, een vorm of een vergelijkbaar element:

![Text and shape effects in PowerPoint](image-20200930114129-5.png)

Bijvoorbeeld, schaduw-, reflectie‑ en gloed‑effecten kunnen op tekst worden toegepast; 3D‑opmaak‑ en 3D‑rotatie‑effecten kunnen op een tekstblok worden toegepast; het Soft Edges‑effect kan op een vorm worden toegepast (het blijft effect hebben wanneer er geen 3D‑opmaak‑effect is ingesteld).

### **Schaduw‑effecten toepassen**

De volgende Python‑code past een schaduweffect alleen toe op tekst:

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

De Aspose.Slides‑API ondersteunt drie soorten schaduwen: [OuterShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/innershadow/), en [PresetShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presetshadow/).

Met [PresetShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presetshadow/) kunt u een schaduw op tekst toepassen met vooraf ingestelde waarden.

**Met Microsoft PowerPoint**

In PowerPoint kunt u één type schaduw gebruiken. Hier is een voorbeeld:

![Shadow settings in PowerPoint](image-20200930114225-6.png)

**Met Aspose.Slides**

Aspose.Slides maakt het inderdaad mogelijk om twee soorten schaduwen tegelijk toe te passen: [InnerShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/innershadow/) en [PresetShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presetshadow/).

**Notes:**
- Wanneer [OuterShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/outershadow/) en [PresetShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presetshadow/) samen worden gebruikt, wordt alleen het [OuterShadow]‑effect toegepast.
- Indien [OuterShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/outershadow/) en [InnerShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/innershadow/) gelijktijdig worden gebruikt, hangt het resulterende of toegepaste effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld. Maar in PowerPoint 2007 wordt het [OuterShadow]‑effect toegepast.

### **Reflectie op tekst toepassen**

We voegen een reflectie toe aan de tekst via dit code‑voorbeeld in Python via Java:

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

### **Een gloed‑effect op tekst toepassen**

We passen het gloed‑effect toe op de tekst om deze te laten schitteren of op te laten vallen met deze code:

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

Het resultaat van de bewerking:

![Text with a glow effect](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
U kunt de parameters voor schaduw, reflectie en gloed wijzigen. De eigenschappen van de effecten worden afzonderlijk ingesteld voor elk deel van de tekst.
{{% /alert %}}

### **Transformaties in WordArt gebruiken**

Gebruik [TextFrameFormat.setTransform](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setTransform) om het gehele tekstblok te transformeren:

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

Het resultaat:

![Text with an arch transformation](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Zowel Microsoft PowerPoint als Aspose.Slides voor Python via Java bieden een aantal vooraf gedefinieerde transformatietypen.
{{% /alert %}}

**Met PowerPoint**

Om de vooraf gedefinieerde transformatietypen te openen, ga naar: **Format** -> **TextEffect** -> **Transform**

**Met Aspose.Slides**

Om een transformatietype te selecteren, gebruikt u de enumeratie [TextShapeType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textshapetype/).

### **3D‑effecten toepassen op tekst en vormen**

We passen een 3D‑effect toe op een tekstvorm met deze voorbeeldcode:

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

De resulterende tekst en bijbehorende vorm:

![Text shape with 3D effects](image-20200930114816-9.png)

We passen een 3D‑effect toe op de tekst met deze Python‑code:

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

Het resultaat van de bewerking:

![Text with 3D effects](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
De toepassing van 3D‑effecten op tekst of zijn vormen en de interacties tussen effecten zijn gebaseerd op bepaalde regels.

Beschouw een scène voor de tekst en de vorm die die tekst bevat. Het 3D‑effect bevat een weergave van een 3D‑object en de scène waarin het object geplaatst is.

- Wanneer de scène zowel voor de vorm als voor de tekst is ingesteld, heeft de scène van de vorm voorrang — de scène van de tekst wordt genegeerd.
- Wanneer de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de tekst‑scène gebruikt.
- Anders — wanneer de vorm oorspronkelijk geen 3D‑effect heeft — is de vorm vlak en wordt het 3D‑effect alleen op de tekst toegepast.

Deze regels hebben betrekking op de methoden [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getLightRig) en [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nl/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Buiten‑schaduw‑effecten toepassen op tekst**

Aspose.Slides voor Python via Java biedt de klassen [OuterShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/outershadow/) en [InnerShadow](https://reference.aspose.com/slides/nl/python-java/aspose.slides/innershadow/) waarmee u schaduweffecten kunt toepassen op tekst in een [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/). Volg deze stappen:

1. Maak een instantie van de klasse [Presentation] aan.
2. Verkrijg de referentie naar een dia met behulp van de index.
3. Voeg een rechthoekige vorm toe aan de dia.
4. Open het tekstframe dat aan de vorm is gekoppeld.
5. Schakel de vulling van de vorm uit.
6. Schakel het buiten‑schaduweffect in.
7. Stel de onscherpte‑radius van de schaduw in.
8. Stel de richting van de schaduw in.
9. Stel de afstand van de schaduw in.
10. Lijn de schaduw uit naar links‑boven.
11. Stel de schaduwkleur in op zwart.
12. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

De voorbeeldcode in Python via Java — een implementatie van de bovenstaande stappen — laat zien hoe u het buiten‑schaduweffect op tekst toepast:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Verkrijg referentie naar de dia
    slide = presentation.getSlides().get_Item(0)

    # Voeg een AutoShape van type Rechthoek toe
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Voeg een TextFrame toe aan de rechthoek
    auto_shape.addTextFrame("Aspose TextBox")

    # Schakel de vulling van de vorm uit voor het geval we de schaduw van de tekst willen gebruiken
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Voeg een buitenste schaduw toe en stel alle benodigde parameters in
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Sla de presentatie op naar de schijf
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Binnen‑schaduw‑effect op vormen toepassen**

Volg deze stappen:

1. Maak een instantie van de klasse [Presentation] aan.
2. Verkrijg een referentie naar de dia.
3. Voeg een rechthoekige vorm toe.
4. Schakel het binnen‑schaduweffect in.
5. Stel alle benodigde parameters in.
6. Stel het type schaduwkleur in om een themakleur te gebruiken.
7. Stel de themakleur in.
8. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

De voorbeeldcode (gebaseerd op de bovenstaande stappen) laat zien hoe u het binnen‑schaduweffect toepast op de tekst in een vorm in Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Verkrijg referentie van de dia
    slide = presentation.getSlides().get_Item(0)

    # Voeg een AutoShape van type Rechthoek toe
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Voeg een TextFrame toe aan de rechthoek
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Schakel InnerShadowEffect in
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Stel alle benodigde parameters in
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Stel ColorType in als Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Stel Scheme-kleur in
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Sla de presentatie op
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of schriftsoorten (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides ondersteunt Unicode en werkt met alle gangbare lettertypen en schriftsoorten. WordArt‑effecten zoals schaduw, vulling en contour kunnen ongeacht de taal worden toegepast, hoewel de beschikbaarheid van lettertypen en de weergave kunnen afhangen van de systeemlettertypen.

**Kan ik WordArt‑effecten toepassen op elementen van de dia‑master?**

Ja, u kunt WordArt‑effecten toepassen op vormen in master‑dia’s, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen in de master‑indeling worden doorgevoerd in alle bijbehorende dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

Enigszins. WordArt‑effecten zoals schaduwen, gloed en gradientvullingen kunnen de bestandsgrootte iets verhogen door extra opmaak‑metadata, maar het verschil is meestal verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia’s met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met behulp van [Shape.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) of [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage). Hiermee kunt u het resultaat in het geheugen of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.