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
- μονοπάτι γεωμετρίας
- σημεία μονοπατιού
- σημεία επεξεργασίας
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- καμπυλωτή γωνία
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργία και προσαρμογή σχημάτων σε παρουσιάσεις PowerPoint με Aspose.Slides για Java: μονοπάτια γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία των σχημάτων μέσω σημείων επεξεργασίας και μονοπατιών γεωμετρίας. Δείχνει πώς να εργάζεστε με [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) και [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας μονοπατιού, να προσθέσετε ή να αφαιρέσετε σημεία, και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Επίσης παρουσιάζει πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να οικοδομήσετε σχήματα με καμπύλες γωνίες, να προσδιορίσετε αν μια γεωμετρία σχήματος είναι κλειστή, να ελέγξετε τα στοιχεία του σχήματος και να μετατρέψετε τα περιγράμματα κειμένου Java AWT σε μονοπάτια γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Edit Points** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Κατά την επεξεργασία σχημάτων PowerPoint, θυμηθείτε τις παρακάτω έννοιες:

* Ένα σχήμα (ή το μονοπάτι του) μπορεί να είναι είτε κλειστό είτε ανοιχτό.
* Το μονοπάτι ενός σχήματος αποτελείται από σημεία αγύρωσης συνδεδεμένα με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή κυρτό. Τα σημεία αγύρωσης και οι χειρολαβές ελέγχου καθορίζουν το σχήμα του.
* Τα σημεία αγύρωσης υπάρχουν ως γωνιακά σημεία, ευθείες σημεία ή λείες σημεία:
  * Σε ένα γωνιακό σημείο, τα διπλανά τμήματα μπορούν να συναντηθούν με γωνία.
  * Σε ένα λείο σημείο, οι δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένες και ισαπέχουν από το σημείο αγύρωσης.
  * Σε ένα ευθύ σημείο, οι δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένες αλλά μπορεί να έχουν διαφορετικές αποστάσεις από το σημείο αγύρωσης.
* Η μετακίνηση των σημείων αγύρωσης ή η ρύθμιση των χειρολαβών τους αλλάζει το περίγραμμα του σχήματος.

Για να επεξεργαστείτε σχήματα PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) και τη διεπαφή [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Μια [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) παρουσία αντιπροσωπεύει ένα μονοπάτι γεωμετρίας του αντικειμένου [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) από την παρουσία [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) για σχήματα με ένα μόνο μονοπάτι και [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) για σχήματα με πολλαπλά μονοπάτια.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους υπό τη [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).
* Χρησιμοποιώντας τις μεθόδους [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) και [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-), μπορείτε να ορίσετε την εμφάνιση για ένα μονοπάτι γεωμετρίας.
* Χρησιμοποιώντας τη μέθοδο [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--), μπορείτε να ανακτήσετε το μονοπάτι γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων μονοπατιού.
* Για να έχετε πρόσβαση σε πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να διαβάσετε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) μέσω του [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) και να επαναλάβετε τα τμήματα σε ένα [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε ένα μονοπάτι γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη θέση μηδενικής βάσης στον πίνακα τμημάτων του μονοπατιού.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή μιας ευθείας γραμμής. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Προσθήκη ή εισαγωγή μιας κυβικής καμπύλης Bézier με δύο σημεία ελέγχου και ένα τελικό σημείο. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Προσθήκη ή εισαγωγή μιας τετραγωνικής καμπύλης Bézier με ένα σημείο ελέγχου και ένα τελικό σημείο. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Προσθήκη μιας ελλειπτικής τοξοειδούς με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το τελικό του σημείο με το αρχικό του σημείο. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Ορισμός του αρχικού σημείου ενός σχήματος. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Αφαίρεση ενός τμήματος σε δείκτη μηδενικής βάσης. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) και εφαρμόζει το επεξεργασμένο μονοπάτι με [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 points από αριστερά και 50 points από πάνω. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στα πάνω και κάτω άκρα, τραβώντας αυτά τα άκρα προς το εσωτερικό.

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

Αυτό το παράδειγμα αλλάζει το περίγραμμα σχήματος καρδιάς αφαιρώντας το τμήμα στη θέση μηδενικής βάσης 2 με [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Η εφαρμογή του τροποποιημένου μονοπατιού με [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ενημερώνει το περίγραμμα του σχήματος.

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

Αυτό το παράδειγμα δημιουργεί έναν πεντάγωνο αστέρι με [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 points ορίζουν τις άκρες και τις εσοχές· ένα βήμα 72 μ graus χωρίζει ομοιόμορφα τις πέντε άκρες. Το μονοπάτι κλείνει με [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) και εφαρμόζεται σε ένα ορθογώνιο σχήμα με [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), αντικαθιστώντας το περίγραμμα του.

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

## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα ορίζει δύο κλειστά [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) αντικείμενα για το άνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο μονοπατιών με [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) δημιουργεί ένα ενιαίο σύνθετο σχήμα με ένα κενό στην κεντρική τρίτη του περιοχή.

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

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπύλες Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθύ τμήματα με [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) για να δημιουργήσει ένα σχήμα με εσωτερικές καμπυλωτές γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος της τοξοειδούς σε points, και η σάρωση -90 μ graus σχεδιάζει ένα αντίστροφα ρολόι τέταρτο έλλειψης. Το ολοκληρωμένο μονοπάτι εφαρμόζεται με [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

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

## **Καθορίστε Εάν η Γεωμετρία Σχήματος Είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει αν κάθε μη κενό μονοπάτι γεωμετρίας λήγει με τμήμα κλεισίματος. Διαβάζει το [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) και συγκρίνει την τελική εντολή του τμήματος [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) με το [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενά μονοπάτια. Ο έλεγχος αφορά την τελική εντολή κάθε μονοπατιού· δεν επιθεωρεί κάθε υποσχήμα εντός του. Το παράδειγμα εκτυπώνει `true` για ένα ορθογώνιο.

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

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σχήματος**

Χρησιμοποιήστε το [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) για να επιθεωρήσετε ένα υφιστάμενο σχήμα ως στοιχεία που περιέχουν σημεία μονοπατιού και τύπους σημείων. Μετατρέψτε κάθε επιστρεφόμενο [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) σε [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) ώστε να λάβετε τους πίνακες σημείων και τύπων μέσω των μεθόδων [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) και [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγραμμάτων ή για μεταφορά γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει το input.pptx, βρίσκει το πρώτο γεωμετρικό σχήμα στην πρώτη διαφάνεια και εκτυπώνει τα τμήματα του μονοπατιού του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθύ και κυρτά τμήματα για να δείτε και τις δύο μορφές εξόδου. Δεν ψάχνει μέσα σε ομάδες.

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
                int pointType = types[i] & 0x07; // Διατήρηση του τύπου τμήματος, εξαιρώντας τις σημαίες.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Καταναλώνει και τα δύο σημεία ελέγχου και το τελικό σημείο.
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

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει τον ρόλο του. Ο τύπος `0` ξεκινά ένα σχήμα, και ο τύπος `1` σχεδιάζει γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα κυβικής Bézier αρχίζει στο προηγούμενο τελικό σημείο και χρησιμοποιεί τρεις διαδοχικές καταχωρήσεις τύπου `3`: δύο σημεία ελέγχου ακολουθούμενα από το νέο τελικό σημείο. Ο βρόχος καταναλώνει αυτές τις τρεις καταχωρήσεις μαζί και ελέγχει το τελικό σημείο για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Χρησιμοποιήστε τη μάσκα `0x07` για να ταυτοποιήσετε τον τύπο του τμήματος και ελέγξτε ξεχωριστά το `0x80` για να ανιχνεύσετε ένα κλειστό υπομονοπάτι. Για παράδειγμα, το `129` (`0x81`) σημαίνει ένα τελικό σημείο γραμμής που κλείνει ένα υπομονοπάτι, και το `131` (`0x83`) σημαίνει ένα τελικό σημείο Bézier που κλείνει ένα. Η Java αποθηκεύει αυτές τις σημαίες σε υπογραφόμενα bytes· η μάσκα διατηρεί τις προοριζόμενες τιμές bit. Η σύγκριση της ωμής τιμής μόνο με `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο του τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρώνται σε points (1/72 ίντσα), με το X να αυξάνεται προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση που επιστρέφεται από τις μεθόδους [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) και [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) και αντικατοπτρίζουν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη περιστραμμένο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέσετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και Y του για να λάβετε συντεταγμένες σχετικά με το μη περιστραμμένο πλαίσιο.

Οι εξαγόμενες σημεία δεν εφαρμόζουν την περιστροφή του σχήματος, που επιστρέφεται από τη [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), ούτε τις οριζόντιες και κάθετες αναστροφές. Για να αποδομήσετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτούς τους μετασχηματισμούς γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων ομάδας και τους μετασχηματισμούς· μην θεωρείτε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόζετε διπλή μετάθεση ή κλιμάκωση αν αυτά ήδη αντικατοπτρίζονται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτήν την προσέγγιση όταν η ανάλυση ή ο κώδικας σχεδίασής σας χρειάζονται πίνακες σημείων/τύπων. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τα επεξεργασμένα μονοπάτια μέσω του [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ή του [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Μετατροπή Σχήματος Java AWT σε GeometryPath**

Αυτό το παράδειγμα συνδυάζει το περίγραμμα ενός ορθογωνίου με κείμενο μετατρεπόμενο σε γεωμετρία. Η μέθοδος [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) του περιγράμματος απενεργοποιεί τη γεμίσή του. Ένα [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) δημιουργεί το περίγραμμα κειμένου σε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Το [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του παρέχει εντολές κίνησης, γραμμής, τετραγωνικής, κυβικής και κλεισίματος· το παράδειγμα τις επαναλαμβάνει σε ένα [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

Το κείμενο χρησιμοποιεί γραμματοσειρά Arial 40 points. Το περίγραμμα μετατοπίζεται 20 points οριζόντια και τοποθετείται έτσι ώστε το οπτικό του πάνω να βρίσκεται 10 points κάτω από την πάνω άκρη του σχήματος. Το μονοπάτι κειμένου γεμίζει, ενώ το αρχικό ορθογώνιο παραμένει ως περίγραμμα. Η εφαρμογή και των δύο μονοπατιών με [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) παράγει ένα ενιαίο σχήμα που περιέχει το ορθογώνιο και το κείμενο.

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

    // Λήψη μονοπατιού γεωμετρίας του σχήματος
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Δημιουργία νέου γραφικού μονοπατιού με κείμενο
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

    // Μετατροπή του γραφικού μονοπατιού σε μονοπάτι γεωμετρίας
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

    // Ορισμός του συνδυασμού νέου μονοπατιού γεωμετρίας και αρχικού μονοπατιού γεωμετρίας στο σχήμα
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **ΣΥΧΝΑ ΕΡΩΤΗΣΕΙΣ**

**Τι θα συμβεί στη γέμιση και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γέμιση και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) του σχήματος· η γεωμετρία περιστρέφεται με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να "κλειδώσω" το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή [slide](/slides/el/java/convert-powerpoint-to-png/) ή το ίδιο το [shape](/slides/el/java/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με πολύπλοκες γεωμετρίες.