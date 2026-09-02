---
title: Δημιουργία μικρογραφιών σχημάτων παρουσίασης σε JavaScript
linktitle: Μικρογραφίες Σχήματος
type: docs
weight: 70
url: /el/nodejs-java/create-shape-thumbnails/
keywords:
- μικρογραφία σχήματος
- εικόνα σχήματος
- απόδοση σχήματος
- απόδοση σχήματος
- οπτικά όρια
- όρια σχήματος
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχημάτων από διαφάνειες PowerPoint με JavaScript και Aspose.Slides για Node.js – δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Το Aspose.Slides χρησιμοποιείται για τη δημιουργία αρχείων παρουσίασης όπου κάθε σελίδα είναι μια διαφάνεια. Αυτές οι διαφάνειες μπορούν να προβάλλονται ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Ωστόσο, μερικές φορές οι προγραμματιστές ενδέχεται να χρειάζονται να προβάλλουν τις εικόνες των σχημάτων ξεχωριστά σε μια εφαρμογή προβολής εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides σας βοηθά να δημιουργήσετε μικρογραφίες των σχημάτων της διαφάνειας. Η χρήση αυτής της δυνατότητας περιγράφεται σε αυτό το άρθρο.  
Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε μικρογραφίες διαφανειών με διαφορετικούς τρόπους:

- Δημιουργία μικρογραφίας σχήματος εντός μιας διαφάνειας.  
- Δημιουργία μικρογραφίας σχήματος για σχήμα διαφάνειας με διαστάσεις ορισμένες από τον χρήστη.  
- Δημιουργία μικρογραφίας σχήματος στα όρια της εμφάνισης του σχήματος.  

## **Δημιουργία μικρογραφιών σχήματος από διαφάνειες**
Για να δημιουργήσετε μια μικρογραφία σχήματος από οποιαδήποτε διαφάνεια χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java, ακολουθήστε τα παρακάτω:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).  
2. Αποκτήστε την αναφορά οποιασδήποτε διαφάνειας χρησιμοποιώντας το ID ή το δείκτη της.  
3. [Λάβετε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getImage--) της αναφερόμενης διαφάνειας σε προεπιλεγμένη κλίμακα.  
4. Αποθηκεύστε την εικόνα μικρογραφίας στην προτιμώμενη μορφή εικόνας.

Αυτός ο κώδικας δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος από μια διαφάνεια:

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Δημιουργία εικόνας πλήρους κλίμακας
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
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

## **Δημιουργία μικρογραφιών σχήματος με παράγοντα κλιμάκωσης ορισμένο από τον χρήστη**
Για να δημιουργήσετε τη μικρογραφία σχήματος μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java, ακολουθήστε τα παρακάτω:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).  
2. Αποκτήστε την αναφορά οποιασδήποτε διαφάνειας χρησιμοποιώντας το ID ή το δείκτη της.  
3. [Λάβετε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) της αναφερόμενης διαφάνειας με διαστάσεις ορισμένες από τον χρήστη.  
4. Αποθηκεύστε την εικόνα μικρογραφίας στην προτιμώμενη μορφή εικόνας.

Αυτός ο κώδικας δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος με βάση ορισμένο παράγοντα κλιμάκωσης:

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Δημιουργία εικόνας πλήρους κλίμακας
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
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

## **Δημιουργία μικρογραφίας σχήματος στα όρια**
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχημάτων επιτρέπει στους προγραμματιστές να παράγουν μια μικρογραφία στα όρια της εμφάνισης του σχήματος, λαμβάνοντας υπόψη όλα τα εφέ του σχήματος. Η δημιουργούμενη μικρογραφία περιορίζεται από τα όρια της διαφάνειας. Για να δημιουργήσετε μια μικρογραφία ενός σχήματος διαφάνειας στα όρια της εμφάνισής του, ακολουθήστε τα παρακάτω:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).  
2. Αποκτήστε την αναφορά οποιασδήποτε διαφάνειας χρησιμοποιώντας το ID ή το δείκτη της.  
3. Λάβετε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με τα όρια του σχήματος ως εμφάνιση.  
4. Αποθηκεύστε την εικόνα μικρογραφίας στην προτιμώμενη μορφή εικόνας.

Ο κώδικας που βασίζεται στα παραπάνω βήματα είναι:

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Δημιουργία εικόνας πλήρους κλίμακας
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Αποθήκευση της εικόνας στο δίσκο σε μορφή PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
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

## **Λήψη των πραγματικών οπτικών ορίων ενός σχήματος**

