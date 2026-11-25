---
title: 使用 Python via Java 在演示文稿中应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/python-java/shape-effect/
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 发光效果
- 柔边效果
- 效果格式
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将 PPT 和 PPTX 文件转化为高级形状效果——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可用于突出形状，但它们不同于 [填充](/slides/zh/python-java/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩散形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一个或多个效果。

某些效果组合看起来比其他组合更好。因此，PowerPoint 在 **Preset** 下提供选项。Preset 选项是两个或多个已知效果良好的组合。这样，通过选择预设，您无需花时间测试或组合不同效果以找到合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) 类中提供属性和方法，允许您对 PowerPoint 演示文稿中的形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Python via Java 支持形状的外部和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影使卡片或面板在幻灯片背景上突出。阴影延伸到形状边缘之外，营造形状高于幻灯片的感觉。调整其颜色、方向、距离和模糊半径，以匹配模板的灯光和样式。

以下 Python 代码展示了如何将 [外部阴影效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) 应用于矩形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![阴影效果](shadow_effect.png)

### **应用内部阴影**

在复现模板的视觉样式时，使用内部阴影为卡片或面板提供凹陷的外观。外部阴影延伸到形状外部，使其看起来突出，而内部阴影则在边缘内部着色。

Call [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), then configure the shadow returned by [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). 较大的模糊半径值会产生更柔和的边缘。

以下 Python 示例创建了一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 点，模糊半径为 6 点：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![带内部阴影的浅蓝色矩形](inner_shadow_effect.png)

要移除内部阴影，请对形状的 effect format 调用 [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

### **应用、修改和移除预设阴影**

Call [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), then use [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) to select a [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). 要切换样式，可在同一形状上更改预设。调用 [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) 可在保留填充和轮廓的情况下移除阴影。

示例在每个阶段克隆矩形，以便您在同一幻灯片上并排比较四种状态。两个阴影均偏移 10 点。225° 的方向将第一个阴影放置在矩形的左上方。45° 的方向将第二个阴影放置在右下方。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 原始 | 第一预设 | 第二预设 | 移除后 |
| :---: | :---: | :---: | :---: |
| ![无阴影](preset_shadow_original.png) | ![左上投影阴影](preset_shadow_top_left.png) | ![右下投影阴影](preset_shadow_bottom_right.png) | ![移除后无阴影](preset_shadow_removed.png) |

## **应用反射效果**

要在 Aspose.Slides for Python via Java 中应用反射效果，您可以向形状添加镜面反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更精致、更加专业的外观来提升演示文稿的美感。使用简短的代码即可轻松实现，可快速在多个元素上统一应用以保持设计一致性。

以下 Python 代码展示了如何将 [反射效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) 应用于形状：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![反射效果](reflection_effect.png)

## **应用发光效果**

要在 Aspose.Slides for Python via Java 中对形状应用发光效果，您可以在形状周围添加柔和的光晕，并调整颜色和大小等属性。此效果有助于使形状更突出，并为演示文稿增添吸引人的视觉元素。只需少量代码即可轻松实现，提升幻灯片的整体观感。

以下 Python 代码展示了如何将 [发光效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) 应用于形状：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![发光效果](glow_effect.png)

## **应用柔边效果**

要在 Aspose.Slides for Python via Java 中应用柔边效果，您可以在形状的边缘创建平滑、模糊的过渡。此效果增添了更细致、精致的外观，非常适合需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿中的各种形状上获得所需效果。

以下 Python 代码展示了如何将 [柔边效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) 应用于形状：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![柔边效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可在保持形状可编辑的同时软化其填充和轮廓。对形状的 effect format 调用 [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect)。半径以点为单位（1/72 英寸）：使用非负值，数值越大模糊越强。半径为零时外观保持不变。

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) 设置控制效果的可见边界。设为 `False` 时，模糊被裁剪到原始绘制边界（包括轮廓）；设为 `True` 时，模糊可以超出该边界。两种设置都不会改变形状的位置或尺寸。

下面的比较使用相同的填充、轮廓和形状尺寸。上排使用 `grow = False`；下排使用 `grow = True`。

![原始矩形与模糊半径为5和15点的比较，grow 禁用和启用时](shape_blur_comparison.png)

以下 Python 示例创建了一个橙色矩形，带深蓝色轮廓，先应用 5 点模糊，然后再次调用 [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) 将模糊半径升级为 15 点，并保存这两种模糊状态，随后调用 [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) 并保存无模糊的形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

形状模糊同时影响填充和轮廓。柔边效果仅淡化形状的边缘，而阴影模糊仅软化阴影本身。图像转换效果作用于图像内容；本例直接对形状的 effect format 应用模糊，而无需将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，例如阴影、反射和发光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对多种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

可以，您可以对组合形状应用效果。效果将作用于整个组合。