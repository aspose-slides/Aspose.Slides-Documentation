---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε Android
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/androidjava/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- κλείδωμα κάθετου διαχωριστικού
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
description: "Χρησιμοποιήστε το Aspose.Slides για Android μέσω Java για να διαμορφώσετε τη διάταξη της κανονικής προβολής, το ζουμ των διαφανειών και των σημειώσεων, την απόσταση πλέγματος και την ορατότητα σχολίων σε παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Στην κανονική προβολή του PowerPoint, η διαφάνεια εμφανίζεται μεταξύ ενός πλευρικού παραθύρου για μικρογραφίες ή περίγραμμα και ενός παραθύρου σημειώσεων από κάτω. Το Aspose.Slides για Android μέσω Java αποκαλύπτει τις αποθηκευμένες προτιμήσεις επεξεργασίας της παρουσίασης μέσω [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Αυτές περιλαμβάνουν τη διάταξη των παραθύρων, τα επίπεδα ζουμ, την απόσταση πλέγματος και την ορατότητα σχολίων.

## **Σχετικά με INormalViewProperties**

Χρησιμοποιήστε το [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) για να προσπελάσετε τη διεπαφή [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). Το [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) ελέγχει αν τα εικονίδια εμφανίζονται δίπλα στους τίτλους των διαφανειών στο περίγραμμα. Το [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) επιτρέπει στο πλευρικό παράθυρο να κλειδώνει στην ελαχιστοποιημένη του κατάσταση όταν ο χρήστης το στενεύει. Το [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) υποδεικνύει προτίμηση για την προβολή ενός παραθύρου σε πλήρες παράθυρο.

Το [setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) ελέγχει το διαχωριστικό μεταξύ του πλευρικού παραθύρου και της διαφάνειας. Το [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) ελέγχει το διαχωριστικό πάνω από το παράθυρο σημειώσεων. Και τα δύο δέχονται μια τιμή [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) του `Minimized`, `Maximized` ή `Restored`.

## **Σχετικά με την Επαναφορά INormalViewProperties**

Όταν ένα διαχωριστικό επαναφέρεται, το [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) παρέχει το αποθηκευμένο μέγεθος του πλευρικού παραθύρου και το [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) παρέχει το αποθηκευμένο μέγεθος της άνω περιοχής της διαφάνειας. Και τα δύο εκθέτουν το [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Η μέθοδος [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) δέχεται ένα ποσοστό από 0 έως 100, και το [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) ελέγχει αν ο επεξεργαστής προσαρμόζει το μέγεθος όταν το παράθυρο αλλάζει μέγεθος.

Αυτό το παράδειγμα ενημερώνει μια υπάρχουσα παρουσίαση. Επαναφέρει το οριζόντιο διαχωριστικό, ορίζει το μέγεθος που επιστρέφει το [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) στο 80% με ενεργοποιημένη την αυτόματη προσαρμογή, και μεγιστοποιεί το κάθετο διαχωριστικό. Επιπλέον καλεί το [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) για να εμφανίσει εικονίδια στην προβολή περίγραμμα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός της Προεπιλεγμένης Τιμής Ζουμ**

Τα [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) και [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) αποθηκεύουν ανεξάρτητες ρυθμίσεις ζουμ για τον επεξεργαστή. Αυτές οι ρυθμίσεις δεν επηρεάζουν τις διαστάσεις της διαφάνειας, την αναπαραγωγή της παρουσίασης ή την ανάλυση εξαγωγής εικόνας.

Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί το [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) για να προσαρμόσει τη διαφάνεια στο παράθυρο επεξεργασίας. Για τη σελίδα σημειώσεων, απενεργοποιεί την αυτόματη κλιμάκωση και καλεί το [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) για να ορίσει σταθερό ζουμ 80%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός της Απόστασης Πλέγματος**

Το [setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) ορίζει την απόσταση μεταξύ των γραμμών του πλέγματος επεξεργασίας σε ολόκληρη την παρουσίαση. Δέχεται μια θετική τιμή σε σημείο, με 72 σημεία ανά ίντσα. Αυτό το παράδειγμα εκτυπώνει την τρέχουσα απόσταση σε μια υπάρχουσα παρουσίαση και αποθηκεύει ένα πλέγμα τέταρτου ίντσας ορίζοντας το διάστημα στα 18 σημεία.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το πλέγμα επαναλαμβάνεται σε σταθερό διάστημα. Οι [Drawing guides](/slides/el/androidjava/drawing-guides/) σημειώνουν μεμονωμένες οριζόντιες ή κατακόρυφες θέσεις. Και τα δύο αποτελούν βοηθήματα επεξεργασίας και εμφανίζονται μόνο σε επεξεργαστές που τα εμφανίζουν. Οι προβολές παρουσίασης και οι εξαγωγές σε PDF, εικόνες ή SVG τα παραλείπουν.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Το [setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) αποθηκεύει μια προτίμηση που οι συμβατοί επεξεργαστές χρησιμοποιούν κατά το άνοιγμα της παρουσίασης. Για μια υπάρχουσα παρουσίαση με σχόλια, αυτό το παράδειγμα εκτυπώνει τη τρέχουσα ρύθμιση και αποθηκεύει ένα αντίγραφο με τα σχόλια κρυμμένα. Επιπλέον καλεί το [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) με το [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) ώστε το αντίγραφο να ανοίξει στην προβολή διαφάνειας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η απόκρυψη σχολίων διατηρεί το κείμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Για να αλλάξετε τα ίδια τα σχόλια, δείτε το [Presentation Comments](/slides/el/androidjava/presentation-comments/). Οι ρυθμίσεις εξαγωγής ελέγχουν αν τα σχόλια εμφανίζονται σε PDF, HTML, εικόνες, σημειώσεις ή φυλλάδια.

## **Συχνές Ερωτήσεις**

**Γιατί το πλέγμα είναι κρυφό όταν ανοίγω ξανά την παρουσίαση;**

Η παρουσίαση αποθηκεύει το διάστημα του πλέγματος. Για να δείτε το πλέγμα, ενεργοποιήστε την ορατότητα του πλέγματος στον επεξεργαστή.

**Η διαγραφή των οδηγών σχεδίασης αλλάζει την απόσταση του πλέγματος;**

Όχι. Η προσθήκη, η μετακίνηση ή η διαγραφή ενός οδηγού δεν αλλάζει το διάστημα του πλέγματος.

**Μπορούν διαφορετικά τμήματα μιας παρουσίασης να έχουν διαφορετικές ρυθμίσεις προβολής;**

Όχι. Το [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) εφαρμόζεται σε ολόκληρη την παρουσίαση.

**Μπορώ να αποθηκεύσω διαφορετικές ρυθμίσεις προβολής για διαφορετικούς χρήστες;**

Το αρχείο αποθηκεύει ένα σύνολο ιδιοτήτων προβολής για όλους. Ένας επεξεργαστής μπορεί επίσης να εφαρμόσει τις τοπικές προτιμήσεις ενός χρήστη.

**Μπορώ να αποθηκεύσω ρυθμίσεις προβολής σε ένα πρότυπο;**

Ναι. Παρουσιάσεις που δημιουργούνται από το πρότυπο κληρονομούν τις αποθηκευμένες ρυθμίσεις προβολής.