---
title: Διαχείριση Πλαισίων Εικόνας σε Παρουσιάσεις χρησιμοποιώντας JavaScript
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
- περικομμένη περιοχή
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
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για Node.js μέσω Java. Βελτιώστε τη ροή εργασίας σας και ενισχύστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Ένα πλαίσιο εικόνας είναι ένα σχήμα που περιέχει μια εικόνα—είναι σαν μια φωτογραφία μέσα σε ένα πλαίσιο. 

Μπορείτε να προσθέσετε μια εικόνα σε μια διαφάνεια μέσω ενός πλαισίου εικόνας. Με αυτόν τον τρόπο, διαμορφώνετε την εικόνα μορφοποιώντας το πλαίσιο εικόνας.

{{% alert  title="Tip" color="primary" %}} 
Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 
{{% /alert %}} 

## **Δημιουργία Πλαισίου Εικόνας**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο `PPImage` προσθέτοντας μια εικόνα στη [ImagesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ImageCollection) που σχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFrame) βασισμένο στο πλάτος και το ύψος της εικόνας μέσω της μεθόδου `addPictureFrame` που εκτίθεται από το αντικείμενο σχήματος που σχετίζεται με την αναφερθείσα διαφάνεια.
6. Προσθέστε ένα πλαίσιο εικόνας (που περιέχει τη φωτογραφία) στη διαφάνεια.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας:

```javascript
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτά τη πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Δημιουργεί ένα στιγμιότυπο της κλάσης Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Προσθέτει ένα πλαίσιο εικόνας με το αντίστοιχο ύψος και πλάτος της εικόνας
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Τα πλαίσια εικόνας σας επιτρέπουν να δημιουργείτε γρήγορα διαφάνειες παρουσίασης βασισμένες σε εικόνες. Όταν συνδυάζετε το πλαίσιο εικόνας με τις επιλογές αποθήκευσης του Aspose.Slides, μπορείτε να διαχειριστείτε τις λειτουργίες εισόδου/εξόδου για να μετατρέψετε εικόνες από μια μορφή σε άλλη.

## **Δημιουργία Πλαισίου Εικόνας με Σχετική Κλίμακα**

Με την αλλαγή της σχετικής κλίμακας μιας εικόνας, μπορείτε να δημιουργήσετε ένα πιο σύνθετο πλαίσιο εικόνας. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της. 
3. Προσθέστε μια εικόνα στη συλλογή εικόνων της παρουσίασης.
4. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PPImage) προσθέτοντας μια εικόνα στη [ImagesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ImageCollection) που σχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
5. Καθορίστε το σχετικό πλάτος και ύψος της εικόνας στο πλαίσιο εικόνας.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας με σχετική κλίμακα:

```javascript
// Δημιουργεί κλάση Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Δημιουργεί κλάση Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Προσθέτει Πλαίσιο Εικόνας με ύψος και πλάτος ισοδύναμα της Εικόνας
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Ορίζει σχετική κλίμακα πλάτους και ύψους
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Εξαγωγή Raster Εικόνων από Πλαίσια Εικόνας**

Μπορείτε να εξάγετε raster εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFrame) και να τις αποθηκεύσετε σε PNG, JPG και άλλες μορφές. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξαγάγετε μια εικόνα από το έγγραφο «sample.pptx» και να τη αποθηκεύσετε σε μορφή PNG.

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

Όταν μια παρουσίαση περιέχει SVG γραφικά τοποθετημένα μέσα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/), το Aspose.Slides for Node.js via Java σας επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη πιστότητα. Διασχίζοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/), να ελέγξετε εάν το υποκείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) περιέχει SVG περιεχόμενο, και στη συνέχεια να αποθηκεύσετε αυτήν την εικόνα σε δίσκο ή ροή στη φυσική της μορφή SVG.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξαγάγετε μια SVG εικόνα από ένα πλαίσιο εικόνας:

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

## **Απόκτηση Διαφάνειας Εικόνας**

Το Aspose.Slides σας επιτρέπει να λάβετε το εφέ διαφάνειας που έχει εφαρμοστεί σε μια εικόνα. Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία:

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

