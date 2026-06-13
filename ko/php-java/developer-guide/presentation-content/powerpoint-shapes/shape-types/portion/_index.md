---
title: PHP를 사용하여 프레젠테이션에서 텍스트 조각 관리
linktitle: 텍스트 조각
type: docs
weight: 70
url: /ko/php-java/portion/
keywords:
- 텍스트 조각
- 텍스트 부분
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 텍스트 조각을 관리하는 방법을 배우고, 성능과 맞춤화를 향상시키세요."
---
## **소개**

텍스트 조각은 단락 내의 특정 텍스트 조각을 나타내며, 주변 내용과 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서는 텍스트 조각을 사용하여 텍스트 조각의 위치를 검색하거나, 단락의 일부만 서식을 적용하거나, 텍스트 동작을 보다 자세한 수준에서 제어할 수 있습니다.

## **텍스트 조각의 좌표 가져오기**
[**getCoordinates()**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/getcoordinates/) 메서드는 [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/) 클래스에 추가되었으며, 조각 시작 위치의 좌표를 가져올 수 있게 합니다.

```php
  # PPTX를 나타내는 Prseetation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 프레젠테이션의 컨텍스트를 재구성합니다
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **자주 묻는 질문**
**단일 단락 내 텍스트의 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 portion에 [하이퍼링크 지정](/slides/ko/php-java/manage-hyperlinks/)을 적용할 수 있습니다; 해당 조각만 클릭 가능하고 전체 단락은 클릭되지 않습니다.

**스타일 상속은 어떻게 작동하나요: Portion이 오버라이드하는 것과 Paragraph/TextFrame에서 가져오는 것은 무엇인가요?**

Portion 수준 속성이 가장 높은 우선순위를 가집니다. 속성이 [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/)에 설정되지 않은 경우 엔진은 [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)에서 가져옵니다; 그곳에도 설정되지 않으면 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/) 또는 [theme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/theme/) 스타일에서 가져옵니다.

**Portion에 지정된 폰트가 대상 머신/서버에 없으면 어떻게 되나요?**

[폰트 대체 규칙](/slides/ko/php-java/font-selection-sequence/)이 적용됩니다. 텍스트가 재배치될 수 있으며, 메트릭, 하이픈 처리 및 너비가 변경될 수 있어 정확한 위치 지정에 영향을 줍니다.

**Portion에만 적용되는 텍스트 채우기 투명도 또는 그라디언트를 단락의 다른 부분과 독립적으로 설정할 수 있나요?**

예, [Portion](https://reference.aspose.com/slides/ko/php-java/aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도를 인접 조각과 다르게 설정할 수 있습니다.