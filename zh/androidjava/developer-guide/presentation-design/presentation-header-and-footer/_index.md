---
title: 在 Android 上管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 管理幻灯片、备注页和讲义中的页脚、日期/时间、幻灯片编号和页眉占位符。"
---
## **概述**

PowerPoint 根据页面类型使用不同的页眉和页脚占位符。Aspose.Slides for Android via Java 通过页眉/页脚管理器接口让您可以控制这些占位符的文本和可见性。

可用的占位符取决于范围：

| 范围 | 页眉 | 页脚 | 日期/时间 | 幻灯片/页码 |
|---|---|---|---|---|
| 普通幻灯片 | 否 | 是 | 是 | 是 |
| 备注母版 | 是 | 是 | 是 | 是 |
| 备注幻灯片 | 是 | 是 | 是 | 是 |
| 讲义母版 | 是 | 是 | 是 | 是 |

普通演示幻灯片没有页眉占位符。页眉仅在备注页和讲义页上可用。对于普通幻灯片，请改为使用页脚、日期/时间和幻灯片编号占位符。

更改的范围取决于使用的管理器。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideheaderfootermanager/) 接口控制单个普通幻灯片。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) 接口控制单个备注幻灯片。母版和版式管理器还可以将设置传播到从属幻灯片，而[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) 接口控制讲义母版。

## **在普通幻灯片上设置页脚、日期/时间和幻灯片编号**

对于普通幻灯片，基本工作流是访问每张幻灯片的页眉/页脚管理器，设置页脚和日期/时间文本，启用所需的占位符，然后保存演示文稿。幻灯片编号由演示文稿自动生成，您只需控制其可见性。

使用[`setFooterText`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-)和[`setDateTimeText`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-)设置文本，使用[`setFooterVisibility`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-)和[`setSlideNumberVisibility`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-)显示相应的占位符。

以下端到端示例将相同的页脚、日期/时间文本和幻灯片编号可见性应用于所有普通幻灯片：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需更新一张幻灯片，请通过[`getSlides`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getSlides--) 方法直接访问该幻灯片，而不是遍历整个集合。

## **在备注母版上设置页眉和页脚**

备注母版定义了备注页的公共格式和占位符行为。当您只想更改备注母版本身时，请使用[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) 接口。

以下示例在备注母版上设置页眉、页脚和日期/时间文本，并使该母版上所有支持的占位符可见：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

当演示文稿不包含备注母版时，[`getMasterNotesSlide`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) 方法返回 `null`。

## **将备注母版设置应用于子备注幻灯片**

备注母版可以将页眉和页脚设置应用于自身以及所有从属的备注幻灯片。当相同设置应跨备注层级传播时，请使用[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) 上的专用传播方法。

例如，[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) 和[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) 更新备注母版页眉及所有子页眉。对页脚、日期/时间和幻灯片编号也提供了等效的方法。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

上述使用的传播方法包括[`setFooterAndChildFootersText`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)以及[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-)。

## **在单个备注幻灯片上设置页眉和页脚**

备注幻灯片属于特定的普通幻灯片。当您只想自定义该备注页时，请使用其[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) 接口。

[`addNotesSlide`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) 方法返回当前幻灯片的备注幻灯片，如果尚不存在则会创建。以下示例配置与第一张演示幻灯片关联的备注页：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果先从备注母版传播设置，然后再更改单个备注幻灯片，后续的每页设置可让您独立自定义该备注页。

## **在讲义母版上设置页眉和页脚**

讲义页使用讲义母版的页眉、页脚、日期/时间和页码占位符。与备注页不同，讲义设置通过讲义母版而不是单个讲义幻灯片进行管理。

使用[`getMasterHandoutSlide`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) 方法访问讲义母版。如果不存在，请调用[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) 创建默认讲义母版。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **理解范围和继承**

请选择与您要更改的范围匹配的页眉/页脚管理器：

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideheaderfootermanager/) 更改单个普通幻灯片的页脚、日期/时间和幻灯片编号设置。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) 控制版式幻灯片，并可将支持的设置传播到从属幻灯片。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) 控制普通幻灯片母版，并可将支持的设置传播到从属幻灯片。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) 控制备注母版，并可将设置传播到所有从属备注幻灯片。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) 更改单个备注幻灯片，并支持页眉占位符以及页脚、日期/时间和幻灯片编号。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) 更改讲义母版，并支持所有四种占位符类型。

当相同设置应在整个层级中应用时，使用母版或版式的传播功能。需要对单页进行本地设置时，使用单个幻灯片或备注幻灯片管理器。

## **常见问题**

**可以在普通幻灯片上添加页眉吗？**

不能。PowerPoint 未为普通幻灯片定义页眉占位符。在普通幻灯片上请使用页脚、日期/时间和幻灯片编号占位符。页眉占位符仅在备注页和讲义页上可用。

**如果页脚、日期/时间或幻灯片编号占位符不可见怎么办？**

使用相应的页眉/页脚管理器检查其可见性并在需要时启用。例如，[`isFooterVisible`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) 报告页脚占位符是否存在，[`setFooterVisibility`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) 用于更改其可见性。

**如何让幻灯片编号从除 1 之外的值开始？**

调用演示文稿的[`setFirstSlideNumber`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 方法。随后幻灯片编号占位符将使用更新后的编号序列。

**导出为 PDF、图像或 HTML 时，页眉和页脚会怎样？**

可见的页眉和页脚元素会与演示文稿的其他内容一起在输出格式中渲染。它们的显示效果取决于导出页面的类型以及相应占位符的可见性设置。