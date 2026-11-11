---
title: Μετατρέψτε παρουσιάσεις PowerPoint σε λειτουργία Handout χρησιμοποιώντας Java
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/java/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία Handout
- handout
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις σε handouts με Java. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξαγάγετε σε PDF ή εικόνες με το Aspose.Slides, με δείγμα κώδικα Java. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides σας επιτρέπει να μετατρέπετε παρουσιάσεις σε μορφές εξόδου που υποστηρίζουν τη λειτουργία Handout. Σε αυτή τη λειτουργία, πολλαπλές διαφάνειες τοποθετούνται σε μια ενιαία σελίδα, κάτι που είναι χρήσιμο για την εκτύπωση υλικού παρουσιάσεων για συνέδρια, σεμινάρια και παρόμοιες εκδηλώσεις.

Η λειτουργία Handout διαμορφώνεται μέσω της μεθόδου `setSlidesLayoutOptions`, η οποία είναι διαθέσιμη σε [IPdfOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihtmloptions/), και [ITiffOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/itiffoptions/). Για να ορίσετε τη διάταξη του handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/handoutlayoutingoptions/) .

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας handout πριν από την εξαγωγή, δείτε [Notes Page Size](/slides/el/java/notes-size/).

## **Εξαγωγή σε Λειτουργία Handout**

Για να εξάγετε μια παρουσίαση σε λειτουργία Handout, ορίστε τη μέθοδο `setSlidesLayoutOptions` στις επιθυμητές επιλογές εξαγωγής και αντιστοιχίστε μια παρουσία της [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/handoutlayoutingoptions/) που ορίζει τον αριθμό διαφανειών ανά σελίδα και σχετικές παραμέτρους εμφάνισης.

Παρακάτω φαίνεται ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```java
import com.aspose.slides.*;

// Φόρτωση μιας παρουσίασης.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ορισμός των επιλογών εξαγωγής.
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

{{% alert color="warning" title="Warning" %}}
Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά τη δημιουργία εικόνων.
{{% /alert %}} 

## **Συχνές ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/java/com.aspose.slides/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κάθετη), 6 (οριζόντια/κάθετη) και 9 (οριζόντια/κάθετη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η διάταξη των μικρογραφιών ελέγχονται αυστηρά από την κλάση [HandoutType](https://reference.aspose.com/slides/el/java/com.aspose.slides/handouttype/) και δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες χρησιμοποιώντας τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη ζητούμενη μορφή, όπως [PdfOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/tiffoptions/).