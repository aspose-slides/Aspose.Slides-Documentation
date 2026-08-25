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
- εικόνα raster
- SVG εικόνα
- περικοπή εικόνας
- διαγραφή περικομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- λόγος διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, περικόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) διαχειρίζεται ενσωματωμένους πόρους εικόνας μέσω του [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/), ενώ ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διαχωριστική προσέγγιση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, διατηρήστε το επιστρεφόμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας κατά τη δημιουργία πλαισίων εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστέρ εικόνες όπως PNG ή JPEG και διανυσματικές SVG εικόνες. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος του αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, οπότε είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addpictureframe/). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, οπότε η παρουσίαση παραμένει αυτόνομη όταν μετακινηθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια εικόνα JPEG, δημιουργεί ένα πλαίσιο στις εγγενείς διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

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

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόπτε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση σχετικής κλίμακας**

[PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) παρέχει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο μέσω των μεθόδων [setRelativeScaleWidth](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/setrelativescalewidth/) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τις τελικές διαστάσεις χειροκίνητα.

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

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ή συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και είναι επομένως η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική θέση μέσω της μεθόδου [Picture::setLinkPathLong](https://reference.aspose.com/slides/el/php-java/aspose.slides/picture/setlinkpathlong/) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά δημιουργούν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα ενδέχεται να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να αποσταλούν μέσω email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το συνδέει με ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμειγνύεται σε αυτό το παράδειγμα.

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

Χρησιμοποιήστε συνδέσμους όταν η διαχείριση εξωτερικών αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως υποκατάστατο συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτόνομα ολοκληρωμένη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Προτού εξάγετε μια εικόνα από υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πράγματι ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν τα δεδομένα εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ραστέρ εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί άμεσα το [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/). Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη ραστέρ εικόνα σε διαφάνεια και την αποθηκεύει ως PNG:

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

Η αποθήκευση μέσω του [IImage::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/#save) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που είναι αποθηκευμένα στην παρουσίαση αντί για ένα μετασχηματισμένο ραστέρ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG εικόνας**

Για μια SVG εικόνα, το [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) εκθέτει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG άμεσα αντί να ραστεριζάτε την εικόνα πρώτα.

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

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι ραστέρ εξαγωγές όπως PNG ή JPEG εξαναγκάζουν το διανυσματικό περιεχόμενο να αποδοθεί σε pixel. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης λειτουργία απόδοσης, οπότε τα εξαγόμενα γραφικά δεν πρέπει να θεωρηθούν ακριβές αντίγραφα του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του [SvgImage::getSvgData](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/getsvgdata/) όταν απαιτείται ο ίδιος ο διανυσματικός πόρος.

## **Περικοπή εικόνας**

Η περικοπή αλλάζει ποιο τμήμα μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [PictureFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή δεν διαγράφει άμεσα τα κρυφά pixel από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

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

Επειδή τα κρυφά δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να τροποποιηθεί αργότερα χωρίς απώλεια των αρχικών pixel. Εάν το μέγεθος του αρχείου έχει μεγαλύτερη σημασία από την αναστρέψιμη επεξεργασία, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων περικομμένης εικόνας**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: αφού η παρουσίαση αποθηκευτεί, τα αφαιρεμένα pixel δεν είναι πλέον διαθέσιμα για μετέπειτα αναιρέση της περικοπής.

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

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχον πόρο, οπότε η διαγραφή των περικομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεριάζει το αποτέλεσμα σε PNG.

## **Συμπίεση ραστέρ εικόνων**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) μειώνει την ανάλυση ραστέρ εικόνας σχετικά με το μέγεθος με το οποίο εμφανίζεται η εικόνα. Μπορεί επίσης να αφαιρέσει τις περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα έχει αλλάξει μέγεθος ή περικοπεί και `false` όταν δεν απαιτήθηκε καμία αλλαγή.

Χρησιμοποιήστε μια προ‑ορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturescompression/) όταν η τυπική στόχευση ανάλυσης είναι επαρκής:

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

Μια προσαρμοσμένη θετική τιμή DPI μπορεί να περάσει αντί για προ‑ορισμένη τιμή όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστέρ εικόνες. Το SVG και το περιεχόμενο μεταφαίσιας δεν μειώνεται από αυτή τη ροή συμπίεσης ραστέρ. Επίσης, θυμηθείτε ότι η μείωση της ανάλυσης και η διαγραφή των περικομμένων περιοχών δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης βάσει του μεγαλύτερου μεγέθους στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί, αντί να εφαρμόζετε το χαμηλότερο DPI σε ολόκληρο το αρχείο.

## **Διαχείριση εφέ μετασχηματισμού εικόνας**

Για πλήρη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, μετασχηματισμούς χρωμάτων, θόλωση, εφέ άλφα, αλυσίδες, επιθεώρηση, αφαίρεση και επαλήθευση γύρω, δείτε [Image Transform Effects](/php-java/image-transform-effects/).

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις [PictureFrameLock](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το [setAspectRatioLocked](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) διατηρεί τις αναλογίες του σχήματος ενώ αλλάζει το μέγεθός του.

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

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν επιβάλλει την επαναδειγματοληψία ή μόνιμη αλλαγή της πηγαίας εικόνας για να ταιριάξει στον ίδιο λόγο διαστάσεων.

## **Προσαρμογή τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι stretch, οι τιμές stretch‑offset στο [PictureFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/) ορίζουν το γεωμετρικό ορθογώνιο γεμίσματος σχετικά με το περιθώριο του πλαισίου εικόνας. Θετικά ποσοστά δημιουργούν εσωτερική απόσταση από την άκρη, ενώ αρνητικά ποσοστά δημιουργούν εξωτερική απόσταση.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι offset stretch αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γεμιστό περιεχόμενο.

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

Χρησιμοποιήστε stretch offsets για τοποθέτηση γεμίσματος. Χρησιμοποιήστε ιδιότητες περικοπής όταν ο στόχος είναι απόκρυψη των άκρων της πηγαίας εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και σκέψεις εξαγωγής**

Τα κύρια πλεονεκτήματα είναι πιο εύκολα στη διαχείριση όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση στον διακομιστή, αλλά μεγάλες ραστέρ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να κρατήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή θέσεις.
- **Περικοπή** είναι αρχικά μη καταστροφική. Τα κρυφά pixel παραμένουν ενσωματωμένα μέχρι να διαγραφούν οι περικομμένες περιοχές ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερβολικές ραστέρ εικόνες, αλλά θυσιάζει την αρχική ανάλυση. Πρέπει να εφαρμοστεί αφού καθοριστεί το επιθυμητό μέγεθος εμφάνισης στη διαφάνεια.
- **SVG εικόνες** πρέπει να παραμένουν ως SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG άμεσα όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι εξαγωγές διαφάνειας σε raster μορφή μετατρέπουν πάντα τη διαφάνεια σε pixel.
- **Επαναλαμβανόμενες εικόνες** θα πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) όταν είναι δυνατόν αντί να φορτώνουν ξανά το ίδιο αρχείο στη ροή εργασίας παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποδοτική όταν γίνεται επιλεκτικά: κρατήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες ανάλογα με το πραγματικό μέγεθος εμφάνισης, αφαιρέστε τα περικομμένα pixel μόνο όταν δεν απαιτείται μετέπειτα επεξεργασία, και αποφύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδιασμού ανάπτυξης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου εικόνας και ενός πόρου εικόνας;**

Ένα [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) είναι ένα σχήμα σε διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώνω ή να συνδέω τις εικόνες;**

Ενσωματώστε τις εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή να αποδίδεται χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε τις εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές θέσεις μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν τμήματα της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε το [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ή τη συμπίεση εικόνας με αφαίρεση περικομμένων περιοχών όταν τα pixel μπορούν να απομακρυνθούν μόνιμα.

**Μπορώ να επαναφέρω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ανάλυση raster, και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγή εικόνας εκτός της παρουσίασης εάν ενδέχεται να χρειαστεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η ακρίβεια του διανύσματος είναι σημαντική. Το ενσωματωμένο [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/) μπορεί να εξαχθεί άμεσα. Η απόδοση μιας διαφάνειας σε raster μορφή όπως PNG ή JPEG ραστεριάζει το SVG ως μέρος της εικόνας διαφάνειας.

**Πώς μπορώ να αποφύγω επικίνδυνες μετατροπές τύπων όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Μια `java_instanceof` ελέγχη κατά το [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) αποτρέπει μη έγκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.