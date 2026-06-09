---
title: "Δημιουργία μικρογραφιών σχημάτων παρουσίασης σε JavaScript"
linktitle: "Μικρογραφίες Σχημάτων"
type: docs
weight: 70
url: /el/nodejs-java/create-shape-thumbnails/
keywords:
- "μικρογραφία σχήματος"
- "εικόνα σχήματος"
- "απόδοση σχήματος"
- "απόδοση σχήματος"
- "PowerPoint"
- "παρουσίαση"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχημάτων από διαφάνειες PowerPoint με JavaScript και Aspose.Slides για Node.js - δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Το Aspose.Slides χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης όπου κάθε σελίδα είναι μια διαφάνεια. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Αλλά κάποιες φορές, οι προγραμματιστές μπορεί να χρειαστούν να δουν τις εικόνες των σχημάτων ξεχωριστά σε προβολέα εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες των σχημάτων των διαφανειών. Πώς να χρησιμοποιήσετε αυτή τη δυνατότητα περιγράφεται σε αυτό το άρθρο.
Αυτό το άρθρο εξηγεί πώς να παράγετε μικρογραφίες διαφανειών με διάφορους τρόπους:

- Δημιουργία μικρογραφίας σχήματος μέσα σε διαφάνεια.
- Δημιουργία μικρογραφίας σχήματος για σχήμα διαφάνειας με διαστάσεις που ορίζονται από το χρήστη.
- Δημιουργία μικρογραφίας σχήματος εντός των ορίων της εμφάνισης ενός σχήματος.

## **Δημιουργία μικρογραφιών σχήματος από διαφάνειες**
Για να δημιουργήσετε μια μικρογραφία σχήματος από οποιαδήποτε διαφάνεια χρησιμοποιώντας το Aspose.Slides for Node.js via Java, κάντε το εξής:

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το δείκτη της.
1. [Ανακτήστε την εικόνα μικρογραφίας του σχήματος](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getImage--) της αναφερθείσας διαφάνειας σε προεπιλεγμένη κλίμακα.
1. Αποθηκεύστε τη μικρογραφία στην προτιμώμενη μορφή εικόνας.

Αυτός ο κώδικας δείγματος δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος από μια διαφάνεια:

```javascript
// Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Δημιουργήστε μια εικόνα πλήρους κλίμακας
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Δημιουργία μικρογραφιών σχήματος με παράγοντα κλιμάκωσης οριζόμενο από το χρήστη**
Για να δημιουργήσετε τη μικρογραφία σχήματος μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides for Node.js via Java, κάντε το εξής:

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το δείκτη της.
1. [Ανακτήστε την εικόνα μικρογραφίας του σχήματος](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) της αναφερθείσας διαφάνειας με διαστάσεις που ορίζονται από το χρήστη.
1. Αποθηκεύστε τη μικρογραφία στην προτιμώμενη μορφή εικόνας.

Αυτός ο κώδικας δείγματος δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος με βάση έναν ορισμένο παράγοντα κλιμάκωσης:

```javascript
// Δημιουργήστε μια κλάση Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Δημιουργήστε μια εικόνα πλήρους κλίμακας
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Δημιουργία μικρογραφίας σχήματος εντός ορίων**
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχημάτων επιτρέπει στους προγραμματιστές να δημιουργήσουν μια μικρογραφία εντός των ορίων της εμφάνισης του σχήματος. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η παραγόμενη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας. Για να δημιουργήσετε μια μικρογραφία ενός σχήματος διαφάνειας στα όρια της εμφάνισής του, κάντε το εξής:

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφερθείσας διαφάνειας με τα όρια του σχήματος ως εμφάνιση.
1. Αποθηκεύστε τη μικρογραφία στην προτιμώμενη μορφή εικόνας.

Αυτός ο κώδικας δείγματος βασίζεται στα παραπάνω βήματα:

```javascript
// Δημιουργήστε μια κλάση Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Δημιουργήστε μια εικόνα πλήρους κλίμακας
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Ποιες μορφές εικόνας μπορούν να χρησιμοποιηθούν κατά την αποθήκευση μικρογραφιών σχήματος;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imageformat/), και άλλες. Τα σχήματα μπορούν επίσης να [εξαχθούν ως διανυσματικό SVG](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/writeassvg/) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

**Ποια είναι η διαφορά μεταξύ των ορίων Shape και Appearance κατά την απόδοση μιας μικρογραφίας;**

`Shape` χρησιμοποιεί τη γεωμετρία του σχήματος· `Appearance` λαμβάνει υπόψη [οπτικά εφέ](/slides/el/nodejs-java/shape-effect/) (σκιές, λάμψεις κ.λπ.).

**Τι συμβαίνει αν ένα σχήμα επισημανθεί ως κρυφό; Θα εξακολουθήσει να αποδίδεται ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφής εμφάνισης επηρεάζει την παρουσίαση διαφάνειας αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται ομάδες σχημάτων, διαγράμματα, SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Οποιοδήποτε αντικείμενο που εκπροσωπείται ως [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/), και [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι εγκατεστημένες στο σύστημα γραμματοσειρές την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/nodejs-java/custom-font/) (ή να [ρυθμίσετε τις αντικαταστάσεις γραμματοσειρών](/slides/el/nodejs-java/font-substitution/)) για να αποφύγετε ανεπιθύμητες εναποθέσεις και την επαναδιάταξη του κειμένου.