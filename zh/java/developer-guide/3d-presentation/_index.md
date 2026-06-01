---
title: 使用 Java 在演示文稿中创建 3D 效果
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 拉伸
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中为 PowerPoint 形状和文本应用并渲染 3D 效果。可配置相机、光照、材质、拉伸、填充以及 3D 文本。"
---
## **概述**

Aspose.Slides for Java 可以创建、编辑、保留和呈现针对形状和文本的 PowerPoint 样式 3D 格式化。本文介绍了诸如旋转、拉伸、倒角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="primary" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果。它并不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/).`getThreeDFormat()` 对形状应用 3D 格式化。返回的格式对象控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`。这会将 3D 格式化应用于文本框，而不是形状本体。

最重要的 API 成员如下：

| API 成员 | 控制内容 | 使用时机 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getCamera--) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getLightRig--) | 灯光预设、方向和灯光旋转。 | 改变 3D 表面上高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材质，例如平面、哑光、塑料或金属。 | 使相同几何体看起来更平坦、柔软、光亮或金属感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形状从正面向后延伸的距离。 | 将平面形状变成可见的厚 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 拉伸侧面的颜色。 | 使深度可见或将侧面颜色与正面填充协调。 |
| [getDepth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 微调形状或文本的深度，尤其是与倒角和材质设置一起使用时。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面和背面上的凸起或圆形边缘。 | 添加柔和或模塑的边缘，而不是锐利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getContourWidth--), 和 [setContourWidth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 对象的轮廓。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

- 相机设置，因为默认的正视图可能会隐藏拉伸效果。
- 灯光设置，因为光照使得各面和侧面可辨识。
- 材质设置，因为表面影响光的渲染方式。
- 拉伸或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其正面添加文本，应用 3D 格式化，将演示文稿保存为 PPTX，并将幻灯片渲染为 PNG 图像。

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

渲染后的幻灯片图像显示该矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面有白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转是在“3-D Rotation”窗格中配置的。X、Y、Z 旋转值对应于通过相机 API 设置的旋转。

![PowerPoint 3-D Rotation 窗格，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 `shape.getThreeDFormat()` 返回的 3D 格式设置相机类型和旋转：

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

当需要更改观看者看到对象的方式时使用相机。它不会改变幻灯片上 2D 形状的几何形状，而是改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加拉伸和深度**

拉伸通过将形状延伸到正面后方，使其看起来更厚。 在 PowerPoint 中，深度控制设置此可见厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到拉伸颜色和拉伸高度属性](img_02_02.png)

设置拉伸高度以确定厚度，设置拉伸颜色以确定侧面颜色：

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

当需要直接使用 PowerPoint 的深度值或将深度与倒角、材质和文本效果结合时使用深度设置。在许多形状场景中，拉伸高度是更直观的设置，因为它直接表示可见的拉伸。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对正面应用纯色、渐变、图案或图片填充，同时仍然使用相同的相机、灯光、材质和拉伸设置。

此示例对形状应用渐变填充，并对侧面使用更深的拉伸颜色：

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

![渲染的 3D 矩形，蓝到橙渐变填充和橙色拉伸](img_02_03.png)

如果要使用图片填充，请将图像添加到演示文稿并分配给形状填充：

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

![渲染的 3D 矩形，正面为照片填充，橙色拉伸](img_02_04.png)

## **将 3D 格式化应用于文本**

形状的 3D 格式化影响形状本体。文本的 3D 格式化影响文本框。这对于类似 WordArt 的效果很有用，因为字母本身需要拉伸、材质、照明和相机设置。

以下示例创建带图案填充的文本，应用 WordArt 变换，并在 [ITextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` 上配置 3D 设置：

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![渲染的 3D 文本，带拱形 WordArt 变换，橙色图案填充和深色拉伸](img_02_05.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。当您将幻灯片渲染为 [PNG](/slides/zh/java/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/java/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/java/convert-powerpoint-to-html/)，或生成用于 [video conversion](/slides/zh/java/convert-powerpoint-to-video/) 的帧时，均适用此行为。

请记住以下要点：

- 导出的图像和 PDF 并非交互式。导出后，观看者无法旋转对象。
- 最终外观取决于相机、灯光、材质、拉伸、填充和幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式化值，请阅读 [effective shape properties](/slides/zh/java/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉效果会被渲染，而不是保留为可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 为形状和文本创建并渲染 PowerPoint 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观看者可以旋转的交互式 3D 场景。在 PPTX 中，3D 格式化在支持该格式的 PowerPoint 中仍保持可编辑。

**3D 模型与 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、拉伸、倒角、照明和材质。本文讨论的是 3D 效果。

**可见的 3D 形状需要哪些设置？**

至少需要设置相机旋转以及拉伸或深度之一。实际使用时，还应设置灯光和材质，以便渲染的面具有清晰的高光和阴影。

**我可以将 3D 效果同时应用于形状和文本吗？**

可以。对形状本体使用 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/).`getThreeDFormat()`，对文本使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`。

**导出为图像、PDF、HTML 或视频帧时，3D 效果会出现吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时渲染 3D 效果。导出的输出包含渲染后的外观，而非可编辑的 3D 对象。

**在应用继承和主题设置后，我可以读取最终的 3D 值吗？**

可以。使用在 [Shape Effective Properties](/slides/zh/java/shape-effective-properties/) 中描述的有效格式化 API 读取最终的相机、灯光、倒角和相关 3D 值。