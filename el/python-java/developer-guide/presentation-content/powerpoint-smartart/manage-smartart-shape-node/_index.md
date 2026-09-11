---
title: Διαχείριση Κόμβων Σχημάτων SmartArt σε Παρουσιάσεις με Python
linktitle: Κόμβος Σχήματος SmartArt
type: docs
weight: 30
url: /el/python-java/manage-smartart-shape-node/
keywords:
- Κόμβος SmartArt
- Υποκόμβος
- Προσθήκη κόμβου
- Θέση κόμβου
- Πρόσβαση σε κόμβο
- Αφαίρεση κόμβου
- Προσαρμοσμένη θέση
- Βοηθητικός κόμβος
- Μορφή γεμίσματος
- Απόδοση κόμβου
- PowerPoint
- Παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τους κόμβους σχήματος SmartArt σε PPT και PPTX με την Aspose.Slides για Python μέσω Java. Λάβετε σαφή παραδείγματα κώδικα και συμβουλές για τη βελτιστοποίηση των παρουσιάσεών σας."
---
## **Επισκόπηση**

Τα γραφικά SmartArt στις παρουσιάσεις PowerPoint οργανώνονται μέσω κόμβων που περιέχουν κείμενο και καθορίζουν τη δομή του διαγράμματος. Η Aspose.Slides σάς επιτρέπει να εργάζεστε προγραμματιστικά με αυτούς τους κόμβους SmartArt: προσθέστε νέους κόμβους και υποκόμβους, εισάγετε υποκόμβους σε συγκεκριμένη θέση, προσπελάστε υπάρχοντες κόμβους και διαβάστε το κείμενο, το επίπεδο και τη θέση τους.

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τους κόμβους σχήματος SmartArt. Δείχνει πώς να αφαιρείτε κόμβους, να εργάζεστε με υποκόμβους κατά δείκτη ή θέση, να μετατρέπετε έναν βοηθητικό κόμβο σε κανονικό, να ρυθμίζετε τη θέση, το μέγεθος και την περιστροφή των σχημάτων κόμβων SmartArt, να ορίζετε μορφές γεμίσματος κόμβων και να δημιουργείτε μικρογραφία για έναν υποκόμβο SmartArt.

