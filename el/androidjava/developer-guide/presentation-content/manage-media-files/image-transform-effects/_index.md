---
title: Διαχείριση Εφέ Μετασχηματισμού Εικόνας σε Παρουσιάσεις σε Android
linktitle: Εφέ Μετασχηματισμού Εικόνας
type: docs
weight: 11
url: /el/androidjava/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- εφέ εικόνας
- φωτεινότητα
- αντίθεση
- γκρι κλίμακα
- δυχρωματισμός
- απόχρωση
- HSL
- αντικατάσταση χρώματος
- θόλωση
- διαφάνεια
- εφέ άλφα
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εφαρμόστε, συνδυάστε, ελέγξτε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Η Aspose.Slides αντιπροσωπεύει τις προσαρμογές εικόνας ως μια ταξινομημένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το πλαίσιο του [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) και αποκτήστε πρόσβαση στο [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). Η επιστρεφόμενη [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) σας επιτρέπει να προσθέσετε, να απαριθμήσετε, να ελέγξετε, να αφαιρέσετε και να εκκαθαρίσετε εφέ χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο παρουσιάζει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρώματος, θόλωση, διαφάνεια, διατεταγμένες αλυσίδες εφέ, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση κυκλικής διαδικασίας PPTX.

## **Κατανόηση Ιδιοκτησίας Εφέ και Επαναχρησιμοποίηση Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) αποθηκεύει ή αναφέρεται στα δεδομένα της πηγαίας εικόνας που ανήκουν στην παρουσίαση.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) ανήκει σε μία γεμιστική εικόνα και παραπέμπει σε έναν πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμού εικόνας.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) είναι το σχήμα διαφάνειας που κατέχει τη σχετική γεμιστική εικόνα, γεωμετρία, ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Ως εκ τούτου, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/). Όταν το ίδιο `IPPImage` περνιέται στη [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) πολλές φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι κλίμακας, ακόμη και αν όλα χρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `ISlidesPicture.getImageTransform` χρησιμοποιείται επίσης από άλλες γεμιστικές εικόνες, όπως σχήμα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν στα πλαίσια εικόνας.

## **Χρήση Έγκυρων Περιοχών Παραμέτρων και Μονάδων**

