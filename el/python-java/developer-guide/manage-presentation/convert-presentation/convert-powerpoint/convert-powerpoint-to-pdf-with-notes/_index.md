---
title: Μετατροπή Παρουσιάσεων PowerPoint σε PDF με Σημειώσεις σε Python
linktitle: PowerPoint σε PDF με Σημειώσεις
type: docs
weight: 50
url: /el/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PDF
- παρουσίαση σε PDF
- PPT σε PDF
- PPTX σε PDF
- αποθήκευση παρουσίασης ως PDF
- εξαγωγή PPT σε PDF
- εξαγωγή PPTX σε PDF
- σημειώσεις ομιλητή
- PDF με σημειώσεις
- Python
- Java
- Aspose.Slides
description: "Μετατροπή παρουσιάσεων PPT και PPTX σε PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Διαμορφώστε τη θέση των σημειώσεων και διατηρήστε τις μακρές σημειώσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε PDF με σημειώσεις ομιλητή χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Μπορείτε να συμπεριλάβετε σημειώσεις κάτω από κάθε διαφάνεια και να επιτρέψετε σε μακρές σημειώσεις να συνεχιστούν σε επιπλέον σελίδες. Για άλλες ρυθμίσεις εξαγωγής PDF, δείτε [Μετατροπή PowerPoint σε PDF](/slides/el/python-java/convert-powerpoint-to-pdf/).

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Χρησιμοποιήστε τη μέθοδο [save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) για να εξαγάγετε μια παρουσίαση PPT ή PPTX σε PDF. Για να συμπεριλάβετε σημειώσεις ομιλητή, δημιουργήστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/) και ρυθμίστε τη μέθοδο [setNotesPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Ανάθεστε αυτή τη διάταξη στο [PdfOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/) χρησιμοποιώντας το [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Το παρακάτω παράδειγμα φορτώνει το `sample.pptx` και το εξάγει σε `output.pdf` με σημειώσεις ομιλητή κάτω από τις διαφάνειες:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Διαμόρφωση επιλογών PDF για απόδοση σημειώσεων ομιλητή.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Αποθήκευση της παρουσίασης σε PDF με σημειώσεις ομιλητή.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να δοκιμάσετε τον [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/el/conversion).
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αποτρέψω την περικοπή των μεγάλων σημειώσεων ομιλητή;**

Χρησιμοποιήστε το [NotesPositions.BottomFull](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/#BottomFull), όπως στο παραπάνω παράδειγμα. Αυτή η ρύθμιση εμφανίζει τις πλήρεις σημειώσεις, χρησιμοποιώντας επιπλέον σελίδες όταν χρειάζεται.

**Μπορώ να διατηρήσω κάθε διαφάνεια και τις σημειώσεις της σε μία μόνο σελίδα;**

Χρησιμοποιήστε το [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/#BottomTruncated). Αυτή η ρύθμιση περιορίζει τις σημειώσεις σε μία σελίδα, οπότε οι σημειώσεις που δεν χωρούν μπορεί να περικοπούν.

**Πώς μπορώ να εξάγω διαφάνειες χωρίς σημειώσεις ομιλητή;**

Παραλείψτε τη ρύθμιση διάταξης σημειώσεων και χρησιμοποιήστε την τυπική εξαγωγή PDF που περιγράφεται στην [Μετατροπή PowerPoint σε PDF](/slides/el/python-java/convert-powerpoint-to-pdf/).