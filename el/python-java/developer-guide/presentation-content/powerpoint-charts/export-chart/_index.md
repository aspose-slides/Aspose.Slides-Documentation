---
title: Εξαγωγή διαγραμμάτων παρουσίασης σε Python μέσω Java
linktitle: Εξαγωγή διαγράμματος
type: docs
weight: 90
url: /el/python-java/export-chart/
keywords:
- διάγραμμα
- διάγραμμα σε εικόνα
- διάγραμμα ως εικόνα
- εξαγωγή εικόνας διαγράμματος
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να εξάγετε διαγράμματα παρουσίασης με το Aspose.Slides για Python μέσω Java, υποστηρίζοντας μορφές PPT και PPTX, και να απλοποιήσετε την αναφορά σε οποιαδήποτε ροή εργασίας."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να εξάγετε ένα διάγραμμα από μια παρουσίαση ως εικόνα. Αυτό το άρθρο δείχνει πώς να λάβετε μια εικόνα από ένα διάγραμμα και να την αποθηκεύσετε, κάτι που είναι χρήσιμο όταν χρειάζεται να επαναχρησιμοποιήσετε τα οπτικά στοιχεία του διαγράμματος εκτός μιας παρουσίασης PowerPoint.

Εκτός από τη βασική διαδικασία εξαγωγής εικόνας, το άρθρο απαντά επίσης σε συχνές ερωτήσεις σχετικές με την εξαγωγή, όπως η αποθήκευση του περιεχομένου του διαγράμματος σε SVG, ο έλεγχος του μεγέθους εξόδου μέσω επιλογών απόδοσης, η φόρτωση γραμματοσειρών για τη διατήρηση της εμφάνισης ετικετών και υπομνήματος, καθώς και η διατήρηση της αρχικής μορφοποίησης της παρουσίασης όπως θέματα, στυλ, γεμίσεις και εφέ κατά την απόδοση.

## **Λήψη εικόνας διαγράμματος**
Το Aspose.Slides for Python via Java υποστηρίζει την εξαγωγή μιας εικόνας ενός συγκεκριμένου διαγράμματος. Το παρακάτω παράδειγμα δείχνει πώς γίνεται αυτό.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Μπορώ να εξάγω ένα διάγραμμα ως διανυσματικό (SVG) αντί για ραστερ εικόνα;**

Ναι. Ένα διάγραμμα είναι ένα σχήμα και τα περιεχόμενά του μπορούν να αποθηκευτούν σε SVG χρησιμοποιώντας τη [μέθοδο αποθήκευσης shape-to-SVG](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Πώς μπορώ να ορίσω το ακριβές μέγεθος του εξαγόμενου διαγράμματος σε εικονοστοιχεία;**

Χρησιμοποιήστε τις υπερφορτώσεις απόδοσης εικόνας που επιτρέπουν τον καθορισμό μεγέθους ή κλίμακας· η βιβλιοθήκη υποστηρίζει την απόδοση αντικειμένων με δεδομένες διαστάσεις/κλίμακα.

**Τι πρέπει να κάνω εάν οι γραμματοσειρές στις ετικέτες και στο υπόμνημα εμφανίζονται λανθασμένα μετά την εξαγωγή;**

[Φορτώστε τις απαιτούμενες γραμματοσειρές](/slides/el/python-java/custom-font/) μέσω του [FontsLoader](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsloader/) ώστε η απόδοση του διαγράμματος να διατηρεί τα μετρικά και την εμφάνιση του κειμένου.

**Η εξαγωγή σέβεται το θέμα, τα στυλ και τα εφέ του PowerPoint;**

Ναι. Ο μηχανισμός απόδοσης του Aspose.Slides ακολουθεί τη μορφοποίηση της παρουσίασης (θέματα, στυλ, γεμίσεις, εφέ), έτσι ότι η εμφάνιση του διαγράμματος διατηρείται.

**Πού μπορώ να βρω διαθέσιμες δυνατότητες απόδοσης/εξαγωγής πέρα από εικόνες διαγραμμάτων;**

Δείτε το [API](https://reference.aspose.com/slides/el/python-java/aspose.slides/)/[documentation](/slides/el/python-java/convert-powerpoint/) για τους προορισμούς εξόδου ([PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/el/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/el/python-java/convert-powerpoint-to-xps/), [HTML](/slides/el/python-java/convert-powerpoint-to-html/), κ.ά.) και τις σχετικές επιλογές απόδοσης.