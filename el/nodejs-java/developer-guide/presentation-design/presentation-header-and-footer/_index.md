---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης σε JavaScript
linktitle: Κεφαλίδα & Υποσέλιδο
type: docs
weight: 140
url: /el/nodejs-java/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορισμός κεφαλίδας
- ορισμός υποσέλιδου
- φυλλάδι
- σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Χρησιμοποιήστε τη JavaScript και το Aspose.Slides για Node.js για να προσθέσετε και να προσαρμόσετε κεφαλίδες και υποσέλιδα σε παρουσιάσεις PowerPoint και OpenDocument, προσφέροντας επαγγελματική εμφάνιση."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε τις ρυθμίσεις κεφαλίδας και υποσέλιδου σε παρουσιάσεις PowerPoint. Οι κεφαλίδες και τα υποσέλιδα διαχειρίζονται στο επίπεδο του κύριου προτύπου παρουσίασης, και το API παρέχει μεθόδους για ορισμό κειμένου υποσέλιδου, αλλαγή της ορατότητας του υποσέλιδου και ενημέρωση κειμένου κεφαλίδας σε κύριες διαφάνειες σημειώσεων.

Μπορείτε επίσης να διαχειριστείτε τις κεφαλίδες και τα υποσέλιδα για τις διαφάνειες φυλλάδων και σημειώσεων. Αυτό περιλαμβάνει την αλλαγή της ορατότητας και του κειμένου των θέσεων κράτησης κεφαλίδας, υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας/ώρας για το κύριο σημειώσεων, όλες τις θυγατρικές διαφάνειες σημειώσεων ή μια μεμονωμένη διαφάνεια σημειώσεων.

## **Διαχείριση Κεφαλίδας και Υποσέλιδου στην Παρουσίαση**

Οι σημειώσεις κάποιων συγκεκριμένων διαφανειών ενδέχεται να αφαιρεθούν, όπως φαίνεται στο παρακάτω παράδειγμα:

