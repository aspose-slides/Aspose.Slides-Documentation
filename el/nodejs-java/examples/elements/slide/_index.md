---
title: Διαφάνεια
type: docs
weight: 10
url: /el/nodejs-java/examples/elements/slide/
keywords:
- παράδειγμα κώδικα
- διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τις διαφάνειες στο Aspose.Slides for Node.js: δημιουργήστε, κλωνοποιήστε, αναδιατάξτε, αλλάξτε το μέγεθος, ορίστε φόντα και εφαρμόστε μεταβάσεις για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο παρέχει μια σειρά παραδειγμάτων που δείχνουν πώς να εργάζεστε με διαφάνειες χρησιμοποιώντας **Aspose.Slides for Node.js via Java**. Θα μάθετε πώς να προσθέτετε, να προσπελάζετε, να κλωνοποιείτε, να αναδιατάσσετε και να αφαιρείτε διαφάνειες χρησιμοποιώντας την κλάση `Presentation`.

Κάθε παράδειγμα παρακάτω περιλαμβάνει μια σύντομη εξήγηση, ακολουθούμενη από ένα απόσπασμα κώδικα σε JavaScript.

## **Προσθήκη διαφάνειας**

Για να προσθέσετε μια νέα διαφάνεια, πρέπει πρώτα να επιλέξετε μια διάταξη. Σε αυτό το παράδειγμα, χρησιμοποιούμε τη διάταξη `Blank` και προσθέτουμε μια κενή διαφάνεια στην παρουσίαση.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Σημείωση:** Κάθε διάταξη διαφάνειας προέρχεται από μια κύρια διαφάνεια, η οποία ορίζει το συνολικό σχεδιασμό και τη δομή των δεσμευτικών θέσεων. Η εικόνα παρακάτω απεικονίζει πώς οι κύριες διαφάνειες και οι σχετικές διατάξεις τους οργανώνονται στο PowerPoint.

![Σχέση κύριας διαφάνειας και διάταξης](master-layout-slide.png)

## **Πρόσβαση σε διαφάνειες κατά δείκτη**

Μπορείτε να προσπελάσετε τις διαφάνειες χρησιμοποιώντας το δείκτη τους. Αυτό είναι χρήσιμο για την επανάληψη ή την τροποποίηση συγκεκριμένων διαφανειών.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Πρόσβαση σε διαφάνεια κατά δείκτη.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Κλωνοποίηση διαφάνειας**

Αυτό το παράδειγμα δείχνει πώς να κλωνοποιήσετε μια υπάρχουσα διαφάνεια. Η κλωνοποιημένη διαφάνεια προστίθεται αυτόματα στο τέλος της συλλογής διαφανειών.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Αναδιάταξη διαφανειών**

Μπορείτε να αλλάξετε τη σειρά των διαφανειών μετακινώντας μία σε νέο δείκτη. Σε αυτή την περίπτωση, μετακινούμε μια διαφάνεια στην πρώτη θέση.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Αναδιάταξη διαφανειών μετακινώντας τη δεύτερη διαφάνεια στην πρώτη θέση.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση διαφάνειας**

Για να αφαιρέσετε μια διαφάνεια, απλώς αναφοράτε την και καλέστε την `remove`. Αυτό το παράδειγμα προσθέτει μια δεύτερη διαφάνεια και στη συνέχεια αφαιρεί την αρχική, αφήνοντας μόνο τη νέα.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```