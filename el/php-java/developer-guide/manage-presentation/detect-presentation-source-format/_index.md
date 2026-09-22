---
title: Καθορισμός της αρχικής μορφής παρουσίασης σε PHP
linktitle: Μορφή Πηγής
type: docs
weight: 35
url: /el/php-java/detect-presentation-source-format/
keywords:
- μορφή πηγής
- εντοπισμός μορφής παρουσίασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Διαβάστε την αρχική μορφή μιας φορτωμένης παρουσίασης σε PHP με το Aspose.Slides για PHP μέσω Java, συγκρίνετε τα API εντοπισμού και χειριστείτε αρχεία, ροές και παλαιότερες μορφές."
---
## **Επισκόπηση**

Αφού φορτώσετε μια παρουσίαση, καλέστε τη μέθοδο [Presentation::getSourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSourceFormat) για να καθορίσετε την αρχική της μορφή. Χρησιμοποιήστε τη όταν η επόμενη επεξεργασία εξαρτάται από τη μορφή από την οποία φορτώθηκε το τρέχον αντικείμενο.

Η πηγή μορφής διαφέρει από το [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/) που επιλέγεται για ένα αρχείο εξόδου. Η αποθήκευση σε άλλη μορφή δεν αλλάζει την πηγή μορφής της υπάρχουσας εμφάνισης.

## **Ανάγνωση της Πηγής Μορφής Αρχείου**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pptx`. Φορτώνει το αρχείο και επιλέγει μια πολιτική επεξεργασίας εφαρμογής χρησιμοποιώντας [Presentation::getSourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSourceFormat), αντί του ονόματος αρχείου. Αλλάξτε τη διαδρομή εισόδου για να δοκιμάσετε άλλες μορφές. Το παράδειγμα εκτυπώνει την επιλεγμένη πολιτική· αντικαταστήστε τα μηνύματα με τη λογική της εφαρμογής σας.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Αναγνώριση των Υποστηριζόμενων Τιμών**

Η κλάση [SourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/sourceformat/) ορίζει ακέραιους σταθερούς που διακρίνουν τις παρακάτω μορφές παρουσίασης. Οι επεκτάσεις παρακάτω είναι συμβατικές επεκτάσεις, όχι ανασύνθεση του αρχικού ονόματος αρχείου.

| Τιμή SourceFormat | Επέκταση | Μορφή |
| --- | --- | --- |
| `Ppt` | `.ppt` | Παρουσίαση PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Παρουσίαση Office Open XML |
| `Pptm` | `.pptm` | Παρουσίαση Office Open XML με μακροεντολές |
| `Pps` | `.pps` | Παρουσίαση διαφάνειας PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Παρουσίαση διαφάνειας Office Open XML |
| `Ppsm` | `.ppsm` | Παρουσίαση διαφάνειας Office Open XML με μακροεντολές |
| `Pot` | `.pot` | Πρότυπο PowerPoint 97–2003 |
| `Potx` | `.potx` | Πρότυπο Office Open XML |
| `Potm` | `.potm` | Πρότυπο Office Open XML με μακροεντολές |
| `Odp` | `.odp` | Παρουσίαση OpenDocument |
| `Otp` | `.otp` | Πρότυπο παρουσίασης OpenDocument |
| `Fodp` | `.fodp` | Παρουσίαση Flat XML ODF |
| `Xml` | `.xml` | Παρουσίαση PowerPoint XML |

## **Ανάγνωση της Πηγής Μορφής από Ροή**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pps`. Η ανάγνωση των bytes του σε μια μνήμη ροής προσομοιώνει είσοδο που λαμβάνεται χωρίς όνομα αρχείου, όπως τιμή βάσης δεδομένων ή μεταφορτωμένος πίνακας byte. Ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) δέχεται μόνο τη ροή.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

Τα PPT, PPS και POT χρησιμοποιούν την ίδια υποκείμενη δυαδική μορφή. Όταν φορτώνεται με διαδρομή αρχείου, η επέκταση μπορεί να βοηθήσει στον διαχωρισμό διαφάνειας ή προτύπου. Χωρίς όνομα αρχείου, το περιεχόμενο κληρονομικού PPS ή POT μπορεί να αναφερθεί ως `SourceFormat::Ppt`; το παραπάνω παράδειγμα PPS εκτυπώνει την ακέραια τιμή του `SourceFormat::Ppt`.

Εάν η εφαρμογή σας πρέπει να διατηρήσει αυτή τη διάκριση, διατηρήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά. Η επέκταση είναι χρήσιμη υπόδειξη για αυτά τα κληρονομικά υποτύπους, αλλά δεν πρέπει να αποτελεί το μοναδικό κριτήριο για την ταυτοποίηση τυχαίου περιεχομένου παρουσίασης.

## **Σύγκριση Εντοπισμού Πριν και Μετά τη Φόρτωση**

