---
title: PHP에서 프레젠테이션에 선 모양 추가
linktitle: 선
type: docs
weight: 50
url: /ko/php-java/Line/
keywords:
- 선
- 선 만들기
- 선 추가
- 일반 선
- 선 구성
- 선 사용자 지정
- 대시 스타일
- 화살표 머리
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 선 서식을 조작하는 방법을 학습합니다. 속성, 메서드 및 예제를 확인하세요."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 슬라이드에 선 모양을 추가할 수 있습니다. 이 문서에서는 간단한 선을 만드는 방법과 선을 화살표처럼 표시하도록 사용자 지정하는 방법을 보여줍니다.

슬라이드에 선 모양을 추가하고, 시각적 모양을 조정한 뒤, 업데이트된 프레젠테이션을 저장하는 방법을 배웁니다. 예제에서는 스타일, 너비, 대시 패턴, 화살표 머리 옵션 및 채우기 색상과 같은 실용적인 선 서식 설정에 중점을 둡니다.

## **일반 선 만들기**

선택한 슬라이드에 간단한 일반 선을 추가하려면 다음 단계를 따르십시오:

- Presentation 클래스의 인스턴스를 생성합니다.([Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation))
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- ShapeCollection 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 Line 유형의 AutoShape를 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 선을 추가했습니다.

```php
  # PPTX 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # 라인 유형의 AutoShape를 추가합니다
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # PPTX를 디스크에 저장합니다
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **화살표 모양 선 만들기**

Aspose.Slides for PHP via Java은 개발자가 선의 일부 속성을 구성하여 더 매력적으로 보이게 할 수도 있습니다. 선을 화살표처럼 보이게 몇 가지 속성을 구성해 보겠습니다. 다음 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.([Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation))
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- ShapeCollection 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용하여 Line 유형의 AutoShape를 추가합니다.
- Aspose.Slides for PHP via Java에서 제공하는 스타일 중 하나로 [Line Style](https://reference.aspose.com/slides/ko/php-java/aspose.slides/LineStyle)을 설정합니다.
- 선의 너비를 설정합니다.
- Aspose.Slides for PHP via Java에서 제공하는 스타일 중 하나로 선의 [Dash Style](https://reference.aspose.com/slides/ko/php-java/aspose.slides/LineDashStyle)을 설정합니다.
- 선의 시작점에 대한 [Arrow Head Style](https://reference.aspose.com/slides/ko/php-java/aspose.slides/LineArrowheadStyle) 및 [Length](https://reference.aspose.com/slides/ko/php-java/aspose.slides/LineArrowheadLength)을 설정합니다.
- 선의 끝점에 대한 [Arrow Head Style](https://reference.aspose.com/slides/ko/php-java/aspose.slides/LineArrowheadStyle) 및 [Length](https://reference.aspose.com/slides/ko/php-java/aspose.slides/LineArrowheadLength)을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```php
  # PPTX 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # 라인 유형의 AutoShape를 추가합니다
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 라인에 일부 서식을 적용합니다
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # PPTX를 디스크에 저장합니다
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**일반 선을 커넥터로 변환하여 도형에 “스냅”되게 할 수 있나요?**

아니요. 일반 선([AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/) 중 [Line](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapetype/) 유형)은 자동으로 커넥터가 되지 않습니다. 도형에 스냅하도록 하려면 전용 [Connector](https://reference.aspose.com/slides/ko/php-java/aspose.slides/connector/) 유형과 연결을 위한 [corresponding APIs](/slides/ko/php-java/connector/)를 사용하십시오.

**선의 속성이 테마에서 상속되어 최종 값을 파악하기 어려울 때는 어떻게 해야 하나요?**

`LineFormatEffectiveData`/`LineFillFormatEffectiveData`를 통해 [효과적인 속성 읽기](/slides/ko/php-java/shape-effective-properties/)를 수행하십시오. 이러한 데이터는 이미 상속 및 테마 스타일을 고려합니다.

**선을 편집(이동, 크기 조정)하지 못하도록 잠글 수 있나요?**

예. Shapes는 편집 작업을 금지할 수 있는 [잠금 개체](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/getautoshapelock/)를 제공합니다.