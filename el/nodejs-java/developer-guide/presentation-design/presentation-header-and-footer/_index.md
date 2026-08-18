---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης σε JavaScript
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/nodejs-java/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορισμός κεφαλίδας
- ορισμός υποσέλιδου
- φυλλάδιο
- σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τους δεσμευτικούς χαρακτήρες υποσέλιδου, ημερομηνίας-ώρας, αριθμού διαφάνειας και κεφαλίδας σε διαφάνειες, σελίδες σημειώσεων και φυλλάδια με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Το PowerPoint χρησιμοποιεί διαφορετικούς δεσμευτικούς χαρακτήρες κεφαλίδας και υποσέλιδου ανάλογα με τον τύπο σελίδας. Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να ελέγχετε το κείμενο και την ορατότητα αυτών των δεσμευτικών χαρακτήρων μέσω των κλάσεων διαχειριστή κεφαλίδας/υποσέλιδου.

Οι διαθέσιμοι δεσμευτικοί χαρακτήρες εξαρτώνται από το εύρος:

| Εύρος | Κεφαλίδα | Υποσέλιδο | Ημερομηνία/ώρα | Αριθμός διαφάνειας/σελίδας |
|---|---|---|---|---|
| Κανονική διαφάνεια | Όχι | Ναι | Ναι | Ναι |
| Κύριος σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Διαφάνεια σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Κύριος φυλλαδίου | Ναι | Ναι | Ναι | Ναι |

Μια κανονική διαφάνεια παρουσίασης δεν διαθέτει δεσμευτικό χαρακτήρα κεφαλίδας. Οι κεφαλίδες είναι διαθέσιμες σε σελίδες σημειώσεων και φυλλάδια. Για κανονικές διαφάνειες, χρησιμοποιήστε αντίθετα τους δεσμευτικούς χαρακτήρες υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας.

Το εύρος μιας αλλαγής εξαρτάται από τον διαχειριστή που χρησιμοποιείτε. Η κλάση [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideheaderfootermanager/) ελέγχει μία κανονική διαφάνεια. Η κλάση [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notesslideheaderfootermanager/) ελέγχει μία διαφάνεια σημειώσεων. Οι διαχειριστές master και layout μπορούν επίσης να διαδώσουν τις ρυθμίσεις σε εξαρτώμενες διαφάνειες, ενώ η κλάση [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) ελέγχει το master του φυλλαδίου.

## **Ορισμός Υποσέλιδου, Ημερομηνίας/Ώρας και Αριθμών Διαφάνειας σε Κανονικές Διαφάνειες**

Για κανονικές διαφάνειες, η βασική ροή εργασίας είναι να προσπελάσετε τον διαχειριστή κεφαλίδας/υποσέλιδου κάθε διαφάνειας, να ορίσετε το κείμενο του υποσέλιδου και της ημερομηνίας/ώρας, να ενεργοποιήσετε τους απαιτούμενους δεσμευτικούς χαρακτήρες και να αποθηκεύσετε την παρουσίαση. Οι αριθμοί διαφάνειας παράγονται από την παρουσίαση, οπότε χρειάζεται μόνο να ελέγξετε την ορατότητά τους.

Χρησιμοποιήστε το [`setFooterText`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) και το [`setDateTimeText`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) για να ορίσετε το κείμενο, και χρησιμοποιήστε τα [`setFooterVisibility`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) και [`setSlideNumberVisibility`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) για να εμφανίσετε τους αντίστοιχους δεσμευτικούς χαρακτήρες.

Το παρακάτω πλήρες παράδειγμα εφαρμόζει το ίδιο υποσέλιδο, κείμενο ημερομηνίας/ώρας και ορατότητα αριθμού διαφάνειας σε όλες τις κανονικές διαφάνειες:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Εάν χρειάζεται να ενημερώσετε μόνο μία διαφάνεια, προσπελάστε τη διαφάνεια άμεσα μέσω της μεθόδου [`getSlides`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getslides/) αντί να διατρέξετε ολόκληρη τη συλλογή.

