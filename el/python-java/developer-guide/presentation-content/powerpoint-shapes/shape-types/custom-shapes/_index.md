---
title: Προσαρμογή Σχημάτων Παρουσίασης σε Python μέσω Java
linktitle: Προσαρμοσμένο Σχήμα
type: docs
weight: 20
url: /el/python-java/custom-shape/
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
- Python
- Aspose.Slides
description: "Δημιουργία και προσαρμογή σχημάτων σε παρουσιάσεις PowerPoint με Aspose.Slides για Python μέσω Java: μονοπάτια γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία σχήματος μέσω σημείων επεξεργασίας και μονοπατιών γεωμετρίας. Δείχνει πώς να εργάζεστε με [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας μονοπατιών, να προσθέσετε ή να καταργήσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία πίσω σε ένα σχήμα.

Επίσης, παρουσιάζει πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να κατασκευάσετε σχήματα με καμπυλωμένες γωνίες, να καθορίσετε αν μια γεωμετρία σχήματος είναι κλειστή, να επιθεωρήσετε στοιχεία σχήματος και να μετατρέψετε τα περιγράμματα κειμένου Java AWT σε μονοπάτια γεωμετρίας.

## **Αλλαγή Σχήματος με Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Σημεία Επεξεργασίας** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Όταν επεξεργάζεστε σχήματα PowerPoint, κρατήστε στο μυαλό σας τις παρακάτω έννοιες:

* Ένα σχήμα (ή το μονοπάτι του) μπορεί να είναι είτε κλειστό είτε ανοικτό.
* Το μονοπάτι ενός σχήματος αποτελείται από άγκυρες συνδεδεμένες με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή καμπύλο. Οι άγκυρες και τα χειριστήρια ελέγχου καθορίζουν το σχήμα του.
* Οι άγκυρες μπορούν να είναι σημεία γωνίας, ευθύ ή λείου:
  * Σε σημείο γωνίας, τα γειτονικά τμήματα μπορούν να συναντηθούν σε γωνία.
  * Σε λείο σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα και ισαπέχοντα από την άγκυρα.
  * Σε ευθύ σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα αλλά μπορεί να έχουν διαφορετικές αποστάσεις από την άγκυρα.
* Η μετακίνηση των αγκυρών ή η ρύθμιση των χειριστηρίων τους αλλάζει το περίγραμμα του σχήματος.

