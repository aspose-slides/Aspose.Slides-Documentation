---
title: Διαχείριση Πλαισίων Εικόνας σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
linktitle: Πλαίσιο Εικόνας
type: docs
weight: 10
url: /el/nodejs-java/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- προσθήκη εικόνας
- δημιουργία εικόνας
- εξαγωγή εικόνας
- raster εικόνα
- διανυσματική εικόνα
- περικοπή εικόνας
- περιοχή περικοπής
- ιδιότητα StretchOff
- μορφοποίηση πλαισίου εικόνας
- ιδιότητες πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- διαφάνεια εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Node.js μέσω Java. Βελτιώστε τη ροή εργασίας σας και ενισχύστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Ένα πλαίσιο εικόνας είναι ένα σχήμα που περιέχει μια εικόνα—είναι σαν μια εικόνα μέσα σε ένα πλαίσιο.  

Μπορείτε να προσθέσετε μια εικόνα σε μια διαφάνεια μέσω ενός πλαισίου εικόνας. Με αυτόν τον τρόπο, μπορείτε να μορφοποιήσετε την εικόνα μορφοποιώντας το πλαίσιο εικόνας.

{{% alert  title="Συμβουλή" color="primary" %}} 

Η Aspose προσφέρει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

## **Δημιουργία Πλαισίου Εικόνας**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο `PPImage` προσθέτοντας μια εικόνα στη [ImagesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ImageCollection) που συσχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFrame) με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου `addPictureFrame` που εκτίθεται από το αντικείμενο σχήματος που συσχετίζεται με τη διαφάνεια.
6. Προσθέστε ένα πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
7. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας:

```javascript
// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Δημιουργεί μια παρουσία της κλάσης Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Προσθέτει ένα πλαίσιο εικόνας με το ισοδύναμο ύψος και πλάτος της εικόνας
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Τα πλαίσια εικόνας σας επιτρέπουν να δημιουργείτε γρήγορα διαφάνειες παρουσίασης βασισμένες σε εικόνες. Όταν συνδυάσετε το πλαίσιο εικόνας με τις επιλογές αποθήκευσης του Aspose.Slides, μπορείτε να διαχειριστείτε τις λειτουργίες εισόδου/εξόδου για να μετατρέψετε εικόνες από μια μορφή στην άλλη.

## **Δημιουργία Πλαισίου Εικόνας με Σχετική Κλίμακα**

Αλλάζοντας τη σχετική κλίμακα μιας εικόνας, μπορείτε να δημιουργήσετε ένα πιο σύνθετο πλαίσιο εικόνας. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Προσθέστε μια εικόνα στη συλλογή εικόνων της παρουσίασης.
4. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PPImage) προσθέτοντας μια εικόνα στη [ImagesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ImageCollection) που συσχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.
5. Καθορίστε το σχετικό πλάτος και ύψος της εικόνας στο πλαίσιο εικόνας.
6. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας με σχετική κλίμακα:

```javascript
// Δημιουργεί κλάση Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Δημιουργεί την κλάση Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Προσθέτει πλαίσιο εικόνας με ύψος και πλάτος ισοδύναμα της εικόνας
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Ορίζει σχετική κλίμακα πλάτους και ύψους
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Εξαγωγή Raster Εικόνων από Πλαίσια Εικόνας**

Μπορείτε να εξάγετε raster εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFrame) και να τις αποθηκεύσετε σε PNG, JPG και άλλες μορφές. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο «sample.pptx» και να την αποθηκεύσετε σε μορφή PNG.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή SVG Εικόνων από Πλαίσια Εικόνας**

Όταν μια παρουσίαση περιέχει γραφικά SVG τοποθετημένα μέσα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/), το Aspose.Slides for Node.js via Java σάς επιτρέπει να αποκτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη πιστότητα. Διατρέχοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/), να ελέγξετε εάν το υποκείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) περιέχει περιεχόμενο SVG, και στη συνέχεια να αποθηκεύσετε αυτήν την εικόνα στο δίσκο ή σε ρεύμα στην μητρική της μορφή SVG.

Το ακόλουθο παράδειγμα κώδικα δείχνει πώς να εξάγετε μια SVG εικόνα από ένα πλαίσιο εικόνας:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Λήψη Διαφάνειας Εικόνας**

Το Aspose.Slides σας επιτρέπει να λάβετε το εφέ διαφάνειας που εφαρμόζεται σε μια εικόνα. Αυτός ο κώδικας JavaScript επιδεικνύει τη λειτουργία:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Λήψη Φωτεινότητας και Αντίθεσης Εικόνας**

Το Aspose.Slides σας επιτρέπει να λάβετε το εφέ φωτεινότητας και αντίθεσης που εφαρμόζεται σε μια εικόνα. Η κλάση [Luminance](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/luminance/) αντιπροσωπεύει αυτή τη μετασχηματιστική ενέργεια της εικόνας.

