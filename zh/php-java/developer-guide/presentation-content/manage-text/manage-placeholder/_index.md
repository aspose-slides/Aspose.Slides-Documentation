---
title: 在 PHP 中管理演示文稿占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh/php-java/manage-placeholder/
keywords:
- 占位符
- 文本占位符
- 图像占位符
- 图表占位符
- 内容占位符
- 提示文本
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何检查和编辑文本、图片、图表和内容占位符，并通过 Java 的 Aspose.Slides for PHP 理解占位符继承。"
---
## **概述**

占位符是一种形状，用于在演示文稿模板中保留特定内容类型的位置。常见示例包括标题、正文、图片、图表和通用内容占位符。与普通形状不同，占位符可以从布局幻灯片或母版幻灯片继承其位置、大小、格式和其他设置。

Aspose.Slides 通过 [Shape::getPlaceholder](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getplaceholder/) 方法公开占位符信息。该方法返回一个 [Placeholder](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholder/) 对象，普通形状则返回 `null`。使用 [Placeholder::getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholder/gettype/) 可确定占位符的预期内容。

了解占位符类型后，形状类仍然很重要：

- 空的文本、图片、图表或内容占位符通常由 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 表示。
- 已填充的图片占位符可以由 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 表示。
- 已填充的图表占位符可以由 [Chart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/) 表示。
- 内容占位符可以包含多种内容。请同时检查 [Placeholder::getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholder/gettype/) 和运行时形状类，而不要假设每个占位符都是 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholder/gettype/) 描述了占位符的角色；它并不能保证形状的运行时类。在访问文本、图片、图表、表格或媒体特定成员之前，请始终进行类型检查。
{{% /alert %}}

## **了解占位符继承**

占位符形成层次结构：

1. 母版幻灯片定义可重复使用的样式，并在某些情况下定义母版级别的占位符。
2. 布局幻灯片定义一个或多个普通幻灯片使用的排列，并可以从母版继承。
3. 普通幻灯片包含该幻灯片的占位符，并可以从其布局继承。

调用 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getbaseplaceholder/) 可在此层次结构中向上移动一级。幻灯片占位符通常返回其布局占位符；布局占位符可以返回其母版占位符。当形状没有基础占位符时，方法返回 `null`。

以下示例列出第一张幻灯片上的占位符并报告其基础占位符：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

在普通幻灯片上编辑占位符会为该幻灯片创建或更改本地覆盖。编辑相关的布局或母版可能会影响所有仍然继承该设置的幻灯片。普通本地形状没有基础占位符，仅因占据相同坐标而不会开始继承。

## **更改占位符中的文本**

标题、居中标题、副标题、正文和文本占位符通常支持文本。在使用其 [getTextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/gettextframe/) 方法之前，请检查是否为 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。

以下示例更新第一张幻灯片上的第一个标题占位符并保存结果：

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此模式避免将图片、图表、表格或媒体占位符视为 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 对象。它还通过用途识别占位符，而不是依赖脆弱的形状索引。

## **在布局上设置提示文本**

提示文本是显示在空占位符中的设计时指令，例如 *单击以添加标题*。请在布局占位符上设置自定义提示文本，而不是尝试通过普通幻灯片的形状集合来访问。通过 [Slide::getLayoutSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getLayoutSlide) 获取布局，并遍历 [BaseSlide::getShapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseslide/#getShapes) 返回的集合。

以下示例更改第一张幻灯片使用的布局上的标题和副标题提示文本：

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

提示文本不是普通幻灯片内容。它用于 PowerPoint 等编辑应用中空占位符的设计时指示。一旦用户或程序提供了真实内容，提示就不再显示。更改提示也不会替换使用该布局的幻灯片上的现有文本。

## **更新图片占位符**

有两种情况需要处理：

- 如果图片占位符已填充并由 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 表示，则通过 [PictureFillFormat::getPicture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/getpicture/) 和 [SlidesPicture::setImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidespicture/setimage/) 替换图像。
- 如果仍是空占位符，则使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addpictureframe/) 在占位符坐标处添加图片框，并删除空占位符。

以下示例同时支持这两种情况并保存演示文稿：

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

为空占位符创建的替换是本地图片框，而不是新占位符，因为 [Shape::getPlaceholder](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getplaceholder/) 没有提供设置器。它保留了预留位置，但不再继承占位符特定行为。如果必须保留占位符关系，请先在 PowerPoint 中准备并填充占位符，然后使用 Aspose.Slides 更新得到的 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/)。

有关图像透明度、裁剪和其他图片特效，请参阅 [Manage Picture Frames](/slides/zh/php-java/picture-frame/)。这些操作属于图片框或图片填充，而非占位符元数据。

## **使用图表和内容占位符**

已填充的图表占位符可以由 [Chart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/) 表示。以下示例通过占位符类型和运行时类找到此类图表，修改其标题并保存文件：

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

通用内容占位符通常具有 [PlaceholderType::Object](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充当多种内容类型的启动器，包括图表、表格、图示、图片和媒体。填充后，请检查实际的形状类以了解其包含的内容。专用布局还可以暴露 [PlaceholderType::Chart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Diagram](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholdertype/)。

Aspose.Slides 并不会仅通过更改 [Placeholder::getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/placeholder/gettype/) 将空的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 占位符转换为 [Chart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/)；类型不能通过类进行更改。要以编程方式填充空的图表或内容区域，请在占位符坐标处添加所需对象，然后删除空占位符。以下示例对图表执行此操作：

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

添加的图表是普通本地图表。它占据占位符的区域，但不继承布局占位符。需要替换其类别、系列或工作簿数据时，请使用专用的 [chart management articles](/slides/zh/php-java/powerpoint-charts/)。

## **完整示例：更新文本或图像内容**

以下端到端示例打开一个模板，搜索第一张幻灯片中的标题或图片占位符，检查占位符和形状类型，更新相应的内容并保存输出。示例刻意避免假设形状索引或将每个占位符视为同一类。

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**什么是基础占位符？**

基础占位符是布局或母版上对应的形状，其他占位符从其继承。使用 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getbaseplaceholder/) 可检索它。普通本地形状返回 `null`，因为它不属于占位符层次结构。

**我可以通过编辑布局占位符来更改所有幻灯片的标题吗？**

您可以通过布局更改继承的格式或提示文本，但已有的标题内容存储在普通幻灯片上。要在整个演示文稿中替换实际标题文本，请遍历幻灯片并更新每个标题占位符。

**如何管理日期、幻灯片编号、页眉和页脚占位符？**

在相应的幻灯片、布局、母版、备注或讲义范围内使用页眉页脚管理器。完整示例请参阅 [Manage Presentation Header and Footer](/slides/zh/php-java/presentation-header-and-footer/)。