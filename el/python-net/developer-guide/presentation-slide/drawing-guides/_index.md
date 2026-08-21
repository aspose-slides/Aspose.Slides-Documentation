---
title: Διαχείριση Γραμμών Οδηγίας σε Παρουσιάσεις με Python
linktitle: Γραμμές Οδηγίας
type: docs
weight: 85
url: /el/python-net/drawing-guides/
keywords:
- γραμμή οδηγίας
- οριζόντια γραμμή οδηγίας
- κάθετη γραμμή οδηγίας
- οδηγός ευθυγράμμισης
- προβολή διαφάνειας
- master διαφάνειας
- διάταξη διαφάνειας
- master σημειώσεων
- master φυλλαδίου
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσθήκη, πρόσβαση και εκκαθάριση οριζόντιων και κάθετων γραμμών οδηγίας σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Οι γραμμές οδηγιών είναι ρυθμιζόμενες οριζόντιες και κάθετες γραμμές που βοηθούν τους χρήστες να ευθυγραμμίζουν τα σχήματα με συνέπεια κατά την επεξεργασία μιας παρουσίασης στο PowerPoint. Είναι ιδιαίτερα χρήσιμες όταν μια εφαρμογή δημιουργεί μια παρουσίαση που θα βελτιωθεί αργότερα με μη αυτόματο τρόπο: η εφαρμογή μπορεί να αποθηκεύσει τα ίδια βοηθήματα ευθυγράμμισης που πρέπει να ακολουθούν οι συγγραφείς κατά την προσθήκη ή τη μετακίνηση του περιεχομένου.

