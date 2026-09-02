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
- δυοχρωματικό
- απόχρωση
- HSL
- αντικατάσταση χρώματος
- θόλωση
- διαφάνεια
- εφέ αλφα
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Εφαρμόστε, συνδέστε, ελέγξτε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με Aspose.Slides για Java."
---
## **Επισκόπηση**

Το Aspose.Slides αναπαριστά τις ρυθμίσεις εικόνας ως μια διατεταγμένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [ISlidesPicture](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidespicture/) του πλαισίου και αποκτήστε πρόσβαση στη [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidespicture/#getImageTransform--). Η επιστρεφόμενη [IImageTransformOperationCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/) σας επιτρέπει να προσθέτετε, να απαριθμείτε, να ελέγχετε, να αφαιρείτε και να διαγράφετε εφέ χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο παρουσιάζει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, χρωματικούς μετασχηματισμούς, θόλωση, διαφάνεια, διατεταγμένες αλυσίδες εφέ, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση κύκλου PPTX.

## **Κατανόηση της Ιδιοκτησίας των Εφέ και της Επανάχρησης Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- Το [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/) αποθηκεύει ή αναφέρεται στα δεδομένα της πηγής εικόνας που ανήκουν στην παρουσίαση.
- Το [ISlidesPicture](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidespicture/) ανήκει σε ένα γέμισμα εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμού εικόνας.
- Το [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Ως εκ τούτου, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes του [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/). Όταν το ίδιο `IPPImage` περνάει στο [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) παραπάνω από μία φορά, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμού. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι, παρόλο που όλα επαναχρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `ISlidesPicture.getImageTransform` χρησιμοποιείται επίσης από άλλα γέμιστρα εικόνας, όπως ένα σχήμα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν στα πλαίσια εικόνας.

## **Χρήση Εγκυρων Εύρων Παραμέτρων και Μονάδων**

Οι παραπάνω μέθοδοι χρησιμοποιούν τα ακόλουθα σημασιολογικά εύρη και μονάδες. Διατηρήστε τις τιμές εντός αυτών των εύρων ακόμα και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε τιμή εκτός εύρους· η μορφή προορισμού μπορεί να κανονικοποιήσει, παραλείψει ή απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή το άνοιγμα του αρχείου από το PowerPoint.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Καμία | Δεν υπάρχουν αριθμητικές παράμετροι. Το αλφα είναι αμετάβλητο. |
| [addDuotoneEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Δύο χρώματα για σκούρα και ανοιχτά pixel. Τα κανάλια RGB και αλφα στο `java.awt.Color` χρησιμοποιούν τιμές από `0` έως `255`. |
| [addTintEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Η απόχρωση είναι `0` (συμπεριλαμβανομένου) έως `360` (αποκλειστικό) σε μοίρες· το ποσό είναι από `-100` έως `100`, ποσοστό. |
| [addHSLEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι `0` (συμπεριλαμβανομένου) έως `360` (αποκλειστικό) σε μοίρες· ο κορεσμός και η φωτεινότητα είναι από `-100` έως `100`, ποσοστό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Το αντικατεστημένο χρώμα χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές αλφα παραμένουν αμετάβλητες. |
| [addBlurEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετράται σε points· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να εκτείνεται εκτός των αρχικών ορίων. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για κανονική αλλαγή διαφάνειας: `0` είναι πλήρως διαφανές και `100` διατηρεί το υπάρχον αλφα. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` έως `100`, ποσοστό διαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου αλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή άνω γίνονται αδιαφάνεια. |

Για σταθερή διαφάνεια, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό σταθερού αλφα 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) επιστρέφει μια λειτουργία [IBrightnessContrast](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibrightnesscontrast/). Οι βαθμωτές ρυθμίσεις παρέχονται κατά τη δημιουργία της λειτουργίας. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση, τις οποίες μπορείτε να ελέγξετε ή να καταγράψετε.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, και στη συνέχεια εμφανίζει μια προεπισκόπηση χωρίς να τροποποιεί την ενσωματωμένη εικόνα:

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

[BrightnessContrast](https://reference.aspose.com/slides/el/java/com.aspose.slides/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητή από το τυπικό εφέ φωτεινότητας DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από κύκλο PPTX, χρησιμοποιήστε [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διάκριση με περισσότερες λεπτομέρειες.

## **Εφαρμογή Χρωματικών Μετασχηματισμών**

Τα χρωματικά εφέ μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, δυοχρωματικό, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

[IDuotone](https://reference.aspose.com/slides/el/java/com.aspose.slides/iduotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `color1` αντιστοιχεί στα σκούρα pixel, ενώ το `color2` στα ανοιχτά. Αυτό το κάνει ένα χρήσιμο παράδειγμα εφέ με πιο σύνθετες ρυθμίσεις από μια απλή βαθμωτή τιμή.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα διατηρώντας το αλφα. Είναι διαφορετικό από το [addColorChangeEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), το οποίο αντιστοιχίζει ένα χρώμα πηγής σε άλλο χρώμα στόχο και εκθέτει και τις δύο μορφές χρώματος.

## **Προσθήκη Θόλωσης, Διαφάνειας και Αλφα Εφέ**

[addBlurEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του αλφα. Ορίστε `grow` σε `true` όταν η θολή άκρη μπορεί να εκτείνεται πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Πολλαπλασιάζει κάθε υπάρχουσα τιμή αλφα, ώστε τα ημιδιαφανή pixel να παραμένουν αναλογικά διαφορετικά. Το [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) αντιθέτως αντιστοιχεί μια σταθερή τιμή αλφα σε όλα τα pixel. Το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) μετατρέπει το αλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

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

Άλλες λειτουργίες αλφα χωρίς παραμέτρους περιλαμβάνουν το [addAlphaCeilingEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), το οποίο κάνει κάθε μη μηδενικό αλφα πλήρως αδιαφάνεια· το [addAlphaFloorEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), που κάνει κάθε αλφα κάτω από 100 % πλήρως διαφανές· και το [addAlphaInverseEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), το οποίο μετατρέπει το αλφα σε `100% - alpha`.

## **Δημιουργία Διατεταγμένης Αλυσίδας Εφέ**

Κάθε μέθοδος `add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο renderer χρησιμοποιεί τη συλλογή ως διατεταγμένο pipeline: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1 κ.ο.Κ. Συνεπώς, το ίδιο σύνολο λειτουργιών με διαφορετική σειρά μπορεί να παράγει διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση αφαιρεί πρώτα την χρωματική πληροφορία και μετά επαναχρωματίζει το αποτέλεσμα φωτεινότητας. Απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί ξανά την απόχρωση. Παρόμοια, η αντικατάσταση αλφα μπορεί να υπερισχύσει των τιμών αλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση αλφα διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ξαναφορτώνει την παρουσίαση, ελέγχει τόσο τους τύπους των λειτουργιών όσο και τη σειρά τους, και αποτυπώνει το ξαναφορτωμένο αποτέλεσμα:

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

Η συλλογή δεν επιβάλλει ένα πίνακα συμβατότητας που περιορίζει χρώμα, αλφα και θόλωση σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί τη μεταβολή RGB που παρήχθη από προηγούμενα χρωματικά εφέ· γκρι κλίμακα μετά από δυοχρωματικό αφαιρεί τα δύο επιλεγμένα χρώματα· και λειτουργίες αλφα οροφής, δαπέδου, αντικατάστασης ή δι-επίπεδου μπορούν να αγνοήσουν λεπτομέρειες αλφα που δημιουργήθηκαν νωρίτερα. Δημιουργήστε την αλυσίδα σύμφωνα με την επιθυμητή σειρά επεξεργασίας pixel αντί να τη θεωρείτε ως αδιατάστατες σημαίες μορφοποίησης.

## **Έλεγχος Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που βρίσκεται στο `ISlidesPicture.getImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει άμεσα γράψιμες ιδιότητες. Για παράδειγμα, το [IBlur](https://reference.aspose.com/slides/el/java/com.aspose.slides/iblur/) εκθέτει γράψιμες τιμές `radius` και `grow`, το [IAlphaModulateFixed](https://reference.aspose.com/slides/el/java/com.aspose.slides/ialphamodulatefixed/) εκθέτει ένα γράψιμο `amount`, και το [IAlphaBiLevel](https://reference.aspose.com/slides/el/java/com.aspose.slides/ialphabilevel/) εκθέτει ένα γράψιμο `threshold`. Τα χρωματικά εφέ όπως το [IDuotone](https://reference.aspose.com/slides/el/java/com.aspose.slides/iduotone/) εκθέτουν μεταβλητά αντικείμενα [IColorFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/icolorformat/).

Κάποιες διεπαφές λειτουργιών, όπως τα [IBrightnessContrast](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/el/java/com.aspose.slides/itint/), και [IAlphaReplace](https://reference.aspose.com/slides/el/java/com.aspose.slides/ialphareplace/), δεν εκθέτουν τα αρχικά τους σκαλάρια ως γράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στην απαιτούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει η `getEffective()` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτημένων από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο renderer, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και ελέγχει αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

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

Τα εφέ χωρίς παραμέτρους όπως η γκρι κλίμακα, η οροφή αλφα και η αντιστροφή αλφα έχουν ακόμα αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν βαθμωτές ρυθμίσεις προς εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι η σημαντική πληροφορία.

## **Αφαίρεση ή Εκκαθάριση Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) για να αφαιρέσετε μια λειτουργία με βάση το δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, ψάξτε πρώτα για τον στόχο και αφαιρέστε τον μετά την απαρίθμηση. Χρησιμοποιήστε το [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/imagetransformoperationcollection/#clear--) για να διαγράψετε ολόκληρη την αλυσίδα.

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

Η αφαίρεση ή η εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν συμπιέζει ξανά και δεν τροποποιεί με οποιονδήποτε τρόπο τον επαναχρησιμοποιούμενο πόρο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ippimage/).

## **Σκέψεις για Μορφές Παρουσίασης και Στόχους Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, επομένως το PPTX είναι η προτιμώμενη μορφή επεξεργασίας για αλυσίδες εφέ. Ακόμη και με PPTX, δεν είναι κάθε λειτουργία εξίσου φορητή:

- Οι τυπικές λειτουργίες DrawingML όπως η luminance, η γκρι κλίμακα, το δυοχρωματικό, η απόχρωση, το HSL, η θόλωση και οι κοινές λειτουργίες αλφα έχουν τις καλύτερες πιθανότητες να επιβιώσουν σε κύκλο PPTX. Πάντα ξαναανοίξτε το παραγόμενο αρχείο και ελέγξτε τη συλλογή όταν η διατήρηση είναι απαίτηση.
- Το [BrightnessContrast](https://reference.aspose.com/slides/el/java/com.aspose.slides/brightnesscontrast/) είναι μια επέκταση Office 2010 και όχι η τυπική λειτουργία luminance DrawingML. Μπορεί να χρησιμοποιηθεί για απεικόνιση στη μνήμη, αλλά δεν εγγυάται ότι θα παραμείνει επεξεργάσιμο [IBrightnessContrast](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibrightnesscontrast/) μετά την αποθήκευση και το ξαναάνοιγμα του PPTX. Προτιμήστε το [addLuminanceEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) για διαρκείς ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιήσετε το PPT ως μορφή επαλήθευσης για μια σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες μορφές απεικόνισης εφαρμόζει την υποστηριζόμενη αλυσίδα στην τελική εμφάνιση. Αυτές οι εξόδους δεν περιέχουν ένα επεξεργάσιμο `IImageTransformOperationCollection`; οι μορφές raster εξισομαλύνουν το αποτέλεσμα σε pixel, ενώ οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου κατά τη φόρτωση της παρουσίασης.

Διάφοροι καταναλωτές παρουσίασης μπορεί να αποδώσουν άκρες διαφορετικά, ειδικά όταν συνδυάζονται πολλαπλές λειτουργίες αλφα ή χρωματικής ποσοτικοποίησης. Για κρίσιμα αποτελέσματα, δοκιμάστε τόσο τον επεξεργάσιμο κύκλο όσο και τη μορφή τελικής εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν οι λειτουργίες μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `ISlidesPicture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα bytes του `IPPImage` παραμένουν αμετάβλητα.

**Θα μοιράζονται δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρήση ενός `IPPImage` αποφεύγει τον διπλό αποθηκευτικό χώρο εικόνας, αλλά κάθε πλαίσιο εικόνας συνήθως έχει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμού.

**Μπορούν τα χρωματικά, θολώδεις και αλφα εφέ να συνδυαστούν;**

Ναι. Η συλλογή τα δέχεται σε μία διατεταγμένη αλυσίδα. Λάβετε υπόψη τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, καθώς οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να αγνοήσουν χρωματικές ή αλφα λεπτομέρειες που δημιουργήθηκαν νωρίτερα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τις υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που βρίσκεται στη συλλογή μετασχηματισμού όπου υπάρχουν γράψιμες ιδιότητες· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες τιμές δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμού;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντάς το ξανά. Η κληρονομική μορφή PPT δεν μπορεί να αποτυπώσει ολόκληρο το μοντέλο εφέ DrawingML, ενώ οι μορφές εξαγωγής αποθηκεύουν μόνο την εμφάνιση και όχι τις επεξεργάσιμες λειτουργίες μετασχηματισμού.