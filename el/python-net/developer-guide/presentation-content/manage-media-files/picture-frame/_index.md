---
title: Διαχείριση Πλαισίων Εικόνας σε Παρουσιάσεις με Python
linktitle: Πλαίσιο Εικόνας
type: docs
weight: 10
url: /el/python-net/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- ενσωματωμένη εικόνα
- συνδεδεμένη εικόνα
- εξαγωγή εικόνας
- εικόνα raster
- εικόνα SVG
- περικοπή εικόνας
- διαγραφή περικομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργία, μορφοποίηση, σύνδεση, περικοπή, εξαγωγή και συμπίεση πλαισίων εικόνας σε παρουσιάσεις με Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω του [ImageCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/), ενώ ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, το περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διάσπαση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, διατηρήστε το επιστρεφόμενο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας όταν δημιουργείτε πλαίσια εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν raster εικόνες όπως PNG ή JPEG και vector εικόνες SVG. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα bytes της εικόνας στην παρουσίαση. Η επιλογή επηρεάζει τη φορητότητα, το μέγεθος αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, οπότε είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_picture_frame/). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, έτσι η παρουσίαση παραμένει αυτόνομη όταν μεταφέρεται σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια εικόνα JPEG, δημιουργεί ένα πλαίσιο στις φυσικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόπτουμε ή συμπιέζουμε μια εικόνα αργότερα.

## **Χρήση σχετικής κλίμακας**

[PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) εκθέτει τις ιδιότητες [relative_scale_width](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/relative_scale_width/) και [relative_scale_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/relative_scale_height/) για το πλαίσιο. Μια τιμή του `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας πρέπει να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τα τελικά διαστάσεων χειροκίνητα.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ή συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και είναι επομένως η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική τοποθεσία μέσω της διαδρομής σύνδεσης [Picture](https://reference.aspose.com/slides/el/python-net/aspose.slides/picture/) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα δεδομένων εικόνας που αποθηκεύεται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα μπορεί να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να σταλούν μέσω email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το κατευθύνει σε ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν συγχωνεύεται σε αυτό το παράδειγμα.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Χρησιμοποιήστε συνδέσμους όταν η διαχείριση εξωτερικών αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως υποκατάσταση της συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτόνομη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξάγετε μια εικόνα από μια υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πραγματικά ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν bytes εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή raster εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί άμεσα το [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/). Το παρακάτω παράδειγμα εντοπίζει την πρώτη ενσωματωμένη raster εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Η αποθήκευση μέσω του [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που αποθηκεύονται στην παρουσίαση αντί για ένα μετατρεπόμενο raster αρχείο, χρησιμοποιήστε την ιδιότητα [PPImage.binary_data](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/binary_data/) αντί αυτής.

### **Εξαγωγή SVG εικόνας**

Για μια SVG εικόνα, το [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) εκθέτει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/svgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG απευθείας αντί να ραστερινίσετε την εικόνα πρώτα.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την vector πηγή μέσα στην παρουσίαση. Οι εξαγωγές raster όπως PNG ή JPEG υποχρεωτικά αποδίδουν αυτό το vector περιεχόμενο σε pixel. Η εξαγωγή διαφανειών σε PDF ή SVG είναι επίσης μια διαδικασία απόδοσης, επομένως τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται ακριβείς αντιγραφές byte‑by‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε το ενσωματωμένο [SvgImage.svg_data](https://reference.aspose.com/slides/el/python-net/aspose.slides/svgimage/svg_data/) όταν απαιτείται ο ίδιος ο vector πόρος.

## **Περικοπή εικόνας**

Η περικοπή αλλάζει ποιο τμήμα μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [PictureFillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή δεν διαγράφει αρχικά τα κρυμμένα pixel από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει με ασφάλεια ένα πλαίσιο εικόνας και εφαρμόζει τιμές περικοπής:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Επειδή τα κρυμμένα δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να αλλάξει αργότερα χωρίς απώλεια των αρχικών pixel. Εάν το μέγεθος αρχείου έχει μεγαλύτερη σημασία από την αναστρέψιμη επεξεργασία, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων περικομμένης εικόνας**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος περιοριστικού τετραγώνου και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά είναι μια καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρεμένα pixel δεν είναι πλέον διαθέσιμα για μεταγενέστερη ενέργεια "αποπερικοπής".

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Η μέθοδος μπορεί να προσθέσει έναν νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, τα πλαίσια αυτά εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο τους, έτσι η διαγραφή περικομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστερινίζει το αποτέλεσμα σε PNG.

## **Συμπίεση raster εικόνων**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/compress_image/) μειώνει την ανάλυση raster εικόνας σε σχέση με το μέγεθος στο οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `True` όταν η εικόνα έχει αλλαγή μεγέθους ή περικοπεί και `False` όταν δεν χρειάστηκε αλλαγή.

Χρησιμοποιήστε μια προ‑καθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/picturescompression/) όταν μια τυπική στόχευση ανάλυσης είναι επαρκής:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Μπορείτε να περάσετε μια προσαρμοσμένη θετική τιμή DPI αντί για μια τιμή enum όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση απευθύνεται σε raster εικόνες. Το περιεχόμενο SVG και metafile δεν μειώνεται από αυτή τη διαδικασία raster συμπίεσης. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και η διαγραφή των περικομμένων περιοχών δεν μπορούν να ανακτηθούν από τη βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης με βάση το μεγαλύτερο μέγεθος στο οποίο η εικόνα θα προβάλλεται ή θα εξαχθεί, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Έλεγχος εφέ εικόνας**

Τα εφέ εικόνας αποθηκεύονται στην εικόνα που χρησιμοποιείται από το πλαίσιο. Η συλλογή μετασχηματισμών εικόνας μπορεί να περιέχει εφέ όπως σταθερή αλφα διαμόρφωση για διαφάνεια και φωτεινότητα (luminance) για φωτεινότητα και αντίθεση. Το παρακάτω παράδειγμα διαβάζει με ασφάλεια και τα δύο είδη εφέ από το πρώτο πλαίσιο εικόνας σε μια διαφάνεια:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/alphamodulatefixed/) και [Luminance](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/luminance/) αλλάζουν τον τρόπο απόδοσης της εικόνας στο πλαίσιο· δεν επανεγγράφουν τα αρχικά ενσωματωμένα bytes εικόνας.

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις του [PictureFrameLock](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, η ιδιότητα [aspect_ratio_locked](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) διατηρεί τις αναλογίες του σχήματος ενώ αυτό αλλάζει μέγεθος.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να αλλάξει μόνιμα στην ίδια αναλογία διαστάσεων.

## **Ρύθμιση τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι stretch, οι τιμές stretch‑offset στο [PictureFillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/) ορίζουν το γεμιστικό ορθογώνιο σχετικά με το όριο του πλαισίου εικόνας. Τα θετικά ποσοστά δημιουργούν εσωτερική απόσταση από την άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν εξωτερική απόσταση.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι stretch offsets αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γεμάτο εικόνας.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Χρησιμοποιήστε stretch offsets για τοποθέτηση γεμίσματος. Χρησιμοποιήστε τις ιδιότητες περικοπής όταν ο στόχος είναι η απόκρυψη των άκρων της πηγαίας εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και εκτιμήσεις εξαγωγής**

Οι κύριες ανταλλαγές είναι πιο εύκολα διαχειρίσιμες όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση από διακομιστή, αλλά οι μεγάλες raster εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από τα εξωτερικά αρχεία που πρέπει να παραμείνουν διαθέσιμα στις αποθηκευμένες διαδρομές ή τοποθεσίες.
- **Περικοπή** είναι αρχικά μη καταστροφική. Τα κρυφά pixel παραμένουν ενσωματωμένα μέχρι οι περικομμένες περιοχές να διαγραφούν ρητά ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει το μέγεθος του αρχείου σημαντικά για υπερμεγέθεις raster εικόνες, αλλά θυσιάζει την ανάλυση πηγής. Πρέπει να εφαρμοστεί μετά τον καθορισμό του επιθυμητού μεγέθους στο slide.
- **SVG εικόνες** πρέπει να παραμείνουν ως SVG όταν η διατήρηση vector είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο τον vector πόρο. Οι raster εξαγωγές διαφανειών πάντα μετατρέπουν το αποδοθέν slide σε pixel.
- **Επαναλαμβανόμενες εικόνες** πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) όταν είναι δυνατόν αντί να φορτώνουν ξανά το ίδιο αρχείο στη ροή παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν πραγματοποιείται επιλεκτικά: διατηρήστε λογότυπα και διαγράμματα ως vector περιεχόμενο, συμπιέστε φωτογραφίες ανάλογα με το πραγματικό τους μέγεθος προβολής, αφαιρέστε τα περικομμένα pixel μόνο όταν δεν απαιτείται μεταγενέστερη επεξεργασία και αποφύγετε εξωτερικές συνδέσεις εκτός εάν η διαχείριση εξαρτήσεων είναι μέρος του σχεδίου ανάπτυξης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου εικόνας και πόρου εικόνας;**

Ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) αντιπροσωπεύει έναν πόρο εικόνας που σχετίζεται με την παρουσίαση. Ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) είναι ένα σχήμα σε μια διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώνω ή να συνδέω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδοθεί χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η διατήρηση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές τοποθεσίες μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν τμήματα της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) ή τη συμπίεση εικόνας με αφαίρεση περικομμένων περιοχών όταν αυτά τα pixel μπορούν να απορριφθούν μόνιμα.

**Μπορώ να επαναφέρω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη raster ανάλυση, και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγαία εικόνα εκτός της παρουσίασης εάν απαιτείται μελλοντική επεξεργασία υψηλής ανάλυσης.

**Πώς πρέπει να διαχειρίζομαι τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η ακεραιότητα vector έχει σημασία. Το ενσωματωμένο [SvgImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/svgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε raster μορφή όπως PNG ή JPEG ραστερινίζει το SVG ως μέρος της εικόνας της διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπου όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη συγκεκριμένα για picture‑frame. Η χρήση του `isinstance(shape, slides.PictureFrame)` αποτρέπει μη έγκυρες μετατροπές και επιτρέπει στον κώδικα να χειριστεί διαφάνειες που δεν περιέχουν picture frames.