---
title: Διαχείριση Γραφικών SmartArt σε Παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Γραφικά SmartArt
type: docs
weight: 20
url: /el/nodejs-java/manage-smartart-shape/
keywords:
- Αντικείμενο SmartArt
- Γραφικό SmartArt
- Στυλ SmartArt
- Χρώμα SmartArt
- Δημιουργία SmartArt
- Προσθήκη SmartArt
- Επεξεργασία SmartArt
- Αλλαγή SmartArt
- Πρόσβαση SmartArt
- Τύπος διάταξης SmartArt
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Αυτοματοποιήστε τη δημιουργία, την επεξεργασία και το στυλ των SmartArt στο PowerPoint με JavaScript χρησιμοποιώντας το Aspose.Slides, με σύντομα παραδείγματα κώδικα και οδηγίες προσανατολισμένες στην απόδοση."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να δημιουργείτε και να διαχειρίζεστε γραφικά SmartArt σε παρουσιάσεις PowerPoint προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να προσθέσετε ένα σχήμα SmartArt σε μια διαφάνεια, να αποκτήσετε πρόσβαση σε υπάρχοντα σχήματα SmartArt, να βρείτε SmartArt με συγκεκριμένο τύπο διάταξης και να ενημερώσετε την οπτική του εμφάνιση αλλάζοντας το στυλ SmartArt ή το στυλ χρώματος.

Τα παραδείγματα δείχνουν πώς να εργάζεστε με σχήματα SmartArt μέσω της συλλογής σχημάτων της διαφάνειας παρουσίασης, να ελέγξετε εάν ένα σχήμα είναι SmartArt και στη συνέχεια να τροποποιήσετε ή να εξετάσετε τις ιδιότητέ του.

## **Δημιουργία Σχήματος SmartArt**
Aspose.Slides για Node.js μέσω Java έχει παράσχει ένα API για δημιουργία σχημάτων SmartArt. Για να δημιουργήσετε ένα σχήμα SmartArt σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) .
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. Προσθέστε ένα σχήμα SmartArt [addSmartArt-float-float-float-float-int-](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) ορίζοντας το [LayoutType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArtLayoutType) .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX .

```javascript
// Δημιουργία κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Λήψη πρώτης διαφάνειας
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη σχήματος Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Αποθήκευση παρουσίασης
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt προστέθηκε στη διαφάνεια**|

## **Πρόσβαση σε Σχήμα SmartArt στη Διαφάνεια**
Ο παρακάτω κώδικας θα χρησιμοποιηθεί για την πρόσβαση στα σχήματα SmartArt που προστέθηκαν στη διαφάνεια παρουσίασης. Στον κώδικα δείγματος θα διασχίσουμε κάθε σχήμα μέσα στη διαφάνεια και θα ελέγξουμε αν είναι σχήμα [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt). Εάν το σχήμα είναι τύπου SmartArt τότε θα το μετατρέψουμε σε παρουσία [**SmartArt**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) .

```javascript
// Φόρτωση της επιθυμητής παρουσίασης
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Διάσχιση κάθε σχήματος μέσα στην πρώτη διαφάνεια
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Έλεγχος εάν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Μετατροπή τύπου σχήματος σε SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Πρόσβαση σε Σχήμα SmartArt με Συγκεκριμένο Τύπο Διάταξης**
Ο παρακάτω κώδικας δείγματος θα βοηθήσει στην πρόσβαση στο σχήμα [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) με συγκεκριμένο LayoutType. Παρακαλώ σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν το σχήμα [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) προστεθεί.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt .
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Ελέγξτε το σχήμα SmartArt με τον συγκεκριμένο LayoutType και εκτελέστε ό,τι απαιτείται μετά.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Διάσχιση κάθε σχήματος μέσα στην πρώτη διαφάνεια
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Έλεγχος εάν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Μετατροπή σχήματος σε SmartArtEx
            var smart = shape;
            // Έλεγχος διάταξης SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αλλαγή Στυλ Σχήματος SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αλλάξουμε το γρήγορο στυλ για οποιοδήποτε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt .
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Βρείτε το σχήμα SmartArt με συγκεκριμένο Στυλ.
1. Ορίστε το νέο Στυλ για το σχήμα SmartArt.
1. Αποθηκεύστε την Παρουσίαση.

