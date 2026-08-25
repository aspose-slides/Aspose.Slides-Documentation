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
- δυο-τόνος
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
- Aspose.Slides
description: "Εφαρμόστε, συνδέστε, επιθεωρήστε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Το Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις εικόνας ως μια διατεταγμένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [Picture](https://reference.aspose.com/slides/el/python-net/aspose.slides/picture/) του πλαισίου και αποκτήστε πρόσβαση στην ιδιότητά του [image_transform](https://reference.aspose.com/slides/el/python-net/aspose.slides/picture/image_transform/). Η επιστρεφόμενη [ImageTransformOperationCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/effects/imagetransformoperationcollection/) σάς επιτρέπει να προσθέτετε, να απαριθμείτε, να ελέγχετε, να αφαιρείτε και να εκκαθαρίζετε εφέ χωρίς να ξαναγράφετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο δείχνει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετατροπές χρώματος, θόλωση, διαφάνεια, διατεταγμένες αλυσίδες εφέ, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση πλήρους κύκλου PPTX.

## **Κατανόηση της Ιδιοκτησίας των Εφέ και Επαναχρησιμοποίησης της Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) αποθηκεύει ή αναφέρει τα δεδομένα της αρχικής εικόνας που ανήκουν στην παρουσίαση.
- [Picture](https://reference.aspose.com/slides/el/python-net/aspose.slides/picture/) ανήκει σε γέμισμα εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμών εικόνας.
- [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Συνεπώς, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/). Όταν το ίδιο `PPImage` περνιέται σε [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_picture_frame/) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `Picture` και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι κλίμακας, παρόλο που όλα χρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `Picture.image_transform` χρησιμοποιείται επίσης από άλλα γεμίσματα εικόνας, όπως σχήμα ή παρασκήνιο διαφάνειας. Τα παραδείγματα παρακάτω επικεντρώνονται στα πλαίσια εικόνας.

## **Χρήση Έγκυρων Εύρος Παραμέτρων και Μονάδων**

Οι μεθόδοι που παρουσιάζονται χρησιμοποιούν τα παρακάτω λογικά εύρη και μονάδες. Διατηρήστε τις τιμές σε αυτά τα εύρη ακόμη και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε τιμή εκτός εύρους· η μορφή προορισμού της παρουσίασης μπορεί να κανονικοποιήσει, παραλείψει ή απορρίψει άκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίγει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Καμία | Χωρίς αριθμητικές παραμέτρους. Η άλφα παραμένει αμετάβλητη. |
| [add_duotone_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Δύο χρώματα για σκούρα και ανοιχτά pixel. Τα κανάλια RGB και άλφα χρησιμοποιούν `0` έως `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Η απόχρωση είναι `0` (συμπεριλαμβανομένου) έως `360` (από αποκλεισμού), σε μοίρες· το ποσό είναι `-100` έως `100`, ποσοστό. |
| [add_hsl_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι `0` έως `360` (μη συμπεριλαμβανομένου), σε μοίρες· κορεσμός και φωτεινότητα είναι `-100` έως `100`, ποσοστό. |
| [add_color_replace_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [add_blur_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετρείται σε points· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να εκτείνεται εκτός των αρχικών ορίων. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για κανονική κλιμάκωση αδιαφάνειας: `0` είναι πλήρως διαυγές και `100` διατηρεί την υπάρχουσα άλφα. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` έως `100`, ποσοστό αδιαφάνειας. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαυγές· τιμές ίσες ή μεγαλύτερες γίνονται αδιαπέραστες. |

Για σταθερή διαμόρφωση άλφα, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, διαφάνεια 35% αντιστοιχεί σε ποσό διαμόρφωσης άλφα 65%.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) επιστρέφει μια λειτουργία [BrightnessContrast](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/brightnesscontrast/). Οι κλιμακωτικές ρυθμίσεις της παρέχονται κατά τη δημιουργία της λειτουργίας. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) επιστρέφει υπολογισμένες, μόνο για ανάγνωση τιμές που μπορούν να ελεγχθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15% και την αντίθεση κατά 20%, στη συνέχεια αποδίδει μια προεπισκόπηση χωρίς τροποποίηση της ενσωματωμένης εικόνας:

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

