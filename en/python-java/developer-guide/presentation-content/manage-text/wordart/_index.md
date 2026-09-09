---
title: Create and Apply WordArt Effects in Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /python-java/wordart/
keywords:
- WordArt
- create WordArt
- WordArt template
- WordArt effect
- shadow effect
- reflection effect
- glow effect
- WordArt transformation
- 3D effect
- outer shadow effect
- inner shadow effect
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Create and customize WordArt effects in Aspose.Slides for Python via Java. This step-by-step guide helps developers enhance presentations with professional text in Python via Java."
---

## **Overview**

WordArt effects allow you to add visually appealing, stylized text to your PowerPoint presentations. With Aspose.Slides, developers can programmatically create, customize, and manage WordArt just like in Microsoft PowerPoint—without needing Office installed. This article provides an overview of working with WordArt, including how to apply text transformations, fill styles, outlines, shadows, and other formatting options to make your presentation content more expressive and engaging. WordArt allows you to treat text as a graphical object. It consists of effects or special modifications applied to text to make it more attractive or noticeable.

## **Create a Simple WordArt Template and Apply It to Text**

**Using Aspose.Slides**

First, we create simple text using this Python code:

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
Next, increase the font size to make the effect more noticeable:

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

**Using Microsoft PowerPoint**

Go to the WordArt effects menu in Microsoft PowerPoint:

![WordArt effects menu in PowerPoint](image-20200930113926-1.png)

From the menu on the right, you can choose a predefined WordArt effect. From the menu on the left, you can specify the settings for new WordArt.

These are some of the available parameters or options:

![WordArt formatting options](image-20200930114015-3.png)

**Using Aspose.Slides**

