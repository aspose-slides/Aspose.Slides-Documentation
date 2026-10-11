---
title: Μετατροπή Παρουσιάσεων σε Λειτουργία Χειρόδειξης με Python
linktitle: Λειτουργία Χειρόδειξης
type: docs
weight: 150
url: /el/python-net/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία χειρόδειξης
- χειρόδειξη
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις σε χειρόδειξεις με Python. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε σημειώσεις, εξάγετε σε PDF ή εικόνες με Aspose.Slides, με δείγμα κώδικα. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας χειρόδειξεων για εκτύπωση σε λειτουργία Handout. Αυτή η λειτουργία σας επιτρέπει να διαμορφώσετε πόσες διαφάνειες εμφανίζονται σε μία σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλες εκδηλώσεις. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας την ιδιότητα `slides_layout_options` στις κλάσεις [PdfOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/), και [TiffOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/).

Για να ορίσετε τις διαστάσεις και το προσανατολισμό της σελίδας χειρόδειξης πριν από την εξαγωγή, δείτε την ενότητα [Notes Page Size](/slides/el/python-net/notes-size/).

## **Εξαγωγή σε Λειτουργία Handout**

Για να διαμορφώσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handoutlayoutingoptions/), το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μία σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```py
import aspose.slides as slides

# Φόρτωση παρουσίασης.
with slides.Presentation("sample.pptx") as presentation:

    # Ορισμός επιλογών εξαγωγής.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 διαφάνειες σε μία σελίδα οριζόντια
    slides_layout_options.print_slide_numbers = True                                 # εκτύπωση αριθμών διαφανειών
    slides_layout_options.print_frame_slide = True                                   # εκτύπωση πλαισίου γύρω από τις διαφάνειες
    slides_layout_options.print_comments = False                                     # χωρίς σχόλια

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Εξαγωγή της παρουσίασης σε PDF με την επιλεγμένη διάταξη.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
Να θυμάστε ότι η ιδιότητα `slides_layout_options` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά τη μετατροπή σε εικόνες.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handouttype/) έως και 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κατακόρυφη), 6 (οριζόντια/κατακόρυφη) και 9 (οριζόντια/κατακόρυφη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η διάταξη των μικρογραφιών ελέγχονται αυστηρά από την απαρίθμηση [HandoutType](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handouttype/); δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε την επιλογή `show_hidden_slides` στις ρυθμίσεις εξαγωγής για τη στοχευόμενη μορφή, όπως [PdfOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/).