## **Μορφοποίηση Πλαισίου Εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορούν να εφαρμοστούν σε ένα πλαίσιο εικόνας. Χρησιμοποιώντας αυτές τις επιλογές, μπορείτε να τροποποιήσετε ένα πλαίσιο εικόνας ώστε να ταιριάζει σε συγκεκριμένες απαιτήσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PPImage) προσθέτοντας μια εικόνα στη [ImagesCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ImageCollection) που σχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα `PictureFrame` βάσει του πλάτους και του ύψους της εικόνας μέσω της μεθόδου [addPictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) που εκτίθεται από το αντικείμενο [Shapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection) που σχετίζεται με την αναφερθείσα διαφάνεια.
6. Προσθέστε το πλαίσιο εικόνας (που περιέχει τη φωτογραφία) στη διαφάνεια.
7. Ορίστε το χρώμα γραμμής του πλαισίου εικόνας.
8. Ορίστε το πάχος γραμμής του πλαισίου εικόνας.
9. Περιστρέψτε το πλαίσιο εικόνας δίνοντάς του θετική ή αρνητική τιμή.
   * Θετική τιμή περιστρέφει την εικόνα δεξιόστροφα.
   * Αρνητική τιμή περιστρέφει την εικόνα αριστερόστροφα.
10. Προσθέστε πάλι το πλαίσιο εικόνας (που περιέχει τη φωτογραφία) στη διαφάνεια.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει τη διαδικασία μορφοποίησης πλαισίου εικόνας:

```javascript
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Δημιουργεί ένα στιγμιότυπο της κλάσης Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Προσθέτει Πλαίσιο Εικόνας με ύψος και πλάτος ισοδύναμα της Εικόνας
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Εφαρμόζει κάποια μορφοποίηση στο PictureFrameEx
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

{{% alert title="Tip" color="primary" %}}
Η Aspose ανέπτυξε πρόσφατα ένα [δωρεάν Collage Maker](https://products.aspose.app/slides/el/collage). Αν χρειαστεί ποτέ να [συνδυάσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, ή να [δημιουργήσετε πλέγματα από φωτογραφίες](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτήν την υπηρεσία. 
{{% /alert %}}

## **Προσθήκη Εικόνας ως Σύνδεσμος**

Για να αποφύγετε μεγάλου μεγέθους παρουσιάσεις, μπορείτε να προσθέσετε εικόνες (ή βίντεο) μέσω συνδέσμων αντί για ενσωμάτωση των αρχείων απευθείας στην παρουσίαση. Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε μια εικόνα και ένα βίντεο σε έναν placeholder:

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

## **Κοπή Εικόνας**

Αυτός ο κώδικας JavaScript δείχνει πώς να κόψετε μια υπάρχουσα εικόνα σε μια διαφάνεια:

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
    // Προσθέτει ένα Πλαίσιο Εικόνας σε μια Διαφάνεια
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

## **Διαγραφή Περιοχών Περικοπής του Πλαισίου**

Εάν θέλετε να διαγράψετε τις περιοχές που έχουν κοπεί από μια εικόνα που βρίσκεται σε ένα πλαίσιο, μπορείτε να χρησιμοποιήσετε τη μέθοδο [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--). Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα ή την αρχική εικόνα εάν η κοπή δεν είναι απαραίτητη.

Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Αποκτά το PictureFrame από την πρώτη διαφάνεια
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

{{% alert title="NOTE" color="warning" %}} 
Η μέθοδος [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Εάν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/), αυτή η ρύθμιση μπορεί να μειώσει το μέγεθος της παρουσίασης. Διαφορετικά, ο αριθμός των εικόνων στην τελική παρουσίαση θα αυξηθεί.

Η μέθοδος μετατρέπει τα μετααρχεία WMF/EMF σε raster εικόνες PNG κατά την πράξη της περικοπής. 
{{% /alert %}}

## **Συμπίεση Εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [PictureFillFormat.compressImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-). Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της με βάση το μέγεθος του σχήματος και την καθορισμένη ανάλυση, με την επιλογή διαγραφής περιοχών περικοπής.

Προσαρμίζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format → Compress Pictures → Resolution** του PowerPoint.

Τα παρακάτω παραδείγματα JavaScript δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση καθορίζοντας μια στοχευμένη ανάλυση και, προαιρετικά, αφαιρώντας περιοχές περικοπής:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Συμπιέζει την εικόνα με στοχευμένη ανάλυση 150 DPI (ανάλυση ιστοσυνεύσεως) και αφαιρεί τις περικομμένες περιοχές.
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

Ή χρησιμοποιώντας μια άλλη προεπιλεγμένη τιμή DPI:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Συμπιέζει την εικόνα στα 96 DPI (ανάλυση email), αφαιρώντας τις περικομμένες περιοχές.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση βάσει του μεγέθους του σχήματος και του παρεχόμενου DPI. Οι περιοχές που έχουν περικοπεί μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.
Εάν η εικόνα είναι μετααρχείο (WMF/EMF) ή SVG, η συμπίεση δεν εφαρμόζεται. Επίσης, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς ανάλογα με την ανάλυση, όπως συμβαίνει στο PowerPoint για υψηλής ανάλυσης JPEG.
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
    // ορίστε το σχήμα να διατηρεί την αναλογία διαστάσεων κατά την αλλαγή μεγέθους
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο την αναλογία διαστάσεων του σχήματος και όχι της εικόνας που περιέχει. 
{{% /alert %}}

## **Χρήση Ιδιότητας StretchOff**

Χρησιμοποιώντας τις μεθόδους [setStretchOffsetLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) και [setStretchOffsetBottom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) από την κλάση [PictureFillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PictureFillFormat), μπορείτε να ορίσετε ένα ορθογώνιο γεμίσματος.

Όταν καθορίζεται τέντωμα για μια εικόνα, ένα αρχικό ορθογώνιο κλιμακώνεται ώστε να ταιριάζει στο καθορισμένο ορθογώνιο γεμίσματος. Κάθε πλευρά του ορθογωνίου γεμίσματος ορίζεται από ένα ποσοστό μετατόπισης από την αντίστοιχη πλευρά του πλαίσιου του σχήματος. Θετικό ποσοστό ορίζει εντός (inset) ενώ αρνητικό ποσοστό ορίζει εξωτερική (outset) μετατόπιση.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο `AutoShape`. 
4. Δημιουργήστε μια εικόνα.
5. Ορίστε τον τύπο γεμίσματος του σχήματος.
6. Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος.
7. Προσθέστε μια καθορισμένη εικόνα για γέμισμα του σχήματος.
8. Καθορίστε τις μετατοπίσεις της εικόνας από την αντίστοιχη πλευρά του πλαίσιου του σχήματος
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει τη διαδικασία χρήσης της ιδιότητας StretchOff:

```javascript
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Δημιουργεί ένα στιγμιότυπο της κλάσης ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Προσθέτει ένα AutoShape τύπου Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Ορίζει τον τύπο γεμίσματος του σχήματος
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Ορίζει τη λειτουργία γεμίσματος εικόνας του σχήματος
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Ορίζει την εικόνα για γέμισμα του σχήματος
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Καθορίζει τις μετατοπίσεις της εικόνας από την αντίστοιχη πλευρά του περιγράμματος του σχήματος
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

