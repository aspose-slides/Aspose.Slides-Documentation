---
title: Προσθήκη Υδατογραφημάτων σε Παρουσιάσεις με Python
linktitle: Υδατογράφημα
type: docs
weight: 40
url: /el/python-java/watermark/
keywords:
- υδατογράφημα
- υδατογράφημα κειμένου
- υδατογράφημα εικόνας
- προσθήκη υδατογραφήματος
- αλλαγή υδατογραφήματος
- αφαίρεση υδατογραφήματος
- διαγραφή υδατογράφηματος
- προσθήκη υδατογραφήματος σε PPT
- προσθήκη υδατογραφήματος σε PPTX
- προσθήκη υδατογραφήματος σε ODP
- αφαίρεση υδατογραφήματος από PPT
- αφαίρεση υδατογραφήματος από PPTX
- αφαίρεση υδατογραφήματος από ODP
- διαγραφή υδατογράφηματος από PPT
- διαγραφή υδατογράφηματος από PPTX
- διαγραφή υδατογράφηματος από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε υδατογραφήματα κειμένου και εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με Python για να υποδείξετε πρόχειρο, εμπιστευτικές πληροφορίες, πνευματικά δικαιώματα και άλλα."
---
## **Εισαγωγή**

**Υδατογράφημα** σε μια παρουσίαση είναι μια σήμανση κειμένου ή εικόνας που χρησιμοποιείται σε μια διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Συνήθως, ένα υδατογράφημα χρησιμοποιείται για να υποδείξει ότι η παρουσίαση είναι πρόχειρη (π.χ. υδατογράφημα «Πρόχειρο»), ότι περιέχει εμπιστευτικές πληροφορίες (π.χ. υδατογράφημα «Εμπιστευτικό»), για να προσδιορίσει σε ποια εταιρεία ανήκει (π.χ. υδατογράφημα «Όνομα Εταιρείας»), για να αναγνωρίσει τον συγγραφέα της παρουσίασης κ.λπ. Ένα υδατογράφημα βοηθά στην αποφυγή παραβίασης πνευματικών δικαιωμάτων υποδεικνύοντας ότι η παρουσίαση δεν πρέπει να αντιγραφεί. Τα υδατογραφήματα χρησιμοποιούνται τόσο σε μορφές παρουσίασης PowerPoint όσο και OpenOffice. Στο **Aspose.Slides**, μπορείτε να προσθέσετε ένα υδατογράφημα στα αρχεία PowerPoint PPT, PPTX και OpenOffice ODP.

