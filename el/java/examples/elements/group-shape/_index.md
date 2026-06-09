---
title: Ομαδικό Σχήμα
type: docs
weight: 170
url: /el/java/examples/elements/group-shape/
keywords:
- παράδειγμα κώδικα
- ομαδικό σχήμα
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε ομαδικά σχήματα στο Aspose.Slides for Java: δημιουργία, ένθεση, στοίχιση, αναδιάταξη και μορφοποίηση ομαδικών σχημάτων με παραδείγματα Java σε παρουσιάσεις PPT, PPTX και ODP."
---
Παραδείγματα δημιουργίας ομάδων σχημάτων, πρόσβασης σε αυτά, αποομαδοποίησης και κατάργησης χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη ομάδας σχήματος**

Δημιουργήστε μια ομάδα που περιλαμβάνει δύο βασικά σχήματα.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε ομάδα σχήματος**

Ανακτήστε το πρώτο σχήμα ομάδας από μια διαφάνεια.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Κατάργηση ομάδας σχήματος**

Διαγράψτε ένα σχήμα ομάδας από τη διαφάνεια.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **Αποομαδοποίηση σχημάτων**

Μετακινήστε τα σχήματα έξω από το κοντέινερ ομάδας.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Μετακινήστε το σχήμα έξω από την ομάδα.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```