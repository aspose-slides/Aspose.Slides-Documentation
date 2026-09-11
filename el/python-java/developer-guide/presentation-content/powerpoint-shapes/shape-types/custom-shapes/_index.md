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
- διαδρομή γεωμετρίας
- σημεία διαδρομής
- σημεία επεξεργασίας
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- καμπυλωτή γωνία
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω Java: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία των σχημάτων μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία σε ένα σχήμα.

Δείχνει επίσης πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να δημιουργήσετε σχήματα με καμπυλωμένες γωνίες, να καθορίσετε εάν μια γεωμετρία σχήματος είναι κλειστή και να μετατρέψετε μεταξύ [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) και [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) για επιπλέον σενάρια προσαρμογής γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Σκεφτείτε ένα τετράγωνο. Στο PowerPoint, χρησιμοποιώντας **σημεία επεξεργασίας**, μπορείτε

* να μετακινήσετε την γωνία του τετραγώνου προς το εσωτερικό ή το εξωτερικό
* να ορίσετε την καμπυλότητα για μια γωνία ή σημείο
* να προσθέσετε νέα σημεία στο τετράγωνο
* να χειριστείτε σημεία στο τετράγωνο, κ.λπ.

Βασικά, μπορείτε να εκτελέσετε τις περιγραφόμενες εργασίες σε οποιοδήποτε σχήμα. Χρησιμοποιώντας σημεία επεξεργασίας, μπορείτε να αλλάξετε ένα σχήμα ή να δημιουργήσετε νέο σχήμα από ένα υπάρχον σχήμα.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Πριν ξεκινήσετε την επεξεργασία σχημάτων PowerPoint μέσω σημείων επεξεργασίας, ίσως θέλετε να λάβετε υπόψη τα εξής σημεία σχετικά με τα σχήματα:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι κλειστό ή ανοικτό.
* Όταν ένα σχήμα είναι κλειστό, δεν έχει σημείο έναρξης ή λήξης. Όταν είναι ανοικτό, έχει αρχή και τέλος.
* Όλα τα σχήματα αποτελούνται τουλάχιστον από 2 άγκυρες (anchor) σημεία συνδεδεμένα μεταξύ τους με γραμμές.
* Μια γραμμή μπορεί να είναι ευθεία ή καμπυλωτή. Τα άγκυρα (anchor) σημεία καθορίζουν τη φύση της γραμμής.
* Τα άγκυρα σημεία υπάρχουν ως γωνιακά σημεία, ευθείες (straight) ή ομαλά (smooth) σημεία:
  * Ένα γωνιακό σημείο είναι σημείο όπου 2 ευθείες γραμμές ενώνονται υπό γωνία.
  * Ένα ομαλό σημείο είναι σημείο όπου 2 χειρολαβές (handles) βρίσκονται σε ευθεία γραμμή και τα τμήματα της γραμμής ενώνονται σε ομαλή καμπύλη. Σε αυτή την περίπτωση, όλες οι χειρολαβές είναι διατεταγμένες από το άγκυρο σημείο με ίση απόσταση.
  * Ένα ευθύ σημείο είναι σημείο όπου 2 χειρολαβές βρίσκονται σε ευθεία γραμμή και τα τμήματα της γραμμής ενώνονται σε ομαλή καμπύλη. Σε αυτή την περίπτωση, οι χειρολαβές δεν χρειάζεται να είναι διατεταγμένες από το άγκυρο σημείο με ίση απόσταση.
* Με τη μετακίνηση ή επεξεργασία των άγκυρων σημείων (που αλλάζει τη γωνία των γραμμών), μπορείτε να αλλάξετε την εμφάνιση του σχήματος.

Για την επεξεργασία σχημάτων PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/).

