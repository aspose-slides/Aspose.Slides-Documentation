---
title: Διαχείριση φόντων παρουσίασης σε Android
linktitle: Φόντο διαφάνειας
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
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java, με συμβουλές κώδικα για τη βελτίωση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα στερεά χρώματα, οι διαβαθμίσεις και οι εικόνες χρησιμοποιούνται συχνά ως φόντο διαφάνειας. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μια μοναδική διαφάνεια) ή για μια **διαφάνεια προτύπου** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![Φόντο PowerPoint](powerpoint-background.png)

## **Ορισμός Φόντου Στερεού Χρώματος για Κανονική Διαφάνεια**

Η Aspose.Slides σας επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση — ακόμα και αν η παρουσίαση χρησιμοποιεί διαφάνεια προτύπου. Η αλλαγή εφαρμόζεται μόνο στην επιλεγμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType] της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType] του φόντου της διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/) για να καθορίσετε το στερεό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα μπλε στερεό χρώμα ως φόντο για μια κανονική διαφάνεια:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
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

## **Ορισμός Φόντου Στερεού Χρώματος για Διαφάνεια Προτύπου**

Η Aspose.Slides σας επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για τη διαφάνεια προτύπου σε μια παρουσίαση. Η διαφάνεια προτύπου λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση για όλες τις διαφάνειες, έτσι όταν επιλέγετε ένα στερεό χρώμα για το φόντο της διαφάνειας προτύπου, εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType] της διαφάνειας προτύπου (μέσω `getMasters`) σε `OwnBackground`.
3. Ορίστε το [FillType] του φόντου της διαφάνειας προτύπου σε `Solid`.
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) για να καθορίσετε το στερεό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα στερεό χρώμα (πράσινο) ως φόντο για μια διαφάνεια προτύπου:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ορίστε το χρώμα φόντου της διαφάνειας πρότυπου σε πράσινο.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Φόντου Διαβάθμισης για Διαφάνεια**

Η διαβάθμιση είναι ένα γραφικό εφέ που δημιουργείται από μια διαδοχική αλλαγή χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, οι διαβάθμιση μπορούν να κάνουν τις παρουσιάσεις να φαίνονται πιο καλλιτεχνικές και επαγγελματικές. Η Aspose.Slides σας επιτρέπει να ορίσετε ένα χρώμα διαβάθμισης ως φόντο για διαφάνειες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType] της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType] του φόντου της διαφάνειας σε `Gradient`.
4. Χρησιμοποιήστε τη μέθοδο [getGradientFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/) για να διαμορφώσετε τις προτιμώμενες ρυθμίσεις διαβάθμισης.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα χρώμα διαβάθμισης ως φόντο για μια διαφάνεια:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Εφαρμόστε ένα εφέ διαβάθμισης στο φόντο.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Προσθέστε τα χρώματα διαβάθμισης. Χωρίς σημεία διαβάθμισης, το φόντο επανέρχεται σε προεπιλεγμένη διαβάθμιση από το μαύρο στο λευκό.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Εκτός από στερεές και διαβαθμισμένες γεμίσεις, η Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφάνειας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Ορίστε το [BackgroundType] της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType] του φόντου της διαφάνειας σε `Picture`.
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε τη μέθοδο [getPictureFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fillformat/) για να ορίσετε την εικόνα ως φόντο.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε μια εικόνα ως φόντο για μια διαφάνεια:

```java
import com.aspose.slides.*;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
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

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσματος φόντου σε ταπετσαρία εικόνας και να τροποποιήσετε τις ιδιότητες επικάλυψης:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Ορίστε την εικόνα που χρησιμοποιείται για τη γέμιση φόντου.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Ορίστε τη λειτουργία γεμίσματος εικόνας σε Ταπετσαρία και προσαρμόστε τις ιδιότητες της ταπετσαρίας.
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

{{% alert color="info" %}}
Διαβάστε περισσότερα: [**Tile Picture As Texture**](/slides/el/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή Διαφάνειας Εικόνας Φόντου**

Ίσως θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Ο παρακάτω κώδικας Java δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Για παράδειγμα.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

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

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη Τιμής Φόντου Διαφάνειας**

Η Aspose.Slides παρέχει τη διεπαφή [IBackgroundEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibackgroundeffectivedata/) για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτή η διεπαφή αποκαλύπτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) και το [EffectFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Χρησιμοποιώντας τη μέθοδο `getBackground` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseslide/), μπορείτε να λάβετε το αποτελεσματικό φόντο μιας διαφάνειας.

Το παρακάτω παράδειγμα Java δείχνει πώς να λάβετε την αποτελεσματική τιμή φόντου μιας διαφάνειας:

```java
import com.aspose.slides.*;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ανακτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη το master, το layout και το theme.
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

### Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να αποκαταστήσω το φόντο του θέματος/διάταξης;

Ναι. Αφαιρέστε τη προσαρμοσμένη γεμιά της διαφάνειας και το φόντο θα κληρονομηθεί εκ νέου από την αντίστοιχη διαφάνεια [διάταξης](/slides/el/androidjava/slide-layout/)/[προτύπου](/slides/el/androidjava/slide-master/) (δηλαδή το [φόντο θέματος](/slides/el/androidjava/presentation-theme/)).

### Τι συμβαίνει με το φόντο αν αλλάξω αργότερα το θέμα της παρουσίασης;

Αν μια διαφάνεια έχει τη δική της γεμιά, αυτή παραμένει αμετάβλητη. Αν το φόντο κληρονομείται από τη [διάταξη](/slides/el/androidjava/slide-layout/)/[πρότυπο](/slides/el/androidjava/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [νέο θέμα](/slides/el/androidjava/presentation-theme/)).