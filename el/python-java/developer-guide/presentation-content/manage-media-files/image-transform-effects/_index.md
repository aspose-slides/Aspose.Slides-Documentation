---
title: Διαχείριση Εφέ Μετασχηματισμού Εικόνας σε Παρουσιάσεις με Python
linktitle: Εφέ Μετασχηματισμού Εικόνας
type: docs
weight: 11
url: /el/python-java/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- εφέ εικόνας
- φωτεινότητα
- αντίθεση
- γκρι κλίμακας
- δυχρωματικό
- απόχρωση
- HSL
- αντικατάσταση χρώματος
- θολούρα
- διαφάνεια
- εφέ άλφα
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εφαρμόστε, αλυσίδωση, επιθεωρήστε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις εικόνας ως μια διατεταγμένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) του πλαισίου και αποκτήστε πρόσβαση στο [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform). Η επιστρεφόμενη [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) σας επιτρέπει να προσθέσετε, να απαριθμήσετε, να ελέγξετε, να αφαιρέσετε και να καθαρίσετε τα εφέ χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο επιδεικνύει μια πλήρη διαδικασία για φωτεινότητα και αντίθεση, μετασχηματισμούς χρώματος, θολότητα, διαφάνεια, διατεταγμένες αλυσίδες εφέ, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση κύκλου PPTX.

