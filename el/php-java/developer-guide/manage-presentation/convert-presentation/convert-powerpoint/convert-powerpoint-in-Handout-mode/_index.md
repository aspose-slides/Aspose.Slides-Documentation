---
title: Μετατροπή παρουσιάσεων PowerPoint σε Λειτουργία Handout χρησιμοποιώντας PHP
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/php-java/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία handout
- handout
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις σε σημειώσεις εκτύπωσης με PHP. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε σημειώσεις, εξάγετε σε PDF ή εικόνες με Aspose.Slides για PHP, με δείγμα κώδικα. Δοκιμάστε δωρεάν."
---
## **Εισαγωγή**

Η Aspose.Slides προσφέρει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας σημειώσεων εκτύπωσης σε λειτουργία Handout. Αυτή η λειτουργία σας επιτρέπει να διαμορφώνετε πώς εμφανίζονται πολλαπλές διαφάνειες σε μια σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλα γεγονότα. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `setSlidesLayoutOptions` στις κλάσεις [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/), και [TiffOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/) .

## **Εξαγωγή σε Λειτουργία Handout**

Για να διαμορφώσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/handoutlayoutingoptions/) , το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μια σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω είναι ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```php
// Φορτώστε μια παρουσίαση.
$presentation = new Presentation("sample.pptx");

// Ορίστε τις επιλογές εξαγωγής.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 διαφάνειες σε μία σελίδα οριζόντια
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // εκτύπωση αριθμών διαφανειών
$slidesLayoutOptions->setPrintFrameSlide(true);                      // εκτύπωση πλαισίου γύρω από τις διαφάνειες
$slidesLayoutOptions->setPrintComments(false);                       // χωρίς σχόλια

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Εξαγάγετε την παρουσίαση σε PDF με την επιλεγμένη διάταξη.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και όταν γίνεται απόδοση ως εικόνες.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Η Aspose.Slides υποστηρίζει [προεπιλογές](https://reference.aspose.com/slides/el/php-java/aspose.slides/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κατακόρυφη διάταξη: 1, 2, 3, 4 (οριζόντια/κατακόρυφη), 6 (οριζόντια/κατακόρυφη) και 9 (οριζόντια/κατακόρυφη).

**Μπορώ να καθορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η διάταξη των μικρογραφιών ελέγχονται αυστηρά από την κλάση [HandoutType](https://reference.aspose.com/slides/el/php-java/aspose.slides/handouttype/) , ενώ δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες χρησιμοποιώντας τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη μορφή‑στόχο, όπως [PdfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/tiffoptions/).