---
title: "Βελτιώστε την Επεξεργασία Εικόνας με το Μοντέρνο API στην Python"
linktitle: "Μοντέρνο API"
type: docs
weight: 237
url: /el/python-java/modern-api/
keywords:
- μοντέρνο API
- σχεδίαση
- μικρογραφία διαφάνειας
- διαφάνεια σε εικόνα
- μικρογραφία σχήματος
- σχήμα σε εικόνα
- μικρογραφία παρουσίασης
- παρουσίαση σε εικόνες
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- Python
- Java
- Aspose.Slides
description: "Μοντερνίστε την επεξεργασία εικόνας στην Python μέσω Java: αποδώστε διαφάνειες και σχήματα, προσθέστε φωτογραφίες και μεταφέρετε τις παρωχημένες κλήσεις επεξεργασίας εικόνας στο Μοντέρνο API του Aspose.Slides."
---
## **Εισαγωγή**

Aspose.Slides for Python via Java προσπελαύνει τη βιβλιοθήκη Java μέσω JPype. Το κληρονομημένο API επεξεργασίας εικόνας χρησιμοποιούσε το [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) και το [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) από `java.awt`.

Η βιβλιοθήκη Java απαίσια (deprecated) αυτές τις API εικόνας ξεκινώντας από την έκδοση 24.4. Το Μοντέρνο API χρησιμοποιεί το [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/) για φόρτωση, απόδοση και αποθήκευση εικόνων. Χρησιμοποιήστε το για νέο κώδικα Python και κατά τη μετάβαση των υπαρχόντων ροών εργασίας επεξεργασίας εικόνας.

{{% alert color="info" title="Σημείωση" %}}

Τα παλιά ονόματα μεθόδων παρακάτω είναι αναφορές μετάβασης. Δεν διατίθενται πλέον στις τρέχουσες εκδόσεις. Τα εκτελέσιμα παραδείγματα χρησιμοποιούν το Μοντέρνο API.

