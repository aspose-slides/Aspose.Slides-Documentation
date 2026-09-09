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
- 3D 挤压
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python（通过 Java）中为 PowerPoint 形状和文本应用并渲染 3D 效果。配置摄像机、照明、材质、挤压、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Python via Java 可以创建、编辑、保留并呈现类似 PowerPoint 的形状和文本的 3D 格式。本文介绍了旋转、挤压、倒角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}
本文介绍了 PowerPoint 形状和文本的 3D 格式化效果。它不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

按照[安装](/slides/zh/python-java/installation/)中描述的方式安装包。每个示例都导入 `asposeslides`，如有需要会启动 JVM，然后导入 API。图片填充示例需要工作目录中有 `image.jpg` 文件。

## **3D 格式化概念**

使用[Shape.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getThreeDFormat)为形状应用 3D 格式化。返回的格式对象控制该形状的 3D 场景。

对于文本，使用[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#getThreeDFormat)。这会将 3D 格式化应用于文本框，而不是形状主体。

以下是最重要的 API 成员：

| API 成员 | 它控制的内容 | 何时使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getCamera) | 视点、预设摄像机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getLightRig) | 灯光预设、方向和灯光旋转。 | 更改 3D 表面上高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#setMaterial) | 表面材质，如平面、哑光、塑料或金属。 | 让相同的几何体看起来更平坦、更柔软、更光亮或更金属化。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 形状从正面向后延伸的距离。 | 将平面形状变为可见的厚 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getExtrusionColor) | 挤压侧面的颜色。 | 使深度可见或将侧面颜色与正面填充协调。 |
| [getDepth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式化使用的额外深度。 | 针对形状或文本微调深度，尤其是与倒角和材质设置一起使用时。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getBevelBottom) | 正面和背面上的凸起或圆角边缘。 | 添加柔化或模具化的边缘，而不是锐利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#setContourWidth) | 围绕 3D 对象的轮廓。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状通常需要四种设置才能看起来逼真的 3D：

- 摄像机设置，因为默认的正视图可能会隐藏挤压效果。
- 光照设置，因为光照使面和侧面可辨。
- 材质设置，因为表面影响光的渲染方式。
- 挤压或深度设置，因为平面形状需要厚度。

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

渲染后的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面有白色 3D 文本](img_01_01.png)

## **使用摄像机旋转形状**

In PowerPoint, 3D rotation is configured from the 3-D Rotation pane. The X, Y, and Z rotation values correspond to the rotation you set through the camera API.

在 PowerPoint 中，3D 旋转在“3-D Rotation”面板中配置。X、Y、Z 旋转值对应于通过摄像机 API 设置的旋转。

![PowerPoint 3-D 旋转面板，突出显示 X、Y、Z 旋转值](img_02_01.png)

In Aspose.Slides, set the camera type and rotation through the 3D format returned by [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getThreeDFormat):

在 Aspose.Slides 中，通过 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getThreeDFormat) 返回的 3D 格式来设置摄像机类型和旋转：

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

在需要更改观察者看到对象的方式时使用摄像机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 在渲染时使用的 3D 视点。

## **添加挤压和深度**

挤压通过将形状延伸到正面之后，使其看起来更厚。在 PowerPoint 中，深度控制设置可见的厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到挤压颜色和挤压高度属性](img_02_02.png)

设置挤压高度以确定厚度，设置挤压颜色以确定侧面颜色：

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

在需要直接使用 PowerPoint 的深度值或将深度与倒角、材质和文本效果结合使用时，使用深度设置。在许多形状场景中，挤压高度是更明确的设置，因为它直接表达可见的挤压。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对正面应用纯色、渐变、图案或图片填充，同时仍使用相同的摄像机、光照、材质和挤压设置。

此示例对形状应用渐变填充，对侧面使用更暗的挤压颜色：

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

![渲染的 3D 矩形，蓝到橙渐变填充，橙色挤压](img_02_03.png)

要改用图片填充，请将图像添加到演示文稿并分配给形状填充：

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

![渲染的 3D 矩形，正面使用照片填充，橙色挤压](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形体主体。文本的 3D 格式化影响文本框。这对于类似 WordArt 的效果很有用，需要对字母本身进行挤压、材质、光照和摄像机设置。

下面的示例创建带有图案填充的文本，应用 WordArt 变换，并在 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 上配置 3D 设置：

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

![渲染的 3D 文本，拱形 WordArt 变换，橙色图案填充，深色挤压](img_02_05.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制到输出中，呈现为 2D 结果。这在将幻灯片渲染为 PNG、导出为 PDF、导出为 HTML 或生成用于视频转换的帧时适用。

请注意以下要点：

- 导出的图像和 PDF 不是交互式的。导出后，观看者无法旋转对象。
- 最终外观取决于摄像机、光照、材质、挤压、填充和幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式值，请使用有效格式化 API。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是作为可编辑的 3D 设置保留。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为可交互的 3D 场景，供观看者旋转。在 PPTX 中，只要格式支持，3D 格式化仍可在 PowerPoint 中编辑。

**3D 模型与 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对常规 PowerPoint 形状或文本应用的格式化，如旋转、挤压、倒角、照明和材质。本文讨论的是 3D 效果。

**可见的 3D 形状需要哪些设置？**

至少需要设置摄像机旋转以及挤压或深度。实际使用中，还应设置光照和材质，以便渲染的面具有明确的高光和阴影。

**我可以将 3D 效果同时应用于形状和文本吗？**

可以。对形状主体使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getThreeDFormat)，对文本使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#getThreeDFormat)。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 输出以及用于视频转换的帧时会渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**在继承和主题设置应用后，我可以读取最终的 3D 值吗？**

可以。使用 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getEffective) 读取最终的摄像机、光照、倒角及相关 3D 值。