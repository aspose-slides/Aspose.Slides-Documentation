---
title: Διαχείριση Παρασκηνίων Παρουσίας σε Android
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/androidjava/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- στερεό χρώμα
- χρώμα διαβάθμισης
- φόντο εικόνας
- διαφάνεια φόντου
- ιδιότητες φόντου
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java, με συμβουλές κώδικα για να ενισχύσετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Τα ενιαία χρώματα, οι διαβαθμίσεις και οι εικόνες χρησιμοποιούνται συχνά ως φόντο διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μία μόνο διαφάνεια) ή μια **διαφάνεια master** (εφαρμόζεται ταυτόχρονα σε πολλές διαφάνειες).

![Φόντο PowerPoint](powerpoint-background.png)

## **Ορισμός Σταθερού Χρώματος Φόντου για Κανονική Διαφάνεια**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα σταθερό χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση — ακόμη και αν η παρουσίαση χρησιμοποιεί διαφάνεια master. Η αλλαγή εφαρμόζεται μόνο στην επιλεγμένη διαφάνεια.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType] της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType] του φόντου της διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/) για να ορίσετε το σταθερό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε μπλε σταθερό χρώμα ως φόντο για μια κανονική διαφάνεια:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ορίστε το χρώμα φόντου της διαφάνειας σε μπλε.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Σταθερού Χρώματος Φόντου για Διαφάνεια Master**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα σταθερό χρώμα ως φόντο για τη διαφάνεια master σε μια παρουσίαση. Η διαφάνεια master λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση για όλες τις διαφάνειες, έτσι όταν επιλέγετε ένα σταθερό χρώμα για το φόντο της διαφάνειας master, αυτό εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType] της διαφάνειας master (μέσω `getMasters`) σε `OwnBackground`.
3. Ορίστε το [FillType] του φόντου της διαφάνειας master σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) για να ορίσετε το σταθερό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα σταθερό χρώμα (πράσινο) ως φόντο για τη διαφάνεια master:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ορίστε το χρώμα φόντου για τη διαφάνεια Master σε Πράσινο δάσους.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Διαβαθμισμένου Φόντου για Διαφάνεια**

Η διαβαθμίση είναι ένα γραφικό εφέ που δημιουργείται από μια βαθμιαία αλλαγή χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, οι διαβαθμίσεις μπορούν να κάνουν τις παρουσιάσεις να φαίνονται πιο καλλιτεχνικές και επαγγελματικές. Το Aspose.Slides σας επιτρέπει να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για διαφάνειες.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType] της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType] του φόντου της διαφάνειας σε `Gradient`.
4. Χρησιμοποιήστε τη μέθοδο [getGradientFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/) για να διαμορφώσετε τις προτιμώμενες ρυθμίσεις διαβαθμίσεων.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για μια διαφάνεια:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Εφαρμόστε ένα εφέ διαβάθμισης στο φόντο.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Εκτός από σταθερές και διαβαθμισμένες γεμίσεις, το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφανειών.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType] της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType] του φόντου της διαφάνειας σε `Picture`.
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε τη μέθοδο [getPictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/) για να αντιστοιχίσετε την εικόνα ως φόντο.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε μια εικόνα ως φόντο για μια διαφάνεια:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ορίστε τις ιδιότητες εικόνας φόντου.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Φορτώστε την εικόνα.
    IImage image = Images.fromFile("Tulips.jpg");
    // Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσματος φόντου σε εικόνα πλέγματος και να τροποποιήσετε τις ιδιότητες επικάλυψης:

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Ορίστε την εικόνα που θα χρησιμοποιηθεί για το γέμισμα φόντου.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Ορίστε τη λειτουργία γεμίσματος εικόνας σε Πλακίδιο και προσαρμόστε τις ιδιότητες πλακιδίου.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Διαβάστε περισσότερα: [**Εικόνα Πλακετών ως Υφή**](/slides/el/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή Διαφάνειας Εικόνας Φόντου**

Μπορεί να θέλετε να ρυθμίσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Το παρακάτω κώδικα Java δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```java
int transparencyValue = 30; // Για παράδειγμα.

// Λάβετε τη συλλογή των λειτουργιών μετασχηματισμού εικόνας.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Βρείτε ένα υπάρχον εφέ διαφάνειας σταθερού ποσοστού.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Ορίστε τη νέα τιμή διαφάνειας.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Λήψη Τιμής Φόντου Διαφάνειας**

Το Aspose.Slides παρέχει τη διεπαφή [IBackgroundEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibackgroundeffectivedata/) για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτή η διεπαφή εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) και το [EffectFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Χρησιμοποιώντας τη μέθοδο `getBackground` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslide/), μπορείτε να λάβετε το αποτελεσματικό φόντο για μια διαφάνεια.

Το παρακάτω παράδειγμα Java δείχνει πώς να λάβετε την αποτελεσματική τιμή φόντου μιας διαφάνειας:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Αποκτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη το master, τη διάταξη και το θέμα.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να επαναφέρω το φόντο θέματος/διάταξης;**

Ναι. Αφαιρέστε τη προσαρμοσμένη γεμίσματος της διαφάνειας, και το φόντο θα κληθεί ξανά από τη σχετική [layout](/slides/el/androidjava/slide-layout/)/[master](/slides/el/androidjava/slide-master/) διαφάνεια (δηλαδή το [theme background](/slides/el/androidjava/presentation-theme/)).

**Τι συμβαίνει με το φόντο εάν αλλάξω αργότερα το θέμα της παρουσίασης;**

Εάν μια διαφάνεια έχει τη δική της γεμιά, αυτή θα παραμείνει αμετάβλητη. Εάν το φόντο κληθεί από τη [layout](/slides/el/androidjava/slide-layout/)/[master](/slides/el/androidjava/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [new theme](/slides/el/androidjava/presentation-theme/).