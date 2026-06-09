---
title: Σημείωση
type: docs
weight: 240
url: /el/java/examples/elements/note/
keywords:
- παράδειγμα κώδικα
- σημείωση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εργαστείτε με τις σημειώσεις διαφάνειας στο Aspose.Slides for Java: προσθέστε, διαβάστε, επεξεργαστείτε και εξάγετε τις σημειώσεις ομιλητή σε PPT, PPTX και ODP χρησιμοποιώντας σαφή παραδείγματα Java."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να διαβάσετε, να αφαιρέσετε και να ενημερώσετε διαφάνειες σημειώσεων χρησιμοποιώντας το **Aspose.Slides for Java**.

## **Προσθήκη διαφάνειας σημειώσεων**

Δημιουργείστε μια διαφάνεια σημειώσεων και αντιστοιχίστε κείμενο σε αυτήν.

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε διαφάνεια σημειώσεων**

Διαβάστε το κείμενο από μια υπάρχουσα διαφάνεια σημειώσεων.

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση διαφάνειας σημειώσεων**

Αφαιρέστε τη διαφάνεια σημειώσεων που σχετίζεται με μια διαφάνεια.

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **Ενημέρωση κειμένου σημειώσεων**

Αλλάξτε το κείμενο μιας διαφάνειας σημειώσεων.

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```