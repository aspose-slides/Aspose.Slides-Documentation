---
title: Διαχείριση Συνδέσμων σε Παρουσιάσεις με Python
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/python-net/connector/
keywords:
- σύνδεσμος
- τύπος συνδέσμου
- σημείο συνδέσμου
- γραμμή συνδέσμου
- γωνία συνδέσμου
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ενδυναμώστε εφαρμογές Python για να σχεδιάζουν, συνδέουν και αυτόματα δρομολογούν γραμμές σε διαφάνειες PowerPoint & OpenDocument — αποκτήστε πλήρη έλεγχο πάνω σε ευθείες, αγκώνας και καμπυλωτούς συνδέσμους."
---
## **Εισαγωγή**

Ένας σύνδεσμος PowerPoint είναι μια εξειδικευμένη γραμμή που συνδέει δύο σχήματα και παραμένει συνδεδεμένη όταν τα σχήματα μετακινούνται ή επανατοποθετούνται σε μια διαφάνεια. Οι σύνδεσμοι συνδέονται σε **σημεία σύνδεσης** (πράσινα σημεία) στα σχήματα. Τα σημεία σύνδεσης εμφανίζονται όταν ο δείκτης πλησιάζει σε αυτά. **Χερούλια ρύθμισης** (κίτρινα σημεία), διαθέσιμα σε ορισμένους συνδέσμους, σας επιτρέπουν να τροποποιήσετε τη θέση και το σχήμα του συνδέσμου.

## **Τύποι Συνδέσμων**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε τρεις τύπους συνδέσμων: ευθεία, αγκώνας (γωνιακή) και καμπυλωτή.

Το Aspose.Slides υποστηρίζει τους ακόλουθους τύπους συνδέσμων:

| Τύπος Συνδέσμου                | Εικόνα                                                     | Αριθμός σημείων προσαρμογής |
| ------------------------------- | --------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`                | ![Σύνδεσμος Γραμμής](shapetype-lineconnector.png)            | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Σύνδεσμος Ευθύ 1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![Λυγμένος σύνδεσμος 2](shapetype-bent-connector2.png)        | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![Λυγμένος σύνδεσμος 3](shapetype-bentconnector3.png)         | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![Λυγμένος σύνδεσμος 4](shapetype-bentconnector4.png)         | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![Λυγμένος σύνδεσμος 5](shapetype-bentconnector5.png)         | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![Καμπυλωτός σύνδεσμος 2](shapetype-curvedconnector2.png)     | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![Καμπυλωτός σύνδεσμος 3](shapetype-curvedconnector3.png)     | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![Καμπυλωτός σύνδεσμος 4](shapetype-curvedconnector4.png)     | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![Καμπυλωτός σύνδεσμος 5](shapetype.curvedconnector5.png)     | 3                           |

## **Σύνδεση Σχημάτων με Συνδέσμους**

Αυτή η ενότητα δείχνει πώς να συνδέετε σχήματα με συνδέσμους στο Aspose.Slides. Θα προσθέσετε έναν σύνδεσμο σε μια διαφάνεια, προσαρμόζοντας την αρχή και το τέλος του σε στόχο σχήματα. Η χρήση σημείων σύνδεσης εξασφαλίζει ότι ο σύνδεσμος παραμένει «κολλημένος» στα σχήματα ακόμη και όταν μετακινούνται ή αλλάζουν μέγεθος.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη διαφάνεια με βάση το ευρετήριο της.
1. Προσθέστε δύο αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `add_auto_shape` που εκτίθενται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/).
1. Προσθέστε ένα σύνδεσμο χρησιμοποιώντας τη μέθοδο `add_connector` που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/) και καθορίστε τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα με τον σύνδεσμο.
1. Καλέστε τη μέθοδο `reroute` για να εφαρμόσετε τη συντομότερη διαδρομή σύνδεσης.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να προσθέσετε έναν λυγμένο σύνδεσμο μεταξύ δύο σχημάτων (μιας έλλειψης και ενός παραλληλόγραμμου):

```python
import aspose.slides as slides

    # Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για να δημιουργήσετε ένα αρχείο PPTX.
    with slides.Presentation() as presentation:

        # Προσπελάστε τη συλλογή σχημάτων της πρώτης διαφάνειας.
        shapes = presentation.slides[0].shapes

        # Προσθέστε ένα AutoShape έλλειψης.
        ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

        # Προσθέστε ένα AutoShape ορθογωνίου.
        rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

        # Προσθέστε έναν σύνδεσμο στη διαφάνεια.
        connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

        # Συνδέστε τα σχήματα με τον σύνδεσμο.
        connector.start_shape_connected_to = ellipse
        connector.end_shape_connected_to = rectangle

        # Κλήστε τη μέθοδο reroute για να ορίσετε τη συντομότερη διαδρομή.
        connector.reroute()

        # Αποθηκεύστε την παρουσίαση.
        presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Η μέθοδος `connector.reroute` επαναδρομολογεί έναν σύνδεσμο, αναγκάζοντάς τον να πάρει τη σύντομη δυνατή διαδρομή μεταξύ των σχημάτων. Για να γίνει αυτό, η μέθοδος μπορεί να αλλάξει τις τιμές `start_shape_connection_site_index` και `end_shape_connection_site_index`.
{{% /alert %}}

