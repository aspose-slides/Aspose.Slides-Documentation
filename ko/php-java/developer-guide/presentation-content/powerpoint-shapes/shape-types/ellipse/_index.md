---
title: PHP에서 프레젠테이션에 타원 추가
linktitle: 타원
type: docs
weight: 30
url: /ko/php-java/ellipse/
keywords:
- 타원
- 도형
- 타원 추가
- 타원 만들기
- 타원 그리기
- 서식이 지정된 타원
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP용 Aspose.Slides에서 Java를 통해 PPT 및 PPTX 프레젠테이션에 타원 모양을 생성, 서식 지정 및 조작하는 방법을 배우세요 — 코드 예제가 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 타원 모양을 추가하는 방법을 보여줍니다. 간단한 타원 만들기, 서식이 지정된 타원 만들기, 그리고 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 과정을 다룹니다. 또한 타원의 위치와 크기 작업, 스태킹 순서 제어, 애니메이션 효과 적용과 같은 관련 질문도 간략히 설명합니다.

## **타원 만들기**
프레젠테이션의 선택된 슬라이드에 간단한 타원을 추가하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/) 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 Ellipse 유형의 AutoShape을 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 첫 번째 슬라이드에 타원을 추가했습니다.

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # 타원 유형의 AutoShape을 추가합니다
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # PPTX 파일을 디스크에 기록합니다
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **서식이 지정된 타원 만들기**
슬라이드에 서식이 지정된 타원을 추가하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/) 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 Ellipse 유형의 AutoShape을 추가합니다.
- 타원의 채우기 유형을 Solid로 설정합니다.
- [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 객체와 연결된 [FillFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fillformat/) 객체가 제공하는 `SolidFillColor::setColor` 메서드를 사용하여 타원의 색을 설정합니다.
- 타원의 선 색을 설정합니다.
- 타원의 선 두께를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 프레젠테이션의 첫 번째 슬라이드에 서식이 지정된 타원을 추가했습니다.

```php
  # PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # 타원 유형의 AutoShape을 추가합니다
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # 타원 도형에 일부 서식을 적용합니다
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # 타원 선에 일부 서식을 적용합니다
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX 파일을 디스크에 기록합니다
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**슬라이드 단위에 대해 타원의 정확한 위치와 크기를 어떻게 지정합니까?**

좌표와 크기는 일반적으로 **포인트** 단위로 지정됩니다. 예측 가능한 결과를 얻으려면 슬라이드 크기를 기준으로 계산하고, 필요한 밀리미터나 인치를 포인트로 변환한 후 값을 할당하십시오.

**다른 객체 위나 아래에 타원을 배치하려면 어떻게 해야 합니까(스태킹 순서 제어)?**

객체를 앞으로 가져오거나 뒤로 보냄으로써 그리기 순서를 조정합니다. 이렇게 하면 타원이 다른 객체 위에 겹치거나 아래에 있는 객체를 드러낼 수 있습니다.

**타원의 등장이나 강조에 애니메이션을 어떻게 적용합니까?**

[적용](/slides/ko/php-java/shape-animation/) 입장, 강조 또는 종료 효과를 도형에 적용하고, 트리거와 타이밍을 구성하여 애니메이션이 언제 어떻게 재생될지 조정합니다.