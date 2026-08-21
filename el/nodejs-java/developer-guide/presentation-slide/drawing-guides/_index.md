---
title: Διαχείριση γραμμών καθοδήγησης σε παρουσιάσεις με JavaScript
linktitle: Γραμμές καθοδήγησης
type: docs
weight: 85
url: /el/nodejs-java/drawing-guides/
keywords:
- γραμμή καθοδήγησης
- οριζόντια γραμμή
- κάθετη γραμμή
- γραμμή ευθυγράμμισης
- προβολή διαφάνειας
- πατρική διαφάνεια
- διαφάνεια διάταξης
- πατρική σημειώσεων
- πατρική εξώφυλλου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσθήκη, πρόσβαση και διαγραφή οριζόντιων και κάθετων γραμμών καθοδήγησης σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Οι γραμμές καθοδήγησης είναι ρυθμιζόμενες οριζόντιες και κάθετες γραμμές που βοηθούν τους χρήστες να ευθυγραμμίζουν τα σχήματα σταθερά κατά την επεξεργασία μιας παρουσίασης στο PowerPoint. Είναι ιδιαίτερα χρήσιμες όταν μια εφαρμογή δημιουργεί μια παρουσίαση που θα βελτιωθεί αργότερα χειροκίνητα: η εφαρμογή μπορεί να αποθηκεύσει τις ίδιες βοηθητικές ευθυγραμμίσεις που πρέπει να ακολουθούν οι συντάκτες κατά την προσθήκη ή τη μετακίνηση περιεχομένου.

Οι γραμμές καθοδήγησης είναι βοηθήματα επεξεργασίας, όχι περιεχόμενο διαφάνειας. Δεν εμφανίζονται σε προβολή παρουσίασης ή σε αποδοθέν έξοδο. Το Aspose.Slides for Node.js via Java τις εκθέτει μέσω της κλάσης [DrawingGuidesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguidescollection/). Μια γραμμή καθοδήγησης αναπαριστάται από το [DrawingGuide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguide/) και έχει προσανατολισμό, θέση και χρώμα.

Η θέση μετράται σε points από την πάνω‑αριστερή γωνία της σχετικής διαφάνειας ή του πατέρα. Μια κάθετη γραμμή χρησιμοποιεί μια οριζόντια συντεταγμένη, συνήθως μεταξύ του μηδενός και του πλάτους της διαφάνειας. Μια οριζόντια γραμμή χρησιμοποιεί μια κατακόρυφη συντεταγμένη, συνήθως μεταξύ του μηδενός και του ύψους της διαφάνειας.

## **Προσθήκη Καθοδηγήσεων στην Προβολή Διαφάνειας**

Χρησιμοποιήστε το [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) για να διαχειριστείτε τις γραμμές που εμφανίζονται κατά την επεξεργασία κανονικών διαφανειών. Καλέστε το [DrawingGuidesCollection.add](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguidescollection/#add) με μια τιμή [Orientation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/orientation/) και μια θέση σε points.

Το παρακάτω παράδειγμα προσθέτει μία κάθετη γραμμή δεξιά από το κέντρο της διαφάνειας και μία οριζόντια γραμμή κάτω από αυτήν:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση σε Καθοδηγήσεις Σχεδίασης**

Οι μέθοδοι [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguidescollection/#getCount) και [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) παρέχουν πρόσβαση σε υπάρχουσες γραμμές. Οι μέθοδοι [DrawingGuide.getOrientation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguide/#getPosition) και [DrawingGuide.getColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguide/#getColor) επιστρέφουν τιμές που μπορούν επίσης να αλλάξουν μέσω των αντίστοιχων μεθόδων setter.

Το παρακάτω παράδειγμα διαβάζει τις γραμμές προβολής διαφάνειας από την παρουσίαση που δημιουργήθηκε παραπάνω:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Καθοδηγήσεων σε Πατρικές και Διαφάνειες Διάταξης**

Μια πατρική διαφάνεια και κάθε μια από τις διαφάνειες διάταξης της μπορούν να έχουν τις δικές τους συλλογές γραμμών καθοδήγησης. Χρησιμοποιήστε το [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) για μία πατρική διαφάνεια και το [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) για μία διαφάνεια διάταξης.

Το παρακάτω παράδειγμα προσθέτει μία κάθετη γραμμή στην πρώτη πατρική διαφάνεια και μία οριζόντια γραμμή στην πρώτη διαφάνεια διάταξης:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Καθοδηγήσεων σε Πατρικές Σημειώσεων και Εξώφυλλου**

Οι πατρικές σημειώσεων και οι πατρικές εξώφυλλου επίσης υποστηρίζουν γραμμές καθοδήγησης. Χρησιμοποιήστε τα [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) και [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) για να πρόσβαλετε τις συλλογές τους. Εάν μια παρουσίαση δεν περιέχει έναν από αυτούς τους πατέρες, το `MasterNotesSlideManager.setDefaultMasterNotesSlide` ή το `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` δημιουργεί τον προεπιλεγμένο πατέρα και τον επιστρέφει.

Το παρακάτω παράδειγμα προσθέτει μία οριζόντια γραμμή σε έναν πατέρα σημειώσεων και μία κάθετη γραμμή σε έναν πατέρα εξώφυλλου:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Καθαρισμός Καθοδηγήσεων Σχεδίασης**

Καλέστε το [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguidescollection/#clear) για να αφαιρέσετε κάθε γραμμή από μια συγκεκριμένη συλλογή. Ο καθαρισμός μιας συλλογής δεν επηρεάζει τις γραμμές που αποθηκεύονται σε άλλη εμβέλεια.

Το παρακάτω παράδειγμα καθαρίζει τις γραμμές προβολής διαφάνειας και όλες τις γραμμές στις πατρικές διαφάνειες, διαφάνειες διάταξης, τον πατέρα σημειώσεων και τον πατέρα εξώφυλλου χωρίς να δημιουργήσει ελλείποντες πατέρες:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Εμφανίζονται οι γραμμές καθοδήγησης σε προβολή παρουσίασης ή σε εξαγόμενες εικόνες;**

Όχι. Οι γραμμές καθοδήγησης είναι βοηθήματα ευθυγράμμισης για την επεξεργασία και δεν αποδίδονται ως περιεχόμενο παρουσίασης.

**Μπορεί μια γραμμή καθοδήγησης να προστεθεί απευθείας σε μια μεμονωμένη κανονική διαφάνεια;**

Οι γραμμές καθοδήγησης επεξεργασίας κανονικής διαφάνειας αποθηκεύονται στις ιδιότητες προβολής διαφάνειας της παρουσίασης. Ξεχωριστές συλλογές οδηγών είναι διαθέσιμες για πατρικές διαφάνειες, διαφάνειες διάταξης, πατρικές σημειώσεων και πατρικές εξώφυλλου.

**Ποια μονάδα χρησιμοποιείται για τις θέσεις των οδηγών;**

Οι θέσεις ορίζονται σε points, όπου 72 points ισοδυναμούν με ένα ίντσο. Οι κάθετες θέσεις μετρώνται από την αριστερή άκρη, και οι οριζόντιες θέσεις μετρώνται από την άνω άκρη.

**Ο καθαρισμός των γραμμών καθοδήγησης αφαιρεί σχήματα ή τροποποιεί το περιεχόμενο της διαφάνειας;**

Όχι. Η μέθοδος [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/drawingguidescollection/#clear) αφαιρεί μόνο τις γραμμές καθοδήγησης στην επιλεγμένη συλλογή. Τα σχήματα και άλλα περιεχόμενα της διαφάνειας παραμένουν αμετάβλητα.