Αυτή η αλλαγή δεν εξαλείφει κάθε τύπο `java.awt`: οι υπερφορτώσεις μέγεθος‑εικόνας και χρώμα‑πατρόν εξακολουθούν να δέχονται το [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) και το [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

{{% /alert %}}

## **Μοντέρνο API**

Οι κύριοι τύποι επεξεργασίας εικόνας είναι:

- [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/) — αντιπροσωπεύει μια ραστική ή διανυσματική εικόνα.
- [ImageFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/imageformat/) — παρέχει σταθερές μορφής αρχείου εικόνας.
- [Images](https://reference.aspose.com/slides/el/python-java/aspose.slides/images/) — δημιουργεί εικόνες, π.χ. με το [Images.fromFile](https://reference.aspose.com/slides/el/python-java/aspose.slides/images/#fromFile).

Χρησιμοποιήστε το [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) ή το [Shape.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) για απόδοση μιας διαφάνειας ή σχήματος. Χρησιμοποιήστε το [Presentation.getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) με επιλογές απόδοσης για απόδοση πολλαπλών διαφανειών. Η υπερφόρτωση χωρίς επιχειρήματα επιστρέφει τη συλλογή εικόνων της παρουσίασης.

Φορτώστε μια εικόνα με το [Images.fromFile](https://reference.aspose.com/slides/el/python-java/aspose.slides/images/#fromFile), προσθέστε τη με το [ImageCollection.addImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagecollection/#addImage), ή ενημερώστε μια υπάρχουσα εικόνα παρουσίασης με το [PPImage.replaceImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#replaceImage). Και οι δύο λειτουργίες συλλογής εικόνας δέχονται το [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/).

Απελευθερώστε κάθε εικόνα που φορτώνετε ή αποδίδετε καλώντας τη μέθοδο `dispose` της μέσα σε ένα μπλοκ `finally`. Απελευθερώστε την παρουσίαση με το [Presentation.dispose](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#dispose).

### **Προετοιμασία του Περιβάλλοντος Python**

Εγκαταστήστε τα πακέτα όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει το JVM, έπειτα εισάγει το API αφού το JVM εκτελείται. Τα παραδείγματα αφήνουν το JVM σε λειτουργία ώστε να μπορεί να επαναχρησιμοποιηθεί. Δείτε τις [Limitations and API Differences](/slides/el/python-java/limitations-and-api-differences/#import-the-library) για οδηγίες σχετικά με το notebook και τον κύκλο ζωής του JVM.

Τα παραδείγματα που ανοίγουν το `pres.pptx` απαιτούν μια παρουσίαση στον τρέχοντα φάκελο εργασίας. Τα παραδείγματα που φορτώνουν το `image.png` απαιτούν ένα υπάρχον αρχείο εικόνας.

### **Φόρτωση Εικόνας και Απόδοση Διαφάνειας**

Αυτό το παράδειγμα προσθέτει μια εικόνα στην πρώτη διαφάνεια και αποθηκεύει τη διαφάνεια ως εικόνα JPEG. Το [IImage.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/#save) γράφει την αποδοθείσα εικόνα στη καθορισμένη μορφή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Αντικατάσταση Παλαιού Κώδικα με Μοντέρνο API**

Αντικαταστήστε τις παλαιές κλήσεις μικρογραφιών με μεθόδους που επιστρέφουν [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/), στη συνέχεια αποθηκεύστε το αποτέλεσμα με το [IImage.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/#save). Αυτό αφαιρεί την ανάγκη να περάσετε τις αποδοθείσες εικόνες στο [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Απόδοση Διαφάνειας σε Καθορισμένο Μέγεθος**

Αντικαταστήστε την κλήση `slide.getThumbnail(image_size)` με το [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) χρησιμοποιώντας το ίδιο μέγεθος εικόνας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Λήψη Μικρογραφίας Διαφάνειας**

Αντικαταστήστε την κλήση `slide.getThumbnail()` με το [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) χωρίς επιχειρήματα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Λήψη Μικρογραφίας Σχήματος**

Αντικαταστήστε την κλήση `shape.getThumbnail()` με το [Shape.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage). Ελέγξτε ότι η διαφάνεια περιέχει σχήμα πριν το προσπελάσετε.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Λήψη Μικρογραφίας Παρουσίασης**

Αντικαταστήστε την κλήση `presentation.getThumbnails(options, image_size)` με το [Presentation.getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages). Χρησιμοποιήστε το [RenderingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/) για ρύθμιση απόδοσης.

Επανάλαβε τον επιστρεφόμενο πίνακα άμεσα με το `enumerate` της Python. Απορρίψτε κάθε εικόνα που επιστρέφεται σε ένα μπλοκ `finally` ώστε μια αποτυχία αποθήκευσης να μην αφήνει υπόλειμμα εικόνων μη αποδεσμευμένων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Προσθήκη Εικόνας σε Παρουσίαση**

Αντικαταστήστε τη φόρτωση μέσω του [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) με το [Images.fromFile](https://reference.aspose.com/slides/el/python-java/aspose.slides/images/#fromFile), στη συνέχεια περάστε τη δημιουργημένη εικόνα στο [ImageCollection.addImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagecollection/#addImage). Προσθέστε την εικόνα στη διαφάνεια και αποθηκεύστε την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Μέθοδοι που Έχουν Παρακμηθεί και Η Αντικατάστασή τους στο Μοντέρνο API**

Οι πίνακες χρησιμοποιούν σύνταξη κλήσης Python. Τα ονόματα στη στήλη «Legacy» ταυτοποιούν αφαιρεμένα API· χρησιμοποιήστε τις συνδεδεμένες μεθόδους αντικατάστασης. Οι μοντέρνες μέθοδοι απόδοσης εικόνας επιστρέφουν αντικείμενα [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/) αντί για Java buffered images.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) επιστρέφει έναν πίνακα αποδομένων εικόνων όταν κληθεί με επιλογές απόδοσης.

| Κλήση legacy | Μοντέρνη αντικατάσταση |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) με `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) με `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) με `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) με `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) με `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) με `options, image_size` |

Εδώ, `slides` είναι ένας Java `int[]` μονοειδών αριθμών διαφανειών· δημιουργήστε τον με `jpype.JArray(jpype.JInt)([1, 3])` για επιλογή των διαφανειών 1 και 3. Το `image_size` είναι ένα [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Κλήση legacy | Μοντέρνη αντικατάσταση |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) χωρίς επιχειρήματα |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) με `bounds, scale_x, scale_y` |

### **Slide**

| Κλήση legacy | Μοντέρνη αντικατάσταση |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) χωρίς επιχειρήματα |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) με `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) με `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) με `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) με `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) με `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) με `image_size` |
| `slide.renderToGraphics(options, graphics)` | Καμία άμεση αντικατάσταση· αποδώστε σε εικόνα αντί για γραφικό |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Καμία άμεση αντικατάσταση· αποδώστε σε εικόνα αντί για γραφικό |
| `slide.renderToGraphics(options, graphics, image_size)` | Καμία άμεση αντικατάσταση· αποδώστε σε εικόνα αντί για γραφικό |

Εδώ, `options` είναι [RenderingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/), και `tiff_options` είναι [TiffOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/tiffoptions/).

### **Output**

| Κλήση legacy | Μοντέρνη αντικατάσταση |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/el/python-java/aspose.slides/output/#add) με `path, image`, όπου `image` είναι [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Κλήση legacy | Μοντέρνη αντικατάσταση |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagecollection/#addImage) με ένα [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/) |

### **PPImage**

| Κλήση legacy | Μοντέρνη αντικατάσταση |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#getImage) |

Για αντικατάσταση του περιεχομένου μιας υπάρχουσας εικόνας παρουσίασης, χρησιμοποιήστε το [PPImage.replaceImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/ppimage/#replaceImage) με ένα [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Κλήση legacy | Μοντέρνη αντικατάσταση |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/el/python-java/aspose.slides/patternformat/#getTile) με `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/el/python-java/aspose.slides/patternformat/#getTile) με `background, foreground` |

Τα επιχειρήματα χρώματος παραμένουν αντικείμενα Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

Για τα αποτελεσματικά δεδομένα πατρόν που επιστρέφει το Java API μέσω JPype, η αντικατάσταση διατηρεί το όνομα `getTileIImage`.

| Κλήση legacy | Μοντέρνη αντικατάσταση |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, επιστρέφει [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/) |

## **Υποστήριξη API για Graphics2D**

Οι παλαιές υπερφορτώσεις `renderToGraphics` σχεδίαζαν σε παρεχόμενο από τον κλήστη πλαίσιο [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html). Το Μοντέρνο API δεν έχει άμεση αντικατάσταση που σχεδιάζει σε αυτό το πλαίσιο.

Χρησιμοποιήστε το [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) για απόδοση διαφάνειας ή το [Presentation.getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) για απόδοση πολλαπλών διαφανειών, στη συνέχεια αποθηκεύστε τις επιστρεφόμενες εικόνες με το [IImage.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/#save). Οι εφαρμογές που συνδύαζαν την απόδοση διαφανειών με προσαρμοσμένη σχεδίαση Java χρειάζεται να προσαρμόσουν το βήμα σύνθεσης.

## **Συχνές Ερωτήσεις**

**Γιατί αντικαταστάθηκε το παλιό API επεξεργασίας εικόνας Java;**

Το Μοντέρνο API μεταφέρει τη φόρτωση, απόδοση και αποθήκευση εικόνας στο [IImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/iimage/). Αυτό παρέχει μια κοινή αφαιρετική εικόνας αντί για την έκθεση Java buffered images ή ενός Java γραφικού πλαισίου.

**Χρειάζομαι ακόμα Java και JPype;**

Ναι. Το Aspose.Slides for Python via Java εξακολουθεί να τρέχει στην JVM. Το Μοντέρνο API αλλάζει μόνο τις κλήσεις επεξεργασίας εικόνας, όχι τις απαιτήσεις χρόνου εκτέλεσης. Δείτε τις [System Requirements](/slides/el/python-java/system-requirements/).

**Πώς απελευθερώνω εικόνες στην Python;**

Καλέστε τη μέθοδο `dispose` σε κάθε εικόνα που φορτώνετε ή αποδίδετε μέσα σε ένα μπλοκ `finally`. Εάν αποδίδετε πολλές διαφάνειες, απελευθερώστε κάθε εικόνα στον επιστρεφόμενο πίνακα. Απελευθερώστε την παρουσίαση ξεχωριστά με το [Presentation.dispose](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#dispose).

**Η μετάβαση στο Μοντέρνο API εγγυάται ταχύτερη δημιουργία μικρογραφιών;**

Δεν εγγυάται βελτίωση απόδοσης. Οι αντικαταστάσεις υποστηρίζουν επιλογές απόδοσης, κλίμακα και μεγέθη εικόνας· μετρήστε την απόδοση με τις δικές σας παρουσιάσεις και ρυθμίσεις εξόδου.

**Γιατί ο αποδέκτης εικόνας μερικές φορές επιστρέφει συλλογή;**

Το [Presentation.getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) χωρίς επιχειρήματα επιστρέφει ενσωματωμένες εικόνες της παρουσίασης. Οι υπερφορτώσεις του με επιλογές απόδοσης επιστρέφουν αποδοθείσες εικόνες διαφανειών.