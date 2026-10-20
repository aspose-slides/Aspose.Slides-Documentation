---
title: 프레젠테이션 슬라이드에서 PHP로 도형 크기 조정
type: docs
weight: 130
url: /ko/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /ko/php-java/re-sizing-shapes-on-slide/
keywords:
  - 도형 크기 조정
  - 도형 크기 변경
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용해 PowerPoint 및 OpenDocument 슬라이드의 도형 크기를 쉽게 조정하고, 슬라이드 레이아웃을 자동화하여 생산성을 높입니다."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면 새 크기에 맞게 도형을 크기 조정하고 위치를 재조정해야 할 수도 있습니다. 이 문서에서는 도형을 수동으로 확대/축소하는 방법과 슬라이드, 마스터, 레이아웃에서 표를 처리하는 방법을 보여줍니다.

## **도형 크기 조정**

각 도형의 상대적인 위치와 크기를 유지하려면 새 슬라이드 너비와 원래 너비의 비율로 가로 좌표와 너비를 곱합니다. 높이 비율을 사용해 세로 좌표와 높이에도 동일하게 적용합니다.

첫 번째 예제는 슬라이드에 표가 없고, 슬라이드 크기를 A4로 변경한 뒤 결과를 저장합니다. 여기서는 [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/)와 [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/)을 사용해 이후 루프에서 확대/축소를 제어합니다. 비율은 단위가 없으며, 도형 위치와 크기는 포인트 단위로 측정됩니다. 너비와 높이 비율이 다르면 도형이 왜곡될 수 있고, 도형의 크기를 변경해도 글꼴 크기는 확대되지 않습니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // 독립적인 가로 및 세로 배율을 계산합니다.
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
표는 별도로 처리해야 합니다: 전체 너비와 높이를 지정하는 대신 열 너비와 행 높이를 각각 비율에 맞게 조정합니다. 셀 내용이 더 많은 공간을 필요로 하면 행 높이가 요청된 값보다 크게 유지될 수 있습니다.
{{% /alert %}}

두 번째 예제는 표를 지원하고, 마스터와 레이아웃의 도형뿐 아니라 개별 슬라이드의 도형도 처리한 뒤 크기 조정된 프레젠테이션을 저장합니다. 도우미는 각 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)를 [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/)로 열 너비를, [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/)으로 최소 행 높이를 조정합니다. 그런 다음 표 전체 크기를 별도로 조정하지 않고 위치만 확대/축소합니다.
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
                // 표의 치수는 열 너비와 행 높이로 제어됩니다.
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
    // 독립적인 가로 및 세로 배율을 계산합니다.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // 마스터와 레이아웃, 그리고 개별 슬라이드에 정의된 도형을 크기 조정합니다.
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

## **자주 묻는 질문**

**슬라이드 크기를 조정한 후 도형이 왜 왜곡되거나 잘리나요?**

슬라이드 크기를 변경하면서 도형을 확대/축소하지 않으면 도형은 원래 위치와 크기를 유지하므로 슬라이드 경계를 넘어설 수 있습니다. 너비와 높이를 서로 다른 비율로 확대하면 도형이 왜곡될 수도 있습니다.

**제공된 코드가 모든 도형 유형에 대해 작동합니까?**

첫 번째 예제는 도형 경계를 직접 변경하며 표가 없는 슬라이드용으로 설계되었습니다. 두 번째 예제는 표를 별도로 처리합니다. 결과 레이아웃—특히 텍스트와 표—을 확인하십시오. 이 예제들은 글꼴 크기를 확대하지 않으며 표 내용이 행 높이를 제한할 수 있습니다.

**슬라이드 크기를 조정할 때 테이블을 어떻게 크기 조정합니까?**

열 너비를 너비 비율에 맞게, 최소 행 높이를 높이 비율에 맞게 조정한 뒤, 표의 위치만 확대/축소합니다. 두 번째 예제에서와 같이 수행하면 됩니다.

**이 크기 조정이 마스터 슬라이드와 레이아웃 슬라이드에도 적용됩니까?**

예. 두 번째 예제는 [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/)와 각 마스터의 [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/)를 순회하면서 동일한 크기 조정 로직을 도형에 적용합니다.

**크기 조정과 함께 슬라이드 방향(세로/가로)을 변경할 수 있습니까?**

예. 슬라이드 크기를 변경한 뒤, 대상 치수를 읽기 전에 [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/)을 호출하면 최종 방향에 맞는 확대/축소 비율이 적용됩니다.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**

[SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/)를 사용해 사용자 지정 슬라이드 치수를 지정할 수 있습니다. 지원되는 치수는 프레젠테이션 형식 및 파일을 여는 애플리케이션에 따라 달라질 수 있습니다.

**고정 비율을 가진 도형이 왜곡되는 것을 어떻게 방지할 수 있나요?**

가로와 세로에 동일한 확대/축소 비율을 사용하십시오. 원래 레이아웃을 새 슬라이드 치수에 맞추려면 가로와 세로 비율 중 작은 값을 두 차원과 위치에 모두 적용합니다. 이렇게 하면 비율이 유지되지만 한쪽 가장자리마다 사용되지 않은 공간이 남을 수 있습니다.