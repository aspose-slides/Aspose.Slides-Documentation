---
title: "Αποθήκευση Παρουσιάσεων σε PHP"
linktitle: "Αποθήκευση Παρουσίασης"
type: docs
weight: 80
url: /el/php-java/save-presentation/
keywords:
- "αποθήκευση PowerPoint"
- "αποθήκευση OpenDocument"
- "αποθήκευση παρουσίασης"
- "αποθήκευση διαφάνειας"
- "αποθήκευση PPT"
- "αποθήκευση PPTX"
- "αποθήκευση ODP"
- "παρουσίαση σε αρχείο"
- "παρουσίαση σε ροή"
- "προκαθορισμένος τύπος προβολής"
- "Αυστηρή μορφή Office Open XML"
- "λειτουργία Zip64"
- "ανανέωση μικρογραφίας"
- "πρόοδος αποθήκευσης"
- PHP
- Aspose.Slides
description: "Αποθήκευση παρουσιάσεων PowerPoint και OpenDocument σε αρχεία ή ροές σε PHP με Aspose.Slides, και διαμόρφωση εξόδου PPTX και αναφοράς προόδου."
---
## **Επισκόπηση**

Αφού δημιουργήσετε μια παρουσίαση ή [ανοίξετε ένα υπάρχον](/slides/el/php-java/open-presentation/), χρησιμοποιήστε τη μέθοδο [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) για να γράψετε το αποτέλεσμα. Το Aspose.Slides for PHP via Java μπορεί να αποθηκεύσει μια παρουσίαση σε αρχείο ή ροή σε μορφές PowerPoint, OpenDocument, PDF και άλλες μορφές. Οι παρακάτω ενότητες καλύπτουν τις τυπικές λειτουργίες αποθήκευσης και τις διαθέσιμες επιλογές για έξοδο PPTX.

## **Αποθήκευση παρουσιάσεων σε αρχεία**

Για να αποθηκεύσετε μια παρουσίαση σε αρχείο, περάστε τη διαδρομή εξόδου και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/) στη μέθοδο [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save). Η τιμή μορφής καθορίζει τον τύπο του αρχείου που δημιουργεί το Aspose.Slides.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει ως αρχείο PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Προσθήκη ή τροποποίηση περιεχομένου παρουσίασης εδώ.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση παρουσιάσεων στην αρχική τους μορφή**

Για παραδείγματα ανίχνευσης αρχείου και ροής, τη συμπεριφορά των νεοδημιουργημένων παρουσιάσεων και τη διάκριση μεταξύ μορφών προέλευσης και εξόδου, δείτε [Καθορίστε την αρχική μορφή παρουσίασης](/slides/el/php-java/detect-presentation-source-format/).

Σε εφαρμογή μαζικής επεξεργασίας, η μορφή εισόδου μπορεί να μην είναι γνωστή εκ των προτέρων. Μετά τη φόρτωση ενός αρχείου, διαβάστε την αρχική του μορφή από τη μέθοδο [Presentation::getSourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSourceFormat). Περνάτε την προκύπτουσα τιμή [SourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/sourceformat/) στη μέθοδο [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/#toSaveFormat) για να λάβετε την αντίστοιχη τιμή [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/), και στη συνέχεια χρησιμοποιείτε το [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) για να γράψετε την τροποποιημένη παρουσίαση.

Το παρακάτω πλήρες παράδειγμα επεξεργάζεται κάθε αρχείο σε έναν φάκελο εισόδου, ενημερώνει τον τίτλο του και το αποθηκεύει σε φάκελο εξόδου στη μορφή από την οποία φορτώθηκε:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/#toSaveFormat) αντιστοιχεί PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP και PowerPoint XML στις αντίστοιχες μορφές αποθήκευσης παρουσίασης. Αντιστοιχεί μόνο μορφές προέλευσης παρουσίασης· δεν προορίζεται για επιλογή μορφών εξαγωγής όπως PDF, HTML, TIFF ή εικόνες. Η παράδοση μιας μη υποστηριζόμενης ή μη έγκυρης τιμής [SourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/sourceformat/) προκαλεί ένα [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Τα κληρονομημένα αρχεία PPT, PPS και POT χρησιμοποιούν το ίδιο δυαδικό κοντέινερ. Όταν μια τέτοια παρουσίαση φορτώνεται από ροή χωρίς κατάληξη αρχείου, ένα αρχείο PPS ή POT μπορεί επομένως να ταυτοποιηθεί ως PPT. Εάν απαιτείται διατήρηση αυτών των κληρονομημένων υποτύπων, διατηρήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα μορφής ξεχωριστά και χρησιμοποιήστε τα όταν επιλέγετε το όνομα αρχείου και τη μορφή εξόδου.

## **Αποθήκευση παρουσιάσεων σε ροές**

Για να γράψετε μια παρουσίαση χωρίς να βασίζεστε σε τελική διαδρομή αρχείου, περάστε μια εγγράψιμη ροή και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/) στη μέθοδο [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save). Αυτή η προσέγγιση είναι χρήσιμη όταν η έξοδος πρέπει να επιστραφεί από μια υπηρεσία web, να αποθηκευτεί σε βάση δεδομένων ή να υποβληθεί σε επεξεργασία στη μνήμη.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση παρουσιάσεων με προκαθορισμένο τύπο προβολής**

