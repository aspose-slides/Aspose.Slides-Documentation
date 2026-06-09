---
title: Προσθήκη πλαισίων εικόνας σε παρουσιάσεις με Python
linktitle: Πλαίσιο Εικόνας
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
- ραστερική εικόνα
- διανυσματική εικόνα
- περικοπή εικόνας
- περιοχή περικοπής
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
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET. Απλοποιήστε τη ροή εργασίας σας και βελτιώστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Τα πλαίσια εικόνας στο Aspose.Slides for Python σάς επιτρέπουν να τοποθετείτε και να διαχειρίζεστε ραστερικές και διανυσματικές εικόνες ως εγγενή σχήματα διαφάνειας. Μπορείτε να εισάγετε εικόνες από αρχεία ή ροές, να τις τοποθετείτε και να τις αλλάζετε μέγεθος με ακριβείς συντεταγμένες, να εφαρμόζετε περιστροφή, να ορίζετε διαφάνεια και να ελέγχετε τη σειρά z μαζί με άλλα σχήματα. Το API υποστηρίζει επίσης περικοπή, διατήρηση λόγου διαστάσεων, ορισμό περιγραμμάτων και εφέ, καθώς και αντικατάσταση της υποκείμενης εικόνας χωρίς να χρειάζεται ανακατασκευή της διάταξης. Επειδή τα πλαίσια εικόνας λειτουργούν όπως τα κανονικά σχήματα, μπορείτε να προσθέσετε κινήσεις, υπερσυνδέσμους και κείμενο εναλλακτικού περιγραφής, κάνοντας εύκολη τη δημιουργία οπτικά πλούσιων, προσβάσιμων παρουσιάσεων.

## **Δημιουργία Πλαισίων Εικόνας**

Αυτή η ενότητα δείχνει πώς να εισάγετε μια εικόνα σε μια διαφάνεια δημιουργώντας ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) με το Aspose.Slides for Python. Θα μάθετε πώς να φορτώνετε την εικόνα, να την τοποθετείτε ακριβώς στη διαφάνεια και να ελέγχετε το μέγεθος και τη μορφοποίηση της.

1. Δημιουργήστε một instance της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Πάρτε μια διαφάνεια με βάση τον δείκτη της.
3. Δημιουργήστε ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας την εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/) του δείγματος. Η εικόνα αυτή θα χρησιμοποιηθεί για τη γεμίσματος του σχήματος.
4. Καθορίστε το πλάτος και το ύψος του πλαισίου.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) του συγκεκριμένου μεγέθους χρησιμοποιώντας τη μέθοδο [add_picture_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Αποθηκεύστε την παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας:

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation για την αναπαράσταση ενός αρχείου PPTX.
with slides.Presentation() as presentation:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.slides[0]

    # Προσθήκη της εικόνας στην παρουσίαση.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Προσθήκη πλαισίου εικόνας με διαστάσεις την εικόνα.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Αποθήκευση της παρουσίασης ως PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

Τα πλαίσια εικόνας σάς επιτρέπουν να δημιουργείτε γρήγορα διαφάνειες παρουσίασης από εικόνες. Όταν συνδυάζετε τα πλαίσια εικόνας με τις επιλογές αποθήκευσης του Aspose.Slides, μπορείτε να ελέγχετε τις λειτουργίες I/O για μετατροπή εικόνων από τη μία μορφή στην άλλη. Ίσως θέλετε να δείτε τις παρακάτω σελίδες: μετατροπή [image to JPG](https://products.aspose.com/slides/el/python-net/conversion/image-to-jpg/); μετατροπή [JPG to image](https://products.aspose.com/slides/el/python-net/conversion/jpg-to-image/); μετατροπή [JPG to PNG](https://products.aspose.com/slides/el/python-net/conversion/jpg-to-png/); μετατροπή [PNG to JPG](https://products.aspose.com/slides/el/python-net/conversion/png-to-jpg/); μετατροπή [PNG to SVG](https://products.aspose.com/slides/el/python-net/conversion/png-to-svg/); μετατροπή [SVG to PNG](https://products.aspose.com/slides/el/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Δημιουργία Πλαισίων Εικόνας με Σχετική Κλίμακα**

Αυτή η ενότητα δείχνει πώς να τοποθετήσετε μια εικόνα σε σταθερό μέγεθος και, στη συνέχεια, να εφαρμόσετε κλιμάκωση με βάση ποσοστά ανεξάρτητα για το πλάτος και το ύψος της. Επειδή τα ποσοστά μπορεί να διαφέρουν, ο λόγος διαστάσεων μπορεί να αλλάξει. Η κλιμάκωση εκτελείται σε σχέση με τις αρχικές διαστάσεις της εικόνας.

1. Δημιουργήστε một instance της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Πάρτε μια διαφάνεια με βάση τον δείκτη της.
3. Δημιουργήστε ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας την εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/) της παρουσίασης.
4. Προσθέστε ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) στη διαφάνεια.
5. Ορίστε το σχετικό πλάτος και ύψος του πλαισίου εικόνας.
6. Αποθηκεύστε την παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας με σχετική κλιμάκωση:

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation για την αναπαράσταση ενός αρχείου PPTX.
with slides.Presentation() as presentation:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.slides[0]

    # Προσθήκη της εικόνας στη συλλογή εικόνων της παρουσίασης.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Προσθήκη πλαισίου εικόνας στη διαφάνεια.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Ορισμός του σχετικού πλάτους και ύψους κλίμακας.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Αποθήκευση της παρουσίασης.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Εξαγωγή Ράστερ Εικόνων από Πλαίσια Εικόνας**

