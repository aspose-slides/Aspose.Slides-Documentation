---
title: Μελάνη
type: docs
weight: 180
url: /el/java/examples/elements/ink/
keywords:
- παράδειγμα κώδικα
- μελάνη
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Δουλέψτε με τη Μελάνη στο Aspose.Slides for Java: σχεδιάστε, εισάγετε και επεξεργαστείτε τις γραμμές, ρυθμίστε το χρώμα και το πλάτος και εξαγάγετε σε PPT, PPTX και ODP χρησιμοποιώντας παραδείγματα Java."
---
Αυτό το άρθρο παρέχει παραδείγματα πρόσβασης σε υπάρχουσες σχήματα μελάνης και αφαίρεσής τους χρησιμοποιώντας **Aspose.Slides for Java**.

> ❗ **Σημείωση:** Τα σχήματα μελάνης αντιπροσωπεύουν την είσοδο χρήστη από εξειδικευμένες συσκευές. Το Aspose.Slides δεν μπορεί να δημιουργήσει νέα γραφικά σημεία μελάνης προγραμματικά, αλλά μπορείτε να διαβάσετε και να τροποποιήσετε την υπάρχουσα μελάνη.

## **Πρόσβαση στη Μελάνη**

Διαβάστε τις ετικέτες από το πρώτο σχήμα μελάνης σε μια διαφάνεια.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // Χρησιμοποιήστε το tagName όπως απαιτείται.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Μελάνης**

Διαγράψτε ένα σχήμα μελάνης από τη διαφάνεια αν υπάρχει.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```