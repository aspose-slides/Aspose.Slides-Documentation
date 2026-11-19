---
title: 在演示文稿中使用 Python 创建 3D 效果
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
description: "使用 Aspose.Slides 在 Python via Java 中为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、照明、材质、挤压、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Python via Java 可以创建、编辑、保留并渲染类似 PowerPoint 的形状和文本的 3D 格式化。本篇文章涵盖了旋转、挤压、倒角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}
本文介绍的是 PowerPoint 形状和文本的 3D 格式化效果。它并不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) 方法对形状应用 3D 格式化。该方法返回 [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)，用于控制该形状的 3D 场景。

对于文本，使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) 方法。这会将 3D 格式化应用于文本框，而不是形状主体。

最重要的 API 成员如下：

| API 成员 | 它控制什么 | 何时使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | 灯光预设、方向和灯光旋转。 | 更改 3D 表面上高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | 表面材质，如平面、哑光、塑料或金属。 | 使相同的几何体看起来更平坦、更柔软、光亮或金属化。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | 形状从正面向后延伸的距离。 | 将平面形状变为可见的厚 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | 挤压侧面的颜色。 | 使深度可见或使侧面颜色与正面填充相匹配。 |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 微调形状或文本的深度，尤其是结合倒角和材质设置一起使用时。 |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | 正面和背面的凸起或圆角边缘。 | 添加柔和或模塑的边缘，而不是尖锐的平面。 |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状在看起来逼真的 3D 之前，通常需要四类设置：

- 相机设置，因为默认的正视图可能隐藏挤压效果。
- 光照设置，因为光照使各面和侧面可辨识。
- 材质设置，因为表面会影响光线的渲染方式。
- 挤压或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其正面添加文本，并应用 3D 格式化。相机旋转值以度为单位，挤压高度为 100 点。示例将幻灯片渲染为尺寸为默认两倍的 PNG 图像，并将演示文稿保存为 PPTX。

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
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

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

![渲染的蓝色 3D 矩形，正面带白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过 “3-D 旋转” 面板进行配置。X、Y 和 Z 旋转值对应于通过相机 API 设置的旋转。

![PowerPoint 3-D 旋转面板，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) 访问相机。此示例创建一个矩形，选择正交前视图，并将其 X、Y、Z 旋转分别设置为 20、30、40 度。它在内存中配置形状，而不保存文件：

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

当需要改变观看者看到对象的方式时使用相机。它不会改变幻灯片上 2D 形状的几何形状，而是更改 PowerPoint 与 Aspose.Slides 渲染时使用的 3D 视点。

### **从模板形状复制相机方向**

为匹配模板形状的方向，使用 [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) 读取其相机预设，使用 [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation) 获取其旋转角度。示例打开 `template.pptx`，并将第一张幻灯片上第一个形状的相机方向复制到第二个形状。两个形状均已具备 3D 灯光，第二个形状没有显式的相机旋转。

角度以度为单位。索引 `0` 为纬度，索引 `1` 为经度，索引 `2` 为旋转。按照此顺序将它们传递给 [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation)。如果源返回 `None`，表示没有显式旋转，则保持第二个形状的角度未设置。显式旋转 `(0, 0, 0)` 会返回三个零，应当复制。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

当您在 PowerPoint 中重新打开 `camera-copy.pptx` 时，右侧的箭头具有与左侧矩形相同的相机预设和旋转。两个形状使用相同的灯光和挤压深度。

![一个蓝色 3D 矩形和一个方向相同的右箭头，从上方和右侧观看](camera-orientation.png)

## **添加挤压和深度**

挤压通过将形状延伸到正面后方，使其看起来更厚。在 PowerPoint 中，深度控制设置可见厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到挤压颜色和挤压高度属性](img_02_02.png)

使用 [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) 设置厚度，使用 [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) 获取侧面颜色。此示例为矩形设置 100 点的挤压，侧面为紫色，并旋转相机以显示其厚度。它在内存中配置形状，而不保存文件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) 方法设置 3D 形状的深度。[setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) 方法控制挤压效果的高度，如本示例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化与形状填充相互独立。您可以对正面应用纯色、渐变、图案或图片填充，同时仍使用相同的相机、灯光、材质和挤压设置。

