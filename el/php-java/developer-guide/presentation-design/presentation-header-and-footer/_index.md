---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης σε PHP
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/php-java/presentation-header-and-footer/
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
- PHP
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τα placeholders υποσέλιδου, ημερομηνίας-ώρας, αριθμού διαφάνειας και κεφαλίδας σε διαφάνειες, σελίδες σημειώσεων και φυλλάδια με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το PowerPoint χρησιμοποιεί διαφορετικούς placeholders κεφαλίδας και υποσέλιδου ανάλογα με τον τύπο της σελίδας. Το Aspose.Slides for PHP μέσω Java σάς επιτρέπει να ελέγχετε το κείμενο και την ορατότητα αυτών των placeholders μέσω των κλάσεων διαχείρισης κεφαλίδας/υποσέλιδου.

Τα διαθέσιμα placeholders εξαρτώνται από το πεδίο:

| Πεδίο | Κεφαλίδα | Υποσέλιδο | Ημερομηνία/ώρα | Αριθμός διαφάνειας/σελίδας |
|---|---|---|---|---|
| Κανονική διαφάνεια | Όχι | Ναι | Ναι | Ναι |
| Κύρια σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Διαφάνεια σημειώσεων | Ναι | Ναι | Ναι | Ναι |
| Κύριος φυλλάδιο | Ναι | Ναι | Ναι | Ναι |

Μια κανονική διαφάνεια παρουσίασης δεν διαθέτει placeholder κεφαλίδας. Οι κεφαλίδες είναι διαθέσιμες στις σελίδες σημειώσεων και στα φυλλάδια. Για κανονικές διαφάνειες, χρησιμοποιήστε τα placeholders υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας αντί αυτού.

Το πεδίο μιας αλλαγής εξαρτάται από τον διαχειριστή που χρησιμοποιείτε. Η κλάση [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideheaderfootermanager/) ελέγχει μία κανονική διαφάνεια. Η κλάση [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/notesslideheaderfootermanager/) ελέγχει μία διαφάνεια σημειώσεων. Οι διαχειριστές master και layout μπορούν επίσης να διαδώσουν τις ρυθμίσεις σε εξαρτημένες διαφάνειες, ενώ η κλάση [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) ελέγχει το master του φυλλάδιο.

## **Ορισμός Υποσέλιδου, Ημερομηνίας/Ώρας και Αριθμών Διαφανειών σε Κανονικές Διαφάνειες**

Για κανονικές διαφάνειες, η βασική ροή εργασίας είναι η πρόσβαση στο διαχειριστή κεφαλίδας/υποσέλιδου κάθε διαφάνειας, ο καθορισμός του κειμένου υποσέλιδου και ημερομηνίας/ώρας, η ενεργοποίηση των απαιτούμενων placeholders και η αποθήκευση της παρουσίασης. Οι αριθμοί διαφανειών δημιουργούνται από την παρουσίαση, οπότε χρειάζεται μόνο να ελέγξετε την ορατότητά τους.

Χρησιμοποιήστε [`setFooterText`](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) και [`setDateTimeText`](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) για να ορίσετε κείμενο, και χρησιμοποιήστε [`setFooterVisibility`](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) και [`setSlideNumberVisibility`](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) για να εμφανίσετε τα αντίστοιχα placeholders.

Το παρακάτω παράδειγμα πλήρους ροής εφαρμόζει το ίδιο υποσέλιδο, κείμενο ημερομηνίας/ώρας και ορατότητα αριθμού διαφάνειας σε όλες τις κανονικές διαφάνειες:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Εάν χρειάζεται να ενημερώσετε μόνο μία διαφάνεια, αποκτήστε πρόσβαση σε αυτήν απευθείας μέσω της μεθόδου [`getSlides`](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/getslides/) αντί να επαναλαμβάνετε όλη τη συλλογή.

## **Ορισμός Κεφαλίδων και Υποσέλιδων στο Master Σημειώσεων**

Το master των σημειώσεων ορίζει κοινή μορφοποίηση και συμπεριφορά placeholders για τις σελίδες σημειώσεων. Χρησιμοποιήστε την κλάση [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/) όταν θέλετε να αλλάξετε μόνο το ίδιο το master των σημειώσεων.

Το παρακάτω παράδειγμα ορίζει κεφαλίδα, υποσέλιδο και κείμενο ημερομηνίας/ώρας στο master των σημειώσεων και κάνει όλα τα υποστηριζόμενα placeholders ορατά σε αυτό το master:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η μέθοδος [`getMasterNotesSlide`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) επιστρέφει `null` όταν η παρουσίαση δεν περιέχει master σημειώσεων.

## **Εφαρμογή Ρυθμίσεων Master Σημειώσεων σε Παιδιά Διαφάνειες Σημειώσεων**

Ένα master σημειώσεων μπορεί να εφαρμόσει ρυθμίσεις κεφαλίδας και υποσέλιδου στον εαυτό του και σε όλες τις εξαρτημένες διαφάνειες σημειώσεων. Χρησιμοποιήστε τις ειδικές μεθόδους διάδοσης στην κλάση [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/) όταν οι ίδιες ρυθμίσεις πρέπει να εφαρμοστούν σε όλη τη ιεραρχία σημειώσεων.