## **Καθορισμός Σημείων Σύνδεσης**

Αυτή η ενότητα εξηγεί πώς να προσαρτήσετε έναν σύνδεσμο σε ένα συγκεκριμένο σημείο σύνδεσης σε ένα σχήμα στο Aspose.Slides. Με την στόχευση ακριβών σημείων σύνδεσης, μπορείτε να ελέγξετε τη διαδρομή και τη διάταξη του συνδέσμου, δημιουργώντας καθαρά, προβλέψιμα διαγράμματα στις παρουσιάσεις σας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη διαφάνεια με βάση το ευρετήριο της.
1. Προσθέστε δύο αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια χρησιμοποιώντας τη μέθοδο `add_auto_shape` που εκτίθενται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/).
1. Προσθέστε ένα σύνδεσμο χρησιμοποιώντας τη μέθοδο `add_connector` που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/) και καθορίστε τον τύπο του συνδέσμου.
1. Συνδέστε τα σχήματα με τον σύνδεσμο.
1. Ορίστε τα προτιμώμενα σημεία σύνδεσης στα σχήματα.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να καθορίσετε ένα προτιμώμενο σημείο σύνδεσης:

```python
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για να δημιουργήσετε ένα αρχείο PPTX.
with slides.Presentation() as presentation:

    # Πρόσβαση στη συλλογή σχημάτων της πρώτης διαφάνειας.
    shapes = presentation.slides[0].shapes

    # Προσθήκη AutoShape έλλειψης.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Προσθήκη AutoShape ορθογωνίου.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Προσθήκη συνδέσμου στη συλλογή σχημάτων της διαφάνειας.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Σύνδεση των σχημάτων με τον σύνδεσμο.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Ορισμός του προτιμώμενου δείκτη σημείου σύνδεσης στην έλλειψη.
    site_index = 6

    # Έλεγχος εάν ο προτιμώμενος δείκτης βρίσκεται μέσα στον διαθέσιμο αριθμό σημείων.
    if  ellipse.connection_site_count > site_index:
        # Ανάθεση του προτιμώμενου σημείου σύνδεσης στην AutoShape έλλειψης.
        connector.start_shape_connection_site_index = site_index

    # Αποθήκευση της παρουσίασης.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσαρμογή Σημείων Συνδέσμου**

Μπορείτε να τροποποιήσετε συνδέσμους χρησιμοποιώντας τα σημεία προσαρμογής τους. Μόνο οι σύνδεσμοι που εκθέτουν σημεία προσαρμογής μπορούν να επεξεργαστούν με αυτόν τον τρόπο. Για λεπτομέρειες σχετικά με το ποιες συνδέσεις υποστηρίζουν προσαρμογές, δείτε τον πίνακα στην ενότητα [Connector Types](/slides/el/python-net/connector/#connector-types).

### **Απλή Περίπτωση**

Σκεφτείτε μια περίπτωση όπου ένας σύνδεσμος μεταξύ δύο σχημάτων (A και B) διασχίζει ένα τρίτο σχήμα (C):

![Παρεμπόδιση σύνδεσμου](connector-obstruction.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

Για να αποφύγετε το τρίτο σχήμα, προσαρμόστε τον σύνδεσμο μετακινώντας το κατακόρυφο τμήμα του προς τα αριστερά:

![Διορθωμένη παρεμπόδιση συνδέσμου](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Πολύπλοκες Περιπτώσεις** 

Για πιο προηγμένες προσαρμογές, εξετάστε τα παρακάτω:

- Το ρυθμιζόμενο σημείο ενός συνδέσμου διέπεται από έναν τύπο που καθορίζει τη θέση του. Η αλλαγή αυτού του σημείου μπορεί να αλλάξει το συνολικό σχήμα του συνδέσμου.
- Τα σημεία προσαρμογής ενός συνδέσμου αποθηκεύονται σε έναν αυστηρά διατεταγμένο πίνακα, αριθμημένο από την αρχή του συνδέσμου μέχρι το τέλος του.
- Οι τιμές των σημείων προσαρμογής αντιπροσωπεύουν ποσοστά του πλάτους/ύψους του σχήματος του συνδέσμου.
  - Το σχήμα ορίζεται από τα σημεία έναρξης και λήξης του συνδέσμου και κλιμακώνεται κατά 1000.
  - Τα πρώτο, δεύτερο και τρίτο σημεία προσαρμογής αντιπροσωπεύουν, αντίστοιχα: ποσοστό του πλάτους, ποσοστό του ύψους και ξανά ποσοστό του πλάτους.
- Κατά τον υπολογισμό των συντεταγμένων των σημείων προσαρμογής, λάβετε υπόψη την περιστροφή και την ανάκλαση του συνδέσμου. **Σημείωση:** Για όλους τους συνδέσμους που αναφέρονται στην ενότητα [Connector Types](/slides/el/python-net/connector/#connector-types), η γωνία περιστροφής είναι 0.

#### **Περίπτωση 1**

Σκεφτείτε μια περίπτωση όπου δύο αντικείμενα πλαισίου κειμένου συνδέονται με έναν σύνδεσμο:

![Συνδεδεμένα σχήματα](connector-shape-complex.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για να δημιουργήσετε ένα αρχείο PPTX.
with slides.Presentation() as presentation:

    # Αποκτήστε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Αποκτήστε την πρώτη διαφάνεια.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Προσθέστε έναν σύνδεσμο.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Ορίστε την κατεύθυνση του συνδέσμου.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Ορίστε το χρώμα του συνδέσμου.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Ορίστε το πάχος της γραμμής του συνδέσμου.
    connector.line_format.width = 3

    # Συνδέστε τα σχήματα με τον σύνδεσμο.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Λάβετε τα σημεία προσαρμογής του συνδέσμου.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Προσαρμογή**

Αλλάξτε τις τιμές των σημείων προσαρμογής του συνδέσμου αυξάνοντας το ποσοστό πλάτους κατά 20% και το ποσοστό ύψους κατά 200%, αντίστοιχα:

```python
    # Αλλάξτε τις τιμές των σημείων προσαρμογής.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Το αποτέλεσμα:

