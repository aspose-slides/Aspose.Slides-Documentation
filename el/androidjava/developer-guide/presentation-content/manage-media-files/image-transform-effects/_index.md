---
title: Διαχείριση Εφέ Μετασχηματισμού Εικόνας σε Παρουσιάσεις στο Android
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
- δυοχρωματικό
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
description: "Εφαρμόστε, συνδέστε, επιθεωρήστε, αφαιρέστε και επαληθεύστε τα εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις εικόνας ως μια διατεταγμένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το πλαίσιο του [ISlidesPicture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidespicture/) και αποκτήστε πρόσβαση στο [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). Η επιστρεφόμενη [IImageTransformOperationCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/) σας επιτρέπει να προσθέτετε, να απαριθμείτε, να επιθεωρείτε, να αφαιρείτε και να διαγράφετε εφέ χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο παρουσιάζει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρώματος, θόλωση, διαφάνεια, διατεταγμένες αλυσίδες εφέ, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση κύκλου PPTX.

## **Κατανόηση της Ιδιοκτησίας των Εφέ και της Επαναχρήσης της Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) αποθηκεύει ή αναφέρεται στα δεδομένα της αρχικής εικόνας που ανήκουν στην παρουσίαση.
- [ISlidesPicture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidespicture/) ανήκει σε ένα γέμισμα εικόνας και παραπέμπει σε έναν πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμών εικόνας.
- [IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Κατά συνέπεια, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/). Όταν το ίδιο `IPPImage` περάσει στο [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι, παρόλο που όλα επαναχρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `ISlidesPicture.getImageTransform` χρησιμοποιείται επίσης από άλλα γέμισματα εικόνας, όπως σχήματα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν σε πλαίσια εικόνας.

## **Χρήση Έγκυρων Εύρους Παραμέτρων και Μονάδων**

Οι παραδειγματικές μέθοδοι χρησιμοποιούν τα παρακάτω εννοιολογικά εύρη και μονάδες. Διατηρήστε τις τιμές εντός αυτών των ορίων ακόμη και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει άμεσα κάθε τιμή εκτός εύρους· η μορφή προορισμού ενδέχεται να κανονίσει, παραλείψει ή απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίξει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το συστατικό αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Καμία | Δεν υπάρχουν αριθμητικές παράμετροι. Το άλφα παραμένει αμετάβλητο. |
| [addDuotoneEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Δύο χρώματα για σκοτεινά και φωτεινά pixel. Οι τιμές καναλιών RGB και άλφα του `android.graphics.Color` κυμαίνονται από `0` έως `255`. |
| [addTintEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Η απόχρωση είναι από `0` (συμπεριλαμβανομένου) έως `360` (εξαιρετικό), σε μοίρες· το ποσό είναι `-100` έως `100`, ποσοστό. |
| [addHSLEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι από `0` έως `360` (εξαιρουμένο), σε μοίρες· η κορεσμός και η λαμπρότητα είναι `-100` έως `100`, ποσοστό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [addBlurEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετράται σε σημεία· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να εκτείνεται εκτός των αρχικών ορίων. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για τυπική κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διαφανές και `100` διατηρεί το υπάρχον άλφα. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` έως `100`, ποσοστό αδιαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή άνω γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση άλφα, η διαφάνεια και η αδιαφάνεια συμπληρώνουν η μία την άλλη. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό διαμόρφωσης άλφα 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

Το [IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) επιστρέφει μια λειτουργία [IBrightnessContrast](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibrightnesscontrast/). Οι κλιμακωτές ρυθμίσεις του παρέχονται κατά τη δημιουργία της λειτουργίας. Το [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να επιθεωρηθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, στη συνέχεια αποδίδει μια προεπισκόπηση χωρίς να τροποποιήσει την ενσωματωμένη εικόνα:

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

Το [BrightnessContrast](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/brightnesscontrast/) είναι επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητό από το τυπικό εφέ luminance του DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από κύκλο PPTX, χρησιμοποιήστε το [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διάκριση λεπτομερέστερα.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, δυοχρωματικό, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

Το [IDuotone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iduotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `color1` αντιστοιχεί στα σκοτεινά pixel, ενώ το `color2` στα φωτεινά. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ με πιο σύνθετες ρυθμίσεις από μια απλή κλιμακωτή τιμή.

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

Το [addColorReplaceEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα διατηρώντας το άλφα. Είναι διαφορετικό από το [addColorChangeEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) που αντιστοιχίζει ένα χρώμα προέλευσης σε άλλο και εκθέτει και τις δύο μορφές χρώματος.

## **Προσθήκη Θόλωσης, Διαφάνειας και Εφέ Άλφα**

Το [addBlurEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε `grow` σε `true` όταν η θολή άκρη μπορεί να εκτείνεται εκτός των αρχικών ορίων της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι ώστε τα ημιδιαφανή pixel να παραμείνουν ανάλογα διαφορετικά. Το [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) αντιθέτως αναθέτει μία τιμή άλφα σε όλα τα pixel. Το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) μετατρέπει το άλφα σε δύο επίπεδα με βάση ένα κατώφλι.

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

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [addAlphaCeilingEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), που κάνει κάθε μη μηδενικό άλφα πλήρως αδιαφανές· το [addAlphaFloorEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), που κάνει κάθε άλφα κάτω του 100 % πλήρως διαφανές· και το [addAlphaInverseEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), που μετατρέπει το άλφα σε `100% - alpha`.

## **Δημιουργία Διατεταγμένης Αλυσίδας Εφέ**

Κάθε μέθοδος `add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο αποδότης χρησιμοποιεί τη συλλογή ως διατεταγμένη αγωγή: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες με διαφορετική σειρά μπορούν να δημιουργήσουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση πρώτα αφαιρεί πληροφορίες χρώματος και στη συνέχεια επαναχρωματίζει το αποτέλεσμα της λαμπρότητας. Η απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί ξανά την απόχρωση. Παρόμοια, η αντικατάσταση άλφα μπορεί να υπερισχύσει των τιμών άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ανοίγει ξανά την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους, και αποδίδει το ξαναανοιγμένο αποτέλεσμα:

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

Η συλλογή δεν επιβάλλει μια μήτρα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θόλωσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί την ποικιλία RGB που παρήγαγε προηγούμενο εφέ χρώματος· η γκρι κλίμακα μετά από δυοχρωματικό αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες αλφα‑ceil, floor, replace ή bi‑level μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Δημιουργήστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας pixel, αντί να θεωρείτε τα στοιχεία ως ανεξάρτητες σημαίες μορφοποίησης.

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `ISlidesPicture.getImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει εγγράψιμα μέλη απευθείας. Για παράδειγμα, η [IBlur](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iblur/) εκθέτει εγγράψιμες τιμές `radius` και `grow`, το [IAlphaModulateFixed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ialphamodulatefixed/) εκθέτει εγγράψιμο `amount`, και το [IAlphaBiLevel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ialphabilevel/) εκθέτει εγγράψιμο `threshold`. Εφέ χρώματος όπως το [IDuotone](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iduotone/) εκθέτουν μεταβλητά αντικείμενα [IColorFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icolorformat/).

Κάποιες διεπαφές λειτουργιών, όπως [IBrightnessContrast](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itint/), και [IAlphaReplace](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ialphareplace/), δεν εκθέτουν τα αρχικά τους scalar ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στη συγκεκριμένη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει το `getEffective()` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτημένων από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο αποδότης, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και επιθεωρεί τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

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

Τα εφέ χωρίς παραμέτρους όπως γκρι κλίμακα, αλφα‑ceil και αλφα‑inverse διαθέτουν επίσης αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν scalar ρυθμίσεις για εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι η σημαντική πληροφορία.

## **Αφαίρεση ή Καθαρισμός Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) για να αφαιρέσετε μια λειτουργία με βάση το δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα τον στόχο και αφαιρέστε τον μετά την απαρίθμηση. Χρησιμοποιήστε το [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) για να διαγράψετε ολόκληρη την αλυσίδα.

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

Η αφαίρεση ή ο καθαρισμός των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν επανασυμπιέζει και δεν τροποποιεί τον επαναχρησιμοποιούμενο πόρο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/).

## **Σκέψη για Μορφές Παρουσίασης και Στόχους Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, επομένως το PPTX είναι η προτιμώμενη μορφή επεξεργάσιμη για αλυσίδες εφέ. Ακόμη και με PPTX, δεν είναι όλες οι λειτουργίες εξίσου φορητές:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, grayscale, duotone, tint, HSL, blur και κοινές λειτουργίες άλφα έχουν τις καλύτερες πιθανότητες να παραμείνουν μετά από κύκλο PPTX. Πάντα ανοίξτε ξανά το δημιουργημένο αρχείο και επιθεωρήστε τη συλλογή όταν η διατήρηση είναι απαραίτηση.
- Το [BrightnessContrast](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/brightnesscontrast/) είναι επέκταση Office 2010 αντί για το τυπικό εφέ luminance του DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση στη μνήμη, αλλά δεν είναι εγγυημένο ότι θα παραμείνει ως επεξεργάσιμο [IBrightnessContrast](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibrightnesscontrast/) μετά την αποθήκευση και ξαναάνοιγμα του PPTX. Προτιμήστε το [addLuminanceEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να περιορίσει μια αλυσίδα σε ένα υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες οπτικές εξόδους εφαρμόζει την υποστηριζόμενη αλυσίδα στην εμφανιζόμενη εικόνα. Αυτές οι εξόδους δεν περιέχουν επεξεργάσιμη `IImageTransformOperationCollection`; οι μορφές raster ισοπεδώνουν το αποτέλεσμα σε pixel, ενώ οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από την διαθεσιμότητα του συνδεδεμένου πόρου κατά τη φόρτωση της παρουσίασης.

Διαφοροί καταναλωτές παρουσίασης ενδέχεται να αποδίδουν ακραίες περιπτώσεις διαφορετικά, ειδικά όταν συνδυάζονται πολλαπλές λειτουργίες άλφα ή χρώματος. Για κρίσιμα αποτελέσματα, δοκιμάστε τόσο τον επεξεργάσιμο κύκλο όσο και τη τελική μορφή εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν τα εφέ μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `ISlidesPicture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα bytes του `IPPImage` παραμένουν αμετάβλητα.

**Μοιράζονται δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρήση ενός `IPPImage` αποφεύγει διπλότυπα δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας συνήθως έχει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμών.

**Μπορούν να συνδυαστούν εφέ χρώματος, θόλωσης και άλφα;**

Ναι. Η συλλογή τα αποδέχεται σε μία διατεταγμένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, καθώς λειτουργίες αντικατάστασης ή κατωφλίου μπορεί να απορρίψουν προηγούμενες λεπτομέρειές χρώματος ή άλφα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμών όπου υπάρχουν εγγράψιμα μέλη· αλλιώς αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποιά μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμού;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντας το ξανά. Η κληρονομική μορφή PPT δεν μπορεί να αναπαραστήσει το πλήρες μοντέλο εφέ DrawingML, ενώ οι μορφές εξαγωγής αποθηκεύουν μόνο την εμφάνιση και όχι επεξεργάσιμες λειτουργίες μετασχηματισμού.