Μπορείτε να καθορίσετε την προβολή στην οποία το PowerPoint ανοίγει αρχικά μια αποθηκευμένη παρουσίαση. Χρησιμοποιήστε τη μέθοδο [ViewProperties::setLastView](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/#setLastView) με μια τιμή [ViewType](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewtype/) πριν από την αποθήκευση.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση παρουσιάσεων σε αυστηρή μορφή Office Open XML**

Για να δημιουργήσετε ένα αρχείο PPTX που συμμορφώνεται με το προφίλ Strict του Office Open XML, δημιουργήστε μια παρουσίαση [PptxOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/) και χρησιμοποιήστε τη μέθοδό της [PptxOptions::setConformance](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/#setConformance) με τιμή [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/el/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Στη συνέχεια περάστε τις επιλογές στη μέθοδο [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML σε λειτουργία Zip64**

Ένα τυπικό αρχείο ZIP περιορίζει το συμπιεσμένο και ασυμπιεσμένο μέγεθος κάθε εγγραφής, το συνολικό μέγεθος του αρχείου και τον αριθμό των εγγραφών. Επειδή ένα αρχείο PPTX είναι αρχείο ZIP, μια πολύ μεγάλη παρουσίαση μπορεί να υπερβεί αυτά τα όρια. Οι επεκτάσεις ZIP64 αυξάνουν τα όρια μεγέθους και αριθμού εγγραφών.

- Το [IfNecessary](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί ZIP64 μόνο όταν η παρουσίαση υπερβαίνει τα τυπικά όρια ZIP. Αυτή είναι η προεπιλεγμένη λειτουργία.
- Το [Never](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#Never) απενεργοποιεί τις επεκτάσεις ZIP64.
- Το [Always](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#Always) πάντα γράφει επεκτάσεις ZIP64.

Το παρακάτω παράδειγμα ενεργοποιεί πάντα τις επεκτάσεις ZIP64 για την έξοδο της παρουσίασης:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Εάν χρησιμοποιηθεί το [Zip64Mode::Never](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#Never) και η παρουσίαση δεν μπορεί να χωρέσει στα τυπικά όρια ZIP, η λειτουργία αποθήκευσης ρίχνει μια [PptxException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML με επίπεδα συμπίεσης**

Για έξοδο PPTX, μπορείτε να ισορροπήσετε την ταχύτητα αποθήκευσης με το μέγεθος του αρχείου χρησιμοποιώντας τη μέθοδο [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/#setCompressionLevel). Η κλάση [CompressionLevel](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/) παρέχει τις ακόλουθες τιμές:

- Το [None](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#None) αποθηκεύει δεδομένα χωρίς συμπίεση.
- Το [Level1](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level1) προσφέρει τη γρηγορότερη συμπίεση και το μεγαλύτερο συμπιεσμένο αποτέλεσμα.
- Τα [Level2](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level2) έως [Level5](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level5) προτιμούν σταδιακά μικρότερο αρχείο αντί για ταχύτητα αποθήκευσης.
- Το [Level6](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level6) ισορροπεί την ταχύτητα αποθήκευσης και το μέγεθος αρχείου. Αυτό είναι το προεπιλεγμένο επίπεδο.
- Τα [Level7](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level7) και [Level8](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level8) προτιμούν ακόμη περισσότερο μικρότερο αρχείο αντί για ταχύτητα.
- Το [Level9](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level9) παρέχει τη μεγαλύτερη συμπίεση και απαιτεί το μεγαλύτερο χρόνο επεξεργασίας.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς συμπίεση:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

Το παρακάτω παράδειγμα χρησιμοποιεί το μέγιστο επίπεδο συμπίεσης:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση παρουσιάσεων χωρίς ανανέωση της μικρογραφίας**

Όταν μια παρουσίαση αποθηκεύεται ως PPTX, η μέθοδος [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ελέγχει τη μικρογραφία του εγγράφου:

- `true` δημιουργεί ξανά τη μικρογραφία κατά την αποθήκευση. Αυτή είναι η προεπιλεγμένη τιμή.
- `false` διατηρεί την υπάρχουσα μικρογραφία. Αν η παρουσίαση δεν έχει μικρογραφία, το Aspose.Slides δεν δημιουργεί κάποια.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς να ανανεώσει τη μικρογραφία της:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Η απενεργοποίηση της ανανέωσης της μικρογραφίας μπορεί να μειώσει το χρόνο που απαιτείται για την αποθήκευση ενός αρχείου PPTX.
{{% /alert %}}

## **Αποθήκευση ενημερώσεων προόδου σε ποσοστό**

Για να παρακολουθείτε μια λειτουργία αποθήκευσης, παρέχετε μια διαμεσολαβητική κλάση Java που υλοποιεί το interface [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/) και περάστε την στον μέθοδο [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/#setProgressCallback). Το Aspose.Slides στη συνέχεια καλεί τη μέθοδο [IProgressCallback::reporting](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/#reporting-double-) με τιμές προόδου κατά την εξαγωγή.

Το παρακάτω παράδειγμα αναφέρει την πρόοδο εξαγωγής PDF στην κονσόλα:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Η Aspose παρέχει ένα δωρεάν [PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χτισμένο με το API Aspose.Slides. Αποθηκεύει επιλεγμένες διαφάνειες από μια παρουσίαση ως ξεχωριστά αρχεία PPT ή PPTX.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζει το Aspose.Slides αποθήκευση σε τμήματα ή «γρήγορη αποθήκευση»;**

Όχι. Κάθε λειτουργία αποθήκευσης γράφει ένα πλήρες αρχείο εξόδου αντί να ενημερώνει μόνο τα τροποποιημένα τμήματα.

**Μπορούν πολλαπλά νήματα να αποθηκεύσουν την ίδια παρουσίαση (Presentation) ταυτόχρονα;**

Όχι. Μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) δεν είναι ασφαλής προς νήματα ([is not thread-safe](/slides/el/php-java/multithreading/)). Πρόσβαση και αποθήκευση κάθε παρουσίας πρέπει να γίνεται από ένα νήμα τη φορά.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία όταν αποθηκεύω μια παρουσίαση;**

Οι [Hyperlinks](/slides/el/php-java/manage-hyperlinks/) παραμένουν στην παρουσίαση. Το Aspose.Slides δεν αντιγράφει τα εξωτερικά συνδεδεμένα αρχεία, έτσι η αποθηκευμένη παρουσίαση πρέπει ακόμα να μπορεί να προσπελάσει τις τοποθεσίες τους.

**Μπορώ να αποθηκεύσω μεταδεδομένα εγγράφου όπως συγγραφέα, τίτλο, εταιρεία και ημερομηνία δημιουργίας;**

Ναι. Ορίστε τις κατάλληλες [ιδιότητες εγγράφου](/slides/el/php-java/presentation-properties/) πριν από την αποθήκευση, και το Aspose.Slides τις γράφει στο αρχείο εξόδου.