## **Ορισμός Κεφαλίδων και Υποσέλιδων στο Master Σημειώσεων**

Το master σημειώσεων ορίζει κοινή μορφοποίηση και συμπεριφορά δεσμευτικών χαρακτήρων για τις σελίδες σημειώσεων. Χρησιμοποιήστε την κλάση [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) όταν θέλετε να αλλάξετε μόνο το ίδιο το master σημειώσεων.

Το παρακάτω παράδειγμα ορίζει την κεφαλίδα, το υποσέλιδο και το κείμενο ημερομηνίας/ώρας στο master σημειώσεων και κάνει όλους τους υποστηριζόμενους δεσμευτικούς χαρακτήρες ορατούς σε αυτό το master:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μέθοδος [`getMasterNotesSlide`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) επιστρέφει `null` όταν η παρουσίαση δεν περιέχει master σημειώσεων.

## **Εφαρμογή Ρυθμίσεων Master Σημειώσεων σε Παράγωγες Διαφάνειες Σημειώσεων**

Ένα master σημειώσεων μπορεί να εφαρμόσει τις ρυθμίσεις κεφαλίδας και υποσέλιδου στον εαυτό του και σε όλες τις εξαρτώμενες διαφάνειες σημειώσεων. Χρησιμοποιήστε τις ειδικές μεθόδους διάδοσης στην κλάση [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) όταν οι ίδιες ρυθμίσεις πρέπει να εφαρμοστούν σε όλη τη ιεραρχία σημειώσεων.

Για παράδειγμα, τα [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) και [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) ενημερώνουν την κεφαλίδα του master σημειώσεων και όλες τις θυγατρικές κεφαλίδες. Ισότιμες μέθοδοι διατίθενται για τα υποσέλιδα, την ημερομηνία/ώρα και τους αριθμούς διαφάνειας.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι μέθοδοι διάδοσης που χρησιμοποιήθηκαν παραπάνω είναι τα [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) και [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Ορισμός Κεφαλίδων και Υποσέλιδων σε Ατομική Διαφάνεια Σημειώσεων**

Μια διαφάνεια σημειώσεων ανήκει σε μια συγκεκριμένη κανονική διαφάνεια. Χρησιμοποιήστε την κλάση [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notesslideheaderfootermanager/) όταν θέλετε να προσαρμόσετε μόνο αυτή τη σελίδα σημειώσεων.

Η μέθοδος [`addNotesSlide`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) επιστρέφει τη διαφάνεια σημειώσεων για τη τρέχουσα διαφάνεια και δημιουργεί μία αν δεν υπάρχει ήδη. Το παρακάτω παράδειγμα ρυθμίζει τη σελίδα σημειώσεων που συνδέεται με την πρώτη διαφάνεια της παρουσίασης:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Εάν πρώτα διαδώσετε τις ρυθμίσεις από το master σημειώσεων και μετά αλλάξετε μια ατομική διαφάνεια σημειώσεων, οι μεταγενέστερες ρυθμίσεις ανά διαφάνεια σας επιτρέπουν να προσαρμόσετε αυτή τη σελίδα σημειώσεων ανεξάρτητα.

## **Ορισμός Κεφαλίδων και Υποσέλιδων στο Master Φυλλαδίου**

Οι σελίδες φυλλαδίου χρησιμοποιούν το master φυλλαδίου για τους δεσμευτικούς χαρακτήρες κεφαλίδας, υποσέλιδου, ημερομηνίας/ώρας και αριθμού σελίδας. Σε αντίθεση με τις σελίδες σημειώσεων, οι ρυθμίσεις φυλλαδίου διαχειρίζονται μέσω του master φυλλαδίου αντί για ατομικές διαφάνειες φυλλαδίου.

Χρησιμοποιήστε το [`getMasterHandoutSlide`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) για να προσπελάσετε το master φυλλαδίου. Αν δεν υπάρχει, καλέστε το [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) για να δημιουργήσετε το προεπιλεγμένο master φυλλαδίου.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Κατανόηση Εύρους και Κληρονομικότητας**

Επιλέξτε τον διαχειριστή κεφαλίδας/υποσέλιδου που ταιριάζει με το εύρος που θέλετε να αλλάξετε:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideheaderfootermanager/) αλλάζει τις ρυθμίσεις υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας για μία κανονική διαφάνεια.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) ελέγχει μια διαφάνεια διάταξης και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτώμενες διαφάνειες.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslideheaderfootermanager/) ελέγχει ένα master κανονικής διαφάνειας και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτώμενες διαφάνειες.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) ελέγχει το master σημειώσεων και μπορεί να διαδώσει τις ρυθμίσεις σε όλες τις εξαρτώμενες διαφάνειες σημειώσεων.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notesslideheaderfootermanager/) αλλάζει μία διαφάνεια σημειώσεων και υποστηρίζει δεσμευτικό χαρακτήρα κεφαλίδας εκτός από υποσέλιδο, ημερομηνία/ώρα και αριθμό διαφάνειας.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) αλλάζει το master φυλλαδίου και υποστηρίζει όλους τους τέσσερις τύπους δεσμευτικών χαρακτήρων.

