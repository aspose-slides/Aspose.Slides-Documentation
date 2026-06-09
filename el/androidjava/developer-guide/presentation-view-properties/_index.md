---
title: Ανάκτηση και ενημέρωση ιδιοτήτων προβολής παρουσίασης σε Android
linktitle: Ιδιότητες προβολής
type: docs
weight: 80
url: /el/androidjava/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- συγκράτηση κάθετου διαχωριστή
- μονή προβολή
- κατάσταση μπάρας
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένη μεγέθυνση
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Android μέσω Java ιδιότητες προβολής για να προσαρμόσετε τις μορφές διαφάνειας PPT, PPTX και ODP — να ρυθμίσετε τις διατάξεις, τα επίπεδα μεγέθυνσης και τις ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθ' αυτή, μια πλάνη πλάι και μια πλάνη στο κάτω μέρος. Ιδιότητες που αφορούν τη θέση των διαφόρων περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής στο αρχείο, έτσι ώστε όταν ανοίξει ξανά η προβολή να βρίσκεται στην ίδια κατάσταση με ό,τι όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής μιας παρουσίασης.  

[INormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties) διεπαφές και οι παράγωγες διεπαφές τους, [SplitterBarStateType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType) enum προστέθηκαν.

## **Σχετικά με INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν αν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν προβάλλεται το περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της κανονικής λειτουργίας προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν αν ο κάθετος διαχωριστής πρέπει να «κρεμαστεί» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι επαρκώς μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) καθορίζουν αν ο χρήστης προτιμά να βλέπει μία περιοχή περιεχομένου πλήρους παραθύρου αντί της τυπικής κανονικής προβολής με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να προβάλλει μία από τις περιοχές περιεχομένου σε ολόκληρο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση εμφάνισης της οριζόντιας ή κάθετης μπάρας διαχωρισμού. Η οριζόντια μπάρα διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κάθετη μπάρα διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) καθορίζουν το μέγεθος της επάνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Restored) έχει εφαρμοστεί στις [getVerticalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την αποκατάσταση INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του [getRestoredTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), ύψος όταν είναι θυγατρική του [getRestoredLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό αποκατεστημένο μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη).  

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του restoredTop, ύψος όταν είναι θυγατρική του restoredLeft).  

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμοστεί στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει τη προβολή εντός της εφαρμογής.  

Παρακάτω δίνεται ένα παράδειγμα που δείχνει πώς μπορείτε να προσπελάσετε τις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) για μια παρουσίαση.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Αποκατάσταση των ιδιοτήτων προβολής της παρουσίασης
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ορισμός της προεπιλεγμένης τιμής μεγέθυνσης**

{{% alert color="primary" %}} 

Το Aspose.Slides για Android μέσω Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής μεγέθυνσης για μια παρουσίαση, ώστε όταν ανοίξει η παρουσίαση η μεγέθυνση να είναι ήδη ρυθμισμένη. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) μιας παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και τα [getNotesViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να ορισθούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) στο [Aspose.Slides](/slides/el/).

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Στο παρακάτω παράδειγμα, ορίσαμε την τιμή μεγέθυνσης για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```java
Presentation presentation = new Presentation();
try {
    // Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Τιμή μεγέθυνσης σε ποσοστά για προβολή διαφάνειας
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Τιμή μεγέθυνσης σε ποσοστά για προβολή σημειώσεων 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), όχι ανά ενότητα, έτσι ένα σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο κατά το άνοιξή του.

**Μπορώ να προπροκαθορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινόχρηστες. Οι εφαρμογές προβολής μπορεί να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να προετοιμάσω ένα πρότυπο με προορισμένες ιδιότητες προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργείτε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.