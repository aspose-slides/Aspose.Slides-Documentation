---
title: Διαχείριση Πλαισίων Εικόνας σε Παρουσιάσεις χρησιμοποιώντας Python
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
- Java
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, περικόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω του [ImageCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagecollection/), ενώ ένα [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, το περικομμένο τμήμα, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτός ο διαχωρισμός είναι χρήσιμος όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας κατά τη δημιουργία πλαισίων εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνες όπως PNG ή JPEG και διανυσματικές εικόνες SVG. Μπορούν επίσης να παραπέμπουν σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα byte της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει τη φορητότητα, το μέγεθος του αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, οπότε είναι χρήσιμο να αποφασιστεί πώς θα αποθηκευτεί η εικόνα προτού εφαρμοστούν μορφοποιήσεις ή βελτιστοποιήσεις.

## **Προσθήκη και Μορφοποίηση Ενσωματωμένης Εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με το [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addPictureFrame). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, ώστε η παρουσίαση να παραμένει αυτό-συμπεπλεγμένη όταν μετακινηθεί σε άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια εικόνα JPEG, δημιουργεί ένα πλαίσιο στις φυσικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

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

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις pixel που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόπτετε ή συμπιέζετε την εικόνα αργότερα.

## **Χρήση Σχετικής Κλίμακας**

[PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο μέσω των [setRelativeScaleWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) και [setRelativeScaleHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Μία τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει το τελικό μέγεθος χειροκίνητα.

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

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ή συμπιέζει τη ενσωματωμένη εικόνα.

## **Ενσωματωμένες και Συνδεδεμένες Εικόνες**

Μία ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και επομένως είναι η πιο ασφαλής επιλογή για φορητότητα και προβλέψιμη απόδοση. Μία συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική θέση μέσω της μεθόδου [Picture.setLinkPathLong](https://reference.aspose.com/slides/el/python-java/aspose.slides/picture/#setLinkPathLong) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν την ποσότητα των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, το αρχείο μετακινηθεί ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα μπορεί να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να σταλούν με email, να αποθηκευτούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη Συνδεδεμένης Εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το δείχνει σε ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμιγνύεται σε αυτό το παράδειγμα.

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

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι προγραμματισμένη. Μην τους χρησιμοποιείτε μόνο ως υποκατάστατο συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτό-συμπεριλαβόμενη παρουσίαση.

## **Εξαγωγή Εικόνων από Πλαίσια Εικόνας**

Πριν εξάγετε μια εικόνα από υπάρχουσα παρουσίαση, ελέγξτε ότι το σχήμα είναι πραγματικά ένα [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας μπορεί να μην περιέχουν byte εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή Ραστερ Εικόνας**

Το σύγχρονο API εικόνας λειτουργεί άμεσα με ραστερ εικόνες και δεν απαιτεί τον παλαιότερο Java image wrapper. Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

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

### **Εξαγωγή Εικόνας SVG**

Για μια εικόνα SVG, το [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) εκθέτει ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG άμεσα αντί να ραστεροποιήσετε πρώτα την εικόνα.

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

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι εξαγωγές ραστερ όπως PNG ή JPEG αναγκάστηκαν να μετατρέψουν αυτό το διανυσματικό περιεχόμενο σε pixel. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης λειτουργία απόδοσης, οπότε τα εξαγόμενα γραφικά δεν πρέπει να θεωρούνται αντίγραφα byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα [SvgImage.getSvgData](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/#getSvgData) όταν απαιτείται ο ίδιος ο διανυσματικός πόρος.

## **Περικοπή Εικόνας**

Η περικοπή αλλάζει ποιο τμήμα της εικόνας είναι ορατό μέσα στο πλαίσιο. Οι τιμές περικοπής στο [PictureFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή δεν διαγράφει αρχικά τα κρυμμένα pixel από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα βρίσκει ένα πλαίσιο εικόνας με ασφάλεια και εφαρμόζει τιμές περικοπής:

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

Επειδή τα κρυφά δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να αλλάξει αργότερα χωρίς να χαθούν τα αρχικά pixel. Εάν το μέγεθος του αρχείου έχει μεγαλύτερη σημασία από την αντιστροψιμότητα, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση Δεδομένων Περικομμένων Εικόνων**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά είναι μια καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρεμένα pixel δεν είναι πια διαθέσιμα για μετέπειτα αποπέρικοπη ενέργεια.

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

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια χρειάζονται ακόμη τον υπάρχον πόρο τους, οπότε η διαγραφή των περικομμένων περιοχών δεν μειώνει υποχρεωτικά το συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο ραστεροποιεί το αποτέλεσμα σε PNG.

## **Συμπίεση Ραστερ Εικόνων**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#compressImage) μειώνει την ανάλυση ραστερ εικόνας σε σχέση με το μέγεθος στο οποίο εμφανίζεται η εικόνα. Μπορεί επίσης να αφαιρέσει περικομμένα τμήματα στην ίδια λειτουργία. Η μέθοδος επιστρέφει `True` όταν η εικόνα έγινε αλλαγής μεγέθους ή περικόπτης και `False` όταν δεν απαιτήθηκε καμία αλλαγή.

Χρησιμοποιήστε μια προκαθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturescompression/) όταν μια τυπική στόχευση ανάλυσης είναι επαρκής:

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

Μια προσαρμοσμένη θετική τιμή DPI μπορεί να περαστεί αντί για προκαθορισμένη τιμή όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το περιεχόμενο SVG και μεταφίλων δεν μειώνεται από αυτή τη ροή συμπίεσης ραστερ εικόνας. Θυμηθείτε επίσης ότι η χαμηλότερη ανάλυση και τα διαγραμμένα περικομμένα τμήματα δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης με βάση το μεγαλύτερο μέγεθος στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί πραγματικά, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Διαχείριση Εφέ Μετασχηματισμού Εικόνας**

Για μια πλήρη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, μετασχηματισμούς χρώματος, θόλωση, εφέ άλφα, αλυσίδες, επιθεώρηση, αφαίρεση και επαλήθευση γύρω από τον κύκλο, δείτε [Image Transform Effects](/slides/el/python-java/image-transform-effects/).

## **Κλείδωμα Γεωμετρίας Πλαισίου Εικόνας**

Οι ρυθμίσεις του [PictureFrameLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, η [setAspectRatioLocked](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) διατηρεί τις αναλογίες του σχήματος ενώ αλλάζει μέγεθος.

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

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να μετατραπεί μόνιμα στην ίδια αναλογία.

## **Ρύθμιση Τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι stretch, οι τιμές stretch‑offset στο [PictureFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/) ορίζουν το ορθογώνιο γέμισμα σε σχέση με το περιθώριο του πλαισίου εικόνας. Τα θετικά ποσοστά δημιουργούν εσοχή από άκρο, ενώ τα αρνητικά ποσοστά δημιουργούν εξώστρεψη.

Αυτό είναι διαφορετικό από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι stretch‑offset αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γέμισμα εικόνας.

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

Χρησιμοποιήστε stretch‑offset για τοποθέτηση γέμισματος. Χρησιμοποιήστε ιδιότητες περικοπής όταν ο στόχος είναι να κρύψετε άκρα της πηγαίας εικόνας.

## **Αποθήκευση, Μέγεθος Αρχείου και Σκέψεις Εξαγωγής**

Οι κύριες ανταλλαγές γίνονται πιο εύκολα διαχειρίσιμες όταν η αποθήκευση εικόνων και η μορφοποίηση πλαισίων εικόνας αντιμετωπίζονται ξεχωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτό‑συμπεριλαμβανόμενη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση διακομιστή, όμως μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή θέσεις.
- **Περικοπή** είναι αρχικά μη‑καταστροφική. Τα κρυμμένα pixel παραμένουν ενσωματωμένα μέχρι να διαγραφούν ρητά οι περικομμένες περιοχές ή κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθεις ραστερ εικόνες, αλλά θυσιάζει την πηγαία ανάλυση. Πρέπει να εφαρμοστεί αφού γνωστεί το επιθυμητό μέγεθος στην διαφάνεια.
- **Εικόνες SVG** θα πρέπει να παραμείνουν SVG όταν η διανυσματική διατήρηση είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεται ο ίδιος ο διανυσματικός πόρος. Οι εξαγωγές διαφάνειας σε raster όπως PNG πάντα μετατρέπουν την απόδοση της διαφάνειας σε pixel.
- **Επαναλαμβανόμενες εικόνες** θα πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) όταν είναι δυνατόν αντί να φορτώνουν ξανά το ίδιο αρχείο στην ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνων είναι συνήθως πιο αποτελεσματική όταν γίνεται επιλεκτικά: κρατήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες ανάλογα με το πραγματικό τους μέγεθος προβολής, αφαιρέστε περικομμένα pixel μόνο όταν δεν απαιτείται μετέπειτα επεξεργασία, και αποφύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδίου ανάπτυξης.

## **FAQ**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου εικόνας και ενός πόρου εικόνας;**

Ένα [PPImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) είναι ένα σχήμα σε διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώσω ή να συνδέσω τις εικόνες;**

Ενσωματώστε τις εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδίδεται χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε τις εικόνες μόνο όταν η τοποθέτηση αρχείων εκτός του PPTX είναι σκόπιμη και οι εξωτερικές θέσεις μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν τμήματα της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε το [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/el/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ή τη συμπίεση εικόνας με αφαίρεση περικομμένων περιοχών όταν μπορούν να απορριφθούν μόνιμα αυτά τα pixel.

**Μπορώ να επαναφέρω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση, και η αφαίρεση περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγαία εικόνα εκτός της παρουσίασης εάν μπορεί να απαιτηθεί επεξεργασία υψηλής ανάλυσης αργότερα.

**Πώς πρέπει να διαχειρίζομαι τις εικόνες SVG;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η διανυσματική πιστότητα είναι σημαντική. Το ενσωματωμένο [SvgImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/) μπορεί να εξαχθεί άμεσα. Η απόδοση μιας διαφάνειας σε μορφή raster όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας της διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπων όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Μια εντολή `isinstance` εναντίον του [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) αποφεύγει μη έγκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.