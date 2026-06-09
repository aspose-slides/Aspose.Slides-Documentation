---
title: Άνοιγμα παρουσιάσεων σε PHP
linktitle: Άνοιγμα παρουσίασης
type: docs
weight: 20
url: /el/php-java/open-presentation/
keywords:
- άνοιγμα PowerPoint
- άνοιγμα OpenDocument
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
description: "Ανοίξτε παρουσιάσεις PowerPoint (.pptx, .ppt) και OpenDocument (.odp) χωρίς κόπο με το Aspose.Slides για PHP μέσω Java — γρήγορο, αξιόπιστο, πλήρως εξοπλισμένο."
---
## **Εισαγωγή**

Πέρα από τη δημιουργία παρουσιάσεων PowerPoint από το μηδέν, το Aspose.Slides σας επιτρέπει επίσης να ανοίγετε υπάρχουσες παρουσιάσεις. Αφού φορτώσετε μια παρουσίαση, μπορείτε να ανακτήσετε πληροφορίες για αυτήν, να επεξεργαστείτε το περιεχόμενο των διαφανειών, να προσθέσετε νέες διαφάνειες, να αφαιρέσετε υπάρχουσες και πολλά άλλα.

## **Άνοιγμα παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και περάστε τη διαδρομή του αρχείου στον κατασκευαστή της.

Το παρακάτω παράδειγμα PHP δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation και περάστε μια διαδρομή αρχείου στον κατασκευαστή της.
$presentation = new Presentation("Sample.pptx");
try {
    // Εκτυπώστε το συνολικό αριθμό των διαφανειών στην παρουσίαση.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Άνοιγμα παρουσιάσεων με κωδικό προστασίας**

Όταν χρειάζεται να ανοίξετε μια παρουσίαση που προστατεύεται με κωδικό, περάστε τον κωδικό μέσω της μεθόδου [setPassword](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setPassword) της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/) για να την αποκρυπτογραφήσετε και να τη φορτώσετε. Το παρακάτω κώδικα PHP δείχνει αυτή τη λειτουργία:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Πραγματοποιήστε λειτουργίες στην αποκρυπτογραφημένη παρουσίαση.
} finally {
    $presentation->dispose();
}
```

## **Άνοιγμα μεγάλων παρουσιάσεων**

Το Aspose.Slides παρέχει επιλογές—ιδιαίτερα τη μέθοδο [getBlobManagementOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) στην κλάση [LoadOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/)—για να σας βοηθήσει να φορτώσετε μεγάλες παρουσιάσεις.

Το παρακάτω κώδικα PHP δείχνει τη φόρτωση μιας μεγάλης παρουσίασης (για παράδειγμα, 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Επιλέξτε τη συμπεριφορά KeepLocked—το αρχείο παρουσίασης θα παραμείνει κλειδωμένο για τη διάρκεια του
// του αντικειμένου Presentation, αλλά δεν απαιτείται φόρτωση στη μνήμη ή αντιγραφή σε προσωρινό αρχείο.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // Η μεγάλη παρουσίαση έχει φορτωθεί και μπορεί να χρησιμοποιηθεί, ενώ η κατανάλωση μνήμης παραμένει χαμηλή.

    // Κάντε αλλαγές στην παρουσίαση.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Αποθηκεύστε την παρουσίαση σε άλλο αρχείο. Η κατανάλωση μνήμης παραμένει χαμηλή κατά τη διάρκεια αυτής της λειτουργίας.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Μην το κάνετε αυτό! Θα προκληθεί εξαίρεση I/O επειδή το αρχείο είναι κλειδωμένο μέχρι να αποδεσμευτεί το αντικείμενο παρουσίασης.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// Είναι εντάξει να γίνει εδώ. Το αρχείο προέλευσης δεν είναι πλέον κλειδωμένο από το αντικείμενο παρουσίασης.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
Για να παρακάμπνετε ορισμένους περιορισμούς κατά τη χρήση ροών, το Aspose.Slides μπορεί να αντιγράψει το περιεχόμενο μιας ροής. Η φόρτωση μιας μεγάλης παρουσίασης από ροή προκαλεί την αντιγραφή της παρουσίασης και μπορεί να επιβραδύνει τη φόρτωση. Συνεπώς, όταν χρειάζεται να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε ανεπιφύλακτα τη χρήση της διαδρομής του αρχείου παρουσίασης αντί για ροή.

Κατά τη δημιουργία μιας παρουσίασης που περιέχει μεγάλα αντικείμενα (βίντεο, ήχους, εικόνες υψηλής ανάλυσης κ.λπ.), μπορείτε να χρησιμοποιήσετε τη [BLOB management](/slides/el/php-java/manage-blob/) για να μειώσετε την κατανάλωση μνήμης.
{{%/alert %}}

## **Διαχείριση εξωτερικών πόρων**

Το Aspose.Slides παρέχει το interface [IResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iresourceloadingcallback/) που σας επιτρέπει να διαχειρίζεστε εξωτερικούς πόρους. Το παρακάτω κώδικα PHP δείχνει πώς να χρησιμοποιήσετε το interface `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Φορτώστε μια υποκατάστατη εικόνα.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Ορίστε μια υποκατάστατη URL.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Παραλείψτε όλες τις άλλες εικόνες.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Φόρτωση παρουσιάσεων χωρίς ενσωματωμένα δυαδικά αντικείμενα**

