---
title: 在 .NET 中管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在幻灯片、备注页和讲义上管理页脚、日期时间、幻灯片编号和页眉占位符。"
---
## **概述**

PowerPoint 根据页面类型使用不同的页眉和页脚占位符。Aspose.Slides for .NET 允许您通过页眉/页脚管理器接口控制这些占位符的文本和可见性。

可用的占位符取决于作用域：

| 范围 | 页眉 | 页脚 | 日期/时间 | 幻灯片/页码 |
|---|---|---|---|---|
| 常规幻灯片 | 否 | 是 | 是 | 是 |
| 备注母版 | 是 | 是 | 是 | 是 |
| 备注幻灯片 | 是 | 是 | 是 | 是 |
| 讲义母版 | 是 | 是 | 是 | 是 |

常规演示幻灯片没有页眉占位符。页眉仅在备注页和讲义页上可用。对于常规幻灯片，请改用页脚、日期/时间和幻灯片编号占位符。

更改的作用域取决于使用的管理器。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/islideheaderfootermanager/) 接口控制单个常规幻灯片。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/inotesslideheaderfootermanager/) 接口控制单个备注幻灯片。母版和布局管理器还可以将设置传播到从属幻灯片，而[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterhandoutslideheaderfootermanager/) 接口控制讲义母版。

## **在常规幻灯片上设置页脚、日期/时间和幻灯片编号**

对于常规幻灯片，基本工作流程是访问每个幻灯片的页眉/页脚管理器，设置页脚和日期/时间文本，启用所需的占位符，然后保存演示文稿。幻灯片编号由演示文稿生成，您只需控制其可见性。

使用[`SetFooterText`](https://reference.aspose.com/slides/zh/net/aspose.slides/baseslideheaderfootermanager/setfootertext/)和[`SetDateTimeText`](https://reference.aspose.com/slides/zh/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/)设置文本，使用[`SetFooterVisibility`](https://reference.aspose.com/slides/zh/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/)、[`SetDateTimeVisibility`](https://reference.aspose.com/slides/zh/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/)和[`SetSlideNumberVisibility`](https://reference.aspose.com/slides/zh/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/)显示相应的占位符。

以下完整示例将相同的页脚、日期/时间文本和幻灯片编号可见性应用于所有常规幻灯片：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

如果只需更新一张幻灯片，请直接通过[`Slides`](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slides/zh/)集合访问该幻灯片，而不是遍历整个集合。

## **在备注母版上设置页眉和页脚**

备注母版定义了备注页的通用格式和占位符行为。当您只想更改备注母版本身时，请使用[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/imasternotesslideheaderfootermanager/) 接口。

以下示例在备注母版上设置页眉、页脚和日期/时间文本，并使该母版上所有受支持的占位符可见：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

如果演示文稿不包含备注母版，[`MasterNotesSlide`](https://reference.aspose.com/slides/zh/net/aspose.slides/imasternotesslidemanager/masternotesslide/) 属性将返回 `null`。

## **将备注母版设置应用于子备注幻灯片**

备注母版可以将页眉和页脚设置应用于自身以及所有从属备注幻灯片。当需要在整个备注层级中使用相同设置时，请使用 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/imasternotesslideheaderfootermanager/) 的专用传播方法。

例如，[`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) 和 [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) 更新备注母版的页眉以及所有子页眉。对应的方法也可用于页脚、日期/时间和幻灯片编号。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

上述使用的传播方法包括 [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/zh/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/)、[`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)、[`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)、[`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) 以及 [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)。

## **在单个备注幻灯片上设置页眉和页脚**

备注幻灯片属于特定的常规幻灯片。当您只想自定义该备注页时，请使用其[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/inotesslideheaderfootermanager/) 接口。

[`AddNotesSlide`](https://reference.aspose.com/slides/zh/net/aspose.slides/inotesslidemanager/addnotesslide/) 方法返回当前幻灯片的备注幻灯片，如果尚不存在则创建。以下示例配置与第一张演示幻灯片关联的备注页：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

如果先从备注母版传播设置，然后再更改单个备注幻灯片，后续的每张幻灯片设置即可独立定制该备注页。

## **在讲义母版上设置页眉和页脚**

讲义页使用讲义母版来提供页眉、页脚、日期/时间和页码占位符。与备注页不同，讲义设置通过讲义母版而不是单个讲义幻灯片进行管理。

使用[`MasterHandoutSlide`](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) 属性访问讲义母版。如果不存在，请调用[`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) 创建默认的讲义母版。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **了解作用域和继承**

选择与您要更改的作用域相匹配的页眉/页脚管理器：

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/islideheaderfootermanager/) 更改单个常规幻灯片的页脚、日期/时间和幻灯片编号设置。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslideheaderfootermanager/) 控制布局幻灯片并可将支持的设置传播到从属幻灯片。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslideheaderfootermanager/) 控制普通幻灯片母版并可将支持的设置传播到从属幻灯片。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/imasternotesslideheaderfootermanager/) 控制备注母版并可将设置传播到所有从属备注幻灯片。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/inotesslideheaderfootermanager/) 更改单个备注幻灯片，支持页眉占位符以及页脚、日期/时间和幻灯片编号。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterhandoutslideheaderfootermanager/) 更改讲义母版，支持全部四种占位符类型。

当相同设置应在整个层级中应用时，使用母版或布局的传播方式。需要对单页进行本地设置时，使用单个幻灯片或备注幻灯片管理器。

## **常见问题解答**

**我可以在常规幻灯片上添加页眉吗？**

不能。PowerPoint 未为常规幻灯片定义页眉占位符。在常规幻灯片上使用页脚、日期/时间和幻灯片编号占位符。页眉占位符仅在备注页和讲义页上可用。

**如果页脚、日期/时间或幻灯片编号占位符不可见怎么办？**

使用相应的页眉/页脚管理器检查其可见性并在需要时启用。例如，[`IsFooterVisible`](https://reference.aspose.com/slides/zh/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) 报告页脚占位符是否存在，[`SetFooterVisibility`](https://reference.aspose.com/slides/zh/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) 则更改其可见性。

**如何让幻灯片编号从非 1 的值开始？**

设置演示文稿的 [`FirstSlideNumber`](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/firstslidenumber/) 属性。随后幻灯片编号占位符将使用更新后的编号序列。

**导出为 PDF、图像或 HTML 时，页眉和页脚会怎样？**

可见的页眉和页脚元素会与演示文稿的其余内容一起在输出格式中渲染。它们的外观取决于导出的页面类型以及相应的占位符可见性设置。