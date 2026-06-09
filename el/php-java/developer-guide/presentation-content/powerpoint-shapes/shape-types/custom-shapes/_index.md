---
title: "Προσαρμογή Σχημάτων Παρουσίασης σε PHP"
linktitle: "Προσαρμοσμένο Σχήμα"
type: docs
weight: 20
url: /el/php-java/custom-shape/
keywords:
- "προσαρμοσμένο σχήμα"
- "προσθήκη σχήματος"
- "δημιουργία σχήματος"
- "αλλαγή σχήματος"
- "γεωμετρία σχήματος"
- "γεωμετρική διαδρομή"
- "σημεία διαδρομής"
- "σημεία επεξεργασίας"
- "προσθήκη σημείου"
- "αφαίρεση σημείου"
- "λειτουργία επεξεργασίας"
- "καμπυλωμένη γωνία"
- "PowerPoint"
- "παρουσίαση"
- "PHP"
- "Aspose.Slides"
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java: γεωμετρικές διαδρομές, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντάς τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με `GeometryPath` για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομών, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία σε ένα σχήμα.

Δemonstra επίσης πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να κατασκευάσετε σχήματα με καμπύλες γωνίες, να καθορίσετε αν η γεωμετρία ενός σχήματος είναι κλειστή και να μετατρέψετε μεταξύ `GeometryPath` και `java.awt.Shape` για επιπλέον σενάρια προσαρμογής γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Θεωρήστε ένα τετράγωνο. Στο PowerPoint, χρησιμοποιώντας **σημεία επεξεργασίας**, μπορείτε

* να μετακινήσετε τη γωνία του τετράγωνου προς τα μέσα ή προς τα έξω
* να ορίσετε την καμπυλότητα μιας γωνίας ή ενός σημείου
* να προσθέσετε νέα σημεία στο τετράγωνο
* να χειριστείτε τα σημεία του τετράγωνου κ.λπ.

Βασικά, μπορείτε να εκτελέσετε αυτές τις εργασίες σε οποιοδήποτε σχήμα. Χρησιμοποιώντας σημεία επεξεργασίας, μπορείτε να αλλάξετε ένα σχήμα ή να δημιουργήσετε νέο σχήμα από ένα υπάρχον σχήμα.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Πριν ξεκινήσετε την επεξεργασία σ Shape PowerPoint μέσω σημείων επεξεργασίας, ίσως θέλετε να λάβετε υπόψη τα εξής σημεία σχετικά με τα σχήματα:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι κλειστό ή ανοιχτό.
* Όταν ένα σχήμα είναι κλειστό, δεν έχει σημείο εκκίνησης ή λήξης. Όταν ένα σχήμα είναι ανοιχτό, έχει αρχή και τέλος. 
* Όλα τα σχήματα αποτελούνται από τουλάχιστον 2 άγκυρα σημεία συνδεδεμένα μεταξύ τους με γραμμές
* Μια γραμμή μπορεί να είναι ευθεία ή καμπυλωτή. Τα άγκυρα σημεία καθορίζουν τη φύση της γραμμής. 
* Τα άγκυρα σημεία υπάρχουν ως σημεία γωνίας, ευθείες σημεία ή ομαλά σημεία:
  * Ένα σημείο γωνίας είναι ένα σημείο όπου δύο ευθείες γραμμές συναντώνται υπό γωνία. 
  * Ένα ομαλό σημείο είναι ένα σημείο όπου δύο χειρολαβές βρίσκονται σε ευθεία γραμμή και τα τμήματα της γραμμής ενώνονται σε ομαλή καμπύλη. Σε αυτή την περίπτωση, όλες οι χειρολαβές είναι χωρισμένες από το άγκυρα σημείο στην ίδια απόσταση. 
  * Ένα ευθύ σημείο είναι ένα σημείο όπου δύο χειρολαβές βρίσκονται σε ευθεία γραμμή και τα τμήματα της γραμμής ενώνονται σε ομαλή καμπύλη. Σε αυτή την περίπτωση, δεν είναι απαραίτητο οι χειρολαβές να είναι χωρισμένες από το άγκυρα σημείο στην ίδια απόσταση. 
* Με τη μετακίνηση ή την επεξεργασία των άγκυρα σημείων (που αλλάζει τη γωνία των γραμμών), μπορείτε να αλλάξετε την εμφάνιση ενός σχήματος. 

Για να επεξεργαστείτε σχήματα PowerPoint μέσω σημείων επεξεργασίας, **Aspose.Slides** παρέχει την κλάση [**GeometryPath**](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryPath).

