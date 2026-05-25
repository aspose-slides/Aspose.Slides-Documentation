---
title: 在 .NET 中管理演示文稿幻灯片母版
linktitle: 幻灯片母版
type: docs
weight: 80
url: /zh/net/slide-master/
keywords:
- 幻灯片母版
- 母版幻灯片
- PPT 母版幻灯片
- 多个母版幻灯片
- 比较母版幻灯片
- 背景
- 占位符
- 克隆母版幻灯片
- 复制母版幻灯片
- 生成副本母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理幻灯片母版：访问、编辑、克隆、比较和删除 PowerPoint 与 OpenDocument 演示文稿中的母版幻灯片。"
---
## **概述**

一个 **幻灯片母版** 定义了一组幻灯片共享的设计设置。它可以包含通用形状、徽标、背景、文本样式、主题设置和页脚设置。在 PowerPoint 中，编辑幻灯片母版是保持演示文稿一致性的常用方式，无需在每张幻灯片上重复相同的格式。

Aspose.Slides for .NET 支持相同的模型。一个演示文稿可以包含一个或多个母版幻灯片，每个母版幻灯片可以包含多个布局幻灯片。普通幻灯片通常不会直接引用母版幻灯片，而是使用布局幻灯片，而该布局幻灯片属于某个母版幻灯片。

层次结构如下：

1. **幻灯片母版** - 定义共享的设计和主题。  
1. **布局幻灯片** - 定义占位符的具体排列和布局级别的格式。  
1. **普通幻灯片** - 包含实际的演示内容并使用一个布局幻灯片。

![主幻灯片、布局幻灯片和普通幻灯片的层次结构](slide-master_2.jpg)

在 Aspose.Slides 中，幻灯片母版由 [IMasterSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslide/) 接口表示。演示文稿中的所有母版幻灯片可通过 [Presentation.Masters](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/masters/) 集合访问，该集合实现了 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslidecollection/)。

{{% alert color="info" title="Inheritance" %}}
当相同属性在多个层级上定义时，层级更具体的会覆盖更通用的。例如，如果母版幻灯片和布局幻灯片都定义了背景，则基于该布局的幻灯片使用布局的背景。有关布局幻灯片的更多信息，请参阅 [Apply or Change Slide Layouts](/slides/zh/net/slide-layout/)。
{{% /alert %}}

## **访问幻灯片母版**

在 PowerPoint 中，您可以通过 **视图** > **幻灯片母版** 打开幻灯片母版视图。

![PowerPoint“视图”选项卡上的“幻灯片母版”命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `Masters` 集合访问母版幻灯片：

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

您还可以通过普通幻灯片的布局获取其使用的母版幻灯片：

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **幻灯片母版包含的内容**

母版幻灯片是类幻灯片对象。它实现了 [IBaseSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/)，因此它公开了普通幻灯片和布局幻灯片使用的许多相同属性。母版特有的成员列在 [IMasterSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslide/) API 页面上。

常用的母版幻灯片成员包括：

| 成员 | 用途 |
| --- | --- |
| `Background` | 设置母版级别的幻灯片背景。 |
| `Shapes` | 存储放置在母版上的形状，如徽标、图片框和共享文本。 |
| `LayoutSlides` | 存储属于该母版的布局幻灯片。 |
| `ThemeManager` | 提供对母版主题 API 的访问。 |
| `HeaderFooterManager` | 控制母版及其子布局的页眉、页脚、日期和幻灯片编号。 |
| `GetDependingSlides` | 返回通过布局依赖于该母版的普通幻灯片。 |

## **向幻灯片母版添加图片**

向母版幻灯片添加图片后，使用该母版布局的幻灯片都会显示该图片。这对于徽标、水印、装饰条等重复的视觉元素非常有用。

下面的示例向第一张母版幻灯片添加徽标：

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

有关图片框的更多信息，请参阅 [Picture Frame](/slides/zh/net/picture-frame/)。

## **使用占位符**

占位符通常在布局幻灯片上定义。母版幻灯片提供共享的样式和主题，布局幻灯片继承这些设置，同时决定哪些占位符可用以及它们的位置。

在 PowerPoint 中，占位符命令位于幻灯片母版视图中。

![PowerPoint 幻灯片母版视图中的“插入占位符”命令](slide-master_5.png)

要在 Aspose.Slides 中添加新占位符，请操作属于母版的布局幻灯片：

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

您也可以格式化已存在于母版幻灯片上的占位符形状。下面的示例查找标题占位符并应用线性渐变填充：

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![普通幻灯片继承的已格式化标题占位符](slide-master_8.png)

有关占位符和文本格式化的更多选项，请参阅 [Set Prompt Text in Placeholder](/slides/zh/net/manage-placeholder/) 和 [Text Formatting](/slides/zh/net/text-formatting/)。

## **更改幻灯片母版背景**

母版背景会被布局和未覆盖它的幻灯片继承。下面的示例为第一张母版幻灯片设置纯色背景：

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

相关主题，请参阅 [Presentation Background](/slides/zh/net/presentation-background/) 和 [Presentation Theme](/slides/zh/net/presentation-theme/)。

## **将幻灯片母版克隆到另一个演示文稿**

使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslidecollection/addclone/) 将母版幻灯片复制到另一个演示文稿中。复制后的母版随后可被目标演示文稿中的布局和幻灯片使用。

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

