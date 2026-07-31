---
title: Μετατροπή Παρουσιάσεων σε Λειτουργία Handout με Python
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/python-net/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία handout
- φυλλάδιο
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις σε φύλλα με Python. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξάγετε σε PDF ή εικόνες με Aspose.Slides, με δείγμα κώδικα. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση σε λειτουργία Handout. Αυτή η λειτουργία σας επιτρέπει να διαμορφώσετε πώς εμφανίζονται πολλαπλές διαφάνειες σε μία σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλες εκδηλώσεις. Μπορείτε να ενεργοποιήσετε αυτήν τη λειτουργία ορίζοντας την ιδιότητα `slides_layout_options` στις κλάσεις [PdfOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/), και [TiffOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/) .

## **Εξαγωγή Λειτουργίας Handout**

Για να διαμορφώσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handoutlayoutingoptions/), το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μία σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω βρίσκεται ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```py
# Φορτώστε μια παρουσίαση.
with slides.Presentation("sample.pptx") as presentation:

    # Ορίστε τις επιλογές εξαγωγής.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 διαφάνειες σε μία σελίδα οριζόντια
    slides_layout_options.print_slide_numbers = True                                 # εκτυπώστε αριθμούς διαφανειών
    slides_layout_options.print_frame_slide = True                                   # εκτυπώστε ένα πλαίσιο γύρω από τις διαφάνειες
    slides_layout_options.print_comments = False                                     # χωρίς σχόλια

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Εξάγετε την παρουσίαση σε PDF με την επιλεγμένη διάταξη.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η ιδιότητα `slides_layout_options` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά τη δημιουργία εικόνων.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κάθετη), 6 (οριζόντια/κάθετη) και 9 (οριζόντια/κάθετη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την απαρίθμηση [HandoutType](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handouttype/), και δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε την επιλογή `show_hidden_slides` στις ρυθμίσεις εξαγωγής για τη μορφή‑στόχο, όπως [PdfOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/).