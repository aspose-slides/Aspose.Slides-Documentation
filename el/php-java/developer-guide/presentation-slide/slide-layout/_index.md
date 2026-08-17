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
- PHP
- Aspose.Slides
description: "Εφαρμόστε, δημιουργήστε και τροποποιήστε διατάξεις διαφάνειας στο Aspose.Slides για PHP μέσω Java, προσθέστε δεσμευτικές θέσεις, αφαιρέστε αχρησιμοποίητες διατάξεις και ελέγξτε την ορατότητα του υποσέλιδου."
---
## **Επισκόπηση**

Ένα διάταξη διαφάνειας ορίζει τις θέσεις και τη μορφοποίηση των δεσμευτικών θέσεων όπως τίτλοι, κείμενο, εικόνες, διαγράμματα και πίνακες. Η εφαρμογή μιας διάταξης δίνει στις διαφάνειες μια συνεπή δομή ενώ επιτρέπει σε κάθε διαφάνεια να περιέχει το δικό της περιεχόμενο.

Οι πιο συνηθισμένες διατάξεις περιλαμβάνουν:

- **Διαφάνεια Τίτλου**: Περιέχει δεσμευτικές θέσεις τίτλου και υποτίτλου.
- **Τίτλος και Περιεχόμενο**: Περιέχει μια δεσμευτική θέση τίτλου και μια γενική δεσμευτική θέση περιεχομένου.
- **Κενό**: Δεν περιέχει δεσμευτικές θέσεις περιεχομένου και είναι χρήσιμο όταν κάθε σχήμα θα τοποθετηθεί χειροκίνητα.

## **Κατανόηση Κληρονομίας Διατάξεων**

Μια παρουσίαση έχει τρία σχετικά επίπεδα:

1. Μια [κύρια διαφάνεια](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/) ορίζει το θέμα, τη κοινή μορφοποίηση, τα παρασκήνια και τα κοινά αντικείμενα.
2. Μια [διαφάνεια διάταξης](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/) ανήκει σε μια κύρια διαφάνεια και ορίζει μια συγκεκριμένη διάταξη δεσμευτικών θέσεων.
3. Μια [κανονική διαφάνεια](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/) χρησιμοποιεί μια διάταξη και αποθηκεύει το περιεχόμενο που εισήχθη για αυτή τη διαφάνεια.

Μια κανονική διαφάνεια κληρονομεί το θέμα και τη μορφοποίηση από τη διάταξή της, και η διάταξη κληρονομεί από τη κύρια διαφάνειά της. Μια τιμή που ορίζεται απευθείας σε μια κανονική διαφάνεια αντικαθιστά την κληρονομημένη τιμή σε αυτό το επίπεδο. Όταν δημιουργείται μια κανονική διαφάνεια, τα σχήματα των δεσμευτικών θέσεων παράγονται από τη επιλεγμένη διάταξη, ενώ το περιεχόμενο που εισάγεται σε αυτές τις δεσμευτικές θέσεις ανήκει στην κανονική διαφάνεια.

Προσθέστε τις απαιτούμενες δεσμευτικές θέσεις σε μια διάταξη πριν δημιουργήσετε διαφάνειες από αυτήν. Η προσθήκη μιας άλλης δεσμευτικής θέσης σε μια διάταξη αργότερα δεν προσθέτει αυτόματα το αντίστοιχο σχήμα δεσμευτικής θέσης στις υπάρχουσες κανονικές διαφάνειες.

Αυτή η σχέση έχει δύο σημαντικές συνέπειες:

- Αλλαγή της κληρονομημένης μορφοποίησης ή της υπάρχουσας γεωμετρίας δεσμευτικών θέσεων σε μια διάταξη μπορεί να ενημερώσει κάθε διαφάνεια που εξαρτάται από αυτήν. Πριν επεξεργαστείτε μια διάταξη που χρησιμοποιείται ήδη, ελέγξτε τις εξαρτημένες διαφάνειες και εξετάστε την προκύπτουσα παρουσίαση.
- Μια διάταξη που χρησιμοποιείται ακόμα από κάποια διαφάνεια δεν μπορεί να αφαιρεθεί. Αναθέστε πρώτα τις εξαρτημένες διαφάνειες σε άλλη διάταξη ή αφαιρέστε μόνο τις αχρησιμοποίητες διατάξεις.

Για περισσότερες πληροφορίες σχετικά με το ανώτερο επίπεδο αυτής της ιεραρχίας, δείτε το [Κύρια Διαφάνεια](/slides/el/php-java/slide-master/).

## **Επιλογή και Εφαρμογή Διάταξης Διαφάνειας**

