---
title: 在 JavaScript 中应用或更改幻灯片布局
linktitle: 幻灯片布局
type: docs
weight: 60
url: /zh/nodejs-java/slide-layout/
keywords:
- 幻灯片布局
- 内容布局
- 占位符
- 演示文稿设计
- 幻灯片设计
- 未使用布局
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Node.js 中管理和自定义幻灯片布局。通过 JavaScript 代码示例，探索布局类型、占位符控制、页脚可见性以及布局操作。"
---

## **概述**

幻灯片布局定义了占位框的排列方式以及幻灯片内容的格式。它控制哪些占位符可用以及它们出现的位置。幻灯片布局帮助您快速且一致地设计演示文稿——无论是创建简单的还是更复杂的内容。PowerPoint 中最常见的幻灯片布局包括：

**标题幻灯片布局** – 包含两个文本占位符：一个用于标题，另一个用于副标题。

**标题和内容布局** – 顶部有较小的标题占位符，下面有更大的占位符用于主要内容（如文本、项目符号、图表、图像等）。

**空白布局** – 不包含占位符，您可以完全自行设计幻灯片。

幻灯片布局是幻灯片母版的一部分，母版是定义整个演示文稿布局样式的顶层幻灯片。您可以通过幻灯片母版访问和修改布局幻灯片——按类型、名称或唯一 ID。或者，您也可以直接在演示文稿中编辑特定的布局幻灯片。

在 Aspose.Slides for Node.js 中使用幻灯片布局，您可以使用：

- 在 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类下的 [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) 和 [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) 方法
- 如 [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/)、[LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) 和 [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) 等类型

{{% alert title="Info" color="info" %}}
要了解更多关于使用母版幻灯片的内容，请查看 [Slide Master](/slides/zh/nodejs-java/slide-master/) 文章。
{{% /alert %}}

## **向演示文稿添加幻灯片布局**

要自定义幻灯片的外观和结构，可能需要向演示文稿添加新的布局幻灯片。Aspose.Slides for Node.js 允许您检查特定布局是否已存在，必要时添加新布局，并使用该布局插入幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 访问 [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/)。
1. 检查所需的布局幻灯片是否已经存在于集合中。如果不存在，则添加所需的布局幻灯片。
1. 基于新布局幻灯片添加一个空白幻灯片。
1. 保存演示文稿。

下面的 JavaScript 代码演示了如何向 PowerPoint 演示文稿添加幻灯片布局：
```js
// 实例化表示 PowerPoint 文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // 遍历布局幻灯片类型以选择布局幻灯片。
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // 演示文稿不包含所有布局类型的情况。
        // 演示文稿文件仅包含 Blank 和 Custom 布局类型。
        // 但是，具有自定义类型的布局幻灯片可能具有可识别的名称，
        // 如 "Title"、"Title and Content" 等，可用于布局幻灯片选择。
        // 也可以依据一组占位符形状类型。
        // 例如，标题幻灯片应仅具有 Title 占位符类型，依此类推。
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // 使用添加的布局幻灯片添加空白幻灯片。
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // 将演示文稿保存到磁盘。
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **删除未使用的布局幻灯片**

Aspose.Slides 提供了 [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) 类的 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 方法，以便删除不需要且未使用的布局幻灯片。

下面的 JavaScript 代码展示了如何从 PowerPoint 演示文稿中删除布局幻灯片：
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **向布局幻灯片添加占位符**

Aspose.Slides 提供了 [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) 方法，允许您向布局幻灯片添加新占位符。

此管理器包含以下占位符类型的方法：

| PowerPoint 占位符                 | [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) 方法 |
| --------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)           | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                 | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)     | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)           | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)               | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)               | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)         | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)               | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)  | addOnlineImagePlaceholder(float x, float y, float width, float height) |

下面的 JavaScript 代码演示了如何向 Blank 布局幻灯片添加新的占位符形状：
```js
let presentation = new aspose.slides.Presentation();
try {
    // 获取空白布局幻灯片。
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // 获取布局幻灯片的占位符管理器。
    let placeholderManager = layout.getPlaceholderManager();

    // 向空白布局幻灯片添加不同的占位符。
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // 使用空白布局添加新幻灯片。
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


结果：

![布局幻灯片上的占位符](add_placeholders.png)

## **设置布局幻灯片的页脚可见性**

在 PowerPoint 演示文稿中，页脚元素（如日期、页码和自定义文本）可以根据幻灯片布局显示或隐藏。Aspose.Slides for Node.js 允许您控制这些页脚占位符的可见性。这在您希望某些布局显示页脚信息而其他布局保持简洁时非常有用。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取布局幻灯片的引用。
1. 将幻灯片页脚占位符设为可见。
1. 将页码占位符设为可见。
1. 将日期时间占位符设为可见。
1. 保存演示文稿。

下面的 JavaScript 代码展示了如何设置幻灯片页脚的可见性以及相关操作：
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **设置子页脚可见性（针对幻灯片）**

在 PowerPoint 演示文稿中，日期、页码和自定义文本等页脚元素可以在母版幻灯片层面进行控制，以确保所有布局幻灯片的一致性。Aspose.Slides for Node.js 使您能够在母版幻灯片上设置这些页脚占位符的可见性和内容，并将这些设置传播到所有子布局幻灯片，从而在整个演示文稿中保持统一的页脚信息。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取母版幻灯片的引用。
1. 将母版及所有子页脚占位符设为可见。
1. 将母版及所有子页码占位符设为可见。
1. 将母版及所有子日期时间占位符设为可见。
1. 保存演示文稿。

下面的 JavaScript 代码演示了此操作：
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **常见问题**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义整体主题和默认格式，而布局幻灯片为不同类型的内容定义特定的占位符排列。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以，您可以通过 [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) 方法获取的布局幻灯片集合克隆布局幻灯片，然后使用 `addClone` 方法将其插入到另一个演示文稿中。

**如果删除仍被幻灯片使用的布局幻灯片会怎样？**

如果尝试删除仍被至少一张幻灯片引用的布局幻灯片，Aspose.Slides 将抛出 [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/)。为避免此情况，请使用 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 方法，它仅安全地删除未使用的布局幻灯片。