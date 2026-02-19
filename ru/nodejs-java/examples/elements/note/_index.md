---
title: Заметка
type: docs
weight: 240
url: /ru/nodejs-java/examples/elements/note/
keywords:
- пример кода
- заметка
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Работайте с заметками слайдов в Aspose.Slides для Node.js: добавляйте, читайте, редактируйте и экспортируйте примечания к докладчику в форматах PPT, PPTX и ODP с помощью понятных примеров JavaScript."
---
В этой статье демонстрируется, как добавлять, читать, удалять и обновлять слайды заметок, используя **Aspose.Slides for Node.js via Java**.

## **Добавить слайд заметок**

Создайте слайд заметок и задайте ему текст.

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

## **Доступ к слайду заметок**

Прочитайте текст из существующего слайда заметок.

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

## **Удалить слайд заметок**

Удалите слайд заметок, связанный со слайдом.

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

## **Обновление текста заметок**

Измените текст слайда заметок.

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