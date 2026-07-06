---
title: Πρόσθεση πλαισίων εικόνας σε παρουσιάσεις με Python
linktitle: Πλαίσιο εικόνας
type: docs
weight: 10
url: /el/python-net/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- προσθήκη εικόνας
- δημιουργία εικόνας
- εξαγωγή εικόνας
- ραστερ εικόνας
- διανυσματική εικόνα
- περικοπή εικόνας
- περικομμένη περιοχή
- ιδιότητα StretchOff
- μορφοποίηση πλαισίου εικόνας
- ιδιότητες πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- διαφάνεια εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides for Python μέσω .NET. Βελτιώστε τη ροή εργασίας σας και ενισχύστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Τα πλαίσια εικόνας στο Aspose.Slides for Python σάς επιτρέπουν να προσθέτετε και να διαχειρίζεστε ραστερ και διάνυσμα εικόνες ως ενσωματωμένα σχήματα διαφάνειας. Μπορείτε να εισάγετε εικόνες από αρχεία ή ροές, να τις τοποθετήσετε και να αλλάξετε το μέγεθός τους με ακριβείς συντεταγμένες, να εφαρμόσετε περιστροφή, να ορίσετε διαφάνεια και να ελέγξετε τη σειρά z μαζί με άλλα σχήματα. Το API υποστηρίζει επίσης περικοπή, διατήρηση αναλογιών, ορισμό περιθωρίων και εφέ, και αντικατάσταση της υποκείμενης εικόνας χωρίς να ξαναχτίσετε τη διάταξη. Επειδή τα πλαίσια εικόνας συμπεριφέρονται όπως τα κανονικά σχήματα, μπορείτε να προσθέτετε κινούμενα σχέδια, υπερσυνδέσμους και εναλλακτικό κείμενο, καθιστώντας εύκολο το δημιουργία οπτικά πλούσιων, προσβάσιμων παρουσιάσεων.

## **Δημιουργία πλαισίων εικόνας**

Αυτή η ενότητα δείχνει πώς να εισάγετε μια εικόνα σε μια διαφάνεια δημιουργώντας ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) με το Aspose.Slides for Python. Θα μάθετε πώς να φορτώνετε την εικόνα, να τη τοποθετείτε ακριβώς στη διαφάνεια και να ελέγχετε το μέγεθος και τη μορφοποίηση της.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Λάβετε μια διαφάνεια με βάση το ευρετήριο της.
3. Δημιουργήστε ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας την εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/) της παρουσίασης. Αυτή η εικόνα θα χρησιμοποιηθεί για γέμισμα του σχήματος.
4. Ορίστε το πλάτος και το ύψος του πλαισίου.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) με αυτό το μέγεθος χρησιμοποιώντας τη μέθοδο [add_picture_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας:

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για την αναπαράσταση ενός αρχείου PPTX.
with slides.Presentation() as presentation:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε την εικόνα στην παρουσίαση.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Προσθέστε ένα πλαίσιο εικόνας με μέγεθος ίσο με της εικόνας.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Αποθηκεύστε την παρουσίαση ως PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Τα πλαίσια εικόνας σάς επιτρέπουν να δημιουργείτε γρήγορα διαφάνειες παρουσίασης από εικόνες. Όταν συνδυάζετε τα πλαίσια εικόνας με τις επιλογές αποθήκευσης του Aspose.Slides, μπορείτε να ελέγχετε τις λειτουργίες I/O για μετατροπή εικόνων από τη μια μορφή στην άλλη. Μπορείτε να δείτε αυτές τις σελίδες: μετατροπή [image to JPG](https://products.aspose.com/slides/el/python-net/conversion/image-to-jpg/); μετατροπή [JPG to image](https://products.aspose.com/slides/el/python-net/conversion/jpg-to-image/); μετατροπή [JPG to PNG](https://products.aspose.com/slides/el/python-net/conversion/jpg-to-png/); μετατροπή [PNG to JPG](https://products.aspose.com/slides/el/python-net/conversion/png-to-jpg/); μετατροπή [PNG to SVG](https://products.aspose.com/slides/el/python-net/conversion/png-to-svg/); μετατροπή [SVG to PNG](https://products.aspose.com/slides/el/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Δημιουργία πλαισίων εικόνας με σχετική κλίμακα**

Αυτή η ενότητα δείχνει πώς να τοποθετήσετε μια εικόνα σε σταθερό μέγεθος και στη συνέχεια να εφαρμόσετε κλιμάκωση με ποσοστό ανεξάρτητα στο πλάτος και το ύψος της. Επειδή τα ποσοστά μπορεί να διαφέρουν, η αναλογία διαστάσεων μπορεί να αλλάξει. Η κλιμάκωση γίνεται σε σχέση με τις αρχικές διαστάσεις της εικόνας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Λάβετε μια διαφάνεια με βάση το ευρετήριο της.
3. Δημιουργήστε ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας την εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/) της παρουσίασης.
4. Προσθέστε ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) στη διαφάνεια.
5. Ορίστε το σχετικό πλάτος και ύψος του πλαισίου εικόνας.
6. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας με σχετική κλιμάκωση:

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για την αναπαράσταση ενός αρχείου PPTX.
with slides.Presentation() as presentation:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Προσθέστε ένα πλαίσιο εικόνας στη διαφάνεια.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Ορίστε το σχετικό πλάτος και ύψος κλιμάκωσης.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Αποθηκεύστε την παρουσίαση.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Εξαγωγή ραστών εικόνων από πλαίσια εικόνας**

