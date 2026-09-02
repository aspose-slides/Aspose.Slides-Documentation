---
title: Διαχείριση Πλαισίων Εικόνας σε Παρουσιάσεις με JavaScript
linktitle: Πλαίσιο Εικόνας
type: docs
weight: 10
url: /el/nodejs-java/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- ενσωματωμένη εικόνα
- συνδεδεμένη εικόνα
- εξαγωγή εικόνας
- ραστερ εικόνα
- εικόνα SVG
- περικοπή εικόνας
- διαγραφή περικομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, περικόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω του [ImageCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagecollection/), ενώ ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) ελέγχει τη θέση, το μέγεθος, τη διαμόρφωση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διάκριση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας όταν δημιουργείτε πλαίσια εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνες όπως PNG ή JPEG και διανυσματικές SVG εικόνες. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή επηρεάζει τη φορητότητα, το μέγεθος αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, επομένως είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και Μορφοποίηση Ενσωματωμένης Εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με το [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, ώστε η παρουσίαση να παραμένει αυτόνομη όταν μεταφερθεί σε άλλον υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια PNG εικόνα, δημιουργεί ένα πλαίσιο στις φυσικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόπτετε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση Σχετικής Κλίμακας**

[PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο μέσω των [setRelativeScaleWidth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγής εικόνας αντί να υπολογίζει τελικά διαστάσεις χειροκίνητα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ή συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και Συνδεδεμένες Εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας εντός της παρουσίασης και αποτελεί επομένως την πιο ασφαλή επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική διαδρομή μέσω της μεθόδου [Picture.setLinkPathLong](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) αντί να ενσωματώνει τα δεδομένα εικόνας με την ίδια μορφή.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν το ποσό των δεδομένων εικόνας που αποθηκεύεται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμείνει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος είναι μη διαθέσιμος, η συνδεδεμένη εικόνα ενδέχεται να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να σταλούν με email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη Συνδεδεμένης Εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το κατευθύνει σε ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμιγνύεται σε αυτό το παράδειγμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε συνδέσμους όταν η διαχείριση εξωτερικών αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως υποκατάστατο συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτοσυμπιεσμένη παρουσίαση.

## **Εξαγωγή Εικόνων από Πλαίσια Εικόνας**

Πριν εξάγετε μια εικόνα από μια υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πραγματικά ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή Ραστερ Εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί άμεσα το [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/). Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Η αποθήκευση μέσω του [IImage.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/#save) μετατρέπει την εξαγόμενη εικόνα στην ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που είναι αποθηκευμένα στην παρουσίαση αντί για ένα μετατρεπόμενο ραστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG Εικόνας**

Για μια SVG εικόνα, το [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) εκθέτει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα SVG δεδομένα άμεσα αντί να ραστεροποιήσετε την εικόνα πρώτα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Διατηρώντας το περιεχόμενο SVG ως SVG διατηρείτε την διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές ραστερ όπως PNG ή JPEG υποχρεωτικά αποδίδουν αυτό το διανυσματικό περιεχόμενο σε pixel. Η εξαγωγή διαφανειών ως PDF ή SVG αποτελεί επίσης λειτουργία απόδοσης, οπότε τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφο byte‑για‑byte της αρχικής ενσωματωμένης SVG· χρησιμοποιήστε τα δεδομένα [SvgImage.getSvgData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/#getSvgData--) όταν απαιτείται ο αρχικός διανυσματικός πόρος.

## **Περικοπή Εικόνας**

Η περικοπή αλλάζει ποιο μέρος μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/) είναι ποσοστά των διαστάσεων της πηγής εικόνας. Η περικοπή δεν διαγράφει αρχικά τα κρυφά pixel από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει ένα πλαίσιο εικόνας με ασφάλεια και εφαρμόζει τιμές περικοπής:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Επειδή τα κρυφά δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να αλλάξει αργότερα χωρίς απώλεια των αρχικών pixel. Εάν το μέγεθος αρχείου είναι πιο σημαντικό από την αντιστροφή, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση Δεδομένων Περικομμένης Εικόνας**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) αφαιρεί δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρεμένα pixel δεν είναι πλέον διαθέσιμα για μετέπειτα αναιρέση της περικοπής.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Η μέθοδος ενδέχεται να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο, επομένως η διαγραφή περικομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή WMF ή EMF περιεχομένου με αυτήν τη μέθοδο ραστεροποιεί το αποτέλεσμα σε PNG.

## **Συμπίεση Ραστερ Εικόνων**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) μειώνει την ανάλυση ραστερ εικόνας σε σχέση με το μέγεθος στο οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα έχει αλλαγή μεγέθους ή περικοπεί και `false` όταν δεν χρειάστηκε καμία αλλαγή.

Χρησιμοποιήστε μια προεγκατεστημένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturescompression/) όταν επαρκεί μια τυπική στόχευση ανάλυσης:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Μπορείτε επίσης να περάσετε μια προσαρμοσμένη θετική τιμή DPI αντί για προεγκατεστημένη τιμή όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το περιεχόμενο SVG και των μεταφαίδων δεν μειώνεται από αυτήν τη ροή συμπίεσης ραστερ. Επίσης θυμηθείτε ότι η χαμηλότερη ανάλυση και η διαγραφή περικομμένων περιοχών δεν μπορούν να αποκατασταθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης με βάση το μεγαλύτερο μέγεθος στο οποίο η εικόνα θα προβληθεί ή θα εξαγαστεί, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Διαχείριση Εφέ Μετασχηματισμού Εικόνας**

Για πλήρη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, μετασχηματισμούς χρώματος, θόλωση, εφέ άλφα, διαδοχικές αλυσίδες, επιθεώρηση, αφαίρεση και επαλήθευση πλήρους κύκλου, δείτε [Image Transform Effects](/nodejs-java/image-transform-effects/).

## **Κλείδωμα Γεωμετρίας Πλαισίου Εικόνας**

Οι ρυθμίσεις του [PictureFrameLock](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το [setAspectRatioLocked](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) διατηρεί τις αναλογίες του σχήματος κατά την αλλαγή μεγέθους.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να μετατραπεί μόνιμα στην ίδια αναλογία.

## **Προσαρμογή Τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι stretch, οι τιμές stretch‑offset στο [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/) ορίζουν το ορθογώνιο γέμισμα σε σχέση με το περίγραμμα του πλαισίου εικόνας. Τα θετικά ποσοστά δημιουργούν εσωτερική απόσταση από την άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν εξωτερική απόσταση.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο μέρος της πηγής εικόνας είναι ορατό· τα stretch‑offset αλλάζουν το ορθογώνιο στο οποίο το εμφανιζόμενο γέμισμα εικόνας τεντώνεται.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε stretch‑offset για τοποθέτηση γεμίσματος. Χρησιμοποιήστε ιδιότητες περικοπής όταν ο στόχος είναι απόκρυψη ακρών της πηγής εικόνας.

## **Αποθήκευση, Μέγεθος Αρχείου και Σκέψεις Εξαγωγής**

Οι κύριοι συμβιβασμοί είναι πιο εύκολα διαχειρίσιμοι όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση διακομιστή, αλλά οι μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να κρατήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμείνουν προσβάσιμα στις αποθηκευμένες διαδρομές ή θέσεις.
- **Περικοπή** είναι αρχικά μη καταστροφική. Τα κρυφά pixel παραμένουν ενσωματωμένα μέχρι οι περικομμένες περιοχές να διαγραφούν ρητά ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος αρχείου για υπερμεγέθη ραστερ εικόνες, αλλά θυσιάζει την ανάλυση πηγής. Πρέπει να εφαρμοστεί μετά τον καθορισμό του τελικού μεγέθους στην διαφάνεια.
- **SVG εικόνες** πρέπει να παραμένουν SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG άμεσα όταν χρειάζεται ο ίδιος ο διανυσματικός πόρος. Οι ραστερ εξαγωγές διαφανειών μετατρέπουν πάντα τη διαφάνεια σε pixel.
- **Επαναλαμβανόμενες εικόνες** πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) όταν είναι δυνατόν αντί να φορτώνουν ξανά το ίδιο αρχείο στη ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν γίνεται επιλεκτικά: κρατήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες σύμφωνα με το πραγματικό μέγεθός τους, αφαιρέστε περικομμένα pixel μόνο όταν δεν απαιτείται μεταγενέστερη επεξεργασία, και αποφύγετε εξωτερικούς συνδέσμους εκτός αν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδιασμού ανάπτυξης.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου εικόνας και ενός πόρου εικόνας;**

Ένα [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) αντιπροσωπεύει έναν πόρο εικόνας που σχετίζεται με την παρουσίαση. Ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) είναι ένα σχήμα σε μια διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώνω ή να συνδέω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδοθεί χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές τοποθεσίες μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν μέρη της πηγής εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε το [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) ή τη συμπίεση εικόνας με αφαίρεση περικομμένων περιοχών όταν τα pixel μπορούν να διαγραφούν μόνιμα.

**Μπορώ να αποκαταστήσω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση, και η αφαίρεση περικομμένων περιοχών απορρίπτει δεδομένα εικόνας. Διατηρήστε την αρχική πηγή εικόνας εκτός της παρουσίασης εάν μπορεί να χρειαστεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η διανυσματική ακεραιότητα είναι σημαντική. Το ενσωματωμένο [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/) μπορεί να εξαχθεί άμεσα. Η απόδοση μιας διαφάνειας σε ραστερ μορφή όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπων κατά την ανάγνωση υφιστάμενων διαφανειών;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Μια έλεγχος `java.instanceOf` έναντι του [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) αποτρέπει μη έγκυρες μετατροπές τύπων και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.