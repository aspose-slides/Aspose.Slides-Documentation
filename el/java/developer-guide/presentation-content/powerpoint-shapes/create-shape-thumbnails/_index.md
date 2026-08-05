---
title: Δημιουργία μικρογραφιών σχημάτων παρουσίασης σε Java
linktitle: Μικρογραφίες Σχημάτων
type: docs
weight: 70
url: /el/java/create-shape-thumbnails/
keywords:
- μικρογραφία σχήματος
- εικόνα σχήματος
- απόδοση σχήματος
- απόδοση σχήματος
- οπτικά όρια
- όρια σχήματος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχήματος από διαφάνειες PowerPoint με το Aspose.Slides for Java – δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Το Aspose.Slides for Java μπορεί να χρησιμοποιηθεί για τη δημιουργία αρχείων παρουσίασης στα οποία κάθε σελίδα αντιστοιχεί σε μία διαφάνεια. Οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Ωστόσο, μερικές φορές οι προγραμματιστές χρειάζεται να προβάλλουν τις εικόνες των σχημάτων ξεχωριστά σε προβολέα εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides for Java τους βοηθά να δημιουργήσουν μικρογραφίες των σχημάτων της διαφάνειας.

Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε μικρογραφίες διαφανειών με διαφορετικούς τρόπους:

- Δημιουργία μικρογραφίας σχήματος εντός μιας διαφάνειας.
- Δημιουργία μικρογραφίας σχήματος για σχήμα διαφάνειας με διαστάσεις καθορισμένες από τον χρήστη.
- Δημιουργία μικρογραφίας σχήματος μέσα στα όρια της εμφάνισης του σχήματος.

## **Δημιουργία μικρογραφίας σχήματος από μια διαφάνεια**
Για να δημιουργήσετε μια μικρογραφία σχήματος από οποιαδήποτε διαφάνεια χρησιμοποιώντας το Aspose.Slides for Java, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το ευρετήριο της.
3. [Αποκτήστε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getImage--) της αναφερόμενης διαφάνειας με προεπιλεγμένη κλίμακα.
4. Αποθηκεύστε την εικόνα μικρογραφίας στη προτιμώμενη μορφή εικόνας.

Αυτό το παράδειγμα κώδικα δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος από μια διαφάνεια:

```java
// Δημιουργήστε ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Δημιουργήστε μια εικόνα πλήρους κλίμακας
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Αποθηκεύστε την εικόνα στον δίσκο σε μορφή PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία μικρογραφίας με παράγοντα κλίμακας καθορισμένο από τον χρήστη**
Για να δημιουργήσετε τη μικρογραφία σχήματος μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides for Java, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το ευρετήριο της.
3. [Αποκτήστε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getImage-int-float-float-) της αναφερόμενης διαφάνειας με διαστάσεις καθορισμένες από τον χρήστη.
4. Αποθηκεύστε την εικόνα μικρογραφίας στη προτιμώμενη μορφή εικόνας.

Αυτό το παράδειγμα κώδικα δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος με βάση έναν καθορισμένο παράγοντα κλιμάκωσης:

```java
// Δημιουργία μιας κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Δημιουργία εικόνας πλήρους κλίμακας
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Αποθήκευση της εικόνας στον δίσκο σε μορφή PNG
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
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχημάτων επιτρέπει στους προγραμματιστές να δημιουργήσουν μια μικρογραφία στα όρια της εμφάνισης του σχήματος. Λαμβάνει υπόψη όλες τις εφέ του σχήματος. Η δημιουργημένη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας. Για να δημιουργήσετε μια μικρογραφία σχήματος μιας διαφάνειας στα όρια της εμφάνισής του, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το ευρετήριο της.
3. Αποκτήστε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με τα όρια του σχήματος ως εμφάνιση.
4. Αποθηκεύστε την εικόνα μικρογραφίας στη προτιμώμενη μορφή εικόνας.

Αυτό το παράδειγμα κώδικα βασίζεται στα παραπάνω βήματα:

