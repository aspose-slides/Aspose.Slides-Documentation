---
title: Μετατροπή παρουσιάσεων PowerPoint σε PDF με Σημειώσεις σε Java
linktitle: PowerPoint σε PDF με Σημειώσεις
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
- σημειώσεις παρουσιαστή
- PDF με σημειώσεις
- Java
- Aspose.Slides
description: "Μετατροπή μορφών PPT και PPTX σε PDF με σημειώσεις χρησιμοποιώντας το Aspose.Slides για Java. Διατήρηση διατάξεων και σημειώσεων παρουσιαστή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέψετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις του παρουσιαστή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παραδείγματα κώδικα για να σας βοηθήσει να ολοκληρώσετε αυτήν την εργασία αποδοτικά. Στο τέλος του άρθρου, θα μπορείτε να:

- Υλοποιήσετε τη διαδικασία μετατροπής ώστε να μετατρέπετε διαφάνειες PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις του παρουσιαστή.
- Προσαρμόσετε το παραγόμενο PDF ώστε οι σημειώσεις του παρουσιαστή να συμπεριλαμβάνονται και να μορφοποιούνται σύμφωνα με τις απαιτήσεις σας.

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `save` στην κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για τη μετατροπή μιας παρουσίασης PPT ή PPTX σε PDF με σημειώσεις παρουσιαστή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, διαμορφώνετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις του παρουσιαστή, και στη συνέχεια αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε μια δείγμα παρουσίασης σε PDF σε εμφάνιση Σημειώσεων Διαφάνειας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Διαμορφώστε τις επιλογές PDF για απόδοση σημειώσεων παρουσιαστή.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Αποδώστε τις σημειώσεις παρουσιαστή κάτω από τη διαφάνεια.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Αποθηκεύστε την παρουσίαση σε PDF με σημειώσεις παρουσιαστή.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
Μπορεί να θέλετε να δοκιμάσετε τον Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/el/conversion). 
{{% /alert %}}