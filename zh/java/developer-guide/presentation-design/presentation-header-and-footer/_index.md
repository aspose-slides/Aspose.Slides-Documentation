---
title: 在 Java 中管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 管理幻灯片、注释页和讲义中的页脚、日期/时间、幻灯片编号和页眉占位符。"
---
## **概述**

PowerPoint 根据页面类型使用不同的页眉和页脚占位符。Aspose.Slides for Java 通过页眉/页脚管理器接口让您控制这些占位符的文本和可见性。

可用的占位符取决于作用域：

| 范围 | 标题 | 页脚 | 日期/时间 | 幻灯片/页号 |
|---|---|---|---|---|
| 常规幻灯片 | 否 | 是 | 是 | 是 |
| 注释母版 | 是 | 是 | 是 | 是 |
| 注释幻灯片 | 是 | 是 | 是 | 是 |
| 讲义母版 | 是 | 是 | 是 | 是 |

常规演示文稿幻灯片没有标题占位符。标题占位符在注释页面和讲义页面上可用。对于常规幻灯片，请使用页脚、日期/时间和幻灯片编号占位符。

更改的作用域取决于使用的管理器。[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islideheaderfootermanager/) 接口控制单个常规幻灯片。[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/inotesslideheaderfootermanager/) 接口控制单个注释幻灯片。母版和布局管理器还可以将设置传播到从属幻灯片，而 [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) 接口控制讲义母版。

## **在常规幻灯片上设置页脚、日期/时间和幻灯片编号**

对于常规幻灯片，基本工作流是访问每张幻灯片的页眉/页脚管理器，设置页脚和日期/时间文本，启用所需的占位符，然后保存演示文稿。幻灯片编号由演示文稿自动生成，您只需控制其可见性。

使用 [`setFooterText`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) 和 [`setDateTimeText`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) 设置文本，使用 [`setFooterVisibility`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-)、[`setDateTimeVisibility`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-) 和 [`setSlideNumberVisibility`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) 显示相应的占位符。

下面的端到端示例将相同的页脚、日期/时间文本和幻灯片编号可见性应用于所有常规幻灯片：

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

如果只需要更新一张幻灯片，请直接通过 [`getSlides`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSlides--) 方法访问该幻灯片，而不是遍历整个集合。

## **在注释母版上设置页眉和页脚**

注释母版定义了注释页面的通用格式和占位符行为。当您只想更改注释母版本身时，请使用 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/) 接口。

下面的示例在注释母版上设置页眉、页脚和日期/时间文本，并使该母版上所有受支持的占位符可见：

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

当演示文稿不包含注释母版时，[`getMasterNotesSlide`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) 方法返回 `null`.

## **将注释母版设置应用于子注释幻灯片**

注释母版可以将页眉和页脚设置应用于自身以及所有从属注释幻灯片。当相同的设置应在注释层级中传播时，请使用 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/) 上的专用传播方法。

例如，[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) 和 [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) 更新注释母版的页眉以及所有子页眉。对应的方法也适用于页脚、日期/时间和幻灯片编号。

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

上面使用的传播方法包括 [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)、[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)、[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)、[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)，以及 [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **在单个注释幻灯片上设置页眉和页脚**

注释幻灯片属于特定的常规幻灯片。当您只想自定义该注释页面时，请使用其 [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/inotesslideheaderfootermanager/) 接口。

[`addNotesSlide`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) 方法返回当前幻灯片的注释幻灯片，如果不存在则创建一个。下面的示例配置与第一张演示文稿幻灯片关联的注释页面：

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

如果先从注释母版传播设置，然后再更改单个注释幻灯片，后续的每张幻灯片设置可让您独立自定义该注释页面。

## **在讲义母版上设置页眉和页脚**

讲义页面使用讲义母版来管理其页眉、页脚、日期/时间和页码占位符。与注释页面不同，讲义设置通过讲义母版而不是单个讲义幻灯片进行管理。

使用 [`getMasterHandoutSlide`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) 方法访问讲义母版。如果不存在，请调用 [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) 创建默认讲义母版。

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

## **了解作用域和继承**

选择与您要更改的作用域相匹配的页眉/页脚管理器：

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islideheaderfootermanager/) 更改单个常规幻灯片的页脚、日期/时间和幻灯片编号设置。
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilayoutslideheaderfootermanager/) 控制布局幻灯片，并可将受支持的设置传播到从属幻灯片。
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslideheaderfootermanager/) 控制常规幻灯片母版，并可将受支持的设置传播到从属幻灯片。
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasternotesslideheaderfootermanager/) 控制注释母版，并可将设置传播到所有从属注释幻灯片。
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/inotesslideheaderfootermanager/) 更改单个注释幻灯片，并支持页眉占位符以及页脚、日期/时间和幻灯片编号。
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) 更改讲义母版，支持所有四种占位符类型。

当相同设置应在整个层级中应用时，请使用母版或布局的传播功能。当需要对单页进行本地设置时，请使用单个幻灯片或注释幻灯片管理器。

## **常见问题**

**我可以在常规幻灯片上添加页眉吗？**

不能。PowerPoint 未为常规幻灯片定义页眉占位符。请在常规幻灯片上使用页脚、日期/时间和幻灯片编号占位符。页眉占位符仅在注释页面和讲义上可用。

**如果页脚、日期/时间或幻灯片编号占位符不可见怎么办？**

使用相应的页眉/页脚管理器检查其可见性并在需要时启用。例如，[`isFooterVisible`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) 报告页脚占位符是否存在，而 [`setFooterVisibility`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) 则更改其可见性。

**如何从除 1 之外的值开始编号幻灯片？**

调用演示文稿的 [`setFirstSlideNumber`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 方法。随后幻灯片编号占位符将使用更新后的编号序列。

**导出为 PDF、图像或 HTML 时，页眉和页脚会怎样？**

可见的页眉和页脚元素会与演示文稿内容一起在输出格式中渲染。其外观取决于导出的页面类型以及相应的占位符可见性设置。