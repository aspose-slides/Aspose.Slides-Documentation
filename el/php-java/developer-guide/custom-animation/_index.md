---
title: Δημιουργία και Τροποποίηση Προσαρμοσμένων Συμπεριφορών Κίνησης σε PHP
linktitle: Προσαρμοσμένη Κίνηση
type: docs
weight: 151
url: /el/php-java/custom-animation/
keywords:
- προσαρμοσμένη κίνηση
- συμπεριφορά κίνησης
- διαδρομή κίνησης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε, ελέγξτε και τροποποιήστε προσαρμοσμένες συμπεριφορές κίνησης και επεξεργάσιμες διαδρομές κίνησης σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Προσαρμοσμένες συμπεριφορές κίνησης σάς επιτρέπουν να ελέγχετε μεμονωμένες λειτουργίες μέσα σε ένα εφέ κίνησης, όπως η αλλαγή χρώματος, η περιστροφή σχήματος ή η ακολουθία επεξεργάσιμης διαδρομής κίνησης. Αυτός ο οδηγός δείχνει πώς να δημιουργήσετε και να συνδυάσετε συμπεριφορές, να διαμορφώσετε το χρονοδιάγραμμα τους, να ελέγξετε και να τροποποιήσετε υπάρχουσες κινήσεις, και να επαληθεύσετε ότι οι ιδιότητές τους παραμένουν μετά την αποθήκευση και την επαναφορά μιας παρουσίασης.

Για προ‑ορισμένα εφέ και ενεργοποιητές κλικ, δείτε [Κίνηση Σχήματος](/slides/el/php-java/shape-animation/).

## **Κατανόηση του Μοντέλου Κίνησης**

Μια κίνηση οργανώνεται ως **Timeline → Sequence → Effect → Behaviors**:

- Κάθε διαφάνεια έχει ένα χρονοδιάγραμμα που περιέχει την κύρια ακολουθία της και τις διαδραστικές ακολουθίες.
- Μια [Sequence](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/) περιέχει εφέ, ενδεχομένως για διαφορετικά σχήματα.
- Ένα [Effect](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/) προσδιορίζει το σχήμα-στόχο, το προ‑ρυθμισμένο εφέ, τον υποτύπο και το χρόνο του εφέ.
- Η συλλογή που επιστρέφεται από το [Effect::getBehaviors](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/getbehaviors/) περιέχει τις λειτουργίες που υλοποιούν το εφέ: αλλαγή χρώματος, μετακίνηση, περιστροφή, ορισμός ιδιότητας κλπ.

## **Δημιουργία Μεμονωμένων Συμπεριφορών**

Καλέστε το [Sequence::addEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/sequence/addeffect/) για να δημιουργήσετε ένα εφέ και να προσπελάσετε τη συλλογή [getBehaviors](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/getbehaviors/). Ένα προ‑ρυθμισμένο εφέ μπορεί να γεμίσει αυτή τη συλλογή αυτόματα. Διατηρήστε τις λειτουργίες του όταν επεκτείνετε το προ‑ρυθμισμένο εφέ, ή χρησιμοποιήστε το [clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorcollection/clear/) όταν προοριζόμενα τις αντικαθιστάτε.

