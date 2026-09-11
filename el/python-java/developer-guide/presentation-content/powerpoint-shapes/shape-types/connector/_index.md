---
title: Διαχείριση Συνδετών σε Παρουσιάσεις με Python μέσω Java
linktitle: Σύνδεσμος
type: docs
weight: 10
url: /el/python-java/connector/
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
description: "Μάθετε πώς να προσθέτετε, συνδέετε, επαναδρομολογείτε, ρυθμίζετε και ελέγχετε ευθείς, λυγισμένους και καμπυλωμένους συνδέσμους PowerPoint με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Ένας σύνδεσμος είναι μια γραμμή που μπορεί να παραμείνει συνδεδεμένη σε δύο σχήματα όταν μετακινείται οποιοδήποτε από τα σχήματα. Τα άκρα του συνδέονται σε σημεία σύνδεσης, που αναπαρίστανται από πράσινα σημεία στο PowerPoint. Ορισμένοι λυγισμένοι και καμπυλωτοί σύνδεσμοι εκθέτουν επίσης σημεία ρύθμισης, που αναπαρίστανται από πορτοκαλί σημεία, και ελέγχουν τη θέση των μεμονωμένων τμημάτων του συνδέσμου.

Το Aspose.Slides αντιπροσωπεύει τους συνδέσμους μέσω της κλάσης [Σύνδεσμος](https://reference.aspose.com/slides/el/python-java/aspose.slides/connector/) . Μπορείτε να τους δημιουργήσετε, να συνδέσετε τα άκρα τους σε σχήματα, να επιλέξετε σημεία σύνδεσης, να τα επαναδρομολογήσετε και να τροποποιήσετε τη γεωμετρία των συνδέσμων που έχουν σημεία ρύθμισης.

## **Τύποι Συνδέσμων**

Η κλάση [ShapeType](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/) περιλαμβάνει προεπιλογές ευθείων, λυγισμένων και καμπυλωτών συνδέσμων. Ο παρακάτω πίνακας δείχνει τις διαθέσιμες γεωμετρίες συνδέσμων και τον αριθμό των σημείων ρύθμισης που ορίζονται σε κάθε προεπιλογή.

| Σύνδεσμος | Εικόνα | Αριθμός σημείων ρύθμισης |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Ο αριθμός και το νόημα των σημείων ρύθμισης αποτελούν μέρος της επιλεγμένης προεπιλογής συνδέσμου. Μην υποθέτετε ότι δύο διαφορετικοί τύποι συνδέσμων εκθέτουν την ίδια διάταξη συλλογής.

## **Σύνδεση Δύο Σχημάτων**

Χρησιμοποιήστε το [ShapeCollection.addConnector](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addConnector) για να προσθέσετε έναν σύνδεσμο και χρησιμοποιήστε τα [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/el/python-java/aspose.slides/connector/#setStartShapeConnectedTo) και [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/el/python-java/aspose.slides/connector/#setEndShapeConnectedTo) για να συνδέσετε τα άκρα του. Αφού συνδεθούν και τα δύο άκρα, το [Connector.reroute](https://reference.aspose.com/slides/el/python-java/aspose.slides/connector/#reroute) επιλέγει μια σύντομη διαδρομή μεταξύ των σχημάτων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Προειδοποίηση" %}}
Η κλήση του [reroute](https://reference.aspose.com/slides/el/python-java/aspose.slides/connector/#reroute) μπορεί να αλλάξει τις τιμές των [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) και [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/el/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Ορίστε συγκεκριμένα σημεία σύνδεσης μετά την επαναδρομολόγηση εάν αυτά τα σημεία πρέπει να παραμείνουν σταθερά.
{{% /alert %}}

## **Επιλογή Σημείου Σύνδεσης**

Κάθε σχήμα που μπορεί να συνδεθεί αναφέρει τον αριθμό των σημείων του μέσω του [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getConnectionSiteCount). Επαληθεύστε έναν προτιμώμενο δείκτη σημείου μηδενικής βάσης πριν το αναθέσετε σε άκρο συνδέσμου· οι μετρήσεις των σημείων διαφέρουν ανάλογα με τη γεωμετρία του σχήματος.

Αυτό το παράδειγμα συνδέει τον σύνδεσμο σε ένα συγκεκριμένο σημείο του έλλειψου όταν αυτό το σημείο υπάρχει:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ρύθμιση Σημείου Συνδέσμου**

Οι σύνδεσμοι με σημεία ρύθμισης τα εκθέτουν μέσω του [GeometryShape.getAdjustments](https://reference.aspose.com/slides/el/python-java/aspose.slides/geometryshape/#getAdjustments). Εξετάστε κάθε [AdjustValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/) και ελέγξτε την τιμή του [getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getType) πριν την αλλάξετε με το [setRawValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#setRawValue). Οι γενικοί κανόνες για τον εντοπισμό των προεπιλεγμένων προσαρμογών σχήματος περιγράφονται στην ενότητα [Shape Manipulation](/slides/el/python-java/shape-manipulations/).

Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος τιμών των ρυθμίσεων του συνδέσμου εξαρτώνται από την προεπιλογή του συνδέσμου. Ο τύπος ρύθμισης είναι μόνο για ανάγνωση, ενώ η τιμή ρύθμισης μπορεί να τροποποιηθεί. Η μέθοδος μόνο για ανάγνωση [getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getName) παρέχει πρόσθετη ταυτοποίηση όταν ένας σύνδεσμος περιέχει περισσότερες από μία ρυθμίσεις του ίδιου σημασιολογικού τύπου.

### **Διαδρομή Πέρα Από Ένα Εμπόδιο**

Στην παρακάτω διάταξη, ένας σύνδεσμος [BentConnector5](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#BentConnector5) μεταξύ δύο σχημάτων περνάει από ένα τρίτο σ Shape:

![connector-obstruction](connector-obstruction.png)

Αυτός ο κώδικας δημιουργεί τον εμποδισμένο σύνδεσμο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η μετακίνηση της κάθετης καμπυλής αλλάζει τη διαδρομή ώστε ο σύνδεσμος να παρακάμπτει το εμπόδιο:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Αντί να υποθέτετε ότι ο δείκτης συλλογής `1` αντιπροσωπεύει πάντα την κάθετη κάμψη, αυτό το παράδειγμα ψάχνει το [ConnectorBendPositionY](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) και το τροποποιεί μόνο όταν υπάρχει ο αναμενόμενος σημασιολογικός τύπος:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ένας [BentConnector5](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#BentConnector5) διαθέτει δύο ρυθμίσεις [ConnectorBendPositionX](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) και μία ρύθμιση [ConnectorBendPositionY](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Εάν ο τύπος που χρειάζεστε εμφανίζεται περισσότερες από μία φορές, εξετάστε το [getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getName) και τη γνωστή γεωμετρία εκείνης της προεπιλογής πριν επιλέξετε μία. Εάν μια ρύθμιση αναφέρει [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#Custom), θεωρήστε το νόημα και το εύρος της ως ειδικό για την προεπιλογή και μην το αλλάξετε μέχρι να είναι γνωστή η σύμβαση.

## **Συσχέτιση Τιμών Ρύθμισης με Γεωμετρία Συνδέσμου**

Για λυγισμένους συνδέσμους, οι τιμές ρύθμισης μπορούν να χρησιμοποιηθούν για την εκτίμηση των θέσεων των επιμέρους τμημάτων. Αυτοί οι υπολογισμοί είναι ειδικοί για την προεπιλογή του συνδέσμου:

- [BentConnector4](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#BentConnector4) συνήθως εκθέτει μία ρύθμιση [ConnectorBendPositionX](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) και μία ρύθμιση [ConnectorBendPositionY](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- Για αυτές τις θέσεις κάμψης, η διαίρεση της τιμής που επιστρέφεται από το [getRawValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getRawValue) διά `100000.0` παράγει το κλάσμα του πλάτους ή του ύψους του πλαισίου του συνδέσμου που χρησιμοποιείται στα παρακάτω παραδείγματα.
- Ένα πλαίσιο συνδέσμου μπορεί να περιστραφεί ή να αντιστραφεί, επομένως οι συντεταγμένες του πλαισίου πρέπει να μετασχηματιστούν πριν συγκριθούν με τις συντεταγμένες της διαφάνειας.

Τα παρακάτω παραδείγματα χρησιμοποιούν το [getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getType) για να προσδιορίσουν πρώτα τις ρυθμίσεις. Δεν αντιμετωπίζουν τους δείκτες συλλογής ως φορητά αναγνωριστικά.

### **Σύνδεσμος Χωρίς Περιστροφή**

Η αρχική διάταξη περιέχει δύο σχήματα κειμένου συνδεδεμένα με έναν [BentConnector4](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Αυτό το παράδειγμα εξετάζει τον σύνδεσμο και λαμβάνει τις οριζόντιες και κάθετες ρυθμίσεις κάμψης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Για να αλλάξετε και τις δύο κάμψεις, εντοπίστε κάθε αναμενόμενο τύπο και τροποποιήστε τις τιμές μόνο αφού βρεθούν και οι δύο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα είναι ένας σύνδεσμος του οποίου τα οριζόντια και κάθετα τμήματα έχουν μετακινηθεί:

![connector-adjusted-1](connector-adjusted-1.png)

Μόλις γνωστοποιηθούν οι σημασιολογικοί τύποι, οι τιμές τους μπορούν να μετατραπούν σε συντεταγμένες του πλαισίου του συνδέσμου. Αυτό το παράδειγμα σχεδιάζει ένα λεπτό ορθογώνιο πάνω από το κάθετο τμήμα που ελέγχεται από τις δύο ρυθμίσεις κάμψης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![connector-adjusted-2](connector-adjusted-2.png)

### **Σύνδεσμος Περιστρεφόμενος ή Αντιστραμμένος**

Όταν η ίδια γεωμετρία συνδέσμου προσανατολίζεται κατακόρυφα, οι τιμές του [Shape.getFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeframe/#getFlipH) και [ShapeFrame.getFlipV](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapeframe/#getFlipV) επηρεάζουν τη μετατροπή από τις συντεταγμένες του πλαισίου του συνδέσμου σε συντεταγμένες της διαφάνειας.

Αυτό το παράδειγμα δημιουργεί και ρυθμίζει τον κατακόρυφα προσανατολισμένο σύνδεσμο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![connector-adjusted-3](connector-adjusted-3.png)

Για μια αυθαίρετη γωνία περιστροφής `alpha`, περιστρέψτε ένα σημείο πλαισίου συνδέσμου `(x, y)` γύρω από το κέντρο του πλαισίου `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Ο παρακάτω κώδικας χειρίζεται τον προσανατολισμό 90 μοιρών που χρησιμοποιείται σε αυτό το παράδειγμα και σχεδιάζει έναν κόκκινο οδηγό πάνω από το αντίστοιχο τμήμα του συνδέσμου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ο κόκκινος οδηγός επισημαίνει το υπολογισμένο τμήμα μετά τον μετασχηματισμό των συντεταγμένων:

![connector-adjusted-4](connector-adjusted-4.png)

Αυτοί οι τύποι περιγράφουν τις προεπιλογές που χρησιμοποιούνται στα παραδείγματα, όχι ένα καθολικό μοντέλο συνδέσμου. Επαληθεύστε τους τύπους ρυθμίσεων, τον προσανατολισμό του πλαισίου και τα εύρη τιμών πριν εφαρμόσετε τον ίδιο υπολογισμό σε διαφορετική προεπιλογή.

## **Εύρεση Γωνίας Κατεύθυνσης Συνδέσμου**

Η κατεύθυνση ενός ευθύ συνδέσμου μπορεί να υπολογιστεί από το πλάτος και το ύψος του, με εφαρμογμένες τις οριζόντιες και κατακόρυφες αντιστροφές. Το παρακάτω παράδειγμα αναφέρει τη δεξιόστροφη γωνία από τον θετικό οριζόντιο άξονα στις συντεταγμένες της διαφάνειας:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας σύνδεσμος μπορεί να συνδεθεί με ένα σχήμα;**

Ελέγξτε την τιμή [getConnectionSiteCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getConnectionSiteCount) του σχήματος. Ένας θετικός αριθμός σημαίνει ότι το σχήμα εκθέτει σημεία σύνδεσης. Επαληθεύστε τον επιλεγμένο δείκτη σημείου πριν το αναθέσετε σε οποιοδήποτε άκρο του συνδέσμου.

**Μπορώ να αναγνωρίσω μια ρύθμιση συνδέσμου από το δείκτη της συλλογής του;**

Ένας δείκτης είναι σημαντικός μόνο για μια γνωστή προεπιλογή συνδέσμου και διάταξη συλλογής. Ελέγξτε το [AdjustValue.getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getType) πριν τροποποιήσετε μια τιμή, και χρησιμοποιήστε το [AdjustValue.getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/adjustvalue/#getName) ως πρόσθετη πληροφορία όταν ο ίδιος σημασιολογικός τύπος εμφανίζεται περισσότερες από μία φορές.

**Τι συμβαίνει όταν ένα συνδεδεμένο σχήμα διαγράφεται;**

Το αντίστοιχο άκρο του συνδέσμου αποσυνδέεται. Ο σύνδεσμος παραμένει στη διαφάνεια και μπορεί να διαγραφεί, να τοποθετηθεί ως ελεύθερη γραμμή ή να συνδεθεί με κάποιο άλλο σχήμα.

**Διατηρούνται οι συνδέσεις του συνδέσμου όταν αντιγράφεται μια διαφάνεια;**

Οι συνδέσεις διατηρούνται γενικά όταν τα συνδεδεμένα σχήματα αντιγράφονται μαζί με τη διαφάνεια. Εάν ένας σύνδεσμος αντιγραφεί χωρίς κάποιο από τα σχήματα-στόχους του, το επηρεασμένο άκρο πρέπει να συνδεθεί ξανά.