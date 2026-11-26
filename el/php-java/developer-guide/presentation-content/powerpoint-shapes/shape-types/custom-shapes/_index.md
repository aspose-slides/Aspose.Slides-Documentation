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
- σημείες επεξεργασίας
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- καμπυλωτή γωνία
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργαστείτε με [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Δείχνει επίσης πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να χτίσετε σχήματα με καμπυλωμένες γωνίες, να προσδιορίσετε αν μια γεωμετρία σχήματος είναι κλειστή, να εξετάσετε τα στοιχεία του σχήματος και να μετατρέψετε τα περιγράμματα κειμένου Java AWT σε διαδρομές γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Σημεία Επεξεργασίας** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς το εσωτερικό ή το εξωτερικό.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθήκη νέων σημείων.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Κατά την επεξεργασία σχημάτων PowerPoint, κρατήστε αυτές τις έννοιες στο μυαλό:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι κλειστό ή ανοικτό.
* Η διαδρομή ενός σχήματος αποτελείται από σημεία αγκύρωσης που συνδέονται με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή κυρτό. Τα σημεία αγκύρωσης και οι χειρολαβές ελέγχου καθορίζουν το σχήμα του.
* Τα σημεία αγκύρωσης εμφανίζονται ως γωνιακά σημεία, ευθείες ή απαλοποιημένα:
  * Σε ένα γωνιακό σημείο, τα γειτονικά τμήματα μπορούν να συναντηθούν με γωνία.
  * Σε ένα απαλοποιημένο σημείο, οι δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένες και ίσου αποστάσεων από το σημείο αγκύρωσης.
  * Σε ένα ευθύ σημείο, οι δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένες αλλά μπορεί να έχουν διαφορετικές αποστάσεις από το σημείο αγκύρωσης.
* Η μετακίνηση των σημείων αγκύρωσης ή η ρύθμιση των χειρολαβών τους αλλάζει το περίγραμμα του σχήματος.

Για την επεξεργασία σχημάτων PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Μία παρουσίαση του [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Για να λάβετε το [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) από την παρουσίαση του [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) για σχήματα με μία μόνο διαδρομή και [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) για σχήματα με πολλαπλές διαδρομές.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους στο [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Χρησιμοποιώντας τις μεθόδους [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) και [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Με τη μέθοδο [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData), μπορείτε να λάβετε τη διαδρομή γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) ως πίνακα τμημάτων διαδρομής.
* Για πρόσβαση σε επιπλέον επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να διαβάσετε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) μέσω του [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) και να επαναλάβετε τα τμήματα σε ένα [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε μια διαδρομή γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη μηδενική θέση του πίνακα τμημάτων της διαδρομής.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή μιας ευθείας γραμμής. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Προσθήκη ή εισαγωγή μιας κυβικής καμπύλης Bézier με δύο σημεία ελέγχου και ένα τελικό σημείο. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Προσθήκη ή εισαγωγή μιας τετραγωνικής καμπύλης Bézier με ένα σημείο ελέγχου και ένα τελικό σημείο. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Προσθήκη ενός ελλειπτικού τόξου με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το τελικό του σημείο με το αρχικό του σημείο. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Ορισμός του αρχικού σημείου ενός σχήματος. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Αφαίρεση ενός τμήματος σε δείκτη μηδενικής βάσης. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογωνικό σχήμα χρησιμοποιώντας [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) και εφαρμόζει τη επεξεργασμένη διαδρομή με [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 μονάδες από τα αριστερά και 50 μονάδες από την κορυφή. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στις άνω και κάτω άκρες, τραβώντας αυτές τις άκρες προς το εσωτερικό.

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

Αυτό το παράδειγμα τροποποιεί το περίγραμμα μιας καρδιάς αφαιρώντας το τμήμα στον δείκτη μηδενικής βάσης 2 με [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Η εφαρμογή της τροποποιημένης διαδρόμου με [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ενημερώνει το περίγραμμα του σχήματος.

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

Αυτό το παράδειγμα δημιουργεί ένα πεντάγωνο αστέρι με το [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες των 100 και 50 μονάδων καθορίζουν τις άκρες και τις εγκοπές· ένα βήμα 72 μοιρών χωρίζει ομοιόμορφα τις πέντε άκρες. Η διαδρομή κλείνει με το [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) και εφαρμόζεται σε ένα ορθογώνιο σχήμα μέσω του [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), αντικαθιστώντας το περίγραμμα του.

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

Αυτό το παράδειγμα ορίζει δύο κλειστές [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) αντικείμενα για το πάνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο διαδρομών με το [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) δημιουργεί ένα ενιαίο σύνθετο σχήμα με ένα κενό διαμέσου του κεντρικού τριτάτου του.

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

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπυλωτές Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθείες τμηματικές με το [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) για να δημιουργήσει ένα σχήμα με εσωτερικά καμπυλωτές γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος του τόξου σε μονάδες, και η στροφή -90 μοιρών σχεδιάζει ένα τέταρτο έλλειψα αριστερόστροφα. Η ολοκληρωμένη διαδρομή εφαρμόζεται με το [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), και η παρουσία αποθηκεύεται σε μορφή PPTX.

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

## **Εύρεση Εάν η Γεωμετρία Σχήματος Είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει εάν κάθε μη-κενή διαδρομή γεωμετρίας τελειώνει με τμήμα κλεισίματος. Διαβάζει το [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) και συγκρίνει την τελική εντολή του τμήματος [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) με το [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη-κενές διαδρομές. Ο έλεγχος αυτός αφορά την τελική εντολή κάθε διαδρομής· δεν εξετάζει κάθε υποσχήμα εντός μιας διαδρομής. Το παράδειγμα εκτυπώνει `true` για ένα ορθογώνιο.

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

## **Επιθεώρηση Εντολών Διαδρομής Γεωμετρίας**

Κατεβάστε το [contour.pptx](contour.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Το πρώτο σχήμα στην πρώτη διαφάνεια έχει μια ευθεία άνω άκρη, μια κυβική καμπύλη Bézier και μια ευθεία κλειστή άκρη. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) για να διαβάσετε τις διαδρομές του σχήματος και το [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) για να διαβάσετε τα τμήματα κάθε διαδρομής με τη σειρά σχεδίασης. Για κάθε τμήμα, το [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) αναγνωρίζει την εντολή και καθορίζει πώς να ερμηνεύσετε τις τιμές που επιστρέφει το [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData).

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

Το σχήμα βρίσκεται στο (200, 100) μονάδες στη διαφάνεια. Οι αναφερόμενες συντεταγμένες είναι τοπικές στο σχήμα, με το (0, 0) στην επάνω‑αριστερή γωνία, x αυξάνεται προς τα δεξιά και y προς τα κάτω. Το τμήμα κλεισίματος επιστρέφει στο αρχικό σημείο χωρίς πρόσθετες συντεταγμένες.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σχήματος**

Χρησιμοποιήστε το [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) για να εξετάσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία διαδρομής και τύπους σημείων. Κάθε επιστρεφόμενα [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) μπορεί να χρησιμοποιηθεί για να ανακτήσει τους πίνακες σημείων και τύπων μέσω των μεθόδων [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) και [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγράμματος ή για μεταφορά γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει το input.pptx, εντοπίζει το πρώτο σχήμα γεωμετρίας απευθείας στην πρώτη διαφάνεια και εκτυπώνει τα τμήματα της διαδρομής του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθείες και καμπύλες τμημάτων για να δείτε και τις δύο μορφές εξόδου. Δεν ψάχνει μέσα σε ομάδες.

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
                $pointType = $types[$i] & 0x07; // Κρατήστε τον τύπο τμήματος, εξαιρώντας τις σημαίες.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Καταναλώστε και τα δύο σημεία ελέγχου και το τελικό σημείο.
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

Οι πίνακες αντιστοιχούν κατά δείκτη: `$points[$i]` είναι ένα σημείο και `$types[$i]` περιγράφει τον ρόλο του. Ο τύπος `0` ξεκινάει ένα σχήμα, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα κυβικής Bézier ξεκινάει στο προηγούμενο τελικό σημείο και χρησιμοποιεί τρία διαδοχικά στοιχεία τύπου `3`: δύο σημεία ελέγχου ακολουθούμενα από το νέο τελικό σημείο. Ο βρόχος καταναλώνει αυτά τα τρία στοιχεία μαζί και ελέγχει το τελικό σημείο για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Εφαρμόστε μάσκα `0x07` για να προσδιορίσετε τον τύπο τμήματος, και δοκιμάστε `0x80` ξεχωριστά για να εντοπίσετε κλειστό υπο‑διαδρομή. Για παράδειγμα, `129` (`0x81`) σημαίνει ένα τελικό σημείο γραμμής που κλείνει μια υπο‑διαδρομή, και `131` (`0x83`) σημαίνει τελικό σημείο Bézier που κλείνει μια. Η γέφυρα PHP/Java επιστρέφει τον πίνακα byte ως δυαδική συμβολοσειρά· η αποσυμπίεση με `"C*"` παράγει ακατέργαστες τιμές byte. Η μάσκα διατηρεί τις προβλεπόμενες τιμές bit. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα παρέλεινε αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρώνται σε μονάδες (1/72 ίντσας), με το X να αυξάνεται προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση που επιστρέφουν οι μέθοδοι [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) και [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) και αντικατοπτρίζουν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη περιστρεφόμενο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέτετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και Y του για να πάρετε συντεταγμένες σχετικές με το μη περιστρεφόμενο πλαίσιο του.

Οι εξαγόμενα σημεία δεν εφαρμόζουν την περιστροφή του σχήματος, που επιστρέφεται από το [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), ή τις οριζόντιες/κατακόρυφες αντιστροφές. Για να αναπαραγάγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτούς τους μετασχηματισμούς γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων της ομάδας και τους μετασχηματισμούς· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόστε διπλή μετάφραση ή κλιμάκωση εάν αυτά ήδη αντικατοπτρίζονται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σ shape. Επιλέξτε αυτήν την προσέγγιση όταν η ανάλυση ή ο κώδικας σχεδίασής σας χρειάζεται πίνακες σημείων/τύπων. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τις επεξεργασμένες διαδρομές μέσω του [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ή του [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Μετατροπή Σχήματος Java AWT σε GeometryPath**

Αυτό το παράδειγμα συνδυάζει ένα ορθογώνιο περίγραμμα με κείμενο που μετατράπηκε σε γεωμετρία. Η μέθοδος [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) του περιγράμματος απενεργοποιεί τη γέμιση. Ένα [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) δημιουργεί το περίγραμμα κειμένου σε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Ο [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του παρέχει κινήσεις, γραμμές, τετραγωνικές, κυβικές και τμήματα κλεισίματος, τα οποία το παράδειγμα επαναλαμβάνει σε ένα [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Το παράδειγμα χρησιμοποιεί έναν πίνακα float Java ώστε η γέφυρα PHP/Java να διατηρήσει τις συντεταγμένες που γράφει ο iterator. Το κείμενο χρησιμοποιεί γραμματοσειρά Arial 40 μονάδων. Το περίγραμμα μετατοπίζεται 20 μονάδες οριζόντια και τοποθετείται με το οπτικό του επάνω μέρος 10 μονάδες κάτω από την άνω άκρη του σχήματος. Η διαδρομή κειμένου γεμίζεται, ενώ το αρχικό ορθογώνιο παραμένει περίγραμμα. Η εφαρμογή και των δύο διαδρομών με το [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) παράγει ένα ενιαίο σχήμα που περιέχει το ορθογώνιο και το κείμενο.

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

**Τι συμβαίνει με τη γέμιση και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γέμιση και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) του σχήματος· η γεωμετρία περιστρέφεται με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να “κλειδώσω” το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη [διαφάνεια](/slides/el/php-java/convert-powerpoint-to-png/) ή το [σχήμα](/slides/el/php-java/create-shape-thumbnails/) στον εαυτό του σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με σύνθετες γεωμετρίες.