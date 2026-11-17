---
title: Διαχείριση Εφέ Μετασχηματισμού Εικόνας σε Παρουσιάσεις με Python
linktitle: Εφέ Μετασχηματισμού Εικόνας
type: docs
weight: 11
url: /el/python-net/image-transform-effects/
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
- εφέ alpha
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Εφαρμόστε, συνδέστε, ελέγξτε, αφαιρέστε και επαληθεύστε τα εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις εικόνας ως μια ταξινομημένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) του πλαισίου και προσπελάστε την ιδιότητα [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/). Η επιστρεφόμενη [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) σας επιτρέπει να προσθέσετε, να καταγράψετε, να εξετάσετε, να αφαιρέσετε και να καθαρίσετε τα εφέ χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο παρουσιάζει μια πλήρη ροή εργασίας για τη φωτεινότητα και την αντίθεση, τις μετασχηματίσεις χρώματος, το θολό, τη διαφάνεια, τις ταξινομημένες αλυσίδες εφέ, τις αποτελεσματικές τιμές, την αφαίρεση και την επαλήθευση κύκλου PPTX.

## **Κατανόηση της Ιδιοκτησίας των Εφέ και της Επανάχρησης Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) αποθηκεύει ή κάνει αναφορά στα δεδομένα της πηγαίας εικόνας που ανήκουν στην παρουσίαση.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) ανήκει σε γέμισμα εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμού εικόνας.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) είναι το σχήμα της διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Συνεπώς, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/). Όταν το ίδιο `PPImage` περάσει στην [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `Picture` και τη δική του συλλογή μετασχηματισμού. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι κλίμακας, ακόμη και αν όλα χρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `Picture.image_transform` χρησιμοποιείται επίσης από άλλα γέμισματα εικόνας, όπως σχήμα ή φόντο διαφάνειας. Τα παρακάτω παραδείγματα εστιάζουν σε πλαίσια εικόνας.

## **Χρήση Έγκυρων Εύρους Παραμέτρων και Μονάδων**