Χρησιμοποιήστε έναν τύπο διάταξης όταν η παρουσίαση ακολουθεί τις τυπικές ορισμούς διαρρύθμισης του PowerPoint. Τα ονόματα διατάξεων είναι επεξεργάσιμα από τον χρήστη και μπορούν να εντοπιστούν, έτσι η επιλογή με βάση το όνομα είναι λιγότερο αξιόπιστη εκτός εάν ελέγχετε το πρότυπο προέλευσης.

Το παρακάτω παράδειγμα αναζητά το **Τίτλος και Περιεχόμενο** στην πρώτη κύρια διαφάνεια. Εάν αυτή η διάταξη δεν είναι διαθέσιμη, επιστρέφει σκόπιμα στο **Κενό**. Ο δεύτερος έλεγχος για null είναι απαραίτητος επειδή μια παρουσίαση μπορεί να περιέχει μόνο προσαρμοσμένες διαρρυθμίσεις. Η επιλεγμένη διάταξη εφαρμόζεται στη πρώτη κανονική διαφάνεια μέσω της μεθόδου [Slide.setLayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#setLayoutSlide).

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

Η αλλαγή της διάταξης μιας διαφάνειας δεν αφαιρεί τα συνηθισμένα σχήματα που προστέθηκαν άμεσα στη διαφάνεια. Ωστόσο, οι θέσεις των δεσμευτικών θέσεων, η κληρονομημένη μορφοποίηση και η αντιστοιχία μεταξύ των υπαρχουσών δεσμευτικών θέσεων και της νέας διάταξης μπορούν να αλλάξουν, γι' αυτό ελέγξτε το αποτέλεσμα όταν αλλάζετε μεταξύ σημαντικά διαφορετικών διατάξεων.

## **Προσθήκη Διάταξης Διαφάνειας**

Η επιλογή και η δημιουργία είναι ξεχωριστές λειτουργίες. Το προηγούμενο παράδειγμα επιλέγει μια υπάρχουσα διάταξη· δεν δημιουργεί μία. Για να δημιουργήσετε μια διάταξη, καλέστε τη μέθοδο [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterlayoutslidecollection/#add) στη συλλογή διατάξεων του στοχευόμενου κυρίου.

Το παρακάτω παράδειγμα προσθέτει πάντα μια νέα διάταξη **Τίτλος και Περιεχόμενο** με όνομα `Report Title and Content`, στη συνέχεια προσθέτει μια κανονική διαφάνεια βασισμένη σε αυτήν. Τα ονόματα των διατάξεων πρέπει να είναι μοναδικά μέσα στη συλλογή.

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

Προσθέστε μια διάταξη μόνο όταν το πρότυπο πραγματικά χρειάζεται μια ακόμη επαναχρησιμοποιήσιμη δομή. Εάν υπάρχει ήδη μια κατάλληλη διάταξη, επιλέξτε και επαναχρησιμοποιήστε την αντί να δημιουργήσετε ένα αντίγραφο.

## **Προσθήκη Δεσμευτικών Θέσεων σε Διάταξη Διαφάνειας**

Η μέθοδος [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getPlaceholderManager) παρέχει έναν [LayoutPlaceholderManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/) για την προσθήκη σχημάτων δεσμευτικών θέσεων σε μια διάταξη.

| Δεσμευτική Θέση PowerPoint | `LayoutPlaceholderManager` Method |
| --------------------------- | --------------------------------- |
| ![Περιεχόμενο](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Περιεχόμενο (Κατακόρυφο)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Κείμενο](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Κείμενο (Κατακόρυφο)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Εικόνα](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Διάγραμμα](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Πίνακας](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Πολυμέσα](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Διαδικτυακή Εικόνα](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Το παρακάτω παράδειγμα ελέγχει ότι η διάταξη **Κενό** υπάρχει, προσθέτει τέσσερις δεσμευτικές θέσεις σε αυτήν και στη συνέχεια δημιουργεί μια κανονική διαφάνεια που χρησιμοποιεί τη τροποποιημένη διάταξη. Η σειρά είναι σκόπιμη: οι δεσμευτικές θέσεις προστίθενται πριν δημιουργηθεί η κανονική διαφάνεια, ώστε η Aspose.Slides να μπορεί να δημιουργήσει τα αντίστοιχα σχήματα δεσμευτικών θέσεων σε αυτήν τη διαφάνεια.

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

![Οι δεσμευτικές θέσεις στην διάταξη διαφάνειας](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Η αλλαγή της κληρονομημένης μορφοποίησης ή της γεωμετρίας των υπάρχουσας δεσμευτικών θέσεων της διάταξης μπορεί να επηρεάσει τις εξαρτημένες διαφάνειες. Μια νέα προστιθέμενη δεσμευτική θέση διάταξης δεν προστίθεται αυτόματα στις υπάρχουσες κανονικές διαφάνειες. Δοκιμάστε τις αλλαγές διάταξης σε αντίγραφο της παρουσίασης και ελέγξτε κάθε εξαρτημένη διαφάνεια.
{{% /alert %}}

## **Αφαίρεση Αχρησιμοποίητων Διατάξεων Διαφάνειας**

Χρησιμοποιήστε τη μέθοδο [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε διατάξεις που δεν αναφέρονται από καμία κανονική διαφάνεια. Η μέθοδος αφήνει αμετάβλητες τις διατάξεις που εξακολουθούν να χρησιμοποιούνται.

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

Για να αφαιρέσετε μια συγκεκριμένη διάταξη, πρώτα χρησιμοποιήστε τη μέθοδ│ό [hasDependingSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#hasDependingSlides) ή [getDependingSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getDependingSlides). Αναθέστε εκ νέου τυχόν εξαρτημένες διαφάνειες πριν καλέσετε [LayoutSlide.remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#remove). Η προσπάθεια αφαίρεσης μιας χρησιμοποιούμενης διάταξης προκαλεί ένα [PptxEditException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxeditexception/).

## **Έλεγχος Ορατότητας Υποσέλιδου σε Διάταξη Διαφάνειας**

Μια διάταξη έχει το δικό της υποσέλιδο, αριθμό διαφάνειας και δεσμευτικές θέσεις ημερομηνίας‑ώρας. Χρησιμοποιήστε τη μέθοδο [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) για να ελέγξετε αυτές τις δεσμευτικές θέσεις για μία διάταξη. Αυτό είναι χρήσιμο όταν, για παράδειγμα, οι διατάξεις περιεχομένου πρέπει να εμφανίζουν υποσέλιδα ενώ οι διατάξεις τίτλου δεν πρέπει.

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

## **Έλεγχος Ορατότητας Υποσέλιδου σε Κύρια Διαφάνεια και τις Παιδικές Διατάξεις της**

Για να εφαρμόσετε συνεπείς ρυθμίσεις υποσέλιδου σε όλη τη ιεραρχία μιας κύριας διαφάνειας, χρησιμοποιήστε τη μέθοδο [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Οι μέθοδοι διάδοσης του [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslideheaderfootermanager/) λειτουργούν στη κύρια διαφάνεια και στις εξαρτημένες διαρρυθμίσεις διαφάνειας και κανονικές διαφάνειες· δεν απευθύνονται μόνο σε μία κανονική διαφάνεια.

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

**Ποια είναι η Διαφορά μεταξύ Κύριας Διαφάνειας και Διάταξης Διαφάνειας;**

Μια κύρια διαφάνεια ορίζει το θέμα της παρουσίασης και τη κοινή μορφοποίηση. Μια διάταξη διαφάνειας ανήκει σε μια κύρια διαφάνεια και ορίζει μία επαναχρησιμοποιήσιμη διάταξη δεσμευτικών θέσεων. Οι κανονικές διαφάνειες χρησιμοποιούν αυτές τις διατάξεις και αποθηκεύουν περιεχόμενο ειδικό για κάθε διαφάνεια.

**Μπορώ να Αντιγράψω μια Διάταξη Διαφάνειας από μια Παρουσίαση σε Άλλη;**

Ναί. Προσθέστε ένα αντίγραφο στη συλλογή προορισμού με τη μέθοδο [addClone](https://reference.aspose.com/slides/el/php-java/aspose.slides/globallayoutslidecollection/#addClone). Κατά την αντιγραφή μεταξύ παρουσιάσεων, ελέγξτε επίσης τις γραμματοσειρές, τα θέματα, τις εικόνες και άλλους πόρους που χρησιμοποιούνται από τη διαρρύθμιση προέλευσης.

**Τι Συμβαίνει όταν Τροποποιήσω μια Διάταξη που Χρησιμοποιείται Ήδη;**

Οι εξαρτημένες διαφάνειες κληρονομούν τις αλλαγές της διάταξης εκτός εάν αντικαταστήσουν το επηρεασμένο μορφοποίηση ή τα αντικείμενα τοπικά. Η γεωμετρία των δεσμευτικών θέσεων και η κληρονομημένη μορφοποίηση μπορούν έτσι να αλλάξουν σε πολλές διαφάνειες ταυτόχρονα. Χρησιμοποιήστε [getDependingSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getDependingSlides) για να εντοπίσετε τις επηρεασμένες διαφάνειες πριν επεξεργαστείτε τη διάταξη.

**Τι Συμβαίνει αν Αφαιρέσω μια Διάταξη που Χρησιμοποιείται Ακόμα;**

Το Aspose.Slides προκαλεί ένα [PptxEditException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxeditexception/). Αναθέστε πρώτα τις εξαρτημένες διαφάνειες ή χρησιμοποιήστε το [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) για να αφαιρέσετε μόνο τις αδειακές διατάξεις.