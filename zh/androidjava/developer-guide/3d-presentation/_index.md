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
description: "在 Android 上使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置摄像机、光照、材质、拉伸、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Android via Java 可以创建、编辑、保存和渲染适用于形状和文本的 PowerPoint 风格 3D 格式化。本文章涵盖旋转、拉伸、斜角、光照、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果，不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用[IShape.getThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 方法对形状应用 3D 格式化。该方法返回[IThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/)，用于控制该形状的 3D 场景。

对于文本，使用[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 方法。这会对文本框而不是形状主体应用 3D 格式化。

最重要的 API 成员如下：

| API member | 它控制的内容 | 何时使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 视点、预设摄像机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 灯光预设、方向和灯光旋转。 | 改变 3D 表面上高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材质，如平面、哑光、塑料或金属。 | 使相同几何形状看起来更平坦、更柔软、光亮或金属感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形状从正面向后延伸的距离。 | 将平面形状变为可见的厚实 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 拉伸侧面的颜色。 | 使深度可见或将侧面颜色与正面填充协同。 |
| [getDepth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 微调形状或文本的深度，尤其是与斜角和材质设置一起使用时。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面和背面的凸起或圆角边缘。 | 添加柔软或成型的边缘，而不是锋利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getContourColor--)、[getContourWidth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) 和 [setContourWidth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 对象的轮廓线。 | 在渲染输出中强调对象的边界。 |

## **创建 3D 形状**

通常要让形状看起来具有说服力的 3D 效果，需要四类设置：

- 摄像机设置，因为默认的正视图可能隐藏拉伸效果。
- 光照设置，因为光照使面和侧面可辨识。
- 材质设置，因为表面会影响光的渲染方式。
- 拉伸或深度设置，因为平面形状需要厚度。

以下示例创建一个矩形，在其正面添加文本，并应用 3D 格式化。摄像机旋转值以度为单位，拉伸高度为 100 点。示例将幻灯片渲染为尺寸为默认两倍的 PNG 图像，并将演示文稿保存为 PPTX。

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

## **使用摄像机旋转形状**

在 PowerPoint 中，3D 旋转在“3-D 旋转”窗格中配置。X、Y、Z 旋转值对应通过摄像机 API 设置的旋转。

![PowerPoint 3-D 旋转窗格，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过[IThreeDFormat.getCamera](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getCamera--) 访问摄像机。此示例创建一个矩形，选择正交前视图，并将其 X、Y、Z 旋转分别设置为 20、30、40 度。它在内存中配置形状而不保存文件：

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

当需要更改观众看到对象的方式时使用摄像机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 在渲染时使用的 3D 视点。

## **添加拉伸和深度**

拉伸通过将形状延伸到正面后方，使其看起来更厚实。在 PowerPoint 中，深度控制设置可见的厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到拉伸颜色和拉伸高度属性](img_02_02.png)

使用[IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 设置厚度，使用[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) 获取侧面颜色。此示例为矩形设置 100 点的拉伸，侧面为紫色，并旋转摄像机以展示其厚度。它在内存中配置形状而不保存文件：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) 方法设置 3D 形状的深度。[setExtrusionHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 方法控制拉伸效果的高度，如本示例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对正面应用纯色、渐变、图案或图片填充，同时仍使用相同的摄像机、光照、材质和拉伸设置。

此示例对正面应用蓝到橙的渐变，对 150 点的拉伸使用深橙色。渐变在 0% 和 100% 处标记渐变的起始和结束。摄像机旋转值以度为单位。幻灯片渲染为尺寸为默认两倍的 PNG 图像：

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
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

![渲染的 3D 矩形，蓝到橙渐变填充，橙色拉伸](img_02_03.png)

若改为使用图片填充，需将图片添加到演示文稿并分配给形状填充。此示例要求工作目录中已有名为 "image.jpg" 的文件。它将图片拉伸以填满矩形，应用 150 点的拉伸，并以度为单位设置摄像机旋转。它在内存中配置形状而不保存或渲染文件：

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![渲染的 3D 矩形，正面照片填充，橙色拉伸](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状主体。文本的 3D 格式化影响文本框。这对于类似 WordArt 的效果很有用，需要对字母本身进行拉伸、材质、光照和摄像机设置。

以下示例创建具有橙白格纹的文本，应用向上的拱形，并通过[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 配置 3D 设置。拉伸高度和深度以点为单位，光照旋转以度为单位。形状填充和轮廓被隐藏，仅显示文本。示例将 PNG 图像渲染为默认幻灯片尺寸的两倍，并将演示文稿保存为 PPTX：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

![渲染的 3D 文本，拱形 WordArt 变换，橙色图案填充，深色拉伸](img_02_05.png)

## **在 3D 形状上保持文本平面**

为了在保持形状 3D 外观的同时让文本易于阅读，可通过[ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) 调用[ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-)。当值为 `true` 时，文本保持在 3D 场景之外；为 `false` 时，文本参与场景并遵循其 3D 方向。

此设置不会移除形状的 3D 格式化：其摄像机、光照、材质和拉伸仍通过[IShape.getThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 配置。它也不同于普通旋转。[IShape.setRotation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#setRotation-float-) 在幻灯片平面上旋转形状，而[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 控制文本在其边界框内的自定义旋转。将文本保持在 3D 场景之外不会重置这两个角度。

以下独立示例创建一个带文本的蓝色矩形，并在原始矩形旁克隆它。两个矩形具有相同的 3D 格式化；仅文本设置不同：左侧为 `false`，右侧为 `true`。摄像机角度以度为单位，拉伸高度为 40 点。示例将演示文稿保存为 PPTX，并将比较幻灯片渲染为默认尺寸两倍的 PNG。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

左侧的文本遵循 3D 方向。右侧的文本保持平面，更易阅读。两个矩形保留相同的可见拉伸和 3D 方向。

![并排的 3D 矩形：左侧文本遵循 3D 方向，右侧文本保持平面](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。此情况适用于将幻灯片渲染为[PNG](/slides/zh/androidjava/convert-powerpoint-to-png/)、导出为[PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)、导出为[HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)、或生成用于[视频转换](/slides/zh/androidjava/convert-powerpoint-to-video/)的帧。

- 导出的图像和 PDF 不是交互式的，导出后观看者无法旋转对象。  
- 最终外观取决于摄像机、光照、材质、拉伸、填充和幻灯片缩放的组合。  
- 如需检查继承或基于主题的格式化值，请阅读[有效形状属性](/slides/zh/androidjava/shape-effective-properties/)。  
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是保留为可编辑的 3D 设置。

## **常见问答**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染 PowerPoint 对形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观众可以旋转的交互式 3D 场景。在 PPTX 中，支持的格式下 3D 格式化仍保持可编辑。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、拉伸、斜角、光照和材质。本文讨论的是 3D 效果。

**可见的 3D 形状需要哪些设置？**

至少需要设置摄像机旋转以及拉伸或深度。实际使用中，还应设置光照和材质，以便渲染的面具有清晰的高光和阴影。

**我可以同时对形状和文本应用 3D 效果吗？**

可以。对形状主体使用[IShape.getThreeDFormat]，对文本使用[ITextFrameFormat.getThreeDFormat]。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**我能在继承和主题设置应用后读取最终的 3D 值吗？**

可以。使用[形状有效属性](/slides/zh/androidjava/shape-effective-properties/) 中描述的有效格式化 API 读取最终的摄像机、光照、斜角等 3D 值。