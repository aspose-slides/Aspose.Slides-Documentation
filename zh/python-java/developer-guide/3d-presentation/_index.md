---
title: 使用 Python 在演示文稿中创建 3D 效果
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 挤出
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、照明、材质、挤出、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Python via Java 可以创建、编辑、保留并渲染 PowerPoint 样式的形状和文本的 3D 格式化。本篇文章介绍旋转、挤出、斜角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="注意" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果，而不是插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

按照 [安装](/slides/zh/python-java/installation/) 中的说明安装包。每个示例都会导入 `asposeslides`，必要时启动 JVM，然后导入 API。图片填充示例需要工作目录中存在 `image.jpg` 文件。

## **3D 格式化概念**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getThreeDFormat) 为形状应用 3D 格式化。返回的格式对象控制该形状的 3D 场景。

对于文本，使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#getThreeDFormat)。这会将 3D 格式化应用于文本框而不是形状主体。

最重要的 API 成员如下：

| API 成员 | 控制内容 | 何时使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getCamera) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getLightRig) | 光源预设、方向和光线旋转。 | 改变 3D 表面上高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#setMaterial) | 表面材质，例如平面、哑光、塑料或金属。 | 使相同的几何形状看起来更平坦、更柔软、光亮或金属化。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 形状从正面向后延伸的距离。 | 将平面形状转换为可见的厚体 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getExtrusionColor) | 挤出侧面的颜色。 | 使深度可见或使侧面颜色与正面填充相匹配。 |
| [getDepth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 细调形状或文本的深度，尤其是与斜角和材质设置一起使用时。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getBevelBottom) | 正面和背面上的凸起或圆角边缘。 | 添加柔和或成形的边缘，而不是尖锐的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getContourWidth), 和 [setContourWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#setContourWidth) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

在形状看起来具有说服力的 3D 之前，通常需要四类设置：

- 相机设置，因为默认的正视图可能隐藏挤出效果。
- 光源设置，因为光照使各面和侧面可读。
- 材质设置，因为表面影响光线的呈现方式。
- 挤出或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其正面添加文本，应用 3D 格式化，将演示文稿保存为 PPTX，并将幻灯片渲染为 PNG 图像。

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

渲染的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面带白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过“3‑D 旋转”窗格配置。X、Y、Z 旋转值对应通过相机 API 设置的旋转。

![PowerPoint 3‑D 旋转窗格，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getThreeDFormat) 返回的 3D 格式对象设置相机类型和旋转：

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

当需要改变观察者看到对象的方式时使用相机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加挤出和深度**

挤出通过在正面后方延伸形状来实现厚度。PowerPoint 中的深度控制决定可见厚度，颜色控制决定侧面的颜色。

![PowerPoint 深度控制映射到挤出颜色和挤出高度属性](img_02_02.png)

设置挤出高度以控制厚度，设置挤出颜色以控制侧面颜色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

当需要直接使用 PowerPoint 的深度值，或将深度与斜角、材质和文本效果结合时使用深度设置。在多数形状情景下，挤出高度是更直观的设置，因为它直接表示可见的挤出量。

## **使用渐变或图片填充与 3D 效果**

3D 格式化独立于形状填充。您可以对正面使用纯色、渐变、图案或图片填充，同时保持相同的相机、光源、材质和挤出设置。

下面的示例对形状使用渐变填充，并对侧面使用更深的挤出颜色：

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

渲染结果保留正面的渐变，并单独渲染挤出侧面：

![渲染的 3D 矩形，蓝到橙的渐变填充，橙色挤出侧面](img_02_03.png)

如果改用图片填充，先将图像加入演示文稿并将其分配给形状填充：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

图片在正面渲染，挤出作为 3D 侧面渲染：

![渲染的 3D 矩形，正面为照片填充，橙色挤出侧面](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状本体，文本的 3D 格式化影响文本框。这对于需要对字母本身进行挤出、材质、照明和相机设置的 WordArt 类效果非常有用。

下面的示例创建带图案填充的文本，应用 WordArt 变换，并在 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 上配置 3D 设置：

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

文本渲染为弧形、挤出的 3D 字体：

![渲染的 3D 文本，拱形 WordArt 变换，橙色图案填充，深色挤出](img_02_05.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会被光栅化或绘制为 2D 结果。这在将幻灯片渲染为 PNG、导出为 PDF、导出为 HTML 或生成视频转换帧时均适用。

请注意以下要点：

- 导出的图像和 PDF 并非交互式。导出后对象无法被观看者旋转。
- 最终外观取决于相机、光源、材质、挤出、填充和幻灯片缩放的组合。
- 若需检查继承或主题基础的格式化值，请使用有效格式化 API。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果是渲染后的图像，而不是可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观看者可旋转的交互式 3D 场景。在 PPTX 中，只要格式支持，3D 格式化仍可在 PowerPoint 中编辑。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，例如旋转、挤出、斜角、照明和材质。本文只讨论 3D 效果。

**可见的 3D 形状需要哪些设置？**

至少需要设置相机旋转并指定挤出或深度。实际使用中，还应设置光源和材质，以便渲染出的面拥有清晰的高光和阴影。

**我可以同时对形状和文本应用 3D 效果吗？**

可以。对形状本体使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getThreeDFormat)，对文本使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#getThreeDFormat)。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 以及用于视频转换的帧时渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**我能读取继承和主题设置后最终的 3D 值吗？**

可以。使用 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getEffective) 读取最终的相机、光源、斜角和相关的 3D 值。