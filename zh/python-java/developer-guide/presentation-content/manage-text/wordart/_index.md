---
title: 在 Python via Java 中创建和应用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh/python-java/wordart/
keywords:
- WordArt
- 创建 WordArt
- WordArt 模板
- WordArt 效果
- 阴影效果
- 反射效果
- 发光效果
- WordArt 变换
- 3D 效果
- 外部阴影效果
- 内部阴影效果
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中创建和自定义 WordArt 效果。此分步指南帮助开发人员使用 Python via Java 为演示文稿添加专业文本。"
---
## **概览**

WordArt 效果允许您在 PowerPoint 演示文稿中添加视觉上吸引人、风格化的文本。使用 Aspose.Slides，开发人员可以以编程方式创建、定制和管理 WordArt，就像在 Microsoft PowerPoint 中一样——无需安装 Office。本文概述了使用 WordArt 的方法，包括如何应用文本变换、填充样式、轮廓、阴影和其他格式选项，以使演示内容更具表现力和吸引力。WordArt 允许您将文本视为图形对象。它由对文本应用的效果或特殊修改组成，以使其更具吸引力或更显眼。

## **创建简单的 WordArt 模板并将其应用于文本**

**使用 Aspose.Slides**

首先，我们使用以下 Python 代码创建简单文本：

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
接下来，增大字体大小以使效果更明显：

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

**使用 Microsoft PowerPoint**

转到 Microsoft PowerPoint 中的 WordArt 效果菜单：

![PowerPoint 中的 WordArt 效果菜单](image-20200930113926-1.png)

在右侧菜单中，您可以选择预定义的 WordArt 效果。在左侧菜单中，您可以为新 WordArt 指定设置。

以下是一些可用的参数或选项：

![WordArt 格式化选项](image-20200930114015-3.png)

**使用 Aspose.Slides**

