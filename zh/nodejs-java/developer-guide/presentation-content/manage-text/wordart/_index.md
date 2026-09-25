---
title: 在 Node.js 中创建和应用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh/nodejs-java/wordart/
keywords:
- 文字艺术
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中创建和自定义 WordArt 效果。此分步指南帮助开发人员在 Node.js 中使用专业文本提升演示文稿。"
---
## **概述**

WordArt 效果让您可以为文本添加填充、轮廓、阴影、反射、发光、变形和 3D 格式。本篇文章说明如何在未安装 Microsoft Office 的情况下，使用 Aspose.Slides for Node.js via Java 在 PowerPoint 演示文稿中创建和自定义这些效果。

## **创建简单的 WordArt 模板并将其应用于文本**

以下示例通过设置文本、字体、图案填充和轮廓来构建一个简单的 WordArt 样式。

每个示例都会创建一个新演示文稿，并在其第一张幻灯片上添加一个矩形；不需要输入文件。第一个示例将文本设置为 “Aspose.Slides”。形状的位置和尺寸以点为单位：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

将字体设置为 Arial Black，大小 36 点，以使格式更明显：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

应用一个前景为深橙色、背景为白色的 [SmallGrid](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/patternstyle/#SmallGrid) 图案，然后添加宽度为 1 点的黑色文字轮廓：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

生成的文本：

![简单的 WordArt 模板](WordArt_template.png)

## **应用其他 WordArt 效果**

以下示例演示如何对文本应用阴影、反射、发光、变形和 3D 效果。

### **应用外部阴影效果**

外部阴影通过在文本后方放置阴影来增加深度。您可以自定义其颜色、方向、距离、模糊半径、比例和倾斜。

此示例调用 [enableOuterShadowEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect)，并设置一个黑色阴影，模糊半径为 4 点，方向为 230 度，距离为 30 点。比例值 100 保持阴影大小，水平倾斜 20 度。alpha 变换将不透明度设为 32%：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

生成的文本：

![外部阴影效果](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 当同时使用外部阴影和预设阴影时，仅应用外部阴影。
- 如果同时使用外部阴影和内部阴影，最终效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会加倍，而在 PowerPoint 2007 中，仅应用外部阴影。
{{% /alert %}}

### **应用反射效果**

反射创建文本的镜像副本。调整其位置、比例、模糊和不透明度以控制外观。

此示例调用 [enableReflectionEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect)，并将反射垂直翻转，比例为 -100%。使用 0.5 点的模糊半径和 4.72 点的距离。不透明度在 0% 到 60% 的位置间从 60% 下降到 0.9%：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

生成的文本：

![反射效果](reflection_effect.png)

### **应用发光效果**

发光在文本周围添加柔和的彩色轮廓。调整其颜色、不透明度和半径以控制效果。

此示例调用 [enableGlowEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effectformat/#enableGlowEffect)，并应用红色发光，透明度为 54%，半径为 7 点：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

生成的文本：

![发光效果](glow_effect.png)

### **应用 WordArt 变形**

WordArt 变形可以弯曲、拉伸或扭曲一块文本。

将 [setTransform](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/#setTransform) 设置为 [ArchUpPour](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textshapetype/#ArchUpPour)，使整个文本框向上弯曲：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

生成的文本：

![WordArt 变形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java 提供了一组预定义的 [transformation types](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textshapetype/)。
{{% /alert %}}

### **对形状和文本应用 3D 效果**

您可以对形状或其文本应用 3D 效果。倒角、拉伸、照明和摄像机设置控制最终外观。

以下示例使用 [ThreeDFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/) 为矩形添加圆形倒角、橙色拉伸和深红色轮廓。倒角尺寸、拉伸高度、轮廓宽度和深度均以点为单位。塑料材质、绕 Z 轴旋转 40 度的平衡照明以及透视摄像机定义其外观：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

生成的形状：

![形状 3D 效果](shape_3D_effect.png)

此示例通过 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) 对文本应用类似的 3D 格式。较小的倒角塑造字母边缘，而拉伸和照明为文本提供深度：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

生成的文本：

![文本 3D 效果](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
将 3D 效果应用于文本或其形状以及这些效果之间的交互受特定规则约束。考虑同时涉及文本及其所在形状的场景。3D 效果包括对象的 3D 表现以及其所在的场景。

- 如果形状和文本都设置了场景，则形状的场景优先，文本的场景被忽略。
- 如果形状没有自己的场景但具有 3D 表现，则使用文本的场景。
- 如果形状根本没有 3D 效果，则视为平面，仅对文本应用 3D 效果。

这些行为涉及 [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getLightRig) 和 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/#getCamera) 方法。
{{% /alert %}}

要在保留形状 3D 格式的同时保持文本平面且可读，请参阅 [Keep Text Flat on a 3D Shape](/slides/zh/nodejs-java/3d-presentation/) 了解两种设置的比较及完整的 JavaScript 示例。

## **常见问题**

**我可以在不同字体或脚本（例如阿拉伯文、中文）中使用 WordArt 效果吗？**

可以，Aspose.Slides for Node.js via Java 支持 Unicode，兼容所有主流字体和脚本。无论语言如何，都可以应用阴影、填充和轮廓等 WordArt 效果，但字体可用性和渲染可能取决于系统字体。

**我可以对母版幻灯片元素应用 WordArt 效果吗？**

可以，您可以对母版幻灯片上的形状（包括标题占位符、页脚或背景文本）应用 WordArt 效果。对母版布局的更改会反映在所有相关幻灯片上。

**WordArt 效果会影响演示文稿文件大小吗？**

会有轻微影响。阴影、发光和渐变填充等 WordArt 效果可能会因增加的格式元数据略微增大文件大小，但通常差异可以忽略不计。

**我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？**

可以，您可以使用 [Slide.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getImage) 将包含 WordArt 的幻灯片渲染为图像（如 PNG、JPEG），或使用 [Shape.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getImage) 渲染单个形状。这使您能够在内存或屏幕上预览结果，而无需保存或导出完整的演示文稿。