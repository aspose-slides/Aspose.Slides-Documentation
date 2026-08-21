---
title: PHP에서 프레젠테이션의 그리기 가이드 관리
linktitle: 그리기 가이드
type: docs
weight: 85
url: /ko/php-java/drawing-guides/
keywords:
- 그리기 가이드
- 수평 가이드
- 수직 가이드
- 정렬 가이드
- 슬라이드 보기
- 마스터 슬라이드
- 레이아웃 슬라이드
- 노트 마스터
- 유인물 마스터
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 수평 및 수직 그리기 가이드를 추가하고, 접근하며, 삭제합니다."
---
## **개요**

드로잉 가이드는 조정 가능한 수평 및 수직선으로, PowerPoint에서 프레젠테이션을 편집할 때 사용자가 도형을 일관되게 정렬하도록 돕습니다. 특히 응용 프로그램이 프레젠테이션을 생성하고 나중에 수동으로 다듬을 경우에 유용합니다. 응용 프로그램은 저자가 콘텐츠를 추가하거나 이동할 때 따라야 할 동일한 정렬 보조선을 저장할 수 있습니다.

그리기 가이드는 편집 보조 도구이며 슬라이드 내용이 아닙니다. 슬라이드 쇼나 렌더링된 출력에 표시되지 않습니다. Aspose.Slides for PHP via Java는 이를 [DrawingGuidesCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguidescollection/) 클래스를 통해 노출합니다. 가이드는 [DrawingGuide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguide/) 로 표현되며 방향, 위치 및 색상을 가집니다.

위치는 해당 슬라이드 또는 마스터의 좌상단 모서리에서부터 포인트 단위로 측정됩니다. 수직 가이드는 가로 좌표를 사용하며 일반적으로 0에서 슬라이드 너비 사이입니다. 수평 가이드는 세로 좌표를 사용하며 일반적으로 0에서 슬라이드 높이 사이입니다.

## **슬라이드 보기에서 가이드 추가**

[CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) 를 사용하여 일반 슬라이드를 편집할 때 표시되는 가이드를 관리합니다. [DrawingGuidesCollection::add](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguidescollection/#add) 를 호출하고 [Orientation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/orientation/) 값과 포인트 단위 위치를 지정합니다.

다음 예제는 슬라이드 중앙 오른쪽에 수직 가이드 하나와 그 아래에 수평 가이드 하나를 추가합니다:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **그리기 가이드 접근**

[DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguidescollection/#getCount) 및 [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguidescollection/#get_Item) 메서드를 통해 기존 가이드에 접근할 수 있습니다. [DrawingGuide::getOrientation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguide/#getPosition), [DrawingGuide::getColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguide/#getColor) 메서드는 값을 반환하며, 해당 Setter 메서드를 통해 변경할 수도 있습니다.

다음 예제는 위에서 만든 프레젠테이션에서 슬라이드 보기 가이드를 읽어옵니다:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **마스터 및 레이아웃 슬라이드에 가이드 추가**

슬라이드 마스터와 각 레이아웃 슬라이드는 자체 그리기 가이드 컬렉션을 가질 수 있습니다. 마스터 슬라이드에는 [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterslide/#getDrawingGuides) 를, 레이아웃 슬라이드에는 [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/layoutslide/#getDrawingGuides) 를 사용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 수직 가이드 하나와 첫 번째 레이아웃 슬라이드에 수평 가이드 하나를 추가합니다:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **노트 및 유인물 마스터에 가이드 추가**

노트 마스터와 유인물 마스터도 그리기 가이드를 지원합니다. 해당 컬렉션에 접근하려면 [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masternotesslide/#getDrawingGuides) 와 [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) 를 사용합니다. 프레젠테이션에 이러한 마스터 중 하나가 없을 경우, [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) 혹은 [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager) 로 적절한 매니저를 얻은 뒤 `setDefaultMasterNotesSlide` 또는 `setDefaultMasterHandoutSlide` 로 기본 마스터를 생성합니다.

다음 예제는 노트 마스터에 수평 가이드 하나와 유인물 마스터에 수직 가이드 하나를 추가합니다:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **그리기 가이드 삭제**

[DrawingGuidesCollection::clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguidescollection/#clear) 를 호출하여 특정 컬렉션의 모든 가이드를 제거합니다. 하나의 컬렉션을 삭제해도 다른 범위에 저장된 가이드에는 영향을 주지 않습니다.

다음 예제는 누락된 마스터를 생성하지 않고 슬라이드 보기 가이드와 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터, 유인물 마스터에 있는 모든 가이드를 삭제합니다:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**그리기 가이드가 슬라이드 쇼나 내보낸 이미지에 표시되나요?**

No. 그리기 가이드는 편집을 위한 정렬 보조 도구이며 프레젠테이션 내용으로 렌더링되지 않습니다.

**그리기 가이드를 개별 일반 슬라이드에 직접 추가할 수 있나요?**

일반 슬라이드 편집 가이드는 프레젠테이션의 슬라이드 보기 속성에 저장됩니다. 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터 및 유인물 마스터용 별도의 가이드 컬렉션이 제공됩니다.

**가이드 위치에 사용되는 단위는 무엇인가요?**

위치는 포인트 단위로 지정되며, 72포인트가 1인치에 해당합니다. 수직 위치는 왼쪽 가장자리에서 측정하고, 수평 위치는 위쪽 가장자리에서 측정합니다.

**그리기 가이드를 삭제하면 도형이 제거되거나 슬라이드 내용이 변경되나요?**

No. [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/drawingguidescollection/#clear) 메서드는 선택한 컬렉션의 가이드만 제거합니다. 도형 및 기타 슬라이드 내용은 그대로 유지됩니다.