Για παράδειγμα, οι μέθοδοι [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) και [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) ενημερώνουν την κεφαλίδα του master σημειώσεων και όλες τις παιδικές κεφαλίδες. Ισοδύναμες μέθοδοι υπάρχουν για τα υποσέλιδα, την ημερομηνία/ώρα και τους αριθμούς διαφανειών.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Οι μέθοδοι διάδοσης που χρησιμοποιήθηκαν παραπάνω είναι [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), και [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Ορισμός Κεφαλίδων και Υποσέλιδων σε Ατομική Διαφάνεια Σημειώσεων**

Μια διαφάνεια σημειώσεων ανήκει σε συγκεκριμένη κανονική διαφάνεια. Χρησιμοποιήστε την κλάση [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/notesslideheaderfootermanager/) όταν θέλετε να προσαρμόσετε μόνο αυτή τη σελίδα σημειώσεων.

Η μέθοδος [`addNotesSlide`](https://reference.aspose.com/slides/el/php-java/aspose.slides/notesslidemanager/addnotesslide/) επιστρέφει τη διαφάνεια σημειώσεων για τη τρέχουσα διαφάνεια και δημιουργεί μία αν δεν υπάρχει ήδη. Το παρακάτω παράδειγμα διαμορφώνει τη σελίδα σημειώσεων που σχετίζεται με την πρώτη διαφάνεια παρουσίασης:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αν πρώτα διαδώσετε ρυθμίσεις από το master σημειώσεων και στη συνέχεια αλλάξετε μια ατομική διαφάνεια σημειώσεων, οι μεταγενέστερες ρυθμίσεις ανά διαφάνεια σας επιτρέπουν να προσαρμόσετε αυτή τη σελίδα σημειώσεων ανεξάρτητα.

## **Ορισμός Κεφαλίδων και Υποσέλιδων στο Master Φυλλάδιο**

Οι σελίδες φυλλάδιο χρησιμοποιούν το master φυλλάδιο για τις κεφαλίδες, τα υποσέλιδα, τις ημερομηνίες/ώρες και τα placeholders αριθμού σελίδας. Σε αντίθεση με τις σελίδες σημειώσεων, οι ρυθμίσεις φυλλάδιου διαχειρίζονται μέσω του master φυλλάδιου και όχι μέσω ατομικών διαφανειών φυλλάδιου.

Χρησιμοποιήστε τη μέθοδο [`getMasterHandoutSlide`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) για να έχετε πρόσβαση στο master φυλλάδιο. Εάν δεν υπάρχει, καλέστε τη μέθοδο [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) για να δημιουργήσετε το προεπιλεγμένο master φυλλάδιου.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Κατανόηση Πεδίου και Κληρονομικότητας**

Επιλέξτε τον διαχειριστή κεφαλίδας/υποσέλιδου που ταιριάζει με το πεδίο που θέλετε να αλλάξετε:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideheaderfootermanager/) αλλάζει ρυθμίσεις υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας για μία κανονική διαφάνεια.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslideheaderfootermanager/) ελέγχει μια διαφάνεια διάταξης και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslideheaderfootermanager/) ελέγχει το master μιας κανονικής διαφάνειας και μπορεί να διαδώσει τις υποστηριζόμενες ρυθμίσεις σε εξαρτημένες διαφάνειες.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masternotesslideheaderfootermanager/) ελέγχει το master των σημειώσεων και μπορεί να διαδώσει τις ρυθμίσεις σε όλες τις εξαρτημένες διαφάνειες σημειώσεων.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/notesslideheaderfootermanager/) αλλάζει μία διαφάνεια σημειώσεων και υποστηρίζει placeholder κεφαλίδας επιπλέον του υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) αλλάζει το master του φυλλάδιο και υποστηρίζει όλους τους τέσσερις τύπους placeholders.

Χρησιμοποιήστε διάδοση από ένα master ή layout όταν η ίδια ρύθμιση πρέπει να ισχύει σε όλη τη ιεραρχία του. Χρησιμοποιήστε έναν ατομικό διαχειριστή διαφάνειας ή σημειώσεων όταν χρειάζεστε τοπική ρύθμιση για μία σελίδα.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσθέσω κεφαλίδα σε κανονική διαφάνεια;**

Όχι. Το PowerPoint δεν ορίζει placeholder κεφαλίδας για κανονικές διαφάνειες. Σε κανονικές διαφάνειες, χρησιμοποιήστε τα placeholders υποσέλιδου, ημερομηνίας/ώρας και αριθμού διαφάνειας. Τα placeholders κεφαλίδας είναι διαθέσιμα σε σελίδες σημειώσεων και φυλλάδια.

**Τι γίνεται αν ένα placeholder υποσέλιδου, ημερομηνίας/ώρας ή αριθμού διαφάνειας δεν είναι ορατό;**

Χρησιμοποιήστε τον αντίστοιχο διαχειριστή κεφαλίδας/υποσέλιδου για να ελέγξετε την ορατότητά του και ενεργοποιήστε το όταν χρειάζεται. Για παράδειγμα, η μέθοδος [`isFooterVisible`](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) αναφέρει εάν υπάρχει placeholder υποσέλιδου, και η μέθοδος [`setFooterVisibility`](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) αλλάζει την ορατότητά του.

**Πώς μπορώ να ξεκινήσω την αρίθμηση διαφανειών από τιμή διαφορετική από το 1;**

Καλείστε τη μέθοδο [`setFirstSlideNumber`](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/setfirstslidenumber/) της παρουσίασης. Οι placeholders αριθμού διαφάνειας χρησιμοποιούν τότε την ενημερωμένη ακολουθία αρίθμησης.

**Τι συμβαίνει με τις κεφαλίδες και τα υποσέλιδα κατά την εξαγωγή σε PDF, εικόνες ή HTML;**

Τα ορατά στοιχεία κεφαλίδας και υποσέλιδου αποδίδονται μαζί με το υπόλοιπο περιεχόμενο της παρουσίασης στην έξοδο. Η εμφάνισή τους εξαρτάται από τον τύπο σελίδας που εξάγεται και τις αντίστοιχες ρυθμίσεις ορατότητας των placeholders.