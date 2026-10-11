---
title: Μετατροπή παρουσιάσεων PowerPoint σε PDF με σημειώσεις σε Python
linktitle: PowerPoint σε PDF με σημειώσεις
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
- σημειώσεις παρουσίασης
- PDF με σημειώσεις
- Python
- Java
- Aspose.Slides
description: "Μετατροπή παρουσιάσεων PPT και PPTX σε PDF με σημειώσεις παρουσίασης χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Διαμορφώστε τη θέση των σημειώσεων και διατηρήστε τις μακριές σημειώσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε PDF με σημειώσεις παρουσίασης χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Μπορείτε να συμπεριλάβετε σημειώσεις κάτω από κάθε διαφάνεια και να επιτρέψετε στις μεγάλες σημειώσεις να συνεχιστούν σε πρόσθετες σελίδες. Για άλλες ρυθμίσεις εξαγωγής PDF, δείτε [Μετατροπή PowerPoint σε PDF](/slides/el/python-java/convert-powerpoint-to-pdf/).

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας σημειώσεων πριν την εξαγωγή, δείτε [Μέγεθος Σελίδας Σημειώσεων](/slides/el/python-java/notes-size/).

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Χρησιμοποιήστε τη μέθοδο [save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) για να εξάγετε μια παρουσίαση PPT ή PPTX σε PDF. Για να συμπεριλάβετε σημειώσεις παρουσίασης, δημιουργήστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/) και ρυθμίστε την τοποθέτηση των σημειώσεων με τη μέθοδό του [setNotesPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Αναθέστε αυτή τη διάταξη στο [PdfOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/) χρησιμοποιώντας το [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Το παρακάτω παράδειγμα φορτώνει το `sample.pptx` και το εξάγει σε `output.pdf` με σημειώσεις παρουσίασης κάτω από τις διαφάνειες:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Διαμόρφωση επιλογών PDF για απόδοση σημειώσεων παρουσίασης.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Αποθήκευση της παρουσίασης σε PDF με σημειώσεις παρουσίασης.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Σημείωση" %}}
Μπορείτε επίσης να δοκιμάσετε το [Online Μετατροπέας PowerPoint σε PDF](https://products.aspose.app/slides/el/conversion).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αποτρέψω την αποκοπή μεγάλων σημειώσεων παρουσίασης;**

Χρησιμοποιήστε το [NotesPositions.BottomFull](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/#BottomFull), όπως στο παραπάνω παράδειγμα. Αυτή η ρύθμιση εμφανίζει τις πλήρεις σημειώσεις, χρησιμοποιώντας πρόσθετες σελίδες όταν απαιτείται.

**Μπορώ να διατηρήσω κάθε διαφάνεια και τις σημειώσεις της σε μία σελίδα;**

Χρησιμοποιήστε το [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/#BottomTruncated). Αυτή η ρύθμιση περιορίζει τις σημειώσεις σε μία σελίδα, έτσι οι σημειώσεις που δεν χωράνε μπορεί να περικοπούν.

**Πώς μπορώ να εξάγω διαφάνειες χωρίς σημειώσεις παρουσίασης;**

Παραλείψτε τη ρύθμιση διάταξης σημειώσεων και χρησιμοποιήστε τη στάνταρ εξαγωγή PDF που περιγράφεται στο [Μετατροπή PowerPoint σε PDF](/slides/el/python-java/convert-powerpoint-to-pdf/).