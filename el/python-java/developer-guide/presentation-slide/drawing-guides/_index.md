---
title: Διαχείριση οδηγών σχεδίασης σε παρουσιάσεις με Python
linktitle: Οδηγίες σχεδίασης
type: docs
weight: 85
url: /el/python-java/drawing-guides/
keywords:
- οδηγός σχεδίασης
- οριζόντια οδηγία
- κατακόρυφη οδηγία
- οδηγός ευθυγράμμισης
- προβολή διαφάνειας
- master διαφάνειας
- διαφάνεια διάταξης
- master σημειώσεων
- master εκτυπώσιμων
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσθήκη, πρόσβαση και καθαρισμός οριζόντιων και κατακόρυφων οδηγών σχεδίασης σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Οι οδηγίες σχεδίασης είναι ρυθμιζόμενες οριζόντιες και κατακόρυφες γραμμές που βοηθούν τους χρήστες να ευθυγραμμίζουν τα σχήματα με συνέπεια κατά την επεξεργασία μιας παρουσίασης στο PowerPoint. Είναι ιδιαίτερα χρήσιμες όταν μια εφαρμογή δημιουργεί μια παρουσίαση που θα βελτιωθεί αργότερα χειροκίνητα: η εφαρμογή μπορεί να αποθηκεύσει τις ίδιες βοηθητικές γραμμές ευθυγράμμισης που πρέπει να ακολουθήσουν οι δημιουργοί όταν προσθέτουν ή μετακινούν περιεχόμενο.

Οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας, όχι περιεχόμενο διαφάνειας. Δεν εμφανίζονται σε μια παρουσίαση ή στο παραγόμενο αποτέλεσμα. Το Aspose.Slides for Python via Java τις εκθέτει μέσω της κλάσης [DrawingGuidesCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguidescollection/). Μια οδηγία αντιπροσωπεύεται από το [DrawingGuide](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguide/) και έχει προσανατολισμό, θέση και χρώμα.

Η θέση μετράται σε σημεία από την επάνω αριστερή γωνία της αντίστοιχης διαφάνειας ή του master. Μια κατακόρυφη οδηγία χρησιμοποιεί μια οριζόντια συντεταγμένη, συνήθως μεταξύ του μηδενός και του πλάτους της διαφάνειας. Μια οριζόντια οδηγία χρησιμοποιεί μια κατακόρυφη συντεταγμένη, συνήθως μεταξύ του μηδενός και του ύψους της διαφάνειας.

## **Προσθήκη Οδηγών στην Προβολή Διαφάνειας**

