---
title: Android에서 프레젠테이션 슬라이드의 도형 크기 조정
type: docs
weight: 130
url: /ko/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/re-sizing-shapes-on-slide/
keywords:
  - 도형 크기 조정
  - 도형 크기 변경
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - Android
  - Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides로 PowerPoint 및 OpenDocument 슬라이드의 도형을 손쉽게 크기 조정하여 슬라이드 레이아웃 조정을 자동화하고 생산성을 높입니다."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면 새 치수에 맞게 도형의 크기를 조정하고 위치를 재배치해야 할 수도 있습니다. 이 문서에서는 도형을 수동으로 확대/축소하는 방법과 슬라이드, 마스터 및 레이아웃의 표를 처리하는 방법을 보여줍니다.

## **도형 크기 조정**

각 도형의 상대적인 위치와 크기를 유지하려면 새 슬라이드 너비와 원래 너비의 비율로 가로 좌표와 너비를 곱합니다. 세로 좌표와 높이에 대해서는 해당 높이 비율을 적용합니다.

첫 번째 예제는 슬라이드에 표가 없는 프레젠테이션을 로드하고, 슬라이드 크기를 A4로 변경한 다음 결과를 저장합니다. 이 예제는 [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-)을 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale)와 함께 사용하여 이후 루프에서 확대/축소를 제어합니다. 비율은 단위가 없으며, 도형 위치와 크기는 포인트 단위로 측정됩니다. 서로 다른 너비와 높이 비율을 사용하면 도형이 왜곡될 수 있으며, 도형의 크기를 변경해도 글꼴 크기는 확대/축소되지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // 독립적인 가로 및 세로 배율을 계산합니다.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
표는 별도로 처리해야 합니다: 표 전체 너비와 높이를 지정하는 대신 열 너비와 행 높이를 확대/축소합니다. 셀 내용에 더 많은 공간이 필요하면 행 높이가 요청된 것보다 크게 남을 수 있습니다.
{{% /alert %}}

두 번째 예제는 표를 지원하고, 리사이즈된 프레젠테이션을 저장하기 전에 마스터와 레이아웃 및 개별 슬라이드의 도형을 처리합니다. 이 도우미는 각 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/)을 [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-)으로 열 너비를, [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-)으로 최소 행 높이를 확대/축소하여 처리합니다. 그런 다음 표 전체 차원을 별도로 확대/축소하지 않고 표의 위치만 확대/축소합니다.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // 표 크기는 열 너비와 행 높이로 제어됩니다.
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
        // 독립적인 가로 및 세로 배율을 계산합니다.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

        // 마스터와 레이아웃, 개별 슬라이드에 정의된 도형을 크기 조정합니다.
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

## **자주 묻는 질문**

**슬라이드 크기를 조정한 후 도형이 왜 왜곡되거나 잘리는가?**

슬라이드 크기를 변경하면서 도형을 확대/축소하지 않으면 도형은 원래 위치와 크기를 유지하고 슬라이드 밖으로 넘어갈 수 있습니다. 너비와 높이를 서로 다른 비율로 확대/축소하면 도형이 왜곡될 수도 있습니다.

**제공된 코드가 모든 도형 유형에서 작동합니까?**

첫 번째 예제는 도형 경계를 직접 변경하며 표가 없는 슬라이드용으로 설계되었습니다. 두 번째 예제는 표를 별도로 처리합니다. 결과 레이아웃, 특히 텍스트와 표를 확인하십시오. 이 예제들은 글꼴 크기를 확대/축소하지 않으며 표 내용이 행 높이를 제한할 수 있기 때문입니다.

**슬라이드 크기를 조정할 때 표를 어떻게 리사이즈합니까?**

두 번째 예제에 표시된 대로, 열 너비를 너비 비율로, 최소 행 높이를 높이 비율로 확대/축소한 다음 표의 위치를 확대/축소합니다.

**마스터 슬라이드와 레이아웃 슬라이드에도 이 크기 조정이 적용됩니까?**

예. 두 번째 예제는 [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--)와 각 마스터의 [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--)를 순회하면서 도형에 동일한 리사이즈 로직을 적용합니다.

**리사이즈와 함께 슬라이드 방향(세로/가로)을 변경할 수 있나요?**

예. 슬라이드 크기를 변경한 후 대상 치수를 읽기 전에 [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-)을 호출하면 축척 계수가 최종 방향을 반영합니다.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**

맞춤 슬라이드 치수는 [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-)을 사용하여 지정할 수 있습니다. 지원되는 치수는 프레젠테이션 형식 및 파일을 여는 애플리케이션에 따라 달라집니다.

**고정 종횡비를 가진 도형이 왜곡되는 것을 어떻게 방지할 수 있나요?**

너비와 높이에 동일한 축척 계수를 사용하십시오. 원래 레이아웃을 새 슬라이드 치수에 맞추려면 너비와 높이 비율 중 작은 값을 두 차원과 위치 모두에 적용합니다. 이렇게 하면 비율은 유지되지만 한쪽 가장자리에 사용되지 않은 공간이 남을 수 있습니다.