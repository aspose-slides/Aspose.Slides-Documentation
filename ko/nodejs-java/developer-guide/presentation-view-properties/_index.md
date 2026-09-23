---
title: JavaScript에서 프레젠테이션 보기 속성을 검색하고 업데이트하기
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/nodejs-java/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 윤곽선 콘텐츠
- 윤곽선 아이콘
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
description: "Aspose.Slides for Node.js via Java의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 지정하고, 레이아웃, 확대/축소 수준 및 표시 설정을 조정합니다."
---
## **소개**

일반 보기에는 슬라이드 자체, 측면 콘텐츠 영역 및 하단 콘텐츠 영역이라는 세 개의 콘텐츠 영역이 포함됩니다. 다양한 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 다시 열었을 때 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 보기가 유지됩니다.

메서드 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 가 추가되어 프레젠테이션의 일반 보기 속성에 접근할 수 있게 되었습니다.

[NormalViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewRestoredProperties) 클래스와 그 파생 클래스, [SplitterBarStateType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **NormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

메서드 [getShowOutlineIcons](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) 은 일반 보기 모드의 콘텐츠 영역 중 어느 곳에서든 윤곽선 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

메서드 [getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) 은 측면 영역이 충분히 작아질 때 수직 분할기가 최소화 상태로 스냅될지 여부를 지정합니다.

속성 [getPreferSingleView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) 은 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기보다 전체 창을 하나의 콘텐츠 영역으로 표시하는 것을 선호하는지 여부를 지정합니다. 활성화된 경우, 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

메서드 [getVerticalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) 은 가로 또는 세로 분할 막대가 표시될 상태를 지정합니다. 가로 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 세로 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Restored) 입니다.

메서드 [getRestoredLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) 및 [getRestoredTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) 은 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SplitterBarStateType#Restored) 값이 [getVerticalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) 에 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **Restoring NormalViewProperties에 대하여**

일반 보기에서 영역이 가변 복원 크기(최소화되지도 않고 최대화되지도 않음)인 경우 슬라이드 영역( [getRestoredTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) 의 자식인 경우 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) 의 자식인 경우 높이)의 크기를 지정합니다.

메서드 [getDimensionSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) 은 슬라이드 영역의 크기( restoredTop의 자식인 경우 너비, restoredLeft의 자식인 경우 높이)를 지정합니다.

메서드 [getAutoAdjust](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) 은 애플리케이션 내에서 뷰가 포함된 창을 크기 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정될지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) 속성에 접근하는 방법을 보여줍니다.

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
Aspose.Slides for Node.js via Java는 이제 프레젠테이션에 대한 기본 확대/축소 값을 설정할 수 있습니다. 이를 통해 프레젠테이션을 열 때 이미 확대/축소가 적용됩니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties) 를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) 및 [getNotesViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) 도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 예제를 통해 Aspose.Slides에서 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 의 [View Properties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties) 를 설정하는 방법을 살펴봅니다.
{{% /alert %}} 

뷰 속성을 설정하려면 아래 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 의 [View Properties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ViewProperties) 를 설정합니다.
3. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.   아래 예제에서는 슬라이드 뷰와 노트 뷰의 확대/축소 값을 설정했습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // 프레젠테이션의 보기 속성을 설정합니다
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 슬라이드 보기의 줌 값(백분율)
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 노트 보기의 줌 값(백분율)
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리드 간격 설정**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getViewProperties--) 를 사용하여 프레젠테이션 전체의 뷰 설정에 접근합니다. [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) 및 [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) 메서드는 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트가 1인치에 해당합니다. API 문서에 명시된 대로 양수 값을 사용하십시오.

다음 예제는 기존 `demo.pptx` 를 열어 현재 그리드 간격을 출력하고, 1/4인치 간격으로 설정한 뒤 결과를 저장합니다.

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

그리드는 [drawing guides](/slides/ko/nodejs-java/drawing-guides/)와 다릅니다. 그리드 간격은 일정한 간격을 제어하는 반면, 드로잉 가이드는 개별적으로 위치가 지정된 가로 또는 세로 정렬선입니다. 드로잉 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변경되지 않습니다.

그리드와 드로잉 가이드 모두 편집 보조 도구이며, PDF, 이미지, SVG 또는 슬라이드 쇼에 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장한다고 해서 편집기가 그리드를 표시한다는 보장은 없으며, 가시성은 뷰어나 편집기의 설정에 따라 달라집니다.

## **프레젠테이션 열 때 주석 표시 또는 숨기기**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getViewProperties--) 를 사용하여 프레젠테이션 전체의 뷰 설정에 접근합니다. [ViewProperties.getShowComments](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/#getShowComments--) 및 [ViewProperties.setShowComments](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte--) 를 사용하여 PowerPoint 또는 기타 호환 편집기에서 프레젠테이션이 열릴 때 주석을 표시할지 여부에 대한 저장된 기본 설정을 읽거나 변경합니다.

이 설정은 저장된 뷰 기본 설정만 제어합니다. 주석을 추가, 제거, 편집 또는 해결하지는 않습니다. 주석을 숨겨도 내용, 작성자, 위치, 답글 및 상태는 보존됩니다. 주석 자체를 변경하는 작업은 [Presentation Comments](/slides/ko/nodejs-java/presentation-comments/) 를 참조하십시오.

다음 예제는 주석이 포함된 기존 `comments.pptx` 파일이 필요합니다. 현재 가시성 설정을 출력하고, 주석을 숨기도록 요청한 뒤, 주석을 제거하지 않은 새로운 PPTX를 저장합니다. 또한 [ViewProperties.setLastView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) 과 [ViewType.SlideView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewtype/#SlideView) 를 사용하여 주석 가시성과 함께 초기 편집 뷰를 구성합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 설정은 PDF, HTML, 이미지, 노트 또는 유인물 내보내기에 주석이 포함되는지를 결정하지 않습니다. 해당 내보내기별 옵션을 별도로 구성하십시오.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는 무엇인가요?**  
파일에는 그리드 간격이 저장되지만, 에디터가 그리드를 표시할지를 제어합니다. 에디터의 그리드 가시성 설정을 확인하십시오.

**드로잉 가이드를 삭제하면 그리드 간격이 변경되나요?**  
아니요. 드로잉 가이드와 그리드 간격은 독립적인 설정입니다. 가이드를 삭제해도 저장된 그리드 간격은 그대로 유지됩니다.

**프레젠테이션의 서로 다른 섹션마다 다른 뷰 설정을 지정할 수 있나요?**  
[View settings](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getviewproperties/) 은 섹션별이 아니라 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/))에서 정의되므로, 문서가 열릴 때 전체 문서에 하나의 파라미터 집합이 적용됩니다.

**다른 사용자마다 다른 뷰 상태를 미리 정의할 수 있나요?**  
아니요. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자의 선호를 따를 수는 있지만, 파일 자체에는 하나의 뷰 속성 집합만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 사전 정의된 View Properties가 포함된 템플릿을 준비할 수 있나요?**  
예. [view properties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getviewproperties/) 가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들면 동일한 초기 뷰 구성이 적용됩니다.