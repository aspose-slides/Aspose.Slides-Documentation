---
title: JavaScript에서 프레젠테이션의 그리기 가이드 관리
linktitle: 그리기 가이드
type: docs
weight: 85
url: /ko/nodejs-java/drawing-guides/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에서 수평 및 수직 그리기 가이드를 추가하고, 접근하며, 삭제합니다."
---
## **개요**

그리기 가이드는 PowerPoint에서 프레젠테이션을 편집하는 동안 사용자가 모양을 일관되게 정렬하도록 돕는 조정 가능한 가로 및 세로 선입니다. 특히 애플리케이션이 프레젠테이션을 생성하고 나중에 수동으로 다듬을 때 유용합니다. 애플리케이션은 저자가 콘텐츠를 추가하거나 이동할 때 따라야 할 동일한 정렬 보조 도구를 저장할 수 있습니다.

그리기 가이드는 편집 보조 도구이며 슬라이드 내용이 아닙니다. 슬라이드 쇼나 렌더링된 출력에 나타나지 않습니다. Aspose.Slides for Node.js via Java는 이를 [DrawingGuidesCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguidescollection/) 클래스를 통해 노출합니다. 가이드는 [DrawingGuide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguide/) 로 표현되며 방향, 위치 및 색상을 가집니다.

위치는 해당 슬라이드 또는 마스터의 왼쪽 위 모서리에서 포인트 단위로 측정됩니다. 세로 가이드는 가로 좌표를 사용하며 일반적으로 0과 슬라이드 너비 사이 값입니다. 가로 가이드는 세로 좌표를 사용하며 일반적으로 0과 슬라이드 높이 사이 값입니다.

## **슬라이드 보기에서 가이드 추가**

일반 슬라이드를 편집하는 동안 표시되는 가이드를 관리하려면 [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides)를 사용합니다. [DrawingGuidesCollection.add](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguidescollection/#add)를 호출하여 [Orientation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/orientation/) 값과 포인트 단위 위치를 지정합니다.

다음 예제는 슬라이드 중앙 오른쪽에 세로 가이드를 하나, 그 아래에 가로 가이드를 하나 추가합니다:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리기 가이드에 액세스**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguidescollection/#getCount) 및 [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) 메서드를 사용하면 기존 가이드에 접근할 수 있습니다. [DrawingGuide.getOrientation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguide/#getPosition) 및 [DrawingGuide.getColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguide/#getColor) 메서드는 값을 반환하며, 해당 setter 메서드를 통해 값도 변경할 수 있습니다.

다음 예제는 앞서 만든 프레젠테이션에서 슬라이드 보기 가이드를 읽어옵니다:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **마스터 및 레이아웃 슬라이드에 가이드 추가**

슬라이드 마스터와 각각의 레이아웃 슬라이드도 자체적인 그리기 가이드 컬렉션을 가질 수 있습니다. 마스터 슬라이드에는 [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterslide/#getDrawingGuides)를, 레이아웃 슬라이드에는 [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides)를 사용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 세로 가이드를 하나, 첫 번째 레이아웃 슬라이드에 가로 가이드를 하나 추가합니다:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **노트 및 유인물 마스터에 가이드 추가**

노트 마스터와 유인물 마스터도 그리기 가이드를 지원합니다. [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides)와 [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides)를 사용하여 해당 컬렉션에 접근합니다. 프레젠테이션에 이러한 마스터가 없을 경우 `MasterNotesSlideManager.setDefaultMasterNotesSlide` 또는 `MasterHandoutSlideManager.setDefaultMasterHandoutSlide`가 기본 마스터를 생성하고 반환합니다.

다음 예제는 노트 마스터에 가로 가이드를, 유인물 마스터에 세로 가이드를 추가합니다:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리기 가이드 지우기**

특정 컬렉션에서 모든 가이드를 제거하려면 [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguidescollection/#clear)를 호출합니다. 하나의 컬렉션을 지워도 다른 범위에 저장된 가이드에는 영향을 주지 않습니다.

다음 예제는 슬라이드 보기 가이드와 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터, 유인물 마스터에 있는 모든 가이드를 누락된 마스터를 만들지 않고 제거합니다:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**그리기 가이드는 슬라이드 쇼나 내보낸 이미지에 표시됩니까?**

아니요. 그리기 가이드는 편집을 위한 정렬 보조 도구이며 프레젠테이션 내용으로 렌더링되지 않습니다.

**그리기 가이드를 개별 일반 슬라이드에 직접 추가할 수 있습니까?**

일반 슬라이드 편집 가이드는 프레젠테이션의 슬라이드 보기 속성에 저장됩니다. 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터 및 유인물 마스터에 대해 별도의 가이드 컬렉션이 제공됩니다.

**가이드 위치에 사용되는 단위는 무엇입니까?**

위치는 포인트 단위로 지정되며, 1인치당 72포인트입니다. 세로 위치는 왼쪽 가장자리에서, 가로 위치는 위쪽 가장자리에서 측정됩니다.

**그리기 가이드를 지우면 도형이나 슬라이드 내용이 변경됩니까?**

아니요. [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/drawingguidescollection/#clear) 메서드는 선택한 컬렉션의 가이드만 제거합니다. 도형 및 기타 슬라이드 내용은 그대로 유지됩니다.