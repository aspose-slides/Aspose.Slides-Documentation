---
title: Μετατροπές Παρουσιάσεων σε PDF με Σημειώσεις σε Python
linktitle: Παρουσίαση σε PDF με Σημειώσεις
type: docs
weight: 50
url: /el/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- μετατροπή PowerPoint
- μετατροπή OpenDocument
- μετατροπή παρουσίασης
- μετατροπή PPT
- μετατροπή PPTX
- μετατροπή ODP
- PowerPoint σε PDF
- OpenDocument σε PDF
- παρουσίαση σε PDF
- PPT σε PDF
- PPTX σε PDF
- ODP σε PDF
- σημειώσεις ομιλητή
- PDF με σημειώσεις
- Python
- Aspose.Slides
description: "Μετατροπή μορφών PPT, PPTX και ODP σε PDF με σημειώσεις χρησιμοποιώντας το Aspose.Slides για Python. Διατήρηση διατάξεων και σημειώσεων ομιλητή για επαγγελματικές παρουσιάσεις."
---
## **Επισκόπηση**

Σε αυτό το άρθρο, θα μάθετε πώς να μετατρέπετε παρουσιάσεις PowerPoint σε μορφή PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides. Αυτός ο οδηγός θα καλύψει τα απαραίτητα βήματα και θα παρέχει παραδείγματα κώδικα για να ολοκληρώσετε αυτήν την εργασία αποτελεσματικά. Στο τέλος αυτού του άρθρου, θα μπορείτε να:

- Υλοποιήσετε τη διαδικασία μετατροπής για να μετατρέψετε τις διαφάνειες PowerPoint σε έγγραφα PDF διατηρώντας τις σημειώσεις ομιλητή.
- Προσαρμόσετε το PDF εξόδου ώστε να περιλαμβάνει και να μορφοποιεί τις σημειώσεις ομιλητή σύμφωνα με τις απαιτήσεις σας.

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας σημειώσεων πριν από την εξαγωγή, δείτε [Μέγεθος Σελίδας Σημειώσεων](/slides/el/python-net/notes-size/).

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Η μέθοδος `save` στην κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψετε μια παρουσίαση PPT ή PPTX σε PDF με σημειώσεις ομιλητή. Με το Aspose.Slides, απλώς φορτώνετε την παρουσίαση, ρυθμίζετε τις επιλογές διάταξης χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/notescommentslayoutingoptions/) για να συμπεριλάβετε τις σημειώσεις ομιλητή, και έπειτα σώζετε το αρχείο ως PDF. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να μετατρέψετε μια δείγμα παρουσίασης σε PDF σε προβολή Σημειώσεων Διαφάνειας.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Ρυθμίστε τις επιλογές PDF για την απόδοση των σημειώσεων ομιλητή.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Αποθηκεύστε την παρουσίαση σε PDF με τις σημειώσεις ομιλητή.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Ίσως θέλετε να δείτε το Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/el/conversion).
{{% /alert %}}