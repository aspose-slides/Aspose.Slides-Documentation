---
title: Διαχείριση εφέ μετασχηματισμού εικόνας σε παρουσιάσεις με JavaScript
linktitle: Εφέ μετασχηματισμού εικόνας
type: docs
weight: 11
url: /el/nodejs-java/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- εφέ εικόνας
- φωτεινότητα
- αντίθεση
- γκρι κλίμακα
- δυοχρωμία
- απόχρωση
- HSL
- αντικατάσταση χρώματος
- θολούρα
- διαφάνεια
- εφέ αλφα
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμόστε, συνδέστε, επιθεωρήστε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides αναπαριστά τις ρυθμίσεις εικόνας ως μια ταξινομημένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) του πλαισίου και αποκτήστε πρόσβαση στο [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). Η επιστρεφόμενη [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) σάς επιτρέπει να προσθέτετε, να απαριθμείτε, να εξετάζετε, να αφαιρείτε και να διαγράφετε εφέ χωρίς να ξαναγράφετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο παρουσιάζει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρώματος, θολούρα, διαφάνεια, ακολουθίες εφέ με σειρά, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση κυκλικής διαδικασίας PPTX.

## **Κατανόηση της Ιδιοκτησίας των Εφέ και της Επαναχρησιμοποίησης Εικόνας**

Μία πηγή εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) αποθηκεύει ή αναφέρεται στα δεδομένα της πηγής εικόνας που ανήκει στην παρουσίαση.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) ανήκει σε γέμισμα εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμού εικόνας.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις σε επίπεδο πλαισίου.

Συνεπώς, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/). Όταν το ίδιο [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) περάσει σε [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) περισσότερες από μια φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) και τη δική του συλλογή μετασχηματισμού. Η εφαρμογή της γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι, ακόμη και αν όλα επαναχρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) χρησιμοποιείται επίσης από άλλα γέμισματα εικόνας, όπως σχήμα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν στα πλαίσια εικόνας.

## **Χρησιμοποιήστε Έγκυρες Περιοχές Παραμέτρων και Μονάδες**

Οι επιδεικνυόμενες μέθοδοι χρησιμοποιούν τις παρακάτω λογικές περιοχές και μονάδες. Κρατήστε τις τιμές σε αυτές τις περιοχές ακόμη και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε εκτός περιοχής τιμή· η μορφή στόχου παρουσίασης μπορεί να κανονικοποιήσει, παραλείψει ή απορρίψει τα μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίγει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρη περιοχή και μονάδα |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | Καμία αριθμητική παράμετρος. Το Alpha παραμένει αμετάβλητο. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Δύο χρώματα για σκοτεινά και φωτεινά pixel. Τα κανάλια RGB και alpha στο `java.awt.Color` χρησιμοποιούν τιμές από `0` έως `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Το hue είναι `0` συμπεριλαμβανομένο έως `360` αποκλειστικό, σε μοίρες· το amount είναι από `-100` έως `100`, ποσοστό. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Το hue είναι `0` συμπεριλαμβανομένο έως `360` αποκλειστικό, σε μοίρες· η saturation και το luminance είναι από `-100` έως `100`, ποσοστό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιού από `0` έως `255`. Οι υπάρχουσες τιμές alpha παραμένουν αμετάβλητες. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετράται σε σημεία· `grow` είναι Boolean που ελέγχει εάν το θολό περιεχόμενο μπορεί να επεκταθεί εκτός των αρχικών ορίων. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για κανονική κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διαφανές και `100` διατηρεί το υπάρχον alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` έως `100`, ποσοστό αδιαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου alpha. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή πάνω από αυτό γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση alpha, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, 35% διαφάνεια αντιστοιχεί σε ποσό διαμόρφωσης alpha 65%.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) επιστρέφει μια λειτουργία [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). Οι βαθμωτές ρυθμίσεις της παρέχονται κατά τη δημιουργία της λειτουργίας. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να εξεταστούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15% και την αντίθεση κατά 20%, έπειτα αποδίδει μια προεπισκόπηση χωρίς να τροποποιεί την ενσωματωμένη εικόνα:

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητή από το τυπικό εφέ luminance του DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από μια κυκλική διαδικασία PPTX, χρησιμοποιήστε [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου ξανά. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διάκριση με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, δυοχρωμία, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `color1` αντιστοιχεί σε σκοτεινά pixel, ενώ το `color2` αντιστοιχεί σε φωτεινά pixel. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ των οποίων οι ρυθμίσεις είναι πιο πολύπλοκες από μια απλή βαθμωτή τιμή.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα ενώ διατηρεί το alpha. Διαφέρει από το [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), το οποίο αντιστοιχίζει ένα χρώμα προέλευσης σε άλλο και εκθέτει και τις μορφές χρώματος προέλευσης και στόχου.

### **Εφαρμογή Κατωφλίου Φωτεινότητας**

Ένα κατώφλι φωτεινότητας μπορεί να κάνει τα αδύναμα σημάδια σε μια σκαναρισμένη σελίδα πιο εύκολα διακριτά από το φόντο. Το [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) διατηρεί ενδιάμεσα αποχρώσεις του γκρι. Το [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) αντιστοιχίζει τη φωτεινότητα σε μαύρο ή λευκό, ενώ το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) εφαρμόζει ένα κατώφλι στην αδιαφάνεια.

