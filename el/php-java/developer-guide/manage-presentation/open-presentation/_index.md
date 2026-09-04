---
title: Άνοιγμα Παρουσιάσεων σε PHP
linktitle: Άνοιγμα Παρουσίασης
type: docs
weight: 20
url: /el/php-java/open-presentation/
keywords:
- άνοιγμα PowerPoint
- άνοιγμα παρουσίασης
- άνοιγμα PPTX
- άνοιγμα PPT
- άνοιγμα ODP
- φόρτωση παρουσίασης
- φόρτωση PPTX
- φόρτωση PPT
- φόρτωση ODP
- προστατευμένη παρουσίαση
- μεγάλη παρουσίαση
- εξωτερικός πόρος
- δυαδικό αντικείμενο
- PHP
- Aspose.Slides
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε PHP, να παρέχετε κωδικούς πρόσβασης ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώνετε τη χρήση μνήμης με το Aspose.Slides για PHP μέσω Java."
---
## **Εισαγωγή**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/el/php-java/) μπορεί να φορτώσει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Αφού φορτωθεί μια παρουσίαση, μπορείτε να ελέγξετε τη δομή της, να επεξεργαστείτε τις διαφάνειες, να διαχειριστείτε τους πόρους και να την αποθηκεύσετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παράσχετε έναν κωδικό πρόσβασης ανοίγματος, να διατηρείτε μεγάλα δυαδικά αντικείμενα εκτός της μνήμης heap της Java, να ελέγχετε εξωτερικούς πόρους ή να παραλείψετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Απελευθερώστε την παρουσίαση μετά τη χρήση ώστε τα χειριστήρια αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι να απελευθερωθούν άμεσα.

Το παρακάτω παράδειγμα PHP δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Άνοιγμα Παρουσιάσεων με Προστασία Κωδικού**

Ένας κωδικός ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε την πλήρη παρουσίαση, περάστε τον σωστό κωδικό στο [LoadOptions::setPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setPassword) και παρέχετε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Η φόρτωση αποτυγχάνει όταν ο κωδικός λείπει ή είναι λανθασμένος.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Για ανίχνευση, επαλήθευση και ροές εργασίας κρυπτογράφησης κωδικού, δείτε [Password-Protect Presentations](/slides/el/php-java/password-protected-presentation/). Αν μια κρυπτογραφημένη παρουσίαση αποθηκεύτηκε σκόπιμα με δημόσιες ιδιότητες εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό· δείτε [Manage Presentation Properties](/slides/el/php-java/presentation-properties/).

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) επιστρέφει επιλογές που ελέγχουν τον τρόπο με τον οποίο το Aspose.Slides διαχειρίζεται μεγάλα δυαδικά αντικείμενα όπως εικόνες, ήχο και βίντεο. Μπορείτε να διατηρήσετε το αρχείο προέλευσης κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε την ποσότητα των δεδομένων BLOB που διατηρούνται στη μνήμη.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Με την επιλογή [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), το αρχείο προέλευσης παραμένει κλειδωμένο μέχρι να αποδεσμευθεί η παρουσίαση. Μην μετακινείτε, αντικαθιστάτε ή διαγράφετε το αρχείο προέλευσης ενώ η παρουσίαση είναι ενεργή.

Το Aspose.Slides ενδέχεται να αντιγράψει το περιεχόμενο μιας ροής εισόδου κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, μια διαδρομή αρχείου είναι γενικά πιο αποδοτική από μια ροή. Δείτε [Manage BLOBs](/slides/el/php-java/manage-blob/) για πρόσθετες επιλογές αποθήκευσης και διαχείρισης μνήμης.
{{% /alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) δέχεται μια υλοποίηση της διεπαφής Java [IResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iresourceloadingcallback/) μέσω του PHP/Java Bridge. Η κλήση επιστροφής μπορεί να παρέχει δεδομένα αντικατάστασης, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να επιλυθούν σύμφωνα με ειδικούς κανόνες ασφαλείας ή αποθήκευσης της εφαρμογής.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα τα οποία μια εφαρμογή δεν χρειάζεται ή δεν επιθυμεί να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- έργα VBA, προσβάσιμα μέσω [Presentation::getVbaProject](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getVbaProject);
- ενσωματωμένα δεδομένα OLE, προσβάσιμα μέσω [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- δεδομένα ελέγχου ActiveX, προσβάσιμα μέσω [Control::getActiveXControlBinary](https://reference.aspose.com/slides/el/php-java/aspose.slides/control/#getActiveXControlBinary).

Ορίστε το [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) σε `true` για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα φορτία, αλλά δεν αποτελεί ολοκληρωμένο σύστημα ανίχνευσης κακόβουλου λογισμικού ή καθαρισμού περιεχομένου.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διακρίνω αν ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχτεί;**

Το Aspose.Slides ρίχνει εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Διαχειριστείτε αυτό το σφάλμα ξεχωριστά από σφάλμα λανθασμένου κωδικού για να μπορεί η εφαρμογή να αναφέρει ακριβώς την αιτία.

**Τι συμβαίνει αν λείπουν τα απαιτούμενα γραμματοσειρά;**

Η παρουσίαση μπορεί ακόμα να φορτωθεί, αλλά η απόδοση και η εξαγωγή ενδέχεται να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [configure font substitution](/slides/el/php-java/font-substitution/) ή να [provide custom fonts](/slides/el/php-java/custom-font/) για να κάνετε την έξοδο πιο προβλέψιμη.

**Φορτώνεται επίσης το ενσωματωμένο πολυμέσο όταν φορτώνεται μια παρουσίαση;**

Το ενσωματωμένο ήχο και βίντεο γίνονται διαθέσιμα μέσω του μοντέλου αντικειμένων της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μην είναι προσβάσιμοι εάν οι θέσεις τους δεν είναι προσβάσιμες.