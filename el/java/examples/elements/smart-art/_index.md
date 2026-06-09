---
title: SmartArt
type: docs
weight: 140
url: /el/java/examples/elements/smart-art/
keywords:
- παράδειγμα κώδικα
- SmartArt
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εργαστείτε με SmartArt στο Aspose.Slides for Java: δημιουργήστε, επεξεργαστείτε, μετατρέψτε και μορφοποιήστε διαγράμματα με Java για παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε γραφικά SmartArt, να τα προσπελάσετε, να τα διαγράψετε και να αλλάξετε τις διατάξεις χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη SmartArt**

Εισάγετε ένα γραφικό SmartArt χρησιμοποιώντας μία από τις ενσωματωμένες διατάξεις.

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση SmartArt**

Ανακτήστε το πρώτο αντικείμενο SmartArt σε μια διαφάνεια.

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση SmartArt**

Διαγράψτε ένα σχήμα SmartArt από τη διαφάνεια.

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **Αλλαγή Διάταξης SmartArt**

Ενημερώστε τον τύπο διάταξης ενός υπάρχοντος γραφικού SmartArt.

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```