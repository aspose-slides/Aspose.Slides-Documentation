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
description: "在 Java 中使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、灯光、材质、拉伸、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Java 能够创建、编辑、保留并渲染 PowerPoint 样式的形状和文本的 3D 格式化。本篇文章涵盖旋转、拉伸、斜面、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}
本文介绍的是 PowerPoint 形状和文本的 3D 格式化效果。它不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) 方法对形状应用 3D 格式化。该方法返回 [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/)，用于控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) 方法。这会将 3D 格式化应用于文本框，而不是形状主体。

最重要的 API 成员如下：

| API 成员 | 控制内容 | 使用时机 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | 光线预设、方向和光线旋转。 | 更改 3D 表面上高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材质，例如平面、哑光、塑料或金属。 | 使相同的几何形状看起来更平坦、更柔软、光亮或金属感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形状从前面延伸到后面的距离。 | 将平面形状转换为可见的厚实 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 拉伸侧面的颜色。 | 使深度可见或将侧面颜色与前部填充协调。 |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 对形状或文本的深度进行微调，尤其是在使用斜面和材质设置时。 |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 前后面上的凸起或圆角边缘。 | 添加柔和或成型的边缘，而不是锐利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 围绕 3D 对象的轮廓。 | 在渲染输出中突出显示对象的边界。 |

## **创建 3D 形状**

形状通常需要四种设置才能呈现出逼真的 3D 效果：

- 相机设置，因为默认的前视图可能隐藏拉伸效果。
- 光照设置，因为光照使各面和侧面可见。
- 材质设置，因为表面会影响光线的渲染方式。
- 拉伸或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其前面添加文本，并应用 3D 格式化。相机旋转值以度为单位，拉伸高度为 100 点。示例将幻灯片渲染为尺寸为默认两倍的 PNG 图像，并将演示文稿保存为 PPTX。

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

渲染后的幻灯片图像将矩形显示为厚实的 3D 块：

![渲染的蓝色 3D 矩形，前面带有白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过 3-D 旋转面板进行配置。X、Y、Z 旋转值对应于通过相机 API 设置的旋转。

![PowerPoint 3-D 旋转面板，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) 访问相机。该示例创建一个矩形，选择正交前视图，并将其 X、Y、Z 旋转分别设置为 20、30、40 度。它在内存中配置形状，而不保存文件：

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

当需要更改查看者看到对象的方式时使用相机。它不会改变幻灯片上 2D 形状的几何形状，而是改变 PowerPoint 和 Aspose.Slides 在渲染时使用的 3D 视点。

### **从模板形状复制相机方向**

要匹配模板形状的方向，可使用 [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) 读取其相机预设，使用 [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--) 读取其旋转角度。示例打开 `template.pptx`，并将第一页第一张幻灯片的第一个形状的相机方向复制到第二个形状。两个形状已经具有 3D 灯光，第二个形状没有显式的相机旋转。

角度以度为单位。索引 `0` 为纬度，索引 `1` 为经度，索引 `2` 为旋转。按此顺序将它们传递给 [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-)。如果源返回 `null`，表示没有显式旋转，则保持第二个形状的角度未设置。显式旋转 `(0, 0, 0)` 会返回三个零，应当复制。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

当在 PowerPoint 中重新打开 `camera-copy.pptx` 时，右侧的箭头具有与左侧矩形相同的相机预设和旋转。两个形状使用相同的灯光和拉伸深度。

![一个蓝色 3D 矩形和一个具有匹配相机方向的右箭头，从上方右侧观看](camera-orientation.png)

## **添加拉伸和深度**

拉伸通过将形状延伸至前面后方，使其看起来更厚。PowerPoint 中的深度控制设置可见的厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到拉伸颜色和拉伸高度属性](img_02_02.png)