[BehaviorFactory](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorfactory/) δημιουργεί τους οχτώ τύπους συμπεριφορών που απεικονίζονται παρακάτω. Η κίνηση καλύπτεται στο [Build a Motion Path](#build-a-motion-path). Κάθε απόσπασμα περιλαμβάνει τις εισαγωγές του και υποθέτει ότι η Γέφυρα PHP/Java και η βιβλιοθήκη Aspose.Slides PHP έχουν φορτωθεί. Τα παραδείγματα επεξεργασίας αναφέρουν ποιο αρχείο εξόδου χρησιμοποιούν.

### **Rotation**

Χρησιμοποιήστε το [createRotationEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorfactory/createrotationeffect/) για να δημιουργήσετε μια περιστροφή. Το [getBy](https://reference.aspose.com/slides/el/php-java/aspose.slides/rotationeffect/getby/) καθορίζει μια σχετική γωνία σε μοίρες· το [getFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/rotationeffect/getfrom/) και το [getTo](https://reference.aspose.com/slides/el/php-java/aspose.slides/rotationeffect/getto/) καθορίζουν τα άκρα.

Το παράδειγμα ξεκινά με ένα εφέ Spin, αντικαθιστά τις προ‑ρυθμισμένες λειτουργίες του με μία συμπεριφορά περιστροφής και δίνει σε αυτή τη λειτουργία διάρκεια δύο δευτερολέπτων. Μια σχετική γωνία 90 μοιρών εκφράζει ένα τέταρτο στροφής από τον αρχικό προσανατολισμό του σχήματος, επομένως δεν απαιτείται ρητή αρχική γωνία.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` περιέχει ένα σχήμα και μία συμπεριφορά περιστροφής. Η συλλογή, το χρονοδιάγραμμα και τα παραδείγματα επεξεργασίας περιστροφής παρακάτω χρησιμοποιούν αυτό το αρχείο.

### **Scale**

Χρησιμοποιήστε το [createScaleEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorfactory/createscaleeffect/) με ποσοστά X/Y: τα [getFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/scaleeffect/getfrom/) και [getTo](https://reference.aspose.com/slides/el/php-java/aspose.slides/scaleeffect/getto/) περιγράφουν το αρχικό και το τελικό μέγεθος, ενώ το [getBy](https://reference.aspose.com/slides/el/php-java/aspose.slides/scaleeffect/getby/) περιγράφει μια σχετική αλλαγή. Εδώ, 100 σημαίνει το αρχικό μέγεθος.

Το παράδειγμα αυξάνει και τις δύο διαστάσεις από 100 % σε 125 % σε δύο δευτερόλεπτα. Η χρήση ίσων οριζόντιων και κατακόρυφων ποσοστών διατηρεί τις αναλογίες του σχήματος· διαφορετικά ποσοστά θα τεντώσουν την μία διάσταση περισσότερο από την άλλη.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Color**

Χρησιμοποιήστε το [createColorEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorfactory/createcoloreffect/) για να αλλάξετε το γέμισμα από μπλε σε πορτοκαλί. Τα [getFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/coloreffect/getfrom/) και [getTo](https://reference.aspose.com/slides/el/php-java/aspose.slides/coloreffect/getto/) είναι χρώματα· το [getBy](https://reference.aspose.com/slides/el/php-java/aspose.slides/coloreffect/getby/) είναι μια απόσταση χρώματος. Η [BehaviorPropertyCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorpropertycollection/) της συμπεριφοράς προσδιορίζει το χαρακτηριστικό που αναπαράγεται.

Η συμπαγής γέμιση του σχήματος αρχικοποιείται σε μπλε, ταιριάζοντας με το αρχικό χρώμα της κίνησης. Η επιλογή του χαρακτηριστικού fill‑color λέει στη συμπεριφορά ποιο μέρος του σχήματος να αλλάξει· τα άκρα των χρωμάτων από μόνα τους δεν προσδιορίζουν αυτό το χαρακτηριστικό. Το αποθηκευμένο εφέ περιγράφει μια μετάβαση δύο δευτερολέπτων προς το πορτοκαλί.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Filter**

Χρησιμοποιήστε το [createFilterEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorfactory/createfiltereffect/) για να επιλέξετε μια απαλοιφή. Τα [getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/el/php-java/aspose.slides/filtereffect/getsubtype/) και [getReveal](https://reference.aspose.com/slides/el/php-java/aspose.slides/filtereffect/getreveal/) καθορίζουν το φίλτρο, την κατεύθυνση και το αν θα αποκαλυφθεί ή θα κρυφτεί το σχήμα.

Αυτό το παράδειγμα ρυθμίζει μια απαλοιφή δύο δευτερολέπτων που αποκαλύπτει το σχήμα χρησιμοποιώντας τον υποτύπο δεξιά. Οι ρυθμίσεις φίλτρου ανήκουν στη συμπεριφορά μέσα στο εφέ, γι’ αυτό διαμορφώνονται αφού έχουν αφαιρεθεί οι αρχικές λειτουργίες του προ‑ρυθμισμένου εφέ.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Property**

Χρησιμοποιήστε το [createPropertyEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) για να αναπαράγετε τη διαφάνεια. Τα [getFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/el/php-java/aspose.slides/propertyeffect/getto/) και [getBy](https://reference.aspose.com/slides/el/php-java/aspose.slides/propertyeffect/getby/) είναι συμβολοσειρές που ερμηνεύονται μέσω των [getValueType](https://reference.aspose.com/slides/el/php-java/aspose.slides/propertyeffect/getvaluetype/) και [getCalcMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/propertyeffect/getcalcmode/). Επιλέξτε άκρα ή σχετική μετατόπιση αντί να ορίσετε και τα τρία χωρίς διάκριση.

Εδώ, το επιλεγμένο χαρακτηριστικό είναι η διαφάνεια, και οι αριθμητικές συμβολοσειρές αντιπροσωπεύουν μια αλλαγή από 25 % διαφάνειας σε πλήρη διαφάνεια. Η γραμμική παρεμβολή περιγράφει μια ομαλή αλλαγή μεταξύ των τιμών. Όταν προσαρμόζετε αυτό το παράδειγμα σε άλλο χαρακτηριστικό, επιλέξτε τύπο τιμής και τιμές άκρων κατάλληλες για το συγκεκριμένο χαρακτηριστικό.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Set**

Χρησιμοποιήστε το [createSetEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorfactory/createseteffect/) για να ορίσετε την ορατότητα μέσω του [getTo](https://reference.aspose.com/slides/el/php-java/aspose.slides/seteffect/getto/). Μια συμπεριφορά set δεν παρεμβάλλει μεταξύ των άκρων.

Το παράδειγμα επιλέγει το χαρακτηριστικό ορατότητας και ορίζει τη συμβολοσειρά `visible` όταν εκτελείται η συμπεριφορά. Το ορθογώνιο είναι ήδη ορατό σε αυτή τη μίνι παρουσίαση, οπότε η ανάθεση μπορεί να μην δημιουργήσει άμεση οπτική αλλαγή. Μια τέτοια λειτουργία είναι χρήσιμη ως μέρος ενός μεγαλύτερου εφέ που ελέγχει επίσης πότε το σχήμα γίνεται κρυφό ή ορατό.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Command**

Χρησιμοποιήστε το [createCommandEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorfactory/createcommandeffect/) και διαμορφώστε τα [getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/el/php-java/aspose.slides/commandeffect/getcommandstring/) και [getShapeTarget](https://reference.aspose.com/slides/el/php-java/aspose.slides/commandeffect/getshapetarget/). Τοποθετήστε μια ηχογράφηση WAV με όνομα `sample.wav` στον εργασιακό φάκελο. Αυτό το παράδειγμα την ενσωματώνει με το [addAudioFrameEmbedded](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addaudioframeembedded/) και συνδέει μια εντολή αναπαραγωγής με το πλαίσιο ήχου.

Το πλαίσιο ήχου είναι τόσο ο στόχος του εφέ όσο και ο στόχος της εντολής. Αυτό συνδέει το αίτημα αναπαραγωγής με την ενσωματωμένη ηχογράφηση· μια εντολή χωρίς περαιτέρω πληροφορίες δεν προσδιορίζει ποιο αντικείμενο πολυμέσων να ελέγξει. Το εφέ ρυθμίζεται να ξεκινά με κλικ κατά τη διάρκεια της παρουσίασης.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Η αποθήκευση αποθηκεύει την εντολή στο `command.pptx`; δεν αναπαράγει την ηχογράφηση. Η αναπαραγωγή απαιτεί έναν προγράμματα παρουσίασης που υποστηρίζει την εντολή και το μέσον-στόχο της.

## **Διαχείριση της Συλλογής Συμπεριφορών**

Το [BehaviorCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorcollection/) υποστηρίζει τα [add](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorcollection/remove/) και [removeAt](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorcollection/removeat/). Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, προσθέτει κλιμάκωση, τη μετακινεί πριν από την περιστροφή και αφαιρεί την περιστροφή. Η αφαίρεση και επανεισαγωγή του ίδιου αντικειμένου αλλάζει τη θέση του στην αποθηκευμένη συλλογή χωρίς δημιουργία αντιγράφου.

Η ακολουθία των επεξεργασιών αλλάζει τη συλλογή από περιστροφή‑κλιμάκωση σε κλιμάκωση‑περιστροφή και, τέλος, μόνο σε κλιμάκωση. Οι δείκτες αναφέρονται στην τρέχουσα συλλογή, επομένως η αφαίρεση χρησιμοποιεί το νέο δείκτη της περιστροφής μετά την αναδιάταξη. Η τελική απαρίθμηση επιβεβαιώνει ποια συμπεριφορά θα αποθηκευτεί.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η έξοδος είναι `ScaleEffect`: απομένει μόνο η κλιμάκωση. Η σειρά της συλλογής από μόνη της δεν προγραμματίζει τις συμπεριφορές η μία μετά την άλλη. Καθαρίστε τη συλλογή μόνο όταν αντικαθιστάτε όλες τις λειτουργίες της.

## **Διαμόρφωση Χρόνου Συμπεριφοράς**

Μια συμπεριφορά έχει το δικό της [Timing](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/), ανεξάρτητα από το χρονοδιάγραμμα που επιστρέφει το [Effect::getTiming](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/gettiming/). Ο χρόνος του εφέ προγραμματίζει το περιβάλλον εφέ· ο χρόνος της συμπεριφοράς περιγράφει μια λειτουργία εντός αυτού.

### **Ορισμός Διάρκειας, Καθυστέρησης, Επανάληψης και Επιτάχυνσης**

Ανοίξτε το `rotation.pptx` και ορίστε τη διάρκεια ([getDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getduration/)) και την καθυστέρηση ενεργοποίησης ([getTriggerDelayTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/gettriggerdelaytime/)) σε δευτερόλεπτα, στη συνέχεια ρυθμίστε τον αριθμό επαναλήψεων μέσω του [setRepeatCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/setrepeatcount/). Τα [getAccelerate](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getaccelerate/) και [getDecelerate](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getdecelerate/) είναι κλάσματα της διάρκειας· διατηρήστε το άθροισμά τους το πολύ 1.

Το αρχείο εισόδου είναι αυτό που δημιουργήθηκε στο παράδειγμα περιστροφής, όπου η πρώτη συμπεριφορά είναι γνωστή ως περιστροφή. Αυτό το παράδειγμα αλλάζει μόνο το χρονοδιάγραμμα εκείνης της συμπεριφοράς· η γωνία των 90 μοιρών παραμένει αμετάβλητη. Η διατήρηση της γωνίας και του χρόνου ξεχωριστά καθιστά ευκολότερη την προσαρμογή του ρυθμού χωρίς επανακατασκευή της κίνησης.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η συμπεριφορά χρησιμοποιεί διάρκεια δύο δευτερολέπτων, καθυστέρηση μισού δευτερολέπτου και αριθμό επαναλήψεων 3. Το πρώτο και το τελευταίο 20 % της διάρκειάς της χρησιμοποιείται για επιτάχυνση και επιβράδυνση.

Άλλες πολιτικές επανάληψης περιλαμβάνουν τα [getRepeatDuration](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getrepeatuntilendslide/) και [getRepeatUntilNextClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getrepeatuntilnextclick/). Επιλέξτε μια πολιτική αντί να τις ενεργοποιήσετε όλες ταυτόχρονα. Το [getAutoReverse](https://reference.aspose.com/slides/el/php-java/aspose.slides/timing/getautoreverse/) παίζει την κίνηση ανάποδα μετά το προώθημα. Η επιτάχυνση και η επιβράδυνση εφαρμόζονται σε συνεχή αλλαγή, όχι σε διακριτές εκχωρήσεις ή εντολές.

## **Δημιουργία Διαδρομής Κίνησης**

Χρησιμοποιήστε το [createMotionEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorfactory/createmotioneffect/) για να δημιουργήσετε κίνηση. Τα [getFrom](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioneffect/getto/) και [getBy](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioneffect/getby/) περιγράφουν συντεταγμένες ή μετατοπίσεις με βάση το ποσοστό. Για επεξεργάσιμη διαδρομή, δημιουργήστε ένα [MotionPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/motionpath/) και αναθέστε το με το [MotionEffect::setPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioneffect/setpath/). Το [MotionPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/motionpath/) αποθηκεύει τις εντολές διαδρομής.

Το [MotionCommandPathType](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioncommandpathtype/) επιλέγει την ενέργεια:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Set the starting position. |
| LineTo | One | Move along a straight segment to its endpoint. |
| CurveTo | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CloseLoop | None | Return to the starting position. |
| End | None | Finish the path. |

Το [MotionPathPointsType](https://reference.aspose.com/slides/el/php-java/aspose.slides/motionpathpointstype/) περιγράφει χαρακτηριστικά επεξεργασιμότητας σημείου, όπως γωνίες ή λείες καμπύλες. Δεν αντικαθιστά τον τύπο εντολής. Χρησιμοποιήστε τύπο σημείου καμπύλης για το παράδειγμα καμπύλης παρακάτω, και τύπο σημείου γωνίας για τα ευθύγραμμα τμήματα.

Οι συντεταγμένες διαδρομής είναι κανονικοποιημένες στις διαστάσεις της διαφάνειας: μια μετατόπιση X 0.25 αντιπροσωπεύει το ένα τέταρτο του πλάτους της διαφάνειας, όχι 0.25 σημεία. Το θετικό Y κατεβαίνει προς τα κάτω. Οι απόλυτες εντολές καθορίζουν θέσεις στο σύστημα συντεταγμένων της διαδρομής· οι σχετικές εντολές καθορίζουν μετατοπίσεις από την τρέχουσα θέση. Αυτό διαχωρίζεται από το [getOrigin](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioneffect/getorigin/), το οποίο επιλέγει το πλαίσιο αναφοράς της διαδρομής, και το [getPathEditMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioneffect/getpatheditmode/), το οποίο ελέγχει πώς η διαδρομή κινείται όταν μετακινείται το σχήμα.

### **Δημιουργία Ευθείας Διαδρομής**

Δημιουργήστε μια συμπεριφορά κίνησης με σημείο εκκίνησης, ένα ευθύ τμήμα και μια εντολή λήξης. Το [MotionPath::add](https://reference.aspose.com/slides/el/php-java/aspose.slides/motionpath/add/) δέχεται τον τύπο εντολής, τα σημεία της, τον τύπο σημείου και μια σημαία συσχετισμού σχετικών συντεταγμένων.

Η εντολή εκκίνησης ορίζει (0, 0), και η γραμμή λήγει στο (0.25, 0), δίνοντας στη διαδρομή μετατόπιση οριζόντια ενός τέταρτου του πλάτους της διαφάνειας. Η εντολή λήξης δεν έχει σημεία. Μόλις ανατεθεί η διαδρομή, η προσθήκη της συμπεριφοράς κίνησης στο εφέ συνδέει αυτή τη διαδρομή με το ορθογώνιο.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` περιέχει μία συμπεριφορά κίνησης με τρεις εντολές διαδρομής. Τα παραδείγματα επεξεργασίας αρχείων που ακολουθούν χρησιμοποιούν αυτή τη γνωστή δομή.

### **Σύγκριση Απόλυτων και Σχετικών Συντεταγμένων**

Αυτά τα δύο αντικείμενα διαδρομής περιγράφουν την ίδια διαδρομή. Η απόλυτη εντολή λήγει στο (0.3, 0.1); η σχετική εντολή προσθέτει (0.1, 0.1) στην τρέχουσα θέση, (0.2, 0).

Και οι δύο διαδρομές ξεκινούν στην ίδια θέση. Για τη σχετική ευθεία, προσθέστε τις μετατοπίσεις X και Y στην τρέχουσα θέση για να λάβετε το άκρο· για την απόλυτη ευθεία, διαβάστε το άκρο άμεσα. Η αλλαγή της σημαίας χωρίς μετατροπή των συντεταγμένων θα περιέγραφε διαφορετική διαδρομή.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Αναθέστε οποιαδήποτε από τις δύο διαδρομές σε μια συμπεριφορά κίνησης για χρήση στην παρουσίαση. Το τελικό λογικό όρισμα επιλέγει σχετικές συντεταγμένες για εκείνη την εντολή.

### **Αντικατάσταση Ευθείας με Καμπύλη**

Ανοίξτε το `motion.pptx` και αντικαταστήστε την εντολή ευθείας με μια κυρτή καμπύλη. Πρώτα δώστε τα δύο σημεία ελέγχου, στη συνέχεια το άκρο.

Η θέση εκκίνησης παρέχεται από την προηγούμενη εντολή. Τα πρώτα δύο σημεία διαμορφώνουν την καμπύλη, ενώ το τρίτο είναι ο προορισμός της· δεν αποτελούν τρία διαδοχικά άκρα. Η ταυτόχρονη ενημέρωση του τύπου εντολής, του τύπου επεξεργασίας σημείου και του πίνακα σημείων διατηρεί το τμήμα συνεπές με τη νέα γεωμετρία του.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η διαδρομή στο `curve.pptx` εξακολουθεί να έχει τρεις εντολές· η μεσαία εντολή τώρα ορίζει μια καμπύλη.

## **Επιθεώρηση και Επεξεργασία Αποθηκευμένης Διαδρομής**

Κάθε [MotionCmdPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioncmdpath/) εκθέτει τα [getPoints](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioncmdpath/getpointstype/) και [isRelative](https://reference.aspose.com/slides/el/php-java/aspose.slides/motioncmdpath/isrelative/). Τα παραδείγματα που ακολουθούν χρησιμοποιούν τη γνωστή τρι‑εντολών διαδρομή στο `motion.pptx`. Για αυθαίρετη είσοδο, εντοπίστε το επιθυμητό εφέ και ελέγξτε τους τύπους εντολών και τον αριθμό σημείων πριν την επεξεργασία με βάση το δείκτη.

### **Ανάγνωση Εντολών και Συντεταγμένων**

Διαβάστε τη διαδρομή χωρίς αλλαγές. Οι εντολές End και CloseLoop δεν χρειάζονται σημεία, επομένως επιτρέψτε έναν μηδενικό πίνακα σημείων.

Η έξοδος αντιστοιχίζει κάθε αριθμητικό τύπο εντολής με τη σημαία σχετικών συντεταγμένων πριν λίστα σημείων. Αυτό σας επιτρέπει να διακρίνετε άκρο σημείου από μετατόπιση πριν τροποποιήσετε τη διαδρομή. Μια καμπύλη θα καταγράψει τρία σημεία, ενώ η ευθεία σε αυτό το αρχείο καταγράφει μόνο ένα.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Η λίστα περιλαμβάνει σημείο εκκίνησης, μια απόλυτη ευθεία που λήγει στο (0.25, 0) και μια εντολή λήξης.

### **Αλλαγή Άκρου Σημείου**

Ανοίξτε το `motion.pptx` και αντικαταστήστε τον πίνακα σημείων της ευθείας για να μετακινήσετε το άκρο της.

Στο αρχείο εισόδου, ο δείκτης 0 είναι η εντολή εκκίνησης και ο δείκτης 1 η ευθεία. Η αντικατάσταση του μοναδικού σημείου της ευθείας αλλάζει τον προορισμό της χωρίς να αλλάζει τον τύπο εντολής, το χρονοδιάγραμμα ή τη θέση της στη συλλογή. Επειδή η εντολή χρησιμοποιεί απόλυτές συντεταγμένες, το νέο ζεύγος καθορίζει μια θέση, όχι μια προστιθέμενη μετατόπιση.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η ευθεία στο `motion-endpoint.pptx` λήγει στο (0.4, 0.1); το αρχικό αρχείο παραμένει αμετάβλητο.

### **Αντικατάσταση Τμηματικού Στοιχείου**

Χρησιμοποιήστε το [insert](https://reference.aspose.com/slides/el/php-java/aspose.slides/motionpath/insert/) και το [removeAt](https://reference.aspose.com/slides/el/php-java/aspose.slides/motionpath/removeat/) για να αντικαταστήσετε την ευθεία στο `motion.pptx`. Η εισαγωγή μετακινεί την παλιά ευθεία στο δείκτη 2.

Αυτό επιδεικνύει την αντικατάσταση ενός αντικειμένου εντολής αντί της επεξεργασίας των υπαρχουσών συντεταγμένων του. Μετά την εισαγωγή, η συλλογή περιέχει προσωρινά την εντολή εκκίνησης, τη νέα ευθεία, την παλιά ευθεία και την εντολή λήξης. Η αφαίρεση του δείκτη 2 απορρίπτει την παλιά ευθεία και αφήνει τη νέα διαδρομή στη θέση της.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η αποθηκευμένη διαδρομή παραμένει τρι‑εντολών, με τη νέα ευθεία να λήγει στο (0.2, 0.1) και την εντολή End στο τέλος.

## **Τροποποίηση και Επαλήθευση Υπάρχουσας Συμπεριφοράς**

Όταν ο δείκτης της συμπεριφοράς είναι άγνωστος, επιλέξτε τη βάσει τύπου. Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, εντοπίζει το [RotationEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/rotationeffect/), αλλάζει τη γωνία και ελέγχει την αποθηκευμένη τιμή μετά το άνοιγμα ξανά.

Ο έλεγχος τύπου επιτρέπει στη βρόχο να παραλείψει συμπεριφορές που δεν είναι περιστροφές. Το δεύτερο φόρτωμα διαβάζει το αποθηκευμένο αρχείο σε ξεχωριστό αντικείμενο παρουσίασης, ώστε η σύγκριση να ελέγχει τα δεδομένα που έχουν αποθηκευτεί, όχι την τιμή που παραμένει στη μνήμη. Το παράδειγμα αυτό εξακολουθεί να υποθέτει ότι το γνωστό εφέ είναι πρώτο στην κύρια ακολουθία· η επιλογή συμπεριφοράς κατά τύπο δεν εντοπίζει το σωστό εφέ σε αυθαίρετη παρουσίαση.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Η έξοδος είναι `Rotation preserved: true`. Εφαρμόστε το ίδιο μοτίβο ελέγχου τύπου σε άλλες συμπεριφορές. Για έναν πλήρη έλεγχο διατήρησης, συγκρίνετε το σχήμα‑στόχο, το εφέ, τους τύπους και τη σειρά των συμπεριφορών, το χρονοδιάγραμμα και τις εντολές διαδρομής. Χρησιμοποιήστε αριθμητική ανοχή για τιμές κινητής υποδιαστολής. Για παρουσίαση με άγνωστο μοντέλο κίνησης, δείτε [Read Shape Animations](/slides/el/php-java/shape-animation/#read-shape-animations) για την περιήγηση των κύριων και διαδραστικών ακολουθιών.

## **Σειρά Συμπεριφορών, Προ‑ρυθμίσεις και Αναπαραγωγή**

Η σειρά στο [BehaviorCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/behaviorcollection/) είναι η αποθηκευμένη σειρά των λειτουργιών ενός εφέ. Δεν είναι λίστα αναπαραγωγής στην οποία κάθε συμπεριφορά περιμένει αυτόματα την προηγούμενη. Ο χρόνος και το περιβάλλον εφέ καθορίζουν τον προγραμματισμό. Οι συμπεριφορές μπορούν να επικαλύπτονται, και οι λειτουργίες στο ίδιο χαρακτηριστικό μπορεί να αλληλεπιδρούν μέσω των ρυθμίσεων [additive](https://reference.aspose.com/slides/el/php-java/aspose.slides/behavioradditivetype/) και [accumulation](https://reference.aspose.com/slides/el/php-java/aspose.slides/behavioraccumulatetype/). Μην χρησιμοποιείτε μόνο την αναδιάταξη της συλλογής για να προγραμματίσετε το “μετακίνηση, μετά περιστροφή”; χρησιμοποιήστε ρητό χρονοδιάγραμμα ή χωριστά εφέ όπως περιγράφεται στην [Κίνηση Σχήματος](/slides/el/php-java/shape-animation/).

Το [getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/gettype/) και το [getSubtype](https://reference.aspose.com/slides/el/php-java/aspose.slides/effect/getsubtype/) του εφέ περιγράφουν το προ‑ρυθμισμένο εφέ. Δεν αποτελούν πλήρη περιγραφή ενός επεξεργασμένου δέντρου συμπεριφορών. Επιλέξτε το προ‑ρυθμισμένο και τον υποτύπο πριν προσαρμόσετε τις συμπεριφορές: η αλλαγή του προ‑ρυθμισμένου εφέ μπορεί να ξαναχτίσει τη συλλογή και να απορρίψει τις προσαρμοσμένες λειτουργίες σας. Για παράδειγμα, η αλλαγή ενός προσαρμοσμένου εφέ Spin σε Fade μπορεί να αντικαταστήσει τη συμπεριφορά περιστροφής με set και filter. Ελέγξτε ξανά τη συλλογή μετά την αλλαγή προ‑ρυθμισμένου ή υποτύπου. Η εκκαθάριση των προ‑ρυθμισμένων συμπεριφορών μπορεί επίσης να αφαιρέσει λειτουργίες ορατότητας ή αρχικοποίησης που απαιτούνται από το προ‑ρυθμισμένο εφέ. Τα παραδείγματα χρησιμοποιούν σχήματα ορατά και αντικαθιστούν τις συμπεριφορές· δεν επανακατασκευάζουν κάθε υλοποίηση προ‑ρυθμισμένου εφέ.

## **Συμβατότητα Μορφής**

Ένα διατηρημένο δέντρο συμπεριφορών δεν εγγυάται ταυτόσημη αναπαραγωγή σε κάθε προβολέα ή εξαγωγέα. Ελέγξτε τα αποθηκευμένα δεδομένα και το παραγόμενο αποτέλεσμα ξεχωριστά.

| Format or output | What to verify |
| --- | --- |
| PPTX | Use as the primary format for these examples. Reopen it to verify the editable behavior tree, then check playback in the intended PowerPoint version. |
| PPT | Legacy binary representation can differ from PPTX. Test a separate save-and-reopen cycle and playback; do not infer support for every custom combination from successful PPTX output. |
| PDF, PNG, JPEG, and other static slide images | Contain a static slide representation, not a playable behavior timeline or a guaranteed final animation frame. |
| [HTML5](/slides/el/php-java/export-to-html5/) | Can play supported animations when shape animation is enabled in the export options. Test custom combinations in the browser. |
| [Animated GIF](/slides/el/php-java/convert-powerpoint-to-animated-gif/) | Stores rendered frames, not editable behaviors or click‑triggered interaction. Check the actual rendered motion. |
| [Video](/slides/el/php-java/convert-powerpoint-to-video/) | Render animation frames and encode them as video. Support is limited to the renderer's [supported animations and effects](/slides/el/php-java/convert-powerpoint-to-video/#supported-animations-and-effects); commands and interactive events do not become an editable timeline. |

## **Συχνές Ερωτήσεις**

**Γιατί το εφέ μου περιέχει συμπεριφορές πριν προσθέσω κάτι;**

Η δημιουργία ενός προ‑ρυθμισμένου εφέ μπορεί να δημιουργήσει τις υποκείμενες λειτουργίες του. Ελέγξτε τις πριν αποφασίσετε αν θα επεκτείνετε το προ‑ρυθμισμένο ή θα τις αντικαταστήσετε.

**Κάνει η μετακίνηση μιας συμπεριφοράς στην αρχή το να παίζεται πρώτη;**

Όχι απαραίτητα. Η σειρά της συλλογής δεν υποκαθιστά το χρονοδιάγραμμα. Ελέγξτε τις καθυστερήσεις, τις διάρκειες και τις αλληλεπιδράσεις μεταξύ λειτουργιών στο ίδιο χαρακτηριστικό.

**Γιατί μια εντολή End δεν έχει σημεία;**

Δηλώνει το τέλος της διαδρομής και δεν χρειάζονται συντεταγμένες. Ελέγξτε για μηδενικό πίνακα σημείων όταν εξετάζετε μια διαδρομή από αρχείο.

**Αρκεί ένας επιτυχής κύκλος αποθήκευσης‑επαναφοράς για να επιβεβαιωθεί η αναπαραγωγή;**

Όχι. Η επαναφορά επαληθεύει τη διατήρηση των ιδιοτήτων που ελέγξατε. Δοκιμάστε τον προγράμματα παρουσίασης ή την εξαγωγή σε κινούμενο αρχείο ξεχωριστά για να επιβεβαιώσετε την οπτική συμπεριφορά.