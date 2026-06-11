---
title: Anteckning
type: docs
weight: 240
url: /sv/nodejs-java/examples/elements/note/
keywords:
- kodexempel
- anteckning
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeta med bildanteckningar i Aspose.Slides för Node.js: lägg till, läs, redigera och exportera talarnoter i PPT, PPTX och ODP med tydliga JavaScript-exempel."
---
Denna artikel visar hur du lägger till, läser, tar bort och uppdaterar anteckningsbilder med **Aspose.Slides for Node.js via Java**.

## **Lägg till en Anteckningsbild**

Skapa en anteckningsbild och tilldela text till den.

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

## **Åtkomst till en Anteckningsbild**

Läs text från en befintlig anteckningsbild.

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

## **Ta bort en Anteckningsbild**

Ta bort anteckningsbilden som är kopplad till en bild.

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

## **Uppdatera Anteckningstext**

Ändra texten på en anteckningsbild.

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