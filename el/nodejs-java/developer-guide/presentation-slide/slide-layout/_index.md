---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε JavaScript
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/nodejs-java/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- θέση κράτησης
- σχεδιασμός παρουσίασης
- σχεδιασμός διαφάνειας
- αχρησιμοποίητη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- κεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με λεζάντα
- εικόνα με λεζάντα
- τίτλος και κατακόρυφο κείμενο
- κατακόρυφος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε τις διατάξεις διαφάνειας στο Aspose.Slides για Node.js μέσω Java, προσθέστε θέσεις κράτησης, αφαιρέστε αχρησιμοποίητες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Ένα σχέδιο διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των θέσεων κράτησης όπως τίτλοι, κείμενο, εικόνες, γραφήματα και πίνακες. Η εφαρμογή ενός σχεδίου δίνει στις διαφάνειες μια συνεπή δομή, ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Τα πιο συχνά σχέδια περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει θέσεις κράτησης για τίτλο και υπότιτλο.  
- **Τίτλος και Περιεχόμενο**: Περιέχει μια θέση κράτησης τίτλου και μια γενικού σκοπού θέση κράτησης περιεχομένου.  
- **Κενό**: Δεν περιέχει θέσεις κράτησης περιεχομένου και είναι χρήσιμο όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονόμησης Σχεδίου**

Μια παρουσίαση έχει τρία σχετικά επίπεδα:

1. Μια [κύρια διαφάνεια](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα υπόβαθρα και τα κοινά αντικείμενα.  
1. Μια [διαφάνεια διάταξης](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/) ανήκει σε μια κύρια διαφάνεια και ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης.  
1. Μια [κανονική διαφάνεια](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/) χρησιμοποιεί ένα σχέδιο και αποθηκεύει το περιεχόμενο που έχει εισαχθεί για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από το σχέδιό της, και το σχέδιο κληρονομεί από την κύρια διαφάνειά του. Μια τιμή που ορίζεται απευθείας σε μια κανονική διαφάνεια παρακάμπτει την κληρονομημένη τιμή σε εκείνο το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα θέσεων κράτησης δημιουργούνται από το επιλεγμένο σχέδιο, ενώ το περιεχόμενο που εισάγεται σε αυτές τις θέσεις ανήκει στην κανονική διαφάνεια.

Προσθέστε τις απαραίτητες θέσεις κράτησης σε ένα σχέδιο πριν δημιουργήσετε διαφάνειες από αυτό. Η προσθήκη μιας νέας θέσης κράτησης σε ένα σχέδιο αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα θέσης κράτησης στις υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχουσών θέσεων κράτησης σε ένα σχέδιο μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτό. Πριν επεξεργαστείτε ένα σχέδιο που είναι ήδη σε χρήση, εξετάστε τις εξαρτημένες διαφάνειες και ελέγξτε το αποτέλεσμα.  
- Ένα σχέδιο που χρησιμοποιείται ακόμα από μια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες του σε άλλο σχέδιο ή αφαιρέστε μόνο τα αχρησιμοποίητα σχέδια.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε το [Διαφάνεια‑Μάστερ](/slides/el/nodejs-java/slide-master/).

Για να κρύψετε κληρονομημένα λογότυπα ή διακοσμητικά σχήματα κύριας διαφάνειας σε μία διαφάνεια ή μέσω μιας κοινόχρηστης διάταξης, δείτε το [Έλεγχος ορατότητας γραφικών κύριας διαφάνειας](/slides/el/nodejs-java/slide-master/). Το παράδειγμα συγκρίνει δύο διαφάνειες που χρησιμοποιούν τον ίδιο μάστερ.

## **Επιλογή και Εφαρμογή Σχεδίου Διαφάνειας**

Χρησιμοποιήστε μια τιμή [SlideLayoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidelayouttype/) όταν η παρουσίαση ακολουθεί τις τυπικές ορισμένες διατάξεις PowerPoint. Τα ονόματα σχεδίων είναι επεξεργάσιμα από τον χρήστη και μπορούν να μεταφραστούν, επομένως η επιλογή με βάση το όνομα είναι λιγότερο αξιόπιστη εκτός αν ελέγχετε το πηγαίο πρότυπο.

Το παρακάτω παράδειγμα ψάχνει για **Τίτλος και Περιεχόμενο** στην πρώτη κύρια διαφάνεια. Εάν αυτό το σχέδιο δεν είναι διαθέσιμο, επιστρέφει σκόπιμα στο **Κενό**. Ο δεύτερος έλεγχος null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένα σχέδια. Το επιλεγμένο σχέδιο εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της μεθόδου [Slide.setLayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αλλαγή του σχεδίου μιας διαφάνειας δεν αφαιρεί τα κανονικά σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των θέσεων κράτησης, η κληρονομημένη μορφοποίηση και η αντιστοίχηση μεταξύ των υπαρχουσών θέσεων κράτησης και του νέου σχεδίου μπορούν να αλλάξουν, γι’ αυτό ελέγξτε το αποτέλεσμα όταν μεταβαίνετε μεταξύ εντελώς διαφορετικών σχεδίων.

## **Προσθήκη Διαφάνειας Σχεδίου**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει ένα υπάρχον σχέδιο· δεν δημιουργεί νέο. Για τη δημιουργία ενός σχεδίου, καλέστε τη μέθοδο [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) στη συλλογή διατάξεων της στοχευμένης κύριας διαφάνειας.

Το παρακάτω παράδειγμα προσθέτει πάντα ένα νέο σχέδιο **Τίτλος και Περιεχόμενο** με το όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια βάσει αυτού. Τα ονόματα σχεδίων πρέπει να είναι μοναδικά μέσα στη συλλογή.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Προσθέστε ένα σχέδιο μόνο όταν το πρότυπο χρειάζεται πραγματικά μια επιπλέον επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη κατάλληλο σχέδιο, επιλέξτε το και επαναχρησιμοποιήστε το αντί να δημιουργήσετε διπλότυπο.

## **Προσθήκη Θέσεων Κράτησης σε Διαφάνεια Σχεδίου**

Η μέθοδος [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) επιστρέφει έναν [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/) για την προσθήκη σχημάτων θέσεων κράτησης σε ένα σχέδιο.

| Θέση Κράτησης PowerPoint          | Μέθοδος `LayoutPlaceholderManager` |
| ----------------------------------- | ----------------------------------- |
| ![Περιεχόμενο](content.png)        | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Κείμενο](text.png)               | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Εικόνα](picture.png)             | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Γράφημα](chart.png)              | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Πίνακας](table.png)              | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Πολυμέσα](media.png)             | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Το παρακάτω παράδειγμα ελέγχει αν το σχέδιο **Κενό** υπάρχει, προσθέτει τέσσερις θέσεις κράτησης σε αυτό, και, στη συνέχεια, δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί το τροποποιημένο σχέδιο. Η σειρά είναι σκόπιμη: οι θέσεις κράτησης προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε η Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα θέσεων κράτησης σε εκείνη τη διαφάνεια.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι θέσεις κράτησης στη διαφάνεια σχεδίου](add_placeholders.png)

