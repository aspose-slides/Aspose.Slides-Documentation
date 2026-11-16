---
title: JavaScript에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/nodejs-java/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 내용
- 개요 아이콘
- 수직 스플리터 스냅
- 단일 보기
- 바 상태
- 치수 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션의 일반 보기 레이아웃, 슬라이드 및 노트 확대/축소, 그리드 간격 및 주석 표시 여부를 구성합니다."
---
## **소개**

PowerPoint의 일반 보기에서 슬라이드는 썸네일 또는 개요용 사이드 펜과 아래쪽 노트 펜 사이에 표시됩니다. Aspose.Slides for Node.js via Java는 [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties)를 통해 프레젠테이션에 저장된 편집 기본 설정을 노출합니다. 여기에는 펜 레이아웃, 확대/축소 수준, 그리드 간격 및 주석 표시 여부가 포함됩니다.

## **NormalViewProperties에 대하여**

[getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties)를 사용하여 [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) 클래스를 액세스합니다. [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons)는 개요에서 슬라이드 제목 옆에 아이콘이 표시되는지 제어합니다. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter)는 사용자가 사이드 펜을 좁게 하면 해당 펜이 최소화된 상태로 스냅되도록 합니다. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView)는 전체 창에서 하나의 펜만 표시하려는 기본 설정을 나타냅니다.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState)는 사이드 펜과 슬라이드 사이의 구분자를 제어합니다. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState)는 노트 펜 위의 구분자를 제어합니다. 두 메서드 모두 `Minimized`, `Maximized`, `Restored` 중 하나의 [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) 값을 허용합니다.

## **NormalViewProperties 복원에 대하여**

구분자가 복원될 때, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft)는 사이드 펜의 저장된 크기를 제공하고, [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop)는 상단 슬라이드 영역의 저장된 크기를 제공합니다. 두 메서드는 모두 [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/)를 노출합니다. 그 중 [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) 메서드는 0에서 100 사이의 백분율을 인수로 받으며, [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust)는 창 크기가 조정될 때 편집기가 크기를 자동으로 맞출지 여부를 제어합니다.

이 예제는 기존 프레젠테이션을 업데이트합니다. 수평 구분자를 복원하고, [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop)이 반환하는 크기를 자동 조정이 활성화된 상태에서 80%로 설정하며, 수직 구분자를 최대화합니다. 또한 [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons)를 호출하여 개요 보기에서 아이콘을 표시합니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **기본 확대/축소 값 설정**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties)와 [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties)는 편집기를 위한 독립적인 확대/축소 설정을 저장합니다. 이러한 설정은 슬라이드 크기, 슬라이드 쇼 재생 또는 이미지 내보내기 해상도에 영향을 주지 않습니다.

이 예제는 기존 프레젠테이션을 열고 [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale)를 호출하여 슬라이드를 편집 창에 맞춥니다. 노트 페이지에 대해서는 자동 스케일링을 비활성화하고 [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale)를 호출하여 고정된 80% 확대/축소를 설정합니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리드 간격 설정**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing)은 프레젠테이션 전체의 편집 그리드 라인 간 거리를 설정합니다. 인치당 72포인트인 양의 포인트 값을 사용합니다. 이 예제는 기존 프레젠테이션에서 현재 간격을 출력하고, 간격을 18포인트로 설정하여 ¼인치 그리드를 저장합니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

그리드는 고정된 간격으로 반복됩니다. [Drawing guides](/slides/ko/nodejs-java/drawing-guides/)는 개별 수평 또는 수직 위치를 표시합니다. 두 요소 모두 편집 보조 도구이며 해당 기능을 표시하는 편집기에서만 나타납니다. 슬라이드 쇼 및 PDF, 이미지, SVG로 내보낼 때는 표시되지 않습니다.

## **프레젠테이션 열 때 주석 표시 또는 숨기기**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments)는 호환 가능한 편집기가 프레젠테이션을 열 때 사용할 기본 설정을 저장합니다. 주석이 포함된 기존 프레젠테이션에 대해 이 예제는 현재 설정을 출력하고 주석이 숨겨진 복사본을 저장합니다. 또한 [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView)와 [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView)를 함께 호출하여 복사본이 슬라이드 보기로 열리도록 합니다.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

주석을 숨기면 텍스트, 작성자, 위치, 답글 및 상태가 보존됩니다. 주석 자체를 변경하려면 [Presentation Comments](/slides/ko/nodejs-java/presentation-comments/)를 참조하십시오. 내보내기 설정은 주석이 PDF, HTML, 이미지, 노트 또는 유인물에 표시될지를 제어합니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 숨겨지는 이유는 무엇인가요?**  
프레젠테이션이 그리드 간격을 저장합니다. 그리드를 보려면 편집기에서 그리드 표시를 활성화하십시오.

**그리드 간격을 변경하지 않고 그리드 가이드를 삭제하면 그리드 간격이 바뀝니까?**  
아니요. 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변경되지 않습니다.

**프레젠테이션의 서로 다른 섹션이 서로 다른 보기 설정을 가질 수 있습니까?**  
아니요. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties)는 전체 프레젠테이션에 적용됩니다.

**다른 사용자마다 다른 보기 설정을 저장할 수 있습니까?**  
파일은 모든 사용자를 위한 하나의 보기 속성 집합만 저장합니다. 편집기는 사용자의 로컬 기본 설정을 추가로 적용할 수 있습니다.

**템플릿에 보기 설정을 저장할 수 있습니까?**  
네. 템플릿에서 만든 프레젠테이션은 템플릿에 저장된 보기 설정을 상속합니다.