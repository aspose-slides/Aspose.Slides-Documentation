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
- επεξεργασία σημείων
- προσθήκη σημείου
- αφαίρεση σημείου
- λειτουργία επεξεργασίας
- κυρτή γωνία
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε σχήματα σε παρουσιάσεις PowerPoint με Aspose.Slides για Python μέσω .NET: διαδρομές γεωμετρίας, κυρτές γωνίες, σύνθετα σχήματα."
---
## **Επισκόπηση**

Το άρθρο αυτό εξηγεί πώς να προσαρμόζετε τα σχήματα παρουσίασης στο Aspose.Slides επεξεργάζοντας τη γεωμετρία του σχήματος μέσω σημείων επεξεργασίας και διαδρομών γεωμετρίας. Δείχνει πώς να εργάζεστε με [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) για να τροποποιήσετε υπάρχοντα σχήματα, να εκτελέσετε βασικές λειτουργίες επεξεργασίας διαδρομής, να προσθέσετε ή να αφαιρέσετε σημεία και να εφαρμόσετε ενημερωμένη γεωμετρία σε ένα σχήμα.

Επίσης, παρουσιάζει πώς να δημιουργείτε προσαρμοσμένα και σύνθετα σχήματα, να κατασκευάσετε σχήματα με κυρτές γωνίες, να καθορίσετε εάν μια γεωμετρία σχήματος είναι κλειστή και να εξάγετε στοιχεία σχήματος για ανάλυση περιγράμματος.

## **Αλλαγή Σχήματος Χρησιμοποιώντας Σημεία Επεξεργασίας**

* Μετακινήστε μια γωνία προς τα μέσα ή προς τα έξω.  
* Ρυθμίστε την καμπυλότητα σε ένα σημείο.  
* Προσθέστε νέα σημεία.  

Η επεξεργασία σημείων σας επιτρέπει να τροποποιήσετε το περίγραμμα ενός σχήματος ή να χρησιμοποιήσετε ένα υπάρχον σχήμα ως βάση για ένα νέο.

## **Συμβουλές Επεξεργασίας Σχημάτων**

![εικόνα_επισκόπησης](custom_shape_0.png)

Κατά την επεξεργασία σχημάτων PowerPoint, κρατήστε αυτές τις έννοιες στο μυαλό:

* Ένα σχήμα (ή η διαδρομή του) μπορεί είτε να είναι κλειστό είτε ανοιχτό.  
* Η διαδρομή ενός σχήματος αποτελείται από αγγυρωμένα σημεία συνδεδεμένα με τμήματα.  
* Ένα τμήμα μπορεί να είναι ευθύ ή κυρτό. Τα αγγυρωμένα σημεία και οι λαβές ελέγχου καθορίζουν το σχήμα του.  
* Τα αγγυρωμένα σημεία εμφανίζονται ως σημεία γωνίας, ευθύ σημεία ή λείο σημεία:  
  * Σε σημείο γωνίας, τα παρακείμενα τμήματα μπορούν να συναντιούνται με γωνία.  
  * Σε λείο σημείο, οι δύο λαβές ελέγχου είναι ευθυγραμμισμένες και εξίσου απομακρυσμένες από το αγγυρωμένο σημείο.  
  * Σε ευθύ σημείο, οι δύο λαβές ελέγχου είναι ευθυγραμμισμένες αλλά μπορεί να έχουν διαφορετικές αποστάσεις από το αγγυρωμένο σημείο.  
* Η μετακίνηση των αγγυρωμένων σημείων ή η ρύθμιση των λαβών τους αλλάζει το περίγραμμα του σχήματος.  

Για να επεξεργαστείτε σχήματα PowerPoint μέσω σημείων επεξεργασίας, το **Aspose.Slides** παρέχει την κλάση [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Μια παρουσίαση [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) αντιπροσωπεύει μια διαδρομή γεωμετρίας του αντικειμένου [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).  
* Για να λάβετε το [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) από την παρουσίαση [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), μπορείτε να χρησιμοποιήσετε τη μέθοδο [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).  
* Για να ορίσετε το [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) για ένα σχήμα, μπορείτε να χρησιμοποιήσετε τις μεθόδους: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) για σχήματα με μία διαδρομή και [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) για σχήματα με πολλαπλές διαδρομές.  
* Για να προσθέσετε τμήματα, μπορείτε να χρησιμοποιήσετε τις μεθόδους κάτω από το [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).  
* Χρησιμοποιώντας τις ιδιότητες [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) και [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), μπορείτε να ορίσετε την εμφάνιση μιας διαδρομής γεωμετρίας.  
* Χρησιμοποιώντας την ιδιότητα [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/), μπορείτε να λάβετε τη διαδρομή γεωμετρίας ενός [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) ως έναν πίνακα τμημάτων διαδρομής.