Το κατώφλι φωτεινότητας κυμαίνεται από 0% έως 100%, συμπεριλαμβανομένου. Τα pixel κάτω από το κατώφλι γίνονται μαύρα. Τα pixel ισάγια ή πάνω από το κατώφλι γίνονται λευκά. Η αύξηση του κατωφλίου κάνει περισσότερες αποχρώσεις μαύρες επειδή περισσότερα pixel πέφτουν κάτω από το όριο.

Κατεβάστε το [grayscale‑swatches.png](grayscale-swatches.png) στον εργατικό φάκελο. Κάθε ετικέτα δίνει το αρχικό επίπεδο γκρι σε κλίμακα από 0 έως 255. Το παράδειγμα τοποθετεί το αρχικό δίπλα σε δύο αντίγραφες και αποθηκεύει το κατώφλι κάθε αντίγραφου στην παρουσίαση.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ανοίξτε την παραγόμενη παρουσίαση στο PowerPoint για να συγκρίνετε τα τρία πλαίσια. Η ετικέτα 96 έχει περίπου 38% φωτεινότητα (96 από 255). Μετατρέπεται σε λευκό στο κατώφλι 20% και σε μαύρο στο κατώφλι 60%.

![Αρχικές γκρι κλίμακες δίπλα στα αποτελέσματα μαύρο‑λευκό σε κατώφλια φωτεινότητας 20% και 60%](luminance-threshold.png)

## **Προσθήκη Θολούρας, Διαφάνειας και Εφέ Alpha**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του alpha. Ορίστε `grow` σε `true` όταν η θολή άκρη μπορεί να επεκταθεί πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή alpha, ώστε τα μερικώς διαφανή pixel να παραμένουν σχετικώς διαφορετικά. Το [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) αντιθέτως εκχωρεί μία τιμή alpha σε όλα τα pixel. Το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) μετατρέπει το alpha σε δύο επίπεδα βάσει ενός κατωφλίου.

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

Άλλες λειτουργίες alpha χωρίς παραμέτρους περιλαμβάνουν το [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), που κάνει κάθε μη μηδενικό alpha πλήρως αδιαφανές· το [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), που κάνει κάθε alpha κάτω από 100% πλήρως διαφανές· και το [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), που αλλάζει το alpha σε `100% - alpha`.

## **Δημιουργία Ταξινομημένης Ακολουθίας Εφέ**

