---
title: 在 C# 中应用或更改幻灯片布局
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
- C#
- .NET
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中管理和自定义幻灯片布局。通过 C# 示例代码探索布局类型、占位符控制、页脚可见性以及布局操作。"
---

## **概述**

幻灯片布局定义了占位框的排列方式以及幻灯片内容的格式。它控制哪些占位符可用以及它们出现的位置。幻灯片布局帮助您快速且一致地设计演示文稿——无论是创建简单还是更复杂的内容。PowerPoint 中最常见的幻灯片布局包括：

**标题幻灯片布局** – 包含两个文本占位符：一个用于标题，另一个用于副标题。

**标题和内容布局** – 顶部有较小的标题占位符，下方有较大的内容占位符（如文本、项目符号、图表、图像等）。

**空白布局** – 不包含任何占位符，允许您从头自行设计幻灯片。

幻灯片布局是母版幻灯片的一部分，母版幻灯片是定义演示文稿布局样式的顶层幻灯片。您可以通过母版幻灯片访问和修改布局幻灯片——可以按类型、名称或唯一 ID 进行操作。或者，您也可以直接在演示文稿中编辑特定的布局幻灯片。

要在 Aspose.Slides for .NET 中使用幻灯片布局，您可以使用：

- 属性，例如 [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) 和 [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) 位于 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类下
- 类型，如 [ILayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/)、[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/)、[ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/)、以及 [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
要了解更多关于使用母版幻灯片的内容，请查看 [Slide Master](/slides/zh/net/slide-master/) 文章。
{{% /alert %}}

## **向演示文稿添加幻灯片布局**

为了自定义幻灯片的外观和结构，您可能需要向演示文稿添加新的布局幻灯片。Aspose.Slides for .NET 允许您检查特定布局是否已经存在，必要时添加新布局，并使用该布局插入幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 访问 [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/)。
1. 检查所需的布局幻灯片是否已经存在于集合中。如果不存在，添加所需的布局幻灯片。
1. 基于新布局幻灯片添加一个空白幻灯片。
1. 保存演示文稿。

以下 C# 代码演示了如何向 PowerPoint 演示文稿添加幻灯片布局：
```cs
// 实例化表示 PowerPoint 文件的 Presentation 类。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // 遍历布局幻灯片类型以选择布局幻灯片。
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // 演示文稿不包含所有布局类型的情况。
        // 演示文稿文件仅包含空白和自定义布局类型。
        // 但是，具有自定义类型的布局幻灯片可能有可识别的名称，
        // 如 “Title”、“Title and Content”等，可用于布局幻灯片选择。
        // 你也可以依赖一组占位符形状类型。
        // 例如，标题幻灯片应仅包含 Title 占位符类型，依此类推。
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 使用添加的布局幻灯片插入一个空白幻灯片。
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // 将演示文稿保存到磁盘。  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **移除未使用的布局幻灯片**

Aspose.Slides 在 [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) 类中提供了 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法，帮助您删除不需要且未使用的布局幻灯片。

以下 C# 代码展示了如何从 PowerPoint 演示文稿中移除布局幻灯片：
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **向幻灯片布局添加占位符**

Aspose.Slides 提供了 [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/placeholdermanager/) 属性，可用于向布局幻灯片添加新的占位符。

此管理器包含以下占位符类型的方法：

| PowerPoint 占位符 | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/) 方法 |
| ------------------ | ------------------------------------------------------------ |
| ![内容](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![内容（垂直）](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![文本](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![文本（垂直）](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![图片](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![图表](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![表格](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![媒体](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![在线图片](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

以下 C# 代码演示了如何向空白布局幻灯片添加新的占位符形状：
```cs
using (var presentation = new Presentation())
{
    // 获取空白布局幻灯片。
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // 获取布局幻灯片的占位符管理器。
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // 向空白布局幻灯片添加不同的占位符。
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // 使用空白布局添加新幻灯片。
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```


结果：

![布局幻灯片上的占位符](add_placeholders.png)

## **设置布局幻灯片的页脚可见性**

在 PowerPoint 演示文稿中，日期、幻灯片编号和自定义文本等页脚元素可以根据幻灯片布局显示或隐藏。Aspose.Slides for .NET 允许您控制这些页脚占位符的可见性。此功能在希望某些布局显示页脚信息，而其他布局保持简洁时非常有用。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 按索引获取布局幻灯片的引用。
1. 将幻灯片页脚占位符设为可见。
1. 将幻灯片编号占位符设为可见。
1. 将日期时间占位符设为可见。
1. 保存演示文稿。

以下 C# 代码展示了如何设置幻灯片页脚的可见性以及相关操作：
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```


## **设置子幻灯片的页脚可见性**

在 PowerPoint 演示文稿中，日期、幻灯片编号和自定义文本等页脚元素可以在母版幻灯片层面进行控制，以确保所有布局幻灯片的一致性。Aspose.Slides for .NET 使您能够在母版幻灯片上设置这些页脚占位符的可见性和内容，并将这些设置传播到所有子布局幻灯片，从而在整个演示文稿中保持统一的页脚信息。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 按索引获取母版幻灯片的引用。
1. 将母版及所有子页脚占位符设为可见。
1. 将母版及所有子幻灯片编号占位符设为可见。
1. 将母版及所有子日期时间占位符设为可见。
1. 保存演示文稿。

以下 C# 代码演示了此操作：
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义整体主题和默认格式，而布局幻灯片为不同类型的内容定义占位符的具体排列方式。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以，您可以从一个演示文稿的 [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) 集合中克隆布局幻灯片，然后使用 `AddClone` 方法将其插入到另一个演示文稿中。

**如果删除仍被幻灯片使用的布局幻灯片会怎样？**

如果尝试删除仍被至少一张幻灯片引用的布局幻灯片，Aspose.Slides 将抛出 [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception/)。为避免此问题，请使用 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)，该方法仅安全地移除未使用的布局幻灯片。