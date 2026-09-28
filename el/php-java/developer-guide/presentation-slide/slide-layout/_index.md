---
title: Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε PHP
linktitle: Διάταξη Διαφάνειας
type: docs
weight: 60
url: /el/php-java/slide-layout/
keywords:
- διάταξη διαφάνειας
- διάταξη περιεχομένου
- δεσμευτική θέση
- σχεδιασμός παρουσίασης
- σχεδιασμός διαφάνειας
- μη χρησιμοποιημένη διάταξη
- ορατότητα υποσέλιδου
- διαφάνεια τίτλου
- τίτλος και περιεχόμενο
- επικεφαλίδα ενότητας
- δύο περιεχόμενα
- σύγκριση
- μόνο τίτλος
- κενή διάταξη
- περιεχόμενο με λεζάντα
- εικόνα με λεζάντα
- τίτλος και κάθετο κείμενο
- κάθετος τίτλος και κείμενο
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για PHP μέσω Java, προσθέστε δεσμευτικές θέσεις, αφαιρέστε μη χρησιμοποιημένες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Μια διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των δεσμευτικών θέσεων, όπως τίτλοι, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης παρέχει στις διαφάνειες συνεπή δομή ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συνηθισμένες διατάξεις είναι:

- **Title Slide**: Περιέχει δεσμευτικές θέσεις τίτλου και υποτίτλου.
- **Title and Content**: Περιέχει δεσμευτική θέση τίτλου και γενικής χρήσης δεσμευτική θέση περιεχομένου.
- **Blank**: Δεν περιέχει δεσμευτικές θέσεις και είναι χρήσιμη όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομιάς Διάταξης**

Μια παρουσίαση έχει τρία συναφή επίπεδα:

1. Μια [κύρια διαφάνεια](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/) ορίζει το θέμα, τη διαμοιραζόμενη μορφοποίηση, τα υποβάθρα και τα κοινά αντικείμενα.
1. Μια [διάταξη διαφάνειας](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/) ανήκει σε μια κύρια διαφάνεια και ορίζει μια συγκεκριμένη διάταξη δεσμευτικών θέσεων.
1. Μια [κανονική διαφάνεια](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/) χρησιμοποιεί μία διάταξη και αποθηκεύει το περιεχόμενο που εισήχθηκε για εκείνη τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, ενώ η διάταξη κληρονομεί από την κύρια διαφάνειά της. Μια τιμή που ορίζεται άμεσα σε μια κανονική διαφάνεια παρακάμπτει την κληρονομημένη τιμή στο ίδιο επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα των δεσμευτικών θέσεων δημιουργούνται από την επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις δεσμευτικές θέσεις ανήκει στην κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες δεσμευτικές θέσεις σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας νέας δεσμευτικής θέσης σε διάταξη αργότερα δεν προσθέτει αυτόματα αντίστοιχο σχήμα δεσμευτικής θέσης σε υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Η αλλαγή κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπάρχουσων δεσμευτικών θέσεων σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που είναι ήδη σε χρήση, εξετάστε τις εξαρτημένες διαφάνειες και αξιολογήστε το τελικό αποτέλεσμα.
- Μια διάταξη που χρησιμοποιείται ακόμη από κάποια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες σε άλλη διάταξη ή αφαιρέστε μόνο τις διατάξεις που δεν χρησιμοποιούνται.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε το [Slide Master](/slides/el/php-java/slide-master/).

Για απόκρυψη κληρονομημένων λογότυπων ή διακοσμητικών σχημάτων κύριας διαφάνειας σε μία διαφάνεια ή μέσω κοινής διάταξης, δείτε το [Control the Visibility of Master Graphics](/slides/el/php-java/slide-master/). Το παράδειγμα συγκρίνει δύο διαφάνειες που χρησιμοποιούν την ίδια κύρια διαφάνεια.

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τα τυπικά ορισμένα του PowerPoint. Τα ονόματα διάταξης είναι επεξεργάσιμα από τον χρήστη και μπορούν να τοπικοποιηθούν, επομένως η επιλογή με βάση το όνομα είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πρότυπο προέλευσης.

