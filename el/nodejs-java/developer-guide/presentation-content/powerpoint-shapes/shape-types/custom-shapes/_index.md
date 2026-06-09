---
title: Προσαρμογή Σχημάτων Παρουσίασης σε JavaScript
linktitle: Προσαρμοσμένο Σχήμα
type: docs
weight: 20
url: /el/nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με JavaScript και Aspose.Slides για Node.js: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργαζόμενοι τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με `GeometryPath` για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Επίσης, δείχνει πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να κατασκευάσετε σχήματα με καμπύλες γωνίες, να καθορίσετε εάν η γεωμετρία ενός σχήματος είναι κλειστή και να μετατρέψετε μεταξύ `GeometryPath` και `java.awt.Shape` για επιπλέον σενάρια προσαρμογής γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Σκεφτείτε ένα τετράγωνο. Στο PowerPoint, χρησιμοποιώντας **edit points**, μπορείτε 

* να μετακινήσετε τη γωνία του τετραγώνου προς μέσα ή έξω
* να ορίσετε την κυρτότητα μιας γωνίας ή σημείου
* να προσθέσετε νέα σημεία στο τετράγωνο
* να χειριστείτε σημεία στο τετράγωνο, κ.λπ. 

Βασικά, μπορείτε να εκτελέσετε τις περιγραφόμενες εργασίες σε οποιοδήποτε σχήμα. Χρησιμοποιώντας σημεία επεξεργασίας, μπορείτε να αλλάξετε ένα σχήμα ή να δημιουργήσετε ένα νέο σχήμα από ένα υπάρχον σχήμα. 

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Πριν ξεκινήσετε την επεξεργασία σχήματος PowerPoint μέσω σημείων επεξεργασίας, ίσως θελήσετε να λάβετε υπόψη τα παρακάτω σημεία σχετικά με τα σχήματα:

* Ένα σχήμα (ή η διαδρομή του) μπορεί είτε να είναι κλειστό είτε ανοιχτό.
* Όταν ένα σχήμα είναι κλειστό, δεν διαθέτει σημείο έναρξης ή λήξης. Όταν ένα σχήμα είναι ανοιχτό, έχει αρχή και τέλος. 
* Όλα τα σχήματα αποτελούνται από τουλάχιστον 2 σημειακός άγκυρας που συνδέονται μεταξύ τους με γραμμές
* Μια γραμμή είναι είτε ευθεία είτε καμπυλωτή. Τα σημεία άγκυρας καθορίζουν τη φύση της γραμμής. 
* Σημεία άγκυρας υπάρχουν ως σημεία γωνίας, ευθείες σημεία ή λεια σημεία:
  * Σημείο γωνίας είναι ένα σημείο όπου δύο ευθείες γραμμές ενώνονται με γωνία. 
  * Λείο σημείο είναι ένα σημείο όπου δύο λαβές βρίσκονται σε ευθεία γραμμή και τα τμήματα της γραμμής ενώνουν σε λείο καμπύλο τμήμα. Σε αυτήν την περίπτωση, όλες οι λαβές είναι διαχωρισμένες από το σημείο άγκυρας ίση απόσταση. 
  * Ευθύ σημείο είναι ένα σημείο όπου δύο λαβές βρίσκονται σε ευθεία γραμμή και τα τμήματα της γραμμής ενώνουν σε λείο καμπύλο τμήμα. Σε αυτήν την περίπτωση, οι λαβές δεν πρέπει να είναι απαραίτητα διαχωρισμένες από το σημείο άγκυρας ίση απόσταση. 
* Με τη μετακίνηση ή επεξεργασία σημείων άγκυρας (που αλλάζει τη γωνία των γραμμών), μπορείτε να αλλάξετε την εμφάνιση ενός σχήματος. 

Για την επεξεργασία σχήματος PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [**GeometryPath**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath) και την κλάση [**GeometryPath**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath).

