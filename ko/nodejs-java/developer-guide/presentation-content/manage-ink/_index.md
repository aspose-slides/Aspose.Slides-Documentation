---
title: JavaScript에서 프레젠테이션 잉크 객체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/nodejs-java/manage-ink/
keywords:
- 잉크
- 잉크 객체
- 잉크 트레이스
- 잉크 관리
- 잉크 그리기
- 그리기
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint 잉크 객체를 관리합니다—Aspose.Slides for Node.js를 사용해 디지털 잉크를 생성, 편집 및 스타일링합니다. 트레이스, 브러시 색상 및 크기에 대한 JavaScript 코드 샘플을 확인하세요."
---
## **소개**

PowerPoint는 비표준 도형을 그릴 수 있도록 잉크 기능을 제공하며, 이를 사용해 다른 개체를 강조하거나 연결 및 프로세스를 표시하고 슬라이드의 특정 항목에 주의를 끌 수 있습니다. 

Aspose.Slides는 잉크 객체를 생성하고 관리하는 데 필요한 모든 Ink 유형(예: [Ink](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ink/) 클래스)을 제공합니다.

## **일반 객체와 잉크 객체의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 도형 객체로 표현됩니다. 가장 단순한 형태의 도형 객체는 개체 자체(프레임)의 영역을 정의하는 컨테이너와 해당 속성을 포함합니다. 여기에는 컨테이너 영역 크기, 컨테이너 모양, 컨테이너 배경 등이 포함됩니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/nodejs-java/shape-manipulations/#access-layout-formats-for-shape)를 참고하십시오.

하지만 PowerPoint가 잉크 객체를 처리할 때는 컨테이너의 크기 외에는 프레임(컨테이너) 속성을 모두 무시합니다. 컨테이너 영역의 크기는 표준 `width`와 `height` 값으로 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 형태 트레이스**

트레이스는 사용자가 디지털 잉크로 필기할 때 펜의 궤적을 기록하기 위해 사용되는 기본 요소 또는 표준입니다. 트레이스는 연결된 점들의 연속을 설명하는 기록입니다. 

가장 단순한 인코딩 형태는 각 샘플 점의 X와 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링되면 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## 그리기용 브러시 속성

브러시를 사용하여 트레이스 요소의 점들을 연결하는 선을 그릴 수 있습니다. 브러시에는 자체 색상과 크기가 있으며, 이는 `Brush.setColor` 및 `Brush.setSize` 메서드에 해당합니다. 

### **잉크 브러시 색상 설정**

다음 JavaScript 코드는 브러시 색상을 설정하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **잉크 브러시 크기 설정** 

다음 JavaScript 코드는 브러시 크기를 설정하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

일반적으로 브러시의 너비와 높이는 일치하지 않으므로 PowerPoint는 브러시 크기를 표시하지 않습니다(데이터 섹션이 회색으로 표시). 그러나 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 하기 위해 잉크 객체의 높이를 늘리고 중요한 치수를 검토해 보겠습니다: 

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시의 크기를 고려하지 않으며—항상 선의 두께를 0으로 가정합니다(마지막 이미지 참조). 

따라서 전체 잉크 객체의 표시 영역을 결정하려면 트레이스 객체의 브러시 크기를 고려해야 합니다. 여기서 대상 객체(필기 텍스트 트레이스 객체)는 컨테이너(프레임) 크기에 맞게 스케일링되었습니다. 컨테이너(프레임) 크기가 변경될 때 브러시 크기는 일정하게 유지되고 그 반대도 마찬가지입니다. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트를 처리할 때도 동일한 동작을 보입니다:

![ink_powerpoint6](ink_powerpoint6.png)

**추가 자료**

* 도형 전반에 대해 읽고 싶다면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/nodejs-java/powerpoint-shapes/) 섹션을 참고하십시오.
* 유효값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/nodejs-java/shape-effective-properties/#getting-effective-font-height-value)를 확인하십시오.