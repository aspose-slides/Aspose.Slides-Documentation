---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις με Python
linktitle: Πλαίσιο εικόνας
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
- ραστερ εικόνα
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
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, περικόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: μια [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) διαχειρίζεται ενσωματωμένους πόρους εικόνας μέσω της [ImageCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/imagecollection/), ενώ ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, το κόψιμο, τα εφέ εικόνας και άλλες ρυθμίσεις σε επίπεδο πλαισίου.

Αυτός ο διαχωρισμός είναι χρήσιμος όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, διατηρήστε την επιστρεφόμενη [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας κατά τη δημιουργία πλαισίων εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνες όπως PNG ή JPEG και διανυσματικές SVG εικόνες. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί για αποθήκευση των δυαδικών δεδομένων της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος του αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, γι' αυτό είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν την εφαρμογή μορφοποίησης ή βελτιστοποίησης.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/shapecollection/add_picture_frame/). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, οπότε η παρουσίαση παραμένει αυτόνομη όταν μεταφερθεί σε άλλον υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια JPEG εικόνα, δημιουργεί πλαίσιο στις φυσικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

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

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις σε εικονοστοιχεία που είναι αποθηκευμένες στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικοθεί ή συμπιεστεί μια εικόνα αργότερα.

## **Χρήση σχετικού κλίμακας**

[PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) εκθέτει τα [relative_scale_width](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/relative_scale_width/) και [relative_scale_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/relative_scale_height/) για το πλαίσιο. Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί για τον υπολογισμό τελικών διαστάσεων χειροκίνητα.

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

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν κάνει επαναδειγματοληψία ή συμπίεση της ενσωματωμένης εικόνας.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και είναι επομένως η ασφαλέστερη επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική διαδρομή μέσω της διαδρομής συνδέσμου [Picture](https://reference.aspose.com/slides/el/python-net/aspose.slides/picture/) αντί για ενσωμάτωση των δεδομένων εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά εισάγουν μια εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα μπορεί να μη εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να αποστέλλονται μέσω email, να αρχειοθετούνται ή να αποδίδονται σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το προσαρμόζει σε τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμιγνύεται σε αυτό το παράδειγμα.

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

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως υποκατάστατο της συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτοδύναμη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξαγάγετε μια εικόνα από υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πραγματικά ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν δυαδικά δεδομένα εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ραστερ εικόνας**

Το σύγχρονο API εικόνων χρησιμοποιεί άμεσα το [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/). Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

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

Η αποθήκευση μέσω [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα δυαδικά δεδομένα που είναι αποθηκευμένα στην παρουσίαση αντί για ένα μετατρεπόμενο ραστερ αρχείο, χρησιμοποιήστε την ιδιότητα [PPImage.binary_data](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/binary_data/) αντί.

### **Εξαγωγή SVG εικόνας**

Για μια SVG εικόνα, το [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) εκθέτει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/svgimage/). Αυτό επιτρέπει την άμεση λήψη των δεδομένων SVG αντί για ραστεροποίηση της εικόνας πρώτα.

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

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές σε ραστερ μορφή όπως PNG ή JPEG απαιτούν απαραίτητα την απόδοση του διανύσματος σε εικονοστοιχεία. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης λειτουργία απόδοσης, επομένως τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφα byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε το ενσωματωμένο [SvgImage.svg_data](https://reference.aspose.com/slides/el/python-net/aspose.slides/svgimage/svg_data/) όταν απαιτείται ο ίδιος ο διανυσματικός πόρος.

## **Περικοπή εικόνας**

Η περικοπή αλλάζει ποιο τμήμα μιας εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [PictureFillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/) είναι ποσοστά των διαστάσεων της πηγής εικόνας. Η περικοπή δεν διαγράφει αρχικά τα κρυμμένα εικονοστοιχεία από την ενσωματωμένη εικόνα· απλώς αλλάζει την ορατή περιοχή.

Το παρακάτω παράδειγμα βρίσκει ένα πλαίσιο εικόνας με ασφάλεια και εφαρμόζει τιμές περικοπής:

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

Επειδή τα κρυμμένα δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να τροποποιηθεί αργότερα χωρίς να χαθούν οι αρχικές εικονοστοιχεία. Εάν το μέγεθος του αρχείου έχει μεγαλύτερη σημασία από την αντιστροφή, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων περικομμένης εικόνας**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) αφαιρεί δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: αφού αποθηκευτεί η παρουσίαση, τα αφαιρεμένα εικονοστοιχεία δεν είναι πλέον διαθέσιμα για μελλοντική ενέργεια «απεπεράσματος».

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

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο, οπότε η διαγραφή περικομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεροποιεί το αποτέλεσμα σε PNG.

## **Συμπίεση ραστερ εικόνων**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/compress_image/) μειώνει την ανάλυση ραστερ εικόνας σε σχέση με το μέγεθος με το οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `True` όταν η εικόνα είχε αλλάξει μέγεθος ή περικοπεί και `False` όταν δεν απαιτήθηκε καμία αλλαγή.

Χρησιμοποιήστε μια προκαθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/picturescompression/) όταν μια τυπική στοχευμένη ανάλυση είναι επαρκής:

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

Μπορείτε επίσης να περάσετε μια προσαρμοσμένη θετική τιμή DPI αντί για τιμή enum όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το περιεχόμενο SVG και των μετααρχείων δεν μειώνεται από αυτή τη ροή εργασίας ραστερ συμπίεσης. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες περικομμένες περιοχές δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στοχευμένη ανάλυση βάσει του μεγαλύτερου μεγέθους στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί πραγματικά, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Διαχείριση Εφέ Μετασχηματισμού Εικόνας**

Για πλήρη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, μετασχηματισμούς χρώματος, θόλωση, εφέ άλφα, αλυσίδες εντολών, επιθεώρηση, αφαίρεση και έλεγχο κυκλικής επαλήθευσης, δείτε [Image Transform Effects](/slides/el/python-net/image-transform-effects/).

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

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγή εικόνας να υποβληθεί σε επαναδειγματοληψία ή μόνιμη αλλαγή στην ίδια αναλογία διαστάσεων.

## **Ρύθμιση τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι τέντωμα, οι τιμές stretch‑offset στο [PictureFillFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/) ορίζουν το γεωμετρικό ορθογώνιο γεμίσματος σε σχέση με το περιθώριο του πλαισίου εικόνας. Θετικά ποσοστά δημιουργούν εσωτερική απόσταση από την άκρη, ενώ αρνητικά ποσοστά δημιουργούν εξωτερική απόσταση.

Αυτό διαφέρει από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγής εικόνας είναι ορατό· οι τιμές stretch αλλάζουν το ορθογώνιο μέσα στο οποίο τεντώνεται το ορατό γεμάτο εικόνας.

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

Χρησιμοποιήστε stretch offsets για τοποθέτηση γεμίσματος. Χρησιμοποιήστε ιδιότητες περικοπής όταν ο στόχος είναι η κάλυψη των άκρων της πηγής εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και σκέψεις εξαγωγής**

Οι κύριες ανταλλαγές είναι πιο εύκολο να διαχειριστούν όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση στο διακομιστή, αλλά μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή θέσεις.
- **Περικοπή** είναι αρχικά μη καταστροφική. Τα κρυμμένα εικονοστοιχεία παραμένουν ενσωματωμένα μέχρι να διαγραφούν ρητά οι περικομμένες περιοχές ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθη ραστερ εικόνες, αλλά θυσιάζει την πηγή ανάλυση. Πρέπει να εφαρμοστεί μετά τον καθορισμό του τελικού μεγέθους στην διαφάνεια.
- **SVG εικόνες** θα πρέπει να παραμένουν ως SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι εξαγωγές διαφάνειας σε ραστερ μορφή μετατρέπει πάντα τη διαφάνεια σε εικονοστοιχεία.
- **Επανάληψη εικόνων** θα πρέπει να επαναχρησιμοποιεί έναν υπάρχοντα πόρο [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) όταν είναι δυνατόν αντί για επαναλαμβανόμενη φόρτωση του ίδιου αρχείου στη ροή εργασίας παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν εκτελείται επιλεκτικά: διατηρήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες ανάλογα με το πραγματικό μέγεθος προβολής, αφαιρέστε περικομμένα εικονοστοιχεία μόνο όταν δεν απαιτείται επεξεργασία αργότερα, και αποφύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων είναι μέρος του σχεδιασμού ανάπτυξης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου εικόνας και πόρου εικόνας;**

Ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) αντιπροσωπεύει έναν πόρο εικόνας σχετιζόμενο με την παρουσίαση. Ένα [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/) είναι ένα σχήμα σε μια διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση σε επίπεδο πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώσω ή να συνδέσω τις εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή να αποδίδεται χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές θέσεις μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν τμήματα της πηγής εικόνας αλλά διατηρούν τα υποκείμενα εικονοστοιχεία. Χρησιμοποιήστε [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/el/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) ή συμπίεση εικόνας με αφαίρεση περικομμένων περιοχών όταν τα εικονοστοιχεία μπορούν να διαγραφούν μόνιμα.

**Μπορώ να επαναφέρω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση, και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγή εικόνας εκτός της παρουσίασης εάν μπορεί να χρειαστεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η πιστότητα του διανύσματος είναι σημαντική. Το ενσωματωμένο [SvgImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/svgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε ραστερ μορφή όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας της διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπων όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Η χρήση `isinstance(shape, slides.PictureFrame)` αποτρέπει μη έγκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.