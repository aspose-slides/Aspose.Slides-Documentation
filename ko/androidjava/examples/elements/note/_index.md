---
title: 노트
type: docs
weight: 240
url: /ko/androidjava/examples/elements/note/
keywords:
- 코드 예제
- 노트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 슬라이드 노트를 작업합니다: 추가, 읽기, 편집 및 PPT, PPTX, ODP 형식으로 발표자 노트를 내보내며 명확한 Java 예제를 사용합니다."
---
이 문서에서는 **Aspose.Slides for Android via Java**를 사용하여 노트 슬라이드를 추가, 읽기, 삭제 및 업데이트하는 방법을 보여줍니다.

## **노트 슬라이드 추가**

노트 슬라이드를 만들고 텍스트를 할당합니다.

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **노트 슬라이드 접근**

기존 노트 슬라이드에서 텍스트를 읽습니다.

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **노트 슬라이드 제거**

슬라이드에 연결된 노트 슬라이드를 제거합니다.

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **노트 텍스트 업데이트**

노트 슬라이드의 텍스트를 변경합니다.

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```