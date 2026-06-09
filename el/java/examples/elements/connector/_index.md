---
title: Σύνδεσμος
type: docs
weight: 190
url: /el/java/examples/elements/connector/
keywords:
- παράδειγμα κώδικα
- Σύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να διαδρομίζετε και να μορφοποιείτε συνδέσμους μεταξύ σχημάτων χρησιμοποιώντας το Aspose.Slides for Java, με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να συνδέετε σχήματα με συνδέσμους και να αλλάζετε τους προορισμούς τους χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη σύνδεσμου**

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

## **Πρόσβαση σε σύνδεσμο**

Ανακτήστε το πρώτο σχήμα σύνδεσμου που προστέθηκε στη διαφάνεια.

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

## **Αφαίρεση σύνδεσμου**

Διαγράψτε ένα σύνδεσμο από τη διαφάνεια.

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

## **Επανασύνδεση σχημάτων**

Συνδέστε έναν σύνδεσμο σε δύο σχήματα ορίζοντας τους αρχικούς και τελικούς προορισμούς.

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