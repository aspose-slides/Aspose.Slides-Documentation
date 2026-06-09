---
title: Διαχείριση Υψιγράφημα και Κατώγραφος σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: Υψιγράφημα και Κατώγραφος
type: docs
weight: 80
url: /el/java/superscript-and-subscript/
keywords:
- υψιγράφημα
- κατώγραφο
- προσθήκη υψιγράφημα
- προσθήκη κατώγραφο
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Αποκτήστε έλεγχο του υψιγράφημα και του κατώγραφου στο Aspose.Slides για Java και βελτιώστε τις παρουσιάσεις σας με επαγγελματική μορφοποίηση κειμένου για μέγιστο αντίκτυπο."
---
## **Επισκόπηση**

Η Aspose.Slides παρέχει δυνατότητες ενσωμάτωσης κειμένου υψιγράφημα και κατώγραφου στις παρουσιάσεις PowerPoint (PPT, PPTX) και OpenDocument (ODP). Είτε χρειάζεστε να επισημάνετε χημικούς τύπους, μαθηματικές εξισώσεις ή να προσθέσετε υποσημειώσεις, αυτές οι εξειδικευμένες επιλογές μορφοποίησης βοηθούν στη διατήρηση της σαφήνειας και της ακρίβειας. Σε αυτό το άρθρο, θα μάθετε πώς να εφαρμόζετε αβίαστα στυλ υψιγράφημα και κατώγραφος και να εξασφαλίζετε επαγγελματικά αποτελέσματα σε κάθε διαφάνεια.

## **Διαχείριση κειμένου Υψιγράφημα και Κατώγραφος**
Μπορείτε να προσθέσετε κείμενο υψιγράφημα και κατώγραφο εντός οποιουδήποτε τμήματος παραγράφου. Για την προσθήκη κειμένου Υψιγράφημα ή Κατώγραφο σε πλαίσιο κειμένου Aspose.Slides, πρέπει να χρησιμοποιήσετε τη μέθοδο [**setEscapement**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) της κλάσης [PortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/PortionFormat).

Αυτή η ιδιότητα επιστρέφει ή ορίζει το κείμενο υψιγράφημα ή κατώγραφο (τιμή από -100% (κατώγραφος) έως 100% (υψιγράφημα)). Για παράδειγμα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) τύπου [Rectangle](https://reference.aspose.com/slides/el/java/com.aspose.slides/ShapeType#Rectangle) στη διαφάνεια.
- Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrame) που σχετίζεται με το [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape).
- Καθαρίστε τις υπάρχουσες Παραγράφους
- Δημιουργήστε ένα νέο αντικείμενο παραγράφου για την αποθήκευση κειμένου υψιγράφημα και προσθέστε το στη [IParagraphs collection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrame#getParagraphs--) του [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrame).
- Δημιουργήστε ένα νέο αντικείμενο portion.
- Ορίστε την ιδιότητα Escapement για το portion μεταξύ 0 και 100 για προσθήκη υψιγράφημα. (0 σημαίνει χωρίς υψιγράφημα)
- Ορίστε κάποιο κείμενο για το [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/Portion) και προσθέστε το στη συλλογή portions της παραγράφου.
- Δημιουργήστε ένα νέο αντικείμενο παραγράφου για κείμενο κατώγραφο και προσθέστε το στη συλλογή IParagraphs του ITextFrame.
- Δημιουργήστε ένα νέο αντικείμενο portion.
- Ορίστε την ιδιότητα Escapement για το portion μεταξύ 0 και -100 για προσθήκη κατώγραφο. (0 σημαίνει χωρίς κατώγραφο)
- Ορίστε κάποιο κείμενο για το [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/Portion) και προσθέστε το στη συλλογή portions της παραγράφου.
- Αποθηκεύστε την παρουσία ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων παρέχεται παρακάτω.

```java
// Δημιουργήστε μια κλάση Presentation που αντιπροσωπεύει ένα PPTX
Presentation pres = new Presentation();
try {
    // Λάβετε τη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);

    // Δημιουργήστε πλαίσιο κειμένου
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Δημιουργήστε παράγραφο για κείμενο υψιγράφημα
    IParagraph superPar = new Paragraph();

    // Δημιουργήστε τμήμα με κανονικό κείμενο
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Δημιουργήστε τμήμα με κείμενο υψιγράφημα
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Δημιουργήστε παράγραφο για κείμενο κατώγραφο
    IParagraph paragraph2 = new Paragraph();

    // Δημιουργήστε τμήμα με κανονικό κείμενο
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Δημιουργήστε τμήμα με κείμενο κατώγραφο
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Προσθέστε παραγράφους στο πλαίσιο κειμένου
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Θα διατηρηθεί το υψιγράφημα και το κατώγραφο κατά την εξαγωγή σε PDF ή άλλα μορφότυπα;**

Ναι, η Aspose.Slides διατηρεί σωστά τη μορφοποίηση υψιγράφημα και κατώγραφο κατά την εξαγωγή παρουσιάσεων σε PDF, PPT/PPTX, εικόνες και άλλα υποστηριζόμενα μορφότυπα. Η εξειδικευμένη μορφοποίηση παραμένει αμετάβλητη σε όλα τα αρχεία εξόδου.

**Μπορούν τα υψιγράφημα και κατώγραφο να συνδυαστούν με άλλα στυλ μορφοποίησης όπως έντονα ή πλάγια;**

Ναι, η Aspose.Slides σας επιτρέπει να συνδυάσετε διάφορα στυλ κειμένου μέσα σε ένα μόνο portion. Μπορείτε να ενεργοποιήσετε έντονα, πλάγια, υπογραμμισμένα και ταυτόχρονα να εφαρμόσετε υψιγράφημα ή κατώγραφο ρυθμίζοντας τις αντίστοιχες ιδιότητες στην [PortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/portionformat/).

**Λειτουργεί η μορφοποίηση υψιγράφημα και κατώγραφο για κείμενο εντός πινάκων, διαγραμμάτων ή SmartArt;**

Ναι, η Aspose.Slides υποστηρίζει μορφοποίηση στα περισσότερα αντικείμενα, συμπεριλαμβανομένων πινάκων και στοιχείων διαγραμμάτων. Όταν εργάζεστε με SmartArt, πρέπει να προσπελάσετε τα αντίστοιχα στοιχεία (όπως το [SmartArtNode](https://reference.aspose.com/slides/el/java/com.aspose.slides/smartartnode/)) και τα περιεχόμενα κειμένου τους, και στη συνέχεια να ρυθμίσετε τις ιδιότητες της [PortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/portionformat/) με παρόμοιο τρόπο.