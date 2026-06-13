---
title: JavaScript에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/nodejs-java/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 정의하고—레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기는 세 개의 콘텐츠 영역으로 구성됩니다: 슬라이드 자체, 측면 콘텐츠 영역, 그리고 하단 콘텐츠 영역. 다양한 콘텐츠 영역의 위치와 관련된 속성들입니다. 이 정보는 애플리케이션이 뷰 상태를 파일에 저장하도록 하며, 파일을 다시 열었을 때 마지막으로 저장된 상태와 동일한 뷰가 표시됩니다.

메서드[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--)이 추가되어 프레젠테이션의 일반 보기 속성에 접근할 수 있게 되었습니다.

[NormalViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewRestoredProperties) 클래스와 그 파생 클래스, [SplitterBarStateType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **NormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

메서드[getShowOutlineIcons](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-)은 일반 보기 모드에서 콘텐츠 영역 중 하나에 개요 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

메서드[getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-)은 측면 영역이 충분히 작아졌을 때 수직 스플리터가 최소화 상태로 스냅될지 여부를 지정합니다.

속성[getPreferSingleView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-)은 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기 대신 전체 창에 단일 콘텐츠 영역을 보기를 선호하는지 여부를 지정합니다. 활성화된 경우 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

메서드[getVerticalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--)은 수평 또는 수직 스플리터 바가 표시될 상태를 지정합니다. 수평 스플리터 바는 슬라이드를 아래쪽 콘텐츠 영역과 구분하고, 수직 스플리터 바는 슬라이드를 측면 콘텐츠 영역과 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Restored)입니다.

메서드[getRestoredLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) 및 [getRestoredTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)은 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Restored) 값이 [getVerticalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--)와 [getHorizontalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--)에 각각 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역 크기를 지정합니다.

## **NormalViewProperties 복원에 대하여**

일반 보기의 슬라이드 영역( [getRestoredTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)의 자식인 경우 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)의 자식인 경우 높이)의 크기를 지정합니다. 이 영역은 가변 복원 크기( 최소화도 아니고 최대화도 아닌)일 때 적용됩니다.

메서드[getDimensionSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--)은 복원된 상단의 자식일 경우 너비, 복원된 좌측의 자식일 경우 높이로 슬라이드 영역의 크기를 지정합니다.

메서드[getAutoAdjust](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--)은 창 크기를 조정할 때 측면 콘텐츠 영역이 새로운 크기에 맞춰 보상하도록 할지 여부를 지정합니다.

아래 예제에서는 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 속성에 어떻게 접근하는지 보여줍니다.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // 프레젠테이션의 보기 속성을 복원합니다
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **기본 확대/축소 값 설정**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java는 이제 프레젠테이션을 열 때 기본 확대/축소 값이 이미 설정되도록 지원합니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties)를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--)와 [getNotesViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--)를 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 예제를 통해 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties)를 설정하는 방법을 살펴봅니다.

{{% /alert %}} 

뷰 속성을 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties)를 설정합니다.
1. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.  
   아래 예제에서는 슬라이드 뷰와 노트 뷰 모두에 확대/축소 값을 설정했습니다.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 프레젠테이션의 보기 속성을 설정합니다
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 슬라이드 보기의 확대/축소 값(퍼센트)
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 노트 보기의 확대/축소 값(퍼센트)
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**프레젠테이션의 서로 다른 섹션에 대해 다른 뷰 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getviewproperties/)은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/))에서 정의되며 섹션별이 아니라 전체 문서에 단일 파라미터 집합이 적용됩니다.

**다른 사용자에 대해 미리 정의된 뷰 상태를 설정할 수 있나요?**

아니요. 설정은 파일에 저장되며 모두가 공유합니다. 뷰어 애플리케이션이 사용자 환경설정을 적용할 수는 있지만 파일 자체에는 하나의 뷰 속성 집합만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties가 포함된 템플릿을 만들 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getviewproperties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들 때 동일한 초기 뷰 구성을 사용할 수 있습니다.