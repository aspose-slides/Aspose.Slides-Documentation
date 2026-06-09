---
title: Μετατροπή παρουσιάσεων PowerPoint σε λειτουργία Handout με C++
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία handout
- handout
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις σε φυλλάδια με C++. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξαγάγετε σε PDF ή εικόνες με Aspose.Slides, με παράδειγμα κώδικα. Δοκιμάστε δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση σε λειτουργία Handout. Αυτή η λειτουργία επιτρέπει τη διαμόρφωση τουπώς πολλές διαφάνειες εμφανίζονται σε μία σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλες εκδηλώσεις. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `set_SlidesLayoutOptions` στις διεπαφές [IPdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ihtmloptions/), και [ITiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/itiffoptions/) .

## **Εξαγωγή σε Λειτουργία Handout**

Για τη διαμόρφωση της λειτουργίας Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/handoutlayoutingoptions/) , το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μία σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```cpp
// Φόρτωση μιας παρουσίασης.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ορίστε τις επιλογές εξαγωγής.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 διαφάνειες σε μία σελίδα οριζόντια
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // εκτύπωση αριθμών διαφανειών
slidesLayoutOptions->set_PrintFrameSlide(true);                      // εκτύπωση πλαισίου γύρω από τις διαφάνειες
slidesLayoutOptions->set_PrintComments(false);                       // χωρίς σχόλια

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η μέθοδος `set_SlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και κατά τη δημιουργία εικόνων.
{{% /alert %}} 

## **Συχνές ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κάθετη), 6 (οριζόντια/κάθετη) και 9 (οριζόντια/κάθετη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την απαρίθμηση [HandoutType](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/handouttype/) , και δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Χρησιμοποιήστε τη μέθοδο `set_ShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη μορφή-στόχο, όπως [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/).