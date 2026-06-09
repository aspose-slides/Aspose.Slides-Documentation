---
title: Διαχείριση Φόντων Παρουσίασης σε Java
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/java/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- μονόχρωμο
- χρώμα διαβάθμισης
- φόντο εικόνας
- διαφάνεια φόντου
- ιδιότητες φόντου
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java, με συμβουλές κώδικα για να ενισχύσετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Συχνά χρησιμοποιούνται μονές χρώματα, διαβαθμίσεις και εικόνες για το φόντο των διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μια μονή διαφάνεια) ή μια **διαφάνεια προτύπου** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![PowerPoint background](powerpoint-background.png)

## **Ορισμός ενός μονόχρωμου φόντου για κανονική διαφάνεια**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα μονόχρωμο χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση—ακόμη και αν η παρουσίαση χρησιμοποιεί διαφάνεια προτύπου. Η αλλαγή εφαρμόζεται μόνο στην επιλεγμένη διαφάνεια.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/java/com.aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του φόντου της διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/#getSolidFillColor--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/) για να ορίσετε το μονόχρωμο χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα μπλε μονόχρωμο φόντο για μια κανονική διαφάνεια:

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

## **Ορισμός ενός μονόχρωμου φόντου για διαφάνεια προτύπου**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα μονόχρωμο χρώμα ως φόντο για τη διαφάνεια προτύπου σε μια παρουσίαση. Η διαφάνεια προτύπου λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση για όλες τις διαφάνειες, επομένως όταν επιλέγετε ένα μονόχρωμο φόντο για τη διαφάνεια προτύπου, αυτό εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/java/com.aspose.slides/backgroundtype/) της διαφάνειας προτύπου (μέσω `getMasters`) σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του φόντου της διαφάνειας προτύπου σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/#getSolidFillColor--) για να ορίσετε το μονόχρωμο χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα πράσινο μονόχρωμο φόντο για μια διαφάνεια προτύπου:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ορίστε το χρώμα φόντου για τη διαφάνεια Master σε Δασικό Πράσινο.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός διαβαθμισμένου φόντου για διαφάνεια**

Μια διαβάθμιση είναι ένα γραφικό εφέ που δημιουργείται με σταδιακή αλλαγή χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, οι διαβαθμίσεις μπορούν να κάνουν τις παρουσιάσεις να φαίνονται πιο καλλιτεχνικές και επαγγελματικές. Το Aspose.Slides σας επιτρέπει να ορίσετε ένα χρώμα διαβάθμισης ως φόντο για διαφάνειες.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/java/com.aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του φόντου της διαφάνειας σε `Gradient`.
4. Χρησιμοποιήστε τη μέθοδο [getGradientFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/#getGradientFormat--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/) για να ρυθμίσετε τις προτιμώμενες ρυθμίσεις διαβάθμισης.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα χρώμα διαβάθμισης ως φόντο για μια διαφάνεια:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Εφαρμόστε ένα διαβαθμισμένο εφέ στο φόντο.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός εικόνας ως φόντο διαφάνειας**

Εκτός από μονές και διαβαθμισμένες γεμίσεις, το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφάνειας.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/java/com.aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του φόντου της διαφάνειας σε `Picture`.
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε τη μέθοδο [getPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/#getPictureFillFormat--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/) για να ορίσετε την εικόνα ως φόντο.
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

Το παρακάτω δείγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσματος φόντου σε εικόνα ταμπέλας και να τροποποιήσετε τις ιδιότητες ταμπέλας:

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

    // Ορίστε την εικόνα που χρησιμοποιείται για το γέμισμα φόντου.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Ορίστε τη λειτουργία γεμίσματος εικόνας σε Tile και προσαρμόστε τις ιδιότητες του πλακιδίου.
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
Διαβάστε περισσότερα: [**Πάτσα Εικόνας Ως Υφή**](/slides/el/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή της διαφάνειας εικόνας φόντου**

Μπορεί να θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Ο παρακάτω κώδικας Java δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```java
int transparencyValue = 30; // Για παράδειγμα.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Λήψη της τιμής φόντου διαφάνειας**

Το Aspose.Slides παρέχει τη διεπαφή [IBackgroundEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibackgroundeffectivedata/) για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτή η διεπαφή εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) και το [EffectFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Χρησιμοποιώντας τη μέθοδο `getBackground` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslide/), μπορείτε να λάβετε το αποτελεσματικό φόντο για μια διαφάνεια.

Το παρακάτω παράδειγμα Java δείχνει πώς να λάβετε την αποτελεσματική τιμή φόντου μιας διαφάνειας:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ανακτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη το master, τη διάταξη και το θέμα.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να αποκαταστήσω το φόντο θέματος/διάταξης;**

Ναι. Αφαιρέστε το προσαρμοσμένο γέμισμα της διαφάνειας και το φόντο θα κληρονομηθεί ξανά από την αντίστοιχη διαφάνεια [διάταξης](/slides/el/java/slide-layout/)/[προτύπου](/slides/el/java/slide-master/) (δηλαδή το [φόντο θέματος](/slides/el/java/presentation-theme/)).

**Τι συμβαίνει με το φόντο εάν αλλάξω αργότερα το θέμα της παρουσίασης;**

Εάν μια διαφάνεια έχει το δικό της γέμισμα, θα παραμείνει αμετάβλητο. Εάν το φόντο κληρονομείται από τη [διάταξη](/slides/el/java/slide-layout/)/[πρότυπο](/slides/el/java/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [νέο θέμα](/slides/el/java/presentation-theme/)).