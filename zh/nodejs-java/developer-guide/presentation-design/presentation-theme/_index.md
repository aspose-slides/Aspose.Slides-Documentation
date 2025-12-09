---
title: 演示主题
type: docs
weight: 10
url: /zh/nodejs-java/presentation-theme/
keywords: "主题, PowerPoint 主题, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "PowerPoint 演示文稿主题的 JavaScript 实现"
---

演示主题定义了设计元素的属性。当您选择演示主题时，实际上是在选择一组特定的视觉元素及其属性。

在 PowerPoint 中，主题包括颜色、[字体](/slides/zh/nodejs-java/powerpoint-fonts/)、[背景样式](/slides/zh/nodejs-java/presentation-background/)和效果。

![主题组成要素](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用一组特定的颜色。如果您不喜欢这些颜色，可以通过为主题应用新颜色来更改它们。为了让您选择新的主题颜色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SchemeColor) 枚举中提供了相应的值。

以下 JavaScript 代码展示了如何更改主题的强调色：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


您可以通过以下方式确定结果颜色的实际值：
```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


为了进一步演示颜色更改操作，我们创建另一个元素并将强调色（来自初始操作）分配给它。然后我们在主题中更改颜色：
```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


新颜色会自动应用到这两个元素上。

### **从附加调色板设置主题颜色**

当您对主主题颜色 (1) 应用亮度变换时，会生成来自附加调色板 (2) 的颜色。随后您可以设置和获取这些主题颜色。

![附加调色板颜色](additional-palette-colors.png)

**1** - 主主题颜色

**2** - 来自附加调色板的颜色。

以下 JavaScript 代码演示了从主主题颜色获取附加调色板颜色并将其用于形状的操作：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // 强调色 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // 强调色 4, 亮度提升 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // 强调色 4, 亮度提升 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // 强调色 4, 亮度提升 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // 强调色 4, 更暗 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // 强调色 4, 更暗 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **更改主题字体**

为了让您为主题及其他用途选择字体，Aspose.Slides 使用了以下特殊标识符（类似于 PowerPoint 中的标识符）：

* **+mn-lt** - 正文字体 Latin（次要 Latin 字体）
* **+mj-lt** - 标题字体 Latin（主要 Latin 字体）
* **+mn-ea** - 正文字体 East Asian（次要 East Asian 字体）
* **+mj-ea** - 正文字体 East Asian（主要 East Asian 字体）

以下 JavaScript 代码展示了如何将 Latin 字体分配给主题元素：
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```


以下 JavaScript 代码展示了如何更改演示文稿的主题字体：
```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```


所有文本框中的字体将被更新。

{{% alert color="primary" title="TIP" %}} 
您可能想查看 [PowerPoint 字体](/slides/zh/nodejs-java/powerpoint-fonts/)。
{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 应用提供 12 种预定义背景，但在典型的演示文稿中仅保存其中的 3 种背景。 

![演示设计_8](presentation-design_8.png)

例如，在 PowerPoint 应用中保存演示文稿后，您可以运行以下 JavaScript 代码来获取演示文稿中预定义背景的数量：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 
使用来自 [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) 类的 [BackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) 属性，您可以在 PowerPoint 主题中添加或访问背景样式。
{{% /alert %}} 

以下 JavaScript 代码展示了如何为演示文稿设置背景：
```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**索引指南**：0 表示无填充。索引从 1 开始。

{{% alert color="primary" title="TIP" %}} 
您可能想查看 [PowerPoint 背景](/slides/zh/nodejs-java/presentation-background/)。
{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常为每个样式数组包含 3 个值。这些数组组合成三种效果：轻微、适中和强烈。例如，当将这些效果应用于特定形状时，得到的效果如下：

![演示设计_10](presentation-design_10.png)

使用来自 [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) 类的 3 个属性（[FillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)），您可以更灵活地更改主题中的元素（比 PowerPoint 中的选项更强大）。

以下 JavaScript 代码展示了如何通过修改元素的各部分来更改主题效果：
```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


结果包括填充颜色、填充类型、阴影效果等的更改：

![演示设计_11](presentation-design_11.png)

## **常见问题**

**是否可以在不更改母版的情况下将主题应用于单个幻灯片？**

是的。Aspose.Slides 支持幻灯片级别的主题覆盖，您可以仅对该幻灯片应用本地主题，同时保持母版主题不变（通过 [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/)）。

**将主题从一个演示文稿安全迁移到另一个演示文稿的最佳方法是什么？**

[Clone slides](/slides/zh/nodejs-java/clone-slides/) 与它们的母版一起克隆到目标演示文稿中。这样可以保留原始母版、布局以及相关主题，从而保持外观一致。

**如何查看所有继承和覆盖之后的“实际”值？**

使用 API 的["effective" 视图](/slides/zh/nodejs-java/shape-effective-properties/)（针对主题/颜色/字体/效果）。这些视图返回在应用母版以及任何本地覆盖后解析得到的最终属性。