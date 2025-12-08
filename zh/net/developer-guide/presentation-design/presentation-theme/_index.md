---
title: 演示主题
type: docs
weight: 10
url: /zh/net/presentation-theme/
keywords: "主题, PowerPoint 主题, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "使用 C# 或 .NET 的 PowerPoint 演示主题"
---

演示主题定义了设计元素的属性。当您选择演示主题时，实际上是在选择一组特定的视觉元素及其属性。

在 PowerPoint 中，主题包括颜色、[字体](/slides/zh/net/powerpoint-fonts/)、[背景样式](/slides/zh/net/presentation-background/)和效果。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用特定的颜色集合。如果您不喜欢这些颜色，可以通过为主题应用新颜色来更改它们。为帮助您选择新的主题颜色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) 枚举中提供了值。

以下 C# 代码演示了如何更改主题的强调颜色：
```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```


您可以通过以下方式确定结果颜色的实际值：
```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (颜色 [A=255, R=128, G=100, B=162])
```


为了进一步演示颜色更改操作，我们创建另一个元素并将（来自初始操作的）强调颜色分配给它。随后我们在主题中更改颜色：
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


新颜色会自动应用到两个元素上。

### **从附加调色板设置主题颜色**

当您对主主题颜色 (1) 应用亮度变换时，会生成来自附加调色板 (2) 的颜色。随后可以设置和获取这些主题颜色。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主主题颜色  
**2** - 来自附加调色板的颜色。

以下 C# 代码演示了从主主题颜色获取附加调色板颜色并在形状中使用的操作：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 强调色 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // 强调色 4，亮度 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // 强调色 4，亮度 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // 强调色 4，亮度 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // 强调色 4，更暗 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 强调色 4，更暗 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```


## **更改主题字体**

为了让您为主题及其他用途选择字体，Aspose.Slides 使用以下特殊标识符（类似于 PowerPoint 中使用的标识符）：

* **+mn-lt** - 正文字体 拉丁文（次要拉丁字体）
* **+mj-lt** - 标题字体 拉丁文（主要拉丁字体）
* **+mn-ea** - 正文字体 东亚（次要东亚字体）
* **+mj-ea** - 标题字体 东亚（主要东亚字体）

以下 C# 代码演示了如何将拉丁字体分配给主题元素：
```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


以下 C# 代码演示了如何更改演示文稿的主题字体：
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


所有文本框中的字体将被更新。

{{% alert color="primary" title="TIP" %}} 
您可能想查看 [PowerPoint 字体](/slides/zh/net/powerpoint-fonts/)。 
{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 应用提供 12 种预定义背景，但在典型的演示文稿中仅保存其中的 3 种背景。

![todo:image_alt_text](presentation-design_8.png)

例如，在 PowerPoint 应用中保存演示文稿后，您可以运行以下 C# 代码来查找演示文稿中预定义背景的数量：
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
使用来自 [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) 类的 [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) 属性，您可以在 PowerPoint 主题中添加或访问背景样式。 
{{% /alert %}}

以下 C# 代码演示了如何为演示文稿设置背景：
```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**索引指南**：0 表示无填充。索引从 1 开始。

{{% alert color="primary" title="TIP" %}} 
您可能想查看 [PowerPoint 背景](/slides/zh/net/presentation-background/)。 
{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常为每个样式数组包含 3 个值。这些数组组合成三种效果：细微、适中和强烈。例如，当这些效果应用于特定形状时，结果如下：

![todo:image_alt_text](presentation-design_10.png)

使用 [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) 类中的三个属性（[FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles)、[LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles)、[EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)），您可以更改主题中的元素（灵活程度甚至超过 PowerPoint 中的选项）。

以下 C# 代码演示了如何通过修改元素的部分来更改主题效果：
```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```


结果会在填充颜色、填充类型、阴影效果等方面产生变化：

![todo:image_alt_text](presentation-design_11.png)

## **常见问题**

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**  
可以。Aspose.Slides 支持幻灯片级别的主题覆盖，因此您可以仅在该幻灯片上应用本地主题，同时保持母版主题不变（通过 [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)）。

**将主题从一个演示文稿安全地迁移到另一个演示文稿的最佳方式是什么？**  
将 [克隆幻灯片](/slides/zh/net/clone-slides/) 与其母版一起复制到目标演示文稿中。这会保留原始的母版、版式以及相关的主题，从而保持外观一致。

**如何查看所有继承和覆盖后的“实际”值？**  
使用 API 的[“实际”视图](/slides/zh/net/shape-effective-properties/) 来查看主题/颜色/字体/效果。这些视图会在应用母版以及任何本地覆盖后返回解析后的最终属性。