---
title: 在 Android 上管理演示主题
linktitle: 演示主题
type: docs
weight: 10
url: /zh/androidjava/presentation-theme/
keywords:
- PowerPoint 主题
- 演示主题
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
- Android
- Java
- Aspose.Slides
description: "通过 Java 在 Android 上使用 Aspose.Slides 管理演示主题，以创建、定制并转换具有一致品牌形象的 PowerPoint 文件。"
---
## **简介**

演示主题定义了设计元素的属性。当您选择演示主题时，实际上是在选择一组特定的视觉元素及其属性。

在 PowerPoint 中，主题包括颜色、[fonts](/slides/zh/androidjava/powerpoint-fonts/)、[background styles](/slides/zh/androidjava/presentation-background/) 和效果。

![主题组成](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用特定的颜色集合。如果您不喜欢这些颜色，可以通过为主题应用新颜色来更改它们。为了让您选择新的主题颜色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SchemeColor) 枚举中提供了相应的值。

下面的 Java 代码演示了如何更改主题的强调颜色：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

您可以通过以下方式确定结果颜色的实际值：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

为了进一步演示颜色更改操作，我们创建另一个元素并将（初始操作得到的）强调颜色分配给它。随后我们在主题中更改颜色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

新颜色会自动应用到两个元素上。

### **从附加调色板设置主题颜色**

当您对主主题颜色(1) 应用亮度变换时，会形成来自附加调色板(2) 的颜色。随后您可以设置并获取这些主题颜色。

![附加调色板颜色](additional-palette-colors.png)

**1** - 主主题颜色  

**2** - 附加调色板中的颜色。

下面的 Java 代码演示了从主主题颜色获取附加调色板颜色并在形状中使用的操作：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 强调色 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // 强调色 4，亮度提升 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // 强调色 4，亮度提升 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // 强调色 4，亮度提升 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // 强调色 4，更暗 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 强调色 4，更暗 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **将 `SchemeColor` 映射到 `IColorScheme` 颜色**

使用 [SchemeColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/schemecolor/) 时，您可能会注意到它包含以下主题颜色值：

`Background1`、`Background2`、`Text1` 和 `Text2`。

然而，`Presentation.getMasterTheme().getColorScheme()` 返回 [IColorScheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icolorscheme/)，其对应的颜色名称为：

`Dark1`、`Dark2`、`Light1`、`Light2`。

这仅是命名上的差异。这些值指向相同的主题颜色槽，映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` 与 `Dark`/`Light` 之间不存在动态转换，它们仅是同一本主题颜色的交替名称。

这种命名差异来源于 Microsoft Office 术语。旧版 Office 使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而新版 UI 则显示为 `Text 1`、`Background 1`、`Text 2`、`Background 2`。

## **更改主题字体**

为了让您为主题及其他用途选择字体，Aspose.Slides 使用了这些特殊标识符（类似 PowerPoint 中的标识符）：

* **+mn-lt** - 正文字体 Latin（Minor Latin Font）
* **+mj-lt** - 标题字体 Latin（Major Latin Font）
* **+mn-ea** - 正文字体 East Asian（Minor East Asian Font）
* **+mj-ea** - 正文字体 East Asian（Major East Asian Font）

下面的 Java 代码演示了如何为主题元素分配 Latin 字体：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

下面的 Java 代码演示了如何更改演示文稿的主题字体：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

所有文本框中的字体都会被更新。

{{% alert color="info" title="TIP" %}} 
您可能想查看 [PowerPoint fonts](/slides/zh/androidjava/powerpoint-fonts/)。
{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 应用提供 12 种预定义背景，但在典型的演示文稿中仅保存其中的 3 种。

![todo:image_alt_text](presentation-design_8.png)

例如，在 PowerPoint 应用中保存演示文稿后，您可以运行以下 Java 代码来获取演示文稿中预定义背景的数量：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
使用来自 [FormatScheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FormatScheme) 类的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) 属性，您可以在 PowerPoint 主题中添加或访问背景样式。
{{% /alert %}} 

下面的 Java 代码演示了如何为演示文稿设置背景：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**索引指南**：0 表示无填充。索引从 1 开始。

{{% alert color="info" title="TIP" %}} 
您可能想查看 [PowerPoint Background](/slides/zh/androidjava/presentation-background/)。
{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常为每个样式数组包含 3 个值。这些数组组合为 3 种效果：微妙、适中和强烈。例如，以下是将效果应用于特定形状时的结果：

![todo:image_alt_text](presentation-design_10.png)

通过使用来自 [FormatScheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FormatScheme) 类的 3 个属性（[FillStyles](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)），您可以更灵活地更改主题中的元素，甚至比 PowerPoint 的选项更强大。

下面的 Java 代码演示了如何通过修改元素的部分属性来更改主题效果：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

 resulting changes in fill color, fill type, shadow effect, etc:

![todo:image_alt_text](presentation-design_11.png)

## **常见问题**

### 我可以在不更改母版的情况下将主题应用于单个幻灯片吗？

可以。Aspose.Slides 支持幻灯片级别的主题覆盖，您可以仅为该幻灯片应用本地主题，同时保持母版主题不变（通过 [SlideThemeManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slidethememanager/)）。

### 将主题从一个演示文稿迁移到另一个演示文稿的最安全方式是什么？

使用 [Clone slides](/slides/zh/androidjava/clone-slides/) 将幻灯片及其母版一起克隆到目标演示文稿中。这会保留原始母版、布局以及关联的主题，从而保持外观一致。

### 如何查看所有继承和覆盖后的“实际”值？

使用 API 的 [“effective” 视图](/slides/zh/androidjava/shape-effective-properties/)（主题/颜色/字体/效果）。这些视图返回在应用母版以及任何本地覆盖后解析出的最终属性。