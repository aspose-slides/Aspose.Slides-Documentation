---
title: Μετατροπή PPT και PPTX σε JPG σε Java
linktitle: PowerPoint σε JPG
type: docs
weight: 60
url: /el/java/convert-powerpoint-to-jpg/
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
- Java
- Aspose.Slides
description: "Μετατροπή διαφανειών PowerPoint (PPT, PPTX) σε εικόνες JPG υψηλής ποιότητας σε Java με Aspose.Slides για Java χρησιμοποιώντας γρήγορα, αξιόπιστα παραδείγματα κώδικα."
---
## **Εισαγωγή**

Η μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εικόνες JPG βοηθάει στην κοινή χρήση διαφανειών, στη βελτιστοποίηση της απόδοσης και στην ενσωμάτωση περιεχομένου σε ιστοτόπους ή εφαρμογές. Το Aspose.Slides επιτρέπει τη μετατροπή αρχείων PPTX, PPT και ODP σε εικόνες JPEG υψηλής ποιότητας. Αυτός ο οδηγός εξηγεί διάφορες μεθόδους μετατροπής.

Με αυτές τις δυνατότητες, είναι εύκολο να υλοποιήσετε το δικό σας πρόγραμμα προβολής παρουσιάσεων και να δημιουργήσετε ένα μικρογραφικό για κάθε διαφάνεια. Αυτό μπορεί να είναι χρήσιμο εάν θέλετε να προστατεύσετε τις διαφάνειες από αντιγραφή ή να παρουσιάσετε την παρουσίαση σε λειτουργία μόνο ανάγνωσης. Το Aspose.Slides σας επιτρέπει να μετατρέψετε ολόκληρη την παρουσίαση ή μια συγκεκριμένη διαφάνεια σε μορφές εικόνας.

## **Μετατροπή PowerPoint PPT/PPTX σε JPG**

