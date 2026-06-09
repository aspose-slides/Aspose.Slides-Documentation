---
title: Διαχείριση Φόντων Παρουσίασης σε PHP
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/php-java/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- απλό χρώμα
- διαβαθμισμένο χρώμα
- φόντο εικόνας
- διαφάνεια φόντου
- ιδιότητες φόντου
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java, με συμβουλές κώδικα για να ενισχύσετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Τα μονά χρώματα, οι διαβαθμίσεις και οι εικόνες χρησιμοποιούνται συχνά ως φόντο διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μία μεμονωμένη διαφάνεια) ή μια **κύρια διαφάνεια** (εφαρμόζεται σε πολλαπλές διαφάνειες ταυτόχρονα).

![Φόντο PowerPoint](powerpoint-background.png)

## **Ορισμός Σταθερού Χρωματικού Φόντου για Κανονική Διαφάνεια**

Το Aspose.Slides σάς επιτρέπει να ορίσετε ένα μονό χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση—ακόμη και αν η παρουσίαση χρησιμοποιεί μια κύρια διαφάνεια. Η αλλαγή ισχύει μόνο για τη επιλεγμένη διαφάνεια.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/php-java/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του φόντου διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/#getSolidFillColor) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/) για να ορίσετε το μονό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα PHP δείχνει πώς να ορίσετε ένα μπλε μονόχρωμο φόντο για μια κανονική διαφάνεια:

```php
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ορίστε το χρώμα φόντου της διαφάνειας σε μπλε.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Σταθερού Χρωματικού Φόντου για Κύρια Διαφάνεια**

Το Aspose.Slides σάς επιτρέπει να ορίσετε ένα μονό χρώμα ως φόντο για τη κύρια διαφάνεια σε μια παρουσίαση. Η κύρια διαφάνεια λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση όλων των διαφανειών, έτσι όταν επιλέγετε ένα μονό χρώμα για το φόντο της κύριας διαφάνειας, εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/php-java/aspose.slides/backgroundtype/) της κύριας διαφάνειας (μέσω `getMasters`) σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του φόντου της κύριας διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/#getSolidFillColor) για να ορίσετε το μονό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα PHP δείχνει πώς να ορίσετε ένα μονό χρώμα (πράσινο) ως φόντο για μια κύρια διαφάνεια:

```php
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Ορίστε το χρώμα φόντου για τη κύρια διαφάνεια σε Πράσινο δάσους.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Διαβαθμισμένου Φόντου για Διαφάνεια**

Η διαβαθμίση είναι ένα γραφικό εφέ που δημιουργείται από σταδιακή αλλαγή του χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, οι διαβαθμίσεις μπορούν να κάνουν τις παρουσιάσεις να φαίνονται πιο καλλιτεχνικές και επαγγελματικές. Το Aspose.Slides σάς επιτρέπει να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για διαφάνειες.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/php-java/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του φόντου διαφάνειας σε `Gradient`.
4. Χρησιμοποιήστε τη μέθοδο [getGradientFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/#getGradientFormat) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/) για να ρυθμίσετε τις προτιμώμενες ρυθμίσεις διαβαθμίσεων.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα PHP δείχνει πώς να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για μια διαφάνεια:

```php
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Εφαρμόστε εφέ διαβάθμισης στο φόντο.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Επιπλέον των μονών και διαβαθμισμένων γεμισμάτων, το Aspose.Slides σάς επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφανειών.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/php-java/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του φόντου διαφάνειας σε `Picture`.
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε τη μέθοδο [getPictureFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/#getPictureFillFormat) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/) για να ορίσετε την εικόνα ως φόντο.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα PHP δείχνει πώς να ορίσετε μια εικόνα ως φόντο για μια διαφάνεια:

```php
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ορίστε τις ιδιότητες εικόνας φόντου.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Φορτώστε την εικόνα.
    $image = Images::fromFile("Tulips.jpg");
    // Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσματος φόντου σε πλακιδική εικόνα και να τροποποιήσετε τις ιδιότητες πλακιδίου:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Ορίστε την εικόνα που χρησιμοποιείται για το γέμισμα φόντου.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Ορίστε τη λειτουργία γεμίσματος εικόνας σε Πλακίδιο και προσαρμόστε τις ιδιότητες του πλακιδίου.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Διαβάστε περισσότερα: [**Εικόνα Πλακιδίου Ως Υφή**](/slides/el/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή Διαφάνειας Εικόνας Φόντου**

Μπορεί να θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Το παρακάτω κώδικα PHP σας δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```php
$transparencyValue = 30; // Για παράδειγμα.

// Get the collection of picture transform operations.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Find an existing fixed-percentage transparency effect.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Set the new transparency value.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Λήψη Τιμής Φόντου Διαφάνειας**

Το Aspose.Slides παρέχει την κλάση `BackgroundEffectiveData` για τη λήψη των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτή η κλάση εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/) και [EffectFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/effectformat/).

Χρησιμοποιώντας τη μέθοδο `getBackground` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/), μπορείτε να λάβετε το αποτελεσματικό φόντο για μια διαφάνεια.

Το παρακάτω παράδειγμα PHP δείχνει πώς να λάβετε την αποτελεσματική τιμή φόντου μιας διαφάνειας:

```php
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ανακτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη τη κύρια διαφάνεια, τη διάταξη και το θέμα.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να επαναφέρω το φόντο θέματος/διάταξης;**

Ναι. Αφαιρέστε το προσαρμοσμένο γεμισμα της διαφάνειας και το φόντο θα κληρονομηθεί ξανά από την αντίστοιχη [διάταξη](/slides/el/php-java/slide-layout/)/[κύρια](/slides/el/php-java/slide-master/) διαφάνεια (δηλαδή το [φόντο θέματος](/slides/el/php-java/presentation-theme/)).

**Τι συμβαίνει με το φόντο αν αλλάξω αργότερα το θέμα της παρουσίασης;**

Αν μια διαφάνεια έχει το δικό της γεμισμα, θα παραμείνει αμετάβλητο. Αν το φόντο κληρονομείται από τη [διάταξη](/slides/el/php-java/slide-layout/)/[κύρια](/slides/el/php-java/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [νέο θέμα](/slides/el/php-java/presentation-theme/)).