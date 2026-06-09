---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις Android
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
- raster εικόνα
- διανυσματική εικόνα
- κοπή εικόνας
- κομμένη περιοχή
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
- Android
- Java
- Aspose.Slides
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Android μέσω Java. Απλοποιήστε τη ροή εργασίας σας και βελτιώστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Ένα πλαίσιο εικόνας είναι ένα σχήμα που περιέχει μια εικόνα—είναι σαν μια εικόνα σε πλαίσιο.

Μπορείτε να προσθέσετε μια εικόνα σε μια διαφάνεια μέσω ενός πλαισίου εικόνας. Με αυτόν τον τρόπο, μπορείτε να μορφοποιήσετε την εικόνα μορφοποιώντας το πλαίσιο εικόνας.

{{% alert title="Συμβουλή" color="primary" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

## **Δημιουργία πλαισίου εικόνας**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [IPPImage]() προσθέτοντας μια εικόνα στη συλλογή [IImagescollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IImageCollection) που σχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/PictureFrame) με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου `AddPictureFrame` που εκτίθεται από το αντικείμενο σχήματος που σχετίζεται με τη συγκεκριμένη διαφάνεια.
6. Προσθέστε ένα πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας:

```java
// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Δημιουργεί την κλάση Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Προσθέτει πλαίσιο εικόνας με το ισοδύναμο ύψος και πλάτος της εικόνας
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία πλαισίου εικόνας με σχετική κλίμακα**

Αλλάζοντας τη σχετική κλίμακα μιας εικόνας, μπορείτε να δημιουργήσετε ένα πιο σύνθετο πλαίσιο εικόνας. 

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε μια εικόνα στη συλλογή εικόνων της παρουσίασης.
4. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή [IImagescollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IImageCollection) που σχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.
5. Καθορίστε το σχετικό πλάτος και ύψος της εικόνας στο πλαίσιο εικόνας.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας με σχετική κλίμακα:

```java
// Δημιουργεί τη κλάση Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Δημιουργεί τη κλάση Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Προσθέτει πλαίσιο εικόνας με ύψος και πλάτος ισοδύναμα της εικόνας
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Ορίζει τη σχετική κλίμακα ύψους και πλάτους
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

Μπορείτε να εξάγετε raster εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/PictureFrame) και να τις αποθηκεύσετε σε PNG, JPG και άλλες μορφές. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο «sample.pptx» και να τη αποθηκεύσετε σε μορφή PNG.

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

Όταν μια παρουσίαση περιέχει SVG γραφικά ενσωματωμένα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/), το Aspose.Slides for Android via Java σάς επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη ακρίβεια. Διασχίζοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/), να ελέγξετε εάν το υποκείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) περιέχει περιεχόμενο SVG και, στη συνέχεια, να αποθηκεύσετε εκείνη την εικόνα στον δίσκο ή σε μια ροή στη γηγενή μορφή SVG.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια SVG εικόνα από ένα πλαίσιο εικόνας:

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

## **Λήψη διαφάνειας εικόνας**

Το Aspose.Slides σάς επιτρέπει να λάβετε το εφέ διαφάνειας που εφαρμόζεται σε μια εικόνα. Αυτός ο κώδικας Java παρουσιάζει τη λειτουργία:

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

## **Μορφοποίηση πλαισίου εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορούν να εφαρμοστούν σε ένα πλαίσιο εικόνας. Χρησιμοποιώντας αυτές τις επιλογές, μπορείτε να τροποποιήσετε ένα πλαίσιο εικόνας ώστε να ταιριάζει σε συγκεκριμένες απαιτήσεις.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή [IImagescollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IImageCollection) που σχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα `PictureFrame` με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου [AddPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) που εκτίθεται από το αντικείμενο [IShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection) που σχετίζεται με τη συγκεκριμένη διαφάνεια.
6. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
7. Ορίστε το χρώμα γραμμής του πλαισίου εικόνας.
8. Ορίστε το πάχος γραμμής του πλαισίου εικόνας.
9. Περιστρέψτε το πλαίσιο εικόνας δίνοντας είτε θετική είτε αρνητική τιμή.
   * Μια θετική τιμή περιστρέφει την εικόνα δεξιόστροφα. 
   * Μια αρνητική τιμή περιστρέφει την εικόνα αριστερόστροφα.
