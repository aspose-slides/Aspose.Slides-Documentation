---
title: Εφαρμογή Κινήσεων Σχημάτων σε Παρουσιάσεις με χρήση PHP
linktitle: Κίνηση Σχήματος
type: docs
weight: 60
url: /el/php-java/shape-animation/
keywords:
- σχήμα
- κίνηση
- εφέ
- κινούμενο σχήμα
- κινούμενο κείμενο
- προσθήκη κίνησης
- λήψη κίνησης
- εξαγωγή κίνησης
- προσθήκη εφέ
- λήψη εφέ
- εξαγωγή εφέ
- ήχος εφέ
- εφαρμογή κίνησης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να επιθεωρείτε και να προσαρμόζετε κινήσεις σχημάτων, χρονισμό, ήχους, συμπεριφορά μετά την κίνηση, και κείμενο με κίνηση με το Aspose.Slides for PHP μέσω Java."
---
## **Επισκόπηση**

Για να εργαστείτε με τις μεμονωμένες συμπεριφορές εντός ενός εφέ ή να επεξεργαστείτε τμήματα διαδρομής κίνησης, δείτε [Custom Animation](/slides/el/php-java/custom-animation/).

Aspose.Slides for PHP μέσω Java αντιπροσωπεύει τις κινήσεις των διαφανειών ως εφέ σε χρονοδιάγραμμα διαφάνειας. Ένα εφέ έχει ένα σχήμα‑στόχο, έναν τύπο και υπό‑τύπο κίνησης, έναν ενεργοποιητή, ρυθμίσεις χρονισμού και προαιρετικές ιδιότητες όπως ήχο ή συμπεριφορά μετά το εφέ.

Το χρονοδιάγραμμα περιέχει δύο είδη ακολουθιών:

- Η **κύρια ακολουθία** εκτελείται καθώς προχωρά η διαφάνεια.
- Μια **διαδραστική ακολουθία** ξεκινά όταν το σχήμα‑ενεργοποιητής της κλικάρεται.

Επειδή τα πλαίσια κειμένου, οι εικόνες, τα διαγράμματα, οι πίνακες και άλλα αντικείμενα διαφάνειας είναι σχήματα, χρησιμοποιείτε την ίδια μέθοδο [Sequence::addEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/addeffect/) για τα περισσότερα περιεχόμενα διαφάνειας. Τα διαθέσιμα εφέ παρατίθενται στην κλάση [EffectType](https://reference.aspose.com/slides/el/php-java/aspose.slides/effecttype/).

## **Προσθήκη Κινήσεων Σχημάτων**

Για να προσθέσετε μια κίνηση, αποκτήστε την κύρια ακολουθία της διαφάνειας και καλέστε [Sequence::addEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/addeffect/) με το σχήμα‑στόχο, τον τύπο εφέ, τον υπό‑τύπο και τον ενεργοποιητή. Για ένα εφέ που ξεκινά όταν κλικάρεται ένα άλλο σχήμα, δημιουργήστε μια διαδραστική ακολουθία του οποίου ο ενεργοποιητής είναι το εν λόγω σχήμα.

Το παρακάτω παράδειγμα δημιουργεί και τους δύο τύπους κίνησης και αποθηκεύει το αποτέλεσμα στο `shape-animations.pptx`.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ο ενεργοποιητής ελέγχει πότε ένα εφέ ξεκινά:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/effecttriggertype/) περιμένει κλικ στην κύρια ακολουθία ή κλικ στο σχήμα‑ενεργοποιητή σε μια διαδραστική ακολουθία.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/el/php-java/aspose.slides/effecttriggertype/) ξεκινά με το προηγούμενο εφέ.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/el/php-java/aspose.slides/effecttriggertype/) ξεκινά όταν ολοκληρωθεί το προηγούμενο εφέ.

Για να κινήσετε μια εικόνα, ένα διάγραμμα ή άλλο τύπο σχήματος, περάστε εκείνο το αντικείμενο στη μέθοδο [Sequence::addEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/addeffect/) αντί για `$targetShape`. Για επιλογές ομαδοποίησης ειδικές για διαγράμματα, δείτε [Animated Charts](/slides/el/php-java/animated-charts/).

## **Ανάγνωση Κινήσεων Σχημάτων**

