---
title: Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες σε PHP
linktitle: Διαφάνεια σε Εικόνα
type: docs
weight: 35
url: /el/php-java/convert-slide/
keywords:
- μετατροπή διαφάνειας
- εξαγωγή διαφάνειας
- διαφάνεια σε εικόνα
- αποθήκευση διαφάνειας ως εικόνα
- διαφάνεια σε EMF
- διαφάνεια σε PNG
- διαφάνεια σε JPEG
- διαφάνεια σε bitmap
- διαφάνεια σε TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες από παρουσιάσεις PPT, PPTX και ODP σε PNG, JPEG, GIF, TIFF, EMF και άλλες μορφές εικόνας σε PHP με Aspose.Slides."
---
## **Εισαγωγή**

Το Aspose.Slides for PHP via Java μπορεί να αποδώσει μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument ως PNG, JPEG, GIF, TIFF και άλλες μορφές εικόνας.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε αυτά τα βήματα:

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Επιλέξτε τη διαφάνεια που θέλετε να αποδώσετε.
3. Εάν είναι απαραίτητο, διαμορφώστε την απόδοση με την κλάση [RenderingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/renderingoptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/).
4. Καλέστε τη μέθοδο [Slide::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getImage). Επιστρέφει ένα αντικείμενο τύπου [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/).
5. Καλέστε τη μέθοδο [IImage::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/#save) και καθορίστε τη μορφή εξόδου με μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/imageformat/).

## **Μετατροπή Διαφάνειας σε Εικόνα PNG**

Η πιο απλή μετατροπή χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις απόδοσης. Το προκύπτον αντικείμενο [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) μπορεί να επεξεργαστεί στη μνήμη ή να αποθηκευτεί σε αρχείο.

Το παρακάτω παράδειγμα PHP αποδίδει την πρώτη διαφάνεια και την αποθηκεύει ως εικόνα PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Μετατροπή Διαφανειών σε Εικόνες με Προσαρμοσμένα Μεγέθη**

Χρησιμοποιήστε την υπερφόρτωση της μεθόδου [Slide::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getImage) που δέχεται μια τιμή [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) για να αποδώσετε μια διαφάνεια με ακριβείς διαστάσεις εικονοστοιχείων.

Το παρακάτω παράδειγμα δημιουργεί μια εικόνα JPEG 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Μετατροπή Διαφανειών με Σημειώσεις και Σχόλια σε Εικόνες**

Από προεπιλογή, οι εικόνες διαφανειών δεν περιλαμβάνουν σημειώσεις ή σχόλια. Περάστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/notescommentslayoutingoptions/) στη μέθοδο [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) για να ελέγξετε πού εμφανίζονται οι σημειώσεις και τα σχόλια.

