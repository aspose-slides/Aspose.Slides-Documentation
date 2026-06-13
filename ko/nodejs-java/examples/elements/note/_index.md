---
title: 노트
type: docs
weight: 240
url: /ko/nodejs-java/examples/elements/note/
keywords:
- 코드 예제
- 노트
- 파워포인트
- 오픈문서
- 프레젠테이션
- Node.js
- 자바스크립트
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 슬라이드 노트를 작업합니다: 추가, 읽기, 편집 및 PPT, PPTX, ODP 형식의 발표자 노트를 명확한 JavaScript 예제를 사용하여 내보냅니다."
---
이 문서는 **Aspose.Slides for Node.js via Java** 를 사용하여 노트 슬라이드를 추가, 읽기, 제거 및 업데이트하는 방법을 보여줍니다.

## **노트 슬라이드 추가**

노트 슬라이드를 만든 후 텍스트를 할당합니다.

```js
function addNote() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().addNotesSlide();
        notesSlide.getNotesTextFrame().setText("My note");

        presentation.save("note.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **노트 슬라이드 액세스**

기존 노트 슬라이드에서 텍스트를 읽습니다.

```js
function accessNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();

        let notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **노트 슬라이드 제거**

슬라이드와 연결된 노트 슬라이드를 제거합니다.

```js
function removeNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getNotesSlideManager().removeNotesSlide();

        presentation.save("note_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **노트 텍스트 업데이트**

노트 슬라이드의 텍스트를 변경합니다.

```js
function updateNoteText() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();
        notesSlide.getNotesTextFrame().setText("Updated");

        presentation.save("note_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```