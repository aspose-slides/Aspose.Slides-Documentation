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
description: "Aspose.Slides for Node.js via Java view properties를 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 지정하고 레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기에는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 개 영역이 포함됩니다. 서로 다른 콘텐츠 영역의 위치에 관한 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하게 하여, 다시 열었을 때 프레젠테이션이 마지막으로 저장된 상태와 동일한 보기 상태가 되도록 합니다.

프레젠테이션의 일반 보기 속성에 접근하기 위해 Method [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 가 추가되었습니다.  

[NormalViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewRestoredProperties) 클래스와 그 파생 클래스, [SplitterBarStateType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **NormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) 은 일반 보기 모드의 콘텐츠 영역 중 어느 곳에서든 개요 콘텐츠를 표시할 때 애플리케이션이 아이콘을 표시할지 여부를 지정합니다.

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) 은 측면 영역이 충분히 작을 때 수직 분할기가 최소화된 상태에 스냅될지 여부를 지정합니다.

Property [getPreferSingleView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) 은 사용자가 세 개의 콘텐츠 영역이 있는 기본 일반 보기 대신 전체 창에 단일 콘텐츠 영역을 보기를 선호하는지 여부를 지정합니다. 활성화된 경우 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

Methods [getVerticalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) 은 수평 또는 수직 분할 막대가 표시될 상태를 지정합니다. 수평 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Restored) 입니다.

Methods [getRestoredLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) 및 [getRestoredTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) 은 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Restored) 값이 [getVerticalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) 에 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **NormalViewProperties 복원에 대하여**

일반 보기에서 영역이 가변 복원 크기(최소화되지도 않고 최대화되지도 않음)일 때 슬라이드 영역( [getRestoredTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)의 자식이면 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)의 자식이면 높이)를 지정합니다.

Method [getDimensionSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) 은 슬라이드 영역의 크기( restoredTop의 자식이면 너비, restoredLeft의 자식이면 높이)를 지정합니다.

Method [getAutoAdjust](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) 은 애플리케이션 내에서 보기를 포함하는 창을 크기 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정될지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대한 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 속성에 어떻게 접근할 수 있는지를 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java는 이제 프레젠테이션에 대한 기본 확대/축소 값을 설정할 수 있습니다. 이를 통해 프레젠테이션을 열면 이미 확대/축소가 적용됩니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties)를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) 및 [getNotesViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) 도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 Aspose.Slides에서 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties)를 설정하는 예제를 살펴봅니다.

{{% /alert %}} 

보기 속성을 설정하려면 아래 단계를 따르십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties)를 설정합니다.
1. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.
   아래 예제에서는 슬라이드 보기와 노트 보기 모두에 대해 확대/축소 값을 설정했습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // 프레젠테이션의 보기 속성 설정
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 슬라이드 보기의 확대/축소 값(백분율)
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 노트 보기의 확대/축소 값(백분율)
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리드 간격 설정**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getViewProperties--) 를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) 및 [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) 메서드는 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트는 1인치에 해당합니다. API 문서에서 요구하는 대로 양수 값을 사용하십시오.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 그리드 간격을 출력하고, 1/4인치 간격으로 설정한 뒤 결과를 저장합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

그리드는 [drawing guides](/slides/ko/nodejs-java/drawing-guides/)와 다릅니다. 그리드 간격은 규칙적인 간격을 제어하지만, 드로잉 가이드는 개별적으로 위치 지정된 수평 또는 수직 정렬선입니다. 드로잉 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변경되지 않습니다.

그리드와 드로잉 가이드는 모두 편집 보조 도구이며 PDF, 이미지, SVG 또는 슬라이드 쇼에서 슬라이드 콘텐츠로 렌더링되지 않습니다. 파일에 그리드 간격을 저장한다고 해서 편집기가 반드시 그리드를 표시한다는 보장은 없으며, 가시성은 뷰어나 편집기의 설정에 따라 달라집니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는 무엇인가요?**

파일에 그리드 간격이 저장되지만, 편집기가 그리드를 표시할지는 제어합니다. 편집기의 그리드 표시 설정을 확인하십시오.

**드로잉 가이드를 삭제하면 그리드 간격이 변경되나요?**

아니요. 드로잉 가이드와 그리드 간격은 독립적인 설정이며, 가이드를 삭제해도 저장된 그리드 간격은 변경되지 않습니다.

**프레젠테이션의 서로 다른 섹션에 대해 다른 보기 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getviewproperties/) 은 프레젠테이션 수준에서 정의되며([Normal View](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), 섹션별로 정의되지 않으므로 문서가 열릴 때 전체 문서에 단일 매개변수 세트가 적용됩니다.

**다른 사용자에 대해 서로 다른 보기 상태를 미리 정의할 수 있나요?**

아니요. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자 선호도를 반영할 수는 있지만, 파일 자체에는 하나의 보기 속성 세트만 포함됩니다.

**미리 정의된 View Properties가 포함된 템플릿을 만들어 새 프레젠테이션이 동일한 방식으로 열리게 할 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getviewproperties/) 가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들면 동일한 초기 보기 구성을 사용할 수 있습니다.