## **Απλές Λειτουργίες Επεξεργασίας**

Χρησιμοποιήστε τις παρακάτω μεθόδους για να επεξεργαστείτε μια διαδρομή γεωμετρίας. Οι υπερφορτώσεις που δέχονται δείκτη εισάγουν ένα τμήμα στη θέση μηδενικής βάσης στον πίνακα τμημάτων της διαδρομής.

| Operation | Method |
| --- | --- |
| Προσθήκη ή εισαγωγή ευθύγραμμης γραμμής. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Προσθήκη ή εισαγωγή κυβικού καμπύλης Bézier με δύο σημεία ελέγχου και ένα τελικό σημείο. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Προσθήκη ή εισαγωγή τετραγωνικής καμπύλης Bézier με ένα σημείο ελέγχου και ένα τελικό σημείο. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Προσθήκη ενός ελλειπτικού τόξου με τις καθορισμένες διαστάσεις και γωνίες σε μοίρες. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Κλείσιμο του τρέχοντος σχήματος συνδέοντας το τελικό του σημείο με το αρχικό. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Ορισμός του αρχικού σημείου ενός σχήματος. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Αφαίρεση τμήματος σε δείκτη μηδενικής βάσης. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Προσθήκη Προσαρμοσμένων Σημείων σε Σχήμα**

