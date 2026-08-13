---
title: Μετατροπή παρουσιάσεων PowerPoint σε PDF με σημειώσεις σε Android
linktitle: PowerPoint σε PDF με Σημειώσεις
type: docs
weight: 50
url: /el/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Μετατροπή μορφών PPT και PPTX σε PDF με σημειώσεις χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Διατήρηση διατάξεων και σημειώσεων ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παραδείγματα κώδικα για να ολοκληρώσετε αυτήν την εργασία αποτελεσματικά. Στο τέλος του άρθρου, θα μπορείτε να:

- Υλοποιήσετε τη διαδικασία μετατροπής για τη μετατροπή των διαφανειών PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις του ομιλητή.
- Προσαρμόσετε το παραγόμενο PDF ώστε να εξασφαλίσετε ότι οι σημειώσεις του ομιλητή περιλαμβάνονται και μορφοποιούνται σύμφωνα με τις απαιτήσεις σας.

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `save` στην κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για τη μετατροπή μιας παρουσίασης PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, διαμορφώνετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις του ομιλητή, και στη συνέχεια αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε ένα παράδειγμα παρουσίασης σε PDF σε προβολή Σημειώσεων Διαφάνειας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Διαμορφώστε τις επιλογές PDF για απόδοση σημειώσεων ομιλητή.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Απόδοση σημειώσεων ομιλητή κάτω από τη διαφάνεια.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Αποθηκεύστε την παρουσίαση σε PDF με σημειώσεις ομιλητή.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
Μπορεί να θέλετε να δείτε τον Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/el/conversion). 
{{% /alert %}}