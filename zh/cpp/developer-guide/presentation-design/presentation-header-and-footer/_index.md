---
title: 在 C++ 中管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/cpp/presentation-header-and-footer/
keywords:
- 页眉
- 页眉文本
- 页脚
- 页脚文本
- 设置页眉
- 设置页脚
- 讲义
- 备注
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在幻灯片、备注页和讲义上管理页脚、日期时间、幻灯片编号和页眉占位符。"
---
## **概述**

PowerPoint 根据页面类型使用不同的页眉和页脚占位符。Aspose.Slides for C++ 允许您通过页眉/页脚管理接口控制这些占位符的文本和可见性。

可用的占位符取决于作用域：

| 范围 | 页眉 | 页脚 | 日期/时间 | 幻灯片/页码 |
|---|---|---|---|---|
| 常规幻灯片 | 否 | 是 | 是 | 是 |
| 备注母版 | 是 | 是 | 是 | 是 |
| 备注幻灯片 | 是 | 是 | 是 | 是 |
| 讲义母版 | 是 | 是 | 是 | 是 |

常规演示文稿幻灯片没有页眉占位符。页眉仅在备注页和讲义页上可用。对于常规幻灯片，请改用页脚、日期/时间和幻灯片编号占位符。

更改的作用域取决于所使用的管理器。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideheaderfootermanager/) 接口控制单个常规幻灯片。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inotesslideheaderfootermanager/) 接口控制单个备注幻灯片。母版和布局管理器还可以将设置传播到依赖的幻灯片，而 [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) 接口控制讲义母版。

## **在常规幻灯片上设置页脚、日期/时间和幻灯片编号**

对于常规幻灯片，基本工作流是访问每张幻灯片的页眉/页脚管理器，设置页脚和日期/时间文本，启用所需的占位符，并保存演示文稿。幻灯片编号由演示文稿生成，因此您只需控制其可见性。

使用 [`SetFooterText`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) 和 [`SetDateTimeText`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) 设置文本，使用 [`SetFooterVisibility`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/)、[`SetDateTimeVisibility`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) 和 [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) 显示相应的占位符。

以下端到端示例将相同的页脚、日期/时间文本以及幻灯片编号可见性应用于所有常规幻灯片：

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

如果只需要更新一张幻灯片，请通过 [`Presentation::get_Slide`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_slide/) 直接访问该幻灯片，而不是遍历整个幻灯片集合。

## **在备注母版上设置页眉和页脚**

备注母版定义了备注页的公共格式和占位符行为。仅想更改备注母版本身时，请使用 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/) 接口。

以下示例在备注母版上设置页眉、页脚和日期/时间文本，并使该母版上所有受支持的占位符可见：

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

当演示文稿不包含备注母版时，[`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) 方法返回 `nullptr`。

## **将备注母版设置应用于子备注幻灯片**

备注母版可以将页眉和页脚设置应用于自身以及所有依赖的备注幻灯片。当相同设置应跨备注层级传播时，请使用 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/) 上的专用传播方法。

例如，[`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) 和 [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) 会更新备注母版的页眉以及所有子页眉。对应的方法也可用于页脚、日期/时间和幻灯片编号。

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

上述使用的传播方法包括 [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/)、[`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)、[`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)、[`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) 和 [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)。

## **在单个备注幻灯片上设置页眉和页脚**

备注幻灯片属于特定的常规幻灯片。当只想自定义该备注页时，请使用其 [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inotesslideheaderfootermanager/) 接口。

[`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inotesslidemanager/addnotesslide/) 方法返回当前幻灯片的备注幻灯片，并在不存在时创建一个。以下示例配置与第一张演示文稿幻灯片关联的备注页：

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

如果先从备注母版传播设置，然后再更改单个备注幻灯片，后续的每页设置可让您独立地自定义该备注页。

## **在讲义母版上设置页眉和页脚**

讲义页使用讲义母版来提供页眉、页脚、日期/时间和页码占位符。与备注页不同，讲义设置通过讲义母版而不是单独的讲义幻灯片进行管理。

使用 [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) 访问讲义母版。如果不存在，请调用 [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) 创建默认的讲义母版。

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **了解作用域和继承**

选择与您要更改的作用域匹配的页眉/页脚管理器：

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islideheaderfootermanager/) 更改单个常规幻灯片的页脚、日期/时间和幻灯片编号设置。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslideheaderfootermanager/) 控制布局幻灯片，并可将受支持的设置传播到依赖的幻灯片。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslideheaderfootermanager/) 控制常规幻灯片母版，并可将受支持的设置传播到依赖的幻灯片。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslideheaderfootermanager/) 控制备注母版，并可将设置传播到所有依赖的备注幻灯片。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inotesslideheaderfootermanager/) 更改单个备注幻灯片，支持页眉占位符以及页脚、日期/时间和幻灯片编号。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) 更改讲义母版，支持所有四种占位符类型。

当相同设置应在整个层级中使用时，请使用母版或布局的传播功能。当需要为单个页面提供本地设置时，请使用单个幻灯片或备注幻灯片管理器。

## **FAQ**

**我可以在常规幻灯片上添加页眉吗？**

不能。PowerPoint 未为常规幻灯片定义页眉占位符。在常规幻灯片上，请使用页脚、日期/时间和幻灯片编号占位符。页眉占位符仅在备注页和讲义页上可用。

**如果页脚、日期/时间或幻灯片编号占位符不可见怎么办？**

使用相应的页眉/页脚管理器检查其可见性并在需要时启用。例如，[`get_IsFooterVisible`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) 报告页脚占位符是否存在，[`SetFooterVisibility`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) 可更改其可见性。

**如何将幻灯片编号的起始值设置为除 1 之外的其他数字？**

使用 [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/set_firstslidenumber/) 设置起始幻灯片编号。随后，幻灯片编号占位符将使用更新后的编号序列。

**导出为 PDF、图像或 HTML 时，页眉和页脚会发生什么？**

可见的页眉和页脚元素会与演示文稿的其余内容一起在输出格式中呈现。它们的外观取决于所导出的页面类型以及相应的占位符可见性设置。