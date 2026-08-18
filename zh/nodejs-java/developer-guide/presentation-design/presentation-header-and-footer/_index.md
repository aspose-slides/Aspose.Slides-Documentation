---
title: 在 JavaScript 中管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/nodejs-java/presentation-header-and-footer/
keywords:
- 页眉
- 页眉文本
- 页脚
- 页脚文本
- 设置页眉
- 设置页脚
- 讲义
- 注释
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Node.js via Java 在幻灯片、注释页和讲义上管理页脚、日期时间、幻灯片编号和页眉占位符。"
---
## **概述**

PowerPoint 根据页面类型使用不同的页眉和页脚占位符。Aspose.Slides for Node.js via Java 让您通过页眉/页脚管理器类控制这些占位符的文本和可见性。

可用的占位符取决于作用域：

| 作用域 | 页眉 | 页脚 | 日期/时间 | 幻灯片/页码 |
|---|---|---|---|---|
| 普通幻灯片 | 否 | 是 | 是 | 是 |
| 注释母版 | 是 | 是 | 是 | 是 |
| 注释幻灯片 | 是 | 是 | 是 | 是 |
| 讲义母版 | 是 | 是 | 是 | 是 |

普通演示文稿幻灯片没有页眉占位符。页眉在注释页和讲义页上可用。对于普通幻灯片，请使用页脚、日期/时间和幻灯片编号占位符。

更改的作用域取决于您使用的管理器。[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideheaderfootermanager/) 类控制单个普通幻灯片。[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notesslideheaderfootermanager/) 类控制单个注释幻灯片。母版和布局管理器还可以将设置传播到所属幻灯片，而[`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) 类控制讲义母版。

## **在普通幻灯片上设置页脚、日期/时间和幻灯片编号**

对于普通幻灯片，基本工作流程是访问每张幻灯片的页眉/页脚管理器，设置页脚和日期/时间文本，启用所需的占位符，然后保存演示文稿。幻灯片编号由演示文稿生成，您只需要控制其可见性。

使用[`setFooterText`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText)和[`setDateTimeText`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText)设置文本，使用[`setFooterVisibility`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility)和[`setSlideNumberVisibility`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility)显示相应的占位符。

以下端到端示例将相同的页脚、日期/时间文本和幻灯片编号可见性应用到所有普通幻灯片：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需更新单张幻灯片，请通过[`getSlides`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getslides/) 方法直接访问该幻灯片，而不是遍历整个集合。

## **在注释母版上设置页眉和页脚**

注释母版定义了注释页的通用格式和占位符行为。希望仅更改注释母版本身时，请使用[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) 类。

以下示例在注释母版上设置页眉、页脚和日期/时间文本，并使该母版上的所有受支持占位符可见：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

当演示文稿不包含注释母版时，[`getMasterNotesSlide`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) 方法返回 `null`。

## **将注释母版设置应用于子注释幻灯片**

注释母版可以将页眉和页脚设置应用于自身以及所有依赖的注释幻灯片。当相同的设置需要在注释层级中传播时，请在[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) 上使用专用的传播方法。

例如，[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) 和 [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) 更新注释母版页眉及所有子页眉。对应的方法也可用于页脚、日期/时间和幻灯片编号。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

上述使用的传播方法包括 [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) 和 [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility)。

## **在单个注释幻灯片上设置页眉和页脚**

注释幻灯片属于特定的普通幻灯片。若只想自定义该注释页，请使用其[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notesslideheaderfootermanager/) 类。

[`addNotesSlide`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) 方法返回当前幻灯片的注释幻灯片，如果不存在则创建。以下示例配置与第一张演示文稿幻灯片关联的注释页：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果先从注释母版传播设置，然后再更改单个注释幻灯片，后面的每页设置可以让您独立定制该注释页。

## **在讲义母版上设置页眉和页脚**

讲义页使用讲义母版的页眉、页脚、日期/时间和页码占位符。与注释页不同，讲义设置通过讲义母版而非单个讲义幻灯片进行管理。

使用[`getMasterHandoutSlide`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) 访问讲义母版。如果不存在，请调用[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) 创建默认的讲义母版。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **理解作用域和继承**

选择匹配您要更改的作用域的页眉/页脚管理器：

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideheaderfootermanager/) 更改单个普通幻灯片的页脚、日期/时间和幻灯片编号设置。
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) 控制布局幻灯片，并可将受支持的设置传播到依赖的幻灯片。
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslideheaderfootermanager/) 控制普通幻灯片母版，并可将受支持的设置传播到依赖的幻灯片。
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) 控制注释母版并可将设置传播到所有依赖的注释幻灯片。
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notesslideheaderfootermanager/) 更改单个注释幻灯片，支持页眉占位符以及页脚、日期/时间和幻灯片编号。
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) 更改讲义母版，支持所有四种占位符类型。

当相同设置应在整个层级中生效时，使用母版或布局的传播功能；当仅需在单页上进行本地设置时，使用单个幻灯片或注释幻灯片管理器。

## **常见问题**

**可以在普通幻灯片上添加页眉吗？**

不能。PowerPoint 未为普通幻灯片定义页眉占位符。请在普通幻灯片上使用页脚、日期/时间和幻灯片编号占位符。页眉占位符仅在注释页和讲义页上可用。

**如果页脚、日期/时间或幻灯片编号占位符不可见怎么办？**

使用相应的页眉/页脚管理器检查其可见性并在需要时启用。例如，[`isFooterVisible`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) 报告页脚占位符是否存在，[`setFooterVisibility`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslideheaderfootomanager/#setFooterVisibility) 则更改其可见性。

**如何让幻灯片编号从除 1 之外的其他值开始？**

调用演示文稿的[`setFirstSlideNumber`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) 方法。随后幻灯片编号占位符将使用更新后的编号序列。

**在导出为 PDF、图像或 HTML 时，页眉和页脚会怎样？**

可见的页眉和页脚元素会与演示文稿的其他内容一起渲染到输出格式中。它们的呈现取决于导出的页面类型以及相应的占位符可见性设置。