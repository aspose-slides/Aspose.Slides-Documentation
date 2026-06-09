---
title: Σύνδεσμος
type: docs
weight: 190
url: /el/androidjava/examples/elements/connector/
keywords:
- παράδειγμα κώδικα
- Σύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, δρομολογείτε και μορφοποιείτε συνδέσμους μεταξύ σχημάτων χρησιμοποιώντας το Aspose.Slides for Android, με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να συνδέσετε σχήματα με συνδέσμους και να αλλάξετε τους προορισμούς τους χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη Σύνδεσμου**

Εισάγετε ένα σχήμα σύνδεσμου μεταξύ δύο σημείων στη διαφάνεια.

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Σύνδεσμο**

Ανακτήστε το πρώτο σχήμα σύνδεσμου που προστέθηκε σε μια διαφάνεια.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Πρόσβαση στον πρώτο σύνδεσμο στη διαφάνεια.
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Κατάργηση Σύνδεσμου**

Διαγράψτε έναν σύνδεσμο από τη διαφάνεια.

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **Επανασύνδεση Σχημάτων**

Συνδέστε ένα σύνδεσμο σε δύο σχήματα αναθέτοντας τους αρχικούς και τελικούς προορισμούς.

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```