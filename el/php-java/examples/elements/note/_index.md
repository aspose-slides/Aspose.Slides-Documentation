---
title: Σημείωση
type: docs
weight: 240
url: /el/php-java/examples/elements/note/
keywords:
- σημείωση
- προσθήκη διαφάνειας σημειώσεων
- πρόσβαση σε διαφάνεια σημειώσεων
- αφαίρεση διαφάνειας σημειώσεων
- ενημέρωση κειμένου σημειώσεων
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσθέστε, διαβάστε, επεξεργαστείτε και εξάγετε σημειώσεις ομιλητή σε PHP με Aspose.Slides: μορφοποιήστε κείμενο, διαχειριστείτε τις σημειώσεις ανά διαφάνεια και ελέγξτε την ορατότητα σε PowerPoint και OpenDocument."
---
Εμφανίζει πώς να προσθέσετε, να διαβάσετε, να καταργήσετε και να ενημερώσετε τις διαφάνειες σημειώσεων χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη διαφάνειας σημειώσεων**

Δημιουργήστε μια διαφάνεια σημειώσεων και αναθέστε κείμενο σε αυτήν.

```php
function addNote() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("My note");

        $presentation->save("note.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε διαφάνεια σημειώσεων**

Διαβάστε κείμενο από μια υπάρχουσα διαφάνεια σημειώσεων.

```php
function accessNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notes = $notesSlide->getNotesTextFrame()->getText();
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση διαφάνειας σημειώσεων**

Αφαιρέστε τη διαφάνεια σημειώσεων που συνδέεται με μια διαφάνεια.

```php
function removeNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getNotesSlideManager()->removeNotesSlide();

        $presentation->save("note_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ενημέρωση κειμένου σημειώσεων**

Αλλάξτε το κείμενο μιας διαφάνειας σημειώσεων.

```php
function updateNoteText() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("Updated");

        $presentation->save("note_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```