* Ένα αντικείμενο [GeometryPath] αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape).
* Για την ανάκτηση του`GeometryPath` από το αντικείμενο `GeometryShape`, μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).
* Για να ορίσετε το `GeometryPath` για ένα σχήμα, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) για *συμπαγή σχήματα* και [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) για *σύνθετα σχήματα*.
* Για την προσθήκη τμημάτων, μπορείτε να χρησιμοποιήσετε τις μεθόδους της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath).
* Χρησιμοποιώντας τις μεθόδους [GeometryPath.setStroke](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) και [GeometryPath.setFillMode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Χρησιμοποιώντας τη μέθοδο [GeometryPath.getPathData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath#getPathData--) μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός `GeometryShape` ως έναν πίνακα τμημάτων διαδρομής.
* Για πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath) σε [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Χρησιμοποιήστε [geometryPathToGraphicsPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) και [graphicsPathToGeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (από την κλάση [ShapeUtil](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeUtil)) για να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath) σε [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) και αντίστροφα.

## **Απλές Λειτουργίες Επεξεργασίας**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να

**Προσθήκη γραμμής** στο τέλος μιας διαδρομής
```javascript
lineTo(point);
lineTo(x, y);
```
**Προσθήκη γραμμής** σε καθορισμένη θέση στη διαδρομή:
```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Προσθήκη κυβικής καμπύλης Bezier** στο τέλος μιας διαδρομής:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Προσθήκη κυβικής καμπύλης Bezier** στην καθορισμένη θέση στη διαδρομή:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Προσθήκη τετραγωνικής καμπύλης Bezier** στο τέλος μιας διαδρομής:
```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Προσθήκη τετραγωνικής καμπύλης Bezier** σε καθορισμένη θέση στη διαδρομή:
```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Προσθήκη δεδομένου τόξου** στη διαδρομή:
```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Κλείσιμο του τρέχοντος σχήματος** της διαδρομής:
```javascript
closeFigure();
```
**Ορισμός της θέσης για το επόμενο σημείο**:
```javascript
moveTo(point);
moveTo(x, y);
```
**Αφαίρεση τμήματος διαδρομής** σε συγκεκριμένο δείκτη:
```javascript
removeAt(index);
```

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape) και ορίστε τον τύπο [ShapeType.Rectangle](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeType).
2. Αποκτήστε ένα αντίτυπο της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath) από το σχήμα.
3. Προσθέστε ένα νέο σημείο μεταξύ των δύο επάνω σημείων στη διαδρομή.
4. Προσθέστε ένα νέο σημείο μεταξύ των δύο κάτω σημείων στη διαδρομή.
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσθέσετε προσαρμοσμένα σημεία σε ένα σχήμα:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

1. Δημιουργήστε ένα αντίτυπο της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape) και ορίστε τον τύπο [ShapeType.Heart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeType).
2. Αποκτήστε ένα αντίτυπο της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath) από το σχήμα.
3. Αφαιρέστε το τμήμα της διαδρομής.
4. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να αφαιρέσετε σημεία από ένα σχήμα:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example2_image](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος**

1. Υπολογίστε τα σημεία για το σχήμα.
2. Δημιουργήστε ένα αντίτυπο της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath).
3. Γεμίστε τη διαδρομή με τα σημεία.
4. Δημιουργήστε ένα αντίτυπο της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape).
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα:
```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example3_image](custom_shape_3.png)


## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

  1. Δημιουργήστε ένα αντίτυπο της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape).
  2. Δημιουργήστε την πρώτη αντίτυπο της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath).
  3. Δημιουργήστε τη δεύτερη αντίτυπο της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath).
  4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να δημιουργήσετε ένα σύνθετο προσαρμοσμένο σχήμα:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example4_image](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπυλωτές Γωνίες**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα με καμπυλωτές γωνίες (προς το εσωτερικό);
```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
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
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Καθορίστε Εάν η Γεωμετρία ενός Σχήματος είναι Κλειστή**

Ένα κλειστό σχήμα ορίζεται ως εκείνο του οποίου όλες οι πλευρές συνδέονται, σχηματίζοντας ένα ενιαίο σύνορο χωρίς κενά. Ένα τέτοιο σχήμα μπορεί να είναι μια απλή γεωμετρική μορφή ή ένα πολύπλοκο προσαρμοσμένο περίγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ελέγξετε εάν μια γεωμετρία σχήματος είναι κλειστή:
```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **Μετατροπή GeometryPath σε java.awt.Shape** 

1. Δημιουργήστε ένα αντίτυπο της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryShape).
2. Δημιουργήστε ένα αντίτυπο της κλάσης [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Μετατρέψτε το αντίτυπο [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) σε αντίτυπο [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GeometryPath) χρησιμοποιώντας το [ShapeUtil](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeUtil).
4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτός ο κώδικας JavaScript—μια υλοποίηση των παραπάνω βημάτων—δείχνει τη διαδικασία μετατροπής **GeometryPath** σε **GraphicsPath**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Δημιουργία νέου σχήματος
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Λήψη γεωμετρικής διαδρομής του σχήματος
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Δημιουργία νέας διαδρομής γραφικών με κείμενο
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Μετατροπή διαδρομής γραφικών σε γεωμετρική διαδρομή
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Ορισμός συνδυασμού νέας γεωμετρικής διαδρομής και αρχικής γεωμετρικής διαδρομής στο σχήμα
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **Συχνές Ερωτήσεις**

**Τι θα συμβεί με τη γέμιση και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γέμιση και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σ shape μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/setrotation/) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σ shape σε εικόνα για να "κλειδώσω" το αποτέλεσμα;**

Ναί. Εξάγετε την απαιτούμενη περιοχή [slide](/slides/el/nodejs-java/convert-powerpoint-to-png/) ή το ίδιο το [shape](/slides/el/nodejs-java/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με πολύπλοκες γεωμετρίες.