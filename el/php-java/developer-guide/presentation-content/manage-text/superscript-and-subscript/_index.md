---
title: Διαχείριση ανώτερου και κατώτερου ως δείκτη σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Ανώτερο και Κατώτερο
type: docs
weight: 80
url: /el/php-java/superscript-and-subscript/
keywords:
- ανώτερος
- κάτω δείκτης
- προσθήκη ανώτερου
- προσθήκη κατώτερου
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Αναπτύξτε την χρήση ανώτερου και κατώτερου ως δείκτη στο Aspose.Slides για PHP μέσω Java και ενισχύστε τις παρουσιάσεις σας με επαγγελματική μορφοποίηση κειμένου για μέγιστο αντίκτυπο."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει δυνατότητες ενσωμάτωσης κειμένου ανώτερου και κατώτερου ως δείκτη (superscript και subscript) στις παρουσιάσεις PowerPoint (PPT, PPTX) και OpenDocument (ODP). Είτε χρειάζεστε να επισημάνετε χημικούς τύπους, μαθηματικές εξισώσεις ή να σχολιάσετε περιεχόμενο με υποσημειώσεις, αυτές οι εξειδικευμένες επιλογές μορφοποίησης βοηθούν στη διατήρηση της σαφήνειας και της ακρίβειας. Σε αυτό το άρθρο, θα μάθετε πώς να εφαρμόζετε αβίαστης την μορφή ανώτερου και κατώτερου ως δείκτη και να εξασφαλίζετε επαγγελματικά αποτελέσματα σε κάθε διαφάνεια.

## **Διαχείριση κειμένου ανώτερου και κατώτερου ως δείκτη**
Μπορείτε να προσθέσετε κείμενο ανώτερου ή κατώτερου ως δείκτη σε οποιοδήποτε τμήμα παραγράφου. Για την προσθήκη κειμένου ανώτερου ή κατώτερου ως δείκτη στο πλαίσιο κειμένου του Aspose.Slides πρέπει να χρησιμοποιήσετε τη μέθοδο [**setEscapement**](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setEscapement) της κλάσης [PortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/PortionFormat).

Αυτή η ιδιότητα επιστρέφει ή ορίζει το κείμενο ανώτερου ή κατώτερου ως δείκτη (τιμές από -100 % (κάτω δείκτη) έως 100 % (άνω δείκτη)). Για παράδειγμα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
- Αποκτήστε τη αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) τύπου [Rectangle](https://reference.aspose.com/slides/el/php-java/aspose.slides/ShapeType#Rectangle) στη διαφάνεια.
- Προβάλετε το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).
- Καθαρίστε τα υπάρχοντα Paragraphs
- Δημιουργήστε ένα νέο αντικείμενο παραγράφου για την αποθήκευση κειμένου ανώτερου ως δείκτη και προσθέστε το στη συλλογή [IParagraphs collection](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParagraphs) του [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/).
- Δημιουργήστε ένα νέο αντικείμενο portion
- Ορίστε την ιδιότητα Escapement για το portion μεταξύ 0 και 100 για προσθήκη ανώτερου δείκτη. (0 σημαίνει χωρίς ανώτερο δείκτη)
- Ορίστε κάποιο κείμενο για [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/Portion) και στη συνέχεια προσθέστε το στη συλλογή portion της παραγράφου.
- Δημιουργήστε ένα νέο αντικείμενο παραγράφου για την αποθήκευση κειμένου κατώτερου ως δείκτη και προσθέστε το στη συλλογή IParagraphs του ITextFrame.
- Δημιουργήστε ένα νέο αντικείμενο portion
- Ορίστε την ιδιότητα Escapement για το portion μεταξύ 0 και -100 για προσθήκη κατώτερου δείκτη. (0 σημαίνει χωρίς κατώτερο δείκτη)
- Ορίστε κάποιο κείμενο για [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/Portion) και στη συνέχεια προσθέστε το στη συλλογή portion της παραγράφου.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω.

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα PPTX
  $pres = new Presentation();
  try {
    # Λήψη διαφάνειας
    $slide = $pres->getSlides()->get_Item(0);
    # Δημιουργία πλαισίου κειμένου
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Δημιουργία παραγράφου για κείμενο ανώτερου δείκτη
    $superPar = new Paragraph();
    # Δημιουργία τμήματος με κανονικό κείμενο
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Δημιουργία τμήματος με κείμενο ανώτερου δείκτη
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Δημιουργία παραγράφου για κείμενο κατώτερου δείκτη
    $paragraph2 = new Paragraph();
    # Δημιουργία τμήματος με κανονικό κείμενο
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Δημιουργία τμήματος με κείμενο κατώτερου δείκτη
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Προσθήκη παραγράφων στο πλαίσιο κειμένου
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Θα διατηρηθεί το ανώτερο και το κατώτερο ως δείκτη όταν εξάγεται σε PDF ή άλλες μορφές;**

Ναι, το Aspose.Slides διατηρεί σωστά τη μορφοποίηση ανώτερου και κατώτερου ως δείκτη κατά την εξαγωγή παρουσιάσεων σε PDF, PPT/PPTX, εικόνες και άλλες υποστηριζόμενες μορφές. Η εξειδικευμένη μορφοποίηση παραμένει αμετάβλητη σε όλα τα αρχεία εξόδου.

**Μπορεί το ανώτερο και το κατώτερο ως δείκτη να συνδυαστούν με άλλες μορφές μορφοποίησης όπως έντονη ή πλάγια γραφή;**

Ναι, το Aspose.Slides σας επιτρέπει να συνδυάσετε διάφορα στυλ κειμένου μέσα σε ένα μόνο portion. Μπορείτε να ενεργοποιήσετε έντονη, πλάγια, υπογράμμιση και ταυτόχρονα να εφαρμόσετε ανώτερο ή κατώτερο ως δείκτη ρυθμίζοντας τις αντίστοιχες ιδιότητες στην κλάση [PortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/).

**Λειτουργεί η μορφοποίηση ανώτερου και κατώτερου ως δείκτη για κείμενο μέσα σε πίνακες, διαγράμματα ή SmartArt;**

Ναι, το Aspose.Slides υποστηρίζει μορφοποίηση στα περισσότερα αντικείμενα, συμπεριλαμβανομένων πινάκων και στοιχείων διαγραμμάτων. Όταν εργάζεστε με SmartArt, πρέπει να έχετε πρόσβαση στα αντίστοιχα στοιχεία (όπως [SmartArtNode](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnode/)) και στα περιέκτονα κειμένου τους, και κατόπιν να ρυθμίσετε τις ιδιότητες της κλάσης [PortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/) με αντίστοιχο τρόπο.