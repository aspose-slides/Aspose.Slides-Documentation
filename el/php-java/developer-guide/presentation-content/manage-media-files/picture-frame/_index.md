---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις με PHP
linktitle: Πλαίσιο εικόνας
type: docs
weight: 10
url: /el/php-java/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- ενσωματωμένη εικόνα
- συνδεδεμένη εικόνα
- εξαγωγή εικόνας
- ραστερ εικόνα
- εικόνα SVG
- περικοπή εικόνας
- διαγραφή περικομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, περικόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω του [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/), ενώ ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διάσπαση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας κατά τη δημιουργία πλαισίων εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνων όπως PNG ή JPEG και διανυσματικές εικόνες SVG. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος του αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, επομένως είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addpictureframe/). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, έτσι η παρουσίαση παραμένει αυτόνομη όταν μεταφερθεί σε άλλον υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια JPEG εικόνα, δημιουργεί ένα πλαίσιο με τις αρχικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που είναι αποθηκευμένες στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόπτεται ή συμπιέζεται μια εικόνα αργότερα.

## **Χρήση σχετικής κλίμακας**

[PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) εκθέτει σχετικό πλάτος και ύψος κλιμάκωσης για το πλαίσιο μέσω των [setRelativeScaleWidth](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/setrelativescalewidth/) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τις τελικές διαστάσεις χειροκίνητα.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν κάνει ξαναδειγματοληψία ή συμπίεση της ενσωματωμένης εικόνας.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και είναι επομένως η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική διαδρομή μέσω της μεθόδου [Picture::setLinkPathLong](https://reference.aspose.com/slides/el/php-java/aspose.slides/picture/setlinkpathlong/) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο από την εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα μπορεί να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να αποσταλούν με email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το συνδέει με ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμιγνύεται σε αυτό το παράδειγμα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Χρησιμοποιήστε συνδέσμους όταν η διαχείριση εξωτερικών αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως υποκατάστατο συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτόνομη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξάγετε μια εικόνα από υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πράγματι ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ραστερ εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί άμεσα το [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/). Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Η αποθήκευση μέσω του [IImage::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/#save) μετατρέπει την εξαχθείσα εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που αποθηκεύονται στην παρουσίαση αντί για ένα μετατρεπόμενο ραστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή εικόνας SVG**

Για μια SVG εικόνα, το [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) εκθέτει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG άμεσα αντί να ραστεροποιήσετε την εικόνα πρώτα.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι ραστερ εξαγωγές όπως PNG ή JPEG απαραίτητα αποδίδουν αυτό το διανυσματικό περιεχόμενο σε pixel. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης λειτουργία απόδοσης, οπότε τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφα byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του ενσωματωμένου [SvgImage::getSvgData](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/getsvgdata/) όταν απαιτείται ο ίδιος ο διανυσματικός πόρος.

## **Περικοπή εικόνας**

Η περικοπή αλλάζει ποιο τμήμα μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [PictureFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή δεν διαγράφει αρχικά τα κρυμμένα pixel από την ενσωματωμένη εικόνα· απλώς αλλάζει την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει με ασφάλεια ένα πλαίσιο εικόνας και εφαρμόζει τιμές περικοπής:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Επειδή τα κρυμμένα δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να αλλάξει αργότερα χωρίς να χαθούν τα αρχικά pixel. Εάν το μέγεθος του αρχείου είναι πιο σημαντικό από την αναστρεψιμότητα, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων περικομμένης εικόνας**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) αφαιρεί δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρεμένα pixel δεν είναι πλέον διαθέσιμα για μετέπειτα αποκοπή‑αποπλήρωση.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
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
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο, οπότε η διαγραφή των περικομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεροποιεί το περικομμένο αποτέλεσμα σε PNG.

## **Συμπίεση ραστερ εικόνων**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) μειώνει την ανάλυση ραστερ εικόνας σε σχέση με το μέγεθος με το οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει τις περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα έχει μειωθεί ή περικοπεί και `false` όταν δεν χρειάστηκε αλλαγή.

Χρησιμοποιήστε μια προ-ορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturescompression/) όταν ένα τυπικό στόχο ανάλυσης είναι επαρκής:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Μπορείτε επίσης να περάσετε μια προσαρμοσμένη θετική τιμή DPI αντί για προ‑ορισμένη τιμή όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το περιεχόμενο SVG και των μετααρχείων δεν μειώνεται από αυτή τη ροή συμπίεσης ραστερ. Επίσης θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες περικομμένες περιοχές δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης με βάση το μεγαλύτερο μέγεθος στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Διαχείριση εφέ μετασχηματισμού εικόνας**

