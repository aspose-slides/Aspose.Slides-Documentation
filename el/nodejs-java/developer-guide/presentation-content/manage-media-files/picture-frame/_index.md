---
title: Διαχειριστείτε Πλαισία Εικόνας σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
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
- SVG εικόνα
- κοπή εικόνας
- διαγραφή κομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακας
- εφέ εικόνας
- αναλογία διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, κόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) διαθέτει ενσωματωμένους πόρους εικόνας μέσω του [ImageCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagecollection/), ενώ ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την κοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διάσπαση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας όταν δημιουργείτε πλαίσια εικόνας.

Τα πλαίσια εικόνας μπορούν να περιλαμβάνουν ραστές εικόνες όπως PNG ή JPEG και διανυσματικές εικόνες SVG. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή επηρεάζει τη φορητότητα, το μέγεθος του αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, επομένως είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και Μορφοποίηση Ενσωματωμένης Εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, ώστε η παρουσίαση να διατηρείται αυτόνομη όταν μεταφερθεί σε υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια εικόνα PNG, δημιουργεί ένα πλαίσιο στις φυσικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

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

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που είναι αποθηκευμένες στο ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν επεξεργάζεστε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση Σχετικού Κλίμακας**

[PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο μέσω [setRelativeScaleWidth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τελικά διαστάσεις χειροκίνητα.

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

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματώνει ή συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και Συνδεδεμένες Εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και αποτελεί επομένως την πιο ασφαλή επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική τοποθεσία μέσω της μεθόδου [Picture.setLinkPathLong](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) αντί να ενσωματώνει τα δεδομένα της εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα δεδομένων εικόνας που αποθηκεύεται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν αλλάξει η διαδρομή, μετακινηθεί το αρχείο ή ο πόρος γίνει μη διαθέσιμος, η συνδεδεμένη εικόνα ενδέχεται να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να αποσταλούν μέσω email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη Συνδεδεμένης Εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το κατευθύνει σε τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και δεν έχει ενσωματωθεί σκόπιμα σε αυτό το παράδειγμα.

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

Χρησιμοποιήστε συνδέσεις όταν η διαχείριση εξωτερικών αρχείων είναι σκόπιμη. Μην τις χρησιμοποιείτε μόνο ως αντικατάσταση συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μία μεγαλύτερη, αυτόνομη παρουσίαση.

## **Εξαγωγή Εικόνων από Πλαίσια Εικόνας**

Πριν εξαγάγετε μια εικόνα από μια υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πραγματικά ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

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

Η αποθήκευση μέσω [IImage.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/#save) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που είναι αποθηκευμένα στην παρουσίαση αντί για ένα μετασχηματισμένο ραστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG Εικόνας**

Για μια SVG εικόνα, το [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) εκθέτει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG άμεσα αντί να ραστεροποιήσετε πρώτα την εικόνα.

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

Η διατήρηση του περιεχομένου SVG ως SVG διαφυλάσσει την διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές σε ραστερ όπως PNG ή JPEG απαραίτητα αποδίδουν αυτό το διανυσματικό περιεχόμενο σε pixel. Η εξαγωγή διαφάνειας σε PDF ή SVG αποτελεί επίσης διαδικασία απόδοσης, οπότε τα εξαγώμενα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφα byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα [SvgImage.getSvgData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/#getSvgData--) όταν απαιτείται ο ίδιος ο πόρος διανύσματος.

## **Κοπή Εικόνας**

Η κοπή αλλάζει ποιο τμήμα της εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές κοπής στο [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η κοπή δεν διαγράφει αρχικά τα κρυφά pixel από την ενσωματωμένη εικόνα· απλώς αλλάζει την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει με ασφάλεια ένα πλαίσιο εικόνας και εφαρμόζει τιμές κοπής:

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

Καθώς τα κρυφά δεδομένα εικόνας παραμένουν, η κοπή μπορεί να αλλάξει αργότερα χωρίς να χαθούν τα αρχικά pixel. Εάν το μέγεθος του αρχείου είναι πιο σημαντικό από την αντιστροφικότητα, οι κομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση Δεδομένων Κομμένης Εικόνας**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου κοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά είναι μια καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρεμένα pixel δεν είναι πλέον διαθέσιμα για μετέπειτα αποκόπωση.

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

Η μέθοδος μπορεί να προσθέσει έναν νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο, οπότε η διαγραφή των κομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η κοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεροποιεί το κομμένο αποτέλεσμα σε PNG.

## **Συμπίεση Ραστερ Εικόνων**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) μειώνει την ανάλυση της ραστερ εικόνας σε σχέση με το μέγεθος με το οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει κομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα έχει αλλαγεί μέγεθος ή κοπεί και `false` όταν δεν ήταν απαραίτητη καμία αλλαγή.

Χρησιμοποιήστε μια προορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturescompression/) όταν μια τυπική ανάλυση στόχου είναι επαρκής:

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

Μια προσαρμοσμένη θετική τιμή DPI μπορεί να περαστεί αντί για προορισμένη τιμή όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το περιεχόμενο SVG και Μεταφίλων δεν μειώνεται από αυτή τη ροή συμπίεσης ραστερ. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες κομμένες περιοχές δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε ανάλυση στόχου με βάση το μεγαλύτερο μέγεθος στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί πραγματικά, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Διαχείριση Εφέ Μετασχηματισμού Εικόνας**

Για πλήρη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, χρωματικούς μετασχηματισμούς, θόλωση, εφέ άλφα, αλυσίδες, έλεγχο, αφαίρεση και επαλήθευση κύκλου ζωής, δείτε [Image Transform Effects](/slides/el/nodejs-java/image-transform-effects/).

## **Κλείδωμα Γεωμετρίας Πλαισίου Εικόνας**

Οι ρυθμίσεις [PictureFrameLock](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το [setAspectRatioLocked](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) διατηρεί τις αναλογίες του σχήματος ενώ αλλάζει μέγεθος.

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

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματωθεί ή να αλλάξει μόνιμα στην ίδια αναλογία.

## **Προσαρμογή Τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι τέντωμα, οι τιμές stretch‑offset στο [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/) ορίζουν το γεωμετρικό ορθογώνιο γεμίσματος σε σχέση με το περίγραμμα του πλαισίου εικόνας. Θετικά ποσοστά δημιουργούν εσοχή από την άκρη, ενώ αρνητικά ποσοστά δημιουργούν προεξοχή.

Αυτό διαφέρει από την κοπή. Οι τιμές κοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι offsets τέντωσης αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γέμισμα εικόνας.

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

Χρησιμοποιήστε τα stretch‑offsets για τοποθέτηση γεμίσματος. Χρησιμοποιήστε τις ιδιότητες κοπής όταν ο στόχος είναι η απόκρυψη άκρων της πηγαίας εικόνας.

## **Αποθήκευση, Μέγεθος Αρχείου και Σκέψεις Εξαγωγών**

Οι κύριες ανταλλαγές είναι πιο εύκολα διαχειρίσιμες όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση στην πλευρά του διακομιστή, αλλά μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή τοποθεσίες.
- **Κοπή** αρχικά δεν είναι καταστροφική. Τα κρυφά pixel παραμένουν ενσωματωμένα μέχρι οι κομμένες περιοχές να διαγραφούν ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθη ραστερ εικόνες, αλλά θυσιάζει την αρχική ανάλυση. Θα πρέπει να εφαρμοστεί μετά τον καθορισμό του τελικού μεγέθους στην διαφάνεια.
- **Εικόνες SVG** πρέπει να παραμείνουν SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG άμεσα όταν χρειάζεστε τον διανυσματικό πόρο. Οι εξαγωγές διαφάνειας σε ραστερ πάντα μετατρέπουν τη διαφάνεια σε pixel.
- **Επαναλαμβανόμενες εικόνες** πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) όταν είναι δυνατόν αντί να φορτώνουν ξανά το ίδιο αρχείο στη ροή εργασίας παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποδοτική όταν πραγματοποιείται επιλεκτικά: διατηρήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες ανάλογα με το πραγματικό μέγεθος εμφάνισης, αφαιρέστε τα κομμένα pixel μόνο όταν δεν απαιτείται περαιτέρω επεξεργασία, και αποφύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδιασμού ανάπτυξης.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου εικόνας και ενός πόρου εικόνας;**

Ένα [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) αντιπροσωπεύει έναν πόρο εικόνας που σχετίζεται με την παρουσίαση. Ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) είναι ένα σχήμα σε μια διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει τη γεωμετρία και τη μορφοποίηση επιπέδου πλαισίου όπως το μέγεθος, η περιστροφή, οι τιμές κοπής, τα εφέ και οι κλειδώσεις.

**Πρέπει να ενσωματώνω ή να συνδέω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδοθεί χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές τοποθεσίες μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η κοπή το μέγεθος του αρχείου PPTX;**

Όχι από μόνο της. Οι κανονικές ρυθμίσεις κοπής αποκρύπτουν τμήματα της πηγαίας εικόνας αλλά κρατούν τα υποκείμενα pixel. Χρησιμοποιήστε [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) ή συμπίεση εικόνας με αφαίρεση κομμένων περιοχών όταν τα pixel μπορούν να απορριφθούν μόνιμα.

**Μπορώ να αποκαταστήσω την ποιότητα της εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση, και η αφαίρεση κομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγή εικόνας εκτός της παρουσίασης εάν μπορεί να απαιτηθεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η ακεραιότητα του διανύσματος είναι σημαντική. Το ενσωματωμένο [SvgImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/svgimage/) μπορεί να εξαχθεί άμεσα. Η απόδοση μιας διαφάνειας σε ραστερ μορφή όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπου κατά την ανάγνωση υπαρχουσών διαφανειών;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Μια проверка `java.instanceOf` έναντι του [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) αποφεύγει άκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.