Οι επιδεικνυόμενες μέθοδοι χρησιμοποιούν τα παρακάτω εννοιολογικά εύρη και μονάδες. Διατηρήστε τις τιμές μέσα σε αυτά τα εύρη ακόμη και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε εκτός εύρους τιμή· η μορφή παρουσίασης-στόχος μπορεί να κανονικοποιήσει, να παραλείψει ή να απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίξει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Δεν υπάρχουν αριθμητικές παράμετροι. Η διαφάνεια (alpha) παραμένει αμετάβλητη. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Δύο χρώματα για σκοτεινά και φωτεινά εικονοστοιχεία. Τα κανάλια RGB και alpha χρησιμοποιούν τιμές από `0` έως `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Η απόχρωση είναι από `0` (συμπεριλαμβανομένου) έως `360` (α αποκλειστικού), σε μοίρες· το ποσό είναι από `-100` έως `100`, ποσοστό. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι από `0` (συμπεριλαμβανομένου) έως `360` (α αποκλειστικού), σε μοίρες· η κορεσμός και η φωτεινότητα είναι από `-100` έως `100`, ποσοστό. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές alpha παραμένουν αμετάβλητες. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετράται σε σημεία· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να επεκταθεί εκτός των αρχικών ορίων. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε τιμές από `0` έως `100` για κανονική κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διαφανές και `100` διατηρεί το υπάρχον alpha. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` έως `100`, ποσοστό αδιαφάνειας. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` έως `100`, όριο alpha σε ποσοστό. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή πάνω γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση alpha, η διαφάνεια και η αδιαφάνεια είναι αμοιβαία συμπληρωματικές. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό διαμόρφωσης alpha 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) επιστρέφει μια λειτουργία [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/). Οι κλιμακωτές ρυθμίσεις του παρέχονται όταν η λειτουργία δημιουργείται. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να επιθεωρηθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, μετά αποδίδει μια προεπισκόπηση χωρίς να τροποποιήσει την ενσωματωμένη εικόνα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας του Office 2010 και είναι λιγότερο φορητό από το τυπικό εφέ luminance του DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμένουν επεξεργάσιμες μετά από κύκλο PPTX, χρησιμοποιήστε το [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου ξανά. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διαφορά με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Οι χρωματικές επιδράσεις μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που χρησιμοποιούν τον ίδιο πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, δυοχρωματική απόχρωση, απόχρωση, ρύθμιση HSL και αντικατάσταση χρώματος.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: `color1` αντιστοιχεί σε σκοτεινά εικονοστοιχεία, ενώ `color2` αντιστοιχεί σε φωτεινά. Αυτό το καθιστά ένα χρήσιμο παράδειγμα εφέ των ρυθμίσεών του είναι πιο πολύπλοκες από μία απλή κλιμακωτή τιμή.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) αντικαθιστά το χρώμα κάθε εικονοστοιχείου με ένα σταθερό χρώμα ενώ διατηρεί το alpha. Διαφέρει από το [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), το οποίο αντιστοιχίζει ένα χρώμα πηγής σε άλλο και εκθέτει και τις μορφές χρώματος πηγής και προορισμού.

### **Εφαρμογή Κατωφλίου Φωτεινότητας**

Ένα κατώφλι φωτεινότητας μπορεί να κάνει πιο εύκολη τη διάκριση αμυδρών σημείων σε σαρωμένη σελίδα από το παρασκήνιο. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) διατηρεί ενδιάμεσες αποχρώσεις του γκρι. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) αντιστοιχεί τη φωτεινότητα σε μαύρο ή λευκό, ενώ [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) εφαρμόζει ένα κατώφλι στην αδιαφάνεια.

Το κατώφλι φωτεινότητας κυμαίνεται από 0 % έως 100 %, συμπεριλαμβανομένων. Τα εικονοστοιχεία κάτω από το κατώφλι γίνονται μαύρα. Τα εικονοστοιχεία ίσα ή πάνω γίνονται λευκά. Η αύξηση του κατωφλίου κάνει περισσότερες αποχρώσεις μαύρες επειδή περισσότερα εικονοστοιχεία πέφτουν κάτω από το όριο.

Κατεβάστε το [grayscale-swatches.png](grayscale-swatches.png) στον τρέχοντα φάκελο εργασίας. Κάθε ετικέτα δίνει το αρχικό επίπεδο γκρι σε κλίμακα από 0 έως 255. Το παράδειγμα τοποθετεί το αρχικό δίπλα σε δύο αντίτυπα και αποθηκεύει το κατώφλι κάθε αντιγράφου στην παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

Ανοίξτε την παραγόμενη παρουσίαση στο PowerPoint για να συγκρίνετε τα τρία πλαίσια. Η ετικέτα 96 έχει περίπου 38 % φωτεινότητα (96 από 255). Γίνονται λευκά στο κατώφλι 20 % και μαύρα στο κατώφλι 60 %.

![Αρχικά γκρι κλίμακες δίπλα στα μαύρο-άσπρα αποτελέσματα σε κατώφλια φωτεινότητας 20% και 60%](luminance-threshold.png)

## **Προσθήκη Θολώματος, Διαφάνειας και Εφέ Alpha**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του alpha. Ορίστε `grow` σε `True` όταν η θολή άκρη μπορεί να επεκταθεί εκτός των αρχικών ορίων της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή alpha, έτσι τα ημιδιαφανή εικονοστοιχεία παραμένουν αντιπροσωπευτικά. Το [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) αντιθέτως εκχωρεί μια τιμή alpha σε όλα τα εικονοστοιχεία. Το [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) μετατρέπει το alpha σε δύο επίπεδα βάσει ενός κατωφλίου.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

Άλλες λειτουργίες alpha χωρίς παραμέτρους περιλαμβάνουν το [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), που καθιστά κάθε μη μηδενικό alpha πλήρως αδιαφανές· το [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), που κάνει κάθε alpha κάτω από 100 % πλήρως διαφανές· και το [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), που αλλάζει το alpha σε `100% - alpha`.

## **Δημιουργία Ταξινομημένης Αλυσίδας Εφέ**

Κάθε μέθοδος `add_..._effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο κινητήρας αποδίδει τη συλλογή ως μια ταξινομημένη αλυσίδα: η έξοδος της λειτουργίας 0 γίνεται είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες σε διαφορετική σειρά μπορούν να παράγουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση αφαιρεί πρώτα την χρωματική πληροφορία και στη συνέχεια επαναχρωματίζει το αποτέλεσμα της φωτεινότητας. Η απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί την απόχρωση ξανά. Παρόμοια, η αντικατάσταση alpha μπορεί να αντικαταστήσει τιμές alpha που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση alpha διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ανοίγει ξανά την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους, και αποδίδει το ξαναανοιγμένο αποτέλεσμα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, alpha και θολώματος σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Η σταθερή αντικατάσταση χρώματος αφαιρεί τις μεταβολές RGB που προκλήθηκαν από προηγούμενα χρωματικά εφέ· η γκρι κλίμακα μετά το δυοχρωμικό εφέ αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες alpha ceiling, floor, replacement ή bi-level μπορούν να αγνοήσουν λεπτομέρειες alpha που δημιουργήθηκαν νωρίτερα. Δημιουργήστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας εικονοστοιχείων αντί να θεωρείτε τα στοιχεία ως αδιάτακτες σημαίες μορφοποίησης.