在此，我们使用以下代码将 [PatternStyle.SmallGrid](https://reference.aspose.com/slides/zh/python-java/aspose.slides/patternstyle/#SmallGrid) 图案填充应用于文本，并使用黑色文本边框：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

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

生成的文本：

![带图案填充和黑色轮廓的文本](image-20200930114108-4.png)

## **应用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程序界面中，您可以将这些效果应用于文本、文本块、形状或类似元素：

![PowerPoint 中的文本和形状效果](image-20200930114129-5.png)

例如，可以将阴影、反射和发光效果应用于文本；将 3D 格式和 3D 旋转效果应用于文本块；将柔化边缘效果应用于形状（即使未设置 3D 格式效果，仍然有效）。

### **应用阴影效果**

以下 Python 代码仅对文本应用阴影效果：

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

Aspose.Slides API 支持三种阴影类型：[OuterShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/outershadow/)、[InnerShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/innershadow/) 和 [PresetShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presetshadow/)。

使用 [PresetShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presetshadow/)，您可以使用预设值将阴影应用于文本。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您只能使用一种阴影类型。以下是示例：

![PowerPoint 中的阴影设置](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许您一次应用两种阴影类型：[InnerShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/innershadow/) 和 [PresetShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presetshadow/)。

**注意：**

- 当同时使用 [OuterShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/outershadow/) 和 [PresetShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presetshadow/) 时，仅应用 [OuterShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/outershadow/) 效果。
- 如果同时使用 [OuterShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/outershadow/) 和 [InnerShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/innershadow/)，实际应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会叠加；但在 PowerPoint 2007 中，仅应用 [OuterShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/outershadow/) 效果。

### **将反射应用于文本**

我们通过以下 Python（通过 Java）代码为文本添加反射：

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

### **将发光效果应用于文本**

我们使用以下代码将发光效果应用于文本，使其发光或突出显示：

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

操作结果：

![带发光效果的文本](image-20200930114621-7.png)

{{% alert color="info" title="注意" %}}
您可以更改阴影、反射和发光的参数。效果属性会分别针对文本的每个部分进行设置。
{{% /alert %}}

### **在 WordArt 中使用变换**

使用 [TextFrameFormat.setTransform](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setTransform) 对整个文本块进行变换：

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

结果：

![带拱形变换的文本](image-20200930114712-8.png)

{{% alert color="info" title="注意" %}}
Microsoft PowerPoint 和 Aspose.Slides for Python via Java 都提供一定数量的预定义变换类型。
{{% /alert %}}

**使用 PowerPoint**

要访问预定义的变换类型，请转到：**格式** -> **文字效果** -> **变换**

**使用 Aspose.Slides**

要选择变换类型，请使用 [TextShapeType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textshapetype/) 枚举。

### **将 3D 效果应用于文本和形状**

我们使用以下示例代码将 3D 效果应用于文本形状：

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

生成的文本及其形状：

![带 3D 效果的文本形状](image-20200930114816-9.png)

我们使用以下 Python 代码将 3D 效果应用于文本：

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

操作结果：

![带 3D 效果的文本](image-20200930114905-10.png)

{{% alert color="info" title="注意" %}}
将 3D 效果应用于文本或其形状以及效果之间的交互遵循一定规则。

考虑文本及其所在形状的场景。3D 效果包含 3D 对象表示以及对象所在的场景。

- 当形状和文本都设置了场景时，形状场景优先——文本场景被忽略。
- 当形状没有自己的场景但具有 3D 表示时，使用文本场景。
- 否则——当形状本身没有 3D 效果时，形状为平面，3D 效果仅应用于文本。

这些规则涉及 [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getLightRig) 和 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getCamera) 方法。
{{% /alert %}}

## **将外部阴影效果应用于文本**

Aspose.Slides for Python via Java 提供了 [OuterShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/outershadow/) 和 [InnerShadow](https://reference.aspose.com/slides/zh/python-java/aspose.slides/innershadow/) 类，允许您在 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 中对文本应用阴影效果。请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 使用索引获取幻灯片的引用。
3. 向幻灯片添加矩形形状。
4. 访问与形状关联的文本框。
5. 禁用形状填充。
6. 启用外部阴影效果。
7. 设置阴影的模糊半径。
8. 设置阴影的方向。
9. 设置阴影的距离。
10. 将阴影对齐到左上角。
11. 将阴影颜色设置为黑色。
12. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

下面的 Python（通过 Java）示例代码实现了上述步骤，演示如何将外部阴影效果应用于文本：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # 获取幻灯片的引用
    slide = presentation.getSlides().get_Item(0)

    # 添加矩形类型的 AutoShape
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # 向矩形添加 TextFrame
    auto_shape.addTextFrame("Aspose TextBox")

    # 禁用形状填充，以便获取文本的阴影
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # 添加外部阴影并设置所有必要参数
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # 将演示文稿写入磁盘
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **将内部阴影效果应用于形状**

请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 获取幻灯片的引用。
3. 添加矩形形状。
4. 启用内部阴影效果。
5. 设置所有必要的参数。
6. 将阴影颜色类型设置为使用主题颜色。
7. 设置主题颜色。
8. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

下面的示例代码（基于上述步骤）展示了如何在 Python via Java 中将内部阴影效果应用于形状中的文本：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # 获取幻灯片的引用
    slide = presentation.getSlides().get_Item(0)

    # 添加矩形类型的 AutoShape
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # 向矩形添加 TextFrame
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # 启用内部阴影效果
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # 设置所有必要参数
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # 将 ColorType 设置为 Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # 设置方案颜色
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # 保存演示文稿
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**我可以将 WordArt 效果与不同的字体或文字脚本（例如阿拉伯语、中文）一起使用吗？**

可以，Aspose.Slides 支持 Unicode 并兼容所有主流字体和文字脚本。无论语言如何，都可以应用阴影、填充和轮廓等 WordArt 效果，虽然字体的可用性和渲染可能取决于系统字体。

**我可以将 WordArt 效果应用于幻灯片母版元素吗？**

可以，您可以对母版幻灯片上的形状（包括标题占位符、页脚或背景文本）应用 WordArt 效果。对母版布局的更改会反映到所有相关幻灯片中。

**WordArt 效果会影响演示文稿文件大小吗？**

会略有影响。阴影、发光和渐变填充等 WordArt 效果可能会因增加的格式元数据而稍微增大文件大小，但差异通常可以忽略不计。

**我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？**

可以，您可以使用 [Shape.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage) 或 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage) 将包含 WordArt 的幻灯片渲染为图像（如 PNG、JPEG），从而在内存或屏幕上预览效果，而无需保存或导出完整演示文稿。