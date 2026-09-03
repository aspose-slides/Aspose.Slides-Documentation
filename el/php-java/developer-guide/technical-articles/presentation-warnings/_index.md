---
title: Διαχείριση Προειδοποιήσεων Παρουσίασης σε PHP
type: docs
weight: 90
url: /el/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback προειδοποίησης
- πολιτική προειδοποίησης
- απώλεια δεδομένων
- διαφθορά πηγής
- ζήτημα συμβατότητας
- αντικατάσταση γραμματοσειράς
- ψηφιακή υπογραφή
- φόρτωση παρουσίασης
- απόδοση παρουσίασης
- μετατροπή παρουσίασης
- αποθήκευση παρουσίασης
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Μάθετε πώς να συλλέγετε, κατηγοριοποιείτε και αντιμετωπίζετε προειδοποιήσεις κατά τη φόρτωση, την απόδοση, τη μετατροπή και την αποθήκευση παρουσιάσεων με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναφέρει επανακτήσιμα προβλήματα κατά τη φόρτωση, την απόδοση, τη μετατροπή ή την αποθήκευση μιας παρουσίασης. Παραδείγματα περιλαμβάνουν κατεστραμμένα αρχεία προέλευσης, περιεχόμενο που δεν μπορεί να διατηρηθεί, αντικατάσταση γραμματοσειρών και περιορισμούς του μορφότυπου προορισμού. Ένα callback προειδοποίησης επιτρέπει σε μια εφαρμογή να καταγράψει αυτές τις συνθήκες και να αποφασίσει εάν η τρέχουσα λειτουργία μπορεί να συνεχιστεί.