Αυτό το παράδειγμα εισάγει δύο σημεία σε ένα ορθογώνιο σχήμα χρησιμοποιώντας [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) και εφαρμόζει τη διορθωμένη διαδρομή με [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Οι συντεταγμένες είναι τοπικές στο σχήμα: και τα δύο νέα σημεία βρίσκονται στο κέντρο του, 100 μονάδες από τα αριστερά και 50 μονάδες από την κορυφή. Οι δείκτες τμημάτων 1 και 4 τα τοποθετούν στα άνω και κάτω άκρα, τραβώντας αυτά τα άκρα προς το εσωτερικό.

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

![παράδειγμα1_εικόνα](custom_shape_1.png)

## **Αφαίρεση Σημείων από Σχήμα**

Αυτό το παράδειγμα αλλάζει το περίγραμμα ενός σχήματος καρδιάς αφαιρώντας το τμήμα στον δείκτη μηδενικής βάσης 2 με [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Η εφαρμογή της τροποποιημένης διαδρομής με [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ενημερώνει το περίγραμμα του σχήματος.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```

![παράδειγμα2_εικόνα](custom_shape_2.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα κατασκευάζει ένα πεντάκτινο αστέρι με [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Εναλλασσόμενες εξωτερικές και εσωτερικές ακτίνες των 100 και 50 μονάδων ορίζουν τις άκρες και τις εσοχές· ένα βήμα 72 μοιρών διαχωρίζει τις πέντε άκρες ομοιόμορφα. Η διαδρομή κλείνει με [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) και εφαρμόζεται σε ένα ορθογώνιο σχήμα χρησιμοποιώντας [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), αντικαθιστώντας το περίγραμμα του.

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

![παράδειγμα3_εικόνα](custom_shape_3.png)

## **Δημιουργία Σύνθετου Προσαρμοσμένου Σχήματος**

Αυτό το παράδειγμα ορίζει δύο κλειστές [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) για το άνω και το κάτω τρίτο ενός σχήματος. Η εφαρμογή και των δύο διαδρομών με [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) δημιουργεί ένα ενιαίο σύνθετο σχήμα με ένα κενό στο μεσαίο τρίτο.

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

![παράδειγμα4_εικόνα](custom_shape_4.png)

## **Δημιουργία Προσαρμοσμένου Σχήματος με Κυρτές Γωνίες**

Αυτό το παράδειγμα συνδυάζει ευθείες ενότητες με [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) για να δημιουργήσει ένα σχήμα με εσωτερικές κυρτές γωνίες. Κάθε μέγεθος γωνίας καθορίζει το πλάτος και το ύψος του τόξου σε μονάδες, και το σβέλμα -90 μοιρών σχεδιάζει ένα αντίστροφα ρολόι τεταρτοελλειπτικό τόξο. Η ολοκληρωμένη διαδρομή εφαρμόζεται με [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), και η παρουσίαση αποθηκεύεται σε μορφή PPTX.

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

Η παρακάτω βοηθητική μέθοδος ελέγχει εάν κάθε μη κενή διαδρομή γεωμετρίας τελειώνει με κλειστό τμήμα. Διαβάζει [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) και συγκρίνει την τελική εντολή του τμήματος [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) με [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Επιστρέφει false όταν δεν υπάρχουν μη κενές διαδρομές. Αυτό ελέγχει την τελική εντολή κάθε διαδρομής· δεν επιθεωρεί κάθε υποσχήμα μέσα σε μια διαδρομή. Το παράδειγμα εκτυπώνει `True` για ένα ορθογώνιο.

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

## **Επιθεώρηση Εντολών Διαδρομής Γεωμετρίας**

Κατεβάστε [contour.pptx](contour.pptx) και τοποθετήστε το στον κατάλογο εργασίας σας. Το πρώτο σχήμα στη πρώτη διαφάνεια έχει ευθύ άνω άκρο, μια κυβική Bézier καμπύλη και ένα ευθύ κλειστό άκρο. Χρησιμοποιήστε [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) για να διαβάσετε τις διαδρομές του. Για κάθε διαδρομή, [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) καταγράφει τα τμήματα με τη σειρά σχεδίασης. Η εντολή κάθε τμήματος [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) καθορίζει πώς να ερμηνευτεί το [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/).

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

Το σχήμα βρίσκεται στο (200, 100) μονάδες στη διαφάνεια. Οι αναφερόμενες συντεταγμένες είναι τοπικές στο σχήμα. Η πάνω‑αριστερή γωνία του είναι (0, 0), το x αυξάνεται προς τα δεξιά και το y αυξάνεται προς τα κάτω. Το κλειστικό τμήμα επιστρέφει στο αρχικό σημείο χωρίς πρόσθετες συντεταγμένες.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![Σχήμα PowerPoint με ευθύ άνω άκρο, κυρτό άκρο από την επάνω δεξιά προς την κάτω αριστερή, και ευθύ αριστερό άκρο](contour.png)

## **Εξαγωγή και Επιθεώρηση Στοιχείων Σχήματος**

Χρησιμοποιήστε [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) για να επιθεωρήσετε ένα υπάρχον σχήμα ως στοιχεία που περιέχουν σημεία διαδρομής και τύπους σημείων. Κάθε επιστρεφόμενο [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) εκθέτει τους πίνακες [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) και [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Αυτή η αναπαράσταση είναι χρήσιμη για ανάλυση περιγράμματος ή για μεταφορά γεωμετρίας σε προσαρμοσμένα εργαλεία σχεδίασης.

Το παράδειγμα ανοίγει μια παρουσίαση, βρίσκει το πρώτο σχήμα γεωμετρίας απευθείας στη πρώτη διαφάνεια και εκτυπώνει τα τμήματα της διαδρομής του. Χρησιμοποιήστε μια παρουσίαση που περιέχει ένα σχήμα με ευθείες και κυρτές ενότητες για να δείτε και τις δύο μορφές εξόδου. Δεν γίνεται αναζήτηση μέσα σε ομάδες.

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
                point_type = types[i] & 0x07  # Διατηρήστε τον τύπο τμήματος, εξαιρώντας τις σημαίες.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Κατανάλωση και των δύο σημείων ελέγχου και του τελικού σημείου.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Οι πίνακες αντιστοιχούν κατά δείκτη: `points[i]` είναι ένα σημείο και `types[i]` περιγράφει τον ρόλο του. Ο τύπος `0` ξεκινά ένα σχήμα, και ο τύπος `1` σχεδιάζει μια γραμμή από το προηγούμενο σημείο στο τρέχον. Ένα τμήμα κυβικής Bézier ξεκινά από το προηγούμενο τελικό σημείο και χρησιμοποιεί τρεις διαδοχικές καταχωρήσεις τύπου `3`: δύο σημεία ελέγχου και το νέο τελικό σημείο. Η επανάληψη καταναλώνει αυτά τα τρία στοιχεία μαζί και ελέγχει το τελικό σημείο για κλείσιμο.

Οι τύποι σημείων περιέχουν επίσης σημαίες. Μάσκα με `0x07` για να προσδιορίσετε τον τύπο τμήματος, και ελέγξτε `0x80` ξεχωριστά για να εντοπίσετε μια κλειστή υποδιαδρομή. Για παράδειγμα, `129` (`0x81`) σημαίνει ένα τελικό σημείο γραμμής που κλείνει μια υποδιαδρομή, και `131` (`0x83`) σημαίνει ένα τελικό σημείο Bézier που κλείνει μια. Η σύγκριση της ακατέργαστης τιμής μόνο με `1` ή `3` θα χάσει αυτές τις περιπτώσεις. Άλλες σημαίες, όπως η παύλα (`0x10`) και ο δείκτης (`0x20`), δεν αλλάζουν τον βασικό τύπο τμήματος.

**Συντεταγμένες και μετασχηματισμοί.** Τα σημεία μετριούνται σε μονάδες (1/72 ίντσας), με το X να αυξάνεται προς τα δεξιά και το Y προς τα κάτω. Για ένα μη ομαδοποιημένο σχήμα, οι εξαγόμενες συντεταγμένες περιλαμβάνουν ήδη τη θέση του [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) και του [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) και αντανακλούν το τρέχον πλάτος και ύψος. Για παράδειγμα, ένα μη περιστραμμένο ορθογώνιο στο `(100, 200)` με μέγεθος `120 × 80` έχει όρια περιγράμματος `(100, 200)`–`(220, 280)`. Μην προσθέτετε ξανά τη θέση του σχήματος. Αφαιρέστε τα X και Y για να λάβετε συντεταγμένες σχετικές με το μη περιστραμμένο πλαίσιο.

Οι εξαγόμενες σημεία δεν εφαρμόζουν την [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) του σχήματος ή τις οριζόντιες και κατακόρυφες αναστροφές. Για να επαναδημιουργήσετε το εμφανιζόμενο περίγραμμα, εφαρμόστε αυτούς τους μετασχηματισμούς γύρω από το κέντρο του σχήματος. Για ομαδοποιημένα σχήματα, λάβετε επίσης υπόψη τη χαρτογράφηση συντεταγμένων της ομάδας και τους μετασχηματισμούς· μην υποθέτετε ότι τα εξαγόμενα σημεία είναι οι τελικές συντεταγμένες της διαφάνειας ή εφαρμόστε διπλή μετάφραση ή κλίμακα εάν ήδη αντανακλώνται στο πλαίσιο του παιδιού.

**Επιθεώρηση έναντι επεξεργασίας.** Τα εξαγόμενα arrays περιγράφουν το περίγραμμα· η αλλαγή τους δεν ενημερώνει το αρχικό σχήμα. Επιλέξτε αυτήν την προσέγγιση όταν η ανάλυση ή ο κώδικας σχεδίασης χρειάζονται πίνακες σημείου/τύπου. Χρησιμοποιήστε [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) όταν χρειάζεστε εντολές γεωμετρίας στο τοπικό σύστημα συντεταγμένων του σχήματος ή θέλετε να επεξεργαστείτε τη γεωμετρία του. Εφαρμόστε τις επεξεργασμένες διαδρομές μέσω [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ή [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Τι θα συμβεί στο γέμισμα και το περίγραμμα μετά την αντικατάσταση της γεωμετρίας;**

Το στυλ παραμένει στο σχήμα· μόνο το περίγραμμα αλλάζει. Το γέμισμα και το περίγραμμα εφαρμόζονται αυτόματα στη νέα γεωμετρία.

**Πώς να περιστρέψω σωστά ένα προσαρμοσμένο σχήμα μαζί με τη γεωμετρία του;**

Χρησιμοποιήστε την ιδιότητα [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) του σχήματος· η γεωμετρία περιστρέφεται μαζί με το σχήμα επειδή είναι δεσμευμένη στο δικό του σύστημα συντεταγμένων.

**Μπορώ να μετατρέψω ένα προσαρμοσμένο σχήμα σε εικόνα για να "κλειδώσω" το αποτέλεσμα;**

Ναι. Εξάγετε την απαιτούμενη περιοχή του [slide](/slides/el/python-net/convert-powerpoint-to-png/) ή το ίδιο το [shape](/slides/el/python-net/create-shape-thumbnails/) σε μορφή raster· αυτό απλοποιεί τη μετέπειτα εργασία με σύνθετες γεωμετρίες.