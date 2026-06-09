---
title: Μετατροπή παρουσιάσεων PowerPoint σε λειτουργία Handout χρησιμοποιώντας Java
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/java/convert-powerpoint-in-Handout-mode/
keywords:
- Μετατροπή PowerPoint
- Μετατροπή παρουσίασης
- Λειτουργία Handout
- Εκτύπωση
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις σε handouts στην Java. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξάγετε σε PDF ή εικόνες με Aspose.Slides, με δείγμα κώδικα Java. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides σάς επιτρέπει να μετατρέπετε παρουσιάσεις σε μορφές εξόδου που υποστηρίζουν τη λειτουργία Handout. Σε αυτή τη λειτουργία, πολλές διαφάνειες τοποθετούνται σε μία σελίδα, κάτι που είναι χρήσιμο για εκτύπωση υλικού παρουσιάσεων για συνέδρια, σεμινάρια και παρόμοιες εκδηλώσεις.

Η λειτουργία Handout διαμορφώνεται μέσω της μεθόδου `setSlidesLayoutOptions`, η οποία είναι διαθέσιμη στα [IPdfOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihtmloptions/), και [ITiffOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiffoptions/). Για να ορίσετε τη διάταξη του handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/handoutlayoutingoptions/) .

## **Εξαγωγή σε Λειτουργία Handout**

Για να εξάγετε μια παρουσίαση σε λειτουργία Handout, ορίστε τη μέθοδο `setSlidesLayoutOptions` για τις επιθυμητές επιλογές εξαγωγής και καθορίστε ένα αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/handoutlayoutingoptions/) που ορίζει τον αριθμό των διαφανειών ανά σελίδα και σχετικές παραμέτρους εμφάνισης.

Παρακάτω βρίσκεται ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```java
// Φόρτωση παρουσίασης.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ορισμός επιλογών εξαγωγής.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 διαφάνειες σε μία σελίδα οριζόντια
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // εκτύπωση αριθμών διαφανειών
    slidesLayoutOptions.setPrintFrameSlide(true);                     // εκτύπωση πλαισίου γύρω από τις διαφάνειες
    slidesLayoutOptions.setPrintComments(false);                      // χωρίς σχόλια

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Εξαγωγή της παρουσίασης σε PDF με την επιλεγμένη διάταξη.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, καθώς και κατά τη δημιουργία εικόνων.
{{% /alert %}} 

## **Συχνές ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/java/com.aspose.slides/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κατακόρυφη διάταξη: 1, 2, 3, 4 (οριζόντια/κατακόρυφη), 6 (οριζόντια/κατακόρυφη) και 9 (οριζόντια/κατακόρυφη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η διάταξη των μικρογραφιών ελέγχονται αυστηρά από την κλάση [HandoutType](https://reference.aspose.com/slides/el/java/com.aspose.slides/handouttype/), και δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες χρησιμοποιώντας τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη ζητούμενη μορφή, όπως [PdfOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/tiffoptions/).