此示例对正面应用蓝到橙的渐变，对 150 点的挤压使用深橙色。渐变在位置 0 和 100 处分别标记渐变的起始和结束。相机旋转值以度为单位。幻灯片渲染为尺寸为默认两倍的 PNG 图像：

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

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

渲染输出保留正面的渐变，并单独渲染挤压：

![渲染的 3D 矩形，蓝到橙的渐变填充和橙色挤压](img_02_03.png)

如果改用图片填充，将图像添加到演示文稿并分配给形状填充。本示例需要工作目录中存在名为 "image.jpg" 的文件。它将图片拉伸以填满矩形，应用 150 点的挤压，并以度为单位设置相机旋转。它在内存中配置形状，而不保存或渲染文件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

图片渲染在正面，而挤压渲染为 3D 侧表面：

![渲染的 3D 矩形，正面填充照片，橙色挤压](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状主体。文本的 3D 格式化影响文本框。这对于类似 WordArt 的效果很有用，需要对字母本身进行挤压、材质、灯光和相机设置。

以下示例创建带有橙白网格图案的文本，应用向上拱形，并通过 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) 配置 3D 设置。挤压高度和深度以点为单位，灯光旋转以度为单位。形状填充和轮廓被隐藏，仅显示文本。示例将幻灯片渲染为尺寸为默认两倍的 PNG 图像，并将演示文稿保存为 PPTX：

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

文本渲染为弯曲的、挤压的 3D 字母：

![渲染的 3D 文本，拱形 WordArt 变换，橙色图案填充，深色挤压](img_02_05.png)

## **在 3D 形状上保持文本平面**

为了在保持形状 3D 外观的同时保持文本可读，调用 [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat)（通过 [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat)）。当该值为 `True` 时，文本保持在 3D 场景之外；当为 `False` 时，文本参与场景并遵循其 3D 方向。

此设置不会移除形状的 3D 格式化：其相机、灯光、材质和挤压仍通过 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) 配置。它也不同于普通旋转。[Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) 在幻灯片平面上旋转形状，而 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) 控制文本在其边界框内的自定义旋转。保持文本不在 3D 场景中不会重置这些角度中的任何一个。

以下独立示例创建一个带文本的蓝色矩形，并在原始旁边克隆它。两个形状具有相同的 3D 格式化；唯一的差异是文本设置：左侧为 `False`，右侧为 `True`。相机角度以度为单位，挤压高度为 40 点。示例将演示文稿保存为 PPTX，并将比较幻灯片渲染为尺寸为默认两倍的 PNG：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

左侧的文本遵循 3D 方向。右侧的文本保持平面，更易阅读。两个矩形保留相同的可见挤压和 3D 方向。

![并排的 3D 矩形：左侧文本遵循 3D 方向，右侧文本保持平面](keep_text_flat.png)

## **导出和渲染行为**

在保存为 PPTX 等 PowerPoint 格式时，Aspose.Slides 会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会被光栅化或绘制为 2D 输出。当您将幻灯片渲染为 [PNG](/slides/zh/python-java/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/python-java/convert-powerpoint-to-html/)，或生成用于 [video conversion](/slides/zh/python-java/convert-powerpoint-to-video/) 的帧时，均适用此行为。

请注意以下要点：

- 导出的图像和 PDF 不是交互式的。导出后对象不能被观看者旋转。
- 最终外观取决于相机、灯光装置、材质、挤压、填充和幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式化值，请阅读 [有效形状属性](/slides/zh/python-java/shape-effective-properties/)。
- 某些输出格式不能存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果是渲染后的，而不是作为可编辑的 3D 设置保留。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观看者可以旋转的交互式 3D 场景。在 PPTX 中，只要格式支持，3D 格式化仍可在 PowerPoint 中进行编辑。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、挤压、倒角、照明和材质。本文讨论的正是 3D 效果。

**可见的 3D 形状需要哪些设置？**

至少需要设置相机旋转以及挤压或深度。实际使用中，还应设置灯光装置和材质，以便渲染出的面具有清晰的高光和阴影。

**我可以对形状和文本都应用 3D 效果吗？**

可以。对形状主体使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat)，对文本使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat)。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 输出以及用于视频转换的帧时会渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**在继承和主题设置应用后，我能读取最终的 3D 值吗？**

可以。使用在 [形状有效属性](/slides/zh/python-java/shape-effective-properties/) 中描述的有效格式化 API，读取最终的相机、灯光装置、倒角等 3D 值。