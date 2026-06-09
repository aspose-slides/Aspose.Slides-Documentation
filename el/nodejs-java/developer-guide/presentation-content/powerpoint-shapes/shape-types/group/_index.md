---
title: Ομαδικά Σχήματα Παρουσίασης σε JavaScript
linktitle: Ομάδα Σχημάτων
type: docs
weight: 40
url: /el/nodejs-java/group/
keywords:
- ομαδικό σχήμα
- ομάδα σχημάτων
- προσθήκη ομάδας
- εναλλακτικό κείμενο
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να ομαδοποιείτε και να αποομαδοποιείτε σχήματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java — γρήγορος, βήμα προς βήμα οδηγός με δωρεάν κώδικα JavaScript."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με ομάδες σχημάτων στο Aspose.Slides. Δείχνει πώς να προσθέσετε μια ομάδα σχήματος σε μια διαφάνεια, να τοποθετήσετε σχήματα μέσα σε αυτήν και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Επίσης, παρουσιάζει πώς να έχετε πρόσβαση σε σχήματα που αποθηκεύονται σε μια ομάδα και να διαβάσετε τις τιμές τους `AlternativeText`. Επιπλέον, το άρθρο καλύπτει εν συντομία σχετικές δυνατότητες ομάδων σχημάτων όπως ένθετες ομάδες, σειρά z και επιλογές κλειδώματος.

## **Προσθήκη Ομάδας Σχημάτων**
Το Aspose.Slides υποστηρίζει εργασία με ομάδες σχημάτων στις διαφάνειες. Αυτή η λειτουργία βοηθά τους προγραμματιστές να δημιουργούν πιο πλούσιες παρουσιάσεις. Το Aspose.Slides για Node.js μέσω Java υποστηρίζει την προσθήκη ή την πρόσβαση σε ομάδες σχημάτων. Είναι δυνατόν να προσθέσετε σχήματα σε μια προστιθέμενη ομάδα σχήματος για να τη γεμίσετε ή να αποκτήσετε πρόσβαση σε οποιαδήποτε ιδιότητα της ομάδας σχήματος. Για να προσθέσετε μια ομάδα σχήματος σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. Προσθέστε μια ομάδα σχήματος στη διαφάνεια.
1. Προσθέστε τα σχήματα στην προστιθέμενη ομάδα σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει μια ομάδα σχήματος σε μια διαφάνεια.

```javascript
// Δημιουργία αντικειμένου της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    // Πρόσβαση στη συλλογή σχημάτων των διαφανειών
    var slideShapes = sld.getShapes();
    // Προσθήκη ομάδας σχήματος στη διαφάνεια
    var groupShape = slideShapes.addGroupShape();
    // Προσθήκη σχημάτων μέσα στην προστεθείσα ομάδα σχήματος
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Προσθήκη πλαισίου ομάδας σχήματος
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Γράψιμο του αρχείου PPTX στο δίσκο
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Πρόσβαση στην Ιδιότητα AltText**
Αυτό το θέμα παρουσιάζει απλά βήματα, συνοδευόμενα από παραδείγματα κώδικα, για την προσθήκη μιας ομάδας σχήματος και την πρόσβαση στην ιδιότητα AltText των ομάδων σχημάτων στις διαφάνειες. Για να αποκτήσετε πρόσβαση στο AltText μιας ομάδας σχήματος σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που αντιπροσωπεύει το αρχείο PPTX.
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. Πρόσβαση στη συλλογή σχημάτων των διαφανειών.
1. Πρόσβαση στην ομάδα σχήματος.
1. Καλέστε την ιδιότητα [getAlternativeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getAlternativeText--).

Το παρακάτω παράδειγμα προσπελάζει το εναλλακτικό κείμενο της ομάδας σχήματος.

```javascript
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει το αρχείο PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Λήψη της πρώτης διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Πρόσβαση στη συλλογή σχημάτων των διαφανειών
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Πρόσβαση στην ομάδα σχήματος.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Πρόσβαση στην ιδιότητα AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η ένθετη ομαδοποίηση (μια ομάδα μέσα σε μια άλλη ομάδα);**

Ναι. Η [GroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/groupshape/) διαθέτει τη μέθοδο [getParentGroup](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getparentgroup/), η οποία υποδεικνύει άμεσα την υποστήριξη ιεραρχίας (μια ομάδα μπορεί να είναι παιδί άλλης ομάδας).

**Πώς μπορώ να ελέγξω τη σειρά z της ομάδας σε σχέση με άλλα αντικείμενα στη διαφάνεια;**

Χρησιμοποιήστε τη μέθοδο [getZOrderPosition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getzorderposition/) του [GroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/groupshape/) για να εξετάσετε τη θέση του στη στοίβα εμφάνισης.

**Μπορώ να αποτρέψω τη μετακίνηση/επεξεργασία/αποομαδοποίηση;**

Ναι. Η ενότητα κλειδώματος της ομάδας εκτίθεται μέσω του [GroupShapeLock](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), που σας επιτρέπει να περιορίσετε τις λειτουργίες στο αντικείμενο.