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
- κατακόρυφη γραμμή διαχωρισμού
- μοναδική προβολή
- κατάσταση μπαρας
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides for Node.js via Java για προσαρμογή μορφών διαφανειών PPT, PPTX και ODP—ρυθμίστε σετ διατάξεων, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια ίδια, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να βρίσκεται στην ίδια κατάσταση με αυτή που είχε αποθηκευτεί τελευταία.

Η μέθοδος [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες κανονικής προβολής της παρουσίασης.

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewRestoredProperties) και τα απογόνους τους, καθώς και η απαρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType) προστέθηκαν.

## **Σχετικά με NormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν αν η εφαρμογή θα πρέπει να εμφανίζει εικονίδια όταν προβάλλει περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν αν η κάθετη γραμμή διαχωρισμού θα «κολλάει» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) και η μέθοδος [setPreferSingleView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) καθορίζουν αν ο χρήστης προτιμά να βλέπει μια πλήρη περιοχή περιεχομένου σε ολόκληρο το παράθυρο αντί της τυπικής κανονικής προβολής με τρεις περιοχές. Εάν είναι ενεργοποιημένο, η εφαρμογή μπορεί να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η κάθετη ή οριζόντια γραμμή διαχωρισμού. Μια οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κάθετη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) καθορίζουν το μέγεθος της επάνω ή πλευρικής περιοχής της διαφάνειας στην κανονική προβολή, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Restored) εφαρμόζεται στις μεθόδους [getVerticalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την Επαναφορά NormalViewProperties**

Καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) στην κανονική προβολή, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένο ούτε μεγιστοποιημένο).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου θα προσαρμόζεται αυτόματα στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή στην εφαρμογή.

Παρακάτω παρουσιάζεται ένα παράδειγμα που δείχνει πώς να προσπελάσετε τις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) για μια παρουσίαση.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Επαναφορά των ιδιοτήτων προβολής της παρουσίασης
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ορισμός Προεπιλεγμένου Ζουμ**

{{% alert color="info" %}} 

Το Aspose.Slides for Node.js via Java υποστηρίζει πλέον τον ορισμό του προκαθορισμένου ζουμ για την παρουσίαση, έτσι ώστε όταν η παρουσίαση ανοίξει, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties) μιας παρουσίασης. Οι μέθοδοι [getSlideViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και [getNotesViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) στο Aspose.Slides.

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
2. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
3. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ τόσο για την προβολή διαφάνειας όσο και για την προβολή σημειώσεων.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Ρύθμιση των ιδιοτήτων προβολής της παρουσίασης
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός του Μεσοδιαστήματος Πλέγματος**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getViewProperties--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής σε επίπεδο παρουσίασης. Οι μέθοδοι [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) και [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παρουσίαση, όχι σε μεμονωμένη διαφάνεια. Το μεσοδιάστημα πλέγματος καθορίζεται σε σημεία, όπου 72 σημεία ισοδυναμούν με ένα ίντσα. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει το τρέχον μεσοδιάστημα πλέγματος, ορίζει ένα διάστημα ενός τέταρτου ιντσών και αποθηκεύει το αποτέλεσμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το πλέγμα είναι διαφορετικό από τις [drawing guides](/slides/el/nodejs-java/drawing-guides/). Το μεσοδιάστημα πλέγματος ελέγχει ένα κανονικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι μεμονωμένες οριζόντιες ή κάθετες γραμμές ευθυγράμμισης. Η προσθήκη, μετακίνηση ή διαγραφή των οδηγών σχεδίασης δεν αλλάζει το μεσοδιάστημα πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποτυπώνονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση του μεσοδιαστήματος πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του θεατή ή του επεξεργαστή.

## **Συχνές ερωτήσεις**

**Γιατί το πλέγμα δεν είναι ορατό όταν ανοίγω ξανά την παρουσίαση;**

Το αρχείο αποθηκεύει το μεσοδιάστημα πλέγματος, αλλά ο επεξεργαστής ελέγχει αν θα εμφανιστεί το πλέγμα. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει το μεσοδιάστημα πλέγματος όταν διαγραφούν οι οδηγίες σχεδίασης;**

Όχι. Οι οδηγίες σχεδίασης και το μεσοδιάστημα πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η διαγραφή των οδηγών δεν τροποποιεί το αποθηκευμένο διάστημα πλέγματος.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι ρυθμίσεις προβολής ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), όχι ανά ενότητα, οπότε ένα σύνολο παραμέτρων ισχύει για ολόκληρο το έγγραφο κατά το άνοιγμά του.

**Μπορώ να προορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορεί να λαμβάνουν υπόψη τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα μόνο σύνολο ιδιοτήτων προβολής.

**Μπορώ να ετοιμάσω ένα πρότυπο με προορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [view properties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getviewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.