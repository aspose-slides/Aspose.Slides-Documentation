---
title: 在 Android 上创建演示文稿的 3D 效果
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置摄像机、照明、材质、拉伸、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Android via Java 可以创建、编辑、保留并渲染 PowerPoint 样式的形状和文本的 3D 格式。本文章覆盖的 3D 效果包括旋转、拉伸、斜面、照明、材质、渐变或图片填充以及 3D 文本。

{{% alert color="info" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果。它不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用[IShape.getThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getThreeDFormat--)方法对形状应用 3D 格式化。该方法返回[IThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/)，用于控制该形状的 3D 场景。

对于文本，使用[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--)方法。它将 3D 格式化应用于文本框，而不是形状本体。

最重要的 API 成员如下：

| API 成员 | 它控制的内容 | 何时使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 视点、预设摄像机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 光照预设、方向和光线旋转。 | 更改 3D 表面上高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材质，如平面、哑光、塑料或金属。 | 使相同的几何形状看起来更平坦、柔和、有光泽或金属感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形状从正面向后延伸的距离。 | 将平面形状变为肉眼可见的厚 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 拉伸侧面的颜色。 | 使深度可见或使侧面颜色与正面填充协调。 |
| [getDepth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 细调形状或文本的深度，尤其是与斜面和材质设置一起使用时。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面和背面上的凸起或圆角边缘。 | 添加柔化或成型的边缘，而不是锐利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), 和 [setContourWidth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状通常需要四类设置才能看起来逼真的 3D：

- 摄像机设置，因为默认的正视图可能会隐藏拉伸效果。
- 光照设置，因为光照使各面和侧面可读。
- 材质设置，因为表面会影响光线的渲染。
- 拉伸或深度设置，因为平面形状需要厚度。

以下示例创建一个矩形，在其正面添加文本，应用 3D 格式化，将演示文稿保存为 PPTX，并将幻灯片渲染为 PNG 图像。

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
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

渲染后的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面有白色 3D 文本](img_01_01.png)

## **使用摄像机旋转形状**

在 PowerPoint 中，3D 旋转通过“3-D 旋转”窗格进行配置。X、Y、Z 旋转值对应于通过摄像机 API 设置的旋转。

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

在 Aspose.Slides 中，通过[IThreeDFormat.getCamera](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getCamera--)设置摄像机类型和旋转：

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

当需要改变观察者看到对象的方式时使用摄像机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加拉伸和深度**

拉伸通过将形状向正面后方延伸，使其看起来更厚。PowerPoint 中的深度控制设置可见的厚度，颜色控制设置侧面的颜色。

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

使用[IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-)设置厚度，用[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--)设置侧面颜色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

当需要直接使用 PowerPoint 的深度值或将深度与斜面、材质、文本效果组合时，请使用[IThreeDFormat.setDepth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-)。在多数形状场景下，`setExtrusionHeight` 更直观，因为它直接表示可见的拉伸。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对正面使用纯色、渐变、图案或图片填充，同时仍使用相同的摄像机、光照、材质和拉伸设置。

以下示例对形状应用渐变填充，并为侧面使用更暗的拉伸颜色：

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

渲染输出保持正面的渐变，同时单独渲染拉伸：

![渲染的 3D 矩形，正面使用蓝到橙的渐变填充，侧面为橙色拉伸](img_02_03.png)

如果改用图片填充，先将图像添加到演示文稿，再将其分配给形状填充：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

图片渲染在正面，而拉伸渲染为 3D 侧面表面：

![渲染的 3D 矩形，正面使用照片填充，侧面为橙色拉伸](img_02_04.png)

## **将 3D 格式化应用于文本**

形状的 3D 格式化影响形状本体。文本的 3D 格式化影响文本框。这对于需要对字母本身进行拉伸、材质、光照和摄像机设置的 WordArt 类效果非常有用。

以下示例创建带有图案填充的文本，应用 WordArt 变换，并在[ITextFrameFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/)上配置 3D 设置：

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

文本被渲染为弧形、拉伸的 3D 字体：

![渲染的 3D 文本，带有拱形 WordArt 变换、橙色图案填充和深色拉伸](img_02_05.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。此行为在将幻灯片渲染为[PNG](/slides/zh/androidjava/convert-powerpoint-to-png/)、导出为[PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)、导出为[HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)、或生成用于[video conversion](/slides/zh/androidjava/convert-powerpoint-to-video/)的帧时均适用。

请牢记以下要点：

- 导出的图像和 PDF 不是交互式的。导出后，查看者无法旋转对象。
- 最终外观取决于摄像机、光照装置、材质、拉伸、填充和幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式值，请读取[有效形状属性](/slides/zh/androidjava/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式。在这些格式中，视觉结果是渲染后的，而不是保留为可编辑的 3D 设置。

## **FAQ**

### Aspose.Slides 能创建交互式 3D 演示文稿吗？

Aspose.Slides 创建并渲染形状和文本的 PowerPoint 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为可由查看者旋转的交互式 3D 场景。在 PPTX 中，支持的情况下，3D 格式化仍可在 PowerPoint 中编辑。

### 3D 模型与 3D 效果有什么区别？

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，例如旋转、拉伸、斜面、照明和材质。本文讨论的正是 3D 效果。

### 可见的 3D 形状需要哪些设置？

至少需要设置摄像机旋转以及拉伸或深度。实际使用中，通常还会设置光照装置和材质，以便渲染出的面具有清晰的高光和阴影。

### 我可以将 3D 效果应用于形状和文本吗？

可以。对形状本体使用[IShape.getThreeDFormat]，对文本使用[ITextFrameFormat.getThreeDFormat]。

### 导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 以及用于视频转换的帧时渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

### 在应用继承和主题设置后，我可以读取最终的 3D 值吗？

可以。使用[有效形状属性](/slides/zh/androidjava/shape-effective-properties/)中描述的有效格式化 API，读取最终的摄像机、光照装置、斜面等 3D 值。