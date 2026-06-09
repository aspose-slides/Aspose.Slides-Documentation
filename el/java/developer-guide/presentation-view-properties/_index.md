---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε Java
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/java/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- συγκράτηση κάθετης γραμμής διαχωρισμού
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για Java για την προσαρμογή μορφών διαφανειών PPT, PPTX και ODP — ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή, μια πλευρική περιοχή περιεχομένου και μια περιοχή περιεχομένου στο κάτω μέρος. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση της προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση με την τελευταία αποθήκευση της παρουσίασης.

Η μέθοδος [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες κανονικής προβολής της παρουσίασης. 

Τα interfaces [INormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties) και οι απογόνους τους, καθώς και το enum [SplitterBarStateType](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType) προστέθηκαν.

## **Σχετικά με το INormalViewProperties**

Αναπαριστά τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει το περιεχόμενο του περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ορίζουν εάν η κάθετη γραμμή διαχωρισμού θα «κόβει» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Οι ιδιότητες [getPreferSingleView](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) καθορίζουν εάν ο χρήστης προτιμά να δει μια μοναδική περιοχή περιεχομένου σε πλήρες παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν είναι ενεργοποιημένο, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε ολόκληρο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) προσδιορίζουν την κατάσταση στην οποία θα εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωρισμού. Μία οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ μια κάθετη γραμμή χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) καθορίζουν το μέγεθος της επάνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Restored) έχει εφαρμοστεί στις [getVerticalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την Επαναφορά του INormalViewProperties** 

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη). 

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμόζεται στο νέο μέγεθος όταν αλλάζει το μέγεθος του παραθύρου που περιέχει την προβολή μέσα στην εφαρμογή.

Ένα παράδειγμα παρατίθεται παρακάτω και δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) μιας παρουσίασης.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Επαναφορά των ιδιοτήτων προβολής της παρουσίασης
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ορισμός της Προεπιλεγμένης Τιμής Ζουμ**

{{% alert color="primary" %}} 

Το Aspose.Slides for Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, έτσι ώστε όταν η παρουσίαση ανοίξει, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας το [ViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) μιας παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και [getNotesViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) στο [Aspose.Slides](/slides/el/).

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
2. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
3. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Στο παρακάτω παράδειγμα, έχουμε ορίσει την τιμή ζουμ για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```java
Presentation presentation = new Presentation();
try {
    // Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή διαφάνειας
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για προβολή σημειώσεων 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [Ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) ορίζονται σε επίπεδο παρουσίασης ([Κανονική Προβολή](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Προβολή Διαφάνειας](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να ορίσω εκ των προτέρων διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι εφαρμογές προβολής μπορούν να λαμβάνουν υπόψη τις προτιμήσεις του χρήστη, αλλά το ίδιο το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προρυθμισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [Ιδιότητες προβολής](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.