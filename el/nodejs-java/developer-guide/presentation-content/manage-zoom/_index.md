---
title: Διαχείριση Zoom Παρουσίασης σε JavaScript
linktitle: Διαχείριση Zoom
type: docs
weight: 60
url: /el/nodejs-java/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- zoom διαφάνειας
- zoom ενότητας
- zoom περίληψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε το Zoom με Aspose.Slides για Node.js μέσω Java — μεταπηδήστε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Τα Zoom του PowerPoint σάς επιτρέπουν να περιηγηθείτε μεταξύ συγκεκριμένων διαφανειών και ενοτήτων κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides για Node.js μέσω Java, μπορείτε να δημιουργήσετε zoom διαφανειών, ενοτήτων και περιλήψεων και να προσαρμόσετε τις προεπισκοπήσεις, τα περιγράμματα και τις μεταβάσεις τους.

![PowerPoint zoom overview](overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μία διαφάνεια, χρησιμοποιήστε ένα [Summary Zoom](#summary-zoom).
* Για να εμφανίσετε μόνο τις επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Slide Zoom](#slide-zoom).
* Για να εμφανίσετε μόνο μία ενότητα, χρησιμοποιήστε ένα [Section Zoom](#section-zoom).

## **Zoom Διαφάνειας**

Ένα zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να περιηγηθείτε ελεύθερα μεταξύ των διαφανειών σε οποιαδήποτε σειρά επιλέγετε χωρίς να διακόπτετε τη ροή της παρουσίασης. Τα zoom διαφανειών είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε να τα χρησιμοποιήσετε και σε διαφορετικά σενάρια παρουσίασης.

Τα zoom διαφανειών σας επιτρέπουν να εξερευνήσετε σχετικές πληροφορίες από μία ενιαία διαφάνεια επισκόπησης.

![Selecting slides for a slide zoom](slidezoomsel.png)

Για αντικείμενα zoom διαφάνειας, το Aspose.Slides παρέχει την αρίθμηση [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomimagetype/), την κλάση [ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/).

### **Δημιουργία Πλαισίων Zoom**

Χρησιμοποιήστε το [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame) για να τοποθετήσετε συνδέσμους σε μεμονωμένες διαφάνειες σε μια διαφάνεια επισκόπησης. Αυτό το παράδειγμα δημιουργεί δύο διαφάνειες-στόχους με διαφορετικά φόντα και ετικέτες, προσθέτει μια προεπισκόπηση του καθένα στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση ως PPTX. Οι θέσεις και οι διαστάσεις των πλαισίων καθορίζονται σε σημεία.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Δημιουργία Πλαισίων Zoom με Προσαρμοσμένες Εικόνες**

Περάστε μια προσαρμοσμένη εικόνα στη [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame) για να αντικαταστήσετε την προεπιλεγμένη προεπισκόπηση της διαφάνειας-στόχου. Αυτό το παράδειγμα απαιτεί μια τοπική εικόνα, τη φορτώνει με το [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) και τη προσθέτει στην παρουσίαση χρησιμοποιώντας το [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage). Το αποτέλεσμα είναι ένα πλαίσιο που εμφανίζει αυτήν την εικόνα ενώ παραμένει συνδεδεμένο με τη δεύτερη διαφάνεια.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    overviewSlide.getShapes().addZoomFrame(20, 20, 300, 200, slide, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Διαμόρφωση Πλαισίων Zoom**

Αυτό το παράδειγμα προσαρμόζει δύο πλαίσια zoom διαφάνειας. Αναθέτει μια τοπική εικόνα στο πρώτο πλαίσιο μέσω του [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) και δίνει στο δεύτερο πλαίσιο ένα 5‑σημείων, παύση‑τελεία ροζ περίγραμμα μέσω του [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat). Η μεταφορά του `false` στη [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground) κρύβει το φόντο του δεύτερου πλαισίου. Απαιτείται μια τοπική εικόνα για την προσαρμοσμένη προεπισκόπηση· και τα δύο πλαίσια διατηρούν τους στόχους διαφάνειας τους στο αποθηκευμένο PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    let firstZoomFrame = overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    let secondZoomFrame = overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    firstZoomFrame.setZoomImage(previewImage);

    secondZoomFrame.getLineFormat().setWidth(5);
    secondZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 105, 180));
    secondZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    secondZoomFrame.setShowBackground(false);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zoom Ενότητας**

Ένα zoom ενότητας συνδέεται με μια ενότητα στην παρουσίασή σας. Χρησιμοποιήστε το για να επαναλάβετε ένα θέμα ή να δείξετε πώς συνδέονται διάφορα τμήματα της παρουσίασης.

![Selecting a section for a section zoom](seczoomsel.png)

Για αντικείμενα zoom ενότητας, το Aspose.Slides παρέχει την κλάση [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/).

### **Δημιουργία Πλαισίων Zoom Ενότητας**

Δημιουργήστε μια ενότητα με το [SectionCollection.addSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#addSection), στη συνέχεια περάστε την επιστρεφόμενη ενότητα στη [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame). Αυτό το παράδειγμα τοποθετεί ένα zoom ενότητας στην πρώτη διαφάνεια και το συνδέει με μια ενότητα που αρχίζει με μια χρωματιστή διαφάνεια. Η θέση και οι διαστάσεις του πλαισίου ορίζονται σε σημεία, και η παρουσίαση αποθηκεύεται ως PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Δημιουργία Πλαισίων Zoom Ενότητας με Προσαρμοσμένες Εικόνες**

Η υπερφόρτωση εικόνας του [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame) σας επιτρέπει να εμφανίσετε μια προσαρμοσμένη προεπισκόπηση χωρίς να αλλάξετε την προοριστική ενότητα. Αυτό το παράδειγμα απαιτεί μια τοπική εικόνα, η οποία φορτώνεται με το [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) και προστίθεται μέσω του [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage). Η αποθηκευμένη παρουσίαση περιέχει ένα zoom ενότητας στην πρώτη διαφάνεια συνδεδεμένο με τη νεοδημιουργημένη ενότητα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Αλλαγή Στόχου Ενότητας Zoom**

Χρησιμοποιήστε το [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/#setTargetSection) για να ανακατευθύνετε ένα υπάρχον zoom ενότητας χωρίς να το ξαναδημιουργήσετε. Επιλέξτε μια γεμάτη ενότητα από τη συλλογή [Presentation.getSections](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSections) της ίδιας παρουσίασης. Η ανάθεση μιας κενής ενότητας αφήνει αμετάβλητο τον τρέχοντα στόχο, γι’ αυτό ελέγξτε το [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSlidesListOfSection) πριν την ανάθεση. Δείτε το [Διαχείριση Ενοτήτων Διαφάνειας](/slides/el/nodejs-java/slide-section/) για περισσότερα σχετικά με τις ενότητες.

Το παρακάτω παράδειγμα φορτώνει ένα αρχείο παρουσίασης, το οποίο πρέπει να περιέχει πολλαπλές γεμάτες ενότητες, ένα υπάρχον zoom ενότητας με όνομα `Section navigation` και μια ενότητα με το μοναδικό όνομα `Results`. Αναζητά σε όλες τις διαφάνειες το zoom και βρίσκει τον προορισμό με βάση το όνομα αντί για δείκτη συλλογής που μπορεί να αλλάξει όταν οι ενότητες ξαναταξινομούνται. Εάν τα ονόματα δεν είναι μοναδικά, χρησιμοποιήστε το [Section.getSectionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSectionId) για να εντοπίσετε τον προορισμό.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("section-zoom.pptx");
try {
    let zoom = null;
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            const shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.ISectionZoomFrame") && shape.getName() === "Section navigation") {
                zoom = shape;
                break;
            }
        }
        if (zoom != null) {
            break;
        }
    }

    let targetSection = null;
    for (let i = 0; i < presentation.getSections().size(); i++) {
        const section = presentation.getSections().get_Item(i);
        if (section.getName() === "Results") {
            targetSection = section;
            break;
        }
    }

    if (zoom == null || targetSection == null) {
        console.log("The section zoom or destination section was not found.");
    } else if (targetSection.getSlidesListOfSection().size() == 0) {
        console.log("The destination section is empty.");
    } else {
        let currentSection = zoom.getTargetSection();
        console.log("Current section: " + (currentSection == null ? "" : currentSection.getName()));
        zoom.setTargetSection(targetSection);
        presentation.save("section-zoom-updated.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

### **Διαμόρφωση Πλαισίων Zoom Ενότητας**

Αυτό το παράδειγμα μετακινεί και αλλάζει το μέγεθος ενός zoom ενότητας σε 100 × 75 σημεία, αναθέτει μια τοπική εικόνα μέσω του [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) και εφαρμόζει ένα 2.5‑σημείων, παύση‑τελεία καφέ περίγραμμα. Ενεργοποιεί το [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) ώστε να επιστρέφει στη διαφάνεια προέλευσης μετά την ενότητα, απενεργοποιεί το [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground) και ρυθμίζει το [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) σε 1.5 δευτερόλεπτα. Απαιτείται τοπική εικόνα για την προσαρμοσμένη προεπισκόπηση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);

    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    sectionZoomFrame.setZoomImage(previewImage);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    sectionZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    sectionZoomFrame.getLineFormat().setWidth(2.5);

    sectionZoomFrame.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zoom Περίληψης**

Ένα zoom περίληψης παρέχει μια επισκόπηση των ενοτήτων της παρουσίασης. Κατά τη διάρκεια μιας παρουσίασης, μπορείτε να το χρησιμοποιήσετε για να μεταβείτε σε μια ενότητα, να προχωρήσετε γρήγορα ή να επανεξετάσετε ένα θέμα χωρίς να ακολουθήσετε τη σειρά των διαφανειών.

![Selecting sections for a summary zoom](sumzoomsel.png)

Για αντικείμενα zoom περίληψης, το Aspose.Slides παρέχει τις κλάσεις [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/) και [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/) και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/).

### **Δημιουργία Zoom Περίληψης**

Χρησιμοποιήστε το [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSummaryZoomFrame) για να δημιουργήσετε μια επισκόπηση των ενοτήτων της παρουσίασης. Αυτό το παράδειγμα δημιουργεί τέσσερις ενότητες με διαφορετικά φόντα διαφανειών και προσθέτει ένα zoom περίληψης στην πρώτη διαφάνεια. Η θέση και οι διαστάσεις του πλαισίου καθορίζονται σε σημεία, και η προκύπτουσα επισκόπηση αποθηκεύεται σε παρουσίαση PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 3", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 100, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 4", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Προσθήκη και Αφαίρεση Ενότητας Zoom Περίληψης**

Ένα zoom περίληψης αποθηκεύει τα αντικείμενα [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/) του στη συλλογή που επιστρέφει το [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Αυτό το παράδειγμα δημιουργεί μια επισκόπηση δύο ενοτήτων, προσθέτει μια τρίτη ενότητα χρησιμοποιώντας το [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) και αφαιρεί την πρώτη εγγραφή με τη χρήση του [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Η αφαίρεση της εγγραφής διατηρεί αμετάβλητες τις ενότητες της παρουσίασης και τις διαφάνειές τους.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let firstSection = presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let thirdSection = presentation.getSections().addSection("Section 3", slide);

    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(thirdSection);

    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(firstSection);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Διαμόρφωση Ενοτήτων Zoom Περίληψης**

Αυτό το παράδειγμα διαμορφώνει την πρώτη εγγραφή στη συλλογή που επιστρέφει το [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), χρησιμοποιώντας τον μηδενικό δείκτη `0`. Απαιτείται τοπική εικόνα για το [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage), εφαρμόζει ένα 1.5‑σημείων, παύση‑τελεία μαύρο περίγραμμα και ορίζει το [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) σε 1.5 δευτερόλεπτα. Η μεταφορά του `false` στη [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) απενεργοποιεί την αυτόματη επιστροφή στη διαφάνεια περίληψης για αυτήν την εγγραφή.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    let summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    summarySection.setZoomImage(previewImage);
    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    summarySection.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    summarySection.getLineFormat().setWidth(1.5);

    summarySection.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την επιστροφή στη «γονική» διαφάνεια μετά την προβολή του στόχου;**

Ναι. Καλέστε το [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) με `true` για να επιστρέψετε στη διαφάνεια προέλευσης μετά την εμφάνιση του περιεχομένου-στόχου.

**Μπορώ να ρυθμίσω την «ταχύτητα» ή τη διάρκεια της μετάβασης Zoom;**

Ναι. Χρησιμοποιήστε το [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) για να ελέγξετε τη διάρκεια της μετάβασης σε δευτερόλεπτα.

**Υπάρχουν περιορισμοί στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρός περιορισμός που να τεκμηριώνεται στο API. Οι πρακτικοί περιορισμοί εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και τις δυνατότητες του προγράμματος προβολής. Μπορείτε να προσθέσετε πολλά πλαίσια Zoom, αλλά σκεφτείτε το μέγεθος του αρχείου και το χρόνο απόδοσης.