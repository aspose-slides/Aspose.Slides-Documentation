---
title: Заметка
type: docs
weight: 240
url: /ru/androidjava/examples/elements/note/
keywords:
- пример кода
- заметка
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Работа со слайдами заметок в Aspose.Slides for Android: добавление, чтение, редактирование и экспорт заметок докладчика в форматах PPT, PPTX и ODP с помощью понятных примеров на Java."
---
В этой статье демонстрируется, как добавлять, читать, удалять и обновлять слайды заметок с помощью **Aspose.Slides for Android via Java**.

## **Добавить слайд заметок**

Создайте слайд заметок и задайте ему текст.

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

## **Получить доступ к слайду заметок**

Прочитайте текст из существующего слайда заметок.

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

## **Удалить слайд заметок**

Удалите слайд заметок, связанный со слайдом.

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

## **Обновить текст заметок**

Измените текст слайда заметок.

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