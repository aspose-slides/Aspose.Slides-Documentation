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
description: "在 Java 中使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、灯光、材质、挤压、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for Java 可以创建、编辑、保留并渲染 PowerPoint 样式的 3D 形状和文本格式。本文章涵盖了旋转、挤压、倒角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果。它不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getThreeDFormat--) 方法对形状应用 3D 格式化。该方法返回 [IThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/)，用于控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) 方法。此方法对文本框而非形体本身应用 3D 格式化。

最重要的 API 成员如下：

| API 成员 | 控制内容 | 使用时机 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getCamera--) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [getLightRig](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getLightRig--) | 光源预设、方向和光线旋转。 | 改变 3D 表面高光和阴影的显示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材质，如平面、哑光、塑料或金属。 | 让相同几何体呈现更平坦、柔和、光泽或金属感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形状从正面向后延伸的距离。 | 将平面形状转换为可见的厚实 3D 对象。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 挤压侧面的颜色。 | 让深度可见或将侧面颜色与正面填充保持一致。 |
| [getDepth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的额外深度。 | 对形状或文本进行精细的深度调节，尤其配合倒角和材质设置使用。 |
| [getBevelTop](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面和背面边缘的凸起或圆角。 | 添加柔化或模具化的边缘，而不是锐利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getContourColor--)、[getContourWidth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getContourWidth--) 和 [setContourWidth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状在看起来逼真的 3D 效果之前通常需要四类设置：

- 相机设置，因为默认的正视角可能隐藏挤压效果。  
- 灯光设置，因为光照使各面和侧面可读。  
- 材质设置，因为表面影响光线的渲染方式。  
- 挤压或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其正面添加文本，并应用 3D 格式化。相机旋转值以度为单位，挤压高度为 100 点。示例将幻灯片渲染为 PNG 图像（尺寸为默认的两倍），并将演示文稿保存为 PPTX。

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

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过“3‑D 旋转”窗格配置。X、Y、Z 旋转值对应于通过相机 API 设置的旋转。

![PowerPoint 3‑D 旋转窗格，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getCamera--) 访问相机。该示例创建一个矩形，选择正投影正视图，并将其 X、Y、Z 旋转分别设置为 20、30、40 度。它在内存中配置形状，而不保存文件：

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

当需要改变观察者看到的对象时使用相机。它不会改变幻灯片上 2D 形状的几何结构，而是改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加挤压和深度**

挤压通过在正面后方延伸形状来实现厚度。在 PowerPoint 中，深度控制设置可见的厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到挤压颜色和挤压高度属性](img_02_02.png)

使用 [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 设置厚度，使用 [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) 访问侧面颜色。此示例为矩形设置 100 点挤压，侧面为紫色，并旋转相机以展示其厚度。它在内存中配置形状，而不保存文件：

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setDepth-double-) 方法设置 3D 形状的深度。[setExtrusionHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 方法控制挤压效果的高度，如本示例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对正面应用纯色、渐变、图案或图片填充，同时使用相同的相机、灯光、材质和挤压设置。

此示例对正面应用蓝到橙的渐变，对 150 点挤压使用深橙色。渐变止点在 0 和 100 处标记渐变的起止。相机旋转值以度为单位。幻灯片渲染为 PNG 图像（尺寸为默认的两倍）：

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

渲染结果保留正面的渐变，并单独渲染挤压：

![渲染的 3D 矩形，正面为蓝到橙的渐变填充，侧面为橙色挤压](img_02_03.png)

若使用图片填充，先将图像添加到演示文稿并分配给形状填充。此示例要求工作目录中已有名为 "image.jpg" 的文件。它将图片拉伸填满矩形，应用 150 点挤压，并以度为单位设置相机旋转。它在内存中配置形状，而不保存或渲染文件：

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

图片在正面渲染，挤压则作为 3D 侧面渲染：

![渲染的 3D 矩形，正面为照片填充，侧面为橙色挤压](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形体本身。文本的 3D 格式化影响文本框。这对于需要字母本身具有挤压、材质、照明和相机设置的 WordArt 类效果非常有用。

下面的示例创建使用橙白网格图案的文本，应用向上拱形，并通过 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) 配置 3D 设置。挤压高度和深度使用点，光线旋转使用度。形状填充和轮廓被隐藏，仅显示文本。示例将 PNG 图像渲染为默认幻灯片尺寸的两倍，并保存演示文稿为 PPTX：

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

文本被渲染为弯曲、挤压的 3D 字体：

![渲染的 3D 文本，拱形 WordArt 变换，橙色图案填充，深色挤压](img_02_05.png)

## **在 3D 形状上保持文本平面**

为在保持形状 3D 外观的同时让文本易读，请通过 [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/#getTextFrameFormat--) 调用 [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-)。当该值为 `true` 时，文本保持在 3D 场景之外；为 `false` 时，文本参与场景并遵循其 3D 朝向。

此设置不会移除形状的 3D 格式化：其相机、灯光、材质和挤压仍通过 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getThreeDFormat--) 配置。它也不同于普通旋转。[IShape.setRotation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#setRotation-float-) 在幻灯片平面内旋转形状，而 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 控制文本在其边界框内的自定义旋转。将文本保持在 3D 场景之外不会重置上述任意角度。

下面的完整示例创建一个带文本的蓝色矩形，并在原始矩形旁复制一份。两个形状拥有相同的 3D 格式化，仅文本设置不同：左侧为 `false`，右侧为 `true`。相机角度使用度，挤压高度为 40 点。示例将演示文稿保存为 PPTX，并将比较幻灯片渲染为 PNG（尺寸为默认的两倍）。

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

左侧文本随 3D 朝向变化，右侧文本保持平面且更易阅读。两者的可见挤压和 3D 朝向相同。

![并排的 3D 矩形：左侧文本随 3D 朝向，右侧文本保持平面](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。这适用于将幻灯片渲染为 [PNG](/slides/zh/java/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/java/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/java/convert-powerpoint-to-html/)，或生成用于 [video conversion](/slides/zh/java/convert-powerpoint-to-video/) 的帧。

请注意以下要点：

- 导出的图像和 PDF 并非交互式。导出后对象无法被观看者旋转。  
- 最终外观取决于相机、灯光装置、材质、挤压、填充和幻灯片缩放的组合。  
- 若需检查继承或主题基准的格式化值，请读取 [effective shape properties](/slides/zh/java/shape-effective-properties/)。  
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染而非保留为可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**  
Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为可交互的 3D 场景供观看者旋转。在 PPTX 中，3D 格式化仍可在支持该格式的 PowerPoint 中编辑。

**3D 模型和 3D 效果有什么区别？**  
3D 模型是插入演示文稿的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、挤压、倒角、照明和材质。本文讨论的正是 3D 效果。

**实现可见的 3D 形状需要哪些设置？**  
至少需要设置相机旋转并使用挤压或深度。实践中，还应设置灯光装置和材质，以便渲染出的面具有清晰的高光和阴影。

**我可以同时对形状和文本应用 3D 效果吗？**  
可以。对形状本体使用 [IShape.getThreeDFormat]，对文本使用 [ITextFrameFormat.getThreeDFormat]。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**  
会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**我能在继承和主题设置应用后读取最终的 3D 值吗？**  
可以。使用在 [Shape Effective Properties](/slides/zh/java/shape-effective-properties/) 中描述的有效格式化 API 读取最终的相机、灯光装置、倒角以及相关的 3D 值。