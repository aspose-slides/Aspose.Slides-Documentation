---
title: 管理 .NET 中的演示文稿主题
linktitle: 演示主题
type: docs
weight: 10
url: /zh/net/presentation-theme/
keywords:
- PowerPoint 主题
- 演示文稿主题
- 幻灯片主题
- 设置主题
- 更改主题
- 管理主题
- 外部主题
- THMX
- 主题颜色
- 附加调色板
- 主题字体
- 主题样式
- 主题效果
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用母版演示文稿主题来创建、定制和转换带有一致品牌的 PowerPoint 文件。"
---
## **介绍**

演示文稿主题定义了一套协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存为固定值，这样更改主题时可以一次性更新许多对象。

在 Aspose.Slides 中，演示文稿级别的主题可以通过 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/mastertheme/) 属性访问。演示文稿还可以在更低层级包含主题覆盖。母版可以通过 [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/masterthememanager/overridetheme/) 覆盖演示文稿主题，版式可以通过 [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) 覆盖其继承的主题，单个幻灯片也可以这样做。实际上，幻灯片的有效主题是通过以下继承链解析的：演示文稿主题 → 母版覆盖 → 版式覆盖 → 幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

下面的章节展示了最常用的主题工作流：检查主题、更改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/mastertheme/) 对象公开主题的 [ColorScheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/mastertheme/fontscheme/) 和 [FormatScheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/mastertheme/formatscheme/)。在更改这些集合之前先检查它们尤其有用，因为来自外部源的演示文稿可能在样式条目数量和内容上有所不同。

以下示例读取主要主题属性并报告主题中存储了多少背景、填充、线条和效果样式：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

如果文件使用了多个母版，请不要假设每张幻灯片都有相同的有效主题。检查与幻灯片关联的母版，并在可能存在版式或幻灯片覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文本可以引用 [SchemeColor](https://reference.aspose.com/slides/zh/net/aspose.slides/schemecolor/) 枚举中的逻辑颜色。当你更改主题的 [IColorScheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/icolorscheme/) 中对应的条目时，所有仍引用该主题颜色的对象都会解析为新值。使用直接 RGB 颜色的对象不会受到主题颜色更新的影响。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色改为红色，保存演示文稿，重新打开，并打印有效填充颜色：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

因为矩形仍链接到 `Accent4`，主题更改后其可见颜色会变为红色。如果在形状上将方案颜色替换为直接颜色，之后对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色变换来生成更亮和更暗的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/zh/net/aspose.slides/colortransformoperation/) 暴露这些变换。

![主主题颜色以及从附加调色板生成的更亮和更暗的颜色](additional-palette-colors.png)

**1** - 主主题颜色。

**2** - 基于主主题颜色生成的更亮和更暗的变体。

以下示例基于 `Accent4` 创建六个矩形，对其中五个应用亮度变换，并保存结果：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

这些变体仍基于主题颜色。如果随后 `Accent4` 发生更改，变换后的颜色会根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `IColorScheme` 槽**