使用 [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 设置厚度，使用 [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) 获取侧面颜色。该示例为矩形设置 100 点的紫色侧面拉伸，并旋转相机以展示其厚度。它在内存中配置形状，而不保存文件：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) 方法设置 3D 形状的深度。[setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 方法控制拉伸效果的高度，如本示例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对前面应用纯色、渐变、图案或图片填充，同时仍使用相同的相机、光照、材质和拉伸设置。

本示例对前面应用蓝到橙的渐变，对 150 点的拉伸使用深橙色。渐变在 0 和 100 处分别标记起始和结束。相机旋转值以度为单位。幻灯片被渲染为尺寸为默认两倍的 PNG 图像：

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

渲染输出保持前面的渐变，并单独渲染拉伸效果：

![渲染的 3D 矩形，蓝到橙的渐变填充和橙色拉伸](img_02_03.png)

若改用图片填充，先将图像添加到演示文稿并分配给形状填充。此示例需要工作目录中存在名为 "image.jpg" 的文件。它将图片拉伸以填满矩形，应用 150 点的拉伸，并以度为单位设置相机旋转。它在内存中配置形状，而不保存或渲染文件：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
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

图片渲染在前面，拉伸渲染为 3D 侧面表面：

![渲染的 3D 矩形，前面为照片填充，侧面为橙色拉伸](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状主体。文本的 3D 格式化影响文本框。这对于类似 WordArt 的效果很有用，需要对字母本身进行拉伸、材质、照明和相机设置。

下面的示例创建带有橙白网格图案的文本，应用向上的拱形，并通过 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) 配置 3D 设置。拉伸高度和深度以点为单位，光照旋转以度为单位。形状填充和轮廓被隐藏，仅显示文本。示例以两倍默认幻灯片尺寸渲染 PNG 图像并将演示文稿保存为 PPTX：

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

文本被渲染为弯曲、拉伸的 3D 字体：

![渲染的 3D 文本，拱形 WordArt 变换，橙色图案填充，深色拉伸](img_02_05.png)

## **在 3D 形状上保持文本平面**

为在保持形状 3D 外观的同时让文本可读，应通过 [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--) 调用 [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-)。当值为 `true` 时，文本保持在 3D 场景之外；当值为 `false` 时，文本参与场景并遵循其 3D 方向。

此设置不会移除形状的 3D 格式化：其相机、灯光、材质和拉伸仍通过 [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) 配置。它也不同于普通旋转。[IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) 在幻灯片平面上旋转形状，而 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 控制文本在其边界框内的自定义旋转。将文本保留在 3D 场景之外不会重置这两个角度。

下面的独立示例创建一个带文本的蓝色矩形，并在原始旁边克隆它。两个形状具有相同的 3D 格式化；仅文本设置不同：左侧为 `false`，右侧为 `true`。相机角度以度为单位，拉伸高度为 40 点。示例将演示文稿保存为 PPTX，并以两倍默认尺寸将对比幻灯片渲染为 PNG。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
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

![并排的 3D 矩形：左侧文本遵循 3D 方向，右侧保持平面](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。此行为适用于将幻灯片渲染为 [PNG](/slides/zh/java/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/java/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/java/convert-powerpoint-to-html/)，或生成用于 [video conversion](/slides/zh/java/convert-powerpoint-to-video/) 的帧时。

- 导出的图像和 PDF 不是交互式的。导出后，观看者无法旋转对象。
- 最终外观取决于相机、灯光装置、材质、拉伸、填充和幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式化值，请读取 [effective shape properties](/slides/zh/java/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是保留为可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染形状和文本的 PowerPoint 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为可交互的 3D 场景，观看者无法旋转。在 PPTX 中，只要格式支持，3D 格式化仍保持在 PowerPoint 中可编辑。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、拉伸、斜面、照明和材质。本文讨论的是 3D 效果。

**可见的 3D 形状需要哪些设置？**

最低要求设置相机旋转以及拉伸或深度。实际使用中，还应设置灯光装置和材质，以便渲染的表面拥有清晰的高光和阴影。

**我可以对形状和文本都应用 3D 效果吗？**

可以。对形状主体使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--)，对文本使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--)。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时会渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**在应用继承和主题设置后，我可以读取最终的 3D 值吗？**

可以。使用在 [Shape Effective Properties](/slides/zh/java/shape-effective-properties/) 中描述的有效格式化 API 读取最终的相机、灯光装置、斜面和相关的 3D 值。