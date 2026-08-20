---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Πλαίσιο εικόνας
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
- εικόνα raster
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

Ένα πλαίσιο εικόνας είναι σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: μια [Παρουσίαση](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω του [ImageCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagecollection/), ενώ ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτός ο χωρισμός είναι χρήσιμος όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας όταν δημιουργείτε πλαίσια εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραδερ εικόνες όπως PNG ή JPEG και διανυσματικές SVG εικόνες. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος του αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, έτσι είναι χρήσιμο να αποφασίσετε πώς πρέπει να αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, έτσι η παρουσίαση παραμένει αυτόνομα όταν μεταφερθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια PNG εικόνα, δημιουργεί ένα πλαίσιο στις εγγενείς διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

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

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόψετε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση σχετικής κλίμακας**

[PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο μέσω των [setRelativeScaleWidth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Μια τιμή `1.0` αντιστοιχεί στο 100% του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τις τελικές διαστάσεις χειροκίνητα.

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

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και κατά συνέπεια είναι η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική θέση μέσω της μεθόδου [Picture.setLinkPathLong](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) αντί να ενσωματώνει τα δεδομένα εικόνας με το ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα δεδομένων εικόνας που αποθηκεύεται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα μπορεί να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να σταλούν μέσω email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το συνδέει με ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμιγνύεται σε αυτό το παράδειγμα.

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

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως υποκατάστατο συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτόνομη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξάγετε μια εικόνα από μια υπάρχουσα παρουσίαση, ελέγξτε ότι το σχήμα είναι πράγματι ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας μπορεί να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ραδερ εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί απευθείας το [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/). Το παρακάτω παράδειγμα εντοπίζει την πρώτη ενσωματωμένη ραδερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

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

Η αποθήκευση μέσω του [IImage.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/#save) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που αποθηκεύονται στην παρουσίαση αντί για ένα μετατραπείσες ραδερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG εικόνας**

Για μια SVG εικόνα, το [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) εκθέτει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG απευθείας αντί να ραδερ ορίσετε πρώτα την εικόνα.

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

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι ραδερ εξαγωγές όπως PNG ή JPEG αναγκαστικά αποδίδουν αυτό το διανυσματικό περιεχόμενο σε pixel. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης λειτουργία απόδοσης, έτσι τα εξαχθέντα γραφικά δεν πρέπει να θεωρούνται ακριβή αντιγραφή byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του [SvgImage.getSvgData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/#getSvgData--) όταν απαιτείται ο ίδιος ο διανυσματικός πόρος.

## **Περικοπή εικόνας**

Η περικοπή αλλάζει ποιο τμήμα μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή αρχικά δεν διαγράφει τα κρυμμένα pixel από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

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

Επειδή τα κρυμμένα δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να αλλάξει αργότερα χωρίς απώλεια των αρχικών pixel. Εάν το μέγεθος του αρχείου έχει μεγαλύτερη σημασία από την αντιστροφησιμότητα, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων περικομμένης εικόνας**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) αφαιρεί δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά είναι μια καταστροφική βελτιστοποίηση: αφού η παρουσίαση αποθηκευθεί, τα αφαιρεθέντα pixel δεν είναι πλέον διαθέσιμα για μεταγενέστερη άνετη επαναφορά.

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

Η μέθοδος μπορεί να προσθέσει έναν νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο τους, έτσι η διαγραφή περικομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραδερώνει το αποτέλεσμα σε PNG.

## **Συμπίεση ραδερ εικόνων**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) μειώνει την ανάλυση ραδερ εικόνας σε σχέση με το μέγεθος κατά το οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα έχει επαναμεγεθύνει ή περικοπεί και `false` όταν δεν απαιτήθηκε καμία αλλαγή.

Χρησιμοποιήστε μια προκαθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturescompression/) όταν μια τυπική στοχευμένη ανάλυση είναι επαρκής:

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

Μπορεί επίσης να παραπεμφθεί μια προσαρμοσμένη θετική τιμή DPI αντί για προκαθορισμένη τιμή όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραδερ εικόνες. Το περιεχόμενο SVG και των μεταβαλλόμενων αρχείων δεν μειώνεται από αυτή τη διαδικασία ραδερ συμπίεσης. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες περικομμένες περιοχές δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε μια στοχευμένη ανάλυση βάσει του μεγαλύτερου μεγέθους στο οποίο η εικόνα θα προβληθεί ή θα εξάγεται πραγματικά, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Έλεγχος εφέ εικόνας**

Τα εφέ εικόνας αποθηκεύονται στην εικόνα που χρησιμοποιείται από το πλαίσιο. Η συλλογή μετασχηματισμών εικόνας μπορεί να περιέχει εφέ όπως σταθερή διασύνδεση άλφα για διαφάνεια και φωτεινότητα/αντίθεση. Το παρακάτω παράδειγμα διαβάζει με ασφάλεια και τα δύο είδη εφέ από το πρώτο πλαίσιο εικόνας σε μια διαφάνεια:

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
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Αυτά τα εφέ αλλάζουν τον τρόπο απόδοσης της εικόνας στο πλαίσιο· δεν επανεγγράφουν τα αρχικά ενσωματωμένα bytes της εικόνας.

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις του [PictureFrameLock](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας απενεργοποιούνται για ένα πλαίσιο εικόνας. Για παράδειγμα, το [setAspectRatioLocked](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) διατηρεί τις αναλογίες του σχήματος κατά την αλλαγή μεγέθους.

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

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν εξαναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να αλλάξει μόνιμα στο ίδιο αναλογικό λόγο.

## **Ρύθμιση τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι τεντωμένη, οι τιμές stretch‑offset στο [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/) ορίζουν το ορθογώνιο γεμίσματος σε σχέση με το περιθώριο του πλαισίου εικόνας. Θετικά ποσοστά δημιουργούν εσωτερική απόσταση από την άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν εξωτερική απόσταση.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι stretch‑offset αλλάζουν το ορθογώνιο μέσα στο οποίο τεντώνεται το ορατό γεμίσμα εικόνας.

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

Χρησιμοποιήστε stretch‑offset για τοποθέτηση γεμίσματος. Χρησιμοποιήστε τις ιδιότητες περικοπής όταν ο στόχος είναι η απόκρυψη των άκρων της πηγαίας εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και ζητήματα εξαγωγής**

Οι κύριες ανταλλαγές γίνονται πιο εύκολες όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση στην πλευρά του διακομιστή, αλλά μεγάλες ραδερ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμείνουν διαθέσιμα στις αποθηκευμένες διαδρομές ή θέσεις.
- **Περικοπή** είναι αρχικά μη καταστροφική. Τα κρυμμένα pixel παραμένουν ενσωματωμένα μέχρι να διαγραφούν ρητά οι περικομμένες περιοχές ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθη ραδερ εικόνες, αλλά θυσιάζει την ανάλυση πηγής. Θα πρέπει να εφαρμόζεται αφού καθοριστεί το επιθυμητό μέγεθος εμφάνισης στη διαφάνεια.
- **Εικόνες SVG** πρέπει να παραμείνουν ως SVG όταν η διανυσματική διατήρηση είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι ραδερ εξαγωγές διαφανειών μετατρέπουν πάντα τη διαφάνεια σε pixel.
- **Επαναλαμβανόμενες εικόνες** θα πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [PPImage] όταν είναι δυνατόν αντί να φορτώνουν ξανά το ίδιο αρχείο στη ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν εφαρμόζεται επιλεκτικά: κρατήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες σύμφωνα με το πραγματικό μέγεθος προβολής, αφαιρέστε τα περικομμένα pixel μόνο όταν δεν απαιτείται μετέπειτα επεξεργασία και αποφύγετε εξωτερικούς συνδέσμους εκτός αν η διαχείριση εξαρτήσεων είναι μέρος του σχεδιασμού ανάπτυξης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου εικόνας και πόρου εικόνας;**

Ένα [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) αντιπροσωπεύει έναν πόρο εικόνας που σχετίζεται με την παρουσίαση. Ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) είναι ένα σχήμα σε διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώνω ή να συνδέω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή να αποδίδεται χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές θέσεις μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του αρχείου PPTX;**

Δεν το κάνει αυτό από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν τμήματα της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε το [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) ή τη συμπίεση εικόνας με αφαίρεση πεδίου περικοπής όταν αυτά τα pixel μπορούν να διαγραφούν μόνιμα.

**Μπορώ να αποκαταστήσω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραδερ ανάλυση, και η αφαίρεση πεδίων περικοπής διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγαία εικόνα εκτός της παρουσίασης εάν μπορεί να απαιτηθεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να αντιμετωπίζω τις SVG εικόνες;**

Κρατήστε το περιεχόμενο SVG ως SVG όταν η πιστότητα του διανύσματος είναι σημαντική. Το ενσωματωμένο [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε ραδερ μορφή όπως PNG ή JPEG ραδερώνει το SVG ως μέρος της εικόνας της διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπων κατά την ανάγνωση υφιστάμενων διαφανειών;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Έλεγχος `java.instanceOf` έναντι του [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) αποτρέπει μη έγκυρες μετατροπές τύπων και επιτρέπει στον κώδικα να χειρίζεται διαφάνειες που δεν περιέχουν πλαίσια εικόνας.