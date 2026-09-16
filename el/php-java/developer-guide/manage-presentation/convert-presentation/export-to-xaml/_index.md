---
title: Εξαγωγή Παρουσιάσεων σε XAML με PHP
linktitle: Παρουσίαση σε XAML
type: docs
weight: 30
url: /el/php-java/export-to-xaml/
keywords:
- εξαγωγή PowerPoint
- εξαγωγή OpenDocument
- εξαγωγή παρουσίασης
- μετατροπή PowerPoint
- μετατροπή OpenDocument
- μετατροπή παρουσίασης
- PowerPoint σε XAML
- OpenDocument σε XAML
- παρουσίαση σε XAML
- PPT σε XAML
- PPTX σε XAML
- ODP σε XAML
- αποθήκευση PPT ως XAML
- αποθήκευση PPTX ως XAML
- αποθήκευση ODP ως XAML
- εξαγωγή PPT σε XAML
- εξαγωγή PPTX σε XAML
- εξαγωγή ODP σε XAML
- PHP
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint και OpenDocument σε XAML χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java — γρήγορη, χωρίς Office λύση που διατηρεί τη διάταξή σας αμετάβλητη."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με προεπιλεγμένες ρυθμίσεις και παρουσιάζει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο επίσης απαντά σε μερικές συνηθισμένες ερωτήσεις που αφορούν τις εναλλακτικές γραμματοσειρές, τη συμβατότητα των στοίβων XAML και τη συμπεριφορά εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια γλώσσα σήμανσης βασισμένη σε XML που χρησιμοποιείται για την περιγραφή διεπαφών χρήστη σε πλαίσια όπως WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) και Xamarin.Forms.

Μπορείτε να εργαστείτε με αρχεία XAML σε ένα οπτικό σχεδιαστή ή να γράψετε και να επεξεργαστείτε το σήμα απευθείας.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Ρυθμίσεις**

Το παρακάτω παράδειγμα PHP δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με προεπιλεγμένες ρυθμίσεις. Αρχικοποιήστε το PHP Java Bridge και φορτώστε το `aspose.slides.php` πριν εκτελέσετε τα παραδείγματα σε αυτό το άρθρο. Τοποθετήστε το `pres.pptx` στον κατάλογο εργασίας του διακομιστή Java Bridge ή παρέχετε μια απόλυτη διαδρομή προσβάσιμη από αυτόν τον διακομιστή.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Από προεπιλογή, οι εξαγώμενες διαφάνειες αποθηκεύονται σε έναν υποφάκελο `pres` του τρέχοντος καταλόγου εργασίας του διακομιστή Java Bridge. Ο φάκελος δημιουργείται αυτόματα και τυχόν απαιτούμενες εικόνες αποθηκεύονται εκεί επίσης.

Το όνομα του φακέλου εξόδου λαμβάνεται από το όνομα του αρχείου προέλευσης χωρίς την επέκτασή του. Για το `pres.pptx`, τα αρχεία εξόδου ονομάζονται `pres/Slide_1.xaml`, `pres/Slide_2.xaml` κ.λπ. Ακόμη και αν περάσετε μια απόλυτη διαδρομή στην είσοδο παρουσίασης, ο φάκελος εξόδου δημιουργείται σχετικά με τον τρέχοντα κατάλογο εργασίας του διακομιστή Java Bridge, αντί να βρίσκεται δίπλα στο αρχείο εισόδου.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Ρυθμίσεις**

Χρησιμοποιήστε τη διεπαφή [IXamlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloptions/) για να ελέγξετε πώς το Aspose.Slides εξάγει μια παρουσίαση σε XAML.

