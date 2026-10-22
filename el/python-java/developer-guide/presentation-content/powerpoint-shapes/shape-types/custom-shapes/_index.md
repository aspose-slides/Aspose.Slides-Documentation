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

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία των σχημάτων μέσω σημείων επεξεργασίας και μονοπατιών γεωμετρίας. Δείχνει πώς να εργάζεστε με [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να πραγματοποιήσετε βασικές λειτουργίες επεξεργασίας μονοπατιού, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε τη ενημερωμένη γεωμετρία σε ένα σχήμα.

Δείχνει επίσης πώς να δημιουργείτε προσαρμοσμένα και σύνθετα σχήματα, να χτίζετε σχήματα με καμπυλωτές γωνίες, να καθορίζετε εάν μια γεωμετρία σχήματος είναι κλειστή, να επιθεωρείτε στοιχεία σχήματος και να μετατρέπετε περιγράμματα κειμένου Java AWT σε μονοπάτια γεωμετρίας.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Σημεία Επεξεργασίας** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχήματος**

![overview_image](custom_shape_0.png)

Κατά την επεξεργασία σχημάτων PowerPoint, κρατήστε αυτές τις έννοιες στο μυαλό:

* Ένα σχήμα (ή το μονοπάτι του) μπορεί να είναι κλειστό ή ανοιχτό.
* Το μονοπάτι ενός σχήματος αποτελείται από άγκυρα σημεία ενωμένα με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή καμπύλο. Τα άγκυρα σημεία και οι χειρολαβές ελέγχουν το σχήμα του.
* Τα άγκυρα σημεία υπάρχουν ως γωνιακά σημεία, ευθύγραμμα σημεία ή λείες (smooth) σημεία:
  * Σε γωνιακό σημείο, τα προσκείμενα τμήματα μπορούν να συναντιούνται υπό γωνία.
  * Σε λείο σημείο, οι δύο χειρολαβές είναι ευθυγραμμισμένες και ισαπέχουν από το άγκυρα σημείο.
  * Σε ευθύ σημείο, οι δύο χειρολαβές είναι ευθυγραμμισμένες αλλά μπορεί να έχουν διαφορετικές αποστάσεις από το άγκυρα σημείο.
* Η μετακίνηση των άγκυρων σημείων ή η ρύθμιση των χειρολαβών τους αλλάζει το περίγραμμα του σχήματος.

Για την επεξεργασία σχημάτων PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Μια παρουσίαση [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) αντιπροσωπεύει το μονοπάτι γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) από την παρουσίαση [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε αυτές τις μεθόδους: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) για σχήματα με ενιαίο μονοπάτι και [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) για σχήματα με πολλαπλά μονοπάτια.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους της κλάσης [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Χρησιμοποιώντας τις μεθόδους [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) και [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), μπορείτε να ορίσετε την εμφάνιση ενός μονοπατιού γεωμετρίας.
* Με τη μέθοδο [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData), μπορείτε να ανακτήσετε το μονοπάτι γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων μονοπατιού.
* Για πρόσβαση σε πρόσθετες επιλογές προσαρμογής γεωμετρίας σχήματος, μπορείτε να διαβάσετε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) μέσω του [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) και να επαναλάβετε τα τμήματα σε ένα [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε ένα μονοπάτι γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη θέση μηδενικής βάσης στον πίνακα τμημάτων του μονοπατιού.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθέτει ή εισάγει ευθεία γραμμή. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Προσθέτει ή εισάγει κυρτό Bézier κυβικό με δύο σημεία ελέγχου και σημείο τερματισμού. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Προσθέτει ή εισάγει τετραγωνικό Bézier με ένα σημείο ελέγχου και σημείο τερματισμού. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Προσθέτει μια ελλειπτική τόξο με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Κλείνει την τρέχουσα μορφή συνδέοντας το σημείο τερματισμού της με το αρχικό σημείο. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Ορίζει το αρχικό σημείο μιας μορφής. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Αφαιρεί ένα τμήμα σε δείκτη μηδενικής βάσης. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας το [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) και εφαρμόζει το επεξεργασμένο μονοπάτι με το [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 σημεία από αριστερά και 50 σημεία από πάνω. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στις άνω και κάτω άκρες, τραβώντας αυτές τις άκρες προς το εσωτερικό.

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

Αυτό το παράδειγμα τροποποιεί το περίγραμμα μιας καρδιάς αφαιρώντας το τμήμα στη θέση δείκτη μηδενικής βάσης 2 με το [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Η εφαρμογή του τροποποιημένου μονοπατιού με το [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ενημερώνει το περίγραμμα του σχήματος.

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

Αυτό το παράδειγμα δημιουργεί ένα πεντάγωνο αστέρι με το [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες των 100 και 50 σημείων καθορίζουν τις άκρες και τις εσοχές· ένα βήμα 72 μοιρών τοποθετεί τις πέντε άκρες ισομερώς. Το μονοπάτι κλείνεται με το [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) και εφαρμόζεται σε ένα ορθογώνιο σχήμα με το [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), αντικαθιστώντας το περίγραμμα του.

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

Αυτό το παράδειγμα ορίζει δύο κλειστά [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) αντικείμενα για το πάνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο μονοπατιών με το [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) δημιουργεί ένα ενιαίο σύνθετο σχήμα με ένα κενό διαγώνιο στο μεσαίο τρίτο.

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

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπυλωτές Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθύ τμήματα με το [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) για να δημιουργήσει σχήμα με εσωτερικά καμπυλωτές γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος της τόξου σε σημεία, και η στροφή -90 μοιρών σχεδιάζει ένα αντίστροφο τετράγωνο ημιδιαγώνιο. Το ολοκληρωμένο μονοπάτι εφαρμόζεται με το [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

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

## **Εντοπισμός Αν Το Σχήμα Γεωμετρίας Είναι Κλειστό**

Ο παρακάτω βοηθητικός κώδικας ελέγχει εάν κάθε μη-κενό μονοπάτι γεωμετρίας τελειώνει με τμήμα κλεισίματος. Διαβάζει το [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) και συγκρίνει την τελική εντολή του τμήματος [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) με το [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Επιστρέφει `False` όταν δεν υπάρχουν μη-κενά μονοπάτια. Ο έλεγχος γίνεται στην τελική εντολή κάθε μονοπατιού· δεν εξετάζει κάθε υπο-σχήμα μέσα σε ένα μονοπάτι. Το παράδειγμα εμφανίζει `True` για ένα ορθογώνιο.

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

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σχήματος**

Χρησιμοποιήστε το [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) για να επιθεωρήσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία μονοπατιού και τύπους σημείων. Μετατρέψτε κάθε επιστρεφόμενο στοιχείο σε [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) με `jpype.JObject` για να ανακτήσετε τους πίνακες σημείων και τύπων μέσω των μεθόδων [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) και [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Η αναπαράσταση αυτή είναι χρήσιμη για ανάλυση περιγράμματος ή για μεταφορά γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει το `input.pptx`, βρίσκει το πρώτο σχήμα γεωμετρίας στην πρώτη διαφάνεια και εμφανίζει τα τμήματα του μονοπατιού του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθύ και καμπυλωτά τμήματα για να δείτε και τις δύο εκδοχές εξόδου. Δεν ψάχνει μέσα σε ομάδες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
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

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει τον ρόλο του. Ο τύπος `0` αρχίζει μια μορφή, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα Bézier κυβικό ξεκινά από το προηγούμενο σημείο τερματισμού και χρησιμοποιεί τρεις διαδοχικές καταχωρήσεις τύπου `3`: δύο σημεία ελέγχου και το νέο σημείο τερματισμού. Ο βρόχος καταναλώνει αυτές τις τρεις εγγραφές μαζί και ελέγχει το σημείο τερματισμού για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Κάντε μάσκα με `0x07` για να προσδιορίσετε τον τύπο τμήματος και ελέγξτε `0x80` ξεχωριστά για να εντοπίσετε κλειστό υπο-μόνοπαθο. Για παράδειγμα, `129` (`0x81`) σημαίνει σημείο γραμμής που κλείνει ένα υπο-μόνοπαθο, και `131` (`0x83`) σημαίνει σημείο Bézier που κλείνει ένα. Η Java αποθηκεύει αυτές τις σημαίες σε υπογραφές byte· η μάσκα διατηρεί τις προοριζόμενες τιμές bit. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η διακεκομμένη (`0x10`) και η σημαία marker (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρώνται σε points (1/72 ίντσας), με το X να αυξάνεται προς τα δεξιά και το Y να αυξάνεται προς τα κάτω. Για ένα αμασάριστο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση που επιστρέφεται από τα [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) και [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) και αντικατοπτρίζουν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη-στρεφόμενο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέσετε ξανά τη θέση του σχήματος. Αφαιρέστε το X και Y για να λάβετε συντεταγμένες σε σχέση με το μη-στρεφόμενο πλαίσιο.

Τα εξαγόμενα σημεία δεν εφαρμόζουν την περιστροφή του σχήματος, που επιστρέφεται από το [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), ή τις οριζόντιες και κάθετες αναστροφές. Για να αναπαραγάγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτές τις μετασχηματισμούς γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων της ομάδας και τους μετασχηματισμούς· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόστε ξανά μετάφραση ή κλιμάκωση αν ήδη περιλαμβάνονται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτή την προσέγγιση όταν η ανάλυση ή ο κώδικάς σας χρειάζεται πίνακες σημείων/τύπων. Χρησιμοποιήστε το [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε επεξεργασμένα μονοπάτια μέσω του [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ή του [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Μετατροπή Java AWT Shape σε GeometryPath**

Αυτό το παράδειγμα συνδυάζει ένα ορθογώνιο περίγραμμα με κείμενο που έχει μετατραπεί σε γεωμετρία. Η μέθοδος [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) του περιγράμματος απενεργοποιεί τη γεμίσή του. Ένα [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) δημιουργεί το περίγραμμα κειμένου σε ένα [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Ο [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) του παρέχει κινήσεις, ευθείες, τετραγωνικές, κυβικές και κλεισίματος εντολές, τις οποίες το παράδειγμα επαναλαμβάνει σε ένα [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Το κείμενο χρησιμοποιεί γραμματοσειρά Arial 40 points. Το περίγραμμα μετατοπίζεται 20 points οριζόντια και τοποθετείται ώστε η οπτική του κορυφή να είναι 10 points κάτω από την άνω άκρη του σχήματος. Η διαδρομή κειμένου γεμίζεται, ενώ το αρχικό ορθογώνιο παραμένει απλώς περίγραμμα. Η εφαρμογή και των δύο διαδρομών με το [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) δημιουργεί ένα ενιαίο σχήμα που περιέχει το ορθογώνιο και το κείμενο.

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

    # Apply the text path together with the original geometry path.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Τι συμβαίνει με τη γεμίσματος και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Η γεμίσματος και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε τη μέθοδο [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να «κλειδώσω» το αποτέλεσμα;**

Ναι. Εξαγάγετε την απαιτούμενη περιοχή [slide](/slides/el/python-java/convert-powerpoint-to-png/) ή το ίδιο το [shape](/slides/el/python-java/create-shape-thumbnails/) σε μορφή raster· αυτό απλουστεύει την περαιτέρω εργασία με σύνθετες γεωμετρίες.