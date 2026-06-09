---
title: Μετατροπή Παρουσιάσεων PowerPoint σε PDF με Σημειώσεις σε .NET
linktitle: PowerPoint σε PDF με Σημειώσεις
type: docs
weight: 50
url: /el/net/convert-powerpoint-to-pdf-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Μετατροπή μορφών PPT και PPTX σε PDF με σημειώσεις χρησιμοποιώντας το Aspose.Slides για .NET. Διατήρηση διατάξεων και σημειώσεων ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέψετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παραδείγματα κώδικα για να σας βοηθήσει να ολοκληρώσετε αυτήν την εργασία αποτελεσματικά. Στο τέλος του άρθρου, θα μπορείτε να:

- Υλοποιήσετε τη διαδικασία μετατροπής για να μετατρέψετε τις διαφάνειες του PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις ομιλητή.  
- Προσαρμόσετε το PDF εξόδου ώστε να εξασφαλίσετε ότι οι σημειώσεις ομιλητή περιλαμβάνονται και μορφοποιούνται σύμφωνα με τις απαιτήσεις σας.

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `Save` στην κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψετε μια παρουσίαση PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, διαμορφώνετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις ομιλητή, και στη συνέχεια αποθηκεύετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε μια δείγμα παρουσίαση σε PDF σε προβολή Σημειώσεων Διαφάνειας.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Διαμορφώστε τις επιλογές PDF για απόδοση σημειώσεων ομιλητή.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Απόδοση σημειώσεων ομιλητή κάτω από τη διαφάνεια.
        }
    };

    // Αποθηκεύστε την παρουσίαση σε PDF με σημειώσεις ομιλητή.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
Ενδέχεται να θέλετε να ελέγξετε το Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/el/conversion). 
{{% /alert %}}