Μια παρουσίαση PowerPoint μπορεί να περιέχει τους παρακάτω τύπους ενσωματωμένων δυαδικών αντικειμένων:

- Έργο VBA (προσβάσιμο μέσω του [Presentation.getVbaProject](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getVbaProject));
- Δεδομένα ενσωματωμένου αντικειμένου OLE (προσβάσιμο μέσω του [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Δυαδικά δεδομένα ελέγχου ActiveX (προσβάσιμο μέσω του [Control.getActiveXControlBinary](https://reference.aspose.com/slides/el/php-java/aspose.slides/control/#getActiveXControlBinary)).

Χρησιμοποιώντας τη μέθοδο [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), μπορείτε να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό αντικείμενο.

Αυτή η μέθοδος είναι χρήσιμη για την αφαίρεση πιθανώς κακόβουλου δυαδικού περιεχομένου. Το παρακάτω κώδικα PHP δείχνει πώς να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό περιεχόμενο:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Πραγματοποιήστε λειτουργίες στην παρουσίαση.
} finally {
    $presentation->dispose();
}
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να διακρίνω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Θα λάβετε μια εξαίρεση επεξεργασίας/επαλήθευσης μορφής κατά τη φόρτωση. Τέτοια σφάλματα συχνά αναφέρουν μη έγκυρη δομή ZIP ή σπασμένα αρχεία PowerPoint.

**Τι συμβαίνει αν λείπουν απαιτούμενες γραμματοσειρές κατά το άνοιγμα;**

Το αρχείο θα ανοίξει, αλλά αργότερα η [απόδοση/εξαγωγή](/slides/el/php-java/convert-presentation/) μπορεί να αντικαταστήσει τις γραμματοσειρές. [Διαμορφώστε τις αντικαταστάσεις γραμματοσειρών](/slides/el/php-java/font-substitution/) ή [προσθέστε τις απαιτούμενες γραμματοσειρές](/slides/el/php-java/custom-font/) στο περιβάλλον εκτέλεσης.

**Τι γίνεται με τα ενσωματωμένα μέσα (βίντεο/ήχος) κατά το άνοιγμα;**

Γίνονται διαθέσιμα ως πόροι της παρουσίασης. Εάν τα μέσα αναφέρονται μέσω εξωτερικών διαδρομών, βεβαιωθείτε ότι αυτές οι διαδρομές είναι προσβάσιμες στο περιβάλλον σας· διαφορετικά η [απόδοση/εξαγωγή](/slides/el/php-java/convert-presentation/) μπορεί να παραλείψει τα μέσα.