Στο [**Aspose.Slides**](https://products.aspose.com/slides/el/python-java/), υπάρχουν διάφοροι τρόποι για να δημιουργήσετε υδατογραφήματα σε έγγραφα PowerPoint ή OpenOffice και να τροποποιήσετε το σχεδιασμό και τη συμπεριφορά τους. Το κοινό στοιχείο είναι ότι για την προσθήκη κειμενικών υδατογραφημάτων πρέπει να χρησιμοποιήσετε την κλάση [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/), και για την προσθήκη εικόνων, χρησιμοποιήστε την κλάση [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) ή γεμίστε ένα σχήμα υδατογραφήματος με εικόνα. Η [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/) κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/), επιτρέποντας τη χρήση όλων των ευέλικτων ρυθμίσεων του αντικειμένου σχήματος. Επειδή η [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) δεν είναι σχήμα και οι ρυθμίσεις της είναι περιορισμένες, περιβάλλεται σε ένα αντικείμενο [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/).

Υπάρχουν δύο τρόποι εφαρμογής ενός υδατογραφήματος: σε μία μόνο διαφάνεια ή σε όλες τις διαφάνειες της παρουσίασης. Ο Δάσκαλος Διαφάνειας (Slide Master) χρησιμοποιείται για την εφαρμογή υδατογραφήματος σε όλες τις διαφάνειες — το υδατογράφημα προστίθεται στον Δάσκαλο Διαφάνειας, σχεδιάζεται πλήρως εκεί και εφαρμόζεται σε όλες τις διαφάνειες χωρίς να επηρεάζει το δικαίωμα τροποποίησης του υδατογραφήματος σε μεμονωμένες διαφάνειες.

Ένα υδατογράφημα θεωρείται συνήθως μη επεξεργάσιμο από άλλους χρήστες. Για να αποτρέψετε την επεξεργασία του υδατογραφήματος (ή περισσότερο συγκεκριμένα του γονικού σχήματος του), το Aspose.Slides προσφέρει λειτουργίες κλειδώματος σχήματος. Ένα συγκεκριμένο σχήμα μπορεί να κλειδωθεί σε κανονική διαφάνεια ή στον Δάσκαλο Διαφάνειας. Όταν το σχήμα του υδατογραφήματος κλειδωθεί στον Δάσκαλο Διαφάνειας, θα είναι κλειδωμένο σε όλες τις διαφάνειες της παρουσίασης.

Μπορείτε να ορίσετε ένα όνομα για το υδατογράφημα ώστε στο μέλλον, αν θέλετε να το διαγράψετε, να το εντοπίσετε στις διαφάνειες με βάση το όνομα.

Μπορείτε να σχεδιάσετε το υδατογράφημα με οποιονδήποτε τρόπο· ωστόσο, συνήθως τα υδατογραφήματα έχουν κοινά χαρακτηριστικά, όπως κεντρική στοίχιση, περιστροφή, θέση μπροστά κ.λπ. Θα δούμε πώς να τα χρησιμοποιήσουμε στα παραδείγματα παρακάτω.

## **Υδατογράφημα Κειμένου**

### **Προσθήκη Υδατογράφηματος Κειμένου σε Διαφάνεια**

Για να προσθέσετε ένα κειμενικό υδατογράφημα σε PPT, PPTX ή ODP, μπορείτε πρώτα να προσθέσετε ένα σχήμα στη διαφάνεια, έπειτα ένα πλαίσιο κειμένου σε αυτό το σχήμα. Το πλαίσιο κειμένου αντιπροσωπεύεται από την κλάση [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/). Αυτός ο τύπος δεν κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/), η οποία παρέχει μεγάλο σύνολο ιδιοτήτων για ευέλικτη τοποθέτηση του υδατογραφήματος. Συνεπώς, το αντικείμενο [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) περιβάλλεται σε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/). Για να προσθέσετε κείμενο υδατογραφήματος στο σχήμα, χρησιμοποιήστε τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#addTextFrame) όπως φαίνεται παρακάτω.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Πώς να Χρησιμοποιήσετε την Κλάση TextFrame](/slides/el/python-java/text-formatting/)
{{% /alert %}}

### **Προσθήκη Υδατογράφηματος Κειμένου σε Παρουσίαση**

Αν θέλετε να προσθέσετε ένα κειμενικό υδατογράφημα σε ολόκληρη την παρουσίαση (δηλαδή σε όλες τις διαφάνειες ταυτόχρονα), προσθέστε το στο [MasterSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/). Το υπόλοιπο λογικό είναι το ίδιο όπως όταν προσθέτετε υδατογράφημα σε μία διαφάνεια — δημιουργήστε ένα αντικείμενο [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) και μετά προσθέστε το υδατογράφημα χρησιμοποιώντας τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Πώς να Χρησιμοποιήσετε το Slide Master](/slides/el/python-java/slide-master/)
{{% /alert %}}

### **Ορισμός Διαφάνειας Σχήματος Υδατογραφήματος**

Προεπιλεγμένα, το ορθογώνιο σχήμα έχει χρώματα γεμίσματος και περιγράμματος. Οι παρακάτω γραμμές κώδικα κάνουν το σχήμα διαυγές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Ορισμός Γραμματοσειράς για Υδατογράφημα Κειμένου**

Μπορείτε να αλλάξετε τη γραμματοσειρά του κειμενικού υδατογραφήματος όπως φαίνεται παρακάτω.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Ορισμός Χρώματος Κειμένου Υδατογραφήματος**

Για να ορίσετε το χρώμα του κειμένου του υδατογραφήματος, χρησιμοποιήστε αυτόν τον κώδικα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Κεντράρισμα Υδατογράφηματος Κειμένου**

Μπορείτε να κεντράρετε το υδατογράφημα σε μια διαφάνεια, ακολουθώντας τα παρακάτω βήματα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

Η εικόνα παρακάτω δείχνει το τελικό αποτέλεσμα.

![Το υδατογράφημα κειμένου](text_watermark.png)

## **Υδατογράφημα Εικόνας**

### **Προσθήκη Υδατογράφηματος Εικόνας σε Παρουσίαση**

Για να προσθέσετε ένα υδατογράφημα εικόνας σε διαφάνεια παρουσίασης, μπορείτε να ακολουθήσετε τα εξής:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Κλείδωμα Υδατογραφήματος από Επεξεργασία**

