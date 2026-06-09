---
title: Καθορισμός Προεπιλεγμένων Γραμματοσειρών Παρουσίασης σε JavaScript
linktitle: Προεπιλεγμένη Γραμματοσειρά
type: docs
weight: 30
url: /el/nodejs-java/default-font/
keywords:
- προεπιλεγμένη γραμματοσειρά
- κανονική γραμματοσειρά
- συνηθισμένη γραμματοσειρά
- ασιατική γραμματοσειρά
- εξαγωγή PDF
- εξαγωγή XPS
- εξαγωγή εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ορίστε τις προεπιλεγμένες γραμματοσειρές στο Aspose.Slides για Node.js μέσω Java ώστε να εξασφαλίσετε τη σωστή μετατροπή PowerPoint (PPT, PPTX) και OpenDocument (ODP) σε PDF, XPS και εικόνες."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να καθορίσετε τις προεπιλεγμένες γραμματοσειρές που χρησιμοποιούνται όταν αποδίδεται μια παρουσίαση. Αυτό είναι χρήσιμο κατά τη δημιουργία μικρογραφιών διαφανειών ή την εξαγωγή μιας παρουσίασης σε μορφές όπως PDF και XPS. Οι προεπιλεγμένες γραμματοσειρές ρυθμίζονται μέσω `LoadOptions` πριν φορτωθεί η παρουσίαση.

Η μέθοδος `setDefaultRegularFont` ορίζει τη προεπιλεγμένη γραμματοσειρά για κανονικό κείμενο, ενώ η `setDefaultAsianFont` ορίζει τη προεπιλεγμένη γραμματοσειρά για ασιατικό κείμενο. Αφού οριστούν αυτές οι επιλογές, η παρουσίαση μπορεί να φορτωθεί και να αποδοθεί χρησιμοποιώντας τις καθορισμένες γραμματοσειρές.

## **Χρήση Προεπιλεγμένων Γραμματοσειρών για Απόδοση Παρουσίασης**
Aspose.Slides σας επιτρέπει να ορίσετε τη προεπιλεγμένη γραμματοσειρά για την απόδοση της παρουσίασης σε PDF, XPS ή μικρογραφίες. Αυτό το άρθρο δείχνει πώς να ορίσετε DefaultRegularFont και DefaultAsianFont ως προεπιλεγμένες γραμματοσειρές. Ακολουθήστε τα παρακάτω βήματα για τη φόρτωση γραμματοσειρών από εξωτερικούς φακέλους χρησιμοποιώντας Aspose.Slides for Node.js μέσω Java API:

1. Δημιουργήστε μια παρουσία του [LoadOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LoadOptions).
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) στην επιθυμητή γραμματοσειρά σας. Στο παρακάτω παράδειγμα, χρησιμοποίησα Wingdings.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) στην επιθυμητή γραμματοσειρά σας. Χρησιμοποίησα Wingdings στο επόμενο δείγμα.
4. Φορτώστε την παρουσίαση χρησιμοποιώντας Presentation και ορίζοντας τις επιλογές φόρτωσης.
5. Τώρα, δημιουργήστε τη μικρογραφία διαφάνειας, PDF και XPS για να επαληθεύσετε τα αποτελέσματα.

Η υλοποίηση του παραπάνω παρατίθεται παρακάτω.

```javascript
// Χρησιμοποιήστε επιλογές φόρτωσης για να ορίσετε τις προεπιλεγμένες κανονικές και ασιατικές γραμματοσειρές
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Φόρτωση της παρουσίασης
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Δημιουργία μικρογραφίας διαφάνειας
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // αποθήκευση της εικόνας στον δίσκο.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Δημιουργία PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Δημιουργία XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Τι ακριβώς επηρεάζουν οι DefaultRegularFont και DefaultAsianFont—μόνο η εξαγωγή, ή και οι μικρογραφίες, PDF, XPS, HTML και SVG;**

Συμμετέχουν στη διαδικασία απόδοσης για όλα τα υποστηριζόμενα αποτελέσματα. Αυτό περιλαμβάνει μικρογραφίες διαφανειών, [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/el/nodejs-java/convert-powerpoint-to-xps/), [raster images](/slides/el/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/), και [SVG](/slides/el/nodejs-java/render-a-slide-as-an-svg-image/), επειδή το Aspose.Slides χρησιμοποιεί την ίδια λογική διάταξης και επίλυσης γλυφών για αυτούς τους στόχους.

**Εφαρμόζονται οι προεπιλεγμένες γραμματοσειρές όταν διαβάζετε και αποθηκεύετε ένα PPTX χωρίς καμία απόδοση;**

Όχι. Οι προεπιλεγμένες γραμματοσειρές έχουν σημασία όταν το κείμενο πρέπει να μετρηθεί και να σχεδιαστεί. Μια απλή ανοίγμα‑αποθήκευση μιας παρουσίασης δεν αλλάζει τις αποθηκευμένες εκτελεστικές γραμματοσειρές ή τη δομή του αρχείου. Οι προεπιλεγμένες γραμματοσειρές έρχονται σε δράση κατά τις λειτουργίες που αποδίδουν ή επανατοποθετούν το κείμενο.

**Εάν προσθέσω τους δικούς μου φακέλους γραμματοσειρών ή παρέχω γραμματοσειρές από τη μνήμη, θα ληφθούν υπόψη κατά την επιλογή των προεπιλεγμένων γραμματοσειρών;**

Ναι. Οι [Custom font sources](/slides/el/nodejs-java/custom-font/) επεκτείνουν τον κατάλογο διαθέσιμων οικογενειών και γλυφών που μπορεί να χρησιμοποιήσει η μηχανή. Οι προεπιλεγμένες γραμματοσειρές και οποιοσδήποτε [fallback rules](/slides/el/nodejs-java/fallback-font/) θα επιλύονται πρώτα έναντι αυτών των πηγών, προσφέροντας πιο αξιόπιστη κάλυψη σε διακομιστές και σε containers.

**Θα επηρεάσουν οι προεπιλεγμένες γραμματοσειρές τις μετρικές κειμένου (kerning, advances) και επομένως τις διακοπές γραμμής και τη συρραφή;**

Ναι. Η αλλαγή της γραμματοσειράς αλλάζει τις μετρικές των γλυφών και μπορεί να τροποποιήσει τις διακοπές γραμμής, τη συρραφή και την σελιδοποίηση κατά την απόδοση. Για σταθερότητα διάταξης, [embed the original fonts](/slides/el/nodejs-java/embedded-font/) ή επιλέξτε προεπιλεγμένες και εναλλακτικές οικογένειες που είναι μετρικά συμβατές.

**Υπάρχει κάποιο όφελος στο να ορίσετε προεπιλεγμένες γραμματοσειρές εάν όλες οι γραμματοσειρές της παρουσίασης είναι ενσωματωμένες;**

Συχνά δεν είναι απαραίτητο, επειδή οι [embedded fonts](/slides/el/nodejs-java/embedded-font/) ήδη εξασφαλίζουν ομοιόμορφη εμφάνιση. Οι προεπιλεγμένες γραμματοσειρές εξακολουθούν να χρησιμεύουν ως εφεδρική λύση για χαρακτήρες που δεν καλύπτονται από το ενσωματωμένο υποσύνολο ή όταν ένα αρχείο συνδυάζει ενσωματωμένο και μη ενσωματωμένο κείμενο.