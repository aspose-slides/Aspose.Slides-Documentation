---
title: Προσαρμογή Σχημάτων σε Παρουσιάσεις με Python
linktitle: Προσαρμοσμένο Σχήμα
type: docs
weight: 20
url: /el/python-net/custom-shape/
keywords:
- προσαρμοσμένο σχήμα
- προσθήκη σχήματος
- δημιουργία σχήματος
- αλλαγή σχήματος
- γεωμετρία σχήματος
- διαδρομή γεωμετρίας
- σημεία διαδρομής
- επεξεργασία σημείων
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- καμπυλωτή γωνία
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για Python μέσω .NET: διαδρομές γεωμετρίας, καμπυλωτές γωνίες, σύνθετα σχήματα."
---
## **Εισαγωγή**

Σκεφτείτε ένα τετράγωνο. Στο PowerPoint, χρησιμοποιώντας **Edit Points**, μπορείτε:

* μετακινήστε την γωνία ενός τετραγώνου προς το εσωτερικό ή το εξωτερικό,
* ρυθμίστε την καμπυλότητα μιας γωνίας ή ενός σημείου,
* προσθέστε νέα σημεία στο τετράγωνο,
* χειριστείτε τα σημεία του.

Μπορείτε να εφαρμόσετε αυτές τις λειτουργίες σε οποιοδήποτε σχήμα. Με το **Edit Points**, μπορείτε να τροποποιήσετε ένα σχήμα ή να δημιουργήσετε ένα νέο από ένα υπάρχον σχήμα.

## **Συμβουλές Επεξεργασίας Σχήματος**

![Εντολή Edit Points](custom_shape_0.png)

Πριν ξεκινήσετε την επεξεργασία των σχημάτων PowerPoint χρησιμοποιώντας το **Edit Points**, λάβετε υπόψη αυτές τις σημειώσεις σχετικά με τα σχήματα:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι **κλειστό** ή **ανοικτό**.
* Ένα κλειστό σχήμα δεν έχει σημείο έναρξης ή λήξης· ένα ανοικτό σχήμα έχει αρχή και τέλος.
* Κάθε σχήμα έχει τουλάχιστον δύο σημεία αγκύρωσης συνδεδεμένα με τμήματα γραμμής.
* Ένα τμήμα είναι είτε ευθύ είτε κυρτό· τα σημεία αγκύρωσης καθορίζουν τη φύση του τμήματος.
* Τα σημεία αγκύρωσης μπορούν να είναι **γωνία**, **ομαλό**, ή **ευθύ**:
  * Ένα **γωνία** σημείο είναι όπου δύο ευθύ τμήματα συναντώνται σε γωνία.
  * Ένα **ομαλό** σημείο έχει δύο χειριστήρια που είναι συγγραμμικά, και τα γειτονικά τμήματα σχηματίζουν μια ομαλή καμπύλη. Σε αυτήν την περίπτωση, και τα δύο χειριστήρια έχουν την ίδια απόσταση από το σημείο αγκύρωσης.
  * Ένα **ευθύ** σημείο επίσης έχει δύο συγγραμμικά χειριστήρια, και τα γειτονικά τμήματα σχηματίζουν μια ομαλή καμπύλη. Σε αυτήν την περίπτωση, τα χειριστήρια δεν χρειάζεται να έχουν την ίδια απόσταση από το σημείο αγκύρωσης.
* Με τη μετακίνηση ή την επεξεργασία των σημείων αγκύρωσης (αλλάζοντας έτσι τις γωνίες των τμημάτων), μπορείτε να αλλάξετε την εμφάνιση του σχήματος.

Για την επεξεργασία σχημάτων PowerPoint, το Aspose.Slides παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) .