Χρησιμοποιήστε [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/#getPresentationInfo) και [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#getLoadFormat) όταν χρειάζεται να εξετάσετε ένα αρχείο πριν φορτωθεί το πλήρες μοντέλο αντικειμένων της παρουσίασης. Χρησιμοποιήστε [Presentation::getSourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSourceFormat) όταν η εμφάνιση υπάρχει ήδη.

Αυτό το παράδειγμα απαιτεί το `sample.pptx` και εκτυπώνει τις ακέραιες τιμές των `LoadFormat::Pptx` και `SourceFormat::Pptx`, αντίστοιχα. Σε παραγωγή, επιλέξτε το API που ταιριάζει στο στάδιο επεξεργασίας σας· μια παρουσίαση που έχει ήδη φορτωθεί δεν χρειάζεται δεύτερη επιθεώρηση μόνο για την απόκτηση της πηγής μορφής της.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Τα αποτελέσματα χρησιμοποιούν σταθερές από διαφορετικές κλάσεις: [LoadFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadformat/) και [SourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/sourceformat/). Μην συγκρίνετε τις αριθμητικές τους τιμές ούτε υποθέτετε ότι κάθε μορφή έχει ίδια αποτελέσματα εντοπισμού. Η PowerPoint XML μπορεί να αναφερθεί ως `LoadFormat::Unknown` πριν τη φόρτωση και ως `SourceFormat::Xml` μετά τη φόρτωση.

## **Διατήρηση Ξεχωριστών Πηγής και Εξόδου Μορφών**

Αυτό το παράδειγμα απαιτεί το `sample.pptx` και γράφει το `converted.odp`. Εκτυπώνει την ακέραια τιμή του `SourceFormat::Pptx` και πριν και μετά την αποθήκευση της αρχικής εμφάνισης. Μόνο η νέα εμφάνιση που φορτώνεται από την έξοδο ODP αναφέρει `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Μια παρουσίαση που δημιουργείται από το μηδέν με `new Presentation()` αναφέρει `SourceFormat::Pptx`. Δεν έχει αρχικό αρχείο: αυτή είναι η προεπιλεγμένη τιμή για μια νεοδημιουργημένη εμφάνιση, όχι ένδειξη ότι φορτώθηκε αρχείο PPTX. Παρακολουθήστε εάν η εφαρμογή σας δημιούργησε ή φόρτωσε την εμφάνιση ξεχωριστά εάν αυτή η διάκριση έχει σημασία.

## **Αντιστοίχιση Πηγής Μορφής σε Επέκταση**

Το παρακάτω παράδειγμα απαιτεί το `sample.pptx`. Αντιστοιχεί κάθε τρέχουσα τιμή [SourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/sourceformat/) σε μια συμβατική επέκταση, χωρίς ανάλυση του ονόματος αρχείου εισόδου. Η εναλλακτική λύση αποφεύγει την σιωπηρή ανάθεση επέκτασης σε μη αναγνωρισμένη τιμή.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Αυτή η αντιστοίχηση δεν μετατρέπει αρχείο ούτε επαναφέρει υποτύπο κληρονομικού PPS/POT που χάθηκε κατά τη φόρτωση ροής. Για πραγματική αποθήκευση, επιλέξτε ρητά ένα [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/) ή χρησιμοποιήστε τη μετατροπή που φαίνεται στο [Save Presentations in Their Original Format](/slides/el/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Επαλήθευση Μορφών με Αποθήκευση και Επαναφόρτωση**

Αυτό το αυτόνομο παράδειγμα δημιουργεί μια παρουσίαση και γράφει τρία αρχεία στον τρέχοντα φάκελο, αντικαθιστώντας αρχεία με τα ίδια ονόματα. Ανοίγει ξανά κάθε έξοδο τόσο με διαδρομή όσο και μέσω μνήμης ροής. Για PPTX και ODP, και οι δύο διαδρομές αναφέρουν τη αποθηκευμένη μορφή. Για PPS, η φόρτωση με διαδρομή αναφέρει `Pps`, ενώ η φόρτωση των ίδιων bytes χωρίς όνομα αρχείου αναφέρει `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Ο παρακάτω πίνακας συνοψίζει την ταυτοποίηση πηγής μορφής για παρουσιάσεις με αντίστοιχες επεκτάσεις. Τα ονόματα δηλώνουν σταθερές· τα παραδείγματα PHP εκτυπώνουν τις ακέραιες τιμές τους:

| Αποθηκευμένη μορφή | SourceFormat από διαδρομή αρχείου | SourceFormat από ροή χωρίς όνομα |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| ODP, OTP | `Odp`, `Otp` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Το περιεχόμενο PPS/POT αναγνωρίζεται ως `Ppt` για ροές χωρίς όνομα. Ο πίνακας περιγράφει την ταυτοποίηση μορφής, όχι τη διατήρηση κάθε χαρακτηριστικού παρουσίασης κατά τη μετατροπή.

## **Συχνές Ερωτήσεις**

**Αλλάζει η αποθήκευση σε ODP τη πηγή μορφής μιας παρουσίασης που φορτώθηκε από PPTX;**

Όχι. Η υπάρχουσα εμφάνιση εξακολουθεί να αναφέρει `Pptx`. Μια εμφάνιση που φορτώνεται από το αποθηκευμένο αρχείο ODP αναφέρει `Odp`.

**Μπορεί μια ροή πάντα να διακρίνει κληρονομική παρουσίαση, διαφάνεια και πρότυπο;**

Όχι. Τα PPT, PPS και POT μοιράζονται την ίδια δυαδική μορφή. Διατηρήστε το όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά όταν απαιτείται αυτή η διάκριση.

**Ποιο API πρέπει να χρησιμοποιήσω εάν η παρουσίαση έχει ήδη φορτωθεί;**

Διαβάστε το [Presentation::getSourceFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSourceFormat). Χρησιμοποιήστε το [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/#getPresentationInfo) για επιθεώρηση πριν από τη φόρτωση.