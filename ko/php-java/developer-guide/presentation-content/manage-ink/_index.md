---
title: PHP에서 프레젠테이션 잉크 개체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/php-java/manage-ink/
keywords:
- 잉크
- 잉크 개체
- 잉크 트레이스
- 잉크 관리
- 잉크 그리기
- 그리기
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PowerPoint 잉크 개체를 관리합니다 — Aspose.Slides for PHP via Java를 사용해 디지털 잉크를 생성, 편집 및 스타일링합니다. 트레이스, 브러시 색상 및 크기에 대한 코드 샘플을 확인하세요."
---
## **소개**

PowerPoint는 표준이 아닌 도형을 그릴 수 있는 잉크 기능을 제공하며, 이를 통해 다른 개체를 강조하거나 연결 및 프로세스를 표시하고 슬라이드의 특정 항목에 주의를 끌 수 있습니다.

Aspose.Slides는 잉크 개체를 만들고 관리하는 데 필요한 모든 Ink 유형(예: [Ink](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ink/) 클래스)을 제공합니다.

## **일반 개체와 잉크 개체의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 도형 개체로 표현됩니다. 도형 개체는 가장 간단한 형태로 개체 자체(프레임)의 영역을 정의하는 컨테이너와 해당 속성을 포함합니다. 여기에는 컨테이너 영역 크기, 컨테이너 형태, 컨테이너 배경 등이 포함됩니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/php-java/shape-manipulations/#access-layout-formats-for-shape)을 참고하세요.

하지만 PowerPoint가 잉크 개체를 처리할 때는 컨테이너(프레임)의 모든 속성을 무시하고 크기만 사용합니다. 컨테이너 영역의 크기는 표준 `width`와 `height` 값으로 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Traces**

Trace는 사용자가 디지털 잉크를 필기할 때 펜의 궤적을 기록하기 위해 사용되는 기본 요소 또는 표준입니다. Trace는 연결된 점들의 순서를 설명하는 기록입니다.

가장 간단한 인코딩 형태는 각 샘플 점의 X와 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링되면 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기를 위한 Brush 속성**

Brush를 사용하여 Trace 요소들의 점을 연결하는 선을 그릴 수 있습니다. Brush는 `Brush.Color`와 `Brush.Size` 속성에 해당하는 자체 색상과 크기를 가집니다.

### **Ink Brush 색상 설정**

다음 PHP 코드는 Brush 색상을 설정하는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ink Brush 크기 설정**

다음 PHP 코드는 Brush 크기를 설정하는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

일반적으로 Brush의 가로와 세로 크기가 일치하지 않으므로 PowerPoint는 Brush 크기를 표시하지 않으며(데이터 섹션이 회색 처리됨) 가로와 세로가 일치할 때는 다음과 같이 크기가 표시됩니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 하기 위해 잉크 개체의 높이를 늘이고 중요한 차원을 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 Brush의 크기를 고려하지 않으며—항상 선의 두께가 0이라고 가정합니다(마지막 이미지 참조).

따라서 전체 잉크 개체의 가시 영역을 결정하려면 Trace 개체들의 Brush 크기를 고려해야 합니다. 여기서 대상 개체(필기 텍스트 Trace 개체)는 컨테이너(프레임) 크기에 맞게 스케일링되었습니다. 컨테이너(프레임)의 크기가 변경되면 Brush 크기는 일정하게 유지되고, 그 반대도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트를 처리할 때도 동일한 동작을 보입니다:

![ink_powerpoint6](ink_powerpoint6.png)

**추가 자료**

* 도형에 대해 전반적으로 읽고 싶다면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/php-java/powerpoint-shapes/) 섹션을 참조하세요.
* 실제값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/php-java/shape-effective-properties/#getting-effective-font-height-value)를 확인하세요.