Αν είναι απαραίτητο να αποτρέψετε την επεξεργασία ενός υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#getAutoShapeLock) στο σχήμα. Με αυτήν την ιδιότητα μπορείτε να προστατεύσετε το σχήμα από επιλογή, αλλαγή μεγέθους, μετακίνηση, ομαδοποίηση με άλλα στοιχεία, κλείδωμα του κειμένου από επεξεργασία και πολλά άλλα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Κλείδωμα του σχήματος υδατογραφήματος ενάντια σε τροποποίηση.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Φέρτε το Υδατογράφημα Μπροστά**

Στο Aspose.Slides, η σειρά Z των σχημάτων μπορεί να οριστεί μέσω της μεθόδου [ShapeCollection.reorder](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#reorder). Για να το πράξετε, καλέστε αυτήν τη μέθοδο από τη συλλογή σχημάτων της διαφάνειας, περνώντας την αναφορά του σχήματος και τον αριθμό σειράς του. Έτσι, είναι δυνατόν να φέρετε ένα σχήμα μπροστά ή να το στείλετε πίσω στη διαφάνεια. Αυτό είναι ιδιαίτερα χρήσιμο αν θέλετε να τοποθετήσετε το υδατογράφημα μπροστά από το περιεχόμενο της παρουσίασης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Ορισμός Περιστροφής Υδατογραφήματος**

Ακολουθεί παράδειγμα κώδικα για το πώς να ρυθμίσετε την περιστροφή του υδατογραφήματος ώστε να τοποθετηθεί διαγώνια στη διαφάνεια:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Ορισμός Ονόματος για Υδατογράφημα**

Το Aspose.Slides σας επιτρέπει να ορίσετε το όνομα ενός σχήματος. Χρησιμοποιώντας το όνομα του σχήματος, μπορείτε μελλοντικά να το προσπελάσετε για τροποποίηση ή διαγραφή. Για να ορίσετε το όνομα του σχήματος υδατογραφήματος, περάστε το στη μέθοδο [Shape.setName](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Αφαίρεση Υδατογραφήματος**

Για να αφαιρέσετε το σχήμα του υδατογραφήματος, χρησιμοποιήστε τη μέθοδο [Shape.getName](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getName) ώστε να το βρείτε στα σχήματα της διαφάνειας. Στη συνέχεια, περάστε το σχήμα υδατογραφήματος στη μέθοδο [ShapeCollection.remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Τι είναι ένα υδατογράφημα και γιατί να το χρησιμοποιήσω;**

Ένα υδατογράφημα είναι μια επικάλυψη κειμένου ή εικόνας που τοποθετείται πάνω σε διαφάνειες για την προστασία της πνευματικής ιδιοκτησίας, την ενίσχυση της αναγνώρισης της μάρκας ή την αποτροπή μη εξουσιοδοτημένης χρήσης των παρουσιάσεων.

**Μπορώ να προσθέσω υδατογράφημα σε όλες τις διαφάνειες μιας παρουσίασης;**

Ναι, το Aspose.Slides επιτρέπει την προγραμματισμένη προσθήκη υδατογραφήματος σε κάθε διαφάνεια της παρουσίασης. Μπορείτε να διατρέξετε όλες τις διαφάνειες και να εφαρμόσετε τις ρυθμίσεις του υδατογραφήματος ξεχωριστά.

**Πώς μπορώ να ρυθμίσω τη διαφάνεια του υδατογράφηματος;**

Μπορείτε να ρυθμίσετε τη διαφάνεια του υδατογράφηματος τροποποιώντας τις ρυθμίσεις γεμίσματος ([getFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getFillFormat)) του σχήματος. Έτσι το υδατογράφημα θα είναι διακριτικό και δεν θα αποσπά την προσοχή από το περιεχόμενο της διαφάνειας.

**Τι τύποι εικόνας υποστηρίζονται για υδατογραφήματα;**

Το Aspose.Slides υποστηρίζει διάφορους τύπους εικόνας όπως PNG, JPEG, GIF, BMP, SVG και άλλους.

**Μπορώ να προσαρμόσω τη γραμματοσειρά και το στυλ ενός υδατογράφηματος κειμένου;**

Ναι, μπορείτε να επιλέξετε οποιαδήποτε γραμματοσειρά, μέγεθος και στυλ ώστε να ταιριάζει με το σχεδιασμό της παρουσίασής σας και να διατηρεί τη συνέπεια της μάρκας.

**Πώς αλλάζω τη θέση ή τον προσανατολισμό ενός υδατογράφηματος;**

Μπορείτε να προσαρμόσετε τη θέση και τον προσανατολισμό του υδατογράφηματος προγραμματιστικά, τροποποιώντας τις συντεταγμένες, το μέγεθος και τις ιδιότητες περιστροφής του σχήματος.