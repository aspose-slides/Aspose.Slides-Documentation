---
title: Διαφάνεια Διάταξης
type: docs
weight: 20
url: /el/androidjava/examples/elements/layout-slide/
keywords:
- παράδειγμα κώδικα
- διαφάνεια διάταξης
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Κύριες διαφάνειες διάταξης στο Aspose.Slides για Android: επιλέξτε, εφαρμόστε και προσαρμόστε διατάξεις διαφανειών, σύμβολα κράτησης και πρότυπα με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
This article demonstrates how to work with **Διαφάνειες Διάταξης** in Aspose.Slides for Android via Java. A layout slide defines the design and formatting inherited by normal slides. You can add, access, clone, and remove layout slides, as well as clean up unused ones to reduce presentation size.

## **Προσθήκη Διαφάνειας Διάταξης**

You can create a custom layout slide to define reusable formatting. For example, you might add a text box that appears on all slides using this layout.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Δημιουργήστε μια διαφάνεια διάταξης με τύπο κενής διάταξης και προσαρμοσμένο όνομα.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Προσθέστε ένα πλαίσιο κειμένου στη διαφάνεια διάταξης.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Προσθέστε δύο διαφάνειες χρησιμοποιώντας αυτή τη διάταξη· και οι δύο θα κληρονομήσουν το κείμενο από τη διάταξη.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Διαφάνειες διάταξης λειτουργούν ως πρότυπα για μεμονωμένες διαφάνειες. Μπορείτε να ορίσετε κοινά στοιχεία μία φορά και να τα επαναχρησιμοποιήσετε σε πολλές διαφάνειες.
> 
> 💡 **Note 2:** Όταν προσθέτετε σχήματα ή κείμενο σε μια διαφάνεια διάταξης, όλες οι διαφάνειες που βασίζονται σε αυτή τη διάταξη θα εμφανίζουν αυτό το κοινό περιεχόμενο αυτόματα.
> Το παρακάτω στιγμιότυπο οθόνης δείχνει δύο διαφάνειες, η καθεμία από τις οποίες κληρονομεί ένα πλαίσιο κειμένου από την ίδια διαφάνεια διάταξης.

![Διαφάνειες που Κληρονομούν Περιεχόμενο Διάταξης](layout-slide-result.png)

## **Πρόσβαση σε Διαφάνεια Διάταξης**

Layout slides can be accessed by index or by layout type (e.g., `Blank`, `Title`, `SectionHeader`, etc.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Πρόσβαση σε διαφάνεια διάταξης με δείκτη.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Πρόσβαση σε διαφάνεια διάταξης με τύπο.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Διαφάνειας Διάταξης**

You can remove a specific layout slide if it's no longer needed.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Λάβετε μια διαφάνεια διάταξης κατά τύπο και καταργήστε την.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Αχρησιμοποίητων Διαφανειών Διάταξης**

To reduce the presentation size, you may want to remove layout slides that are not used by any normal slides.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Αφαιρεί αυτόματα όλες τις διαφάνειες διάταξης που δεν αναφέρονται από καμία διαφάνεια.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Κλωνοποίηση Διαφάνειας Διάταξης**

You can duplicate a layout slide using the `addClone` method.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Λάβετε μια υπάρχουσα διαφάνεια διάταξης κατά τύπο.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Κλωνοποιήστε τη διαφάνεια διάταξης στο τέλος της συλλογής διαφανειών διάταξης.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Σύνοψη:** Οι διαφάνειες διάταξης είναι ισχυρά εργαλεία για τη διαχείριση συνεπούς μορφοποίησης σε όλες τις διαφάνειες. Aspose.Slides allows full control over creating, managing, and optimizing layout slides.