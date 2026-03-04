---
title: 在 .NET 中管理演示主题
linktitle: 演示主题
type: docs
weight: 10
url: /zh/net/presentation-theme/
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
- 演示
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中掌握演示主题，以创建、定制并转换具有一致品牌形象的 PowerPoint 文件。"
---
演示主题定义了设计元素的属性。当您选择演示主题时，实际上是选择了一组特定的视觉元素及其属性。

在 PowerPoint 中，主题包括颜色、[字体](/slides/zh/net/powerpoint-fonts/)、[背景样式](/slides/zh/net/presentation-background/) 和效果。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用一组特定颜色。如果您不喜欢这些颜色，可以通过为主题应用新颜色来更改它们。Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh/net/aspose.slides/schemecolor/) 枚举下提供了相应的值，以便选择新的主题颜色。

以下 C# 代码演示如何更改主题的强调颜色：

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

为了进一步演示颜色更改操作，我们创建另一个元素并将强调颜色（来自首次操作）分配给它。随后在主题中更改该颜色：

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

新颜色会自动应用于两个元素。

### **从附加调色板设置主题颜色**

当您对主主题颜色(1)应用亮度变换时，会生成来自附加调色板(2)的颜色。随后您可以设置和获取这些主题颜色。

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

    // 强调色 4, 更亮 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // 强调色 4, 更亮 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // 强调色 4, 更亮 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // 强调色 4, 更暗 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 强调色 4, 更暗 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **将 `SchemeColor` 映射到 `IColorScheme` 颜色**

在使用 [SchemeColor](https://reference.aspose.com/slides/zh/net/aspose.slides/schemecolor/) 时，您可能会注意到它包含以下主题颜色值：

`Background1`、`Background2`、`Text1` 和 `Text2`。

然而，`Presentation.MasterTheme.ColorScheme` 返回 [IColorScheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/icolorscheme/)，它将相应的颜色呈现为：

`Dark1`、`Dark2`、`Light1` 和 `Light2`。

此差异仅在于命名。这些值指向相同的主题颜色槽，映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` 与 `Dark`/`Light` 之间不存在动态转换。它们仅是同一主题颜色的备用名称。

这种命名差异源自 Microsoft Office 的术语。旧版 Office 使用 `Dark 1`、`Light 1`、`Dark 2` 和 `Light 2`，而新版 UI 则将相同槽显示为 `Text 1`、`Background 1`、`Text 2` 和 `Background 2`。

## **更改主题字体**

为了让您为主题及其他用途选择字体，Aspose.Slides 使用了以下特殊标识符（类似于 PowerPoint 中使用的）：

* **+mn-lt** - 正文字体拉丁文（Minor Latin Font）
* **+mj-lt** - 标题拉丁字体（Major Latin Font）
* **+mn-ea** - 正文东亚字体（Minor East Asian Font）
* **+mj-ea** - 标题东亚字体（Minor East Asian Font）

以下 C# 代码演示如何将拉丁字体分配给主题元素：

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

以下 C# 代码演示如何更改演示文稿的主题字体：

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

例如，在 PowerPoint 应用中保存演示文稿后，您可以运行以下 C# 代码以查找演示文稿中预定义背景的数量：

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

使用来自 [FormatScheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme/) 类的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) 属性，您可以在 PowerPoint 主题中添加或访问背景样式。 

{{% /alert %}}

以下 C# 代码演示如何为演示文稿设置背景：

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**索引说明**：0 表示无填充。索引从 1 开始。

{{% alert color="primary" title="TIP" %}} 

您可能想查看 [PowerPoint 背景](/slides/zh/net/presentation-background/)。

{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常为每个样式数组包含 3 个值。这些数组组合成 3 种效果：柔和、适中和强烈。例如，将这些效果应用于特定形状时的结果如下：

![todo:image_alt_text](presentation-design_10.png)

通过使用来自 [FormatScheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme) 类的 3 个属性（[FillStyles](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme/fillstyles)、[LineStyles](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme/linestyles)、[EffectStyles](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme/effectstyles)），您可以更改主题中的元素（比 PowerPoint 的选项更灵活）。

以下 C# 代码演示如何通过更改元素的部分来更改主题效果：

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

由此产生的填充颜色、填充类型、阴影效果等更改如下：

![todo:image_alt_text](presentation-design_11.png)

## **常见问题**

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**

可以。Aspose.Slides 支持幻灯片级别的主题覆盖，您可以仅对该幻灯片应用局部主题，同时保持母版主题不变（通过 [SlideThemeManager](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/slidethememanager/)）。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方式是什么？**

[Clone slides](/slides/zh/net/clone-slides/) 与其母版一起复制到目标演示文稿。这会保留原始母版、布局以及相关主题，从而保持外观一致。

**如何查看所有继承和覆盖后的“实际”值？**

使用 API 的 ["effective" 视图](/slides/zh/net/shape-effective-properties/) 来查看主题、颜色、字体、效果等的实际值。这些视图返回在应用母版以及任何局部覆盖后解析出的最终属性。