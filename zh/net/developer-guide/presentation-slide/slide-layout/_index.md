---
title: 在 .NET 中应用或更改幻灯片布局
linktitle: 幻灯片布局
type: docs
weight: 60
url: /zh/net/slide-layout/
keywords:
- 幻灯片布局
- 内容布局
- 占位符
- 演示文稿设计
- 幻灯片设计
- 未使用的布局
- 页脚可见性
- 标题幻灯片
- 标题和内容
- 部分标题
- 双内容
- 对比
- 仅标题
- 空白布局
- 带标题的内容
- 带标题的图片
- 标题和垂直文本
- 垂直标题和文本
- PowerPoint
- OpenDocument
- 演示文稿
- C#
- .NET
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中应用、创建和修改幻灯片布局，添加占位符，移除未使用的布局，并控制页脚可见性。"
---
## **概述**

幻灯片布局定义了标题、文本、图片、图表和表格等占位符的位置和格式。应用布局可为幻灯片提供一致的结构，同时允许每张幻灯片包含各自的内容。

最常用的布局包括：

- **标题幻灯片**：包含标题和副标题占位符。
- **标题和内容**：包含标题占位符和通用内容占位符。
- **空白**：不包含内容占位符，适用于所有形状将手动定位的情况。

## **了解布局继承**

演示文稿有三个相关层级：

1. 一个[母版幻灯片](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslide/)定义主题、共享的格式、背景和公共对象。
2. 一个[布局幻灯片](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/)属于母版，并定义特定的占位符排列。
3. 一个[普通幻灯片](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/)使用一种布局并存储为该幻灯片输入的内容。

普通幻灯片从其布局继承主题和格式，布局又从其母版继承。直接在普通幻灯片上设置的值会覆盖该层级继承的值。创建普通幻灯片时，其占位符形状会根据所选布局生成，而输入到这些占位符的内容则属于普通幻灯片。

在从布局创建幻灯片之前，需要先向布局添加所需的占位符。之后向布局添加另一个占位符不会自动向已有的普通幻灯片添加相应的占位符形状。

此关系有两个重要的后果：

- 更改布局上继承的格式或现有占位符的几何形状可能会更新所有依赖该布局的幻灯片。在编辑已在使用的布局之前，请检查其依赖的幻灯片并审阅生成的演示文稿。
- 仍被幻灯片使用的布局无法被删除。请先将其依赖的幻灯片重新分配到其他布局，或仅删除未使用的布局。

有关此层级顶层的更多信息，请参阅[幻灯片母版](/slides/zh/net/slide-master/)。

要在单个幻灯片或共享布局上隐藏继承的徽标或装饰性母版形状，请参阅[控制母版图形的可见性](/slides/zh/net/slide-master/)。示例比较了使用相同母版的两张幻灯片。

## **选择并应用幻灯片布局**

当演示文稿遵循标准的 PowerPoint 布局定义时，请使用布局类型。布局名称可由用户编辑并支持本地化，因此基于名称的选择并不可靠，除非您控制源模板。

以下示例在第一个母版上查找**Title and Content**布局。如果该布局不可用，则有意回退到**Blank**。第二个空检查是必需的，因为演示文稿可能仅包含自定义布局。随后通过[ISlide.LayoutSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/layoutslide/)属性将选定的布局应用于第一张普通幻灯片。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

更改幻灯片的布局不会删除直接添加到幻灯片的普通形状。然而，占位符位置、继承的格式以及现有占位符与新布局之间的对应关系可能会改变，因此在切换差异较大的布局时请检查输出。

## **添加布局幻灯片**

选择和创建是分开的操作。前面的示例仅选择了现有布局，并未创建新布局。要创建布局，请在目标母版的布局集合上调用[IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/zh/net/aspose.slides/masterlayoutslidecollection/add/)方法。

以下示例始终添加一个名为`Report Title and Content`的新**Title and Content**布局，然后基于该布局添加一张普通幻灯片。布局名称在集合内必须唯一。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

仅在模板确实需要另一个可重用结构时才添加布局。如果已有合适的布局，请选择并复用它，而不是创建重复的布局。

## **向布局幻灯片添加占位符**

[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/placeholdermanager/)属性提供了一个[ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutplaceholdermanager/)，用于向布局添加占位符形状。

| PowerPoint 占位符                | `ILayoutPlaceholderManager` 方法 |
| -------------------------------- | -------------------------------- |
| ![内容](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![内容（垂直）](contentV.png)    | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![文本](text.png)                | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![文本（垂直）](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![图片](picture.png)             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![图表](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![表格](table.png)               | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)        | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![媒体](media.png)               | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![在线图片](onlineImage.png)     | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

以下示例验证**Blank**布局是否存在，向其添加四个占位符，然后创建使用该修改后布局的普通幻灯片。顺序是有意的：占位符在创建普通幻灯片之前添加，以便 Aspose.Slides 能在该幻灯片上生成相应的占位符形状。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

结果：

![布局幻灯片上的占位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
更改继承的格式或现有布局占位符的几何形状可能会影响依赖的幻灯片。新添加的布局占位符不会回填到已有的普通幻灯片中。请在演示文稿的副本上测试布局更改，并检查每个依赖的幻灯片。
{{% /alert %}}

## **移除未使用的布局幻灯片**

使用[Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)方法移除没有普通幻灯片引用的布局。该方法会保留仍在使用中的布局。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

要移除特定的布局，首先使用其[HasDependingSlides](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/hasdependingslides/)属性或[GetDependingSlides](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/getdependingslides/)方法。在调用[ILayoutSlide.Remove](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/remove/)之前，请重新分配任何依赖的幻灯片。尝试移除正在使用的布局会抛出[PptxEditException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxeditexception/)。

## **控制布局幻灯片的页脚可见性**

布局拥有自己的页脚、幻灯片编号和日期时间占位符。使用[ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/headerfootermanager/)属性可对单个布局的这些占位符进行控制。例如，内容布局应显示页脚而标题布局则不显示时，这非常有用。

以下示例安全地选择一个布局并使其页脚元素可见：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **在母版及其子布局上控制页脚可见性**

要在母版层级中应用一致的页脚设置，请使用[IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslide/headerfootermanager/)属性。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslideheaderfootermanager/)的传播方法作用于母版及其依赖的布局幻灯片和普通幻灯片；它们不会仅针对单个普通幻灯片。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义演示文稿的主题和共享格式。布局幻灯片属于母版，定义一种可重用的占位符排列。普通幻灯片使用这些布局并存储特定于幻灯片的内容。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以。使用[AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/globallayoutslidecollection/addclone/)方法将副本添加到目标集合。在跨演示文稿复制时，还需检查源布局使用的字体、主题、图像和其他资源。

**当我修改已在使用的布局时会发生什么？**

依赖的幻灯片会继承布局的更改，除非它们在本地覆盖了受影响的格式或对象。因此，占位符的几何形状和继承的样式可能一次性在多个幻灯片上改变。编辑布局前，请使用[GetDependingSlides](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/getdependingslides/)确定受影响的幻灯片。

**如果我移除仍在使用的布局会怎样？**

Aspose.Slides 会抛出[PptxEditException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxeditexception/)。请先重新分配依赖的幻灯片，或使用[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)仅移除未被引用的布局。