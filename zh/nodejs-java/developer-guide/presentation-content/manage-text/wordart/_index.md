---
title: 文字艺术
type: docs
weight: 110
url: /zh/nodejs-java/wordart/
---

## **关于 WordArt？**

WordArt 或 Word Art 是一种功能，可让您对文本应用效果，使其脱颖而出。例如，使用 WordArt，您可以为文本添加轮廓或填充颜色（或渐变），为其添加 3D 效果等。您还可以倾斜、弯曲和拉伸文本的形状。

{{% alert color="primary" %}}

WordArt 允许您将文本视为图形对象来处理。通常，WordArt 包括对文本进行的各种效果或特殊修改，以使其更具吸引力或更显眼。

{{% /alert %}}

**Microsoft PowerPoint 中的 WordArt**

要在 Microsoft PowerPoint 中使用 WordArt，必须选择预定义的 WordArt 模板之一。WordArt 模板是一组将应用于文本或其形状的效果。

**Aspose.Slides 中的 WordArt**

在 Aspose.Slides for Node.js via Java 20.10 中，我们实现了对 WordArt 的支持，并在后续的 Aspose.Slides for Node.js via Java 版本中对该功能进行了改进。

使用 Aspose.Slides for Node.js via Java，您可以轻松在 JavaScript 中创建自己的 WordArt 模板（单个效果或效果组合），并将其应用于文本。

## **创建简单的 WordArt 模板并将其应用于文本**

**使用 Aspose.Slides**

首先，我们使用以下 JavaScript 代码创建一个简单的文本：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

现在，通过以下代码将文本的字体高度设置为更大的值，以使效果更明显：
```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**使用 Microsoft PowerPoint**

转到 Microsoft PowerPoint 中的 WordArt 效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧的菜单中，您可以选择预定义的 WordArt 效果。在左侧的菜单中，您可以为新的 WordArt 指定设置。

以下是一些可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在此，我们将 [SmallGrid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternStyle#SmallGrid) 图案颜色应用于文本，并使用以下代码添加宽度为 1 的黑色文本边框：
```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```


生成的文本：

![todo:image_alt_text](image-20200930114108-4.png)

## **应用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程序的类中，您可以将这些效果应用于文本、文本框、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，Shadow、Reflection 和 Glow 效果可以应用于文本；3D Format 和 3D Rotation 效果可以应用于文本框；Soft Edges 属性可以应用于形状对象（即使未设置 3D Format 属性，也仍会产生效果）。

### **应用阴影效果**

这里，我们仅针对文本设置属性。使用以下 JavaScript 代码将阴影效果应用于文本：
```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```


Aspose.Slides API 支持三种阴影类型：OuterShadow、InnerShadow 和 PresetShadow。

使用 PresetShadow，您可以为文本应用预设值的阴影。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您只能使用一种阴影类型。以下是示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许您一次同时应用两种阴影：InnerShadow 和 PresetShadow。

**注意：**

- 当同时使用 OuterShadow 和 PresetShadow 时，仅会应用 OuterShadow 效果。
- 如果同时使用 OuterShadow 和 InnerShadow，所产生或应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会加倍；但在 PowerPoint 2007 中，只会应用 OuterShadow 效果。

### **将显示效果应用于文本**

我们通过以下 JavaScript 示例代码为文本添加显示效果：
```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```


### **将 Glow 效果应用于文本**

我们使用以下代码将 Glow 效果应用于文本，使其发光或突出显示：
```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


操作结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}}

您可以更改阴影、显示和 Glow 的参数。这些效果的属性分别设置在文本的每个部分上。

{{% /alert %}}

### **在 WordArt 中使用变换**

我们通过以下代码使用 Transform 属性（作用于整个文本块）：
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```


结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}}

Microsoft PowerPoint 和 Aspose.Slides for Node.js via Java 均提供一定数量的预定义变换类型。

{{% /alert %}}

**使用 PowerPoint**

要访问预定义变换类型，请依次选择：**Format** -> **TextEffect** -> **Transform**

**使用 Aspose.Slides**

要选择变换类型，请使用 TextShapeType 枚举。

### **将 3D 效果应用于文本和形状**

我们使用以下示例代码为文本形状设置 3D 效果：
```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


