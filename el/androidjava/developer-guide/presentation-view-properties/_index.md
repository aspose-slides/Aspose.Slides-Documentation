---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης στο Android
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/androidjava/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- συγκράτηση κατακόρυφου διαχωριστικού
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
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για Android μέσω Java για να προσαρμόσετε τις μορφές PPT, PPTX και ODP διαφάνειες — ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια την ίδια, μια πλευρική περιοχή περιεχομένου και μια κατώτερη περιοχή περιεχομένου. Ιδιότητες που αφορούν την τοποθέτηση των διαφόρων περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να βρίσκεται στην ίδια κατάσταση με αυτήν που αποθηκεύτηκε τελευταία.

Η μέθοδος [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης.

Τα interfaces [INormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties) και οι απογόνους τους, καθώς και η enum [SplitterBarStateType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType) προστέθηκαν.

## **Σχετικά με INormalViewProperties**

Αναπαριστά τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν εάν η εφαρμογή θα πρέπει να εμφανίζει εικονίδια όταν εμφανίζει περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν εάν το κάθετο διαχωριστικό πρέπει να «κρεμαστεί» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι επαρκώς μικρή.

Οι ιδιότητες [getPreferSingleView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) καθορίζουν αν ο χρήστης προτιμά να βλέπει μια μοναδική περιοχή περιεχομένου σε πλήρες παράθυρο αντί της τυπικής κανονικής προβολής με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση στην οποία θα πρέπει να εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωρισμού. Μία οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κάθετη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) καθορίζουν τις διαστάσεις της επάνω ή πλαϊνής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Restored) εφαρμόζεται στα [getVerticalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την Επαναφορά των INormalViewProperties**

Καθορίζει τις διαστάσεις της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρικό του [getRestoredTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), ύψος όταν είναι θυγατρικό του [getRestoredLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του restoredTop, ύψος όταν είναι θυγατρική του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμόζεται στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή στην εφαρμογή.

Παρακάτω δίνεται ένα παράδειγμα που δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) για μια παρουσίαση.

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

Το Aspose.Slides για Android μέσω Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, ώστε όταν η παρουσίαση ανοίγει, το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) μιας παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και τα [getNotesViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσετε τις [View Properties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) στο Aspose.Slides.

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, παρακαλώ ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/). Στο παρακάτω παράδειγμα, έχουμε ορίσει την τιμή ζουμ τόσο για την προβολή διαφάνειας όσο και για την προβολή σημειώσεων.

```java
import com.aspose.slides.*;

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
## **Ορισμός του Διαστήματος Πλέγματος**

Χρησιμοποιήστε τη μέθοδο [Presentation.getViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής σε επίπεδο παρουσίασης. Οι μέθοδοι [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) και [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση εφαρμόζεται σε ολόκληρη την παρουσίαση, όχι σε μεμονωμένη διαφάνεια. Το διάστημα του πλέγματος ορίζεται σε σημεία (points), όπου 72 σημεία ισοδυναμούν με ένα ίντσο. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει το τρέχον διάστημα πλέγματος, θέτει ένα διάστημα ενός τέταρτου ίντσου και αποθηκεύει το αποτέλεσμα.

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

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/androidjava/drawing-guides/). Το διάστημα πλέγματος ελέγχει ένα τακτικό διάστημα, ενώ οι οδηγίες σχεδίασης (drawing guides) είναι επιμέρους οριζόντιες ή κάθετες γραμμές στοίχησης που τοποθετούνται ξεχωριστά. Η προσθήκη, η μετακίνηση ή η κατάργηση των οδηγίων σχεδίασης δεν αλλάζει το διάστημα του πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση του διαστήματος πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις ρυθμίσεις του προβολέα ή του επεξεργαστή.

## **FAQ**

**Γιατί το πλέγμα δεν είναι ορατό μετά την επαναλειτουργία της παρουσίασης;**

Το αρχείο αποθηκεύει το διάστημα του πλέγματος, αλλά ο επεξεργαστής ελέγχει εάν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει το διάστημα του πλέγματος η εκκαθάριση των οδηγίων σχεδίασης;**

Όχι. Οι οδηγίες σχεδίασης και το διάστημα του πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η εκκαθάριση των οδηγών αφήνει το αποθηκευμένο διάστημα πλέγματος αμετάβλητο.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων ισχύει για ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να προκαθορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι εφαρμογές προβολής μπορεί να τηρήσουν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα μόνο σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προκαθορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.