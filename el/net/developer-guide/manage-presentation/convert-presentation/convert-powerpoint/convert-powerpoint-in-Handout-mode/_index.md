---
title: Μετατροπή παρουσιάσεων PowerPoint σε λειτουργία φυλλαδίου στο .NET
linktitle: Λειτουργία φυλλαδίου
type: docs
weight: 150
url: /el/net/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία φυλλαδίου
- φυλλάδιο
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις σε φυλλάδια στο .NET. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξάγετε σε PDF ή εικόνες με το Aspose.Slides, με δείγμα κώδικα C#. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides σάς επιτρέπει να μετατρέπετε παρουσιάσεις σε μορφές εξόδου που υποστηρίζουν τη λειτουργία Handout. Σε αυτή τη λειτουργία, πολλές διαφάνειες τοποθετούνται σε μία σελίδα, κάτι που είναι χρήσιμο για εκτύπωση υλικού παρουσιάσεων για συνέδρια, σεμινάρια και παρόμοιες εκδηλώσεις.

Η λειτουργία Handout ρυθμίζεται μέσω της ιδιότητας `SlidesLayoutOptions`, η οποία είναι διαθέσιμη στα [IPdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/ihtmloptions/) και [ITiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/itiffoptions/). Για να ορίσετε τη διάταξη του handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/handoutlayoutingoptions/).

## **Εξαγωγή σε Λειτουργία Handout**

Για να εξάγετε μια παρουσίαση σε λειτουργία Handout, ορίστε την ιδιότητα `SlidesLayoutOptions` για τις στοχευμένες επιλογές εξαγωγής και εκχωρήστε μία παρουσίαση [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/handoutlayoutingoptions/) που ορίζει τον αριθμό διαφανειών ανά σελίδα και τις σχετικές παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```c#
// Φόρτωση μιας παρουσίασης.
using var presentation = new Presentation("sample.pptx");

// Ορισμός επιλογών εξαγωγής.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 διαφάνειες σε μία σελίδα οριζόντια
        PrintSlideNumbers = true,                   // εκτύπωση αριθμών διαφανειών
        PrintFrameSlide = true,                     // εκτύπωση πλαισίου γύρω από τις διαφάνειες
        PrintComments = false                       // χωρίς σχόλια
    }
};

// Εξαγωγή της παρουσίασης σε PDF με την επιλεγμένη διάταξη.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η ιδιότητα `SlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά την απόδοση ως εικόνες.
{{% /alert %}} 

## **Συχνές ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφάνειας ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [προεπιλογές](https://reference.aspose.com/slides/el/net/aspose.slides.export/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη σειρά: 1, 2, 3, 4 (οριζόντια/κάθετη), 6 (οριζόντια/κάθετη) και 9 (οριζόντια/κάθετη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, π.χ. 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την απαρίθμηση [HandoutType](https://reference.aspose.com/slides/el/net/aspose.slides.export/handouttype/), και δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε την επιλογή `ShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη στοχευόμενη μορφή, όπως [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/).