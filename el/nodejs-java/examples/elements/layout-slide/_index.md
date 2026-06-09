---
title: Διαφάνεια διάταξης
type: docs
weight: 20
url: /el/nodejs-java/examples/elements/layout-slide/
keywords:
- παράδειγμα κώδικα
- διαφάνεια διάταξης
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Κύριες διαφάνειες διάταξης στο Aspose.Slides για Node.js: επιλέξτε, εφαρμόστε και προσαρμόστε τις διατάξεις διαφανειών, τους κράτητες θέσης και τα master με παραδείγματα για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εργάζεστε με **Layout Slides** στο Aspose.Slides για Node.js μέσω Java. Μια διαφάνεια διατάξεων ορίζει το σχεδιασμό και τη μορφοποίηση που κληρονομούν οι κανονικές διαφάνειες. Μπορείτε να προσθέτετε, να έχετε πρόσβαση, να κλωνοποιείτε και να καταργείτε διαφάνειες διατάξεων, καθώς και να καθαρίζετε τις αχρησιμοποίητες για να μειώσετε το μέγεθος της παρουσίασης.

## **Προσθήκη διαφάνειας διατάξεων**

Μπορείτε να δημιουργήσετε μια προσαρμοσμένη διαφάνεια διατάξεων για να ορίσετε επαναχρησιμοποιήσιμη μορφοποίηση.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Δημιουργήστε μια διαφάνεια διάταξης με τύπο διάταξης κενό και προσαρμοσμένο όνομα.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Σημείωση 1:** Οι διαφάνειες διατάξεων λειτουργούν ως πρότυπα για μεμονωμένες διαφάνειες. Μπορείτε να ορίσετε κοινά στοιχεία μία φορά και να τα επαναχρησιμοποιήσετε σε πολλές διαφάνειες.
> 
> 💡 **Σημείωση 2:** Όταν προσθέτετε σχήματα ή κείμενο σε μια διαφάνεια διατάξεων, όλες οι διαφάνειες που βασίζονται σε αυτήν τη διάταξη θα εμφανίσουν αυτό το κοινό περιεχόμενο αυτόματα.
> Το παρακάτω στιγμιότυπο δείχνει δύο διαφάνειες, η καθεμία από τις οποίες κληρονομεί ένα πλαίσιο κειμένου από την ίδια διαφάνεια διατάξεων.

![Διαφάνειες που κληρονομούν περιεχόμενο διάταξης](layout-slide-result.png)

## **Πρόσβαση σε διαφάνεια διατάξεων**

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Πρόσβαση σε διαφάνεια διάταξης κατά δείκτη.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Πρόσβαση σε διαφάνεια διάταξης με βάση τον τύπο.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Κατάργηση διαφάνειας διατάξεων**

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Λάβετε μια διαφάνεια διάταξης κατά τύπο και αφαιρέστε την.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Κατάργηση αχρησιμοποίητων διαφανειών διατάξεων**

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Αφαιρεί αυτόματα όλες τις διαφάνειες διάταξης που δεν αναφέρονται από καμία διαφάνεια.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Κλωνοποίηση διαφάνιας διατάξεων**

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Λάβετε μια υπάρχουσα διαφάνεια διάταξης κατά τύπο.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Κλωνοποιήστε τη διαφάνεια διάταξης στο τέλος της συλλογής διαφανειών διάταξης.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Σύνοψη:** Οι διαφάνειες διατάξεων είναι ισχυρά εργαλεία για τη διαχείριση συνεπούς μορφοποίησης μεταξύ των διαφανειών. Το Aspose.Slides παρέχει πλήρη έλεγχο στην δημιουργία, διαχείριση και βελτιστοποίηση των διαφανειών διατάξεων.