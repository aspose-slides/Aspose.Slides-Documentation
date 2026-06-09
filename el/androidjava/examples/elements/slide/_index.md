---
title: Διαφάνεια
type: docs
weight: 10
url: /el/androidjava/examples/elements/slide/
keywords:
- παράδειγμα κώδικα
- διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις διαφάνειες στο Aspose.Slides for Android: δημιουργία, κλωνοποίηση, επαναδιάταξη, αλλαγή μεγέθους, ορισμός φόντου και εφαρμογή μεταβάσεων με Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο παρέχει μια σειρά παραδειγμάτων που δείχνουν πώς να εργάζεστε με διαφάνειες χρησιμοποιώντας **Aspose.Slides for Android via Java**. Θα μάθετε πώς να προσθέτετε, να προσπελάζετε, να κλωνοποιείτε, να επαναδιατάσσετε και να αφαιρείτε διαφάνειες χρησιμοποιώντας την κλάση `Presentation`.

Κάθε παράδειγμα παρακάτω περιλαμβάνει μια σύντομη εξήγηση, ακολουθούμενη από ένα τμήμα κώδικα σε Java.

## **Προσθήκη διαφάνειας**

Για να προσθέσετε μια νέα διαφάνεια, πρέπει πρώτα να επιλέξετε διάταξη. Σε αυτό το παράδειγμα, χρησιμοποιούμε τη διάταξη `Blank` και προσθέτουμε μια κενή διαφάνεια στην παρουσίαση.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Σημείωση:** Κάθε διάταξη διαφάνειας προέρχεται από μια κύρια διαφάνεια, η οποία ορίζει το συνολικό σχεδιασμό και τη δομή των δεσμευτικών θέσεων. Η παρακάτω εικόνα απεικονίζει πώς οργανώνονται οι κύριες διαφάνειες και οι σχετικές διατάξεις τους στο PowerPoint.
![Σχέση κύριας διαφάνειας και διάταξης](master-layout-slide.png)

## **Πρόσβαση σε διαφάνειες με δείκτη**

Μπορείτε να προσπελάσετε τις διαφάνειες χρησιμοποιώντας το δείκτη τους ή να βρείτε το δείκτη μιας διαφάνειας βάσει μιας αναφοράς. Αυτό είναι χρήσιμο για επανάληψη ή τροποποίηση συγκεκριμένων διαφαινέων.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Προσθέστε άλλη κενή διαφάνεια.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Πρόσβαση στις διαφάνειες με δείκτη.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Λάβετε το δείκτη της διαφάνειας από μια αναφορά, στη συνέχεια προσπελάστε την με δείκτη.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Κλωνοποίηση διαφάνειας**

Αυτό το παράδειγμα δείχνει πώς να κλωνοποιήσετε μια υπάρχουσα διαφάνεια. Η κλωνοποιημένη διαφάνεια προστίθεται αυτόματα στο τέλος της συλλογής διαφανειών.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Επαναδιάταξη διαφανειών**

Μπορείτε να αλλάξετε τη σειρά των διαφανειών μετακινώντας μία σε νέο δείκτη. Σε αυτή την περίπτωση, μετακινούμε μια κλωνοποιημένη διαφάνεια στην πρώτη θέση.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση διαφάνειας**

Για να αφαιρέσετε μια διαφάνεια, απλώς αναφερθείτε σε αυτήν και καλέστε `remove`. Αυτό το παράδειγμα προσθέτει μια δεύτερη διαφάνεια και στη συνέχεια αφαιρεί την αρχική, αφήνοντας μόνο τη νέα.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```