---
title: Διαχείριση μεταβάσεων διαφάνειας σε παρουσιάσεις με PHP
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
description: "Εφαρμόστε μεταβάσεις διαφάνειας, ρυθμίστε αυτόματη προχώρηση διαφανειών και προσαρμόστε το Morph και άλλα εφέ μετάβασης με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Οι μεταβάσεις διαφανειών ελέγχουν πώς εμφανίζονται οι διαφάνειες κατά τη διάρκεια μιας παρουσίασης διαφανειών. Με το Aspose.Slides για PHP μέσω Java, μπορείτε να επιλέξετε ένα εφέ μετάβασης για κάθε διαφάνεια, να ρυθμίσετε την προχώρηση με κλικ του ποντικιού ή χρονοδιακόπτη, και να προσαρμόσετε επιλογές που είναι συγκεκριμένες για ένα εφέ. Αυτό το άρθρο χρησιμοποιεί παραδείγματα PHP για την εφαρμογή μεταβάσεων, ορισμό ακριβών χρόνων μετάβασης, διαχείριση χρόνου διαφάνειας και δημιουργία μιας μετάβασης Morph μεταξύ δύο διαφανειών. Τα παραδείγματα δείχνουν επίσης πώς να αποθηκεύσετε τις ρυθμίσεις σε αρχείο PPTX.

## **Προσθήκη Μετάβασης Διαφάνειας**

Για να εφαρμόσετε μια μετάβαση, φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις ρυθμίσεις μετάβασης της διαφάνειας μέσω του [getSlideShowTransition](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getSlideShowTransition). Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setType) με μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitiontype/), στη συνέχεια αποθηκεύστε την παρουσίαση.

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

## **Προσθήκη Προχωρημένης Μετάβασης Διαφάνειας**

Μπορείτε να ρυθμίσετε πόσο χρόνο παραμένει μια διαφάνεια στην οθόνη και αν ένα κλικ του ποντικιού προχωράει την παρουσίαση. Οι ακόλουθες μέθοδοι ελέγχουν αυτή τη συμπεριφορά:

- [setAdvanceOnClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) επιτρέπει στον θεατή να προχωράει κάνοντας κλικ με το ποντίκι.
- [setAdvanceAfter](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) ενεργοποιεί την αυτόματη προχώρηση.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) καθορίζει την καθυστέρηση πριν την αυτόματη προχώρηση, σε χιλιοστά του δευτερολέπτου.