## **Προσθήκη κόμβου SmartArt**
Η Aspose.Slides για Python μέσω Java παρέχει ένα API για τη διαχείριση σχημάτων SmartArt. Το παρακάτω παράδειγμα προσθέτει έναν κόμβο και έναν υποκόμβο σε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει σχήμα SmartArt.  
2. Αποκτήστε την πρώτη διαφάνεια με βάση τον δείκτη της.  
3. Επανάληψη σε κάθε σχήμα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι μια περίπτωση του [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).  
5. [Προσθήκη νέου κόμβου](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnodecollection/#addNode) στο [συλλογή κόμβων](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/#getAllNodes) του σχήματος SmartArt και ορίστε το κείμενό του μέσω του [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/).  
6. [Προσθήκη](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnodecollection/#addNode) ενός [υποκόμβου](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/#getChildNodes) στο νέο κόμβο και ορίστε το κείμενό του μέσω του [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/).  
7. Αποθηκεύστε την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσθήκη κόμβου SmartArt σε συγκεκριμένη θέση**
Το παρακάτω παράδειγμα προσθέτει έναν υποκόμβο σε συγκεκριμένη θέση σε έναν κόμβο SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).  
2. Αποκτήστε την πρώτη διαφάνεια με βάση τον δείκτη της.  
3. Προσθέστε ένα σχήμα [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/) με τη διάταξη [StackedList](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartlayouttype/#StackedList) στην διαφάνεια.  
4. Προσπελάστε τον πρώτο κόμβο στο προστεθέν σχήμα SmartArt.  
5. Προσθέστε έναν υποκόμβο στον επιλεγμένο κόμβο στη θέση 2 χρησιμοποιώντας το [addNodeByPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) και ορίστε το κείμενό του.  
6. Αποθηκεύστε την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε κόμβο SmartArt**
Το παρακάτω παράδειγμα προσπελαύνει κόμβους σε σχήμα SmartArt. Η διάταξη που επιστρέφεται από το [getLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/#getLayout) είναι μόνο για ανάγνωση και ορίζεται όταν προστίθεται το σχήμα SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει σχήμα SmartArt.  
2. Αποκτήστε την πρώτη διαφάνεια με βάση τον δείκτη της.  
3. Επανάληψη σε κάθε σχήμα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι μια περίπτωση του [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).  
5. Επανάληψη μέσα σε όλους τους [κόμβους](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/#getAllNodes) του σχήματος SmartArt.  
6. Διαβάστε και εμφανίστε τη θέση, το επίπεδο και το κείμενο κάθε κόμβου SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Πρόσβαση σε υποκόμβο SmartArt**
Το παρακάτω παράδειγμα προσπελαύνει τους υποκόμβους κάθε κόμβου σε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει σχήμα SmartArt.  
2. Αποκτήστε την πρώτη διαφάνεια με βάση τον δείκτη της.  
3. Επανάληψη σε κάθε σχήμα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι μια περίπτωση του [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).  
5. Επανάληψη μέσα σε όλους τους [κόμβους](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/#getAllNodes) του σχήματος SmartArt.  
6. Για κάθε κόμβο, επανάληψη μέσα στους [υποκόμβους](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/#getChildNodes).  
7. Διαβάστε και εμφανίστε τη θέση, το επίπεδο και το κείμενο του [υποκόμβου](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Πρόσβαση σε υποκόμβο SmartArt σε συγκεκριμένη θέση**
Το παρακάτω παράδειγμα προσπελαύνει έναν υποκόμβο σε συγκεκριμένο δείκτη στη συλλογή του γονικού του κόμβου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).  
2. Αποκτήστε την πρώτη διαφάνεια με βάση τον δείκτη της.  
3. Προσθέστε ένα σχήμα SmartArt με τη διάταξη [StackedList](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartlayouttype/#StackedList).  
4. Προσπελάστε το προστεθέν σχήμα SmartArt.  
5. Προσπελάστε τον κόμβο με δείκτη 0 στο σχήμα SmartArt.  
6. Προσπελάστε τον υποκόμβο με δείκτη 1 χρησιμοποιώντας το [get_Item](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnodecollection/#get_Item).  
7. Διαβάστε και εμφανίστε τη θέση, το επίπεδο και το κείμενο του [υποκόμβου](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Αφαίρεση κόμβου SmartArt**
Το παρακάτω παράδειγμα αφαιρεί έναν κόμβο από σχήμα SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει σχήμα SmartArt.  
2. Αποκτήστε την πρώτη διαφάνεια με βάση τον δείκτη της.  
3. Επανάληψη σε κάθε σχήμα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι μια περίπτωση του [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).  
5. Ελέγξτε ότι το σχήμα SmartArt περιέχει τουλάχιστον έναν κόμβο.  
6. Επιλέξτε το κόμβο SmartArt που θα διαγραφεί.  
7. Αφαιρέστε τον επιλεγμένο κόμβο χρησιμοποιώντας το [removeNode](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnodecollection/#removeNode).  
8. Αποθηκεύστε την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αφαίρεση κόμβου SmartArt από συγκεκριμένη θέση**
Το παρακάτω παράδειγμα αφαιρεί έναν υποκόμβο σε συγκεκριμένο δείκτη στη συλλογή ενός κόμβου SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει σχήμα SmartArt.  
2. Αποκτήστε την πρώτη διαφάνεια με βάση τον δείκτη της.  
3. Επανάληψη σε κάθε σχήμα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι μια περίπτωση του [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).  
5. Προσπελάστε τον κόμβο SmartArt με δείκτη 0 εφόσον υπάρχει.  
6. Ελέγξτε ότι ο επιλεγμένος κόμβος SmartArt έχει τουλάχιστον δύο υποκόμβους.  
7. Αφαιρέστε τον υποκόμβο με δείκτη 1 χρησιμοποιώντας το [removeNode](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnodecollection/#removeNode).  
8. Αποθηκεύστε την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός προσαρμοσμένης θέσης για υποκόμβο σε αντικείμενο SmartArt**
Η Aspose.Slides για Python μέσω Java υποστηρίζει τον ορισμό της θέσης ενός [SmartArtShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartshape/) χρησιμοποιώντας τις μεθόδους [setX](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setX) και [setY](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setY). Το παρακάτω παράδειγμα ορίζει προσαρμοσμένη θέση, μέγεθος και περιστροφή για τα σχήματα κόμβων SmartArt. Η προσθήκη νέων κόμβων επαναϋπολογίζει τις θέσεις και τα μεγέθη όλων των κόμβων. Η προσαρμοσμένη θέση σας επιτρέπει να διατάξετε τους κόμβους όπως απαιτείται.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Έλεγχος βοηθητικού κόμβου**
{{% alert color="info" title="Σημείωση" %}} 

Αυτή η ενότητα εξερευνά τα σχήματα SmartArt που προστίθενται σε διαφάνειες παρουσίασης προγραμματιστικά χρησιμοποιώντας την Aspose.Slides για Python μέσω Java.

{{% /alert %}} 

Το παρακάτω αρχικό σχήμα SmartArt χρησιμοποιείται σε αυτό το παράδειγμα.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Σχήμα: Αρχικό σχήμα SmartArt σε διαφάνεια**|

Το παρακάτω παράδειγμα εντοπίζει βοηθητικούς κόμβους σε συλλογή κόμβων SmartArt και τους αλλάζει σε κανονικούς κόμβους.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει σχήμα SmartArt.  
2. Αποκτήστε την πρώτη διαφάνεια με βάση τον δείκτη της.  
3. Επανάληψη σε κάθε σχήμα στην πρώτη διαφάνεια.  
4. Ελέγξτε αν το σχήμα είναι μια περίπτωση του [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).  
5. Επανάληψη μέσα σε όλους τους κόμβους του σχήματος SmartArt και ελέγξτε αν είναι [Assistant Nodes](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/#isAssistant).  
6. Αλλάξτε κάθε βοηθητικό κόμβο σε κανονικό.  
7. Αποθηκεύστε την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Σχήμα: Οι βοηθητικοί κόμβοι άλλαξαν σε σχήμα SmartArt σε διαφάνεια**|

## **Ορισμός μορφής γεμίσματος κόμβου**
Αυτή η ενότητα εξηγεί πώς να δημιουργήσετε και να προσπελάσετε σχήματα SmartArt και να ορίσετε τη μορφή γεμίσματος τους χρησιμοποιώντας την Aspose.Slides για Python μέσω Java.

Παρακαλούμε ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).  
2. Αποκτήστε μια διαφάνεια με βάση τον δείκτη της.  
3. Προσθέστε ένα σχήμα [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/) με τη διάταξη [ClosedChevronProcess](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).  
4. Ορίστε το [FillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getFillFormat) για τους κόμβους του σχήματος SmartArt.  
5. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Δημιουργία μικρογραφίας υποκόμβου SmartArt**
Για τη δημιουργία μικρογραφίας ενός υποκόμβου SmartArt, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).  
2. [Προσθήκη σχήματος SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addSmartArt).  
3. Αποκτήστε έναν κόμβο με βάση τον δείκτη του.  
4. Αποκτήστε την εικόνα μικρογραφίας.  
5. Αποθηκεύστε την εικόνα μικρογραφίας σε οποιαδήποτε επιθυμώμενη μορφή εικόνας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Υποστηρίζεται η κίνηση SmartArt;**

Ναι. Το SmartArt αντιμετωπίζεται ως κανονικό σχήμα, έτσι μπορείτε να [εφαρμόσετε τυπικές κινούμενες εφέ](/slides/el/python-java/shape-animation/) (εισόδους, εξόδους, έμφαση, διαδρομές κίνησης) και να ρυθμίσετε το χρόνο. Μπορείτε επίσης να κινείτε σχήματα μέσα σε κόμβους SmartArt όταν απαιτείται.

**Πώς μπορώ να εντοπίσω αξιόπιστα ένα συγκεκριμένο SmartArt σε μια διαφάνεια εάν το εσωτερικό του ID είναι άγνωστο;**

Αναθέστε και αναζητήστε με βάση το [alternative text](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getAlternativeText). Ορίζοντας διακριτικό εναλλακτικό κείμενο στο SmartArt, μπορείτε να το βρείτε προγραμματιστικά χωρίς να βασίζεστε σε εσωτερικά αναγνωριστικά.

**Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή της παρουσίασης σε PDF;**

Ναι. Η Aspose.Slides αποδίδει το SmartArt με υψηλή οπτική πιστότητα κατά την [εξαγωγή PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), διατηρώντας τη διάταξη, τα χρώματα και τις εφέ.

**Μπορώ να εξάγω εικόνα ολόκληρου του SmartArt (για προεπισκοπήσεις ή αναφορές);**

Ναι. Μπορείτε να αποδώσετε ένα σχήμα SmartArt σε [μορφές raster](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) ή σε [SVG](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#writeAsSvgToBytes) για διανυσματική εξαγωγή, καθιστώντας το κατάλληλο για μικρογραφίες, αναφορές ή χρήση στο web.