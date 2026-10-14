---
title: Μετατροπή διαφανειών PowerPoint σε PNG με PHP
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/php-java/convert-powerpoint-to-png/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PNG
- παρουσίαση σε PNG
- διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- αποθήκευση PPT ως PNG
- αποθήκευση PPTX ως PNG
- εξαγωγή PPT σε PNG
- εξαγωγή PPTX σε PNG
- PHP
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας γρήγορα με το Aspose.Slides για PHP μέσω Java, διασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε διαφάνειες παρουσίασης σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Μπορείτε να φορτώσετε παρουσιάσεις σε μορφές όπως PPT, PPTX και ODP, να αποδώσετε κάθε διαφάνεια και να την αποθηκεύσετε ως ξεχωριστή εικόνα PNG.

Τα παραδείγματα παρακάτω επιδεικνύουν την απόδοση στην προεπιλεγμένη κλίμακα, την αύξηση της κλίμακας, τον καθορισμό των διαστάσεων εξόδου σε εικονοστοιχεία και την επιλογή στυλ απόδοσης διαβάθμισης.

## **Μετατροπή PowerPoint σε PNG**

Φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις διαφάνειες μέσω της συλλογής [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). Το παράδειγμα αποδίδει κάθε διαφάνεια με το [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) χωρίς παραμέτρους για να δημιουργήσει μια μικρογραφία. Στη συνέχεια καλεί το [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) με το [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) για να αποθηκεύσει κάθε αποδιδόμενη διαφάνεια ως εικόνα PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Η υπερφόρτωση [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) χωρίς παραμέτρους αποδίδει με κλίμακα 0.2. Για παράδειγμα, μια διαφάνεια με μέγεθος 720 × 540 σημεία παράγει μικρογραφία 144 × 108 εικονοστοιχεία. Για να ελέγξετε τις διαστάσεις εξόδου, χρησιμοποιήστε τις υπερφορτώσεις με παράγοντες κλίμακας ή ένα ρητό μέγεθος εικόνας όπως φαίνεται παρακάτω.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Περάστε οριζόντιους και κατακόρυφους παράγοντες κλίμακας στο [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) για να ελέγξετε τις αποδιδόμενες διαστάσεις. Σε αυτό το παράδειγμα, και οι δύο παράγοντες είναι 2, έτσι μια διαφάνεια μεγέθους 720 × 540 σημεία παράγει εικόνα 1440 × 1080 εικονοστοιχεία. Οι ίσοι παράγοντες κλίμακας διατηρούν την αναλογία διαστάσεων της διαφάνειας. Κάθε εικόνα αποθηκεύεται σε μορφή PNG με το [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Για να καθορίσετε τις διαστάσεις εξόδου σε εικονοστοιχεία, περάστε ένα μέγεθος στο [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) αντί για παράγοντες κλίμακας. Αυτό το παράδειγμα αποδίδει κάθε διαφάνεια στα 960 × 720 εικονοστοιχεία και αποθηκεύει το αποτέλεσμα με το [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Επιλέξτε διαστάσεις που ταιριάζουν με την αναλογία διαστάσεων της διαφάνειας ώστε να αποφύγετε το τέντωμα της εικόνας.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Επιλογή Στυλ Απεικόνισης Διαβάθμισης**

Υποθέτουμε ότι μια διαφάνεια περιέχει διαβαθμισμένες γεμίσεις, αλλά οι μεταβάσεις στην εξαγόμενη PNG φαίνονται πιο ανοιχτές ή διαφορετικές από ό,τι βλέπετε στο PowerPoint. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) που κληρονομείται από το [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) για να επιλέξετε πώς θα αποδίδονται οι διαβαθμίσεις.

Κατεβάστε το [gradient-styles.pptx](gradient-styles.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη διαφάνειά του περιέχει δύο γραμμικές διαβαθμίσεις: κυανό προς πορτοκαλί στην κορυφή και μπλε προς κίτρινο στο κάτω μέρος. Κάθε διαβάθμιση έχει δύο στάσεις, στο 0% και το 100%.

Το παρακάτω παράδειγμα φορτώνει αυτήν την παρουσίαση και αποδίδει την ίδια πρώτη διαφάνεια και στις δύο λειτουργίες με το [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Οι εικόνες παρακάτω δείχνουν το αποτέλεσμα από την ίδια διαφάνεια, με και τις δύο διαβαθμίσεις σε κάθε εικόνα:

| Default | PowerPointUI |
| --- | --- |
| ![Διαβαθμίσεις από κυανό προς πορτοκαλί και από μπλε προς κίτρινο αποδομένες με Default](gradient-Default.png) | ![Ίδιες διαβαθμίσεις αποδομένες με PowerPointUI](gradient-PowerPointUI.png) |

Σε αυτό το παράδειγμα, το `Default` παράγει πιο ανοιχτά ενδιάμεσα χρώματα, ενώ το `PowerPointUI` παράγει πιο σκούρα ενδιάμεσα χρώματα. Η διαφορά εξαρτάται από τα χρώματα και τις στάσεις στη διαβάθμιση.

Επιλέξτε το `Default` όταν η τυπική έξοδος του Aspose.Slides εξυπηρετεί τις ανάγκες σας. Δοκιμάστε το `PowerPointUI` όταν η προτεραιότητά σας είναι να ταιριάζει με την εμφάνιση στο PowerPoint. Συγκρίνετε και τις δύο εξόδους με το επιθυμητό αποτέλεσμα· καμία λειτουργία δεν είναι γενικά προτιμότερη.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξάγω ένα συγκεκριμένο σχήμα, όπως ένα γράφημα ή εικόνα, αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/php-java/create-shape-thumbnails/), επιτρέποντάς σας να αποδώσετε ένα σχήμα ως εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι. Χρησιμοποιήστε ξεχωριστό αντικείμενο παρουσίασης για κάθε νήμα ή διεργασία· [μην μοιράζεστε ένα ενιαίο αντικείμενο μεταξύ νημάτων](/slides/el/php-java/multithreading/).

**Ποιους περιορισμούς έχει η δοκιμαστική έκδοση κατά την εξαγωγή σε PNG;**

Η δοκιμαστική λειτουργία προσθέτει υδατογράφημα στις εικόνες εξόδου και εφαρμόζει [άλλους περιορισμούς](/slides/el/php-java/licensing/) μέχρι να εφαρμοστεί άδεια.