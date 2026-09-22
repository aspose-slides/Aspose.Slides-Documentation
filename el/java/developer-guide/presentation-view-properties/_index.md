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
- συγκράτηση κάθετου διαχωριστή
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
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για Java για να προσαρμόσετε μορφές διαφανειών PPT, PPTX και ODP — ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη δική της διαφάνεια, μια πλευρική περιοχή περιεχομένου και μια κατώτερη περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφόρων περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής της στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να βρίσκεται στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής μιας παρουσίασης.

Τα διεπαφές [INormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties) καθώς και οι απογόνους τους, το enum [SplitterBarStateType](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType) προστέθηκαν.

## **Σχετικά με INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζεται το περίγραμμα του περιεχομένου σε οποιαδήποτε από τις περιοχές περιεχομένου της κανονικής λειτουργίας προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν εάν ο κάθετος διαχωριστής θα «σφίξει» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι επαρκώς μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) καθορίζουν εάν ο χρήστης προτιμά να δει μια περιοχή περιεχομένου πλήρους παραθύρου αντί της τυπικής κανονικής προβολής με τρεις περιοχές περιεχομένου. Εάν είναι ενεργοποιημένη, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε ολόκληρο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωρισμού. Μια οριζόντια γραμμή διαχωρισμού διαχωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, η κάθετη γραμμή διαχωρισμού διαχωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Οι πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) καθορίζουν το μέγεθος της επάνω ή πλευρικής περιοχής διαφάνειας στην κανονική προβολή, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Restored) εφαρμόζεται στις [getVerticalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) στην κανονική προβολή, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένο ούτε μεγιστοποιημένο).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμοστεί στο νέο μέγεθος κατά την αλλαγή διαστάσεων του παραθύρου που περιέχει την προβολή στην εφαρμογή.

Στο παρακάτω παράδειγμα φαίνεται πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) για μια παρουσίαση.

```java
import com.aspose.slides.*;

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

## **Ορισμός της Προεπιλεγμένης Τιμής Ζουμ**

{{% alert color="info" %}} 

Το Aspose.Slides για Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, ώστε όταν η παρουσίαση ανοίγει, το ζουμ είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) μιας παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και τα [getNotesViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) του [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) στο Aspose.Slides.

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) του [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Γράψτε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).
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

## **Ορισμός Διαστήματος Πλέγματος**

Χρησιμοποιήστε τη μέθοδο [Presentation.getViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής σε ολόκληρη την παρουσίαση. Οι μέθοδοι [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/el/java/com.aspose.slides/iviewproperties/#getGridSpacing--) και [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/el/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση ισχύει για ολόκληρη την παρουσίαση, όχι για μεμονωμένη διαφάνεια. Το διάστημα πλέγματος καθορίζεται σε σημεία, όπου 72 σημεία ισοδυναμούν με ένα ίντσα. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εμφανίζει το τρέχον διάστημα πλέγματος, ορίζει ένα διάστημα τέταρτου ίντσας και αποθηκεύει το αποτέλεσμα.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το πλέγμα διαφέρει από τις [οδηγίες σχεδίασης](/slides/el/java/drawing-guides/). Το διάστημα πλέγματος ελέγχει ένα τακτικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι ξεχωριστές κατακόρυφες ή οριζόντιες γραμμές ευθυγράμμισης. Η προσθήκη, μετακίνηση ή εκκαθάριση οδηγών σχεδίασης δεν αλλάζει το διάστημα πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθητικά εργαλεία επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση του διαστήματος πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του θεατή ή του επεξεργαστή.

## **FAQ**

**Γιατί το πλέγμα δεν είναι ορατό αφού ανοίξω ξανά την παρουσίαση;**

Το αρχείο αποθηκεύει το διάστημα πλέγματος, αλλά ο επεξεργαστής ελέγχει αν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η εκκαθάριση των οδηγών σχεδίασης το διάστημα πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και το διάστημα πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η εκκαθάριση των οδηγών αφήνει το αποθηκευμένο διάστημα πλέγματος αμετάβλητο.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να προ-ορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορεί να λαμβάνουν υπόψη τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω πρότυπο με προ-ορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.