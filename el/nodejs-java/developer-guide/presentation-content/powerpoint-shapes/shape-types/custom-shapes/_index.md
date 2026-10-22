---
title: Προσαρμογή Σχημάτων Παρουσίασης με JavaScript
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
- μονοπάτι γεωμετρίας
- σημεία μονοπατιού
- σημεία επεξεργασίας
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- καμπυλωτές γωνίες
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργία και προσαρμογή σχημάτων σε παρουσιάσεις PowerPoint με JavaScript και Aspose.Slides για Node.js: μονοπάτια γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσιάσεων στο Aspose.Slides επεξεργάζοντας τη γεωμετρία των σχημάτων μέσω σημείων επεξεργασίας και μονοπατιών γεωμετρίας. Δείχνει πώς να εργαστείτε με [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας μονοπατιού, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε τη νέα γεωμετρία σε ένα σχήμα.

Επίσης δείχνει πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να χτίσετε σχήματα με καμπύλες γωνίες, να προσδιορίσετε αν η γεωμετρία ενός σχήματος είναι κλειστή, να επιθεωρήσετε στοιχεία σχήματος και να μετατρέψετε περιγράμματα κειμένου Java AWT σε μονοπάτια γεωμετρίας.

## **Αλλαγή Σχήματος με Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Σημεία Επεξεργασίας** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Όταν επεξεργάζεστε σχήματα PowerPoint, κρατήστε αυτά τα concepts στο μυαλό:

* Ένα σχήμα (ή το μονοπάτι του) μπορεί να είναι είτε κλειστό είτε ανοιχτό.
* Το μονοπάτι ενός σχήματος αποτελείται από άγκυρα σημεία συνδεδεμένα με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή κυρτό. Τα άγκυρα σημεία και τα χειριστήρια ελέγχου καθορίζουν το σχήμα του.
* Τα άγκυρα σημεία υπάρχουν ως γωνιακά σημεία, ευθύγραμμα σημεία ή ομαλά σημεία:
  * Σε γωνιακό σημείο, τα γειτονικά τμήματα μπορούν να συναντηθούν υπό γωνία.
  * Σε ομαλό σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα και έχουν την ίδια απόσταση από το άγκυρα σημείο.
  * Σε ευθύ σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα αλλά μπορεί να έχουν διαφορετικές αποστάσεις από το άγκυρα σημείο.
* Η μετακίνηση των άγκυρων σημείων ή η ρύθμιση των χειριστηρίων τους αλλάζει το περίγραμμα του σχήματος.

Για την επεξεργασία σχημάτων PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Μια παρουσίαση [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) αντιπροσωπεύει ένα μονοπάτι γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) από την παρουσίαση [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) για σχήματα με ένα μόνο μονοπάτι και [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) για σχήματα με πολλαπλά μονοπάτια.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους της κλάσης [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Χρησιμοποιώντας τις μεθόδους [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) και [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), μπορείτε να ορίσετε την εμφάνιση ενός μονοπατιού γεωμετρίας.
* Με τη μέθοδο [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), μπορείτε να λάβετε το μονοπάτι γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων μονοπατιού.
* Για πρόσβαση σε πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να διαβάσετε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) μέσω του [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) και να επαναλάβετε τα τμήματα σε ένα [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε ένα μονοπάτι γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη μηδενική θέση του πίνακα τμημάτων του μονοπατιού.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθέτει ή εισάγει ευθεία γραμμή. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Προσθέτει ή εισάγει κυβική καμπύλη Bézier με δύο σημεία ελέγχου και σημείο τερματισμού. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Προσθέτει ή εισάγει τετραγωνική καμπύλη Bézier με ένα σημείο ελέγχου και σημείο τερματισμού. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Προσθέτει ελλειπτικό τόξο με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Κλείνει το τρέχον σχήμα συνδέοντας το τελικό του σημείο με το αρχικό. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Ορίζει το αρχικό σημείο ενός σχήματος. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Αφαιρεί ένα τμήμα σε μηδενική βάση δείκτη. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) και εφαρμόζει το επεξεργασμένο μονοπάτι με [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 μονάδες από την αριστερή πλευρά και 50 μονάδες από την κορυφή. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στην επάνω και κάτω άκρη, τραβώντας αυτές τις άκρες προς το εσωτερικό.

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

Αυτό το παράδειγμα αλλάζει το περίγραμμα μιας καρδιάς αφαιρώντας το τμήμα στη μηδενική θέση δείκτη 2 με [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Η εφαρμογή του τροποποιημένου μονοπατιού με [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ενημερώνει το περίγραμμα του σχήματος.

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

Αυτό το παράδειγμα κατασκευάζει ένα πεντάφυλλο αστέρι χρησιμοποιώντας [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 μονάδες ορίζουν τις άκτες και τις εγκοπές· ένα βήμα 72 μοιρών διανέμεται ισομερώς στις πέντε άκτες. Το μονοπάτι κλείνει με [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) και εφαρμόζεται σε ένα ορθογώνιο σχήμα με [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), αντικαθιστώντας το περίγραμμά του.

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

Αυτό το παράδειγμα ορίζει δύο κλειστά αντικείμενα [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) για το άνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο μονοπατιών με [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) δημιουργεί ένα ενιαίο σύνθετο σχήμα με κενό στη μέση τρίτη του.

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

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπύλες Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθείες γραμμές με [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) για να δημιουργήσει σχήμα με εσωτερικά κυρτές γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος του τόξου σε μονάδες, και η περιστροφή -90 μοιρών σχεδιάζει ένα τέταρτο έλλειψας αριστερόστροφα. Το ολοκληρωμένο μονοπάτι εφαρμόζεται με [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

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

## **Έλεγχος Εάν Η Γεωμετρία Σχήματος Είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει εάν κάθε μη κενό μονοπάτι γεωμετρίας λήγει με τμήμα κλεισίματος. Διαβάζει το [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) και συγκρίνει τη τελική εντολή του τμήματος [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) με [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενά μονοπάτια. Αυτό ελέγχει την τελική εντολή κάθε μονοπατιού· δεν επιθεωρεί κάθε υποσχήμα μέσα σε ένα μονοπάτι. Το παράδειγμα εκτυπώνει `true` για ένα ορθογώνιο.

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

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σχήματος**

Χρησιμοποιήστε το [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) για να επιθεωρήσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία μονοπατιού και τύπους σημείων. Κάθε [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) επιστρέφει τα σύνολα σημείων και τύπων μέσω των μεθόδων [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) και [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγράμματος ή για μεταφορά γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει το *input.pptx*, εντοπίζει το πρώτο σχήμα γεωμετρίας στην πρώτη διαφάνεια και εκτυπώνει τα τμήματα του μονοπατιού του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθείες και κυρτές γωνίες για να δείτε και τις δύο μορφές εξόδου. Δεν ψάχνει μέσα σε ομάδες.

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
                const pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
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

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει τη λειτουργία του. Ο τύπος `0` ξεκινά ένα σχήμα, και ο τύπος `1` σχεδιάζει γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα κυβικής Bézier ξεκινά από το προηγούμενο τελικό σημείο και χρησιμοποιεί τρία διαδοχικά στοιχεία τύπου `3`: δύο σημεία ελέγχου και το νέο τελικό σημείο. Ο βρόχος καταναλώνει αυτά τα τρία στοιχεία μαζί και ελέγχει το τελικό σημείο για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Κάντε μάσκα με `0x07` για να προσδιορίσετε τον τύπο τμήματος και ελέγξτε `0x80` ξεχωριστά για να ανιχνεύσετε ένα κλειστό υπομονοπάτι. Για παράδειγμα, `129` (`0x81`) σημαίνει ένα άκρο γραμμής που κλείνει ένα υπομονοπάτι, και `131` (`0x83`) σημαίνει ένα άκρο Bézier που κλείνει ένα. Η Java αποθηκεύει αυτές τις σημαίες σε υπογεγραμμένα bytes· η μάσκα διατηρεί τις προδιαγεγραμμένες τιμές bit. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα χάνονταν αυτές οι περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρώνται σε μονάδες (1/72 ίντσας), με το X να αυξάνει προς τα δεξιά και το Y να αυξάνει προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση που επιστρέφει το [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) και το [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) και αντικατοπτρίζουν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη περιστρεφόμενο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέσετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και Y του για να λάβετε τις συντεταγμένες σε σχέση με το ακατέργαστο πλαίσιο του.

Τα εξαγόμενα σημεία δεν εφαρμόζουν την περιστροφή του σχήματος, που επιστρέφει το [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), ούτε τις οριζόντιες και κατακόρυφες αναστροφές. Για να αναπαραγάγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτές τις μετατροπές γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη μετατόπιση συντεταγμένων της ομάδας και τις μετατροπές· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες στο διαφάνεια ή ότι πρέπει να εφαρμόσετε τη μετάφραση ή κλιμάκωση δύο φορές αν ήδη λογικά περιλαμβάνονται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτήν τη μέθοδο όταν η ανάλυση ή ο κώδικάς σας χρειάζεται πίνακες σημείου/τύπου. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε επεξεργασμένα μονοπάτια μέσω του [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ή του [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Μετατροπή Java AWT Shape σε GeometryPath**

Αυτό το παράδειγμα συνδυάζει ένα ορθογώνιο περίγραμμα με κείμενο που έχει μετατραπεί σε γεωμετρία. Η μέθοδος [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) του περιγράμματος απενεργοποιεί τη γέμισή του. Ένα [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) δημιουργεί το περίγραμμα κειμένου σε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Ο [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του παρέχει εντολές κίνησης, γραμμής, τετραγωνικής, κυβικής και κλεισίματος, που το παράδειγμα επαναλαμβάνει σε ένα [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Η γέφυρα Java χρησιμοποιεί ρητές τιμές float και byte για τις αντίστοιχες παραμέτρους Java. Ο Iterator γράφει συντεταγμένες σε έναν πίνακα float της Java· η απεικόνιση διαβάζει τις ενημερωμένες τιμές πίσω σε JavaScript. Το κείμενο χρησιμοποιεί γραμματοσειρά Arial 40 σημείων. Το περίγραμμα μετατοπίζεται 20 σημείων οριζόντια και τοποθετείται με το οπτικό του άνω άκρο 10 σημεία κάτω από την κορυφή του σχήματος. Η διαδρομή κειμένου γεμίζει, ενώ το αρχικό ορθογώνιο παραμένει περίγραμμα. Η εφαρμογή και των δύο διαδρομών με [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) δημιουργεί ένα ενιαίο σχήμα που περιέχει το ορθογώνιο και το κείμενο.

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
            case 2: // Τετραγωνική καμπύλη Bézier.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Κυβική καμπύλη Bézier.
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

## **Συχνές Ερωτήσεις**

**Τι γίνεται με τη γέμιση και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γέμιση και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο του σχήματος [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation)· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο τοπικό σύστημα συντεταγμένων του.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για "κλείδωμα" του αποτελέσματος;**

Ναι. Εξάγετε την απαιτούμενη [slide](/slides/el/nodejs-java/convert-powerpoint-to-png/) περιοχή ή το [shape](/slides/el/nodejs-java/create-shape-thumbnails/) ίδιο σε μορφή raster· αυτό απλοποιεί περαιτέρω εργασία με πολύπλοκες γεωμετρίες.