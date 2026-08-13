---
title: Διαχείριση Υποβάθρων Παρουσίασης σε Java
linktitle: Υπόβαθρο Διαφάνειας
type: docs
weight: 20
url: /el/java/presentation-background/
keywords:
- υπόβαθρο παρουσίασης
- υπόβαθρο διαφάνειας
- στερεό χρώμα
- διαβαθμισμένο χρώμα
- υπόβαθρο εικόνας
- διαφάνεια υποβάθρου
- ιδιότητες υποβάθρου
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά υπόβαθρα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας την Aspose.Slides για Java, με συμβουλές κώδικα για να ενισχύσετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Τα στερεά χρώματα, τα διαβαθμισμένα χρώματα και οι εικόνες χρησιμοποιούνται συχνά ως φόντο διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μια μόνο διαφάνεια) ή μια **κύρια διαφάνεια** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![Φόντο PowerPoint](powerpoint-background.png)

## **Ορισμός Στερεού Χρώματος Φόντου για Κανονική Διαφάνεια**

Η Aspose.Slides σάς επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση — ακόμη και αν η παρουσίαση χρησιμοποιεί μια κύρια διαφάνεια. Η αλλαγή εφαρμόζεται μόνο στην επιλεγμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/java/com.aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του φόντου της διαφάνειας σε `Solid` .
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/#getSolidFillColor--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/) για να καθορίσετε το στερεό χρώμα φόντου.
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

## **Ορισμός Στερεού Χρώματος Φόντου για Κύρια Διαφάνεια**

Η Aspose.Slides σάς επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για τη κύρια διαφάνεια σε μια παρουσίαση. Η κύρια διαφάνεια λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση για όλες τις διαφάνειες, έτσι όταν επιλέγετε ένα στερεό χρώμα για το φόντο της κύριας διαφάνειας, αυτό εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/java/com.aspose.slides/backgroundtype/) της κύριας διαφάνειας (μέσω `getMasters`) σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του φόντου της κύριας διαφάνειας σε `Solid` .
4. Χρησιμοποιήστε τη μέθοδο [getSolidFillColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/#getSolidFillColor--) για να καθορίσετε το στερεό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα στερεό χρώμα (πράσινο) ως φόντο για μια κύρια διαφάνεια:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ορίστε το χρώμα φόντου για τη κύρια διαφάνεια σε πράσινο.
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

Ένα διαβάθμισμα είναι ένα γραφικό εφέ που δημιουργείται από διαδοχική αλλαγή χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, τα διαβαθμισμένα χρώματα μπορούν να κάνουν τις παρουσιάσεις να φαίνονται πιο καλλιτεχνικές και επαγγελματικές. Η Aspose.Slides σάς επιτρέπει να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για διαφάνειες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/java/com.aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του φόντου της διαφάνειας σε `Gradient` .
4. Χρησιμοποιήστε τη μέθοδο [getGradientFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/#getGradientFormat--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/) για να ρυθμίσετε τις προτιμώμενες ρυθμίσεις διαβάθμισης.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Java δείχνει πώς να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για μια διαφάνεια:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Εφαρμόστε ένα διαβαθμισμένο εφέ στο φόντο.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Προσθέστε τα διαβαθμισμένα χρώματα. Χωρίς στάσεις διαβάθμισης, το φόντο επανέρχεται σε προεπιλεγμένη κλίμακα μαύρο-άσπρο.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Εκτός από στερεές και διαβαθμισμένες γεμίσεις, η Aspose.Slides σάς επιτρέπει να χρησιμοποιείτε εικόνες ως φόντο διαφανειών.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) .
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/java/com.aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground` .
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/) του φόντου της διαφάνειας σε `Picture` .
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε τη μέθοδο [getPictureFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/#getPictureFillFormat--) στην κλάση [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/fillformat/) για να ορίσετε την εικόνα ως φόντο.
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

Το παρακάτω δείγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσεως φόντου σε μία επαναλαμβανόμενη εικόνα και να τροποποιήσετε τις ιδιότητες επαναληψίας:

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

    // Ορίστε την εικόνα που χρησιμοποιείται για τη γεμιστική του φόντου.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Ορίστε τη μέθοδο γεμίσματος εικόνας σε Καρό και προσαρμόστε τις ιδιότητες του καρώματος.
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
Διαβάστε περισσότερα: [**Επανάληψη Εικόνας ως Υφή**](/slides/el/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή Διαφάνειας Εικόνας Φόντου**

Μπορεί να θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Το παρακάτω κώδικας Java σας δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Για παράδειγμα.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Λάβετε τη συλλογή των λειτουργιών μετασχηματισμού εικόνας.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Βρείτε ένα υπάρχον εφέ διαφάνειας με σταθερό ποσοστό.
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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη Τιμής Φόντου Διαφάνειας**

Η Aspose.Slides παρέχει τη διεπαφή [IBackgroundEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibackgroundeffectivedata/) για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτή η διεπαφή εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) και το [EffectFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Χρησιμοποιώντας τη μέθοδο `getBackground` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseslide/) , μπορείτε να αποκτήσετε το αποτελεσματικό φόντο για μια διαφάνεια.

```java
import com.aspose.slides.*;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Retrieve the effective background, taking into account master, layout, and theme.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να αποκαταστήσω το φόντο του θέματος/διάταξης;
Ναι. Αφαιρέστε την προσαρμοσμένη γεμιστική της διαφάνειας, και το φόντο θα κληρονομηθεί ξανά από τη σχετική διαφάνεια [διάταξης](/slides/el/java/slide-layout/)/[κύριας διαφάνειας](/slides/el/java/slide-master/) (δηλαδή το [φόντο θέματος](/slides/el/java/presentation-theme/)).

### Τι συμβαίνει με το φόντο αν αλλάξω το θέμα της παρουσίασης αργότερα;
Αν μια διαφάνεια έχει τη δική της γεμιστική, αυτή θα παραμείνει αμετάβλητη. Αν το φόντο κληρονομείται από τη [διάταξη](/slides/el/java/slide-layout/)/[κύρια διαφάνεια](/slides/el/java/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [νέο θέμα](/slides/el/java/presentation-theme/).