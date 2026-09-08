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
- γκρι κλίμακα
- διχρωμία
- απόχρωση
- HSL
- αντικατάσταση χρώματος
- θόλωση
- διαφάνεια
- εφέ άλφα
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εφαρμόστε, συνδέστε, ελέγξτε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις εικόνας ως μια διατεταγμένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [Picture](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/) του πλαισίου και αποκτήστε πρόσβαση στο [Picture.getImageTransform](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/#getImageTransform). Η επιστρεφόμενη [ImageTransformOperationCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/) σας επιτρέπει να προσθέτετε, να απαριθμείτε, να εξετάζετε, να αφαιρείτε και να καθαρίζετε τα εφέ χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο δείχνει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρώματος, θόλωση, διαφάνεια, διατεταγμένες αλυσίδες εφέ, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση στρογγυλής διαδρομής PPTX.

## **Κατανόηση της κυριότητας των εφέ και επαναχρησιμοποίηση της εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) αποθηκεύει ή αναφέρεται στα δεδομένα της πηγής εικόνας που ανήκουν στην παρουσίαση.
- [Picture](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/) ανήκει σε γέμισμα εικόνας και αναφέρεται σε έναν πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμού εικόνας.
- [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) είναι το σχήμα της διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Συνεπώς, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/). Όταν το ίδιο `PPImage` περνιέται στην [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addPictureFrame) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `Picture` και τη δική του συλλογή μετασχηματισμού. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι κλίμακας, ακόμη και αν όλα επαναχρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `Picture.getImageTransform` χρησιμοποιείται επίσης από άλλα γέμιστρα εικόνας, όπως ένα σχήμα ή το φόντο διαφάνειας. Τα παραδείγματα παρακάτω επικεντρώνονται στα πλαίσια εικόνας.

## **Χρήση έγκυρων εύρους παραμέτρων και μονάδων**

