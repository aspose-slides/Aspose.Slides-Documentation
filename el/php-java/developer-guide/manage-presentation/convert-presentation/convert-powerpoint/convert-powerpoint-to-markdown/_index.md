---
title: Μετατροπή παρουσιάσεων PowerPoint σε Markdown με PHP
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/php-java/convert-powerpoint-to-markdown/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε MD
- παρουσίαση σε MD
- διαφάνεια σε MD
- PPT σε MD
- PPTX σε MD
- αποθήκευση PowerPoint ως Markdown
- αποθήκευση παρουσίασης ως Markdown
- αποθήκευση διαφάνειας ως Markdown
- αποθήκευση PPT ως MD
- αποθήκευση PPTX ως MD
- εξαγωγή PPT σε MD
- εξαγωγή PPTX σε MD
- εξαγωγή εικόνας Markdown
- σύνδεσμοι εικόνων CDN
- PowerPoint
- παρουσίαση
- Markdown
- PHP
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PPT και PPTX σε Markdown με PHP και ελέγξτε πού αποθηκεύονται και αναφέρονται οι εξαγώμενες εικόνες bitmap, metafile και SVG."
---
## **Επισκόπηση**

Το Aspose.Slides για PHP μέσω Java μπορεί να μετατρέπει παρουσιάσεις PPT και PPTX σε Markdown για τεκμηρίωση, στατικές ιστοσελίδες, μεταφορά περιεχομένου και ροές εργασίας ελέγχου εκδόσεων. Μπορείτε να επιλέξετε μια γεύση Markdown, να ελέγξετε πώς αποδίδεται το περιεχόμενο των διαφανειών και να καθορίσετε πού αποθηκεύονται οι εξαγόμενες εικόνες και πώς οι παραγόμενες αναφορές Markdown τις αντιμετωπίζουν.

Από προεπιλογή, η εξαγωγή σε Markdown χρησιμοποιεί έξοδο μόνο κειμένου. Για να εξάγετε οπτικό περιεχόμενο, ορίστε τον τύπο εξαγωγής με τη μέθοδο [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) στην τιμή `Sequential` ή `Visual` από την απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownexporttype/). Το `Sequential` αποδίδει τα στοιχεία της διαφάνειας ξεχωριστά και με τη σειρά, ενώ το `Visual` διατηρεί τα ομαδοποιημένα στοιχεία μαζί ώστε να διατηρηθεί η οπτική τους σχέση. Η τιμή `TextOnly` δεν εκτυπώνει πόρους εικόνας, έτσι οι κλήσεις επιστροφής αποθήκευσης εικόνας δεν κληθούν σε αυτή τη λειτουργία.

## **Μετατροπή Παρουσίασης σε Markdown**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και, στη συνέχεια, καλέστε τη μέθοδο [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) με την τιμή `Md` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Επιλογή Γεύσης Markdown**

Η μέθοδος [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) ελέγχει την προδιαγραφή Markdown που χρησιμοποιείται για την έξοδο. Η απαρίθμηση [Flavor](https://reference.aspose.com/slides/el/php-java/aspose.slides/flavor/) περιλαμβάνει CommonMark, GitHub Flavored Markdown και άλλες υποστηριζόμενες παραλλαγές.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση ως CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Εξαγωγή Εικόνων με την Προεπιλεγμένη Συμπεριφορά Τοπικής Αποθήκευσης**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) παρέχει δύο μεθόδους για τη ρύθμιση τοπικά αποθηκευμένων εικόνων:

- [setBasePath](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) καθορίζει τον βασικό φάκελο για το έγγραφο Markdown και τους πόρους του.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) καθορίζει το υποφάκελο των εικόνων. Η προεπιλεγμένη τιμή είναι `Images`.

Το παρακάτω παράδειγμα αποδίδει οπτικό περιεχόμενο, γράφει εικόνες στο `output/assets` και δημιουργεί σχετικές αναφορές εικόνας στο έγγραφο Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Αυτή η συμπεριφορά χρησιμεύει επίσης ως εφεδρική όταν ένας προσαρμοσμένος επεξεργαστής αποθήκευσης εικόνας επιστρέφει `false`.

## **Προσαρμογή Αποθήκευσης Εικόνας και Συνδέσμων Markdown**

Χρησιμοποιήστε τη μέθοδο [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) για να καταχωρήσετε μια κλήση επιστροφής για πόρους bitmap και metafile που δεν είναι SVG και εκτυπώνονται κατά την εξαγωγή Markdown. Η κλήση επιστροφής `MarkdownImageSavingHandler` λαμβάνει το αντικείμενο [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/), την τιμή [ImageFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/imageformat/) και τον παραγόμενο σύνδεσμο Markdown ως έναν μονοστοιχικό πίνακα συμβολοσειρών Java. Αποθηκεύστε ή ανεβάστε την εικόνα με τη δοθείσα μορφή και αντικαταστήστε το `$link[0]` με την αναφορά που πρέπει να εμφανιστεί στην έξοδο Markdown.

