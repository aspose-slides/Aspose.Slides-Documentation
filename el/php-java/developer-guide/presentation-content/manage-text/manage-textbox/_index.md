---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις με χρήση PHP
linktitle: Διαχείριση πλαισίου κειμένου
type: docs
weight: 20
url: /el/php-java/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσυνδέσμου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Το Aspose.Slides for PHP καθιστά εύκολη τη δημιουργία, επεξεργασία και κλωνοποίηση πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, βελτιώνοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως βρίσκονται σε πλαίσια κειμένου ή σχήματα. Συνεπώς, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα πλαίσιο κειμένου και στη συνέχεια να τοποθετήσετε κάποιο κείμενο μέσα στο πλαίσιο. Aspose.Slides for PHP via Java παρέχει την κλάση [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) που σάς επιτρέπει να προσθέσετε ένα σχήμα που περιέχει κάποιο κείμενο.

{{% alert title="Info" color="info" %}}
Το Aspose.Slides παρέχει επίσης την κλάση [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) που σάς επιτρέπει να προσθέσετε σχήματα στις διαφάνειες. Ωστόσο, όχι όλα τα σχήματα που προστίθενται μέσω της κλάσης `Shape` μπορούν να περιέχουν κείμενο. Τα σχήματα που προστίθενται μέσω της κλάσης [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) μπορούν όμως να περιέχουν κείμενο.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Επομένως, όταν εργάζεστε με ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θέλετε να ελέγξετε και να επιβεβαιώσετε ότι δημιουργήθηκε μέσω της κλάσης `AutoShape`. Μόνο τότε θα μπορείτε να εργαστείτε με την κλάση [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/), η οποία είναι ιδιότητα της `AutoShape`. Δείτε την ενότητα [Update Text](/slides/el/php-java/manage-textbox/#update-text) σε αυτήν τη σελίδα.
{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου σε μια διαφάνεια, ακολουθήστε τα ακόλουθα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πάρτε μια αναφορά για την πρώτη διαφάνεια στην νεοδημιουργημένη παρουσία. 
3. Προσθέστε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) με τύπο σχήματος ορισμένο ως [Rectangle](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapetype/#Rectangle) σε μια καθορισμένη θέση στη διαφάνεια και λάβετε την αναφορά για το νεοπροστέθειμε αντικείμενο `AutoShape`.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε το κείμενο: *Aspose TextBox*
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας PHP — μια υλοποίηση των παραπάνω βημάτων — δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```php
  # Δημιουργεί παρουσίαση
  $pres = new Presentation();
  try {
    # Αποκτά την πρώτη διαφάνεια στην παρουσίαση
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθέτει AutoShape με τύπο ορισμένο ως Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Προσθέτει TextFrame στο Rectangle
    $ashp->addTextFrame(" ");
    # Προσπελαύνει το πλαίσιο κειμένου
    $txtFrame = $ashp->getTextFrame();
    # Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Δημιουργεί ένα αντικείμενο Portion για την παράγραφο
    $portion = $para->getPortions()->get_Item(0);
    # Ορίζει κείμενο
    $portion->setText("Aspose TextBox");
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Το Aspose.Slides παρέχει τη μέθοδο [isTextBox](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/istextbox/) από την κλάση [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) , επιτρέποντάς σας να εξετάζετε τα σχήματα και να εντοπίζετε τα πλαίσια κειμένου.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Αυτός ο κώδικας PHP σας δείχνει πώς να ελέγξετε αν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Σημειώστε ότι εάν προσθέσετε απλώς ένα autoshape χρησιμοποιώντας τη μέθοδο `addAutoShape` από την κλάση [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/), η μέθοδος `isTextBox` του autoshape θα επιστρέψει `false`. Ωστόσο, αφού προσθέσετε κείμενο στο autoshape χρησιμοποιώντας τη μέθοδο `addTextFrame` ή τη μέθοδο `setText`, η ιδιότητα `isTextBox` επιστρέφει `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() επιστρέφει false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() επιστρέφει true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() επιστρέφει false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() επιστρέφει true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() επιστρέφει false
$shape3->addTextFrame("");
// shape3->isTextBox() επιστρέφει false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() επιστρέφει false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() επιστρέφει false
```

## **Εύρεση του σχήματος που κατέχει ένα πλαίσιο κειμένου**

Σε γενικό κώδικα επεξεργασίας κειμένου, μπορεί να λάβετε ένα [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) χωρίς να γνωρίζετε εκ των προτέρων ποιο αντικείμενο παρουσία το περιέχει. Χρησιμοποιήστε τη μέθοδο [TextFrame::getParentShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentShape) για να επιστρέψετε στο ιδιοκτητικό [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) ή σε άλλο σχήμα που περιέχει κείμενο, η [TextFrame::getParentShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentShape) επιστρέφει τον ιδιοκτήτη και η [TextFrame::getParentCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentCell) επιστρέφει `null`. Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση, έτσι η κλήση τους δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε την επιστραφόμενη τιμή με `java_is_null` πριν αποκτήσετε πρόσβαση στο σχήμα.

Για ένα πλήρες παράδειγμα που προσδιορίζει ιδιοκτήτες σχήματος και κελιού‑πίνακα, συμπεριλαμβανομένων σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/php-java/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Το Aspose.Slides παρέχει τις μεθόδους [setColumnCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setcolumncount/) και [setColumnSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setcolumnspacing/) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/) που σας επιτρέπουν να προσθέσετε στήλες σε πλαίσια κειμένου. Μπορείτε να καθορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και να ορίσετε την απόσταση μεταξύ τους σε σημεία.

Αυτός ο κώδικας δείχνει τη περιγεγραμμένη λειτουργία:

```php
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθέτει AutoShape με τύπο ορισμένο ως Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Προσθέτει TextFrame στο Rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Λαμβάνει τη μορφή κειμένου του TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Καθορίζει τον αριθμό των στηλών στο TextFrame
    $format->setColumnCount(3);
    # Καθορίζει την απόσταση μεταξύ των στηλών
    $format->setColumnSpacing(10);
    # Αποθηκεύει την παρουσίαση
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Το Aspose.Slides for PHP via Java παρέχει τη μέθοδο [setColumnCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setcolumncount/) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/) που σας επιτρέπει να προσθέσετε στήλες σε πλαίσια κειμένου. Μέσω αυτής της ιδιότητας, μπορείτε να καθορίσετε τον επιθυμητό αριθμό στηλών σε ένα πλαίσιο κειμένου.

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε μια στήλη μέσα σε ένα πλαίσιο κειμένου:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ενημέρωση κειμένου**

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλο το κείμενο που περιέχεται σε μια παρουσία.

Αυτός ο κώδικας PHP παρουσιάζει μια λειτουργία όπου όλα τα κείμενα σε μια παρουσία ενημερώνονται ή αλλάζουν:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Ελέγχει αν το σχήμα υποστηρίζει πλαίσιο κειμένου (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Διατρέχει τις παραγράφους στο πλαίσιο κειμένου
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Διατρέχει κάθε τμήμα στην παράγραφο
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Αλλάζει το κείμενο

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Αλλάζει τη μορφοποίηση

            }
          }
        }
      }
    }
    # Αποθηκεύει την τροποποιημένη παρουσίαση
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο**

