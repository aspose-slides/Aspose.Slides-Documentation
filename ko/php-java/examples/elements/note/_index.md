---
title: 노트
type: docs
weight: 240
url: /ko/php-java/examples/elements/note/
keywords:
- 노트
- 노트 슬라이드 추가
- 노트 슬라이드 액세스
- 노트 슬라이드 제거
- 노트 텍스트 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용한 PHP에서 발표자 노트를 추가, 읽기, 편집 및 내보내기: 텍스트 서식 지정, 슬라이드별 노트 관리, PowerPoint 및 OpenDocument에서 가시성 제어."
---
**Aspose.Slides for PHP via Java**를 사용하여 노트 슬라이드를 추가, 읽기, 제거 및 업데이트하는 방법을 보여줍니다.

## **노트 슬라이드 추가**

노트 슬라이드를 만들고 텍스트를 할당합니다.

```php
function addNote() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("My note");

        $presentation->save("note.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **노트 슬라이드 액세스**

기존 노트 슬라이드에서 텍스트를 읽습니다.

```php
function accessNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notes = $notesSlide->getNotesTextFrame()->getText();
    } finally {
        $presentation->dispose();
    }
}
```

## **노트 슬라이드 제거**

슬라이드에 연결된 노트 슬라이드를 제거합니다.

```php
function removeNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getNotesSlideManager()->removeNotesSlide();

        $presentation->save("note_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **노트 텍스트 업데이트**

노트 슬라이드의 텍스트를 변경합니다.

```php
function updateNoteText() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("Updated");

        $presentation->save("note_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```