---
title: 在 Android 上应用或更改幻灯片布局
linktitle: 幻灯片布局
type: docs
weight: 60
url: /zh/androidjava/slide-layout/
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
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中管理和自定义幻灯片布局。通过 Java 代码示例探索布局类型、占位符控制和页脚可见性。"
---

## **概述**

幻灯片布局定义了占位框的排列方式以及幻灯片内容的格式化。它控制哪些占位符可用以及它们出现的位置。幻灯片布局帮助您快速且一致地设计演示文稿——无论是创建简单的还是更复杂的内容。PowerPoint 中最常见的幻灯片布局包括：

**标题幻灯片布局** – 包含两个文本占位符：一个用于标题，一个用于副标题。

**标题和内容布局** – 在顶部有较小的标题占位符，下方有较大的内容占位符（如文本、项目符号、图表、图像等）。

**空白布局** – 不包含任何占位符，您可以完全自行设计幻灯片。

幻灯片布局是幻灯片母版的一部分，母版是定义演示文稿布局样式的顶级幻灯片。您可以通过幻灯片母版访问和修改布局幻灯片——可以按类型、名称或唯一 ID 进行操作。或者，您也可以直接在演示文稿内编辑特定的布局幻灯片。

要在 Aspose.Slides for Android 中使用幻灯片布局，您可以使用：

- 方法，例如 [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) 和 [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--)，位于 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类下
- 类型，如 [ILayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/)、[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/)、[ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/)，以及 [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

要了解更多关于母版幻灯片的使用，请查看 [Slide Master](/slides/zh/androidjava/slide-master/) 文章。

{{% /alert %}}

## **向演示文稿添加幻灯片布局**

为了自定义幻灯片的外观和结构，您可能需要向演示文稿添加新的布局幻灯片。Aspose.Slides for Android 允许您检查特定布局是否已存在，必要时添加新布局，并基于该布局插入幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 访问 [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/)。
1. 检查所需的布局幻灯片是否已经存在于集合中。如果不存在，添加所需的布局幻灯片。
1. 基于新布局幻灯片添加一个空白幻灯片。
1. 保存演示文稿。

以下 Java 代码演示了如何向 PowerPoint 演示文稿添加幻灯片布局：
```java
// 实例化表示 PowerPoint 文件的 Presentation 类。
Presentation presentation = new Presentation("Sample.pptx");
try {
    // 遍历布局幻灯片类型以选择布局幻灯片。
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // 演示文稿不包含所有布局类型的情况。
        // 演示文稿文件仅包含 Blank 和 Custom 布局类型。
        // 但是，具有自定义类型的布局幻灯片可能具有可识别的名称，
        // 如 “Title”“Title and Content”等，可用于布局幻灯片选择。
        // 也可以依据一组占位符形状类型。
        // 例如，标题幻灯片应只有 Title 占位符类型，依此类推。
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 使用添加的布局幻灯片插入一个空白幻灯片。
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // 将演示文稿保存到磁盘。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **移除未使用的布局幻灯片**

Aspose.Slides 提供了位于 [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) 类中的 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 方法，以便您删除不需要的未使用布局幻灯片。

以下 Java 代码展示了如何从 PowerPoint 演示文稿中移除布局幻灯片：
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **向布局幻灯片添加占位符**

Aspose.Slides 提供了 [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) 方法，允许您向布局幻灯片添加新占位符。

该管理器包含以下占位符类型的方法：

| PowerPoint 占位符                | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) 方法 |
| -------------------------------- | ------------------------------------------------------------ |
| ![内容](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![内容（垂直）](contentV.png)    | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![文本](text.png)                | addTextPlaceholder(float x, float y, float width, float height) |
| ![文本（垂直）](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![图片](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![图表](chart.png)               | addChartPlaceholder(float x, float y, float width, float height) |
| ![表格](table.png)               | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)        | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![媒体](media.png)               | addMediaPlaceholder(float x, float y, float width, float height) |
| ![在线图片](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

以下 Java 代码演示了如何向空白布局幻灯片添加新的占位符形状：
```java
Presentation presentation = new Presentation();
try {
    // 获取 Blank 布局幻灯片。
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // 获取布局幻灯片的占位符管理器。
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // 向 Blank 布局幻灯片添加不同的占位符。
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // 使用 Blank 布局添加新幻灯片。
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


结果：

![布局幻灯片上的占位符](add_placeholders.png)

## **设置布局幻灯片的页脚可见性**

在 PowerPoint 演示文稿中，页脚元素（如日期、幻灯片编号和自定义文本）可以根据布局幻灯片的不同显示或隐藏。Aspose.Slides for Android 允许您控制这些页脚占位符的可见性。这对于希望某些布局显示页脚信息而其他布局保持简洁的情况非常有用。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取布局幻灯片的引用。
1. 将幻灯片页脚占位符设置为可见。
1. 将幻灯片编号占位符设置为可见。
1. 将日期时间占位符设置为可见。
1. 保存演示文稿。

以下 Java 代码展示了如何设置幻灯片页脚的可见性并执行相关操作：
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **设置子布局幻灯片的页脚可见性**

在 PowerPoint 演示文稿中，页脚元素（如日期、幻灯片编号和自定义文本）可以在母版幻灯片层面进行控制，以确保所有布局幻灯片的一致性。Aspose.Slides for Android 使您能够在母版幻灯片上设置这些页脚占位符的可见性和内容，并将这些设置传播到所有子布局幻灯片，从而在整个演示文稿中保持统一的页脚信息。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取母版幻灯片的引用。
1. 将母版及所有子布局的页脚占位符设置为可见。
1. 将母版及所有子布局的幻灯片编号占位符设置为可见。
1. 将母版及所有子布局的日期时间占位符设置为可见。
1. 保存演示文稿。

以下 Java 代码演示了此操作：
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **常见问题**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义整体主题和默认格式，而布局幻灯片则为不同类型的内容定义占位符的具体排列方式。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以，您可以通过 [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) 方法获取的布局幻灯片集合克隆布局幻灯片，然后使用 `addClone` 方法将其插入到另一个演示文稿中。

**如果删除仍被幻灯片使用的布局幻灯片会怎样？**

如果尝试删除仍被演示文稿中至少一张幻灯片引用的布局幻灯片，Aspose.Slides 会抛出 [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/)。为避免此问题，请使用 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 方法，它只会安全地移除未使用的布局幻灯片。