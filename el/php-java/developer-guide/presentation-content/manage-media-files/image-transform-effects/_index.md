---
title: Διαχείριση Εφέ Μετασχηματισμού Εικόνας σε Παρουσιάσεις με PHP
linktitle: Εφέ Μετασχηματισμού Εικόνας
type: docs
weight: 11
url: /el/php-java/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- εφέ εικόνας
- φωτεινότητα
- αντίθεση
- γκρι κλίμακα
- διχρωματισμός
- απόχρωση
- HSL
- αντικατάσταση χρώματος
- θόλωση
- διαφάνεια
- εφέ άλφα
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εφαρμόστε, συνδυάστε, ελέγξτε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις μιας εικόνας ως μια διατεταγμένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) του πλαισίου και αποκτήστε πρόσβαση στην [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/). Η επιστρεφόμενη [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) σάς επιτρέπει να προσθέσετε, να καταγράψετε, να ελέγξετε, να αφαιρέσετε και να εκκαθαρίσετε εφέ χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Το παρόν άρθρο παρουσιάζει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρώματος, θόλωμα, διαφάνεια, διατεταγμένες αλυσίδες εφέ, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση στρογγυλής διαδρομής PPTX.

## **Κατανόηση της Ιδιοκτησίας των Εφέ και Επαναχρησιμοποίηση Εικόνας**

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) αποθηκεύει ή αναφέρει τα δεδομένα της πηγαίας εικόνας που ανήκει στην παρουσίαση.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) ανήκει σε μια γεμιστική εικόνα και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμού εικόνας.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) είναι το σχήμα διαφάνειας που κατέχει τη σχετική γεμιστική εικόνα, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Άρα, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes του [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/). Όταν το ίδιο `PPImage` παρέχεται στη μέθοδο [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `Picture` και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν επηρεάζει τα άλλα πλαίσια, ακόμα κι αν όλα χρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο [Picture::getImageTransform] χρησιμοποιείται επίσης από άλλες γεμιστικές εικόνες, όπως ένα σχήμα ή το φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν στα πλαίσια εικόνας.

## **Χρήση Έγκυρων Εύρους Παραμέτρων και Μονάδων**

Οι παρουσιαζόμενες μέθοδοι χρησιμοποιούν τα ακόλουθα σημασιολογικά εύρη και μονάδες. Διατηρήστε τις τιμές εντός αυτών των ορίων, ακόμη και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε τιμή εκτός εύρους· η στοχευμένη μορφή παρουσίασης μπορεί να κανονικοποιήσει, παραλείψει ή απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίξει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` έως `100`, τοις εκατό· το `0` αφήνει το στοιχείο αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Δεν υπάρχουν αριθμητικές παράμετροι. Το άλφα παραμένει αμετάβλητο. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Δύο χρώματα για σκοτεινά και ανοιχτά εικονοστοιχεία. Τα κανάλια RGB και άλφα στο `java.awt.Color` χρησιμοποιούν τιμές από `0` έως `255`. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` είναι από `0` (συμπεριλαμβανομένου) έως `360` (αποκλεισμένου), σε μοίρες· `amount` είναι από `-100` έως `100`, τοις εκατό. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` είναι από `0` (συμπεριλαμβανομένου) έως `360` (αποκλεισμένου), σε μοίρες· `saturation` και `luminance` είναι από `-100` έως `100`, τοις εκατό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` είναι μη αρνητικός και μετράται σε πόντους· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να επεκταθεί εκτός των αρχικών ορίων. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | `amount` μη αρνητικό ποσοστό. Χρησιμοποιήστε τιμές από `0` έως `100` για κανονική κλιμάκωση αδιαφάνειας: το `0` είναι πλήρως διαφανές και το `100` διατηρεί το υπάρχον άλφα. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `alpha` από `0` έως `100`, ποσοστό αδιαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `threshold` από `0` έως `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό καθίστανται διαφανείς· τιμές ίσες ή ανώτερες γίνονται αδιαφανείς. |

Για σταθερή διαφάνεια, το ποσοστό διαφάνειας και η αδιαφάνεια είναι αμοιβαία συμπληρωματικά. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσοστό αλφα 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) επιστρέφει μια λειτουργία [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/). Οι βαθμωτοί ρυθμίσεις του παρέχονται όταν η λειτουργία δημιουργείται. Η μέθοδος [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να εξεταστούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, και στη συνέχεια αποδίδει μια προεπισκόπηση χωρίς να τροποποιήσει την ενσωματωμένη εικόνα:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Το `Luminance` είναι το τυπικό εφέ φωτεινότητας και αντίθεσης του DrawingML. Όταν αυτές οι ρυθμίσεις πρέπει να παραμείνουν επεξεργάσιμες μετά από στρογγυλή διαδρομή PPTX, ανοίξτε ξανά την αποθηκευμένη παρουσίαση και επαληθεύστε τόσο τον τύπο της λειτουργίας όσο και τις αποτελεσματικές τιμές.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που χρησιμοποιούν τον ίδιο πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, διχρωματισμό, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) περιλαμβάνει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `color1` αντιστοιχεί σε σκοτεινά εικονοστοιχεία, ενώ το `color2` αντιστοιχεί σε ανοιχτά. Αυτό το καθιστά ένα χρήσιμο παράδειγμα εφέ με πιο σύνθετες ρυθμίσεις από μια απλή βαθμωτή τιμή.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) αντικαθιστά το χρώμα κάθε εικονοστοιχείου με ένα σταθερό χρώμα, διατηρώντας το άλφα. Είναι διαφορετικό από το [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), το οποίο αντιστοιχίζει ένα χρώμα προέλευσης σε άλλο και εκθέτει και τις μορφές χρώματος προέλευσης και στόχου.

### **Εφαρμογή Κατωφλίου Φωτεινότητας**

Ένα κατώφλι φωτεινότητας μπορεί να κάνει τα αχνά σημάδια σε μια σαρωμένη σελίδα πιο ευδιάκριτα από το φόντο. Το [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) διατηρεί ενδιάμεσες αποχρώσεις του γκρι. Το [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) χαρτογραφεί τη φωτεινότητα σε μαύρο ή λευκό, ενώ το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) εφαρμόζει ένα κατώφλι στην αδιαφάνεια.

Το κατώφλι φωτεινότητας κυμαίνεται από 0 % έως 100 %, περιλαμβανομένων. Τα εικονοστοιχεία κάτω από το κατώφλι γίνονται μαύρα. Τα εικονοστοιχεία ίσα ή άνω του κατωφλίου γίνονται λευκά. Η αύξηση του κατωφλίου κάνει περισσότερες αποχρώσεις μαύρες επειδή περισσότερα εικονοστοιχεία πέφτουν κάτω από το όριο.

Κατεβάστε το αρχείο [grayscale-swatches.png](grayscale-swatches.png) στον φάκελο που περιέχει το script PHP. Κάθε ετικέτα δείχνει το αρχικό επίπεδο γκρι σε κλίμακα από 0 έως 255. Το παράδειγμα τοποθετεί το αρχικό δίπλα σε δύο αντίγραφα και αποθηκεύει το κατώφλι κάθε αντιγράφου στην παρουσίαση.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ανοίξτε την παραγόμενη παρουσίαση στο PowerPoint για να συγκρίνετε τα τρία πλαίσια. Το δείγμα με ετικέτα 96 έχει περίπου 38 % φωτεινότητα (96 από 255). Στο κατώφλι 20 % γίνεται λευκό και στο κατώφλι 60 % γίνεται μαύρο.

![Αρχικά δείγματα γκρι δίπλα στα μαύρο‑λευκά αποτελέσματα σε κατώφλια φωτεινότητας 20% και 60%](luminance-threshold.png)

## **Προσθήκη Θολώματος, Διαφάνειας και Άλφα Εφέ**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε το `grow` σε `true` όταν η θολή άκρη μπορεί να επεκταθεί πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι ώστε τα μερικώς διαφανή εικονοστοιχεία να παραμένουν αναλογικά διαφορετικά. Το [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) αντιθέτως εκχωρεί μία τιμή άλφα σε όλα τα εικονοστοιχεία. Το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) μετατρέπει το άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), που κάνει κάθε μη μηδενικό άλφα πλήρως αδιαπαστέο· το [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), που κάνει κάθε άλφα κάτω από 100 % πλήρως διαφανές· και το [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), που μετατρέπει το άλφα σε `100% - alpha`.

## **Δημιουργία Διατεταγμένης Αλυσίδας Εφέ**

Κάθε μέθοδος `add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο αποδότης χρησιμοποιεί τη συλλογή ως μια διατεταγμένη διαδρομή: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1, κλπ. Ως εκ τούτου, οι ίδιες λειτουργίες με διαφορετική σειρά μπορούν να παράγουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση πρώτα αφαιρεί την χρωματική πληροφορία και στη συνέχεια επαναχρωματίζει το αποτέλεσμα φωτεινότητας. Η απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί ξανά την απόχρωση. Ομοίως, η αντικατάσταση άλφα μπορεί να υπερισχύσει των τιμών άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές τους διαφορές.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ξανανοίγει την παρουσίαση, ελέγχει τους τύπους των λειτουργιών και τη σειρά τους, και αποδίδει το επανανοιγμένο αποτέλεσμα:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει χρωματικές, άλφα και θολές λειτουργίες σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί την ποικιλία RGB που δημιουργήθηκε από προηγούμενα χρωματικά εφέ· η γκρι κλίμακα μετά από διχρωματισμό αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα ceiling, floor, replacement ή bi‑level μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Κατασκευάστε την αλυσίδα σύμφωνα με την επιθυμητή σειρά επεξεργασίας εικονοστοιχείων αντί να τη θεωρείτε ως ασυνεχή σύνολο σημαιών μορφοποίησης.

<!-- visual-explanation:image-transform-effects:start -->
[![Η ίδια εικόνα περνάει πρώτα από γκρι κλίμακα, έπειτα από απόχρωση, και το αντίστροφο. Οι δύο τελικές εικόνες γκρι κλίμακας έχουν διαφορετικές αποχρώσεις.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Στην εικονική απόδοση Aspose.Slides for .NET 26.11, μία απόχρωση 220° με 25 % αφήνει την εικόνα σε γκρι κλίμακα αμετάβλητη. Η εφαρμογή της ίδιας απόχρωσης πριν από τη γκρι κλίμακα παράγει διαφορετικές αποχρώσεις.*
<!-- visual-explanation:image-transform-effects:end -->

## **Έλεγχος Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `Picture::getImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει εγγράψιμα μέλη άμεσα. Για παράδειγμα, το [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) εκθέτει εγγράψιμες τιμές `radius` και `grow`, το [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) εκθέτει εγγράψιμη τιμή `amount`, και το [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) εκθέτει εγγράψιμη τιμή `threshold`. Τα χρωματικά εφέ όπως το [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) εκθέτουν μεταβλητά αντικείμενα [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/).

Κάποιες λειτουργίες, όπως το [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), το [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), το [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), και το [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), δεν εκθέτουν τα αρχικά τους βαθμωτά ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στη χρειαζόμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει η `getEffective()` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων που εξαρτώνται από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο αποδότης, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα καταμετρά την αλυσίδα και ελέγχει τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Οι λειτουργίες χωρίς παραμέτρους όπως η γκρι κλίμακα, το αλφα ceiling και το αλφα inverse έχουν επίσης αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν βαθμωτές ρυθμίσεις για εκτύπωση. Η παρουσία τους και η θέση τους στη συλλογή είναι οι σημαντικές πληροφορίες.

## **Αφαίρεση ή Εκκαθάριση Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε τη μέθοδο [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) για να αφαιρέσετε μια λειτουργία κατά δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, εντοπίστε πρώτα τον στόχο και αφαιρέστε τον μετά την καταγραφή. Χρησιμοποιήστε τη μέθοδο [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) για να αφαιρέσετε ολόκληρη την αλυσίδα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Η αφαίρεση ή η εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν συμπιέζει ξανά και δεν τροποποιεί τον επαναχρησιμοποιημένο πόρο [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).

## **Σκεφτείτε τις Μορφές Παρουσίασης και τους Στόχους Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, έτσι το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμη και με PPTX, δεν έχει κάθε λειτουργία την ίδια φορητότητα:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, grayscale, duotone, tint, HSL, blur και κοινές λειτουργίες άλφα έχουν τις καλύτερες πιθανότητες να επιβιώσουν μετά από στρογγυλή διαδρομή PPTX. Πάντα ανοίξτε ξανά το παραγόμενο αρχείο και ελέγξτε τη συλλογή όταν η διατήρηση είναι απαραίτητη.
- Η δυαδική μορφή PPT προϋπάρχει του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε ένα υποσύνολο ή να προσομοιώσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες οπτικές εξόδους εφαρμόζει την υποστηριζόμενη αλυσίδα στην απεικόνιση. Αυτές οι εξόδους δεν περιέχουν ένα επεξεργάσιμο `ImageTransformOperationCollection`; οι μορφές raster ισοπεδώνουν το αποτέλεσμα σε εικονοστοιχεία, ενώ οι εξαγωγές εγγράφου ή διανυσματικού τύπου αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομα ενσωματωμένη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν η παρουσίαση φορτώνεται.

Διαφορετικοί καταναλωτές παρουσιάσεων μπορεί να αποδίδουν ακρογωνιαίους όρους διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρωματικού κβαντισμού. Για κρίσιμα αποτελέσματα, δοκιμάστε τόσο την επεξεργάσιμη στρογγυλή διαδρομή όσο και την τελική μορφή εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν τα εφέ μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα της εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `Picture` που χρησιμοποιείται από το γεμιστικό της εικόνας. Τα υποκείμενα bytes του `PPImage` παραμένουν αμετάβλητα.

**Θα μοιραστούν δύο πλαίσια εικόνας που χρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρησιμοποίηση ενός `PPImage` αποφεύγει διπλότυπα δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας συνήθως έχει ξεχωριστό `Picture` και τη δική του συλλογή μετασχηματισμών εικόνας.

**Μπορούν να συνδυαστούν χρωματικά, θολά και άλφα εφέ;**

Ναι. Η συλλογή τα αποδέχεται σε μία διατεταγμένη αλυσίδα. Λάβετε υπόψη τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, καθώς οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να απορρίψουν χρωματικές ή άλφα λεπτομέρειες από προηγούμενα βήματα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τις υπολογισθείσες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμών όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμών;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντάς το ξανά. Η κληρονομική μορφή PPT δεν μπορεί να αντιπροσωπεύσει όλο το μοντέλο εφέ DrawingML, ενώ οι εξαγώγιμες μορφές εμφάνισης διατηρούν μόνο την εμφάνιση και όχι τις επεξεργάσιμες λειτουργίες μετασχηματισμού.