Μπορείτε να εξάγετε ραστερικές εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) και να τις αποθηκεύσετε σε PNG, JPG και άλλες μορφές. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο «sample.pptx» και να την αποθηκεύσετε σε μορφή PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Εξαγωγή SVG Εικόνων από Πλαίσια Εικόνας**

Όταν μια παρουσίαση περιέχει γραφικά SVG τοποθετημένα μέσα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/), το Aspose.Slides for Python μέσω .NET σάς επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη πιστότητα. Διατρέχοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/), να ελέγξετε εάν το υποκείμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) περιέχει περιεχόμενο SVG και, στη συνέχεια, να αποθηκεύσετε αυτήν την εικόνα στο δίσκο ή σε ροή στη γνήσια μορφή SVG.

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

## **Λήψη Διαφάνειας Εικόνας**

Το Aspose.Slides σάς επιτρέπει να ανακτήσετε το εφέ διαφάνειας που έχει εφαρμοστεί σε μια εικόνα. Ο παρακάτω κώδικας Python παρουσιάζει αυτήν τη λειτουργία:

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
Όλα τα εφέ που εφαρμόζονται σε εικόνες μπορείτε να τα βρείτε στο [aspose.slides.effects](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Μορφοποίηση Πλαισίου Εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο εικόνας. Με αυτές τις επιλογές, μπορείτε να προσαρμόσετε ένα πλαίσιο εικόνας ώστε να πληροί συγκεκριμένες απαιτήσεις.

1. Δημιουργήστε một instance της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Πάρτε μια διαφάνεια με βάση τον δείκτη της.
3. Δημιουργήστε ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) προσθέτοντας την εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/) της παρουσίασης. Η εικόνα αυτή θα χρησιμοποιηθεί για τη γεμίσματος του σχήματος.
4. Καθορίστε το πλάτος και το ύψος του πλαισίου.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) του συγκεκριμένου μεγέθους χρησιμοποιώντας τη μέθοδο [add_picture_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_picture_frame/) της διαφάνειας.
6. Ορίστε το χρώμα γραμμής του πλαισίου εικόνας.
7. Ορίστε το πάχος γραμμής του πλαισίου εικόνας.
8. Περιστρέψτε το πλαίσιο εικόνας παρέχοντας θετική (δεξιόστροφη) ή αρνητική (αριστερόστροφη) τιμή.
9. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python παρουσιάζει τη διαδικασία μορφοποίησης πλαισίου εικόνας:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία της κλάσης Presentation για την αναπαράσταση ενός αρχείου PPTX.
with slides.Presentation() as presentation:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.slides[0]

    # Προσθήκη της εικόνας στη συλλογή εικόνων της παρουσίασης.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Προσθήκη πλαισίου εικόνας με διαστάσεις της εικόνας.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Εφαρμογή μορφοποίησης στο πλαίσιο εικόνας.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Αποθήκευση της παρουσίασης ως PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Η Aspose έχει δημιουργήσει ένα δωρεάν [Collage Maker](https://products.aspose.app/slides/el/collage). Εάν χρειάζεστε να [συγχωνεύσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, ή να [δημιουργήσετε πλέγματα φωτογραφιών](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτήν την υπηρεσία.

