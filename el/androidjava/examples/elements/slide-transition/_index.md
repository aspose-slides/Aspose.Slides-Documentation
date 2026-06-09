---
title: Μετάβαση Διαφάνειας
type: docs
weight: 110
url: /el/androidjava/examples/elements/slide-transition/
keywords:
- παράδειγμα κώδικα
- μετάβαση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Κατέχετε τις μεταβάσεις διαφάνειας στο Aspose.Slides για Android: προσθέστε, προσαρμόστε και ακολουθήστε εφέ και διάρκειες με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εφαρμόσετε εφέ μετάβασης διαφάνειας και χρόνους με **Aspose.Slides for Android via Java**.

## **Προσθήκη Μετάβασης Διαφάνειας**

Εφαρμόστε ένα εφέ μετάβασης ξεθώριασμα στην πρώτη διαφάνεια.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Εφαρμόστε μια μετάβαση ξεθώριασμα.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Μετάβαση Διαφάνειας**

Διαβάστε τον τύπο μετάβασης που έχει εκχωρηθεί σε μια διαφάνεια.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Πρόσβαση στον τύπο της μετάβασης.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Μετάβασης Διαφάνειας**

Καθαρίστε οποιοδήποτε εφέ μετάβασης καθορίζοντας τον τύπο σε `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Αφαίρεση μετάβασης ορίζοντας none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Ορισμός Διάρκειας Μετάβασης**

Καθορίστε για πόσο χρόνο εμφανίζεται η διαφάνεια προ της αυτόματης προόδου.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // σε χιλιοστά του δευτερολέπτου.
    } finally {
        presentation.dispose();
    }
}
```