Το Aspose.Slides υποστηρίζει τόσο raster εικόνες (PNG, JPEG, BMP, GIF κ.λπ.) όσο και διανυσματικές εικόνες (π.χ., SVG) μέσω του αντικειμένου εικόνας που ορίζεται σε ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/). Η λίστα των υποστηριζόμενων μορφών συνήθως συμπίπτει με τις δυνατότητες του μηχανήματος μετατροπής διαφάνειας και εικόνας.

**Πώς η προσθήκη δεκάδων μεγάλων εικόνων επηρεάζει το μέγεθος και την απόδοση του PPTX;**

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθά στη διατήρηση του μεγέθους της παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να παραμένουν προσβάσιμα. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων με σύνδεσμο για μείωση του μεγέθους του αρχείου.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας ώστε να μην μετακινείται/αλλάζει μέγεθος κατά λάθος;**

Χρησιμοποιήστε τα «shape locks» για ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) (π.χ., απενεργοποίηση μετακίνησης ή αλλαγής μεγέθους). Ο μηχανισμός κλειδώματος υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένου του [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/).

**Διατηρείται η πιστότητα του διανύσματος SVG κατά την εξαγωγή μιας παρουσίασης σε PDF/εικόνες;**

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Κατά την [εξαγωγή σε PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/) ή σε [raster μορφές](/slides/el/nodejs-java/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να ραστεροποιηθεί ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.