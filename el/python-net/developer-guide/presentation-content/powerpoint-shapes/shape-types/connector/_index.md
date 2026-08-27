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
- σημείο σύνδεσης
- σημείο ρύθμισης
- σύνδεση σχημάτων
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να συνδέετε, να αλλάζετε διαδρομή, να ρυθμίζετε και να εξετάζετε ευθείες, λυγισμένες και κυρτές συνδέσεις PowerPoint με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Ένας σύνδεσμος είναι μια γραμμή που μπορεί να παραμείνει συνδεδεμένη σε δύο σχήματα όταν μετακινηθεί οποιοδήποτε από τα σχήματα. Τα άκρα του συνδέονται σε σημεία σύνδεσης, που αντιστοιχούν σε πράσινα σημεία στο PowerPoint. Ορισμένοι λυγισμένοι και καμπυλωτοί σύνδεσμοι εκθέτουν επίσης σημεία ρύθμισης, που απεικονίζονται με πορτοκαλί σημεία, και ελέγχουν τη θέση των μεμονωμένων τμημάτων του συνδέσμου.

Aspose.Slides αναπαριστά τους συνδέσμους μέσω της διεπαφής [IConnector](https://reference.aspose.com/slides/el/python-net/aspose.slides/iconnector/). Μπορείτε να τους δημιουργήσετε, να συνδέσετε τα άκρα τους με σχήματα, να επιλέξετε σημεία σύνδεσης, να αλλάξετε τη διαδρομή τους και να τροποποιήσετε τη γεωμετρία των συνδέσμων που διαθέτουν σημεία ρύθμισης.

## **Τύποι Συνδέσμων**

Η απαρίθμηση [ShapeType](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapetype/) περιλαμβάνει έτοιμες ρυθμίσεις για ευθείες, λυγισμένες και καμπυλωτές συνδέσεις. Ο παρακάτω πίνακας εμφανίζει τις διαθέσιμες γεωμετρίες συνδέσμων και τον αριθμό των σημείων ρύθμισης που ορίζονται για κάθε προεπιλογή.

| Connector | Image | Number of adjustment points |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Ο αριθμός και η σημασία των σημείων ρύθμισης αποτελούν μέρος της επιλεγμένης προεπιλογής συνδέσμου. Μην υποθέτετε ότι δύο διαφορετικοί τύποι συνδέσμων εκθέτουν την ίδια διάταξη συλλογής.

## **Σύνδεση Δύο Σχημάτων**

Χρησιμοποιήστε τη μέθοδο [IShapeCollection.add_connector](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishapecollection/add_connector/) για να προσθέσετε ένα σύνδεσμο και ορίστε τις ιδιότητες [start_shape_connected_to](https://reference.aspose.com/slides/el/python-net/aspose.slides/iconnector/start_shape_connected_to/) και [end_shape_connected_to](https://reference.aspose.com/slides/el/python-net/aspose.slides/iconnector/end_shape_connected_to/). Αφού συνδεθούν και τα δύο άκρα, η μέθοδος [IConnector.reroute](https://reference.aspose.com/slides/el/python-net/aspose.slides/iconnector/reroute/) επιλέγει τη σύντομη διαδρομή μεταξύ των σχημάτων.

Το παρακάτω παράδειγμα συνδέει μια έλλειψη και ένα ορθογώνιο με ένα λυγισμένο σύνδεσμο:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
Η κλήση του `reroute` μπορεί να αλλάξει τις τιμές [start_shape_connection_site_index](https://reference.aspose.com/slides/el/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) και [end_shape_connection_site_index](https://reference.aspose.com/slides/el/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). Ανάθετε συγκεκριμένα σημεία σύνδεσης μετά την αλλαγή διαδρομής εφόσον πρέπει να παραμείνουν σταθερά.

{{% /alert %}}

## **Επιλογή Σημείου Σύνδεσης**

Κάθε σχήμα που μπορεί να συνδεθεί αναφέρει τον αριθμό των σημείων του μέσω του [connection_site_count](https://reference.aspose.com/slides/el/python-net/aspose.slides/igeometryshape/connection_site_count/). Επικυρώστε έναν προτιμώμενο δείκτη σημείου (μηδενικής βάσης) πριν τον ορίσετε σε άκρο συνδέσμου· οι μετρήσεις διαφέρουν ανάλογα με τη γεωμετρία του σχήματος.

Το παράδειγμα αυτό συνδέει το σύνδεσμο με ένα συγκεκριμένο σημείο στην έλλειψη όταν αυτό το σημείο υπάρχει:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Ρύθμιση Σημείου Σύνδεσμου**

Οι σύνδεσμοι με σημεία ρύθμισης τα εκθέτουν μέσω του [IGeometryShape.adjustments](https://reference.aspose.com/slides/el/python-net/aspose.slides/igeometryshape/adjustments/). Εξετάστε κάθε [IAdjustValue](https://reference.aspose.com/slides/el/python-net/aspose.slides/iadjustvalue/) και ελέγξτε τον [type](https://reference.aspose.com/slides/el/python-net/aspose.slides/iadjustvalue/type/) πριν αλλάξετε την [raw_value](https://reference.aspose.com/slides/el/python-net/aspose.slides/iadjustvalue/raw_value/). Για γενική επεξεργασία σχημάτων, δείτε την ενότητα [Shape Manipulation](/slides/el/python-net/shape-manipulations/).

Ο αριθμός, η σειρά, η σημασία και το έγκυρο εύρος τιμών των ρυθμίσεων συνδέσμου εξαρτώνται από την προεπιλογή. Η ιδιότητα `type` είναι μόνο για ανάγνωση, ενώ η τιμή ρύθμισης είναι εγγράφουσιμη. Η μόνο‑ανά‑ανάγνωση ιδιότητα [name](https://reference.aspose.com/slides/el/python-net/aspose.slides/iadjustvalue/name/) παρέχει επιπλέον ταυτοποίηση όταν ένας σύνδεσμος περιέχει περισσότερες από μία ρυθμίσεις του ίδιου σημασιολογικού τύπου.

### **Διαδρομή Περιμέσου Εμπόδου**

Στη παρακάτω διάταξη, ένας σύνδεσμος `ShapeType.BENT_CONNECTOR5` μεταξύ δύο σχημάτων περνάει από τρίτο σχήμα:

![connector-obstruction](connector-obstruction.png)

Αυτός ο κώδικας δημιουργεί τον φραγμένο σύνδεσμο:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

Η μετακίνηση του κάθετου λοξόματος αλλάζει τη διαδρομή ώστε ο σύνδεσμος να παρακάμπτει το εμπόδιο:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Αντί να υποθέτετε ότι ο δείκτης της συλλογής `1` αντιπροσωπεύει πάντα το κάθετο λοξόγραμμα, αυτό το παράδειγμα αναζητά το `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` και το αλλάζει μόνο όταν υπάρχει ο αναμενόμενος σημασιολογικός τύπος:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

Ένας `ShapeType.BENT_CONNECTOR5` έχει δύο ρυθμίσεις `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` και μία ρύθμιση `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. Εάν ο τύπος που χρειάζεστε εμφανίζεται περισσότερες από μία φορές, εξετάστε το `name` και τη γνωστή γεωμετρία της προεπιλογής πριν επιλέξετε. Εάν μια ρύθμιση επιστρέφει [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapeadjustmenttype/), θεωρήστε τη σημασία και το εύρος της ως ειδικά για την προεπιλογή και μην την αλλάξετε μέχρι να γνωρίζετε το συμβόλαιο.

## **Συσχέτιση Τιμών Ρύθμισης με Γεωμετρία Συνδέσμου**

Για λυγισμένους συνδέσμους, οι τιμές ρύθμισης μπορούν να χρησιμοποιηθούν για εκτίμηση των θέσεων των μεμονωμένων τμημάτων. Οι υπολογισμοί αυτοί είναι ειδικοί για την προεπιλογή του συνδέσμου:

- Το `ShapeType.BENT_CONNECTOR4` συνήθως εκθέτει μία ρύθμιση `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` και μία `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`.
- Για αυτές τις θέσεις λοξογράμματος, η έκφραση `raw_value / 100000` δίνει το κλάσμα του πλάτους ή του ύψους του πλαισίου του συνδέσμου που χρησιμοποιείται στα παραδείγματα.
- Ένα πλαίσιο συνδέσμου μπορεί να περιστραφεί ή να αναστραφεί, επομένως οι συντεταγμένες του πλαισίου πρέπει να μετασχηματιστούν πριν συγκριθούν με τις συντεταγμένες της διαφάνειας.

Τα παρακάτω παραδείγματα χρησιμοποιούν το `type` για την αρχική αναγνώριση των ρυθμίσεων. Δεν αντιμετωπίζουν τους δείκτες συλλογής ως φορητούς ταυτοποιητές.

### **Μη Περιστρεφόμενος Σύνδεσμος**

Η αρχική διάταξη περιέχει δύο κείμενα συνδεδεμένα με έναν `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

Αυτό το παράδειγμα εξετάζει το σύνδεσμο και παίρνει τις οριζόντιες και κάθετες ρυθμίσεις λοξογράμματος:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

Για να αλλάξετε και τις δύο καμπύλες, εντοπίστε κάθε αναμενόμενο τύπο και μεταβείτε τις τιμές μόνο αφού εντοπιστούν και οι δύο:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα είναι ένας σύνδεσμος του οποίου τα οριζόντια και κάθετα τμήματα έχουν μετακινηθεί:

![connector-adjusted-1](connector-adjusted-1.png)

Μόλις γνωστοποιηθούν οι σημασιολογικοί τύποι, οι τιμές τους μπορούν να μετατραπούν σε συντεταγμένες πλαισίου συνδέσμου. Αυτό το παράδειγμα σχεδιάζει ένα λεπτό ορθογώνιο πάνω στο κάθετο τμήμα που ελέγχεται από τις δύο ρυθμίσεις λοξογράμματος:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Το σχήμα οδηγού σηματοδοτεί το υπολογισμένο τμήμα:

![connector-adjusted-2](connector-adjusted-2.png)

### **Περιστρεφόμενος ή Αναστραφόμενος Σύνδεσμος**

Όταν η ίδια γεωμετρία συνδέσμου προσανατολίζεται κατακόρυφα, οι τιμές του [frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishapeframe/flip_h/) και [flip_v](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishapeframe/flip_v/) επηρεάζουν τη μετατροπή από τις συντεταγμένες πλαισίου του συνδέσμου στις συντεταγμένες της διαφάνειας.

Αυτό το παράδειγμα δημιουργεί και ρυθμίζει τον κάθετα προσανατολισμένο σύνδεσμο:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Ο προσαρμοσμένος σύνδεσμος εμφανίζεται κατακόρυφα μεταξύ των σχημάτων:

![connector-adjusted-3](connector-adjusted-3.png)

Για μια αυθαίρετη γωνία περιστροφής `alpha`, περιστρέψτε ένα σημείο πλαισίου συνδέσμου `(x, y)` γύρω από το κέντρο του πλαισίου `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Ο παρακάτω κώδικας διαχειρίζεται τον προσανατολισμό 90 μοιρών που χρησιμοποιείται σε αυτό το παράδειγμα και σχεδιάζει έναν κόκκινο οδηγό πάνω στο αντίστοιχο τμήμα του συνδέσμου:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Ο κόκκινος οδηγός σημειώνει το υπολογισμένο τμήμα μετά τη μετατροπή συντεταγμένων:

![connector-adjusted-4](connector-adjusted-4.png)

Αυτές οι τύποι περιγράφουν τις προεπιλογές που χρησιμοποιούνται στα παραδείγματα, όχι ένα καθολικό μοντέλο συνδέσμου. Επικυρώστε τους τύπους ρύθμισης, τον προσανατολισμό πλαισίου και τα εύρη τιμών πριν εφαρμόσετε τον ίδιο υπολογισμό σε διαφορετική προεπιλογή.

## **Εύρεση Γωνίας Κατεύθυνσης Συνδέσμου**

Η κατεύθυνση ενός ευθύ συνδέσμου μπορεί να υπολογιστεί από το πλάτος και το ύψος του, λαμβάνοντας υπόψιν τις οριζόντιες και κάθετες αναστροφές. Το παρακάτω παράδειγμα αναφέρει τη ρολογιακή γωνία από τον θετικό οριζόντιο άξονα στις συντεταγμένες της διαφάνειας:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διαπιστώ αν ένας σύνδεσμος μπορεί να συνδεθεί με ένα σχήμα;**

Ελέγξτε το [connection_site_count](https://reference.aspose.com/slides/el/python-net/aspose.slides/igeometryshape/connection_site_count/) του σχήματος. Ένας θετικός αριθμός σημαίνει ότι το σχήμα εκθέτει σημεία σύνδεσης. Επικυρώστε τον επιλεγμένο δείκτη σημείου πριν τον ορίσετε σε οποιοδήποτε άκρο του συνδέσμου.

**Μπορώ να προσδιορίσω μια ρύθμιση σύνδεσμου με τον δείκτη της συλλογής;**

Ένας δείκτης είναι σημαίνων μόνο για μια γνωστή προεπιλογή συνδέσμου και τη διάταξη της συλλογής. Ελέγξτε το [IAdjustValue.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/iadjustvalue/type/) πριν τροποποιήσετε μια τιμή και χρησιμοποιήστε το [IAdjustValue.name](https://reference.aspose.com/slides/el/python-net/aspose.slides/iadjustvalue/name/) ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερες από μία φορές.

**Τι συμβαίνει όταν ένα συνδεδεμένο σχήμα διαγραφεί;**

Το αντίστοιχο άκρο του συνδέσμου αποσυνδέεται. Ο σύνδεσμος παραμένει στη διαφάνεια και μπορεί να διαγραφεί, να τοποθετηθεί ως ελεύθερη γραμμή ή να συνδεθεί ξανά με άλλο σχήμα.

**Διατηρούνται οι συνδέσεις όταν αντιγραφεί μια διαφάνεια;**

Οι συνδέσεις διατηρούνται γενικά όταν τα συνδεδεμένα σχήματα αντιγράφονται μαζί με τη διαφάνεια. Εάν ένας σύνδεσμος αντιγραφεί χωρίς ένα από τα σχήματα-στόχους, το επηρεαζόμενο άκρο πρέπει να επανασυνδεθεί.