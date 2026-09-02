---
title: Μετατροπή παρουσιάσεων PowerPoint σε XML σε PHP
linktitle: PowerPoint σε XML
type: docs
weight: 145
url: /el/php-java/convert-powerpoint-to-xml/
keywords:
- μετατροπή PowerPoint σε XML
- μετατροπή παρουσίασης σε XML
- PPT σε XML
- PPTX σε XML
- ODP σε XML
- Παρουσίαση PowerPoint XML
- SaveFormat.Xml
- αποθήκευση παρουσίασης ως XML
- εξαγωγή παρουσίασης σε XML
- ροή XML
- PHP
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML με PHP χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides για PHP μέσω Java μπορεί να μετατρέπει παρουσιάσεις PowerPoint σε μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια κειμενική αναπαράσταση για την επιθεώρηση της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων των παραγόμενων εγγράφων, τη σύγκριση της εξόδου σε αυτοματοποιημένα τεστ ή την ενσωμάτωση σε ροή εργασίας που καταναλώνει XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) με την τιμή `Xml` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/). Μπορείτε να εγγράψετε το αποτέλεσμα απευθείας σε αρχείο ή σε ροή.

{{% alert color="info" title="Σημείωση" %}}

`SaveFormat::Xml` δημιουργεί ένα PowerPoint XML Presentation. Δεν εξάγει τα επιμέρους μέρη του Office Open XML που είναι αποθηκευμένα μέσα σε ένα πακέτο PPTX. Εάν χρειάζεστε τα ακριβή μέρη του πακέτου PPTX, όπως `ppt/presentation.xml` ή τα μεμονωμένα αρχεία XML των διαφανειών, επιθεωρήστε το ίδιο το πακέτο PPTX.

{{% /alert %}}

## **Μετατροπή παρουσίασης σε αρχείο XML**

Φορτώστε μια πηγή παρουσίασης με την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/), και στη συνέχεια περάστε τη διαδρομή εξόδου και το `SaveFormat::Xml` στη [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Η πηγή μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση PPTX σε αρχείο XML:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Εγγραφή της εξόδου XML σε ροή**

Χρησιμοποιήστε την υπερφόρτωση ροής της [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) όταν το XML πρέπει να παραμείνει στη μνήμη ή να περάσει σε άλλο στοιχείο, όπως μια υπηρεσία web, πάροχο αποθήκευσης ή σωλήνα επεξεργασίας XML. Το παρακάτω παράδειγμα γράφει το αποτέλεσμα σε ένα [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) και λαμβάνει το δημιουργημένο XML ως πίνακα byte:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Περράστε $xmlBytes στο επόμενο στοιχείο της ροής εργασίας.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Ένα `ByteArrayOutputStream` αποθηκεύει όλα τα παραγόμενα δεδομένα στη μνήμη, οπότε δεν απαιτείται επαναφορά της θέσης πριν από την κλήση του `toByteArray`.

## **Σύγκριση XML με μορφές παρουσίασης και εξαγωγής**

Επιλέξτε τη μορφή εξόδου ανάλογα με το πώς θα χρησιμοποιηθεί το αποτέλεσμα:

| Μορφή | Έξοδος | Τυπική χρήση |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Ένα PowerPoint XML Presentation | Επιθεώρηση δομής, αντιμετώπιση προβλημάτων, σύγκριση παραγόμενης εξόδου και ενσωμάτωση βάσει XML |
| PPT (`.ppt`) | Ένα κληρονομημένο δυαδικό αρχείο παρουσίασης | Συμβατότητα με παλαιότερες ροές εργασίας PowerPoint |
| PPTX (`.pptx`) | Ένα πακέτο Office Open XML που περιέχει πολλαπλά μέρη | Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων |
| PDF or TIFF | Σελίδες σταθερής διάταξης ή εικόνα πολλαπλών σελίδων | Προβολή, εκτύπωση και αρχειοθέτηση |
| PNG, JPEG, or SVG | Μια επεξεργασμένη αναπαράσταση μιας μεμονωμένης διαφάνειας | Μικρογραφίες, προεπισκοπήσεις και εικόνες περιουσιακών στοιχείων |
| HTML or HTML5 | Έξοδος παρουσίασης προσανατολισμένη στο web | Προβολή σε πρόγραμμα περιήγησης και δημοσίευση στο web |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για επιθεώρηση και ροές εργασίας προσανατολισμένες σε δεδομένα. Σε αντίθεση με τα PDF, TIFF, HTML και μορφές εικόνων διαφανειών, αντιπροσωπεύει τα δεδομένα παρουσίασης αντί να αποδίδει τις διαφάνειες ως σελίδες ή οπτικά στοιχεία. Ο πίνακας [supported file formats](/slides/el/php-java/supported-file-formats/) αναφέρει το PowerPoint XML Presentation ως μορφή μόνο αποθήκευσης, επομένως μην τη χρησιμοποιείτε όταν μια ροή εργασίας πρέπει να φορτώσει το εξαγόμενο αρχείο ξανά στο Aspose.Slides για συνέχιση της επεξεργασίας.

## **Συχνές ερωτήσεις**

**Είναι το `SaveFormat::Xml` το ίδιο με την αποθήκευση αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά μέρη Office Open XML, ενώ το `SaveFormat::Xml` δημιουργεί ένα αρχείο PowerPoint XML Presentation.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναι. Περάστε μια εγγράψιμη ροή στη [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/). Για παράδειγμα, χρησιμοποιήστε ένα [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαχθέν αρχείο XML;**

Όχι. Το PowerPoint XML Presentation υποστηρίζεται προς το παρόν μόνο για αποθήκευση και όχι για φόρτωση. Χρησιμοποιήστε PPTX ή άλλη υποστηριζόμενη μορφή παρουσίασης όταν απαιτείται επαναφόρτωση για επεξεργασία.

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένο σε σελίδες ή PNG, JPEG και SVG για εικόνες μεμονωμένων διαφανειών.