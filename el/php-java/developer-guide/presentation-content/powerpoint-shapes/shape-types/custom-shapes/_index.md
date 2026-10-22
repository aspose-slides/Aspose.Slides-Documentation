---
title: Προσαρμογή Σχημάτων Παρουσίασης σε PHP
linktitle: Προσαρμοσμένο Σχήμα
type: docs
weight: 20
url: /el/php-java/custom-shape/
keywords:
- προσαρμοσμένο σχήμα
- προσθήκη σχήματος
- δημιουργία σχήματος
- αλλαγή σχήματος
- γεωμετρία σχήματος
- διαδρομή γεωμετρίας
- σημεία διαδρομής
- σημεία επεξεργασίας
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- καμπυλωμένη γωνία
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργαστείτε με [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία σε ένα σχήμα.

Δemonstra επίσης πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να χτίσετε σχήματα με καμπυλωμένες γωνίες, να καθορίσετε εάν η γεωμετρία ενός σχήματος είναι κλειστή, να επιθεωρήσετε τα στοιχεία του σχήματος και να μετατρέψετε τα περίγραμμα κειμένου Java AWT σε διαδρομές γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Σημεία Επεξεργασίας** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Κατά την επεξεργασία σχημάτων PowerPoint, κρατήστε αυτά τα concepts στο μυαλό:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι είτε κλειστό είτε ανοιχτό.
* Η διαδρομή ενός σχήματος αποτελείται από anchor points συνδεδεμένα με segments.
* Ένα segment μπορεί να είναι straight ή curved. Τα anchor points και τα control handles καθορίζουν το σχήμα του.
* Τα anchor points υπάρχουν ως corner points, straight points ή smooth points:
  * Σε ένα corner point, τα γειτονικά segments μπορούν να συναντιούνται με γωνία.
  * Σε ένα smooth point, τα δύο control handles είναι ευθυγραμμισμένα και ισαπέχουν από το anchor point.
  * Σε ένα straight point, τα δύο control handles είναι ευθυγραμμισμένα αλλά μπορούν να έχουν διαφορετικές αποστάσεις από το anchor point.
* Η μετακίνηση των anchor points ή η προσαρμογή των handles τους αλλάζει το περίγραμμα του σχήματος.

Για επεξεργασία σχημάτων PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Ένα αντικείμενο [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) από το αντικείμενο [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) για ένα σ Shape, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) για σ Shape με μία διαδρομή και [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) για σ Shape με πολλαπλές διαδρομές.
* Για να προσθέσετε segments, μπορείτε να χρησιμοποιήσετε τις μεθόδους κάτω από [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Χρησιμοποιώντας τις μεθόδους [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) και [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Με τη μέθοδο [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData), μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) ως πίνακα δια segments.
* Για πρόσβαση σε πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να διαβάσετε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) μέσω του [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) και να επαναλάβετε τα segments σε ένα [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε μια διαδρομή γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα segment στη συγκεκριμένη θέση μηδενικής βάσης στον πίνακα segments της διαδρομής.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή ευθείας γραμμής. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Προσθήκη ή εισαγωγή κυρτής Bézier καμπύλης με δύο control points και ένα endpoint. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Προσθήκη ή εισαγωγή τετραγωνικής Bézier καμπύλης με ένα control point και ένα endpoint. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Προσθήκη ελλειπτικού τόξου με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το endpoint του με το αρχικό του σημείο. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Ορισμός του αρχικού σημείου ενός σχήματος. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Αφαίρεση segment σε δείκτη μηδενικής βάσης. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) και εφαρμόζει τη διόρθωση διαδρομής με [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Οι συντεταγμένες είναι τοπικές στο σ Shape: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 σημεία από τα αριστερά και 50 σημεία από την κορυφή. Οι δείκτες των segments 1 και 4 τα τοποθετούν στις άνω και κάτω άκρες, τραβώντας αυτές τις άκρες προς το εσωτερικό.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

Αυτό το παράδειγμα αλλάζει το περίγραμμα ενός σχήματος σε σχήμα καρδιάς αφαιρώντας το segment στη θέση μηδενικής βάσης 2 με [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Η εφαρμογή της τροποποιημένης διαδρομής με [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ενημερώνει το περίγραμμα του σ Shape.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα χτίζει ένα πεντάγωνο αστέρι με το [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 points ορίζουν τα άκρα και τις εσοχές· ένα βήμα 72 μοιρών χωρίζει τα πέντε άκρα ισότιμα. Η διαδρομή κλείνει με το [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) και εφαρμόζεται σε ένα ορθογώνιο σ Shape με το [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), αντικαθιστώντας το περίγραμμά του.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα ορίζει δύο κλειστές [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) για το άνω και το κάτω τρίτο ενός σ Shape. Η εφαρμογή και των δύο διαδρομών με το [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) δημιουργεί ένα ενιαίο σύνθετο σ Shape με κενό στο μεσαίο τρίτο.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπυλωμένες Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθείες segments με το [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) για να δημιουργήσει ένα σ Shape με εσωτερικά καμπυλωμένες γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος του τόξου σε points, και η σάρωση -90 μοιρών σχεδιάζει ένα αντίστροφο ανοιγμένο τέταρτο έλλειψης. Η ολοκληρωμένη διαδρομή εφαρμόζεται με το [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Έλεγχος Εάν η Γεωμετρία Σχήματος Είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει εάν κάθε μη κενή διαδρομή γεωμετρίας λήγει με segment κλεισίματος. Διαβάζει το [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) και συγκρίνει την τελική εντολή του segment [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) με το [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενές διαδρομές. Αυτό ελέγχει την τελική εντολή κάθε διαδρομής· δεν επιθεωρεί κάθε υποσχήμα μέσα σε μια διαδρομή. Το παράδειγμα εκτυπώνει `true` για ένα ορθογώνιο.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σχήματος**

Χρησιμοποιήστε το [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) για να επιθεωρήσετε ένα υπάρχον σ Shape ως στοιχεία που περιέχουν σημεία διαδρομής και τύπους σημείων. Χρησιμοποιήστε κάθε επιστρεφόμενο [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) για να ανακτήσετε τους πίνακες σημείων και τύπων μέσω των μεθόδων [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) και [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγράμματος ή για περαιτέρω επεξεργασία γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει το input.pptx, βρίσκει το πρώτο σ Shape γεωμετρίας απευθείας στην πρώτη διαφάνεια και εκτυπώνει τα segments της διαδρομής. Χρησιμοποιήστε μια παρουσίαση που περιέχει σ Shape με ευθείες και καμπυλωτές segments για να δείτε και τις δύο εκδοχές εξόδου. Δεν ψάχνει μέσα σε ομάδες.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Διατήρηση του τύπου του τμήματος, εξαιρώντας τις σημαίες.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consume both control points and the endpoint.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Οι πίνακες αντιστοιχούν κατά δείκτη: `$points[$i]` είναι ένα σημείο και `$types[$i]` περιγράφει το ρόλο του. Ο τύπος `0` ξεκινά μια μορφή, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα segment cubic Bézier ξεκινά από το προηγούμενο endpoint και χρησιμοποιεί τρία διαδοχικά στοιχεία τύπου `3`: δύο control points ακολουθούμενα από το νέο endpoint. Η λούπα καταναλώνει αυτά τα τρία στοιχεία μαζί και ελέγχει το endpoint για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης flags. Χρησιμοποιήστε μάσκα `0x07` για να προσδιορίσετε τον τύπο του segment, και ελέγξτε το `0x80` ξεχωριστά για να εντοπίσετε υποδιαδρομή κλειστή. Για παράδειγμα, `129` (`0x81`) σημαίνει ένα endpoint γραμμής που κλείνει μια υποδιαδρομή, και `131` (`0x83`) σημαίνει ένα endpoint Bézier που κλείνει μία. Η γέφυρα PHP/Java επιστρέφει τον πίνακα byte ως δυαδική συμβολοσειρά· η αποσυμπίεση με `"C*"` παράγει αμεταβλητές τιμές byte. Η μάσκα διατηρεί τις προγραμματισμένες τιμές bit. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα παρέλειπε αυτές τις περιπτώσεις. Άλλα flags, όπως dash (`0x10`) και marker (`0x20`), δεν αλλάζουν τον βασικό τύπο του segment.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετριούνται σε points (1/72 ίντσας), με το X να αυξάνεται προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σ Shape, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση που επιστρέφεται από το [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) και το [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) και αντανακλούν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη περιστρεφόμενο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέσετε ξανά τη θέση του σ Shape. Αφαιρέστε το X και Y του για να πάρετε συντεταγμένες σχετικά με το μη περιστραμμένο πλαίσιο του.

Τα εξαγόμενα σημεία δεν εφαρμόζουν την περιστροφή του σ Shape, που επιστρέφεται από το [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), ή τις οριζόντιες και κάθετες αναστροφές. Για να αναπαραγάγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτούς τους μετασχηματισμούς γύρω από το κέντρο του σ Shape. Για σ Shape σε ομάδες, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων της ομάδας και τους μετασχηματισμούς· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόστε μετάφραση ή κλίμακα δύο φορές αν είναι ήδη ενσωματωμένα στο πλαίσιο του παιδιού.

**Επιθεώρηση εναντίον επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σ Shape. Επιλέξτε αυτήν την προσέγγιση όταν η ανάλυση ή ο κώδικας σχεδίασής σας χρειάζεται πίνακες σημείων/τύπων. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σ Shape ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τις επεξεργασμένες διαδρομές μέσω του [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ή του [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Μετατροπή Java AWT Shape σε GeometryPath**

Αυτό το παράδειγμα συνδυάζει ένα ορθογώνιο περίγραμμα με κείμενο που μετατράπηκε σε γεωμετρία. Η μέθοδος [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) του περιγράμματος απενεργοποιεί το γέμισμα. Ένα [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) δημιουργεί το περίγραμμα κειμένου σε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Ο [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του παρέχει εντολές μετακίνησης, γραμμής, τετραγωνικής, κυρτής και κλεισίματος, που το παράδειγμα επαναλαμβάνει σε ένα [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Το παράδειγμα χρησιμοποιεί έναν πίνακα Java float ώστε η γέφυρα PHP/Java να διατηρήσει τις συντεταγμένες που γράφτηκαν από τον iterator. Το κείμενο χρησιμοποιεί γραμματοσειρά Arial 40 points. Το περίγραμμα μετατοπίζεται 20 points οριζόντια και τοποθετείται ώστε το οπτικό του πάνω έχει 10 points κάτω από την άνω άκρη του σ Shape. Η διαδρομή κειμένου γεμίζει, ενώ το αρχικό ορθογώνιο παραμένει περίγραμμα. Η εφαρμογή και των δύο διαδρομών με το [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) παράγει ένα ενιαίο σ Shape που περιέχει το ορθογώνιο και το κείμενο.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **Συχνές Ερωτήσεις**

**Τι συμβαίνει με το γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σ Shape· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σ Shape μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) του σ Shape· η γεωμετρία περιστρέφεται με το σ Shape επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σ Shape σε εικόνα για να «κλειδώσω» το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη [slide](/slides/el/php-java/convert-powerpoint-to-png/) περιοχή ή το [shape](/slides/el/php-java/create-shape-thumbnails/) ίδιο σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με σύνθετες γεωμετρίες.