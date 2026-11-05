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
description: "Μετατροπή μορφών PPT και PPTX σε PDF με σημειώσεις χρησιμοποιώντας Aspose.Slides για PHP μέσω Java. Διατήρηση διατάξεων και σημειώσεων ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παραδείγματα κώδικα για να ολοκληρώσετε αυτήν την εργασία αποδοτικά. Στο τέλος του άρθρου, θα μπορείτε να:

- Εφαρμόσετε τη διαδικασία μετατροπής για να μετατρέψετε τις διαφάνειες PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις του ομιλητή.
- Προσαρμόσετε το εξαγόμενο PDF ώστε να περιλαμβάνει και να μορφοποιεί τις σημειώσεις του ομιλητή σύμφωνα με τις απαιτήσεις σας.

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας σημειώσεων πριν την εξαγωγή, δείτε [Μέγεθος Σελίδας Σημειώσεων](/slides/el/php-java/notes-size/).

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `save` στην κλάση [Παρουσίαση](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψει μια παρουσίαση PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, ρυθμίζετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις ομιλητή, και στη συνέχεια αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε μια δείγμα παρουσίαση σε PDF σε προβολή Σημειώσεων Διαφάνειας.

```php
$presentation = new Presentation("sample.pptx");

// Διαμορφώστε τις επιλογές PDF για την απόδοση των σημειώσεων ομιλητή.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Απόδοση σημειώσεων ομιλητή κάτω από τη διαφάνεια.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Αποθηκεύστε την παρουσίαση σε PDF με σημειώσεις ομιλητή.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Σημείωση" %}}
Ίσως θέλετε να δείτε τον Aspose [Ηλεκτρονικός Μετατροπέας PowerPoint σε PDF](https://products.aspose.app/slides/el/conversion).
{{% /alert %}}