[SchemeColor](https://reference.aspose.com/slides/zh/net/aspose.slides/schemecolor/) 枚举使用 `Text1`、`Background1`、`Text2` 和 `Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/icolorscheme/) 将相同的主题槽公开为 `Dark1`、`Light1`、`Dark2`、`Light2`。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题槽的别名；它们不是从一种形式动态转换到另一种形式的值。

## **更改主题字体**

主题字体方案包含用于标题的主要字体集和用于正文的次要字体集。[FontScheme.Major](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/fontscheme/major/) 和 [FontScheme.Minor](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/fontscheme/minor/) 属性公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体拉丁文（次要拉丁字体）
* `+mj-lt` - 标题字体拉丁文（主要拉丁字体）
* `+mn-ea` - 正文字体东亚文（次要东亚字体）
* `+mj-ea` - 标题字体东亚文（主要东亚字体）

下面的示例创建一个使用主要拉丁主题字体的标题和一个使用次要拉丁主题字体的正文行，然后更改主题字体并保存结果：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

标题遵循主要字体，正文遵循次要字体。使用显式字体名称而非主题标识符的文本在主题字体方案更改时不会自动切换。

主要和次要字体集合还可以包含针对特定书写系统的字体映射，如西里尔文、阿拉伯文、日文、格鲁吉亚文和塔纳文。要检查、添加、替换或移除这些映射，请参阅 [Script-Specific Theme Fonts](/slides/zh/net/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
有关演示文稿字体的更多信息，请参阅 [PowerPoint Fonts](/slides/zh/net/powerpoint-fonts/)。
{{% /alert %}}

## **复制或应用主题**

以下工作流解决不同的主题相关问题。

### **将外部主题应用于主母版的从属幻灯片**

当你拥有 PowerPoint 主题文件（`.thmx`）并希望重新样式化依赖特定母版的所有幻灯片时，请使用 [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/)。从 [Presentation.Masters](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/masters/) 集合中选择母版，该集合实现了 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslidecollection/)，并将主题文件路径传递给该方法。

该方法执行以下操作：

1. 基于所选母版创建一个新的母版幻灯片。
1. 将外部主题应用到新母版。
1. 将新母版分配给先前依赖所选母版的所有幻灯片。
1. 返回新创建的 [IMasterSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslide/)。

下面的示例将外部主题应用于依赖第一个母版的幻灯片，保存演示文稿并重新打开结果：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

无效、损坏或不受支持的主题可能会导致 [PptxException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxexception/) 或其格式相关子类。请验证用户提供的路径，处理文件系统访问失败，并仅在主题成功应用后才保存演示文稿。

只有依赖所选母版的幻灯片会被重新分配。与其他母版关联的幻灯片保留其现有母版和主题。支持主题的颜色、字体、填充、线条、背景和效果会根据外部主题解析。直接分配的颜色、字体、填充等显式格式可能保持不变。版式级和幻灯片级覆盖也可能优先于从新母版继承的值。

主题可能引用运行时环境中不可用的字体。为确保一致的渲染和导出，请安装所需字体、通过 [custom font sources](/slides/zh/net/custom-font/) 提供，或配置 [font substitution](/slides/zh/net/font-substitution/)。

这是一种直接的母版级工作流：方法接受 `.thmx` 文件路径，无需手动创建幻灯片级或版式级主题覆盖。

### **在多母版演示文稿中应用不同的外部主题**

当事先不知道相关母版时，可通过 [ISlide.LayoutSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/layoutslide/) 和 [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/masterslide/) 从代表性幻灯片获取。应用任何主题之前请先保存原始母版的引用，因为每次调用都会在演示文稿中创建另一个母版。

下面的示例使用来自两个区段的幻灯片定位它们的母版，并对每组应用不同的外部主题：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

第一次调用仅影响依赖 `firstGroupMaster` 的幻灯片，第二次调用仅影响依赖 `secondGroupMaster` 的幻灯片。属于其他母版的幻灯片不会被重新样式化。

### **在移动幻灯片时保留源主题**

如果希望将幻灯片移动到另一个演示文稿并保留其原始设计，请使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslidecollection/addclone/) 将源母版克隆到目标演示文稿中，然后使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/addclone/) 将幻灯片连同克隆的母版一起克隆。这样可以将母版、其版式以及关联的主题一起携带。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

在需要在目标中保持外观完全相同的情况下，这是首选工作流。仅将内容克隆到不相关的目标母版上可能会更改受主题驱动的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持当前的母版和版式，请从源主题初始化幻灯片级覆盖。使用 [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/overridetheme/initfontschemefrom/) 和 [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/overridetheme/initformatschemefrom/) 方法将三大主题组件复制到覆盖中。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

此操作会更改该幻灯片使用的主题，而不会影响其他幻灯片继承的主题。要移除本地覆盖并恢复继承值，请调用 [OverrideTheme.Clear](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/overridetheme/clear/)。

### **将主题覆盖应用于版式**

版式级覆盖适用于使用该版式的幻灯片，除非特定幻灯片拥有自己的覆盖。相同的初始化方法可以通过版式的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/layoutslidethememanager/) 使用：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

