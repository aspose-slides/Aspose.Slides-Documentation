---
title: Δημιουργία μικρογραφιών σχημάτων παρουσίασης στο Android
linktitle: Μικρογραφίες Σχήματος
type: docs
weight: 70
url: /el/androidjava/create-shape-thumbnails/
keywords:
- μικρογραφία σχήματος
- εικόνα σχήματος
- απόδοση σχήματος
- απόδοση σχημάτων
- οπτικά όρια
- όρια σχήματος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχημάτων από διαφάνειες PowerPoint με Aspose.Slides για Android μέσω Java – δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Το Aspose.Slides for Android μέσω Java μπορεί να χρησιμοποιηθεί για τη δημιουργία αρχείων παρουσίασης στα οποία κάθε σελίδα αντιστοιχεί σε μια διαφάνεια. Οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Ωστόσο, οι προγραμματιστές μερικές φορές χρειάζονται να προβάλλουν τις εικόνες των σχημάτων ξεχωριστά σε προβολέα εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides for Android μέσω Java τους βοηθά να δημιουργήσουν μικρογραφίες των σχημάτων της διαφάνειας.

Σε αυτό το θέμα, θα δείξουμε πώς να δημιουργήσετε μικρογραφίες διαφάνειας σε διαφορετικές καταστάσεις:

- Δημιουργία μικρογραφίας σχήματος μέσα σε μια διαφάνεια.
- Δημιουργία μικρογραφίας σχήματος για σχήμα διαφάνειας με διαστάσεις που ορίζονται από τον χρήστη.
- Δημιουργία μικρογραφίας σχήματος στα όρια της εμφάνισης ενός σχήματος.

## **Δημιουργία μικρογραφίας σχήματος από διαφάνεια**
Για να δημιουργήσετε μια μικρογραφία σχήματος από οποιαδήποτε διαφάνεια χρησιμοποιώντας το Aspose.Slides for Android μέσω Java, ακολουθήστε τα παρακάτω:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά οποιασδήποτε διαφάνειας χρησιμοποιώντας το αναγνωριστικό ή το δείκτη της.
1. [Λάβετε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getImage--) της αναφερόμενης διαφάνειας σε προεπιλεγμένη κλίμακα.
1. Αποθηκεύστε την εικόνα μικρογραφίας στην προτιμώμενη μορφή εικόνας.

Αυτό το παράδειγμα κώδικα δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος από μια διαφάνεια:

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Δημιουργήστε εικόνα πλήρους κλίμακας
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία μικρογραφίας με προσαρμοσμένο συντελεστή κλιμάκωσης**
Για να δημιουργήσετε τη μικρογραφία σχήματος μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides for Android μέσω Java, ακολουθήστε τα παρακάτω:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά οποιασδήποτε διαφάνειας χρησιμοποιώντας το αναγνωριστικό ή το δείκτη της.
1. [Λάβετε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) της αναφερόμενης διαφάνειας με διαστάσεις που ορίζονται από τον χρήστη.
1. Αποθηκεύστε την εικόνα μικρογραφίας στην προτιμώμενη μορφή εικόνας.

Αυτό το παράδειγμα κώδικα δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος βασισμένη σε καθορισμένο συντελεστή κλιμάκωσης:

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Δημιουργία εικόνας πλήρους κλίμακας
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία μικρογραφίας εμφάνισης σχήματος βάσει ορίων**
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχημάτων επιτρέπει στους προγραμματιστές να παράγουν μια μικρογραφία εντός των ορίων της εμφάνισης του σχήματος. Λαμβάνει υπόψη όλες τις εφέ του σχήματος. Η παραγόμενη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας. Για να δημιουργήσετε μια μικρογραφία σχήματος διαφάνειας στα όρια της εμφάνισής του, ακολουθήστε τα παρακάτω:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά οποιασδήποτε διαφάνειας χρησιμοποιώντας το αναγνωριστικό ή το δείκτη της.
1. Λάβετε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με τα όρια του σχήματος ως εμφάνιση.
1. Αποθηκεύστε την εικόνα μικρογραφίας στην προτιμώμενη μορφή εικόνας.

Αυτό το παράδειγμα κώδικα βασίζεται στα παραπάνω βήματα:

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Δημιουργία εικόνας πλήρους κλίμακας
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Λήψη των πραγματικών οπτικών ορίων ενός σχήματος**

Οι ιδιότητες πλαισίου του [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) — οι μέθοδοι `getX()`, `getY()`, `getWidth()` και `getHeight()` — περιγράφουν το ορθογώνιο που αποθηκεύεται στο μοντέλο παρουσίασης. Το περιεχόμενο που πραγματικά αποδίδεται μπορεί να εκτείνεται πέρα από αυτό το πλαίσιο ή να καταλαμβάνει διαφορετικό ευθυγραμμισμένο ορθογώνιο. Η περιστροφή, τα περιγράμματα, τα βέλη, η διάταξη και υπερχείλιση κειμένου, η παραγόμενη γεωμετρία SmartArt και άλλα εφέ απόδοσης μπορούν όλα να αλλάξουν την κατειλημμένη περιοχή.

