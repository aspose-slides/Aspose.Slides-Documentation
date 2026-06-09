---
title: Κύρια Διαφάνεια
type: docs
weight: 30
url: /el/nodejs-java/examples/elements/master-slide/
keywords:
- παράδειγμα κώδικα
- κύρια διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα κύριων διαφανειών Aspose.Slides για Node.js: δημιουργήστε, επεξεργαστείτε και διαμορφώστε master, πλαίσια κράτησης θέσης και θέματα σε PPT, PPTX και ODP με σαφή κώδικα."
---
Οι κύριες διαφάνειες αποτελούν το ανώτερο επίπεδο της ιεραρχίας κληρονομικότητας διαφανειών στο PowerPoint. Μια **master slide** ορίζει κοινά στοιχεία σχεδίασης όπως φόντο, λογότυπα και μορφοποίηση κειμένου. **Layout slides** κληρονομούν από τις master slides, και **normal slides** κληρονομούν από τις layout slides.

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε, τροποποιήσετε και διαχειριστείτε τις master slides χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java.

## **Προσθήκη Master Slide**

Αυτό το παράδειγμα δείχνει πώς να δημιουργήσετε μια νέα master slide αντιγράφοντας την προεπιλεγμένη. Στη συνέχεια προσθέτει ένα λογότυπο με το όνομα της εταιρείας σε όλες τις διαφάνειες μέσω κληρονομικότητας layout.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Αντιγράψτε την προεπιλεγμένη κύρια διαφάνεια.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Προσθέστε μια λωρίδα με το όνομα της εταιρείας στην κορυφή της κύριας διαφάνειας.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Αναθέστε τη νέα κύρια διαφάνεια σε μια διαφάνεια διάταξης.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Αναθέστε τη διαφάνεια διάταξης στην πρώτη διαφάνεια της παρουσίασης.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Σημείωση 1:** Οι master slides παρέχουν τρόπο για να εφαρμόζετε συνεπή branding ή κοινά στοιχεία σχεδίασης σε όλες τις διαφάνειες. Οποιεσδήποτε αλλαγές γίνουν στη master θα αντικατοπτρίζονται αυτόματα στις εξαρτώμενες layout και normal διαφάνειες.

> 💡 **Σημείωση 2:** Οποιαδήποτε σχήματα ή μορφοποίηση προστεθούν σε μια master slide κληρονομούνται από τις layout slides και, με τη σειρά τους, από όλες τις normal διαφάνειες που χρησιμοποιούν αυτές τις διατάξεις.  
> Η παρακάτω εικόνα δείχνει πώς ένα πλαίσιο κειμένου που προστέθηκε σε μια master slide αποδίδεται αυτόματα στην τελική διαφάνεια.

![Παράδειγμα κληρονομικότητας master](master-slide-banner.png)

## **Πρόσβαση σε Master Slide**

Μπορείτε να έχετε πρόσβαση στις master slides χρησιμοποιώντας τη συλλογή master του παρόντος. Ακολουθεί η διαδικασία ανάκτησης και εργασίας με αυτές:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Αλλαγή του τύπου φόντου.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Master Slide**

Οι master slides μπορούν να αφαιρεθούν είτε με δείκτη είτε με αναφορά.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Αφαίρεση κύριας διαφάνειας κατά δείκτη.
        presentation.getMasters().removeAt(0);

        // Αφαίρεση κύριας διαφάνειας με αναφορά.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση μη χρησιμοποιημένων Master Slides**

Ορισμένες παρουσιάσεις περιέχουν master slides που δεν χρησιμοποιούνται. Η αφαίρεση αυτών των διαφανειών μπορεί να βοηθήσει στη μείωση του μεγέθους του αρχείου.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Αφαίρεση όλων των αχρησιμοποίητων κύριων διαφανειών (ακόμα και εκείνων που έχουν επισημανθεί ως Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```