Οι γραμμές οδηγιών είναι βοηθήματα επεξεργασίας, όχι περιεχόμενο διαφάνειας. Δεν εμφανίζονται σε παρουσίαση ή στην παραγόμενη έξοδο. Το Aspose.Slides για Python μέσω .NET τις εκθέτει μέσω της διεπαφής [IDrawingGuidesCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/idrawingguidescollection/). Μια γραμμή οδηγίας αναπαρίσταται από το [IDrawingGuide](https://reference.aspose.com/slides/el/python-net/aspose.slides/idrawingguide/) και διαθέτει προσανατολισμό, θέση και χρώμα.

Η θέση μετράται σε points από την επάνω αριστερή γωνία της σχετικής διαφάνειας ή του master. Μία κάθετη γραμμή οδηγίας χρησιμοποιεί μία οριζόντια συντεταγμένη, συνήθως μεταξύ του μηδενός και του πλάτους της διαφάνειας. Μία οριζόντια γραμμή οδηγίας χρησιμοποιεί μία κάθετη συντεταγμένη, συνήθως μεταξύ του μηδενός και του ύψους της διαφάνειας.

## **Προσθήκη Γραμμών Οδηγίας στην Προβολή Διαφάνειας**

Χρησιμοποιήστε το [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/el/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) για να διαχειριστείτε τις γραμμές οδηγιών που εμφανίζονται κατά την επεξεργασία κανονικών διαφανειών. Καλέστε το [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/el/python-net/aspose.slides/idrawingguidescollection/add/) με μια τιμή [Orientation](https://reference.aspose.com/slides/el/python-net/aspose.slides/orientation/) και μια θέση σε points.

Το παρακάτω παράδειγμα προσθέτει μία κάθετη γραμμή οδηγίας δεξιά από το κέντρο της διαφάνειας και μία οριζόντια γραμμή οδηγίας κάτω από αυτήν:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση στις Γραμμές Οδηγίας**

Η ιδιότητα [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/el/python-net/aspose.slides/idrawingguidescollection/count/) και ο δείκτης (indexer) παρέχουν πρόσβαση στις υπάρχουσες γραμμές οδηγίας. Οι ιδιότητες [IDrawingGuide.orientation](https://reference.aspose.com/slides/el/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/el/python-net/aspose.slides/idrawingguide/position/) και [IDrawingGuide.color](https://reference.aspose.com/slides/el/python-net/aspose.slides/idrawingguide/color/) μπορούν να διαβαστούν ή να τροποποιηθούν.

Το παρακάτω παράδειγμα διαβάζει τις γραμμές οδηγιών της προβολής διαφάνειας από την παρουσίαση που δημιουργήθηκε παραπάνω:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Προσθήκη Γραμμών Οδηγίας σε Master και Layout Διαφάνειες**

Ένας master διαφάνειας και κάθε μία από τις διαφάνειες διάταξης του μπορεί να έχει τις δικές του συλλογές γραμμών οδηγίας. Χρησιμοποιήστε το [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasterslide/drawing_guides/) για μια master διαφάνειας και το [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/el/python-net/aspose.slides/ilayoutslide/drawing_guides/) για μια διαφάνεια διάταξης.

Το παρακάτω παράδειγμα προσθέτει μία κάθετη γραμμή οδηγίας στην πρώτη master διαφάνειας και μία οριζόντια γραμμή οδηγίας στην πρώτη διαφάνεια διάταξης:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Προσθήκη Γραμμών Οδηγίας σε Master Σημειώσεων και Handout**

Οι master σημειώσεων και οι master εγχειριδίων υποστηρίζουν επίσης γραμμές οδηγίας. Χρησιμοποιήστε τα [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasternotesslide/drawing_guides/) και [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) για να αποκτήσετε πρόσβαση στις συλλογές τους. Εάν μια παρουσίαση δεν περιέχει κάποιον από αυτούς τους master, το [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) ή το [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) δημιουργεί τον προεπιλεγμένο master και τον επιστρέφει.

Το παρακάτω παράδειγμα προσθέτει μία οριζόντια γραμμή οδηγίας σε ένα master σημειώσεων και μία κάθετη γραμμή οδηγίας σε ένα master εγχειριδίων:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Καθαρισμός Γραμμών Οδηγίας**

Καλέστε το [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/el/python-net/aspose.slides/idrawingguidescollection/clear/) για να αφαιρέσετε κάθε γραμμή οδηγίας από μια συγκεκριμένη συλλογή. Η εκκαθάριση μιας συλλογής δεν επηρεάζει τις γραμμές οδηγίας που είναι αποθηκευμένες σε άλλη περιοχή.

Το παρακάτω παράδειγμα καθαρίζει τις γραμμές οδηγιών της προβολής διαφάνειας και όλες τις γραμμές στους master διαφάνειας, στις διαφάνειες διάταξης, στον master σημειώσεων και στον master εγχειριδίων χωρίς να δημιουργήσει ελλιπείς master:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Εμφανίζονται οι γραμμές οδηγών σε παρουσίαση ή εξαγώμενες εικόνες;**

Όχι. Οι γραμμές οδηγών είναι βοηθήματα ευθυγράμμισης για την επεξεργασία και δεν αποδίδονται ως περιεχόμενο παρουσίασης.

**Μπορεί μια γραμμή οδηγίας να προστεθεί απευθείας σε μια μεμονωμένη κανονική διαφάνεια;**

Οι οδηγίες επεξεργασίας κανονικών διαφανειών αποθηκεύονται στις ιδιότητες προβολής διαφάνειας της παρουσίασης. Διαχωρισμένες συλλογές γραμμών οδηγιών είναι διαθέσιμες για τους master διαφάνειας, τις διαφάνειες διάταξης, τους master σημειώσεων και τους master εγχειριδίων.

**Ποιες μονάδες χρησιμοποιούνται για τις θέσεις των γραμμών οδηγών;**

Οι θέσεις ορίζονται σε points, όπου 72 points ισοδυναμούν με ένα ίντσα. Οι κάθετες θέσεις μετρώνται από την αριστερή άκρη, και οι οριζόντιες θέσεις μετρώνται από την επάνω άκρη.

**Η εκκαθάριση των γραμμών οδηγών αφαιρεί σχήματα ή αλλάζει το περιεχόμενο της διαφάνειας;**

Όχι. Η μέθοδος `clear` αφαιρεί μόνο τις γραμμές οδηγών στην επιλεγμένη συλλογή. Τα σχήματα και το υπόλοιπο περιεχόμενο της διαφάνειας παραμένουν αμετάβλητα.