Οι μεθόδοι που παρουσιάζονται χρησιμοποιούν τα ακόλουθα λογικά εύρη και μονάδες. Διατηρήστε τις τιμές εντός αυτών των ορίων ακόμη και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε έξω από το εύρος τιμή. Η μορφή παρουσίασης-στόχος μπορεί να ομαλοποιήσει, να παραλείψει ή να απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίξει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Καμία | Χωρίς αριθμητικές παραμέτρους. Το άλφα παραμένει αμετάβλητο. |
| [addDuotoneEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Δύο χρώματα για σκοτεινά και φωτεινά pixels. Τα κανάλια RGB και άλφα στο `java.awt.Color` χρησιμοποιούν τιμές `0` έως `255`. |
| [addTintEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Η απόχρωση είναι `0` (συμπεριλαμβανομένου) έως `360` (αποκλειστικό) μοίρες· το ποσό είναι `-100` έως `100` ποσοστό. |
| [addHSLEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι `0` έως `360` μοίρες· κορεσμός και φωτεινότητα είναι `-100` έως `100` ποσοστό. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [addBlurEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετράται σε points· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να εκτείνεται έξω από τα αρχικά όρια. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για τυπική κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διάφανο και `100` διατηρεί το υπάρχον άλφα. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` έως `100` ποσοστό αδιαφάνειας. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` έως `100` ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή πάνω γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση άλφα, η διαφάνεια και η αδιαφάνεια είναι αμοιβαία συμπληρωματικές. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό διαμόρφωσης άλφα 65 %.

## **Εφαρμογή φωτεινότητας και αντίθεσης**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) επιστρέφει μια λειτουργία [BrightnessContrast](https://reference.aspose.com/slides/el/python-java/aspose.slides/brightnesscontrast/). Οι κλιμακωτές ρυθμίσεις παρέχονται κατά τη δημιουργία της λειτουργίας. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/brightnesscontrast/#getEffective) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να εξεταστούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, έπειτα προβάλλει μια προεπισκόπηση χωρίς τροποποίηση της ενσωματωμένης εικόνας:

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

[BrightnessContrast](https://reference.aspose.com/slides/el/python-java/aspose.slides/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητό από το τυπικό εφέ luminance του DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από στρογγυλή διαδρομή PPTX, χρησιμοποιήστε το [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα ξανά του αρχείου. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διάκριση με περισσότερη λεπτομέρεια.

## **Εφαρμογή μετασχηματισμών χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το επόμενο παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, διχρωμία, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

[Duotone](https://reference.aspose.com/slides/el/python-java/aspose.slides/duotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `color1` αντιστοιχεί στα σκοτεινά pixels, ενώ το `color2` στα φωτεινά. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ με πιο σύνθετες ρυθμίσεις από μια μοναδική κλιμακωτή τιμή.

```python
import jpime
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

[addColorReplaceEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα διατηρώντας το άλφα. Είναι διαφορετικό από το [addColorChangeEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), το οποίο αντιστοιχίζει ένα χρώμα πηγής σε ένα χρώμα προορισμού και εκθέτει τόσο τη μορφή χρώματος πηγής όσο και προορισμού.

## **Προσθέστε θόλωση, διαφάνεια και εφέ άλφα**

[addBlurEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε `grow` σε `True` όταν το θολό άκρο μπορεί να εκτείνεται πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι ώστε τα ημιδιαφανή pixels να παραμένουν αναλογικά διαφορετικά. Το [addAlphaReplaceEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) αντιθέτως αποδίδει μία τιμή άλφα σε όλα τα pixels. Το [addAlphaBiLevelEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) μετατρέπει το άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

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

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [addAlphaCeilingEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), που κάνει κάθε μη μηδενικό άλφα πλήρως αδιαφανές· το [addAlphaFloorEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), που κάνει κάθε άλφα κάτω από 100 % πλήρως διαφανές· και το [addAlphaInverseEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), που αλλάζει το άλφα σε `100% - alpha`.

## **Δημιουργία διατεταγμένης αλυσίδας εφέ**

Κάθε μέθοδος `add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο renderer χρησιμοποιεί τη συλλογή ως διατεταγμένο pipeline: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες σε διαφορετική σειρά μπορούν να αποδώσουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση αφαιρεί πρώτα τις χρωματικές πληροφορίες και στη συνέχεια επαναχρωματίζει το αποτέλεσμα φωτεινότητας. Η απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί εκ νέου την απόχρωση. Παρόμοια, η αντικατάσταση άλφα μπορεί να υπερισχύσει των τιμών άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, τη σώζει ως PPTX, ανοίγει ξανά την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους, και προβάλλει το ξαναανοιγμένο αποτέλεσμα:

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

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θόλωσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί την παραλλαγή RGB που υπήρχε από προηγούμενα εφέ χρώματος· η γκρι κλίμακα μετά από διχρωμία αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα (ceil, floor, replace, bi‑level) μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Κατασκευάστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας pixel αντί να θεωρείτε τα στοιχεία ως αταξινόμητες σημαίες μορφοποίησης.

## **Επιθεώρηση επεξεργάσιμων και αποτελεσματικών τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο αποθηκευμένο στο `Picture.getImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει εγγράψιμα μέλη απευθείας. Για παράδειγμα, το [Blur](https://reference.aspose.com/slides/el/python-java/aspose.slides/blur/) εκθέτει εγγράψιμες τιμές `radius` και `grow`, το [AlphaModulateFixed](https://reference.aspose.com/slides/el/python-java/aspose.slides/alphamodulatefixed/) εκθέτει εγγράψιμο `amount`, και το [AlphaBiLevel](https://reference.aspose.com/slides/el/python-java/aspose.slides/alphabilevel/) εκθέτει εγγράψιμο `threshold`. Τα εφέ χρώματος όπως το [Duotone](https://reference.aspose.com/slides/el/python-java/aspose.slides/duotone/) εκθέτουν μεταβλητά αντικείμενα [ColorFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/colorformat/).

Κάποιες κλάσεις λειτουργιών, όπως το [BrightnessContrast](https://reference.aspose.com/slides/el/python-java/aspose.slides/brightnesscontrast/), το [HSL](https://reference.aspose.com/slides/el/python-java/aspose.slides/hsl/), το [Tint](https://reference.aspose.com/slides/el/python-java/aspose.slides/tint/), και το [AlphaReplace](https://reference.aspose.com/slides/el/python-java/aspose.slides/alphareplace/), δεν εκθέτουν τα αρχικά τους scalars ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στη ζητούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει το `getEffective` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτώμενων από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο renderer, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και εξετάζει τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

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

Τα εφέ χωρίς παραμέτρους όπως γκρι κλίμακα, άλφα ceiling και άλφα inverse έχουν ακόμη αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν κλιμακωτές ρυθμίσεις προς εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι η σημαντική πληροφορία.

## **Αφαίρεση ή εκκαθάριση μετασχηματισμών εικόνας**

Χρησιμοποιήστε το [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) για να αφαιρέσετε μια λειτουργία βάσει δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα τον στόχο και αφαιρέστε το μετά την απαρίθμηση. Χρησιμοποιήστε το [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#clear) για να αφαιρέσετε ολόκληρη την αλυσίδα.

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

Η αφαίρεση ή εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν επανασυμπιέζει και δεν τροποποιεί με άλλο τρόπο τον επαναχρησιμοποιούμενο πόρο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/).

## **Λάβετε υπόψη τις μορφές παρουσίασης και τους προορισμούς εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, έτσι το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμη και με PPTX, όχι κάθε λειτουργία έχει την ίδια φορητότητα:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, γκρι κλίμακα, διχρωμία, απόχρωση, HSL, θόλωση και κοινές λειτουργίες άλφα έχουν τις μεγαλύτερες πιθανότητες να παραμείνουν μετά από στρογγυλή διαδρομή PPTX. Πάντα ανοίξτε ξανά το παραγόμενο αρχείο και ελέγξτε τη συλλογή όταν η διατήρηση είναι απαίτηση.
- Το [BrightnessContrast](https://reference.aspose.com/slides/el/python-java/aspose.slides/brightnesscontrast/) είναι μια επέκταση Office 2010 αντί για το τυπικό εφέ luminance του DrawingML. Μπορεί να χρησιμοποιηθεί για ενδομνήμη rendering, αλλά δεν είναι εγγυημένο ότι θα παραμείνει ως επεξεργάσιμο [BrightnessContrast](https://reference.aspose.com/slides/el/python-java/aspose.slides/brightnesscontrast/) μετά την αποθήκευση και πάλι το άνοιγμα του PPTX. Προτιμήστε το [addLuminanceEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια πολύπλοκη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες οπτικές εξόδους εφαρμόζει την υποστηριζόμενη αλυσίδα στην τελική εμφάνιση. Αυτές οι εξόδους δεν περιέχουν επεξεργάσιμη `ImageTransformOperationCollection`; οι raster μορφές επίπεδουν το αποτέλεσμα σε pixel, και οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν τη δική τους αναπαράσταση rendering.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν η παρουσίαση φορτώνεται.

Διαφορετικοί καταναλωτές παρουσίασης μπορεί να αποδώσουν άκρια σενάρια διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρώματος. Για κρίσιμα αποτελέσματα, δοκιμάστε τόσο την επεξεργάσιμη στρογγυλή διαδρομή όσο και τη τελική μορφή εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές ερωτήσεις**

**Τροποποιούν τα εφέ μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `Picture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα bytes του `PPImage` παραμένουν αμετάβλητα.

**Μοιράζονται δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρησιμοποίηση ενός `PPImage` αποφεύγει διπλότυπα δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας κανονικά έχει ξεχωριστό `Picture` και συλλογή μετασχηματισμού εικόνας.

**Μπορούν τα εφέ χρώματος, θόλωσης και άλφα να συνδυαστούν;**

Ναι. Η συλλογή τα δέχεται σε μία διατεταγμένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στο αποτέλεσμα της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να απορρίψουν χρώμα ή άλφα που δημιουργήθηκε νωρίτερα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τις υπολογισμένες τιμές που χρησιμοποιούνται για rendering, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμού όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμού;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντας το ξανά. Το παλαιό PPT δεν μπορεί να αναπαραστήσει το πλήρες μοντέλο εφέ DrawingML, ενώ οι μορφές εξαγωγής διατηρούν την εμφάνιση παρά τις επεξεργάσιμες λειτουργίες μετασχηματισμού.