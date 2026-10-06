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
- ιδιότητα κρυμμένου
- οργανωτικό διάγραμμα
- διάγραμμα οργανωτικού τύπου εικόνας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε να δημιουργείτε και να επεξεργάζεστε SmartArt PowerPoint με το Aspose.Slides για Python μέσω Java χρησιμοποιώντας σαφή παραδείγματα κώδικα που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση των διαφανειών."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που δημιουργείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides for Python μέσω Java, μπορείτε να δημιουργήσετε SmartArt, να διαβάζετε κείμενο από τους κόμβους του, να αλλάζετε τη διάταξή του, να ελέγχετε κρυφούς κόμβους, να διαμορφώνετε διατάξεις οργανωτικών διαγραμμάτων και να δημιουργείτε διαγράμματα οργανωτικού τύπου εικόνας.

## **Λήψη κειμένου από αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε κείμενο από τα σχήματα του κόμβου, επαναλάβετε μέσω του [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), μετά διαβάστε το [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) που επιστρέφεται από το [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

Το παράδειγμα απαιτεί μια παρουσίαση με τουλάχιστον μία διαφάνεια και ένα αντικείμενο SmartArt ως πρώτο σχήμα σε αυτή τη διαφάνεια. Εκτυπώνει κάθε διαθέσιμο πλαίσιο κειμένου στην κονσόλα.

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

## **Αλλαγή τύπου διάταξης αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς διατάσσονται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, την αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση. Η θέση και το μέγεθος που περνούν στο [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) μετρώνται σε μονάδες σημείου. Χρησιμοποιήστε το [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) για να αλλάξετε τη διάταξη.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Έλεγχος αν ένας κόμβος SmartArt είναι κρυφός**

Η μέθοδος [SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) υποδεικνύει αν ο κόμβος είναι κρυφός στο μοντέλο δεδομένων SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε αντικείμενο SmartArt που χρησιμοποιεί την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` και ελέγχει την κρυφή κατάσταση του προστιθέμενου κόμβου. Εκτυπώνει ένα μήνυμα εάν ο κόμβος είναι κρυφός και αποθηκεύει το διάγραμμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Λήψη ή ορισμός της διάταξης οργανωτικού διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, οι μέθοδοι [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) και [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) καθορίζουν πώς διατάσσονται οι κόμβοι‑παιδιά κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε οι κόμβοι‑παιδιά να κρέμονται από την αριστερή, τη δεξιά ή και τις δύο πλευρές, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Ο δείκτης μηδενικής βάσης `0` επιλέγει τον πρώτο κορυφαίο κόμβο· οι κόμβοι‑παιδιά του χρησιμοποιούν τη επιλεγμένη διάταξη. Η τροποποιημένη παρουσίαση αποθηκεύεται μετά.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Δημιουργία διαγράμματος οργανωτικού τύπου εικόνας**

Ένα διάγραμμα οργανωτικού τύπου εικόνας είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν υποδείκτες εικόνας. Χρησιμοποιήστε την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια. Αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα με υποδείκτες εικόνας· δεν γεμίζει τους υποδείκτες με εικόνες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Μετατροπή διαγραμμάτων παλαιού τύπου σε ομάδες σχημάτων**

Κατά τη μοντερνποίηση μιας υπάρχουσας παρουσίασης, ίσως χρειαστεί να ενημερώσετε ένα οργανωτικό διάγραμμα που δημιουργήθηκε αρχικά στο PowerPoint 97–2003. Το Aspose.Slides αντιπροσωπεύει αυτά τα διαγράμματα παλαιού τύπου ως αντικείμενα [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). Χρησιμοποιήστε τη μέθοδο [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) για να μετατρέψετε ένα διάγραμμα σε ομάδα σχημάτων ώστε να μπορείτε να επεξεργαστείτε μεμονωμένα οπτικά στοιχεία. Δείτε την [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) για λεπτομέρειες.

Η μετατροπή προσθέτει μια νέα ομάδα στη συλλογή σχημάτων χωρίς να αφαιρέσει το αρχικό διάγραμμα. Μετά την επιτυχή μετατροπή, αφαιρέστε το αρχικό με τη μέθοδο [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) για να αποφευχθεί διπλό περιεχόμενο. Συλλέξτε τα διαγράμματα παλαιού τύπου σε μια λίστα πριν τα μετατρέψετε, ώστε η προσθήκη και αφαίρεση σχημάτων να μην διακόπτει την επανάληψη.

Το παρακάτω παράδειγμα ανοίγει μια παρουσίαση, ψάχνει σε κάθε διαφάνεια, μετατρέπει τα διαγράμματα σε ομάδες σχημάτων και αποθηκεύει την ενημερωμένη παρουσίαση ως PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αποθηκευμένη παρουσίαση περιέχει επεξεργάσιμες ομάδες σχημάτων στη θέση των μετατρεπόμενων διαγραμμάτων παλαιού τύπου, χωρίς να απομένουν τα αρχικά διαγράμματα. Ανοίξτε το PPTX στο PowerPoint για να επεξεργαστείτε μεμονωμένα στοιχεία μέσα σε κάθε ομάδα, όπως το κείμενό τους, τη γέμιση ή τη θέση.

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το SmartArt καθρεφτισμό ή ανάστροφη για γλώσσες RTL;**

Ναι. Η μέθοδος [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αναστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [αντιγράψετε το σχήμα SmartArt](/slides/el/python-java/shape-manipulations/) με τη μέθοδο [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) ή να [αντιγράψετε ολόκληρη τη διαφάνεια](/slides/el/python-java/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς μπορώ να αποδείξω το SmartArt σε εικόνα raster για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/python-java/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια εάν υπάρχουν πολλά;**

Χρησιμοποιήστε τη μέθοδο [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) ή [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) για να αντιστοιχίσετε ένα ξεχωριστό εναλλακτικό κείμενο ή όνομα στο σχήμα SmartArt, αναζητήστε αυτήν την τιμή στο [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) και, στη συνέχεια, ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).