Αυτός ο κώδικας JavaScript δείχνει πώς να λάβετε τις ρυθμίσεις φωτεινότητας και αντίθεσης από ένα πλαίσιο εικόνας:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση Πλαισίου Εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορούν να εφαρμοστούν σε ένα πλαίσιο εικόνας. Χρησιμοποιώντας αυτές τις επιλογές, μπορείτε να τροποποιήσετε ένα πλαίσιο εικόνας ώστε να ταιριάζει σε συγκεκριμένες απαιτήσεις.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PPImage) προσθέτοντας μια εικόνα στη [ImagesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ImageCollection) που συσχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα `PictureFrame` με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου [addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) που εκτίθεται από το αντικείμενο [Shapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection) που σχετίζεται με τη διαφάνεια.
6. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
7. Ορίστε το χρώμα γραμμής του πλαισίου εικόνας.
8. Ορίστε το πάχος γραμμής του πλαισίου εικόνας.
9. Περιστρέψτε το πλαίσιο εικόνας δίνοντας του είτε θετική είτε αρνητική τιμή.
   * Μια θετική τιμή περιστρέφει την εικόνα δεξιόστροφα.
   * Μια αρνητική τιμή περιστρέφει την εικόνα αριστερόστροφα.
10. Προσθέστε ξανά το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
11. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει τη διαδικασία μορφοποίησης του πλαισίου εικόνας:

```javascript
// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Δημιουργεί την κλάση Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Προσθέτει Πλαίσιο Εικόνας με ύψος και πλάτος ισοδύναμα της Εικόνας
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Εφαρμόζει κάποιες μορφοποιήσεις στο PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Συμβουλή" color="primary" %}}

Η Aspose ανέπτυξε πρόσφατα ένα [δωρεάν Collage Maker](https://products.aspose.app/slides/el/collage). Αν χρειαστεί ποτέ να [συγχωνεύσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, ή να [δημιουργήσετε πλέγματα από φωτογραφίες](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτήν την υπηρεσία. 

{{% /alert %}}

## **Προσθήκη Εικόνας ως Σύνδεσμο**

Για να αποφύγετε μεγάλα μεγέθη παρουσίασης, μπορείτε να προσθέτετε εικόνες (ή βίντεο) μέσω συνδέσμων αντί να ενσωματώνετε τα αρχεία απευθείας στην παρουσίαση. Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε μια εικόνα και ένα βίντεο σε ένα σύμβολο κράτησης θέσης:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Περικοπή Εικόνας**

Αυτός ο κώδικας JavaScript δείχνει πώς να περικόψετε μια υπάρχουσα εικόνα σε μια διαφάνεια:

```javascript
var pres = new aspose.slides.Presentation();
// Δημιουργεί νέο αντικείμενο εικόνας
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Προσθέτει Πλαίσιο Εικόνας σε μια Διαφάνεια
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Κόβει την εικόνα (τιμές ποσοστών)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Αποθηκεύει το αποτέλεσμα
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Διαγραφή Περιοχών Περικοπής του Πλαισίου Εικόνας**

Εάν θέλετε να διαγράψετε τις περιοχές που έχουν περικοπεί από μια εικόνα που περιέχεται σε ένα πλαίσιο, μπορείτε να χρησιμοποιήσετε τη μέθοδο [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα ή την αρχική εάν η περικοπή είναι περιττή.

Αυτός ο κώδικας JavaScript επιδεικνύει τη λειτουργία:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Λαμβάνει το PictureFrame από την πρώτη διαφάνεια
    var picFrame = slide.getShapes().get_Item(0);
    // Διαγράφει τις περικομμένες περιοχές της εικόνας PictureFrame και επιστρέφει την περικομμένη εικόνα
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Αποθηκεύει το αποτέλεσμα
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Εάν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/), αυτή η ρύθμιση μπορεί να μειώσει το μέγεθος της παρουσίασης. Διαφορετικά, ο αριθμός των εικόνων στην τελική παρουσίαση θα αυξηθεί.

Αυτή η μέθοδος μετατρέπει αρχεία WMF/EMF σε raster εικόνα PNG κατά την πράξη της περικοπής. 

{{% /alert %}}

## **Συμπίεση Εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [PictureFillFormat.compressImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) . Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της βάσει του μεγέθους του σχήματος και της καθορισμένης ανάλυσης, με την επιλογή διαγραφής των περιοχών που έχουν περικοπεί.

Ρυθμίζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format → Compress Pictures → Resolution** του PowerPoint.