1. Δημιουργήστε ένα στιγμιότυπο του τύπου [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε το αντικείμενο διαφάνειας του τύπου [ISlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide) από τη συλλογή [Presentation.getSlides()](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#getSlides--).
3. Δημιουργήστε το μικρογραφικό κάθε διαφάνειας και στη συνέχεια μετατρέψτε το σε JPG. Η μέθοδος [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide#getImage-float-float-) χρησιμοποιείται για τη λήψη μικρογραφικού μιας διαφάνειας, επιστρέφει ένα αντικείμενο [Images](https://reference.aspose.com/slides/el/java/com.aspose.slides/Images). Η μέθοδος [getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) πρέπει να κληθεί από την απαιτούμενη διαφάνεια του τύπου [ISlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide), όπου οι κλίμακες του προκύπτοντος μικρογραφικού περνούν στη μέθοδο.
4. Αφού λάβετε το μικρογραφικό της διαφάνειας, καλέστε τη μέθοδο [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) από το αντικείμενο μικρογραφικού. Περάστε το όνομα του αρχείου που προκύπτει και τη μορφή εικόνας σε αυτήν.

{{% alert color="primary" %}}

**Σημείωση**: Η μετατροπή PPT/PPTX σε JPG διαφέρει από τη μετατροπή σε άλλους τύπους στην Aspose.Slides API. Για άλλους τύπους, συνήθως χρησιμοποιείτε τη μέθοδο [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) αλλά εδώ χρειάζεστε τη μέθοδο [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Δημιουργεί εικόνα πλήρους κλίμακας
        IImage slideImage = sld.getImage(1f, 1f);

        // Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Μετατροπή PowerPoint PPT/PPTX σε JPG με Προσαρμοσμένες Διαστάσεις**

Για να αλλάξετε τη διάσταση του προκύπτοντος μικρογραφικού και της εικόνας JPG, μπορείτε να ορίσετε τις τιμές *ScaleX* και *ScaleY* περνώντας τις στις μεθόδους [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISlide#getImage-float-float-):

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Ορίζει διαστάσεις
    int desiredX = 1200;
    int desiredY = 800;
    // Λαμβάνει κλιμακωτές τιμές του X και του Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Δημιουργεί εικόνα πλήρους κλίμακας
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Αποθηκεύει την εικόνα στο δίσκο σε μορφή JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Απόδοση Σχολίων Κατά την Αποθήκευση Διαφανειών ως Εικόνες**

Το Aspose.Slides for Java παρέχει μια λειτουργία που σας επιτρέπει να αποδίδετε σχόλια στις διαφάνειες μιας παρουσίασης όταν μετατρέπετε αυτές τις διαφάνειες σε εικόνες. Αυτός ο κώδικας Java δείχνει τη λειτουργία:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Η Aspose παρέχει μια [ΔΩΡΕΑΝ εφαρμογή Collage στο web](https://products.aspose.app/slides/el/collage). Χρησιμοποιώντας αυτήν την διαδικτυακή υπηρεσία, μπορείτε να συγχωνεύσετε εικόνες [JPG σε JPG](https://products.aspose.app/slides/el/collage/jpg) ή PNG σε PNG, να δημιουργήσετε [πλέγματα φωτογραφιών](https://products.aspose.app/slides/el/collage/photo-grid) κ.ά.

Χρησιμοποιώντας τις ίδιες αρχές που περιγράφονται σε αυτό το άρθρο, μπορείτε να μετατρέψετε εικόνες από μορφή σε άλλη. Για περισσότερες πληροφορίες, δείτε τις παρακάτω σελίδες: μετατροπή [εικόνα σε JPG](https://products.aspose.com/slides/el/java/conversion/image-to-jpg/); μετατροπή [JPG σε εικόνα](https://products.aspose.com/slides/el/java/conversion/jpg-to-image/); μετατροπή [JPG σε PNG](https://products.aspose.com/slides/el/java/conversion/jpg-to-png/), μετατροπή [PNG σε JPG](https://products.aspose.com/slides/el/java/conversion/png-to-jpg/); μετατροπή [PNG σε SVG](https://products.aspose.com/slides/el/java/conversion/png-to-svg/), μετατροπή [SVG σε PNG](https://products.aspose.com/slides/el/java/conversion/svg-to-png/).

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζει αυτή η μέθοδος τη μαζική μετατροπή;**

Ναι, το Aspose.Slides επιτρέπει τη μαζική μετατροπή πολλαπλών διαφανειών σε JPG με μια μόνο λειτουργία.

**Υποστηρίζει η μετατροπή SmartArt, γραφήματα και άλλα σύνθετα αντικείμενα;**

Ναι, το Aspose.Slides αποδίδει όλο το περιεχόμενο, συμπεριλαμβανομένων SmartArt, γραφημάτων, πινάκων, σχημάτων κ.ά. Ωστόσο, η ακρίβεια απόδοσης μπορεί να διαφέρει ελαφρώς σε σύγκριση με το PowerPoint, ειδικά όταν χρησιμοποιούνται προσαρμοσμένες ή ελλιπείς γραμματοσειρές.

**Υπάρχουν περιορισμοί στον αριθμό των διαφανειών που μπορούν να υποβληθούν σε επεξεργασία;**

Το Aspose.Slides από μόνο του δεν θέτει αυστηρούς περιορισμούς στον αριθμό των διαφανών που μπορείτε να επεξεργαστείτε. Ωστόσο, ενδέχεται να αντιμετωπίσετε σφάλμα έλλειψης μνήμης όταν εργάζεστε με μεγάλες παρουσιάσεις ή εικόνες υψηλής ανάλυσης.

## **Δείτε επίσης**

Δείτε άλλες επιλογές για τη μετατροπή PPT/PPTX σε εικόνα όπως:

- [Μετατροπή PPT/PPTX σε SVG](/slides/el/java/render-a-slide-as-an-svg-image/).