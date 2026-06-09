---
title: Δημιουργία μικρογραφιών σχημάτων παρουσίασης σε Android
linktitle: Μικρογραφίες Σχημάτων
type: docs
weight: 70
url: /el/androidjava/create-shape-thumbnails/
keywords:
- μικρογραφία σχήματος
- εικόνα σχήματος
- απόδοση σχήματος
- απόδοση σχήματος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε υψηλής ποιότητας μικρογραφίες σχημάτων από διαφάνειες PowerPoint με Aspose.Slides for Android μέσω Java – δημιουργήστε και εξάγετε εύκολα μικρογραφίες παρουσίασης."
---
## **Εισαγωγή**

Το Aspose.Slides for Android μέσω Java μπορεί να χρησιμοποιηθεί για τη δημιουργία αρχείων παρουσίασης στα οποία κάθε σελίδα αντιστοιχεί σε μια διαφάνεια. Οι διαφάνειες μπορούν να προβληθούν ανοίγοντας τα αρχεία παρουσίασης με το Microsoft PowerPoint. Ωστόσο, μερικές φορές οι προγραμματιστές χρειάζεται να δουν τις εικόνες των σχημάτων ξεχωριστά σε έναν προβολέα εικόνων. Σε τέτοιες περιπτώσεις, το Aspose.Slides for Android μέσω Java τους βοηθά να δημιουργήσουν μικρογραφίες των σχημάτων της διαφάνειας.

Σε αυτή τη θεματική ενότητα, θα δείξουμε πώς να δημιουργήσετε μικρογραφίες διαφάνειας σε διαφορετικές καταστάσεις:

- Δημιουργία μικρογραφίας σχήματος μέσα σε διαφάνεια.
- Δημιουργία μικρογραφίας σχήματος για σχήμα διαφάνειας με διαστάσεις ορισμένες από τον χρήστη.
- Δημιουργία μικρογραφίας σχήματος εντός των ορίων της εμφάνισης του σχήματος.

## **Δημιουργία μικρογραφίας σχήματος από διαφάνεια**
Για να δημιουργήσετε μια μικρογραφία σχήματος από οποιαδήποτε διαφάνεια χρησιμοποιώντας το Aspose.Slides for Android μέσω Java, κάντε τα εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το ευρετήριο της.
1. [Αποκτήστε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getImage--) της αναφερόμενης διαφάνειας με προεπιλεγμένη κλίμακα.
1. Αποθηκεύστε την εικόνα μικρογραφίας στη προτιμώμενη μορφή εικόνας.

Αυτό το παράδειγμα κώδικα δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος από μια διαφάνεια:

```java
// Δημιουργήστε μια κλάση Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
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

## **Δημιουργία μικρογραφίας με παράγοντα κλιμάκωσης ορισμένο από τον χρήστη**
Για να δημιουργήσετε τη μικρογραφία σχήματος μιας διαφάνειας χρησιμοποιώντας το Aspose.Slides for Android μέσω Java, κάντε τα εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το ευρετήριο της.
1. [Αποκτήστε την εικόνα μικρογραφίας σχήματος](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) της αναφερόμενης διαφάνειας με διαστάσεις ορισμένες από τον χρήστη.
1. Αποθηκεύστε την εικόνα μικρογραφίας στη προτιμώμενη μορφή εικόνας.

Αυτό το παράδειγμα κώδικα δείχνει πώς να δημιουργήσετε μια μικρογραφία σχήματος βάσει ορισμένου παράγοντα κλιμάκωσης:

```java
// Δημιουργήστε μια κλάση Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
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
Αυτή η μέθοδος δημιουργίας μικρογραφιών σχημάτων επιτρέπει στους προγραμματιστές να δημιουργήσουν μια μικρογραφία εντός των ορίων της εμφάνισης του σχήματος. Λαμβάνει υπόψη όλες τις εφέ του σχήματος. Η παραγόμενη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας. Για να δημιουργήσετε μια μικρογραφία σχήματος διαφάνειας στα όρια της εμφάνισής του, κάντε τα εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Αποκτήστε την αναφορά σε οποιαδήποτε διαφάνεια χρησιμοποιώντας το ID ή το ευρετήριο της.
1. Αποκτήστε την εικόνα μικρογραφίας της αναφερόμενης διαφάνειας με όρια σχήματος ως εμφάνιση.
1. Αποθηκεύστε την εικόνα μικρογραφίας στη προτιμώμενη μορφή εικόνας.

Αυτό το παράδειγμα κώδικα βασίζεται στα παραπάνω βήματα:

```java
// Δημιουργήστε μια κλάση Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
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

## **Συχνές ερωτήσεις**

**Ποιες μορφές εικόνας μπορούν να χρησιμοποιηθούν κατά την αποθήκευση μικρογραφιών σχήματος;**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imageformat/), και άλλα. Τα σχήματα μπορούν επίσης να [εξαχθούν ως διανυσματικό SVG](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) αποθηκεύοντας το περιεχόμενο του σχήματος ως SVG.

**Ποια είναι η διαφορά μεταξύ των ορίων Shape και Appearance κατά την απόδοση μιας μικρογραφίας;**

`Shape` χρησιμοποιεί τη γεωμετρία του σχήματος· `Appearance` λαμβάνει υπόψη τα [οπτικά εφέ](/slides/el/androidjava/shape-effect/) (σκιές, λάμψεις κ.λπ.).

**Τι συμβαίνει αν ένα σχήμα έχει επισημανθεί ως κρυφό; Θα εξακολουθήσει να αποδίδεται ως μικρογραφία;**

Ένα κρυφό σχήμα παραμένει μέρος του μοντέλου και μπορεί να αποδοθεί· η σημαία κρυμμένου σχήματος επηρεάζει την προβολή της παρουσίασης αλλά δεν εμποδίζει τη δημιουργία της εικόνας του σχήματος.

**Υποστηρίζονται τα ομαδικά σχήματα, τα διαγράμματα, το SmartArt και άλλα σύνθετα αντικείμενα;**

Ναι. Οποιοδήποτε αντικείμενο που αντιπροσωπεύεται ως [Shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/) (συμπεριλαμβανομένων των [GroupShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/) και [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/smartart/)) μπορεί να αποθηκευτεί ως μικρογραφία ή ως SVG.

**Επηρεάζουν οι συστηματικά εγκατεστημένες γραμματοσειρές την ποιότητα των μικρογραφιών για σχήματα κειμένου;**

Ναι. Πρέπει να [παρέχετε τις απαιτούμενες γραμματοσειρές](/slides/el/androidjava/custom-font/) (ή να [ρυθμίσετε τις αντικαταστάσεις γραμματοσειρών](/slides/el/androidjava/font-substitution/)) ώστε να αποφευχθούν ανεπιθύμητες εναλλακτικές και επαναδιάταξη κειμένου.