![Προσαρμογή συνδέσμου 1](connector-adjusted-1.png)

Για να ορίσετε ένα μοντέλο που μας επιτρέπει να προσδιορίσουμε τις συντεταγμένες και το σχήμα των τμημάτων του συνδέσμου, δημιουργήστε ένα σχήμα που αντιστοιχεί στο κάθετο στοιχείο του συνδέσμου στο `connector.adjustments[0]`:

```python
    # Σχεδιάστε το κάθετο στοιχείο του συνδέσμου.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Το αποτέλεσμα:

![Προσαρμογή συνδέσμου 2](connector-adjusted-2.png)

#### **Περίπτωση 2**

Στην **Περίπτωση 1**, δείξαμε μια απλή προσαρμογή συνδέσμου χρησιμοποιώντας βασικές αρχές. Σε τυπικές περιπτώσεις, πρέπει να λάβετε υπόψη την περιστροφή του συνδέσμου και τις ρυθμίσεις απεικόνισης του (ελεγχόμενες από τα `connector.rotation`, `connector.frame.flip_h` και `connector.frame.flip_v`). Ακολουθεί η διαδικασία.

Πρώτα, προσθέστε ένα νέο αντικείμενο πλαισίου κειμένου (**To 1**) στη διαφάνεια (για σύνδεση) και δημιουργήστε έναν νέο πράσινο σύνδεσμο που το συνδέει με τα υπάρχοντα αντικείμενα.

```python
    # Δημιουργήστε ένα νέο αντικείμενο προορισμού.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Δημιουργήστε έναν νέο σύνδεσμο.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Συνδέστε τα αντικείμενα χρησιμοποιώντας τον νεοδημιουργημένο σύνδεσμο.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Λάβετε τα σημεία προσαρμογής του συνδέσμου.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Αλλάξτε τις τιμές των σημείων προσαρμογής.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Το αποτέλεσμα:

![Προσαρμογή συνδέσμου 3](connector-adjusted-3.png)

