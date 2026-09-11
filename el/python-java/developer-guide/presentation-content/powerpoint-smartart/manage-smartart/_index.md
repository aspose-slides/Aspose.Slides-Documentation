---
title: Διαχείριση SmartArt σε παρουσιάσεις PowerPoint χρησιμοποιώντας Python
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/python-java/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- τύπος διάταξης
- κρυφή ιδιότητα
- οργανογράφημα
- διάγραμμα οργανωτικού με εικόνα
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να επεξεργάζεστε SmartArt PowerPoint με το Aspose.Slides για Python μέσω Java, χρησιμοποιώντας σαφή παραδείγματα κώδικα που επιταχύνουν το σχεδιασμό διαφανειών και την αυτοματοποίηση."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που αποτελείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides for Python μέσω Java, μπορείτε να δημιουργήσετε SmartArt, να διαβάζετε κείμενο από τους κόμβους του, να αλλάζετε τη διάταξή του, να επιθεωρείτε κρυφά κόμβους, να διαμορφώνετε διατάξεις οργανωτικών διαγραμμάτων και να δημιουργείτε διαγράμματα οργανωτικού τύπου με εικόνα.

## **Λήψη Κειμένου από Αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το ορατό κείμενο, επαναλάβετε μέσω του [SmartArt.getAllNodes](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/#getAllNodes), στη συνέχεια διαβάστε το [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) που επιστρέφεται από το [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartshape/#getTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Αλλαγή Τύπου Διάταξης Αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς τακτοποιούνται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή `BasicBlockList` του [SmartArtLayoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartlayouttype/), την αλλάζει στη τιμή `BasicProcess` και αποθηκεύει την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Έλεγχος Εάν Κόμβος SmartArt Είναι Κρυφό**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/#isHidden) υποδεικνύει εάν ο κόμβος είναι κρυφό στο μοντέλο δεδομένων του SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή `RadialCycle` του [SmartArtLayoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartlayouttype/) και ελέγχει την κρυφή κατάσταση του κόμβου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Λήψη ή Ορισμός Διάταξης Οργανωτικού Διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, οι μέθοδοι [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) και [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) ορίζουν πώς τα παιδικά κόμβοι τοποθετούνται κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε τα παιδικά κόμβοι να κρέμονται από τα αριστερά, δεξιά ή και τις δύο πλευρές, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή `LeftHanging` του [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/organizationchartlayouttype/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Δημιουργία Διαγράμματος Οργανωτικού Τύπου με Εικόνα**

Ένα διάγραμμα οργανωτικού τύπου με εικόνα είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν δεσμευτικούς θέσεων εικόνας. Χρησιμοποιήστε την τιμή `PictureOrganizationChart` του [SmartArtLayoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartlayouttype/) όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το SmartArt κατοπτρισμό ή αντιστροφή για γλώσσες RTL;**

Ναι. Η μέθοδος [SmartArt.setReversed](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/#setReversed) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/python-java/shape-manipulations/) με το [ShapeCollection.addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addClone) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/python-java/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς μπορώ να αποδώσω το SmartArt σε εικόνα raster για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/python-java/convert-powerpoint-to-png/) ή όλη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια αν υπάρχουν πολλά;**

Ορίστε μια διακριτική τιμή στο [Shape.getAlternativeText](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getAlternativeText) ή στο [Shape.getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getName) του σχήματος SmartArt, αναζητήστε αυτήν την τιμή στο [BaseSlide.getShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getShapes), και στη συνέχεια ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).