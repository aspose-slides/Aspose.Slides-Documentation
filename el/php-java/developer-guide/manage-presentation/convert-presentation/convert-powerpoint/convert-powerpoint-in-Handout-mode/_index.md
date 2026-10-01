---
title: Μετατροπή παρουσιάσεων PowerPoint σε λειτουργία Handout χρησιμοποιώντας PHP
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/php-java/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία handout
- φυλλάδιο
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις σε φυλλάδια με PHP. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξάγετε σε PDF ή εικόνες με το Aspose.Slides για PHP, με δείγμα κώδικα. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση σε λειτουργία Handout. Αυτή η λειτουργία σάς επιτρέπει να διαμορφώσετε πώς εμφανίζονται πολλές διαφάνειες σε μία σελίδα, καθιστώντας την χρήσιμη για συσκέψεις, σεμινάρια και άλλες εκδηλώσεις. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `setSlidesLayoutOptions` στις κλάσεις [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/), και [TiffOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/).

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας του φυλλαδίου πριν από την εξαγωγή, δείτε [Μέγεθος Σελίδας Σημειώσεων](/slides/el/php-java/notes-size/).

## **Εξαγωγή Λειτουργίας Handout**

Για να διαμορφώσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/handoutlayoutingoptions/) το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μία σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```php
// Φόρτωση μιας παρουσίασης.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 διαφάνειες σε μία σελίδα οριζόντια
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // εκτύπωση αριθμών διαφανειών
$slidesLayoutOptions->setPrintFrameSlide(true);                      // εκτύπωση πλαισίου γύρω από τις διαφάνειες
$slidesLayoutOptions->setPrintComments(false);                       // χωρίς σχόλια

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά την απόδοση ως εικόνες.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [προεπιλογές](https://reference.aspose.com/slides/el/php-java/aspose.slides/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κάθετη), 6 (οριζόντια/κάθετη) και 9 (οριζόντια/κάθετη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την κλάση [HandoutType](https://reference.aspose.com/slides/el/php-java/aspose.slides/handouttype/)· οι αυθαίρετες διατάξεις δεν υποστηρίζονται.

**Μπορώ να συμπεριλάβω κρυμμένες διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε τις κρυμμένες διαφάνειες χρησιμοποιώντας τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη μορφή-στόχο, όπως [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/).