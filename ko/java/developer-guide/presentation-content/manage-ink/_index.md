---
title: Java에서 프레젠테이션 잉크 개체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/java/manage-ink/
keywords:
- 잉크
- 잉크 개체
- 잉크 트레이스
- 잉크 관리
- 잉크 그리기
- 그리기
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "PowerPoint 잉크 개체 관리—Aspose.Slides for Java를 사용해 디지털 잉크를 생성, 편집 및 스타일링합니다. 트레이스, 브러시 색상 및 크기 등에 대한 코드 샘플을 얻으세요."
---
## **소개**

PowerPoint는 비표준 도형을 그릴 수 있는 잉크 기능을 제공하며, 이를 사용하여 다른 개체를 강조하고, 연결 및 프로세스를 표시하며, 슬라이드의 특정 항목에 주의를 끌 수 있습니다.

Aspose.Slides는 잉크 개체를 생성하고 관리하는 데 필요한 모든 Ink 유형(예: [Ink](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ink/) 클래스)을 제공합니다.

## **일반 개체와 잉크 개체 간의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 도형 개체로 표시됩니다. 도형 개체는 가장 간단한 형태로 개체 자체의 영역(프레임)을 정의하는 컨테이너와 해당 속성을 포함합니다. 여기에는 컨테이너 영역 크기, 컨테이너 모양, 컨테이너 배경 등이 포함됩니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/java/shape-manipulations/#access-layout-formats-for-shape)을 참조하십시오.

하지만 PowerPoint가 잉크 개체를 처리할 때는 컨테이너의 속성을 모두 무시하고 크기만 사용합니다. 컨테이너 영역의 크기는 표준 `width`와 `height` 값에 의해 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape 트레이스**

Trace는 사용자가 디지털 잉크로 필기할 때 펜의 궤적을 기록하는 기본 요소 또는 표준입니다. Trace는 연결된 점들의 순서를 설명하는 기록입니다.

가장 간단한 인코딩 형태는 각 샘플 점의 X 및 Y 좌표를 지정하는 것입니다. 모든 연결된 점이 렌더링되면 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기용 브러시 속성**

브러시를 사용하여 Trace 요소의 점들을 연결하는 선을 그릴 수 있습니다. 브러시에는 자체 색상과 크기가 있으며, 이는 `Brush.Color` 및 `Brush.Size` 속성에 해당합니다.

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

일반적으로 브러시의 너비와 높이는 일치하지 않으므로 PowerPoint는 브러시 크기를 표시하지 않습니다(데이터 섹션이 회색으로 표시됩니다). 그러나 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 보기 위해 잉크 개체의 높이를 증가시키고 중요한 차원을 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시 크기를 고려하지 않으며, 항상 선의 두께가 0이라고 가정합니다(마지막 이미지를 참조하십시오).

따라서 전체 잉크 개체의 표시 영역을 결정하려면 Trace 개체의 브러시 크기를 고려해야 합니다. 여기서 대상 개체(손글씨 텍스트 Trace 개체)는 컨테이너(프레임) 크기에 맞게 확대되었습니다. 컨테이너(프레임)의 크기가 변경되면 브러시 크기는 일정하게 유지되며 그 반대도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트를 처리할 때도 동일한 동작을 보입니다:

![ink_powerpoint6](ink_powerpoint6.png)

**추가 읽을거리**

* 일반적인 도형에 대해 읽으려면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/java/powerpoint-shapes/) 섹션을 참조하십시오. 
* 효과적인 값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/java/shape-effective-properties/#getting-effective-font-height-value)를 참조하십시오.