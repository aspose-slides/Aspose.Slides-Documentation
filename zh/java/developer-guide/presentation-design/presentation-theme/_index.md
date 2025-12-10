---
title: 在 Java 中管理演示主题
linktitle: 演示主题
type: docs
weight: 10
url: /zh/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中掌握演示主题，以创建、定制并转换具有一致品牌形象的 PowerPoint 文件。"
---

演示主题定义了设计元素的属性。选择演示主题时，实际上是选择了一组特定的视觉元素及其属性。

在 PowerPoint 中，主题包括颜色、[字体](/slides/zh/java/powerpoint-fonts/)、[背景样式](/slides/zh/java/presentation-background/)和效果。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用特定的颜色组合。如果您不喜欢这些颜色，可以通过为主题应用新颜色来更改它们。为了让您选择新的主题颜色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/SchemeColor) 枚举中提供了相应的值。

下面的 Java 代码演示如何更改主题的强调色：
```java
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
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


为了进一步演示颜色更改操作，我们创建另一个元素并将强调色（来自首次操作）赋给它。然后在主题中更改颜色：
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```


新颜色会自动应用到两个元素上。

### **从附加调色板设置主题颜色**

当对主主题颜色 (1) 应用亮度变换时，会生成来自附加调色板 (2) 的颜色。随后您可以设置和获取这些主题颜色。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主主题颜色

**2** - 来自附加调色板的颜色。

下面的 Java 代码演示了从主主题颜色获取附加调色板颜色并在形状中使用的操作：
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 强调色 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // 强调色 4，更亮 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // 强调色 4，更亮 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // 强调色 4，更亮 40%
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

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **更改主题字体**

为了让您为主题及其他用途选择字体，Aspose.Slides 使用了以下特殊标识符（类似于 PowerPoint 中使用的标识符）：

* **+mn-lt** - 正文字体拉丁文（次要拉丁字体）
* **+mj-lt** - 标题字体拉丁文（主要拉丁字体）
* **+mn-ea** - 正文字体东亚（次要东亚字体）
* **+mj-ea** - 标题字体东亚（主要东亚字体）

下面的 Java 代码演示如何将拉丁字体分配给主题元素：
```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```


下面的 Java 代码演示如何更改演示文稿的主题字体：
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```


所有文本框中的字体将被更新。

{{% alert color="primary" title="TIP" %}} 
您可能想查看[PowerPoint 字体](/slides/zh/java/powerpoint-fonts/)。
{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 应用提供 12 种预定义背景，但在典型的演示文稿中只会保存其中的 3 种背景。

![todo:image_alt_text](presentation-design_8.png)

例如，在 PowerPoint 应用中保存演示文稿后，您可以运行以下 Java 代码来获取演示文稿中预定义背景的数量：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
使用来自 [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) 类的 [BackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) 属性，您可以在 PowerPoint 主题中添加或访问背景样式。 
{{% /alert %}} 

下面的 Java 代码演示如何为演示文稿设置背景：
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**索引指南**：0 表示无填充。索引从 1 开始。

{{% alert color="primary" title="TIP" %}} 
您可能想查看[PowerPoint 背景](/slides/zh/java/presentation-background/)。
{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常为每个样式数组包含 3 个数值。这些数组组合形成 3 种效果：细微、适中和强烈。例如，将这些效果应用于特定形状时的结果如下：

![todo:image_alt_text](presentation-design_10.png)

使用来自 [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) 类的 3 个属性（[FillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getEffectStyles--)），您可以更改主题中的元素（比 PowerPoint 中的选项更灵活）。

下面的 Java 代码演示如何通过修改元素的部分属性来更改主题效果：
```java
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


产生的填充颜色、填充类型、阴影效果等更改如下：

![todo:image_alt_text](presentation-design_11.png)

## **常见问题**

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**
可以。Aspose.Slides 支持幻灯片级别的主题覆盖，因此您可以仅对该幻灯片应用本地主题，同时保持母版主题不变（通过 [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/)）。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方式是什么？**
[克隆幻灯片](/slides/zh/java/clone-slides/) 连同其母版一起复制到目标演示文稿中。这样可保留原始母版、布局以及关联的主题，从而保持外观一致。

**如何查看所有继承和覆盖后的“实际”值？**
使用 API 的[“实际”视图](/slides/zh/java/shape-effective-properties/) 来查看主题/颜色/字体/效果的实际值。这些视图在应用母版及任何本地覆盖后返回解析后的最终属性。