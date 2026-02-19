---
title: Notiz
type: docs
weight: 240
url: /de/nodejs-java/examples/elements/note/
keywords:
- Codebeispiel
- Notiz
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeiten Sie mit Foliennotizen in Aspose.Slides für Node.js: Hinzufügen, Lesen, Bearbeiten und Exportieren von Rednernotizen in PPT, PPTX und ODP mit klaren JavaScript-Beispielen."
---
Dieser Artikel zeigt, wie man Notizfolien hinzufügt, liest, entfernt und aktualisiert, indem man **Aspose.Slides for Node.js via Java** verwendet.

## **Notizfolie hinzufügen**

Erstellen Sie eine Notizfolie und weisen Sie ihr Text zu.

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

## **Auf eine Notizfolie zugreifen**

Lesen Sie den Text einer vorhandenen Notizfolie.

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

## **Notizfolie entfernen**

Entfernen Sie die Notizfolie, die einer Folie zugeordnet ist.

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

## **Notiztext aktualisieren**

Ändern Sie den Text einer Notizfolie.

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