Δημιουργήστε μια κλάση PHP με δημόσια μέθοδο `warning` και εκθέστε την μέσω του PHP Java Bridge ως τη διεπαφή Java [IWarningCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarningcallback/) χρησιμοποιώντας `java_closure`. Εξετάστε τις τιμές [getWarningType](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getWarningType--) και [getDescription](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getDescription--) που παρέχονται μέσω του [IWarningInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/). Επιστρέψτε [ReturnAction::Continue](https://reference.aspose.com/slides/el/php-java/aspose.slides/returnaction/#Continue) για να αποδεχθείτε την προειδοποίηση ή [ReturnAction::Abort](https://reference.aspose.com/slides/el/php-java/aspose.slides/returnaction/#Abort) για να σταματήσετε τη λειτουργία.

Χρησιμοποιήστε το [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setWarningCallback) για τις προειδοποιήσεις που προκύπτουν κατά το άνοιγμα μιας παρουσίασης. Οι κλάσεις επιλογών απόδοσης και εξαγωγής κληρονομούν το [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/#setWarningCallback), το οποίο λαμβάνει προειδοποιήσεις από την απόδοση διαφάνειας, τη μετατροπή και την αποθήκευση. Επειδή η ίδια η προειδοποίηση δεν προσδιορίζει τη λειτουργία της εφαρμογής, συσχετίστε κάθε instance του callback με ένα στάδιο λειτουργίας όταν δημιουργείτε μια συνδυασμένη αναφορά.

## **Προειδοποιήσεις και Εξαιρέσεις**

Οι εξαιρέσεις Java εκτίθενται στη PHP μέσω του PHP Java Bridge· πιάστε τις στο όριο της λειτουργίας, όπως φαίνεται στο παρακάτω παράδειγμα. Οι σύνδεσμοι της διεπαφής Java σε αυτό το άρθρο περιγράφουν το συμβόλαιο του callback που χρησιμοποιείται από τη γέφυρα.

Μια προειδοποίηση περιγράφει μια κατάσταση από την οποία το Aspose.Slides μπορεί να ανακάμψει εάν το callback επιστρέψει `ReturnAction::Continue`. Μια εξαίρεση σημαίνει ότι η ζητούμενη λειτουργία δεν μπορεί να ολοκληρωθεί κανονικά· οι εξαιρέσεις δεν μετατρέπονται σε προειδοποιήσεις και δεν μπορούν να αντιμετωπιστούν από μια πολιτική προειδοποιήσεων.

Επιστρέφοντας το `ReturnAction::Abort` ζητείται από τον διαχειριστή προειδοποιήσεων να τερματίσει τη τρέχουσα λειτουργία ρίχνοντας μια εξαίρεση. Η δημόσια εξαίρεση εξαρτάται από τη λειτουργία και το μορφότυπο παρουσίασης. Για παράδειγμα, η φόρτωση μπορεί να εμφανίσει μια [PptxReadException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxreadexception/) ή [PptReadException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptreadexception/), ενώ η αποθήκευση ή η εξαγωγή μπορεί να εμφανίσει μια [PptxException](https://reference.aspose.com/slides/el/php-java/aspose.slides/pptxexception/). Διαχειριστείτε την εξαίρεση στο όριο της λειτουργίας και χρησιμοποιήστε την αναφορά προειδοποιήσεων για να προσδιορίσετε εάν η πολιτική της εφαρμογής προκάλεσε τον τερματισμό αντί να βασίζεστε σε έναν υποτύπο ή μήνυμα εξαίρεσης. Το callback καταγράφει την προειδοποίηση πριν επιστέψει το `ReturnAction::Abort`, εξασφαλίζοντας ότι ο λόγος παραμένει διαθέσιμος στην εφαρμογή.

## **Κατηγορίες Προειδοποιήσεων**

Η κλάση [WarningType](https://reference.aspose.com/slides/el/php-java/aspose.slides/warningtype/) παρέχει ακέραιες σταθερές για τις παρακάτω κατηγορίες:

| Τύπος προειδοποίησης | Σημασία | Τυπική πολιτική |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/el/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Η πηγαία παρουσίαση περιέχει καταστροφή που μπορεί να κάνει ένα έγγραφο αποθηκευμένο στο αρχικό του μορφότυπο αχρησιμοποίητο. | Ακύρωση. |
| [DataLoss](https://reference.aspose.com/slides/el/php-java/aspose.slides/warningtype/#DataLoss) | Κείμενο, διαγράμματα, εικόνες ή άλλα δεδομένα μπορεί να λείπουν μετά τη φόρτωση ή την αποθήκευση. | Ακύρωση. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/el/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | Η παρουσίαση μπορεί να χάσει σημαντική μορφοποίηση. | Ακύρωση σε αυστηρή λειτουργία επικύρωσης· διαφορετικά καταγραφή και συνέχιση. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/el/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Μπορεί να προκύψει περιορισμένη διαφορά μορφοποίησης. | Καταγραφή για διαγνωστικούς σκοπούς και συνέχιση. |
| [CompatibilityIssue](https://reference.aspose.com/slides/el/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Το αποτέλεσμα μπορεί να μην ανοίξει ή να λειτουργήσει σωστά σε κάποιες εφαρμογές ή παλιές εκδόσεις. | Καταγραφή και συνέχιση εκτός εάν η συμβατότητα είναι υποχρεωτική. |
| [UnexpectedContent](https://reference.aspose.com/slides/el/php-java/aspose.slides/warningtype/#UnexpectedContent) | Η πηγή περιέχει μη υποστηριζόμενο ή μη αναγνωρισμένο περιεχόμενο του οποίου η επίδραση ενδέχεται να μην είναι ακόμη γνωστή. | Καταγραφή και συνέχιση, ή αντιμετώπιση ως σφάλμα σε αυστηρή πολιτική. |

Η κατηγορία θα πρέπει να καθοδηγεί την απόφαση της πολιτικής. Αποθηκεύστε την τιμή που επιστρέφει το [getDescription](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getDescription--) για διαγνωστικούς σκοπούς, αλλά μην βασίζεστε στη διατύπωσή της για λογική της εφαρμογής, καθώς το κείμενο του μηνύματος μπορεί να διαφέρει μεταξύ σεναρίων προειδοποίησης και εκδόσεων προϊόντος.

## **Συλλογή και Κατηγοριοποίηση Προειδοποιήσεων**

Το παρακάτω παράδειγμα χρησιμοποιεί μία αναφορά επιπέδου εφαρμογής για ολόκληρη τη διαδικασία επεξεργασίας. Ένα ξεχωριστό instance του callback ετικετοποιεί τις προειδοποιήσεις από τη φόρτωση, την απόδοση, τη μετατροπή PDF και την αποθήκευση PPTX. Η πολιτική ακυρώνει σε περίπτωση καταστροφής προέλευσης ή απώλειας δεδομένων, προαιρετικά ακυρώνει σε περίπτωση σημαντικής απώλειας μορφοποίησης και συνεχίζει για άλλες προειδοποιήσεις. Το callback μετατρέπει τις τιμές προειδοποίησης σε εγγενείς τιμές PHP με `java_values` πριν τις καταγράψει και τις συγκρίνει.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Περάστε `false` για το `abortOnMajorFormattingLoss` κατά τη δημιουργία του `WarningPolicy` εάν οι σημαντικές διαφορές μορφοποίησης είναι αποδεκτές. Τα ζητήματα συμβατότητας, η μικρή απώλεια μορφοποίησης και το μη αναμενόμενο περιεχόμενο παραμένουν στην αναφορά ακόμη και όταν η λειτουργία συνεχίζεται. Αναπτύξτε το `WarningPolicy::getAction` εάν η εφαρμογή πρέπει να απορρίψει οποιαδήποτε από αυτές τις κατηγορίες.

## **Κοινά Σενάρια Προειδοποίησης**

Οι προειδοποιήσεις μπορούν να εμφανιστούν σε διαφορετικά στάδια μιας ροής εργασίας:

- **Ψηφιακές υπογραφές:** Μια υπογεγραμμένη παρουσίαση μπορεί να δημιουργήσει μια προειδοποίηση κατά τη φόρτωση ότι η υπογραφή της θα χαθεί κατά την επεξεργασία. Το Aspose.Slides αναφέρει αυτήν την κατάσταση `DataLoss` μέσω του [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationsignedwarninginfo/). Ένα callback στο στάδιο φόρτωσης επιτρέπει στην εφαρμογή να απορρίψει το αρχείο ή να αποδεχθεί ρητά την αναφερόμενη απώλεια.
- **Αντικατάσταση γραμματοσειράς:** Μια μη διαθέσιμη γραμματοσειρά μπορεί να αντικατασταθεί ενώ μια διαφάνεια αποδίδεται ή εξάγεται. Οι προειδοποιήσεις αντικατάστασης γραμματοσειράς αναφέρονται ως `DataLoss`, έτσι η αυστηρή πολιτική παραπάνω ακυρώνει ακόμη και αν η εφαρμογή θεωρούσε την συγκεκριμένη αντικατάσταση οπτικά αποδεκτή. Για να παρατηρήσετε αυτή τη συμπεριφορά, χρησιμοποιήστε μια παρουσίαση εισόδου που περιέχει κείμενο σε γραμματοσειρά μη διαθέσιμη στο περιβάλλον εκτέλεσης. Η περιγραφή της προειδοποίησης προσδιορίζει την αντικατάσταση· ρυθμίστε τις απαιτούμενες γραμματοσειρές ή [font substitution rules](/slides/el/php-java/font-substitution/) πριν επαναλάβετε.
- **Μη υποστηριζόμενο ή μη αναμενόμενο περιεχόμενο:** Ένας φορτωτής μπορεί να συναντήσει αρχεία παρουσίασης ή δυνατότητες που δεν αναγνωρίζει. Τέτοιες προειδοποιήσεις μπορεί να χρησιμοποιούν το `UnexpectedContent`, ή μια πιο σοβαρή κατηγορία όταν γνωρίζεται ότι επηρεάζονται δεδομένα ή μορφοποίηση.
- **Συμβατότητα μορφότυπου:** Η αποθήκευση σε άλλο μορφότυπο παρουσίασης μπορεί να παραλείψει λειτουργίες ή να παραγάγει αποτέλεσμα που συμπεριφέρεται διαφορετικά σε κάποιες εφαρμογές. Για παράδειγμα, η αποθήκευση μιας παρουσίασης με περισσότερους από οκτώ οριζόντιους ή κάθετους οδηγούς σχεδίασης σε παλαιό PPT αναφέρει ένα `CompatibilityIssue`. Το callback στο στάδιο αποθήκευσης μπορεί να καταγράψει την απώλεια και να συνεχίσει, ή να την απορρίψει εάν απαιτείται η διατήρηση όλων των οδηγών.
- **Συμπεριφορά φόρτωσης:** Οι επιλογές φόρτωσης και οι παλιότερες συμπεριφορές μπορούν επίσης να παράγουν προειδοποιήσεις. Για παράδειγμα, το [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) εντοπίζει τη χρήση μιας παρωμένης συμπεριφοράς κλειδώματος παρουσίασης ως `CompatibilityIssue`.

Οι προειδοποιήσεις εξαρτώνται από το πηγαίο έγγραφο, το μορφότυπο προορισμού, τη λειτουργία και την έκδοση του Aspose.Slides. Μην υποθέτετε ότι κάθε αρχείο παράγει προειδοποίηση ή ότι ένα σενάριο αντιστοιχεί πάντα σε μία μόνο κατηγορία.

## **Ασφαλής Διαχείριση Ακυρωμένων Λειτουργιών**

Όταν ένα callback επιστρέφει `ReturnAction::Abort`, μην χρησιμοποιήσετε ένα αντικείμενο που δεν φορτώθηκε και μην υποθέτετε ότι η απόδοση ή η έξοδος αποθήκευσης είναι ολοκληρωμένη. Η λειτουργία μπορεί να τερματιστεί μετά τη δημιουργία ενός αρχείου εξόδου αλλά πριν ολοκληρωθεί.

Αποθηκεύστε τα επικυρωμένα αποτελέσματα σε διαφορετική διαδρομή, όπως `validated-output.pptx`. Αντικαταστήστε μια υπάρχουσα παρουσίαση μόνο αφού η λειτουργία ολοκληρωθεί επιτυχώς, η αναφορά προειδοποιήσεων ικανοποιήσει την πολιτική της εφαρμογής και η έξοδος μπορεί να ανοίξει και να ελεγχθεί. Αυτό αποτρέπει την αντικατάσταση ενός έγκυρου πηγαίου αρχείου με ένα μερικό ή απορριπτόμενο αποτέλεσμα.

Μία κενή αναφορά προειδοποιήσεων δεν είναι εγγύηση ότι κάθε πηγαία δυνατότητα έχει διατηρηθεί. Εφαρμόστε τυχόν πρόσθετους ελέγχους περιεχομένου και εμφανίσεων που απαιτεί η εφαρμογή. Δείτε επίσης [Open Presentations](/slides/el/php-java/open-presentation/) και [Save Presentations](/slides/el/php-java/save-presentation/).

## **Συχνές Ερωτήσεις**

**Μπορεί ένα callback προειδοποίησης να χειριστεί κάθε σφάλμα του Aspose.Slides;**

Όχι. Διαχειρίζεται μόνο επανακτήσιμες καταστάσεις που αναφέρονται ως προειδοποιήσεις. Οι εξαιρέσεις που προκύπτουν ανεξάρτητα από το callback πρέπει να αντιμετωπίζονται από την εφαρμογή γύρω από την κλήση φόρτωσης, απόδοσης, μετατροπής ή αποθήκευσης.

**Εγγυάται η επιστροφή του `ReturnAction::Continue` ταυτόσημο αποτέλεσμα;**

Όχι. Επιτρέπει μόνο τη συνέχιση της επεξεργασίας. Η αναφερθείσα κατάσταση μπορεί ακόμα να προκαλέσει διαφορές σε δεδομένα, μορφοποίηση ή συμβατότητα, επομένως πρέπει να ελέγξετε τους συγκεντρωμένους τύπους προειδοποιήσεων και τις περιγραφές.

**Πώς μπορεί μια εφαρμογή να προσδιορίσει τη λειτουργία που παρήγαγε μια προειδοποίηση;**

Δημιουργήστε ένα instance του callback για κάθε λειτουργία και αποθηκεύστε ένα στάδιο ορισμένο από την εφαρμογή μαζί με τις τιμές που επιστρέφουν τα [getWarningType](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getWarningType--) και [getDescription](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarninginfo/#getDescription--), όπως φαίνεται στο παράδειγμα.