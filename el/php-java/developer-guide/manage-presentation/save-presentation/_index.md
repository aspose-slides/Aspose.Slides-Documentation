---
title: Αποθήκευση Παρουσιάσεων σε PHP
linktitle: Αποθήκευση Παρουσίασης
type: docs
weight: 80
url: /el/php-java/save-presentation/
keywords:
- αποθήκευση PowerPoint
- αποθήκευση OpenDocument
- αποθήκευση παρουσίασης
- αποθήκευση διαφάνειας
- αποθήκευση PPT
- αποθήκευση PPTX
- αποθήκευση ODP
- παρουσίαση σε αρχείο
- παρουσίαση σε ροή
- προκαθορισμένος τύπος προβολής
- Απολύτο μορφό Office Open XML
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- PHP
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java — εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας τις διατάξεις, τις γραμματοσειρές και τα εφέ."
---
## **Επισκόπηση**

[Άνοιγμα Παρουσιάσεων σε PHP](/slides/el/php-java/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) για το άνοιγμα μιας παρουσίασης. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) περιέχει τα περιεχόμενα μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides for PHP, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τους διαφορετικούς τρόπους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Μεταβιβάστε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με Aspose.Slides.

```php
// Δημιουργήστε το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Εκτελέστε κάποια εργασία εδώ...

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια έξοδο ροής στη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφεί σε πολλούς τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ροή αρχείου.

```php
// Δημιουργήστε το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Αποθηκεύστε την παρουσίαση στη ροή.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Το Aspose.Slides σάς επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργημένη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/#setLastView) με μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Απολύτο Μορφό Office Open XML**

Το Aspose.Slides σάς επιτρέπει να αποθηκεύσετε μια παρουσίαση στο Απολύτο μορφό Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε το [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), το αρχείο εξόδου αποθηκεύεται στο Απολύτο μορφό Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει στο Απολύτο μορφό Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Δημιουργήστε το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποθηκεύστε την παρουσίαση σε Απολύτο μορφό Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Μορφό Office Open XML σε Λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει όρια 4 GB (2^32 bytes) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, καθώς και περιορίζει τον αριθμό αρχείων σε 65 535 (2^16‑1). Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια στο 2^64.

Η μέθοδος [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/#setZip64Mode) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιήσετε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τις ακόλουθες λειτουργίες:

- [IfNecessary](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί τις επεκτάσεις ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τα παραπάνω όρια. Αυτή είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#Never) δεν χρησιμοποιεί ποτέ τις επεκτάσεις ZIP64.
- [Always](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#Always) χρησιμοποιεί πάντα τις επεκτάσεις ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Όταν αποθηκεύετε με [Zip64Mode.Never](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#Never), μια [PptxException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxexception/) ρίχνεται εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Μορφό Office Open XML με Επίπεδα Συμπίεσης**

Κατά την εργασία με μεγάλες παρουσιάσεις, μπορείτε να ρυθμίσετε το επίπεδο συμπίεσης για να εξισορροπήσετε το μέγεθος του αρχείου και το χρόνο επεξεργασίας. Ανάλογα με τις απαιτήσεις σας, μπορεί να προτιμάτε ταχύτερη επεξεργασία ή μικρότερα αρχεία εξόδου.

Το Aspose.Slides παρέχει τη μέθοδο [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/#setCompressionLevel), η οποία επιτρέπει τον καθορισμό του επιπέδου συμπίεσης που χρησιμοποιείται κατά την αποθήκευση μιας παρουσίασης σε μορφό Office Open XML.

Τα διαθέσιμα επίπεδα συμπίεσης είναι:

- [**None**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#None): Δεν εφαρμόζεται συμπίεση. Τα αρχεία αποθηκεύονται όπως είναι.
- [**Level1**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level1): Η πιο γρήγορη συμπίεση με το χαμηλότερο λόγο συμπίεσης.
- [**Level2**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level2): Ταχύτερη συμπίεση με ελαφρώς καλύτερο λόγο από το **Level1**.
- [**Level3**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level3): Παρέχει καλύτερη συμπίεση από το **Level2** με μέτρια επίδραση στον χρόνο επεξεργασίας.
- [**Level4**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level4): Παρέχει καλύτερη συμπίεση από το **Level3**.
- [**Level5**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level5): Παρέχει βελτιωμένη συμπίεση σε σχέση με το **Level4** με επιπλέον χρόνο επεξεργασίας.
- [**Level6**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level6): Πρότυπη συμπίεση που προσφέρει καλή ισορροπία μεταξύ ταχύτητας επεξεργασίας και μεγέθους αρχείου. Αυτό είναι το *προεπιλεγμένο επίπεδο συμπίεσης*.
- [**Level7**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level7): Παρέχει καλύτερη συμπίεση από το **Level6** με πιο αργή επεξεργασία.
- [**Level8**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level8): Παρέχει καλύτερη συμπίεση από το **Level7**.
- [**Level9**](https://reference.aspose.com/slides/el/php-java/aspose.slides/compressionlevel/#Level9): Μέγιστη συμπίεση. Παράγει το μικρότερο μέγεθος αρχείου με κόστος του μεγαλύτερου χρόνου επεξεργασίας.

Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX *χωρίς συμπίεση*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Αυτό το παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με *μέγιστη συμπίεση*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση Μικρογραφίας**

Η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ελέγχει τη δημιουργία μικρογραφίας όταν αποθηκεύετε μια παρουσίαση σε PPTX:

- Εάν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτή είναι η προεπιλογή.
- Εάν οριστεί σε `false`, διατηρείται η τρέχουσα μικρογραφία. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς ανανέωση της μικρογραφίας.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Αυτή η επιλογή βοηθά στη μείωση του χρόνου που απαιτείται για την αποθήκευση μιας παρουσίασης σε μορφή PPTX.
{{% /alert %}}

## **Αποθήκευση Ενημερώσεων Προόδου σε Ποσοστό**

Η αναφορά προόδου αποθήκευσης διαμορφώνεται μέσω της μεθόδου [setProgressCallback](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/#setProgressCallback) στην κλάση [SaveOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/) και στις υποκλάσεις της. Παρέχετε έναν διακομιστή Java που υλοποιεί τη διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/); κατά την εξαγωγή, η κλήση επιστρέφει περιοδικές ενημερώσεις σε ποσοστό.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Χρησιμοποιήστε εδώ την τιμή του ποσοστού προόδου.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Η Aspose έχει δημιουργήσει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σάς επιτρέπει να χωρίσετε μια παρουσίαση σε πολλά αρχεία αποθηκεύοντας επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξητική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η αυξητική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλής η αποθήκευση του ίδιου αντικειμένου Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) δεν είναι ασφαλές για πολλαπλά νήματα· αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

Τα [Hyperlinks](/slides/el/php-java/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Τα κλασσικά [document properties](/slides/el/php-java/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.