---
title: Προσαρμόστε τους Πίνακες Δεδομένων Γραφημάτων σε Παρουσιάσεις στο Android
linktitle: Πίνακας Δεδομένων
type: docs
url: /el/androidjava/chart-data-table/
keywords:
- δεδομένα γραφήματος
- πίνακας δεδομένων
- ιδιότητες γραμματοσειράς
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσαρμόστε τους πίνακες δεδομένων γραφημάτων σε Java για PPT και PPTX με το Aspose.Slides για Android προκειμένου να ενισχύσετε την αποδοτικότητα και την ελκυστικότητα στις παρουσιάσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με πίνακες δεδομένων γραφημάτων στο Aspose.Slides. Δείχνει πώς να εμφανίσετε έναν πίνακα δεδομένων για ένα γράφημα και να προσαρμόσετε τη μορφοποίηση κειμένου του ορίζοντας ιδιότητες γραμματοσειράς όπως έντονη μορφή και ύψος γραμματοσειράς. Το παράδειγμα δείχνει τη φόρτωση μιας παρουσίασης, την προσθήκη γραφήματος, την ενεργοποίηση του πίνακα δεδομένων του γραφήματος, την εφαρμογή ρυθμίσεων γραμματοσειράς και την αποθήκευση της ενημερωμένης παρουσίασης.

## **Ορισμός Ιδιοτήτων Γραμματοσειράς για Πίνακα Δεδομένων Γραφήματος**
Το Aspose.Slides για Android μέσω Java παρέχει υποστήριξη για αλλαγή χρώματος των κατηγοριών σε χρώμα σειράς. 

1. Δημιουργήστε ένα αντικείμενο κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Προσθέστε γράφημα στη διαφάνεια.
1. Ορίστε τον πίνακα γραφήματος.
1. Ορίστε το ύψος γραμματοσειράς.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Παράδειγμα δείγματος παρέχεται παρακάτω. 

```java
// Δημιουργία κενής παρουσίασης
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εμφανίζω μικρά κλειδιά υπομνήματος δίπλα στις τιμές στον πίνακα δεδομένων του γραφήματος;**

Ναι. Ο πίνακας δεδομένων υποστηρίζει [legend keys](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), και μπορείτε να τα ενεργοποιήσετε ή να τα απενεργοποιήσετε.

**Θα διατηρηθεί ο πίνακας δεδομένων κατά την εξαγωγή της παρουσίασης σε PDF, HTML ή εικόνες;**

Ναι. Το Aspose.Slides αποδίδει το γράφημα ως μέρος της διαφάνειας, έτσι το εξαγόμενο [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/el/androidjava/convert-powerpoint-to-html/)/[image](/slides/el/androidjava/convert-powerpoint-to-png/) περιλαμβάνει το γράφημα με τον πίνακα δεδομένων του.

**Υποστηρίζονται πίνακες δεδομένων για γραφήματα που προέρχονται από αρχείο προτύπου;**

Ναι. Για οποιοδήποτε γράφημα που φορτώνεται από υπάρχουσα παρουσίαση ή πρότυπο, μπορείτε να ελέγξετε και να αλλάξετε εάν ένας πίνακας δεδομένων [εμφανίζεται](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/#hasDataTable--) χρησιμοποιώντας τις ιδιότητες του γραφήματος.

**Πώς μπορώ γρήγορα να βρω ποια γραφήματα σε ένα αρχείο έχουν ενεργοποιημένο τον πίνακα δεδομένων;**

Εξετάστε την ιδιότητα κάθε γραφήματος που δείχνει εάν ο πίνακας δεδομένων [εμφανίζεται](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/#hasDataTable--) και επαναλάβετε τις διαφάνειες για να εντοπίσετε τα γραφήματα όπου είναι ενεργοποιημένος.