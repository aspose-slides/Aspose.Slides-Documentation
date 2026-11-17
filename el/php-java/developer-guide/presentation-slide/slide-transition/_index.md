---
title: Διαχείριση μεταβάσεων διαφανειών σε παρουσιάσεις με PHP
linktitle: Μετάβαση διαφάνειας
type: docs
weight: 80
url: /el/php-java/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- εφαρμογή μετάβασης διαφάνειας
- προχωρημένη μετάβαση διαφάνειας
- μετάβαση Morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφανειών, ρυθμίστε την αυτόματη προοδευτική αλλαγή διαφανειών και προσαρμόστε το Morph και άλλα εφέ μετάβασης με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφανειών ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας προβολής. Με το Aspose.Slides for PHP via Java, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την πρόοδο με κλικ του ποντικιού ή χρονοδιακόπτη και να προσαρμόσετε επιλογές ειδικές για το εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα PHP για την εφαρμογή μεταβάσεων, τον καθορισμό ακριβούς διάρκειας των μεταβάσεων, τη διαχείριση του χρόνου των διαφανειών και τη δημιουργία μιας μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις ρυθμίσεις μετάβασης της διαφάνειας μέσω του [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) με μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), έπειτα αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει τη μετάβαση Circle στην πρώτη διαφάνεια και τη μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Μετάβαση Wheel**