Για πλήρη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, χρωματικούς μετασχηματισμούς, θόλωση, εφέ άλφα, αλυσίδες, επιθεώρηση, αφαίρεση και επαλήθευση γύρω‑γύρω, δείτε [Image Transform Effects](/slides/el/php-java/image-transform-effects/).

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις [PictureFrameLock](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το [setAspectRatioLocked](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) διατηρεί τις αναλογίες του σχήματος ενώ αυτό αναδιπλώνεται.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να ξαναδειγματοληφθεί ή να αλλάξει μόνιμα σε ίδια αναλογία διαστάσεων.

## **Προσαρμογή τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι “stretch”, οι τιμές stretch‑offset στο [PictureFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/) καθορίζουν το ορθογώνιο γέμισμα σε σχέση με το πλαίσιο του πλαισίου εικόνας. Τα θετικά ποσοστά δημιουργούν εσωτερική απόσταση από μια άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν εξωτερική απόσταση.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι stretch‑offset αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γέμισμα εικόνας.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Χρησιμοποιήστε stretch‑offset για τοποθέτηση γεμίσματος. Χρησιμοποιήστε ιδιότητες περικοπής όταν ο στόχος είναι η απόκρυψη άκρων της πηγαίας εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και σκέψεις εξαγωγής**

Τα κύρια εμπόδια γίνονται ευκολότερα διαχειρίσιμα όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση στο διακομιστή, αλλά οι μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή τοποθεσίες.
- **Περικοπή** είναι αρχικά μη καταστροφική. Τα κρυμμένα pixel παραμένουν ενσωματωμένα μέχρι οι περικομμένες περιοχές να διαγραφούν ρητά ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθη ραστερ εικόνες, αλλά θυσιάζει την πηγαία ανάλυση. Πρέπει να εφαρμοστεί μετά τον καθορισμό του τελικού μεγέθους στην διαφάνεια.
- **Εικόνες SVG** πρέπει να διατηρούνται ως SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG άμεσα όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι ραστερ εξαγωγές διαφάνειας πάντα μετατρέπουν τη διαφάνεια σε pixel.
- **Επαναλαμβανόμενες εικόνες** πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [PPImage] όταν είναι δυνατόν αντί να φορτώνουν επανειλημμένα το ίδιο αρχείο στη ροή εργασίας παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν γίνεται επιλεκτικά: κρατήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες σύμφωνα με το πραγματικό μέγεθος εμφάνισης, αφαιρέστε τα περικομμένα pixel μόνο όταν δεν απαιτείται περαιτέρω επεξεργασία, και αποφύγετε εξωτερικούς συνδέσμους εκτός αν η διαχείριση εξαρτήσεων είναι μέρος του σχεδιασμού ανάπτυξης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου εικόνας και πόρου εικόνας;**

Ένα [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) είναι ένα σχήμα σε διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Να ενσωματώσω ή να συνδέσω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή να αποδίδεται χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές τοποθεσίες μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν μέρη της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε το [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ή τη συμπίεση εικόνας με αφαίρεση περικομμένων περιοχών όταν τα pixel μπορούν να διαγραφούν μόνιμα.

**Μπορώ να επαναφέρω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση, και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Κρατήστε την αρχική πηγή εικόνας εκτός της παρουσίασης εάν μπορεί να χρειαστεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις εικόνες SVG;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η πιστότητα διανύσματος έχει σημασία. Το ενσωματωμένο [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/) μπορεί να εξαχθεί άμεσα. Η απόδοση μιας διαφάνειας σε ραστερ μορφή όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπων όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Μια εξακρίβωση `java_instanceof` έναντι του [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) αποτρέπει ακατάλληλες μετατροπές τύπων και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.