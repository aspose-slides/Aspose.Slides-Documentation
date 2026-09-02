---
title: Διαχείριση Ετικετών Ευαισθησίας σε Παρουσιάσεις PowerPoint σε PHP
linktitle: Ετικέτες Ευαισθησίας
type: docs
weight: 50
url: /el/php-java/sensitivity-labels/
keywords:
- ετικέτα ευαισθησίας
- Microsoft Purview
- Microsoft Information Protection
- μεταδεδομένα MIP
- ένδειξη περιεχομένου
- προστασία πληροφοριών
- διακυβέρνηση εγγράφων
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- PHP
- Aspose.Slides
description: "Ανάγνωση, προσθήκη, ενημέρωση, αφαίρεση και μεταφορά ετικετών ευαισθησίας Microsoft Purview σε παρουσιάσεις PowerPoint PPTX σε PHP."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας του Microsoft Purview βοηθούν τις οργανισμούς να ταξινομούν και να διαχειρίζονται έγγραφα. Κατά την αυτοματοποιημένη επεξεργασία παρουσιάσεων, μια εφαρμογή μπορεί να χρειάζεται να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που επιλέχθηκε από πολιτική, να ενημερώσει την κατάστασή της ή να μεταφέρει μεταδεδομένα ετικέτας που γράφτηκαν από παλαιότερη ροή εργασίας Microsoft Information Protection (MIP).

Το Aspose.Slides for PHP via Java εκθέτει σύγχρονα μεταδεδομένα ετικέτας ευαισθησίας μέσω του [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSensitivityLabels). Αυτή η μέθοδος επιστρέφει μια [SensitivityLabelCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcollection/) που μπορεί να επιθεωρηθεί και να τροποποιηθεί πριν η παρουσίαση αποθηκευτεί ως PPTX.

{{% alert color="primary" title="Note" %}}
Οι ταυτοποιητές ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη ρύθμιση του Microsoft Purview. Επαληθεύστε τη διαθεσιμότητα ετικετών και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταφέρετε μεταδεδομένα. Οι τιμές του [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) περιγράφουν τις ενδείξεις περιεχομένου που σχετίζονται με μια ετικέτα· από μόνες τους δεν προσθέτουν ορατό κείμενο ή σχήματα στις διαφάνειες.
{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [SensitivityLabel](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/) περιέχει τα παρακάτω μεταδεδομένα:

| Μέθοδοι | Σκοπός |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#getId) και [SensitivityLabel::setId](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#setId) | Λήψη ή ορισμός του ταυτοποιητή ετικέτας ευαισθησίας στην πολιτική Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#getSiteId) και [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Λήψη ή ορισμός του τοπίου (site) που συνδέεται με την πολιτική ετικέτας. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#isEnabled) και [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Λήψη ή ορισμός του αν η ετικέτα είναι ενεργοποιημένη. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#isRemoved) και [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Λήψη ή ορισμός του αν η ετικέτα έχει αφαιρεθεί. Ορίστε την τιμή σε `true` όταν πρέπει να διατηρηθεί η κατάσταση αφαίρεσης στα μεταδεδομένα. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) και [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Λήψη ή ορισμός του αν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Λήψη των τύπων ενδείξεων περιεχομένου που σχετίζονται με την ετικέτα. |

Η κλάση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelassignmenttype/) ορίζει πώς ανατέθηκε μια ετικέτα:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια ετικέτα που εφαρμόστηκε με απόφαση χρήστη, συμπεριλαμβανομένων των χειροκίνητων, προτεινόμενων και υποχρεωτικών ετικετών.

Η κλάση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcontenttype/) ορίζει την ένδειξη που συνδέεται με μια ετικέτα:

| Τιμή | Σημασία |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε από προεπιλογή ή αυτόματα. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcontenttype/) | Η ένδειξη κεφαλίδας (header) συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcontenttype/) | Η ένδειξη υποσέλιδου (footer) συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcontenttype/) | Η ένδειξη υδατογραφήματος (watermark) συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης συνδέεται με την ετικέτα. |

Πολλοί τύποι ενδείξεων μπορούν να συνδεθούν με μία ετικέτα.

## **Ανίχνευση Υπάρχουσας Ετικέτας Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από το [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSensitivityLabels) και κάντε την επανάληψη. Το παρακάτω παράδειγμα εμφανίζει κάθε ιδιότητα και την ένδειξη περιεχομένου που αποθηκεύεται για κάθε ετικέτα:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Προσθήκη Ετικέτας Ευαισθησίας με Ένδειξη Περιεχομένου**

