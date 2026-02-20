---
title: Заметка
type: docs
weight: 240
url: /ru/php-java/examples/elements/note/
keywords:
- заметка
- добавить слайд заметок
- доступ к слайду заметок
- удалить слайд заметок
- обновить текст заметок
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Добавлять, читать, редактировать и экспортировать заметки докладчика в PHP с помощью Aspose.Slides: форматировать текст, управлять заметками для каждого слайда и контролировать их отображение в PowerPoint и OpenDocument."
---
Показывает, как добавлять, читать, удалять и обновлять слайды заметок с использованием **Aspose.Slides for PHP via Java**.

## **Добавить слайд заметок**

Создайте слайд заметок и назначьте ему текст.

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

## **Доступ к слайду заметок**

Прочитайте текст из существующего слайда заметок.

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

## **Удалить слайд заметок**

Удалите слайд заметок, связанный со слайдом.

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

## **Обновить текст заметок**

Измените текст слайда заметок.

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