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
- 部分标题
- 双内容
- 比较
- 仅标题
- 空白布局
- 带说明的内容
- 带说明的图片
- 标题和垂直文本
- 垂直标题和文本
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for PHP 中管理和自定义幻灯片布局。探索布局类型、占位符控制以及通过代码示例实现的页脚可见性。"
---

## **概述**

幻灯片布局定义了占位框的排列方式以及幻灯片内容的格式化。它控制哪些占位符可用以及它们出现的位置。幻灯片布局帮助您快速且一致地设计演示文稿——无论是创建简单的还是更复杂的内容。PowerPoint 中最常见的幻灯片布局包括：

**标题幻灯片布局** – 包含两个文本占位符：一个用于标题，一个用于副标题。

**标题和内容布局** – 在顶部有较小的标题占位符，在下面有较大的主体内容占位符（如文本、项目符号、图表、图像等）。

**空白布局** – 不包含任何占位符，您可以完全自行设计幻灯片。

幻灯片布局是幻灯片母版的一部分，母版是定义演示文稿布局样式的顶层幻灯片。您可以通过母版访问并修改布局幻灯片——按类型、名称或唯一 ID。或者，您也可以直接在演示文稿中编辑特定的布局幻灯片。

要在 Aspose.Slides for PHP 中使用幻灯片布局，您可以使用：

- 在[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类下的方法，例如[getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides)和[getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters)
- 类型如[LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/)、[LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/)以及[LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
欲了解更多关于母版幻灯片的使用，请查看[Slide Master](/slides/zh/php-java/slide-master/)文章。
{{% /alert %}}

## **向演示文稿添加幻灯片布局**

为了自定义幻灯片的外观和结构，您可能需要向演示文稿添加新的布局幻灯片。Aspose.Slides for PHP 允许您检查特定布局是否已存在，必要时添加新布局，并使用该布局插入幻灯片。

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类的实例。  
2. 访问[MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/)。  
3. 检查所需的布局幻灯片是否已经存在于集合中。如果不存在，则添加所需的布局幻灯片。  
4. 基于新布局幻灯片添加一个空白幻灯片。  
5. 保存演示文稿。

下面的 PHP 代码演示了如何向 PowerPoint 演示文稿添加幻灯片布局：
```php
// 实例化表示 PowerPoint 文件的 Presentation 类。
$presentation = new Presentation("Sample.pptx");
try {
    // 遍历布局幻灯片类型以选择布局幻灯片。
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // 演示文稿不包含所有布局类型的情况。
        // 演示文稿文件仅包含空白和自定义布局类型。
        // 但是，具有自定义类型的布局幻灯片可能有可识别的名称，
        // 如 “Title”、 “Title and Content”等，可用于布局幻灯片选择。
        // 也可以依赖一组占位符形状类型。
        // 例如，标题幻灯片应仅包含 Title 占位符类型，依此类推。
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 使用添加的布局幻灯片插入一个空白幻灯片。
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // 将演示文稿保存到磁盘。
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **删除未使用的布局幻灯片**

Aspose.Slides 提供了来自[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)类的[removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)方法，以便您删除不需要且未使用的布局幻灯片。

下面的 PHP 代码展示了如何从 PowerPoint 演示文稿中删除布局幻灯片：
```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **向幻灯片布局添加占位符**

Aspose.Slides 提供了[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/#getPlaceholderManager)方法，您可以使用它向布局幻灯片添加新的占位符。

此管理器包含以下占位符类型的方法：

| PowerPoint 占位符                | [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/) 方法 |
| --------------------------------- | ------------------------------------------------------------ |
| ![内容](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![内容（垂直）](contentV.png)    | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![文本](text.png)                | addTextPlaceholder(float x, float y, float width, float height) |
| ![文本（垂直）](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![图片](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![图表](chart.png)               | addChartPlaceholder(float x, float y, float width, float height) |
| ![表格](table.png)               | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)        | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![媒体](media.png)               | addMediaPlaceholder(float x, float y, float width, float height) |
| ![在线图片](onlineimage.png)     | addOnlineImagePlaceholder(float x, float y, float width, float height) |

下面的 PHP 代码演示了如何向空白布局幻灯片添加新的占位符形状：
```php
$presentation = new Presentation();
try {
    // 获取空白布局幻灯片。
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // 获取布局幻灯片的占位符管理器。
    $placeholderManager = $layout->getPlaceholderManager();

    // 向空白布局幻灯片添加不同的占位符。
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // 使用空白布局添加新幻灯片。
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![布局幻灯片上的占位符](add_placeholders.png)

## **设置布局幻灯片的页脚可见性**

在 PowerPoint 演示文稿中，页脚元素（如日期、页码和自定义文本）可以根据幻灯片布局显示或隐藏。Aspose.Slides for PHP 允许您控制这些页脚占位符的可见性。这在您希望某些布局显示页脚信息而其他布局保持简洁时非常有用。

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类的实例。  
2. 按索引获取布局幻灯片引用。  
3. 将幻灯片页脚占位符设为可见。  
4. 将页码占位符设为可见。  
5. 将日期时间占位符设为可见。  
6. 保存演示文稿。

下面的 PHP 代码展示了如何设置幻灯片页脚的可见性以及相关操作：
```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```


## **为幻灯片设置子页脚的可见性**

在 PowerPoint 演示文稿中，页脚元素（如日期、页码和自定义文本）可以在母版幻灯片级别进行控制，以确保所有布局幻灯片的一致性。Aspose.Slides for PHP 使您能够在母版幻灯片上设置这些页脚占位符的可见性和内容，并将这些设置传播到所有子布局幻灯片，从而在整个演示文稿中保持统一的页脚信息。

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)类的实例。  
2. 按索引获取母版幻灯片引用。  
3. 将母版及其所有子页脚占位符设为可见。  
4. 将母版及其所有子页码占位符设为可见。  
5. 将母版及其所有子日期时间占位符设为可见。  
6. 保存演示文稿。

下面的 PHP 代码演示了此操作：
```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **常见问题**

**母版幻灯片和布局幻灯片有什么区别？**

母版幻灯片定义整体主题和默认格式，而布局幻灯片为不同类型的内容定义特定的占位符排列。

**我能把布局幻灯片从一个演示文稿复制到另一个吗？**

可以，您可以通过[getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides)方法访问的布局幻灯片集合克隆一个布局幻灯片，并使用`addClone`方法将其插入到另一个演示文稿中。

**如果我删除仍被幻灯片使用的布局幻灯片会怎样？**

如果尝试删除仍被至少一张幻灯片引用的布局幻灯片，Aspose.Slides 将抛出[PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/)。为避免此问题，请使用[removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)，它只安全地删除未使用的布局幻灯片。