---
title: Διαχείριση SmartArt σε Παρουσιάσεις PowerPoint χρησιμοποιώντας JavaScript
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- τύπος διάταξης
- ιδιότητα κρυμμένη
- οργανόγραμμα
- οργανόγραμμα εικόνας
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε να δημιουργείτε και να επεξεργάζεστε SmartArt του PowerPoint με το Aspose.Slides για Node.js χρησιμοποιώντας σαφή παραδείγματα κώδικα JavaScript που επιταχύνουν το σχεδιασμό και την αυτοματοποίηση των διαφανειών."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που αποτελείται από κόμβους, σχήματα κόμβων και μια διάταξη. Με το Aspose.Slides για Node.js μέσω Java, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να ελέγξετε κρυμμένους κόμβους, να ρυθμίσετε διατάξεις οργανωτικών διαγραμμάτων και να δημιουργήσετε εικόνες οργανωτικών διαγραμμάτων.

## **Λήψη Κειμένου από Αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε το ορατό κείμενο, επαναλάβετε μέσω του [SmartArt.getAllNodes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartart/#getAllNodes--), έπειτα διαβάστε το [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) που επιστρέφεται από το [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Αλλαγή Τύπου Διάταξης Αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς οργανώνονται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με τον τύπο [SmartArtLayoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartlayouttype/) τιμή `BasicBlockList`, το αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Εάν Κόμβος SmartArt Είναι Κρυμμένος**

Το [SmartArtNode.isHidden](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartnode/ishidden/) υποδεικνύει εάν ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων SmartArt. Οι κρυμμένοι κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε αντικείμενο SmartArt που χρησιμοποιεί τον τύπο [SmartArtLayoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartlayouttype/) τιμή `RadialCycle` και ελέγχει την κρυμμένη κατάσταση του κόμβου.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη ή Ορισμός Διάταξης Οργανωτικού Διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, τα [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) και [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) ορίζουν πώς διατάσσονται οι θυγατρικοί κόμβοι κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ρυθμίσετε τους θυγατρικούς κόμβους να κρέμονται από την αριστερή, τη δεξιά ή και τις δύο πλευρές, ανάλογα με τον επιλεγμένο [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ρυθμίζει τη διάταξη για τον πρώτο κόμβο στην τιμή [OrganizationChartLayoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Δημιουργία Εικόνας Οργανωτικού Διαγράμματος**

Ένα εικόνα οργανωτικού διαγράμματος είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν πλαίσια εικόνας. Χρησιμοποιήστε την τιμή [SmartArtLayoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το SmartArt κατοπτρισμό ή αντιστροφή για γλώσσες RTL;**

Ναι. Η μέθοδος [SmartArt.setReversed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartart/setreversed/) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή το αντίστροφο, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/nodejs-java/shape-manipulations/) με τη [ShapeCollection.addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/addclone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/nodejs-java/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς μπορώ να αποδώσω το SmartArt σε εικόνα raster για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/nodejs-java/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια αν υπάρχουν πολλά;**

Ορίστε μία διακριτική τιμή στο [Shape.setAlternativeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/setalternativetext/) ή στο [Shape.setName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/setname/) του σχήματος SmartArt, αναζητήστε αυτήν την τιμή στο [BaseSlide.getShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#getShapes), και στη συνέχεια ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartart/).