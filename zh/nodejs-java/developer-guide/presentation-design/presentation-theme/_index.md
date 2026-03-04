---
title: 在 JavaScript 中管理演示文稿主题
linktitle: 演示文稿主题
type: docs
weight: 10
url: /zh/nodejs-java/presentation-theme/
keywords:
- PowerPoint 主题
- 演示文稿主题
- 幻灯片主题
- 设置主题
- 更改主题
- 管理主题
- 主题颜色
- 附加调色板
- 主题字体
- 主题样式
- 主题效果
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中精通演示文稿主题，以创建、定制并转换具有一致品牌形象的 PowerPoint 文件。"
---
演示主题定义了设计元素的属性。当您选择演示主题时，实际上是选择了一组特定的视觉元素及其属性。

在 PowerPoint 中，主题包括颜色、[字体](/slides/zh/nodejs-java/powerpoint-fonts/)、[背景样式](/slides/zh/nodejs-java/presentation-background/)和效果。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用一组特定颜色。如果您不喜欢这些颜色，可通过为主题应用新颜色来更改它们。为方便您选择新主题颜色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/SchemeColor) 枚举中提供了相应的值。

下面的 JavaScript 代码演示了如何更改主题的强调色：

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

您可以通过以下方式确定生成颜色的有效值：

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

为了进一步演示颜色更改操作，我们创建另一个元素并将强调色（来自首次操作）分配给它。然后我们在主题中更改颜色：

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

新颜色会自动应用到两个元素上。

### **从附加调色板设置主题颜色**

当对主主题颜色 (1) 应用亮度变换时，会产生附加调色板 (2) 中的颜色。随后您可以设置和获取这些主题颜色。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主主题颜色  
**2** - 来自附加调色板的颜色。

下面的 JavaScript 代码演示了从主主题颜色获取附加调色板颜色并在形状中使用的操作：

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // 强调色 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // 强调色 4，亮度提升 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // 强调色 4，亮度提升 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // 强调色 4，亮度提升 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // 强调色 4，暗度 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // 强调色 4，暗度 50%
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

### **将 `SchemeColor` 映射到 `ColorScheme` 颜色**

使用 [SchemeColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/schemecolor/) 时，您可能会注意到它包含以下主题颜色值：

`Background1`, `Background2`, `Text1`, 和 `Text2`.

然而，`Presentation.getMasterTheme().getColorScheme()` 返回 [ColorScheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/colorscheme/)，它以以下方式公开相应的颜色：

`Dark1`, `Dark2`, `Light1`, 和 `Light2`.

此差异仅在于命名。这些值对应相同的主题颜色槽，映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` 与 `Dark`/`Light` 之间不存在动态转换，它们仅是同一主题颜色的别名。

这种命名差异来源于 Microsoft Office 的术语。较早的 Office 版本使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而新版 UI 则将相同槽显示为 `Text 1`、`Background 1`、`Text 2`、`Background 2`。

## **更改主题字体**

为了方便您为主题及其他用途选择字体，Aspose.Slides 使用了以下特殊标识符（类似于 PowerPoint 中的标识符）：

* **+mn-lt** - 正文字体拉丁语（次要拉丁字体）
* **+mj-lt** - 标题字体拉丁语（主要拉丁字体）
* **+mn-ea** - 正文字体东亚（次要东亚字体）
* **+mj-ea** - 正文字体东亚（主要东亚字体）

下面的 JavaScript 代码演示了如何将拉丁字体分配给主题元素：

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

下面的 JavaScript 代码演示了如何更改演示文稿的主题字体：

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

所有文本框中的字体都会被更新。

{{% alert color="primary" title="TIP" %}} 
您可能想查看[PowerPoint 字体](/slides/zh/nodejs-java/powerpoint-fonts/)。 
{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 应用提供 12 种预定义背景，但在典型的演示文稿中仅保存这 12 种背景中的 3 种。

![todo:image_alt_text](presentation-design_8.png)

例如，在 PowerPoint 应用中保存演示文稿后，您可以运行以下 JavaScript 代码来查找演示文稿中预定义背景的数量：

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
使用来自 [FormatScheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/FormatScheme) 类的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) 属性，您可以在 PowerPoint 主题中添加或访问背景样式。 
{{% /alert %}} 

下面的 JavaScript 代码演示了如何为演示文稿设置背景：

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**索引指南**：0 表示无填充。索引从 1 开始。

{{% alert color="primary" title="TIP" %}} 
您可能想查看[PowerPoint Background](/slides/zh/nodejs-java/presentation-background/)。 
{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常为每个样式数组包含 3 个值。这些数组组合成以下 3 种效果：细微、适中和强烈。例如，将这些效果应用于特定形状时的结果如下：

![todo:image_alt_text](presentation-design_10.png)

使用来自 [FormatScheme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/FormatScheme) 类的 3 个属性（[FillStyles](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)），您可以更改主题中的元素（甚至比 PowerPoint 中的选项更灵活）。

下面的 JavaScript 代码演示了如何通过更改元素的部分属性来更改主题效果：

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

产生的填充颜色、填充类型、阴影效果等变化如下：

![todo:image_alt_text](presentation-design_11.png)

## **常见问题**

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**  
是的。Aspose.Slides 支持幻灯片级别的主题覆盖，您可以仅对该幻灯片应用局部主题，同时保持母版主题不变（通过 [SlideThemeManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidethememanager/)）。

**从一个演示文稿迁移主题到另一个演示文稿的最安全方式是什么？**  
将幻灯片与其母版一起克隆到目标演示文稿中（参见[克隆幻灯片](/slides/zh/nodejs-java/clone-slides/)）。这样可以保留原始母版、布局及其关联的主题，从而保持外观一致。

**如何查看所有继承和覆盖后的“有效”值？**  
使用 API 的[“有效”视图](/slides/zh/nodejs-java/shape-effective-properties/)（主题/颜色/字体/效果）。这些视图返回在应用母版及任何局部覆盖后解析出的最终属性。