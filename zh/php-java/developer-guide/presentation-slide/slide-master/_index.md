---
title: 在 PHP 中管理演示文稿幻灯片母版
linktitle: 幻灯片母版
type: docs
weight: 70
url: /zh/php-java/slide-master/
keywords:
- 幻灯片母版
- 母版幻灯片
- PPT 母版幻灯片
- 多个母版幻灯片
- 比较母版幻灯片
- 背景
- 占位符
- 克隆母版幻灯片
- 复制母版幻灯片
- 重复母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中管理幻灯片母版：访问、编辑、克隆、比较以及删除 PowerPoint 和 OpenDocument 演示文稿中的母版幻灯片。"
---
## **概述**

**幻灯片母版** 定义一组幻灯片的共享设计设置。它可以包含公共形状、徽标、背景、文本样式、主题设置和页脚设置。在 PowerPoint 中，编辑幻灯片母版是保持演示文稿一致性的常用方式，无需在每张幻灯片上重复相同的格式。

Aspose.Slides for PHP via Java 支持相同的模型。一个演示文稿可以包含一个或多个母版幻灯片，每个母版幻灯片可以包含若干版式幻灯片。普通幻灯片通常不直接引用母版幻灯片，而是使用版式幻灯片，并且该版式幻灯片属于某个母版幻灯片。

层次结构如下：

1. **幻灯片母版** - 定义共享的设计和主题。  
1. **版式幻灯片** - 定义占位符的特定排列以及版式级别的格式。  
1. **普通幻灯片** - 包含实际的演示内容，并使用一个版式幻灯片。

![母版幻灯片、版式幻灯片和普通幻灯片的层次结构](slide-master_2.jpg)

在 Aspose.Slides 中，幻灯片母版由 [MasterSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslide/) 类表示。演示文稿中的所有母版幻灯片可通过 [Presentation.getMasters](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getMasters) 方法获取，该方法返回一个 [MasterSlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/) 对象。

{{% alert color="info" title="继承" %}}

当同一属性在多个层级上定义时，层级更具体的会生效。例如，如果母版幻灯片和版式幻灯片都定义了背景，则基于该版式的幻灯片使用版式背景。有关版式幻灯片的更多信息，请参阅 [Apply or Change Slide Layouts](/slides/zh/php-java/slide-layout/)。

{{% /alert %}}

## **访问幻灯片母版**

在 PowerPoint 中，可以通过 **视图** > **幻灯片母版** 打开幻灯片母版视图。

