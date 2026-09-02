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
- 两列内容
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
description: "通过 Java 在 Aspose.Slides for Android 中应用、创建和修改幻灯片布局，添加占位符，删除未使用的布局，并控制页脚可见性。"
---
## **概述**

幻灯片布局定义了标题、文本、图片、图表和表格等占位符的位置和格式。应用布局可以为幻灯片提供一致的结构，同时允许每张幻灯片包含其自己的内容。

最常用的布局包括：

- **标题幻灯片**：包含标题和副标题占位符。
- **标题和内容**：包含标题占位符和通用内容占位符。
- **空白**：不包含任何内容占位符，适用于需要手动定位每个形状的情况。

## **了解布局继承**

演示文稿有三个相关层级：

1. 一个[母版幻灯片](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterslide/)定义主题、共享格式、背景和公共对象。
1. 一个[布局幻灯片](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutslide/)属于母版，定义特定的占位符排列。
1. 一个[普通幻灯片](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/)使用一个布局并存储该幻灯片的内容。

普通幻灯片从其布局继承主题和格式，布局则从其母版继承。直接在普通幻灯片上设置的值会覆盖该层级的继承值。创建普通幻灯片时，其占位符形状是根据所选布局生成的，而填入这些占位符的内容属于普通幻灯片。

在从布局创建幻灯片之前，请先向布局添加所需的占位符。随后再向布局添加占位符不会自动为已有的普通幻灯片添加相应的占位符形状。

此关系有两个重要后果：

- 更改布局上继承的格式或现有占位符的几何形状会更新所有依赖该布局的幻灯片。在编辑已在使用的布局之前，请检查其依赖的幻灯片并预览生成的演示文稿。
- 仍被幻灯片使用的布局无法删除。请先将其依赖的幻灯片重新分配到其他布局，或仅删除未使用的布局。

有关此层级顶部的更多信息，请参阅[幻灯片母版](/slides/zh/androidjava/slide-master/)。

## **选择并应用幻灯片布局**

当演示文稿遵循标准 PowerPoint 布局定义时，请使用布局类型。布局名称可由用户编辑并本地化，因此除非您控制源模板，否则基于名称的选择可靠性较低。

下面的示例在第一个母版上查找**标题和内容**布局。如果该布局不可用，则有意回退到**空白**。第二次空检查是必要的，因为演示文稿可能只包含自定义布局。随后通过[ISlide.setLayoutSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-)方法将选定的布局应用到第一个普通幻灯片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

更改幻灯片的布局不会删除直接添加到幻灯片的普通形状。但占位符位置、继承的格式以及现有占位符与新布局之间的对应关系可能会改变，因此在在差异较大的布局之间切换时请检查输出。

## **添加布局幻灯片**

选择和创建是分开的操作。前面的示例只选择了已有布局，并未创建新的布局。要创建布局，请在目标母版的布局集合上调用[IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-)方法。

下面的示例始终添加一个新的**标题和内容**布局，名称为`Report Title and Content`，随后基于该布局添加普通幻灯片。布局名称在集合内必须唯一。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

仅在模板确实需要另一个可重用结构时才添加布局。如果已存在合适的布局，请选择并重复使用，而不是创建重复的布局。

## **向布局幻灯片添加占位符**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--)方法提供一个[ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/)用于向布局添加占位符形状。

| PowerPoint 占位符                | `ILayoutPlaceholderManager` 方法 |
| --------------------------------- | -------------------------------- |
| ![内容](content.png)              | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![内容（垂直）](contentV.png)     | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![文本](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![文本（垂直）](textV.png)        | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![图片](picture.png)              | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![图表](chart.png)                | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![表格](table.png)                | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![媒体](media.png)                | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![在线图片](onlineImage.png)      | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

下面的示例验证**空白**布局是否存在，向其添加四个占位符，然后创建使用该修改后布局的普通幻灯片。顺序是刻意的：在创建普通幻灯片之前先添加占位符，这样 Aspose.Slides 能在该幻灯片上生成相应的占位符形状。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![布局幻灯片上的占位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
更改继承的格式或现有布局占位符的几何形状可能会影响依赖的幻灯片。新添加的布局占位符不会回填到已有的普通幻灯片中。请在演示文稿的副本上测试布局更改，并检查每一张依赖的幻灯片。
{{% /alert %}}

## **删除未使用的布局幻灯片**

使用[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)方法删除没有普通幻灯片引用的布局。该方法会保留仍在使用的布局。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

要删除特定布局，首先使用其[hasDependingSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--)或[getDependingSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--)方法。在调用[ILayoutSlide.remove](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutslide/#remove--)之前，先重新分配任何依赖的幻灯片。尝试删除正在使用的布局会抛出[PptxEditException](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pptxeditexception/)。

## **在布局幻灯片上控制页脚可见性**

布局拥有自己的页脚、幻灯片编号和日期时间占位符。使用[ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--)方法可为单个布局控制这些占位符。这在例如内容布局需要显示页脚而标题布局不需要时非常有用。

下面的示例安全地选择一个布局并使其页脚元素可见：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在母版及其子布局上控制页脚可见性**

要在母版层次结构中统一页脚设置，请使用[IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--)方法。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterslideheaderfootermanager/)的传播方法作用于母版及其依赖的布局幻灯片和普通幻灯片；它们不会只针对单个普通幻灯片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义演示文稿的主题和共享格式。布局幻灯片属于母版，定义一种可复用的占位符排列。普通幻灯片使用这些布局并存储特定于幻灯片的内容。

**可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以。使用[addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-)方法将副本添加到目标集合。在跨演示文稿复制时，还需检查源布局使用的字体、主题、图像和其他资源。

**修改已在使用的布局会怎样？**

依赖的幻灯片会继承布局的更改，除非它们在本地覆盖了受影响的格式或对象。因此，占位符的几何形状和继承的样式可能会一次性在多个幻灯片上改变。使用[getDependingSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--)在编辑布局之前识别受影响的幻灯片。

**如果删除仍在使用的布局会怎样？**

Aspose.Slides 会抛出[PptxEditException]。请先重新分配依赖的幻灯片，或使用[removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)只删除未被引用的布局。