Οι πόροι που εκτυπώνονται σε μορφή SVG διαχειρίζονται ξεχωριστά. Καταχωρήστε μια κλήση επιστροφής με τη μέθοδο [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/). Η κλήση επιστροφής `MarkdownSvgImageSavingHandler` λαμβάνει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/isvgimage/) και τον μονοστοιχικό πίνακα συμβολοσειρών Java `$link`. Ένα SVG δεν έχει όρισμα `ImageFormat`; γράψτε ή ανεβάστε τα XML δεδομένα του μέσω της μεθόδου [ISvgImage::getSvgData](https://reference.aspose.com/slides/el/php-java/aspose.slides/isvgimage/). Ανάλογα με τη λειτουργία εξαγωγής και την οπτική ομαδοποίηση, ένα SVG στην πηγή μπορεί να ραστεριστεί ή να συνδυαστεί με άλλο περιεχόμενο· ο προκύπτων μη‑SVG πόρος στη συνέχεια παραδίδεται στην κλήση επιστροφής αποθήκευσης εικόνας. Καταχωρήστε και τις δύο κλήσεις όταν κάθε εξαγόμενο οπτικό πόρο απαιτεί προσαρμοσμένη επεξεργασία.

Στο PHP μέσω Java, υλοποιήστε κάθε κλήση επιστροφής σε μια κλάση PHP και χρησιμοποιήστε `java_closure` για να εκθέσετε το αντικείμενο ως το αντίστοιχο interface Java.

{{% alert color="info" title="Note" %}}

Αρχικοποιήστε το PHP/Java Bridge με ενεργοποιημένο το `JAVA_PREFER_VALUES` πριν φορτώσετε το `Java.inc`. Η μέθοδος [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) επιστρέφει `void`, και η προεπιλεγμένη λειτουργία ροής του bridge δεν μπορεί να καλέσει μια κλήση επιστροφής PHP κατά τη διάρκεια αυτής της ουράς κλήσης. Το πλήρες παράδειγμα παρακάτω περιλαμβάνει την απαιτούμενη αρχικοποίηση.

{{% /alert %}}

Η τιμή επιστροφής του επεξεργαστή καθορίζει ποιος επεξεργάζεται την εικόνα:

- Επιστρέψτε `true` μετά από αποθήκευση, ανέβασμα, μετασχηματισμό ή οποιαδήποτε επεξεργασία της εικόνας και αφού έχετε ορίσει έγκυρη τιμή στο `$link[0]`. Το Aspose.Slides γράφει αυτήν την τιμή στο έγγραφο Markdown και δεν εκτελεί την προεπιλεγμένη τοπική αποθήκευση.
- Επιστρέψτε `false` για να αφήσετε το Aspose.Slides να αποθηκεύσει την εικόνα τοπικά και να δημιουργήσει τον σύνδεσμό της σύμφωνα με τις τιμές που έχουν οριστεί με [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) και [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}

Ένας επεξεργαστής που επιστρέφει `true` αναλαμβάνει την ευθύνη για την εικόνα. Εάν επιστρέψει `true` χωρίς να καθορίσει έγκυρο, μη κενό σύνδεσμο, η εξαγωγή αποτυγχάνει με `InvalidOperationException`.

{{% /alert %}}

### **Αποθήκευση Εικόνων σε Κατάλογο CDN Origin και Χρήση Εξωτερικών URL**

Το παρακάτω παράδειγμα αντιμετωπίζει το `cdn-origin/presentations/quarterly-report` ως προσαρτημένο ή συγχρονισμένο κατάλογο CDN origin. Κάθε επεξεργαστής εξάγει το παραγόμενο όνομα αρχείου, αποθηκεύει την εικόνα σε αυτόν τον προσαρμοσμένο κατάλογο και αντικαθιστά την τοπική αναφορά με ένα δημόσιο URL CDN. Το ίδιο το δείγμα δεν εκτελεί δικτυακό ανέβασμα: το URL γίνεται έγκυρο μόνο αφού ο κατάλογος προσαρτηθεί ως CDN origin ή τα αρχεία του δημοσιευτούν στο CDN. Για αποθήκευση αντικειμένου, αντικαταστήστε τη γραφή στο σύστημα αρχείων με την ενέργεια ανεβάσματος του SDK αποθήκευσης και ορίστε το `$link[0]` μόνο αφού το ανέβασμα πετύχει.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Ο επεξεργαστής bitmap επιστρέφει σκόπιμα `false` για εικόνες μικρότερες από 128 × 128 pixels, έτσι το Aspose.Slides αποθηκεύει αυτές τις εικόνες στο `output/fallback-images` χρησιμοποιώντας την προεπιλεγμένη συμπεριφορά. Μεγαλύτεροι bitmap και πόροι metafile, καθώς και πόροι SVG, διαχειρίζονται από τον προσαρμοσμένο κώδικα. Για παράδειγμα, μια τοπική αναφορά όπως `fallback-images/image1.png` γίνεται `https://cdn.example.com/presentations/quarterly-report/image1.png`. Οι επεξεργαστές χρησιμοποιούν διαδρομές λειτουργικού συστήματος μόνο κατά τη συγγραφή αρχείων· οι σύνδεσοι που γράφονται στο Markdown χρησιμοποιούν μπροστά κάθετες παύλες και URL‑κωδικοποιημένα ονόματα αρχείων. Εφαρμόστε τον ίδιο κανόνα όταν χτίζετε σχετικούς συνδέσμους: χρησιμοποιήστε `/`, όχι το διαχωριστικό καταλόγου της πλατφόρμας.

## **Συχνές Ερωτήσεις**

**Μπορεί ένας επεξεργαστής να επεξεργαστεί τόσο bitmap όσο και SVG εικόνες;**

Όχι. Χρησιμοποιήστε [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) για τους bitmap και metafile πόρους και [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) για τους πόρους που εκτυπώνονται ως SVG. Ο πρώτος παρέχει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) και μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/imageformat/); ο δεύτερος παρέχει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/isvgimage/) του οποίου τα δεδομένα SVG μπορούν να διαβαστούν με [ISvgImage::getSvgData](https://reference.aspose.com/slides/el/php-java/aspose.slides/isvgimage/). Ένα SVG στην πηγή που ραστερίζεται κατά την εξαγωγή επεξεργάζεται από την κλήση επιστροφής αποθήκευσης εικόνας αντί για αυτήν.

**Τι συμβαίνει όταν ένας επεξεργαστής αποθήκευσης εικόνας επιστρέφει `false`;**

Το Aspose.Slides χρησιμοποιεί την προεπιλεγμένη τοπική συμπεριφορά αποθήκευσης. Η θέση της εικόνας και η παραγόμενη αναφορά ελέγχονται από τις τιμές που έχουν οριστεί με [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) και [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/).

**Μπορεί ένας επεξεργαστής να παρέχει URL χωρίς να αποθηκεύσει την εικόνα τοπικά;**

Ναι. Ο επεξεργαστής μπορεί να ανεβάσει την εικόνα σε αποθήκη αντικειμένων ή να τη μεταβιβάσει σε άλλη υπηρεσία, να ορίσει το παραγόμενο URL στο `$link[0]` και να επιστρέψει `true`. Ο επεξεργαστής πρέπει να ολοκληρώσει την επεξεργασία μόνος του· η επιστροφή `true` εμποδίζει την προεπιλεγμένη τοπική αποθήκευση.

**Γιατί η εξαγωγή Markdown ρίχνει `InvalidOperationException` από έναν επεξεργαστή;**

Η εξαίρεση εμφανίζεται όταν ο επεξεργαστής επιστρέφει `true` αλλά δεν παρέχει έγκυρο σύνδεσμο. Ορίστε τη σχετική διαδρομή ή το εξωτερικό URL που πρέπει να γραφτεί στο Markdown πριν επιστρέψετε `true`.

**Ποιον διαχωριστικό διαδρομής πρέπει να χρησιμοποιούν οι σύνδεσμοι εικόνας;**

Χρησιμοποιήστε μπροστά κάθετες παύλες στα συνδέσμους Markdown και στα URLs. Χρησιμοποιήστε `DIRECTORY_SEPARATOR` μόνο για διαδρομές συστήματος αρχείων, στη συνέχεια δημιουργήστε ή κανονικοποιήστε την αναφορά Markdown χωριστά.

**Διατηρούνται οι υπερσύνδεσμοι κατά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/php-java/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/php-java/slide-transition/) και [animations](/slides/el/php-java/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορούν οι παρουσιάσεις να μετατραπούν σε Markdown παράλληλα;**

Μπορείτε να επεξεργαστείτε διαφορετικά αρχεία παρουσίασης παράλληλα, αλλά μην μοιράζεστε την ίδια περίπτωση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) μεταξύ νημάτων. Ακολουθήστε τις [multithreading guidelines](/slides/el/php-java/multithreading/) και χρησιμοποιήστε ξεχωριστή περίπτωση για κάθε αρχείο.