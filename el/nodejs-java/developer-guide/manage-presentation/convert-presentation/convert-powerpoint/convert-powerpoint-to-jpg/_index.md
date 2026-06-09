---
title: Μετατροπή PPT και PPTX σε JPG σε JavaScript
linktitle: PowerPoint σε JPG
type: docs
weight: 60
url: /el/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε JPG
- παρουσίαση σε JPG
- διαφάνεια σε JPG
- PPT σε JPG
- PPTX σε JPG
- αποθήκευση PowerPoint ως JPG
- αποθήκευση παρουσίασης ως JPG
- αποθήκευση διαφάνειας ως JPG
- αποθήκευση PPT ως JPG
- αποθήκευση PPTX ως JPG
- εξαγωγή PPT σε JPG
- εξαγωγή PPTX σε JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint (PPT, PPTX) σε εικόνες JPG υψηλής ποιότητας με JavaScript χρησιμοποιώντας Aspose.Slides για Node.js μέσω Java, με γρήγορα και αξιόπιστα παραδείγματα κώδικα."
---
## **Εισαγωγή**

Η μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εικόνες JPG βοηθά στην κοινοποίηση των διαφανειών, στη βελτιστοποίηση της απόδοσης και στην ενσωμάτωση περιεχομένου σε ιστοσελίδες ή εφαρμογές. Το Aspose.Slides επιτρέπει τη μετατροπή αρχείων PPTX, PPT και ODP σε εικόνες JPEG υψηλής ποιότητας. Αυτός ο οδηγός εξηγεί διαφορετικές μεθόδους μετατροπής.

Με αυτές τις δυνατότητες, είναι εύκολο να υλοποιήσετε τον δικό σας προβολέα παρουσιάσεων και να δημιουργήσετε μια μικρογραφία για κάθε διαφάνεια. Αυτό μπορεί να είναι χρήσιμο εάν θέλετε να προστατεύσετε τις διαφάνειες από αντιγραφή ή να παρουσιάσετε την παρουσίαση σε λειτουργία μόνο για ανάγνωση. Το Aspose.Slides επιτρέπει τη μετατροπή ολόκληρης παρουσίασης ή μιας συγκεκριμένης διαφάνειας σε μορφές εικόνας.

## **Μετατροπή PowerPoint PPT/PPTX σε JPG**
Ακολουθούν τα βήματα για τη μετατροπή PPT/PPTX σε JPG:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) τύπου.
2. Αποκτήστε το αντικείμενο διαφάνειας τύπου [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide) από τη συλλογή [Presentation.getSlides()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getSlides--) .
3. Δημιουργήστε τη μικρογραφία κάθε διαφάνειας και στη συνέχεια μετατρέψτε την σε JPG. Η μέθοδος [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide#getImage-float-float-) χρησιμοποιείται για τη λήψη μικρογραφίας μιας διαφάνειας· επιστρέφει το αντικείμενο [Imagess](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Images) ως αποτέλεσμα. Η μέθοδος [getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) πρέπει να κληθεί από τη ζητούμενη διαφάνεια του τύπου [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide), οι κλίμακες της προκύπτουσας μικρογραφίας περνιούνται στη μέθοδο.
4. Αφού λάβετε τη μικρογραφία της διαφάνειας, καλέστε τη μέθοδο [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/#save) από το αντικείμενο μικρογραφίας. Περάστε σε αυτή το όνομα του αρχείου και τη μορφή εικόνας.

{{% alert color="primary" %}}
**Σημείωση**: Η μετατροπή PPT/PPTX σε JPG διαφέρει από τη μετατροπή σε άλλους τύπους στο Aspose.Slides API. Για άλλους τύπους, συνήθως χρησιμοποιείτε τη μέθοδο [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) , αλλά εδώ χρειάζεται η μέθοδος [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/#save) .
{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Δημιουργεί μια εικόνα πλήρους κλίμακας
        var slideImage = sld.getImage(1.0, 1.0);
        // Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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

## **Μετατροπή PowerPoint PPT/PPTX σε JPG με Προσαρμοσμένες Διαστάσεις**
Για να αλλάξετε τη διάσταση της προκύπτουσας μικρογραφίας και της εικόνας JPG, μπορείτε να ορίσετε τις τιμές *ScaleX* και *ScaleY* περνώντας τες στις μεθόδους [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Slide#getImage-float-float-) :

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Ορίζει τις διαστάσεις
    var desiredX = 1200;
    var desiredY = 800;
    // Λαμβάνει κλιμακωμένες τιμές του X και του Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Δημιουργεί μια εικόνα πλήρους κλίμακας
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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

## **Απόδοση Σχολίων κατά την αποθήκευση της Παρουσίασης σε Εικόνα**
Το Aspose.Slides για Node.js μέσω Java παρέχει μια δυνατότητα που σας επιτρέπει να αποδίδετε σχόλια στις διαφάνειες μιας παρουσίασης όταν μετατρέπετε αυτές τις διαφάνειες σε εικόνες. Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
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

{{% alert title="Tip" color="primary" %}}
Το Aspose παρέχει μια [ΔΩΡΕΑΝ εφαρμογή Collage στο web](https://products.aspose.app/slides/el/collage). Χρησιμοποιώντας αυτή την online υπηρεσία, μπορείτε να συγχωνεύσετε εικόνες [JPG σε JPG](https://products.aspose.app/slides/el/collage/jpg) ή PNG σε PNG, να δημιουργήσετε [πλέγματα φωτογραφιών](https://products.aspose.app/slides/el/collage/photo-grid), κ.ά. 
{{% /alert %}}

## **Δείτε επίσης**

Δείτε άλλες επιλογές για μετατροπή PPT/PPTX σε εικόνα όπως:

- [Μετατροπή PPT/PPTX σε SVG](/slides/el/nodejs-java/render-a-slide-as-an-svg-image/).

## **Συχνές Ερωτήσεις**

**Υποστηρίζει αυτή η μέθοδος τη μαζική μετατροπή;**

Ναι, το Aspose.Slides επιτρέπει τη μαζική μετατροπή πολλαπλών διαφανειών σε JPG σε μία ενέργεια.

**Υποστηρίζει η μετατροπή SmartArt, διαγράμματα και άλλα σύνθετα αντικείμενα;**

Ναι, το Aspose.Slides εμφανίζει όλο το περιεχόμενο, συμπεριλαμβανομένων των SmartArt, των διαγραμμάτων, των πινάκων, των σχημάτων κ.ά. Ωστόσο, η ακρίβεια απόδοσης μπορεί να διαφέρει ελαφρώς σε σχέση με το PowerPoint, ειδικά όταν χρησιμοποιούνται προσαρμοσμένες ή ελλείπουσες γραμματοσειρές.

**Υπάρχουν περιορισμοί στον αριθμό των διαφανειών που μπορούν να επεξεργαστούν;**

Το ίδιο το Aspose.Slides δεν επιβάλλει αυστηρούς περιορισμούς στον αριθμό των διαφανειών που μπορείτε να επεξεργαστείτε. Ωστόσο, μπορεί να αντιμετωπίσετε σφάλμα έλλειψης μνήμης όταν εργάζεστε με μεγάλες παρουσιάσεις ή εικόνες υψηλής ανάλυσης.