```javascript
// Φόρτωση Παρουσίασης
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Ορισμός Υποσέλιδου
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Πρόσβαση και Ενημέρωση Κεφαλίδας
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Αποθήκευση παρουσίασης
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Διαχείριση Κεφαλίδας και Υποσέλιδου στις Φυλλάδια και Διαφάνειες Σημειώσεων**
Aspose.Slides for Node.js via Java υποστηρίζει Header και Footer σε φυλλάδια και διαφάνειες σημειώσεων. Ακολουθήστε τα παρακάτω βήματα:

- Φορτώστε μια [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) που περιέχει βίντεο.
- Αλλάξτε τις ρυθμίσεις Header και Footer για το master notes και όλες τις διαφάνειες σημειώσεων.
- Ορίστε το master notes slide και όλες τις θυγατρικές θέσεις κράτησης Footer ορατές.
- Ορίστε το master notes slide και όλες τις θυγατρικές θέσεις κράτησης Date και time ορατές.
- Αλλάξτε τις ρυθμίσεις Header και Footer μόνο για την πρώτη διαφάνεια σημειώσεων.
- Ορίστε τη θέση κράτησης Header της διαφάνειας σημειώσεων ορατή.
- Ορίστε κείμενο στη θέση κράτησης Header της διαφάνειας σημειώσεων.
- Ορίστε κείμενο στη θέση κράτησης Date-time της διαφάνειας σημειώσεων.
- Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Το απόσπασμα κώδικα παρέχεται στο παρακάτω Παράδειγμα.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Αλλαγή ρυθμίσεων κεφαλίδας και υποσέλιδου για το κύριο σημειώσεων και όλες τις διαφάνειες σημειώσεων
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// κάντε ορατή τη διαφάνεια κύριου σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Υποσέλιδου
        headerFooterManager.setFooterAndChildFootersVisibility(true);// κάντε ορατή τη διαφάνεια κύριου σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Κεφαλίδας
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// κάντε ορατή τη διαφάνεια κύριου σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Αριθμού διαφάνειας
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// κάντε ορατή τη διαφάνεια κύριου σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Ημερομηνίας και ώρας
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// ορίστε κείμενο στη διαφάνεια κύριου σημειώσεων και όλες τις θυγατρικές θέσεις κράτησης Κεφαλίδας
        headerFooterManager.setFooterAndChildFootersText("Footer text");// ορίστε κείμενο στη διαφάνεια κύριου σημειώνων και όλες τις θυγατρικές θέσεις κράτησης Υποσέλιδου
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// ορίστε κείμενο στη διαφάνεια κύριου σημειώνων και όλες τις θυγατρικές θέσεις κράτησης Ημερομηνίας και ώρας
    }
    // Αλλαγή ρυθμίσεων κεφαλίδας και υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// κάντε αυτή τη θέση κράτησης Κεφαλίδας της διαφάνειας σημειώσεων ορατή
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// κάντε αυτή τη θέση κράτησης Υποσέλιδου της διαφάνειας σημειώσεων ορατή
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// κάντε αυτή τη θέση κράτησης Αριθμού διαφάνειας της διαφάνειας σημειώσεων ορατή
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// κάντε αυτή τη θέση κράτησης Ημερομηνίας-ώρας της διαφάνειας σημειώσεων ορατή
        headerFooterManager.setHeaderText("New header text");// ορίστε κείμενο στη θέση κράτησης Κεφαλίδας της διαφάνειας σημειώσεων
        headerFooterManager.setFooterText("New footer text");// ορίστε κείμενο στη θέση κράτησης Υποσέλιδου της διαφάνειας σημειώσεων
        headerFooterManager.setDateTimeText("New date and time text");// ορίστε κείμενο στη θέση κράτησης Ημερομηνίας-ώρας της διαφάνειας σημειώσεων
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να προσθέσω "header" σε κανονικές διαφάνειες;**

Στο PowerPoint, η "Header" υπάρχει μόνο για σημειώσεις και φυλλάδια· σε κανονικές διαφάνειες τα υποστηριζόμενα στοιχεία είναι το υποσέλιδο, η ημερομηνία/ώρα και ο αριθμός διαφάνειας. Στο Aspose.Slides αυτό αντανακλά τις ίδιες περιορισμούς: header μόνο για Notes/Handout, και στις διαφάνειες—Footer/DateTime/SlideNumber.

**Τι γίνεται αν η διάταξη δεν περιέχει περιοχή υποσέλιδου—μπορώ να "turn on" την ορατότητά της;**

Ναι. Ελέγξτε την ορατότητα μέσω του διαχειριστή κεφαλίδας/υποσέλιδου και ενεργοποιήστε την αν χρειάζεται. Αυτοί οι δείκτες και οι μέθοδοι του API έχουν σχεδιαστεί για περιπτώσεις όπου η θέση κράτησης λείπει ή είναι κρυφή.

**Πώς μπορώ να κάνω τον αριθμό διαφάνειας να αρχίζει από τιμή διαφορετική από 1;**

Ορίστε τον [first slide number](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/setfirstslidenumber/); μετά από αυτό, όλα τα νούμερα επαναϋπολογίζονται. Για παράδειγμα, μπορείτε να ξεκινήσετε από 0 ή 10 και να κρύψετε τον αριθμό στη διαφάνεια τίτλου.

**Τι συμβαίνει με τις κεφαλίδες/υποσέλιδα όταν εξάγετε σε PDF/εικόνες/HTML;**

Αυτά αποδίδονται ως τακτικά κείμενα της παρουσίασης. Δηλαδή, αν τα στοιχεία είναι ορατά στις διαφάνειες/σελίδες σημειώσεων, θα εμφανιστούν επίσης και στην εξαγόμενη μορφή μαζί με το υπόλοιπο περιεχόμενο.