---
title: Μετατροπή PPT σε PPTX σε PHP
linktitle: PPT σε PPTX
type: docs
weight: 20
url: /el/php-java/convert-ppt-to-pptx/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- PPT σε PPTX
- αποθήκευση PPT ως PPTX
- εξαγωγή PPT σε PPTX
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μετατροπή παλαιών αρχείων PPT σε PPTX σε PHP με Aspose.Slides. Περιλαμβάνει παραδείγματα PHP για μετατροπή ενός αρχείου ή δέσμης, διαχείριση σφαλμάτων και σημειώσεις πιστότητας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιότερη δυαδική μορφή του PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides for PHP μέσω Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) , έπειτα καλέστε το [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/#Pptx). Το μπλοκ `finally` απελευθερώνει την παρουσίαση και απελευθερώνει τους πόρους της.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Φόρτωση της κληρονομικής παρουσίασης PPT.
$presentation = new Presentation("presentation.ppt");
try {
    // Αποθήκευση της παρουσίασης σε μορφή PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η επέκταση αρχείου δεν καθορίζει από μόνη της τη μορφή εξόδου· το όρισμα [SaveFormat::Pptx](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/#Pptx) το κάνει. Διατηρήστε διαφορετικές διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το παρακάτω παράδειγμα μετατρέπει κάθε αρχείο `.ppt` σε έναν φάκελο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, έτσι μια αποτυχία μετατροπής δεν σταματά το υπόλοιπο batch.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Για παραγωγικές εργασίες, καταγράψτε την πλήρη εξαίρεση, αποφασίστε αν μπορεί να αντικατασταθεί υπάρχον αρχείο εξόδου και γράψτε τα ονόματα των αποτυχημένων αρχείων σε ουρά επανάληψης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία με κωδικό πρόσβασης που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμες διαδρομές και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε την [Παρουσιάσεις με κωδικό πρόσβασης](/slides/el/php-java/password-protected-presentation/) για φόρτωση κρυπτογραφημένων αρχείων.

## **Πιστότητα και κληρονομημένες λειτουργίες**

Η μετατροπή συνήθως διατηρεί τις διαφάνειες, τα master, τις διατάξεις, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα διαγράμματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε δυνατότητα με τον ακριβώς ίδιο τρόπο. Μια κληρονομημένη δυνατότητα που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη, μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινούμενα σχέδια, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελέγχους ActiveX, ενσωματωμένα μέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή που υποστηρίζει μακροεντολές, επομένως χρησιμοποιήστε κατάλληλη ροή εργασίας με ενεργοποιημένες μακροεντολές όταν η VBA πρέπει να παραμείνει διαθέσιμη. Επίσης, επαληθεύστε ότι οι απαιτούμενες γραμματοσειρές και οι εξωτερικοί πόροι υπάρχουν στο περιβάλλον όπου η μετατρεπόμενη παρουσίαση θα ανοιχτεί ή θα αποδοθεί.

Για σημαντικά έγγραφα, ανοίξτε ξανά το παραγόμενο PPTX προγραμματιστικά και ελέγξτε τους βασικούς αριθμούς διαφανειών και το περιεχόμενο, έπειτα συγκρίνετε την εμφάνισή του και τη συμπεριφορά προβολής διαφανειών στο προοριζόμενο πρόγραμμα προβολής. Μην αντιμετωπίζετε μια επιτυχή κλήση του [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) ως απόδειξη ότι κάθε κληρονομημένη λειτουργία έχει ακριβή αναπαράσταση στο PPTX.

## **Πότε να χρησιμοποιήσετε το PPTX**

Χρησιμοποιήστε το PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, ανταλλαγεί με συστήματα που δουλεύουν με πακέτα Open XML ή αποθηκεύεται σε μορφή που είναι πιο εύκολο να επιθεωρηθεί και να ανακτηθεί από το παλαιότερο δυαδικό PPT. Κρατήστε το αρχικό PPT ως αρχείο αρχείου ή αντιγραφή επαναφοράς μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους πιστότητας.

Εάν χρειάζεστε PDF, HTML, εικόνες, XPS ή κάποιο άλλο τύπο εξόδου, χρησιμοποιήστε τις οδηγίες συγκεκριμένων μορφών στο [Convert Presentations to Multiple Formats](/slides/el/php-java/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν επεξεργάσιμες δυνατότητες PowerPoint.

## **Online Μετατροπέας**

Για περιστασιακό αρχείο ή γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε τον [online μετατροπέας PPT σε PPTX](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία batch ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το PHP API.

## **Σχετικά άρθρα**

- [PPT vs PPTX](/slides/el/php-java/ppt-vs-pptx/)
- [Αποθήκευση παρουσιάσεων σε PHP](/slides/el/php-java/save-presentation/)
- [Υποστηριζόμενες μορφές αρχείων](/slides/el/php-java/supported-file-formats/)
- [Άνοιγμα παρουσιάσεων σε PHP](/slides/el/php-java/open-presentation/)

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς να είναι εγκατεστημένο το Microsoft PowerPoint;**

Ναι. Το Aspose.Slides for PHP μέσω Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς την ανάγκη του Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT σε PPTX όλο το περιεχόμενο ακριβώς όπως είναι;**

Διατηρεί το κοινό περιεχόμενο παρουσίασης, αλλά η ακριβής πιστότητα δεν εγγυάται για κάθε κληρονομημένη ή μη υποστηριζόμενη λειτουργία. Εξετάστε το παραγόμενο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, πολυμέσα, εξειδικευμένες κινούμενες εικόνες ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα αρχείο PPT με κωδικό πρόσβασης;**

Ναι, εφόσον παρέχετε τον σωστό κωδικό πρόσβασης κατά τη φόρτωση του αρχείου. Ένας ελλιπής ή λανθασμένος κωδικός πρόσβασης προκαλεί αποτυχία της διαδικασίας φόρτωσης.

**Πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να επαληθεύσετε το PPTX στα προγράμματα προβολής και τις ροές εργασίας που σας ενδιαφέρουν. Αυτό παρέχει αντίγραφο επαναφοράς εάν μια κληρονομημένη λειτουργία μετατραπεί διαφορετικά.