Οι ιδιότητες πλαισίου ενός [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/)—οι μέθοδοι `getX()`, `getY()`, `getWidth()` και `getHeight()`—περιγράφουν το ορθογώνιο που αποθηκεύεται στο μοντέλο παρουσίασης. Το περιεχόμενο που πραγματικά αποδίδεται μπορεί να επεκτείνεται πέρα από αυτό το πλαίσιο ή να καταλαμβάνει διαφορετικό ορθογώνιο ευθυγραμμισμένο με τους άξονες. Περιστροφή, περίγραμμα, κεφαλές βελών, διάταξη κειμένου και υπερχείλιση, γεωμετρία SmartArt που δημιουργείται και άλλα εφέ απόδοση μπορούν να αλλάξουν το κατειλημμένο χώρο.

Χρησιμοποιήστε [Shape.getVisualBounds](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getVisualBounds--) για να υπολογίσετε αυτόν τον χώρο χωρίς να δημιουργήσετε εικόνα. Η μέθοδος επιστρέφει ένα αντικείμενο [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) σε συντεταγμένες διαφάνειας. Το επιστρεφόμενο ορθογώνιο δεν περικόπτεται από τη διαφάνεια, έτσι οι συντεταγμένες του μπορεί να είναι αρνητικές όταν το περιεχόμενο εκτείνεται πέρα από το αρχικό σημείο της διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει και συγκρίνει τα πλαίσια και τα οπτικά όρια:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Το ίδιο ορθογώνιο μπορεί να χρησιμοποιηθεί για να ευθυγραμμιστεί ένα σχήμα στα αριστερά, δεξιά, πάνω ή κάτω άκρο του, για να διατηρηθεί επαρκής χώρος σε δημιουργημένη διάταξη ή για να εντοπιστεί περιεχόμενο εκτός επιτρεπόμενης περιοχής. Τα οπτικά όρια είναι ιδιαίτερα χρήσιμα για SmartArt, πλαίσια κειμένου, βέλη, εικόνες, περιστραμμένα σχήματα και ομαδικά σχήματα, όπου το αποθηκευμένο πλαίσιο ενδέχεται να μην αντιπροσωπεύει το πλήρες αποτέλεσμα απόδοσης.

Χρησιμοποιήστε [Shape.getVisualBounds](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getVisualBounds--) όταν χρειάζεστε συντεταγμένες για διάταξη ή επικύρωση και δεν χρειάζεστε bitmap. Χρησιμοποιήστε [Shape.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getImage--) όταν χρειάζεστε την απόδοση του σχήματος. Με το [ShapeThumbnailBounds](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapethumbnailbounds/), το `ShapeThumbnailBounds.Shape` προσαρμόζει την εικόνα από τα όρια του σχήματος, συμπεριλαμβανομένων των ρυθμίσεων περιγράμματος, ενώ το `ShapeThumbnailBounds.Appearance` την προσαρμόζει από την εμφάνιση του σχήματος και περιορίζει το αποτέλεσμα στα όρια της διαφάνειας. Αντίθετα, το [Shape.getVisualBounds](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getVisualBounds--) επιστρέφει μόνο το υπολογισμένο ορθογώνιο και δεν το περικόπτει στη διαφάνεια.

## **Συχνές ερωτήσεις**

**Ποιοι μορφές εικόνας μπορούν να χρησιμοποιηθούν κατά την αποθήκευση μικρογραφιών σχήματος;**  

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imageformat/), και άλλες. Τα σχήματα μπορούν επίσης να [εξαχθούν ως διανυσματικό SVG](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/writeassvg/) αποθηκεύοντας το περιεχόμενό τους ως SVG.

**Ποια είναι η διαφορά μεταξύ των ορίων Shape και Appearance όταν αποδίδεται μια μικρογραφία;**  

`Shape` χρησιμοποιεί τη γεωμετρία του σχήματος· `Appearance` λαμβάνει υπόψη [οπτικά εφέ](/slides/el/nodejs-java/shape-effect/) (σκιές, λαμπρότητα κ.λπ.).

**Τι συμβαίνει εάν ένα σχήμα είναι επισημασμένο ως κρυφό; Θα συνεχίσει να αποδίδεται ως μικρογραφία;**  

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυφής εμφάνισης επηρεάζει μόνο την προβολή της παρουσίασης, όχι τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται τα ομαδικά σχήματα, τα διαγράμματα, το SmartArt και άλλα σύνθετα αντικείμενα;**  

Ναι. Οποιοδήποτε αντικείμενο που αναπαρίσταται ως [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/) και [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι γραμματοσειρές που είναι εγκατεστημένες στο σύστημα την ποιότητα των μικρογραφιών για σχήματα κειμένου;**  

Ναι. Θα πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/nodejs-java/custom-font/) (ή να [ρυθμίζετε τις αντικαταστάσεις γραμματοσειρών](/slides/el/nodejs-java/font-substitution/)) για να αποφύγετε ανεπιθύμητες εναλλαγές και αναδιάταξη κειμένου.