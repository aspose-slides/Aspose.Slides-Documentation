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
- παρουσίαση σε ρεύμα
- προκαθορισμένος τύπος προβολής
- Αυστηρή μορφή Office Open XML
- λειτουργία Zip64
- ανανέωση μικρογραφίας
- αποθήκευση προόδου
- PHP
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java — εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας διατάξεις, γραμματοσειρές και εφέ."
---
## **Επισκόπηση**

[Open Presentations in PHP](/slides/el/php-java/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) για να ανοίξετε μια παρουσίαση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) περιέχει τα περιεχόμενα μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides for PHP, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ρεύμα**. Αυτό το άρθρο εξηγεί τους διαφορετικούς τρόπους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Περνάτε το όνομα του αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Κάντε κάποιες εργασίες εδώ...

    // Αποθηκεύστε την παρουσίαση σε αρχείο.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Ρεύματα**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ρεύμα περνώντας ένα ρεύμα εξόδου στη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ρευμάτων. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ρεύμα αρχείου.

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Αποθηκεύστε την παρουσίαση στο ρεύμα.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η παραγόμενη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [setLastView](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/#setLastView) με μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Αυστηρή Μορφή Office Open XML**

Το Aspose.Slides σάς επιτρέπει να αποθηκεύσετε μια παρουσίαση σε μορφή Strict Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε το [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), το αρχείο εξόδου θα αποθηκευτεί σε μορφή Strict Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει στη μορφή Strict Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποθηκεύστε την παρουσίαση σε μορφή Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML σε Κατάσταση Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει όρια 4 GB (2^32 bytes) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, ενώ περιορίζει επίσης το αρχείο σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια σε 2^64.

Η μέθοδος [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/#setZip64Mode) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιήσετε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τις ακόλουθες καταστάσεις:

- [IfNecessary](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τα παραπάνω περιορισμούς. Αυτή είναι η προεπιλεγμένη κατάσταση.
- [Never](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#Never) δεν χρησιμοποιεί ποτέ επεκτάσεις μορφής ZIP64.
- [Always](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#Always) χρησιμοποιεί πάντα επεκτάσεις μορφής ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

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
Όταν αποθηκεύετε με το [Zip64Mode.Never](https://reference.aspose.com/slides/el/php-java/aspose.slides/zip64mode/#Never), πετάγεται μια [PptxException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxexception/) εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση Μικρογραφίας**

Η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ελέγχει τη δημιουργία μικρογραφίας κατά την αποθήκευση μιας παρουσίασης σε PPTX:

- Εάν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτό είναι η προεπιλογή.
- Εάν οριστεί σε `false`, η τρέχουσα μικρογραφία διατηρείται. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς να ανανεώνεται η μικρογραφία της.

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

Η αναφορά προόδου αποθήκευσης ρυθμίζεται μέσω της μεθόδου [setProgressCallback](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/#setProgressCallback) στην κλάση [SaveOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/) και στις υποκλάσεις της. Παρέχετε έναν διακομιστή Java που υλοποιεί τη διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprogresscallback/); κατά την εξαγωγή, η κλήση επιστροφής λαμβάνει περιοδικές ενημερώσεις ποσοστού.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Χρησιμοποιήστε την τιμή ποσοστού προόδου εδώ.
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
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σας επιτρέπει να χωρίσετε μια παρουσίαση σε πολλά αρχεία αποθηκεύοντας τις επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξητική αποθήκευση) ώστε να γραφτούν μόνο οι αλλαγές;**

Όχι. Κατά την αποθήκευση δημιουργείται το πλήρες αρχείο προορισμού κάθε φορά· η αυξητική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλής η αποθήκευση του ίδιου αντικειμένου Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) δεν είναι ασφαλές ως προς τα νήματα [/slides/el/php-java/multithreading/]; αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

[Hyperlinks](/slides/el/php-java/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ., βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα—βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Οι τυπικές [document properties](/slides/el/php-java/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.