Οι επιδεικνυόμενες μέθοδοι χρησιμοποιούν τις παρακάτω σημασιολογικές περιοχές και μονάδες. Διατηρήστε τις τιμές εντός αυτών των περιοχών ακόμη και αν κάποια έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε τιμή εκτός ορίου· η μορφή παρουσίασης-στόχος μπορεί να κανονικοποιήσει, αφαιρέσει ή απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίγει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρη περιοχή και μονάδα |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` μέχρι `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Χωρίς αριθμητικές παραμέτρους. Η άλφα παραμένει αμετάβλητη. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Δύο χρώματα για σκούρα και ανοιχτά pixel. Οι τιμές RGB και του καναλιού άλφα που χρησιμοποιεί το `android.graphics.Color` κυμαίνονται από `0` μέχρι `255`. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | `hue` είναι `0` (συμπεριλαμβανομένου) μέχρι `360` (αποκλειστικό) σε μοίρες· `amount` είναι `-100` μέχρι `100`, ποσοστό. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | `hue` είναι `0` (συμπεριλαμβανομένου) μέχρι `360` (αποκλειστικό) σε μοίρες· `saturation` και `luminance` είναι `-100` μέχρι `100`, ποσοστό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` μέχρι `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετράται σε points· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να εκτείνεται έξω από τα αρχικά όρια. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` μέχρι `100` για τυπική κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διαυγές και `100` διατηρεί το υπάρχον άλφα. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` μέχρι `100`, ποσοστό αδιαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` μέχρι `100`, ποσοστό κατωφλίου άλφα. Οι τιμές κάτω από αυτό γίνονται διαυγείς· οι τιμές στο ή πάνω από αυτό γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση άλφα, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό διαμόρφωσης άλφα 65 %.

## **Εφαρμογή Φωτεινότητα και Αντίθεση**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) επιστρέφει μια λειτουργία [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). Οι κλιμακωτές ρυθμίσεις της παρέχονται όταν δημιουργείται η λειτουργία. Το [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) επιστρέφει υπολογισμένες μόνο‑ανάγνωση τιμές που μπορούν να επιθεωρηθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, μετά δημιουργεί μια προεπισκόπηση χωρίς να τροποποιήσει την ενσωματωμένη εικόνα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητή από το τυπικό εφέ luminance του DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από έναν κύκλο PPTX, χρησιμοποιήστε [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου. Η ενότητα περιορισμών μορφοτύπου εξηγεί αυτή την διαφορά με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν τον ίδιο πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, διχρωματισμό, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `color1` αντιστοιχίζεται στα σκούρα pixel, ενώ το `color2` στα ανοιχτά pixel. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ με πιο σύνθετες ρυθμίσεις από μία απλή κλιμακωτή τιμή.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα διατηρώντας το άλφα. Είναι διαφορετικό από το [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), το οποίο αντιστοιχίζει ένα χρώμα πηγής σε άλλο χρώμα-στόχο και εκθέτει και τις δύο μορφές χρώματος.

### **Εφαρμογή Κατωφλίου Λουμινάνσεας**

Ένα κατώφλι λουμινάνσεας μπορεί να κάνει πιο ευδιάκριτες τις αχνές σημαδιές σε σαρωμένη σελίδα. Το [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) διατηρεί ενδιάμεσες αποχρώσεις του γκρι. Το [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) αντιστοιχίζει τη λουμινάνσες σε μαύρο ή λευκό, ενώ το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) εφαρμόζει κατώφλι στην αδιαφάνεια.

Το κατώφλι λουμινάνσεας κυμαίνεται από 0 % έως 100 %, συμπεριλαμβανομένων. Τα pixel κάτω από το κατώφλι γίνονται μαύρα. Τα pixel στο ή πάνω από το κατώφλι γίνονται λευκά. Η αύξηση του κατωφλίου κάνει περισσότερες αποχρώσεις μαύρες επειδή περισσότερα pixel πέφτουν κάτω από τη διέλευση.

Κατεβάστε το [grayscale-swatches.png](grayscale-swatches.png) στο φάκελο εργασίας. Κάθε ετικέτα δείχνει το αρχικό γκρι επίπεδο σε κλίμακα 0‑255. Το παράδειγμα τοποθετεί το αρχικό δίπλα σε δύο αντίγραφα και αποθηκεύει το κατώφλι κάθε αντιγράφου στην παρουσίαση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ανοίξτε την έξοδο παρουσίασης στο PowerPoint για σύγκριση των τριών πλαισίων. Η ετικέτα 96 έχει περίπου 38 % λουμινάνσες (96 από 255). Γίνεται λευκό στο κατώφλι 20 % και μαύρο στο κατώφλι 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Προσθήκη Θόλωσης, Διαφάνειας και Εφέ Άλφα**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε `grow` σε `true` όταν η θολή άκρη μπορεί να εκτείνεται εκτός των αρχικών προσανατολισμών της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, ώστε τα μερικώς διαυγείς pixel παραμένουν ανάλογα διαφορετικά. Το [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) αντιθέτως αντιστοιχίζει μία τιμή άλφα σε όλα τα pixel. Το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) μετατρέπει το άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) που κάνει κάθε μη‑μηδενικό άλφα πλήρως αδιαφανές· [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) που κάνει κάθε άλφα κάτω από 100 % πλήρως διαυγές· και [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) που αλλάζει το άλφα σε `100% - alpha`.

## **Δημιουργία Διατεταγμένης Αλυσίδας Εφέ**

Κάθε μέθοδος `add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο renderer χρησιμοποιεί τη συλλογή ως διατεταγμένο σύστημα σωλήνων: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1, κλπ. Ως αποτέλεσμα, οι ίδιες λειτουργίες σε διαφορετική σειρά μπορούν να αποδώσουν διαφορετική εικόνα.

Για παράδειγμα, το γκρι κλίμακας ακολουθούμενο από απόχρωση αφαιρεί πρώτα την χρωματική πληροφορία και μετά χρωματίζει το αποτέλεσμα λουμινάνσεως. Η απόχρωση ακολουθούμενη από γκρι κλίμακας αφαιρεί ξανά την απόχρωση. Παρομοίως, η αντικατάσταση άλφα μπορεί να υπερκαλύψει τις τιμές άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ανοίγει ξανά την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους, και αποδίδει το ξανά ανοιχτό αποτέλεσμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θόλωσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μία σταθερή αντικατάσταση χρώματος αφαιρεί την παραλλαγή RGB που προκύπτει από προηγούμενα εφέ χρώματος· γκρι κλίμακα μετά από διχρωματισμό αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες alpha ceiling, floor, replacement ή bi‑level μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Κατασκευάστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας pixel αντί να τη θεωρείτε ως σύνολο ανεξάρτητων σημαιών μορφοποίησης.


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μία επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `ISlidesPicture.getImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει άμεσα εγγράψιμα μέλη. Για παράδειγμα, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) εκθέτει εγγράψιμες τιμές `radius` και `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) εκθέτει εγγράψιμη `amount`, και [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) εκθέτει εγγράψιμη `threshold`. Τα εφέ χρώματος όπως [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) εκθέτουν μεταβλητά αντικείμενα [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/).

