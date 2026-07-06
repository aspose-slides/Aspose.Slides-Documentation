---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις στο Android
linktitle: Πλαίσιο εικόνας
type: docs
weight: 10
url: /el/androidjava/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- προσθήκη εικόνας
- δημιουργία εικόνας
- εξαγωγή εικόνας
- εικόνα raster
- διανυσματική εικόνα
- περικοπή εικόνας
- περικομμένη περιοχή
- ιδιότητα StretchOff
- μορφοποίηση πλαισίου εικόνας
- ιδιότητες πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- λόγος διαστάσεων
- διαφάνεια εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Android μέσω Java. Βελτιώστε τη ροή εργασίας σας και ενισχύστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Το πλαίσιο εικόνας είναι ένα σχήμα που περιέχει μια εικόνα—είναι όπως μια φωτογραφία σε ένα πλαίσιο.

Μπορείτε να προσθέσετε μια εικόνα σε μια διαφάνεια μέσω ενός πλαισίου εικόνας. Με αυτόν τον τρόπο, μπορείτε να μορφοποιήσετε την εικόνα μορφοποιώντας το πλαίσιο εικόνας.

{{% alert title="Συμβουλή" color="primary" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

## **Δημιουργία πλαισίου εικόνας**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά στην διαφάνεια μέσω του δείκτη της.
3. Δημιουργήστε ένα αντικείμενο [IPPImage]() προσθέτοντας μια εικόνα στη συλλογή [IImagescollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IImageCollection) που είναι συνδεδεμένη με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/PictureFrame) με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου `AddPictureFrame` που εκτίθεται από το αντικείμενο σχήματος που σχετίζεται με την αναφερθείσα διαφάνεια.
6. Προσθέστε ένα πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας:

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Δημιουργεί ένα στιγμιότυπο της κλάσης Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Προσθέτει ένα πλαίσιο εικόνας με το αντίστοιχο ύψος και πλάτος της εικόνας
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία πλαισίου εικόνας με σχετική κλίμακα**

Αλλάζοντας τη σχετική κλιμάκωση μιας εικόνας, μπορείτε να δημιουργήσετε ένα πιο πολύπλοκο πλαίσιο εικόνας.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά στην διαφάνεια μέσω του δείκτη της.
3. Προσθέστε μια εικόνα στη συλλογή εικόνων της παρουσίασης.
4. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή [IImagescollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IImageCollection) που είναι συνδεδεμένη με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
5. Καθορίστε το σχετικό πλάτος και ύψος της εικόνας στο πλαίσιο εικόνας.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας με σχετική κλίμακα:

```java
// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Δημιουργεί ένα στιγμιότυπο της κλάσης Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Προσθέτει Πλαίσιο Εικόνας με ύψος και πλάτος ίσο με αυτά της Εικόνας
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Ορισμός σχετικής κλίμακας πλάτους και ύψους
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εξαγωγή raster εικόνων από πλαίσια εικόνας**

Μπορείτε να εξάγετε raster εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/PictureFrame) και να τις αποθηκεύσετε σε μορφές PNG, JPG και άλλες. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο «sample.pptx» και να την αποθηκεύσετε σε μορφή PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή SVG εικόνων από πλαίσια εικόνας**

Όταν μια παρουσίαση περιέχει SVG γραφικά τοποθετημένα μέσα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/), η Aspose.Slides για Android μέσω Java σάς επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη αξιοπιστία. Διασχίζοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/), να ελέγξετε αν το υποκείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) περιέχει SVG περιεχόμενο και, στη συνέχεια, να αποθηκεύσετε αυτή την εικόνα στο δίσκο ή σε ροή στη γηγενή μορφή SVG.

Το ακόλουθο παράδειγμα κώδικα δείχνει πώς να εξάγετε μια SVG εικόνα από ένα πλαίσιο εικόνας:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Απόκτηση διαφάνειας εικόνας**

Η Aspose.Slides επιτρέπει την λήψη του εφέ διαφάνειας που εφαρμόζεται σε μια εικόνα. Αυτός ο κώδικας Java δείχνει τη λειτουργία:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Απόκτηση φωτεινότητας και αντίθεσης εικόνας**

Η Aspose.Slides επιτρέπει την λήψη των εφέ φωτεινότητας και αντίθεσης που εφαρμόζονται σε μια εικόνα. Η διεπαφή [ILuminance](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iluminance/) αντιπροσωπεύει αυτή τη μετασχηματιστική λειτουργία εικόνας.

Αυτός ο κώδικας Java δείχνει πώς να λάβετε τις ρυθμίσεις φωτεινότητας και αντίθεσης από ένα πλαίσιο εικόνας:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση πλαισίου εικόνας**

Η Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορούν να εφαρμοστούν σε ένα πλαίσιο εικόνας. Χρησιμοποιώντας αυτές τις επιλογές, μπορείτε να τροποποιήσετε ένα πλαίσιο εικόνας ώστε να ταιριάζει σε συγκεκριμένες απαιτήσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά στην διαφάνεια μέσω του δείκτη της.
3. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή [IImagescollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IImageCollection) που είναι συνδεδεμένη με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα `PictureFrame` με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου [AddPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) που εκτίθεται από το αντικείμενο [IShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection) που συσχετίζεται με την αναφερθείσα διαφάνεια.
6. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
7. Ορίστε το χρώμα γραμμής του πλαισίου εικόνας.
8. Ορίστε το πάχος γραμμής του πλαισίου εικόνας.
9. Περιστρέψτε το πλαίσιο εικόνας δίνοντας του είτε θετική είτε αρνητική τιμή.
   * Μια θετική τιμή περιστρέφει την εικόνα δεξιόστροφα.
   * Μια αρνητική τιμή περιστρέφει την εικόνα αριστερόστροφα.
10. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει τη διαδικασία μορφοποίησης πλαισίου εικόνας:

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Δημιουργεί ένα στιγμιότυπο της κλάσης Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Προσθέτει Πλαίσιο Εικόνας με ύψος και πλάτος ίσο με αυτά της Εικόνας
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Εφαρμόζει μορφοποίηση στο PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Συμβουλή" color="primary" %}}

Η Aspose ανέπτυξε πρόσφατα ένα [δωρεάν Collage Maker](https://products.aspose.app/slides/el/collage). Αν χρειαστεί να [συγχωνεύσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, ή [δημιουργήσετε πλέγματα από φωτογραφίες](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτή τη υπηρεσία. 

{{% /alert %}}

## **Προσθήκη εικόνας ως σύνδεσμο**

Για να αποφύγετε μεγάλα μεγέθη παρουσιάσεων, μπορείτε να προσθέτετε εικόνες (ή βίντεο) μέσω συνδέσμων αντί να ενσωματώνετε τα αρχεία άμεσα στις παρουσιάσεις. Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε μια εικόνα και ένα βίντεο σε έναν χώρο κράτησης:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Περικοπή εικόνων**

Αυτός ο κώδικας Java δείχνει πώς να περικόψετε μια υπάρχουσα εικόνα σε μια διαφάνεια:

```java
Presentation pres = new Presentation();
// Δημιουργεί νέο αντικείμενο εικόνας
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Προσθέτει ένα Πλαίσιο Εικόνας σε μια Διαφάνεια
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Κόβει την εικόνα (τιμές ποσοστού)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Αποθηκεύει το αποτέλεσμα
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαγραφή περικομμένων περιοχών εικόνας**

Αν θέλετε να διαγράψετε τις περικομμένες περιοχές μιας εικόνας που βρίσκεται σε ένα πλαίσιο, μπορείτε να χρησιμοποιήσετε τη μέθοδο [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα ή την αρχική εικόνα εάν δεν απαιτείται περικοπή.

Αυτός ο κώδικας Java δείχνει τη λειτουργία:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Λαμβάνει το Πλαίσιο Εικόνας από την πρώτη διαφάνεια
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Διαγράφει τις περικομμένες περιοχές της εικόνας του Πλαισίου Εικόνας και επιστρέφει την περικομμένη εικόνα
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Αποθηκεύει το αποτέλεσμα
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Εάν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/), αυτή η ρύθμιση μπορεί να μειώσει το μέγεθος της παρουσίασης. Διαφορετικά, ο αριθμός των εικόνων στην τελική παρουσίαση θα αυξηθεί.

Η μέθοδος μετατρέπει αρχεία WMF/EMF σε raster PNG εικόνα κατά τη διαδικασία περικοπής. 

{{% /alert %}}

## **Συμπίεση εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της με βάση το μέγεθος του σχήματος και την καθορισμένη ανάλυση, με την επιλογή διαγραφής περικομμένων περιοχών.

Ρυθμίζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format > Compress Pictures > Resolution** του PowerPoint.

Τα παρακάτω παραδείγματα Java δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση ορίζοντας στόχο ανάλυσης και προαιρετικά αφαιρώντας τις περικομμένες περιοχές:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Συμπιέζει την εικόνα με στόχο την ανάλυση 150 DPI (ανάλυση ιστού) και αφαιρεί τις περικομμένες περιοχές.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Ελέγχει το αποτέλεσμα της συμπίεσης.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ή χρησιμοποιώντας άμεσα μια προσαρμοσμένη τιμή DPI:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Συμπιέζει την εικόνα σε 150 DPI (ανάλυση ιστοσέλιδας), αφαιρώντας τις περικομμένες περιοχές.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση βάσει του μεγέθους του σχήματος και του παρεχόμενου DPI. Οι περικομμένες περιοχές μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.  
Εάν η εικόνα είναι αρχείο metafile (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επίσης, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς ανάλογα με την ανάλυση, όπως συμβαίνει στο PowerPoint για υψηλής ανάλυσης JPEG.

{{% /alert %}}

## **Κλείδωμα αναλογίας διαστάσεων**

Εάν θέλετε ένα σχήμα που περιέχει μια εικόνα να διατηρεί την αναλογία διαστάσεων ακόμη και μετά την αλλαγή των διαστάσεων της εικόνας, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) για να ορίσετε τη ρύθμιση *Lock Aspect Ratio*.

Αυτός ο κώδικας Java δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων ενός σχήματος:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // Ορίζει το σχήμα να διατηρεί την αναλογία διαστάσεων κατά την αλλαγή μεγέθους
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο την αναλογία του σχήματος και όχι την εικόνα που περιέχει.

{{% /alert %}}

## **Χρήση ιδιότητας StretchOff**

Χρησιμοποιώντας τις ιδιότητες [StretchOffsetLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) και [StretchOffsetBottom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) από τη διεπαφή [IPictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat) και την κλάση [PictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat), μπορείτε να ορίσετε ένα ορθογώνιο γεμίσματος.

Όταν ορίζεται η τήξη (stretch) για μια εικόνα, ένα πηγαίο ορθογώνιο κλιμακώνεται ώστε να ταιριάζει στο ορθογώνιο γεμίσματος που έχει καθοριστεί. Κάθε άκρο του ορθογωνίου γεμίσματος ορίζεται με ποσοστιαία μετατόπιση από το αντίστοιχο άκρο του πλαισίου του σχήματος. Μια θετική ποσοστιαία τιμή υποδεικνύει εσωτερική μετατόπιση, ενώ μια αρνητική τιμή εξωτερική.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά στην διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο `AutoShape`.
4. Δημιουργήστε μια εικόνα.
5. Ορίστε τον τύπο γεμίσματος του σχήματος.
6. Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος.
7. Προσθέστε μια εικόνα σύμπλεγμα για γέμισμα του σχήματος.
8. Καθορίστε τις μετατοπίσεις της εικόνας από το αντίστοιχο άκρο του πλαισίου του σχήματος.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει μια διαδικασία κατά την οποία χρησιμοποιείται η ιδιότητα StretchOff:

```java
// Δημιουργεί στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);

    // Δημιουργεί στιγμιότυπο της κλάσης ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Προσθέτει AutoShape τύπου Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Ορίζει τον τύπο γεμίσματος του σχήματος
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Ορίζει τη λειτουργία γεμίσματος εικόνας του σχήματος
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Ορίζει την εικόνα για γέμισμα του σχήματος
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Καθορίζει τις μετατοπίσεις της εικόνας από το αντίστοιχο άκρο του πλαισίου του σχήματος
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να μάθω ποιοι τύποι εικόνας υποστηρίζονται για το PictureFrame;**

Η Aspose.Slides υποστηρίζει τόσο raster εικόνες (PNG, JPEG, BMP, GIF κ.λπ.) όσο και διανυσματικές εικόνες (π.χ. SVG) μέσω του αντικειμένου εικόνας που αντιστοιχίζεται σε ένα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/). Η λίστα των υποστηριζόμενων μορφών γενικά συμπίπτει με τις δυνατότητες του μηχανισμού μετατροπής διαφανειών και εικόνων.

**Πώς θα επηρεάσει η προσθήκη δεκάδων μεγάλων εικόνων το μέγεθος και την απόδοση του PPTX;**

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθά στη διατήρηση μικρότερου μεγέθους παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να είναι προσβάσιμα. Η Aspose.Slides προσφέρει τη δυνατότητα προσθήκης εικόνων μέσω συνδέσμου για μείωση του μεγέθους του αρχείου.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας ώστε να μην μετακινείται/αλλάζει μέγεθος τυχαία;**

Χρησιμοποιήστε τα [shape locks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) για ένα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/) (π.χ., απενεργοποίηση κίνησης ή αλλαγής μεγέθους). Ο μηχανισμός κλειδώματος υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένων των [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/).

**Διατηρείται η ακεραιότητα των SVG διανυσματικών εικόνων κατά την εξαγωγή μιας παρουσίασης σε PDF/εικόνες;**

Η Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Κατά την [εξαγωγή σε PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/) ή σε [raster μορφές](/slides/el/androidjava/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να ραστεροποιηθεί ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.