Χρησιμοποιήστε το [Shape.getVisualBounds](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getVisualBounds--) για να υπολογίσετε αυτήν την κατειλημμένη περιοχή χωρίς να δημιουργήσετε εικόνα. Η μέθοδος επιστρέφει ένα [RectF](https://developer.android.com/reference/android/graphics/RectF) σε συντεταγμένες διαφάνειας. Το επιστρεφόμενο ορθογώνιο δεν περικοπεί στη διαφάνεια, έτσι οι συντεταγμένες του μπορούν να είναι αρνητικές όταν το περιεχόμενο εκτείνεται πέρα από το σημείο προέλευσης της διαφάνειας.

[Shape.getVisualBounds](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getVisualBounds--) δεν είναι προς το παρόν δηλωμένο από τη διεπαφή [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/). Συνεπώς, διατηρήστε το σχήμα που λαμβάνετε από τη συλλογή σχημάτων της διαφάνειας ως τιμή διεπαφής και κάντε cast μόνο όταν καλείτε τη μέθοδο.

Το παρακάτω παράδειγμα λαμβάνει και συγκρίνει τα όρια πλαισίου και τα οπτικά όρια:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Το ίδιο [RectF](https://developer.android.com/reference/android/graphics/RectF) μπορεί να χρησιμοποιηθεί για να ευθυγραμμιστούν τα κοντινά σχήματα προς αριστερή, δεξιά, επάνω ή κάτω πλευρά του· να διατηρηθεί επαρκής χώρος σε δημιουργημένη διάταξη· ή να εντοπιστεί περιεχόμενο εκτός επιτρεπόμενης περιοχής. Τα οπτικά όρια είναι ιδιαίτερα χρήσιμα για SmartArt, πλαίσια κειμένου, βέλη, εικόνες, περιστραμένα σχήματα και ομαδικά σχήματα, όπου το αποθηκευμένο πλαίσιο μπορεί να μην αντιπροσωπεύει το πλήρες αποτέλεσμα απόδοσης.

Χρησιμοποιήστε το [Shape.getVisualBounds](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getVisualBounds--) όταν χρειάζεστε συντεταγμένες για διάταξη ή επικύρωση και δεν χρειάζεστε bitmap. Χρησιμοποιήστε το [IShape.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getImage--) όταν χρειάζεται να αποδώσετε το σχήμα. Με το [ShapeThumbnailBounds](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapethumbnailbounds/), το `ShapeThumbnailBounds.Shape` καθορίζει το μέγεθος της εικόνας από τα όρια του σχήματος, συμπεριλαμβανομένων των ρυθμίσεων περιγράμματος, ενώ το `ShapeThumbnailBounds.Appearance` το καθορίζει από την εμφάνιση του σχήματος και περιορίζει το αποτέλεσμα στα όρια της διαφάνειας. Αντιθέτως, το [Shape.getVisualBounds](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getVisualBounds--) επιστρέφει μόνο το υπολογισμένο ορθογώνιο και δεν το περικόπτεται στη διαφάνεια.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποιοι μορφές εικόνας μπορούν να χρησιμοποιηθούν κατά την αποθήκευση μικρογραφιών σχήματος;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imageformat/), και άλλες. Τα σχήματα μπορούν επίσης να [εξάγονται ως διανυσματικό SVG](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

**Ποια είναι η διαφορά μεταξύ των ορίων Shape και Appearance κατά την απόδοση μιας μικρογραφίας;**

`Shape` χρησιμοποιεί τη γεωμετρία του σχήματος· `Appearance` λαμβάνει υπόψη τα [οπτικά εφέ](/slides/el/androidjava/shape-effect/) (σκιές, λαμπρότητα κ.λπ.).

**Τι συμβαίνει εάν ένα σχήμα σημειωθεί ως κρυφό; Θα εξακολουθήσει να αποδίδεται ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφής κατάστασης επηρεάζει την προβολή της παρουσίασης, αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται τα ομαδικά σχήματα, τα διαγράμματα, το SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Οποιοδήποτε αντικείμενο που αντιπροσωπεύεται ως [Shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/) και [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι συστημικά εγκατεστημένες γραμματοσειρές την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/androidjava/custom-font/) (ή να [ρυθμίσετε τις αντικαταστάσεις γραμματοσειρών](/slides/el/androidjava/font-substitution/)) για να αποφύγετε ανεπιθύμητες εναλλακτικές και την επαναδιάταξη κειμένου.