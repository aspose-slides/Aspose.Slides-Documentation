---
title: Μετάβαση Διαφάνειας
type: docs
weight: 110
url: /el/php-java/examples/elements/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- πρόσβαση σε μετάβαση διαφάνειας
- κατάργηση μετάβασης διαφάνειας
- διάρκεια μετάβασης
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τις μεταβάσεις διαφάνειας σε PHP με το Aspose.Slides: επιλέξτε τύπους, ταχύτητα, ήχο και χρονισμό για να τελειοποιήσετε τις παρουσιάσεις σε PPT, PPTX και ODP."
---
Δείχνει την εφαρμογή εφέ μετάβασης διαφάνειας και χρόνων με **Aspose.Slides for PHP via Java**.

## **Προσθήκη Μετάβασης Διαφάνειας**

Εφαρμόστε ένα εφέ μετάβασης ξεθώριασματος στην πρώτη διαφάνεια.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Εφαρμόστε μια μετάβαση ξεθώριασματος.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε Μετάβαση Διαφάνειας**

Διαβάστε τον τύπο μετάβασης που έχει ανατεθεί σε μια διαφάνεια.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στον τύπο της μετάβασης.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Κατάργηση Μετάβασης Διαφάνειας**

Αφαιρέστε οποιοδήποτε εφέ μετάβασης ορίζοντας τον τύπο σε `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Αφαίρεση μετάβασης ορίζοντας none.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ορισμός Διάρκειας Μετάβασης**

Καθορίστε πόσο χρόνο θα εμφανίζεται η διαφάνεια πριν προχωρήσει αυτόματα.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // σε χιλιοστά του δευτερολέπτου.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```