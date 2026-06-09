---
title: Λήψη Ορίων Παραγράφων από Παρουσιάσεις σε PHP
linktitle: Παράγραφος
type: docs
weight: 60
url: /el/php-java/paragraph/
keywords:
- όρια παραγράφου
- όρια τμήματος κειμένου
- συντεταγμένη παραγράφου
- συντεταγμένη τμήματος
- μέγεθος παραγράφου
- μέγεθος τμήματος κειμένου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφων και τμημάτων κειμένου στο Aspose.Slides για PHP μέσω Java για βελτιστοποίηση της θέσης κειμένου σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λάβετε τα όρια, το μέγεθος και τις συντεταγμένες παραγράφων και τμημάτων κειμένου στο Aspose.Slides. Δείχνει πώς να ανακτήσετε το ορθογώνιο μιας παραγράφου σε ένα `TextFrame` χρησιμοποιώντας τη `getRect()`, πώς να λάβετε τις συντεταγμένες παραγράφου και τμήματος μέσα σε ένα πλαίσιο κειμένου κελιού πίνακα, και υπογραμμίζει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίδραση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixels και οι τιμές αποτελεσματικής μορφοποίησης παραγράφου.

## **Λήψη Συντεταγμένων Παραγράφων και Τμημάτων σε TextFrame**
Χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java, οι προγραμματιστές μπορούν πλέον να λάβουν τις ορθογώνιες συντεταγμένες για την Paragraph μέσα στη συλλογή παραγράφων του TextFrame. Επιτρέπει επίσης τη λήψη των [συντεταγμένων του τμήματος](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#getCoordinates) μέσα στη συλλογή τμημάτων μιας παραγράφου. Σε αυτό το θέμα, θα δείξουμε με τη βοήθεια ενός παραδείγματος πώς να λάβετε τις ορθογώνιες συντεταγμένες για την παράγραφο μαζί με τη θέση του τμήματος μέσα στην παράγραφο.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **Λήψη Ορθογώνιων Συντεταγμένων Παραγράφου**
Χρησιμοποιώντας τη μέθοδο [**getRect()**](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getRect), οι προγραμματιστές μπορούν να λάβουν το ορθογώνιο των ορίων της παραγράφου.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Λήψη του Μεγέθους Παραγράφου και Τμήματος μέσα σε TextFrame Κελιού Πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες του [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/Portion) ή του [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/Paragraph) σε ένα πλαίσιο κειμένου κελιού πίνακα, μπορείτε να χρησιμοποιήσετε τις μεθόδους [Portion::getRect](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#getRect) και [Paragraph::getRect](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getRect).

Αυτός ο κώδικας δείγματος δείχνει τη περιγραφείσα λειτουργία:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Σε ποιες μονάδες επιστρέφονται οι συντεταγμένες για μια παράγραφο και τμήματα κειμένου;**

Σε points, όπου 1 ίντσα = 72 points. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν η [αναδίπλωση](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setwraptext/) είναι ενεργοποιημένη στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/), το κείμενο χωρίζεται ώστε να ταιριάζει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες της παραγράφου να χαρτογραφηθούν αξιόπιστα σε pixels στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τα points σε pixels χρησιμοποιώντας: pixels = points × (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για απόδοση/εξαγωγή.

**Πώς μπορώ να λάβω τις «αποτελεσματικές» παραμέτρους μορφοποίησης παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα του στυλ;**

Χρησιμοποιήστε τη [δομή δεδομένων αποτελεσματικής μορφοποίησης παραγράφου](/slides/el/php-java/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.