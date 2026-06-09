---
title: Μετάβαση Διαφάνειας
type: docs
weight: 110
url: /el/nodejs-java/examples/elements/slide-transition/
keywords:
- παράδειγμα κώδικα
- μετάβαση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε τις μεταβάσεις διαφάνειας στο Aspose.Slides για Node.js: προσθέστε, προσαρμόστε και ακολουθήστε εφέ και διάρκειες με παραδείγματα για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εφαρμόζετε εφέ μετάβασης διαφάνειας και χρόνους με **Aspose.Slides for Node.js via Java**.

## **Add a Slide Transition**
Προσθήκη μετάβασης διαφάνειας

Εφαρμόστε εφέ μετάβασης ξεθωριάσματος στην πρώτη διαφάνεια.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Εφαρμόστε μια μετάβαση ξεθωριάσματος.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Slide Transition**
Πρόσβαση σε μετάβαση διαφάνειας

Διαβάστε τον τύπο μετάβασης που έχει εκχωρηθεί σε μια διαφάνεια.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Πρόσβαση στον τύπο μετάβασης.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Slide Transition**
Αφαίρεση μετάβασης διαφάνειας

Καθαρίστε οποιοδήποτε εφέ μετάβασης ορίζοντας τον τύπο σε `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Αφαίρεση της μετάβασης ορίζοντας none.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Transition Duration**
Ορισμός διάρκειας μετάβασης

Καθορίστε πόσο χρόνο εμφανίζεται η διαφάνεια πριν προχωρήσει αυτόματα.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // σε χιλιοστά του δευτερολέπτου.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```