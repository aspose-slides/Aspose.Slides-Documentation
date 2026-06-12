---
title: Notitie
type: docs
weight: 240
url: /nl/nodejs-java/examples/elements/note/
keywords:
- codevoorbeeld
- notitie
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Werken met notities op dia's in Aspose.Slides voor Node.js: toevoegen, lezen, bewerken en exporteren van presentatorenotities in PPT, PPTX en ODP met duidelijke JavaScript-voorbeelden."
---
Dit artikel laat zien hoe je notitieslides kunt toevoegen, lezen, verwijderen en bijwerken met **Aspose.Slides for Node.js via Java**.

## **Notitieslide toevoegen**

Maak een notitieslide aan en ken er tekst aan toe.

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

## **Toegang tot een notitieslide**

Lees de tekst van een bestaande notitieslide.

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

## **Notitieslide verwijderen**

Verwijder de notitieslide die bij een slide hoort.

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

## **Notitiestekst bijwerken**

Wijzig de tekst van een notitieslide.

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