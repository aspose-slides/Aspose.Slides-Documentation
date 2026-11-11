---
title: "Μετατροπή Παρουσιάσεων PowerPoint σε Λειτουργία Handout Χρησιμοποιώντας JavaScript"
linktitle: "Λειτουργία Handout"
type: docs
weight: 150
url: /el/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- "μετατροπή PowerPoint"
- "μετατροπή παρουσίασης"
- "λειτουργία handout"
- "φύλλο"
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέπει τις παρουσιάσεις σε φυλλάδια. Ορίστε πόσες διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξάγετε σε PDF ή εικόνες με Aspose.Slides για Node.js, με δείγμα κώδικα. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Aspose.Slides παρέχει τη δυνατότητα να μετατρέπει παρουσιάσεις σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση σε λειτουργία Handout. Αυτή η λειτουργία επιτρέπει τη διαμόρφωση του πώς πολλές διαφάνειες εμφανίζονται σε μία σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλα γεγονότα. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `setSlidesLayoutOptions` στις κλάσεις [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/) και [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/).

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας φυλλαδίου πριν την εξαγωγή, δείτε [Notes Page Size](/slides/el/nodejs-java/notes-size/).

## **Εξαγωγή σε Λειτουργία Handout**

Για να διαμορφώσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handoutlayoutingoptions/) , το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μία σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```js
const asposeSlides = require("aspose.slides.via.java");

// Φόρτωση παρουσίασης.
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

{{% alert color="warning" title="Warning" %}}
Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά τη μετατροπή σε εικόνες.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κάθετη), 6 (οριζόντια/κάθετη) και 9 (οριζόντια/κάθετη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η διάταξη των μικρογραφιών ελέγχονται αυστηρά από την απαρίθμηση [HandoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/handouttype/)· δεν υποστηρίζονται τυχαίες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Χρησιμοποιήστε τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη μορφή‑στόχο, όπως [PdfOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tiffoptions/).