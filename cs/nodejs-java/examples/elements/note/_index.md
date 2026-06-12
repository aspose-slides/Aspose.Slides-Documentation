---
title: Poznámka
type: docs
weight: 240
url: /cs/nodejs-java/examples/elements/note/
keywords:
- ukázka kódu
- poznámka
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracujte s poznámkami snímků v Aspose.Slides pro Node.js: přidávejte, čtěte, upravujte a exportujte poznámky přednášejícího ve formátech PPT, PPTX a ODP pomocí přehledných JavaScript ukázek."
---
Tento článek ukazuje, jak pomocí **Aspose.Slides for Node.js via Java** přidávat, číst, odstraňovat a aktualizovat poznámkové snímky.

## **Přidat poznámkový snímek**

Vytvořte poznámkový snímek a přiřaďte mu text.

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

## **Přístup k poznámkovému snímku**

Přečtěte si text z existujícího poznámkového snímku.

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

## **Odstranit poznámkový snímek**

Odstraňte poznámkový snímek spojený se snímkem.

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

## **Aktualizovat text poznámkového snímku**

Změňte text poznámkového snímku.

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