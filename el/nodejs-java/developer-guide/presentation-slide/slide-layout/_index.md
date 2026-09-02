---
title: Εφαρμογή ή Αλλαγή Διαρρυθμίσεων Διαφάνειας σε JavaScript
linktitle: Διαρρύθμιση Διαφάνειας
type: docs
weight: 60
url: /el/nodejs-java/slide-layout/
keywords:
- διαρρύθμιση διαφάνειας
- διαρρύθμιση περιεχομένου
- σύμβολο κράτησης
- σχεδίαση παρουσίασης
- σχεδίαση διαφάνειας
- μη χρησιμοποιούμενη διαρρύθμιση
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- κεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διαρρύθμιση
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
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διαρρυθμίσεις διαφάνειας στο Aspose.Slides για Node.js μέσω Java, προσθέστε σύμβολα κράτησης, αφαιρέστε μη χρησιμοποιούμενες διαρρυθμίσεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Μια διαρρύθμιση διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των στοιχείων κράτησης όπως τίτλοι, κείμενο, εικόνες, γραφήματα και πίνακες. Η εφαρμογή μιας διαρρύθμισης δίνει στις διαφάνειες μια συνεπή δομή ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συνηθισμένες διαρρυθμίσεις περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει στοιχεία κράτησης τίτλου και υποτίτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει ένα στοιχείο κράτησης τίτλου και ένα γενικής χρήσης στοιχείο κράτησης περιεχομένου.
- **Κενή**: Δεν περιέχει στοιχεία κράτησης περιεχομένου και είναι χρήσιμη όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονόμησης Διαρρύθμισης**

Μια παρουσίαση έχει τρία σχετιζόμενα επίπεδα:

1. Ένα [master slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα φόντα και τα κοινά αντικείμενα.
1. Ένα [layout slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/) ανήκει σε ένα master και ορίζει μια συγκεκριμένη διάταξη στοιχείων κράτησης.
1. Ένα [normal slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/) χρησιμοποιεί μία διαρρύθμιση και αποθηκεύει το περιεχόμενο που εισήχθη για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διαρρύθμισή της, και η διαρρύθμιση κληρονομεί από το master της. Μία τιμή ορισμένη άμεσα σε μια κανονική διαφάνεια παρακάμπτει την κληρονομημένη τιμή σε εκείνο το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα στοιχείων κράτησης δημιουργούνται από τη διαρρύθμιση που επιλέχθηκε, ενώ το περιεχόμενο που εισήχθη σε αυτά τα στοιχεία ανήκει στη κανονική διαφάνεια.

Προσθέστε τα απαιτούμενα στοιχεία κράτησης σε μια διαρρύθμιση πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη ενός νέου στοιχείου κράτησης σε μια διαρρύθμιση αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα στοιχείου κράτησης σε υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχόντων στοιχείων κράτησης σε μια διαρρύθμιση μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διαρρύθμιση που χρησιμοποιείται ήδη, ελέγξτε τις εξαρτημένες διαφάνειες και επανεξετάστε το προκύπτον αποτέλεσμα.
- Μια διαρρύθμιση που χρησιμοποιείται ακόμα από κάποια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες σε άλλη διαρρύθμιση ή αφαιρέστε μόνο τις διαρρυθμίσεις που δεν χρησιμοποιούνται.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε το [Slide Master](/slides/el/nodejs-java/slide-master/).

## **Επιλογή και Εφαρμογή Διαρρύθμισης Διαφάνειας**

Χρησιμοποιήστε μια τιμή [SlideLayoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidelayouttype/) όταν η παρουσίαση ακολουθεί τους τυπικούς ορισμούς διαρρυθμίσεων του PowerPoint. Τα ονόματα διαρρυθμίσεων είναι επεξεργάσιμα από το χρήστη και μπορούν να μεταφραστούν, οπότε η επιλογή βάσει ονόματος είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πρότυπο πηγή.

Το παρακάτω παράδειγμα ψάχνει για **Title and Content** στον πρώτο master. Εάν αυτή η διαρρύθμιση δεν είναι διαθέσιμη, πέφτει σκόπιμα σε **Blank**. Ο δεύτερος έλεγχος null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διαρρυθμίσεις. Η επιλεγμένη διαρρύθμιση εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της μεθόδου [Slide.setLayoutSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#setLayoutSlide).

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

Η αλλαγή της διαρρύθμισης μιας διαφάνειας δεν αφαιρεί τα κανονικά σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των στοιχείων κράτησης, η κληρονομημένη μορφοποίηση και η αντιστοιχία μεταξύ των υπαρχόντων στοιχείων κράτησης και της νέας διαρρύθμισης μπορεί να αλλάξει, γι’ αυτό ελέγξτε το αποτέλεσμα όταν εναλλάσσετε ενδιάμεσα διαφορετικές διαρρυθμίσεις.

## **Προσθήκη Διαφάνειας Διάταξης**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διαρρύθμιση· δεν τη δημιουργεί. Για να δημιουργήσετε μια διαρρύθμιση, καλέστε τη μέθοδο [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) στη συλλογή διαρρυθμίσεων του στόχου master.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διαρρύθμιση **Title and Content** με όνομα `Report Title and Content`, έπειτα προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα διαρρυθμίσεων πρέπει να είναι μοναδικά εντός της συλλογής.

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

Προσθέστε μια διαρρύθμιση μόνο όταν το πρότυπο χρειάζεται πραγματικά μια επιπλέον επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διαρρύθμιση, επιλέξτε και επαναχρησιμοποιήστε την αντί να δημιουργήσετε διπλότυπο.

## **Προσθήκη Στοιχείων Κράτησης σε Διαφάνεια Διάταξης**

Η μέθοδος [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) παρέχει ένα [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/) για να προσθέσετε σχήματα στοιχείων κράτησης σε μια διαρρύθμιση.

| PowerPoint Placeholder | `LayoutPlaceholderManager` Method |
| ---------------------- | --------------------------------- |
| ![Περιεχόμενο](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Κείμενο](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Εικόνα](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Διάγραμμα](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Πίνακας](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Πολυμέσα](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Φωτογραφία online](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Το παρακάτω παράδειγμα ελέγχει αν υπάρχει η διαρρύθμιση **Κενή**, προσθέτει τέσσερα στοιχεία κράτησης σε αυτήν και έπειτα δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διαρρύθμιση. Η σειρά είναι σκόπιμη: τα στοιχεία κράτησης προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα στοιχείων κράτησης σε αυτή τη διαφάνεια.

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

![Τα στοιχεία κράτησης στη διαφάνεια διαρρύθμισης](add_placeholders.png)

{{% alert color="warning" title="Προειδοποίηση" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπαρχόντων στοιχείων κράτησης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Ένα νέο στοιχείο κράτησης που προστίθεται δεν συμπληρώνεται αυτόματα σε υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Μη Χρησιμοποιούμενων Διαρρυθμίσεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε διαρρυθμίσεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει αμετάβλητες τις διαρρυθμίσεις που είναι ακόμη σε χρήση.

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

Για να αφαιρέσετε μια συγκεκριμένη διαρρύθμιση, πρώτα χρησιμοποιήστε τη μέθοδο [hasDependingSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) ή [getDependingSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Αναθέστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε το [LayoutSlide.remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#remove). Η προσπάθεια αφαίρεσης μιας διαρρύθμισης που χρησιμοποιείται προκαλεί την εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διαφάνεια Διάταξης**

Μια διαρρύθμιση διαθέτει τα δικά της στοιχεία κράτησης υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας‑ώρας. Χρησιμοποιήστε τη μέθοδο [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) για να ελέγξετε αυτά τα στοιχεία σε μια διαρρύθμιση. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διαρρυθμίσεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα αλλά οι διαρρυθμίσεις τίτλου όχι.

Το παρακάτω παράδειγμα επιλέγει μια διαρρύθμιση με ασφάλεια και κάνει τα στοιχεία υποσέλιδου της ορατά:

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

## **Έλεγχος Ορατότητας Υποσέλιδου σε Master και τις Κατόχους Διαρρυθμίσεις**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε όλη τη ιεραρχία του master, χρησιμοποιήστε τη μέθοδο [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Οι μέθοδοι διάδοσης του [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslideheaderfootermanager/) επηρεάζουν το master, τις εξαρτημένες διαφάνειες διαρρύθμισης και τις κανονικές διαφάνειες· δεν στοχεύουν μόνο μία κανονική διαφάνεια.

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

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ master slide και layout slide;**

Ένα master slide ορίζει το θέμα και τη κοινή μορφοποίηση της παρουσίασης. Ένα layout slide ανήκει σε ένα master και ορίζει μία επαναχρησιμοποιήσιμη διάταξη στοιχείων κράτησης. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διαρρυθμίσεις και αποθηκεύουν το περιεχόμενο της κάθε διαφάνειας.

**Μπορώ να αντιγράψω ένα layout slide από μια παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Κατά την αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιεί η πηγή διαρρύθμιση.

**Τι συμβαίνει όταν τροποποιώ μια διαρρύθμιση που χρησιμοποιείται ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διαρρύθμισης εκτός εάν παρακάμψουν τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των στοιχείων κράτησης και η κληρονομημένη μορφοποίηση μπορούν επομένως να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε το [getDependingSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διαρρύθμιση.

**Τι συμβαίνει αν αφαιρέσω μια διαρρύθμιση που είναι ακόμα σε χρήση;**

Το Aspose.Slides ρίχνει μια [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε το [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε μόνο τις διαρρυθμίσεις που δεν αναφέρονται.