Τα παρακάτω παραδείγματα JavaScript δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση καθορίζοντας μια στοχευμένη ανάλυση και προαιρετικά αφαιρώντας περιοχές που έχουν περικοπεί:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Συμπιέζει την εικόνα με στόχο ανάλυση 150 DPI (ανάλυση ιστού) και αφαιρεί τις περικομμένες περιοχές.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Ελέγχει το αποτέλεσμα της συμπίεσης.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ή χρησιμοποιώντας άλλη προεπιλεγμένη τιμή DPI:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Συμπιέζει την εικόνα σε 96 DPI (ανάλυση email), αφαιρώντας τις περικομμένες περιοχές.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση βάσει του μεγέθους του σχήματος και του παρεχόμενου DPI. Οι περικομμένες περιοχές μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου. Εάν η εικόνα είναι μεταφόρμα (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επίσης, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς ανάλογα με την ανάλυση, παρόμοια με την αντιμετώπιση υψηλής ανάλυσης JPEG από το PowerPoint.

{{% /alert %}}

## **Κλείδωμα Αναλογίας Διαστάσεων**

Εάν θέλετε ένα σχήμα που περιέχει μια εικόνα να διατηρεί την αναλογία διαστάσεων ακόμη και μετά την αλλαγή των διαστάσεων της εικόνας, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) για να ορίσετε τη ρύθμιση *Lock Aspect Ratio*.

Αυτός ο κώδικας JavaScript δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων ενός σχήματος:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // ορίστε το σχήμα ώστε να διατηρεί την αναλογία διαστάσεων κατά την αλλαγή μεγέθους
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο την αναλογία διαστάσεων του σχήματος και όχι της εικόνας που περιέχει.

{{% /alert %}}

## **Χρήση Ιδιότητας StretchOff**

Χρησιμοποιώντας τις μεθόδους [setStretchOffsetLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) και [setStretchOffsetBottom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) από την κλάση [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat), μπορείτε να ορίσετε ένα ορθογώνιο γέμισης.

Όταν καθορίζεται τέντωμα για μια εικόνα, ένα ορθογώνιο προέλευσης κλιμακώνεται ώστε να ταιριάζει στο καθορισμένο ορθογώνιο γέμισης. Κάθε άκρη του ορθογωνίου γέμισης ορίζεται από ένα ποσοστό offset από την αντίστοιχη άκρη του περιβλήματος του σχήματος. Ένα θετικό ποσοστό υποδεικνύει ενδοχώριο, ενώ ένα αρνητικό ποσοστό εξωχώριο.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο `AutoShape`. 
4. Δημιουργήστε μια εικόνα.
5. Ορίστε τον τύπο γέμισης του σχήματος.
6. Ορίστε τη λειτουργία γέμισματος εικόνας του σχήματος.
7. Προσθέστε μια ορισμένη εικόνα για να γεμίσει το σχήμα.
8. Καθορίστε τα offsets της εικόνας από την αντίστοιχη άκρη του περιβλήματος του σχήματος.
9. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει μια διαδικασία κατά την οποία χρησιμοποιείται η ιδιότητα StretchOff:

```javascript
// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Δημιουργεί την κλάση ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Προσθέτει AutoShape ορισμένο σε Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Ορίζει τον τύπο γέμισματος του σχήματος
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Ορίζει τη λειτουργία γέμισματος εικόνας του σχήματος
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Ορίζει την εικόνα για γέμισμα του σχήματος
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Καθορίζει τις μετατοπίσεις της εικόνας από την αντίστοιχη άκρη του πλαισίου του σχήματος
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να μάθω ποιες μορφές εικόνας υποστηρίζονται για το PictureFrame;**

Το Aspose.Slides υποστηρίζει τόσο raster εικόνες (PNG, JPEG, BMP, GIF κ.λπ.) όσο και διανυσματικές εικόνες (π.χ., SVG) μέσω του αντικειμένου εικόνας που ανατίθεται σε ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/). Η λίστα των υποστηριζόμενων μορφών γενικά συμπίπτει με τις δυνατότητες του κινητήρα διαφάνειας και μετατροπής εικόνας.

**Πώς θα επηρεάσει η προσθήκη δεκάδων μεγάλων εικόνων το μέγεθος και την απόδοση του PPTX;**

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθά στη διατήρηση του μικρότερου μεγέθους παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να παραμένουν προσβάσιμα. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων μέσω συνδέσμου για μείωση του μεγέθους του αρχείου.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας ώστε να μην μετακινηθεί/αλλάξει μέγεθος τυχαία;**

Χρησιμοποιήστε τα [shape locks](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) για ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) (π.χ., να απενεργοποιήσετε τη μετακίνηση ή το μέγεθος). Ο μηχανισμός κλειδώματος υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένου του [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/).

**Διατηρείται η πιστότητα του διανύσματος SVG όταν εξάγεται μια παρουσίαση σε PDF/εικόνες;**

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Όταν γίνεται [εξαγωγή σε PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/) ή σε [raster μορφές](/slides/el/nodejs-java/convert-powerpoint-to-png/), το αποτέλεσμα ενδέχεται να γίνει raster ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.