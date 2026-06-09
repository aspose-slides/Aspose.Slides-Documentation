---
title: Διαχείριση Φόντου Παρουσίασης σε JavaScript
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/nodejs-java/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- συμπαγές χρώμα
- διαβαθμισμένο χρώμα
- φόντο εικόνας
- διαφάνεια φόντου
- ιδιότητες φόντου
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Node.js, με συμβουλές κώδικα για να ενισχύσετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Τα σταθερά χρώματα, τα διαβαθμισμένα χρώματα και οι εικόνες χρησιμοποιούνται συνήθως ως φόντο διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μία μόνο διαφάνεια) ή μια **κύρια διαφάνεια** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![PowerPoint background](powerpoint-background.png)

## **Ορισμός Σταθερού Χρώματος Φόντου για Κανονική Διαφάνεια**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα σταθερό χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση—ακόμη και αν η παρουσίαση χρησιμοποιεί κύρια διαφάνεια. Η αλλαγή εφαρμόζεται μόνο στην επιλεγμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) στο [FillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/) για να ορίσετε το χρώμα του σταθερού φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα JavaScript δείχνει πώς να ορίσετε ένα μπλε σταθερό χρώμα ως φόντο για μια κανονική διαφάνεια:

```js
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Ορίστε το χρώμα φόντου της διαφάνειας σε μπλε.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Σταθερού Χρώματος Φόντου για την Κύρια Διαφάνεια**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα σταθερό χρώμα ως φόντο για τη κύρια διαφάνεια σε μια παρουσίαση. Η κύρια διαφάνεια λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση όλων των διαφανειών, έτσι όταν επιλέγετε ένα σταθερό χρώμα για το φόντο της κύριας διαφάνειας, αυτό εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/backgroundtype/) της κύριας διαφάνειας (μέσω `getMasters`) σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του φόντου της κύριας διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) για να ορίσετε το χρώμα του σταθερού φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα JavaScript δείχνει πώς να ορίσετε ένα σταθερό χρώμα (πράσινο) ως φόντο για μια κύρια διαφάνεια:

```js
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Ορίστε το χρώμα φόντου για τη κύρια διαφάνεια σε Πράσινο δάσους.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Διαβαθμισμένου Φόντου για Διαφάνεια**

Ένα διαβαθμισμένο χρώμα (gradient) είναι ένα γραφικό εφέ που δημιουργείται από σταδιακή αλλαγή του χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, τα διαβαθμισμένα χρώματα μπορούν να κάνουν τις παρουσιάσεις πιο καλλιτεχνικές και επαγγελματικές. Το Aspose.Slides σας επιτρέπει να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για διαφάνειες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Gradient`.
4. Χρησιμοποιήστε τη μέθοδο [getGradientFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/#getGradientFormat) στο [FillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/) για να ρυθμίσετε τις προτιμώμενες ρυθμίσεις διαβάθμισης.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα JavaScript δείχνει πώς να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για μια διαφάνεια:

```js
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Εφαρμόστε ένα διαβαθμισμένο εφέ στο φόντο.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Εκτός από σταθερά και διαβαθμισμένα γεμίσματα, το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφάνειας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Picture`.
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο της διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε τη μέθοδο [getPictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) στο [FillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/) για να ορίσετε την εικόνα ως φόντο.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα JavaScript δείχνει πώς να ορίσετε μια εικόνα ως φόντο για μια διαφάνεια:

```js
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Ορίστε τις ιδιότητες εικόνας φόντου.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Φορτώστε την εικόνα.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσματος φόντου σε μια επαναλαμβανόμενη εικόνα (tiled picture) και να τροποποιήσετε τις ιδιότητες επικάλυψης:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Ορίστε την εικόνα που χρησιμοποιείται για το γέμισμα φόντου.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Ορίστε τη λειτουργία γέμισης εικόνας σε Tile και προσαρμόστε τις ιδιότητες του πλακιδίου.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Διαβάστε περισσότερα: [**Tile Picture As Texture**](/slides/el/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή Διαφάνειας Εικόνας Φόντου**

Μπορεί να θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Το παρακάτω κώδικα JavaScript δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```js
var transparencyValue = 30; // Για παράδειγμα.

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Ανάκτηση Τιμής Φόντου Διαφάνειας**

Το Aspose.Slides παρέχει την κλάση `BackgroundEffectiveData` για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτή η κλάση εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/) και [EffectFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effectformat/).

Χρησιμοποιώντας τη μέθοδο `getBackground` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/), μπορείτε να αποκτήσετε το αποτελεσματικό φόντο για μια διαφάνεια.

Το παρακάτω παράδειγμα JavaScript δείχνει πώς να λάβετε την αποτελεσματική τιμή φόντου μιας διαφάνειας:

```js
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Ανακτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη την κύρια διαφάνεια, τη διάταξη και το θέμα.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να αποκαταστήσω το φόντο θέματος/διάταξης;**

Ναι. Αφαιρέστε το προσαρμοσμένο γέμισμα της διαφάνειας και το φόντο θα κληρονομηθεί ξανά από τη σχετική διαφάνεια [layout](/slides/el/nodejs-java/slide-layout/)/[master](/slides/el/nodejs-java/slide-master/) (δηλαδή το [theme background](/slides/el/nodejs-java/presentation-theme/)).

**Τι συμβαίνει με το φόντο αν αλλαγώ αργότερα το θέμα της παρουσίασης;**

Αν μια διαφάνεια έχει το δικό της γέμισμα, αυτό θα παραμείνει αμετάβλητο. Αν το φόντο κληρονομείται από τη [layout](/slides/el/nodejs-java/slide-layout/)/[master](/slides/el/nodejs-java/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [new theme](/slides/el/nodejs-java/presentation-theme/).