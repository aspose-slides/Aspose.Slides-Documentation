---
title: Διαχείριση Μεταβάσεων Διαφάνειας σε Παρουσιάσεις με PHP
linktitle: Μετάβαση Διαφάνειας
type: docs
weight: 80
url: /el/php-java/slide-transition/
keywords:
- μετάβαση διαφάνειας
- προσθήκη μετάβασης διαφάνειας
- εφαρμογή μετάβασης διαφάνειας
- προηγμένη μετάβαση διαφάνειας
- μετάβαση Morph
- τύπος μετάβασης
- εφέ μετάβασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εφαρμόστε μεταβάσεις διαφάνειας, ρυθμίστε την αυτόματη προώθηση διαφάνειας και προσαρμόστε το Morph και άλλα εφέ μετάβασης με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφάνειας ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides για PHP μέσω Java, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την προώθηση με κλικ του ποντικιού ή χρονομετρητή, και να προσαρμόσετε επιλογές ειδικές για ένα εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα PHP για την εφαρμογή μεταβάσεων, τον ορισμό ακριβών χρόνων μετάβασης, τη διαχείριση του χρόνου διαφάνειας και τη δημιουργία μιας μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις ρυθμίσεις μετάβασης της διαφάνειας μέσω του [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) με μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), έπειτα αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Circle στην πρώτη διαφάνεια και μια μετάβαση Comb στη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

## **Μετάβαση Τροχού**

