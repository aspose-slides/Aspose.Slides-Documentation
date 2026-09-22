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
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP για πιο γρήγορη ανάλυση και πιο έξυπνες αξιολογήσεις περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να εντοπίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες μοντέλο αντικειμένων παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε ένα απόθεμα ή να εξετάσετε ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Αυτό το άρθρο δείχνει ελαφριά επιθεώρηση μέσω του [PresentationFactory](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) και του [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω του [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/).

## **Έλεγχος μορφής παρουσίασης**

Αν έχετε ήδη μια φορτωμένη παρουσίαση, δείτε το [Determine the Original Presentation Format](/slides/el/php-java/detect-presentation-source-format/) για ανίχνευση μετά τη φόρτωση και τους περιορισμούς των παλαιών ροών PPT, PPS και POT.

Χρησιμοποιήστε το [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) για να εξετάσετε ένα αρχείο χωρίς να δημιουργήσετε μια παρουσία του [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Η μέθοδος [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#getLoadFormat) αναφέρει τη ανιχνευμένη μορφή, όπως PPTX, PPT ή ODP.

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

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, μπορεί να χρειαστείτε ένα συμπαγές απόθεμα για επαλήθευση, ευρετηρίαση ή σύστημα διαχείρισης εγγράφων. Σε αυτήν την περίπτωση, χρησιμοποιήστε το [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) για να αποκτήσετε ένα αντικείμενο [PresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/), και έπειτα καλέστε το [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί μια παρουσία του [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) ούτε απαιτεί να διασχίσετε το πλήρες μοντέλο αντικειμένων παρουσίασης.

Οι επεκταμένες ιδιότητες που εκτίθενται από το [DocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/) παρέχουν τις ακόλουθες τιμές αποθέματος:

| Μέθοδος | Τιμή αποθέματος |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getSlides) | Συνολικός αριθμός διαφανειών. |
| [getHiddenSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Αριθμός κρυφών διαφανειών. |
| [getNotes](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getNotes) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [getParagraphs](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getParagraphs) | Συνολικός αριθμός παραγράφων, όταν είναι διαθέσιμος. |
| [getWords](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getWords) | Συνολικός αριθμός λέξεων. |
| [getMultimediaClips](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργήσει ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και εκτυπώνει ένα συμπαγές απόθεμα. Συνδυάζει επίσης το [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getHeadingPairs) με το [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getTitlesOfParts) ώστε να εμφανίσει ομάδες περιεχομένου όπως γραμματοσειρές, θέματα και τίτλους διαφανειών.

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

Κάθε [HeadingPair](https://reference.aspose.com/slides/el/php-java/aspose.slides/headingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των στοιχείων σε αυτήν την ομάδα. Η μέθοδος [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getTitlesOfParts) επιστρέφει έναν επίπεδο, ταξινομημένο πίνακα, ώστε να χρησιμοποιήσετε τον αριθμό των διαδοχικών τίτλων που καθορίζονται από κάθε heading pair.

### **Αποθηκευμένα μεταδεδομένα και περιορισμοί μορφής**

Οι ιδιότητες αποθέματος που επιστρέφει η [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties) αντανακλούν τα μεταδεδομένα που είναι διαθέσιμα στο αρχικό έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένων παρουσίασης για να επαναυπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες αντιπροσωπεύονται από προεπιλεγμένες τιμές, και οι αποθηκευμένες τιμές μπορεί να είναι ξεπερασμένες αν η εφαρμογή που αποθήκευσε τελευταία το αρχείο δεν ενημέρωσε τις ιδιότητες του εγγράφου.

**PPTX:** Η μορφή παρέχει επεκταμένες ιδιότητες εγγράφου για μετρήσεις διαφάνειας, σημείωσης, κρυφής διαφάνειας, παραγράφου, λέξης και πολυμέσων, καθώς και για heading pairs και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από τις ιδιότητες που έγραψε ο δημιουργός του εγγράφου.

**PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει τις αντίστοιχες ιδιότητες περίληψης εγγράφου. Αν μια ιδιότητα λείπει ή δεν ενημερώθηκε από τον δημιουργό του εγγράφου, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίζει από τις διαφάνειες.

**ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικά στατιστικά εγγράφου, όπως αριθμός σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε ειδική για PowerPoint επεκταμένη ιδιότητα. Τα μεταδεδομένα κρυφών διαφανειών, σημειώσεων, πολυμέσων, heading-pair και τίτλων τμημάτων μπορεί να μην είναι διαθέσιμα, και οι ιδιότητες αποθέματος μπορεί να επιστρέφουν προεπιλεγμένες τιμές. Μην θεωρείτε μια τιμή μηδέν ή έναν κενό πίνακα ως αποδεικτικό ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για αποθέματα και προφορικούς ελέγχους. Φορτώστε την παρουσίαση και εξετάστε το ζωντανό μοντέλο αντικειμένων όταν το αποτέλεσμα πρέπει να αντανακλά αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Οι ιδιότητες που επιστρέφει η [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties) μπορούν επίσης να τροποποιηθούν χωρίς τη δημιουργία μιας παρουσίας [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Εφαρμόστε τις αλλαγές με τη [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), και στη συνέχεια γράψτε την δεσμευμένη παρουσίαση με τη [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Η ακόλουθη εικόνα δείχνει τις αρχικές ιδιότητες του εγγράφου.

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

Η ακόλουθη εικόνα δείχνει τις τροποποιημένες ιδιότητες του εγγράφου της παρουσίασης PowerPoint.

![Τροποποιημένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Σχετικοί σύνδεσμοι**

Για σχετικούς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Προστασία παρουσίασης με κωδικό](/slides/el/php-java/password-protected-presentation/)
- [Προστασία παρουσίασης από εγγραφή](/slides/el/php-java/write-protected-presentation/)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation::getFontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getFontsManager). Καλέστε το [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) για να λάβετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager::getFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getFonts) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε γραμματοσειρές που απαιτούνται για την απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getHiddenSlides) μέσω του [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationfactory/) και του [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Αυτό είναι κατάλληλο για ελαφρύ απόθεμα. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι ξεπερασμένα, ή χρειάζεται να επαληθεύσετε τις ζωντανές τιμές, επαναλάβετε μέσω του [Presentation::getSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlides) και ελέγξτε τη μέθοδο [Slide::getHidden](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getHidden) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμό διαφάνειας, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και καλέστε το [Presentation::getSlideSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlideSize). Χρησιμοποιήστε τα [SlideSize::getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/#getSize) και [SlideSize::getOrientation](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidesize/#getOrientation) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με την αναμενόμενη προεπιλογή και διαστάσεις.

**Υπάρχει γρήγορος τρόπος να διαπιστώ αν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/) και καλέστε το [ChartData::getDataSourceType](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/#getDataSourceType). Για εξωτερικό βιβλίο εργασίας, καλέστε το [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Ο τύπος πηγής δεδομένων και η διαδρομή αναγνωρίζουν μια εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω τις 'βαριές' διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Δεν υπάρχει μια μοναδική ιδιότητα πολυπλοκότητας. Διασχίστε το [Presentation::getSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlides) και τη συλλογή [BaseSlide::getShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getShapes) κάθε διαφάνειας. Χρησιμοποιήστε τον αριθμό των σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων γραφικών ή πολυμέσων ως σήματα φιλτραρίσματος, και μετρήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο στερέωμα απόδοσης.