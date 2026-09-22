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
- 세로 분할기 스냅
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
description: "Aspose.Slides for PHP via Java 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 지정하고, 레이아웃, 확대/축소 수준 및 표시 설정을 조정합니다."
---
## **소개**

일반 보기에는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 개 콘텐츠 영역이 포함됩니다. 서로 다른 콘텐츠 영역의 위치에 관한 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 다시 열었을 때 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 보이게 합니다.

프레젠테이션의 일반 보기 속성에 접근하기 위해 메서드 [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) 가 추가되었습니다.  

[NormalViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewRestoredProperties) 클래스와 그 파생 클래스, [SplitterBarStateType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

메서드 [getShowOutlineIcons](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) 은 일반 보기 모드의 콘텐츠 영역 중 하나에 개요 콘텐츠를 표시할 때 애플리케이션이 아이콘을 표시할지 여부를 지정합니다.

메서드 [getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) 은 측면 영역이 충분히 작아질 경우 세로 분할기가 최소화 상태에 스냅될지 여부를 지정합니다.

속성 [getPreferSingleView](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) 은 사용자가 세 개 콘텐츠 영역이 있는 표준 일반 보기보다 전체 창을 차지하는 단일 콘텐츠 영역을 선호하는지를 지정합니다. 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

메서드 [getVerticalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 와 [getHorizontalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) 은 가로 또는 세로 분할 막대가 표시될 상태를 지정합니다. 가로 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 세로 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Maximized) 및 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Restored) 입니다.

메서드 [getRestoredLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) 와 [getRestoredTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties#getRestoredTop) 은 [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SplitterBarStateType/#Restored) 값이 [getVerticalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) 에 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역 크기를 지정합니다.

## **INormalViewProperties 복원에 관하여**

일반 보기에서 슬라이드 영역의 크기( [getRestoredTop](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) 의 자식일 경우 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) 의 자식일 경우 높이)를 지정합니다. 이 영역이 가변 복원 크기(최소화도 최대화도 아님)일 때 적용됩니다.

메서드 [getDimensionSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) 은 슬라이드 영역의 크기( restoredTop의 자식일 경우 너비, restoredLeft의 자식일 경우 높이)를 지정합니다.

메서드 [getAutoAdjust](https://reference.aspose.com/slides/ko/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) 은 애플리케이션 내에서 보기를 포함하는 창의 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정될지 여부를 지정합니다.

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
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java는 이제 프레젠테이션의 기본 확대/축소 값을 설정할 수 있습니다. 프레젠테이션을 열면 확대/축소가 미리 설정됩니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties)를 설정함으로써 가능합니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getSlideViewProperties)와 [getNotesViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties/#getNotesViewProperties)도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 예제를 통해 Aspose.Slides에서 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties)를 설정하는 방법을 살펴봅니다.

{{% /alert %}} 

보기 속성을 설정하려면 아래 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ViewProperties)를 설정합니다.
1. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.
   아래 예제에서는 슬라이드 보기와 노트 보기의 확대/축소 값을 설정했습니다.

```php
  $presentation = new Presentation();
  try {
    # 프레젠테이션의 보기 속성을 설정합니다
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // 슬라이드 보기용 줌 값(퍼센트)
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // 노트 보기용 줌 값(퍼센트)

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **격자 간격 설정**

[Presentation::getViewProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getViewProperties)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/#getGridSpacing) 및 [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/#setGridSpacing) 메서드는 기본 편집 격자의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 격자 간격은 포인트 단위이며, 72포인트가 1인치에 해당합니다. API 문서에서 요구하는 대로 양수 값을 사용하십시오.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 격자 간격을 출력하고, ¼인치 간격으로 설정한 뒤 결과를 저장합니다.

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

격자는 [drawing guides](/slides/ko/php-java/drawing-guides/)와 다릅니다. 격자 간격은 규칙적인 간격을 제어하는 반면, 드로잉 가이드는 개별적으로 위치 지정된 가로 또는 세로 정렬선입니다. 드로잉 가이드를 추가, 이동 또는 삭제해도 격자 간격은 변경되지 않습니다.

격자와 드로잉 가이드는 모두 편집 보조 도구입니다. 이들은 PDF, 이미지, SVG 또는 슬라이드 쇼에서 슬라이드 콘텐츠로 렌더링되지 않습니다. 격자 간격을 파일에 저장한다고 해서 편집기가 격자를 표시한다는 보장은 없으며, 표시 여부는 뷰어 또는 편집기의 설정에 따라 달라집니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 격자가 보이지 않는 이유는 무엇인가요?**  
파일에 격자 간격이 저장되지만, 격자를 표시할지는 편집기가 제어합니다. 편집기의 격자 표시 설정을 확인하십시오.

**드로잉 가이드를 삭제하면 격자 간격이 변경되나요?**  
아니요. 드로잉 가이드와 격자 간격은 별개의 설정입니다. 가이드를 삭제해도 저장된 격자 간격은 변경되지 않습니다.

**프레젠테이션의 서로 다른 섹션에 대해 다른 보기 설정을 지정할 수 있나요?**  
[View settings](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getviewproperties/) 은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/php-java/aspose.slides/viewproperties/getslideviewproperties/))에서 정의되며 섹션별로는 정의되지 않으므로, 문서가 열릴 때 전체 문서에 하나의 매개변수 집합이 적용됩니다.

**다른 사용자에 대해 서로 다른 보기 상태를 미리 정의할 수 있나요?**  
아니요. 설정은 파일에 저장되어 공유됩니다. 뷰어 애플리케이션이 사용자 설정을 따를 수는 있지만, 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**미리 정의된 View Properties가 포함된 템플릿을 준비해서 새 프레젠테이션이 동일하게 열리게 할 수 있나요?**  
예. [view properties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getviewproperties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 두고, 이를 기반으로 새 문서를 만들면 동일한 초기 보기 구성이 적용됩니다.