Το παρακάτω παράδειγμα τοποθετεί περικομμένες σημειώσεις κάτω από τη διαφάνεια και σχόλια στα δεξιά της:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Για τη μετατροπή διαφάνειας σε εικόνα, μην περάσετε το [BottomFull](https://reference.aspose.com/slides/el/php-java/aspose.slides/notespositions/) στη μέθοδο [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/el/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Οι σημειώσεις μπορεί να περιέχουν περισσότερο κείμενο από ό,τι μπορεί να χωρέσει το σταθερό μέγεθος της εικόνας. Χρησιμοποιήστε το [BottomTruncated](https://reference.aspose.com/slides/el/php-java/aspose.slides/notespositions/) αντί αυτού.
{{% /alert %}}

## **Μετατροπή Διαφανειών σε Εικόνες Χρησιμοποιώντας Επιλογές TIFF**

Η κλάση [TiffOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/) σας επιτρέπει να ελέγξετε το μέγεθος, την ανάλυση και άλλες ιδιότητες της παραγόμενης εικόνας TIFF.

Το παρακάτω παράδειγμα αποδίδει την πρώτη διαφάνεια ως εικόνα TIFF 2160 × 2880 σε 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Η υποστήριξη TIFF δεν είναι εγγυημένη σε εκδόσεις Java παλαιότερες από το JDK 9.
{{% /alert %}}

## **Μετατροπή Όλων των Διαφανειών σε Εικόνες**

Επαναλάβετε τη συλλογή των διαφανειών για να μετατρέψετε όλη την παρουσίαση σε μια σειρά εικόνων. Οι κρυμμένες διαφάνειες περιλαμβάνονται εκτός αν τις παραλείψετε ρητά.

Το παρακάτω παράδειγμα αποδίδει κάθε διαφάνεια ως εικόνα JPEG με οριζόντιους και κατακόρυφους συντελεστές κλίμακας ίσους με 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Δημιουργία Εξόδου Enhanced Metafile**

Το Enhanced Metafile (EMF) είναι χρήσιμο όταν γραφικά βασισμένα σε διανύσματα πρέπει να ανταλλαγούν με το Microsoft Office ή άλλες εφαρμογές Windows που υποστηρίζουν Windows metafiles. Σε αντίθεση με μια εικόνα βασισμένη σε εικονοστοιχεία, ένα EMF μπορεί να διατηρήσει τις διανυσματικές λειτουργίες σχεδίασης που κλιμακώνονται χωρίς την ίδια απώλεια ακρίβειας. Ωστόσο, το EMF είναι κυρίως μια μορφή συμβατότητας για εφαρμογές με υποστήριξη Windows metafile, όχι μια καθολική μορφή ανταλλαγής. Επιπλέον, περίπλοκο περιεχόμενο διαφάνειας, όπως εικόνες bitmap και ορισμένα εφέ, μπορεί να αποθηκευτεί ως ραστεροποιημένα στοιχεία μέσα στο διανυσματικό container του metafile.

### **Εξαγωγή Διαφάνειας σε EMF**

Η μέθοδος [Slide::writeAsEmf](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#writeAsEmf) γράφει μια διαφάνεια σε ροή-στόχο σε μορφή EMF. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, επιλέγει την πρώτη διαφάνεια και τη γράφει σε ροή αρχείου EMF:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Ο καλών έχει την κυριότητα της ροής που περνά στη [Slide::writeAsEmf](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#writeAsEmf) και είναι υπεύθυνος για το κλείσιμο της, όπως φαίνεται παραπάνω.

### **Μετατροπή Εικόνας SVG σε EMF και Προσθήκη της σε Παρουσίαση**

Χρησιμοποιήστε τη [SvgImage::writeAsEmf](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/#writeAsEmf) για να μετατρέψετε περιεχόμενο SVG σε EMF. Τα προκύπτοντα bytes μπορούν να προστεθούν στην παρουσίαση μέσω της [ImageCollection::addImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/#addImage) και να τοποθετηθούν σε μια διαφάνεια με την [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addPictureFrame).

Το παρακάτω παράδειγμα δημιουργεί ένα [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/) από σήμανση SVG, το μετατρέπει σε EMF στη μνήμη, εισάγει το metafile στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η [SvgImage::writeAsEmf](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/#writeAsEmf) δεν αποκτά την κυριότητα της ροής προορισμού. Ένα [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) αποθηκεύει όλα τα παραγόμενα δεδομένα στη μνήμη, έτσι δεν απαιτείται επαναφορά της θέσης πριν από την κλήση του `toByteArray`. Ο επιστραφόμενος πίνακας byte παραμένει έγκυρος μετά το κλείσιμο της ροής.

Η δημιουργία EMF είναι διαθέσιμη στα λειτουργικά συστήματα που υποστηρίζονται από την επιλεγμένη διαμόρφωση Aspose.Slides for PHP via Java και JDK, αλλά η απόδοση μπορεί να διαφέρει ανά πλατφόρμα όταν δεν υπάρχουν διαθέσιμες γραμματοσειρές ή εξαρτήσεις γραφικών. Εγκαταστήστε τις γραμματοσειρές που χρησιμοποιεί το πηγαίο περιεχόμενο ή διαμορφώστε κατάλληλες εναλλακτικές, ακολουθήστε τις [platform requirements](/slides/el/php-java/system-requirements/) για το Aspose.Slides for PHP via Java, και επαληθεύστε το αποτέλεσμα στην εφαρμογή-καταναλωτή EMF. Οι εφαρμογές Linux και macOS συχνά έχουν περιορισμένη ή ασυνεπή υποστήριξη για εμφάνιση και επεξεργασία Windows metafiles.

## **Απόδοση Έγχρωμων Emoji**

{{% alert title="Note" color="info" %}}
Για τη σωστή απόδοση έγχρωμων emoji κατά τη μετατροπή των διαφανειών παρουσίασης σε εικόνες, οι γραμματοσειρές emoji που χρησιμοποιούνται στην παρουσίαση πρέπει να είναι εγκατεστημένες και διαθέσιμες στο σύστημα που εκτελεί τη μετατροπή. Για παράδειγμα, εάν η παρουσίαση χρησιμοποιεί τη γραμματοσειρά **Segoe UI Emoji** και αυτή λείπει, τα emoji μπορεί να εμφανιστούν σε μονόχρωμη μορφή στις εικόνες εξόδου.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides την απόδοση διαφανειών με κινούμενα σχέδια;**

Όχι. Η μέθοδος [Slide::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getImage) αποδίδει μια στατική εικόνα της διαφάνειας και δεν εξάγει τις κινήσεις.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι. Οι κρυμμένες διαφάνειες μπορούν να αποδοθούν όπως και οι κανονικές. Συμπεριλάβετε τις στον βρόχο επεξεργασίας, όπως φαίνεται στο παραπάνω παράδειγμα.

**Διατηρούνται οι σκιές και άλλα εφέ στις εικόνες των διαφανειών;**

Ναι. Το Aspose.Slides αποδίδει σκιές, διαφάνεια και άλλα υποστηριζόμενα γραφικά εφέ στις εικόνες των διαφανειών.