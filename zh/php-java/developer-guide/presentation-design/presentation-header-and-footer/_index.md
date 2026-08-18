---
title: 在 PHP 中管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/php-java/presentation-header-and-footer/
keywords:
- 页眉
- 页眉文字
- 页脚
- 页脚文字
- 设置页眉
- 设置页脚
- 讲义
- 备注
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在幻灯片、备注页和讲义上管理页脚、日期/时间、幻灯片编号和页眉占位符。"
---
## **概述**

PowerPoint 根据页面类型使用不同的页眉和页脚占位符。Aspose.Slides for PHP via Java 通过页眉/页脚管理器类让您能够控制这些占位符的文本和可见性。

可用的占位符取决于作用域：

| 范围 | 标题 | 页脚 | 日期/时间 | 幻灯片/页码 |
|---|---|---|---|---|
| 常规幻灯片 | No | Yes | Yes | Yes |
| 备注母版 | Yes | Yes | Yes | Yes |
| 备注幻灯片 | Yes | Yes | Yes | Yes |
| 讲义母版 | Yes | Yes | Yes | Yes |

常规演示幻灯片没有标题占位符。标题仅在备注页和讲义页上可用。对于常规幻灯片，请使用页脚、日期/时间和页码占位符。

更改的作用域取决于使用的管理器。[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideheaderfootermanager/) 类控制单个常规幻灯片。[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notesslideheaderfootermanager/) 类控制单个备注幻灯片。母版和布局管理器还能将设置传播到从属幻灯片，而[`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) 类控制讲义母版。

## **在常规幻灯片上设置页脚、日期/时间和幻灯片编号**

对于常规幻灯片，基本工作流是访问每张幻灯片的页眉/页脚管理器，设置页脚和日期/时间文本，启用所需的占位符，然后保存演示文稿。幻灯片编号由演示文稿自动生成，您只需控制其可见性。

使用[`setFooterText`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/)和[`setDateTimeText`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/)来设置文本，使用[`setFooterVisibility`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/)以及[`setSlideNumberVisibility`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/)来显示相应的占位符。

下面的端到端示例将相同的页脚、日期/时间文本以及幻灯片编号可见性应用到所有常规幻灯片：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果只需更新一张幻灯片，请直接通过[`getSlides`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getslides/)方法访问该幻灯片，而不是遍历整个集合。

## **在备注母版上设置页眉和页脚**

备注母版定义了备注页的公共格式和占位符行为。要仅更改备注母版本身，请使用[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/) 类。

下面的示例在备注母版上设置页眉、页脚和日期/时间文本，并使该母版上所有受支持的占位符可见：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

当演示文稿不包含备注母版时，[`getMasterNotesSlide`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) 方法返回 `null`。

## **将备注母版设置应用于子备注幻灯片**

备注母版可以将页眉和页脚设置应用于自身以及所有从属的备注幻灯片。当需要在备注层次结构中统一设置时，请使用[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/) 的专用传播方法。

例如，[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/)和[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/)会更新备注母版的页眉以及所有子页眉。页脚、日期/时间和幻灯片编号也提供了相应的方法。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

上面使用的传播方法还有[`setFooterAndChildFootersText`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/)以及[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)。

## **在单个备注幻灯片上设置页眉和页脚**

备注幻灯片属于特定的常规幻灯片。若只想自定义该备注页，请使用其[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notesslideheaderfootermanager/) 类。

[`addNotesSlide`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notesslidemanager/addnotesslide/) 方法返回当前幻灯片的备注幻灯片，如果不存在则会创建。下面的示例配置与第一张演示幻灯片关联的备注页：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果您先从备注母版传播设置，然后再更改单个备注幻灯片，则后面的每张幻灯片设置可让您独立定制该备注页。

## **在讲义母版上设置页眉和页脚**

讲义页使用讲义母版来管理其页眉、页脚、日期/时间和页码占位符。与备注页不同，讲义设置是通过讲义母版而非单个讲义幻灯片来管理的。

使用[`getMasterHandoutSlide`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) 方法访问讲义母版。如果不存在，请调用[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) 来创建默认的讲义母版。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **了解作用域和继承**

选择与您要更改的作用域相匹配的页眉/页脚管理器：

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideheaderfootermanager/) 更改单个常规幻灯片的页脚、日期/时间和幻灯片编号设置。
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslideheaderfootermanager/) 控制布局幻灯片，并可将受支持的设置传播到从属幻灯片。
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslideheaderfootermanager/) 控制普通幻灯片母版，并可将受支持的设置传播到从属幻灯片。
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masternotesslideheaderfootermanager/) 控制备注母版，并可将设置传播到所有从属备注幻灯片。
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notesslideheaderfootermanager/) 更改单个备注幻灯片，并支持页眉占位符以及页脚、日期/时间和幻灯片编号。
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) 更改讲义母版，支持所有四种占位符类型。

当相同设置应在整个层次结构中应用时，使用母版或布局的传播功能。需要针对某一页面进行局部设置时，则使用单独的幻灯片或备注幻灯片管理器。

## **常见问题解答**

**我可以在常规幻灯片上添加页眉吗？**

不能。PowerPoint 并未为常规幻灯片定义页眉占位符。请在常规幻灯片上使用页脚、日期/时间和页码占位符。页眉占位符仅在备注页和讲义页上可用。

**如果页脚、日期/时间或页码占位符不可见怎么办？**

使用相应的页眉/页脚管理器检查其可见性并在需要时启用它。例如，[`isFooterVisible`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) 可报告页脚占位符是否存在，[`setFooterVisibility`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) 可更改其可见性。

**如何让幻灯片编号从除 1 之外的值开始？**

调用演示文稿的[`setFirstSlideNumber`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/setfirstslidenumber/) 方法。之后幻灯片编号占位符将使用更新后的编号序列。

**导出为 PDF、图像或 HTML 时，页眉和页脚会怎样？**

可见的页眉和页脚元素会与演示文稿的其余内容一起在输出格式中渲染。它们的显示效果取决于导出的页面类型以及对应的占位符可见性设置。