![PowerPoint“视图”选项卡上的幻灯片母版命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters` 方法访问母版幻灯片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

也可以通过普通幻灯片的版式获取其使用的母版幻灯片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **幻灯片母版包含的内容**

母版幻灯片是类似幻灯片的对象。它继承自 [BaseSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslide/)，因此具有普通幻灯片和版式幻灯片的许多属性。母版特有的成员列在 [MasterSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslide/) API 页面上。

常用的母版幻灯片成员包括：

| 成员 | 用途 |
| --- | --- |
| `getBackground` | 设置母版级别的幻灯片背景。 |
| `getShapes` | 存储放置在母版上的形状，如徽标、图片框和共享文本。 |
| `getLayoutSlides` | 存储属于该母版的版式幻灯片。 |
| `getThemeManager` | 提供对母版主题 API 的访问。 |
| `getHeaderFooterManager` | 控制母版及其子版式的页眉、页脚、日期和页码。 |
| `getDependingSlides` | 返回通过其版式依赖于该母版的普通幻灯片。 |

## **向幻灯片母版添加图像**

向母版幻灯片添加图像后，使用该母版版式的幻灯片都会显示该图像。这对于徽标、 水印、装饰条以及其他重复的视觉元素非常有用。

下面的示例向第一张母版幻灯片添加徽标：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

有关图片框的更多信息，请参阅 [Picture Frame](/slides/zh/php-java/picture-frame/)。

## **使用占位符**

占位符通常在版式幻灯片上定义。母版幻灯片提供共享的样式和主题，版式继承这些设置，并决定哪些占位符可用以及它们的位置。

在 PowerPoint 中，占位符命令位于幻灯片母版视图中。

![PowerPoint 幻灯片母版视图中的插入占位符命令](slide-master_5.png)

要使用 Aspose.Slides 添加新占位符，请操作属于母版的版式幻灯片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

也可以格式化已存在于母版幻灯片上的占位符形状。下面的示例找到标题占位符并应用线性渐变填充：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![普通幻灯片继承的已格式化标题占位符](slide-master_8.png)

有关占位符和文本格式化的更多选项，请参阅 [Set Prompt Text in Placeholder](/slides/zh/php-java/manage-placeholder/) 和 [Text Formatting](/slides/zh/php-java/text-formatting/)。

## **更改幻灯片母版背景**

母版背景会被版式和未覆盖该背景的幻灯片继承。下面的示例为第一张母版幻灯片设置纯色背景：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

相关主题请参阅 [Presentation Background](/slides/zh/php-java/presentation-background/) 和 [Presentation Theme](/slides/zh/php-java/presentation-theme/)。

## **将幻灯片母版克隆到其他演示文稿**

使用 [MasterSlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/) 的 `addClone` 将母版幻灯片复制到另一演示文稿。复制后的母版可供目标演示文稿中的版式和幻灯片使用。

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

如果需要连同母版一起克隆普通幻灯片，请参阅 [Clone Slides](/slides/zh/php-java/clone-slides/)。

## **添加多个幻灯片母版**

一个演示文稿可以包含多个母版幻灯片。这在不同章节需要不同品牌、页面结构或主题设置时非常有用。

![PowerPoint 插入和管理母版幻灯片的命令](slide-master_9.jpg)

下面的示例克隆默认母版，为克隆副本设置不同的背景，随后在该克隆母版下创建版式，并基于该版式添加新幻灯片：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **比较幻灯片母版**

可以使用从 [BaseSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslide/) 继承的 `equals` 方法比较母版幻灯片。比较会检查结构和静态内容，如形状、文本、格式、动画以及其他幻灯片设置。不比较唯一标识符（如幻灯片 ID）或动态占位符值（如当前日期）。

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

有关详细信息，请参阅 [Compare Presentation Slides](/slides/zh/php-java/compare-slides/)。

## **将幻灯片母版视图设为默认视图**

使用 [ViewProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/viewproperties/) 的 `setLastView` 方法可以控制 PowerPoint 首次打开的视图。下面的示例在幻灯片母版视图中打开演示文稿：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

有关更多视图设置，请参阅 [Save Presentation](/slides/zh/php-java/save-presentation/)。

## **删除未使用的母版幻灯片**

有时演示文稿中会存在不再被任何普通幻灯片使用的母版幻灯片。删除未使用的母版可减小文件大小并简化模板维护。

使用 [MasterSlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/masterslidecollection/) 的 `removeUnused` 方法从 `getMasters` 集合中删除未使用的母版：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

也可以使用 [Compress](https://reference.aspose.com/slides/zh/php-java/aspose.slides/compress/) 类的低代码 `removeUnusedMasterSlides` 方法：

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**幻灯片母版和版式幻灯片有什么区别？**

幻灯片母版定义共享的设计设置，如主题、背景、公共形状和文本样式。版式幻灯片属于母版，并定义占位符的具体排列。普通幻灯片使用版式幻灯片，因此同时继承版式和母版的设置。

**一个演示文稿可以包含多个幻灯片母版吗？**

可以。演示文稿可以包含多个幻灯片母版。不同章节需要不同视觉体系或品牌时，请使用多个母版。

**应该在母版幻灯片还是版式幻灯片上添加占位符？**

大多数情况下，应在版式幻灯片上添加占位符。将共享的视觉元素和共享格式放在母版上，然后在普通幻灯片将使用的版式上放置内容占位符。

**我可以删除仍在使用的母版幻灯片吗？**

不能。拥有依赖幻灯片的母版不能直接安全删除。请先将这些幻灯片移动到其他母版的版式下，或使用仅删除未使用母版的清理方法。