10. Προσθέστε ξανά το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει τη διαδικασία μορφοποίησης πλαισίου εικόνας:

```java
// Δημιουργεί τη κλάση Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Δημιουργεί τη κλάση Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Προσθέτει πλαίσιο εικόνας με ύψος και πλάτος ισοδύναμα της εικόνας
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Εφαρμόζει κάποιες μορφοποιήσεις στο PictureFrameEx
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

Η Aspose δημιούργησε πρόσφατα ένα [δωρεάν Collage Maker](https://products.aspose.app/slides/el/collage). Εάν χρειαστεί να [συγχωνεύσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, ή να [δημιουργήσετε πλέγματα από φωτογραφίες](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτήν την υπηρεσία. 

{{% /alert %}}

## **Προσθήκη εικόνας ως σύνδεσμος**

Για να αποφύγετε μεγάλα μεγέθη παρουσίασης, μπορείτε να προσθέτετε εικόνες (ή βίντεο) μέσω συνδέσμων αντί να ενσωματώνετε τα αρχεία απευθείας στις παρουσιάσεις. Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε μια εικόνα και ένα βίντεο σε έναν placeholder:

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

## **Κοπή εικόνων**

Αυτός ο κώδικας Java δείχνει πώς να κόψετε μια υπάρχουσα εικόνα σε μια διαφάνεια:

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

    // Προσθέτει ένα PictureFrame σε μια διαφάνεια
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Κόβει την εικόνα (τιμές ποσοστών)
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

## **Διαγραφή κομμένων περιοχών πλαισίου εικόνας**

Εάν θέλετε να διαγράψετε τις κομμένες περιοχές μιας εικόνας που βρίσκεται σε πλαίσιο, μπορείτε να χρησιμοποιήσετε τη μέθοδο [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Αυτή η μέθοδος επιστρέφει την κομμένη εικόνα ή την αρχική εικόνα εάν η κοπή δεν είναι απαραίτητη.

Αυτός ο κώδικας Java επιδεικνύει τη λειτουργία:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Λαμβάνει το PictureFrame από την πρώτη διαφάνεια
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Διαγράφει τις κομμένες περιοχές της εικόνας του PictureFrame και επιστρέφει την κομμένη εικόνα
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Αποθηκεύει το αποτέλεσμα
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) προσθέτει την κομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Εάν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/), αυτή η ρύθμιση μπορεί να μειώσει το μέγεθος της παρουσίασης. Διαφορετικά, ο αριθμός των εικόνων στην τελική παρουσίαση θα αυξηθεί.

Η μέθοδος μετατρέπει αρχεία metafile WMF/EMF σε raster PNG εικόνα κατά τη διαδικασία κοπής. 

{{% /alert %}}

## **Συμπίεση εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) .
Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της βάσει του μεγέθους του σχήματος και της καθορισμένης ανάλυσης, με την επιλογή να διαγράψετε τις κομμένες περιοχές.

Ρυθμίζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format > Compress Pictures > Resolution** του PowerPoint.

Τα παρακάτω παραδείγματα Java δείχνουν πώς να συμπιέσετε μια εικόνα σε παρουσίαση καθορίζοντας μια στοχευμένη ανάλυση και προαιρετικά αφαιρώντας τις κομμένες περιοχές:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Συμπιέζει την εικόνα με στοχευμένη ανάλυση 150 DPI (ανάλυση Web) και αφαιρεί τις κομμένες περιοχές.
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

Ή χρησιμοποιώντας απευθείας μια προσαρμοσμένη τιμή DPI:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Συμπιέζει την εικόνα σε 150 DPI (ανάλυση web), αφαιρώντας τις κομμένες περιοχές.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση βάσει του μεγέθους του σχήματος και του παρεχόμενου DPI. Οι κομμένες περιοχές μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.  
Εάν η εικόνα είναι metafile (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επίσης, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς βάσει της ανάλυσης, όπως γίνεται στο PowerPoint για JPEG υψηλής ανάλυσης.

{{% /alert %}}

## **Κλείδωμα αναλογίας διαστάσεων**

Εάν θέλετε ένα σχήμα που περιέχει εικόνα να διατηρεί την αναλογία διαστάσεων ακόμη και μετά την αλλαγή των διαστάσεων της εικόνας, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) για να ορίσετε τη ρύθμιση *Lock Aspect Ratio*.

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

    // Ορίστε το σχήμα ώστε να διατηρεί την αναλογία διαστάσεων κατά την αλλαγή μεγέθους
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο την αναλογία διαστάσεων του σχήματος και όχι της εικόνας που περιέχει.

{{% /alert %}}

## **Χρήση της ιδιότητας StretchOff**

Χρησιμοποιώντας τις ιδιότητες [StretchOffsetLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) και [StretchOffsetBottom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) από το interface [IPictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat) και την κλάση [PictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPictureFillFormat), μπορείτε να ορίσετε ένα ορθογώνιο γεμίσματος.

Όταν καθορίζεται τέντωμα για μια εικόνα, ένα αρχικό ορθογώνιο κλιμακώνεται ώστε να ταιριάζει στο καθορισμένο ορθογώνιο γεμίσματος. Κάθε πλευρά του ορθογώνιου γεμίσματος ορίζεται από ένα ποσοστιαίο offset από την αντίστοιχη πλευρά του περιγράμματος του σχήματος. Ένα θετικό ποσοστό υποδηλώνει εσοχή, ενώ ένα αρνητικό ποσοστό υποδηλώνει απόπτωμα.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο `AutoShape`. 
4. Δημιουργήστε μια εικόνα.
5. Ορίστε τον τύπο γεμίσματος του σχήματος.
6. Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος.
7. Προσθέστε μια εικόνα για το γέμισμα του σχήματος.
8. Καθορίστε τα offsets της εικόνας από την αντίστοιχη πλευρά του περιγράμματος του σχήματος.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει μια διαδικασία κατά την οποία χρησιμοποιείται η ιδιότητα StretchOff:

```java
// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);

    // Δημιουργεί την κλάση ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Προσθέτει AutoShape με τύπο Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Ορίζει τον τύπο γεμίσματος του σχήματος
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Ορίζει τη λειτουργία γεμίσματος εικόνας του σχήματος
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Ορίζει την εικόνα που θα γεμίζει το σχήμα
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Καθορίζει τις μετατοπίσεις της εικόνας από την αντίστοιχη άκρη του περιγράμματος του σχήματος
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