Here, we apply the [PatternStyle.SmallGrid](https://reference.aspose.com/slides/python-java/aspose.slides/patternstyle/#SmallGrid) pattern fill to the text and add a black text border using this code:

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

The resulting text:

![Text with a pattern fill and black outline](image-20200930114108-4.png)

## **Applying Other WordArt Effects**

**Using Microsoft PowerPoint**

From the program’s interface, you can apply these effects to text, a text block, a shape, or a similar element:

![Text and shape effects in PowerPoint](image-20200930114129-5.png)

For example, Shadow, Reflection, and Glow effects can be applied to text; 3D Format and 3D Rotation effects can be applied to a text block; the Soft Edges effect can be applied to a shape (it still has an effect when no 3D Format effect is set).

### **Applying Shadow Effects**

The following Python code applies a shadow effect to text only:

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

Aspose.Slides API supports three types of shadows: [OuterShadow](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/python-java/aspose.slides/innershadow/), and [PresetShadow](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/).

With [PresetShadow](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/), you can apply a shadow to text using preset values.

**Using Microsoft PowerPoint**

In PowerPoint, you can use one type of shadow. Here’s an example:

![Shadow settings in PowerPoint](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides actually allows you to apply two types of shadows at once: [InnerShadow](https://reference.aspose.com/slides/python-java/aspose.slides/innershadow/) and [PresetShadow](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/).

**Notes:**

- When [OuterShadow](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/) and [PresetShadow](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/) are used together, only the [OuterShadow](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/) effect is applied.
- If [OuterShadow](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/) and [InnerShadow](https://reference.aspose.com/slides/python-java/aspose.slides/innershadow/) are used simultaneously, the resulting or applied effect depends on the PowerPoint version. For instance, in PowerPoint 2013, the effect is doubled. But in PowerPoint 2007, the [OuterShadow](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/) effect is applied.

### **Apply Reflection to Text**

We add a reflection to the text through this code sample in Python via Java:

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

### **Apply a Glow Effect to Text**

We apply the glow effect to the text to make it shine or stand out using this code:

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

The result of the operation:

![Text with a glow effect](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}

You can change the parameters for shadow, reflection, and glow. The effects’ properties get set on each portion of the text separately.

{{% /alert %}}

### **Using Transformations in WordArt**

Use [TextFrameFormat.setTransform](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTransform) to transform the entire text block:

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

The result:

![Text with an arch transformation](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}

Both Microsoft PowerPoint and Aspose.Slides for Python via Java provide a certain number of predefined transformation types.

{{% /alert %}}

**Using PowerPoint**

To access predefined transformation types, go to: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

To select a transformation type, use the [TextShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/textshapetype/) enumeration.

### **Apply 3D Effects to Text and Shapes**

We apply a 3D effect to a text shape using this sample code:

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

The resulting text and its shape:

![Text shape with 3D effects](image-20200930114816-9.png)

We apply a 3D effect to the text with this Python code:

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

The result of the operation:

![Text with 3D effects](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}

The application of 3D effects to text or its shapes and interactions between effects are based on certain rules.

Consider a scene for text and the shape containing that text. The 3D effect contains a 3D object representation and the scene in which the object is placed.

- When the scene is set for both the shape and the text, the shape scene takes priority—the text scene is ignored.
- When the shape lacks its own scene but has a 3D representation, the text scene is used.
- Otherwise—when the shape originally has no 3D effect—the shape is flat and the 3D effect is applied only to the text.

These rules relate to the [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) and [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) methods.

{{% /alert %}}

## **Apply Outer Shadow Effects to Text**

Aspose.Slides for Python via Java provides the [OuterShadow](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/) and [InnerShadow](https://reference.aspose.com/slides/python-java/aspose.slides/innershadow/) classes that allow you to apply shadow effects to text in a [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/). Follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Obtain the reference to a slide by using its index.
3. Add a rectangular shape to the slide.
4. Access the text frame associated with the shape.
5. Disable the shape fill.
6. Enable the outer shadow effect.
7. Set the blur radius of the shadow.
8. Set the direction of the shadow.
9. Set the distance of the shadow.
10. Align the shadow to the top left.
11. Set the shadow color to black.
12. Write the presentation as a [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

This sample code in Python via Java—an implementation of the steps above—shows you how to apply the outer shadow effect to text:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Get reference of the slide
    slide = presentation.getSlides().get_Item(0)

    # Add an AutoShape of Rectangle type
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Add TextFrame to the Rectangle
    auto_shape.addTextFrame("Aspose TextBox")

    # Disable shape fill in case we want to get shadow of text
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Add outer shadow and set all necessary parameters
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Write the presentation to disk
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Apply Inner Shadow Effect to Shapes**

Follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference of the slide.
3. Add a rectangular shape.
4. Enable the inner shadow effect.
5. Set all the necessary parameters.
6. Set the shadow color type to use a theme color.
7. Set the theme color.
8. Write the presentation as a [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

This sample code (based on the steps above) shows you how to apply the inner shadow effect to the text in a shape in Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Get reference of the slide
    slide = presentation.getSlides().get_Item(0)

    # Add an AutoShape of Rectangle type
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Add TextFrame to the Rectangle
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Enable InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Set all necessary parameters
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Set ColorType as Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Set Scheme Color
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Save Presentation
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I use WordArt effects with different fonts or scripts (e.g., Arabic, Chinese)?**

Yes, Aspose.Slides supports Unicode and works with all major fonts and scripts. WordArt effects such as shadow, fill, and outline can be applied regardless of the language, although font availability and rendering may depend on the system fonts.

**Can I apply WordArt effects to slide master elements?**

Yes, you can apply WordArt effects to shapes on master slides, including title placeholders, footers, or background text. Changes made to the master layout will be reflected across all associated slides.

**Do WordArt effects affect presentation file size?**

Slightly. WordArt effects like shadows, glows, and gradient fills may slightly increase the file size due to added formatting metadata, but the difference is usually negligible.

**Can I preview the result of WordArt effects without saving the presentation?**

Yes, you can render slides containing WordArt to images (e.g., PNG, JPEG) using [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) or [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage). This lets you preview the result in-memory or on-screen before saving or exporting the full presentation.
