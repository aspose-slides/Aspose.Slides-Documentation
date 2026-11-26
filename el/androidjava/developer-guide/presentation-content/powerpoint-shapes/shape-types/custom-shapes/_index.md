---
title: Προσαρμογή Σχημάτων Παρουσίασης σε Android
linktitle: Προσαρμοσμένο Σχήμα
type: docs
weight: 20
url: /el/androidjava/custom-shape/
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
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Android μέσω Java: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία των σχημάτων μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) και [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομών, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Επίσης παρουσιάζεται πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να δημιουργήσετε σχήματα με καμπυλωτές γωνίες, να προσδιορίσετε εάν μια γεωμετρία σχήματος είναι κλειστή και να εξετάσετε τα στοιχεία του σχήματος χρησιμοποιώντας πίνακες σημείων Android.

## **Αλλαγή Σχήματος μέσω Σημείων Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Edit Points** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σάς επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Καθώς επεξεργάζεστε σχήματα PowerPoint, να θυμάστε τα εξής:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι είτε κλειστό είτε ανοιχτό.
* Η διαδρομή ενός σχήματος αποτελείται από σημεία άγκυρας που συνδέονται με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή καμπυλωτό. Τα σημεία άγκυρας και οι χειρολαβές ελέγχουν το σχήμα του.
* Τα σημεία άγκυρας υπάρχουν ως γωνιακά σημεία, ευθύγραμμα σημεία ή ομαλά σημεία:
  * Σε γωνιακό σημείο, τα σύμπλεγγα τμήματα μπορούν να συναντηθούν σε γωνία.
  * Σε ομαλό σημείο, οι δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένες και ισαπέχουν από το σημείο άγκυρας.
  * Σε ευθύγραμμο σημείο, οι δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένες αλλά μπορεί να έχουν διαφορετικές αποστάσεις από το σημείο άγκυρας.
* Η μετακίνηση των σημείων άγκυρας ή η ρύθμιση των χειρολαβών τους αλλάζει το περίγραμμα του σχήματος.

Για την επεξεργασία σχημάτων PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) και τη διεπαφή [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Μία παρουσίαση [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) αντιπροσωπεύει τη διαδρομή γεωμετρίας του αντικειμένου [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Για να λάβετε το [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) από την παρουσίαση [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε τις μεθόδους: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) για σχήματα με μία μόνο διαδρομή και [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) για σχήματα με πολλαπλές διαδρομές.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους της [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* Χρησιμοποιώντας τις μεθόδους [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) και [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Μέσω της μεθόδου [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--), μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων διαδρομής.

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε μια διαδρομή γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη θέση αυτή στο μηδενικό‑βάση πίνακα τμημάτων της διαδρομής.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή ευθείας γραμμής. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Προσθήκη ή εισαγωγή κυρτής καμπύλης Bézier τρίτου βαθμού με δύο σημεία ελέγχου και σημείο λήξης. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Προσθήκη ή εισαγωγή τετραγωνικής καμπύλης Bézier με ένα σημείο ελέγχου και σημείο λήξης. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Προσθήκη ελλειπτικού τόξου με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το σημείο λήξης του με το σημείο εκκίνησης. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Ορισμός του σημείου εκκίνησης ενός σχήματος. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Αφαίρεση τμήματος με μηδενική‑βάση δείκτη. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας το [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) και εφαρμόζει τη διορθωμένη διαδρομή με το [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 μονάδες από τα αριστερά και 50 μονάδες από το πάνω. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν πάνω και κάτω πλευρά, τραβώντας αυτές τις πλευρές προς τα μέσα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

Αυτό το παράδειγμα τροποποιεί το περίγραμμα μιας καρδιάς αφαιρώντας το τμήμα με μηδενική‑βάση δείκτη 2 χρησιμοποιώντας το [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Η εφαρμογή της τροποποιημένης διαδρομής με το [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ενημερώνει το περίγραμμα του σχήματος.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα δημιουργεί ένα πεντάπλευρο αστέρι με τη [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 μονάδες καθορίζουν τις άκρες και τις εσοχές· βήμα 72 μοιρών χωρίζει ισόποσα τις πέντε κορυφές. Η διαδρομή κλείνεται με τη [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) και εφαρμόζεται σε ένα ορθογώνιο σχήμα μέσω του [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), αντικαθιστώντας το προηγούμενο περίγραμμα.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα ορίζει δύο κλειστές [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) για το επάνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο διαδρομών με το [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) δημιουργεί ένα ενιαίο σύνθετο σχήμα με κενό στη μέση του.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπυλωτές Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθείες τμήματα με το [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) για να δημιουργήσει ένα σχήμα με εσωτερικές καμπυλωτές γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος του τόξου σε μονάδες, και το άνοιγμα -90 μοιρών σχεδιάζει ένα αντίστροφο τετράγωνο ελλειπτικό τόξο. Η ολοκληρωμένη διαδρομή εφαρμόζεται με το [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Εάν η Γεωμετρία Σχήματος είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει εάν κάθε μη κενή διαδρομή γεωμετρίας τελειώνει με τμήμα κλεισίματος. Διαβάζει το [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) και συγκρίνει την τελική εντολή του τμήματος [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) με το [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενές διαδρομές. Ο έλεγχος αφορά μόνο την τελική εντολή κάθε διαδρομής· δεν εξετάζει κάθε υποσχήμα εντός μιας διαδρομής. Το παράδειγμα εκτυπώνει `true` για ένα ορθογώνιο.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Εξέταση Εντολών Διαδρομής Γεωμετρίας**

Κατεβάστε το αρχείο [contour.pptx](contour.pptx) και αντικαταστήστε το όνομα δείγματος με τη διαδρομή του στο τηλέφωνό σας. Το πρώτο σχήμα στην πρώτη διαφάνεια έχει μια ευθεία πάνω άκρη, μια κυρτή Bézier καμπύλη και μια ευθεία κλειστική άκρη. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) για να διαβάσετε τις διαδρομές του σχήματος και το [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) για να διαβάσετε τα τμήματα κάθε διαδρομής με τη σειρά σχεδίασης. Για κάθε τμήμα, η μέθοδος [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) προσδιορίζει την εντολή και καθορίζει πώς να ερμηνευτούν οι τιμές που επιστρέφει το [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--).

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

Το σχήμα βρίσκεται στη θέση (200, 100) μονάδες στη διαφάνεια. Οι αναφερόμενες συντεταγμένες είναι τοπικές στο σχήμα, με (0, 0) στην άνω αριστερή γωνία, το x αυξάνει προς τα δεξιά και το y αυξάνει προς τα κάτω. Το τμήμα κλεισίματος επιστρέφει στο σημείο εκκίνησης χωρίς επιπλέον συντεταγμένες.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Εξαγωγή και Εξέταση Στοιχείων Σχήματος**

Χρησιμοποιήστε το [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) για να εξετάσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία διαδρομής και τύπους σημείων. Μετατρέψτε κάθε επιστραφόμενο [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) σε [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) για να λάβετε τους πίνακες σημείων και τύπων μέσω των μεθόδων [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) και [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγραμμάτων ή για μετάδοση γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει το `input.pptx`, βρίσκει το πρώτο σχήμα γεωμετρίας απευθείας στην πρώτη διαφάνεια και εκτυπώνει τα τμήματα της διαδρομής του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθείες και καμπυλωτές πλευρές για να δείτε και τις δύο μορφές εξόδου. Δεν γίνεται αναζήτηση εντός ομάδων.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Διατηρήστε τον τύπο τμήματος, εξαιρουμένων των σημαιών.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει το ρόλο του. Ο τύπος `0` ξεκινά ένα σχήμα, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα Bézier τρίτου βαθμού ξεκινά από το προηγούμενο σημείο λήξης και χρησιμοποιεί τρεις διαδοχικές τιμές τύπου `3`: δύο σημεία ελέγχου και το νέο σημείο λήξης. Ο βρόχος καταναλώνει αυτές τις τρεις καταχωρήσεις μαζί και ελέγχει το σημείο λήξης για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Κάντε μάσκα με `0x07` για να εντοπίσετε τον τύπο τμήματος, και ελέγξτε το `0x80` ξεχωριστά για να ανιχνεύσετε μια κλειστή υποδιαδρομή. Για παράδειγμα, `129` (`0x81`) σημαίνει σημείο λήξης γραμμής που κλείνει μια υποδιαδρομή, και `131` (`0x83`) σημαίνει σημείο λήξης Bézier που κλείνει μια. Η Java αποθηκεύει αυτές τις σημαίες σε υπογραφόμενα bytes· η μάσκα διατηρεί τις προοριζόμενες τιμές bit. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως το dash (`0x10`) και το marker (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρώνται σε μονάδες (1/72 ίντσας), με το X να αυξάνει προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση που επιστρέφουν οι μέθοδοι [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) και [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--), καθώς και το τρέχον πλάτος και ύψος. Π.χ., ένα μη περιστραμένο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέτετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και Y για να λάβετε συντεταγμένες σχετικές με το μη περιστραμένο πλαίσιο.

Τα εξαγόμενα σημεία δεν εφαρμόζουν την περιστροφή του σχήματος, που επιστρέφεται από το [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), ούτε τις οριζόντιες/κάθετες αναστροφές. Για να αποδομήσετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτές τις μετατροπές γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων ομάδας και τις μετατροπές· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόστε διπλή μετάφραση ή κλίμακα αν ήδη ενσωματώνονται στο πλαίσιο του παιδιού.

**Εξέταση έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτή τη μέθοδο όταν η ανάλυση ή ο κώδικας σχεδίασης χρειάζονται πίνακες σημείων/τύπων. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τις επεξεργασμένες διαδρομές μέσω του [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ή του [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Συχνές Ερωτήσεις**

**Τι συμβαίνει με τη γέμιση και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γέμιση και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς μπορώ σωστά να περιστρέψω ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) του σχήματος· η γεωμετρία περιστρέφεται μαζί επειδή είναι δεσμευμένη στο σύστημα συντεταγμένων του σχήματος.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να "κλειδώσω" το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή της [slide](/slides/el/androidjava/convert-powerpoint-to-png/) ή το [shape](/slides/el/androidjava/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί περαιτέρω εργασία με πολύπλοκες γεωμετρίες.