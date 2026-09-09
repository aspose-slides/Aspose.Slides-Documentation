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
- σημειώσεις παρουσιάστη
- PDF με σημειώσεις
- Python
- Java
- Aspose.Slides
description: "Μετατροπή παρουσιάσεων PPT και PPTX σε PDF με σημειώσεις παρουσιάστη χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Διαμόρφωση της θέσης των σημειώσεων και διατήρηση μακρών σημειώσεων."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε PDF με σημειώσεις παρουσιάστη χρησιμοποιώντας το Aspose.Slides for Python μέσω Java. Μπορείτε να συμπεριλάβετε τις σημειώσεις κάτω από κάθε διαφάνεια και να επιτρέψετε στις μεγάλες σημειώσεις να συνεχίζουν σε επιπλέον σελίδες. Για άλλες ρυθμίσεις εξαγωγής PDF, δείτε [Convert PowerPoint to PDF](/slides/el/python-java/convert-powerpoint-to-pdf/).

## **Μετατροπή PowerPoint σε PDF με Σημειώσεις**

Χρησιμοποιήστε τη μέθοδο [save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) για να εξάγετε μια παρουσίαση PPT ή PPTX σε PDF. Για να συμπεριλάβετε σημειώσεις παρουσιαστή, δημιουργήστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/) και ρυθμίστε τη θέση των σημειώσεων με τη μέθοδο [setNotesPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Αναθέστε αυτήν τη διάταξη στο [PdfOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/) χρησιμοποιώντας τη μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Το παρακάτω παράδειγμα φορτώνει το `sample.pptx` και το εξάγει σε `output.pdf` με σημειώσεις παρουσιάστη κάτω από τις διαφάνειες:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Διαμόρφωση επιλογών PDF για απόδοση σημειώσεων παρουσιάστη.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Αποθήκευση της παρουσίασης σε PDF με σημειώσεις παρουσιάστη.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να δοκιμάσετε τον [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/el/conversion).
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αποτρέψω το κόψιμο μεγάλων σημειώσεων παρουσιάστη;**

Χρησιμοποιήστε το [NotesPositions.BottomFull](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/#BottomFull), όπως στο παραπάνω παράδειγμα. Αυτή η ρύθμιση εμφανίζει τις πλήρεις σημειώσεις, χρησιμοποιώντας επιπλέον σελίδες όταν είναι απαραίτητο.

**Μπορώ να διατηρήσω κάθε διαφάνεια και τις σημειώσεις της στην ίδια σελίδα;**

Χρησιμοποιήστε το [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/#BottomTruncated). Αυτή η ρύθμιση περιορίζει τις σημειώσεις σε μία σελίδα, οπότε οι σημειώσεις που δεν χωράνε μπορεί να περικοπούν.

**Πώς εξάγω διαφάνειες χωρίς σημειώσεις παρουσιάστη;**

Παραλείψτε τη ρύθμιση διάταξης σημειώσεων και χρησιμοποιήστε την τυπική εξαγωγή PDF που περιγράφεται στο [Convert PowerPoint to PDF](/slides/el/python-java/convert-powerpoint-to-pdf/).