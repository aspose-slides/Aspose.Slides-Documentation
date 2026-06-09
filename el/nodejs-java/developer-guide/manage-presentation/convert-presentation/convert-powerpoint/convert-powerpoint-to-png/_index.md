---
title: Μετατροπή διαφανειών PowerPoint σε PNG με JavaScript
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/nodejs-java/convert-powerpoint-to-png/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PNG
- παρουσίαση σε PNG
- διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- αποθήκευση PPT ως PNG
- αποθήκευση PPTX ως PNG
- εξαγωγή PPT σε PNG
- εξαγωγή PPTX σε PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας με JavaScript γρήγορα χρησιμοποιώντας το Aspose.Slides για Node.js, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να φορτώνετε αρχεία παρουσίασης σε μορφές όπως PPT, PPTX και ODP, να αποδίδετε τις διαφάνειες ως εικόνες και να αποθηκεύετε τα αποτελέσματα σε μορφή PNG.

Το άρθρο επίσης δείχνει πώς να προσαρμόσετε τις παραγόμενες εικόνες PNG ορίζοντας τιμές κλίμακας ή καθορίζοντας το επιθυμητό πλάτος και ύψος.

## **Μετατροπή PowerPoint σε PNG**

Ακολουθήστε αυτά τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε το αντικείμενο διαφάνειας από τη συλλογή που επιστρέφεται από τη μέθοδο [Presentation.getSlides()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) στην κλάση [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide).
3. Χρησιμοποιήστε τη μέθοδο [Slide.getImage()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide) για να λάβετε τη μικρογραφία για κάθε διαφάνεια.
4. Χρησιμοποιήστε τη μέθοδο [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/#save) για να αποθηκεύσετε τη μικρογραφία της διαφάνειας σε μορφή PNG.

Αυτός ο κώδικας JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PNG:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Εάν θέλετε να αποκτήσετε αρχεία PNG με συγκεκριμένη κλίμακα, μπορείτε να ορίσετε τις τιμές για `desiredX` και `desiredY`, που καθορίζουν τις διαστάσεις της παραγόμενης μικρογραφίας.

Αυτός ο κώδικας σε JavaScript επιδεικνύει τη περιγραφόμενη λειτουργία:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Εάν θέλετε να αποκτήσετε αρχεία PNG με συγκεκριμένο μέγεθος, μπορείτε να περάσετε τα προτιμώμενα ορίσματα `width` και `height` για το `ImageSize`.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε ένα PowerPoint σε PNG καθορίζοντας το μέγεθος των εικόνων:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να εξάγω μόνο ένα συγκεκριμένο σχήμα (π.χ., διάγραμμα ή εικόνα) αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει τη δημιουργία μικρογραφιών για μεμονωμένα σχήματα· μπορείτε να αποδώσετε ένα σχήμα σε εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι, αλλά μην μοιράζεστε ένα μόνο στιγμιότυπο παρουσίασης μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστό στιγμιότυπο ανά νήμα ή διαδικασία.

**Ποιες είναι οι περιορισμοί της δοκιμαστικής έκδοσης κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδάτινο σήμα στις εξαγόμενες εικόνες και επιβάλλει άλλους περιορισμούς μέχρι να εφαρμοστεί άδεια.