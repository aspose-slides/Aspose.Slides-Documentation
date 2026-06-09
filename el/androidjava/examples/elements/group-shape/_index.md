---
title: Ομαδικό σχήμα
type: docs
weight: 170
url: /el/androidjava/examples/elements/group-shape/
keywords:
- παράδειγμα κώδικα
- ομαδικό σχήμα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε ομαδικά σχήματα στο Aspose.Slides για Android: δημιουργήστε, τοποθετήστε, ευθυγραμμίστε, αναδιατάξτε και μορφοποιήστε ομαδικά σχήματα με παραδείγματα Java σε παρουσιάσεις PPT, PPTX και ODP."
---
Παραδείγματα δημιουργίας ομάδων σχημάτων, πρόσβασης σε αυτά, αποομάδωσης και αφαίρεσης χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη ομαδικού σχήματος**

Δημιουργήστε μια ομάδα που περιέχει δύο βασικά σχήματα.

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

## **Πρόσβαση σε ομαδικό σχήμα**

Ανακτήστε το πρώτο ομαδικό σχήμα από τη διαφάνεια.

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

## **Διαγραφή ομαδικού σχήματος**

Διαγράψτε ένα ομαδικό σχήμα από τη διαφάνεια.

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

## **Αποομάδωση σχημάτων**

Μετακινήστε τα σχήματα έξω από το ομαδικό περιβάλλον.

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