## **Κατανόηση Ιδιοκτησίας Εφέ και Επαναχρησιμοποίησης Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- Το [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) αποθηκεύει ή αναφέρει τα δεδομένα της πηγαίας εικόνας που ανήκουν στην παρουσίαση.
- Το [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) ανήκει σε γέμισμα εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμών εικόνας.
- Το [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Ως εκ τούτου, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/). Όταν το ίδιο `PPImage` περάσει στο [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `Picture` και τη δική του συλλογή μετασχηματισμού. Η εφαρμογή του γκριτουνου σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκριτουνου, ακόμη και αν όλα επαναχρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `Picture.getImageTransform` χρησιμοποιείται επίσης από άλλα γεμίσματα εικόνας, όπως ένα σχήμα ή το φόντο της διαφάνειας. Τα παραδείγματα παρακάτω εστιάζουν στα πλαίσια εικόνας.

## **Χρήση Έγκυρων Εύρους Παραμέτρων και Μονάδων**

Οι επιδεικνυόμενες μέθοδοι χρησιμοποιούν τα ακόλουθα λογικά εύρη και μονάδες. Κρατήστε τις τιμές μέσα σε αυτά τα εύρη ακόμη και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε τιμή εκτός εύρους· η μορφή παρουσίασης-στόχος μπορεί να κανονικοποιήσει, να παραλείψει ή να απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίγει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | Κανένα αριθμητικό παράμετρο. Το άλφα παραμένει αμετάβλητο. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Δύο χρώματα για σκούρα και ανοιχτά εικονοστοιχεία. Τα κανάλια RGB και άλφα στο `java.awt.Color` χρησιμοποιούν τιμές από `0` έως `255`. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Η απόχρωση είναι `0` (συμπεριλαμβανομένη) μέχρι `360` (α αποκλειστικό), σε μοίρες· το ποσό είναι από `-100` έως `100`, ποσοστό. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι `0` (συμπεριλαμβανομένη) μέχρι `360` (α αποκλειστικό), σε μοίρες· ο κορεσμός και η φωτεινότητα είναι από `-100` έως `100`, ποσοστό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετράται σε points· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να επεκταθεί εκτός των αρχικών ορίων. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε τιμές από `0` έως `100` για κανονική κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διαφανές και `100` διατηρεί το υπάρχον άλφα. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` έως `100`, ποσοστό αδιαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή πάνω γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση άλφα, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, 35% διαφάνεια αντιστοιχεί σε ποσό διαμόρφωσης άλφα 65%.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

Η [ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) επιστρέφει μια λειτουργία [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/). Οι βαθμικές ρυθμίσεις της παρέχονται κατά τη δημιουργία της λειτουργίας. Η [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να επιθεωρηθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15% και την αντίθεση κατά 20%, μετά εμφανίζει μια προεπισκόπηση χωρίς να τροποποιήσει την ενσωματωμένη εικόνα:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας του Office 2010 και είναι λιγότερο φορητή από το τυπικό εφέ φωτεινότητας DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από έναν κύκλο PPTX, χρησιμοποιήστε την [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διάκριση με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκριτουνου, διχρωματικό, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `color1` αντιστοιχεί στα σκούρα εικονοστοιχεία, ενώ το `color2` στα ανοιχτά. Αυτό το καθιστά ένα χρήσιμο παράδειγμα εφέ των οποίων οι ρυθμίσεις είναι πιο σύνθετες από μια μοναδική βαθμική τιμή.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) αντικαθιστά το χρώμα κάθε εικονοστοιχείου με ένα σταθερό χρώμα διατηρώντας το άλφα. Είναι διαφορετικό από το [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), που αντιστοιχεί ένα χρώμα προέλευσης σε άλλο και εκθέτει και τις μορφές χρώματος πηγής και προορισμού.

### **Εφαρμογή Κατωφλίου Φωτεινότητας**

Ένα κατώφλι φωτεινότητας μπορεί να κάνει τα αχνά σημάδια σε μια σαρωμένη σελίδα πιο εύκολα διακριτά από το φόντο. Το [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) διατηρεί ενδιάμεσες αποχρώσεις του γκρι. Το [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) αντιστοιχεί τη φωτεινότητα σε μαύρο ή λευκό, ενώ το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) εφαρμόζει κατώφλι στην αδιαφάνεια.

Το κατώφλι φωτεινότητας κυμαίνεται από 0% έως 100%, συμπεριλαμβανομένων. Τα εικονοστοιχεία κάτω από το κατώφλι γίνονται μαύρα. Τα εικονοστοιχεία στο ή πάνω από αυτό γίνονται λευκά. Η αύξηση του κατωφλίου μετατρέπει περισσότερες αποχρώσεις σε μαύρο επειδή περισσότερα πέφτουν κάτω από το όριο.

Κατεβάστε το αρχείο [grayscale-swatches.png](grayscale-swatches.png) στον τρέχοντα φάκελο. Κάθε ετικέτα δείχνει το αρχικό επίπεδο γκρι σε κλίμακα από 0 έως 255. Το παράδειγμα τοποθετεί το αρχικό δίπλα σε δύο αντίγραφα και αποθηκεύει το κατώφλι κάθε αντιγράφου στην παρουσίαση.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ανοίξτε την έξοδο παρουσίασης στο PowerPoint για να συγκρίνετε τα τρία πλαίσια. Η δειγματοληψία με ετικέτα 96 έχει περίπου 38% φωτεινότητα (96 από 255). Γίνεται λευκή στο κατώφλι 20% και μαύρη στο 60% .

![Αρχικές γκρι δειγματοληψίες δίπλα στα αποτελέσματα ασπρόμαυρου στα κατώφλια φωτεινότητας 20% και 60%](luminance-threshold.png)

## **Προσθήκη Θολούσας, Διαφάνειας και Εφέ Άλφα**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε το `grow` σε `True` όταν η θολωμένη άκρη μπορεί να επεκταθεί εκτός των αρχικών ορίων της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι ώστε τα μερικώς διαφανή εικονοστοιχεία να παραμένουν αναλογικά διαφορετικά. Το [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) αντιθέτως αναθέτει μία τιμή άλφα σε όλα τα εικονοστοιχεία. Το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) μετατρέπει το άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), που κάνει κάθε μη μηδενικό άλφα πλήρως αδιαφανές· το [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), που κάνει κάθε άλφα κάτω από 100% πλήρως διαφανές· και το [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), που αλλάζει το άλφα σε `100% - alpha`.

## **Κατασκευή Διατεταγμένης Αλυσίδας Εφέ**

Κάθε `add...Effect` μέθοδος προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο renderer χρησιμοποιεί τη συλλογή ως μια διατεταγμένη pipeline: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1, κλπ. Συνεπώς, οι ίδιες λειτουργίες με διαφορετική σειρά μπορούν να παράγουν διαφορετική εικόνα.

Για παράδειγμα, το γκριτουνου ακολουθούμενο από απόχρωση αφαιρεί πρώτα την χρωματική πληροφορία και στη συνέχεια επαναχρωματίζει το αποτέλεσμα της φωτεινότητας. Η απόχρωση ακολουθούμενη από γκριτουνου αφαιρεί ξανά την απόχρωση. Ομοίως, η αντικατάσταση άλφα μπορεί να υπερκαλύψει τις τιμές άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ανοίγει ξανά την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους, και αποδίδει το αποτέλεσμα μετά το άνοιγμα:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θολούσας σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί την παραλλαγή RGB που δημιουργήθηκε από προηγούμενα εφέ χρώματος· το γκριτουνου μετά το διχρωματικό αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα ceiling, floor, replacement ή bi-level μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Κατασκευάστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας εικονοστοιχείων αντί να θεωρείτε τα στοιχεία της ως μη διατεταγμένες σημαίες μορφοποίησης.

<!-- visual-explanation:image-transform-effects:start -->
[![Η ίδια εικόνα περνάει από γκριτουνου τότε απόχρωση, και απόχρωση τότε γκριτουνου. Οι δύο τελικές γκρι εικόνες έχουν διαφορετικούς τόνους.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
<!-- visual-explanation:image-transform-effects:end -->

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `Picture.getImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει απευθείας επεξεργάσιμα μέλη. Για παράδειγμα, το [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) εκθέτει επεξεργάσιμες τιμές `radius` και `grow`, το [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) εκθέτει επεξεργάσιμο `amount`, και το [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) εκθέτει επεξεργάσιμο `threshold`. Τα εφέ χρώματος όπως το [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) εκθέτουν μεταβλητά αντικείμενα [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/).

Ορισμένες κλάσεις λειτουργίας, όπως τα [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/) και [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/), δεν εκθέτουν τις δημιουργικές βαθμικές τιμές ως επεξεργάσιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στην απαιτούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει η `getEffective` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτώνται από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο renderer, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και επιθεωρεί τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Εφέ χωρίς παραμέτρους όπως το γκριτουνου, το alpha ceiling και το alpha inverse διατηρούν ακόμη ένα αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν βαθμικές ρυθμίσεις για εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι η σημαντική πληροφορία.

## **Αφαίρεση ή Καθαρισμός Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) για να αφαιρέσετε μια λειτουργία με βάση το δείκτη. Επειδή οι δείκτες μεταβάλλονται μετά την αφαίρεση, αναζητήστε πρώτα τον στόχο και αφαιρέστε τον μετά την απαρίθμηση. Χρησιμοποιήστε το [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) για να αφαιρέσετε ολόκληρη την αλυσίδα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αφαίρεση ή ο καθαρισμός των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν συμπιέζει ξανά, ή αλλιώς τροποποιεί τον επαναχρησιμοποιημένο πόρο [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/).

## **Λάβετε υπόψη τις μορφές παρουσίασης και τους στόχους εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, επομένως το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμα και με PPTX, δεν έχει κάθε λειτουργία την ίδια φορητότητα:

- Οι τυπικές λειτουργίες DrawingML όπως η φωτεινότητα, το γκριτουνου, το διχρωματικό, η απόχρωση, το HSL, η θολούσα και οι κοινές λειτουργίες άλφα έχουν τις μεγαλύτερες πιθανότητες να επιβιώσουν σε έναν κύκλο PPTX. Πάντα ανοίξτε ξανά το παραγόμενο αρχείο και επιθεωρήστε τη συλλογή όταν απαιτείται διατήρηση.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) είναι μια επέκταση του Office 2010 αντί για τη στάνταρ λειτουργία φωτεινότητας DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση στην μνήμη, αλλά δεν εγγυάται ότι θα παραμείνει ως επεξεργάσιμο [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) μετά την αποθήκευση και το άνοιγμα ξανά του PPTX. Προτιμήστε το [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε υποσύνολο υποστηριζόμενο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες οπτικές εξόδους εφαρμόζει την υποστηριζόμενη αλυσίδα στην απόδοση. Αυτές οι εξόδους δεν περιέχουν μια επεξεργάσιμη `ImageTransformOperationCollection`; οι μορφές raster ισοπεδώνουν το αποτέλεσμα σε εικονοστοιχεία, και οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν φορτώνεται η παρουσίαση.

Διαφορετικοί καταναλωτές παρουσίασης μπορεί να αποδίδουν περιπτώσεις άκρων διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρωματικού κβαντισμού. Για κρίσιμα αποτελέσματα, δοκιμάστε τόσο τον επεξεργάσιμο κύκλο όσο και τη τελική μορφή εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν τα εφέ μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `Picture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα bytes του `PPImage` παραμένουν αμετάβλητα.

**Θα μοιραστούν δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρησιμοποίηση ενός `PPImage` αποτρέπει τα διπλότυπα δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας συνήθως έχει ξεχωριστό `Picture` και συλλογή μετασχηματισμού εικόνας.

**Μπορούν τα εφέ χρώματος, θολούσας και άλφα να συνδυαστούν;**

Ναι. Η συλλογή τα αποδέχεται σε μια διατεταγμένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή λειτουργίες αντικατάστασης και κατωφλίου μπορεί να απορρίψουν πρώιμες λεπτομέρειες χρώματος ή άλφα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, περιλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που είναι αποθηκευμένη στη συλλογή μετασχηματισμών όπου υπάρχουν επεξεργάσιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμού;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντάς το ξανά. Η παλαιά μορφή PPT δεν μπορεί να αναπαραστήσει το πλήρες μοντέλο εφέ DrawingML, και οι μορφές εξαγωγής που αποδίδουν διατηρούν μόνο την εμφάνιση και όχι τις επεξεργάσιμες λειτουργίες μετασχηματισμού.