Μπορείτε να εισαγάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν το πλαίσιο κειμένου κλικάρεται, οι χρήστες μεταφέρονται για άνοιγμα του συνδέσμου.

Για να προσθέσετε ένα πλαίσιο κειμένου που περιέχει σύνδεσμο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης `Presentation`. 
2. Πάρτε μια αναφορά για την πρώτη διαφάνεια στην νεοδημιουργημένη παρουσία. 
3. Προσθέστε ένα αντικείμενο `AutoShape` με `ShapeType` ορισμένο ως `Rectangle` σε μια καθορισμένη θέση στη διαφάνεια και λάβετε μια αναφορά του νεοπροστέθειμένου αντικειμένου AutoShape.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που περιέχει *Aspose TextBox* ως προεπιλεγμένο κείμενο. 
5. Δημιουργήστε μια παρουσία της κλάσης `HyperlinkManager`. 
6. Ορίστε έναν υπερσύνδεσμο χρησιμοποιώντας τη μέθοδο [setExternalHyperlinkClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) που σχετίζεται με το επιθυμητό τμήμα του `TextFrame`.
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας PHP — μια υλοποίηση των παραπάνω βημάτων — δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```php
  # Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθέτει αντικείμενο AutoShape με τύπο ορισμένο ως Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Κάνει cast το σχήμα σε AutoShape
    $pptxAutoShape = $shape;
    # Προσπελαύνει την ιδιότητα ITextFrame που σχετίζεται με το AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Προσθέτει κείμενο στο πλαίσιο
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Ορίζει τον υπερσύνδεσμο για το κείμενο του τμήματος
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Αποθηκεύει την παρουσίαση PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Ποια είναι η διαφορά μεταξύ πλαισίου κειμένου και placeholder κειμένου όταν δουλεύετε με master διαφάνειες;**

Ένα [placeholder](/slides/el/php-java/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/) και μπορεί να παρακαμφθεί σε [layouts](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/), ενώ ένα κανονικό πλαίσιο κειμένου είναι ένα αυτόνομα αντικείμενο σε μια συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε τα layout.

**Πώς μπορώ να κάνω μαζική αντικατάσταση κειμένου σε όλη την παρουσία χωρίς να επηρεάσω το κείμενο μέσα σε γραφήματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψή σας σε auto‑shapes που έχουν πλαίσια κειμένου και αποκλείστε τα ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/)) διασχίζοντας τις συλλογές τους ξεχωριστά ή παρακάμπτοντας αυτούς τους τύπους αντικειμένων.