Το Aspose.Slides υποστηρίζει τόσο raster εικόνες (PNG, JPEG, BMP, GIF κ.λπ.) όσο και διανυσματικές εικόνες (π.χ., SVG) μέσω του αντικειμένου εικόνας που έχει εκχωρηθεί σε ένα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/). Η λίστα υποστηριζόμενων μορφών γενικά επικαλύπτεται με τις δυνατότητες του μηχανισμού μετατροπής διαφάνειας και εικόνας.

**Πώς η προσθήκη δεκάδων μεγάλων εικόνων επηρεάζει το μέγεθος και την απόδοση του PPTX;**

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθά στη μείωση του μεγέθους της παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να παραμένουν προσβάσιμα. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων με σύνδεσμο για μείωση του μεγέθους του αρχείου.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας ώστε να μην μετακινείται/αλλάζει μέγεθος κατά λάθος;**

Χρησιμοποιήστε τα [shape locks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) για ένα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/) (π.χ., απενεργοποίηση μετακίνησης ή αλλαγής μεγέθους). Ο μηχανισμός κλειδώματος υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένων των [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/).

**Διατηρείται η διανυσματική ποιότητα SVG κατά την εξαγωγή μιας παρουσίασης σε PDF/εικόνες;**

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Όταν γίνεται [εξαγωγή σε PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/) ή σε [raster μορφές](/slides/el/androidjava/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να rasterαριστεί ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG είναι αποθηκευμένο ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.