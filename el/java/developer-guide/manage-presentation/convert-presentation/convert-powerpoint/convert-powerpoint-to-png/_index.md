---
title: Μετατροπή διαφανειών PowerPoint σε PNG με Java
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας γρήγορα με Aspose.Slides for Java, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να φορτώνετε αρχεία παρουσίασης σε μορφές όπως PPT, PPTX και ODP, να αποδίδετε τις διαφάνειες ως εικόνες και να αποθηκεύετε τα αποτελέσματα σε μορφή PNG.

Το άρθρο επίσης παρουσιάζει πώς να προσαρμόζετε τις παραγόμενες εικόνες PNG ορίζοντας τιμές κλίμακας ή καθορίζοντας το επιθυμητό πλάτος και ύψος.

## **Μετατροπή PowerPoint σε PNG**

Ακολουθήστε αυτά τα βήματα:

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Λάβετε το αντικείμενο διαφάνειας από τη συλλογή [Presentation.getSlides()](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--) υπό το interface [ISlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide).
3. Χρησιμοποιήστε τη μέθοδο [ISlide.getImage()](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide) για να λάβετε τη μικρογραφία για κάθε διαφάνεια.
4. Χρησιμοποιήστε τη μέθοδο [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) για να αποθηκεύσετε τη μικρογραφία της διαφάνειας σε μορφή PNG.

Αυτός ο κώδικας Java δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Εάν θέλετε να λάβετε αρχεία PNG με συγκεκριμένη κλίμακα, μπορείτε να ορίσετε τις τιμές για `desiredX` και `desiredY`, οι οποίες καθορίζουν τις διαστάσεις της προκύπτουσας μικρογραφίας.

Αυτός ο κώδικας Java επιδεικνύει τη περιγραφόμενη λειτουργία:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Εάν θέλετε να λάβετε αρχεία PNG με συγκεκριμένο μέγεθος, μπορείτε να περάσετε τα προτιμώμενα επιχειρήματα `width` και `height` για το `ImageSize`.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε ένα PowerPoint σε PNG καθορίζοντας το μέγεθος των εικόνων:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να εξάγω μόνο ένα συγκεκριμένο σχήμα (π.χ. γράφημα ή εικόνα) αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/java/create-shape-thumbnails/); μπορείτε να αποδώσετε ένα σχήμα σε εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι, αλλά [μην μοιράζεστε](/slides/el/java/multithreading/) ένα ενιαίο παρουσίαση μεταξύ νήματος. Χρησιμοποιήστε ξεχωριστό αντικείμενο ανά νήμα ή διαδικασία.

**Ποιες είναι οι περιορισμοί της δοκιμαστικής έκδοσης κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδγράφημα στις εικόνες εξόδου και επιβάλλει [άλλους περιορισμούς](/slides/el/java/licensing/) μέχρι να εφαρμοστεί άδεια.