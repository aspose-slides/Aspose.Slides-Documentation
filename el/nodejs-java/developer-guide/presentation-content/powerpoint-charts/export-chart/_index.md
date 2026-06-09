---
title: Εξαγωγή Γραφημάτων Παρουσίασης σε JavaScript
linktitle: Εξαγωγή Γραφήματος
type: docs
weight: 90
url: /el/nodejs-java/export-chart/
keywords:
- γράφημα
- γράφημα σε εικόνα
- γράφημα ως εικόνα
- εξαγωγή εικόνας γραφήματος
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να εξάγετε γραφήματα παρουσίασης με το Aspose.Slides for Node.js μέσω Java, υποστηρίζοντας μορφές PPT και PPTX, και να ενσωματώσετε την αναφορά σε οποιαδήποτε ροή εργασίας."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να εξάγετε ένα γράφημα από μια παρουσίαση ως εικόνα. Αυτό το άρθρο δείχνει πώς να λάβετε μια εικόνα από ένα γράφημα και να την αποθηκεύσετε, κάτι που είναι χρήσιμο όταν χρειάζεται να επαναχρησιμοποιήσετε τα γραφικά του γραφήματος εκτός μιας παρουσίασης PowerPoint.

## **Απόκτηση εικόνας γραφήματος**
Το Aspose.Slides for Node.js μέσω Java παρέχει υποστήριξη για εξαγωγή εικόνας συγκεκριμένου γραφήματος. Το παρακάτω παράδειγμα δίνεται.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να εξάγω ένα γράφημα ως διανυσματική (SVG) εικόνα αντί για ραστερ εικόνα;**

Ναι. Ένα γράφημα είναι σχήμα, και το περιεχόμενό του μπορεί να αποθηκευτεί σε SVG χρησιμοποιώντας τη [μέθοδο αποθήκευσης shape-to-SVG](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/writeassvg/).

**Πώς μπορώ να ορίσω το ακριβές μέγεθος του εξαγόμενου γραφήματος σε εικονοστοιχεία;**

Χρησιμοποιήστε τις υπερφορτώσεις απόδοσης εικόνας που σας επιτρέπουν να καθορίσετε μέγεθος ή κλίμακα — η βιβλιοθήκη υποστηρίζει απόδοση αντικειμένων με δεδομένες διαστάσεις/κλίμακα.

**Τι πρέπει να κάνω αν οι γραμματοσειρές στις ετικέτες και στο υπόμνημα εμφανίζονται εσφαλμένα μετά την εξαγωγή;**

[Φορτώστε τις απαιτούμενες γραμματοσειρές](/slides/el/nodejs-java/custom-font/) μέσω του [FontsLoader](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/) ώστε η απόδοση του γραφήματος να διατηρεί τις μετρικές και την εμφάνιση του κειμένου.

**Τηρεί η εξαγωγή το θέμα, τα στυλ και τα εφέ του PowerPoint;**

Ναί. Η μηχανή απόδοσης του Aspose.Slides ακολουθεί τη μορφοποίηση της παρουσίασης (θέματα, στυλ, γεμίσεις, εφέ), έτσι διατηρείται η εμφάνιση του γραφήματος.

**Πού μπορώ να βρω διαθέσιμες δυνατότητες απόδοσης/εξαγωγής εκτός των εικόνων γραφημάτων;**

Δείτε το [API](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/)/[documentation](/slides/el/nodejs-java/convert-powerpoint/) για τους προορισμούς εξόδου ([PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/el/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/el/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/), κ.λπ.) και τις σχετικές επιλογές απόδοσης.