<!-- visual-explanation:image-transform-effects:start -->
[![Η ίδια εικόνα περνάει από γκρι κλίμακα και μετά από απόχρωση, και από απόχρωση και μετά από γκρι κλίμακα. Οι δύο τελικές εικόνες γκρι κλίμακας έχουν διαφορετικές αποχρώσεις.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Σε αυτήν την επεξηγηματική απόδοση του Aspose.Slides for .NET 26.11, μια απόχρωση 220° με 25% δεν αλλάζει την εικόνα γκρι κλίμακας. Η εφαρμογή της ίδιας απόχρωσης πριν από τη γκρι κλίμακα παράγει διαφορετικές αποχρώσεις.*
<!-- visual-explanation:image-transform-effects:end -->

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μία επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `Picture.image_transform`. Ανάλογα με το εφέ, μπορεί να εκθέτει εγγράψιμα μέλη απευθείας. Για παράδειγμα, το [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) εκθέτει εγγράψιμες ιδιότητες `radius` και `grow`, το [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) εκθέτει εγγράψιμη ιδιότητα `amount`, και το [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) εκθέτει εγγράψιμη ιδιότητα `threshold`. Τα χρωματικά εφέ όπως το [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) εκθέτουν μεταβλητά αντικείμενα [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/).

Ορισμένες λειτουργίες, όπως το [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), το [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), το [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/), και το [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/), δεν εκθέτουν τις κλιμακωτές δημιουργίας ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μία αντικατάσταση στη ζητούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει η `get_effective()` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτώμενων από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο κινητήρας, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα καταγράφει την αλυσίδα και επιθεωρεί τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Οι λειτουργίες χωρίς παραμέτρους όπως η γκρι κλίμακα, το alpha ceiling και το alpha inverse έχουν ακόμη αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν κλιμακωτές ρυθμίσεις προς εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι η σημαντική πληροφορία.

## **Αφαίρεση ή Εκκαθάριση Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) για να αφαιρέσετε μία λειτουργία με βάση το δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα το στόχο και αφαιρέστε το μετά την καταμέτρηση. Χρησιμοποιήστε `clear()` για να αφαιρέσετε ολόκληρη την αλυσίδα.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Η αφαίρεση ή εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, συμπιέζει ξανά ή αλλιώς τροποποιεί τον επανχρησιμοποιούμενο πόρο [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).

## **Λήψη Υπόψης Μορφών Παρουσίασης και Στόχων Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, έτσι το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμη και με PPTX, δεν έχουν όλες οι λειτουργίες την ίδια φορητότητα:

- Τα τυπικά λειτουργίες DrawingML όπως η luminance, η γκρι κλίμακα, η δυοχρωμική απόχρωση, η απόχρωση, το HSL, το θόλωμα και οι κοινές λειτουργίες alpha έχουν την καλύτερη πιθανότητα να παραμείνουν μετά από κύκλο PPTX. Πάντοτε ανοίξτε ξανά το παραγόμενο αρχείο και ελέγξτε τη συλλογή όταν η διατήρηση είναι απαραίτητη.
- Το [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση του Office 2010 και όχι η τυπική λειτουργία luminance του DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση στη μνήμη, αλλά δεν εγγυάται ότι θα παραμείνει ως επεξεργάσιμη λειτουργία `BrightnessContrast` μετά την αποθήκευση και το ξαναάνοιγμα του PPTX. Προτιμήστε το [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει την αλυσίδα σε ένα υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες οπτικές μορφές εφαρμόζει την υποστηριζόμενη αλυσίδα στην εμφανιζόμενη εικόνα. Αυτές οι εξαγωγές δεν περιέχουν επεξεργάσιμη [ImageTransformOperationCollection]; οι μορφές raster ισοπεδώνουν το αποτέλεσμα σε εικονοστοιχεία, ενώ οι εξαγωγές εγγράφων ή διανυσμάτων αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν φορτώνεται η παρουσίαση.

Διαφορετικοί καταναλωτές παρουσίασης μπορεί να αποδώσουν ακραίες περιπτώσεις διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες alpha ή χρωματικής ποσοτικοποίησης. Για κρίσιμη έξοδο, δοκιμάστε τόσο τον επεξεργάσιμο κύκλο όσο και τη τελική μορφή εξαγωγής με την ίδια έκδοση Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν οι μετασχηματισμοί εικόνας τα ενσωματωμένα δεδομένα της εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `Picture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα bytes του `PPImage` παραμένουν αμετάβλητα.

**Θα μοιράζονται δύο πλαίσια εικόνας που χρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρήση ενός `PPImage` αποφεύγει την διπλή αποθήκευση των δεδομένων εικόνας, αλλά κάθε πλαίσιο εικόνας συνήθως έχει ξεχωριστό `Picture` και συλλογή μετασχηματισμού εικόνας.

**Μπορούν να συνδυαστούν χρωματικά, θολώματα και epsilon α-α;** (Note: original says "alpha effects")

**Μπορούν να συνδυαστούν χρωματικά, θολώματα και epsilon alpha;** Wait translation: We need proper Greek.

Original question: "Can color, blur, and alpha effects be combined?" Translate to Greek: "Μπορούν να συνδυαστούν χρωματικά, θολώματα και εφέ alpha;"

Answer: "Ναι. Η συλλογή τα δέχεται σε μια ταξινομημένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να αφαιρέσουν χρώμα ή λεπτομέρειες alpha που είχαν υπολογιστεί νωρίτερα."

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Οι αποτελεσματικές τιμές αντιπροσωπεύουν τις υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμού όπου υπάρχουν εγγράψιμες ιδιότητες· διαφορετικά αφαιρέστε την και προσθέστε μια αντικατάσταση με τις νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμού;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντάς το ξανά. Το κληροδοτημένο PPT δεν μπορεί να αντιπροσωπεύσει το πλήρες μοντέλο εφέ DrawingML, και οι εκχωρημένες μορφές εξαγώγονται μόνο για εμφάνιση, όχι για επεξεργάσιμες λειτουργίες μετασχηματισμού.