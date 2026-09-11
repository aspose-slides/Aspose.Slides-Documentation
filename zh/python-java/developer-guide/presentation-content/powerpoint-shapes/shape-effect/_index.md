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
- 柔化边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将您的 PPT 和 PPTX 文件转换为高级形状效果——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可用于突出形状，但它们不同于 [fills](/slides/zh/python-java/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射、扩展形状的发光等。

<img src="shape-effect.png" alt="形状效果" style="zoom:50%;" />

* PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一个或多个效果。

* 某些效果组合比其他的更好看。基于此，PowerPoint 在 **Preset** 下提供了选项。Preset 选项本质上是两种或更多已知效果良好组合的预设。这样，选择预设后，您无需花时间测试或组合不同效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effectformat/) 类下提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

以下 Python 代码演示如何将外部阴影效果（[EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effectformat/#getOuterShadowEffect)）应用于矩形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **应用反射效果**

以下 Python 代码演示如何将反射效果应用于形状：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **应用发光效果**

以下 Python 代码演示如何将发光效果应用于形状：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **应用柔化边缘效果**

以下 Python 代码演示如何将柔化边缘效果应用于形状：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，例如阴影、反射和发光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。效果将应用于整个组合。