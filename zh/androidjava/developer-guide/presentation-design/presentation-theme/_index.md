---
title: 演示主题
type: docs
weight: 10
url: /androidjava/presentation-theme/
keywords: "主题, PowerPoint主题, PowerPoint演示文稿, Java, Aspose.Slides for Android via Java"
description: "Java中的PowerPoint演示文稿主题"
---

演示主题定义了设计元素的属性。当您选择演示主题时，您实际上是在选择一组特定的视觉元素及其属性。

在PowerPoint中，主题包括颜色、[字体](/slides/androidjava/powerpoint-fonts/)、[背景样式](/slides/androidjava/presentation-background/)和效果。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint主题为幻灯片上的不同元素使用特定的颜色集。如果您不喜欢这些颜色，您可以通过为主题应用新颜色来更改它们。为了让您选择新主题颜色，Aspose.Slides提供了[SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor)枚举下的值。

下面的Java代码演示了如何更改主题的强调色：

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

您可以通过以下方式确定结果颜色的有效值：

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("颜色 [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

为了进一步演示颜色更改操作，我们创建另一个元素，并将强调色（来自初始操作）分配给它。然后我们在主题中更改颜色：

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

新颜色会自动应用于两个元素。

### **从附加调色板设置主题颜色**

当您对主主题颜色(1)应用亮度变换时，会形成附加调色板(2)的颜色。您可以设置和获取这些主题颜色。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主主题颜色

**2** - 附加调色板的颜色。

以下Java代码演示了一种操作，其中从主主题颜色获取附加调色板颜色，然后用于形状：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 强调 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // 强调 4，变亮 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // 强调 4，变亮 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // 强调 4，变亮 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // 强调 4，变暗 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 强调 4，变暗 50%
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

为了让您为主题和其他目的选择字体，Aspose.Slides使用这些特殊标识符（类似于PowerPoint中使用的标识符）：

* **+mn-lt** - 正文字体拉丁文（次要拉丁文字体）
* **+mj-lt** - 标题字体拉丁文（主要拉丁文字体）
* **+mn-ea** - 正文字体东亚文（次要东亚字体）
* **+mj-ea** - 正文字体东亚文（主要东亚字体）

下面的Java代码演示了如何将拉丁字体分配给主题元素：

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("主题文本格式");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

下面的Java代码显示了如何更改演示主题字体：

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

所有文本框中的字体将被更新。

{{% alert color="primary" title="提示" %}} 

您可能想查看 [PowerPoint字体](/slides/androidjava/powerpoint-fonts/)。

{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint应用程序提供12种预定义背景，但在典型演示文稿中仅保存这12种背景中的3种。

![todo:image_alt_text](presentation-design_8.png)

例如，在您在PowerPoint应用程序中保存演示文稿后，可以运行以下Java代码来查找演示文稿中预定义背景的数量：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("主题的背景填充样式数量为 " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

使用[BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--)属性从[FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme)类，您可以在PowerPoint主题中添加或访问背景样式。

{{% /alert %}} 

以下Java代码显示了如何设置演示文稿的背景：

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**索引指南**：0表示无填充。索引从1开始。

{{% alert color="primary" title="提示" %}} 

您可能想查看 [PowerPoint背景](/slides/androidjava/presentation-background/)。

{{% /alert %}}

## **更改主题效果**

PowerPoint主题通常为每个样式数组包含3个值。这些数组组合成这3种效果：微妙、适中和强烈。例如，当效果应用于特定形状时会产生如下结果：

![todo:image_alt_text](presentation-design_10.png)

使用3个属性([FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--))来自[FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme)类，您可以更改主题中的元素（甚至比PowerPoint中的选项更灵活）。

以下Java代码展示了如何通过改变元素的某些部分来更改主题效果：

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

填充颜色、填充类型、阴影效果等的结果更改：

![todo:image_alt_text](presentation-design_11.png)