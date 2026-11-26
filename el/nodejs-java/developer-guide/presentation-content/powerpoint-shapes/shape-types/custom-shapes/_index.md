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

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Δείχνει επίσης πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να δημιουργήσετε σχήματα με καμπυλωτές γωνίες, να καθορίσετε εάν μια γεωμετρία σχήματος είναι κλειστή, να επιθεωρήσετε τα στοιχεία του σχήματος και να μετατρέψετε τα περιγράμματα κειμένου Java AWT σε διαδρομές γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Edit Points** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Κατά την επεξεργασία σχημάτων PowerPoint, κρατήστε κατά νου τις παρακάτω έννοιες:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι είτε κλειστό είτε ανοιχτό.
* Η διαδρομή ενός σχήματος αποτελείται από άγκυρες σημεία (anchor points) συνδεδεμένα με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή καμπύλο. Τα άγκυρα σημεία και τα χειρολαβές ελέγχου (control handles) καθορίζουν το σχήμα του.
* Τα άγκυρα σημεία υπάρχουν ως γωνιακά σημεία, ευθύγραμμα σημεία ή λείες (smooth) σημεία:
  * Σε ένα γωνιακό σημείο, τα διπλά τμήματα μπορούν να συναντηθούν υπό γωνία.
  * Σε ένα λείο σημείο, τα δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένα και ισαπέχουν από το άγκυρα σημείο.
  * Σε ένα ευθύ σημείο, τα δύο χειρολαβές ελέγχου είναι ευθυγραμμισμένα αλλά μπορεί να έχουν διαφορετικές αποστάσεις από το άγκυρα σημείο.
* Η μετακίνηση των άγκυρων σημείων ή η ρύθμιση των χειρολαβών τους αλλάζει το περίγραμμα του σχήματος.

