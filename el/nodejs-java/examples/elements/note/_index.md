---
title: Σημείωση
type: docs
weight: 240
url: /el/nodejs-java/examples/elements/note/
keywords:
- παράδειγμα κώδικα
- σημείωση
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εργαστείτε με τις σημειώσεις διαφανειών στο Aspose.Slides for Node.js: προσθέστε, διαβάστε, επεξεργαστείτε και εξάγετε τις σημειώσεις ομιλητή σε PPT, PPTX και ODP χρησιμοποιώντας σαφή παραδείγματα JavaScript."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να διαβάσετε, να αφαιρέσετε και να ενημερώσετε διαφάνειες σημειώσεων χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη διαφάνειας σημειώσεων**

Δημιουργήστε μια διαφάνεια σημειώσεων και εκχωρήστε κείμενο σε αυτήν.

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

## **Πρόσβαση σε διαφάνεια σημειώσεων**

Διαβάστε το κείμενο από μια υπάρχουσα διαφάνεια σημειώσεων.

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

## **Αφαίρεση διαφάνειας σημειώσεων**

Αφαιρέστε τη διαφάνεια σημειώσεων που σχετίζεται με μια διαφάνεια.

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

## **Ενημέρωση κειμένου σημειώσεων**

Αλλάξτε το κείμενο μιας διαφάνειας σημειώσεων.

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