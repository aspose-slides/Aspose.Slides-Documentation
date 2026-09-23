---
title: "Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε Java"
linktitle: "Ιδιότητες Προβολής"
type: docs
weight: 80
url: /el/java/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- κλείδωμα κάθετου διαχωριστή
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
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides for Java για προσαρμογή των μορφών διαφανειών PPT, PPTX και ODP — ρυθμίστε τις διατάξεις, τα επίπεδα ζουμ και τις ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθαυτή, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύσει την κατάσταση προβολής στο αρχείο, ώστε όταν ξανανοίξει η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες κανονικής προβολής της παρουσίασης.

Προστέθηκαν τα interface [INormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties) καθώς και οι απογόνους τους, το enum [SplitterBarStateType](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType).

## **Σχετικά με το INormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζει το περίγραμμα σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν εάν ο κάθετος διαχωριστής πρέπει να "κλειδώνει" σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) καθορίζουν εάν ο χρήστης προτιμά να βλέπει μια περιοχή περιεχομένου σε πλήρη παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η οριζόντια ή η κάθετη μπάρα διαχωριστικού. Μια οριζόντια μπάρα διαχωριστικού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κάθετη μπάρα χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) καθορίζουν το μέγεθος της άνω ή της πλευρικής περιοχής της διαφάνειας στην κανονική προβολή, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/java/com.aspose.slides/SplitterBarStateType#Restored) εφαρμόζεται στην [getVerticalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) και στην [getHorizontalBarState](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την Επαναφορά των INormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) στην κανονική προβολή, όταν η περιοχή έχει μεταβλητό αποκατεστημένο μέγεθος (ούτε ελαχιστοποιημένο ούτε μεγιστοποιημένο).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του restoredTop, ύψος όταν είναι παιδί του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να αντισταθμίσει το νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή στην εφαρμογή.

Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) μιας παρουσίασης.

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

Το Aspose.Slides for Java υποστηρίζει πλέον τον ορισμό της προεπιλεγμένης τιμής ζουμ για μια παρουσίαση, ώστε όταν η παρουσίαση ανοίξει το ζουμ να είναι ήδη ορισμένο. Αυτό μπορεί να γίνει ορίζοντας τα [ViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) της παρουσίασης. Οι μέθοδοι [getSlideViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και [getNotesViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τα [View Properties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) στο Aspose.Slides.

{{% /alert %}} 

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
2. Ορίστε τα [View Properties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
3. Αποθηκεύστε την παρουσία ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Στο παρακάτω παράδειγμα, ορίσαμε την τιμή ζουμ τόσο για την προβολή διαφάνειας όσο και για την προβολή σημειώσεων.

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

## **Ορισμός του Αποστάματος Πλέγματος**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) για πρόσβαση στις ρυθμίσεις προβολής σε επίπεδο παρουσίασης. Οι μέθοδοι [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/el/java/com.aspose.slides/iviewproperties/#getGridSpacing--) και [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/el/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση ισχύει για ολόκληρη την παρουσίαση, όχι μόνο για μια συγκεκριμένη διαφάνεια. Το απόστημα του πλέγματος ορίζεται σε σημεία, όπου 72 σημεία ισοδυναμούν με μία ίντσα. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει το τρέχον απόστημα πλέγματος, ορίζει ένα διάστημα τέταρτης ίντσας και αποθηκεύει το αποτέλεσμα.

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

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/java/drawing-guides/). Το απόστημα πλέγματος ελέγχει ένα κανονικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι μεμονωμένα τοποθετημένες οριζόντιες ή κάθετες γραμμές στοίχισης. Η προσθήκη, η μετακίνηση ή η εκκαθάριση των οδηγιών σχεδίασης δεν αλλάζει το απόστημα του πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση του αποστάματος πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα· η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του θεατή ή του επεξεργαστή.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) για πρόσβαση στις ρυθμίσεις προβολής σε επίπεδο παρουσίασης. Χρησιμοποιήστε τα [IViewProperties.getShowComments](https://reference.aspose.com/slides/el/java/com.aspose.slides/iviewproperties/#getShowComments--) και [IViewProperties.setShowComments](https://reference.aspose.com/slides/el/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) για να διαβάσετε ή να αλλάξετε την αποθηκευμένη προτίμηση σχετικά με το εάν θα εμφανίζονται σχόλια όταν η παρουσίαση ανοίγει στο PowerPoint ή σε κάποιο άλλο συμβατό πρόγραμμα.

Αυτή η ρύθμιση ελέγχει μόνο την αποθηκευμένη προτίμηση προβολής. Δεν προσθέτει, αφαιρεί, επεξεργάζεται ή λύνει σχόλια. Η απόκρυψη σχολίων διατηρεί το περιεχόμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Δείτε τις [Presentation Comments](/slides/el/java/presentation-comments/) για ενέργειες που αλλάζουν τα ίδια τα σχόλια.

Το παρακάτω παράδειγμα απαιτεί ένα υπάρχον `comments.pptx` που περιέχει σχόλια. Εκτυπώνει την τρέχουσα ρύθμιση ορατότητας, ζητά την απόκρυψη των σχόλίων και αποθηκεύει ένα νέο PPTX χωρίς να αφαιρέσει κανένα σχόλιο. Χρησιμοποιεί επίσης το [IViewProperties.setLastView](https://reference.aspose.com/slides/el/java/com.aspose.slides/iviewproperties/#setLastView-int-) με το [ViewType.SlideView](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewtype/#SlideView) για να ρυθμίσει την αρχική προβολή επεξεργασίας μαζί με την ορατότητα των σχολίων.

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

Αυτή η ρύθμιση δεν καθορίζει αν τα σχόλια θα συμπεριληφθούν στις εξαγωγές PDF, HTML, εικόνας, σημειώσεων ή φυλλαδίου. Διαμορφώστε ξεχωριστά τις επιλογές εξαγωγής που σχετίζονται με κάθε μορφή.

## **Συχνές Ερωτήσεις**

**Γιατί το πλέγμα δεν είναι ορατό μετά το άνοιγμα εκ νέου της παρουσίασης;**

Το αρχείο αποθηκεύει το απόστημα πλέγματος, αλλά ο επεξεργαστής ελέγχει αν θα εμφανιστεί το πλέγμα. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η εκκαθάριση των οδηγών σχεδίασης το απόστημα του πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και το απόστημα πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η εκκαθάριση των οδηγών δεν επηρεάζει το αποθηκευμένο διάστημα του πλέγματος.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/el/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), όχι ανά ενότητα, οπότε ένα σύνολο παραμέτρων ισχύει για ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να προ-ορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορεί να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα μόνο σύνολο ιδιοτήτων προβολής.

**Μπορώ να ετοιμάσω ένα πρότυπο με προορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getViewProperties--) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.