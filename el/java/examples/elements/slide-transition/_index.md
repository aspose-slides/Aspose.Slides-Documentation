---
title: Μετάβαση διαφάνειας
type: docs
weight: 110
url: /el/java/examples/elements/slide-transition/
keywords:
- παράδειγμα κώδικα
- μετάβαση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Κατακτήστε τις μεταβάσεις διαφάνειας στο Aspose.Slides for Java: προσθέστε, προσαρμόστε και ακολουθήστε εφέ και διάρκειες με παραδείγματα Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει την εφαρμογή εφέ μετάβασης διαφανειών και χρονισμών με **Aspose.Slides for Java**.

## **Προσθήκη μετάβασης διαφάνειας**

Εφαρμόστε ένα εφέ εξασθένισης στη πρώτη διαφάνεια.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Εφαρμόστε εφέ εξασθένισης.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε μετάβαση διαφάνειας**

Διαβάστε τον τύπο μετάβασης που είναι επί του παρόντος εκχωρημένος σε μια διαφάνεια.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Πρόσβαση στον τύπο μετάβασης.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση μετάβασης διαφάνειας**

Καθαρίστε οποιοδήποτε εφέ μετάβασης ορίζοντας τον τύπο σε `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Αφαιρέστε τη μετάβαση ορίζοντας none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Ορισμός διάρκειας μετάβασης**

Καθορίστε πόσο χρόνο εμφανίζεται η διαφάνεια πριν προχωρήσει αυτόματα.

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