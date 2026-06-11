---
title: Notatka
type: docs
weight: 240
url: /pl/nodejs-java/examples/elements/note/
keywords:
- przykład kodu
- notatka
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracuj z notatkami slajdu w Aspose.Slides dla Node.js: dodawaj, odczytuj, edytuj i eksportuj notatki prelegenta w formatach PPT, PPTX i ODP, korzystając z przejrzystych przykładów JavaScript."
---
Ten artykuł demonstruje, jak dodawać, odczytywać, usuwać i aktualizować slajdy notatek przy użyciu **Aspose.Slides for Node.js via Java**.

## **Add a Notes Slide**
Utwórz slajd notatek i przypisz do niego tekst.

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

## **Access a Notes Slide**
Odczytaj tekst z istniejącego slajdu notatek.

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

## **Remove a Notes Slide**
Usuń slajd notatek powiązany ze slajdem.

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

## **Update Notes Text**
Zmień tekst slajdu notatek.

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