* Ένα αντικείμενο [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) αντιπροσωπεύει τη γεωμετρική διαδρομή ενός αντικειμένου [GeometryShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/) .
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) από ένα αντικείμενο [GeometryShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/) , χρησιμοποιήστε τη μέθοδο [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/get_geometry_paths/) .
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) για ένα σχήμα, χρησιμοποιήστε τη [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/set_geometry_path/) για *συμπαγή σχήματα* και τη [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/set_geometry_paths/) για *σύνθετα σχήματα*.
* Για την προσθήκη τμημάτων, χρησιμοποιήστε τις μεθόδους στην κλάση [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) .
* Χρησιμοποιήστε τις ιδιότητες [GeometryPath.stroke](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/stroke/) και [GeometryPath.fill_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/fill_mode/) για να ελέγξετε την εμφάνιση μιας γεωμετρικής διαδρομής.
* Χρησιμοποιήστε την ιδιότητα [GeometryPath.path_data](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/path_data/) για να ανακτήσετε τη γεωμετρική διαδρομή ενός σχήματος ως έναν πίνακα τμημάτων διαδρομής.

## **Απλές Λειτουργίες Επεξεργασίας**

Οι παρακάτω μέθοδοι χρησιμοποιούνται για απλές λειτουργίες επεξεργασίας.

**Προσθήκη γραμμής** στο τέλος μιας διαδρομής:

```py
line_to(point)
line_to(x, y)
```

**Προσθήκη γραμμής** σε συγκεκριμένη θέση σε μια διαδρομή:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Προσθήκη κυβικής καμπύλης Bezier** στο τέλος μιας διαδρομής:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Προσθήκη κυβικής καμπύλης Bezier** σε συγκεκριμένη θέση σε μια διαδρομή:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Προσθήκη τετραγωνικής καμπύλης Bezier** στο τέλος μιας διαδρομής:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Προσθήκη τετραγωνικής καμπύλης Bezier** σε συγκεκριμένη θέση σε μια διαδρομή:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Προσθήκη τόξου** σε μια διαδρομή:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Κλείσιμο του τρέχοντος σχήματος** σε μια διαδρομή:

```py
close_figure()
```

**Ορισμός θέσης για το επόμενο σημείο**:

```py
move_to(point)
move_to(x, y)
```

**Αφαίρεση τμήματος διαδρομής** σε δεδομένο δείκτη:

```py
remove_at(index)
```

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήματα**

Εδώ θα μάθετε πώς να ορίσετε ένα ελεύθερης μορφής σχήμα προσθέτοντας τη δική σας ακολουθία σημείων. Με τον καθορισμό διαδοχικών σημείων και τύπων τμημάτων (ευθύ ή κυρτό) και προαιρετικά κλείνοντας τη διαδρομή, μπορείτε να σχεδιάσετε ακριβή προσαρμοσμένα γραφικά—πολυγωνικά, εικονίδια, επισημάνσεις ή λογότυπα—απευθείας στις διαφάνειές σας.

1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/) και ορίστε το [ShapeType.RECTANGLE](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapetype/) .
2. Λάβετε μια παρουσία [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) από το σχήμα.
3. Εισάγετε ένα νέο σημείο μεταξύ των δύο άνω σημείων της διαδρομής.
4. Εισάγετε ένα νέο σημείο μεταξύ των δύο κάτω σημείων της διαδρομής.
5. Εφαρμόστε τη ενημερωμένη διαδρομή στο σχήμα.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Προσαρμοσμένα σημεία](custom_shape_1.png)

##  **Αφαίρεση Σημείων από Σχήματα**

Μερικές φορές ένα προσαρμοσμένο σχήμα περιέχει περιττά σημεία που δυσκολεύουν τη γεωμετρία του ή επηρεάζουν τον τρόπο απόδοσής του. Αυτή η ενότητα δείχνει πώς να αφαιρέσετε συγκεκριμένα σημεία από τη διαδρομή ενός σχήματος ώστε να απλοποιήσετε το περίγραμμα και να επιτύχετε καθαρότερα, πιο ακριβή αποτελέσματα.

