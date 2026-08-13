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
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드의 도형을 쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 높입니다."
---
## **개요**

Aspose.Slides for Java 고객이 가장 흔히 묻는 질문 중 하나는 슬라이드 크기가 변경될 때 데이터가 잘리지 않도록 도형의 크기를 조정하는 방법이다. 이 짧은 기술 문서에서는 그 방법을 보여준다.

## **도형 크기 조정**

슬라이드 크기가 변경될 때 도형이 어긋나는 것을 방지하려면 각 도형의 위치와 크기를 새 슬라이드 레이아웃에 맞게 업데이트합니다.

```java
import com.aspose.slides.*;

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

    // 각 슬라이드의 도형 크기를 조정하고 위치를 재설정합니다.
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

{{% alert color="info" %}} 
표는 특별히 처리할 필요가 없습니다. 표의 너비와 높이를 설정하면 해당 열과 행이 비례적으로 재조정되므로 행 높이와 열 너비를 다시 스케일링하면 비율이 두 번 적용됩니다.
{{% /alert %}} 

위 코드는 슬라이드에 있는 도형만 변경합니다. 마스터 슬라이드와 레이아웃 슬라이드에는 자체 도형이 있으므로 전체 프레젠테이션이 새 슬라이드 크기를 따르도록 하려면 이들 역시 스케일링해야 합니다:

```java
import com.aspose.slides.*;

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
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

### 슬라이드 크기 조정 후 도형이 왜 왜곡되거나 잘리나요?

슬라이드 크기를 조정할 때 스케일을 명시적으로 변경하지 않으면 도형은 원래 위치와 크기를 유지합니다. 이로 인해 콘텐츠가 잘리거나 도형이 어긋날 수 있습니다.

### 제공된 코드가 모든 도형 유형에 적용되나요?

예합니다. 높이와 너비를 설정하면 텍스트 상자, 이미지, 차트, 표 모두에 적용됩니다.

### 슬라이드 크기를 조정할 때 표는 어떻게 크기를 조정하나요?

표 도형 자체를 다른 도형과 마찬가지로 스케일링합니다. 행과 열이 비례적으로 따라오므로 이후에 다시 스케일링하지 마세요.

### 이 크기 조정이 마스터 슬라이드와 레이아웃 슬라이드에도 적용되나요?

예, 하지만 [Masters](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getMasters--)와 [Layout slides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getLayoutSlides--)을 순회하면서 각 도형에 동일한 스케일링 로직을 적용해야 프레젠테이션 전반에 일관성을 유지할 수 있습니다.

### 슬라이드 방향(세로/가로)을 크기 조정과 함께 변경할 수 있나요?

예. [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidesize/#setOrientation-int-)을 사용해 방향을 변경할 수 있습니다. 레이아웃을 유지하려면 스케일링 로직을 그에 맞게 설정하세요.

### 설정할 수 있는 슬라이드 크기에 제한이 있나요?

Aspose.Slides는 사용자 정의 크기를 지원하지만, 매우 큰 크기는 성능이나 일부 PowerPoint 버전과의 호환성에 영향을 줄 수 있습니다.

### 고정 종횡비 도형이 왜곡되는 것을 어떻게 방지할 수 있나요?

스케일링하기 전에 도형의 `getAspectRatioLocked` 메서드를 확인할 수 있습니다. 잠겨 있다면 개별적으로 스케일링하기보다 너비와 높이를 비례적으로 조정하세요.