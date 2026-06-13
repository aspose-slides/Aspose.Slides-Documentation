---
title: 프레젠테이션 슬라이드에서 도형 크기 조정
type: docs
weight: 110
url: /ko/java/re-sizing-shapes-on-slide/
keywords:
- 도형 크기 조정
- 도형 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 도형을 쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 높여줍니다."
---
## **개요**

Aspose.Slides for Java 고객이 가장 많이 묻는 질문 중 하나는 슬라이드 크기가 변경될 때 데이터가 잘리지 않도록 도형의 크기를 조정하는 방법입니다. 이 짧은 기술 문서에서는 그 방법을 보여 줍니다.

## **모양 크기 조정**

슬라이드 크기가 변경될 때 도형이 정렬이 흐트러지지 않도록, 각 도형의 위치와 크기를 새 슬라이드 레이아웃에 맞게 업데이트합니다.

```java
// 프레젠테이션 파일을 로드합니다.
Presentation presentation = new Presentation("sample.ppt");
try {
    // 원본 슬라이드 크기를 가져옵니다.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 기존 도형을 스케일링하지 않고 슬라이드 크기를 변경합니다.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 새 슬라이드 크기를 가져옵니다.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 모든 슬라이드의 도형 크기를 조정하고 위치를 재설정합니다.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // 도형 크기를 스케일링합니다.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 도형 위치를 스케일링합니다.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}} 
슬라이드에 표가 포함된 경우 위 코드는 올바르게 작동하지 않습니다. 이 경우 표의 각 셀을 개별적으로 크기 조정해야 합니다.
{{% /alert %}} 

표가 포함된 슬라이드를 크기 조정하려면 다음 코드를 사용하십시오. 표의 너비나 높이를 설정하는 것은 특수한 경우이며, 전체 표 크기를 변경하려면 개별 행 높이와 열 너비를 조정해야 합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // 원본 슬라이드 크기를 가져옵니다.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // 기존 도형을 스케일링하지 않고 슬라이드 크기를 변경합니다.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // 새 슬라이드 크기를 가져옵니다.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // 도형 크기를 스케일링합니다.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 도형 위치를 스케일링합니다.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // 도형 크기를 스케일링합니다.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // 도형 위치를 스케일링합니다.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // 도형 크기를 스케일링합니다.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // 도형 위치를 스케일링합니다.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**슬라이드 크기 조정 후 도형이 왜 왜곡되거나 잘리나요?**

슬라이드를 크기 조정할 때, 별도로 비율을 변경하지 않으면 도형은 원래 위치와 크기를 유지합니다. 이로 인해 내용이 잘리거나 도형이 정렬이 흐트러질 수 있습니다.

**제공된 코드가 모든 도형 유형에 적용되나요?**

기본 예제는 대부분의 도형 유형(텍스트 상자, 이미지, 차트 등)에 적용됩니다. 그러나 표의 경우 행과 열을 별도로 처리해야 합니다. 표의 높이와 너비는 개별 셀의 크기에 따라 결정되기 때문입니다.

**슬라이드 크기 조정 시 표는 어떻게 크기 조정하나요?**

표의 모든 행과 열을 순회하며 높이와 너비를 비례적으로 조정하면 됩니다. 두 번째 코드 예제에 나와 있습니다.

**이 크기 조정이 마스터 슬라이드와 레이아웃 슬라이드에도 적용되나요?**

예, 적용됩니다. 프레젠테이션의 [마스터](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getMasters--)와 [레이아웃 슬라이드](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getLayoutSlides--)를 순회하면서 동일한 스케일링 논리를 적용해 프레젠테이션 전체의 일관성을 유지해야 합니다.

**슬라이드 방향(세로/가로)을 변경하면서 크기를 조정할 수 있나요?**

예. [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidesize/#setOrientation-int-)을 사용해 방향을 변경할 수 있습니다. 레이아웃을 유지하려면 스케일링 논리를 그에 맞게 설정해야 합니다.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**

Aspose.Slides는 사용자 지정 크기를 지원하지만, 매우 큰 크기는 성능에 영향을 주거나 일부 PowerPoint 버전과의 호환성 문제를 일으킬 수 있습니다.

**고정된 종횡비 도형이 왜곡되는 것을 어떻게 방지하나요?**

도형을 스케일링하기 전에 `getAspectRatioLocked` 메서드를 확인합니다. 잠겨 있는 경우 개별적으로 가로·세로를 스케일링하지 말고 비례적으로 너비 또는 높이를 조정합니다.