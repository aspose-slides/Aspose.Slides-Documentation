---
title: Μετατροπή παρουσιάσεων PowerPoint σε λειτουργία Handout χρησιμοποιώντας JavaScript
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία φυλλαδίου
- φυλλάδιο
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις σε φυλλάδια. Ορίστε πόσες διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξάγετε σε PDF ή εικόνες με Aspose.Slides για Node.js, με παράδειγμα κώδικα. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Η Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση στη λειτουργία Handout. Αυτή η λειτουργία σας επιτρέπει να ρυθμίσετε πώς εμφανίζονται πολλές διαφάνειες σε μία σελίδα, καθιστώντας τη χρήσιμη για συνέδρια, σεμινάρια και άλλες εκδηλώσεις. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `setSlidesLayoutOptions` στις κλάσεις [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/), και [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/) .

## **Εξαγωγή Λειτουργίας Handout**

Για να διαμορφώσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handoutlayoutingoptions/), το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μία σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF στη λειτουργία Handout.

```js
// Φόρτωση παρουσίασης.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Ορισμός επιλογών εξαγωγής.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 διαφάνειες σε μία σελίδα οριζόντια
slidesLayoutOptions.setPrintSlideNumbers(true);                                // εκτύπωση αριθμών διαφανειών
slidesLayoutOptions.setPrintFrameSlide(true);                                  // εκτύπωση πλαισίου γύρω από τις διαφάνειες
slidesLayoutOptions.setPrintComments(false);                                   // χωρίς σχόλια

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Εξαγωγή παρουσίασης σε PDF με την επιλεγμένη διάταξη.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά την απόδοση ως εικόνες.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Η Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handouttype/) μέχρι 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κατακόρυφη), 6 (οριζόντια/κατακόρυφα) και 9 (οριζόντια/κατακόρυφα).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την αναγραφή [HandoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handouttype/)· επομένως δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Χρησιμοποιήστε τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη μορφή‑στόχο, όπως [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/).