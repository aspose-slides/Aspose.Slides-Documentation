---
title: Διαχείριση Εφέ Μετασχηματισμού Εικόνας σε Παρουσιάσεις με JavaScript
linktitle: Εφέ Μετασχηματισμού Εικόνας
type: docs
weight: 11
url: /el/nodejs-java/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- εφέ εικόνας
- φωτεινότητα
- αντίθεση
- γκρίζα κλίμακα
- δυτονικό
- απόχρωση
- HSL
- αντικατάσταση χρώματος
- θόλωση
- διαφάνεια
- εφέ άλφα
- αλυσιδωτή αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμόστε, αλυσίδωση, επιθεώρηση, αφαίρεση και επαλήθευση εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις εικόνας ως μια ταξινομημένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/) του πλαισίου και προσπελάστε το [Picture.getImageTransform](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/). Η επιστρεφόμενη [ImageTransformOperationCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) σας επιτρέπει να προσθέτετε, να απαριθμείτε, να εξετάζετε, να αφαιρείτε και να καθαρίζετε εφέ χωρίς να ξαναγράφετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο παρουσιάζει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, χρωματικούς μετασχηματισμούς, θόλωση, διαφάνεια, αλυσίδες εφέ με σειρά, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση κλειστού κύκλου PPTX.

