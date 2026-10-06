---
title: Διαχείριση SmartArt σε παρουσιάσεις PowerPoint χρησιμοποιώντας JavaScript
linktitle: Διαχείριση SmartArt
type: docs
weight: 10
url: /el/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Κείμενο SmartArt
- Τύπος διάταξης
- Κρυφή ιδιότητα
- Διάγραμμα οργάνωσης
- Διάγραμμα οργάνωσης με εικόνα
- PowerPoint
- Παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε να δημιουργείτε και να επεξεργάζεστε SmartArt PowerPoint με Aspose.Slides για Node.js χρησιμοποιώντας σαφή παραδείγματα κώδικα JavaScript που επιταχύνουν το σχεδιασμό διαφανειών και την αυτοματοποίηση."
---
## **Επισκόπηση**

Το SmartArt είναι ένα διάγραμμα PowerPoint που αποτελείται από κόμβους, σχήματα κόμβων και διάταξη. Με το Aspose.Slides για Node.js μέσω Java, μπορείτε να δημιουργήσετε SmartArt, να διαβάσετε κείμενο από τους κόμβους του, να αλλάξετε τη διάταξή του, να ελέγξετε κρυφούς κόμβους, να διαμορφώσετε διατάξεις διαγραμμάτων οργάνωσης και να δημιουργήσετε διαγράμματα οργάνωσης με εικόνες.

## **Λήψη κειμένου από αντικείμενο SmartArt**