当许多版式和幻灯片应共享相同的基础设计时使用母版或演示文稿级主题；当某个版式族需要不同样式时使用版式覆盖；仅在真正例外时使用幻灯片覆盖。过多的幻灯片级覆盖会使后期全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在 [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) 中。PowerPoint 在 UI 中可以呈现比此集合实际存储的填充定义更多的背景选项，因为 UI 能将主题填充与主题颜色和其他样式引用组合使用。

![PowerPoint 演示文稿主题的背景样式库](presentation-design_8.png)

在使用背景样式之前，请检查存储的集合以及当前的 [Background.StyleIndex](https://reference.aspose.com/slides/zh/net/aspose.slides/background/styleindex/)。`StyleIndex` 为 `0` 表示没有主题填充；正值表示主题背景样式引用。这不同于直接对 .NET 集合进行索引时 `[0]` 表示第一项。不要假设每个演示文稿都有相同数量的背景填充样式。

下面的示例报告可用的背景填充计数，将主题背景引用分配给第一个母版，并保存演示文稿：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

最终视觉结果取决于母版引用的主题条目以及版式或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要了解继承后最终背景时，请使用 [Background.GetEffective](https://reference.aspose.com/slides/zh/net/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="Warning" %}}
不要把 `StyleIndex` 当作零基集合索引。另外，避免硬编码来自某个文件的样式编号并假设它在另一个文件中具有相同外观；主题样式定义是针对特定演示文稿的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅 [Presentation Background](/slides/zh/net/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含独立的 [FillStyles](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme/fillstyles/)、[LineStyles](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme/linestyles/) 和 [EffectStyles](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/formatscheme/effectstyles/) 集合。典型的 Office 主题通常包含三个主要样式条目，分别对应细微、适中和强烈的视觉效果，但代码应检查每个集合，而不是假设固定数量。

![对同一形状应用细微、适中和强烈主题效果](presentation-design_10.png)

在 C# 中访问这些集合时，集合索引是从零开始的：`[0]` 是第一项，`[2]` 是第三项。形状的样式引用索引是另一概念，通过 [IShapeStyle](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapestyle/) 暴露。修改主题样式会影响引用该主题样式的形状；使用直接格式的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外阴影，并保存结果：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

对于引用这些槽位的形状，第一条主题线条样式将变为红色，第三条主题填充样式将变为实心森林绿，第三条效果样式将获得距离为 10 点的外阴影。具体视觉结果仍取决于每个形状引用的样式槽位以及是否有直接格式覆盖主题。

![更改线条、填充和阴影设置后主题效果样式](presentation-design_11.png)

## **读取有效主题值**

原始主题对象告诉你在特定层级上定义了什么。有效值告诉你幻灯片或形状在继承和本地覆盖解析后实际使用的内容。对于幻灯片，调用 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)。对于背景，使用 [Background.GetEffective](https://reference.aspose.com/slides/zh/net/aspose.slides/background/geteffective/)，对于填充，使用 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh/net/aspose.slides/fillformat/geteffective/)。

下面的示例读取幻灯片的有效主题、背景以及第一形状的填充：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

使用有效数据进行渲染诊断、验证和比较。如果仅检查 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/mastertheme/)，可能会错过母版、版式、幻灯片或形状的覆盖，从而改变最终外观。

## **常见问题**

**将外部主题应用于演示文稿是否会影响每一张幻灯片？**

不会。[IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) 只会重新分配依赖所选母版的幻灯片。使用其他母版的幻灯片保留其现有主题。

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**

可以。使用幻灯片的 [SlideThemeManager](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/slidethememanager/) 并初始化其覆盖主题。更改仅局限于该幻灯片，其他幻灯片继续继承各自的主题。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方式是什么？**

在移动幻灯片并保留源外观时，使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslidecollection/addclone/) 将源母版克隆到目标演示文稿，然后使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/addclone/) 将幻灯片连同该母版一起克隆。这会把母版、版式和主题一起保留下来。

**如何查看继承和覆盖后得到的有效值？**

对幻灯片或版式主题使用 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)，对格式对象如背景和填充分别使用对应的有效数据方法，例如 [Background.GetEffective](https://reference.aspose.com/slides/zh/net/aspose.slides/background/geteffective/) 和 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh/net/aspose.slides/fillformat/geteffective/)。这些 API 会在继承和覆盖应用后返回解析后的值。