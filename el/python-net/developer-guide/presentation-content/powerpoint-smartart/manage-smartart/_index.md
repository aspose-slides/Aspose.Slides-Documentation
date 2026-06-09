---
title: Διαχείριση SmartArt σε Παρουσιάσεις PowerPoint χρησιμοποιώντας Python
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/python-net/manage-smartart/
keywords:
- SmartArt
- κείμενο από SmartArt
- τύπος διάταξης
- ιδιότητα κρυφής
- οργανωτικό διάγραμμα
- διάγραμμα οργανωτικού με εικόνα
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να επεξεργάζεστε SmartArt PowerPoint με το Aspose.Slides για Python μέσω .NET, χρησιμοποιώντας σαφή παραδείγματα κώδικα που επιταχύνουν το σχεδιασμό διαφανειών και την αυτοματοποίηση."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που δημιουργείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides για Python μέσω .NET, μπορείτε να δημιουργήσετε SmartArt, να διαβάζετε κείμενο από τους κόμβους του, να αλλάζετε τη διάταξή του, να εξετάζετε κρυφούς κόμβους, να διαμορφώνετε διατάξεις οργανωτικών διαγραμμάτων και να δημιουργείτε εικόνες οργανωτικών διαγραμμάτων.

## **Λήψη κειμένου από αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το ορατό κείμενο, διατρέξτε τη συλλογή [SmartArt.all_nodes](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/all_nodes/), και έπειτα διαβάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) που επιστρέφει το [SmartArtShape.text_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **Αλλαγή του τύπου διάταξης ενός αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς διατάσσονται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, την αλλάζει στην τιμή `BASIC_PROCESS` και αποθηκεύει την παρουσίαση.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Έλεγχος εάν κόμβος SmartArt είναι κρυμμένος**

Η μέθοδος [SmartArtNode.is_hidden](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartartnode/is_hidden/) υποδεικνύει εάν ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` και ελέγχει την κατάσταση κρυφότητας του κόμβου.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Λήψη ή ορισμός της διάταξης οργανωτικού διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, το [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) ορίζει πώς οι υποκόμβοι τοποθετούνται κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ορίσετε τους υποκόμβους να κρεμαστές από τα αριστερά, τα δεξιά ή και τα δύο πλάγια, ανάλογα με την επιλεγμένη [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Δημιουργία εικόνας οργανωτικού διαγράμματος**

Ένα οργανωτικό διάγραμμα εικόνας είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν θέσεις εικόνας. Χρησιμοποιήστε την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές ερωτήσεις**

**Υποστηρίζει το SmartArt αντανάκλαση ή αντιστροφή για γλώσσες RTL;**

Ναι. Η ιδιότητα [SmartArt.is_reversed](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/is_reversed/) εναλλάσσει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/python-net/shape-manipulations/) με τη μέθοδο [ShapeCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_clone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/python-net/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς αποδίδω το SmartArt σε εικόνα raster για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/python-net/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια αν υπάρχουν πολλά;**

Ορίστε μια διακριτική τιμή στο [Shape.alternative_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/alternative_text/) ή στο [Shape.name](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/name/) του σχήματος SmartArt, αναζητήστε αυτήν την τιμή στα [Slide.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/shapes/), και στη συνέχεια ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [SmartArt](https://reference.aspose.com/slides/el/python-net/aspose.slides.smartart/smartart/).