---
title: PHP에서 프레젠테이션의 단락 경계 가져오기
linktitle: 단락
type: docs
weight: 60
url: /ko/php-java/paragraph/
keywords:
- 단락 경계
- 텍스트 구간 경계
- 단락 좌표
- 구간 좌표
- 단락 크기
- 텍스트 구간 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java에서 단락 및 텍스트 구간 경계를 검색하여 PowerPoint 프레젠테이션의 텍스트 위치를 최적화하는 방법을 배우십시오."
---
## **개요**

이 문서에서는 Aspose.Slides에서 단락 및 텍스트 구간의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. `TextFrame`에서 `getRect()`를 사용하여 단락의 사각형을 검색하는 방법, 표 셀 텍스트 프레임 내부에서 단락 및 구간 좌표를 가져오는 방법, 측정 단위, 텍스트 줄바꿈이 경계에 미치는 영향, 픽셀 변환 및 실제 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **텍스트 프레임에서 단락 및 구간 좌표 가져오기**
Aspose.Slides for PHP via Java를 사용하면 개발자는 이제 `TextFrame`의 단락 컬렉션 내부에 있는 단락에 대한 직사각형 좌표를 가져올 수 있습니다. 또한 단락의 구간 컬렉션 내부에 있는 [구간 좌표](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#getCoordinates)를 가져올 수 있습니다. 이 항목에서는 예제를 통해 단락에 대한 직사각형 좌표와 단락 내부 구간의 위치를 ​​가져오는 방법을 보여드립니다.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **단락의 직사각형 좌표 가져오기**
[**getRect()**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/#getRect) 메서드를 사용하면 개발자는 단락 경계 사각형을 얻을 수 있습니다.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **테이블 셀 텍스트 프레임 내 단락 및 구간 크기 가져오기**

표 셀 텍스트 프레임에서 [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Portion) 또는 [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Paragraph) 크기와 좌표를 가져오려면 [Portion::getRect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/#getRect) 및 [Paragraph::getRect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/#getRect) 메서드를 사용할 수 있습니다.

다음 샘플 코드가 해당 작업을 보여줍니다:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**단락 및 텍스트 구간의 좌표는 어떤 단위로 반환됩니까?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 슬라이드의 모든 좌표와 크기에 적용됩니다.

**단어 줄바꿈이 단락의 경계에 영향을 줍니까?**

예. [wrapping](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/setwraptext/)이 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에서 활성화된 경우 텍스트가 영역 너비에 맞게 자동으로 줄바꿈되어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀에 신뢰성 있게 매핑할 수 있습니까?**

예. 포인트를 픽셀로 변환하려면 다음 식을 사용합니다: pixels = points × (DPI / 72). 결과는 렌더링/내보내기에 사용된 DPI에 따라 달라집니다.

**스타일 상속을 고려한 “실제” 단락 서식 매개변수는 어떻게 얻습니까?**

[effective paragraph formatting data structure](/slides/ko/php-java/shape-effective-properties/)를 사용하십시오. 이는 들여쓰기, 간격, 줄바꿈, RTL 등 최종 통합 값을 반환합니다.