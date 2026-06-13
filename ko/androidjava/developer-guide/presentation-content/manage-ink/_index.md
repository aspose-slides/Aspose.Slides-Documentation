---
title: Android에서 프레젠테이션 잉크 객체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/androidjava/manage-ink/
keywords:
- 잉크
- 잉크 객체
- 잉크 트레이스
- 잉크 관리
- 잉크 그리기
- 그리기
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "PowerPoint 잉크 객체를 관리—Aspose.Slides for Android로 디지털 잉크를 생성, 편집 및 스타일링합니다. 트레이스, 브러시 색상 및 크기에 대한 Java 코드 샘플을 얻으세요."
---
## **소개**

PowerPoint는 표준이 아닌 도형을 그릴 수 있는 잉크 기능을 제공하며, 이를 사용해 슬라이드의 다른 객체를 강조하거나 연결 및 프로세스를 표시하고 특정 항목에 주의를 끌 수 있습니다.

Aspose.Slides는 잉크 개체를 생성하고 관리하는 데 필요한 모든 잉크 유형(예: [Ink](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ink/) 클래스)을 제공합니다.

## **일반 개체와 잉크 개체의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 도형 객체로 표현됩니다. 도형 객체는 가장 단순한 형태로 객체 자체(프레임)의 영역과 해당 속성을 정의하는 컨테이너입니다. 여기에는 컨테이너 영역 크기, 컨테이너 형태, 컨테이너 배경 등이 포함됩니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/androidjava/shape-manipulations/#access-layout-formats-for-shape)을 참고하십시오.

하지만 PowerPoint가 잉크 개체를 처리할 때는 컨테이너(프레임)의 모든 속성을 무시하고 크기만 사용합니다. 컨테이너 영역의 크기는 표준 `width`와 `height` 값으로 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 형태 트레이스**

트레이스는 사용자가 디지털 잉크로 글을 쓸 때 펜의 궤적을 기록하는 기본 요소 또는 표준입니다. 트레이스는 연결된 점들의 순서를 설명하는 기록입니다.

가장 단순한 인코딩 형태는 각 샘플 점의 X 및 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링되면 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기용 브러시 속성**

브러시를 사용해 트레이스 요소의 점들을 연결하는 선을 그릴 수 있습니다. 브러시에는 `Brush.Color`와 `Brush.Size` 속성에 해당하는 자체 색상과 크기가 있습니다.

### **잉크 브러시 색상 설정**

다음 Java 코드는 브러시 색상을 설정하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **잉크 브러시 크기 설정**

다음 Java 코드는 브러시 크기를 설정하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

일반적으로 브러시의 가로와 세로가 일치하지 않기 때문에 PowerPoint는 브러시 크기를 표시하지 않습니다(데이터 섹션이 회색 처리됨). 하지만 브러시의 가로와 세로가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 보기 위해 잉크 개체의 높이를 늘리고 중요한 치수를 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시 크기를 고려하지 않으며, 항상 선 두께가 0이라고 가정합니다(마지막 이미지 참조).

따라서 전체 잉크 개체의 보이는 영역을 결정하려면 트레이스 개체의 브러시 크기를 고려해야 합니다. 여기서 대상 개체(손글씨 트레이스 개체)는 컨테이너(프레임) 크기에 맞게 스케일링되었습니다. 컨테이너(프레임)의 크기가 변경되면 브러시 크기는 일정하게 유지되고 그 반대도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트를 처리할 때도 동일한 동작을 보입니다:

![ink_powerpoint6](ink_powerpoint6.png)

**추가 참고**

* 일반적인 도형에 대해 읽고 싶다면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/androidjava/powerpoint-shapes/) 섹션을 확인하십시오.
* 유효값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/androidjava/shape-effective-properties/#getting-effective-font-height-value)를 참고하십시오.