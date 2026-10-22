---
title: Προσαρμογή Σχημάτων Παρουσίασης σε Python
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
- σημεία επεξεργασίας
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- καμπυλωμένη γωνία
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω .NET: διαδρομές γεωμετρίας, καμπυλωμένες γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να δουλεύετε με [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε την ενημερωμένη γεωμετρία ξανά σε ένα σχήμα.

Δείχνει επίσης πώς να δημιουργήσετε προσαρμοσμένα και σύνθετα σχήματα, να χτίζετε σχήματα με καμπύλες γωνίες, να καθορίσετε εάν μια γεωμετρία σχήματος είναι κλειστή και να εξάγετε τα στοιχεία του σχήματος για ανάλυση περιγράμματος.

## **Αλλαγή Σχήματος με Χρήση Σημείων Επεξεργασίας**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε **Edit Points** για να τροποποιήσετε ένα τετράγωνο:

* Μετακινήστε μια γωνία προς το εσωτερικό ή το εξωτερικό.
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.
* Προσθέστε νέα σημεία.

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχημάτων**

![overview_image](custom_shape_0.png)

Κατά την επεξεργασία σχημάτων PowerPoint, κρατήστε αυτές τις έννοιες στο μυαλό:

* Ένα σχήμα (ή η διαδρομή του) μπορεί να είναι κλειστό ή ανοικτό.
* Η διαδρομή ενός σχήματος αποτελείται από άγκυρα σημεία συνδεδεμένα με τμήματα.
* Ένα τμήμα μπορεί να είναι ευθύ ή καμπυλωτό. Τα άγκυρα σημεία και τα χειριστήρια ελέγχου καθορίζουν το σχήμα του.
* Τα άγκυρα σημεία υπάρχουν ως γωνιακά σημεία, ευθύγραμμα σημεία ή λείες (smooth) σημεία:
  * Σε ένα γωνιακό σημείο, τα γειτονικά τμήματα μπορούν να συναντηθούν με γωνία.
  * Σε ένα λείο σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα και εξίσου απομακρυμένα από το άγκυρα σημείο.
  * Σε ένα ευθύγραμμο σημείο, τα δύο χειριστήρια ελέγχου είναι ευθυγραμμισμένα αλλά μπορούν να έχουν διαφορετικές αποστάσεις από το άγκυρα σημείο.
* Η μετακίνηση των άγκυρα σημείων ή η ρύθμιση των χειριστηρίων τους αλλάζει το περίγραμμα του σχήματος.

Για να επεξεργαστείτε σχήματα PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Μια παρουσία της [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Για να ανακτήσετε το [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) από την παρουσία του [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε τις μεθόδους: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) για σχήματα με μία μόνο διαδρομή και [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) για σχήματα με πολλαπλές διαδρομές.
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους κάτω από την [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Χρησιμοποιώντας τις ιδιότητες [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) και [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), μπορείτε να ορίσετε την εμφάνιση μιας γεωμετρικής διαδρομής.
* Χρησιμοποιώντας την ιδιότητα [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/), μπορείτε να ανακτήσετε τη γεωμετρική διαδρομή ενός [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων διαδρομής.

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε μια γεωμετρική διαδρομή. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη θέση αυτή (μηδενική βασική) στον πίνακα τμημάτων της διαδρομής.

| Λειτουργία | Μέθοδος |
| --- | --- |
| Προσθήκη ή εισαγωγή ευθείας γραμμής. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Προσθήκη ή εισαγωγή καμπύλης κυβικού Bézier με δύο σημεία ελέγχου και σημείο λήξης. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Προσθήκη ή εισαγωγή τετραγωνικής Bézier καμπύλης με ένα σημείο ελέγχου και σημείο λήξης. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Προσθήκη ελλειπτικού τόξου με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το σημείο λήξης του με το αρχικό του σημείο. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Ορισμός του αρχικού σημείου ενός σχήματος. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Αφαίρεση τμήματος σε δείκτη μηδενικής βάσης. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας τη [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) και εφαρμόζει τη επεξεργασμένη διαδρομή με τη [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 μονάδες από την αριστερά και 50 μονάδες από την κορυφή. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στα άνω και κάτω άκρα, τραβώντας αυτά τα άκρα προς το κέντρο.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

Αυτό το παράδειγμα αλλάζει το περίγραμμα σχήματος σε σχήμα καρδιάς αφαιρώντας το τμήμα στο μηδενικό δείκτη 2 με τη [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Η εφαρμογή της τροποποιημένης διαδρομής με τη [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ενημερώνει το περίγραμμα του σχήματος.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα δημιουργεί ένα πεντάκτυρο αστέρι με τη [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες 100 και 50 μονάδες ορίζουν τις άκρες και τις εσοχές· ένα βήμα 72 μοιρών τοποθετεί ομοιόμορφα τις πέντε άκρες. Η διαδρομή κλείνει με τη [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/), και εφαρμόζεται σε ένα ορθογώνιο σχήμα χρησιμοποιώντας τη [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), αντικαθιστώντας το περίγραμμά του.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα ορίζει δύο κλειστά αντικείμενα [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) για το πάνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο διαδρομών με τη [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) δημιουργεί ένα ενιαίο σύνθετο σχήμα με ένα κενό στο μεσαίο τρίτο.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος με Καμπύλες Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθύγραμμα τμήματα με τη [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) για να δημιουργήσει ένα σχήμα με εσωτερικές καμπύλες γωνίες. Κάθε μέγεθος γωνίας ορίζει το πλάτος και το ύψος του τόξου σε μονάδες, και η περιστροφή -90 μοίρες σχεδιάζει ένα τέταρτο ελλειπτικό τόξο αριστερόστροφα. Η ολοκληρωμένη διαδρομή εφαρμόζεται με τη [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

```python
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

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Εύρεση Εάν η Γεωμετρία Σχήματος Είναι Κλειστή**

Ο παρακάτω βοηθός ελέγχει αν κάθε μη κενή γεωμετρική διαδρομή τελειώνει με τμήμα κλεισίματος. Διαβάζει τη [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) και συγκρίνει την εντολή του τελευταίου τμήματος [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) με το [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενές διαδρομές. Αυτό ελέγχει την τελική εντολή κάθε διαδρομής· δεν εξετάζει κάθε υποσχήμα μέσα στη διαδρομή. Το παράδειγμα εκτυπώνει `True` για ένα ορθογώνιο.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σχήματος**

Χρησιμοποιήστε τη [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) για να επιθεωρήσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία διαδρομής και τύπους σημείων. Κάθε επιστρεφόμενο [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) εκθέτει τους πίνακες [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) και [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγράμματος ή για μεταφορά γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο γεωμετρικό σχήμα απευθείας στην πρώτη διαφάνεια και εκτυπώνει τα τμήματα της διαδρομής του. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχήμα με ευθύ και καμπυλωτά τμήματα για να δείτε και τις δύο μορφές εξόδου. Δεν ψάχνει μέσα σε ομάδες.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
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

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει το ρόλο του. Ο τύπος `0` ξεκινά ένα σχήμα, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον σημείο. Ένα τμήμα κυβικού Bézier ξεκινά από το προηγούμενο σημείο λήξης και χρησιμοποιεί τρία διαδοχικά στοιχεία τύπου `3`: δύο σημεία ελέγχου ακολουθούμενα από το νέο σημείο λήξης. Η επανάληψη καταναλώνει αυτά τα τρία στοιχεία μαζί και ελέγχει το σημείο λήξης για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Χρησιμοποιήστε μάσκα `0x07` για να προσδιορίσετε τον τύπο τμήματος και ελέγξτε `0x80` ξεχωριστά για να εντοπίσετε κλειστό υπο‑σπάσιμο. Για παράδειγμα, `129` (`0x81`) σημαίνει ένα άκρο γραμμής που κλείνει ένα υπο‑σπάσιμο, και `131` (`0x83`) σημαίνει άκρο Bézier που κλείσει ένα. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετρούνται σε μονάδες (1/72 ίντσα), με το X να αυξάνεται προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση του [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) και [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) και αντανακλούν το τρέχον πλάτος και ύψος του. Για παράδειγμα, ένα μη περιστρεφθέν ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέσετε ξανά τη θέση του σχήματος. Αφαιρέστε τα X και Y του για να αποκτήσετε συντεταγμένες σχετικά με το μη περιστραμμένο πλαίσιο του.

Τα εξαγόμενα σημεία δεν εφαρμόζουν τη [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) ή τις οριζόντιες και κατακόρυφες αναστροφές του σχήματος. Για να αναπαράγετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτούς τους μετασχηματισμούς γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων της ομάδας και τους μετασχηματισμούς· μην υποθέσετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόστε διπλή μετάφραση ή κλιμάκωση αν ήδη αντανακλώνται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.** Οι εξαγόμενοι πίνακες περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτή την προσέγγιση όταν η ανάλυση ή ο κώδικας σχεδίασής σας χρειάζονται πίνακες σημείο/τύπος. Χρησιμοποιήστε το [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τις επεξεργασμένες διαδρομές μέσω του [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ή του [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **Συχνές Ερωτήσεις**

**Τι θα συμβεί στο γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε την ιδιότητα [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να “κλειδώσω” το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή [διαφάνεια](/slides/el/python-net/convert-powerpoint-to-png/) ή το ίδιο το [σχήμα](/slides/el/python-net/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί την περαιτέρω εργασία με σύνθετες γεωμετρίες.