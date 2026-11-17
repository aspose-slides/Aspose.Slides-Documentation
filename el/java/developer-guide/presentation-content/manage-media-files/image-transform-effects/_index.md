---
title: Διαχείριση Εφέ Μετασχηματισμού Εικόνας σε Παρουσιάσεις με Java
linktitle: Εφέ Μετασχηματισμού Εικόνας
type: docs
weight: 11
url: /el/java/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- εφέ εικόνας
- φωτεινότητα
- αντίθεση
- γκρι κλίμακα
- δυοτόν
- χρωματισμός
- HSL
- αντικατάσταση χρώματος
- θόλωση
- διαφάνεια
- άλφα εφέ
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Εφαρμόστε, συνδυάστε, επιθεωρήστε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με Aspose.Slides for Java."
---
## **Επισκόπηση**

Aspose.Slides παρουσιάζει τις ρυθμίσεις εικόνας ως μια τακτοποιημένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) και αποκτήστε πρόσβαση στο [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--). Η επιστρεφόμενη [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) σας επιτρέπει να προσθέσετε, να απαριθμήσετε, να ελέγξετε, να αφαιρέσετε και να διαγράψετε εφέ χωρίς να επανγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο δείχνει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρώματος, θόλωση, διαφάνεια, αλυσίδες εφέ με σειρά, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση κυκλικής διαδρομής PPTX.

## **Κατανόηση της Ιδιοκτησίας Εφέ και Επαναχρησιμοποίηση Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) αποθηκεύει ή αναφέρεται στα δεδομένα εικόνας που ανήκουν στην παρουσίαση.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) ανήκει σε γέμισμα εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμών εικόνας.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου διαφάνειας.

