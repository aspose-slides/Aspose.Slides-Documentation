---
title: Διαχείριση Φόντων Παρουσίασης σε Python
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/python-net/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- μονόχρωμο χρώμα
- διαβαθμισμένο χρώμα
- φόντο εικόνας
- διαφάνεια φόντου
- ιδιότητες φόντου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET, με συμβουλές κώδικα για τη βελτίωση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Οι ενιαίοχρωμες, τα διαβαθμισμένα χρώματα και οι εικόνες χρησιμοποιούνται συχνά ως φόντο διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μια μόνο διαφάνεια) ή μια **διαφάνεια προτύπου** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![Φόντο PowerPoint](powerpoint-background.png)

## **Ορισμός Φόντου Ενιαίου Χρώματος για Κανονική Διαφάνεια**

Το Aspose.Slides σάς επιτρέπει να ορίσετε ένα ενιαίο χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση—ακόμη και αν η παρουσίαση χρησιμοποιεί διαφάνεια προτύπου. Η αλλαγή εφαρμόζεται μόνο στην επιλεγμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/python-net/aspose.slides/backgroundtype/) της διαφάνειας σε `OWN_BACKGROUND`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του φόντου διαφάνειας σε `SOLID`.
4. Χρησιμοποιήστε την ιδιότητα `solid_fill_color` στην κλάση [FillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/) για να ορίσετε το χρώμα του ενιαίου φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Python δείχνει πώς να ορίσετε ένα μπλε ενιαίο χρώμα ως φόντο για μια κανονική διαφάνεια:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ορίστε το χρώμα φόντου της διαφάνειας σε μπλε.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Φόντου Ενιαίου Χρώματος για τη Διαφάνεια Προτύπου**

Το Aspose.Slides σάς επιτρέπει να ορίσετε ένα ενιαίο χρώμα ως φόντο για τη διαφάνεια προτύπου σε μια παρουσίαση. Η διαφάνεια προτύπου λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση για όλες τις διαφάνειες, έτσι όταν επιλέγετε ένα ενιαίο χρώμα για το φόντο της διαφάνειας προτύπου, αυτό εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/python-net/aspose.slides/backgroundtype/) της διαφάνειας προτύπου (μέσω `masters`) σε `OWN_BACKGROUND`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του φόντου διαφάνειας προτύπου σε `SOLID`.
4. Χρησιμοποιήστε την ιδιότητα `solid_fill_color` στην κλάση [FillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/) για να ορίσετε το χρώμα του ενιαίου φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Python δείχνει πώς να ορίσετε ένα ενιαίο χρώμα (φυτικό πράσινο) ως φόντο για τη διαφάνεια προτύπου:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Ορίστε το χρώμα φόντου για τη διαφάνεια Master σε Πράσινο δάσους.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Διαβαθμισμένου Φόντου για μια Διαφάνεια**

Η διαβάθμιση είναι ένα γραφικό εφέ που δημιουργείται από μια σταδιακή αλλαγή χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, οι διαβαθμίσεις μπορούν να κάνουν τις παρουσιάσεις να φαίνονται πιο καλλιτεχνικές και επαγγελματικές. Το Aspose.Slides σάς επιτρέπει να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για διαφάνειες.

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/python-net/aspose.slides/backgroundtype/) της διαφάνειας σε `OWN_BACKGROUND`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του φόντου διαφάνειας σε `GRADIENT`.
4. Χρησιμοποιήστε την ιδιότητα `gradient_format` στην κλάση [FillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/) για να ρυθμίσετε τις προτιμώμενες παραμέτρους διαβάθμισης.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Python δείχνει πώς να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για μια διαφάνεια:

```python
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Εφαρμόστε ένα διαβαθμισμένο εφέ στο φόντο.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Εκτός από ενιαία και διαβαθμισμένα γέμισματα, το Aspose.Slides σάς επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφανειών.

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/python-net/aspose.slides/backgroundtype/) της διαφάνειας σε `OWN_BACKGROUND`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/python-net/aspose.slides/filltype/) του φόντου διαφάνειας σε `PICTURE`.
4. Φορτώστε την εικόνα που επιθυμείτε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε την ιδιότητα `picture_fill_format` στην κλάση [FillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/) για να αναθέσετε την εικόνα ως φόντο.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα Python δείχνει πώς να ορίσετε μια εικόνα ως φόντο για μια διαφάνεια:

```python
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ορίστε τις ιδιότητες εικόνας φόντου.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Φορτώστε την εικόνα.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Το παρακάτω δείγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσματος φόντου σε επαναλαμβανόμενη εικόνα και να τροποποιήσετε τις ιδιότητες επικάλυψης:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Ορίστε την εικόνα που χρησιμοποιείται για το γέμισμα φόντου.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Ορίστε τη λειτουργία γέμισματος εικόνας σε πλακίδιο και προσαρμόστε τις ιδιότητες του πλακιδίου.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
Διαβάστε περισσότερα: [**Εικόνα Παράθεσης Ως Υφή**](/slides/el/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή Διαφάνειας Φόντου Εικόνας**

Μπορεί να θέλετε να ρυθμίσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο να ξεχωρίζει. Ο παρακάτω κώδικας Python σας δείχνει πώς να αλλάξετε τη διαφάνεια για την εικόνα φόντου μιας διαφάνειας:

```python
transparency_value = 30  # Για παράδειγμα.

# Αποκτήστε τη συλλογή των λειτουργιών μετασχηματισμού εικόνας.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Βρείτε ένα υπάρχον εφέ διαφάνειας με σταθερό ποσοστό.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Ορίστε τη νέα τιμή διαφάνειας.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Λήψη Τιμής Φόντου Διαφάνειας**

Το Aspose.Slides παρέχει την κλάση [IBackgroundEffectiveData](https://reference.aspose.com/slides/el/python-net/aspose.slides/ibackgroundeffectivedata/) για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτή η κλάση εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/) και [EffectFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/effectformat/).

Χρησιμοποιώντας την ιδιότητα `background` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/), μπορείτε να λάβετε το αποτελεσματικό φόντο για μια διαφάνεια.

Το παρακάτω παράδειγμα Python δείχνει πώς να λάβετε την αποτελεσματική τιμή φόντου μιας διαφάνειας:

```python
import aspose.slides as slides

# Δημιουργήστε μια παρουσία της κλάσης Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Ανακτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη το master, τη διάταξη και το θέμα.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **Συχνές Ερωτήσεις**

**Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να αποκαταστήσω το φόντο θέματος/διάταξης;**

Ναι. Αφαιρέστε το προσαρμοσμένο γέμισμα της διαφάνειας, και το φόντο θα κληθεί ξανά από την αντίστοιχη διαφάνεια [διάταξης](/slides/el/python-net/slide-layout/)/[προτύπου](/slides/el/python-net/slide-master/) (δηλαδή το [φόντο θέματος](/slides/el/python-net/presentation-theme/)).

**Τι συμβαίνει με το φόντο αν αλλάξω αργότερα το θέμα της παρουσίασης;**

Αν μια διαφάνεια έχει το δικό της γέμισμα, αυτό θα παραμείνει αμετάβλητο. Αν το φόντο κληθεί από τη [διάταξη](/slides/el/python-net/slide-layout/)/[πρότυπο](/slides/el/python-net/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [νέο θέμα](/slides/el/python-net/presentation-theme/)).