* Ένα [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryPath) αντικείμενο αντιπροσωπεύει μια γεωμετρική διαδρομή του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometryshape/).
* Για να αποκτήσετε το`GeometryPath` από το αντικείμενο `GeometryShape`, μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Για να ορίσετε το `GeometryPath` σε ένα σχήμα, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometryshape/#setGeometryPath) για *συμπαγή σχήματα* και [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometryshape/#setGeometryPaths) για *σύνθετα σχήματα*.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους κάτω από [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometrypath/).
* Χρησιμοποιώντας τις μεθόδους [GeometryPath::setStroke](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometrypath/setstroke/) και [GeometryPath::setFillMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometrypath/setfillmode/), μπορείτε να ορίσετε την εμφάνιση μιας γεωμετρικής διαδρομής.
* Χρησιμοποιώντας τη μέθοδο [GeometryPath::getPathData](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometrypath/getpathdata/) μπορείτε να ανακτήσετε τη γεωμετρική διαδρομή ενός `GeometryShape` ως πίνακα τμημάτων διαδρομής.
* Για να έχετε πρόσβαση σε πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometrypath/) σε [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
* Χρησιμοποιήστε τις μεθόδους [geometryPathToGraphicsPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) και [graphicsPathToGeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (από την κλάση [ShapeUtil](https://reference.aspose.com/slides/el/php-java/aspose.slides/ShapeUtil)) για να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometrypath/) σε [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) και αντίστροφα.

## **Απλές Λειτουργίες Επεξεργασίας**

Αυτός ο κώδικας PHP σας δείχνει πώς να

**Προσθήκη γραμμής** στο τέλος μιας διαδρομής

```php

```
**Προσθήκη γραμμής** σε καθορισμένη θέση μιας διαδρομής:

```php

```
**Προσθήκη κυβικής καμπύλης Bezier** στο τέλος μιας διαδρομής:

```php

```
**Προσθήκη κυβικής καμπύλης Bezier** στην καθορισμένη θέση μιας διαδρομής:

```php

```
**Προσθήκη τετραγωνικής καμπύλης Bezier** στο τέλος μιας διαδρομής:

```php

```
**Προσθήκη τετραγωνικής καμπύλης Bezier** στην καθορισμένη θέση μιας διαδρομής:

```php

```
**Προσθήκη δεδομένου τόξου** σε μια διαδρομή:

```php

```
**Κλείσιμο του τρέχοντος σχήματος** μιας διαδρομής:

```php

```
**Ορισμός θέσης για το επόμενο σημείο**:

```php

```
**Αφαίρεση τμήματος διαδρομής** σε δεδομένο δείκτη:

```php

```

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryShape) και ορίστε τον τύπο [ShapeType::Rectangle](https://reference.aspose.com/slides/el/php-java/aspose.slides/ShapeType).
2. Λάβετε μια παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryPath) από το σχήμα.
3. Προσθέστε ένα νέο σημείο μεταξύ των δύο άνω σημείων της διαδρομής.
4. Προσθέστε ένα νέο σημείο μεταξύ των δύο κάτω σημείων της διαδρομής.
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας PHP σας δείχνει πώς να προσθέσετε προσαρμοσμένα σημεία σε ένα σχήμα:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryShape) και ορίστε τον τύπο [ShapeType::Heart](https://reference.aspose.com/slides/el/php-java/aspose.slides/ShapeType).
2. Λάβετε μια παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryPath) από το σχήμα.
3. Αφαιρέστε το τμήμα της διαδρομής.
4. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας PHP σας δείχνει πώς να αφαιρέσετε σημεία από ένα σχήμα:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

## **Create a Custom Shape**

1. Υπολογίστε τα σημεία του σχήματος.
2. Δημιουργήστε μια παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryPath).
3. Γεμίστε τη διαδρομή με τα σημεία.
4. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryShape).
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας Java σας δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα:

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **Create a Composite Custom Shape**

  1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryShape).
  2. Δημιουργήστε την πρώτη παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryPath).
  3. Δημιουργήστε τη δεύτερη παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryPath).
  4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτός ο κώδικας PHP σας δείχνει πώς να δημιουργήσετε ένα σύνθετο προσαρμοσμένο σχήμα:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **Create a Custom Shape with Curved Corners**

Αυτός ο κώδικας PHP σας δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα με καμπυλωτές γωνίες (προς τα μέσα);

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Find Out If a Shape Geometry Is Closed**

Ένα κλειστό σχήμα ορίζεται ως εκείνο όπου όλες οι πλευρές του συνδέονται, σχηματίζοντας ένα ενιαίο σύνορο χωρίς κενά. Ένα τέτοιο σχήμα μπορεί να είναι μια απλή γεωμετρική μορφή ή ένα πολύπλοκο προσαρμοσμένο περίγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ελέγξετε αν η γεωμετρία ενός σχήματος είναι κλειστή:

```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```

## **Convert GeometryPath to java.awt.Shape**

1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryShape).
2. Δημιουργήστε μια παρουσία της κλάσης [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Μετατρέψτε την παρουσία [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) στην παρουσία [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/GeometryPath) χρησιμοποιώντας το [ShapeUtil](https://reference.aspose.com/slides/el/php-java/aspose.slides/ShapeUtil).
4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτός ο κώδικας PHP—μια υλοποίηση των παραπάνω βημάτων—δείχνει τη διαδικασία μετατροπής **GeometryPath** σε **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # Δημιουργία νέου σχήματος
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Λήψη διαδρομής γεωμετρίας του σχήματος
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Δημιουργία νέας διαδρομής γραφικών με κείμενο
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Μετατροπή διαδρομής γραφικών σε διαδρομή γεωμετρίας
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Ορισμός συνδυασμού νέας διαδρομής γεωμετρίας και αρχικής διαδρομής γεωμετρίας στο σχήμα
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **Συχνές Ερωτήσεις**

**Τι θα συμβεί στη γέμιση και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γέμιση και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς μπορώ να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/setrotation/) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να "κλειδώσω" το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή [διαφάνειας](/slides/el/php-java/convert-powerpoint-to-png/) ή το ίδιο το [σχήμα](/slides/el/php-java/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με πολύπλοκες γεωμετρίες.