* Μια παρουσίαση [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/).
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) από την παρουσίαση [GeometryShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) σε ένα σχήμα, μπορείτε να χρησιμοποιήσετε τις μεθόδους: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/#setGeometryPath) για *συμπαγή σχήματα* και [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/#setGeometryPaths) για *σύνθετα σχήματα*.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/).
* Χρησιμοποιώντας τις μεθόδους [GeometryPath.setStroke](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/#setStroke) και [GeometryPath.setFillMode](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/#setFillMode), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.
* Με την μέθοδο [GeometryPath.getPathData](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/#getPathData), μπορείτε να ανακτήσετε τη διαδρομή γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων διαδρομής.
* Για πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) σε [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
* Χρησιμοποιήστε τις μεθόδους [geometryPathToGraphicsPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeutil/) και [graphicsPathToGeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeutil/) (από την κλάση [ShapeUtil](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeutil/)) για να μετατρέψετε το [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) σε [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) και αντίστροφα.

## **Απλές Λειτουργίες Επεξεργασίας**

Οι παρακάτω υπογραφές δείχνουν τις βασικές λειτουργίες επεξεργασίας:

**Προσθήκη γραμμής** στο τέλος μιας διαδρομής:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Προσθήκη γραμμής** σε καθορισμένη θέση στην διαδρομή:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Προσθήκη κυβικής καμπύλης Bezier** στο τέλος μιας διαδρομής:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Προσθήκη κυβικής καμπύλης Bezier** στην καθορισμένη θέση στην διαδρομή:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Προσθήκη τετραγωνικής καμπύλης Bezier** στο τέλος μιας διαδρομής:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Προσθήκη τετραγωνικής καμπύλης Bezier** στην καθορισμένη θέση στην διαδρομή:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Προσθήκη δοσμένης τόξου** στην διαδρομή:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Κλείσιμο του τρέχοντος σχήματος** της διαδρομής:

- `geometry_path.closeFigure()`

**Ορισμός θέσης για το επόμενο σημείο**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Αφαίρεση τμήματος διαδρομής** σε δεδομένο δείκτη:

- `geometry_path.removeAt(index)`

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**
1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/) και ορίστε τον τύπο [ShapeType.Rectangle](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#Rectangle).
2. Αποκτήστε μια παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) από το σχήμα.
3. Προσθέστε ένα νέο σημείο μεταξύ των δύο άνω σημείων της διαδρομής.
4. Προσθέστε ένα νέο σημείο μεταξύ των δύο κάτω σημείων της διαδρομής.
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτό το κώδικα Python δείχνει πώς να προσθέσετε προσαρμοσμένα σημεία σε ένα σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/) και ορίστε τον τύπο [ShapeType.Heart](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#Heart).
2. Αποκτήστε μια παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) από το σχήμα.
3. Αφαιρέστε το τμήμα της διαδρομής.
4. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτό το κώδικα Python δείχνει πώς να αφαιρέσετε σημεία από ένα σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος**

1. Υπολογίστε τα σημεία για το σχήμα.
2. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/).
3. Συμπληρώστε τη διαδρομή με τα σημεία.
4. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/).
5. Εφαρμόστε τη διαδρομή στο σχήμα.

Αυτό το κώδικα Python δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα:

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
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)


## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

  1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/).
  2. Δημιουργήστε μια πρώτη παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/).
  3. Δημιουργήστε μια δεύτερη παρουσίαση της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/).
  4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτό το κώδικα Python δείχνει πώς να δημιουργήσετε ένα σύνθετο προσαρμοσμένο σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπυλωτές Γωνίες**

Αυτό το κώδικα Python δείχνει πώς να δημιουργήσετε ένα προσαρμοσμένο σχήμα με καμπυλωτές γωνίες (προς το εσωτερικό):

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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
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

## **Εντοπισμός Εάν Η Γεωμετρία Σχήματος Είναι Κλειστή**

Ένα κλειστό σχήμα ορίζεται ως εκείνο στο οποίο όλες οι πλευρές του συνδέονται, σχηματίζοντας ένα ενιαίο σύνορο χωρίς κενά. Ένα τέτοιο σχήμα μπορεί να είναι απλή γεωμετρική μορφή ή πολύπλοκη προσαρμοσμένη περιγράμμιση. Ο παρακάτω κώδικας δείχνει πώς να ελέγξετε εάν η γεωμετρία ενός σχήματος είναι κλειστή:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **Μετατροπή GeometryPath σε java.awt.Shape** 

1. Δημιουργήστε μια παρουσίαση της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/).
2. Δημιουργήστε μια παρουσίαση της κλάσης [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Μετατρέψτε την παρουσίαση [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) σε παρουσίαση [GeometryPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometrypath/) περπατώντας τον [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του και επαναλαμβάνοντας κάθε τμήμα στην διαδρομή.
4. Εφαρμόστε τις διαδρομές στο σχήμα.

Αυτό το κώδικα Python υλοποιεί τα παραπάνω βήματα για τη μετατροπή μιας διαδρομής γραφικών σε διαδρομή γεωμετρίας:

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
    # Δημιουργήστε ένα νέο σχήμα.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Αποκτήστε τη διαδρομή γεωμετρίας του σχήματος.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Δημιουργήστε μια νέα διαδρομή γραφικών με κείμενο.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Μετατρέψτε τη διαδρομή γραφικών σε διαδρομή γεωμετρίας.
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

    # Εφαρμόστε τη διαδρομή κειμένου μαζί με την αρχική διαδρομή γεωμετρίας.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Τι συμβαίνει με τη γεμίσμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γεμίσμα και το περίγραμμα εφαρμόζονται αυτόματα στο νέο γεωμετρικό σχήμα.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setRotation) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να «κλειδώσω» το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή [slide](/slides/el/python-java/convert-powerpoint-to-png/) ή το [shape](/slides/el/python-java/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με βαριές γεωμετρίες.