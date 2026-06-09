---
title: Μετατροπή παρουσιάσεων PowerPoint σε PDF με σημειώσεις σε C++
linktitle: PowerPoint σε PDF με σημειώσεις
type: docs
weight: 50
url: /el/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "Μετατροπή μορφών PPT και PPTX σε PDF με σημειώσεις χρησιμοποιώντας το Aspose.Slides για C++. Διατήρηση διατάξεων και σημειώσεων ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παράδειγμα κώδικα για να σας βοηθήσει να ολοκληρώσετε αυτήν την εργασία αποδοτικά. Στο τέλος του άρθρου, θα μπορείτε να:

- Εφαρμόσετε τη διαδικασία μετατροπής για να μετατρέψετε διαφάνειες PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις ομιλητή.
- Προσαρμόσετε το παραγόμενο PDF ώστε να διασφαλίσετε ότι οι σημειώσεις ομιλητή συμπεριλαμβάνονται και μορφοποιούνται σύμφωνα με τις απαιτήσεις σας.

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `Save` στην κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψετε μια παρουσίαση PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, διαμορφώνετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις ομιλητή, και στη συνέχεια αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε μια δείγμα παρουσίασης σε PDF στην προβολή Σημειώσεων Διαφάνειας.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Διαμορφώστε τις επιλογές PDF για την απόδοση των σημειώσεων ομιλητή.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Αποδώστε τις σημειώσεις ομιλητή κάτω από τη διαφάνεια.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Αποθηκεύστε την παρουσίαση σε PDF με σημειώσεις ομιλητή.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 
Μπορεί να θέλετε να ελέγξετε το Aspose [Online Μετατροπέας PowerPoint σε PDF](https://products.aspose.app/slides/el/conversion). 
{{% /alert %}}