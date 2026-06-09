---
title: Διαφάνεια Διάταξης
type: docs
weight: 20
url: /el/java/examples/elements/layout-slide/
keywords:
- παράδειγμα κώδικα
- διαφάνεια διάταξης
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Κύριες διαφάνειες διάταξης στο Aspose.Slides για Java: επιλέξτε, εφαρμόστε και προσαρμόστε διαφάνειες διάταξης, σύμβολα κράτησης θέσης και πρότυπα με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εργάζεστε με **Layout Slides** στο Aspose.Slides για Java. Μια διαφάνεια διάταξης ορίζει το σχεδιασμό και τη μορφοποίηση που κληρονομείται από τις κανονικές διαφάνειες. Μπορείτε να προσθέσετε, να αποκτήσετε πρόσβαση, να κλωνοποιήσετε και να αφαιρέσετε διαφάνειες διάταξης, καθώς και να καθαρίσετε τις αχρησιμοποίητες ώστε να μειώσετε το μέγεθος της παρουσίασης.

## **Προσθήκη διαφάνειας διάταξης**

Μπορείτε να δημιουργήσετε μια προσαρμοσμένη διαφάνεια διάταξης για να ορίσετε επαναχρησιμοποιήσιμη μορφοποίηση. Για παράδειγμα, μπορεί να προσθέσετε ένα πλαίσιο κειμένου που εμφανίζεται σε όλες τις διαφάνειες που χρησιμοποιούν αυτή τη διάταξη.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Δημιουργεί μια διαφάνεια διάταξης με κενό τύπο διάταξης και προσαρμοσμένο όνομα.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Προσθέτει ένα πλαίσιο κειμένου στη διαφάνεια διάταξης.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Προσθέτει δύο διαφάνειες χρησιμοποιώντας αυτή τη διάταξη· και οι δύο θα κληρονομήσουν το κείμενο από τη διάταξη.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Σημείωση 1:** Οι διαφάνειες διάταξης λειτουργούν ως πρότυπα για ξεχωριστές διαφάνειες. Μπορείτε να ορίσετε κοινά στοιχεία μία φορά και να τα επαναχρησιμοποιήσετε σε πολλές διαφάνειες.

> 💡 **Σημείωση 2:** Όταν προσθέτετε σχήματα ή κείμενο σε μια διαφάνεια διάταξης, όλες οι διαφάνειες που βασίζονται σε αυτή τη διάταξη θα εμφανίσουν αυτό το κοινό περιεχόμενο αυτόματα.
> Το στιγμιότυπο οθόνης παρακάτω δείχνει δύο διαφάνειες, η κάθε μία κληρονομεί ένα πλαίσιο κειμένου από την ίδια διαφάνεια διάταξης.

![Διαφάνειες που κληρονομούν περιεχόμενο διάταξης](layout-slide-result.png)

## **Πρόσβαση σε διαφάνεια διάταξης**

Οι διαφάνειες διάταξης μπορούν να προσπελαστούν κατά δείκτη ή κατά τύπο διάταξης (π.χ., `Blank`, `Title`, `SectionHeader`, κλπ).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Πρόσβαση σε διαφάνεια διάταξης κατά δείκτη.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Πρόσβαση σε διαφάνεια διάταξης κατά τύπο.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση διαφάνειας διάταξης**

Μπορείτε να αφαιρέσετε μια συγκεκριμένη διαφάνεια διάταξης αν δεν χρειάζεται πια.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Αποκτήστε μια διαφάνεια διάταξης κατά τύπο και αφαιρέστε την.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση αχρησιμοποίητων διαφανειών διάταξης**

Για να μειώσετε το μέγεθος της παρουσίασης, ίσως θελήσετε να αφαιρέσετε τις διαφάνειες διάταξης που δεν χρησιμοποιούνται από καμία κανονική διαφάνεια.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Αυτόματα αφαιρεί όλες τις διαφάνειες διάταξης που δεν αναφέρονται από καμία διαφάνεια.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Κλωνοποίηση διαφάνειας διάταξης**

Μπορείτε να αντιγράψετε μια διαφάνεια διάταξης χρησιμοποιώντας τη μέθοδο `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Αποκτήστε μια υπάρχουσα διαφάνεια διάταξης κατά τύπο.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Κλωνοποιήστε τη διαφάνεια διάταξης στο τέλος της συλλογής διαφανειών διάταξης.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Σύνοψη:** Οι διαφάνειες διάταξης είναι ισχυρά εργαλεία για τη διαχείριση συνεπούς μορφοποίησης σε όλο το σετ διαφανειών. Το Aspose.Slides παρέχει πλήρη έλεγχο για τη δημιουργία, τη διαχείριση και την βελτιστοποίηση των διαφανειών διάταξης.