Ενεργοποιήστε τόσο το κλικ όσο και την χρονομετρημένη προχώρηση ώστε ο θεατής να μπορεί να προχωρήσει με κλικ ή να περιμένει το χρονομετρητή. Για χρήση μόνο του χρονομετρητή, περάστε `false` στη μέθοδο [setAdvanceOnClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Η καθυστέρηση ελέγχει πότε η παρουσίαση προχωράει· δεν καθορίζει τη διάρκεια του οπτικού εφέ μετάβασης.

Αυτό το παράδειγμα εκχωρεί διαφορετικά εφέ στις πρώτες τρεις διαφάνειες και ενεργοποιεί την αυτόματη προχώρηση μετά από 3, 5 και 7 δευτερόλεπτα, αντίστοιχα. Τα κλικ του ποντικιού μπορούν επίσης να προχωρήσουν αυτές τις διαφάνειες. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον τρεις διαφάνειες.

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

Για να ελέγξετε αν η χρονομετρημένη προχώρηση είναι ενεργοποιημένη, καλέστε τη μέθοδο [getAdvanceAfter](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Η αποθηκευμένη καθυστέρηση από μόνη της δεν υποδεικνύει ότι ο χρονομετρητής είναι ενεργός.

Το επόμενο παράδειγμα ανοίγει το παραπάνω αποθηκευμένο αρχείο, αναφέρει κάθε ενεργό χρονομετρητή και απενεργοποιεί την αυτόματη προχώρηση για διαφάνειες με καθυστέρηση μεγαλύτερη των δύο δευτερολέπτων. Ενεργοποιεί τα κλικ του ποντικιού για αυτές τις διαφάνειες και αποθηκεύει τις ενημερωμένες ρυθμίσεις.

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

## **Έλεγχος Ακριβούς Χρόνου Μετάβασης**

Χρησιμοποιήστε τη μέθοδο [setDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setDuration) για να καθορίσετε το ακριβές μήκος ενός εφέ μετάβασης σε χιλιοστά του δευτερολέπτου. Η μέθοδος [getSlideShowTransition](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας εκθέτει αυτές τις ρυθμίσεις μέσω του [SlideShowTransition](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/):

| Μέθοδος | Σκοπός |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setDuration) | Ορίζει τη διάρκεια του εφέ μετάβασης, σε χιλιοστά του δευτερολέπτου. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ορίζει την καθυστέρηση πριν τη διαφάνεια προχωρήσει αυτόματα, σε χιλιοστά του δευτερολέπτου. Περάστε `true` στη μέθοδο [setAdvanceAfter](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) για να ενεργοποιήσετε αυτόν τον χρονομετρητή. |
| [setSpeed](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setSpeed) | Επιλέγει μια προ-ορισμένη κατηγορία ταχύτητας από την [TransitionSpeed](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitionspeed/): Slow, Medium ή Fast. Χρησιμοποιείται όταν δεν έχει οριστεί ρητή διάρκεια. |

Η μέθοδος [setDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setDuration) ελέγχει μόνο το εφέ μετάβασης· δεν καθορίζει πόσο χρόνο παραμένει η διαφάνεια ορατή. Ρυθμίστε τη χρονική καθυστέρηση της αυτόματης προχώρησης ξεχωριστά. Όταν δεν έχει οριστεί ρητή διάρκεια, το Aspose.Slides καθορίζει τη διάρκεια του εφέ βάσει του τύπου μετάβασης και της τιμής της [getSpeed](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Εφαρμογή Ίδιας Διάρκειας σε Κάθε Διαφάνεια**

Για συνεπή ρυθμό, εφαρμόστε το ίδιο εφέ και ακριβή διάρκεια σε κάθε διαφάνεια. Αυτό το παράδειγμα φορτώνει το `input.pptx`, επιλέγει το Fade από την [TransitionType](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitiontype/), και δίνει σε κάθε μετάβαση διάρκεια 750 χιλιοστών του δευτερολέπτου. Ενεργοποιεί ξεχωριστά την αυτόματη προχώρηση μετά από 5 000 χιλιοστά του δευτερολέπτου και απενεργοποιεί την προχώρηση με κλικ του ποντικιού, στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX.

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

        // Ρύθμιση αυτόματης προχώρησης ανεξάρτητα από τη διάρκεια του εφέ.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ορισμός Διαφορετικών Διάρκειων για Ατομικές Διαφάνειες**

Διαφορετικές διαφάνειες μπορούν να χρησιμοποιούν διαφορετικές διάρκειες εφέ. Για παράδειγμα, χρησιμοποιήστε μια σύντομη μετάβαση για τη διαφάνεια τίτλου και μια πιο μακρά για την εισαγωγή ενότητας. Αυτό το παράδειγμα ορίζει 500 χιλιοστά του δευτερολέπτου για την πρώτη διαφάνεια και 1 200 χιλιοστά του δευτερολέπτου για τη δεύτερη. Χρησιμοποιήστε ένα αρχείο `input.pptx` με τουλάχιστον δύο διαφάνειες.

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

### **Συντονισμός Μεταβάσεων με Ανιματικό Έξοδο**

Κατά την προετοιμασία ενός [animated GIF](/slides/el/php-java/convert-powerpoint-to-animated-gif/), μιας [HTML5 presentation](/slides/el/php-java/export-to-html5/) ή ενός [video](/slides/el/php-java/convert-powerpoint-to-video/), ορίστε ακριβείς διάρκειες μεταβάσεων πριν την εξαγωγή ώστε να ταιριάζουν με τον επιθυμητό ρυθμό. Για παράδειγμα, χρησιμοποιήστε ένα fade 600 χιλιοστών του δευτερολέπτου μεταξύ σκηνών και προσαρμόστε ξεχωριστά την καθυστέρηση προχώρησης κάθε διαφάνειας για να επιτρέψετε χρόνο για την αφήγηση ή το περιεχόμενό της.

Για GIF και βίντεο, συντονίστε το ρυθμό καρέ του εξόδου με τη διάρκεια του εφέ: 600 χιλιοστά του δευτερολέπτου αντιστοιχούν σε 18 καρέ στα 30 καρέ ανά δευτερόλεπτο. Στο HTML5, ενεργοποιήστε τις ανιματικές μεταβάσεις στις ρυθμίσεις εξαγωγής. Ελέγξτε τις υποστηριζόμενες εφέ και επιλογές χρονισμού της επιλεγμένης μορφής εξαγωγής και προεπισκοπήστε το αποτέλεσμα για να επιβεβαιώσετε τον συγχρονισμό.

### **Ανάγνωση Υπάρχουσας Διάρκειας Μετάβασης**

Καλέστε τη μέθοδο [getDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#getDuration) πριν τροποποιήσετε τη μετάβαση για να προσδιορίσετε αν αποθηκεύεται ρητή τιμή. Μια τιμή `-1` σημαίνει ότι δεν έχει οριστεί ρητή διάρκεια· μια μη αρνητική τιμή καθορίζει την αποθηκευμένη διάρκεια σε χιλιοστά του δευτερολέπτου. Η μη ορισμένη τιμή δεν είναι η υπολογιζόμενη διάρκεια αναπαραγωγής: το Aspose.Slides χρησιμοποιεί τον τύπο μετάβασης και την τιμή της [getSpeed](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#getSpeed) για να καθορίσει αυτή τη διάρκεια. Ο ορισμός ενός τύπου μετάβασης μπορεί να αρχικοποιήσει μια διάρκεια, επομένως εξετάστε πρώτα τις αρχικές ρυθμίσεις.

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

Η μετάβαση Morph αναπαριστά αλλαγές μεταξύ αντικειμένων σε διαδοχικές διαφάνειες. Για να δημιουργήσετε ένα απλό εφέ Morph, κλωνοποιήστε μια διαφάνεια, μετακινήστε ή αλλάξτε το μέγεθος ενός αντικειμένου στον κλώνο, και εφαρμόστε τη μετάβαση Morph στη δεύτερη διαφάνεια. Αυτό παρέχει στη μετάβαση τα αντίστοιχα αντικείμενα για animation μεταξύ της αρχικής και της τροποποιημένης τους κατάστασης.

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

Η απαρίθμηση [TransitionMorphType](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitionmorphtype/) ελέγχει πώς το Morph ταιριάζει και αναπαριστά το περιεχόμενο:

- [ByObject](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitionmorphtype/#ByObject) αντιμετωπίζει κάθε σχήμα ως ολόκληρο αντικείμενο.
- [ByWord](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitionmorphtype/#ByWord) αναπαριστά το κείμενο ταιριάζοντας λέξεις όπου είναι δυνατόν.
- [ByChar](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitionmorphtype/#ByChar) αναπαριστά το κείμενο ταιριάζοντας χαρακτήρες όπου είναι δυνατόν.

Χρησιμοποιήστε το [setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setType) για να επιλέξετε Morph πριν την πρόσβαση στο [getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#getValue). Η τιμή παρέχει στη συνέχεια ένα αντικείμενο [MorphTransition](https://reference.aspose.com/slides/el/php-java/aspose.slides/morphtransition/), του οποίου η μέθοδος [setMorphType](https://reference.aspose.com/slides/el/php-java/aspose.slides/morphtransition/#setMorphType) επιλέγει τη λειτουργία αντιστοίχησης.

Αυτό το παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε στην προηγούμενη ενότητα και ρυθμίζει τη δεύτερη διαφάνεια να χρησιμοποιεί Morph animation με βάση τις λέξεις.

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

Κάποιες μεταβάσεις εκθέτουν πρόσθετες επιλογές, όπως η κατεύθυνση ή αν το εφέ ξεκινά από μαύρη οθόνη. Οι διαθέσιμες επιλογές εξαρτώνται από τη μετάβαση που έχει επιλεγεί με το [setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setType). Ορίστε πρώτα τον τύπο, στη συνέχεια χρησιμοποιήστε το κατάλληλο αντικείμενο μετάβασης από το [getValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#getValue).

Το παρακάτω παράδειγμα εφαρμόζει μια μετάβαση Cut στην πρώτη διαφάνεια του `input.pptx`. Καλεί το [setFromBlack](https://reference.aspose.com/slides/el/php-java/aspose.slides/optionalblacktransition/#setFromBlack) μέσω του [OptionalBlackTransition](https://reference.aspose.com/slides/el/php-java/aspose.slides/optionalblacktransition/) ώστε η μετάβαση να ξεκινά από μαύρη οθόνη.

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

## **FAQ**

**Μπορώ να ελέγξω την ταχύτητα αναπαραγωγής μιας μετάβασης διαφάνειας;**

Ναι. Προτιμήστε το [setDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setDuration) όταν χρειάζεστε ακριβή διάρκεια εφέ σε χιλιοστά του δευτερολέπτου. Χρησιμοποιήστε το [setSpeed](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setSpeed) όταν μια προ-ορισμένη κατηγορία [TransitionSpeed](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitionspeed/) — Slow, Medium ή Fast — είναι επαρκής και δεν έχει οριστεί ρητή διάρκεια. Αυτές οι ρυθμίσεις ελέγχουν το εφέ μετάβασης ανεξάρτητα από τη χρονική καθυστέρηση αυτόματης προχώρησης.

**Μπορώ να συνημψω ήχο σε μια μετάβαση και να τον κάνω επανάληψη;**

Ναι. Αντιστοιχίστε ενσωματωμένο ήχο με τη μέθοδο [setSound](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setSound), περάστε το StartSound από την απαρίθμηση [TransitionSoundMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitionsoundmode/) στη μέθοδο [setSoundMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setSoundMode), και ενεργοποιήστε το [setSoundLoop](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setSoundLoop) με `true`. Ο ήχος επαναλαμβάνεται μέχρι το επόμενο ηχητικό γεγονός στην παρουσίαση.

**Ποιος είναι ο ταχύτερος τρόπος να εφαρμόσω την ίδια μετάβαση σε κάθε διαφάνεια;**

Διενεργήστε βρόχο στη συλλογή [getSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlides) της παρουσίασης και καλέστε το [setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#setType) με την ίδια τιμή για τη μετάβαση κάθε διαφάνειας. Ορίστε τυχόν επιλογές χρονισμού και εφέ στον ίδιο βρόχο για να διατηρήσετε τη συμπεριφορά συνεπή σε όλες τις διαφάνειες.

**Πώς μπορώ να ελέγξω ποια μετάβαση είναι αυτή τη στιγμή ορισμένη σε μια διαφάνεια;**

Καλέστε το [getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideshowtransition/#getType) στο αποτέλεσμα του [getSlideShowTransition](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getSlideShowTransition) της διαφάνειας. Επιστρέφει μια τιμή από την απαρίθμηση [TransitionType](https://reference.aspose.com/slides/el/php-java/aspose.slides/transitiontype/); η τιμή None σημαίνει ότι δεν έχει εφαρμοστεί καμία μετάβαση.