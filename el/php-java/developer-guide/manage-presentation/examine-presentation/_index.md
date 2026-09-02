---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε PHP
linktitle: Πληροφορίες Παρουσίασης
type: docs
weight: 30
url: /el/php-java/examine-presentation/
keywords:
- μορφή παρουσίασης
- ιδιότητες παρουσίασης
- ιδιότητες εγγράφου
- λήψη ιδιοτήτων
- ανάγνωση ιδιοτήτων
- αλλαγή ιδιοτήτων
- τροποποίηση ιδιοτήτων
- ενημέρωση ιδιοτήτων
- εξέταση PPTX
- εξέταση PPT
- εξέταση ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP για πιο γρήγορη ανάλυση και έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να εντοπίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς τη δημιουργία ενός πλήρους μοντέλου αντικειμένων παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε ένα απόθεμα ή να ελέγξετε ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Το άρθρο αυτό δείχνει ελαφριά επιθεώρηση μέσω [PresentationFactory](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) και [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/).

## **Έλεγχος μορφής παρουσίασης**

Χρησιμοποιήστε [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) για να επιθεωρήσετε ένα αρχείο χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Η μέθοδος [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#getLoadFormat) αναφέρει τη μορφή που εντοπίστηκε, όπως PPTX, PPT ή ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Δημιουργία ελαφρού αποθέματος παρουσίασης**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, μπορεί να χρειαστείτε ένα συμπαγές απόθεμα για επικύρωση, ευρετήριο ή σύστημα διαχείρισης εγγράφων. Σε αυτό το σενάριο, χρησιμοποιήστε [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) για να αποκτήσετε ένα αντικείμενο [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/) και, στη συνέχεια, καλέστε [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) ούτε απαιτεί την πλήρη διάσχιση του μοντέλου αντικειμένων παρουσίασης.

Οι εκτεταμένες ιδιότητες που εκτίθενται από το [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/) παρέχουν τις παρακάτω τιμές αποθέματος:

| Μέθοδος | Τιμή αποθέματος |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getSlides) | Συνολικός αριθμός διαφανειών. |
| [getHiddenSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Αριθμός κρυφών διαφανειών. |
| [getNotes](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getNotes) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [getParagraphs](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getParagraphs) | Συνολικός αριθμός παραγράφων, εάν είναι διαθέσιμο. |
| [getWords](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getWords) | Συνολικός αριθμός λέξεων. |
| [getMultimediaClips](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς τη δημιουργία αντικειμένου [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και εκτυπώνει ένα συμπαγές απόθεμα. Επιπλέον, συνδυάζει το [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getHeadingPairs) με το [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getTitlesOfParts) για να εμφανίσει ομάδες περιεχομένου όπως γραμματοσειρές, θέματα και τίτλους διαφανειών.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Κάθε [HeadingPair](https://reference.aspose.com/slides/el/php-java/aspose.slides/headingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των στοιχείων σε αυτήν την ομάδα. Το [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getTitlesOfParts) επιστρέφει έναν επίπεδο, διατεταγμένο πίνακα, οπότε καταναλώστε τον αριθμό των διαδοχικών τίτλων που καθορίζονται από κάθε ζεύγος επικεφαλίδας.

### **Αποθηκευμένα μεταδεδομένα και περιορισμοί μορφής**

Οι ιδιότητες αποθέματος που επιστρέφει το [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties) αντανακλούν τα μεταδεδομένα που διατίθενται στο πηγαίο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένων παρουσίασης για να επανυπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες αντιπροσωπεύονται από προεπιλεγμένες τιμές, και οι αποθηκευμένες τιμές μπορεί να είναι ξεπερασμένες εάν η εφαρμογή που αποθήκευσε το αρχείο τελευταία δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή παρέχει εκτεταμένες ιδιότητες εγγράφου για αριθμό διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζευγάρια επικεφαλίδων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από τις ιδιότητες που έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες περίληψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν ενημερώθηκε από τον δημιουργό, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίσει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικές στατιστικές εγγράφου, όπως αριθμό σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε εκτεταμένη ιδιότητα του PowerPoint. Ιδιότητες όπως κρυφές διαφάνειες, σημειώσεις-διαφάνειες, πολυμέσα, ζεύγη επικεφαλίδων και τίτλοι τμημάτων μπορεί να μην είναι διαθέσιμες, και οι ιδιότητες αποθέματος μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε το μηδενικό αποτέλεσμα ή έναν κενό πίνακα απόδειξη ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε τη μέθοδο ελαφριάς μεταδεδομένων για αποθέματα και προαπαιτούμενους ελέγχους. Φορτώστε την παρουσίαση και επιθεωρήστε το ενεργό της μοντέλο αντικειμένων όταν το αποτέλεσμα πρέπει να αντικατοπτρίζει αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Οι ιδιότητες που επιστρέφει το [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties) μπορούν επίσης να τροποποιηθούν χωρίς τη δημιουργία ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Εφαρμόστε τις αλλαγές με το [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) και, στη συνέχεια, γράψτε την δεσμευμένη παρουσίαση με το [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Η ακόλουθη εικόνα δείχνει τις αρχικές ιδιότητες εγγράφου.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το παρακάτω παράδειγμα αλλάζει τον τίτλο και την ημερομηνία τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

Η ακόλουθη εικόνα δείχνει τις τροποποιημένες ιδιότητες εγγράφου.

![Τροποποιημένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για σχετικούς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Password-Protect Presentations](/slides/el/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/el/php-java/write-protected-presentation/)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation::getFontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getFontsManager). Καλέστε το [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) για να λάβετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager::getFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getFonts) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα ώστε να βρείτε γραμματοσειρές που απαιτούνται για την απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getHiddenSlides) μέσω του [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) και του [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Αυτό είναι κατάλληλο για ελαφρύ απόθεμα. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι ξεπερασμένα· ή εάν χρειάζεται να επαληθεύσετε τις τιμές σε ζωντανή κατάσταση, διασχίστε το [Presentation::getSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlides) και ελέγξτε το [Slide::getHidden](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getHidden) για κάθε διαφάνεια.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος διαφάνειας και προσανατολισμός, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και καλέστε το [Presentation::getSlideSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlideSize). Χρησιμοποιήστε το [SlideSize::getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/#getType), το [SlideSize::getSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/#getSize) και το [SlideSize::getOrientation](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/#getOrientation) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με τις προβλεπόμενες προεπιλογές και διαστάσεις.

**Υπάρχει γρήγορος τρόπος να διαπιστωθεί αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/) και καλέστε το [ChartData::getDataSourceType](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/#getDataSourceType). Για εξωτερικό βιβλίο εργασίας, καλέστε το [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Ο τύπος πηγής δεδομένων και η διαδρομή υποδεικνύουν εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω «βαριές» διαφάνειες που μπορεί να καθυστερήσουν την απόδοση ή την εξαγωγή PDF;**

Δεν υπάρχει μία ενιαία ιδιότητα πολυπλοκότητας. Διασχίστε το [Presentation::getSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlides) και τη συλλογή [BaseSlide::getShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getShapes) κάθε διαφάνειας. Χρησιμοποιήστε τον αριθμό σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων ή πολυμέσων ως σήματα φιλτραρίσματος, και μετρήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο εμπόδιο απόδοσης.