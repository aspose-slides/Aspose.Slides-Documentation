---
title: Δημιουργία 3Δ Εφέ σε Παρουσιάσεις Χρησιμοποιώντας Python
linktitle: 3Δ Παρουσίαση
type: docs
weight: 232
url: /el/python-java/3d-presentation/
keywords:
- 3Δ PowerPoint
- 3Δ παρουσίαση
- 3Δ περιστροφή
- 3Δ βάθος
- 3Δ εξώθηση
- 3Δ διαβάθμιση
- 3Δ κείμενο
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε Python μέσω Java με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω Java μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, κλίσεις, φωτισμό, υλικό, γεμίσματα διαβάθμισης ή εικόνας και κείμενο 3Δ.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ανεξάρτητων αρχείων μοντέλων 3Δ. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαχθείσα 2Δ έξοδο.
{{% /alert %}}

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides`, ξεκινά το JVM εάν είναι απαραίτητο και στη συνέχεια εισάγει το API. Το παράδειγμα γεμίσματος εικόνας απαιτεί ένα αρχείο `image.jpg` στον τρέχοντα φάκελο.

## **Αρχές Μορφοποίησης 3Δ**

Χρησιμοποιήστε το [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Το επιστρεφόμενο αντικείμενο μορφοποίησης ελέγχει τη σκηνή 3Δ για αυτό το σχήμα.

Για κείμενο, χρησιμοποιήστε το [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#getThreeDFormat). Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη API είναι:

| Μέλος API | Τι ελέγχει | Πότε χρησιμοποιείται |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getCamera) | Οπτική γωνία, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε χώρο 3Δ ή ταιριάξτε μια προεπιλογή περιστροφής 3Δ του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getLightRig) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο με τον οποίο εμφανίζονται οι αντανακλάσεις και οι σκιές στην επιφάνεια 3Δ. |
| [getMaterial](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setMaterial) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε τη γεωμετρία να φαίνεται πιο επίπεδη, πιο μαλακή, γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την εμπρόσθια όψη του. | Μετατρέψτε ένα επίπεδο σχήμα σε ορατά παχύ 3Δ αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getExtrusionColor) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το εμπρόσθιο γέμισμα. |
| [getDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setDepth) | Επιπλέον βάθος 3Δ που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ιδιαίτερα μαζί με ρυθμίσεις κλίσεων και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getBevelBottom) | Ανασηκωμένες ή στρογγυλεμένες άκρες στις εμπρόσθιες και οπίσθιες όψεις. | Προσθέστε μια απαλυμένη ή διαμορφωμένη άκρη αντί για μια αιχμηρή επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setContourWidth) | Περίγραμμα γύρω από το αντικείμενο 3Δ. | Τονίστε το όριο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία Σχήματος 3Δ**

Ένα σχήμα συνήθως χρειάζεται τέσσερα είδη ρυθμίσεων πριν εμφανιστεί πειστικά ως 3Δ:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές ευανάγνωστες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο αποτύπωσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρόσθια του όψη, εφαρμόζει μορφοποίηση 3Δ, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αποδοθείσα εικόνα της διαφάνειας εμφανίζει το ορθογώνιο ως ένα παχύ 3Δ μπλοκ:

![Αποδοχή μπλε 3Δ ορθογωνίου με λευκό 3Δ κείμενο στην εμπρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3Δ περιστροφή ρυθμίζεται από το παράθυρο 3-D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API κάμερας.

![Παράθυρο 3-D Rotation του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο της κάμερας και τη περιστροφή μέσω της μορφοποίησης 3Δ που επιστρέφεται από το [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει τη 3Δ προοπτική που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντας το πίσω από την εμπρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint χαρτογραφημένοι στα χαρακτηριστικά χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Ορίστε το ύψος εξώθησης για το πάχος και το χρώμα εξώθησης για το χρώμα των πλευρών:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Χρησιμοποιήστε τη ρύθμιση βάθους όταν χρειάζεται να δουλέψετε απευθείας με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με κλίσεις, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το ύψος εξώθησης είναι πιο σαφής ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση Διαβαθμίσεων ή Γεμίσεων Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από τη γέμιση του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέµιση εικόνας στην εμπρόσθια όψη και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει μια γέμιση διαβάθμισης στο σχήμα και ένα πιο σκούρο χρώμα εξώθησης στις πλευρές:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

Η αποδοθείσα έξοδος διατηρεί τη διαβάθμιση στην εμπρόσθια όψη και αποδίδει την εξώθηση ξεχωριστά:

![Αποδοχή 3Δ ορθογωνίου με γέμιση διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμιση εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε την στη γέμιση του σχήματος:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

![Αποδοχή 3Δ ορθογωνίου με φωτογραφική γέμιση στην εμπρόσθια όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμιση μοτίβου, εφαρμόζει μετασχηματισμό WordArt και ρυθμίζει τις ρυθμίσεις 3Δ στο [TextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Αποδοχή 3Δ κειμένου με καμπυλωτό μετασχηματισμό WordArt, πορτοκαλί γέμιση μοτίβου και σκοτεινή εξώθηση](img_02_05.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές στατικού σχεδίου, η σκηνή 3Δ μετατρέπεται σε ρευστό ή σχεδιάζεται στο αποτέλεσμα ως 2Δ αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε PNG, εξάγετε σε PDF, εξάγετε σε HTML ή δημιουργείτε καρέ για μετατροπή βίντεο.

- Οι εξαγόμενες εικόνες και PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτιστικού, υλικού, εξώθησης, γέμισης και κλιματισμού διαφάνειας.
- Εάν χρειάζεται να εξετάσετε τις κληρονομημένες ή βασισμένες στο θέμα τιμές μορφοποίησης, χρησιμοποιήστε το API αποτελεσματικής μορφοποίησης.
- Κάποιες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές παρουσιάσεις 3Δ;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν μετατρέπει τις εξαγόμενες εικόνες, PDF ή σελίδες HTML σε διαδραστικές σκηνές 3Δ που ο θεατής μπορεί να περιστρέψει. Στο PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή τη υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ μοντέλου 3Δ και εφέ 3Δ;**

Ένα μοντέλο 3Δ είναι ένα ξεχωριστό αντικείμενο 3Δ που εισάγεται στην παρουσίαση. Ένα εφέ 3Δ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, κλίση, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει εφέ 3Δ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό σχήμα 3Δ;**

Ως ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτιστικό και υλικό ώστε οι αποδοθείσες όψεις να έχουν καθαρές αντανακλάσεις και σκιές.

**Μπορώ να εφαρμόσω εφέ 3Δ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape.getThreeDFormat] για το σώμα του σχήματος και το [TextFrameFormat.getThreeDFormat] για το κείμενο.

**Θα εμφανιστούν τα εφέ 3Δ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα εφέ 3Δ όταν παράγει εικόνες διαφανειών, έξοδο PDF, έξοδο HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδομένη εμφάνιση, όχι ένα επεξεργάσιμο αντικείμενο 3Δ.

**Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την εφαρμογή κληρονομικών και θεματικών ρυθμίσεων;**

Ναι. Χρησιμοποιήστε το [ThreeDFormat.getEffective] για να διαβάσετε τις τελικές τιμές κάμερας, φωτιστικού, κλίσης και σχετικές τιμές 3Δ.