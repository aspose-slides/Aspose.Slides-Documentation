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
- καμπύλη γωνία
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Android μέσω Java: διαδρομές γεωμετρίας, καμπύλες γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία των σχημάτων μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με `GeometryPath` και `IGeometryPath` για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Επίσης, επιδεικνύει πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να χτίσετε σχήματα με καμπύλες γωνίες, να προσδιορίσετε αν η γεωμετρία ενός σχήματος είναι κλειστή και να μετατρέψετε μεταξύ `GeometryPath` και `java.awt.Shape` για επιπλέον σενάρια προσαρμογής γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**
Ας θεωρήσουμε ένα τετράγωνο. Στο PowerPoint, χρησιμοποιώντας **σημεία επεξεργασίας**, μπορείτε

* να μετακινήσετε την γωνία του τετραγώνου προς το εσωτερικό ή το εξωτερικό  
* να ορίσετε την καμπυλότητα μιας γωνίας ή ενός σημείου  
* να προσθέσετε νέα σημεία στο τετράγωνο  
* να χειριστείτε σημεία στο τετράγωνο κ.λπ.

Κατά ουσία, μπορείτε να εκτελέσετε τις παραπάνω εργασίες σε οποιοδήποτε σχήμα. Χρησιμοποιώντας σημεία επεξεργασίας, μπορείτε να αλλάξετε ένα σχήμα ή να δημιουργήσετε νέο σχήμα από ένα υπάρχον σχήμα.

## **Συμβουλές Επεξεργασίας Σχημάτων**

![overview_image](custom_shape_0.png)

Πριν αρχίσετε την επεξεργασία σχημάτων PowerPoint μέσω σημείων επεξεργασίας, ίσως θελήσετε να λάβετε υπόψη τα εξής σχετικά με τα σχήματα:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι είτε κλειστό είτε ανοιχτό.  
* Όταν ένα σχήμα είναι κλειστό, δεν έχει σημείο έναρξης ή λήξης. Όταν είναι ανοιχτό, έχει αρχή και τέλος.  
* Όλα τα σχήματα αποτελούνται από τουλάχιστον 2 άγκυρα σημεία που συνδέονται μεταξύ τους με γραμμές.  
* Μια γραμμή μπορεί να είναι ευθεία ή καμπυλώδης. Τα άγκυρα σημεία καθορίζουν τη φύση της γραμμής.  
* Τα άγκυρα σημεία υπάρχουν ως γωνιακά σημεία, ευθείες σημεία ή λείες (smooth) σημεία:  
  * Ένα γωνιακό σημείο είναι σημείο όπου 2 ευθείες γραμμές συναντώνται υπό γωνία.  
  * Ένα λείο σημείο είναι σημείο όπου 2 χειρολαβές βρίσκονται στην ίδια ευθεία γραμμή και τα τμήματα της γραμμής ενώνονται σε ομαλή καμπύλη. Σε αυτή την περίπτωση, όλες οι χειρολαβές είναι ισαπέχουν από το άγκυρα σημείο.  
  * Ένα ευθύ σημείο είναι σημείο όπου 2 χειρολαβές βρίσκονται στην ίδια ευθεία γραμμή και τα τμήματα της γραμμής ενώνονται σε λείο τόξο. Σε αυτή την περίπτωση, οι χειρολαβές δεν χρειάζεται να είναι ισαπέχουν από το άγκυρα σημείο.  
* Με τη μετακίνηση ή την επεξεργασία των άγκυρων σημείων (που αλλάζουν τη γωνία των γραμμών), μπορείτε να τροποποιήσετε την εμφάνιση ενός σχήματος.

Για να επεξεργαστείτε σχήματα PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [**GeometryPath**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath) και τη διεπαφή [**IGeometryPath**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryPath).

