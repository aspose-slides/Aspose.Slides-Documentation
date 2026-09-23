---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε JavaScript
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/nodejs-java/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- αυτόματη τοποθέτηση κάθετης γραμμής διαχωρισμού
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένη εστίαση
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Node.js μέσω Java ιδιότητες προβολής για να προσαρμόσετε τις μορφές διαφανειών PPT, PPTX και ODP — να προσαρμόσετε τις διατάξεις, τα επίπεδα εστίασης και τις ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια ίδια, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Ιδιότητες που αφορούν τη θέση των διαφορετικών περιοχών περιεχομένου. Αυτή η πληροφορία επιτρέπει στην εφαρμογή να αποθηκεύει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να βρίσκεται στην ίδια κατάσταση με όποτε η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής της παρουσίασης.

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewRestoredProperties) και οι απογόνους τους, καθώς και η αντολογία [SplitterBarStateType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType) προστέθηκαν.

## **Σχετικά με το NormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) καθορίζουν αν η εφαρμογή θα εμφανίζει εικονίδια όταν εμφανίζει περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) καθορίζουν αν η κάθετη γραμμή διαχωρισμού θα «κολλήσει» σε κατάσταση ελαχιστοποιημένη όταν η πλευρική περιοχή είναι αρκετά μικρή.

Η ιδιότητα [getPreferSingleView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) και [setPreferSingleView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) καθορίζει αν ο χρήστης προτιμά μια πλήρους παραθύρου περιοχή με μοναδικό περιεχόμενο αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Αν είναι ενεργοποιημένο, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε ολόκληρο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) και [getHorizontalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) καθορίζουν την κατάσταση που θα πρέπει να εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωρισμού. Μια οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια, ενώ η κάθετη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) και [getRestoredTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) καθορίζουν το μέγεθος της επάνω ή πλάγιας περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SplitterBarStateType#Restored) εφαρμόζεται στην [getVerticalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) και στη [getHorizontalBarState](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) αντίστοιχα.

## **Σχετικά με την Επαναφορά NormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του [getRestoredTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), ύψος όταν είναι θυγατρική του [getRestoredLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του restoredTop, ύψος όταν είναι θυγατρική του restoredLeft).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου θα προσαρμόζεται αυτόματα στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που φιλοξενεί την προβολή μέσα στην εφαρμογή.

Ένα παράδειγμα παρακάτω δείχνει πώς μπορείτε να αποκτήσετε πρόσβαση στις ιδιότητες [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) για μια παρουσίαση.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Επαναφορά των ιδιοτήτων προβολής της παρουσίασης
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Τιμής Εστίασης**

{{% alert color="info" %}} 

Το Aspose.Slides for Node.js via Java υποστηρίζει πλέον τον ορισμό προεπιλεγμένης τιμής εστίασης για την παρουσίαση, ώστε όταν η παρουσίαση ανοίξει η εστίαση να είναι ήδη ορισμένη. Αυτό μπορεί να γίνει ορίζοντας το [ViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties) μιας παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) καθώς και [getNotesViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) μπορούν να οριστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) στο Aspose.Slides.

{{% /alert %}} 

Για τον ορισμό των ιδιοτήτων προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ViewProperties) της [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/). Στο παρακάτω παράδειγμα, ορίσαμε την τιμή εστίασης για την προβολή διαφάνειας καθώς και για την προβολή σημειώσεων.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Ορισμός των ιδιοτήτων προβολής της παρουσίασης
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Τιμή εστίασης σε ποσοστά για την προβολή διαφάνειας
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Τιμή εστίασης σε ποσοστά για την προβολή σημειώσεων
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Διαστήματος Πλέγματος**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getViewProperties--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Οι μέθοδοι [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) και [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση ισχύει για ολόκληρη την παρουσίαση, όχι για μεμονωμένη διαφάνεια. Το διάστημα πλέγματος ορίζεται σε μονάδες σημείου, όπου 72 σημεία ισοδυναμούν με ένα ίντσο. Χρησιμοποιήστε θετική τιμή, όπως απαιτείται από την τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει το τρέχον διάστημα πλέγματος, θέτει ένα διάστημα τέταρτου ίντσου και αποθηκεύει το αποτέλεσμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/nodejs-java/drawing-guides/). Το διάστημα πλέγματος ελέγχει ένα κανονικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι μεμονωμένες οριζόντιες ή κάθετες γραμμές ευθυγράμμισης. Η προσθήκη, η μετακίνηση ή η αφαίρεση οδηγών σχεδίασης δεν αλλάζει το διάστημα πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση του διαστήματος πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του προβολέα ή του επεξεργαστή.

## **Προβολή ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getViewProperties--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις προβολής σε όλη την παρουσίαση. Χρησιμοποιήστε τα [ViewProperties.getShowComments](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#getShowComments--) και [ViewProperties.setShowComments](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) για να διαβάσετε ή να αλλάξετε την αποθηκευμένη προτίμηση σχετικά με το αν τα σχόλια θα εμφανίζονται όταν η παρουσίαση ανοίγει στο PowerPoint ή σε άλλο συμβατό πρόγραμμα.

Αυτή η ρύθμιση ελέγχει μόνο την αποθηκευμένη προτίμηση προβολής. Δεν προσθέτει, αφαιρεί, επεξεργάζεται ή επιλύει σχόλια. Η απόκρυψη σχολίων διατηρεί το περιεχόμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Δείτε το [Presentation Comments](/slides/el/nodejs-java/presentation-comments/) για λειτουργίες που αλλάζουν τα ίδια τα σχόλια.

Το παρακάτω παράδειγμα απαιτεί ένα υπάρχον `comments.pptx` με σχόλια. Εκτυπώνει την τρέχουσα ρύθμιση ορατότητας, ζητάει η απόκρυψη των σχολίων και αποθηκεύει ένα νέο PPTX χωρίς να αφαιρέσει κανένα σχόλιο. Χρησιμοποιεί επίσης το [ViewProperties.setLastView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) με το [ViewType.SlideView](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewtype/#SlideView) για να διαμορφώσει την αρχική προβολή επεξεργασίας μαζί με την ορατότητα των σχολίων.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτή η ρύθμιση δεν καθορίζει αν τα σχόλια περιλαμβάνονται σε εξαγωγές PDF, HTML, εικόνας, σημειώσεων ή φυλλαδίων. Ρυθμίστε τις αντίστοιχες επιλογές εξαγωγής ξεχωριστά.

## **Συχνές Ερωτήσεις**

**Γιατί το πλέγμα δεν είναι ορατό μετά το άνοιγμα ξανά της παρουσίασης;**

Το αρχείο αποθηκεύει το διάστημα πλέγματος, αλλά ο επεξεργαστής ελέγχει αν το πλέγμα θα εμφανιστεί. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η αφαίρεση οδηγιών σχεδίασης το διάστημα πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και το διάστημα πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η αφαίρεση οδηγών δεν αλλάζει το αποθηκευμένο διάστημα πλέγματος.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getviewproperties/) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), όχι ανά ενότητα, έτσι ένα σύνολο παραμέτρων ισχύει για όλο το έγγραφο όταν ανοίγει.

**Μπορώ να προ-ορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορεί να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το ίδιο το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να ετοιμάσω ένα πρότυπο με προ-καθορισμένες Ιδιότητες Προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getviewproperties/) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική διαμόρφωση προβολής.