Χρησιμοποιήστε το [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/el/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) για τη διαχείριση των οδηγιών που εμφανίζονται κατά την επεξεργασία κανονικών διαφανειών. Καλέστε το [DrawingGuidesCollection.add](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguidescollection/#add) με μια τιμή [Orientation](https://reference.aspose.com/slides/el/python-java/aspose.slides/orientation/) και μια θέση σε σημεία.

Το παρακάτω παράδειγμα προσθέτει μία κατακόρυφη οδηγία δεξιά από το κέντρο της διαφάνειας και μία οριζόντια οδηγία κάτω από αυτήν:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση στις Οδηγίες Σχεδίασης**

Οι μέθοδοι [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguidescollection/#getCount) και [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguidescollection/#get_Item) παρέχουν πρόσβαση στις υπάρχουσες οδηγίες. Οι μέθοδοι [DrawingGuide.getOrientation](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguide/#getPosition) και [DrawingGuide.getColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguide/#getColor) επιστρέφουν τιμές που μπορούν επίσης να αλλάξουν μέσω των αντίστοιχων μεθόδων ορισμού.

Το παρακάτω παράδειγμα διαβάζει τις οδηγίες προβολής διαφάνειας από την παρουσίαση που δημιουργήθηκε παραπάνω:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Προσθήκη Οδηγών σε Master και Διαφάνειες Διάταξης**

Ένα master διαφάνειας και καθεμία από τις διαφάνειες διάταξης του μπορεί να έχει τις δικές του συλλογές οδηγιών σχεδίασης. Χρησιμοποιήστε το [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/#getDrawingGuides) για μια master διαφάνειας και το [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/#getDrawingGuides) για μια διαφάνεια διάταξης.

Το παρακάτω παράδειγμα προσθέτει μία κατακόρυφη οδηγία στην πρώτη master διαφάνεια και μία οριζόντια οδηγία στην πρώτη διαφάνεια διάταξης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσθήκη Οδηγών σε Masters Σημειώσεων και Εκτυπώσιμων**

Τα masters σημειώσεων και τα masters εκτυπώσιμων επίσης υποστηρίζουν οδηγίες σχεδίασης. Χρησιμοποιήστε τα [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/el/python-java/aspose.slides/masternotesslide/#getDrawingGuides) και [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) για πρόσβαση στις συλλογές τους. Εάν μια παρουσίαση δεν περιέχει κάποιο από αυτά τα masters, η μέθοδος `MasterNotesSlideManager.setDefaultMasterNotesSlide` ή `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` δημιουργεί το προεπιλεγμένο master και το επιστρέφει.

Το παρακάτω παράδειγμα προσθέτει μία οριζόντια οδηγία σε ένα master σημειώσεων και μία κατακόρυφη οδηγία σε ένα master εκτυπώσιμων:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Καθαρισμός Οδηγών Σχεδίασης**

Καλέστε το [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguidescollection/#clear) για να αφαιρέσετε κάθε οδηγία από μια συγκεκριμένη συλλογή. Ο καθαρισμός μιας συλλογής δεν επηρεάζει τις οδηγίες που είναι αποθηκευμένες σε άλλη εστία.

Το παρακάτω παράδειγμα καθαρίζει τις οδηγίες προβολής διαφάνειας και όλες τις οδηγίες στα masters διαφάνειας, τις διαφάνειες διάταξης, το master σημειώσεων και το master εκτυπώσιμων χωρίς να δημιουργήσει ελλείποντα masters:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Εμφανίζονται οι οδηγίες σχεδίασης σε παρουσίαση ή σε εξαγώμενες εικόνες;**

Όχι. Οι οδηγίες σχεδίασης είναι βοηθήματα ευθυγράμμισης για την επεξεργασία και δεν αποδίδονται ως περιεχόμενο παρουσίασης.

**Μπορεί μια οδηγία σχεδίασης να προστεθεί απευθείας σε μια μεμονωμένη κανονική διαφάνεια;**

Οι οδηγίες επεξεργασίας κανονικής διαφάνειας αποθηκεύονται στις ιδιότητες προβολής διαφάνειας της παρουσίασης. Ξεχωριστές συλλογές οδηγιών είναι διαθέσιμες για τα masters διαφάνειας, τις διαφάνειες διάταξης, τα masters σημειώσεων και τα masters εκτυπώσιμων.

**Ποιοι μονάδες χρησιμοποιούνται για τις θέσεις των οδηγιών;**

Οι θέσεις καθορίζονται σε σημεία, όπου 72 σημεία ισοδυναμούν με μία ίντσα. Οι κατακόρυφες θέσεις μετριούνται από την αριστερή άκρη, και οι οριζόντιες θέσεις μετριούνται από την επάνω άκρη.

**Καθαρίζοντας τις οδηγίες σχεδίασης αφαιρούνται σχήματα ή αλλάζει το περιεχόμενο της διαφάνειας;**

Όχι. Η μέθοδος [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/drawingguidescollection/#clear) αφαιρεί μόνο τις οδηγίες στη выбранη συλλογή. Τα σχήματα και το υπόλοιπο περιεχόμενο της διαφάνειας παραμένουν αμετάβλητα.