{{% /alert %}}

## **Προσθήκη Εικόνων ως Σύνδεσμοι**

Για να διατηρήσετε μικρότερα τα αρχεία παρουσίασης, μπορείτε να προσθέτετε εικόνες ή βίντεο μέσω συνδέσμων αντί να ενσωματώνετε τα αρχεία απευθείας στις παρουσιάσεις. Ο παρακάτω κώδικας Python δείχνει πώς να εισάγετε μια εικόνα και ένα βίντεο σε ένα σύμβολο κράτησης θέσης:

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

## **Περικοπή Εικόνων**

Σε αυτήν την ενότητα, θα μάθετε πώς να περικόπτετε την ορατή περιοχή μιας εικόνας μέσα σε ένα πλαίσιο εικόνας χωρίς να αλλάζετε το αρχικό αρχείο. Θα μάθετε επίσης τη βασική μέθοδο για την εφαρμογή περιθωρίων περικοπής ώστε να δημιουργήσετε μια καθαρή, εστιασμένη σύνθεση απευθείας στη διαφάνεια.

Ο παρακάτω κώδικας Python δείχνει πώς να περικόψετε μια εικόνα σε μια διαφάνεια:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθήκη της εικόνας στη συλλογή εικόνων της παρουσίασης.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Προσθήκη πλαισίου εικόνας στη διαφάνεια.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Περικοπή της εικόνας (τιμές ποσοστών).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Αποθήκευση του αποτελέσματος.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαγραφή Περιοχών Περικοπής Εικόνων**

Εάν θέλετε να διαγράψετε τις περιοχές που έχουν περικοπεί σε μια εικόνα μέσα σε ένα πλαίσιο, χρησιμοποιήστε τη μέθοδο [delete_picture_cropped_areas](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα ή την αρχική εικόνα εάν δεν απαιτείται περικοπή.

Ο παρακάτω κώδικας Python δείχνει τη λειτουργία:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Λήψη του PictureFrame από την πρώτη διαφάνεια.
    picture_frame = slides.shape[0]

    # Λήψη του PictureFrame από την πρώτη διαφάνεια.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Αποθήκευση του αποτελέσματος.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Η μέθοδος [delete_picture_cropped_areas](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Εάν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/), αυτό μπορεί να μειώσει το μέγεθος της παρουσίασης· διαφορετικά, ο αριθμός των εικόνων στην τελική παρουσίαση μπορεί να αυξηθεί.

Κατά την περικοπή, αυτή η μέθοδος μετατρέπει αρχεία WMF/EMF σε ράστερ εικόνα PNG.

{{% /alert %}}

## **Συμπίεση Εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [PictureFillFormat.compress_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/compress_image/). Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της βάσει του μεγέθους του σχήματος και της καθορισμένης ανάλυσης, με την επιλογή διαγραφής περιοχών περικοπής.

Προσαρμόζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format → Compress Pictures → Resolution** του PowerPoint.

Τα παρακάτω παραδείγματα Python δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση ορίζοντας στοχοθέτηση ανάλυσης και, προαιρετικά, αφαιρώντας περιοχές περικοπής:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Συμπίεση της εικόνας με στοχευμένη ανάλυση 150 DPI (ανάλυση ιστού) και αφαίρεση περιοχών περικοπής.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Έλεγχος του αποτελέσματος της συμπίεσης.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Ή χρησιμοποιώντας απευθείας μια προσαρμοσμένη τιμή DPI:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Συμπίεση της εικόνας σε 150 DPI (ανάλυση ιστού), αφαιρώντας περιοχές περικοπής.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση βάσει του μεγέθους του σχήματος και του παρεχόμενου DPI. Οι περιοχές που έχουν περικοπεί μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.
Εάν η εικόνα είναι μετααρχείο (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επίσης, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς ανάλογα με την ανάλυση, όπως γίνεται στο PowerPoint.

{{% /alert %}}

## **Κλείδωμα Αναλογίας Διαστάσεων**

Εάν θέλετε ένα σχήμα που περιέχει εικόνα να διατηρεί την αναλογία διαστάσεων του μετά την αλλαγή των διαστάσεων της εικόνας, ορίστε την ιδιότητα [aspect_ratio_locked](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) σε `True`.

Ο παρακάτω κώδικας Python δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων ενός σχήματος:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Κλείδωμα της αναλογίας διαστάσεων κατά την αλλαγή μεγέθους.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο την αναλογία διαστάσεων του σχήματος, όχι την αναλογία διαστάσεων της εικόνας μέσα σε αυτό.

{{% /alert %}}

## **Χρήση Ιδιοτήτων Stretch Offset**

Με τις ιδιότητες `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` και `stretch_offset_bottom` της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/), μπορείτε να ορίσετε ένα ορθογώνιο γεμίσματος.

Όταν ορίζεται τράνσα για μια εικόνα, το αρχικό ορθογώνιο κλιμακώνεται ώστε να ταιριάζει με το ορθογώνιο γεμίσματος. Κάθε άκρο του ορθογωνίου γεμίσματος ορίζεται ως ποσοστιαία απόσταση από το αντίστοιχο άκρο του περιβλήματος του σχήματος. Ένα θετικό ποσοστό υποδεικνύει εσωτερική απόσταση, ενώ ένα αρνητικό ποσοστό υποδεικνύει εξωτερική απόσταση.

1. Δημιουργήστε một instance της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Πάρτε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).
4. Ορίστε τον τύπο γεμίσματος του σχήματος.
5. Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος.
6. Φορτώστε μια εικόνα.
7. Αναθέστε την εικόνα για να γεμίσει το σχήμα.
8. Καθορίστε τις απολιτικές τιμές της εικόνας από τα αντίστοιχα άκρα του περιβλήματος του σχήματος.
9. Αποθηκεύστε την παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας Python δείχνει πώς να χρησιμοποιήσετε τις ιδιότητες Stretch Offset:

```py
import aspose.slides as slides

# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation() as presentation:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.slides[0]

    # Προσθήκη παραλληλόγραμμου AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Ορισμός του τύπου γεμίσματος του σχήματος.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ορισμός της λειτουργίας γεμίσματος εικόνας του σχήματος.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Φόρτωση της εικόνας και προσθήκη της στην παρουσίαση.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Ανάθεση της εικόνας για γέμισμα του σχήματος.
    shape.fill_format.picture_fill_format.picture.image = image

    # Καθορισμός των αποσπασμάτων εικόνας από τις αντίστοιχες άκρες του πλαισίου περιγράμματος του σχήματος.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Αποθήκευση του αρχείου PPTX στο δίσκο.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που σας επιτρέπουν να δημιουργείτε γρήγορα παρουσιάσεις από εικόνες.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να μάθω ποιες μορφές εικόνας υποστηρίζονται για το PictureFrame;**

Το Aspose.Slides υποστηρίζει τόσο ραστερικές εικόνες (PNG, JPEG, BMP, GIF κ.λπ.) όσο και διανυσματικές εικόνες (π.χ., SVG) μέσω του αντικειμένου εικόνας που αποδίδεται σε ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/). Η λίστα των υποστηριζόμενων μορφών γενικά συμπίπτει με τις δυνατότητες του κινητήρα μετατροπής διαφάνειας και εικόνας.

**Πώς η προσθήκη δεκάδων μεγάλων εικόνων επηρεάζει το μέγεθος και την απόδοση του PPTX;**

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση των εικόνων βοηθά στη μείωση του μεγέθους της παρουσίασης, αλλά απαιτεί την προσβασιμότητα των εξωτερικών αρχείων. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων μέσω συνδέσμου για μείωση του μεγέθους του αρχείου.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας ώστε να μην μετακινηθεί ή να αλλάξει μέγεθος κατά λάθος;**

Χρησιμοποιήστε [shape locks](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/picture_frame_lock/) για ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) (π.χ., απενεργοποίηση μετακίνησης ή αλλαγής μεγέθους). Ο μηχανισμός κλειδώματος περιγράφεται για σχήματα σε ένα ξεχωριστό άρθρο προστασίας [/slides/el/python-net/applying-protection-to-presentation/] και υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένων των [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/).

**Διατηρείται η πιστότητα του διανυσματικού SVG όταν εξάγεται μια παρουσίαση σε PDF/εικόνες;**

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Όταν [εξάγετε σε PDF](/slides/el/python-net/convert-powerpoint-to-pdf/) ή [σε ραστερικές μορφές](/slides/el/python-net/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να γίνει ραστερικό ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.