Χρησιμοποιήστε το [SensitivityLabelCollection::add](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcollection/#add) με τον ταυτοποιητή ετικέτας, τον ταυτοποιητή τοπίου, την κατάσταση ενεργοποίησης και τη μέθοδο ανάθεσης. Αφού η μέθοδος επιστρέψει τη νέα [SensitivityLabel](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/), προσθέστε τις απαιτούμενες τιμές ενδείξεων μέσω της λίστας που επιστρέφεται από το [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που συνδέεται με ενδείξεις υποσέλιδου και υδατογραφήματος και, στη συνέχεια, αποθηκεύει το αποτέλεσμα ως PPTX:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ενημέρωση Ετικέτας Ευαισθησίας**

Οι τιμές της [SensitivityLabel](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/) είναι αναγνώσιμες/εγγράψιμες, εκτός από τη λίστα που επιστρέφεται από το [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) η οποία τροποποιείται μέσω των λειτουργιών λίστας. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε τον ταυτοποιητή της, τον ταυτοποιητή τοπίου, την κατάσταση ενεργοποίησης, τη μέθοδο ανάθεσης, την κατάσταση αφαίρεσης και τους τύπους ενδείξεων περιεχομένου. Σώστε την παρουσίαση για να διατηρηθούν οι αλλαγές.

Το παρακάτω παράδειγμα ενημερώνει την κατάσταση ενεργοποίησης και τη μέθοδο ανάθεσης της πρώτης ετικέτας:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Σήμανση Ετικέτας Ευαισθησίας ως Αφαιρεθείσα**

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και καλέστε το [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#setRemoved) με τιμή `true`. Αυτό διατηρεί την καταχώριση της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσης. Αν θέλετε να διαγράψετε μια καταχώριση από τη σύγχρονη συλλογή, χρησιμοποιήστε το [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); χρησιμοποιήστε το [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcollection/#clear) για διαγραφή όλων των καταχωρήσεων.

Το παρακάτω παράδειγμα σημαδεύει μια συγκεκριμένη ετικέτα ως αφαιρεθείσα και αποθηκεύει την ενημερωμένη παρουσίαση:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ανάγνωση και Μεταφορά Παλαιών Ετικετών MIP Ευαισθησίας**

Οι παλαιότερες ροές εργασίας βασισμένες σε MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικέτας ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί για τη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getSensitivityLabels). Η μέθοδος αναλύει τις παλαιές προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα Java αντικειμένων [SensitivityLabel](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/).

Για να μεταφέρετε τα μεταδεδομένα, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [SensitivityLabelCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcollection/) μέσω του [SensitivityLabelCollection::add](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcollection/#add). Επειδή η προσθήκη διπλότυπου ταυτοποιητή ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω επικύρωση για να επιβεβαιώσετε ότι κάθε παλαιά ετικέτα εξακολουθεί να υπάρχει στην τρέχουσα πολιτική Purview.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η μεταφορά αντιγράφει τα αναλυθέντα αντικείμενα ετικέτας στη σύγχρονη συλλογή. Δεν απαιτεί εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, οπότε τα μη σχετιζόμενα μεταδεδομένα του εγγράφου παραμένουν ανέπαφα. Χρησιμοποιήστε το [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικέτας σε αρχείο PPTX.

## **FAQ**

**Δημιουργεί η προσθήκη τύπου ένδειξης περιεχομένου ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω της λίστας που επιστρέφεται από το [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) περιγράφουν τις ενδείξεις που συνδέονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο στις διαφάνειες ξεχωριστά εάν η ροή εργασίας σας πρέπει να τα αποδώσει.

**Ποια είναι η διαφορά μεταξύ σήμανσης μιας ετικέτας ως αφαιρεθείσα και διαγραφής της από τη συλλογή;**

Η κλήση του [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#setRemoved) με `true` διατηρεί την καταχώριση της ετικέτας και καταγράφει την κατάσταση αφαίρεσης. Η κλήση του [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) διαγράφει την καταχώριση από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο παλαιά μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι παλαιές ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω του [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSensitivityLabels). Χρησιμοποιήστε το [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/el/php-java/aspose.slides/documentproperties/#getSensitivityLabels) για να διαβάσετε τα παλαιά μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με τον ίδιο ταυτοποιητή προστίθεται περισσότερες από μία φορές;**

Το [SensitivityLabelCollection::add](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabelcollection/#add) προκαλεί εξαίρεση όταν η συλλογή περιέχει ήδη ετικέτα με τον ίδιο ταυτοποιητή. Ελέγξτε τις υπάρχουσες τιμές που επιστρέφονται από το [SensitivityLabel::getId](https://reference.aspose.com/slides/el/php-java/aspose.slides/sensitivitylabel/#getId) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διατήρηση ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) με το [SaveFormat::Pptx](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/), όπως φαίνεται στα παραδείγματα παραπάνω.