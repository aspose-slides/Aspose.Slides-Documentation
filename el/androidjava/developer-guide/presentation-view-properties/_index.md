---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε Android
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/androidjava/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περίγραμμα
- εικονίδια περιγράμματος
- προσκόλληση κάθετου διαχωριστικού
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για Android μέσω Java για να προσαρμόσετε τις μορφές PPT, PPTX και ODP διαφάνειες - να ρυθμίσετε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθαυτή, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν την τοποθέτηση των διαφόρων περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής της στο αρχείο, ώστε όταν ανοίγει ξανά η προβολή να βρίσκεται στην ίδια κατάσταση όπως κατά την τελευταία αποθήκευση της παρουσίασης.

Η μέθοδος [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης.

[INormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties) διεπαφές και τα απογόνους τους, [SplitterBarStateType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType) κλήση προστέθηκαν.

## **Σχετικά με INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν εάν ο κατακόρυφος διαχωριστής πρέπει να «κρεμαστεί» σε μειωμένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) καθορίζουν εάν ο χρήστης προτιμά να δει μια περιοχή περιεχομένου μονής οθόνης σε πλήρη παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση στην οποία πρέπει να εμφανίζεται η οριζόντια ή κατακόρυφη γραμμή διαχωριστικού. Μια οριζόντια γραμμή διαχωριστικού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κατακόρυφη γραμμή διαχωριστικού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) καθορίζουν το μέγεθος της επάνω ή πλευρικής περιοχής της διαφάνειας στην κανονική προβολή, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Restored) εφαρμόζεται στην [getVerticalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και στην [getHorizontalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την αποκατάσταση INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) στην κανονική προβολή, όταν η περιοχή έχει μεταβλητό αποκατεστημένο μέγεθος (ούτε μειωμένη ούτε μεγιστοποιημένη).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής της διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμόζεται στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή μέσα στην εφαρμογή.

Παρακάτω δίεται ένα παράδειγμα που δείχνει πώς μπορείτε να προσπελάσετε τις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) για μια παρουσίαση.

```java
import com.aspose.slides.*;

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
## **Ορισμός Προεπιλεγμένης Τιμής Ζουμ**

{{% alert color="info" %}} 

Η Aspose.Slides για Android μέσω Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, ώστε όταν η παρουσίαση ανοίξει, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) μιας παρουσίασης. Οι [getSlideViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και οι [getNotesViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) στην [Aspose.Slides](/slides/el/).

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).
   Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για την προβολή διαφάνειας
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για την προβολή σημειώσεων 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

### Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;

Οι [View settings](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε όλο το έγγραφο όταν ανοίγει.

### Μπορώ να προκαθορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι εφαρμογές προβολής μπορεί να τηρούν τις προτιμήσεις του χρήστη, αλλά το ίδιο το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

### Μπορώ να προετοιμάσω ένα πρότυπο με προ-ορισμένες ιδιότητες προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;

Ναι. Επειδή οι [view properties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.