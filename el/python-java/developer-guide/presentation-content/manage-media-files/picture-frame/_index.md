---
title: Διαχείριση Πλαισίων Εικόνας σε Παρουσιάσεις με Python
linktitle: Πλαίσιο Εικόνας
type: docs
weight: 10
url: /el/python-java/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- ενσωματωμένη εικόνα
- συνδεδεμένη εικόνα
- εξαγωγή εικόνας
- ραστερ εικόνα
- SVG εικόνα
- κοπή εικόνας
- διαγραφή κομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- λόγος διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, κόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με το Aspose.Slides for Python μέσω Java."
---
## **Overview**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος της εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω του [ImageCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagecollection/), ενώ ένα [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, το κόψιμο, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διάσπαση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας όταν δημιουργείτε πλαίσια εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνες όπως PNG ή JPEG και διανυσματικές SVG εικόνες. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα byte της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, επομένως είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Add and Format an Embedded Image**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addPictureFrame). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, οπότε η παρουσίαση παραμένει αυτόνομα ενσωματωμένη όταν μεταφερθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια JPEG εικόνα, δημιουργεί ένα πλαίσιο με τις εγγενείς διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις εικονοστοιχείων που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν κόβετε ή συμπιέζετε μια εικόνα αργότερα.

## **Use Relative Scale**

[PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο μέσω των [setRelativeScaleWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγής εικόνας αντί να υπολογίζει τελικές διαστάσεις χειροκίνητα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ούτε συμπιέζει την ενσωματωμένη εικόνα.

## **Embedded and Linked Images**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και είναι επομένως η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική τοποθεσία μέσω της μεθόδου [Picture.setLinkPathLong](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/#setLinkPathLong) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορεί να μειώσουν το ποσό των δεδομένων εικόνας που αποθηκεύεται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα μπορεί να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να αποστέλλονται μέσω email, να αρχειοθετούνται ή να αποδίδονται σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Add a Linked Image**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το κατευθύνει σε ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και εσκεμμένα δεν αναμιγνύεται σε αυτό το παράδειγμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε μόνο ως υποκατάστατο της συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτόνομα ενσωματωμένη παρουσίαση.

## **Extract Images from Picture Frames**

Πριν εξάγετε μια εικόνα από μια υπάρχουσα παρουσίαση, ελέγξτε ότι το σχήμα είναι πράγματι ένα [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας μπορεί να μην περιέχουν τα byte της εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Extract a Raster Image**

Το σύγχρονο API εικόνας δουλεύει απευθείας με ραστερ εικόνες και δεν απαιτεί το παλαιότερο Java image wrapper. Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Η αποθήκευση της ραστερ εικόνας μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα byte που αποθηκεύονται στην παρουσίαση αντί για ένα μετατρεπόμενο ραστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Extract an SVG Image**

Για μια SVG εικόνα, το [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) εκθέτει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/). Αυτό σας επιτρέπει να λάβετε τα SVG δεδομένα απευθείας αντί να ραστεράρετε την εικόνα πρώτα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Η διατήρηση του SVG περιεχομένου ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές ραστερ όπως PNG ή JPEG αναγκάζουν το διανυσματικό περιεχόμενο να αποδοθεί σε εικονοστοιχεία. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης λειτουργία απόδοσης, οπότε τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφο byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα [SvgImage.getSvgData](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/#getSvgData) όταν απαιτείται ο αρχικός διανυσματικός πόρος.

## **Crop an Image**

Το κόψιμο αλλάζει ποιο τμήμα της εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές κόψιμου στο [PictureFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Το κόψιμο αρχικά δεν διαγράφει τα κρυμμένα εικονοστοιχεία από την ενσωματωμένη εικόνα· απλώς αλλάζει την ορατή περιοχή.

Το παρακάτω παράδειγμα βρίσκει με ασφάλεια ένα πλαίσιο εικόνας και εφαρμόζει τιμές κόψιμου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Επειδή τα κρυφά δεδομένα εικόνας παραμένουν, το κόψιμο μπορεί να τροποποιηθεί αργότερα χωρίς να χαθούν τα αρχικά pixel. Εάν το μέγεθος αρχείου έχει μεγαλύτερη σημασία από την επαναδιόρθωση, οι κομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Remove Cropped Image Data**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου κόψιμου και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: αφού η παρουσίαση αποθηκευτεί, τα αφαιρεμένα pixel δεν είναι πλέον διαθέσιμα για μετέπειτα ενέργεια «αποκόπης».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια χρειάζονται ακόμα τον υπάρχοντα πόρο, έτσι η διαγραφή των κομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Το κόψιμο περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεράρει το κομμένο αποτέλεσμα σε PNG.

## **Compress Raster Images**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#compressImage) μειώνει την ανάλυση ραστερ εικόνας σε σχέση με το μέγεθος με το οποίο η εικόνα προβάλλεται. Μπορεί επίσης να αφαιρέσει τις κομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `True` όταν η εικόνα επαναμετρήθηκε ή κόπηκε και `False` όταν δεν ήταν απαραίτητη καμία αλλαγή.

Χρησιμοποιήστε μια προεπιλεγμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturescompression/) όταν είναι επαρκής μια τυπική στόχευση ανάλυσης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Μια προσαρμοσμένη θετική τιμή DPI μπορεί να δωθεί αντί μιας προεπιλεγμένης τιμής όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το SVG και το περιεχόμενο μεταφόρμας δεν μειώνονται από αυτή τη ροή συμπίεσης ραστερ. Επίσης θυμηθείτε ότι η χαμηλότερη ανάλυση και η διαγραφή των κομμένων περιοχών δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης βασισμένο στο μεγαλύτερο μέγεθος στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Manage Image Transform Effects**

Για μια ολοκληρωμένη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, μετασχηματισμούς χρώματος, θόλωση, εφέ άλφα, αλυσίδες, έλεγχο, αφαίρεση και επαλήθευση round‑trip, δείτε [Image Transform Effects](/slides/el/python-java/image-transform-effects/).

## **Lock Picture Frame Geometry**

Οι ρυθμίσεις [PictureFrameLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας απενεργοποιούνται για ένα πλαίσιο εικόνας. Για παράδειγμα, το [setAspectRatioLocked](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) διατηρεί τις αναλογίες του σχήματος όταν αλλάζει το μέγεθός του.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να αλλάξει μόνιμα στον ίδιο λόγο διαστάσεων.

## **Adjust the StretchOffset Values**

Όταν η λειτουργία γεμίσματος εικόνας είναι «stretch», οι τιμές stretch‑offset στο [PictureFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/) ορίζουν το ορθογώνιο γέμισμα σε σχέση με το πλαίσιο οριοθέτησης του πλαισίου εικόνας. Θετικά ποσοστά δημιουργούν εσοχή από την άκρη, ενώ αρνητικά ποσοστά δημιουργούν εξώθεση.

Αυτό διαφέρει από το κόψιμο. Οι τιμές κόψιμου επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι stretch‑offset αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γέμισμα εικόνας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Χρησιμοποιήστε stretch‑offset για τοποθέτηση γεμίσματος. Χρησιμοποιήστε ιδιότητες κόψιμου όταν ο στόχος είναι να κρύψετε άκρες της πηγαίας εικόνας.

## **Storage, File Size, and Export Considerations**

Οι κύριες ανταλλαγές γίνονται πιο διαχειρίσιμες όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται ξεχωριστά:

- **Embedded images** κάνουν την παρουσίαση αυτόνομα ενσωματωμένη και είναι η πιο αξιόπιστη επιλογή για κοινή χρήση και απόδοση πλευράς διακομιστή, αλλά μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Linked images** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που πρέπει να παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή τοποθεσίες.
- **Cropping** είναι αρχικά μη καταστροφικό. Τα κρυφά pixel παραμένουν ενσωματωμένα μέχρι οι κομμένες περιοχές να διαγραφούν ρητά ή να αφαιρεθούν κατά τη συμπίεση.
- **Compression** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθεις ραστερ εικόνες, αλλά θυσιάζει την πηγαία ανάλυση. Πρέπει να εφαρμοστεί αφού γνωστοποιηθεί το επιθυμητό μέγεθος στην διαφάνεια.
- **SVG images** θα πρέπει να παραμένουν ως SVG όταν η διανυσματική διατήρηση είναι σημαντική. Εξάγετε το ενσωματωμένο SVG άμεσα όταν χρειάζεστε τον ίδιο διανυσματικό πόρο. Οι εξαγωγές διαφάνειας σε ραστερ πάντα μετατρέπει τη διαφάνεια σε pixel.
- **Repeated images** θα πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) όποτε είναι δυνατόν αντί να φορτώνουν ξανά το ίδιο αρχείο στη ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν γίνεται επιλεκτικά: κρατήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες σύμφωνα με το πραγματικό τους μέγεθος προβολής, αφαιρέστε τα κομμένα pixel μόνο όταν δεν απαιτείται επεξεργασία αργότερα, και αποφύγετε εξωτερικούς συνδέσμους εκτός αν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδίου υλοποίησης.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

Ένα [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) αντιπροσωπεύει έναν πόρο εικόνας που σχετίζεται με την παρουσίαση. Ένα [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) είναι ένα σχήμα σε διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές κόψιμου, εφέ και κλειδώματα.

**Should I embed or link images?**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή να αποδίδεται χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές θέσεις μπορούν να διατηρηθούν αξιόπιστα.

**Does cropping reduce PPTX file size?**

Όχι μόνο του. Οι κανονικές ρυθμίσεις κόψιμου κρύβουν τμήματα της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε το [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ή τη συμπίεση εικόνας με αφαίρεση κομμένων περιοχών όταν τα pixel αυτά μπορούν να διαγραφούν μόνιμα.

**Can I restore image quality after compression?**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση, και η διαγραφή των κομμένων περιοχών αφαιρεί δεδομένα εικόνας. Κρατήστε την αρχική πηγή εικόνας εκτός της παρουσίασης αν απαιτηθεί επεξεργασία υψηλής ανάλυσης αργότερα.

**How should SVG images be handled?**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η ακρίβεια διανυσματισμού είναι σημαντική. Το ενσωματωμένο [SvgImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε ραστερ μορφή όπως PNG ή JPEG ραστεράρει το SVG ως μέρος της εικόνας διαφάνειας.

**How can I avoid unsafe casts when reading existing slides?**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Μια ελέγχος `isinstance` έναντι του [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) αποτρέπει μη έγκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.