Το παρακάτω παράδειγμα αναζητά **Title and Content** στην πρώτη κύρια διαφάνεια. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει σκόπιμα στην **Blank**. Ο δεύτερος έλεγχος null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διατάξεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της μεθόδου [Slide.setLayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα κανονικά σχήματα που προστέθηκαν απευθείας στη διαφάνεια. Ωστόσο, οι θέσεις των δεσμευτικών θέσεων, η κληρονομημένη μορφοποίηση και η αντιστοιχία μεταξύ των υπαρχόντων δεσμευτικών θέσεων και της νέας διάταξης μπορεί να αλλάξει, οπότε ελέγξτε το αποτέλεσμα όταν μεταβαίνετε μεταξύ εντελώς διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν τη δημιουργεί. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterlayoutslidecollection/#add) στη συλλογή διατάξεων της στοχευόμενης κύριας διαφάνειας.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Title and Content** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα των διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Προσθέστε μια διάταξη μόνο όταν το πρότυπο χρειάζεται πραγματικά μια επιπλέον επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διάταξη, επιλέξτε και επαναχρησιμοποιήστε την αντί να δημιουργήσετε διπλότυπο.

## **Προσθήκη Δεσμευτικών Θέσεων σε Διάταξη Διαφάνειας**

Η μέθοδος [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getPlaceholderManager) παρέχει έναν [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/) για την προσθήκη σχήματος δεσμευτικών θέσεων σε μια διάταξη.

| Δεσμευτική Θέση PowerPoint | Μέθοδος `LayoutPlaceholderManager` |
| -------------------------- | ----------------------------------- |
| ![Περιεχόμενο](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Περιεχόμενο (Κάθετη)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Κείμενο](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Κείμενο (Κάθετη)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Εικόνα](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Διάγραμμα](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Πίνακας](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Πολυμέσα](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Το παρακάτω παράδειγμα ελέγχει ότι η διάταξη **Blank** υπάρχει, προσθέτει τέσσερις δεσμευτικές θέσεις σε αυτήν και στη συνέχεια δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι δεσμευτικές θέσεις προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε το Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα δεσμευτικής θέσης σε αυτήν τη διαφάνεια.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι δεσμευτικές θέσεις στη διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Η αλλαγή κληρονομημένης μορφοποίησης ή της γεωμετρίας των υφιστάμενων δεσμευτικών θέσεων σε μια διάταξη μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια νεοεισαχθείσα δεσμευτική θέση διάταξης δεν συμπληρώνεται αυτόματα σε υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και εξετάστε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Μη Χρησιμοποιημένων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει αμετάβλητες τις διατάξεις που είναι ακόμη σε χρήση.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, πρώτα χρησιμοποιήστε τη μέθοδο [hasDependingSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#hasDependingSlides) ή [getDependingSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getDependingSlides). Αναθέστε τυχόν εξαρτημένες διαφάνειες πριν καλέσετε το [LayoutSlide.remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#remove). Η προσπάθεια αφαίρεσης μίας διάταξης που χρησιμοποιείται προκαλεί την εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μία διάταξη έχει το δικό της υποσέλιδο, αριθμό διαφάνειας και δεσμευτικές θέσεις ημερομηνίας‑ώρας. Χρησιμοποιήστε τη μέθοδο [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) για να ελέγξετε αυτές τις δεσμευτικές θέσεις για μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου όχι.

Το παρακάτω παράδειγμα επιλέγει μια διάταξη με ασφάλεια και κάνει τα στοιχεία υποσέλιδου ορατά:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Έλεγχος Ορατότητας Υποσέλιδου σε Κύρια Διαφάνεια και τις Παιδικές Διατάξεις**

Για να εφαρμόσετε συνεπή ρυθμίσεις υποσέλιδου σε όλη τη ιεραρχία μιας κύριας διαφάνειας, χρησιμοποιήστε τη μέθοδο [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Οι μέθοδοι διάδοσης του [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslideheaderfootermanager/) λειτουργούν στην κύρια διαφάνεια, στις εξαρτημένες διατάξεις και στις κανονικές διαφάνειες· δεν στοχεύουν μόνο μία κανονική διαφάνεια.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ μιας κύριας διαφάνειας και μιας διάταξης διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το θέμα και τη διαμοιραζόμενη μορφοποίηση της παρουσίασης. Μια διάταξη διαφάνειας ανήκει σε μια κύρια διαφάνεια και ορίζει μία επαναχρησιμοποιήσιμη διάταξη δεσμευτικών θέσεων. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν το περιεχόμενο της διαφάνειας.

**Μπορώ να αντιγράψω μια διάταξη διαφάνειας από μία παρουσίαση σε άλλη;**

Ναι. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/globallayoutslidecollection/#addClone). Όταν γίνεται αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιεί η πηγαία διάταξη.

**Τι συμβαίνει όταν τροποποιώ μια διάταξη που χρησιμοποιείται ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές στη διάταξη εκτός εάν παρακάμψουν τη μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των δεσμευτικών θέσεων και η κληρονομημένη στυλιζαρίσθηση μπορούν έτσι να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε το [getDependingSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getDependingSlides) για να εντοπίσετε τις επηρεαζόμενες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι συμβαίνει εάν αφαιρέσω μια διάταξη που βρίσκεται ακόμη σε χρήση;**

Το Aspose.Slides ρίχνει μια [PptxEditException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε τη μέθοδο [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε μόνο τις μη αναφερόμενες διατάξεις.