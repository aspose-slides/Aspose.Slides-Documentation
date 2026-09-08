---
title: Δημιουργία 3D εφέ σε παρουσιάσεις χρησιμοποιώντας Python
linktitle: 3D παρουσίαση
type: docs
weight: 232
url: /el/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D παρουσίαση
- 3D περιστροφή
- 3D βάθος
- 3D εξώθηση
- 3D διαβάθμιση
- 3D κείμενο
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε Python μέσω Java με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3D κείμενο."
---
## **Επισκόπηση**

Aspose.Slides for Python via Java μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει 3D μορφοποίηση σε σχήματα και κείμενο τύπου PowerPoint. Αυτό το άρθρο καλύπτει 3D εφέ όπως περιστροφή, εξώθηση, λοξώσεις, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και 3D κείμενο.

{{% alert color="info" title="Σημείωση" %}}

Αυτό το άρθρο αφορά 3D εφέ μορφοποίησης σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία αυτόνομων αρχείων 3D μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα 3D εφέ στην εξαγόμενη 2D έξοδο.

{{% /alert %}}

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει `asposeslides`, εκκινεί το JVM αν χρειάζεται και, στη συνέχεια, εισάγει το API. Το παράδειγμα γεμίσματος εικόνας απαιτεί ένα αρχείο `image.jpg` στο τρέχον φάκελο.

## **Έννοιες 3D Μορφοποίησης**

Χρησιμοποιήστε το [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat) για να εφαρμόσετε 3D μορφοποίηση σε ένα σχήμα. Το επιστρεφόμενο αντικείμενο μορφής ελέγχει τη σκηνή 3D για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε το [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#getThreeDFormat). Αυτό εφαρμόζει 3D μορφοποίηση στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getCamera) | Θέση κάμερας, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστροφή του αντικειμένου στο 3D χώρο ή αντιστοίχηση με προεπιλεγμένη περιστροφή PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getLightRig) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλαγή του τρόπου που εμφανίζονται τα highlights και οι σκιές στην 3D επιφάνεια. |
| [getMaterial](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getMaterial) και [setMaterial](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setMaterial) | Υλικό επιφάνειας, π.χ. επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακή, λαμπερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getExtrusionHeight) και [setExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την πρόσθια όψη. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3D αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getExtrusionColor) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος εμφανές ή συντονίστε το χρώμα των πλευρών με το πρόσθιο γέμισμα. |
| [getDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getDepth) και [setDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setDepth) | Πρόσθετο βάθος 3D που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε το βάθος για σχήματα ή κείμενο, ειδικά μαζί με ρυθμίσεις λοξιάς και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getBevelTop) και [getBevelBottom](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getBevelBottom) | Ανασηκωμένα ή στρογγυλεμένα άκρα στις πρόσθιες και οπίσθιες όψεις. | Προσθέστε ένα μαλακό ή χωνευμένο άκρο αντί για μια αιχμηρή επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getContourWidth) και [setContourWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setContourWidth) | Περιγράμματα γύρω από το 3D αντικείμενο. | Τονίστε το όριο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία 3D Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν εμφανιστεί πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην πρόσθια όψη, εφαρμόζει 3D μορφοποίηση, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

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

Η αποδιδόμενη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3D μπλοκ:

![Αποδιδόμενο μπλε 3D ορθογώνιο με λευκό 3D κείμενο στην πρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το πλαίσιο 3‑D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API κάμερας.

![Πλαίσιο PowerPoint 3‑D Rotation με επισημασμένες τιμές X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και τη περιστροφή μέσω της 3D μορφής που επιστρέφει το [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat):

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

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει το 3D σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από την πρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, ενώ ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους PowerPoint συνδεδεμένοι με ιδιότητες χρώματος και ύψους εξώθησης](img_02_02.png)

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

Χρησιμοποιήστε τη ρύθμιση βάθους όταν πρέπει να εργαστείτε άμεσα με την τιμή βάθους του PowerPoint ή να συνδυάσετε βάθος με λοξιά, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το ύψος εξώθησης είναι η πιο ξεκάθαρη ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση Διαβάθμισης ή Γεμίσματος Εικόνας με 3D Εφέ**

Η 3D μορφοποίηση είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην πρόσθια όψη και να διατηρήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση στα σχήμα και σκούρο χρώμα εξώθησης στις πλευρές:

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

Η αποδιδόμενη έξοδος διατηρεί τη διαβάθμιση στην πρόσθια όψη και αποδίδει την εξώθηση χωριστά:

![Αποδιδόμενο 3D ορθογώνιο με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε την στο γέμισμα του σχήματος:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

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

Η εικόνα αποδίδεται στην πρόσθια όψη, ενώ η εξώθηση αποδίδεται ως η 3D πλευρική επιφάνεια:

![Αποδιδόμενο 3D ορθογώνιο με γέμισμα φωτογραφίας στην πρόσθια όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή 3D Μορφοποίησης σε Κείμενο**

Η 3D μορφοποίηση σχήματος επηρεάζει το σώμα του σχήματος. Η 3D μορφοποίηση κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και ρυθμίζει 3D ρυθμίσεις στο [TextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/):

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

Το κείμενο αποδίδεται ως καμπυλωτά, εξωθημένα 3D γράμματα:

![Αποδιδόμενο 3D κείμενο με καμπύλο μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη 3D μορφοποίηση κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές στατικών διατάξεων, η σκηνή 3D ραστεροποιείται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε PNG, εξάγετε σε PDF, εξάγετε σε HTML ή δημιουργείτε καρέ για μετατροπή βίντεο.

Να προσέχετε τα εξής:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλίμακας διαφάνειας.
- Εάν χρειάζεστε να ελέγξετε κληρονομούσες ή τιμές μορφοποίησης βάσει θέματος, χρησιμοποιήστε το API αποτελεσματικής μορφοποίησης.
- Κάποιες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη 3D μορφοποίηση PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3D ρυθμίσεις.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει 3D εφέ PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σε διαδραστικές 3D σκηνές που ένας θεατής μπορεί να περιστρέψει. Στο PPTX, η 3D μορφοποίηση παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3D μοντέλου και ενός 3D εφέ;**

Ένα 3D μοντέλο είναι ξεχωριστό 3D αντικείμενο που εισάγεται σε παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξιά, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει 3D εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Στο ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδοθείσες όψεις να έχουν καθαρά highlights και σκιές.

**Μπορώ να εφαρμόσω 3D εφέ σε σχήματα και κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat) για το σώμα του σχήματος και το [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#getThreeDFormat) για το κείμενο.

**Θα εμφανιστούν τα 3D εφέ όταν εξάγονται σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3D εφέ όταν παράγει εικόνες διαφανειών, PDF, HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδιδόμενη εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε το [ThreeDFormat.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getEffective) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λοξιάς και σχετικών 3D τιμών.