Η μέθοδος [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) ελέγχει πόσοι ακτινικοί τομείς αποκαλύπτουν τη διαφάνειά προορισμού. Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) για να επιλέξετε Wheel από την [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), έπειτα καλέστε το [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) για πρόσβαση στις ρυθμίσεις του [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

Το παράδειγμα δημιουργεί δύο ζεύγη διαφανειών που είναι πανομοιότυπα. Κάθε ζεύγος ξεκινά με μια μαύρη διαφάνεια και τελειώνει με μια διαφάνεια καλυμμένη από ένα χρυσό ορθογώνιο. Η διαφάνεια 2 χρησιμοποιεί μία ακτίνα και η διαφάνεια 4 χρησιμοποιεί οκτώ. Και οι δύο μεταβάσεις χρησιμοποιούν την ίδια αργή ταχύτητα, ορισμένη με το [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), και μια ρητή διάρκεια 8 000 χιλιοστέλαιων, ορισμένη με το [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ανοίξτε την αποθηκευμένη παρουσίαση στο PowerPoint και ξεκινήστε την προβολή διαφανειών. Προχωρήστε από τη διαφάνεια 1 στη διαφάνεια 2 για να δείτε ένα μόνο κυκλικό σάρωση. Στη συνέχεια προχωρήστε από τη διαφάνεια 3 στη διαφάνεια 4 για να δείτε οκτώ ακτίνες να αποκαλύπτουν ταυτόχρονα το ίδιο ορθογώνιο.

## **Προσθήκη Προηγμένων Μεταβάσεων Διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο ώρα μια διαφάνεια παραμένει στην οθόνη και αν ένα κλικ του ποντικιού προχωρά την προβολή. Οι παρακάτω μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) επιτρέπει στον θεατή να προχωρήσει με κλικ του ποντικιού.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) ενεργοποιεί αυτόματη πρόοδο.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) καθορίζει την καθυστέρηση πριν την αυτόματη πρόοδο, σε χιλιοστέλαιους.

Ενεργοποιήστε τόσο το κλικ όσο και την προγραμματισμένη πρόοδο ώστε ο θεατής να μπορεί να προχωρήσει με κλικ ή να περιμένει τον χρονοδιακόπτη. Για χρήση μόνο του χρονοδιακόπτη, περάστε `false` στο [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Η καθυστέρηση ελέγχει πότε η προβολή προχωρά· δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα αναθέτει διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί αυτόματη πρόοδο μετά από 3, 5 και 7 δευτερόλεπτα αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προχωρήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Για να ελέγξετε αν η χρονική πρόοδος είναι ενεργοποιημένη, καλέστε το [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Μία αποθηκευμένη καθυστέρηση από μόνη της δεν υποδεικνύει ότι ο χρονοδιακόπτης είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το αποθηκευμένο αρχείο, αναφέρει κάθε ενεργό χρονοδιακόπτη και απενεργοποιεί την αυτόματη πρόοδο για διαφάνειες με καθυστέρηση μεγαλύτερη από δύο δευτερόλεπτα. Ενεργοποιεί κλικ του ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Έλεγχος Χρόνου Μετάβασης με Ακρίβεια**

Χρησιμοποιήστε το [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) για να ορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστέλαιους. Η μέθοδος [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας εκθέτει αυτές τις ρυθμίσεις μέσω του [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Ορίζει τη διάρκεια του εφέ μετάβασης σε χιλιοστέλαιους. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ορίζει την καθυστέρηση πριν η διαφάνεια προχωρήσει αυτόματα, σε χιλιοστέλαιους. Περάστε `true` στο [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) για να ενεργοποιήσετε αυτόν τον χρονοδιακόπτη. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Επιλέγει μια προεπιλεγμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν έχει οριστεί ρητή διάρκεια. |

Το [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) ελέγχει μόνο το εφέ της μετάβασης· δεν καθορίζει πόσο χρόνο παραμένει η διαφάνεια ορατή. Ρυθμίστε την αυτόματη καθυστέρηση προοδευτικά ξεχωριστά. Όταν δεν ορίζεται ρητή διάρκεια, το Aspose.Slides υπολογίζει τη διάρκεια του εφέ από τον τύπο της μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Τα διακριτά μπαρ δείχνουν τη διάρκεια της μετάβασης 750 ms και τη ρύθμιση αυτόματης προόδου 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Το κοινό παράδειγμα δίνει σε κάθε διαφάνεια μια μετάβαση Fade 750 ms και ξεχωριστά ενεργοποιεί την αυτόματη πρόοδο στα 5 000 ms. Η διάρκεια της μετάβασης ελέγχει το εφέ· η πρόοδος ελέγχει πότε θα φύγει η διαφάνεια. Αυτά τα μπαρ είναι σχήματα ρυθμίσεων, όχι μετρημένο συνδυαστικό χρονοδιάγραμμα.*
<!-- visual-explanation:slide-transition:end -->

### **Εφαρμογή της Ίδιας Διάρκειας σε Κάθε Διαφάνεια**

Για σταθερό ρυθμό, εφαρμόστε το ίδιο εφέ και την ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από την [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστέλαιων. Ενεργοποιεί ξεχωριστά την αυτόματη πρόοδο μετά από 5 000 χιλιοστέλαιους και απενεργοποιεί την πρόοδο με κλικ του ποντικιού, έπειτα αποθηκεύει το αποτέλεσμα ως PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Ρυθμίστε την αυτόματη προώθηση ανεξάρτητα από τη διάρκεια του εφέ.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ορισμός Διαφορετικών Διάρκειών για Ατομικές Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να χρησιμοποιούν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για μια διαφάνεια τίτλου και μια πιο μακριά για μια εισαγωγή τμήματος. Αυτό το παράδειγμα θέτει 500 χιλιοστέλαιους για την πρώτη διαφάνεια και 1 200 χιλιοστέλαιους για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Συντονισμός Μεταβάσεων με Αναπαραγωγή Animation**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/php-java/convert-powerpoint-to-animated-gif/), μιας [HTML5 presentation](/slides/el/php-java/export-to-html5/) ή ενός [video](/slides/el/php-java/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν την εξαγωγή για να ταιριάζουν με τον προγραμματισμένο ρυθμό. Για παράδειγμα, χρησιμοποιήστε μια εξασθένιση 600 ms μεταξύ σκηνών και προσαρμόστε την καθυστέρηση προόδου κάθε διαφάνειας ξεχωριστά ώστε να υπάρχει χρόνος για αφήγηση ή περιεχόμενο.

Για GIF και βίντεο, συντονίστε το ρυθμό πλαισίου της εξόδου με τη διάρκεια του εφέ: 600 ms αντιστοιχούν σε 18 καρέ σε 30 fps. Στο HTML5, ενεργοποιήστε τις animated μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες επιλογές εφέ και χρόνου της επιλεγμένης μορφής εξόδου και προεπισκοπήστε το αποτέλεσμα για να επιβεβαιώσετε τον συγχρονισμό.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Καλέστε το [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) πριν τροποποιήσετε τη μετάβαση για να διαπιστώσετε αν υπάρχει αποθηκευμένη ρητή τιμή. Μια τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή υποδεικνύει τη διάρκεια σε χιλιοστέλαιους. Η μη ορισμένη τιμή δεν είναι η υπολογισμένη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο της μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) για να προσδιορίσει αυτή τη διάρκεια. Ο ορισμός τύπου μετάβασης μπορεί να αρχικοποιήσει μια διάρκεια, επομένως ελέγξτε πρώτα τις αρχικές ρυθμίσεις.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Μετάβαση Morph**

Η μετάβαση Morph ανιματοποιεί τις αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στο κλώνο και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό δίνει στα αντίστοιχα αντικείμενα κάτι για ανιματοποίηση μεταξύ της αρχικής και της τροποποιημένης τους κατάστασης.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ορθογώνιο κειμένου, κλωνοποιεί τη διαφάνεια και αλλάζει τη θέση και το μέγεθος του ορθογωνίου στο κλώνο. Στη συνέχεια επιλέγει Morph από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε έναν προγράμματα ανάγνωσης παρουσιάσεων που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια μιας προβολής διαφανειών.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Τύποι Μετάβασης Morph**

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) ελέγχει πώς το Morph αντιστοιχεί και ανιματοποιεί το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) αντιμετωπίζει κάθε σχήμα ως ολόκληρο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) ανιματοποιεί το κείμενο αντιστοιχίζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) ανιματοποιεί το κείμενο αντιστοιχίζοντας χαρακτήρες όπου είναι δυνατόν.

Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) για να επιλέξετε Morph πριν προσπελάσετε το [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Η τιμή τότε επιστρέφει ένα αντικείμενο [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), του οποίου η μέθοδος [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) επιλέγει τη λειτουργία αντιστοίχησης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και διαμορφώνει τη δεύτερη διαφάνεια ώστε να χρησιμοποιεί ανιματοποίηση Morph βάσει λέξης.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Εφέ Μετάβασης**

Ορισμένες μεταβάσεις εκθέτουν πρόσθετες επιλογές, όπως κατεύθυνση ή αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τη μετάβαση που επιλέχθηκε με το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Ορίστε πρώτα τον τύπο, έπειτα χρησιμοποιήστε το κατάλληλο αντικείμενο μετάβασης από το [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Καλεί το [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) μέσω του [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστέλαιους. Χρησιμοποιήστε το [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) όταν αρκεί μια προεπιλεγμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) — Slow, Medium ή Fast — και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ της μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προόδου.

**Μπορώ να συσχετίσω ήχο με μια μετάβαση και να τον επαναλαμβάνω;**

Ναι. Αναθέστε ενσωματωμένο ήχο με το [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), περάστε το StartSound από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) στο [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) και ενεργοποιήστε το [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) με `true`. Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην προβολή.

**Ποιος είναι ο πιο γρήγορος τρόπος να εφαρμόσω την ίδια μετάβαση σε όλες τις διαφάνειες;**

Δεσμεύστε μια επανάληψη πάνω στη συλλογή [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) της παρουσίασης και καλέστε το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) με την ίδια τιμή για τη μετάβαση κάθε διαφάνειας. Ορίστε τυχόν χρόνους και επιλογές εφέ στην ίδια επανάληψη για να διατηρήσετε συνεπή συμπεριφορά σε όλες τις διαφάνειες.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Καλείστε το [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) στο αποτέλεσμα του [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); η τιμή None σημαίνει ότι δεν έχει εφαρμοστεί κάποιο εφέ μετάβασης.