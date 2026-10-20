---
title: 在 PHP 中调整演示文稿幻灯片上的形状大小
type: docs
weight: 130
url: /zh/php-java/resizing-shapes-on-slide/
aliases:
  - /zh/php-java/re-sizing-shapes-on-slide/
  /php-java/重新调整-形状-幻灯片/
keywords:
- 调整形状大小
- 更改形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，轻松在 PowerPoint 和 OpenDocument 幻灯片上调整形状大小——实现幻灯片布局自动化并提升生产力。"
---
## **概述**

当您更改演示文稿的幻灯片尺寸时，可能还需要调整其形状的大小和位置以适应新尺寸。本文介绍了如何手动缩放形状以及如何处理幻灯片、母版和布局上的表格。

## **调整形状大小**

为了保持每个形状的相对位置和大小，将其水平坐标和宽度乘以新幻灯片宽度与原始宽度的比例。将相应的高度比例应用于其垂直坐标和高度。

第一个示例加载一个幻灯片中不包含表格的演示文稿，将幻灯片尺寸更改为 A4，并保存结果。它使用 [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) 与 [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/)，以便后续循环控制缩放。比例是无单位的；形状的位置和尺寸以点为单位测量。不同的宽度和高度比例会导致形状失真，且更改形状的尺寸不会缩放其字体大小。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // 计算独立的水平和垂直缩放因子。
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
表格需要单独处理：缩放其列宽和行高，而不是直接设置表格的整体宽度和高度。如果单元格内容需要更多空间，行高可能会保持大于请求的值。
{{% /alert %}}

第二个示例支持表格，并在保存已调整大小的演示文稿之前处理母版、布局以及各个幻灯片上的形状。它的帮助程序通过使用 [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) 缩放列宽和使用 [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) 缩放最小行高来处理每个 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)。然后，它在不单独缩放整体尺寸的情况下缩放表格的位置。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // 表格尺寸由列宽和行高控制。
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
        // 计算独立的水平和垂直缩放因子。
        $originalSize = $presentation->getSlideSize()->getSize();
        $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
        $targetSize = $presentation->getSlideSize()->getSize();
        $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
        $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

        $resizer = new ShapeResizer();

        // 调整在母版、布局以及单个幻灯片上定义的形状大小。
        for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
            $master = $presentation->getMasters()->get_Item($masterIndex);
            $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

            for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
                $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
                $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
            }
        }

        for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
            $slide = $presentation->getSlides()->get_Item($slideIndex);
            $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
        }

        $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **常见问题**

**为什么在调整幻灯片大小后形状会失真或被截断？**

如果在更改幻灯片尺寸时未对形状进行缩放，它们会保持原始位置和尺寸，可能会超出幻灯片范围。使用不同的比例缩放宽度和高度也会导致形状失真。

**提供的代码适用于所有形状类型吗？**

第一个示例直接更改形状边界，适用于没有表格的幻灯片。第二个示例单独处理表格。检查生成的布局，特别是文本和表格，因为这些示例不会缩放字体大小，且表格内容可能限制行高。

**在调整幻灯片大小时如何调整表格大小？**

按宽度比例缩放列宽，按高度比例缩放最小行高，然后如第二个示例所示缩放表格的位置。

**此调整大小方法适用于母版幻灯片和布局幻灯片吗？**

是的。第二个示例遍历 [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) 和每个母版的 [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/)，并将相同的调整大小逻辑应用于它们的形状。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。请在更改幻灯片尺寸后、读取目标尺寸之前调用 [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/)，以便比例因子反映最终方向。

**我可以设置的幻灯片尺寸有限制吗？**

您可以使用 [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) 指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿格式以及用于打开文件的应用程序。

**如何防止具有固定宽高比的形状被拉伸失真？**

对宽度和高度使用相同的比例因子。为了在新幻灯片尺寸内保持原始布局，请对宽度和高度均采用宽高比例中较小的那个来进行尺寸和位置的缩放。这样可以保持比例，但可能在某一边留下未使用的空间。