* Μια παρουσίαση του [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [IGeometryShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryShape).  
* Για να ανακτήσετε το `GeometryPath` από την παρουσίαση `IGeometryShape`, μπορείτε να χρησιμοποιήσετε τη μέθοδο [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--).  
* Για να ορίσετε το `GeometryPath` για ένα σχήμα, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) για *συμπαγή σχήματα* και [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) για *σύνθετα σχήματα*.  
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους υπό [IGeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryPath).  
* Χρησιμοποιώντας τις μεθόδους [IGeometryPath.setStroke](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) και [IGeometryPath.setFillMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.  
* Με τη μέθοδο [IGeometryPath.getPathData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IGeometryPath#getPathData--) μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός `GeometryShape` ως έναν πίνακα τμημάτων διαδρομής.  
* Για πρόσβαση σε επιπλέον επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath) σε [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
* Χρησιμοποιήστε τις μεθόδους [geometryPathToGraphicsPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) και [graphicsPathToGeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (από την κλάση [ShapeUtil](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ShapeUtil)) για μετατροπή του [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath) σε [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) και αντίστροφα.

## **Απλές Λειτουργίες Επεξεργασίας**

Αυτός ο κώδικας Java δείχνει πώς να

**Προσθέσετε μια γραμμή** στο τέλος μιας διαδρομής

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Προσθέσετε μια γραμμή** σε καθορισμένη θέση μιας διαδρομής:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Προσθέσετε μια κυβική καμπύλη Bezier** στο τέλος μιας διαδρομής:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Προσθέσετε μια κυβική καμπύλη Bezier** σε καθορισμένη θέση μιας διαδρομής:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Προσθέσετε μια τετραγωνική καμπύλη Bezier** στο τέλος μιας διαδρομής:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Προσθέσετε τετραγωνική καμπύλη Bezier** σε καθορισμένη θέση μιας διαδρομής:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Προσθέσετε ένα δεδομένο τόξο** σε μια διαδρομή:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Κλείσετε το τρέχον σχήμα** μιας διαδρομής:

``` java
public void closeFigure();
```
**Ορίσετε τη θέση για το επόμενο σημείο**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Αφαιρέσετε το τμήμα διαδρομής** σε συγκεκριμένο δείκτη:

``` java
public void removeAt(int index);
```

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**
1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryShape) και ορίστε τον τύπο [ShapeType.Rectangle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ShapeType).  
2. Αποκτήστε μια παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath) από το σχήμα.  
3. Προσθέστε ένα νέο σημείο μεταξύ των δύο άνω σημείων της διαδρομής.  
4. Προσθέστε ένα νέο σημείο μεταξύ των δύο κάτω σημείων της διαδρομής.  
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε προσαρμοσμένα σημεία σε ένα σχήμα:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryShape) και ορίστε τον τύπο [ShapeType.Heart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ShapeType).  
2. Αποκτήστε μια παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath) από το σχήμα.  
3. Αφαιρέστε το τμήμα της διαδρομής.  
4. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε σημεία από ένα σχήμα:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

##  **Δημιουργία Προσαρμοσμένου Σχήματος**

1. Υπολογίστε τα σημεία για το σχήμα.  
2. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath).  
3. Συμπληρώστε τη διαδρομή με τα σημεία.  
4. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryShape).  
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα:

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example3_image](custom_shape_3.png)


## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

  1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryShape).  
  2. Δημιουργήστε μια πρώτη παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath).  
  3. Δημιουργήστε μια δεύτερη παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath).  
  4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα σύνθετο προσαρμοσμένο σχήμα:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπύλες Γωνίες**

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα με καμπύλες γωνίες (εσωτερικές):

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.closeFigure();

    childShape.setGeometryPath(geometryPath);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **Εύρεση Εάν η Γεωμετρία Σχήματος είναι Κλειστή**

Ένα κλειστό σχήμα ορίζεται ως αυτό που όλες οι πλευρές του συνδέονται, σχηματίζοντας ένα ενιαίο όριο χωρίς κενά. Ένα τέτοιο σχήμα μπορεί να είναι μια απλή γεωμετρική μορφή ή ένα πολύπλοκο προσαρμοσμένο περίγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ελέγξετε αν η γεωμετρία ενός σχήματος είναι κλειστή:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **Μετατροπή GeometryPath σε java.awt.Shape** 

1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryShape).  
2. Δημιουργήστε μια παρουσίαση της κλάσης [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
3. Μετατρέψτε την παρουσίαση [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) σε παρουσίαση [GeometryPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GeometryPath) χρησιμοποιώντας το [ShapeUtil](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ShapeUtil).  
4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτός ο κώδικας Java—μια υλοποίηση των παραπάνω βημάτων—δείχνει τη διαδικασία μετατροπής **GeometryPath** σε **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Δημιουργία νέου σχήματος
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Λήψη διαδρομής γεωμετρίας του σχήματος
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Δημιουργία νέας διαδρομής γραφικών με κείμενο
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Μετατροπή διαδρομής γραφικών σε διαδρομή γεωμετρίας
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Ορισμός συνδυασμού νέας διαδρομής γεωμετρίας και αρχικής διαδρομής γεωμετρίας στο σχήμα
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **Συχνές Ερωτήσεις**

**Τι θα συμβεί με τη γέμιση και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γέμιση και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#setRotation-float-) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο σύστημα συντεταγμένων του σχήματος.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να "κλειδώσω" το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη [slide](/slides/el/androidjava/convert-powerpoint-to-png/) περιοχή ή το [shape](/slides/el/androidjava/create-shape-thumbnails/) ίδιο σε μορφή raster· αυτό απλοποιεί περαιτέρω εργασία με περίπλοκες γεωμετρίες.