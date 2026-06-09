---
title: Διαχείριση Πλαισίων Κειμένου σε Παρουσιάσεις με PHP
linktitle: Διαχείριση Πλαισίου Κειμένου
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
description: "Το Aspose.Slides for PHP καθιστά εύκολο τη δημιουργία, επεξεργασία και κλώνο πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, ενισχύοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως βρίσκονται σε πλαίσια κειμένου ή σχήματα. Επομένως, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει να προσθέσετε ένα πλαίσιο κειμένου και στη συνέχεια να βάλετε κάποιο κείμενο μέσα στο πλαίσιο. Το Aspose.Slides for PHP μέσω Java παρέχει την κλάση [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) που σας επιτρέπει να προσθέσετε σχήμα που περιέχει κάποιο κείμενο.

{{% alert title="Info" color="info" %}}
Το Aspose.Slides παρέχει επίσης την κλάση [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) που επιτρέπει την προσθήκη σχημάτων σε διαφάνειες. Ωστόσο, δεν όλα τα σχήματα που προστίθενται μέσω της κλάσης `Shape` μπορούν να περιέχουν κείμενο. Αλλά τα σχήματα που προστίθενται μέσω της κλάσης [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) μπορεί να περιέχουν κείμενο.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Επομένως, όταν εργάζεστε με ένα σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θελήσετε να ελέγξετε και να επιβεβαιώσετε ότι έχει μετατραπεί μέσω της κλάσης `AutoShape`. Μόνο τότε θα μπορέσετε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/), το οποίο είναι ιδιότητα της `AutoShape`. Δείτε την ενότητα [Ενημέρωση κειμένου](/slides/el/php-java/manage-textbox/#update-text) σε αυτή τη σελίδα.
{{% /alert %}}

## **Δημιουργία Πλαισίου Κειμένου σε Διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά για την πρώτη διαφάνεια στην πρόσφατα δημιουργημένη παρουσίαση. 
3. Προσθέστε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) με τύπο σχήματος ορισμένο σε [Rectangle](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapetype/#Rectangle) σε καθορισμένη θέση στη διαφάνεια και αποκτήστε την αναφορά για το νεοδημιουργημένο αντικείμενο `AutoShape`.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε αυτό το κείμενο: *Aspose TextBox*
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας PHP—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```php
  # Δημιουργεί παρουσίαση
  $pres = new Presentation();
  try {
    # Λαμβάνει τη πρώτη διαφάνεια στην παρουσίαση
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθέτει AutoShape με τύπο ορισμένο ως Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Προσθέτει TextFrame στο Rectangle
    $ashp->addTextFrame(" ");
    # Αποκτά πρόσβαση στο πλαίσιο κειμένου
    $txtFrame = $ashp->getTextFrame();
    # Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Δημιουργεί ένα αντικείμενο Portion για το παράγραφο
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

## **Έλεγχος για Σχήμα Πλαισίου Κειμένου**

Το Aspose.Slides παρέχει τη μέθοδο [isTextBox](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/istextbox/) από την κλάση [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) που σας επιτρέπει να εξετάσετε σχήματα και να εντοπίσετε πλαίσια κειμένου.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Αυτός ο κώδικας PHP σας δείχνει πώς να ελέγξετε εάν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Σημειώστε ότι εάν απλώς προσθέσετε ένα autoshape χρησιμοποιώντας τη μέθοδο `addAutoShape` από την κλάση [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/), η μέθοδος `isTextBox` του autoshape θα επιστρέψει `false`. Ωστόσο, αφού προσθέσετε κείμενο στο autoshape χρησιμοποιώντας τη μέθοδο `addTextFrame` ή τη μέθοδο `setText`, η ιδιότητα `isTextBox` θα επιστρέψει `true`.

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

## **Προσθήκη Στηλών σε Πλαίσιο Κειμένου**

Το Aspose.Slides παρέχει τις μεθόδους [setColumnCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setcolumncount/) και [setColumnSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setcolumnspacing/) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/) που σας επιτρέπουν να προσθέσετε στήλες σε πλαίσια κειμένου. Μπορείτε να καθορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και το διάστημα μεταξύ των στηλών σε πόντους.

Αυτός ο κώδικας επιδεικνύει τη περιγραφόμενη λειτουργία:

```php
  $pres = new Presentation();
  try {
    # Λαμβάνει τη πρώτη διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθέτει AutoShape με τύπο ορισμένο ως Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Προσθέτει TextFrame στο Rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Λαμβάνει τη μορφοποίηση κειμένου του TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Καθορίζει τον αριθμό των στηλών στο TextFrame
    $format->setColumnCount(3);
    # Καθορίζει το διάστημα μεταξύ των στηλών
    $format->setColumnSpacing(10);
    # Αποθηκεύει την παρουσίαση
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη Στηλών σε Πλαίσιο Κειμένου**

Το Aspose.Slides for PHP μέσω Java παρέχει τη μέθοδο [setColumnCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setcolumncount/) από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/) που επιτρέπει την προσθήκη στηλών σε πλαίσια κειμένου. Μέσω αυτής της ιδιότητας, μπορείτε να καθορίσετε τον προτιμώμενο αριθμό στηλών σε ένα πλαίσιο κειμένου.

Αυτός ο κώδικας PHP σας δείχνει πώς να προσθέσετε μια στήλη μέσα σε ένα πλαίσιο κειμένου:

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

## **Ενημέρωση Κειμένου**

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλο το κείμενο που περιέχεται σε μια παρουσίαση. 

Αυτός ο κώδικας PHP επιδεικνύει μια λειτουργία όπου όλα τα κείμενα σε μια παρουσίαση ενημερώνονται ή τροποποιούνται:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Ελέγχει εάν το σχήμα υποστηρίζει πλαίσιο κειμένου (IAutoShape).
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

## **Προσθήκη Πλαισίου Κειμένου με Υπερσύνδεσμο** 

Μπορείτε να εισάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν το πλαίσιο κειμένου κάνει κλικ, οι χρήστες μεταφέρονται για να ανοίξουν τον σύνδεσμο. 

Για να προσθέσετε ένα πλαίσιο κειμένου που περιέχει σύνδεσμο, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation`. 
2. Αποκτήστε μια αναφορά για την πρώτη διαφάνεια στην πρόσφατα δημιουργημένη παρουσίαση. 
3. Προσθέστε ένα αντικείμενο `AutoShape` με `ShapeType` ορισμένο ως `Rectangle` σε καθορισμένη θέση στη διαφάνεια και αποκτήστε την αναφορά του νεοδημιουργημένου αντικειμένου AutoShape.
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που περιέχει *Aspose TextBox* ως προεπιλεγμένο κείμενο. 
5. Δημιουργήστε ένα αντικείμενο της κλάσης `HyperlinkManager`. 
6. Εκχωρήστε έναν υπερσύνδεσμο χρησιμοποιώντας τη μέθοδο [setExternalHyperlinkClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) που συνδέεται με το επιθυμητό τμήμα του `TextFrame`.
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας PHP—μια υλοποίηση των παραπάνω βημάτων—σας δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```php
  # Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθέτει ένα αντικείμενο AutoShape με τύπο ορισμένο ως Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Μετατρέπει το σχήμα σε AutoShape
    $pptxAutoShape = $shape;
    # Πρόσβαση στην ιδιότητα ITextFrame που συσχετίζεται με το AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Προσθέτει κάποιο κείμενο στο πλαίσιο
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

## **Συχνές Ερωτήσεις**

**What’s the difference between a text box and a text placeholder when working with master slides?**

A [placeholder](/slides/el/php-java/manage-placeholder/) inherits style/position from the [master](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/) and can be overridden on [layouts](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/), whereas a regular text box is an independent object on a specific slide and doesn’t change when you switch layouts.

**How can I perform a bulk text replacement across the presentation without touching text inside charts, tables, and SmartArt?**

Limit your iteration to auto-shapes that have text frames and exclude embedded objects ([charts](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/)) by traversing their collections separately or skipping those object types.