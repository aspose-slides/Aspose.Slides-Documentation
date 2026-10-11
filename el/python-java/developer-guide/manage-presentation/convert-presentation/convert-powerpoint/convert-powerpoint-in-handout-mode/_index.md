---
title: Μετατροπή παρουσιάσεων PowerPoint σε λειτουργία σημειώματος χρησιμοποιώντας Python
linktitle: Λειτουργία Σημειώματος
type: docs
weight: 150
url: /el/python-java/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία σημειώματος
- σημείωμα
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις PowerPoint σε σημειώματα με Python μέσω Java. Τακτοποιήστε πολλαπλές διαφάνειες ανά σελίδα και εξάγετε σε PDF με Aspose.Slides."
---
## **Εισαγωγή**

Το Aspose.Slides for Python μέσω Java σας επιτρέπει να εξάγετε παρουσιάσεις σε λειτουργία σημειώματος, τοποθετώντας πολλαπλές διαφάνειες σε μία σελίδα. Αυτό είναι χρήσιμο για την εκτύπωση υλικού παρουσίασης για συνέδρια, σεμινάρια και παρόμοια γεγονότα.

Διαμορφώστε τη διάταξη μέσω της μεθόδου [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Οι διατάξεις σημειώματος υποστηρίζονται από τα [PdfOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/) και [TiffOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/tiffoptions/). Χρησιμοποιήστε ένα αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/handoutlayoutingoptions/) για να καθορίσετε τις ρυθμίσεις διάταξης και εμφάνισης.

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας σημειώματος πριν από την εξαγωγή, δείτε [Μέγεθος Σελίδας Σημειώματος](/slides/el/python-java/notes-size/).

## **Εξαγωγή σε Λειτουργία Σημειώματος**

Για να εξάγετε μια παρουσίαση σε λειτουργία σημειώματος, δημιουργήστε μια παρουσίαση [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/handoutlayoutingoptions/) και αναθέστε την στις επιλογές εξαγωγής στόχου χρησιμοποιώντας την [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Το παρακάτω παράδειγμα φορτώνει το `sample.pptx` και το εξάγει σε PDF με τέσσερις διαφάνειες ανά σελίδα με οριζόντια διάταξη. Περιλαμβάνει αριθμούς διαφανειών και πλαίσια γύρω από τις διαφάνειες, και αποκλείει σχόλια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Φόρτωση παρουσίασης.
presentation = Presentation("sample.pptx")
try:
    # Διαμόρφωση διάταξης σημειώματος.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Εξαγωγή της παρουσίασης σε PDF με την επιλεγμένη διάταξη.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Οι ρυθμίσεις διάταξης σημειώματος ισχύουν για τις υποστηριζόμενες μορφές εξόδου, όπως PDF, HTML, TIFF και αποδομένες εικόνες. Δεν αναδιοργανώνουν τις διαφάνειες στην πηγαία παρουσίαση.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφάνειας ανά σελίδα σε λειτουργία σημειώματος;**

Το Aspose.Slides υποστηρίζει έως εννέα μικρογραφίες ανά σελίδα. Οι προεπιλογές [HandoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/handouttype/) προσφέρουν μία, δύο, τρεις, τέσσερις, έξι ή εννέα διαφάνειες ανά σελίδα. Οι προεπιλογές με τέσσερις, έξι και εννέα διαφάνειες προσφέρουν οριζόντια και κάθετη διάταξη.

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως πέντε ή οκτώ διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται από τις προκαθορισμένες τιμές του [HandoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/handouttype/). Τα αυθαίρετα πλέγματα δεν υποστηρίζονται από αυτές τις ρυθμίσεις διάταξης σημειώματος.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο σημειώματος;**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες στις ρυθμίσεις εξαγωγής για τη μορφή‑στόχο. Για PDF, καλέστε την [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) με `True` πριν αποθηκεύσετε την παρουσίαση.