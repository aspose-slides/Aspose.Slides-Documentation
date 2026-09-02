---
title: Διαχείριση τμημάτων διαφανειών σε παρουσιάσεις με PHP
linktitle: Τμήμα Διαφάνειας
type: docs
weight: 90
url: /el/php-java/slide-section/
keywords:
- δημιουργία τμήματος
- προσθήκη τμήματος
- επεξεργασία τμήματος
- αλλαγή τμήματος
- όνομα τμήματος
- ανάκτηση διαφανειών τμήματος
- επεξεργασία διαφανειών τμήματος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τα τμήματα διαφανειών με Aspose.Slides για PHP μέσω Java: δημιουργία, μετονομασία, επαναδιάταξη, ανάκτηση και επεξεργασία διαφανειών τμημάτων σε παρουσιάσεις PPTX."
---
## **Εισαγωγή**

Τα τμήματα οργανώνουν διαδοχικές διαφάνειες σε ονομαστικές ομάδες χωρίς να αλλάζουν το περιεχόμενο της διαφάνειας. Με το Aspose.Slides για PHP μέσω Java, μπορείτε να δημιουργείτε, να επαναδιατάσσετε, να μετονομάζετε, να ελέγχετε και να αφαιρείτε τμήματα μέσω της μεθόδου [Presentation::getSections](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSections).

Τα τμήματα είναι ιδιαίτερα χρήσιμα όταν:

- μια μεγάλη παρουσίαση χρειάζεται να χωριστεί σε λογικά θέματα ή κεφάλαια·
- διαφορετικές ομάδες διαφανειών ανατίθενται σε διαφορετικούς συνεργάτες·
- οι διαφάνειες χρειάζεται να υποβληθούν σε επεξεργασία, μεταφορά ή συγχώνευση ως ομάδες.

Επιλέξτε σύντομα ονόματα τμημάτων που περιγράφουν τον σκοπό των ομαδοποιημένων διαφανειών. Επειδή τα τμήματα αποτελούν μέρος της δομής της παρουσίασης, χρησιμοποιήστε τα API τμημάτων για να προσδιορίσετε τη συμμετοχή αντί να την εξάγετε από τις θέσεις των διαφανειών.

## **Δημιουργία και Διαχείριση Τμημάτων**