生成的文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下 JavaScript 代码为文本应用 3D 效果：
```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```


操作结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}}

将 3D 效果应用于文本或其形状以及效果之间的交互遵循一定规则。

考虑文本及其包含文本的形状的场景。3D 效果包括 3D 对象表示以及放置该对象的场景。

- 当场景同时为图形和文本设置时，图形场景拥有更高优先级——文本场景被忽略。
- 当图形缺少自身场景但具有 3D 表示时，使用文本场景。
- 否则——当形状原本没有 3D 效果时，形状保持平面，3D 效果仅应用于文本。

这些描述与 ThreeDFormat.getLightRig() 和 ThreeDFormat.getCamera() 方法相关。

{{% /alert %}}

## **对文本应用外阴影效果**

Aspose.Slides for Node.js via Java 提供了 [**OuterShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IOuterShadow) 和 [**InnerShadow**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/IInnerShadow) 类，允许您对由 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) 承载的文本应用阴影效果。请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
2. 使用索引获取幻灯片的引用。
3. 向幻灯片添加矩形类型的 AutoShape。
4. 访问与 AutoShape 关联的 TextFrame。
5. 将 AutoShape 的 FillType 设置为 NoFill。
6. 实例化 OuterShadow 类。
7. 设置阴影的 BlurRadius。
8. 设置阴影的 Direction。
9. 设置阴影的 Distance。
10. 将 RectanglelAlign 设置为 TopLeft。
11. 将阴影的 PresetColor 设置为 Black。
12. 将演示文稿写入为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下 Java 示例代码实现了上述步骤，演示如何对文本应用外阴影效果：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 获取幻灯片的引用
    var sld = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // 向矩形添加 TextFrame
    ashp.addTextFrame("Aspose TextBox");
    // 禁用形状填充，以便获取文本的阴影
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 添加外阴影并设置所有必要的参数
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // 将演示文稿写入磁盘
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **对形状应用内阴影效果**

按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
2. 获取幻灯片的引用。
3. 添加矩形类型的 AutoShape。
4. 启用 InnerShadowEffect。
5. 设置所有必要参数。
6. 将 ColorType 设置为 Scheme。
7. 设置 Scheme Color。
8. 将演示文稿写入为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下示例代码（基于上述步骤）展示了如何在 JavaScript 中为两个形状之间添加连接器：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 获取幻灯片的引用
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 向矩形添加 TextFrame
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // 启用 InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // 设置所有必要的参数
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // 将 ColorType 设置为 Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // 设置 Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // 保存演示文稿
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**是否可以将 WordArt 效果与不同的字体或脚本（例如阿拉伯语、中文）一起使用？**

是的，Aspose.Slides 支持 Unicode，并可与所有主流字体和脚本一起使用。无论语言如何，都可以应用阴影、填充和轮廓等 WordArt 效果，尽管字体的可用性和渲染可能取决于系统字体。

**是否可以将 WordArt 效果应用于幻灯片母版元素？**

是的，您可以将 WordArt 效果应用于母版幻灯片上的形状，包括标题占位符、页脚或背景文本。对母版布局所做的更改将反映在所有相关幻灯片中。

**WordArt 效果是否会影响演示文稿文件大小？**

略有影响。阴影、Glow 和渐变填充等 WordArt 效果可能会因添加的格式元数据而略微增加文件大小，但差异通常可以忽略不计。

**是否可以在不保存演示文稿的情况下预览 WordArt 效果的结果？**

是的，您可以使用 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 或 [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) 类的 `getImage` 方法将包含 WordArt 的幻灯片渲染为图像（例如 PNG、JPEG），从而在内存中或屏幕上预览结果，然后再保存或导出完整演示文稿。