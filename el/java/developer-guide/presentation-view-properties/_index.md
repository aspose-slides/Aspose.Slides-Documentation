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
- συγκράτηση κάθετου διαχωριστικού
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
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides for Java για να προσαρμόσετε τις μορφές διαφανειών PPT, PPTX και ODP — να ρυθμίσετε διάταξη, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθ' αυτή, μια πλευρική περιοχή περιεχομένου και μια κατώτερη περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύσει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση με ό,τι είχε αποθηκευθεί τελευταία.

Η μέθοδος [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής μιας παρουσίασης.

Οι διεπαφές [INormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties) και οι απογόνους τους, καθώς και η απαριθμητική τιμή [SplitterBarStateType](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType) προστέθηκαν.

## **Σχετικά με INormalViewProperties**

Αναπαριστά τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν αν η εφαρμογή θα πρέπει να εμφανίζει εικονίδια όταν εμφανίζεται το περίγραμμα σε οποιαδήποτε περιοχή περιεχομένου της κανονικής λειτουργίας προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν αν η κάθετη γραμμή διαχωριστικού θα «κλειδώνει» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) καθορίζει αν ο χρήστης προτιμά να δει μια πλήρη περιοχή περιεχομένου σε όλο το παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η κατακόρυφη ή η οριζόντια γραμμή διαχωρισμού. Μια οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κάθετη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) καθορίζουν το μέγεθος της πάνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Restored) εφαρμόζεται στις μεθόδους [getVerticalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την Αποκατάσταση των INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του [getRestoredTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), ύψος όταν είναι θυγατρική του [getRestoredLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό αποκατεστημένο μέγεθος (ούτε ελαχιστοποιημένο ούτε μεγεθυμένο).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του αποκατεστημένου πάνω, ύψος όταν είναι θυγατρική του αποκατεστημένου αριστερά).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου θα προσαρμόζεται αυτόματα στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή στην εφαρμογή.

Παράδειγμα δίδεται παρακάτω για το πώς να αποκτήσετε πρόσβαση στις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) μιας παρουσίασης.

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

## **Ορισμός της Προεπιλεγμένης Τιμής Ζουμ**

{{% alert color="info" %}} 

Το Aspose.Slides for Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, ώστε όταν η παρουσίαση ανοίξει το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τα [ViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) της παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και τα [getNotesViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με παράδειγμα πώς να ορίσετε τις [View Properties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) στο [Aspose.Slides](/slides/el/).

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Ορίστε τα [View Properties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/). Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ τόσο για την προβολή διαφάνειας όσο και για την προβολή σημειώσεων.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Ρύθμιση των ιδιοτήτων προβολής της παρουσίασης
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για την προβολή διαφάνειας
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Τιμή ζουμ σε ποσοστά για την προβολή σημειώσεων 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

### Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;

Οι ρυθμίσεις προβολής ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), όχι ανά ενότητα, οπότε ένα σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο κατά το άνοιγμα.

### Μπορώ να ορίσω προκαθορισμένες καταστάσεις προβολής για διαφορετικούς χρήστες;

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινόχρηστες. Οι εφαρμογές προβολής μπορεί να σέβονται τις προτιμήσεις του χρήστη, αλλά το ίδιο το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

### Μπορώ να δημιουργήσω ένα πρότυπο με προ-ορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;

Ναι. Επειδή οι [view properties](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.