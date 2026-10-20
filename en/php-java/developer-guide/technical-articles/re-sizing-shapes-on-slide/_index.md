---
title: Resize Shapes on Presentation Slides in PHP
type: docs
weight: 130
url: /php-java/resizing-shapes-on-slide/
aliases:
  /php-java/re-sizing-shapes-on-slide/
keywords:
- resize shape
- change shape size
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Easily resize shapes on PowerPoint and OpenDocument slides with Aspose.Slides for PHP via Java—automate slide layout adjustments and boost productivity."
---

## **Overview**

When you change a presentation's slide size, you may also need to resize and reposition its shapes to fit the new dimensions. This article shows how to scale shapes manually and how to handle tables on slides, masters, and layouts.

## **Resize Shapes**

To preserve each shape's relative position and size, multiply its horizontal coordinates and width by the ratio of the new slide width to the original width. Apply the corresponding height ratio to its vertical coordinates and height.

The first example loads a presentation whose slides contain no tables, changes the slide size to A4, and saves the result. It uses [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) with [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) so that the subsequent loop controls the scaling. The ratios are unitless; shape positions and dimensions are measured in points. Different width and height ratios can distort shapes, and changing a shape's dimensions does not scale its font sizes.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Calculate independent horizontal and vertical scale factors.
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

Tables require separate handling: scale their column widths and row heights instead of assigning the table's overall width and height. Row heights may remain larger than requested if the cell content requires more space.

{{% /alert %}}

The second example supports tables and processes shapes on masters and layouts as well as individual slides before saving the resized presentation. Its helper handles each [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) by scaling column widths with [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) and minimum row heights with [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). It then scales the table's position without separately scaling its overall dimensions.

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
                // Table dimensions are controlled by column widths and row heights.
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
    // Calculate independent horizontal and vertical scale factors.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Resize shapes defined on masters and layouts as well as individual slides.
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

## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**

If you change the slide size without scaling the shapes, they keep their original positions and dimensions and may extend beyond the slide. Scaling width and height by different ratios can also distort shapes.

**Does the provided code work for all shape types?**

The first example changes shape bounds directly and is intended for slides without tables. The second example handles tables separately. Check the resulting layout, particularly text and tables, because these examples do not scale font sizes and table content can constrain row heights.

**How do I resize tables when resizing a slide?**

Scale column widths by the width ratio and minimum row heights by the height ratio, then scale the table's position, as shown in the second example.

**Will this resizing work for master slides and layout slides?**

Yes. The second example iterates through [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) and each master's [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) and applies the same resizing logic to their shapes.

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. Call [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) after changing the slide size and before reading the target dimensions, so the scale factors reflect the final orientation.

**Is there a limit to the slide size I can set?**

You can specify custom slide dimensions with [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). The supported dimensions also depend on the presentation format and the application used to open the file.

**How can I prevent shapes with a fixed aspect ratio from becoming distorted?**

Use the same scale factor for width and height. To fit the original layout within the new slide dimensions, use the smaller of the width and height ratios for both dimensions and positions. This preserves proportions but may leave unused space along one edge.