Μπορείτε να εξάγετε ραστές εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) και να τις αποθηκεύσετε σε PNG, JPG και άλλες μορφές. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο «sample.pptx» και να την αποθηκεύσετε σε μορφή PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Εξαγωγή SVG εικόνων από πλαίσια εικόνας**

Όταν μια παρουσίαση περιέχει SVG γραφικά ενσωματωμένα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/), το Aspose.Slides for Python via .NET σας επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη πιστότητα. Διασχίζοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/), να ελέγξετε αν το υποκείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) περιέχει περιεχόμενο SVG και μετά να αποθηκεύσετε αυτή την εικόνα στο δίσκο ή σε ροή στην γνήσια μορφή SVG.

Ο παρακάτω κώδικας δείχνει πώς να εξάγετε μια SVG εικόνα από ένα πλαίσιο εικόνας:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Λήψη διαφάνειας εικόνας**

Το Aspose.Slides σάς επιτρέπει να ανακτήσετε το εφέ διαφάνειας που έχει εφαρμοστεί σε μια εικόνα. Αυτός ο κώδικας Python δείχνει τη λειτουργία:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Όλα τα εφέ που εφαρμόζονται σε εικόνες μπορούν να βρεθούν στο [aspose.slides.effects](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Λήψη φωτεινότητας και αντίθεσης εικόνας**

Το Aspose.Slides σάς επιτρέπει να ανακτήσετε το εφέ φωτεινότητας και αντίθεσης που έχει εφαρμοστεί σε μια εικόνα. Η κλάση [Luminance](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/luminance/) αντιπροσωπεύει αυτό το εφέ μετασχηματισμού εικόνας.

Αυτός ο κώδικας Python δείχνει πώς να λάβετε τις ρυθμίσεις φωτεινότητας και αντίθεσης από ένα πλαίσιο εικόνας:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Μορφοποίηση πλαισίου εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο εικόνας. Με αυτές τις επιλογές, μπορείτε να προσαρμόσετε το πλαίσιο ώστε να ανταποκρίνεται σε συγκεκριμένες απαιτήσεις.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Λάβετε μια διαφάνεια με βάση το ευρετήριο της.
3. Δημιουργήστε ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας την εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/) της παρουσίασης. Αυτή η εικόνα θα χρησιμοποιηθεί για γέμισμα του σχήματος.
4. Ορίστε το πλάτος και το ύψος του πλαισίου.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) με αυτό το μέγεθος χρησιμοποιώντας τη μέθοδο [add_picture_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_picture_frame/) του slide.
6. Ορίστε το χρώμα γραμμής του πλαισίου εικόνας.
7. Ορίστε το πάχος γραμμής του πλαισίου εικόνας.
8. Περιστρέψτε το πλαίσιο εικόνας παρέχοντας θετική (δεξιόστροφα) ή αρνητική (αριστερόστροφα) τιμή.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει τη διαδικασία μορφοποίησης πλαισίου εικόνας:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για την αναπαράσταση ενός αρχείου PPTX.
with slides.Presentation() as presentation:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Προσθέστε ένα πλαίσιο εικόνας με μέγεθος ίσο με της εικόνας.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Εφαρμόστε μορφοποίηση στο πλαίσιο εικόνας.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Αποθηκεύστε την παρουσίαση ως PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Η Aspose έχει αναπτύξει ένα δωρεάν [Collage Maker](https://products.aspose.app/slides/el/collage). Αν χρειάζεστε να [συγχωνεύσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, ή να [δημιουργήσετε πλέγματα φωτογραφιών](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτήν την υπηρεσία.
{{% /alert %}}

## **Προσθήκη εικόνων ως συνδέσμους**

Για να διατηρήσετε τα αρχεία παρουσίασης μικρά, μπορείτε να προσθέσετε εικόνες ή βίντεο μέσω συνδέσμων αντί να ενσωματώνετε τα αρχεία απευθείας στις παρουσιάσεις. Ο παρακάτω κώδικας Python δείχνει πώς να εισάγετε μια εικόνα και ένα βίντεο σε έναν σύμβολο κράτησης θέσης:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Περικοπή εικόνων**

Σε αυτήν την ενότητα, θα μάθετε πώς να περικόψετε την ορατή περιοχή μιας εικόνας μέσα σε πλαίσιο εικόνας χωρίς να αλλάξετε το αρχείο προέλευσης. Θα μάθετε επίσης τη βασική μέθοδο για την εφαρμογή περιθωρίων περικοπής ώστε να δημιουργήσετε μια καθαρή, εστιασμένη σύνθεση απευθείας στη διαφάνεια.

Ο παρακάτω κώδικας Python δείχνει πώς να περικόψετε μια εικόνα σε μια διαφάνεια:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Προσθέστε ένα πλαίσιο εικόνας στη διαφάνεια.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Περικόψτε την εικόνα (τιμές σε ποσοστό).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Αποθηκεύστε το αποτέλεσμα.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαγραφή περικομμένων περιοχών εικόνων**

Αν θέλετε να διαγράψετε τις περικομμένες περιοχές μιας εικόνας σε ένα πλαίσιο, χρησιμοποιήστε τη μέθοδο [delete_picture_cropped_areas](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα, ή την αρχική εικόνα εάν δεν απαιτείται περικοπή.

Ο παρακάτω κώδικας Python δείχνει τη λειτουργία:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Λάβετε το PictureFrame από την πρώτη διαφάνεια.
    picture_frame = slides.shape[0]

    # Λάβετε το PictureFrame από την πρώτη διαφάνεια.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Αποθηκεύστε το αποτέλεσμα.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Η μέθοδος [delete_picture_cropped_areas](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Αν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/), αυτό μπορεί να μειώσει το μέγεθος της παρουσίασης· αλλιώς, ο αριθμός των εικόνων στην τελική παρουσίαση μπορεί να αυξηθεί.

Κατά τη διάρκεια της περικοπής, αυτή η μέθοδος μετατρέπει αρχεία WMF/EMF σε ραστερ εικόνα PNG.
{{% /alert %}}

## **Συμπίεση εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [PictureFillFormat.compress_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/compress_image/). Η μέθοδος αυτή μειώνει το μέγεθος μιας εικόνας με βάση το μέγεθος του σχήματος και την καθορισμένη ανάλυση, με δυνατότητα διαγραφής των περικομμένων περιοχών.

Ρυθμίζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format → Compress Pictures → Resolution** του PowerPoint.

Τα παρακάτω παραδείγματα Python δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση ορίζοντας στοχευμένη ανάλυση και προαιρετικά αφαιρώντας τις περικομμένες περιοχές:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Συμπιέστε την εικόνα με στοχευμένη ανάλυση 150 DPI (ανάλυση Web) και αφαιρέστε τις περικομμένες περιοχές.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Ελέγξτε το αποτέλεσμα της συμπίεσης.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Ή χρησιμοποιώντας άμεσα μια προσαρμοσμένη τιμή DPI:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Συμπιέστε την εικόνα σε 150 DPI (ανάλυση ιστού), αφαιρώντας τις περικομμένες περιοχές.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση με βάση το μέγεθος του σχήματος και το παρεχόμενο DPI. Οι περικομμένες περιοχές μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.
Αν η εικόνα είναι μετααρχείο (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επίσης, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς ανάλογα με την ανάλυση, όπως συμβαίνει στο PowerPoint με υψηλής ανάλυσης JPEG.
{{% /alert %}}

## **Κλείδωμα αναλογίας διαστάσεων**

Αν θέλετε ένα σχήμα που περιέχει εικόνα να διατηρεί την αναλογία του μετά την αλλαγή των διαστάσεων της εικόνας, ορίστε την ιδιότητα [aspect_ratio_locked](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) σε `True`.

Ο παρακάτω κώδικας Python δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων ενός σχήματος:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Κλειδώστε την αναλογία διαστάσεων κατά την αλλαγή μεγέθους.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο την αναλογία του σχήματος, όχι την αναλογία της εικόνας που περιέχει.
{{% /alert %}}

## **Χρήση ιδιοτήτων Stretch Offset**

Χρησιμοποιώντας τις ιδιότητες `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` και `stretch_offset_bottom` της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/), μπορείτε να ορίσετε ένα ορθογώνιο γεμίσματος.

Όταν καθορίζεται τράνσος για μια εικόνα, το πηγαίο ορθογώνιο κλιμακώνεται ώστε να ταιριάζει στο ορθογώνιο γεμίσματος. Κάθε άκρη του ορθογωνίου γεμίσματος ορίζεται με ποσοστιαία μετατόπιση από την αντίστοιχη άκρη του περιοριστικού πλαισίου του σχήματος. Θετικό ποσοστό δηλώνει εσωτερική μετατόπιση, αρνητικό ποσοστό εξωτερική.
 
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε διαφάνεια με βάση το ευρετήριο της.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).
4. Ορίστε τον τύπο γεμίσματος του σχήματος.
5. Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος.
6. Φορτώστε μια εικόνα.
7. Εκχωρήστε την εικόνα για γέμισμα του σχήματος.
8. Ορίστε τις μετατοπίσεις εικόνας από τις αντίστοιχες άκρες του περιοριστικού πλαισίου του σχήματος.
9. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να χρησιμοποιήσετε τις ιδιότητες Stretch Offset:

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα AutoShape τύπου Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Ορίστε τον τύπο γεμίσματος του σχήματος.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Φορτώστε την εικόνα και προσθέστε τη στην παρουσίαση.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Αναθέστε την εικόνα για γέμισμα του σχήματος.
    shape.fill_format.picture_fill_format.picture.image = image

    # Ορίστε τις μετατοπίσεις της εικόνας από τις αντίστοιχες άκρες του περιοριστικού πλαισίου του σχήματος.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που σας επιτρέπουν να δημιουργήσετε γρήγορα παρουσιάσεις από εικόνες.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Πώς μπορώ να μάθω ποιες μορφές εικόνας υποστηρίζονται για το PictureFrame;**

Το Aspose.Slides υποστηρίζει τόσο ραστές εικόνες (PNG, JPEG, BMP, GIF κ.λπ.) όσο και διανυσματικές εικόνες (π.χ., SVG) μέσω του αντικειμένου εικόνας που αντιστοιχίζεται σε ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/). Η λίστα υποστηριζόμενων μορφών γενικά επικαλύπτεται με τις δυνατότητες του μηχανήματος μετατροπής διαφάνειας και εικόνας.

**Πώς θα επηρεάσει η προσθήκη δεκάδων μεγάλων εικόνων το μέγεθος και την απόδοση του PPTX;**

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθά στη μείωση του μεγέθους της παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να παραμείνουν προσβάσιμα. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων μέσω συνδέσμου για μείωση του μεγέθους του αρχείου.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας από ακούσιες μετακινήσεις/αλλαγές μεγέθους;**

Χρησιμοποιήστε τα [shape locks](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/picture_frame_lock/) για ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) (π.χ., απενεργοποίηση μετακίνησης ή αλλαγής μεγέθους). Ο μηχανισμός κλειδώματος περιγράφεται για σχήματα σε ξεχωριστό άρθρο [protection article](/slides/el/python-net/applying-protection-to-presentation/) και υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένων των [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/).

**Διατηρείται η πιστότητα του διανυσματικού SVG κατά την εξαγωγή μιας παρουσίασης σε PDF/εικόνες;**

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) ως το αρχικό διανύσματος. Όταν [εξάγετε σε PDF](/slides/el/python-net/convert-powerpoint-to-pdf/) ή σε [ραντεσκοποιημένες μορφές](/slides/el/python-net/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να ραστεροποιηθεί ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.