Για την επεξεργασία σχήματων PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Μια παρουσίαση [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) αντιπροσωπεύει το μονοπάτι γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) από την παρουσίαση [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) ενός σχήματος, μπορείτε να χρησιμοποιήσετε τις μεθόδους: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) για σχήματα με ένα μονοπάτι και [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) για σχήματα με πολλά μονοπάτια.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους της κλάσης [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Χρησιμοποιώντας τις μεθόδους [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) και [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), μπορείτε να ορίσετε την εμφάνιση ενός μονοπατιού γεωμετρίας.
* Με τη μέθοδο [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData), μπορείτε να ανακτήσετε το μονοπάτι γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων μονοπατιού.
* Για πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να διαβάσετε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) μέσω του [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) και να επαναλάβετε τα τμήματα σε ένα [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε ένα μονοπάτι γεωμετρίας. Οι υπερφορτώσεις που δέχονται ευρετήριο εισάγουν ένα τμήμα στη μηδενική θέση του πίνακα τμημάτων του μονοπατιού.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή ευθείας γραμμής. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Προσθήκη ή εισαγωγή κυρτής καμπύλης Bézier με δύο σημεία ελέγχου και ένα άκρο. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Προσθήκη ή εισαγωγή τετραγωνικής καμπύλης Bézier με ένα σημείο ελέγχου και ένα άκρο. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Προσθήκη ελλειπτικού τόξου με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Κλείσιμο της τρέχουσας μορφής συνδέοντας το άκρο της με το αρχικό σημείο. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Ορισμός του αρχικού σημείου μιας μορφής. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Αφαίρεση τμήματος σε μηδενική βάση ευρετηρίου. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Το παράδειγμα αυτό εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) και εφαρμόζει το επεξεργασμένο μονοπάτι με [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 μονάδες από τα αριστερά και 50 μονάδες από την κορυφή. Τα ευρετήρια τμημάτων 1 και 4 τα τοποθετούν στις άνω και κάτω άκρες, τραβώντας αυτές τις άκρες προς το εσωτερικό.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

Το παράδειγμα αυτό τροποποιεί το περίγραμμα σχήματος καρδιάς αφαιρώντας το τμήμα στη μηδενική θέση ευρετηρίου 2 με [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Η εφαρμογή του τροποποιημένου μονοπατιού με [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ενημερώνει το περίγραμμα του σχήματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος**

Το παράδειγμα αυτό κατασκευάζει έναν πεντάγωνο αστέρι με χρήση του [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Οι εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες των 100 και 50 μονάδων καθορίζουν τις άκρες και τις εσοχές· ένα βήμα 72 μοιρών διαχωρίζει ομοιόμορφα τις πέντε άκρες. Το μονοπάτι κλείνει με [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) και εφαρμόζεται σε ένα ορθογώνιο σχήμα μέσω [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), αντικαθιστώντας το προηγούμενο περίγραμμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

Το παράδειγμα αυτό ορίζει δύο κλειστά αντικείμενα [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) για το άνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο μονοπατιών με [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) δημιουργεί ένα ενιαίο σύνθετο σχήμα με κενό στο μέσο τρίτου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπύλες Γωνίες**

Το παράδειγμα αυτό συνδυάζει ευθεία τμήματα με [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) για να δημιουργήσει ένα σχήμα με εσωτερικά καμπυλωτές γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος του τόξου σε μονάδες, και η σκέψη -90 μοίρες σχεδιάζει ένα τέταρτο έλλειψο αντίστροφα. Το ολοκληρωμένο μονοπάτι εφαρμόζεται με [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Έλεγχος Αν η Γεωμετρία Σχήματος Είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει εάν κάθε μη κενό μονοπάτι γεωμετρίας τελειώνει με τμήμα κλεισίματος. Διαβάζει το [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) και συγκρίνει την τελική εντολή του τμήματος [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) με το [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Επιστρέφει `False` όταν δεν υπάρχουν μη κενά μονοπάτια. Αυτό ελέγχει την τελική εντολή κάθε μονοπατιού· δεν εξετάζει κάθε υποσχήμα μέσα σε ένα μονοπάτι. Το παράδειγμα εκτυπώνει `True` για ένα ορθογώνιο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Επιθεώρηση Εντολών Μονοπατιού Γεωμετρίας**

Κατεβάστε το [contour.pptx](contour.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Το πρώτο σχήμα στην πρώτη διαφάνεια έχει ευθεία άνω άκρη, κυρτή καμπύλη Bézier και ευθεία κλειστική άκρη. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) για να διαβάσετε τα μονοπάτια του σχήματος και το [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) για να διαβάσετε τα τμήματα κάθε μονοπατιού με σειρά σχεδίασης. Για κάθε τμήμα, το [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) προσδιορίζει την εντολή και καθορίζει πώς να ερμηνεύσετε τις τιμές που επιστρέφει το [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

Το σχήμα βρίσκεται στο (200, 100) μονάδες της διαφάνειας. Οι αναφερθείσες συντεταγμένες είναι τοπικές στο σχήμα, με το (0, 0) στην επάνω αριστερή γωνία, x αυξάνεται προς τα δεξιά και y αυξάνεται προς τα κάτω. Το κλειστικό τμήμα επιστρέφει στο αρχικό σημείο χωρίς επιπλέον συντεταγμένες.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Εξαγωγή και Έλεγχος Στοιχείων Σχήματος**

Χρησιμοποιήστε το [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) για να επιθεωρήσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία μονοπατιού και τύπους σημείων. Μετατρέψτε κάθε επιστρεφόμενο στοιχείο σε [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) με `jpype.JObject` για να ανακτήσετε τους πίνακες σημείων και τύπων μέσω των μεθόδων [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) και [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγράμματος ή για μεταβίβαση γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει το input.pptx, εντοπίζει το πρώτο σχήμα γεωμετρίας άμεσα στην πρώτη διαφάνεια και εκτυπώνει τα τμήματα του μονοπατιού του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθείες και καμπύλες άκρες για να δείτε και τις δύο μορφές εξόδου. Δεν ψάχνει μέσα σε ομάδες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Διατηρήστε τον τύπο τμήματος, εξαιρώντας σημαίες.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει το ρόλο του. Ο τύπος `0` ξεκινά μια μορφή, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα κυρτής Bézier ξεκινά από το προηγούμενο άκρο και χρησιμοποιεί τρεις διαδοχικές εγγραφές τύπου `3`: δύο σημεία ελέγχου και στη συνέχεια το νέο άκρο. Ο βρόχος καταναλώνει αυτές τις τρεις εγγραφές μαζί και ελέγχει το άκρο για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Εφαρμόστε μάσκα `0x07` για να προσδιορίσετε τον τύπο τμήματος και ελέγξτε ξεχωριστά το `0x80` για να εντοπίσετε κλειστό υπομονοπάτι. Για παράδειγμα, το `129` (`0x81`) σημαίνει άκρο γραμμής που κλείνει υπομονοπάτι, και το `131` (`0x83`) σημαίνει άκρο Bézier που κλείνει ένα. Η Java αποθηκεύει αυτές τις σημαίες σε υπογραφόμενα bytes· η μάσκα διατηρεί τις προγραμματισμένες τιμές bit. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετριούνται σε μονάδες (1/72 ίντσα), με X να αυξάνεται προς τα δεξιά και Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση που επιστρέφει το [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) και το [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) και αντικατοπτρίζουν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη περιστρεφόμενο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέτετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και Y του για να λάβετε συντεταγμένες σε σχέση με το μη περιστρεφόμενο πλαίσιο του.

Τα εξαγόμενα σημεία δεν εφαρμόζουν την περιστροφή του σχήματος, που επιστρέφει το [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), ή τις οριζόντιες και κατακόρυφες αντιστροφές. Για να αναδημιουργήσετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτούς τους μετασχηματισμούς γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων της ομάδας και τους μετασχηματισμούς· μην υποθέσετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόστε ξανά μετάθεση ή κλιμάκωση αν ήδη ενσωματώνονται στο πλαίσιο του παιδικού αντικειμένου.

**Έλεγχος έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτήν την προσέγγιση όταν η ανάλυση ή ο κώδικας σχεδίασης απαιτεί πίνακες σημείου/τύπου. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τα επεξεργασμένα μονοπάτια μέσω του [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ή του [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Μετατροπή Java AWT Shape σε GeometryPath**

Το παράδειγμα αυτό συνδυάζει ένα ορθογώνιο περίγραμμα με κείμενο μετατρεπόμενο σε γεωμετρία. Η μέθοδος [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) του περιγράμματος απενεργοποιεί το γέμισμα. Ένα [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) δημιουργεί το περίγραμμα κειμένου σε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Ο [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του παρέχει κινήσεις, γραμμές, τετραγωνικές, κυρτές και κλειστικές εντολές, τις οποίες το παράδειγμα επαναλαμβάνει σε ένα [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Το κείμενο χρησιμοποιεί γραμματοσειρά Arial 40 σημείων. Το περίγραμμα μετατοπίζεται 20 μονάδες οριζόντια και τοποθετείται ώστε η οπτική του κορυφή να είναι 10 μονάδες κάτω από την άνω άκρη του σχήματος. Το μονοπάτι του κειμένου γεμίζεται, ενώ το αρχικό ορθογώνιο παραμένει περίγραμμα. Η ταυτόχρονη εφαρμογή των δύο μονοπατιών με [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) παράγει ένα ενιαίο σχήμα που περιέχει το ορθογώνιο και το κείμενο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Λάβετε το μονοπάτι γεωμετρίας του σχήματος.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Δημιουργήστε ένα νέο μονοπάτι γραφικών με κείμενο.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # Μετατρέψτε το μονοπάτι γραφικών σε μονοπάτι γεωμετρίας.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Εφαρμόστε το μονοπάτι κειμένου μαζί με το αρχικό μονοπάτι γεωμετρίας.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **Συχνές Ερωτήσεις**

**Τι θα συμβεί στο γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτομάτως στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο σύστημα συντεταγμένων του σχήματος.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να «κλειδώσω» το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη [διαφάνεια](/slides/el/python-java/convert-powerpoint-to-png/) ή το [σχήμα](/slides/el/python-java/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με πολύπλοκες γεωμετρίες.