[BrightnessContrast](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/brightnesscontrast/) είναι επέκταση εφέ εικόνας Office 2010 και είναι λιγότερο φορητή από το τυπικό εφέ luminance του DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από έναν πλήρη κύκλο PPTX, χρησιμοποιήστε [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα ξανά του αρχείου. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διάκριση με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, δυο‑τόνο, απόχρωση, διόρθωση HSL και αντικατάσταση χρώματος.

[Duotone](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/duotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `color1` αντιστοιχεί σε σκούρα pixel, ενώ το `color2` σε ανοιχτά pixel. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ των ρυθμίσεων του οποίου είναι πιο πολύπλοκο από μια μοναδική κλιμακωτική τιμή.

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

[add_color_replace_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα διατηρώντας την άλφα. Είναι διαφορετικό από το [add_color_change_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), το οποίο αντιστοιχίζει ένα χρώμα πηγής σε ένα χρώμα στόχου και εκθέτει και τις δύο μορφές χρώματος.

## **Προσθήκη Θόλωσης, Διαφάνειας και Εφέ Άλφα**

[add_blur_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένης της άλφα. Ορίστε `grow` σε `True` όταν η θολή άκρη μπορεί να επεκταθεί πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, έτσι τα μερικώς διαυγή pixel παραμένουν αναλογικά διαφορετικά. [add_alpha_replace_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) αντιθέτως αναθέτει μια τιμή άλφα σε όλα τα pixel. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) μετατρέπει την άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

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

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν [add_alpha_ceiling_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), η οποία καθιστά κάθε μη‑μηδενική άλφα πλήρως αδιαπέραστη· [add_alpha_floor_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), η οποία κάνει κάθε άλφα κάτω από 100% πλήρως διαυγή· και [add_alpha_inverse_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), η οποία μετατρέπει την άλφα σε `100% - alpha`.

## **Δημιουργία Διατεταγμένης Αλυσίδας Εφέ**

Κάθε μέθοδος `add_..._effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο αποδότης χρησιμοποιεί τη συλλογή ως διατεταγμένη αλυσίδα επεξεργασίας: η έξοδος της λειτουργίας 0 γίνεται είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες με διαφορετική σειρά μπορούν να παράγουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι κλίμακα ακολουθούμενη από απόχρωση πρώτα αφαιρεί τις χρωματικές πληροφορίες και στη συνέχεια επαναχρωματίζει το αποτέλεσμα φωτεινότητας. Αντίθετα, η απόχρωση ακολουθούμενη από γκρι κλίμακα αφαιρεί ξανά την απόχρωση. Ομοίως, η αντικατάσταση άλφα μπορεί να υπερισχύσει των τιμών άλφα που υπολογίστηκαν από προηγούμενες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές τους.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ανοίγει ξανά την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους, και αποδίδει το αποτέλεσμα μετά το άνοιγμα:

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

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θόλωσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά δεν είναι πάντα χρήσιμοι οι συνδυασμοί. Μια σταθερή αντικατάσταση χρώματος αφαιρεί την παραλλαγή RGB που δημιουργήθηκε από προηγούμενα εφέ χρώματος· η γκρι κλίμακα μετά το δυο‑τόνο αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα «ceiling», «floor», «replacement» ή «bi‑level» μπορούν να απορρίψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Δημιουργήστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας pixel αντί να θεωρείτε τα στοιχεία της ως ασυγκεκριμένα σημαίες μορφοποίησης.

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `Picture.image_transform`. Ανάλογα με το εφέ, μπορεί να αποκαλύπτει εγγράψιμα μέλη άμεσα. Για παράδειγμα, το [Blur](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/blur/) εκθέτει εγγράψιμες ιδιότητες `radius` και `grow`, το [AlphaModulateFixed](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/alphamodulatefixed/) εκθέτει εγγράψιμη ιδιότητα `amount`, και το [AlphaBiLevel](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/alphabilevel/) εκθέτει εγγράψιμη ιδιότητα `threshold`. Τα εφέ χρώματος όπως το [Duotone](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/duotone/) εκθέτουν μεταβλητά αντικείμενα [ColorFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/colorformat/).

Ορισμένες λειτουργίες, όπως [BrightnessContrast](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/tint/), και [AlphaReplace](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/alphareplace/), δεν εκθέτουν τα αρχικά κλιμακωτικά παραμέτρων ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στη θέση που απαιτείται.

Τα αποτελεσματικά δεδομένα που επιστρέφει η `get_effective()` υπολογίζονται και είναι μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων που εξαρτώνται από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο αποδότης, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και ελέγχει τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

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

Τα εφέ χωρίς παραμέτρους, όπως η γκρι κλίμακα, το άλφα ceiling και το άλφα inverse, διαθέτουν αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχει κλιμακωτική ρύθμιση προς εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι οι σημαντικές πληροφορίες.

## **Αφαίρεση ή Εκκαθάριση Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) για να αφαιρέσετε μια λειτουργία με βάση το δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, εντοπίστε πρώτα τον στόχο και αφαιρέστε το μετά την απαρίθμηση. Χρησιμοποιήστε `clear()` για να αφαιρέσετε ολόκληρη την αλυσίδα.

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

Η αφαίρεση ή εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, συμπιέζει ξανά ή τροποποιεί με άλλο τρόπο τον επαναχρησιμοποιημένο πόρο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/).

## **Σκέψεις για Μορφές Παρουσίασης και Στόχους Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, έτσι το PPTX είναι η προτιμώμενη μορφή επεξεργασίας για αλυσίδες εφέ. Ακόμη και με PPTX, δεν έχουν όλες οι λειτουργίες την ίδια φορητότητα:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, γκρι κλίμακα, δυο‑τόνος, απόχρωση, HSL, θόλωση και κοινές λειτουργίες άλφα έχουν τις καλύτερες πιθανότητες να παραμείνουν μετά από έναν πλήρη κύκλο PPTX. Πάντα ανοίξτε ξανά το παραγόμενο αρχείο και ελέγξτε τη συλλογή όταν η διατήρηση είναι απαραίτητη.
- Το [BrightnessContrast](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/brightnesscontrast/) είναι επέκταση Office 2010 και όχι τυπική λειτουργία luminance του DrawingML. Μπορεί να χρησιμοποιηθεί για αποτύπωση στη μνήμη, αλλά δεν είναι εγγυημένο ότι θα παραμείνει επεξεργάσιμο ως λειτουργία `BrightnessContrast` μετά την αποθήκευση και το άνοιγμα ξανά του PPTX. Προτιμήστε το [add_luminance_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε ένα υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες οπτικές εξόδους εφαρμόζει την υποστηριζόμενη αλυσίδα στην εμφάνιση που αποδίδεται. Αυτές οι εξόδους δεν περιέχουν μια επεξεργάσιμη `ImageTransformOperationCollection`; οι μορφές raster εξομαλύνουν το αποτέλεσμα σε pixel, και οι εξαγωγές εγγράφου ή διανυσματικά αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν η παρουσίαση φορτώνεται.

Διαφοροί καταναλωτές παρουσίασης μπορεί να αποδίδουν περιπτώσεις άκρων διαφορετικά, ιδιαίτερα όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρωματικής ποσοτικοποίησης. Για κρίσιμη έξοδο, δοκιμάστε τόσο τον επεξεργάσιμο πλήρη κύκλο όσο και τη τελική μορφή εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν τα εφέ μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `Picture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα bytes του `PPImage` παραμένουν αμετάβλητα.

**Μοιράζονται δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρησιμοποίηση ενός `PPImage` αποφεύγει διπλότυπα δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας κανονικά έχει ανεξάρτητο `Picture` και συλλογή μετασχηματισμών εικόνας.

**Μπορούν τα εφέ χρώματος, θόλωσης και άλφα να συνδυαστούν;**

Ναι. Η συλλογή τα δέχεται σε μία διατεταγμένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορεί να απορρίψουν χρωματικές ή άλφα λεπτομέρειες που είχαν παραχθεί νωρίτερα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που είναι αποθηκευμένη στη συλλογή μετασχηματισμών όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμών;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντας το ξανά. Η κληρονομική μορφή PPT δεν μπορεί να απεικονίσει ολόκληρο το μοντέλο εφέ DrawingML, ενώ οι μορφές εξαγωγής αποδίδουν την εμφάνιση αντί για επεξεργάσιμες λειτουργίες μετασχηματισμού.