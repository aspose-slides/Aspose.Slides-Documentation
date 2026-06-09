---
title: Διαχείριση Εκθέτη και Δείκτη σε Παρουσιάσεις με JavaScript
linktitle: Εκθέτης και Δείκτης
type: docs
weight: 80
url: /el/nodejs-java/superscript-and-subscript/
keywords:
- εκθέτης
- δείκτης
- προσθήκη εκθέτη
- προσθήκη δείκτη
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Κατέχετε την τεχνοτροπία του εκθέτη και του δείκτη στο Aspose.Slides για Node.js μέσω Java και ενισχύστε τις παρουσιάσεις σας με επαγγελματική μορφοποίηση κειμένου για μέγιστο αντίκτυπο."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει δυνατότητες ενσωμάτωσης κειμένου εκθέτη και δείκτη στα PowerPoint (PPT, PPTX) και OpenDocument (ODP) παρουσιάσεις σας. Είτε χρειάζεστε να επισημάνετε χημικούς τύπους, μαθηματικές εξισώσεις ή να σχολιάσετε περιεχόμενο με υποσήμερα, αυτές οι εξειδικευμένες επιλογές μορφοποίησης βοηθούν στη διατήρηση της σαφήνειας και της ακρίβειας. Σε αυτό το άρθρο, θα μάθετε πώς να εφαρμόζετε άψογα στυλ εκθέτη και δείκτη και να εξασφαλίζετε επαγγελματικά αποτελέσματα σε κάθε διαφάνεια.

## **Διαχείριση Κειμένου Εκθέτη και Δείκτη**

Μπορείτε να προσθέσετε κείμενο εκθέτη και δείκτη μέσα σε οποιοδήποτε τμήμα παραγράφου. Για την προσθήκη κειμένου εκθέτη ή δείκτη σε πλαίσιο κειμένου Aspose.Slides, πρέπει να χρησιμοποιήσετε τη μέθοδο [**setEscapement**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) της κλάσης [PortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PortionFormat).

Αυτή η ιδιότητα επιστρέφει ή ορίζει το κείμενο εκθέτη ή δείκτη (τιμή από -100% (δείκτης) έως 100% (εκθέτης)). Για παράδειγμα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [AutoShape] τύπου [Rectangle](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeType#Rectangle) στη διαφάνεια.
- Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame) που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape).
- Καθαρίστε τις υπάρχουσες παραγράφους
- Δημιουργήστε ένα νέο αντικείμενο παραγράφου για την αποθήκευση κειμένου εκθέτη και προσθέστε το στη [Paragraphs collection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame#getParagraphs--) του [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/TextFrame).
- Δημιουργήστε ένα νέο αντικείμενο Portion.
- Ορίστε την ιδιότητα Escapement για το portion μεταξύ 0 και 100 για την προσθήκη εκθέτη. (0 σημαίνει χωρίς εκθέτη)
- Ορίστε κάποιο κείμενο για το [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Portion) και, στη συνέχεια, προσθέστε το στη συλλογή portion της παραγράφου.
- Δημιουργήστε ένα νέο αντικείμενο παραγράφου για την αποθήκευση κειμένου δείκτη και προσθέστε το στη συλλογή IParagraphs του ITextFrame.
- Δημιουργήστε ένα νέο αντικείμενο Portion.
- Ορίστε την ιδιότητα Escapement για το portion μεταξύ 0 και -100 για την προσθήκη δείκτη. (0 σημαίνει χωρίς δείκτη)
- Ορίστε κάποιο κείμενο για το [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Portion) και, στη συνέχεια, προσθέστε το στη συλλογή portion της παραγράφου.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω.

```javascript
// Δημιουργήστε μια κλάση Presentation που αντιπροσωπεύει ένα PPTX
var pres = new aspose.slides.Presentation();
try {
    // Λάβετε τη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Δημιουργήστε πλαίσιο κειμένου
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Δημιουργήστε παράγραφο για κείμενο εκθέτη
    var superPar = new aspose.slides.Paragraph();
    // Δημιουργήστε τμήμα με συνηθισμένο κείμενο
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Δημιουργήστε τμήμα με κείμενο εκθέτη
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Δημιουργήστε παράγραφο για κείμενο δείκτη
    var paragraph2 = new aspose.slides.Paragraph();
    // Δημιουργήστε τμήμα με συνηθισμένο κείμενο
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Δημιουργήστε τμήμα με κείμενο δείκτη
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Προσθέστε παραγράφους στο πλαίσιο κειμένου
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Θα διατηρηθούν οι εκθέτες και δείκτες κατά την εξαγωγή σε PDF ή άλλες μορφές;**

Ναι, το Aspose.Slides διατηρεί σωστά τη μορφοποίηση εκθέτη και δείκτη κατά την εξαγωγή παρουσιάσεων σε PDF, PPT/PPTX, εικόνες και άλλες υποστηριζόμενες μορφές. Η εξειδικευμένη μορφοποίηση παραμένει αμετάβλητη σε όλα τα αρχεία εξόδου.

**Μπορούν οι εκθέτες και δείκτες να συνδυασθούν με άλλες μορφές μορφοποίησης όπως έντονα ή πλάγια;**

Ναι, το Aspose.Slides επιτρέπει την ανάμειξη διαφόρων στυλ κειμένου σε ένα τμήμα κειμένου. Μπορείτε να ενεργοποιήσετε έντονη γραφή, πλάγια, υπογράμμιση, και ταυτόχρονα να εφαρμόσετε εκθέτη ή δείκτη ρυθμίζοντας τις αντίστοιχες ιδιότητες στην [PortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/).

**Λειτουργεί η μορφοποίηση εκθέτη και δείκτη για κείμενο μέσα σε πίνακες, διαγράμματα ή SmartArt;**

Ναι, το Aspose.Slides υποστηρίζει μορφοποίηση μέσα στα περισσότερα αντικείμενα, συμπεριλαμβανομένων πινάκων και στοιχείων διαγραμμάτων. Όταν εργάζεστε με SmartArt, πρέπει να προσπελάσετε τα αντίστοιχα στοιχεία (όπως [SmartArtNode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartnode/)) και τα περιεχόμενα κειμένου τους, και έπειτα να ρυθμίσετε τις ιδιότητες [PortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/) με παρόμοιο τρόπο.