Για να αποθηκεύσετε την έξοδο σε προσαρμοσμένη θέση, παρέχετε έναν διακομιστή Java που υλοποιεί το [IXamlOutputSaver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloutputsaver/) και περάστε μια παρουσία της υλοποίησής σας στη μέθοδο [setOutputSaver](https://reference.aspose.com/slides/el/php-java/aspose.slides/xamloptions/#setOutputSaver) του [XamlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/xamloptions/).

Για να συμπεριλάβετε κρυφές διαφάνειες στην έξοδο XAML, καλέστε το [setExportHiddenSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) με τιμή `true`, όπως φαίνεται στο παρακάτω παράδειγμα PHP:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Συλλογή Όλων των Παραγόμενων Αντικειμένων XAML**

Μια εξαγωγή XAML μπορεί να δημιουργήσει ένα έγγραφο XAML για κάθε εξαγώμενη διαφάνεια καθώς και ξεχωριστές εικόνες και βοηθητικούς πόρους. Αναθέστε έναν προσαρμοσμένο [IXamlOutputSaver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloutputsaver/) στο [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/el/php-java/aspose.slides/xamloptions/#setOutputSaver) για να λαμβάνετε αυτά τα αντικείμενα αντί για τον προεπιλεγμένο αποθηκευτή αρχείων. Ξεκινήστε την εξαγωγή με την υπερφόρτωση του [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) που δέχεται επιλογές XAML.

Η συνάρτηση `java_closure` του PHP Java Bridge εκθέτει ένα αντικείμενο PHP ως διεπαφή Java. Κρατήστε τόσο τον αποθηκευτή PHP όσο και το proxy του ζωντανά μέχρι να ολοκληρωθεί η εξαγωγή. Οι σύνδεσμοι διεπαφής οδηγούν στο API Java που υλοποιείται από το proxy.

### **Κατανόηση του Κύκλου Ζωής του Callback**

Ο εξαγωγέας καλεί το [IXamlOutputSaver::save](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) ξεχωριστά για κάθε παραγόμενο αντικείμενο:

- `path` προσδιορίζει το αντικείμενο και μπορεί να περιέχει σχετικούς καταλόγους. Διατηρήστε αυτή την πληροφορία επειδή το XAML μπορεί να αναφέρεται σε πόρους μέσω σχετικών διαδρομών.
- `data` περιέχει τα byte του αντικειμένου. Οι εικόνες και άλλοι δυαδικοί πόροι δεν πρέπει να αποκωδικοποιηθούν ως κείμενο.
- Ο αποθηκευτής είναι υπεύθυνος για τη διατήρηση ή την αποθήκευση των δεδομένων πριν επιστρέψει. Τα παραδείγματα μετατρέπουν κάθε Java byte array σε PHP binary string που ανήκει στην εφαρμογή.
- Θεωρείτε την εξαγωγή επιτυχημένη μόνο όταν η λειτουργία αποθήκευσης της παρουσίασης επιστρέψει και όλα τα callbacks έχουν ολοκληρωθεί με επιτυχία. Μην αγνοείτε σφάλματα αποθήκευσης ή ξεκινάτε αόρατες εγγραφές στο παρασκήνιο. Εάν η μόνιμη αποθήκευση συμβαίνει αργότερα, αναφέρετε τη συνολική επιτυχία μόνο μετά την ολοκλήρωση αυτού του βήματος.

Το [XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) ισχύει επίσης για προσαρμοσμένο αποθηκευτή. Η προεπιλεγμένη τιμή, `false`, εξαιρεί τα XAML έγγραφα κρυφών διαφανειών. Η μεταβίβαση `true` τα συμπεριλαμβάνει μαζί με όλους τους απαιτούμενους πόρους για την εξαγωγή τους. Οι αριθμοί πόρων εξαρτώνται από την παρουσίαση· μην υποθέτετε ένα callback ανά διαφάνεια ή σταθερή σειρά callbacks.

### **Εξαγωγή στη Μνήμη και Έλεγχος των Αντικειμένων**

Αυτό το πλήρες παράδειγμα φορτώνει το `pres.pptx`, συλλέγει κάθε αντικείμενο σε έναν πίνακα συνAssociative PHP με δυαδικές συμβολοσειρές και εκτυπώνει το όνομα, τον τύπο και το μέγεθος σε byte. Διατηρεί τα παρεχόμενα ονόματα ακριβώς. Τα διπλότυπα ονόματα θεωρούν τη συλλογή ως άκυρη αντί να αντικαθιστούν σιωπηρά ένα αντικείμενο. Το παράδειγμα ελέγχει αυτό πριν χρησιμοποιήσει τα αποτελέσματα.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Μόνο το XAML θεωρείται κείμενο UTF-8 για προαιρετική επιθεώρηση.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Ο έλεγχος επεκτάσεων είναι χρήσιμος για επιθεώρηση· διατηρήστε όλα τα αντικείμενα, συμπεριλαμβανομένων άγνωστων τύπων πόρων. Μην τροποποιείτε τα byte κατά την αποθήκευση ή τη μετάδοση. Οι συμβολοσειρές PHP μπορούν να διακρατούν δυαδικά δεδομένα, συμπεριλαμβανομένων των μηδενικών byte. Θεωρείτε μια συμβολοσειρά ως κείμενο UTF‑8 μόνο όταν επιθεωρείτε το XAML· μην μετατρέπετε τα byte εικόνας ή πόρου.

### **Συσκευασία των Συλλεγμένων Αντικειμένων σε Αρχείο ZIP**

Αυτό το ανεξάρτητο παράδειγμα συλλέγει την εξαγωγή, επικυρώνει τα ονόματα και γράφει τα αρχικά byte σε αρχείο ZIP. Ένας αποκλειστικά δημιουργημένος κατάλογος εργασίας διαχωρίζει ταυτόχρονες εργασίες εξαγωγής. Το παράδειγμα απαιτεί την επέκταση PHP Phar με υποστήριξη ZIP. Οι καταχωρήσεις ZIP χρησιμοποιούν εμπρός κάθετες γραμμές (`/`) και διατηρούν σχετικούς καταλόγους. Μη ασφαλή ονόματα ή ονόματα που συγκρούονται μετά την κανονικοποίηση απορρίπτουν ολόκληρο το πακέτο πριν γραφτεί.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

Το παράδειγμα χρησιμοποιεί το [PharData](https://www.php.net/manual/en/class.phardata.php) για να γράψει ένα τοπικό αρχείο ZIP στον κατάλογο εργασίας της διεργασίας PHP· ο εξαγωγέας δεν γράφει ξεχωριστά αρχεία XAML ή εικόνας. Για αποθήκευση σε απομακρυσμένο χώρο, αντικαταστήστε το στάδιο γραφής του αρχείου με ανεβάσματα των συλλεγμένων δυαδικών συμβολοσειρών. Χρησιμοποιήστε ένα αναγνωριστικό εργασίας εξαγωγής συν το πλήρες σχετικό όνομα του αντικειμένου ως κλειδί blob ή αποθηκεύστε το αναγνωριστικό εργασίας, το σχετικό όνομα και τα δυαδικά δεδομένα σε γραμμή βάσης δεδομένων. Δημοσιεύστε την εργασία μόνο αφού ολοκληρωθούν όλα τα ανεβάσματα ή δεσμευτεί η συναλλαγή της βάσης. Καθαρίστε τμήματα εξόδου εάν αποτύχει η μόνιμη αποθήκευση.

Για μεγάλες παρουσιάσεις, ένας προσαρμοσμένος αποθηκευτής μπορεί να αποθηκεύει απευθείας κάθε αντικείμενο στην αποθήκευση της εφαρμογής ώστε να αποφύγετε τη διατήρηση επιπλέον αντιγράφου ολόκληρης της εξαγωγής στη μνήμη. Κρατήστε κάθε callback συγχρονισμένο από την προοπτική του εξαγωγέα: επιστρέψτε μόνο αφού ο προορισμός έχει αποδεχθεί τα byte και επιτρέψτε στα σφάλματα να φτάσουν στον καλούντα.

### **Διατήρηση Ονομάτων Πόρων και Επαλήθευση Αναφορών**

- Κανονικοποιήστε τα διαχωριστικά διαδρομών όταν τοποθετείται απαιτείται, αλλά διατηρήστε τους σχετικούς καταλόγους. Μην χρησιμοποιείτε μόνο το [basename](https://www.php.net/manual/en/function.basename.php) εκτός αν κάθε παραγόμενο όνομα είναι σίγουρα μοναδικό και οι αναφορές πόρων παραμένουν έγκυρες.
- Εφαρμόστε επικυρωτικό έλεγχο ονομάτων ειδικό για τον προορισμό. Όταν γράφετε ξεχωριστά αρχεία, απορρίψτε διαδρομές που αρχίζουν με ρίζα και τμήματα διαφυγής, λύστε τον προορισμό σε απόλυτη διαδρομή και βεβαιωθείτε ότι παραμένει κάτω από τον προορισμένο κατάλογο εξαγωγής, περιλαμβάνοντας το διαχωριστικό καταλόγου στον έλεγχο περιορισμού. Χρησιμοποιήστε κατάλογο ελεγχόμενο από την εφαρμογή χωρίς συμβολικούς δεσμούς που θα μπορούσαν να ανακατευθύνουν εγγραφές.
- Χρησιμοποιήστε ξεχωριστό αποθηκευτή και χώρο ονομάτων αποθήκευσης για κάθε εργασία εξαγωγής. Εντοπίστε συγκρούσεις μετά την κανονικοποίηση των διαχωριστών και σύμφωνα με τους κανόνες ασυμμετρίας κεφαλαίων-πεζών του προορισμού.
- Πριν τη δημοσίευση, αναλύστε κάθε έγγραφο XAML ως XML και ελέγξτε τις αναφορές πόρων βασισμένες σε αρχεία, όπως τα χαρακτηριστικά `Source` ή `ImageSource` εικόνας. Επίλυση κάθε σχετικού URI έναντι του καταλόγου του περιέχοντος αντικειμένου XAML, κανονικοποίηση του προκύψαντος ονόματος αποθήκευσης και επιβεβαίωση ότι το αντίστοιχο κλειδί χάρτη, η καταχώρηση ZIP ή το αποθηκευμένο αντικείμενο υπάρχει. Θεωρήστε τα εξωτερικά URI και τις εκφράσεις σήμανσης XAML ξεχωριστά από τα σχετικά ονόματα αρχείων.

Για παράδειγμα, αν το `pres/Slide_1.xaml` αναφέρεται στο `images/image1.png`, ο αποθηκευμένος πόρος πρέπει να είναι διαθέσιμος ως `pres/images/image1.png`. Η διατήρηση μόνο του `image1.png` θα διακόψει τη σχέση αυτή. Για αποθήκευση αντικειμένων, διατηρήστε την ίδια δομή κάτω από το πρόθεμα εργασίας και κάντε αυτά τα URLs πόρων προσβάσιμα στον καταναλωτή XAML. Ξαναανοίξτε το ολοκληρωμένο ZIP για να επαληθεύσετε τα ονόματα καταχωρήσεων και τα byte των πόρων και φορτώστε αντιπροσωπευτικές διαφάνειες στο περιβάλλον XAML-στόχο για να ελέγξετε ότι οι εικόνες επιλύονται σωστά.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξασφαλίσω προβλέψιμες γραμματοσειρές εάν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στο μηχάνημα;**

Καλέστε το [setDefaultRegularFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) στο [XamlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/xamloptions/) — χρησιμοποιείται ως εναλλακτική γραμματοσειρά κατά την εξαγωγή όταν η αρχική λείπει. Αυτό δεν εγγυάται ότι το παραγόμενο XAML θα αναφέρει την εναλλακτική γραμματοσειρά ή ότι η γραμματοσειρά είναι διαθέσιμη στον προορισμό. Βεβαιωθείτε ότι οι γραμματοσειρές του XAML είναι διαθέσιμες στο περιβάλλον όπου θα εμφανίζεται.

**Η εξαγόμενη XAML προορίζεται μόνο για WPF ή μπορεί να χρησιμοποιηθεί και σε άλλες στοίβες XAML;**

Το Aspose.Slides εξάγει XAML για WPF μέσω του δημόσιου API του. Η συμβατότητα με άλλες στοίβες XAML, όπως UWP και Xamarin.Forms, δεν είναι εγγυημένη. Δοκιμάστε το παραγόμενο σήμα στο περιβάλλον-στόχο σας.

**Υποστηρίζονται οι κρυφές διαφάνειες και πώς μπορώ να αποτρέψω την προεπιλεγμένη εξαγωγή τους;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν περιλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [setExportHiddenSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) στο [XamlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/xamloptions/) — αφήστε το απενεργοποιημένο εάν δεν χρειάζεστε την εξαγωγή τους.