---
title: Jegyzet
type: docs
weight: 240
url: /hu/nodejs-java/examples/elements/note/
keywords:
- kódpélda
- jegyzet
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Dolgozzon dia jegyzetekkel az Aspose.Slides for Node.js-ben: adjon hozzá, olvasson, szerkesszen, és exportálja az előadói jegyzeteket PPT, PPTX és ODP formátumban, egyértelmű JavaScript példákkal."
---
Ez a cikk bemutatja, hogyan adhat hozzá, olvashat, eltávolíthat és frissíthet jegyzetdiákat az **Aspose.Slides for Node.js via Java** használatával.

## **Jegyzetdia hozzáadása**

Hozzon létre egy jegyzetdiát, és rendelje hozzá a szöveget.

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

## **Jegyzetdia elérése**

Olvassa el a szöveget egy meglévő jegyzetdiáról.

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

## **Jegyzetdia eltávolítása**

Távolítsa el az adott diához kapcsolódó jegyzetdiát.

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

## **Jegyzet szövegének frissítése**

Módosítsa egy jegyzetdia szövegét.

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