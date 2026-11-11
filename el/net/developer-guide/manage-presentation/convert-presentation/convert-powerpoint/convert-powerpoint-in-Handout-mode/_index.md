---
title: Μετατροπή παρουσιάσεων PowerPoint σε λειτουργία Handout σε .NET
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/net/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία Handout
- χειρόγραφο
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις σε χαρτόσημα σε .NET. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξάγετε σε PDF ή εικόνες με το Aspose.Slides, με δείγμα κώδικα C#. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε παρουσιάσεις σε μορφές εξόδου που υποστηρίζουν τη λειτουργία Handout. Σε αυτή τη λειτουργία, πολλές διαφάνειες τοποθετούνται σε μία σελίδα, κάτι που είναι χρήσιμο για εκτύπωση υλικού παρουσίασης για συνέδρια, σεμινάρια και παρόμοιες εκδηλώσεις.

Η λειτουργία Handout ρυθμίζεται μέσω της ιδιότητας `SlidesLayoutOptions`, η οποία είναι διαθέσιμη σε [IPdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/ihtmloptions/), και [ITiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/itiffoptions/). Για να ορίσετε τη διάταξη του handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/handoutlayoutingoptions/) .

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας handout πριν από την εξαγωγή, δείτε [Notes Page Size](/slides/el/net/notes-size/) .

## **Εξαγωγή σε Λειτουργία Handout**

Για να εξάγετε μια παρουσίαση σε λειτουργία Handout, ορίστε την ιδιότητα `SlidesLayoutOptions` για τις επιθυμητές επιλογές εξαγωγής και αναθέστε μια παρουσίαση του [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/handoutlayoutingoptions/) που ορίζει τον αριθμό των διαφανειών ανά σελίδα και σχετικές παραμέτρους εμφάνισης.

Παρακάτω είναι ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Φορτώστε μια παρουσίαση.
using var presentation = new Presentation("sample.pptx");

// Ορίστε τις επιλογές εξαγωγής.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 διαφάνειες σε μια σελίδα οριζόντια
        PrintSlideNumbers = true,                   // εκτύπωση αριθμών διαφανειών
        PrintFrameSlide = true,                     // εκτύπωση πλαισίου γύρω από τις διαφάνειες
        PrintComments = false                       // χωρίς σχόλια
    }
};

// Εξάγετε την παρουσίαση σε PDF με την επιλεγμένη διάταξη.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η ιδιότητα `SlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά τη μετατροπή σε εικόνες.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

### Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;

Το Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/net/aspose.slides.export/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κατακόρυφη), 6 (οριζόντια/κατακόρυφη) και 9 (οριζόντια/κατακόρυφη).

### Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την απαρίθμηση [HandoutType](https://reference.aspose.com/slides/el/net/aspose.slides.export/handouttype/), οι αυθαίρετες διατάξεις δεν υποστηρίζονται.

### Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;

Ναι. Ενεργοποιήστε την επιλογή `ShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη μορφή προορισμού, όπως [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/).