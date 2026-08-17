---
title: 在 PHP 中应用或更改幻灯片布局
linktitle: 幻灯片布局
type: docs
weight: 60
url: /zh/php-java/slide-layout/
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
- 章节标题
- 双内容
- 比较
- 仅标题
- 空白布局
- 带标题的内容
- 带标题的图片
- 标题和垂直文本
- 垂直标题和文本
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for PHP 中应用、创建和修改幻灯片布局，添加占位符，删除未使用的布局，并控制页脚可见性。"
---
## **概述**

幻灯片布局定义了标题、文本、图片、图表和表格等占位符的位置和格式。应用布局可为幻灯片提供一致的结构，同时允许每张幻灯片包含各自的内容。

最常见的布局包括：

- **标题幻灯片**：包含标题和副标题占位符。  
- **标题和内容**：包含标题占位符和通用内容占位符。  
- **空白**：不包含任何内容占位符，适用于需要手动定位所有形状的情况。

## **了解布局继承**

演示文稿有三个相关层级：

1. 一个[母版幻灯片](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslide/)定义主题、共享格式、背景和公共对象。  
1. 一个[布局幻灯片](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/)属于母版，定义特定的占位符排列。  
1. 一个[普通幻灯片](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/)使用一种布局，并存储该幻灯片的内容。

普通幻灯片从其布局继承主题和格式，布局又从其母版继承。直接在普通幻灯片上设置的值会覆盖该层级继承的值。创建普通幻灯片时，其占位符形状会根据所选布局生成，而填入这些占位符的内容属于普通幻灯片。

在从布局创建幻灯片之前，请先向布局添加必需的占位符。随后向布局添加新占位符不会自动为已有的普通幻灯片添加对应的占位符形状。

此关系有两个重要后果：

- 更改布局上继承的格式或已有占位符的几何形状会更新所有依赖该布局的幻灯片。在编辑已在使用的布局前，请检查其依赖的幻灯片并预览生成的演示文稿。  
- 正在被幻灯片使用的布局无法被删除。请先将其依赖的幻灯片重新指派到其他布局，或仅删除未使用的布局。

有关此层级顶部的更多信息，请参阅[幻灯片母版](/slides/zh/php-java/slide-master/)。

## **选择并应用幻灯片布局**

当演示文稿遵循标准 PowerPoint 布局定义时，请使用布局类型。布局名称可以编辑并本地化，因此除非您能够控制源模板，否则基于名称的选择可靠性较低。

下面的示例在第一个母版上查找**标题和内容**布局。如果该布局不可用，则有意回退到**空白**。第二个空检查是必需的，因为演示文稿可能只包含自定义布局。随后通过[Slide.setLayoutSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#setLayoutSlide)方法将选中的布局应用到第一张普通幻灯片。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

更改幻灯片的布局不会删除直接添加到幻灯片的普通形状。然而，占位符位置、继承的格式以及现有占位符与新布局之间的对应关系可能会改变，因此在切换显著不同的布局时请检查输出。

## **添加布局幻灯片**

选择和创建是分开的操作。前面的示例仅选择了已有布局，并未创建新布局。要创建布局，请对目标母版的布局集合调用[MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterlayoutslidecollection/#add)方法。

下面的示例始终添加一个名为`Report Title and Content`的新**标题和内容**布局，然后基于它添加一张普通幻灯片。布局名称在集合内必须唯一。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

仅在模板真正需要另一个可复用结构时才添加布局。如果已经存在合适的布局，请选择并复用它，而不是创建重复的布局。

## **向布局幻灯片添加占位符**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/#getPlaceholderManager)方法提供一个[LayoutPlaceholderManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/)用于向布局添加占位符形状。

| PowerPoint 占位符                | `LayoutPlaceholderManager` 方法 |
| --------------------------------- | -------------------------------- |
| ![Content](content.png)           | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)     | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)           | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)               | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)               | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)  | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

下面的示例先验证**空白**布局是否存在，向其添加四个占位符，然后创建使用该修改后布局的普通幻灯片。顺序是有意为之：先添加占位符，再创建普通幻灯片，以便 Aspose.Slides 能在该幻灯片上生成相应的占位符形状。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![布局幻灯片上的占位符](add_placeholders.png)

{{% alert color="warning" title="警告" %}}
更改继承的格式或已有布局占位符的几何形状可能影响依赖的幻灯片。新添加的布局占位符不会回填到已有的普通幻灯片。请在演示文稿的副本上测试布局更改，并检查每一张依赖幻灯片。
{{% /alert %}}

## **删除未使用的布局幻灯片**

使用[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)方法删除所有普通幻灯片未引用的布局。该方法会保留仍在使用的布局。

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若要删除特定布局，请先调用其[hasDependingSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/#hasDependingSlides)或[getDependingSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/#getDependingSlides)方法。重新指派任何依赖幻灯片后，再调用[LayoutSlide.remove](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/#remove)。尝试删除仍在使用的布局会抛出[PptxEditException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxeditexception/)。

## **在布局幻灯片上控制页脚可见性**

布局拥有自己的页脚、幻灯片编号和日期时间占位符。使用[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/#getHeaderFooterManager)方法可对单个布局的这些占位符进行控制。例如，内容布局需要显示页脚，而标题布局则不需要。

下面的示例安全地选择一个布局并使其页脚元素可见：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在母版及其子布局上控制页脚可见性**

若需在整个母版层级中统一页脚设置，请使用[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslide/#getHeaderFooterManager)方法。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslideheaderfootermanager/)的传播方法作用于母版、本层级的布局幻灯片以及普通幻灯片；它们不会只针对单个普通幻灯片。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义演示文稿的主题和共享格式。布局幻灯片属于母版，用于定义可复用的占位符排列。普通幻灯片使用这些布局并存储特定于幻灯片的内容。

**我可以将布局幻灯片从一个演示文稿复制到另一个吗？**

可以。使用[addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/globallayoutslidecollection/#addClone)方法将副本添加到目标集合。跨演示文稿复制时，还需检查字体、主题、图像及其他资源是否在源布局中使用。

**当我修改已在使用的布局时会发生什么？**

依赖幻灯片会继承布局的更改，除非它们在本地覆盖了受影响的格式或对象。占位符的几何形状和继承的样式可能一次性在多张幻灯片上改变。编辑布局前，请使用[getDependingSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/#getDependingSlides)确定受影响的幻灯片。

**如果我删除仍在使用的布局会怎样？**

Aspose.Slides 会抛出[PptxEditException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxeditexception/)。请先重新指派依赖的幻灯片，或使用[removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)仅删除未被引用的布局。