{{% alert color="warning" title="Προειδοποίηση" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχουσών θέσεων κράτησης σε σχέδιο μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια νεοεισαχθείσα θέση κράτησης σε σχέδιο δεν προστίθεται αυτόματα στις υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές σχεδίου σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Αχρησιμοποίητων Διαφανειών Σχεδίου**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε σχέδια που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει αμετάβλητα τα σχέδια που είναι ακόμη σε χρήση.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να αφαιρέσετε ένα συγκεκριμένο σχέδιο, πρώτα χρησιμοποιήστε τη μέθοδο [hasDependingSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) ή [getDependingSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Αναθέστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε [LayoutSlide.remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#remove). Η προσπάθεια αφαίρεσης ενός σχεδίου που χρησιμοποιείται προκαλεί [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδας σε Διαφάνεια Σχεδίου**

Ένα σχέδιο διαθέτει δικά του υποσέλιδα, αριθμό διαφάνειας και θέση κράτησης ημερομηνίας‑ώρας. Χρησιμοποιήστε τη μέθοδο [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) για να ελέγξετε αυτές τις θέσεις σε ένα σχέδιο. Αυτό είναι χρήσιμο, για παράδειγμα, όταν τα σχέδια περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ τα σχέδια τίτλου όχι.

Το παρακάτω παράδειγμα επιλέγει με ασφάλεια ένα σχέδιο και κάνει τα στοιχεία υποσέλιδου ορατά:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Ορατότητας Υποσέλιδου σε Μάστερ και τα Παιδικά Σχέδια του**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε όλη τη ιεραρχία του μάστερ, χρησιμοποιήστε τη μέθοδο [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Οι μέθοδοι διάδοσης του [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslideheaderfootermanager/) λειτουργούν στον μάστερ και στις εξαρτημένες διαφάνειες σχεδίου και στις κανονικές διαφάνειες· δεν στοχεύουν μόνο σε μία κανονική διαφάνεια.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ΣΥΝΑΝΤΑΤΙΚΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Ποια είναι η διαφορά μεταξύ Μάστερ Διαφάνειας και Διαφάνειας Σχεδίου;**

Ένας μάστερ διαφάνειας ορίζει το θέμα και τη κοινή μορφοποίηση της παρουσίασης. Μια διαφάνεια διάταξης ανήκει σε έναν μάστερ και ορίζει μία επαναχρησιμοποιήσιμη διάταξη θέσεων κράτησης. Οι κανονικές διαφάνειες χρησιμοποιούν αυτά τα σχέδια και αποθηκεύουν το περιεχόμενο της συγκεκριμένης διαφάνειας.

**Μπορώ να αντιγράψω μια Διαφάνεια Σχεδίου από μία Παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Κατά την αντιγραφή μεταξύ παρουσιάσεων, επαληθεύστε επίσης γραμματοσειρές, θέματα, εικόνες και άλλους πόρους που χρησιμοποιεί το αρχικό σχέδιο.

**Τι συμβαίνει αν τροποποιήσω ένα Σχέδιο που είναι ήδη σε χρήση;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές του σχεδίου εκτός αν παρακάμψουν τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των θέσεων κράτησης και η κληρονομημένη μορφή μπορούν επομένως να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε τη μέθοδο [getDependingSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε το σχέδιο.

**Τι συμβαίνει αν αφαιρέσω ένα Σχέδιο που είναι ακόμα σε χρήση;**

Η Aspose.Slides ρίχνει μια [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε μόνο τα αχρησιμοποίητα σχέδια.