Χρησιμοποιήστε τη μέθοδο [Sequence::getEffectsByShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/geteffectsbyshape/) όταν γνωρίζετε το σχήμα‑στόχο. Για να επιθεωρήσετε κάθε εφέ, απαριθμήστε την κύρια ακολουθία και κάθε διαδραστική ακολουθία. Η απαρίθμηση αποτρέπει την υπόθεση ότι μια ακολουθία περιέχει εφέ στη θέση `0`.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα με εφέ κύριας και διαδραστικής ακολουθίας, παίρνει τα εφέ που στοχεύουν το σχήμα και κατόπιν απαριθμεί κάθε ακολουθία στη διαφάνεια.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

Αν χρειάζεστε μόνο τα εφέ για ένα σχήμα, πρώτα προσδιορίστε το σχήμα με το όνομα, τον τύπο του συμπληρώματος ή κάποια άλλη σταθερή ιδιότητα· στη συνέχεια καλέστε τη μέθοδο [Sequence::getEffectsByShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/geteffectsbyshape/). Μην υποθέτετε ότι το [ShapeCollection::get_Item](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/get_item/) στη θέση `0` είναι πάντα το επιθυμητό αντικείμενο.

## **Εργασία με Κληρονομημένα Εφέ Συμπληρωμάτων**

Ένα συμπλήρωμα σε μια κανονική διαφάνεια μπορεί να κληρονομήσει τη συμπεριφορά κίνησης από το αντίστοιχο συμπλήρωμα στη διάταξη και στο κύριο πρότυπο. Η μέθοδος [Shape::getBasePlaceholder](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getbaseplaceholder/) επιστρέφει εκείνο το γονικό συμπλήρωμα, ή `null` όταν δεν υπάρχει γονέας.

Στην παρακάτω παρουσίαση παραδείγματος, το υποσέλιδο έχει **Random Bars** στην κανονική διαφάνεια, **Split** στη διαφάνεια διάταξης και **Fly In** στη κύρια διαφάνεια.

![Εφέ κίνησης υποσέλιδου στην κανονική διαφάνεια](slide-shape-animation.png)

![Εφέ κίνησης συμπληρώματος υποσέλιδου στη διαφάνεια διάταξης](layout-shape-animation.png)

![Εφέ κίνησης συμπληρώματος υποσέλιδου στη κύρια διαφάνεια](master-shape-animation.png)

Το επόμενο παράδειγμα χρησιμοποιεί μια ιεραρχία συμπληρωμάτων από μια νέα παρουσίαση. Προσθέτει εφέ σε ένα κύριο συμπλήρωμα, ένα συμπλήρωμα διάταξης και το αντίστοιχο συμπλήρωμα σε μια κανονική διαφάνεια. Κάθε κλήση στη μέθοδο [Shape::getBasePlaceholder](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getbaseplaceholder/) ελέγχεται πριν χρησιμοποιηθεί το επιστρεφόμενο σχήμα.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αλλαγή Χρονισμού Κίνησης**

Ο διάλογος **Timing** του PowerPoint αντιστοιχεί στις ιδιότητες της κλάσης [Timing](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/).

![Διάλογος χρονισμού PowerPoint για ένα εφέ κίνησης](shape-animation.png)

