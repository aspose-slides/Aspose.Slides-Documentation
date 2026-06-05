---
title: 使用 Node.js 在演示文稿中创建 3D 效果
linktitle: 3D 演示
type: docs
weight: 232
url: /zh/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 演示
- 3D 旋转
- 3D 深度
- 3D 挤压
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Node.js 中使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置摄像机、照明、材质、挤压、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Node.js via Java 可以创建、编辑、保留并渲染 PowerPoint 样式的 3D 格式化，用于形状和文本。本文介绍了诸如旋转、挤压、斜角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="primary" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果，不涉及插入或编辑独立的 3D 模型文件。将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` 将 3D 格式应用于形状。返回的 [ThreeDFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/) 对象控制该形状的 3D 场景。

对于文本，使用 [TextFrameFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`。这会将 3D 格式应用于文本框，而不是形状本体。

最重要的 API 成员如下：

| API 成员 | 控制内容 | 何时使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getCamera) | 视点、预设摄像机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getLightRig) | 光照预设、方向和光线旋转。 | 改变 3D 表面上高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#setMaterial) | 表面材质，如平面、哑光、塑料或金属。 | 使相同几何体看起来更平坦、更柔软、光亮或金属感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | 形状从前表面向后延伸的距离。 | 将平面形状转换为可见的厚 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | 挤压侧面的颜色。 | 使深度可见或将侧面颜色与前填充协调。 |
| [getDepth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 对形状或文本的深度进行微调，尤其是与斜角和材质设置一起使用。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | 前后表面的凸起或圆形边缘。 | 添加柔和或模制的边缘，而不是锐利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D 对象周围的轮廓。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状通常需要四种设置才能看起来逼真地 3D：

- 摄像机设置，因为默认的前视图可能会隐藏挤压。
- 光照设置，因为光照使面和侧面可辨。
- 材质设置，因为表面影响光线的呈现方式。
- 挤压或深度设置，因为平面形状需要厚度。

以下示例创建一个矩形，在其正面添加文本，应用 3D 格式化，将演示文稿保存为 PPTX，并将幻灯片渲染为 PNG 图像。

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

渲染的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面带白色 3D 文本](img_01_01.png)

## **使用摄像机旋转形状**

在 PowerPoint 中，3D 旋转通过“3‑D 旋转”窗格配置。X、Y、Z 旋转值对应通过摄像机 API 设置的旋转。

![PowerPoint 3-D 旋转窗格，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 `shape.getThreeDFormat()` 返回的 3D 格式设置摄像机类型和旋转：

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

当需要改变观众看到对象的方式时使用摄像机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 与 Aspose.Slides 渲染时使用的 3D 视点。

## **添加挤压和深度**

挤压通过在前表面后方延伸来使形状看起来更厚。PowerPoint 中的深度控制决定可见厚度，颜色控制决定侧面的颜色。

![PowerPoint 深度控制映射到挤压颜色和挤压高度属性](img_02_02.png)

设置挤压高度以决定厚度，设置挤压颜色以决定侧面颜色：

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

当需要直接使用 PowerPoint 的深度值，或将深度与斜角、材质和文本效果组合使用时，请使用深度设置。在多数形状场景中，挤压高度更直观，因为它直接表达了可见的挤压程度。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化与形状填充相互独立。可以对正面使用纯色、渐变、图案或图片填充，同时仍使用相同的摄像机、光照、材质和挤压设置。

下面示例对形状应用渐变填充，并对侧面使用更暗的挤压颜色：

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

![渲染的 3D 矩形，蓝至橙渐变填充，橙色挤压](img_02_03.png)

若改用图片填充，先将图像添加到演示文稿，再将其分配给形状填充：

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

![渲染的 3D 矩形，正面采用照片填充，橙色挤压](img_02_04.png)

## **将 3D 格式应用于文本**

形状的 3D 格式影响形体本体，文本的 3D 格式影响文本框。这对于需要对字母本身进行挤压、材质、照明和摄像机设置的 WordArt 类效果非常有用。

下面示例创建带图案填充的文本，应用 WordArt 变换，并在 [TextFrameFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/) 上配置 3D 设置：

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![渲染的 3D 文本，呈拱形 WordArt 变换，橙色图案填充，暗色挤压](img_02_05.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。此行为同样适用于将幻灯片渲染为 [PNG](/slides/zh/nodejs-java/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/)，或生成用于 [video conversion](/slides/zh/nodejs-java/convert-powerpoint-to-video/) 的帧。

- 导出的图像和 PDF 并非交互式。导出后观众无法旋转对象。
- 最终外观取决于摄像机、光照、材质、挤压、填充和幻灯片缩放的组合。
- 如需检查继承或基于主题的格式化值，请读取 [有效形状属性](/slides/zh/nodejs-java/shape-effective-properties/)。
- 某些输出格式无法保存可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是作为可编辑的 3D 设置保留。

## **FAQ**

**Aspose.Slides 能否创建交互式 3D 演示文稿？**

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会将导出的图像、PDF 或 HTML 页面制作成交互式 3D 场景，供观众旋转。在 PPTX 中，3D 格式在 PowerPoint 中仍保持可编辑（前提是该格式支持）。

**3D 模型与 3D 效果有什么区别？**

3D 模型是插入演示文稿的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、挤压、斜角、照明和材质。本文讨论的是 3D 效果。

**可见的 3D 形状需要哪些设置？**

最低要求是设置摄像机旋转并使用挤压或深度。实际使用中，通常还会设置光照和材质，以便渲染出的面拥有明显的高光和阴影。

**我可以将 3D 效果应用于形状和文本吗？**

可以。对形状本体使用 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/).`getThreeDFormat()`，对文本使用 [TextFrameFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`。

**导出为图像、PDF、HTML 或视频帧时，3D 效果会出现吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时会渲染 3D 效果。导出的文件包含渲染后的外观，而不是可编辑的 3D 对象。

**在应用继承和主题设置后，我能读取最终的 3D 值吗？**

可以。使用在 [有效形状属性](/slides/zh/nodejs-java/shape-effective-properties/) 中描述的有效格式化 API 来读取最终的摄像机、光照、斜角及相关 3D 值。