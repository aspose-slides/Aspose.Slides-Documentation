---
title: Σχήμα Ομάδας
type: docs
weight: 170
url: /el/nodejs-java/examples/elements/group-shape/
keywords:
- παράδειγμα κώδικα
- σχήμα ομάδας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε ομάδες σχημάτων στο Aspose.Slides για Node.js: δημιουργήστε, ενσωματώστε, ευθυγραμμίστε, αναδιατάξτε και μορφοποιήστε σχήματα ομάδας με παραδείγματα σε παρουσιάσεις PPT, PPTX και ODP."
---
Παραδείγματα δημιουργίας ομάδων σχημάτων, πρόσβασης σε αυτά, αποομαδοποίησης και αφαίρεσης χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη Σχήματος Ομάδας**

Δημιουργήστε μια ομάδα που περιέχει δύο βασικά σχήματα.

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Σχήμα Ομάδας**

Ανακτήστε το πρώτο σχήμα ομάδας από μια διαφάνεια.

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Σχήματος Ομάδας**

Διαγράψτε ένα σχήμα ομάδας από τη διαφάνεια.

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα είναι σχήμα ομάδας.
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Αποομαδοποίηση Σχημάτων**

Μετακινήστε σχήματα εκτός του κοντέινερ ομάδας.

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα είναι σχήμα ομάδας.
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // Κλωνοποιήστε κάθε σχήμα από την ομάδα στη διαφάνεια.
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```