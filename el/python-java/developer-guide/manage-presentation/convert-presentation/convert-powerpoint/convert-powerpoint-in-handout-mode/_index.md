---
title: Μετατροπή παρουσιάσεων PowerPoint σε λειτουργία φυλλάδιου χρησιμοποιώντας Python
linktitle: Λειτουργία φυλλάδιου
type: docs
weight: 150
url: /el/python-java/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία φυλλάδιου
- φυλλάδιο
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις PowerPoint σε φυλλάδια σε Python μέσω Java. Τακτοποιήστε πολλές διαφάνειες ανά σελίδα και εξάγετε σε PDF με Aspose.Slides."
---
## **Εισαγωγή**

Aspose.Slides for Python via Java σάς επιτρέπει να εξάγετε παρουσιάσεις σε λειτουργία φυλλάδιου, τοποθετώντας πολλές διαφάνειες σε μία σελίδα. Αυτό είναι χρήσιμο για εκτύπωση υλικού παρουσίασης για συνέδρια, σεμινάρια και παρόμοιες εκδηλώσεις.

Ρυθμίστε τη διάταξη μέσω της μεθόδου [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Οι διατάξεις φυλλάδιου υποστηρίζονται από [PdfOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/htmloptions/), και [TiffOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/tiffoptions/). Χρησιμοποιήστε ένα αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/handoutlayoutingoptions/) για τον καθορισμό των ρυθμίσεων διάταξης και εμφάνισης.

## **Εξαγωγή σε Λειτουργία Φυλλάδιου**

Για να εξάγετε μια παρουσίαση σε λειτουργία φυλλάδιου, δημιουργήστε ένα στιγμιότυπο του [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/handoutlayoutingoptions/) και αναθέστε το στις επιλογές εξαγωγής-στόχο χρησιμοποιώντας τη μέθοδο [setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Το παρακάτω παράδειγμα φορτώνει το αρχείο `sample.pptx` και το εξάγει σε PDF με τέσσερις διαφάνειες ανά σελίδα σε οριζόντια σειρά. Περιλαμβάνει αριθμούς διαφανειών και πλαίσια γύρω από τις διαφάνειες, και εξαιρεί τα σχόλια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Φορτώστε μια παρουσίαση.
presentation = Presentation("sample.pptx")
try:
    # Διαμορφώστε τη διάταξη του φυλλαδίου.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Εξάγετε την παρουσίαση σε PDF με την επιλεγμένη διάταξη.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Οι ρυθμίσεις διάταξης φυλλάδιου εφαρμόζονται στα υποστηριζόμενα μορφότυπα εξόδου, όπως PDF, HTML, TIFF και απεικονίσεις που αποδίδονται. Δεν αναδιατάσσουν τις διαφάνειες στην πηγαία παρουσίαση.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία φυλλάδιου;**

Το Aspose.Slides υποστηρίζει έως και εννέα μικρογραφίες ανά σελίδα. Οι προρυθμίσεις [HandoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/handouttype/) παρέχουν μία, δύο, τρεις, τέσσερις, έξι ή εννέα διαφάνειες ανά σελίδα. Οι προρυθμίσεις των τεσσάρων, έξι και εννέα διαφανειών προσφέρουν οριζόντια και κάθετη σειρά.

**Μπορώ να ορίσω προσαρμοστικό πλέγμα, όπως πέντε ή οκτώ διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται από τις προεπιλεγμένες τιμές του [HandoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/handouttype/). Οι αυθαίρετες διατάξεις δεν υποστηρίζονται από αυτές τις ρυθμίσεις διάταξης φυλλάδιου.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο φυλλάδιου;**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες στις ρυθμίσεις εξαγωγής για το μορφότυπο-στόχο. Για PDF, καλέστε τη μέθοδο [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) με `True` πριν αποθηκεύσετε την παρουσίαση.