Χρησιμοποιήστε προβολή από ένα master ή layout όταν η ίδια ρύθμιση πρέπει να ισχύει σε όλη τη ιεραρχία του. Χρησιμοποιήστε διαχειριστή ατομικής διαφάνειας ή διαφάνειας σημειώσεων όταν χρειάζεστε τοπική ρύθμιση για μία σελίδα.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσθέσω κεφαλίδα σε κανονική διαφάνεια;**

Όχι. Το PowerPoint δεν ορίζει δεσμευτικό χαρακτήρα κεφαλίδας για κανονικές διαφάνειες. Στις κανονικές διαφάνειες, χρησιμοποιήστε τους δεσμευτικούς χαρακτήρες υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας. Οι δεσμευτικοί χαρακτήρες κεφαλίδας είναι διαθέσιμοι σε σελίδες σημειώσεων και φυλλάδια.

**Τι γίνεται αν ένας δεσμευτικός χαρακτήρας υποσέλιδου, ημερομηνίας/ώρας ή αριθμού διαφάνειας δεν είναι ορατός;**

Χρησιμοποιήστε τον αντίστοιχο διαχειριστή κεφαλίδας/υποσέλιδου για να ελέγξετε την ορατότητά του και να τον ενεργοποιήσετε όταν χρειάζεται. Για παράδειγμα, το [`isFooterVisible`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) αναφέρει αν υπάρχει δεσμευτικό χαρακτήρα υποσέλιδου, και το [`setFooterVisibility`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) αλλάζει την ορατότητά του.

**Πώς μπορώ να ξεκινήσω την αρίθμηση των διαφανειών από τιμή διαφορετική από το 1;**

Καλέστε τη μέθοδο [`setFirstSlideNumber`](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) της παρουσίασης. Οι δεσμευτικοί χαρακτήρες αριθμού διαφάνειας θα χρησιμοποιήσουν τότε την ενημερωμένη ακολουθία αρίθμησης.

**Τι γίνεται με τις κεφαλίδες και τα υποσέλιδα κατά την εξαγωγή σε PDF, εικόνες ή HTML;**

Τα ορατά στοιχεία κεφαλίδας και υποσέλιδου αποδίδονται μαζί με το υπόλοιπο περιεχόμενο της παρουσίασης στη μορφή εξόδου. Η εμφάνισή τους εξαρτάται από τον τύπο σελίδας που εξάγεται και τις αντίστοιχες ρυθμίσεις ορατότητας των δεσμευτικών χαρακτήρων.