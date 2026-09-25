---
title: 在 Android 上创建和应用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh/androidjava/wordart/
keywords:
- WordArt
- 创建 WordArt
- WordArt 模板
- WordArt 效果
- 阴影效果
- 反射效果
- 发光效果
- WordArt 变形
- 3D 效果
- 外部阴影效果
- 内部阴影效果
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android via Java 中创建和自定义 WordArt 效果。本分步指南帮助开发者在 Android 上使用专业文本提升演示文稿。"
---
## **概述**

WordArt 效果允许您使用填充、轮廓、阴影、反射、发光、变形和 3D 格式来美化文本。本文介绍如何在未安装 Microsoft Office 的情况下，使用 Aspose.Slides for Android via Java 在 PowerPoint 演示文稿中创建和自定义这些效果。

## **创建简单的 WordArt 模板并将其应用于文本**

以下示例通过设置文本、字体、图案填充和轮廓来构建一个简单的 WordArt 样式。

每个示例都会创建一个新演示文稿，并在其第一张幻灯片上添加一个矩形；不需要输入文件。第一个示例将文本设置为 “Aspose.Slides”。形状的位置和尺寸以点为单位：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

将字体设置为 Arial Black，字号 36 点，以使格式更为显眼：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

应用具有深橙色前景和白色背景的 [SmallGrid](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/patternstyle/#SmallGrid) 图案，然后添加宽度为 1 点的黑色文本轮廓：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int darkOrange = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

生成的文本：

![简单的 WordArt 模板](WordArt_template.png)

## **应用其他 WordArt 效果**

以下示例演示如何将阴影、反射、发光、变形和 3D 效果应用于文本。

### **应用外部阴影效果**

外部阴影通过在文本后方放置阴影来增加深度。您可以自定义其颜色、方向、距离、模糊半径、比例和倾斜。

此示例调用 [enableOuterShadowEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--)，并设置黑色阴影，模糊半径为 4 点，方向为 230 度，距离为 30 点。比例值为 100 保持阴影大小不变，水平倾斜 20 度。Alpha 变换将不透明度设为 32%：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

生成的文本：

![外部阴影效果](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 当同时使用外部阴影和预设阴影时，仅应用外部阴影。
- 如果同时使用外部阴影和内部阴影，产生的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会叠加；而在 PowerPoint 2007 中，仅应用外部阴影。
{{% /alert %}}

### **应用反射效果**

反射会创建文本的镜像副本。您可以调节其位置、比例、模糊和不透明度以控制外观。

此示例调用 [enableReflectionEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--)，将反射垂直翻转，比例为 -100%。使用 0.5 点的模糊半径和 4.72 点的距离。不透明度在反射的 0% 至 60% 位置之间从 60% 下降至 0.9%：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

生成的文本：

![反射效果](reflection_effect.png)

### **应用发光效果**

发光在文本周围添加柔和的彩色轮廓。您可以调节颜色、不透明度和半径来控制效果。

此示例调用 [enableGlowEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--)，应用红色发光，透明度为 54%，半径为 7 点：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

生成的文本：

![发光效果](glow_effect.png)

### **应用 WordArt 变形**

WordArt 变形可以弯曲、拉伸或扭曲一块文本。

将 [setTransform](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) 设置为 [ArchUpPour](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textshapetype/#ArchUpPour)，使整个文本框向上弧形：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

生成的文本：

![WordArt 变形效果](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java 提供了一组预定义的 [变形类型](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textshapetype/)。
{{% /alert %}}

### **对形状和文本应用 3D 效果**

您可以对形状或其文本应用 3D 效果。斜角、挤压、光照和摄像机设置决定最终外观。

以下示例使用 [ThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/threedformat/) 为矩形添加圆形斜角、橙色挤压和深红色轮廓。斜角尺寸、挤压高度、轮廓宽度和深度均以点为单位。塑料材质、围绕 Z 轴旋转 40 度的平衡光照以及透视摄像机定义了其外观：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

生成的形状：

![形状 3D 效果](shape_3D_effect.png)

此示例通过 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--) 对文本应用类似的 3D 格式。较小的斜角塑造字母边缘，挤压和光照为文本提供深度：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

生成的文本：

![文本 3D 效果](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
对文本或其形状应用 3D 效果以及这些效果之间的交互受特定规则约束。考虑一个同时包含文本和承载它的形状的场景。3D 效果包括对象的 3D 表现以及它所在的场景。

- 如果形状和文本都设置了场景，则以形状的场景为优先，忽略文本的场景。
- 如果形状没有自己的场景但有 3D 表现，则使用文本的场景。
- 如果形状根本没有 3D 效果，则视为平面，仅对文本应用 3D 效果。

这些行为涉及 [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/threedformat/#getLightRig--) 和 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/threedformat/#getCamera--) 方法。
{{% /alert %}}

要在保持文本可读性的同时保留其形状的 3D 格式，请参阅 [在 3D 形状上保持文本平面](/slides/zh/androidjava/3d-presentation/) 了解两种设置的对比以及完整的 Java 示例。

## **常见问题解答**

**我可以将 WordArt 效果用于不同的字体或脚本（例如阿拉伯语、中文）吗？**

是的，Aspose.Slides for Android via Java 支持 Unicode，兼容所有主流字体和脚本。无论语言如何，都可以应用阴影、填充和轮廓等 WordArt 效果，但字体的可用性和渲染可能取决于系统字体。

**我可以对幻灯片母版元素应用 WordArt 效果吗？**

可以，您可以对母版幻灯片上的形状（包括标题占位符、页脚或背景文字）应用 WordArt 效果。对母版布局的更改会在所有关联的幻灯片中体现。

**WordArt 效果会影响演示文稿的文件大小吗？**

会有轻微影响。阴影、发光和渐变填充等 WordArt 效果会因增加的格式元数据而略微增大文件大小，但差异通常可以忽略不计。

**我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？**

可以，您可以使用 [ISlide.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/#getImage--) 将包含 WordArt 的幻灯片渲染为图像（例如 PNG、JPEG），或使用 [IShape.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getImage--) 渲染单个形状。这样即可在内存或屏幕上预览效果，而无需保存或导出完整演示文稿。