## **Κατανόηση της Ιδιοκτησίας του Εφέ και Επανάχρηση Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- Το [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) αποθηκεύει ή αναφορά το πηγαίο δεδομένο εικόνας που ανήκει στην παρουσίαση.
- Το [Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/) ανήκει σε γεμισμό εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμών εικόνας.
- Το [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γεμισμό εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις σε επίπεδο πλαισίου.

Κατά συνέπεια, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/). Όταν το ίδιο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) περνάει στο [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του [Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/) και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι κλίμακας, ακόμη και αν όλα επαναχρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο [Picture.getImageTransform](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/) χρησιμοποιείται επίσης από άλλα γεμίσματα εικόνας, όπως σχήμα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν σε πλαίσια εικόνας.

## **Χρήση Έγκυρων Εύρους Παραμέτρων και Μονάδων**

Οι μεθόδους που παρουσιάζονται χρησιμοποιούν τα παρακάτω λογικά εύρη και μονάδες. Διατηρήστε τις τιμές εντός αυτών των ορίων ακόμη κι αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει άμεσα κάθε έξω‑από‑το‑εύρος τιμή· η μορφή εξόδου της παρουσίασης μπορεί να κανονικοποιήσει, παραλείψει ή απορρίψει άκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίξει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | Καμία αριθμητική παράμετρος. Η άλφα παραμένει αμετάβλητη. |
| [addDuotoneEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Δύο χρώματα για σκούρα και ανοιχτά εικονοστοιχεία. Τα κανάλια RGB και άλφα στο `java.awt.Color` χρησιμοποιούν τιμές από `0` έως `255`. |
| [addTintEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Η απόχρωση είναι `0` (συμπεριλαμβανόμενη) έως `360` (αποκλειστική), σε μοίρες· η ποσότητα είναι `-100` έως `100`, ποσοστό. |
| [addHSLEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι `0` (συμπεριλαμβανόμενη) έως `360` (αποκλειστική), σε μοίρες· ο κορεσμός και η φωτεινότητα είναι `-100` έως `100`, ποσοστό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [addBlurEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετριέται σε points· `grow` είναι Boolean που ελέγχει εάν το θολό περιεχόμενο μπορεί να εκταθεί πέρα από τα αρχικά όρια. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για κανονική κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διαφανές και `100` διατηρεί την υπάρχουσα άλφα. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` έως `100`, ποσοστό διαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή πάνω γίνονται αδιαφανείς. |

Για σταθερή διαμεσολάβηση άλφα, η διαφάνεια και η αδιαφάνεια είναι αμοιβαία συμπληρωματικά. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό διαμεσολάβησης άλφα 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

Η μέθοδος [ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) επιστρέφει μια λειτουργία [BrightnessContrast](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/brightnesscontrast/). Οι κλιμακωτές ρυθμίσεις της παρέχονται κατά τη δημιουργία της λειτουργίας. Η μέθοδος [BrightnessContrast.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/brightnesscontrast/) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να επιθεωρηθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, έπειτα αποδίδει μια προεπισκόπηση χωρίς να τροποποιεί την ενσωματωμένη εικόνα:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

Το [BrightnessContrast](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητό από το τυπικό εφέ φωτεινότητας DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από κλειστό κύκλο PPTX, χρησιμοποιήστε το [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διαφορά πιο λεπτομερώς.

## **Εφαρμογή Χρωματικών Μετασχηματισμών**

Τα χρωματικά εφέ μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, δυο‑τρόπιο, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

Το [Duotone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/duotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες χρωματικές παραμέτρους: το `color1` αντιστοιχεί στα σκούρα εικονοστοιχεία, ενώ το `color2` στα ανοιχτά. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ των οποίων οι ρυθμίσεις είναι πιο σύνθετες από μια απλή κλιμακωτή τιμή.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μέθοδος [addColorReplaceEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) αντικαθιστά το χρώμα κάθε εικονοστοιχείου με ένα σταθερό χρώμα διατηρώντας την άλφα. Είναι διαφορετική από το [addColorChangeEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/), το οποίο χαρτογραφήσει ένα χρώμα προέλευσης σε ένα άλλο και εκθέτει τόσο τη μορφή χρώματος προέλευσης όσο και στόχου.

## **Προσθήκη Θόλωσης, Διαφάνειας και Εφέ Άλφα**

Η μέθοδος [addBlurEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένης της άλφα. Ορίστε `grow` σε `true` όταν η θολή άκρη μπορεί να επεκταθεί πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι τα ημιδιαφανή εικονοστοιχεία παραμένουν αναλογικά διαφορετικά. Η μέθοδος [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) αντιθέτως αντιστοιχίζει μια τιμή άλφα σε όλα τα εικονοστοιχεία. Η μέθοδος [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) μετατρέπει την άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [addAlphaCeilingEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/), που κάνει κάθε μη‑μηδενική άλφα πλήρως αδιαφανή· το [addAlphaFloorEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/), που κάνει κάθε άλφα κάτω από 100 % πλήρως διαφανές· και το [addAlphaInverseEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/), που αλλάζει την άλφα σε `100% - alpha`.

## **Δημιουργία Ταξινομημένης Αλυσίδας Εφέ**

Κάθε μέθοδος `add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο αποδοχέας χρησιμοποιεί τη συλλογή ως μια ταξινομημένη διασωλήνωση: η έξοδος της λειτουργίας 0 γίνεται είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες με διαφορετική σειρά μπορούν να παραγάγουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση πρώτα αφαιρεί χρωματική πληροφορία και μετά χρωματίζει το αποτέλεσμα της φωτεινότητας. Η απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί ξανά την απόχρωση. Ομοίως, η αντικατάσταση άλφα μπορεί να υπερισχύσει των τιμών άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμεσολάβηση άλφα διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ξαναανοίγει την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους, και αποδίδει το ξαναανοικτό αποτέλεσμα:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θόλωσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί την ποικιλία RGB που παρήχθη από προηγούμενα χρωματικά εφέ· η γκρι κλίμακα μετά από δυο‑τρόπιο αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα (ceil, floor, replace, bi‑level) μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Χτίστε την αλυσίδα σύμφωνα με την επιθυμητή σειρά επεξεργασίας εικονοστοιχείων αντί να θεωρείτε τα στοιχεία ως αταξία μορφοποιήσεων.

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο [Picture.getImageTransform](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/). Ανάλογα με το εφέ, μπορεί να εκθέτει εγγράψιμα μέλη άμεσα. Για παράδειγμα, το [Blur](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/blur/) εκθέτει εγγράψιμα `radius` και `grow`, το [AlphaModulateFixed](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/alphamodulatefixed/) εκθέτει εγγράψιμο `amount`, και το [AlphaBiLevel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/alphabilevel/) εκθέτει εγγράψιμο `threshold`. Τα χρωματικά εφέ όπως το [Duotone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/duotone/) εκθέτουν μεταβλητά αντικείμενα [ColorFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/colorformat/).

Κάποιες λειτουργίες, όπως το [BrightnessContrast](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/brightnesscontrast/), το [HSL](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/hsl/), το [Tint](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/tint/), και το [AlphaReplace](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/alphareplace/), δεν εκθέτουν τα αρχικά τους σκαλαρισμένα δεδομένα ως εγγράψιμα ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια νέα στη ζητούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει η `getEffective()` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων που εξαρτώνται από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο αποδοχέας, αλλά δεν αποτελούν επιπλέον επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και επιθεωρεί τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Τα εφέ χωρίς παραμέτρους όπως η γκρι κλίμακα, η άλφα οροφή και η άλφα αντιστροφή διαθέτουν ακόμη αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν τιμές κλίμακας προς εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι οι σημαντικές πληροφορίες.

## **Αφαίρεση ή Εκκαθάριση Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) για να αφαιρέσετε μια λειτουργία κατά δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα το στόχο και αφαιρέστε το μετά την απαρίθμηση. Χρησιμοποιήστε το [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) για να αφαιρέσετε ολόκληρη την αλυσίδα.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Η αφαίρεση ή η εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν επανασυμπιέζει ή αλλιώς δεν τροποποιεί τον ξαναχρησιμοποιούμενο πόρο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/).

## **Λήψη Υπόψη Μορφών Παρουσίασης και Προορισμών Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, γι' αυτό το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμη και με PPTX, δεν έχουν όλες οι λειτουργίες την ίδια φορητότητα:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, grayscale, duotone, tint, HSL, blur και κοινές λειτουργίες άλφα έχουν τις μεγαλύτερες πιθανότητες να επιβιώσουν μετά από κλειστό κύκλο PPTX. Πάντα ανοίξτε εκ νέου το δημιουργημένο αρχείο και επιθεωρήστε τη συλλογή όταν η διατήρηση είναι απαίτηση.
- Το [BrightnessContrast](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/brightnesscontrast/) είναι μια επέκταση Office 2010 αντί της τυπικής λειτουργίας luminance DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση στη μνήμη, αλλά δεν εγγυάται ότι θα παραμείνει επεξεργάσιμη μετά την αποθήκευση και το άνοιγμα του PPTX. Προτιμήστε το [addLuminanceEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη‑υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες οπτικές εξόδους εφαρμόζει την υποστηριζόμενη αλυσίδα στην εμφάνιση. Αυτές οι εξόδους δεν περιέχουν επεξεργάσιμη [ImageTransformOperationCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagetransformoperationcollection/); οι μορφές raster ισοπεδώνουν το αποτέλεσμα σε εικονοστοιχεία, και οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν φορτωθεί η παρουσίαση.

Διαφορετικοί καταναλωτές παρουσίασης μπορεί να αποδώσουν άκρες περιπτώσεων διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρωματικής ποσότητας. Για κρίσιμη έξοδο, δοκιμάστε τόσο τον επεξεργάσιμο κλειστό κύκλο όσο και την τελική μορφή εξαγωγής με την ίδια έκδοση Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν οι μετασχηματισμοί εφέ εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο [Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/) που χρησιμοποιείται από το γεμισμό εικόνας. Τα bytes του υποκείμενου [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) παραμένουν αμετάβλητα.

**Θα μοιραστούν οι δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρησιμοποίηση ενός [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) αποτρέπει διπλή αποθήκευση δεδομένων εικόνας, αλλά κάθε πλαίσιο εικόνας κανονικά έχει το δικό του [Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picture/) και τη δική του συλλογή μετασχηματισμών εικόνας.

**Μπορούν τα χρωματικά, θολώσιμα και άλφα εφέ να συνδυαστούν;**

Ναι. Η συλλογή τα αποδέχεται σε μία ταξινομημένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή λειτουργίες αντικατάστασης και κατωφλιού μπορούν να απορρίψουν χρώμα ή άλφα που δημιουργήθηκαν νωρίτερα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τις υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που βρίσκεται στη συλλογή μετασχηματισμών όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε την και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμών;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ξαναανοίγοντάς το. Η παλαιότερη μορφή PPT δεν μπορεί να αναπαραστήσει το πλήρες μοντέλο εφέ DrawingML, και οι μορφές εξαγωγής αποθηκεύουν μόνο την εμφάνιση αντί των επεξεργάσιμων λειτουργιών μετασχηματισμού.