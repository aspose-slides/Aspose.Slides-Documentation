---
title: 在 PHP 中调整演示文稿幻灯片上的形状大小
type: docs
weight: 130
url: /zh/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /zh/php-java/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 更改形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，轻松调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整并提升生产力。"
---
## **概述**

当您更改演示文稿的幻灯片大小时，可能还需要调整形状的大小并重新定位它们以适应新尺寸。本文展示了如何手动缩放形状以及如何处理幻灯片、母版和布局上的表格。

## **调整形状大小**

为了保持每个形状的相对位置和尺寸，需要将其水平坐标和宽度乘以新的幻灯片宽度与原始宽度的比例。将相同的高度比例应用于其垂直坐标和高度。

第一个示例加载一个幻灯片中不包含表格的演示文稿，将幻灯片大小更改为 A4 并保存结果。它使用 [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) 与 [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) 以便后续循环控制缩放。比例是无单位的；形状的位置和尺寸以点为单位。不同的宽高比例会导致形状变形，并且修改形状尺寸不会缩放其字体大小。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // 计算独立的水平和垂直比例因子。
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
表格需要单独处理：应按列宽和行高的比例进行缩放，而不是直接为表格设置整体宽度和高度。如果单元格内容需要更多空间，行高可能会保持大于请求的高度。
{{% /alert %}}

第二个示例支持表格，并在保存已调整大小的演示文稿之前，对母版、布局以及各个幻灯片上的形状进行处理。它的辅助方法通过使用 [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) 缩放列宽，并使用 [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) 缩放最小行高来处理每个 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)。随后，它在不单独缩放整体尺寸的情况下，缩放表格的位置。

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
    // 计算独立的水平和垂直比例因子。
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // 调整在母版、布局以及单独幻灯片上定义的形状大小。
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

**为什么在调整幻灯片大小后形状会被扭曲或被截断？**

如果在更改幻灯片大小时未对形状进行缩放，它们会保持原始位置和尺寸，可能会超出幻灯片范围。使用不同的宽高比例进行缩放也会导致形状变形。

**提供的代码适用于所有形状类型吗？**

第一个示例直接修改形状边界，适用于没有表格的幻灯片。第二个示例单独处理表格。请检查生成的布局，尤其是文本和表格，因为这些示例不缩放字体大小，表格内容可能限制行高。

**在调整幻灯片大小时如何调整表格？**

按宽度比例缩放列宽，按高度比例缩放最小行高，然后如第二个示例所示缩放表格的位置。

**此调整大小方法适用于母版幻灯片和布局幻灯片吗？**

是的。第二个示例会遍历 [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) 和每个母版的 [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/)，并对它们的形状应用相同的调整大小逻辑。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。在更改幻灯片大小后、读取目标尺寸之前调用 [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/)，这样比例因子会反映最终的方向。

**幻灯片大小是否有设置上限？**

您可以使用 [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) 指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿格式以及用于打开文件的应用程序。

**如何防止具有固定宽高比的形状被扭曲？**

对宽度和高度使用相同的比例因子。为了在新幻灯片尺寸内保持原始布局，可使用宽高比例中较小的那个作为宽度和高度以及位置的统一比例因子。这可以保持比例，但可能在某一边留下未使用的空间。