Δεύτερον, δημιουργήστε ένα σχήμα που αντιστοιχεί στο **οριζόντιο** τμήμα του συνδέσμου που περνά από το νέο σημείο προσαρμογής του συνδέσμου, `connector.adjustments[0]`. Χρησιμοποιήστε τις τιμές από `connector.rotation`, `connector.frame.flip_h` και `connector.frame.flip_v`, και εφαρμόστε τον τυπικό τύπο μετατροπής συντεταγμένων για περιστροφή γύρω από δεδομένο σημείο `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Στην περίπτωση μας, η γωνία περιστροφής του αντικειμένου είναι 90 μοίρες και ο σύνδεσμος προβάλλεται κατακόρυφα, επομένως ο αντίστοιχος κώδικας είναι:

```python
    # Αποθηκεύστε τις συντεταγμένες του συνδέσμου.
    x = connector.x
    y = connector.y
    
    # Διορθώστε τις συντεταγμένες του συνδέσμου αν είναι αναστροφή.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Χρησιμοποιήστε την τιμή του σημείου προσαρμογής ως συντεταγμένη.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Μετατρέψτε τις συντεταγμένες επειδή sin(90°) = 1 και cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Καθορίστε το πλάτος του οριζόντιου τμήματος χρησιμοποιώντας τη δεύτερη τιμή σημείου προσαρμογής.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Το αποτέλεσμα:

![Προσαρμογή συνδέσμου 4](connector-adjusted-4.png)

Δείξαμε υπολογισμούς που περιλαμβάνουν απλές προσαρμογές και πιο σύνθετα σημεία προσαρμογής (αυτά που λαμβάνουν υπόψη την περιστροφή). Χρησιμοποιώντας αυτές τις γνώσεις, μπορείτε να δημιουργήσετε το δικό σας μοντέλο — ή να γράψετε κώδικα — για να αποκτήσετε ένα αντικείμενο `GraphicsPath` ή ακόμη και να ορίσετε τις τιμές των σημείων προσαρμογής ενός συνδέσμου βάσει συγκεκριμένων συντεταγμένων διαφάνειας.

## **Εύρεση Γωνιών Γραμμής Συνδέσμου**

Χρησιμοποιήστε το παρακάτω παράδειγμα για να καθορίσετε τη γωνία των γραμμών συνδέσμου σε μια διαφάνεια με το Aspose.Slides. Θα μάθετε πώς να διαβάζετε τα άκρα ενός συνδέσμου και να υπολογίζετε την προσανατολισμό του ώστε να ευθυγραμμίζετε με ακρίβεια βέλη, ετικέτες και άλλα σχήματα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη διαφάνεια με το ευρετήριο.
1. Προσεγγίστε το σχήμα γραμμής του συνδέσμου.
1. Χρησιμοποιήστε το πλάτος και το ύψος της γραμμής, καθώς και το πλάτος και το ύψος του πλαισίου του σχήματος, για να υπολογίσετε τη γωνία.

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξακριβώσω εάν ένας σύνδεσμος μπορεί να «κολληθεί» σε ένα συγκεκριμένο σχήμα;**

Ελέγξτε εάν το σχήμα εκθέτει [σημεία σύνδεσης](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/connection_site_count/). Αν δεν υπάρχουν ή ο αριθμός είναι μηδέν, η λειτουργία «κόλλησης» δεν είναι διαθέσιμη· σε αυτήν την περίπτωση, χρησιμοποιήστε ελεύθερα άκρα και τοποθετήστε τα χειροκίνητα. Είναι σύνετο να ελέγχετε τον αριθμό των σημείων πριν προσαρτήσετε.

**Τι συμβαίνει με έναν σύνδεσμο αν διαγράψω ένα από τα συνδεδεμένα σχήματα;**

Τα άκρα του θα αποσυνδεθούν· ο σύνδεσμος παραμένει στη διαφάνεια ως κανονική γραμμή με ελεύθερη αρχή/τέλος. Μπορείτε είτε να τον διαγράψετε είτε να επαναπροσαρμόσετε τις συνδέσεις και, εφόσον χρειάζεται, [reroute](https://reference.aspose.com/slides/el/python-net/aspose.slides/connector/reroute/).

**Διατηρούνται οι δεσμοί των συνδέσμων όταν αντιγράφεται μια διαφάνεια σε άλλη παρουσίαση;**

Γενικά ναι, εφόσον τα αντίστοιχα σχήματα αντιγραφούν επίσης. Αν η διαφάνεια εισαχθεί σε άλλο αρχείο χωρίς τα συνδεδεμένα σχήματα, τα άκρα γίνονται ελεύθερα και θα χρειαστεί να τα επανασυνδέσετε.