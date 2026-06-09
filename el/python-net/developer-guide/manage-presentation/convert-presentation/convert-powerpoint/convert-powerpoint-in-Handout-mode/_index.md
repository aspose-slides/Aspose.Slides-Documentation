---
title: Μετατροπή παρουσιάσεων σε λειτουργία Handout με Python
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία Handout
- Handout
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Μετατροπή παρουσιάσεων σε φυλλάδια με Python. Ορίστε τις διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξαγάγετε σε PDF ή εικόνες με Aspose.Slides, με δείγμα κώδικα. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση στη λειτουργία Handout. Αυτή η λειτουργία σάς επιτρέπει να διαμορφώσετε τον τρόπο με τον οποίο εμφανίζονται πολλές διαφάνειες σε μια μόνο σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλες εκδηλώσεις. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας την ιδιότητα `slides_layout_options` στις κλάσεις [PdfOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/), και [TiffOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/).

## **Εξαγωγή σε Λειτουργία Handout**

Για να διαμορφώσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handoutlayoutingoptions/) το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μια μόνο σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω βρίσκεται ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF στη λειτουργία Handout.

```py
# Φορτώνει μια παρουσίαση.
with slides.Presentation("sample.pptx") as presentation:

    # Ορίζει τις επιλογές εξαγωγής.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 διαφάνειες σε μια σελίδα οριζόντια
    slides_layout_options.print_slide_numbers = True                                 # εκτύπωση αριθμών διαφανειών
    slides_layout_options.print_frame_slide = True                                   # εκτύπωση πλαισίου γύρω από τις διαφάνειες
    slides_layout_options.print_comments = False                                     # χωρίς σχόλια

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Εξάγει την παρουσίαση σε PDF με την επιλεγμένη διάταξη.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η ιδιότητα `slides_layout_options` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά την απόδοση ως εικόνες.
{{% /alert %}} 

## **Συχνές ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κατακόρυφη), 6 (οριζόντια/κατακόρυφη) και 9 (οριζόντια/κατακόρυφη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την απαρίθμηση [HandoutType](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handouttype/), και δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε την επιλογή `show_hidden_slides` στις ρυθμίσεις εξαγωγής για τη μορφή‑στόχο, όπως [PdfOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/tiffoptions/).