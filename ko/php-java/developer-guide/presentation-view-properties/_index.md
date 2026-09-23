---
title: PHP에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/php-java/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 스플리터 스냅
- 단일 보기
- 막대 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 지정하고 레이아웃, 확대/축소 수준 및 표시 설정을 조정하십시오."
---
## **소개**

일반 보기에는 세 개의 콘텐츠 영역이 있습니다: 슬라이드 자체, 측면 콘텐츠 영역, 그리고 하단 콘텐츠 영역. 서로 다른 콘텐츠 영역의 위치와 관련된 속성들입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하며, 다시 열었을 때 프레젠테이션이 마지막으로 저장된 상태와 동일한 상태로 표시됩니다.

프레젠테이션의 일반 보기 속성에 접근하기 위해 Method [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)가 추가되었습니다. 

[NormalViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewRestoredProperties) 클래스와 그 파생 클래스들, [SplitterBarStateType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

메서드 [getShowOutlineIcons](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons)는 일반 보기 모드의 콘텐츠 영역 중 어느 곳에서든 개요 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

메서드 [getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter)는 측면 영역이 충분히 작아졌을 때 수직 분할기가 최소화된 상태로 고정될지 여부를 지정합니다.

속성 [getPreferSingleView](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView)는 사용자가 표준 일반 보기(세 개의 콘텐츠 영역) 대신 전체 창 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

메서드 [getVerticalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState)는 수평 또는 수직 분할 막대가 표시되어야 할 상태를 지정합니다. 수평 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Maximized) 및 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Restored)입니다.

메서드 [getRestoredLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) 및 [getRestoredTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties#getRestoredTop)는 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Restored) 값이 [getVerticalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) 에 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

일반 보기에서 영역이 가변 복원 크기(최소화도 최대화도 아님)일 때 슬라이드 영역의 크기([getRestoredTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getRestoredTop)의 자식이면 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)의 자식이면 높이)를 지정합니다.

메서드 [getDimensionSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize)는 복원된 상단의 자식이면 너비, 복원된 좌측의 자식이면 높이인 슬라이드 영역의 크기를 지정합니다.

메서드 [getAutoAdjust](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust)는 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보상하도록 할지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) 속성에 접근하는 방법을 보여줍니다.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # 프레젠테이션의 보기 속성을 복원합니다
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **기본 확대/축소 값 설정**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java는 이제 프레젠테이션의 기본 확대/축소 값을 설정할 수 있습니다. 프레젠테이션을 열면 확대/축소가 이미 적용됩니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties) 를 설정함으로써 가능합니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getSlideViewProperties)와 [getNotesViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getNotesViewProperties)를 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 Aspose.Slides에서 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties)를 설정하는 예제를 보여줍니다.

{{% /alert %}} 

보기 속성을 설정하려면 아래 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties)를 설정합니다.
1. 프레젠테이션을 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다. 아래 예제에서는 슬라이드 보기와 노트 보기 모두에 대해 확대/축소 값을 설정했습니다.

```php
  $presentation = new Presentation();
  try {
    # 프레젠테이션의 보기 속성을 설정합니다
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // 슬라이드 보기용 백분율 확대/축소 값
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // 노트 보기용 백분율 확대/축소 값

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **그리드 간격 설정**

[Presentation::getViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getViewProperties)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/#getGridSpacing) 및 [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/#setGridSpacing) 메서드는 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 프레젠테이션 전체에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트가 1인치에 해당합니다. API 문서에 따라 양수 값을 사용하세요.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 그리드 간격을 출력하고, 1/4인치 간격으로 설정한 뒤 결과를 저장합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

그리드는 [drawing guides](/slides/ko/php-java/drawing-guides/)와 다릅니다. 그리드 간격은 규칙적인 간격을 제어하고, 드로잉 가이드는 개별적으로 배치된 수평 또는 수직 정렬선입니다. 드로잉 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변경되지 않습니다.

그리드와 드로잉 가이드는 모두 편집 보조 도구이며, PDF, 이미지, SVG 또는 슬라이드 쇼에서 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장한다고 해서 편집기가 그리드를 표시한다는 보장은 없으며, 표시 여부는 뷰어나 편집기의 설정에 따라 달라집니다.

## **프레젠테이션 열 때 주석 표시 또는 숨기기**

[Presentation::getViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getviewproperties/)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [ViewProperties::getShowComments](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/getshowcomments/) 및 [ViewProperties::setShowComments](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/setshowcomments/)를 사용하여 프레젠테이션이 PowerPoint 또는 기타 호환 편집기에서 열릴 때 주석을 표시할지 여부에 대한 저장된 기본 설정을 읽거나 변경합니다.

이 설정은 저장된 보기 기본 설정만 제어합니다. 주석을 추가, 제거, 편집 또는 해결하지는 않으며, 주석을 숨겨도 내용, 작성자, 위치, 답글 및 상태가 보존됩니다. 주석 자체를 변경하는 작업은 [Presentation Comments](/slides/ko/php-java/presentation-comments/)를 참고하십시오.

다음 예제는 주석이 포함된 기존 `comments.pptx` 파일이 필요합니다. 현재 가시성 설정을 출력하고, 주석을 숨기도록 요청한 뒤 주석을 제거하지 않은 새로운 PPTX 파일을 저장합니다. 또한 [ViewProperties::setLastView](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/setlastview/)와 [ViewType::SlideView](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewtype/#SlideView)를 사용하여 주석 가시성과 함께 초기 편집 보기를 구성합니다.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는?**

파일에 그리드 간격이 저장되어 있지만, 편집기가 그리드 표시 여부를 제어합니다. 편집기의 그리드 가시성 설정을 확인하십시오.

**드로잉 가이드를 삭제하면 그리드 간격이 변경되나요?**

아니요. 드로잉 가이드와 그리드 간격은 독립적인 설정이며, 가이드를 삭제해도 저장된 그리드 간격은 변경되지 않습니다.

**프레젠테이션의 다른 섹션에 대해 서로 다른 보기 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getviewproperties/)은 프레젠테이션 수준에서 정의되며([Normal View](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/getslideviewproperties/)), 섹션별이 아니라 전체 문서에 하나의 매개변수 집합이 적용됩니다.

**다른 사용자별로 서로 다른 보기 상태를 미리 정의할 수 있나요?**

아니요. 설정은 파일에 저장되어 공유됩니다. 뷰어 애플리케이션이 사용자 선호도를 반영할 수는 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**미리 정의된 View Properties가 있는 템플릿을 준비하여 새 프레젠테이션이 동일하게 열리도록 할 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getviewproperties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새로운 문서를 만들면 동일한 초기 보기 구성을 사용할 수 있습니다.