1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/) και ορίστε τον τύπο [ShapeType.HEART](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapetype/) .
2. Λάβετε μια παρουσία [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) από το σ_shape.
3. Αφαιρέστε ένα τμήμα από τη διαδρομή.
4. Εφαρμόστε τη ενημερωμένη διαδρομή στο σ_shape.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Αφαιρεμένα σημεία](custom_shape_2.png)

##  **Δημιουργία Προσαρμοσμένων Σχημάτων**

Δημιουργήστε εξατομικευμένα διανυσματικά σχήματα ορίζοντας ένα [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) και συνθέτοντάς το από γραμμές, τόξα και καμπύλες Bézier. Αυτή η ενότητα δείχνει πώς να κατασκευάσετε μια προσαρμοσμένη γεωμετρία από το μηδέν και να προσθέσετε το αποτέλεσμα σχήμα στην διαφάνεια σας.

1. Υπολογίστε τα σημεία του σχήματος.
2. Δημιουργήστε μια παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) .
3. Συμπληρώστε τη διαδρομή με τα σημεία.
4. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/) .
5. Εφαρμόστε τη διαδρομή στο σ_shape.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Προσαρμοσμένο σχήμα](custom_shape_3.png)

## **Δημιουργία Σύνθετων Προσαρμοσμένων Σχημάτων**

Η δημιουργία ενός σύνθετου προσαρμοσμένου σχήματος σας επιτρέπει να συνδυάσετε πολλαπλές γεωμετρικές διαδρομές σε ένα ενιαίο, επαναχρησιμοποιήσιμο σ_shape σε μια διαφάνεια. Ορίστε και συγχωνεύστε αυτές τις διαδρομές για να κατασκευάσετε σύνθετες απεικονίσεις που υπερβαίνουν το τυπικό σύνολο σχημάτων.

1. Δημιουργήστε μια παρουσία της κλάσης [GeometryShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/) .
2. Δημιουργήστε την πρώτη παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) .
3. Δημιουργήστε τη δεύτερη παρουσία της κλάσης [GeometryPath](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometrypath/) .
4. Εφαρμόστε και τις δύο διαδρομές στο σ_shape.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Σύνθετο σχήμα](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένων Σχημάτων με Καμπυλωτές Γωνίες**

Αυτή η ενότητα δείχνει πώς να σχεδιάσετε ένα προσαρμοσμένο σχήμα με ομαλά καμπυλωτές γωνίες χρησιμοποιώντας μια γεωμετρική διαδρομή. Θα συνδυάσετε ευθύγραμμα τμήματα και κυκλικά τόξα για να σχηματίσετε το περίγραμμα και θα προσθέσετε το τελικό σχήμα στη διαφάνεια σας.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Καμπυλωτές γωνίες](custom_shape_6.png)

## **Καθορισμός Εάν Η Γεωμετρία Ένα Σχήματος Είναι Κλειστή**

Ένα κλειστό σχήμα ορίζεται ως εκείνο όπου όλες οι πλευρές του συνδέονται, σχηματίζοντας ένα ενιαίο σύνορο χωρίς κενά. Ένα τέτοιο σ_shape μπορεί να είναι μια απλή γεωμετρική μορφή ή ένα σύνθετο προσαρμοσμένο περίγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ελέγξετε αν η γεωμετρία ενός σ_shape είναι κλειστή:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **Συχνές Ερωτήσεις**

**Τι θα συμβεί στο γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σ_shape· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς μπορώ να περιστρέψω σωστά ένα προσαρμοσμένο σ_shape μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε την ιδιότητα [rotation](https://reference.aspose.com/slides/el/python-net/aspose.slides/geometryshape/rotation/) του σ_shape· η γεωμετρία περιστρέφεται μαζί με το σ_shape επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σ_shape σε εικόνα για να «κλειδώσω» το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή [slide](/slides/el/python-net/convert-powerpoint-to-png/) ή το [shape](/slides/el/python-net/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με πολύπλοκες γεωμετρίες.