---
title: "Διαχείριση εκθέτη και δείκτη σε παρουσιάσεις για Android"
linktitle: "Εκθέτης και Δείκτης"
type: docs
weight: 80
url: /el/androidjava/superscript-and-subscript/
keywords:
  - "εκθέτης"
  - "δείκτης"
  - "προσθήκη εκθέτη"
  - "προσθήκη δείκτη"
  - "PowerPoint"
  - "OpenDocument"
  - "παρουσίαση"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "Κατακτήστε τη χρήση εκθέτη και δείκτη στο Aspose.Slides για Android μέσω Java και ανεβάστε τις παρουσιάσεις σας με επαγγελματική μορφοποίηση κειμένου για μέγιστο αντίκτυπο."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει δυνατότητες ενσωμάτωσης κειμένου με εκθέτη και δείκτη στις παρουσιάσεις PowerPoint (PPT, PPTX) και OpenDocument (ODP). Είτε χρειάζεστε να τονίσετε χημικούς τύπους, μαθηματικές εξισώσεις ή να προσθέσετε σημειώσεις υποσημείωσης, αυτές οι ειδικές επιλογές μορφοποίησης βοηθούν στη διατήρηση της σαφήνειας και της ακρίβειας. Σε αυτό το άρθρο, θα μάθετε πώς να εφαρμόζετε αβίαστα στυλ εκθέτη και δείκτη και να εξασφαλίζετε επαγγελματικά αποτελέσματα σε κάθε διαφάνεια.

## **Διαχείριση κειμένου εκθέτη και δείκτη**
Μπορείτε να προσθέσετε κείμενο εκθέτη και δείκτη σε οποιοδήποτε τμήμα παραγράφου. Για την προσθήκη κειμένου Εκθέτη ή Δείκτη σε πλαίσιο κειμένου του Aspose.Slides πρέπει να χρησιμοποιήσετε τη μέθοδο [**setEscapement**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) της κλάσης [PortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/PortionFormat).

Αυτή η ιδιότητα επιστρέφει ή ορίζει το κείμενο εκθέτη ή δείκτη (τιμή από -100% (δείκτης) έως 100% (εκθέτης)). Για παράδειγμα:

- Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
- Αποκτήστε τη αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) τύπου [Rectangle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ShapeType#Rectangle) στη διαφάνεια.
- Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrame) που συσχετίζεται με το [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape).
- Καθαρίστε τις υπάρχουσες παραγράφους
- Δημιουργήστε ένα νέο αντικείμενο παραγράφου για την αποθήκευση κειμένου εκθέτη και προσθέστε το στη [IParagraphs collection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) του [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITextFrame).
- Δημιουργήστε ένα νέο αντικείμενο Portion
- Ορίστε την ιδιότητα Escapement για το portion στο εύρος 0 έως 100 για την προσθήκη εκθέτη. (0 σημαίνει χωρίς εκθέτη)
- Ορίστε κάποιο κείμενο για το [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Portion) και στη συνέχεια προσθέστε το στη συλλογή portion της παραγράφου.
- Δημιουργήστε ένα νέο αντικείμενο παραγράφου για την αποθήκευση κειμένου δείκτη και προσθέστε το στη συλλογή IParagraphs του ITextFrame.
- Δημιουργήστε ένα νέο αντικείμενο Portion
- Ορίστε την ιδιότητα Escapement για το portion στο εύρος 0 έως -100 για την προσθήκη δείκτη. (0 σημαίνει χωρίς δείκτη)
- Ορίστε κάποιο κείμενο για το [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Portion) και στη συνέχεια προσθέστε το στη συλλογή portion της παραγράφου.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων παρατίθεται παρακάτω.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα PPTX
Presentation pres = new Presentation();
try {
    // Ανάκτηση διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);

    // Δημιουργία πλαισίου κειμένου
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Δημιουργία παραγράφου για κείμενο εκθέτη
    IParagraph superPar = new Paragraph();

    // Δημιουργία τμήματος με κανονικό κείμενο
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Δημιουργία τμήματος με κείμενο εκθέτη
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Δημιουργία παραγράφου για κείμενο δείκτη
    IParagraph paragraph2 = new Paragraph();

    // Δημιουργία τμήματος με κανονικό κείμενο
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Δημιουργία τμήματος με κείμενο δείκτη
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Προσθήκη παραγράφων στο πλαίσιο κειμένου
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Θα διατηρηθούν τα εκθέτη και δείκτης κατά την εξαγωγή σε PDF ή άλλα μορφότυπα;**

Ναι, το Aspose.Slides διατηρεί σωστά τη μορφοποίηση εκθέτη και δείκτη κατά την εξαγωγή παρουσιάσεων σε PDF, PPT/PPTX, εικόνες και άλλες υποστηριζόμενες μορφές. Η ειδική μορφοποίηση παραμένει αμετάβλητη σε όλα τα αρχεία εξόδου.

**Μπορούν τα εκθέτη και δείκτης να συνδυαστούν με άλλες μορφές μορφοποίησης όπως έντονα ή πλάγια;**

Ναι, το Aspose.Slides επιτρέπει την ανάμειξη διαφόρων στυλ κειμένου μέσα σε ένα μοναδικό portion. Μπορείτε να ενεργοποιήσετε έντονα, πλάγια, υπογράμμιση και ταυτόχρονα να εφαρμόσετε εκθέτη ή δείκτη ρυθμίζοντας τις αντίστοιχες ιδιότητες στην [PortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portionformat/).

**Λειτουργεί η μορφοποίηση εκθέτη και δείκτη για κείμενο μέσα σε πίνακες, διαγράμματα ή SmartArt;**

Ναι, το Aspose.Slides υποστηρίζει τη μορφοποίηση στα περισσότερα αντικείμενα, συμπεριλαμβανομένων πινάκων και στοιχείων διαγραμμάτων. Όταν εργάζεστε με SmartArt, πρέπει να προσπελάσετε τα κατάλληλα στοιχεία (όπως το [SmartArtNode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/smartartnode/)) και τους περιέκτες κειμένου τους, και στη συνέχεια να ρυθμίσετε τις ιδιότητες [PortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portionformat/) με παρόμοιο τρόπο.