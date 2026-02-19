---
title: Note
type: docs
weight: 240
url: /fr/nodejs-java/examples/elements/note/
keywords:
- exemple de code
- note
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Travaillez avec les notes de diapositives dans Aspose.Slides for Node.js : ajoutez, lisez, modifiez et exportez les notes du présentateur au format PPT, PPTX et ODP à l'aide d'exemples JavaScript clairs."
---
Cet article montre comment ajouter, lire, supprimer et mettre à jour des diapositives de notes en utilisant **Aspose.Slides for Node.js via Java**.

## **Ajouter une diapositive de notes**

Créez une diapositive de notes et attribuez‑lui du texte.

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

## **Accéder à une diapositive de notes**

Lisez le texte d'une diapositive de notes existante.

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

## **Supprimer une diapositive de notes**

Supprimez la diapositive de notes associée à une diapositive.

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

## **Mettre à jour le texte des notes**

Modifiez le texte d'une diapositive de notes.

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