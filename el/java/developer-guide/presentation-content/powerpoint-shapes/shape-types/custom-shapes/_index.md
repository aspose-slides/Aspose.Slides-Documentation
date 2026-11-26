---
title: Προσαρμογή Σχημάτων Παρουσίασης σε Java
linktitle: Προσαρμοσμένο Σχήμα
type: docs
weight: 20
url: /el/java/custom-shape/
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
- καμπυλωτή γωνία
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργία και προσαρμογή σχημάτων σε παρουσιάσεις PowerPoint με Aspose.Slides για Java: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) και [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Επίσης, παρουσιάζεται πώς να δημιουργείτε προσαρμοσμένα και σύνθετα σχήματα, να σχεδιάζετε σχήματα με καμπυλωτές γωνίες, να καθορίζετε αν η γεωμετρία ενός σχήματος είναι κλειστή, να ελέγχετε τα στοιχεία του σχήματος και να μετατρέπετε τις γραμμές κειμένου Java AWT σε διαδρομές γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Edit Points** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σάς επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Όταν επεξεργάζεστε σχήματα PowerPoint, διατηρήστε αυτές τις έννοιες στο μυαλό σας:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι είτε κλειστό είτε ανοιχτό.
* Η διαδρομή ενός σχήματος αποτελείται από σημεία αγκύρωσης που συνδέονται με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή καμπυλωτό. Τα σημεία αγκύρωσης και τα χειριστήρια ελέγχου καθορίζουν το σχήμα του.
* Τα σημεία αγκύρωσης υπάρχουν ως σημεία γωνίας, ευθείες σημεία ή λείες (smooth) σημεία:
  * Σε σημείο γωνίας, τα διπλά τμήματα μπορούν να συναντηθούν υπό γωνία.
  * Σε λείο σημείο, οι δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένες και ισαπέχουν από το σημείο αγκύρωσης.
  * Σε ευθύ σημείο, οι δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένες αλλά μπορούν να έχουν διαφορετικές αποστάσεις από το σημείο αγκύρωσης.
* Η μετακίνηση των σημείων αγκύρωσης ή η ρύθμιση των χειρολαβών τους αλλάζει το περίγραμμα του σχήματος.

Για την επεξεργασία σ Shapes PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) και την διεπαφή [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Μια [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) παρουσία αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Για να ανακτήσετε τη [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) από την παρουσία [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Για να ορίσετε τη [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) για σχήματα με μία διαδρομή και [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) για σχήματα με πολλές διαδρομές.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους κάτω από [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).
* Χρησιμοποιώντας τις μεθόδους [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) και [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Χρησιμοποιώντας τη μέθοδο [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--), μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων διαδρομής.
* Για πρόσβαση σε πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να διαβάσετε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) μέσω του [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) και να επαναλάβετε τα τμήματα σε μια [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε μια διαδρομή γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη μηδενική θέση του πίνακα τμημάτων της διαδρομής.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή ευθείας γραμμής. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Προσθήκη ή εισαγωγή καμπύλης κυβικού Bézier με δύο σημεία ελέγχου και ένα σημείο λήξης. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Προσθήκη ή εισαγωγή τετραγωνικής Bézier καμπύλης με ένα σημείο ελέγχου και ένα σημείο λήξης. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Προσθήκη ελλειπτικού τόξου με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το σημείο λήξης του με το αρχικό σημείο. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Ορισμός του αρχικού σημείου ενός σχήματος. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Αφαίρεση ενός τμήματος σε δείκτη μηδενικής βάσης. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) και εφαρμόζει τη διορθωμένη διαδρομή με [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 σημεία από τα αριστερά και 50 σημεία από το πάνω μέρος. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στην επάνω και κάτω άκρη, τραβώντας αυτές τις άκρες προς το κέντρο.

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

Αυτό το παράδειγμα αλλάζει το περίγραμμα ενός σχήματος σε σχήμα καρδιάς αφαιρώντας το τμήμα στη μηδενική θέση με δείκτη 2 με [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Η εφαρμογή της τροποποιημένης διαδρομής με [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ενημερώνει το περίγραμμα του σχήματος.

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

Αυτό το παράδειγμα δημιουργεί έναν πενταπτερείο αστέρι χρησιμοποιώντας [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 σημεία καθορίζουν τις άκρες και τα ενδοσυστήματα· ένα βήμα 72 μοιρών διαστέλλει τις πέντε άκρες ομοιόμορφα. Η διαδρομή κλείνει με [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) και εφαρμόζεται σε ένα ορθογώνιο σχήμα με [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), αντικαθιστώντας το περίγραμμα του.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
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

## **Δημιουργία Συνθετικού Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα ορίζει δύο κλειστές [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) για το άνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο διαδρομών με [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) δημιουργεί ένα ενιαίο σύνθετο σχήμα με ένα κενό στο μεσαίο τρίτο.

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

Αυτό το παράδειγμα συνδυάζει ευθείες τμήματα με [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) για να δημιουργήσει ένα σχήμα με εσωτερικές καμπυλωτές γωνίες. Το μέγεθος κάθε γωνίας ορίζει το πλάτος και το ύψος του τόξου σε σημεία, και η σάρωση -90 μοιρών δημιουργεί ένα αντίστροφο τέταρτο έλλειψη. Η ολοκληρωμένη διαδρομή εφαρμόζεται με [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

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

## **Εύρεση Αν Η Γεωμετρία Σχήματος Είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει αν κάθε μη κενή διαδρομή γεωμετρίας λήγεται με τμήμα κλεισίματος. Διαβάζει το [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) και συγκρίνει την τελική εντολή του τμήματος [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) με [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενές διαδρομές. Αυτό ελέγχει την τελική εντολή κάθε διαδρομής· δεν εξετάζει κάθε υποσχήμα εντός μιας διαδρομής. Το παράδειγμα εκτυπώνει `true` για ένα ορθογώνιο.

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

## **Έλεγχος Εντολών Διαδρομής Γεωμετρίας**

Κατεβάστε το αρχείο [contour.pptx](contour.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Το πρώτο σχήμα στην πρώτη διαφάνεια έχει ευθύ άνω άκρο, καμπύλη κυβικού Bézier και ευθύ κλείσιμο άκρου. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) για να διαβάσετε τις διαδρομές του σχήματος και το [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) για να διαβάσετε τα τμήματα κάθε διαδρομής με σειρά σχεδίασης. Για κάθε τμήμα, το [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) προσδιορίζει την εντολή και καθορίζει πώς να ερμηνεύσετε τις τιμές που επιστρέφει το [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--).

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

Το σχήμα βρίσκεται στο (200, 100) σημεία στη διαφάνεια. Οι αναφερθέντες συντεταγμένες είναι τοπικές στο σχήμα, με (0, 0) στην επάνω αριστερή γωνία, x αυξάνεται προς τα δεξιά και y αυξάνεται προς τα κάτω. Το κλείσιμο τμήματος επιστρέφει στο αρχικό σημείο χωρίς πρόσθετες συντεταγμένες.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Σχήμα PowerPoint με ευθύ άνω άκρο, καμπυλωτό άκρο από την επάνω δεξιά προς την κάτω αριστερή και ευθύ αριστερό άκρο](contour.png)

## **Εξαγωγή και Έλεγχος Στοιχείων Σχήματος**

Χρησιμοποιήστε το [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) για να ελέγξετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία διαδρομής και τύπους σημείου. Μετατρέψτε κάθε επιστρεφόμενο [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) σε [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) για να λάβετε τους πίνακες σημείων και τύπων μέσω των μεθόδων [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) και [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγραμμάτων ή για μεταφορά γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει το input.pptx, βρίσκει το πρώτο σχήμα γεωμετρίας απευθείας στην πρώτη διαφάνεια και εκτυπώνει τα τμήματά του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθείες και καμπυλωτές πλευρές για να δείτε και τα δύο είδη εξόδου. Δεν γίνεται αναζήτηση μέσα σε ομάδες.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Διατηρήστε τον τύπο τμήματος, εξαιρώντας τις σημαίες.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Καταναλώστε και τα δύο σημεία ελέγχου και το σημείο λήξης.
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

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει τον ρόλο του. Ο τύπος `0` ξεκινά ένα σχήμα, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα κυβικού Bézier ξεκινά από το προηγούμενο σημείο λήξης και χρησιμοποιεί τρία διαδοχικά στοιχεία τύπου `3`: δύο σημεία ελέγχου και, στη συνέχεια, το νέο σημείο λήξης. Ο βρόχος καταναλώνει αυτά τα τρία στοιχεία μαζί και ελέγχει το σημείο λήξης για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Κάντε μάσκα με `0x07` για να προσδιορίσετε τον τύπο τμήματος και δοκιμάστε `0x80` ξεχωριστά για να εντοπίσετε κλειστό υπο‑σχέδιο. Για παράδειγμα, το `129` (`0x81`) σημαίνει ένα σημείο λήξης γραμμής που κλείνει ένα υπο‑σχέδιο, και το `131` (`0x83`) σημαίνει σημείο λήξης Bézier που κλείνει ένα. Η Java αποθηκεύει αυτές τις σημαίες σε υπογεγραμμένα bytes· η μάσκα διατηρεί τις προτιμώμενες τιμές bit. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρώνται σε σημεία (1/72 ίντσα), με το X να αυξάνεται προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες ήδη περιλαμβάνουν τη θέση που επιστρέφεται από [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) και [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) και αντανακλούν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη περιστρεφόμενο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέτετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και Y του για να πάρετε συντεταγμένες σχετικές με το μη περιστρεφόμενο πλαίσιο.

Τα εξαγόμενα σημεία δεν εφαρμόζουν την περιστροφή του σχήματος, που επιστρέφεται από [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), ούτε τις οριζόντιες και κάθετες αναστροφές. Για να αναπαραγάγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτούς τους μετασχηματισμούς γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε υπόψη επίσης τη χαρτογράφηση συντεταγμένων της ομάδας και τους μετασχηματισμούς· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες στην προβολή της διαφάνειας ή εφαρμόστε μετάφραση ή κλίμακα δύο φορές εάν ήδη αντικατοπτρίζονται στο πλαίσιο του παιδιού.

**Έλεγχος έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η τροποποίησή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτήν την προσέγγιση όταν η ανάλυση ή ο κώδικας σχεδίασης χρειάζονται πίνακες σημείου/τύπου. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) όταν χρειάζεσθε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τις επεξεργασμένες διαδρομές μέσω [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ή [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Μετατροπή Java AWT Shape σε GeometryPath**

Αυτό το παράδειγμα συνδυάζει ένα ορθογώνιο περίγραμμα με κείμενο που μετατράπηκε σε γεωμετρία. Η μέθοδος [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) του περιγράμματος απενεργοποιεί το γέμισμα. Ένα [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) δημιουργεί το περίγραμμα κειμένου σε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Ο [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του παρέχει μετακινήσεις, γραμμές, τετραγωνικές, κυβικές και κλειστικές εντολές, τις οποίες το παράδειγμα επαναλαμβάνει σε μια [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

Το κείμενο χρησιμοποιεί γραμματοσειρά Arial 40 σημεία. Το περίγραμμα είναι μετατοπισμένο 20 σημεία οριζόντια και τοποθετείται ώστε το οπτικό του πάνω μέρος είναι 10 σημεία κάτω από την άνω άκρη του σχήματος. Η διαδρομή κειμένου γεμίζεται, ενώ το αρχικό ορθογώνιο παραμένει ως περίγραμμα. Η εφαρμογή και των δύο διαδρομών με [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) παράγει ένα ενιαίο σχήμα που περιέχει το ορθογώνιο και το κείμενο.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Δημιουργία νέου σχήματος
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Λήψη διαδρομής γεωμετρίας του σχήματος
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Δημιουργία νέας διαδρομής γραφικών με κείμενο
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Μετατροπή διαδρομής γραφικών σε διαδρομή γεωμετρίας
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Ορισμός συνδυασμού νέας διαδρομής γεωμετρίας και αρχικής διαδρομής γεωμετρίας στο σχήμα
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **Συχνές Ερωτήσεις**

**Τι θα συμβεί στο γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς μπορώ να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να «κλειδώσω» το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή του [slide](/slides/el/java/convert-powerpoint-to-png/) ή το ίδιο το [shape](/slides/el/java/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με σύνθετες γεωμετρίες.