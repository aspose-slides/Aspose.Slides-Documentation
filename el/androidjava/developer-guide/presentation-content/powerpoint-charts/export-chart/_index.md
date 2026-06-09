---
title: "Εξαγωγή Διαγραμμάτων Παρουσίασης σε Android"
linktitle: "Εξαγωγή Διαγράμματος"
type: docs
weight: 90
url: /el/androidjava/export-chart/
keywords:
  - διάγραμμα
  - διάγραμμα σε εικόνα
  - διάγραμμα ως εικόνα
  - εξαγωγή εικόνας διαγράμματος
  - PowerPoint
  - παρουσίαση
  - Android
  - Java
  - Aspose.Slides
description: "Μάθετε πώς να εξάγετε διαγράμματα παρουσίασης με το Aspose.Slides για Android μέσω Java, υποστηρίζοντας μορφές PPT και PPTX, και να βελτιώσετε την αναφορά σε οποιαδήποτε ροή εργασιών."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να εξάγετε ένα διάγραμμα από μια παρουσίαση ως εικόνα. Αυτό το άρθρο δείχνει πώς να λάβετε μια εικόνα από ένα διάγραμμα και να την αποθηκεύσετε, κάτι που είναι χρήσιμο όταν χρειάζεται να επαναχρησιμοποιήσετε τα γραφικά του διαγράμματος εκτός μιας παρουσίασης PowerPoint.

Εκτός της βασικής ροής εργασίας εξαγωγής εικόνας, το άρθρο επίσης αντιμετωπίζει συνήθεις ερωτήσεις σχετικά με την εξαγωγή, όπως η αποθήκευση του περιεχομένου του διαγράμματος σε SVG, ο έλεγχος του μεγέθους εξόδου μέσω επιλογών απόδοσης, η φόρτωση γραμματοσειρών για τη διατήρηση της εμφάνισης των ετικετών και του υπομνήματος, και η διατήρηση της αρχικής μορφοποίησης της παρουσίασης, όπως θέματα, στυλ, γεμίσματα και εφέ, κατά την απόδοση.

## **Λήψη Εικόνας Διαγράμματος**
Το Aspose.Slides for Android μέσω Java παρέχει υποστήριξη για την εξαγωγή εικόνας συγκεκριμένου διαγράμματος. Παρατίθεται παρακάτω ένα παράδειγμα.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εξάγω ένα διάγραμμα ως διανυσματικό (SVG) αντί για ραστερ εικόνα;**

Ναι. Ένα διάγραμμα είναι ένα σχήμα, και το περιεχόμενό του μπορεί να αποθηκευτεί σε SVG χρησιμοποιώντας τη [μέθοδο αποθήκευσης shape-to-SVG](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Πώς μπορώ να ορίσω το ακριβές μέγεθος του εξαγόμενου διαγράμματος σε pixel;**

Χρησιμοποιήστε τις υπερφορτώσεις απόδοσης εικόνας που επιτρέπουν τον καθορισμό του μεγέθους ή της κλίμακας — η βιβλιοθήκη υποστηρίζει την απόδοση αντικειμένων με δεδομένες διαστάσεις/κλίμακα.

**Τι πρέπει να κάνω εάν οι γραμματοσειρές στις ετικέτες και το υπόμνημα φαίνονται λανθασμένα μετά την εξαγωγή;**

[Φορτώστε τις απαιτούμενες γραμματοσειρές](/slides/el/androidjava/custom-font/) μέσω του [FontsLoader](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/) ώστε η απόδοση του διαγράμματος να διατηρεί τις μετρήσεις και την εμφάνιση του κειμένου.

**Τηρεί η εξαγωγή το θέμα, τα στυλ και τα εφέ του PowerPoint;**

Ναι. Ο μηχανισμός απόδοσης του Aspose.Slides ακολουθεί τη μορφοποίηση της παρουσίασης (θέματα, στυλ, γεμίσματα, εφέ), έτσι η εμφάνιση του διαγράμματος διατηρείται.

**Πού μπορώ να βρω διαθέσιμες δυνατότητες απόδοσης/εξαγωγής πέρα από τις εικόνες διαγράμματος;**

Δείτε το [API](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/)/[τεκμηρίωση](/slides/el/androidjava/convert-powerpoint/) για τους προορισμούς εξόδου ([PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/el/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/el/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/el/androidjava/convert-powerpoint-to-html/), κ.λπ.) και τις σχετικές επιλογές απόδοσης.