```javascript
// Δημιουργία κλάσης Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    var slide = pres.getSlides().get_Item(0);
    // Διάσχιση κάθε σχήματος μέσα στην πρώτη διαφάνεια
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Έλεγχος εάν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Μετατροπή σχήματος σε SmartArtEx
            var smart = shape;
            // Έλεγχος στυλ SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Αλλαγή στυλ SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Αποθήκευση παρουσίασης
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt με αλλαγμένο Στυλ**|

## **Αλλαγή Στυλ Χρώματος Σχήματος SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αλλάξουμε το στυλ χρώματος για οποιοδήποτε σχήμα SmartArt. Στον παρακάτω κώδικα δείγματος θα αποκτήσουμε πρόσβαση στο σχήμα SmartArt με συγκεκριμένο στυλ χρώματος και θα το αλλάξουμε.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt .
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε αν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Βρείτε το σχήμα SmartArt με συγκεκριμένο Στυλ Χρώματος.
1. Ορίστε το νέο Στυλ Χρώματος για το σχήμα SmartArt.
1. Αποθηκεύστε την Παρουσίαση.

```javascript
// Δημιουργία κλάσης Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    var slide = pres.getSlides().get_Item(0);
    // Διάσχιση κάθε σχήματος μέσα στην πρώτη διαφάνεια
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Έλεγχος εάν το σχήμα είναι τύπου SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Μετατροπή σχήματος σε SmartArtEx
            var smart = shape;
            // Έλεγχος τύπου χρώματος SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Αλλαγή τύπου χρώματος SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Αποθήκευση παρουσίασης
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt με αλλαγμένο Στυλ Χρώματος**|

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να δημιουργήσω κινούμενα εφέ για το SmartArt ως ένα ενιαίο αντικείμενο;**

Ναι. Το SmartArt είναι σχήμα, οπότε μπορείτε να εφαρμόσετε [τυπικές κινήσεις](/slides/el/nodejs-java/powerpoint-animation/) μέσω του API κινήσεων (είσοδος, έξοδος, τονισμό, διαδρομές κίνησης) όπως και για άλλα σχήματα.

**Πώς μπορώ να βρω ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν δεν γνωρίζω το εσωτερικό του ID;**

Ορίστε και χρησιμοποιήστε το Εναλλακτικό Κείμενο (AltText) και αναζητήστε το σχήμα με αυτήν την τιμή — αυτή είναι η προτεινόμενη μέθοδος για τον εντοπισμό του στοχευμένου σχήματος.

**Μπορώ να ομαδοποιήσω το SmartArt με άλλα σχήματα;**

Ναι. Μπορείτε να ομαδοποιήσετε το SmartArt με άλλα σχήματα (εικόνες, πίνακες κ.λπ.) και στη συνέχεια να [χειριστείτε την ομάδα](/slides/el/nodejs-java/group/).

**Πώς μπορώ να λάβω μια εικόνα ενός συγκεκριμένου SmartArt (π.χ., για προεπισκόπηση ή αναφορά);**

Εξάγετε μια μικροεπισκόπηση/εικόνα του σχήματος· η βιβλιοθήκη μπορεί να [αποδώσει μεμονωμένα σχήματα](/slides/el/nodejs-java/create-shape-thumbnails/) σε αρχεία raster (PNG/JPG/TIFF).

**Θα διατηρηθεί η εμφάνιση του SmartArt όταν μετατρέπω ολόκληρη την παρουσίαση σε PDF;**

Ναι. Η μηχανή απόδοσης στοχεύει σε υψηλή πιστότητα για την [εξαγωγή PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), με μια σειρά από επιλογές ποιότητας και συμβατότητας.