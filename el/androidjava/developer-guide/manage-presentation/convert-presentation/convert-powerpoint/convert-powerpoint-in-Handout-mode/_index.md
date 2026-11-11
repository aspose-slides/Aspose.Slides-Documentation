---
title: Μετατροπή παρουσιάσεων PowerPoint σε λειτουργία Handout στο Android
linktitle: Λειτουργία Handout
type: docs
weight: 150
url: /el/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- λειτουργία Handout
- φυλλάδιο
- PPT
- PPTX
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις σε φυλλάδια σε Java. Ορίστε διαφάνειες ανά σελίδα, διατηρήστε σημειώσεις, εξάγετε σε PDF ή εικόνες με το Aspose.Slides για Android, με παράδειγμα κώδικα. Δοκιμάστε το δωρεάν."
---
## **Εισαγωγή**

Το Aspose.Slides προσφέρει τη δυνατότητα μετατροπής παρουσιάσεων σε διάφορες μορφές, συμπεριλαμβανομένης της δημιουργίας φυλλαδίων για εκτύπωση σε λειτουργία Handout. Αυτή η λειτουργία σας επιτρέπει να ρυθμίσετε πώς θα εμφανίζονται πολλαπλές διαφάνειες σε μία σελίδα, καθιστώντας την χρήσιμη για συνέδρια, σεμινάρια και άλλα γεγονότα. Μπορείτε να ενεργοποιήσετε αυτή τη λειτουργία ορίζοντας τη μέθοδο `setSlidesLayoutOptions` στα interfaces [IPdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihtmloptions/), και [ITiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itiffoptions/) .

Για να ορίσετε τις διαστάσεις και τον προσανατολισμό της σελίδας του φυλλαδίου πριν από την εξαγωγή, δείτε [Notes Page Size](/slides/el/androidjava/notes-size/).

## **Εξαγωγή σε Λειτουργία Handout**

Για να ρυθμίσετε τη λειτουργία Handout, χρησιμοποιήστε το αντικείμενο [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/handoutlayoutingoptions/), το οποίο καθορίζει πόσες διαφάνειες τοποθετούνται σε μία σελίδα και άλλες παραμέτρους εμφάνισης.

Παρακάτω υπάρχει ένα παράδειγμα κώδικα που δείχνει πώς να μετατρέψετε μια παρουσίαση σε PDF σε λειτουργία Handout.

```java
import com.aspose.slides.*;

// Φόρτωση παρουσίασης.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Ορισμός επιλογών εξαγωγής.
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
Λάβετε υπόψη ότι η μέθοδος `setSlidesLayoutOptions` είναι διαθέσιμη μόνο για ορισμένες μορφές εξόδου, όπως PDF, HTML, TIFF, και όταν γίνεται απόδοση ως εικόνες.
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο μέγιστος αριθμός μικρογραφιών διαφάνειας ανά σελίδα στη λειτουργία Handout;**

Το Aspose.Slides υποστηρίζει [προεπιλογές](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/handouttype/) έως 9 μικρογραφίες ανά σελίδα με οριζόντια ή κάθετη διάταξη: 1, 2, 3, 4 (οριζόντια/κατακόρυφη), 6 (οριζόντια/κατακόρυφη) και 9 (οριζόντια/κατακόρυφη).

**Μπορώ να ορίσω προσαρμοσμένο πλέγμα, όπως 5 ή 8 διαφάνειες ανά σελίδα;**

Όχι. Ο αριθμός και η σειρά των μικρογραφιών ελέγχονται αυστηρά από την κλάση [HandoutType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/handouttype/), και δεν υποστηρίζονται αυθαίρετες διατάξεις.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο Handout;**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες χρησιμοποιώντας τη μέθοδο `setShowHiddenSlides` στις ρυθμίσεις εξαγωγής για τη ζητούμενη μορφή, όπως [PdfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/htmloptions/), ή [TiffOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/tiffoptions/).