Κάθε μέθοδος `add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο αποδότης χρησιμοποιεί τη συλλογή ως μια ταξινομημένη γραμμή επεξεργασίας: η έξοδος της λειτουργίας 0 γίνεται είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες σε διαφορετική σειρά μπορούν να παραγάγουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση πρώτα αφαιρεί την χρωματική πληροφορία και έπειτα χρωματίζει εκ νέου το αποτέλεσμα της φωτεινότητας. Η απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί ξανά την απόχρωση. Παρομοίως, η αντικατάσταση alpha μπορεί να επικρατήσει των αλφα τιμών που έχουν υπολογιστεί από προηγούμενες λειτουργίες, ενώ η διαμόρφωση alpha διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ξαναφορτώνει την παρουσίαση, ελέγχει τόσο τους τύπους των λειτουργιών όσο και τη σειρά τους, και αποδίδει το ξαναφορτωμένο αποτέλεσμα:

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

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που να περιορίζει τις λειτουργίες χρώματος, alpha και θολούρας σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Η σταθερή αντικατάσταση χρώματος αφαιρεί την μεταβλητότητα RGB που παρήχθη από προηγούμενα εφέ χρώματος· η γκρι κλίμακα μετά από δυοχρωμία αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες alpha ceiling, floor, replacement ή bi‑level μπορούν να απορρίψουν λεπτομέρεια alpha που είχε δημιουργηθεί νωρίτερα. Κατασκευάστε την αλυσίδα σύμφωνα με την επιθυμητή σειρά επεξεργασίας pixel αντί να θεωρείτε τα στοιχεία ως ανεξάρτητες σημαδοφόρες μορφοποίησης.


<!-- visual-explanation:image-transform-effects:start -->
[![Η ίδια εικόνα περνάει πρώτα από γκρι κλίμακα και μετά από απόχρωση, και αντίστροφα. Οι δύο τελικές γκρι κλίμακες έχουν διαφορετικούς τόνους.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Σε αυτήν την εικονογραφική απόδοση Aspose.Slides for .NET 26.11, ένα χρωματισμό 220° με 25% αφήνει την γκρι κλίμακα αμετάβλητη. Η εφαρμογή του ίδιου χρωματισμού πριν από τη γκρι κλίμακα παράγει διαφορετικούς τόνους.*
<!-- visual-explanation:image-transform-effects:end -->

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). Ανάλογα με το εφέ, μπορεί να εκθέτει εγγράψιμα μέλη άμεσα. Για παράδειγμα, το [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) εκθέτει εγγράψιμες τιμές `radius` και `grow`, το [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) εκθέτει εγγράψιμη τιμή `amount`, και το [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) εκθέτει εγγράψιμη τιμή `threshold`. Τα εφέ χρώματος όπως το [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) εκθέτουν μεταβλητά αντικείμενα [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/).

Κάποιες λειτουργίες, όπως το [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), το [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), το [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), και το [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), δεν εκθέτουν τις αρχικές βαθμωτές τιμές ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στη ζητούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει η `getEffective()` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων που εξαρτώνται από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο αποδότης, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και επιθεωρεί τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

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

Τα εφέ χωρίς παραμέτρους όπως η γκρι κλίμακα, το alpha ceiling και το alpha inverse έχουν ακόμη αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν βαθμωτές ρυθμίσεις προς εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι οι σημαντικές πληροφορίες.

## **Αφαίρεση ή Καθαρισμός Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) για να αφαιρέσετε μία λειτουργία με βάση το δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε τον στόχο πρώτα και αφαιρέστε τον μετά την απαρίθμηση. Χρησιμοποιήστε το [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) για να αφαιρέσετε ολόκληρη την αλυσίδα.

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

Η αφαίρεση ή ο καθαρισμός των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, συμπιέζει ξανά ή αλλιώς τροποποιεί τον επαναχρησιμοποιημένο πόρο [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).

## **Λήψη υπόψη των Μορφών Παρουσίασης και των Στόχων Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, έτσι το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμα και με PPTX, δεν είναι κάθε λειτουργία εξίσου φορητή:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, γκρι κλίμακα, δυοχρωμία, απόχρωση, HSL, θολούρα και οι κοινές λειτουργίες alpha έχουν τις μεγαλύτερες πιθανότητες να επιβιώσουν σε μια κυκλική διαδικασία PPTX. Πάντα ανοίγετε ξανά το παραγόμενο αρχείο και επιθεωρείτε τη συλλογή όταν η διατήρηση είναι απαίτηση.
- Το [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) είναι μια επέκταση Office 2010 αντί για την τυπική λειτουργία luminance του DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση εντός μνήμης, αλλά δεν υπάρχει εγγύηση ότι θα παραμείνει ως επεξεργάσιμη λειτουργία [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) μετά την αποθήκευση και το ξαναάνοιγμα του PPTX. Προτιμήστε το [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε ένα υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια πολύπλοκη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλα οπτικά αποτελέσματα εφαρμόζει την υποστηριζόμενη αλυσίδα στην απόδοση. Αυτές οι εξόδους δεν περιέχουν επεξεργάσιμη [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/); οι μορφές raster ισοπεδώνουν το αποτέλεσμα σε pixel, και οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν η παρουσίαση φορτώνεται.

Διαφοροί καταναλωτές παρουσίασης μπορεί να αποδίδουν ακραίες περιπτώσεις διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες alpha ή χρωματικής ποσοτικοποίησης. Για κρίσιμη έξοδο, ελέγξτε τόσο την επεξεργάσιμη κυκλική διαδικασία όσο και τη τελική μορφή εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Τροποποιούν τα εφέ μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα bytes του [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) παραμένουν αμετάβλητα.

**Θα μοιραστούν δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρήση ενός [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) αποφεύγει διπλότυπα δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας συνήθως έχει το δικό του [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) και τη δική του συλλογή μετασχηματισμού εικόνας.

**Μπορούν να συνδυαστούν χρώματα, θολούρα και εφέ alpha;**

Ναι. Η συλλογή δέχεται τα εφέ σε μια ταξινομημένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στο αποτέλεσμα της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να αφαιρέσουν χρώμα ή alpha που είχε δημιουργηθεί νωρίτερα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τις υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που βρίσκεται στη συλλογή μετασχηματισμού όταν υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμών;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ξαναανοίγοντάς το. Η παλαιά μορφή PPT δεν μπορεί να αντιπροσωπεύσει το πλήρες μοντέλο εφέ DrawingML, και οι εξαγώμενες μορφές εμφάνισης διατηρούν μόνο την εμφάνιση αντί για επεξεργάσιμες λειτουργίες μετασχηματισμού.