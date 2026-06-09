---
title: Μελάνη
type: docs
weight: 180
url: /el/nodejs-java/examples/elements/ink/
keywords:
- παράδειγμα κώδικα
- μελάνη
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δουλέψτε με τη Μελάνη στο Aspose.Slides για Node.js: σχεδιάστε, εισάγετε και επεξεργαστείτε στίγματα, ρυθμίστε το χρώμα και το πλάτος, και εξάγετε σε PPT, PPTX και ODP χρησιμοποιώντας παραδείγματα."
---
Αυτό το άρθρο παρέχει παραδείγματα πρόσβασης σε υπάρχουσες σχήματα μελάνης και αφαίρεσής τους χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

> ❗ **Σημείωση:** Τα σχήματα μελάνης αντιπροσωπεύουν την είσοδο του χρήστη από εξειδικευμένες συσκευές. Το Aspose.Slides δεν μπορεί να δημιουργήσει νέα στίγματα μελάνης προγραμματιστικά, αλλά μπορείτε να διαβάσετε και να τροποποιήσετε την υπάρχουσα μελάνη.

## **Πρόσβαση σε Μελάνη**

Ανακτήστε το πρώτο σχήμα μελάνης σε μια διαφάνεια.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Μελάνης**

Διαγράψτε ένα σχήμα μελάνης από τη διαφάνεια.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το σχήμα μελάνης είναι το πρώτο σχήμα στη διαφάνεια.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```