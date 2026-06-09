---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Λειτουργία Φυλλαδίου με JavaScript
linktitle: Λειτουργία Φυλλαδίου
type: docs
weight: 150
url: /el/nodejs-java/convert-powerpoint-in-Handout-mode/
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
description: "Μετατρέψτε τις παρουσιάσεις σε φυλλάδια. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε τα σημειώματα, εξαγάγετε σε PDF ή εικόνες με το Aspose.Slides για Node.js, με παράδειγμα κώδικα. Δοκιμάστε δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση σε λειτουργία Φυλλαδίου. Αυτή η λειτουργία σάς επιτρέπει να διαμορφώσετε πώς εμφανίζονται πολλές διαφάνειες σε μία σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλες εκδηλώσεις. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `setSlidesLayoutOptions` στις κλάσεις [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/), και [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/).

## **Εξαγωγή σε Λειτουργία Φυλλαδίου**

Για να διαμορφώσετε τη λειτουργία Φυλλαδίου, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handoutlayoutingoptions/), το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μία σελίδα και άλλες παραμέτρους εμφάνισης.

Ακολουθεί ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Φυλλαδίου.

```js
// Φορτώστε μια παρουσίαση.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 διαφάνειες σε μία σελίδα οριζόντια
slidesLayoutOptions.setPrintSlideNumbers(true);                                // εκτύπωση αριθμών διαφανειών
slidesLayoutOptions.setPrintFrameSlide(true);                                  // εκτύπωση πλαισίου γύρω από τις διαφάνειες
slidesLayoutOptions.setPrintComments(false);                                   // χωρίς σχόλια

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά τη δημιουργία εικόνων.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Φυλλαδίου;**

Το Aspose.Slides υποστηρίζει [προεπιλογές](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κάθετη), 6 (οριζόντια/κάθετη) και 9 (οριζόντια/κάθετη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η διάταξη των μικρογραφιών ελέγχονται αυστηρά από την απαρίθμηση [HandoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handouttype/), και δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Φυλλαδίου;**

Ναι. Χρησιμοποιήστε τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη μορφή‑στόχο, όπως [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/).