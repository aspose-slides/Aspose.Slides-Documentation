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
- 未使用的布局
- 页脚可见性
- 标题幻灯片
- 标题和内容
- 节标题
- 双内容
- 对比
- 仅标题
- 空白布局
- 带说明的内容
- 带说明的图片
- 标题和垂直文本
- 垂直标题和文本
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js（通过 Java）中应用、创建和修改幻灯片布局，添加占位符，移除未使用的布局，并控制页脚可见性。"
---
## **概述**

幻灯片布局定义了占位符（如标题、文本、图片、图表和表格）的位置和格式。应用布局可使幻灯片具有一致的结构，同时允许每张幻灯片包含自己的内容。

最常见的布局包括：

- **标题幻灯片**：包含标题和副标题占位符。
- **标题和内容**：包含标题占位符和通用内容占位符。
- **空白**：不包含内容占位符，适用于需要手动定位每个形状的情况。

## **了解布局继承**

演示文稿有三个相关层级：

1. 一个[母版幻灯片](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/)定义主题、共享格式、背景和公共对象。  
1. 一个[布局幻灯片](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/)属于母版，定义特定的占位符排列。  
1. 一个[普通幻灯片](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/)使用一种布局并存储该幻灯片的内容。

普通幻灯片从其布局继承主题和格式，布局又从其母版继承。直接在普通幻灯片上设置的值会覆盖该层级的继承值。创建普通幻灯片时，其占位符形状会根据所选布局生成，而这些占位符中输入的内容属于普通幻灯片。

在从布局创建幻灯片之前，请先向布局添加所需的占位符。之后再向布局添加占位符不会自动在已有的普通幻灯片中添加相应的占位符形状。

此关系有两个重要后果：

- 更改布局上继承的格式或现有占位符的几何形状会更新所有依赖该布局的幻灯片。编辑已在使用的布局前，请检查其依赖的幻灯片并预览最终演示文稿。  
- 仍被幻灯片使用的布局不能被删除。请先将其依赖的幻灯片重新分配到其他布局，或仅删除未使用的布局。

有关此层级顶部的更多信息，请参阅[幻灯片母版](/slides/zh/nodejs-java/slide-master/)。

## **选择并应用幻灯片布局**

当演示文稿遵循标准 PowerPoint 布局定义时，请使用[SlideLayoutType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidelayouttype/)值。布局名称可由用户编辑并本地化，除非您控制源模板，否则基于名称的选择可靠性较低。

下面的示例在第一个母版上查找**标题和内容**布局。如果该布局不可用，则有意回退到**空白**。第二个空检查是必要的，因为演示文稿可能仅包含自定义布局。选定的布局随后通过[Slide.setLayoutSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#setLayoutSlide)方法应用到第一个普通幻灯片。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

更改幻灯片的布局不会删除直接添加到幻灯片的普通形状。然而，占位符位置、继承的格式以及现有占位符与新布局之间的对应关系可能会改变，因此在切换差异较大的布局时请检查输出。

## **添加布局幻灯片**

选择和创建是两个独立的操作。前面的示例仅选择了现有布局，并未创建新布局。要创建布局，请在目标母版的布局集合上调用[MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterlayoutslidecollection/#add)方法。

下面的示例始终添加一个名为`Report Title and Content`的全新**标题和内容**布局，然后基于它添加普通幻灯片。布局名称在集合中必须唯一。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

仅在模板确实需要另一个可重复使用的结构时才添加布局。如果已有合适的布局，请选择并复用它，而不是创建重复的布局。

## **向布局幻灯片添加占位符**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager)方法提供一个[LayoutPlaceholderManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/)用于向布局添加占位符形状。

| PowerPoint 占位符                | `LayoutPlaceholderManager` 方法 |
| --------------------------------- | -------------------------------- |
| ![内容](content.png)             | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![内容（垂直）](contentV.png)    | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![文本](text.png)                 | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![文本（垂直）](textV.png)        | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![图片](picture.png)              | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![图表](chart.png)                | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![表格](table.png)                | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![媒体](media.png)                | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![在线图片](onlineImage.png)      | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

下面的示例验证**空白**布局是否存在，向其添加四个占位符，然后创建使用该修改后布局的普通幻灯片。顺序是有意的：先添加占位符，再创建普通幻灯片，以便 Aspose.Slides 能在该幻灯片上生成相应的占位符形状。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![布局幻灯片上的占位符](add_placeholders.png)

{{% alert color="warning" title="警告" %}}
更改继承的格式或现有布局占位符的几何形状可能会影响依赖的幻灯片。新添加的布局占位符不会回填到已有的普通幻灯片中。请在演示文稿的副本上测试布局更改，并检查每个依赖幻灯片。
{{% /alert %}}

## **移除未使用的布局幻灯片**

使用[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides)方法删除没有普通幻灯片引用的布局。该方法会保留仍在使用的布局。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

要移除特定布局，请先使用其[hasDependingSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides)或[getDependingSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/#getDependingSlides)方法。重新分配所有依赖幻灯片后，再调用[LayoutSlide.remove](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/#remove)。尝试删除正在使用的布局会抛出[PptxEditException](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxeditexception/)。

## **控制布局幻灯片的页脚可见性**

布局拥有自己的页脚、幻灯片编号和日期时间占位符。使用[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager)方法可为单个布局控制这些占位符。这在例如内容布局需要显示页脚而标题布局不需要时非常有用。

下面的示例安全地选择一个布局，并使其页脚元素可见：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在母版及其子布局上控制页脚可见性**

要在整个母版层级中应用一致的页脚设置，请使用[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager)方法。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslideheaderfootermanager/)的传播方法作用于母版及其依赖的布局幻灯片和普通幻灯片；它们不会只针对单个普通幻灯片。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题解答**

**母版幻灯片与布局幻灯片有什么区别？**

母版幻灯片定义演示文稿的主题和共享格式。布局幻灯片属于母版，定义一种可重复使用的占位符排列。普通幻灯片使用这些布局并存储特定于幻灯片的内容。

**可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以。使用[addClone](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone)方法将副本添加到目标集合。在跨演示文稿复制时，还需要检查源布局使用的字体、主题、图片和其他资源。

**修改已在使用的布局会发生什么？**

依赖的幻灯片会继承布局的更改，除非它们在本地覆盖了受影响的格式或对象。因此，占位符几何形状和继承的样式可能会在许多幻灯片上同时改变。编辑布局前，请使用[getDependingSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/#getDependingSlides)识别受影响的幻灯片。

**如果删除仍在使用的布局会怎样？**

Aspose.Slides 会抛出[PptxEditException](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxeditexception/)。请先重新分配依赖的幻灯片，或使用[removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides)仅删除未被引用的布局。