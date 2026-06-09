---
title: Δημιουργία προβολέα παρουσίασης σε PHP
linktitle: Προβολέας παρουσίασης
type: docs
weight: 50
url: /el/php-java/presentation-viewer/
keywords:
- προβολή παρουσίασης
- προβολέας παρουσίασης
- δημιουργία προβολέα παρουσίασης
- προβολή PPT
- προβολή PPTX
- προβολή ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε έναν προσαρμοσμένο προβολέα παρουσίασης χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Εύκολη προβολή αρχείων PowerPoint και OpenDocument χωρίς το Microsoft PowerPoint."
---
## **Εισαγωγή**

Aspose.Slides for PHP via Java χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης με διαφάνειες. Αυτές οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τις παρουσιάσεις στο Microsoft PowerPoint, για παράδειγμα. Ωστόσο, μερικές φορές οι προγραμματιστές μπορεί να χρειαστούν να προβάλουν τις διαφάνειες ως εικόνες στον προτιμώμενο προβολέα εικόνας ή να δημιουργήσουν τον δικό τους προβολέα παρουσίασης. Σε τέτοιες περιπτώσεις, το Aspose.Slides σας επιτρέπει να εξάγετε μια μεμονωμένη διαφάνεια ως εικόνα. Αυτό το άρθρο περιγράφει πώς να το κάνετε.

## **Δημιουργία εικόνας SVG από διαφάνεια**

Για να δημιουργήσετε μια εικόνα SVG από μια διαφάνεια παρουσίασης με το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με βάση το δείκτη της.
1. Ανοίξτε μια ροή αρχείου.
1. Αποθηκεύστε τη διαφάνεια ως εικόνα SVG στη ροή αρχείου.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Δημιουργία SVG με προσαρμοσμένο αναγνωριστικό σχήματος**

Το Aspose.Slides μπορεί να χρησιμοποιηθεί για τη δημιουργία ενός [SVG](https://docs.fileformat.com/page-description-language/svg/) από μια διαφάνεια με προσαρμοσμένο αναγνωριστικό σχήματος. Για να το κάνετε αυτό, χρησιμοποιήστε τη μέθοδο `setId` από το [SvgShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgshape/). Η κλάση `CustomSvgShapeFormattingController` μπορεί να χρησιμοποιηθεί για να ορίσει το αναγνωριστικό σχήματος.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **Δημιουργία εικόνας μικρογραφίας διαφάνειας**

Aspose.Slides σας βοηθά να δημιουργήσετε εικόνες μικρογραφιών διαφανειών. Για να δημιουργήσετε μια μικρογραφία μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με βάση το δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφοράς διαφάνειας σε καθορισμένη κλίμακα.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Δημιουργία μικρογραφίας διαφάνειας με διαστάσεις ορισμένες από τον χρήστη**

Για να δημιουργήσετε μια εικόνα μικρογραφίας διαφάνειας με διαστάσεις που καθορίζονται από τον χρήστη, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με βάση το δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφοράς διαφάνειας με τις καθορισμένες διαστάσεις.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Δημιουργία μικρογραφίας διαφάνειας με σημειώσεις ομιλητή**

Για να δημιουργήσετε τη μικρογραφία μιας διαφάνειας με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [RenderingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/renderingoptions/).
1. Χρησιμοποιήστε τη μέθοδο `RenderingOptions.setSlidesLayoutOptions` για να ορίσετε τη θέση των σημειώσεων ομιλητή.
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε την αναφορά της διαφάνειας με βάση το δείκτη της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφοράς διαφάνειας με τις επιλογές απόδοσης.
1. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμητή μορφή εικόνας.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Ζωντανό Παράδειγμα**

Μπορείτε να δοκιμάσετε τη δωρεάν εφαρμογή [**Aspose.Slides Viewer**](https://products.aspose.app/slides/el/viewer/) για να δείτε τι μπορείτε να υλοποιήσετε με το API του Aspose.Slides:

![Online Προβολέας PowerPoint](online-PowerPoint-viewer.png)

## **Συχνές ερωτήσεις**

**Μπορώ να ενσωματώσω έναν προβολέα παρουσίασης σε μια εφαρμογή web;**

Ναι. Μπορείτε να χρησιμοποιήσετε το Aspose.Slides στην πλευρά του διακομιστή για να αποδίδετε διαφάνειες ως εικόνες ή HTML και να τις εμφανίζετε στον πρόγραμμα περιήγησης. Οι λειτουργίες πλοήγησης και ζουμ μπορούν να υλοποιηθούν με JavaScript για μια διαδραστική εμπειρία.

**Ποιος είναι ο καλύτερος τρόπος για να εμφανίσετε διαφάνειες μέσα σε έναν προσαρμοσμένο προβολέα;**

Η συνιστώμενη προσέγγιση είναι να αποδίδετε κάθε διαφάνεια ως εικόνα (π.χ., PNG ή SVG) ή να τη μετατρέψετε σε HTML χρησιμοποιώντας το Aspose.Slides, και στη συνέχεια να εμφανίσετε το αποτέλεσμα μέσα σε ένα picture box (για επιφάνεια εργασίας) ή σε έναν HTML container (για το web).

**Πώς να διαχειριστείτε μεγάλες παρουσιάσεις με πολλές διαφάνειες;**

Για μεγάλα σετ διαφανειών, εξετάστε τη φόρτωση με καθυστέρηση (lazy-loading) ή την απόδοση κατά απαίτηση των διαφανειών. Αυτό σημαίνει ότι το περιεχόμενο μιας διαφάνειας δημιουργείται μόνο όταν ο χρήστης μεταβεί σε αυτήν, μειώνοντας τη μνήμη και το χρόνο φόρτωσης.