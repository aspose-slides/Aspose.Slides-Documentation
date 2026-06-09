---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε JavaScript
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/nodejs-java/presentation-view-properties/
keywords: 
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περίγραμμα
- εικονίδια περιγράμματος
- επικόλληση κάθετου διαχωριστή
- μονή προβολή
- κατάσταση μπάρας
- μέγεθος διάστασης
- αυτόματη ρύθμιση
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Node.js μέσω ιδιοτήτων προβολής Java για να προσαρμόσετε μορφές διαφανειών PPT, PPTX και ODP — ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις προβολής."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: την ίδια τη διαφάνεια, μια πλαϊνή περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής της στο αρχείο, ώστε όταν ανοίγει ξανά η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης.  

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewRestoredProperties) και οι απογόνους τους, καθώς και η απαρτίδα [SplitterBarStateType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType) προστέθηκαν.

## **Σχετικά με το NormalViewProperties**

Αναπαριστά τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει το περιεχόμενο περίγραμμα σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν εάν ο κάθετος διαχωριστής πρέπει να κλειδώνει σε μειωμένη κατάσταση όταν η πλαϊνή περιοχή είναι επαρκώς μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) καθορίζει εάν ο χρήστης προτιμά να δει μια περιοχή περιεχομένου πλήρους παραθύρου αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν είναι ενεργοποιημένη, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση στην οποία πρέπει να εμφανίζεται η οριζόντια ή κάθετη μπάρα διαχωρισμού. Μία οριζόντια μπάρα διαχωρισμού διαχωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, η κάθετη μπάρα διαχωρισμού διαχωρίζει τη διαφάνεια από την πλαϊνή περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) καθορίζουν το μέγεθος της άνω ή πλαϊνής περιοχής της διαφάνειας στην κανονική προβολή, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Restored) εφαρμόζεται στις [getVerticalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--).

## **Σχετικά με την Επαναφορά NormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) στην κανονική προβολή, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε μειωμένο ούτε μεγιστοποιημένο).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) καθορίζει εάν το μέγεθος της πλαϊνής περιοχής περιεχομένου πρέπει να προσαρμόζεται στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή μέσα στην εφαρμογή.

Παρατίθεται ένα παράδειγμα παρακάτω που δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) για μια παρουσίαση.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Επαναφορά ιδιοτήτων προβολής της παρουσίασης
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Τιμής Ζουμ**

{{% alert color="primary" %}} 

Το Aspose.Slides για Node.js μέσω Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για παρουσιάσεις, ώστε όταν ανοίγει η παρουσίαση, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας το [ViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties) μιας παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και τα [getNotesViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τα [View Properties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties) του [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) στο [Aspose.Slides](/slides/el/).

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Ορίστε τα [View Properties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties) του [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Στο παρακάτω παράδειγμα, έχουμε ορίσει την τιμή ζουμ για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι ρυθμίσεις προβολής ορίζονται σε επίπεδο παρουσίασης (Κανονική Προβολή/Προβολή Διαφάνειας), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να προ-ορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι εφαρμογές προβολής μπορεί να τηρούν τις προτιμήσεις του χρήστη, αλλά το ίδιο το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προ-ορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι ιδιότητες προβολής αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.