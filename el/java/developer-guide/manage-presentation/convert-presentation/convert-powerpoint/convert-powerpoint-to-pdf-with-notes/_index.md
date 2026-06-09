---
title: Μετατροπή παρουσιάσεων PowerPoint σε PDF με σημειώσεις στην Java
linktitle: PowerPoint σε PDF με σημειώσεις
type: docs
weight: 50
url: /el/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: "Μετατροπή μορφών PPT και PPTX σε PDF με σημειώσεις χρησιμοποιώντας Aspose.Slides για Java. Διατηρήστε τις διατάξεις και τις σημειώσεις ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παραδείγματα κώδικα ώστε να ολοκληρώσετε αυτήν την εργασία αποδοτικά. Στο τέλος του άρθρου, θα μπορείτε να:

- Υλοποιήσετε τη διαδικασία μετατροπής για να μετατρέψετε τις διαφάνειες PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις ομιλητή.
- Προσαρμόσετε το παραγόμενο PDF ώστε να περιλαμβάνει και να μορφοποιεί τις σημειώσεις ομιλητή σύμφωνα με τις απαιτήσεις σας.

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `save` στην κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψετε μια παρουσίαση PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, διαμορφώνετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις ομιλητή, και στη συνέχεια αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε ένα δείγμα παρουσίασης σε PDF σε προβολή Σημειώσεων Διαφάνειας.

```java
Presentation presentation = new Presentation("sample.pptx");

// Διαμορφώστε τις επιλογές PDF για την απόδοση των σημειώσεων ομιλητή.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Απόδοση των σημειώσεων ομιλητή κάτω από τη διαφάνεια.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Αποθήκευση της παρουσίασης σε PDF με σημειώσεις ομιλητή.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 

Μπορείτε να θέλετε να ελέγξετε τον Aspose [Online PowerPoint σε PDF Converter](https://products.aspose.app/slides/el/conversion). 

{{% /alert %}}