Ορισμένες διεπαφές λειτουργιών, όπως [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), και [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/), δεν εκθέτουν τις κλιμακωτές τιμές δημιουργίας ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στη ζητούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει `getEffective()` υπολογίζονται και είναι μόνο‑ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτώμενων από θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο renderer, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και επιθεωρεί αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Τα εφέ χωρίς παραμέτρους όπως γκρι κλίμακα, alpha ceiling και alpha inverse έχουν ακόμη αντικείμενο effective‑data, αλλά δεν υπάρχουν κλιμακωτές ρυθμίσεις για εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι οι σημαντικές πληροφορίες.

## **Αφαίρεση ή Εκκαθάριση Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) για να αφαιρέσετε μία λειτουργία κατά δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα τον στόχο και αφαιρέστε τον μετά την απαρίθμηση. Χρησιμοποιήστε [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) για να αφαιρέσετε ολόκληρη την αλυσίδα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Η αφαίρεση ή η εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, συμπιέζει ξανά ή αλλιώς τροποποιεί τον ξαναχρησιμοποιούμενο πόρο [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).

## **Σκέψη για Μορφές Παρουσίασης και Προορισμούς Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, έτσι το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμη και με PPTX, δεν είναι κάθε λειτουργία εξίσου φορητή:

- Οι τυπικές λειτουργίες DrawingML όπως λουμινάνσες, γκρι κλίμακα, διχρωματισμός, απόχρωση, HSL, θόλωση και κοινές λειτουργίες άλφα έχουν την καλύτερη πιθανότητα να παραμείνουν μετά από κύκλο PPTX. Πάντα ανοίξτε ξανά το δημιουργημένο αρχείο και ελέγξτε τη συλλογή όταν η διατήρηση είναι απαίτηση.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) είναι μια επέκταση Office 2010 αντί για την τυπική λειτουργία λουμινάνσεως DrawingML. Μπορεί να χρησιμοποιηθεί για εσωτερική απόδοση, αλλά δεν εγγυάται ότι θα παραμείνει ως επεξεργάσιμη [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) μετά την αποθήκευση και το άνοιγμα του PPTX. Προτιμήστε το [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) για μόνιμες προσαρμογές φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγείται του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε ένα υποσσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε PPT για επαλήθευση μιας σύνθετης επεξεργάσιμης αλυσίδας.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες οπτικές εξόδους εφαρμόζει την υποστηριζόμενη αλυσίδα στην απόδοση. Αυτές οι εξόδους δεν περιέχουν επεξεργάσιμο IImageTransformOperationCollection· οι μορφές raster επίπεδών εικόνων επίπεδών απλώς ισοπεδώνουν το αποτέλεσμα σε pixel, ενώ οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν την δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μία συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν φορτώνεται η παρουσίαση.

Διαφορετικοί καταναλωτές παρουσίασης μπορεί να αποδώσουν περιθώρια διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρωματικής κβαντοποίησης. Για κρίσιμα αποτελέσματα, δοκιμάστε τόσο το επεξεργάσιμο κύκλο όσο και τη τελική μορφή εξαγωγής με την ίδια έκδοση Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν τα εφέ μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `ISlidesPicture` που χρησιμοποιείται από τη γεμιστική εικόνα. Τα υποκείμενα bytes του `IPPImage` παραμένουν αμετάβλητα.

**Μοιράζονται δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρησιμοποίηση ενός `IPPImage` αποφεύγει διπλά δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας κανονικά έχει ξεχωριστό `ISlidesPicture` και συλλογή μετασχηματισμού εικόνας.

**Μπορούν να συνδυαστούν εφέ χρώματος, θόλωσης και άλφα;**

Ναι. Η συλλογή τα δέχεται σε μία διατεταγμένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να απορρίψουν προηγούμενες λεπτομέρειες χρώματος ή άλφα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο‑ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμών όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες τιμές δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμού;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντας το ξανά. Η παλαιότερη μορφή PPT δεν μπορεί να αντιπροσωπεύσει το πλήρες μοντέλο εφέ DrawingML, ενώ οι μορφές εξαγωγής αποθηκεύουν την εμφάνιση αντί για επεξεργάσιμες λειτουργίες μετασχηματισμού.