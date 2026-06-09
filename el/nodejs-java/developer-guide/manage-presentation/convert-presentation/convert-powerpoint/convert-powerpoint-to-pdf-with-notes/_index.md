---
title: Μετατροπή Παρουσιάσεων PowerPoint σε PDF με Σημειώσεις σε JavaScript
linktitle: PowerPoint σε PDF με Σημειώσεις
type: docs
weight: 50
url: /el/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατροπή μορφών PPT και PPTX σε PDF με σημειώσεις σε JavaScript χρησιμοποιώντας το Aspose.Slides για Node.js. Διατήρηση διατάξεων και σημειώσεων ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα προσφέρει παραδείγματα κώδικα για να σας βοηθήσει να ολοκληρώσετε αυτήν τη δουλειά αποδοτικά. Στο τέλος του άρθρου, θα μπορείτε να:

- Εφαρμόσετε τη διαδικασία μετατροπής για να μετατρέψετε τις διαφάνειες PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις ομιλητή.
- Προσαρμόσετε το παραγόμενο PDF ώστε να εξασφαλιστεί η συμπερίληψη και η μορφοποίηση των σημειώσεων ομιλητή σύμφωνα με τις απαιτήσεις σας.

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψει μια παρουσίαση PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, ρυθμίζετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις ομιλητή, και, στη συνέχεια, αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε μια παράδειγμα παρουσίασης σε PDF σε προβολή Σημειώσεων Διαφάνειας.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// Διαμορφώστε τις επιλογές PDF για απόδοση σημειώσεων ομιλητή.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Απόδοση σημειώσεων ομιλητή κάτω από τη διαφάνεια.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Αποθήκευση της παρουσίασης σε PDF με σημειώσεις ομιλητή.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Ίσως να θέλετε να εξετάσετε το Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/el/conversion). 
{{% /alert %}}