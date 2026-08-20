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
description: "Μετατρέψτε τα παλαιά αρχεία PPT σε PPTX σε PHP με το Aspose.Slides. Περιλαμβάνει παραδείγματα PHP για μετατροπή ενός αρχείου ή μαζική μετατροπή, διαχείριση σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιότερη δυαδική μορφή του PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides for PHP via Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν κατάλογο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το πηγαίο αρχείο με την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/), έπειτα καλέστε [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/#Pptx). Το μπλοκ `finally` απελευθερώνει την παρουσίαση και απελευθερώνει τους πόρους της.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Φορτώστε την παλαιότερη παρουσίαση PPT.
$presentation = new Presentation("presentation.ppt");
try {
    // Αποθηκεύστε την παρουσίαση σε μορφή PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η κατάληξη αρχείου δεν επιλέγει από μόνη της τη μορφή εξόδου· το όρισμα [SaveFormat::Pptx](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/#Pptx) το κάνει. Διατηρήστε διαφορετικές τις διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το παρακάτω παράδειγμα μετατρέπει κάθε αρχείο `.ppt` που βρίσκεται σε έναν κατάλογο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, έτσι μια αποτυχία μετατροπής δεν σταματά το υπόλοιπο παρτίδα.

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

Για παραγωγικά φορτία, καταγράψτε την πλήρη εξαίρεση, αποφασίστε αν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί, και γράψτε τα ονόματα αποτυχημένων αρχείων σε ουρά επανάληψης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία προστατευμένα με κωδικό που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμες διαδρομές και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε [Password-Protected Presentations](/php-java/password-protected-presentation/) για τη φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και Παλαιές Λειτουργίες**

Η μετατροπή συνήθως διατηρεί τις διαφάνειες, τα master, τις διατάξεις, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα διαγράμματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε χαρακτηριστικό με ακριβώς τον ίδιο τρόπο. Ένα παλαιότερο χαρακτηριστικό που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη, μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινήσεις, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελέγχους ActiveX, ενσωματωμένα πολυμέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή με υποστήριξη μακροεντολών, επομένως χρησιμοποιήστε μια κατάλληλη ροή εργασίας με υποστήριξη μακροεντολών όταν η VBA πρέπει να παραμείνει διαθέσιμη. Επίσης, βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές και εξωτερικοί πόροι είναι παρόντες στο περιβάλλον όπου θα ανοιχτεί ή θα αποδοθεί η μετατρεπόμενη παρουσίαση.

Για σημαντικά έγγραφα, ανοίξτε εκ νέου το δημιουργημένο PPTX προγραμματιστικά και ελέγξτε βασικές μετρήσεις διαφανειών και περιεχομένου, έπειτα συγκρίνετε την εμφάνιση και τη συμπεριφορά της παρουσίασης στο προοριζόμενο πρόγραμμα προβολής. Μην θεωρείτε μια επιτυχημένη κλήση [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) απόδειξη ότι κάθε παλαιό χαρακτηριστικό έχει ακριβή αναπαράσταση σε PPTX.

## **Πότε να χρησιμοποιήσετε το PPTX**

Χρησιμοποιήστε το PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, ανταλλαχθεί με συστήματα που εργάζονται με πακέτα Open XML ή αποθηκευτεί σε μορφή που είναι πιο εύκολη στην επιθεώρηση και ανάκτηση από το παλαιότερο δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή εφεδρικό αντίγραφο μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Εάν χρειάζεστε PDF, HTML, εικόνες, XPS ή κάποιον άλλο τύπο εξόδου, χρησιμοποιήστε τις οδηγίες ειδικές για μορφές στο [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν δυνατότητες επεξεργάσιμου PowerPoint.

## **Online Μετατροπέας**

Για περιστασιακό αρχείο ή γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε το [online PPT to PPTX converter](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία παρτίδας ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το PHP API.

## **Σχετικά Άρθρα**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Αποθήκευση Παρουσιάσεων σε PHP](/php-java/save-presentation/)
- [Υποστηριζόμενες Μορφές Αρχείων](/php-java/supported-file-formats/)
- [Άνοιγμα Παρουσιάσεων σε PHP](/php-java/open-presentation/)

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς να είναι εγκατεστημένο το Microsoft PowerPoint;**

Ναι. Το Aspose.Slides for PHP via Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT σε PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο της παρουσίασης, αλλά η ακριβής ακρίβεια δεν είναι εγγυημένη για κάθε παλαιότερο ή μη υποστηριζόμενο χαρακτηριστικό. Ελέγξτε το παραγόμενο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, πολυμέσα, εξειδικευμένες κινήσεις ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα αρχείο PPT προστατευμένο με κωδικό;**

Ναι, εφόσον παρέχετε τον σωστό κωδικό κατά τη φόρτωση του αρχείου. Η έλλειψη ή ο εσφαλμένος κωδικός προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Θα πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να έχετε επιβεβαιώσει το PPTX στους προβολείς και τις διαδικασίες που σας ενδιαφέρουν. Αυτό παρέχει ένα εφεδρικό αντίγραφο σε περίπτωση που κάποιο παλαιό χαρακτηριστικό μετατραπεί διαφορετικά.