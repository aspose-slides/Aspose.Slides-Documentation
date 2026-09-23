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
- συγκράτηση κάθετης γραμμής διαχωρισμού
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
description: "Ανακαλύψτε το Aspose.Slides για Android μέσω Java ιδιότητες προβολής για να προσαρμόσετε τα μορφότυπα διαφανειών PPT, PPTX και ODP — προσαρμόστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια ίδια, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφόρων περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύσει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να βρίσκεται στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής μιας παρουσίασης. 

Οι διεπαφές [INormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties) και οι απογόνους τους, καθώς και η απαρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType) έχουν προστεθεί.

## **Σχετικά με το INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει το περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της κανονικής λειτουργίας προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν εάν η κάθετη διαχωριστική γραμμή πρέπει να «κολλάει» σε μια ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι επαρκώς μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) καθορίζει εάν ο χρήστης προτιμά να βλέπει μια ενιαία περιοχή περιεχομένου σε πλήρη παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση στην οποία πρέπει να εμφανίζεται η κάθετη ή οριζόντια γραμμή διαχωρισμού. Μία οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, η κάθετη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) καθορίζουν τις διαστάσεις της άνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SplitterBarStateType#Restored) εφαρμόζεται στις [getVerticalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την Επαναφορά των INormalViewProperties**

Καθορίζει τις διαστάσεις της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη). 

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμόζεται αυτόματα στο νέο μέγεθος κατά την αλλαγή του μεγέθους του παραθύρου που περιέχει την προβολή μέσα στην εφαρμογή.

Ένα παράδειγμα που δίνεται παρακάτω δείχνει πώς μπορείτε να έχετε πρόσβαση στις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) μιας παρουσίασης.

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

## **Ορισμός της Προεπιλεγμένης Τιμής Μεγέθυνσης**

{{% alert color="info" %}} 

Aspose.Slides για Android μέσω Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής μεγέθυνσης για μια παρουσίαση, ώστε όταν ανοίγει η παρουσίαση, η μεγέθυνση να είναι ήδη ορισμένη. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) μιας παρουσίασης. Οι [getSlideViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και [getNotesViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) στο Aspose.Slides.

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, παρακαλούμε ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Γράψτε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).
   Στο παρακάτω παράδειγμα, έχουμε ορίσει την τιμή μεγέθυνσης για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

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

## **Ορισμός του Διαστήματος Πλέγματος**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) για να έχετε πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Οι μέθοδοι [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) και [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) διαβάζουν ή τροποποιούν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση ισχύει για ολόκληρη την παρουσίαση, όχι για μεμονωμένη διαφάνεια. Το διάστημα πλέγματος καθορίζεται σε σημεία, όπου 72 σημεία ισοδυναμούν με ένα ίντσα. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει το τρέχον διάστημα πλέγματος, ορίζει ένα διάστημα τέταρτου ιντσών και αποθηκεύει το αποτέλεσμα.

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

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/androidjava/drawing-guides/). Το διάστημα πλέγματος ελέγχει ένα κανονικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι μεμονωμένα τοποθετημένες οριζόντιες ή κάθετες γραμμές ευθυγράμμισης. Η προσθήκη, η μετακίνηση ή η διαγραφή οδηγών σχεδίασης δεν αλλάζει το διάστημα του πλέγματος.

Και το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση του διαστήματος πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του προβολέα ή επεξεργαστή.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) για να έχετε πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Χρησιμοποιήστε τα [IViewProperties.getShowComments](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) και [IViewProperties.setShowComments](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) για να διαβάσετε ή να τροποποιήσετε την αποθηκευμένη προτίμηση σχετικά με το αν τα σχόλια πρέπει να εμφανίζονται όταν η παρουσίαση ανοίγει στο PowerPoint ή σε άλλο συμβατό επεξεργαστή.

Αυτή η ρύθμιση ελέγχει μόνο την αποθηκευμένη προτίμηση προβολής. Δεν προσθέτει, αφαιρεί, επεξεργάζεται ή λύνει σχόλια. Η απόκρυψη σχολίων διατηρεί το περιεχόμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Δείτε τα [Presentation Comments](/slides/el/androidjava/presentation-comments/) για ενέργειες που αλλάζουν τα ίδια τα σχόλια.

Το παρακάτω παράδειγμα απαιτεί ένα υπάρχον `comments.pptx` που περιέχει σχόλια. Εκτυπώνει την τρέχουσα ρύθμιση ορατότητας, ζητά την απόκρυψη των σχολίων και αποθηκεύει ένα νέο PPTX χωρίς να αφαιρέσει κανένα σχόλιο. Χρησιμοποιεί επίσης το [IViewProperties.setLastView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) μαζί με το [ViewType.SlideView](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewtype/#SlideView) για να διαμορφώσει την αρχική προβολή επεξεργασίας μαζί με την ορατότητα των σχολίων.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτή η ρύθμιση δεν καθορίζει εάν τα σχόλια θα συμπεριληφθούν σε εξαγωγές PDF, HTML, εικόνας, σημειώσεων ή φυλλαδίων. Διαμορφώστε χωριστά τις σχετικές επιλογές εξαγωγής.

## **FAQ**

**Γιατί δεν είναι ορατό το πλέγμα μετά το άνοιγμα ξανά της παρουσίασης;**

Το αρχείο αποθηκεύει το διάστημα του πλέγματος, αλλά ο επεξεργαστής ελέγχει αν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλαγάζει η διαγραφή οδηγών σχεδίασης το διάστημα του πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και το διάστημα του πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η διαγραφή των οδηγιών αφήνει το αποθηκευμένο διάστημα πλέγματος αμετάβλητο.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε όλο το έγγραφο κατά το άνοιγμα.

**Μπορώ να προκαθορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορεί να τηρήσουν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να δημιουργήσω ένα πρότυπο με προορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getViewProperties--) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.