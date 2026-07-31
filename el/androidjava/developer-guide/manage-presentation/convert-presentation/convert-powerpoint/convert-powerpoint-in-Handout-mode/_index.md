---
title: Μετατροπή παρουσιάσεων PowerPoint σε Λειτουργία Handout σε Android
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία Handout
- σημειώσεις
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις σε σημειώσεις σε Java. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε τις σημειώσεις, εξάγετε σε PDF ή εικόνες με το Aspose.Slides για Android, με δείγμα κώδικα. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Η Aspose.Slides παρέχει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας σημειώσεων για εκτύπωση σε λειτουργία Handout. Αυτή η λειτουργία σας επιτρέπει να ρυθμίσετε πώς εμφανίζονται πολλαπλές διαφάνειες σε μια σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλες εκδηλώσεις. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `setSlidesLayoutOptions` στις διεπαφές [IPdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihtmloptions/), και [ITiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiffoptions/) .

## **Εξαγωγή σε Λειτουργία Handout**

Για να διαμορφώσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/handoutlayoutingoptions/) , το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μια σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```java
// Φορτώνει μια παρουσίαση.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Ορίζει τις επιλογές εξαγωγής.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 διαφάνειες σε μία σελίδα οριζόντια
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // εκτυπώνει αριθμούς διαφανειών
	slidesLayoutOptions.setPrintFrameSlide(true);                     // εκτυπώνει πλαίσιο γύρω από τις διαφάνειες
	slidesLayoutOptions.setPrintComments(false);                      // χωρίς σχόλια

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Εξάγει την παρουσίαση σε PDF με την επιλεγμένη διάταξη.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και όταν γίνεται απόδοση ως εικόνες.
{{% /alert %}} 

## **FAQ**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφανειών ανά σελίδα στη λειτουργία Handout;**

Η Aspose.Slides υποστηρίζει [presets](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/handouttype/) μέχρι 9 μικρογραφίες ανά σελίδα με οριζόντια ή κατακόρυφη διάταξη: 1, 2, 3, 4 (οριζόντια/κατακόρυφος), 6 (οριζόντια/κατακόρυφος) και 9 (οριζόντια/κατακόρυφος).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την κλάση [HandoutType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/handouttype/)· οι αυθαίρετες διατάξεις δεν υποστηρίζονται.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες χρησιμοποιώντας τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη στοχευμένη μορφή, όπως [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/htmloptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tiffoptions/).