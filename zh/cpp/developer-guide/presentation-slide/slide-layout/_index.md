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
- 节标题
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
description: "在 Aspose.Slides for C++ 中应用、创建和修改幻灯片布局，添加占位符，删除未使用的布局，并控制页脚可见性。"
---
## **概览**

幻灯片布局定义了标题、文本、图片、图表和表格等占位符的位置和格式。应用布局可为幻灯片提供一致的结构，同时允许每张幻灯片包含自己的内容。

最常见的布局包括：

- **标题幻灯片**：包含标题和副标题占位符。
- **标题和内容**：包含标题占位符和通用内容占位符。
- **空白**：不包含任何内容占位符，适用于需要手动定位每个形状的情况。

## **了解布局继承**

演示文稿具有三个相关层级：

1. A [master slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [layout slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [normal slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/) uses one layout and stores the content entered for that slide.

普通幻灯片从其布局继承主题和格式，布局则从其母版继承。直接在普通幻灯片上设置的值会覆盖该层级继承来的值。创建普通幻灯片时，其占位符形状会根据所选布局生成，而填写到这些占位符中的内容属于普通幻灯片本身。

在从布局创建幻灯片之前，请先向布局添加所需的占位符。之后再向布局添加占位符并不会自动在已有的普通幻灯片中生成相应的占位符形状。

此关系有两个重要的影响：

- 更改布局上继承的格式或已有占位符的几何形状会更新所有依赖该布局的幻灯片。编辑已在使用的布局前，请检查其依赖的幻灯片并审阅生成的演示文稿。
- 正在被幻灯片使用的布局不能被删除。必须先将依赖的幻灯片重新分配到其他布局，或仅删除未使用的布局。

有关此层次结构顶层的更多信息，请参阅[幻灯片母版](/slides/zh/cpp/slide-master/)。

## **选择并应用幻灯片布局**

当演示文稿使用标准 PowerPoint 布局定义时，请使用布局类型。布局名称可编辑且可本地化，因此除非您控制源模板，否则基于名称的选择可靠性较低。

以下示例在第一个母版上查找 **标题和内容**。如果该布局不可用，则有意回退到 **空白**。第二个空检查是必需的，因为演示文稿可能仅包含自定义布局。随后通过 [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/set_layoutslide/) 方法将选定的布局应用于第一张普通幻灯片。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

更改幻灯片的布局不会删除直接添加到幻灯片的普通形状。不过，占位符位置、继承的格式以及现有占位符与新布局之间的对应关系可能会改变，因此在切换差异较大的布局时请检查输出。

## **添加布局幻灯片**

选择和创建是分开的操作。前面的示例仅选择了已有布局，并未创建新布局。若要创建布局，请在目标母版的布局集合上调用 [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterlayoutslidecollection/add/) 方法。

以下示例始终添加一个名为 `Report Title and Content` 的新 **标题和内容** 布局，然后基于该布局添加一张普通幻灯片。布局名称在集合内必须唯一。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

仅当模板真正需要另一个可复用结构时才添加布局。如果已经存在合适的布局，请选择并复用，而不是创建重复的布局。

## **向布局幻灯片添加占位符**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) 方法提供一个 [ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/) 用于向布局添加占位符形状。

| PowerPoint 占位符                | `ILayoutPlaceholderManager` 方法 |
| --------------------------------- | -------------------------------- |
| ![内容](content.png)              | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![内容（垂直）](contentV.png)     | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![文本](text.png)                 | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![文本（垂直）](textV.png)        | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![图片](picture.png)              | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![图表](chart.png)                | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![表格](table.png)                | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)         | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![媒体](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![在线图片](onlineImage.png)      | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

以下示例验证 **空白** 布局是否存在，向其添加四个占位符，然后创建使用该修改后布局的普通幻灯片。顺序是有意为之：先添加占位符，再创建普通幻灯片，以便 Aspose.Slides 能在该幻灯片上生成相应的占位符形状。

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![布局幻灯片上的占位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
更改继承的格式或现有布局占位符的几何形状可能影响依赖的幻灯片。新添加的布局占位符不会回填到已有的普通幻灯片中。请在演示文稿的副本上测试布局更改，并检查每个依赖的幻灯片。
{{% /alert %}}

## **删除未使用的布局幻灯片**

使用 [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法删除没有普通幻灯片引用的布局。该方法会保留仍在使用的布局。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

若要删除特定布局，首先使用其 [get_HasDependingSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) 方法或 [GetDependingSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslide/getdependingslides/) 方法。在调用 [ILayoutSlide::Remove](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslide/remove/) 之前请重新分配所有依赖的幻灯片。尝试删除正在使用的布局会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pptxeditexception/)。

## **控制布局幻灯片的页脚可见性**

布局拥有自己的页脚、幻灯片编号和日期时间占位符。使用 [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) 方法可对单个布局的这些占位符进行控制。例如，内容布局应显示页脚而标题布局不应显示时，此功能非常有用。

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **控制母版及其子布局的页脚可见性**

要在整个母版层次结构中统一页脚设置，请使用 [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslide/get_headerfootermanager/) 方法。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslideheaderfootermanager/) 的传播方法作用于母版及其依赖的布局幻灯片和普通幻灯片；它们不会仅针对单个普通幻灯片。

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常见问题解答**

**母版幻灯片与布局幻灯片有什么区别？**

母版幻灯片定义演示文稿的主题和共享格式。布局幻灯片隶属于母版，定义一种可复用的占位符排列。普通幻灯片使用这些布局并存储特定于幻灯片的内容。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以。使用 [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/igloballayoutslidecollection/addclone/) 方法将副本添加到目标集合。在跨演示文稿复制时，还需验证源布局使用的字体、主题、图像及其他资源。

**当我修改已在使用的布局时会发生什么？**

依赖的幻灯片会继承布局的更改，除非它们在本地覆盖了受影响的格式或对象。占位符的几何形状和继承的样式可能会在许多幻灯片上一并改变。编辑布局前请使用 [GetDependingSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslide/getdependingslides/) 确认受影响的幻灯片。

**如果删除仍在使用的布局会怎样？**

Aspose.Slides 会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pptxeditexception/)。请先将依赖的幻灯片重新分配，或使用 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 只删除未被引用的布局。