---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Λειτουργία Φυλλαδίου με C++
linktitle: Λειτουργία Φυλλαδίου
type: docs
weight: 150
url: /el/cpp/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία φυλλαδίου
- φυλλάδιο
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις σε φυλλάδια με C++. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε σημειώσεις, εξάγετε σε PDF ή εικόνες με το Aspose.Slides, με δοκιμαστικό κώδικα. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση σε λειτουργία Φυλλαδίου. Αυτή η λειτουργία σας επιτρέπει να ρυθμίσετε πώς εμφανίζονται πολλές διαφάνειες σε μία σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλα γεγονότα. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `set_SlidesLayoutOptions` στα interfaces [IPdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ihtmloptions/) και [ITiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/itiffoptions/).

## **Εξαγωγή σε Λειτουργία Φυλλαδίου**

Για να ρυθμίσετε τη λειτουργία Φυλλαδίου, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/handoutlayoutingoptions/) το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μια σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Φυλλαδίου.

```cpp
// Φορτώνει μια παρουσίαση.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ορίζει τις επιλογές εξαγωγής.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 διαφάνειες σε μία σελίδα οριζόντια
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // εκτύπωση αριθμών διαφανειών
slidesLayoutOptions->set_PrintFrameSlide(true);                      // εκτύπωση πλαισίου γύρω από τις διαφάνειες
slidesLayoutOptions->set_PrintComments(false);                       // χωρίς σχόλια

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Εξάγει την παρουσίαση σε PDF με την επιλεγμένη διάταξη.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η μέθοδος `set_SlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF και κατά τη δημιουργία εικόνων.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Φυλλαδίου;**

Το Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/handouttype/) μέχρι 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κατακόρυφη), 6 (οριζόντια/κατακόρυφη) και 9 (οριζόντια/κατακόρυφη).

**Μπορώ να ορίσω προσαρμοστικό πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την απαρίθμηση [HandoutType](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/handouttype/); οι αυθαίρετες διατάξεις δεν υποστηρίζονται.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην εξαγωγή Φυλλαδίου;**

Ναι. Χρησιμοποιήστε τη μέθοδο `set_ShowHiddenSlides` στις ρυθμίσεις εξόδου για τη στοχευμένη μορφή, όπως [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/).