---
title: Java에서 프레젠테이션 슬라이드의 도형 크기 조정
type: docs
weight: 130
url: /ko/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /ko/java/re-sizing-shapes-on-slide/
keywords:
- 도형 크기 조정
- 도형 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드의 도형을 손쉽게 크기 조정—슬라이드 레이아웃 조정을 자동화하고 생산성을 향상시킵니다."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면 새 차원에 맞게 도형의 크기를 조정하고 위치를 재조정해야 할 수도 있습니다. 이 문서에서는 도형을 수동으로 스케일링하는 방법과 슬라이드, 마스터 및 레이아웃의 표를 처리하는 방법을 보여줍니다.

## **도형 크기 조정**

각 도형의 상대적 위치와 크기를 유지하려면 새로운 슬라이드 너비와 원래 너비의 비율을 사용해 가로 좌표와 너비를 곱합니다. 세로 좌표와 높이에는 해당 높이 비율을 적용합니다.

첫 번째 예제는 슬라이드에 표가 없는 프레젠테이션을 로드하고 슬라이드 크기를 A4로 변경한 뒤 결과를 저장합니다. 이후 루프가 스케일링을 제어하도록 [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-)와 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale)을 사용합니다. 비율은 단위가 없으며 도형의 위치와 크기는 포인트 단위로 측정됩니다. 너비와 높이 비율이 다르면 도형이 왜곡될 수 있으며, 도형 크기를 변경해도 폰트 크기는 스케일링되지 않습니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 독립적인 가로 및 세로 스케일 팩터를 계산합니다.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
표는 별도로 처리해야 합니다: 표 전체 너비와 높이를 지정하는 대신 열 너비와 행 높이를 스케일링합니다. 셀 내용이 더 많은 공간을 필요로 하면 행 높이가 요청된 값보다 크게 유지될 수 있습니다.
{{% /alert %}}

두 번째 예제는 표를 지원하고 마스터와 레이아웃의 도형 및 개별 슬라이드를 처리한 후 크기 조정된 프레젠테이션을 저장합니다. 이 헬퍼는 각 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/)을 처리하면서 [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-)으로 열 너비를, [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-)으로 최소 행 높이를 스케일링합니다. 그런 다음 표 전체 차원을 별도로 스케일링하지 않고 표의 위치만 스케일링합니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // 표의 치수는 열 너비와 행 높이에 의해 제어됩니다.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // 독립적인 가로 및 세로 스케일 팩터를 계산합니다.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // 마스터와 레이아웃, 그리고 개별 슬라이드에 정의된 도형을 크기 조정합니다.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**슬라이드 크기를 조정한 후 도형이 왜 왜곡되거나 잘리는가?**

슬라이드 크기를 변경하면서 도형을 스케일링하지 않으면 도형은 원래 위치와 크기를 유지하고 슬라이드를 벗어날 수 있습니다. 너비와 높이를 다른 비율로 스케일링하면 도형이 왜곡될 수도 있습니다.

**제공된 코드가 모든 도형 유형에 대해 작동합니까?**

첫 번째 예제는 도형 범위를 직접 변경하며 표가 없는 슬라이드를 대상으로 합니다. 두 번째 예제는 표를 별도로 처리합니다. 이러한 예제는 폰트 크기를 스케일링하지 않으며 표 내용이 행 높이를 제한할 수 있으므로 특히 텍스트와 표의 최종 레이아웃을 확인하십시오.

**슬라이드 크기를 조정할 때 표의 크기를 어떻게 조정합니까?**

두 번째 예제에 표시된 대로 열 너비를 너비 비율에 따라, 최소 행 높이를 높이 비율에 따라 스케일링한 다음 표의 위치를 스케일링합니다.

**마스터 슬라이드와 레이아웃 슬라이드에서도 이 크기 조정이 작동합니까?**

예. 두 번째 예제는 [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)와 각 마스터의 [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--)를 순회하면서 도형에 동일한 크기 조정 로직을 적용합니다.

**크기 조정과 함께 슬라이드의 방향(세로/가로)를 변경할 수 있습니까?**

예. 슬라이드 크기를 변경한 후 및 대상 차원을 읽기 전에 [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-)을 호출하면 스케일 팩터가 최종 방향을 반영합니다.

**설정할 수 있는 슬라이드 크기에 제한이 있습니까?**

[SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-)을 사용하여 사용자 지정 슬라이드 크기를 지정할 수 있습니다. 지원되는 차원은 프레젠테이션 형식 및 파일을 여는 애플리케이션에 따라 다릅니다.

**고정 종횡비를 가진 도형이 왜곡되는 것을 어떻게 방지할 수 있나요?**

너비와 높이에 동일한 스케일 팩터를 사용하십시오. 원래 레이아웃을 새 슬라이드 차원에 맞추려면 너비와 높이 비율 중 작은 값을 두 차원과 위치에 모두 적용합니다. 이렇게 하면 비율을 유지하지만 한쪽 가장자리에 사용되지 않은 공간이 남을 수 있습니다.