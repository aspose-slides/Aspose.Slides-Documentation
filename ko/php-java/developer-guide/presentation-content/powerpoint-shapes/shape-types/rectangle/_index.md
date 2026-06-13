---
title: PHP에서 프레젠테이션에 사각형 추가
linktitle: 사각형
type: docs
weight: 80
url: /ko/php-java/rectangle/
keywords:
- 사각형 추가
- 사각형 만들기
- 사각형 모양
- 간단한 사각형
- 서식이 지정된 사각형
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java을 사용하여 사각형을 추가함으로써 PowerPoint 프레젠테이션을 강화하세요 — 프로그램matically 형태를 쉽게 설계하고 수정할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 사각형 모양을 추가하는 방법을 보여줍니다. 간단한 사각형 만들기, 서식이 지정된 사각형 만들기 및 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 방법을 다룹니다.

또한 채우기 색상, 선 색상 및 선 두께와 같은 기본 사각형 서식을 적용하는 방법을 확인할 수 있습니다. 추가로, 문서의 FAQ에서는 둥근 모서리, 그림 채우기, 시각 효과, 하이퍼링크, 도형 잠금, 내보내기 옵션 및 유효 속성과 같은 관련 사각형 작업을 안내합니다.

## **슬라이드에 사각형 추가**
프레젠테이션의 선택된 슬라이드에 간단한 사각형을 추가하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
- ShapeCollection 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 Rectangle 유형의 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 간단한 사각형을 추가했습니다.

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # 타원 유형의 AutoShape을 추가합니다
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **슬라이드에 서식이 지정된 사각형 추가**
슬라이드에 서식이 지정된 사각형을 추가하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
- ShapeCollection 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 Rectangle 유형의 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)을 추가합니다.
- Rectangle의 [Fill Type](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FillType)을 Solid(단색)으로 설정합니다.
- Rectangle와 연결된 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 객체의 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/) 객체가 제공하는 [ColorFormat::setColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/colorformat/#setColor) 메서드를 사용하여 사각형의 색상을 설정합니다.
- Rectangle 선의 색상을 설정합니다.
- Rectangle 선의 두께를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계는 아래 예제에 구현되었습니다.

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # 타원 유형의 AutoShape을 추가합니다
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # 타원 모양에 일부 서식을 적용합니다
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # 타원 선에 일부 서식을 적용합니다
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX 파일을 디스크에 저장합니다
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**둥근 모서리를 가진 사각형을 추가하려면 어떻게 해야 하나요?**

둥근 모서리 [shape type](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapetype/)을 사용하고, 모양의 속성에서 코너 반경을 조정합니다; 기하학적 조정을 통해 각 코너마다 개별적으로 라운딩을 적용할 수도 있습니다.

**사각형을 이미지(텍스처)로 채우려면 어떻게 해야 하나요?**

그림 [fill type](https://reference.aspose.com/slides/ko/php-java/aspose.slides/filltype/)을 선택하고 이미지 소스를 제공한 다음, [stretching/tiling modes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/picturefillmode/)를 구성합니다.

**사각형에 그림자와 글로우를 적용할 수 있나요?**

예. 조정 가능한 매개변수를 가진 [Outer/inner shadow, glow, and soft edges](/slides/ko/php-java/shape-effect/)를 사용할 수 있습니다.

**사각형을 하이퍼링크가 있는 버튼으로 만들 수 있나요?**

예. 도형 클릭 시 (슬라이드, 파일, 웹 주소 또는 이메일로 이동하도록) [Assign a hyperlink](/slides/ko/php-java/manage-hyperlinks/)을 설정합니다.

**사각형이 이동하거나 변경되지 않도록 보호하려면 어떻게 해야 하나요?**

도형 잠금을 사용합니다. 이동, 크기 조정, 선택 또는 텍스트 편집을 금지하여 레이아웃을 유지할 수 있습니다.

**사각형을 래스터 이미지 또는 SVG로 변환할 수 있나요?**

예. 지정된 크기/스케일로 이미지를 만들기 위해 [render the shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getImage)을 사용하거나, 벡터용으로 [export it as SVG](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/writeassvg/)를 사용할 수 있습니다.

**테마와 상속을 고려한 사각형의 실제(유효) 속성을 빠르게 얻으려면 어떻게 해야 하나요?**

[Use the shape’s effective properties](/slides/ko/php-java/shape-effective-properties/)를 사용합니다: API는 테마 스타일, 레이아웃 및 로컬 설정을 고려한 계산된 값을 반환하여 서식 분석을 간소화합니다.