Για να επεξεργαστείτε σχήματα PowerPoint μέσω σημείων επεξεργασίας, **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Μία παρουσία [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) από την παρουσία [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) για σχήματα με μία διαδρομή και [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) για σχήματα με πολλαπλές διαδρομές.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους στο [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Χρησιμοποιώντας τις μεθόδους [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) και [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Χρησιμοποιώντας τη μέθοδο [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων διαδρομής.
* Για να αποκτήσετε πρόσβαση σε πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να διαβάσετε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) μέσω του [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του και να επαναλάβετε τα τμήματα σε ένα [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε μια διαδρομή γεωμετρίας. Υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη θέση μηδενικής βάσης στον πίνακα τμημάτων της διαδρομής.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθέτει ή εισάγει ευθεία γραμμή. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Προσθέτει ή εισάγει καμπύλη Bézier τρίτου βαθμού με δύο σημεία ελέγχου και ένα τελικό σημείο. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Προσθέτει ή εισάγει τετραγωνική Bézier καμπύλη με ένα σημείο ελέγχου και ένα τελικό σημείο. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Προσθέτει ένα ελλειπτικό τόξο με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Κλείνει το τρέχον σχήμα συνδέοντας το τελικό του σημείο με το αρχικό. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Ορίζει το αρχικό σημείο ενός σχήματος. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Αφαιρεί ένα τμήμα με δείκτη μηδενικής βάσης. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας το [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) και εφαρμόζει τη διόρθωση διαδρομής με το [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 points από τα αριστερά και 50 points από την κορυφή. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στις άνω και κάτω άκρες, τραβώντας αυτές τις άκρες προς τα μέσα.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

Αυτό το παράδειγμα τροποποιεί το περίγραμμα σχήματος καρδιάς αφαιρώντας το τμήμα στη θέση μηδενικής βάσης 2 με το [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Η εφαρμογή της τροποποιημένης διαδρομής με το [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ενημερώνει το περίγραμμα του σχήματος.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```

![example2_image](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα δημιουργεί έναν πεντάκτινο αστέρι με το [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 points ορίζουν τις άκρα και τις εσοχές· ένα βήμα 72 μοιρών χωρίζει τα πέντε άκρα ομοιόμορφα. Η διαδρομή κλείνει με το [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) και εφαρμόζεται σε ένα ορθογώνιο σχήμα χρησιμοποιώντας το [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), αντικαθιστώντας το περίγραμμα του.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```

![example3_image](custom_shape_3.png)

## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα ορίζει δύο κλειστές αντικείμενα [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) για τα πάνω και κάτω τρίτα ενός σχήματος. Η εφαρμογή και των δύο διαδρομών με το [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) δημιουργεί ένα ενιαίο σύνθετο σχήμα με ένα κενό διαμέσου του μεσαίου τρίτου.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```

![example4_image](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπυλωτές Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθύγραμμα τμήματα με το [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) για να δημιουργήσει ένα σχήμα με εσωτερικά καμπυλωτές γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος του τόξου σε points, και η σάρωση -90 μοιρών σχεδιάζει ένα αντίστροφα κυκλικό τέταρτο έλλειψα. Η ολοκληρωμένη διαδρομή εφαρμόζεται με το [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εύρεση Αν η Γεωμετρία Σχήματος Είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει αν κάθε μη κενή διαδρομή γεωμετρίας λήγεται με τμήμα κλεισίματος. Διαβάζει το [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) και συγκρίνει την τελική εντολή του τμήματος [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) με το [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενές διαδρομές. Αυτό ελέγχει την τελική εντολή κάθε διαδρομής· δεν εξετάζει κάθε υποσχήμα μέσα σε μια διαδρομή. Το παράδειγμα εμφανίζει `true` για ένα ορθογώνιο.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Επιθεώρηση Εντολών Διαδρομής Γεωμετρίας**

Κατεβάστε το [contour.pptx](contour.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Το πρώτο σχήμα στην πρώτη διαφάνεια έχει μια ευθεία άνω πλευρά, μια καμπύλη Bézier τρίτου βαθμού και μια ευθεία πλευρά κλεισίματος. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) για να διαβάσετε τις διαδρομές του σχήματος και το [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) για να διαβάσετε τα τμήματα κάθε διαδρομής με τη σειρά σχεδίασης. Για κάθε τμήμα, το [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) προσδιορίζει την εντολή και καθορίζει πώς να ερμηνεύσετε τις τιμές που επιστρέφει το [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData).

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

Το σχήμα βρίσκεται στο (200, 100) points στη διαφάνεια. Οι αναφερόμενες συντεταγμένες είναι τοπικές στο σχήμα, με το (0, 0) στην πάνω αριστερή γωνία, το x να αυξάνεται προς τα δεξιά και το y προς τα κάτω. Το τμήμα κλεισίματος επιστρέφει στο αρχικό σημείο χωρίς επιπλέον συντεταγμένες.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Σχήμα PowerPoint με ευθεία άνω πλευρά, καμπύλη πλευρά από το άνω δεξί προς το κάτω αριστερό και ευθεία αριστερή πλευρά](contour.png)

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σχήματος**

Χρησιμοποιήστε το [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) για να επιθεωρήσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία διαδρομής και τύπους σημείων. Χρησιμοποιήστε κάθε επιστρεφόμενο [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) για να ανακτήσετε τους πίνακες σημείων και τύπων μέσω των μεθόδων [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) και [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγράμματος ή για μεταφορά γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει το input.pptx, εντοπίζει το πρώτο γεωμετρικό σχήμα απευθείας στην πρώτη διαφάνεια και εμφανίζει τα τμήματα της διαδρομής του. Χρησιμοποιήστε μια παρουσίαση που περιέχει ένα σχήμα με ευθείες και καμπύλες πλευρές για να δείτε και τις δύο μορφές εξόδου. Δεν ψάχνει μέσα σε ομάδες.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Διατηρούμε τον τύπο τμήματος, εξαιρώντας τις σημαίες.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Καταναλώνει και τα δύο σημεία ελέγχου και το σημείο τερματισμού.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει τον ρόλο του. Ο τύπος `0` ξεκινά ένα σχήμα, και ο τύπος `1` σχεδιάζει γραμμή από το προηγούμενο σημείο στο τρέχον σημείο. Ένα τμήμα Bézier τρίτου βαθμού ξεκινά από το προηγούμενο τελικό σημείο και χρησιμοποιεί τρία διαδοχικά στοιχεία τύπου `3`: δύο σημεία ελέγχου ακολουθούμενα από το νέο τελικό σημείο. Η βρόχος καταναλώνει αυτά τα τρία στοιχεία μαζί και ελέγχει το τελικό σημείο για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Χρησιμοποιήστε μάσκα `0x07` για να προσδιορίσετε τον τύπο τμήματος, και ελέγξτε ξεχωριστά το `0x80` για να εντοπίσετε ένα κλειστό υποσυνολο. Για παράδειγμα, το `129` (`0x81`) σημαίνει ένα άκρο γραμμής που κλείνει ένα υποσυνολο, και το `131` (`0x83`) σημαίνει ένα άκρο Bézier που κλείνει ένα. Η Java αποθηκεύει αυτές τις σημαίες σε υπογόμενα bytes· η μάσκα διατηρεί τις προτιμόμενες τιμές των bit. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα αγνοούσε αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.**  
Οι μονάδες μετρώνται σε points (1/72 ίντσα), με το X να αυξάνεται προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση που επιστρέφει το [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) και το [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) και αντανακλούν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη περιστρεφόμενο ορθογώνιο στη θέση `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέτετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και το Y του για να λάβετε συντεταγμένες σε σχέση με το μη περιστρεφόμενο πλαίσιο του.

Οι εξαγόμενα σημεία δεν εφαρμόζουν την περιστροφή του σχήματος, που επιστρέφει το [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), ούτε τις οριζόντιες και κάθετες αναστροφές. Για να αναπαράγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτές τις μετασχηματισίες γύρω από το κέντρο του σχήματος. Για σχήματα σε ομάδες, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων της ομάδας και τις μετασχηματισίες· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόστε ξανά μετάφραση ή κλίμακα αν ήδη εμφανίζονται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.**  
Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η τροποποίησή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτή τη μέθοδο όταν η ανάλυση ή ο κώδικας σχεδίασής σας χρειάζεται πίνακες σημείων/τύπων. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τις επεξεργασμένες διαδρομές μέσω του [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ή του [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Μετατροπή Σχήματος Java AWT σε GeometryPath**

Αυτό το παράδειγμα συνδυάζει ένα ορθογώνιο περίγραμμα με κείμενο που μετατρέπεται σε γεωμετρία. Η μέθοδος [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) του περιγράμματος απενεργοποιεί τη γεμίσμα του. Ένα [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) δημιουργεί το περίγραμμα κειμένου σε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Ο [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του παρέχει εντολές μετακίνησης, γραμμής, τετραγωνικής, κυβικής και κλεισίματος, τις οποίες το παράδειγμα επαναλαμβάνει σε ένα [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Η γέφυρα Java χρησιμοποιεί ρητές τιμές float και byte για τις αντίστοιχες παραμέτρους Java. Ο iterator γράφει τις συντεταγμένες σε έναν πίνακα float της Java· η αντανάκλαση διαβάζει τις ενημερωμένες τιμές πίσω στο JavaScript. Το κείμενο χρησιμοποιεί γραμματοσειρά Arial 40 points. Το περίγραμμα έχει οριζόντια μετατόπιση 20 points και τοποθετείται έτσι ώστε το οπτικό του επάνω μέρος να είναι 10 points κάτω από την άνω πλευρά του σχήματος. Η διαδρομή κειμένου γεμίζεται, ενώ το αρχικό ορθογώνιο παραμένει περίγραμμα. Η εφαρμογή και των δύο διαδρομών με το [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) παράγει ένα ενιαίο σχήμα που περιέχει το ορθογώνιο και το κείμενο.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Μετακίνηση σε.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Γραμμή προς.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Τετραγωνική καμπύλη Bezier.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Κυβική καμπύλη Bezier.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Κλείσιμο σχήματος.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Τι θα συμβεί στη γεμιστική και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γεμίσμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να "κλειδώσω" το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή [slide](/slides/el/nodejs-java/convert-powerpoint-to-png/) ή το ίδιο το [shape](/slides/el/nodejs-java/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με πολύπλοκες γεωμετρίες.