Χρησιμοποιήστε [SectionCollection::addSection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionCollection/#addSection) για να δημιουργήσετε ένα τμήμα ορίζοντας το όνομα και τη διαφάνεια εκκίνησης. Το Aspose.Slides καθορίζει ποιες διαφάνειες ανήκουν στο τμήμα από την τρέχουσα δομή τμημάτων της παρουσίασης.

Το ίδιο [SectionCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionCollection/) σας επιτρέπει επίσης να:

- μετακινήσετε ένα τμήμα μαζί με τις διαφάνειές του χρησιμοποιώντας [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- αφαιρέσετε μόνο τον ορισμό του τμήματος με [SectionCollection::removeSection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionCollection/#removeSection), το οποίο διατηρεί τις διαφάνειές του·
- αφαιρέσετε ένα τμήμα και τις διαφάνειές του με [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- προσθέσετε ένα κενό τμήμα στο τέλος με [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionCollection/#appendEmptySection).

Το παρακάτω παράδειγμα δημιουργεί δύο τμήματα, μετακινεί ένα από αυτά, το αφαιρεί μαζί με τις διαφάνειές του και προσθέτει ένα κενό τμήμα:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

Μετά από αυτές τις ενέργειες, η παρουσίαση περιέχει το τμήμα `Introduction` με τις διαφάνειές του και ένα κενό τμήμα `Appendix`. Το τμήμα `Results` και οι διαφάνειές του έχουν αφαιρεθεί.

## **Μετονομασία Τμημάτων**

Για να μετονομάσετε ένα τμήμα, καλέστε τη μέθοδο [Section::setName](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#setName). Οι διαφάνειες και η θέση του τμήματος παραμένουν αμετάβλητες.

Το παρακάτω παράδειγμα δημιουργεί ένα τμήμα και αλλάζει το όνομά του:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **Ανάκτηση Διαφανειών από Τμήματα**

Η μέθοδος [Presentation::getSections](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSections) επιστρέφει μια [SectionCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionCollection/) που μπορείτε να επεξεργαστείτε με βάση το δείκτη. Για κάθε [Section](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/), καλέστε [Section::getSlidesListOfSection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getSlidesListOfSection) για να λάβετε τις διαφάνειες που ανήκουν αυτή τη στιγμή σε αυτήν. Η μέθοδος επιστρέφει μια [SectionSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionSlideCollection/), η οποία παρέχει αριθμό και πρόσβαση με δείκτη.

Το παρακάτω παράδειγμα δημιουργεί δύο γεμάτα τμήματα και ένα κενό τμήμα, στη συνέχεια εκτυπώνει για κάθε τμήμα το [name](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getName), το [identifier](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getSectionId), τη [starting slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getStartedFromSlide), τον αριθμό διαφανειών και τους αριθμούς διαφανειών. Χρησιμοποιεί [SectionCollection::get_Item](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionCollection/#get_Item) και [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/el/php-java/aspose.slides/SectionSlideCollection/#get_Item) για πρόσβαση με δείκτη. Για το κενό τμήμα, η επιστρεφόμενη συλλογή έχει μέγεθος μηδέν και δεν καλείται το `get_Item`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Η συμμετοχή σε τμήμα καθορίζεται από τη δομή τμημάτων της παρουσίασης. Μην υπολογίζετε χειροκίνητα το εύρος ενός τμήματος από το [Section::getStartedFromSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getStartedFromSlide), τους δείκτες διαφανειών και τη διαφάνεια εκκίνησης του επόμενου τμήματος.

Οι δομικές επεξεργασίες μπορούν να αλλάξουν τόσο τις διαφάνειες που επιστρέφονται για ένα τμήμα όσο και τους αριθμούς τους. Αυτό περιλαμβάνει επαναδιάταξη διαφανειών, κλωνοποίηση μιας διαφάνειας σε τμήμα, μετακίνηση ενός τμήματος μαζί με τις διαφάνειές του, αφαίρεση διαφανειών και αφαίρεση τμημάτων. Το επόμενο παράδειγμα καλεί το [Section::getSlidesListOfSection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getSlidesListOfSection) μετά από κάθε τέτοια αλλαγή αντί να διατηρεί υποθέσεις για τα παλαιά όρια του τμήματος.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

Καλέστε ξανά το [Section::getSlidesListOfSection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getSlidesListOfSection) όποτε διαφάνειες ή τμήματα επαναδιατάσσονται, κλωνοποιούνται, μετακινούνται ή αφαιρούνται. Αυτό διατηρεί τη μεταγενέστερη επεξεργασία ευθυγραμμισμένη με την τρέχουσα δομή της παρουσίασης.

Η μορφή PPT (PowerPoint 97–2003) δεν διατηρεί τα μεταδεδομένα τμημάτων. Χρησιμοποιήστε αυτή τη διαδικασία με μορφότυπο που υποστηρίζει τμήματα, όπως το PPTX· η μετατροπή σε PPT αφαιρεί τη δομή τμημάτων που απαιτείται για μετέπειτα επανάληψη.

## **Συχνές Ερωτήσεις**

**Διατηρούνται τα τμήματα όταν αποθηκεύεται στο μορφότυπο PPT (PowerPoint 97–2003);**

Όχι. Η μορφή PPT δεν υποστηρίζει μεταδεδομένα τμημάτων, επομένως η ομαδοποίηση τμημάτων χάνεται κατά την αποθήκευση σε .ppt.

**Μπορεί ένα ολόκληρο τμήμα να είναι «κρυφό»;**

Όχι. Ένα τμήμα δεν διαθέτει κατάσταση ορατότητας. Για να κρύψετε τα περιεχόμενά του, καλέστε [Slide::setHidden](https://reference.aspose.com/slides/el/php-java/aspose.slides/Slide/#setHidden) για κάθε διαφάνεια του τμήματος.

**Πώς μπορώ να βρω το τμήμα που περιέχει μια διαφάνεια;**

Κάντε βρόχο στη συλλογή που επιστρέφεται από το [Presentation::getSections](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getSections), καλέστε [Section::getSlidesListOfSection](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getSlidesListOfSection) για κάθε τμήμα και συγκρίνετε τις επιστρεφόμενες διαφάνειες με τη διαφάνεια-στόχο. Για ένα μη κενό τμήμα, το [Section::getStartedFromSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/Section/#getStartedFromSlide) επιστρέφει την πρώτη διαφάνειά του· για ένα κενό τμήμα, επιστρέφει `null`.