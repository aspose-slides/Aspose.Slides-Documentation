---
title: 在 PHP 中管理演示文稿占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh/php-java/manage-placeholder/
keywords:
- 占位符
- 文本占位符
- 图片占位符
- 图表占位符
- 内容占位符
- 提示文本
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 检查和编辑文本、图片、图表和内容占位符，并了解占位符继承。"
---
## **概述**

占位符是一种形状，用于在演示文稿模板中为特定类型的内容保留位置。常见示例包括标题、正文、图片、图表以及通用内容占位符。与普通形状不同，占位符可以从布局幻灯片或母版幻灯片继承其位置、大小、格式以及其他设置。

Aspose.Slides 通过 [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) 方法公开占位符信息。该方法返回一个 [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) 对象，普通形状则返回 `null`。使用 [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 可确定占位符预期包含的内容。

了解占位符类型后，形状类仍然重要：

- 空的文本、图片、图表或内容占位符通常由 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 表示。
- 已填充的图片占位符可以由 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 表示。
- 已填充的图表占位符可以由 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) 表示。
- 内容占位符可以包含多种内容。请同时检查 [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 和运行时形状类，而不要假设每个占位符都是 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 描述了占位符的角色；它并不能保证形状的运行时类。在访问文本、图片、图表、表格或媒体特定成员之前，请始终进行类型检查。
{{% /alert %}}

## **了解占位符继承**

占位符形成层级结构：

1. 母版幻灯片定义可重用的样式，并在某些情况下定义母版级别的占位符。
2. 布局幻灯片定义一个或多个普通幻灯片使用的布局，并且可以继承自母版。
3. 普通幻灯片包含该幻灯片的占位符，并且可以继承其布局。

调用 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) 可在此层级向上移动一级。幻灯片占位符通常返回其布局占位符；布局占位符可以返回其母版占位符。当形状没有基础占位符时，方法返回 `null`。

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

在普通幻灯片上编辑占位符会为该幻灯片创建或更改本地覆盖。编辑相关的布局或母版会影响所有仍然继承该设置的幻灯片。本地普通形状没有基础占位符，仅因占据相同坐标而不会开始继承。

## **移除占位符状态**

在改编模板时，使用 [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) 可将现有对象保留为普通形状。其 [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) 方法返回 `null`，但形状仍保留在幻灯片的集合中。相比之下，[ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) 会从该集合中删除形状。

以下示例需要一个包含至少一张幻灯片且第一张幻灯片上有非空文本占位符的 `template.pptx`。使用格式从布局或母版继承的占位符以查看移除该关系的效果。示例检查相同形状仍然存在，对现在的普通形状再次调用该方法，并保存结果。

{{% alert color="warning" title="Warning" %}}
移除占位符状态不会自动保留继承的外观设置。下面的示例故意保持这些设置不变，因此输出可能会有所不同。一个完全继承位置和大小的形状在调用后可能会出现坐标和尺寸为零，虽然仍在集合中，但会变得不可见。
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // 在普通形状上调用此方法没有任何效果。
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

对于匹配的占位符，所有三项检查都会输出 `true`。文本保持不变，但在移除占位符关系后，继承的位置、大小、旋转、字体、段落对齐、文本框边距、垂直锚点、填充和线条设置可能会改变。例如，继承的标题格式可能会回退为普通文本格式。更多布局信息请参阅 [幻灯片布局](/slides/zh/php-java/slide-layout/)。

为了保留预期的外观，在调用之前捕获解析后的位置、大小和旋转，并将所需的有效格式值复制到单独的变量中。通过 [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/)、[ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/)、[TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/)、[FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/)、和 [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/) 获取这些值。不要仅依赖保留有效格式对象，因为在移除关系后，它们的文本格式值可能会改变。随后显式将捕获的值应用于普通形状，包括字体系列、大小、样式、颜色、段落设置、文本框设置、填充和线条等模板使用的属性。

