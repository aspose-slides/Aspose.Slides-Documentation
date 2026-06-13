---
title: PHP에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/php-java/presentation-view-properties/
keywords:
- 보기 속성
- 표준 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 스플리터 스냅
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 맞춤 설정하고 레이아웃, 확대/축소 수준 및 표시 설정을 조정하는 방법을 알아보세요."
---
## **소개**

표준 보기에는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 가지 콘텐츠 영역이 포함됩니다. 서로 다른 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 다시 열었을 때 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 보기를 복원할 수 있게 합니다.

메서드 [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)가 추가되어 프레젠테이션의 표준 보기 속성에 접근할 수 있게 되었습니다. 

[NormalViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewRestoredProperties) 클래스와 그 파생 클래스, [SplitterBarStateType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **INormalViewProperties에 대해**

표준 보기 속성을 나타냅니다.

메서드 [getShowOutlineIcons](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons)은 표준 보기 모드의 콘텐츠 영역 중 어느 영역에서든 개요 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

메서드 [getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter)은 측면 영역이 충분히 작아질 경우 수직 분할기가 최소화 상태로 스냅되는지 여부를 지정합니다.

속성 [getPreferSingleView](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView)은 사용자가 세 개의 콘텐츠 영역이 있는 표준 표준 보기 대신 전체 창에 단일 콘텐츠 영역을 보기를 선호하는지 여부를 지정합니다. 활성화된 경우, 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

메서드 [getVerticalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState)은 수평 또는 수직 분할 막대가 표시될 상태를 지정합니다. 수평 분할 막대는 슬라이드를 슬라이드 아래의 콘텐츠 영역과 구분하고, 수직 분할 막대는 슬라이드를 측면 콘텐츠 영역과 구분합니다. 가능한 값은: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Maximized) 및 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Restored).

메서드 [getRestoredLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) 및 [getRestoredTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties#getRestoredTop)은 [getVerticalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState)에 대해 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Restored) 값이 적용될 때 표준 보기의 상단 또는 측면 슬라이드 영역 크기를 지정합니다.

## **INormalViewProperties 복원에 대해**

표준 보기에서 슬라이드 영역의 크기( [getRestoredTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getRestoredTop)의 자식일 경우 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)의 자식일 경우 높이)를 지정하며, 해당 영역이 가변 복원 크기(최소화도 최대화도 아님)일 때 적용됩니다.

메서드 [getDimensionSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize)은 슬라이드 영역의 크기( restoredTop의 자식이면 너비, restoredLeft의 자식이면 높이)를 지정합니다.

메서드 [getAutoAdjust](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust)은 애플리케이션 내에서 보기를 포함하는 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정되어야 하는지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) 속성에 어떻게 접근할 수 있는지를 보여줍니다.

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
{{% alert color="primary" %}} 

이제 Aspose.Slides for PHP via Java는 프레젠테이션이 열릴 때 확대/축소 비율이 이미 설정된 상태가 되도록 기본 확대/축소 값을 설정하는 기능을 지원합니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties) 를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getSlideViewProperties)와 [getNotesViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getNotesViewProperties)를 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 예제를 통해 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties)를 [Aspose.Slides](/slides/ko/)에서 설정하는 방법을 살펴보겠습니다.

{{% /alert %}} 

보기 속성을 설정하려면 다음 단계를 따르십시오:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties)를 설정합니다.
1. [PPTX ](https://docs.fileformat.com/presentation/pptx/)파일로 프레젠테이션을 저장합니다. 아래 예제에서는 슬라이드 보기와 노트 보기 모두에 확대/축소 값을 설정했습니다.

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

## **FAQ**

**프레젠테이션의 서로 다른 섹션에 대해 다른 보기 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getviewproperties/)는 프레젠테이션 수준에서 정의되며([Normal View](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/getslideviewproperties/)), 섹션별이 아니므로 하나의 매개변수 집합이 문서가 열릴 때 전체 문서에 적용됩니다.

**다른 사용자에 대해 서로 다른 보기 상태를 미리 정의할 수 있나요?**

아니요. 설정은 파일에 저장되어 공유됩니다. 뷰어 애플리케이션이 사용자 선호도를 반영할 수는 있지만, 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**미리 정의된 View Properties가 포함된 템플릿을 준비하여 새 프레젠테이션이 동일하게 열리게 할 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getviewproperties/)가 프레젠테이션 수준에 저장되므로 이를 템플릿에 포함시켜 동일한 초기 보기 구성을 가진 새 문서를 만들 수 있습니다.