Η μέθοδος [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) ελέγχει πόσοι ακτινικοί τομείς αποκαλύπτουν τη διαφάνεια προορισμού. Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) για να επιλέξετε Wheel από το [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), έπειτα καλέστε το [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) για πρόσβαση στις ρυθμίσεις [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

Το παράδειγμα δημιουργεί δύο ταυτόσπαρτα ζεύγη διαφανειών. Κάθε ζεύγος ξεκινά με μια μαύρη διαφάνεια και τελειώνει με μια διαφάνεια καλυμμένη από ένα χρυσό ορθογώνιο. Η διαφάνεια 2 χρησιμοποιεί ένα τομή και η διαφάνεια 4 χρησιμοποιεί οκτώ. Και οι δύο μεταβάσεις χρησιμοποιούν την ίδια αργή ταχύτητα, ορισμένη με το [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), και μια ρητή διάρκεια 8 000 χιλιοστών του δευτερολέπτου, ορισμένη με το [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

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

Ανοίξτε την αποθηκευμένη παρουσίαση στο PowerPoint και ξεκινήστε την παρουσίαση διαφανειών. Προχωρήστε από τη διαφάνεια 1 στη διαφάνεια 2 για να δείτε ένα μοναδικό κυκλικό πέρασμα δεξιόστροφα. Στη συνέχεια προχωρήστε από τη διαφάνεια 3 στη διαφάνεια 4 για να δείτε οκτώ ακτινικούς τομείς να αποκαλύπτουν ταυτόχρονα το ίδιο ορθογώνιο.

## **Ξεθώριασμα μέσω μαύρου με τη μετάβαση Reveal**

Ορίστε τον τύπο μετάβασης της διαφάνειας προορισμού σε Reveal, έπειτα καλέστε το [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) στις ρυθμίσεις του [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/). Το παράδειγμα δημιουργεί μια πηγαία διαφάνεια σε τυρκουάζ και μια διαφάνεια προορισμού σε κοραλί, στη συνέχεια κλωνοποιεί και τις δύο. Κάθε ζεύγος χρησιμοποιεί την ίδια μεταβατική Reveal διάρκειας δύο δευτερολέπτων. Μόνο το δεύτερο ζεύγος ξεθωριάζει μέσω μαύρου.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ανοίξτε την αποθηκευμένη παρουσίαση στο PowerPoint και ξεκινήστε την παρουσίαση διαφανειών. Προχωρήστε από τη διαφάνεια 1 στη διαφάνεια 2 για να δείτε το τυρκουάζ να ξεθωριάζει απευθείας σε κοραλί. Στη συνέχεια προχωρήστε από τη διαφάνεια 3 στη διαφάνεια 4. Η οθόνη σκοτεινιάζει στιγμιαία σχεδόν στο μαύρο πριν εμφανιστεί η διαφάνεια κοραλί. Και οι δύο διαφάνειες διατηρούν τα αρχικά χρώματα φόντου.

Οι σειρές παρακάτω εμφανίζουν καρέ από το PowerPoint σε διαστήματα μισού δευτερολέπτου. Συγκρίνετε το μεσαίο καρέ σε κάθε σειρά για να δείτε το εφέ.

![Αναπαραγωγή PowerPoint με το ξεθώριασμα μέσω μαύρου απενεργοποιημένο (επάνω) και ενεργοποιημένο (κάτω). Μόνο η κάτω σειρά περνάει κοντά στο μαύρο.](reveal-through-black.png)

## **Προσθήκη Προηγμένης Μετάβασης Διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο καιρό παραμένει μια διαφάνεια στην οθόνη και αν ένα κλικ του ποντικιού προχωρά την παρουσίαση. Οι παρακάτω μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) επιτρέπει στον θεατή να προχωρήσει κάνοντας κλικ με το ποντίκι.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) ενεργοποιεί την αυτόματη προώθηση.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) καθορίζει την καθυστέρηση πριν την αυτόματη προώθηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε τόσο το κλικ όσο και την χρονομετρημένη προώθηση για να επιτρέψετε στον θεατή να προχωρήσει με κλικ ή να περιμένει τον χρονομετρητή. Για να χρησιμοποιήσετε μόνο τον χρονομετρητή, περάστε `false` στο [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Η καθυστέρηση ελέγχει πότε προχωρά η παρουσίαση· δεν ορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα εκχωρεί διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί αυτόματη προώθηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προωθούν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

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

Για να ελέγξετε αν η χρονομετρημένη προώθηση είναι ενεργή, καλέστε το [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Μια αποθηκευμένη καθυστέρηση από μόνη της δεν σημαίνει ότι το χρονομετρημένο είναι ενεργό.

Το επόμενο παράδειγμα ανοίγει το αποθηκευμένο παραπάνω αρχείο, αναφέρει κάθε ενεργό χρονομετρητή και απενεργοποιεί την αυτόματη προώθηση για διαφάνειες με καθυστέρηση μεγαλύτερη από δύο δευτερόλεπτα. Ενεργοποιεί κλικ ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

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

Χρησιμοποιήστε το [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) για να ορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η μέθοδος [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας εκθέτει αυτές τις ρυθμίσεις μέσω του [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Ορίζει τη διάρκεια του ίδιου του εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ορίζει την καθυστέρηση πριν η διαφάνεια προχωρήσει αυτόματα, σε χιλιοστά του δευτερολέπτου. Περάστε `true` στο [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) για να ενεργοποιήσετε αυτό το χρονόμετρο. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Επιλέγει μια προκαθορισμένη κατηγορία ταχύτητας από το [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν ορίζεται ακριβής διάρκεια. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) ελέγχει μόνο το εφέ μετάβασης· δεν προσδιορίζει πόσο καιρό παραμένει η διαφάνεια ορατή. Ρυθμίστε την αυτόματη καθυστέρηση προχώρησης ξεχωριστά. Όταν δεν ορίζεται ρητή διάρκεια, η Aspose.Slides υπολογίζει τη διάρκεια του εφέ από τον τύπο της μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Το κοινό παράδειγμα δίνει σε κάθε διαφάνεια μια μετάβαση Fade 750 ms και ενεργοποιεί ξεχωριστά την αυτόματη προώθηση στα 5 000 ms. Η διάρκεια της μετάβασης ελέγχει το εφέ· η προώθηση ελέγχει πότε θα φύγει η διαφάνεια. Αυτές οι γραμμές είναι σχήματα ρυθμίσεων, όχι μετρητό συνδυαστικό χρονοδιάγραμμα.*
<!-- visual-explanation:slide-transition:end -->

### **Εφαρμογή της Ίδιας Διάρκειας σε Κάθε Διαφάνεια**

Για συνεπή ρυθμό, εφαρμόστε το ίδιο εφέ και την ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει Fade από το [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστών του δευτερολέπτου. Ενεργοποιεί ξεχωριστά αυτόματη προώθηση μετά από 5 000 χιλιοστά του δευτερολέπτου και απενεργοποιεί την προώθηση με κλικ ποντικιού, έπειτα αποθηκεύει το αποτέλεσμα ως PPTX.

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

        // Ρύθμιση αυτόματης προώθησης ανεξάρτητα από τη διάρκεια του εφέ.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ορισμός Διαφορετικών Διοράσεων για Ατομικές Διαφάνειες**

Διάφορες διαφάνειες μπορούν να χρησιμοποιούν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για μια διαφάνεια τίτλου και μια μακρύτερη για μια εισαγωγή ενότητας. Αυτό το παράδειγμα ορίζει 500 χιλιοστά του δευτερολέπτου για την πρώτη διαφάνεια και 1 200 χιλιοστά του δευτερολέπτου για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

### **Συντονισμός Μεταβάσεων με την Κινούμενη Έξοδο**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/el/php-java/export-to-html5/), ή [video](/slides/el/php-java/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν από την εξαγωγή για να ταιριάζουν με τον επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε ένα ξεθώριασμα 600 χιλιοστών του δευτερολέπτου μεταξύ σκηνών και προσαρμόστε ξεχωριστά την καθυστέρηση προχώρησης κάθε διαφάνειας ώστε να υπάρχει χρόνο για αφήγηση ή περιεχόμενο.

Για GIF και βίντεο, συντονίστε τον ρυθμό καρέ εξόδου με τη διάρκεια του εφέ: 600 χιλιοστά του δευτερολέπτου αντιστοιχούν σε 18 καρέ στα 30 καρέ ανά δευτερόλεπτο. Σε HTML5, ενεργοποιήστε τις κινούμενες μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες εφέ και επιλογές χρονοδικού του επιλεγμένου μορφότυπου εξόδου και προεπισκοπήστε το αποτέλεσμα για επιβεβαίωση του συγχρονισμού.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Καλέστε το [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) πριν τροποποιήσετε τη μετάβαση για να προσδιορίσετε αν υπάρχει αποθηκευμένη ρητή τιμή. Μία τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή καθορίζει την αποθηκευμένη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογισμένη διάρκεια αναπαραγωγής: η Aspose.Slides χρησιμοποιεί τον τύπο της μετάβασης και την τιμή του [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) για να υπολογίσει αυτή τη διάρκεια. Ο ορισμός τύπου μετάβασης μπορεί να ξεκινήσει μια διάρκεια, γι' αυτό πρώτα ελέγξτε τις αρχικές ρυθμίσεις.

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

Η μετάβαση Morph ανιματοποιεί τις αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στην κλωνοποιημένη έκδοση και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό παρέχει στα αντίστοιχα αντικείμενα τη δυνατότητα να ανιματοποιηθούν μεταξύ των αρχικών και των τροποποιημένων τους καταστάσεων.

Το παρακάτω παράδειγμα δημιουργεί μια διαφάνεια με ένα πλεγμένο ορθογώνιο κείμενο, κλωνοποιεί τη διαφάνεια και αλλάζει τη θέση και το μέγεθος του ορθογωνίου στην κλώνη. Στη συνέχεια επιλέγει Morph από το [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) για τη δεύτερη διαφάνεια. Ανοίξτε το αποθηκευμένο αρχείο σε πρόγραμμα προβολής που υποστηρίζει Morph για να δείτε το εφέ κατά τη διάρκεια μιας παρουσίασης.

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

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) ελέγχει πώς το Morph ταιριάζει και ανιματοποιεί το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) αντιμετωπίζει κάθε σχήμα ως ενιαίο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) ανιματοποιεί το κείμενο αντιστοιχίζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) ανιματοποιεί το κείμενο αντιστοιχίζοντας χαρακτήρες όπου είναι δυνατόν.

Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) για να επιλέξετε Morph πριν προσπελάσετε το [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Η τιμή τότε παρέχει ένα αντικείμενο [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), του οποίου η μέθοδος [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) επιλέγει τη δυνατότητα αντιστοίχισης.

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

Ορισμένες μεταβάσεις εκθέτουν πρόσθετες επιλογές, όπως κατεύθυνση ή αν το εφέ ξεκινά από μια μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τη μετάβαση που επιλέχθηκε με το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Ορίστε πρώτα τον τύπο, έπειτα χρησιμοποιήστε το κατάλληλο αντικείμενο μετάβασης από το [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

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

Ναι. Προτιμήστε το [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) όταν μια προκαθορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/)—Slow, Medium ή Fast—είναι επαρκής και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ μετάβασης ανεξάρτητα από την καθυστέρηση αυτόματης προώθησης.

**Μπορώ να συνδέσω ήχο σε μια μετάβαση και να τον κάνω επανάληψη;**

Ναι. Εκχωρήστε ενσωματωμένο ήχο με το [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), περάστε το StartSound από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) στη μέθοδο [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode), και ενεργοποιήστε το [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) με `true`. Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην παρουσίαση.

**Ποιος είναι ο γρηγορότερος τρόπος να εφαρμόσω την ίδια μετάβαση σε κάθε διαφάνεια;**

Κάντε βρόχο στην συλλογή [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) της παρουσίασης και καλέστε το [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) με την ίδια τιμή για τη μετάβαση κάθε διαφάνειας. Ορίστε τυχόν επιλογές χρονοδίου και εφέ στον ίδιο βρόχο για να διατηρήσετε τη συμπεριφορά συνεπή σε όλες τις διαφάνειες.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Καλέστε το [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) στο αποτέλεσμα του [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); None σημαίνει ότι δεν έχει εφαρμοστεί κάποιο εφέ μετάβασης.