```java
// Δημιουργία μιας κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Δημιουργία εικόνας πλήρους κλίμακας
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Αποθήκευση της εικόνας στον δίσκο σε μορφή PNG
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

Οι ιδιότητες πλαισίου του [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) — οι μέθοδοι `getX()`, `getY()`, `getWidth()`, και `getHeight()` — περιγράφουν το ορθογώνιο που αποθηκεύεται στο μοντέλο παρουσίασης. Το περιεχόμενο που στην πραγματικότητα αποδίδεται μπορεί να εκτείνεται πέρα από αυτό το πλαίσιο ή να καταλαμβάνει διαφορετικό ορθογώνιο ευθυγραμμισμένο με τους άξονες. Η περιστροφή, τα περιγράμματα, τα βέλη, η διάταξη και η υπερχείλιση κειμένου, η παραγόμενη γεωμετρία SmartArt και άλλα εφέ απόδοσης μπορούν όλα να αλλάξουν το καταλαμβανόμενο χώρο.

Χρησιμοποιήστε [Shape.getVisualBounds](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getVisualBounds--) για να υπολογίσετε αυτόν τον καταλαμβανόμενο χώρο χωρίς δημιουργία εικόνας. Η μέθοδος επιστρέφει ένα [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) σε συντεταγμένες διαφάνειας. Το επιστρεφόμενο ορθογώνιο δεν περικόπτεται στη διαφάνεια, οπότε οι συντεταγμένες του μπορούν να είναι αρνητικές όταν το περιεχόμενο εκτείνεται πέρα από την αρχή της διαφάνειας.

[Shape.getVisualBounds](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getVisualBounds--) δεν είναι αυτή τη στιγμή δηλωμένη από την διεπαφή [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/). Συνεπώς, διατηρήστε το σχήμα που λαμβάνετε από τη συλλογή σχημάτων της διαφάνειας ως τιμή διεπαφής και κάντε cast μόνο όταν καλέσετε τη μέθοδο.

Το παρακάτω παράδειγμα λαμβάνει και συγκρίνει τα όρια πλαισίου και τα οπτικά όρια:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Το ίδιο [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) μπορεί να χρησιμοποιηθεί για την ευθυγράμμιση κοντινών σχημάτων προς την αριστερή, δεξιά, άνω ή κάτω άκρη του, για την κράτηση επαρκούς χώρου σε μια παραγόμενη διάταξη, ή για την ανίχνευση περιεχομένου εκτός μιας επιτρεπόμενης περιοχής. Τα οπτικά όρια είναι ιδιαίτερα χρήσιμα για SmartArt, πλαίσια κειμένου, βέλη, εικόνες, περιστραμμένα σχήματα και ομαδικά σχήματα, όπου το αποθηκευμένο πλαίσιο ενδέχεται να μην αντιπροσωπεύει το πλήρες αποδοσημένο αποτέλεσμα.

Χρησιμοποιήστε [Shape.getVisualBounds](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getVisualBounds--) όταν χρειάζεστε συντεταγμένες για διάταξη ή επαλήθευση και δεν χρειάζεστε bitmap. Χρησιμοποιήστε [IShape.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getImage--) όταν χρειάζεστε απόδοση του σχήματος. Με το [ShapeThumbnailBounds](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapethumbnailbounds/), το `ShapeThumbnailBounds.Shape` ορίζει το μέγεθος της εικόνας από τα όρια του σχήματος, συμπεριλαμβανομένων των ρυθμίσεων περιγράμματος, ενώ το `ShapeThumbnailBounds.Appearance` το ορίζει από την εμφάνιση του σχήματος και περιορίζει το αποτέλεσμα στα όρια της διαφάνειας. Αντίθετα, το [Shape.getVisualBounds](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getVisualBounds--) επιστρέφει μόνο το υπολογισμένο ορθογώνιο και δεν το περικόπτει στη διαφάνεια.

## **Συχνές Ερωτήσεις**

**Ποιες μορφές εικόνας μπορούν να χρησιμοποιηθούν κατά την αποθήκευση μικρογραφιών σχήματος;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/java/com.aspose.slides/imageformat/), και άλλες. Τα σχήματα μπορούν επίσης να [εξαγάγουν ως διανυσματικό SVG](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

**Ποια είναι η διαφορά μεταξύ ορίων Shape και Appearance κατά την απόδοση μιας μικρογραφίας;**

`Shape` χρησιμοποιεί τη γεωμετρία του σχήματος· `Appearance` λαμβάνει υπόψη [οπτικά εφέ](/slides/el/java/shape-effect/) (σκιές, λάμψεις κ.λπ.).

**Τι συμβαίνει αν ένα σχήμα είναι σημειωμένο ως κρυφό; Θα εξακολουθεί να αποδίδεται ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφού επηρεάζει την προβολή της παρουσίασης, αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται ομαδικά σχήματα, διαγράμματα, SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Οποιοδήποτε αντικείμενο που αντιπροσωπεύεται ως [Shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/java/com.aspose.slides/chart/), και [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι εγκατεστημένες στο σύστημα γραμματοσειρές την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/java/custom-font/) (ή να [ρυθμίσετε τις αντικαταστάσεις γραμματοσειρών](/slides/el/java/font-substitution/)) για να αποφύγετε ανεπιθύμητες εναλλαγές και ανακατασκευή κειμένου.