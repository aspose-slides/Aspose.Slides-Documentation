---
title: Διαχείριση εφέ μετασχηματισμού εικόνας σε παρουσιάσεις με PHP
linktitle: Εφέ μετασχηματισμού εικόνας
type: docs
weight: 11
url: /el/php-java/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- εφέ εικόνας
- φωτεινότητα
- αντίθεση
- γκρι κλίμακα
- δυοχρωματισμός
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

Το Aspose.Slides παρουσιάζει τις ρυθμίσεις εικόνας ως μια διατεταγμένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [Picture](https://reference.aspose.com/slides/el/php-java/aspose.slides/picture/) του πλαισίου και αποκτήστε πρόσβαση στο [Picture::getImageTransform](https://reference.aspose.com/slides/el/php-java/aspose.slides/picture/getimagetransform/). Η επιστρεφόμενη [ImageTransformOperationCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/) σάς επιτρέπει να προσθέσετε, να απαριθμήσετε, να εξετάσετε, να αφαιρέσετε και να διαγράψετε εφέ χωρίς να ξαναγράψετε τα αρχικά δεδομένα εικόνας.

Αυτό το άρθρο δείχνει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρώματος, θόλωση, διαφάνεια, διατεταγμένα αλυσίδες εφέ, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση στρογγυλής διαδρομής PPTX.

## **Κατανόηση της κυριότητας του εφέ και επαναχρησιμοποίηση της εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) αποθηκεύει ή αναφέρεται στα δεδομένα της πηγής εικόνας που ανήκουν στην παρουσίαση.
- [Picture](https://reference.aspose.com/slides/el/php-java/aspose.slides/picture/) ανήκει σε γέμισμα εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμών εικόνας.
- [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις κοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Κατά συνέπεια, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα byte στο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/). Όταν το ίδιο `PPImage` περνάει στο [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addpictureframe/) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `Picture` και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι κλίμακας, ακόμη και αν όλα χρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `Picture::getImageTransform` χρησιμοποιείται επίσης από άλλα γέμισματα εικόνας, όπως σχήμα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν στα πλαίσια εικόνας.

## **Χρήση έγκυρων περιοχών παραμέτρων και μονάδων**

Οι παρουσιάζοντες μέθοδοι χρησιμοποιούν τις παρακάτω σημασιολογικές περιοχές και μονάδες. Διατηρήστε τις τιμές σε αυτές τις περιοχές ακόμη κι αν κάποια έκδοση της βιβλιοθήκης δεν απορρίπτει άμεσα κάθε εκτός περιοχής τιμή· η μορφή παρουσίασης-στόχος μπορεί να κανονικοποιήσει, παραλείψει ή απορρίψει λανθασμένα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίξει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Δεν υπάρχουν αριθμητικές παράμετροι. Το άλφα παραμένει αμετάβλητο. |
| [addDuotoneEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Δύο χρώματα για σκοτεινά και φωτεινά pixel. Τα κανάλια RGB και άλφα στο `java.awt.Color` χρησιμοποιούν τιμές `0` έως `255`. |
| [addTintEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Η απόχρωση είναι `0` (συμπεριλαμβανομένου) έως `360` (εξαίρετο), σε μοίρες· το ποσό είναι `-100` έως `100`, ποσοστό. |
| [addHSLEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι `0` έως `360` (εξαίρετο), σε μοίρες· ο κορεσμός και η φωτεινότητα είναι `-100` έως `100`, ποσοστό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Το αντικατάσταση χρώματος χρησιμοποιεί τιμές καναλιού από `0` έως `255`. Τα υπάρχοντα άλφα παραμένουν αμετάβλητα. |
| [addBlurEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετριέται σε points· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να εκτείνεται εκτός των αρχικών ορίων. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για συνηθισμένη κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διαφανές και `100` διατηρεί το υπάρχον άλφα. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` έως `100`, ποσοστό αδιαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή άνω γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση άλφα, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό διαμόρφωσης άλφα 65 %.

## **Εφαρμογή φωτεινότητας και αντίθεσης**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) επιστρέφει μια λειτουργία [Luminance](https://reference.aspose.com/slides/el/php-java/aspose.slides/luminance/). Οι βαθμωτές ρυθμίσεις του παρέχονται όταν δημιουργείται η λειτουργία. [Luminance::getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/luminance/geteffective/) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να εξεταστούν ή να καταγραφούν.

Το ακόλουθο παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, έπειτα εμφανίζει προεπισκόπηση χωρίς να τροποποιεί την ενσωματωμένη εικόνα:

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

`Luminance` είναι το τυπικό εφέ φωτεινότητας και αντίθεσης του DrawingML. Όταν αυτές οι ρυθμίσεις πρέπει να παραμείνουν επεξεργάσιμες μετά από στρογγυλή διαδρομή PPTX, ανοίξτε ξανά την αποθηκευμένη παρουσίαση και επαληθεύστε τόσο τον τύπο λειτουργίας όσο και τις αποτελεσματικές τιμές.

## **Εφαρμογή μετασχηματισμών χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το ακόλουθο παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, δυοχρωματισμό, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

[Duotone](https://reference.aspose.com/slides/el/php-java/aspose.slides/duotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: `color1` αντιστοιχεί στα σκοτεινά pixel, ενώ `color2` στα φωτεινά pixel. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ του οποίου οι ρυθμίσεις είναι πιο σύνθετες από μία μόνο βαθμωτή τιμή.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) αντικαθιστά κάθε χρώμα pixel με ένα σταθερό χρώμα διατηρώντας το άλφα. Είναι διαφορετικό από το [addColorChangeEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), το οποίο αντιστοιχίζει ένα χρώμα προέλευσης σε άλλο και εκθέτει και τις μορφές χρώματος προέλευσης και στόχου.

## **Προσθήκη θόλωσης, διαφανούς και άλφα εφέ**

[addBlurEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε `grow` σε `true` όταν η θολή άκρη μπορεί να εκτείνεται πέρα από τα αρχικά όρια εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι ώστε τα μερικώς διαφανή pixel να παραμένουν ανάλογα διαφορετικά. [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) αντιθέτως αναθέτει μία τιμή άλφα σε όλα τα pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) μετατρέπει το άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

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

Άλλες λειτουργίες άλφα χωρίς παραμέτρους είναι [addAlphaCeilingEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), η οποία κάνει κάθε μη μηδενικό άλφα πλήρως αδιαφανές· [addAlphaFloorEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), η οποία κάνει κάθε άλφα κάτω από 100 % πλήρως διαφανές· και [addAlphaInverseEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), η οποία αλλάζει το άλφα σε `100% - alpha`.

## **Κατασκευή διατεταγμένης αλυσίδας εφέ**

Κάθε μέθοδος `add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο προγράμματος απόδοσης χρησιμοποιεί τη συλλογή ως διατεταγμένο pipeline: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες σε διαφορετική σειρά μπορούν να παράγουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση αφαιρεί πρώτα τις χρωματικές πληροφορίες και έπειτα επαναχρωματίζει το αποτέλεσμα φωτεινότητας. Η απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί την απόχρωση εκ νέου. Παρομοίως, η αντικατάσταση άλφα μπορεί να παρακάμπτει τιμές άλφα που υπολογίστηκαν από προγενέστερες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές τους.

Το ακόλουθο παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ξαναανοίγει την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργίας όσο και τη σειρά τους, και αποδίδει το αποτέλεσμα μετά το άνοιγμα:

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

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θόλωσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί την ποικιλία RGB που παρήχθη από προηγούμενα εφέ χρώματος· η γκρι κλίμακα μετά από δυοχρωματισμό αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα οροφής, δαπέδου, αντικατάστασης ή δυο επιπέδων μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Δημιουργήστε την αλυσίδα σύμφωνα με την επιθυμητή σειρά επεξεργασίας pixel αντί να θεωρείτε τα στοιχεία της ως μη διατεταγμένες σημαίες μορφοποίησης.

## **Επιθεώρηση επεξεργάσιμων και αποτελεσματικών τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `Picture::getImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει εγγράψιμα μέλη απευθείας. Για παράδειγμα, το [Blur](https://reference.aspose.com/slides/el/php-java/aspose.slides/blur/) εκθέτει εγγράψιμες τιμές `radius` και `grow`, το [AlphaModulateFixed](https://reference.aspose.com/slides/el/php-java/aspose.slides/alphamodulatefixed/) εκθέτει εγγράψιμο `amount`, και το [AlphaBiLevel](https://reference.aspose.com/slides/el/php-java/aspose.slides/alphabilevel/) εκθέτει εγγράψιμο `threshold`. Τα εφέ χρώματος όπως το [Duotone](https://reference.aspose.com/slides/el/php-java/aspose.slides/duotone/) εκθέτουν μεταβλητά αντικείμενα [ColorFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/colorformat/).

Ορισμένες λειτουργίες, όπως [Luminance](https://reference.aspose.com/slides/el/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/el/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/el/php-java/aspose.slides/tint/) και [AlphaReplace](https://reference.aspose.com/slides/el/php-java/aspose.slides/alphareplace/), δεν εκθέτουν τις δημιουργικές τους βαθμωτές τιμές ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στη ζητούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει το `getEffective()` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτώμενων από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο προγράμματος απόδοσης, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και εξετάζει τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

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

Τα εφέ χωρίς παραμέτρους όπως η γκρι κλίμακα, η οροφή άλφα και η αντίστροφη άλφα έχουν ακόμα αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχει βαθμωτή ρύθμιση για εκτύπωση. Η παρουσία τους και η θέση τους στη συλλογή είναι η σημαντική πληροφορία.

## **Αφαίρεση ή εκκαθάριση μετασχηματισμών εικόνας**

Χρησιμοποιήστε το [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/removeat/) για να αφαιρέσετε μια λειτουργία με βάση το ευρετήριο. Επειδή τα ευρετήρια μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα το στόχο και αφαιρέστε το μετά την απαρίθμηση. Χρησιμοποιήστε το [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagetransformoperationcollection/clear/) για να αφαιρέσετε ολόκληρη την αλυσίδα.

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

Η αφαίρεση ή η εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν συμπιέζει ξανά και δεν τροποποιεί με κανέναν τρόπο τον επαναχρησιμοποιούμενο πόρο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/).

## **Λάβετε υπόψη τις μορφές παρουσίασης και τους προορισμούς εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, έτσι το PPTX είναι η προτιμώμενη μορφή επεξεργάσιμης αλυσίδας εφέ. Ακόμη και με PPTX, δεν έχουν όλες οι λειτουργίες την ίδια φορητότητα:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, grayscale, duotone, tint, HSL, blur και κοινές λειτουργίες άλφα έχουν την καλύτερη πιθανότητα να επιβιώσουν από στρογγυλή διαδρομή PPTX. Πάντα ανοίξτε ξανά το παραγόμενο αρχείο και ελέγξτε τη συλλογή όταν η διατήρηση είναι απαραίτητη.
- Η δυαδική μορφή PPT είναι παλαιότερη από το πλήρες μοντέλο εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε υποσύνολο που υποστηρίζεται ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλη οπτική έξοδο εφαρμόζει την υποστηριζόμενη αλυσίδα στην εμφανιζόμενη εικόνα. Αυτές οι εξόδους δεν περιέχουν επεξεργάσιμη `ImageTransformOperationCollection`; οι μορφές raster ισοπεδώνουν το αποτέλεσμα σε pixel, και οι εξαγωγές εγγράφου ή διανυσματικής μορφής αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν η παρουσίαση φορτώνεται.

Διαφορετικοί καταναλωτές παρουσίασης μπορεί να αποδίδουν περιθώρια διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρωματικής κβαντοποίησης. Για κρίσιμη έξοδο, δοκιμάστε τόσο τη στρογγυλή διαδρομή επεξεργασίας όσο και την τελική μορφή εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές ερωτήσεις**

**Τροποποιούν οι λειτουργίες μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `Picture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα byte του `PPImage` παραμένουν αμετάβλητα.

**Μοιράζονται δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρησιμοποίηση ενός `PPImage` αποφεύγει διπλότυπα δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας συνήθως έχει ξεχωριστό `Picture` και συλλογή μετασχηματισμών εικόνας.

**Μπορούν τα εφέ χρώματος, θόλωσης και άλφα να συνδυαστούν;**

Ναι. Η συλλογή τα αποδέχεται σε μία διατεταγμένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να απορρίψουν χρώμα ή άλφα που δημιουργήθηκαν νωρίτερα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τις υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργασθείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμού όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για τη διατήρηση μιας αλυσίδας μετασχηματισμών;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντας το ξανά. Το παλαιό PPT δεν μπορεί να αναπαραστήσει όλο το μοντέλο εφέ DrawingML, και οι εξαγώμενες μορφές διατήρούν την εμφάνιση αντί για επεξεργάσιμες λειτουργίες μετασχηματισμού.