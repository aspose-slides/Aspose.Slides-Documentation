---
title: Μετατροπή Παρουσιάσεων PowerPoint σε PDF με Σημειώσεις σε Java
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
- σημειώσεις ομιλητή
- PDF με σημειώσεις
- Java
- Aspose.Slides
description: "Μετατροπή μορφών PPT και PPTX σε PDF με σημειώσεις χρησιμοποιώντας το Aspose.Slides για Java. Διατήρηση διατάξεων και σημειώσεων ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παραδείγματα κώδικα για να σας βοηθήσει να ολοκληρώσετε αυτήν την εργασία αποδοτικά. Στο τέλος του άρθρου, θα είστε σε θέση να:

- Εφαρμόσετε τη διαδικασία μετατροπής για να μετατρέψετε τις διαφάνειες PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις ομιλητή.
- Προσαρμόσετε το PDF εξόδου ώστε να εξασφαλίζεται ότι οι σημειώσεις ομιλητή περιλαμβάνονται και μορφοποιούνται σύμφωνα με τις απαιτήσεις σας.

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας σημειώσεων πριν από την εξαγωγή, δείτε [Μέγεθος Σελίδας Σημειώσεων](/slides/el/java/notes-size/).

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `save` στην κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψετε μια παρουσίαση PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, ρυθμίζετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις ομιλητή, και στη συνέχεια αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε μια δείγματική παρουσίαση σε PDF σε προβολή Σημειώσεων Διαφάνειας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Διαμόρφωση επιλογών PDF για την απόδοση σημειώσεων ομιλητή.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Απόδοση σημειώσεων ομιλητή κάτω από τη διαφάνεια.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Αποθήκευση της παρουσίασης σε PDF με σημειώσεις ομιλητή.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Μπορεί να θέλετε να δοκιμάσετε το Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/el/conversion).
{{% /alert %}}