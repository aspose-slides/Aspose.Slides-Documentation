---
title: 在演示文稿中使用 Python via Java 应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/python-java/shape-effect/
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 发光效果
- 柔化边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将您的 PPT 和 PPTX 文件转换为高级形状效果——在几秒钟内创建醒目、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可用于让形状突出，但它们不同于 [填充](/slides/zh/python-java/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，你可以在形状上创建逼真的反射，扩展形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。你可以对形状应用一种或多种效果。

某些效果组合看起来比其他组合更好。因此，PowerPoint 在 **Preset** 下提供选项。Preset 选项是两个或多个已知效果组合，这样通过选择预设，你无需浪费时间测试或组合不同效果来找到合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) 类下提供属性和方法，允许你在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Python via Java 支持形状的外部和内部阴影。你可以自定义它们的颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影可以让卡片或面板在幻灯片背景上突出。阴影延伸超出形状边缘，营造形状位于幻灯片之上的感觉。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

此 Python 代码演示如何对矩形应用 [外部阴影效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect)：

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

#### **在形状旋转时控制阴影方向**

默认情况下，外部阴影会随形状旋转。为了使不同旋转的形状看起来从相同方向受光，请使用 `False` 调用 [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape)，并使用 [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) 为它们的阴影设定相同的方向。

该示例创建了两个带有灰色阴影、向右偏移 42 点（0°）的蓝色箭头。随后复制幻灯片并将两个箭头顺时针旋转 90°。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在第二张幻灯片中，左侧箭头的阴影向下投射，而右侧箭头的阴影仍向右投射。配置的方向对两个阴影均保持 0°。

![PowerPoint 渲染在 90° 旋转前后的对比。两个阴影最初在右侧。旋转后，左侧箭头的阴影移至下方，右侧箭头的阴影仍在右侧。](arrow-shadow-rotation.png)

### **应用内部阴影**

在复制模板的视觉样式时，使用内部阴影可以使卡片或面板呈现凹陷外观。外部阴影延伸到形状外部，使其看起来凸起，而内部阴影则为其边缘内部着色。

调用 [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect)，然后配置由 [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) 返回的阴影。较大的模糊半径值会产生更柔和的边缘。

此 Python 示例创建了一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 点，模糊半径为 6 点：

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

要移除内部阴影，请在形状的 effect format 上调用 [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

### **应用、修改和移除预设阴影**

调用 [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect)，然后使用 [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) 选择 [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/)。要切换样式，可在同一形状上更改预设。调用 [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) 可在保留填充和轮廓的同时移除阴影。

该示例在每个阶段克隆矩形，以便在同一张幻灯片上并排比较四种状态。两个阴影均偏移 10 点。225° 的方向将第一个阴影放置在矩形的左上方。45° 的方向将第二个阴影放置在右下方。

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

| 原始 | 第一个预设 | 第二个预设 | 移除后 |
| :---: | :---: | :---: | :---: |
| ![无阴影](preset_shadow_original.png) | ![左上投影阴影](preset_shadow_top_left.png) | ![右下投影阴影](preset_shadow_bottom_right.png) | ![移除后无阴影](preset_shadow_removed.png) |

## **应用反射效果**

要在 Aspose.Slides for Python via Java 中应用反射效果，你可以为形状添加镜像反射，调整距离、透明度和大小等参数。此效果通过为形状增添更精致、专业的外观来提升演示文稿的美感。只需简单代码即可实现，能够快速在多个元素上统一应用以保持设计一致性。

此 Python 代码演示如何对形状应用 [反射效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect)：

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

要在 Aspose.Slides for Python via Java 中为形状应用发光效果，你可以在形状周围添加柔和的光晕，调整颜色和大小等属性。此效果有助于突出形状并为演示文稿增添吸引眼球的视觉元素。只需少量代码即可实现，提升幻灯片整体外观。

此 Python 代码演示如何对形状应用 [发光效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect)：

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

## **应用柔化边缘效果**

要在 Aspose.Slides for Python via Java 中应用柔化边缘效果，你可以在形状的边缘周围创建平滑、模糊的过渡。此效果为设计增添更细腻、精致的外观，适用于需要柔和外观的设计。你可以轻松调整半径等参数，以在演示文稿的各种形状上实现所需效果。

此 Python 代码演示如何对形状应用 [柔化边缘效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect)：

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

![柔化边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可以在保持形状可编辑的同时软化其填充和轮廓。对形状的 effect format 调用 [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect)。半径以点为单位（1/72 英寸）：使用非负值，值越大模糊越强。半径为零时外观保持不变。

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) 设置控制效果的可见范围。`False` 时，模糊被限制在原始绘制范围内，包括轮廓；`True` 时，模糊可以超出该范围。两种设置均不改变形状的位置或尺寸。

下面的比较在整个过程中使用相同的填充、轮廓和形状尺寸。顶部行使用 `grow = False`；底部行使用 `grow = True`。

![原始矩形与模糊半径 5 点和 15 点的比较，分别在禁用和启用 grow 的情况下](shape_blur_comparison.png)

此 Python 示例创建了一个橙色矩形，带深蓝色轮廓，应用 5 点模糊，然后调用 [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) 再次将其更新为 15 点模糊。它保存了两个模糊状态，然后调用 [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) 并保存无模糊的形状。

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

形状模糊同时影响填充和轮廓。柔化边缘效果淡化形状的边缘，而阴影模糊仅软化阴影。图像转换效果作用于图像内容；本例直接在形状的 effect format 上应用模糊，而不将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，你可以在单个形状上组合不同的效果，例如阴影、反射和发光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

你可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等等。

**我可以对组合形状应用效果吗？**

是的，你可以对组合形状应用效果。效果将应用于整个组合。