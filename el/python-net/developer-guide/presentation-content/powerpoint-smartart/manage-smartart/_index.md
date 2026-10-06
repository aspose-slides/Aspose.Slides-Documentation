---
title: Διαχείριση SmartArt σε Παρουσιάσεις PowerPoint με χρήση Python
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/python-net/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- Τύπος διάταξης
- Κρυφή ιδιότητα
- Διάγραμμα οργάνωσης
- Διάγραμμα οργάνωσης με εικόνα
- PowerPoint
- Παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να επεξεργάζεστε SmartArt σε PowerPoint με Aspose.Slides για Python μέσω .NET χρησιμοποιώντας σαφή παραδείγματα κώδικα που επιταχύνουν το σχεδιασμό διαφανειών και την αυτοματοποίηση."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που δημιουργείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides για Python μέσω .NET, μπορείτε να δημιουργήσετε SmartArt, να διαβάζετε κείμενο από τους κόμβους του, να αλλάζετε τη διάταξή του, να ελέγχετε κρυφά κόμβους, να διαμορφώνετε διατάξεις διαγραμμάτων οργάνωσης και να δημιουργείτε διαγράμματα οργάνωσης με εικόνες.

## **Ανάγνωση κειμένου από αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το κείμενο από τα σχήματα του κόμβου, επαναλάβετε τη διαδρομή μέσω [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), στη συνέχεια διαβάστε το [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) που επιστρέφεται από το [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

Το παράδειγμα απαιτεί μια παρουσίαση με τουλάχιστον μία διαφάνεια και ένα αντικείμενο SmartArt ως το πρώτο σχήμα σε αυτή τη διαφάνεια. Εκτυπώνει κάθε διαθέσιμο πλαίσιο κειμένου στην κονσόλα.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **Αλλαγή τύπου διάταξης αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς οργανώνονται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή `BASIC_BLOCK_LIST` του [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/), την αλλάζει στην τιμή `BASIC_PROCESS` και αποθηκεύει την παρουσίαση. Η θέση και το μέγεθος που περνούν στο [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) μετρώνται σε σημεία. Ορίστε το [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) για να αλλάξετε τη διάταξη.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Έλεγχος αν ένας κόμβος SmartArt είναι κρυφός**

Το [SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) υποδεικνύει εάν ο κόμβος είναι κρυφός στο μοντέλο δεδομένων του SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή `RADIAL_CYCLE` του [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) και ελέγχει την κατάσταση κρυφότητας του προστεθέντος κόμβου. Εκτυπώνει ένα μήνυμα εάν ο κόμβος είναι κρυφός και αποθηκεύει το διάγραμμα.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Λήψη ή ορισμός της διάταξης διαγράμματος οργάνωσης**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη διαγράμματος οργάνωσης, το [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) καθορίζει πώς διατάσσονται οι θυγατρικοί κόμβοι κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ρυθμίσετε τους θυγατρικούς κόμβους να κρέμονται από αριστερά, δεξιά ή και τις δύο πλευρές, ανάλογα με τον επιλεγμένο [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα οργάνωσης και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή `LEFT_HANGING` του [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/). Ο μηδενικής βάσης δείκτης `0` επιλέγει τον πρώτο κόμβο του ανώτατου επιπέδου· οι θυγατρικοί του κόμβοι χρησιμοποιούν την επιλεγμένη διάταξη. Η τροποποιημένη παρουσίαση αποθηκεύεται στη συνέχεια.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Δημιουργία διαγράμματος οργάνωσης με εικόνα**

Ένα διάγραμμα οργάνωσης με εικόνα είναι μια διάταξη SmartArt σχεδιασμένη για ιεραρχικά διαγράμματα που περιλαμβάνουν θέση για εικόνες. Χρησιμοποιήστε την τιμή `PICTURE_ORGANIZATION_CHART` του [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια. Αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα με θέσεις εικόνων· δεν γεμίζει τις θέσεις με πραγματικές εικόνες.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Μετατροπή παλαιών διαγραμμάτων σε ομάδες σχημάτων**

Κατά τον εκσυγχρονισμό μιας υπάρχουσας παρουσίασης, μπορεί να χρειαστεί να ενημερώσετε ένα διάγραμμα οργάνωσης που δημιουργήθηκε αρχικά σε PowerPoint 97–2003. Το Aspose.Slides αντιπροσωπεύει αυτά τα παλαιά διαγράμματα ως αντικείμενα [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Χρησιμοποιήστε το [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) για να μετατρέψετε ένα διάγραμμα σε μια ομάδα σχημάτων ώστε να μπορείτε να επεξεργαστείτε μεμονωμένα οπτικά στοιχεία. Δείτε την [Καταγραφή API του LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) για λεπτομέρειες.

Η μετατροπή προσθέτει μια νέα ομάδα στη συλλογή σχημάτων χωρίς να αφαιρέσει το αρχικό διάγραμμα. Μετά την επιτυχή μετατροπή, αφαιρέστε το αρχικό χρησιμοποιώντας το [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) για να αποφύγετε διπλό περιεχόμενο. Συλλέξτε τα παλαιά διαγράμματα σε μια λίστα πριν τα μετατρέψετε, ώστε η προσθήκη και αφαίρεση σχημάτων να μην διαταράσσει την επανάληψη.

Το παρακάτω παράδειγμα ανοίγει μια παρουσίαση, ψάχνει σε κάθε διαφάνεια, μετατρέπει τα διαγράμματα σε ομάδες σχημάτων και αποθηκεύει την ενημερωμένη παρουσίαση ως PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

Η αποθηκευμένη παρουσίαση περιέχει επεξεργάσιμες ομάδες σχημάτων στη θέση των μετατρεπόμενων παλαιών διαγραμμάτων, χωρίς κανένα αρχικό διάγραμμα να παραμένει. Ανοίξτε το PPTX στο PowerPoint για να επεξεργαστείτε μεμονωμένα στοιχεία μέσα σε κάθε ομάδα, όπως το κείμενο, το γέμισμα ή τη θέση τους.

## **Συχνές ερωτήσεις**

**Υποστηρίζει το SmartArt την αλλαγή κατεύθυνσης ή την ανάστροφη για γλώσσες RTL;**

Ναι. Η ιδιότητα [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την ανάστροφη.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/python-net/shape-manipulations/) με το [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/python-net/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς μπορώ να αποδώσω το SmartArt σε εικόνα raster για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/python-net/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια εάν υπάρχουν πολλά;**

Ορίστε μια χαρακτηριστική τιμή στο [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) ή στο [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) του σχήματος SmartArt, ψάξτε για αυτή τη τιμή στα [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), και στη συνέχεια ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).