继承的形状几何也可能需要通过 [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) 显式分配。对于矩形文本占位符，这意味着分配 [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)，仅恢复填充和线条可能无法恢复可见的矩形。具有附加效果或更复杂格式的模板也需要相应处理这些设置。

## **更改占位符中的文本**

标题、居中标题、字幕、正文和文本占位符通常支持文本。在使用其 [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) 方法之前，请检查是否为 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。

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

此模式避免将图片、图表、表格或媒体占位符视为 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 对象。它还通过用途识别占位符，而不是依赖脆弱的形状索引。

## **在布局上设置提示文本**

提示文本是在空占位符中显示的设计时指令，例如 *单击以添加标题*。请在布局占位符上设置自定义提示文本，而不是尝试通过普通幻灯片的形状集合访问它。通过 [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) 获取布局，并遍历 [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 返回的集合。

以下示例更改第一张幻灯片使用的布局上的标题和副标题提示：

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

提示文本不是普通幻灯片内容。它用于 PowerPoint 等编辑应用中的空占位符。一旦用户或程序提供真实内容，提示将不再显示。更改提示也不会替换使用该布局的幻灯片上已有的文本。

## **更新图片占位符**

有两种情况需要处理：

- 如果图片占位符已填充并由 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) 表示，则通过 [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) 和 [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage) 替换图像。
- 如果它仍是空占位符，则使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) 在占位符坐标处添加图片框，并删除空占位符。

下面的示例同时支持这两种情况并保存演示文稿：

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

为空占位符创建的替换是本地图片框，而不是新占位符，因为 [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) 没有提供 setter。它保留了预留位置，但不再继承占位符特有的行为。如果保留占位符关系至关重要，请先在 PowerPoint 中准备并填充占位符，然后使用 Aspose.Slides 更新生成的 [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)。

有关图像透明度、裁剪和其他图片特定效果，请参阅 [管理图片框](/slides/zh/php-java/picture-frame/)。这些操作属于图片框或图片填充，而非占位符元数据。

## **使用图表和内容占位符**

已填充的图表占位符可以由 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) 表示。此示例通过占位符类型和运行时类同时查找此类图表，修改其标题并保存文件：

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

通用内容占位符通常具有 [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充当多个内容类型的启动器，包括图表、表格、图示、图片和媒体。填充后，请检查实际的形状类以了解其包含的内容。专用布局还可以公开 [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、或 [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)。

Aspose.Slides 并不会仅通过更改 [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) 将空的 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 占位符转换为 [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)；该类型无法通过类进行更改。要以编程方式填充空的图表或内容区域，请在占位符坐标处添加所需对象，然后删除空占位符。以下示例针对图表执行此操作：

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

添加的图表是普通本地图表。它占据占位符的区域，但不继承布局占位符的属性。当需要替换其类别、系列或工作簿数据时，请使用专门的 [图表管理相关文章](/slides/zh/php-java/powerpoint-charts/)。

## **完整示例：更新文本或图像内容**

以下端到端示例打开模板，在第一张幻灯片中搜索标题或图片占位符，检查占位符和形状类型，更新相应内容并保存输出。示例特意避免假设形状索引或将每个占位符视为相同的类。

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

## **常见问题**

**什么是基础占位符？**

基础占位符是布局或母版上对应的形状，其他占位符从其继承。使用 [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) 可检索它。普通本地形状返回 `null`，因为它不属于占位符层级。

**我可以通过编辑布局占位符更改所有幻灯片的标题吗？**

您可以通过布局更改继承的格式或提示文本，但现有的标题内容存储在普通幻灯片上。要在整个演示文稿中替换实际标题文本，需要遍历幻灯片并更新每个标题占位符。

**如何管理日期、页码、页眉和页脚占位符？**

在相应的幻灯片、布局、母版、备注或讲义范围内使用页眉页脚管理器。完整示例请参阅 [管理演示文稿页眉和页脚](/slides/zh/php-java/presentation-header-and-footer/)。