如果需要连同母版一起克隆普通幻灯片，请参阅 [Clone Slides](/slides/zh/net/clone-slides/)。

## **添加多个幻灯片母版**

一个演示文稿可以包含多个母版幻灯片。当不同章节需要不同的品牌、页面结构或主题设置时，这非常有用。

![PowerPoint 插入和管理母版幻灯片的命令](slide-master_9.jpg)

下面的示例克隆默认母版，为克隆母版设置不同的背景，在该克隆母版下创建布局，并基于该布局添加新幻灯片：

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **比较幻灯片母版**

可以使用从 [IBaseSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/) 继承的 `Equals` 方法比较母版幻灯片。比较检查结构和静态内容，如形状、文本、格式、动画以及其他幻灯片设置。它不比较唯一标识符（如幻灯片 ID）或动态占位符值（如当前日期）。

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

更多信息，请参阅 [Compare Presentation Slides](/slides/zh/net/compare-slides/)。

## **将幻灯片母版视图设为默认视图**

在 [ViewProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/viewproperties/) 上使用 `LastView` 属性可控制 PowerPoint 首次打开的视图。下面的示例在幻灯片母版视图中打开演示文稿：

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

更多视图设置，请参阅 [Save Presentation](/slides/zh/net/save-presentation/)。

## **删除未使用的幻灯片母版**

演示文稿有时会包含已不再被任何普通幻灯片使用的母版幻灯片。删除未使用的母版可以减小文件大小并简化模板维护。

使用 [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/zh/net/aspose.slides/masterslidecollection/removeunused/) 从 `Masters` 集合中删除未使用的母版：

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

您也可以使用低代码的 [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法：

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **常见问题解答**

**幻灯片母版和布局幻灯片有什么区别？**

幻灯片母版定义共享的设计设置，如主题、背景、通用形状和文本样式。布局幻灯片属于某个母版，定义占位符的具体排列。普通幻灯片使用布局幻灯片，从而同时继承布局和母版的设置。

**一个演示文稿可以包含多个幻灯片母版吗？**

可以。一个演示文稿可以包含多个幻灯片母版。当不同章节需要不同的视觉体系或品牌时，请使用多个母版。

**应该在母版幻灯片还是布局幻灯片上添加占位符？**

大多数情况下，在布局幻灯片上添加占位符。将在母版上放置共享的视觉元素和共享格式，然后在布局上放置内容占位符，普通幻灯片使用这些布局。

**我可以删除仍在使用的母版幻灯片吗？**

不能。拥有依赖幻灯片的母版不能直接安全删除。请先将这些幻灯片移动到另一个母版的布局下，或使用仅删除未使用母版的清理方法。