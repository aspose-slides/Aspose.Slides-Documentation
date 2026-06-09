---
title: Μετατροπή παρουσιάσεων PowerPoint σε PDF με σημειώσεις σε PHP
linktitle: PowerPoint σε PDF με σημειώσεις
type: docs
weight: 50
url: /el/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PDF
- παρουσίαση σε PDF
- διαφάνεια σε PDF
- PPT σε PDF
- PPTX σε PDF
- αποθήκευση παρουσίασης ως PDF
- αποθήκευση PPT ως PDF
- αποθήκευση PPTX ως PDF
- εξαγωγή PPT σε PDF
- εξαγωγή PPTX σε PDF
- σημειώσεις ομιλητή
- PDF με σημειώσεις
- PHP
- Aspose.Slides
description: "Μετατρέψτε μορφές PPT και PPTX σε PDF με σημειώσεις χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Διατηρήστε τις διατάξεις και τις σημειώσεις ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέψετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παραδείγματα κώδικα για να ολοκληρώσετε αυτήν την εργασία αποδοτικά. Στο τέλος του άρθρου, θα μπορείτε να:

- Υλοποιήστε τη διαδικασία μετατροπής για να μετατρέψετε τις διαφάνειες PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις του ομιλητή.
- Προσαρμόστε το PDF εξόδου ώστε να περιλαμβάνει τις σημειώσεις του ομιλητή και να είναι μορφοποιημένες σύμφωνα με τις απαιτήσεις σας.

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `save` στην κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψει μια παρουσίαση PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, ρυθμίζετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/notescommentslayoutingoptions/) ώστε να περιλαμβάνονται οι σημειώσεις ομιλητή, και στη συνέχεια αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε μια δείγματική παρουσίαση σε PDF σε προβολή σημειώσεων διαφάνειας.

```php
$presentation = new Presentation("sample.pptx");

// Διαμόρφωση επιλογών PDF για την απόδοση σημειώσεων ομιλητή.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Απόδοση σημειώσεων ομιλητή κάτω από τη διαφάνεια.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Αποθήκευση της παρουσίασης σε PDF με σημειώσεις ομιλητή.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
Μπορεί να θέλετε να ελέγξετε το Aspose [Διαδικτυακός Μετατροπέας PowerPoint σε PDF](https://products.aspose.app/slides/el/conversion). 
{{% /alert %}}