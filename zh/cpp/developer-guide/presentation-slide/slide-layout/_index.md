---
title: 在 C++ 中应用或更改幻灯片布局
linktitle: 幻灯片布局
type: docs
weight: 60
url: /zh/cpp/slide-layout/
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
- 章节标题
- 双内容
- 比较
- 仅标题
- 空白布局
- 带标题的内容
- 带标题的图片
- 标题和垂直文本
- 垂直标题和文本
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中管理和自定义幻灯片布局。通过 C++ 示例代码探索布局类型、占位符控制和页脚可见性。"
---

## **概述**

幻灯片布局定义了占位框的排列方式以及幻灯片内容的格式。它控制哪些占位符可用以及它们出现的位置。幻灯片布局帮助您快速且一致地设计演示文稿——无论您创建的是简单的还是更复杂的内容。PowerPoint 中最常见的一些幻灯片布局包括：

**标题幻灯片布局** – 包含两个文本占位符：一个用于标题，另一个用于副标题。

**标题和内容布局** – 在顶部具有较小的标题占位符，下面有较大的占位符用于主要内容（如文本、项目符号、图表、图像等）。

**空白布局** – 不包含任何占位符，允许您从头开始完全控制幻灯片设计。

幻灯片布局是幻灯片母板的一部分，母板是定义演示文稿布局样式的顶层幻灯片。您可以通过幻灯片母板访问和修改布局幻灯片——可以按类型、名称或唯一 ID。或者，您也可以直接在演示文稿中编辑特定的布局幻灯片。

要在 Aspose.Slides for Android 中使用幻灯片布局，您可以使用：

- 在 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类下的诸如 [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) 和 [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) 方法
- 诸如 [ILayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/), 和 [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslideheaderfootermanager/) 等类型

{{% alert title="Info" color="info" %}}
要了解更多关于使用母版幻灯片的内容，请查看 [Slide Master](/slides/zh/cpp/slide-master/) 文章。
{{% /alert %}}

## **向演示文稿添加幻灯片布局**

要自定义幻灯片的外观和结构，您可能需要向演示文稿添加新的布局幻灯片。Aspose.Slides for Android 允许您检查特定布局是否已经存在，如有需要可添加新的布局，并使用它插入基于该布局的幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 访问 [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/)。
3. 检查所需的布局幻灯片是否已存在于集合中。如果不存在，则添加所需的布局幻灯片。
4. 基于新布局幻灯片添加一个空白幻灯片。
5. 保存演示文稿。

以下 C++ 代码演示了如何向 PowerPoint 演示文稿添加幻灯片布局：
```cpp
// 实例化表示 PowerPoint 文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // 演示文稿不包含所有布局类型的情况。
    // 演示文稿仅包含空白和自定义布局类型。
    // 但是，具有自定义类型的布局幻灯片可能有可识别的名称，
    // 如 “Title”“Title and Content”等，可用于布局幻灯片选择。
    // 也可以依赖一组占位符形状类型。
    // 例如，标题幻灯片应仅包含 Title 占位符类型，依此类推。
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// 使用添加的布局幻灯片插入一个空白幻灯片。
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// 将演示文稿保存到磁盘。
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **删除未使用的布局幻灯片**

Aspose.Slides 提供了来自 [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类的 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法，以便您删除不需要且未使用的布局幻灯片。

以下 C++ 代码展示了如何从 PowerPoint 演示文稿中删除布局幻灯片：
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **向布局幻灯片添加占位符**

Aspose.Slides 提供了 [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) 方法，允许您向布局幻灯片添加新的占位符。

此管理器包含以下占位符类型的方法：

| PowerPoint 占位符 | [ILayoutPlaceholderManager] 方法 |
| ----------------- | -------------------------------- |
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

以下 C++ 代码演示了如何向空白布局幻灯片添加新的占位符形状：
```cpp
auto presentation = MakeObject<Presentation>();

// 获取空白布局幻灯片。
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// 获取布局幻灯片的占位符管理器。
auto placeholderManager = layout->get_PlaceholderManager();

// 向空白布局幻灯片添加不同的占位符。
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![布局幻灯片上的占位符](add_placeholders.png)

## **设置布局幻灯片的页脚可见性**

在 PowerPoint 演示文稿中，页脚元素（如日期、幻灯片编号和自定义文本）可以根据布局幻灯片的不同而显示或隐藏。Aspose.Slides for Android 允许您控制这些页脚占位符的可见性。这在您希望某些布局显示页脚信息，而其他布局保持简洁时非常有用。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引获取布局幻灯片的引用。
3. 将幻灯片页脚占位符设为可见。
4. 将幻灯片编号占位符设为可见。
5. 将日期时间占位符设为可见。
6. 保存演示文稿。

以下 C++ 代码展示了如何设置幻灯片页脚的可见性并执行相关操作：
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```


## **设置子幻灯片的页脚可见性**

在 PowerPoint 演示文稿中，日期、幻灯片编号和自定义文本等页脚元素可以在母版幻灯片层面进行控制，以确保所有布局幻灯片的一致性。Aspose.Slides for Android 使您能够在母版幻灯片上设置这些页脚占位符的可见性和内容，并将这些设置传播到所有子布局幻灯片，从而在整个演示文稿中保持统一的页脚信息。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引获取母版幻灯片的引用。
3. 将母版及所有子页脚占位符设为可见。
4. 将母版及所有子幻灯片编号占位符设为可见。
5. 将母版及所有子日期时间占位符设为可见。
6. 保存演示文稿。

以下 C++ 代码演示了此操作：
```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义整体主题和默认格式，而布局幻灯片为不同类型的内容定义占位符的具体排列方式。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以，您可以通过 [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) 方法获取的布局幻灯片集合克隆布局幻灯片，然后使用 `AddClone` 方法将其插入到另一个演示文稿中。

**如果我删除仍被幻灯片使用的布局幻灯片会怎样？**

如果尝试删除仍被至少一个幻灯片引用的布局幻灯片，Aspose.Slides 将抛出 [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/)。为避免此情况，请使用 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)，此方法仅安全地删除未被使用的布局幻灯片。