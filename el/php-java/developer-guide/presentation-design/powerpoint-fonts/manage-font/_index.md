---
title: Διαχείριση γραμματοσειρών σε παρουσιάσεις με PHP
linktitle: Διαχείριση γραμματοσειρών
type: docs
weight: 10
url: /el/php-java/manage-fonts/
keywords:
- διαχείριση γραμματοσειρών
- ιδιότητες γραμματοσειράς
- παράγραφος
- μορφοποίηση κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Έλεγχος γραμματοσειρών σε PHP με το Aspose.Slides: ενσωμάτωση, αντικατάσταση και φόρτωση προσαρμοσμένων γραμματοσειρών για να διατηρηθούν οι παρουσιάσεις PPT, PPTX και ODP καθαρές, ασφαλείς για το brand και συνεπείς."
---
## **Διαχείριση ιδιοτήτων σχετικών με τη γραμματοσειρά**
{{% alert color="primary" %}} 

Οι παρουσιάσεις συνήθως περιέχουν τόσο κείμενο όσο και εικόνες. Το κείμενο μπορεί να μορφοποιηθεί με διαφορετικούς τρόπους, είτε για να τονιστούν συγκεκριμένα τμήματα και λέξεις, είτε για να συμμορφωθεί με εταιρικά στυλ. Η μορφοποίηση του κειμένου βοηθά τους χρήστες να διαφοροποιήσουν την εμφάνιση και την αίσθηση του περιεχομένου της παρουσίασης. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides for PHP via Java για να ρυθμίσετε τις ιδιότητες γραμματοσειράς των παραγράφων κειμένου στις διαφάνειες.

{{% /alert %}} 

Για να διαχειριστείτε τις ιδιότητες γραμματοσειράς μιας παραγράφου χρησιμοποιώντας το Aspose.Slides for PHP via Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Λάβετε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Πρόσβαση στα σχήματα [Placeholder](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholder/) στη διαφάνεια και μετατροπή τους σε [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).
1. Πάρτε το [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) από το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) που εκτίθεται από το [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).
1. Στοίχιση της παραγράφου.
1. Πρόσβαση στο κείμενο [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) μιας [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/).
1. Ορίστε τη γραμματοσειρά χρησιμοποιώντας το [FontData](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontdata/) και θέστε το **Font** της [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) ανάλογα.
   1. Ορίστε τη γραμματοσειρά σε έντονη.
   1. Ορίστε τη γραμματοσειρά σε πλάγια.
1. Ορίστε το χρώμα της γραμματοσειράς χρησιμοποιώντας το [FillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/) που εκτίθεται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/).
1. Αποθηκεύστε την τροποποιημένη παρουσία σε αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω. Παίρνει μια ακατέργαστη παρουσία και μορφοποιεί τις γραμματοσειρές σε μία από τις διαφάνειες. Τα στιγμιότυπα οθόνης που ακολουθούν δείχνουν το αρχείο εισόδου και πώς οι αποσπάσματα κώδικα το μεταβάλλουν. Ο κώδικας αλλάζει τη γραμματοσειρά, το χρώμα και το στυλ γραμματοσειράς.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Σχήμα: Το κείμενο στο αρχείο εισόδου**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Σχήμα: Το ίδιο κείμενο με ενημερωμένη μορφοποίηση**|

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Πρόσβαση σε διαφάνεια χρησιμοποιώντας τη θέση της
    $slide = $pres->getSlides()->get_Item(0);
    # Πρόσβαση στον πρώτο και δεύτερο placeholder στη διαφάνεια και μετατροπή του σε AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Πρόσβαση στην πρώτη Παράγραφο
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Στοίχιση παραγράφου
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Πρόσβαση στο πρώτο τμήμα
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Ορισμός νέων γραμματοσειρών
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Ανάθεση νέων γραμματοσειρών στο τμήμα
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Ορισμός γραμματοσειράς σε έντονη
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Ορισμός γραμματοσειράς σε πλάγια
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Ορισμός χρώματος γραμματοσειράς
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Αποθήκευση του PPTX στο δίσκο
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός ιδιοτήτων γραμματοσειράς κειμένου**
{{% alert color="primary" %}} 

Όπως αναφέρθηκε στη **Διαχείριση ιδιοτήτων σχετικών με τη γραμματοσειρά**, ένα [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) χρησιμοποιείται για τη διατήρηση κειμένου με παρόμοιο στυλ μορφοποίησης σε μια παράγραφο. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides for PHP via Java για να δημιουργήσετε ένα πλαίσιο κειμένου με κάποιο κείμενο και μετά να ορίσετε μια συγκεκριμένη γραμματοσειρά, καθώς και διάφορες άλλες ιδιότητες της κατηγορίας οικογένειας γραμματοσειρών.

{{% /alert %}} 

Για να δημιουργήσετε ένα πλαίσιο κειμένου και να ορίσετε τις ιδιότητες γραμματοσειράς του κειμένου σε αυτό:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) τύπου **Rectangle** στη διαφάνεια.
1. Καταργήστε το στυλ γεμίσματος που συνδέεται με το [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).
1. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).
1. Προσθέστε κάποιο κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/).
1. Πρόσβαση στο αντικείμενο [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) που σχετίζεται με το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/).
1. Ορίστε τη γραμματοσειρά που θα χρησιμοποιηθεί για το [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/).
1. Ορίστε άλλες ιδιότητες γραμματοσειράς όπως έντονη, πλάγια, υπογράμμιση, χρώμα και ύψος χρησιμοποιώντας τις αντίστοιχες ιδιότητες που εκτίθενται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/).
1. Γράψτε την τροποποιημένη παρουσία ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Σχήμα: Κείμενο με ορισμένες ιδιότητες γραμματοσειράς που ορίστηκαν από το Aspose.Slides for PHP via Java**|

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Λήψη πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape τύπου Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Αφαίρεση οποιουδήποτε στυλ γεμίσματος που σχετίζεται με το AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Πρόσβαση στο TextFrame που σχετίζεται με το AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Πρόσβαση στο Portion που σχετίζεται με το TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Ορισμός γραμματοσειράς για το Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Ορισμός ιδιότητας έντονης γραμματοσειράς
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Ορισμός ιδιότητας πλάγιας γραμματοσειράς
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Ορισμός ιδιότητας υπογράμμισης γραμματοσειράς
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Ορισμός ύψους γραμματοσειράς
    $port->getPortionFormat()->setFontHeight(25);
    # Ορισμός χρώματος γραμματοσειράς
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Αποθήκευση της παρουσίασης στο δίσκο
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```