Ως εκ τούτου, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). Όταν το ίδιο `IPPImage` περάσει στο [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι, ακόμη και αν όλα χρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `ISlidesPicture.getImageTransform` χρησιμοποιείται επίσης από άλλα γέμισμα εικόνας, όπως ένα σχήμα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν στα πλαίσια εικόνας.

## **Χρήση Έγκυρων Εύρους Παραμέτρων και Μονάδων**

Οι μεθόδοι που παρουσιάζονται χρησιμοποιούν τα παρακάτω λογικά εύρη και μονάδες. Διατηρήστε τις τιμές σε αυτά τα εύρη ακόμα και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει άμεσα κάθε τιμή εκτός εύρους· η μορφή παρουσίασης-στόχος μπορεί να κανονικοποιήσει, να παραβλέψει ή να απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίξει το αρχείο.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Χωρίς αριθμητικές παραμέτρους. Το άλφα παραμένει αμετάβλητο. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Δύο χρώματα για σκοτεινά και φωτεινά pixel. Τα κανάλια RGB και άλφα στο `java.awt.Color` χρησιμοποιούν τιμές από `0` έως `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Η απόχρωση είναι από `0` (συμπεριλαμβανομένου) έως `360` (αποκλειστικό), σε μοίρες· το ποσό είναι από `-100` έως `100`, ποσοστό. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι από `0` (συμπεριλαμβανομένου) έως `360` (αποκλειστικό), σε μοίρες· η κορεσμός και η φωτεινότητα είναι από `-100` έως `100`, ποσοστό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετριέται σε points· το `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να επεκταθεί εκτός των αρχικών ορίων. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε τιμές από `0` έως `100` για κανονική κλίμακα αδιαφάνειας: το `0` είναι πλήρως διαφανές και το `100` διατηρεί το υπάρχον άλφα. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` έως `100`, ποσοστό αδιαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή άνω γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση άλφα, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό διαμόρφωσης άλφα 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) επιστρέφει λειτουργία [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). Οι κλίμακες της καθορίζονται κατά τη δημιουργία της λειτουργίας. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να επιθεωρηθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, στη συνέχεια αποδίδει μια προεπισκόπηση χωρίς να τροποποιήσει την ενσωματωμένη εικόνα:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) είναι επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητό από το τυπικό εφέ φωτεινότητας DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από μια κυκλική διαδρομή PPTX, χρησιμοποιήστε [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα ξανά του αρχείου. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διάκριση με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, duotone, χρωματισμό, ρύθμιση HSL και αντικατάσταση χρώματος.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `color1` αντιστοιχεί στα σκοτεινά pixel, ενώ το `color2` στα φωτεινά. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ με πιο σύνθετες ρυθμίσεις από μια απλή κλίμακα.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα, διατηρώντας το άλφα. Είναι διαφορετικό από το [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), το οποίο αντιστοιχεί ένα χρώμα προέλευσης σε ένα χρώμα προορισμού και αποκαλύπτει και τις μορφές χρώματος προέλευσης και προορισμού.

### **Εφαρμογή Κατωφλίου Φωτεινότητας**

Ένα κατώφλι φωτεινότητας μπορεί να κάνει τα αδύναμα σημάδια σε μια σκαλισμένη σελίδα πιο ευδιάκριτα από το φόντο. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) διατηρεί ενδιάμεσες αποχρώσεις του γκρι. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) αντιστοιχεί τη φωτεινότητα σε μαύρο ή λευκό, ενώ το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) εφαρμόζει κατώφλι στην αδιαφάνεια.

Το κατώφλι φωτεινότητας κυμαίνεται από 0 % έως 100 %, περιλαμβανομένων. Τα pixel κάτω από το κατώφλι γίνονται μαύρα. Τα pixel στο ή πάνω από το κατώφλι γίνονται λευκά. Η αύξηση του κατωφλίου κάνει περισσότερες αποχρώσεις μαύρες επειδή περισσότερες πέφτουν κάτω από το όριο.

Κατεβάστε το [grayscale-swatches.png](grayscale-swatches.png) στον τρέχοντα φάκελο. Κάθε ετικέτα δείχνει το αρχικό γκρι επίπεδο σε κλίμακα από 0 έως 255. Το παράδειγμα τοποθετεί το αρχικό δίπλα σε δύο αντίγραφα και αποθηκεύει το κατώφλι κάθε αντίγραφου στην παρουσίαση.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Ανοίξτε την έξοδο παρουσίασης στο PowerPoint για σύγκριση των τριών πλαισίων. Το δείγμα με ετικέτα 96 έχει περίπου 38 % φωτεινότητα (96 από 255). Μετατρέπεται σε λευκό στο κατώφλι 20 % και σε μαύρο στο κατώφλι 60 %.

![Αρχικά χρωματιστά γκρι δείγματα δίπλα στα μαύρο‑λευκά αποτελέσματα σε κατώφλια φωτεινότητας 20% και 60%](luminance-threshold.png)

## **Προσθήκη Θόλωσης, Διαφάνειας και Άλφα Εφέ**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε το `grow` σε `true` όταν η θολή άκρη μπορεί να επεκταθεί πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι οι μερικώς διαφανείς εικονοστοιχεία παραμένουν αναλογικά διαφορετικά. Το [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) αντιθέτως αναθέτει μια τιμή άλφα σε όλα τα pixel. Το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) μετατρέπει το άλφα σε δύο επίπεδα βάσει ενός κατώφλιου.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), που κάνει κάθε μη μηδενικό άλφα πλήρως αδιαφαές· το [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), που κάνει κάθε άλφα κάτω από 100 % πλήρως διαφανές· και το [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), που αλλάζει το άλφα σε `100% - alpha`.

## **Δημιουργία Τακτοποιημένης Αλυσίδας Εφέ**

Κάθε μέθοδος `add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο αποδότης χρησιμοποιεί τη συλλογή ως τακτοποιημένη δίαυλο: η έξοδος της λειτουργίας 0 γίνεται είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες σε διαφορετική σειρά μπορούν να παράγουν διαφορετική εικόνα.

Για παράδειγμα, γκρι κλίμακα ακολουθούμενη από χρωματισμό αφαιρεί πρώτα τη χρωματική πληροφορία και μετά επαναχρωματίζει το αποτέλεσμα της φωτεινότητας. Χρωματισμός ακολουθούμενος από γκρι κλίμακα αφαιρεί ξανά τον χρωματισμό. Ομοίως, η αντικατάσταση άλφα μπορεί να παρακάμψει τιμές άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ξαναανοίγει την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους, και αποδίδει το ξαναανοιγμένο αποτέλεσμα:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

Η συλλογή δεν επιβάλλει πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θόλωσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί την ποικιλία RGB που παράγουν προηγούμενα χρωματικά εφέ· η γκρι κλίμακα μετά το duotone αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα ceiling, floor, replacement ή bi‑level μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Δημιουργήστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας pixel, αντί να τη θεωρείτε ως μη τακτοποιημένα σήματα μορφοποίησης.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Σε αυτή την εικονογραφική απόδοση Aspose.Slides for .NET 26.11, χρωματισμός 220° με 25 % αφήνει την γκρι κλίμακα αμετάβλητη. Η εφαρμογή του ίδιου χρωματισμού πριν από τη γκρι κλίμακα παράγει διαφορετικές αποχρώσεις.*  
<!-- visual-explanation:image-transform-effects:end -->

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `ISlidesPicture.getImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει απευθείας εγγράψιμα μέλη. Για παράδειγμα, το [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) εκθέτει εγγράψιμες τιμές `radius` και `grow`, το [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) εκθέτει εγγράψιμο `amount`, και το [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) εκθέτει εγγράψιμο `threshold`. Τα εφέ χρώματος όπως το [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) εκθέτουν μεταβλητά αντικείμενα [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/).

Ορισμένα interfaces λειτουργιών, όπως τα [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/), και [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), δεν εκθέτουν τις αρχικές κλίμακες τους ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στην απαιτούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει η `getEffective()` είναι υπολογισμένα και μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων που εξαρτώνται από το θέμα και την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο αποδότης, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και επιθεωρεί τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

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

Οι λειτουργίες χωρίς παραμέτρους όπως η γκρι κλίμακα, το αλφα ceiling και το αλφα inverse έχουν ακόμη αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν κλίμακες για εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι οι σημαντικές πληροφορίες.

## **Αφαίρεση ή Καθαρισμός Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) για να αφαιρέσετε μια λειτουργία κατά δείκτη. Επειδή οι δείκτες μετακινούνται μετά την αφαίρεση, ψάξτε πρώτα το στόχο και αφαιρέστε τον μετά την απαρίθμηση. Χρησιμοποιήστε το [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) για να αφαιρέσετε ολόκληρη την αλυσίδα.

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

Η αφαίρεση ή ο καθαρισμός των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν συμπιέζει ξανά και δεν τροποποιεί τον επανεχρησιμοποιούμενο πόρο [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).

## **Λάβετε υπόψη τις μορφές παρουσίασης και τους στόχους εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, έτσι το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμη και με PPTX, δεν έχει κάθε λειτουργία την ίδια φορητότητα:

- Οι τυπικές λειτουργίες DrawingML όπως η φωτεινότητα, η γκρι κλίμακα, το duotone, ο χρωματισμός, το HSL, η θόλωση και οι κοινές λειτουργίες άλφα έχουν τις μεγίστους πιθανότητες να επιβιώσουν από μια κυκλική διαδρομή PPTX. Πάντα ανοίξτε ξανά το δημιουργημένο αρχείο και επιθεωρήστε τη συλλογή όταν η διατήρηση είναι απαίτηση.
- Το [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) είναι επέκταση Office 2010 και όχι η τυπική λειτουργία φωτεινότητας DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση στη μνήμη, αλλά δεν εγγυάται ότι θα παραμείνει ως επεξεργάσιμο [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) μετά την αποθήκευση και το άνοιγμα του PPTX. Προτιμήστε το [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείπει μη υποστηριζόμενες λειτουργίες, να μειώνει μια αλυσίδα σε υποσύνολο ή να προσομοιώνει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια πολύπλοκη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλη οπτική έξοδο εφαρμόζει την υποστηριζόμενη αλυσίδα στην απόδοση. Αυτές οι εξόδους δεν περιέχουν μια επεξεργάσιμη `IImageTransformOperationCollection·`· οι μορφές raster ισοπέδουν το αποτέλεσμα σε pixel, και οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθέσιμη συνδεδεμένη πηγή όταν φορτώνεται η παρουσίαση.

Διαφορετικοί καταναλωτές παρουσίασης μπορεί να αποδίδουν περιπτώσεις άκρων διαφορετικά, ιδιαίτερα όταν συνδυάζονται αρκετές λειτουργίες άλφα ή χρωματικού κβαντισμού. Για κρίσιμες εξόδους, δοκιμάστε τόσο την επεξεργάσιμη κυκλική διαδρομή όσο και την τελική μορφή εξαγωγής με την ίδια έκδοση Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν οι μετασχηματισμοί εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `ISlidesPicture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα bytes του `IPPImage` παραμένουν αμετάβλητα.

**Θα μοιράζονται δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επανάχρηση ενός `IPPImage` αποτρέπει την διπλή αποθήκευση δεδομένων εικόνας, αλλά καθε πλαίσιο εικόνας συνήθως έχει ξεχωριστό `ISlidesPicture` και συλλογή μετασχηματισμών εικόνας.

**Μπορούν να συνδυαστούν εφέ χρώματος, θόλωσης και άλφα;**

Ναι. Η συλλογή τα αποδέχεται σε μια τακτοποιημένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να απορρίψουν πρώιμες λεπτομέρειες χρώματος ή άλφα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμών όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμών;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντάς το ξανά. Η παλιά μορφή PPT δεν μπορεί να αντιπροσωπεύσει το πλήρες μοντέλο εφέ DrawingML, και οι εξαγώμενες μορφές διατηρούν μόνο την εμφάνιση και όχι τις επεξεργάσιμες λειτουργίες μετασχηματισμού.