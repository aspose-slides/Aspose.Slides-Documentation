---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε JavaScript
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/nodejs-java/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- συγκράτηση κάθετου διαχωριστή
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για Node.js μέσω Java για να διαμορφώσετε τη διάταξη της κανονικής προβολής, το ζουμ της διαφάνειας και των σημειώσεων, την απόσταση πλέγματος και την ορατότητα σχολίων σε παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Στην κανονική προβολή του PowerPoint, η διαφάνεια εμφανίζεται μεταξύ ενός πλευρικού πλαισίου για μικρογραφίες ή περίγραμμα και ενός πλαισίου σημειώσεων από κάτω. Το Aspose.Slides για Node.js μέσω Java εκθέτει τις αποθηκευμένες προτιμήσεις επεξεργασίας της παρουσίασης μέσω του [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Αυτά περιλαμβάνουν τη διάταξη των πλαισίων, τα επίπεδα ζουμ, την απόσταση πλέγματος και την ορατότητα σχολίων.

## **Σχετικά με NormalViewProperties**

Χρησιμοποιήστε το [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) για πρόσβαση στην κλάση [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). Η μέθοδος [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) ελέγχει αν τα εικονίδια εμφανίζονται δίπλα στους τίτλους διαφανειών στο περίγραμμα. Η [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) επιτρέπει στο πλευρικό πάνελ να «κουμπώνει» στην ελαχιστοποιημένη του κατάσταση όταν ο χρήστης το μειώνει. Η [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) δηλώνει προτίμηση για εμφάνιση ενός μόνο πάνελ σε πλήρη παράθυρο.

Η [setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) ελέγχει το χωρίο μεταξύ του πλευρικού πάνελ και της διαφάνειας. Η [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) ελέγχει το χωρίο πάνω από το πάνελ σημειώσεων. Και οι δύο δέχονται μια τιμή τύπου [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) του `Minimized`, `Maximized` ή `Restored`.

## **Σχετικό με την Επαναφορά NormalViewProperties**

Όταν ένα χωρίο επανέρχεται στην αρχική του θέση, το [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) παρέχει το αποθηκευμένο μέγεθος του πλευρικού πάνελ και το [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) παρέχει το αποθηκευμένο μέγεθος της άνω περιοχής της διαφάνειας. Και οι δύο εκθέτουν το [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Η μέθοδος [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) δέχεται ένα ποσοστό από 0 έως 100, ενώ η [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) ελέγχει αν ο επεξεργαστής προσαρμόζει το μέγεθος όταν το παράθυρο αλλάζει μέγεθος.

Αυτό το παράδειγμα ενημερώνει μια υπάρχουσα παρουσίαση. Επαναφέρει το οριζόντιο χωρίο, ορίζει το μέγεθος που επιστρέφει το [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) στο 80% με ενεργή αυτόματη προσαρμογή, και μεγιστοποιεί το κατακόρυφο χωρίο. Επίσης καλεί τη [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) για εμφάνιση εικονιδίων στην προβολή περίγραμμα.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Τιμής Zoom**

Οι [getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) και [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) αποθηκεύουν ανεξάρτητες ρυθμίσεις ζουμ για τον επεξεργαστή. Αυτές οι ρυθμίσεις δεν επηρεάζουν τις διαστάσεις της διαφάνειας, την αναπαραγωγή της παρουσίασης ή την ανάλυση εξαγωγής εικόνας.

Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί τη [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) για να προσαρμόσει τη διαφάνεια στο παράθυρο επεξεργασίας. Για τη σελίδα σημειώσεων, απενεργοποιεί την αυτόματη κλίμακα και καλεί τη [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) για να ορίσει σταθερό ζουμ 80%.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Απόστασης Πλέγματος**

Η [setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) ορίζει την απόσταση μεταξύ των γραμμών του πλέγματος επεξεργασίας σε όλη την παρουσίαση. Δέχεται μια θετική τιμή σε σημεία (points), με 72 σημεία ανά ίντσα. Αυτό το παράδειγμα εκτυπώνει την τρέχουσα απόσταση σε μια υπάρχουσα παρουσίαση και αποθηκεύει ένα πλέγμα τεταρτοξενού (quarter‑inch) ορίζοντας το διάστημα στα 18 σημεία.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το πλέγμα επαναλαμβάνεται σε σταθερό διάστημα. Οι [Οδηγοί σχεδίασης](/slides/el/nodejs-java/drawing-guides/) σημειώνουν μεμονωμένες οριζόντιες ή κατακόρυφες θέσεις. Και τα δύο είναι βοηθήματα επεξεργασίας και εμφανίζονται μόνο σε επεξεργαστές που τα εμφανίζουν. Οι παρουσιάσεις και οι εξαγωγές σε PDF, εικόνες ή SVG τα παραβλέπουν.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Η [setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) αποθηκεύει μια προτίμηση που χρησιμοποιούν οι συμβατοί επεξεργαστές κατά το άνοιγμα της παρουσίασης. Για μια υπάρχουσα παρουσίαση με σχόλια, αυτό το παράδειγμα εκτυπώνει τη τρέχουσα ρύθμιση και αποθηκεύει ένα αντίγραφο με τα σχόλια κρυμμένα. Επίσης καλεί τη [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) με το [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) ώστε το αντίγραφο ανοίξει στην προβολή διαφάνειας.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η απόκρυψη σχολίων διατηρεί το κείμενο, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις τους. Για να αλλάξετε τα ίδια τα σχόλια, δείτε τα [Σχόλια Παρουσίασης](/slides/el/nodejs-java/presentation-comments/). Οι ρυθμίσεις εξαγωγής ελέγχουν αν τα σχόλια εμφανίζονται σε PDF, HTML, εικόνες, σημειώσεις ή φυλλάδια.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Γιατί το πλέγμα είναι κρυφό όταν ανοίγω ξανά την παρουσίαση;**

Η παρουσίαση αποθηκεύει το διάστημα του πλέγματος. Για να δείτε το πλέγμα, ενεργοποιήστε την ορατότητα του πλέγματος στον επεξεργαστή.

**Αλλάζει η αφαίρεση των οδηγών σχεδίασης την απόσταση του πλέγματος;**

Όχι. Η προσθήκη, η μετακίνηση ή η διαγραφή ενός οδηγού αφήνει το διάστημα του πλέγματος αμετάβλητο.

**Μπορούν διαφορετικές ενότητες μιας παρουσίασης να έχουν διαφορετικές ρυθμίσεις προβολής;**

Όχι. Η [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) ισχύει για ολόκληρη την παρουσίαση.

**Μπορώ να αποθηκεύσω διαφορετικές ρυθμίσεις προβολής για διαφορετικούς χρήστες;**

Το αρχείο αποθηκεύει ένα σύνολο ιδιοτήτων προβολής για όλους. Ένας επεξεργαστής μπορεί επίσης να εφαρμόσει τις τοπικές προτιμήσεις ενός χρήστη.

**Μπορώ να αποθηκεύσω ρυθμίσεις προβολής σε ένα πρότυπο;**

Ναι. Οι παρουσιάσεις που δημιουργούνται από το πρότυπο κληρονομούν τις αποθηκευμένες ρυθμίσεις προβολής του.