- **Έναρξη** αντιστοιχεί στο [Timing::getTriggerType](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/gettriggertype/).
- **Διάρκεια** αντιστοιχεί στο [Timing::getDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getduration/), σε δευτερόλεπτα.
- **Καθυστέρηση** αντιστοιχεί στο [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/gettriggerdelaytime/), σε δευτερόλεπτα.
- **Επανάληψη** αντιστοιχεί στο [Timing::getRepeatCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getrepeatcount/), στο [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getrepeatuntilnextclick/) ή στο [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Επαναφορά όταν ολοκληρωθεί η αναπαραγόμενη** αντιστοιχεί στο [Timing::getRewind](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getrewind/).

Αυτό το ανεξάρτητο παράδειγμα προσθέτει ένα εφέ, αλλάζει τον χρονισμό του μέσω του αντικειμένου που επιστρέφει η μέθοδος [Sequence::addEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/addeffect/), και αποθηκεύει το αποτέλεσμα. Η διατήρηση της επιστρεφόμενης αναφοράς [Effect](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/) αποφεύγει έναν περιττό δείκτη συλλογής.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Χρησιμοποιήστε έναν τρόπο επανάληψης σκόπιμα. Ο συνδυασμός μετρητή επανάληψης με σημαία «μέχρι» μπορεί να δημιουργήσει συγκεχυμένα αποτελέσματα σε διαφορετικούς προγράμματα προβολής. Όταν αλλάζετε τρόπους επανάληψης, ορίστε πρώτα το [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/setrepeatuntilnextclick/) και το [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/setrepeatuntilendslide/), πριν καλέσετε το [Timing::setRepeatCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/setrepeatcount/), επειδή η ρύθμιση οποιασδήποτε σημαίας αλλάζει επίσης τη δραστήρια λειτουργία επανάληψης.

## **Προσθήκη και Εξαγωγή Ήχων Κίνησης**

Ένα εφέ κίνησης μπορεί να αναφέρεται σε ενσωματωμένο ήχο μέσω του [Effect::getSound](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/getsound/). Η μέθοδος [Effect::setStopPreviousSound](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/setstopprevioussound/) λέει σε ένα εφέ να σταματήσει ήχο που είχε ξεκινήσει ένα προηγούμενο εφέ.

### **Προσθήκη Ήχου σε Εφέ**

Το παρακάτω παράδειγμα υποθέτει την ύπαρξη τοπικού αρχείου ήχου με όνομα `animation-sound.wav`. Δημιουργεί δύο εφέ, ενσωματώνει το αρχείο ως ήχο για το πρώτο εφέ και ρυθμίζει το δεύτερο εφέ ώστε να σταματά τον ήχο. Χρησιμοποιεί τα αντικείμενα που επιστρέφονται από το [Sequence::addEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/addeffect/), οπότε δεν απαιτείται δείκτης ακολουθίας.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Εξαγωγή Ενσωματωμένων Ήχων Εφέ**

Το παρακάτω παράδειγμα υποθέτει την ύπαρξη τοπικής παρουσίασης με όνομα `presentation-with-animation-sounds.pptx`. Σαρώνει τόσο την κύρια όσο και τη διαδραστική ακολουθία και γράφει κάθε ενσωματωμένο ήχο εφέ στον φάκελο `extracted-animation-sounds`. Η επέκταση επιλέγεται από τον τύπο MIME του ήχου που εκτίθεται από το [Audio::getContentType](https://reference.aspose.com/slides/el/php-java/aspose.slides/audio/getcontenttype/).

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Για μεγάλα αντικείμενα ήχου, χρησιμοποιήστε το [Audio::getStream](https://reference.aspose.com/slides/el/php-java/aspose.slides/audio/getstream/) και αντιγράψτε τη ροή σε αρχείο αντί να φορτώσετε ολόκληρο το αντικείμενο σε έναν πίνακα bytes.

## **Ορισμός Συμπεριφοράς Μετά το Εφέ**

Η επιλογή **After animation** ελέγχει τι συμβαίνει με ένα σχήμα μετά το τέλος του εφέ.

![Διάλογος επιλογών εφέ PowerPoint που εμφανίζει τις ρυθμίσεις μετά το εφέ](shape-after-animation.png)

Η κλάση [AfterAnimationType](https://reference.aspose.com/slides/el/php-java/aspose.slides/afteranimationtype/) υποστηρίζει το να αφήνεται το σχήμα αμετάβλητο, να αλλάζει το χρώμα του, να κρύβεται μετά το εφέ ή να κρύβεται στο επόμενο κλικ. Όταν ο τύπος είναι [AfterAnimationType::Color](https://reference.aspose.com/slides/el/php-java/aspose.slides/afteranimationtype/), ορίστε επίσης το [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/getafteranimationcolor/).

Αυτό το ανεξάρτητο παράδειγμα δημιουργεί ένα εφέ, ορίζει τη συμπεριφορά μετά το εφέ μέσω του επιστρεφόμενου αντικειμένου εφέ και αποθηκεύει το αποτέλεσμα.

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η αλλαγή του τύπου από το [AfterAnimationType::Color](https://reference.aspose.com/slides/el/php-java/aspose.slides/afteranimationtype/) διαγράφει τη ρύθμιση χρώματος μετά το εφέ.

## **Κινούμενο Κείμενο**

Η κίνηση κειμένου έχει δύο σχετιζόμενους ελέγχους:

- Το [TextAnimation::getBuildType](https://reference.aspose.com/slides/el/php-java/aspose.slides/textanimation/getbuildtype/) ελέγχει εάν οι παράγραφοι εμφανίζονται μαζί ή ανά επίπεδο παραγράφου.
- Το [Effect::getAnimateTextType](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/getanimatetexttype/) ελέγχει εάν το κείμενο εμφανίζεται ολόκληρο, ανά λέξη ή ανά γράμμα. Το [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/getdelaybetweentextparts/) ορίζει την καθυστέρηση μεταξύ λέξεων ή γραμμάτων. Μια θετική τιμή είναι ποσοστό της διάρκειας του εφέ· μια αρνητική τιμή είναι καθυστέρηση σε δευτερόλεπτα.

Το παρακάτω ανεξάρτητο παράδειγμα κινεί τις λέξεις σε ένα πλαίσιο κειμένου. Το [BuildType::AsOneObject](https://reference.aspose.com/slides/el/php-java/aspose.slides/buildtype/) απενεργοποιεί την κατασκευή παράγραφος‑προς‑παράγραφο ώστε η ρύθμιση λέξης να ισχύει για όλο το πλαίσιο κειμένου.

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για να κατασκευάσετε ένα πλαίσιο κειμένου παράγραφο‑προς‑παράγραφο, ορίστε το [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/el/php-java/aspose.slides/buildtype/) (ή άλλο επίπεδο παραγράφου). Για να στοχεύσετε μια μόνο παράγραφο με δικό της εφέ, χρησιμοποιήστε την υπερφόρτωση του [Sequence::addEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/addeffect/) που δέχεται ένα [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/). Δείτε το [Animated Text](/slides/el/php-java/animated-text/) για παραδείγματα επιπέδου παραγράφου.

## **Σημειώσεις Εξαγωγής και Συμβατότητας**

- Η αποθήκευση σε PPT ή PPTX διατηρεί το μοντέλο κίνησης, αλλά η τελική αναπαραγωγή ελέγχεται από το πρόγραμμα προβολής παρουσίασης.
- Το PDF και οι στατικές εικόνες δεν παίζουν κινήσεις. Χρησιμοποιήστε την [HTML5 export](/slides/el/php-java/export-to-html5/), animated GIF ή τη [video conversion](/slides/el/php-java/convert-powerpoint-to-video/) όταν η έξοδος πρέπει να δείχνει κίνηση.
- Για HTML5, ενεργοποιήστε το [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/html5options/setanimateshapes/) και, όταν χρειάζεται, το [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/el/php-java/aspose.slides/html5options/setanimatetransitions/).
- Η απόδοση βίντεο υποστηρίζει πολλές συνηθισμένες εφέ εισόδου, έμφασης, εξόδου και διαδρομής κίνησης, αλλά δεν υποστηρίζονται όλα τα εφέ του PowerPoint. Ελέγξτε τις τρέχουσες [supported animations and effects](/slides/el/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) και δοκιμάστε κρίσιμες παρουσιάσεις με την έκδοση του Aspose.Slides που χρησιμοποιείτε.
- Προηγμένα προσαρμοσμένα εφέ και εφέ που εισάγονται από άλλες μορφές παρουσίασης μπορεί να διατηρηθούν στο αρχείο αλλά να αποδίδονται διαφορετικά σε PowerPoint, HTML5 ή βίντεο. Επαληθεύστε το εξαγόμενο αποτέλεσμα αντί να βασίζεστε μόνο στο όνομα του εφέ.

## **Συχνές Ερωτήσεις**

**Γιατί εμφανίζεται μια κίνηση στο PowerPoint αλλά όχι σε PDF;**

Το PDF είναι στατική μορφή, επομένως οι κινήσεις και οι μεταβάσεις διαφανειών δεν εκτελούνται. Εξάγετε σε HTML5, animated GIF ή βίντεο όταν πρέπει να διατηρηθεί η κίνηση.

**Γιατί ένα εφέ αποδίδεται διαφορετικά σε βίντεο;**

Η εξαγωγή σε βίντεο αποδίδει τις κινήσεις αντί να αποθηκεύει τη συμπεριφορά του PowerPoint. Ορισμένα προχωρημένα εφέ δεν υποστηρίζονται ή προσεγγίζονται. Εξετάστε τον πίνακα των υποστηριζόμενων εφέ και δοκιμάστε την παρουσίαση πριν την παραγωγή.

**Αλλάζει η σειρά των κινήσεων όταν μετακινείται ένα σχήμα προς τα εμπρός ή προς τα πίσω;**

Όχι. Η σειρά z‑order ελέγχει την επικάλυψη, ενώ η σειρά ακολουθίας και οι ενεργοποιητές ελέγχουν την αναπαραγωγή της κίνησης. Αλλάξτε το χρονοδιάγραμμα αν χρειάζεστε διαφορετική σειρά αναπαραγωγής.