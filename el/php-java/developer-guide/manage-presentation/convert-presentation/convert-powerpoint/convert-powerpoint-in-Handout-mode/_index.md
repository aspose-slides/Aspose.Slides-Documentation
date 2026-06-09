---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Λειτουργία Handout με PHP
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία Handout
- φυλλάδιο
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις σε φυλλάδια με PHP. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε σημειώσεις, εξαγάγετε σε PDF ή εικόνες με Aspose.Slides για PHP, με παράδειγμα κώδικα. Δοκιμάστε δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση σε λειτουργία Handout. Αυτή η λειτουργία σας επιτρέπει να διαμορφώσετε πώς πολλές διαφάνειες εμφανίζονται σε μια σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλες εκδηλώσεις. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `setSlidesLayoutOptions` στις κλάσεις [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/) και [TiffOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/).

## **Εξαγωγή σε Λειτουργία Handout**

Για να διαμορφώσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/handoutlayoutingoptions/), το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μια σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```php
// Φόρτωση παρουσίασης.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 διαφάνειες σε μια σελίδα οριζόντια
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // εκτύπωση αριθμών διαφανειών
$slidesLayoutOptions->setPrintFrameSlide(true);                      // εκτύπωση πλαισίου γύρω από τις διαφάνειες
$slidesLayoutOptions->setPrintComments(false);                       // χωρίς σχόλια

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 

Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά την απόδοση ως εικόνες.

{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφάνειας ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [preset](https://reference.aspose.com/slides/el/php-java/aspose.slides/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κάθετη), 6 (οριζόντια/κάθετη) και 9 (οριζόντια/κάθετη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η διάταξη των μικρογραφιών ελέγχονται αυστηρά από την κλάση [HandoutType](https://reference.aspose.com/slides/el/php-java/aspose.slides/handouttype/); δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες χρησιμοποιώντας τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη μορφή-στόχο, όπως [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/).