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
- 3D 挤压
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置摄像机、照明、材质、挤压、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Java 可以创建、编辑、保留并呈现 PowerPoint 样式的形状和文本的 3D 格式化。本文介绍了旋转、挤压、斜角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" %}}
本文讲述的是 PowerPoint 形状和文本的 3D 格式化效果。它不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/).`getThreeDFormat()` 可对形状应用 3D 格式化。返回的格式对象控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`。这会将 3D 格式化应用于文本框，而不是形状主体。

最重要的 API 成员如下：

| API 成员 | 控制内容 | 使用时机 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getCamera--) | 视点、预设摄像机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getLightRig--) | 灯光预设、方向和灯光旋转。 | 更改 3D 表面上的高光和阴影效果。 |
| [getMaterial](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材质，如平面、哑光、塑料或金属。 | 使相同几何体看起来更平坦、柔软、光亮或金属感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形状从正面向后延伸的距离。 | 将平面形状变为可见的厚度 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 挤压侧面的颜色。 | 使深度可见或将侧面颜色与正面填充协调。 |
| [getDepth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 微调形状或文本的深度，尤其与斜角和材质设置一起使用。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面和背面上的凸起或圆角边缘。 | 在锐利的平面上添加柔化或模铸的边缘。 |
| [getContourColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getContourWidth--), 和 [setContourWidth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 对象的轮廓颜色。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状在看起来逼真 3D 之前通常需要四类设置：

- 摄像机设置，因为默认的前视图可能隐藏挤压效果。
- 灯光设置，因为光照使面和侧面可辨。
- 材质设置，因为表面会影响光的渲染。
- 挤压或深度设置，因为平面形状需要厚度。

以下示例创建一个矩形，在正面添加文本，应用 3D 格式化，将演示文稿保存为 PPTX，并将幻灯片渲染为 PNG 图像。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

渲染的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面有白色 3D 文本](img_01_01.png)

## **使用摄像机旋转形状**

在 PowerPoint 中，3D 旋转通过 “3‑D 旋转” 面板配置。X、Y、Z 旋转值对应通过摄像机 API 设置的旋转。

![PowerPoint 3‑D 旋转面板，突出显示 X、Y 和 Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 `shape.getThreeDFormat()` 返回的 3D 格式设置摄像机类型和旋转：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

当需要更改观看者看到对象的方式时使用摄像机。它不会改变幻灯片上 2D 形状的几何形状，而是改变 PowerPoint 与 Aspose.Slides 渲染时使用的 3D 视点。

## **添加挤压和深度**

挤压通过在正面后方延伸形状来使其看起来厚实。PowerPoint 中的深度控制设置可见厚度，颜色控制设置侧面颜色。

![PowerPoint 深度控制映射到挤压颜色和挤压高度属性](img_02_02.png)

为厚度设置挤压高度，为侧面设置挤压颜色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

当需要直接使用 PowerPoint 的深度值或将深度与斜角、材质、文本效果结合时使用深度设置。在许多形状场景下，挤压高度更直观，因为它直接表达可见的挤压。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对正面使用纯色、渐变、图案或图片填充，同时保持相同的摄像机、灯光、材质和挤压设置。

以下示例对形状应用渐变填充，并对侧面使用更深的挤压颜色：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

渲染的输出在正面保留渐变，在侧面单独渲染挤压：

![渲染的 3D 矩形，正面有蓝到橙的渐变填充，侧面为橙色挤压](img_02_03.png)

若改用图片填充，先将图片添加到演示文稿并将其分配给形状填充：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

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
} finally {
    presentation.dispose();
}
```

图片在正面渲染，挤压作为 3D 侧面表面渲染：

![渲染的 3D 矩形，正面有照片填充，侧面为橙色挤压](img_02_04.png)

## **将 3D 格式化应用于文本**

形状的 3D 格式化影响形状主体，文本的 3D 格式化影响文本框。这对于需要对字母本身进行挤压、材质、照明和摄像机设置的 WordArt 类效果非常有用。

以下示例创建带图案填充的文本，应用 WordArt 变换，并在 [ITextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` 上配置 3D 设置：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

文本渲染为弧形、挤压的 3D 字母：

![渲染的 3D 文本，带有拱形 WordArt 变换、橙色图案填充和深色挤压](img_02_05.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。此行为适用于将幻灯片渲染为 [PNG](/slides/zh/java/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/java/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/java/convert-powerpoint-to-html/)，或为 [video conversion](/slides/zh/java/convert-powerpoint-to-video/) 生成帧。

请记住以下要点：

- 导出的图像和 PDF 不是交互式的。导出后观看者无法旋转对象。
- 最终外观取决于摄像机、灯光、材质、挤压、填充和幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式值，请阅读[有效形状属性](/slides/zh/java/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果是渲染后的，而不是作为可编辑的 3D 设置保留。

## **常见问题**

### Aspose.Slides 能创建交互式 3D 演示文稿吗？

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为可交互的 3D 场景，供观看者旋转。在 PPTX 中，3D 格式化在 PowerPoint 中仍保持可编辑（前提是格式本身支持）。

### 3D 模型和 3D 效果有什么区别？

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、挤压、斜角、照明和材质。本文只讨论 3D 效果。

### 可见的 3D 形状需要哪些设置？

至少需要设置摄像机旋转并使用挤压或深度。实践中，还应设置灯光和材质，以便渲染出的面拥有清晰的高光和阴影。

### 我可以将 3D 效果同时应用于形状和文本吗？

可以。对形状主体使用 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/).`getThreeDFormat()`，对文本使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`。

### 导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 输出以及用于视频转换的帧时渲染 3D 效果。导出的内容包含渲染后的外观，而不是可编辑的 3D 对象。

### 在应用继承和主题设置后，我能读取最终的 3D 值吗？

可以。使用[有效形状属性](/slides/zh/java/shape-effective-properties/) 中描述的有效格式化 API 读取最终的摄像机、灯光、斜角和相关 3D 值。