Ένας κόμβος SmartArt μπορεί να περιέχει ένα ή περισσότερα σχήματα. Για να διαβάσετε κείμενο από τα σχήματα του κόμβου, επαναλάβετε μέσω του [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), κατόπιν διαβάστε το [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) που επιστρέφεται από το [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

Το παράδειγμα απαιτεί μια παρουσίαση με τουλάχιστον μία διαφάνεια και ένα αντικείμενο SmartArt ως το πρώτο σχήμα σε αυτή τη διαφάνεια. Εκτυπώνει κάθε διαθέσιμο πλαίσιο κειμένου στην κονσόλα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **Αλλαγή τύπου διάταξης αντικειμένου SmartArt**

Η διάταξη SmartArt ελέγχει πώς τακτοποιούνται και συνδέονται οι κόμβοι. Το παρακάτω παράδειγμα δημιουργεί ένα αντικείμενο SmartArt με την τιμή `BasicBlockList` του [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/), το αλλάζει στην τιμή `BasicProcess` και αποθηκεύει την παρουσίαση. Η θέση και το μέγεθος που περνούν στο [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) μετρώνται σε σημεία. Χρησιμοποιήστε το [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) για να αλλάξετε τη διάταξη.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος εάν ένας κόμβος SmartArt είναι κρυφός**

Το [SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) υποδεικνύει εάν ο κόμβος είναι κρυφός στο μοντέλο δεδομένων SmartArt. Οι κρυφοί κόμβοι μπορούν να υπάρχουν στη δομή ακόμη και όταν η επιλεγμένη διάταξη δεν τους εμφανίζει ως ορατά στοιχεία του διαγράμματος.

Το παρακάτω παράδειγμα προσθέτει έναν κόμβο σε ένα αντικείμενο SmartArt που χρησιμοποιεί την τιμή `RadialCycle` του [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/), και ελέγχει την κατάστασή του ως κρυφό. Εκτυπώνει ένα μήνυμα εάν ο κόμβος είναι κρυφός και αποθηκεύει το διάγραμμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη ή ορισμός διάταξης οργανωτικού διαγράμματος**

Για διαγράμματα SmartArt που χρησιμοποιούν διάταξη οργανωτικού διαγράμματος, τα [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) και [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) ορίζουν πώς οι θυγατρικοί κόμβοι τακτοποιούνται κάτω από έναν γονικό κόμβο. Για παράδειγμα, μπορείτε να ρυθμίσετε τους θυγατρικούς κόμβους να κρέμονται από αριστερά, δεξιά ή και από τις δύο πλευρές, ανάλογα με το επιλεγμένο [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/).

Το παρακάτω παράδειγμα δημιουργεί ένα οργανωτικό διάγραμμα και ορίζει τη διάταξη για τον πρώτο κόμβο στην τιμή `LeftHanging` του [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/). Ο μηδενικός δείκτης `0` επιλέγει τον πρώτο κορυφαίο κόμβο· οι θυγατρικοί του κόμβοι χρησιμοποιούν την επιλεγμένη διάταξη. Η τροποποιημένη παρουσίαση αποθηκεύεται στη συνέχεια.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Δημιουργία οργανωτικού διαγράμματος με εικόνα**

Ένα οργανωτικό διάγραμμα με εικόνα είναι μια διάταξη SmartArt σχεδιασμένη για διαγράμματα ιεραρχίας που περιλαμβάνουν δεσμευτικά θέσης εικόνων. Χρησιμοποιήστε την τιμή `PictureOrganizationChart` του [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) όταν προσθέτετε το αντικείμενο SmartArt σε μια διαφάνεια. Αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα με δεσμευτικά θέσης εικόνων· δεν γεμίζει τα δεσμευτικά θέσης με εικόνες.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Μετατροπή παλαιών διαγραμμάτων σε ομάδες σχημάτων**

Κατά τη σύγχρονη αναβάθμιση μιας υπάρχουσας παρουσίασης, ενδέχεται να χρειαστεί να ενημερώσετε ένα οργανωτικό διάγραμμα που δημιουργήθηκε αρχικά σε PowerPoint 97–2003. Το Aspose.Slides αντιπροσωπεύει αυτά τα παλιά διαγράμματα ως αντικείμενα [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/). Χρησιμοποιήστε το [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) για να μετατρέψετε ένα διάγραμμα σε ομάδα σχημάτων, ώστε να μπορείτε να επεξεργαστείτε μεμονωμένα οπτικά στοιχεία. Δείτε την [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) για λεπτομέρειες.

Η μετατροπή προσθέτει μια νέα ομάδα στη συλλογή σχημάτων χωρίς να αφαιρεί το αρχικό διάγραμμα. Μετά την επιτυχή μετατροπή, αφαιρέστε το αρχικό με το [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) για να αποφύγετε διπλό περιεχόμενο. Συλλέξτε τα παλιά διαγράμματα σε μια λίστα πριν τα μετατρέψετε, ώστε η προσθήκη και η αφαίρεση σχημάτων να μην διακόπτει την επανάληψη.

Το παρακάτω παράδειγμα ανοίγει μια παρουσίαση, ψάχνει σε κάθε διαφάνεια, μετατρέπει τα διαγράμματα σε ομάδες σχημάτων και αποθηκεύει την ενημερωμένη παρουσίαση ως PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αποθηκευμένη παρουσίαση περιέχει επεξεργάσιμες ομάδες σχημάτων αντί για τα μετατρεπόμενα παλιά διαγράμματα, χωρίς να παραμένουν τα αρχικά διαγράμματα δίπλα τους. Ανοίξτε το PPTX στο PowerPoint για να επεξεργαστείτε μεμονωμένα στοιχεία μέσα σε κάθε ομάδα, όπως το κείμενο, το γέμισμα ή τη θέση τους.

## **Συχνές ερωτήσεις**

**Υποστηρίζει το SmartArt κατοπτρισμό ή αντιστροφή για γλώσσες RTL;**

Ναι. Η μέθοδος [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) αλλάζει την κατεύθυνση του διαγράμματος από αριστερά προς δεξιά σε δεξιά προς αριστερά, ή αντίστροφα, όταν η επιλεγμένη διάταξη SmartArt υποστηρίζει την αντιστροφή.

**Πώς μπορώ να αντιγράψω το SmartArt στην ίδια διαφάνεια ή σε άλλη παρουσίαση διατηρώντας τη μορφοποίηση;**

Μπορείτε να [κλωνοποιήσετε το σχήμα SmartArt](/slides/el/nodejs-java/shape-manipulations/) με το [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) ή να [κλωνοποιήσετε ολόκληρη τη διαφάνεια](/slides/el/nodejs-java/clone-slides/) που περιέχει το SmartArt. Και οι δύο προσεγγίσεις διατηρούν το μέγεθος, τη θέση και τη μορφοποίηση.

**Πώς μπορώ να αποδώσω το SmartArt σε ραστερική εικόνα για προεπισκόπηση ή εξαγωγή στο web;**

[Αποδώστε τη διαφάνεια](/slides/el/nodejs-java/convert-powerpoint-to-png/) ή ολόκληρη την παρουσίαση σε PNG ή JPEG. Το SmartArt αποδίδεται ως μέρος της διαφάνειας.

**Πώς μπορώ να βρω ένα συγκεκριμένο αντικείμενο SmartArt σε μια διαφάνεια αν υπάρχουν πολλά;**

Χρησιμοποιήστε το [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) ή το [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) για να ορίσετε ένα ιδιαίτερο εναλλακτικό κείμενο ή όνομα στο σχήμα SmartArt, αναζητήστε αυτήν την τιμή στο [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), και στη συνέχεια ελέγξτε ότι το αντίστοιχο σχήμα είναι ένα [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).