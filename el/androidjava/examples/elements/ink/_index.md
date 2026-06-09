---
title: Μελάνη
type: docs
weight: 180
url: /el/androidjava/examples/elements/ink/
keywords:
- παράδειγμα κώδικα
- μελάνη
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εργαστείτε με τη Μελάνη στο Aspose.Slides for Android: σχεδιάστε, εισάγετε και επεξεργαστείτε στρώματα, προσαρμόστε το χρώμα και το πλάτος, και εξάγετε σε PPT, PPTX και ODP χρησιμοποιώντας παραδείγματα Java."
---
Αυτό το άρθρο παρέχει παραδείγματα πρόσβασης σε υπάρχουσες σχήματα μελάνης και αφαίρεσής τους χρησιμοποιώντας **Aspose.Slides for Android via Java**.

> ❗ **Σημείωση:** Τα σχήματα μελάνης αντιπροσωπεύουν είσοδο χρήστη από εξειδικευμένες συσκευές. Το Aspose.Slides δεν μπορεί να δημιουργήσει νέες κινήσεις μελάνης προγραμματιστικά, αλλά μπορείτε να διαβάσετε και να τροποποιήσετε την υπάρχουσα μελάνη.

## **Πρόσβαση σε Μελάνη**

Διαβάστε τις ετικέτες από το πρώτο σχήμα μελάνης στη διαφάνεια.

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
                // Χρησιμοποιήστε το tagName όπως χρειάζεται.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Μελάνης**

Διαγράψτε ένα σχήμα μελάνης από τη διαφάνεια εάν υπάρχει.

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