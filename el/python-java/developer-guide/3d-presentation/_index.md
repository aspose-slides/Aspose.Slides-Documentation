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

Το Aspose.Slides για Python μέσω Java μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3Δ τύπου PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφές, εξώθηση, λοξές άκρες, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα με εικόνα, και κείμενο 3Δ.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ανεξάρτητων αρχείων μοντέλων 3Δ. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη 2Δ έξοδο.
{{% /alert %}}

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Εγκατάσταση](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει `asposeslides`, ξεκινά το JVM αν χρειάζεται και στη συνέχεια εισάγει το API. Το παράδειγμα γεμίσματος με εικόνα απαιτεί ένα αρχείο `image.jpg` στον τρέχοντα φάκελο εργασίας.

## **Έννοιες Μορφοποίησης 3Δ**

Χρησιμοποιήστε [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Το αντικείμενο μορφής που επιστρέφεται ελέγχει τη σκηνή 3Δ για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#getThreeDFormat). Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε χρησιμοποιείται |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getCamera) | Οπτική γωνία, προκαθορισμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστροφή του αντικειμένου σε χώρο 3Δ ή αντιστοίχιση με προκαθορισμένη περιστροφή 3Δ του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getLightRig) | Προκαθορισμένος φως, κατεύθυνση και περιστροφή φωτός. | Αλλαγή του τρόπου εμφάνισης των φωτεινών σημείων και των σκιών στην επιφάνεια 3Δ. |
| [getMaterial](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getMaterial) και [setMaterial](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setMaterial) | Υλικό επιφανείας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάναμε το ίδιο γεωμετρικό σχήμα να φαίνεται πιο επίπεδο, μαλακό, γυαλιστερό ή μεταλλικό. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getExtrusionHeight) και [setExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την εμπρός όψη του. | Μετατροπή ενός επίπεδου σχήματος σε ορατά παχύ 3Δ αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getExtrusionColor) | Χρώμα των εξωθημένων πλευρών. | Κατασκευή οπτικής βάθους ή συντονισμός του χρώματος των πλευρών με το εμπρός γέμισμα. |
| [getDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getDepth) και [setDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setDepth) | Πρόσθετο βάθος 3Δ που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Λεπτομερής ρύθμιση του βάθους για σχήματα ή κείμενο, ειδικά μαζί με ρυθμίσεις λοξής άκρης και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getBevelTop) και [getBevelBottom](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getBevelBottom) | Ανυψωμένες ή στρογγυλεμένες άκρες στις εμπρός και πίσω όψεις. | Προσθήκη μαλακής ή μορφοποιημένης άκρης αντί για οξεία επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getContourWidth) και [setContourWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setContourWidth) | Περιγράμματα γύρω από το 3Δ αντικείμενο. | Έμφαση στα όρια του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία Σχήματος 3Δ**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν δείχνει πειστικά τρισδιάστατο:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει το πώς αποδίδεται το φως.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το ακόλουθο παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρός όψη του, εφαρμόζει μορφοποίηση 3Δ, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

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

Η αποδιδόμενη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως παχύ 3Δ μπλοκ:

![Απόδοση μπλε 3Δ ορθογωνίου με λευκό 3Δ κείμενο στην εμπρός όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η περιστροφή 3Δ ρυθμίζεται από το πλαίσιο 3‑Δ Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Πλαίσιο 3‑Δ Rotation του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και την περιστροφή μέσω της μορφοποίησης 3Δ που επιστρέφει η [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat):

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

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει το 3Δ σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από την εμπρός όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint χαρτογραφημένοι σε ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

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

Χρησιμοποιήστε τη ρύθμιση βάθους όταν χρειάζεται να εργαστείτε άμεσα με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με λοξή άκρη, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το ύψος εξώθησης είναι η πιο ξεκάθαρη ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση Διαβαθμίσεων ή Γεμίσματος Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην εμπρός όψη και να συνεχίσετε να χρησιμοποιείτε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει μια διαβάθμιση στο σχήμα και ένα πιο σκούρο χρώμα εξώθησης στις πλευρές:

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

Η αποδιδόμενη έξοδος διατηρεί τη διαβάθμιση στην εμπρός όψη και αποδίδει την εξώθηση ξεχωριστά:

![Απόδοση 3Δ ορθογωνίου με διαβάθμιση μπλε‑προσωπικού και εξώθηση πορτοκαλί](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας αντίγια, προσθέστε την εικόνα στην παρουσίαση και αντιστοιχίστε την στο γέμισμα σχήματος:

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

Η εικόνα αποδίδεται στην εμπρός όψη, ενώ η εξώθηση αποδίδεται ως η τρισδιάστατη πλευρική επιφάνεια:

![Απόδοση 3Δ ορθογωνίου με γέμισμα φωτογραφίας στην εμπρός όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα απαιτούν εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και ρυθμίζει ρυθμίσεις 3Δ στην [TextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/):

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

Το κείμενο αποδίδεται ως καμπυλωτά, εξωθημένα 3Δ γράμματα:

![Απόδοση 3Δ κειμένου με κυρτό μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ όταν αποθηκεύεται σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η σκηνή 3Δ ριζοσπαστιζείται ή σχεδιάζεται στην έξοδο ως 2Δ αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε PNG, εξάγετε σε PDF, εξάγετε σε HTML ή δημιουργείτε καρέ για μετατροπή βίντεο.

Να θυμάστε τα εξής:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτιστικού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης διαφάνειας.
- Εάν χρειάζεστε να ελέγξετε κληρονομημένες ή θεματικές τιμές μορφοποίησης, χρησιμοποιήστε το API αποτελεσματικής μορφοποίησης.
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σελίδες διαδραστικές 3Δ σκηνές που ο θεατής μπορεί να περιστρέψει. Στο PPTX η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όταν η μορφή την υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3Δ μοντέλου και ενός 3Δ εφέ;**

Ένα 3Δ μοντέλο είναι ένα ξεχωριστό 3Δ αντικείμενο που εισάγεται στην παρουσίαση. Ένα 3Δ εφέ είναι μορφοποίηση που εφαρμόζεται σε κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξή άκρη, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει εφέ 3Δ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3Δ σχήμα;**

Ελάχιστα, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτιστικό και υλικό ώστε οι αποδοθείσες όψεις να έχουν σαφή αντανάκλαση και σκιές.

**Μπορώ να εφαρμόσω εφέ 3Δ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat) για το σώμα του σχήματος και [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#getThreeDFormat) για το κείμενο.

**Θα εμφανίζονται τα εφέ 3Δ όταν εξάγονται σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα εφέ 3Δ όταν παράγει εικόνες διαφάνειας, έξοδο PDF, έξοδο HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδιδόμενη εμφάνιση, όχι ένα επεξεργάσιμο 3Δ αντικείμενο.

**Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε το [ThreeDFormat.getEffective](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getEffective) για να διαβάσετε τις τελικές τιμές κάμερας, φωτιστικού, λοξής άκρης και συναφείς τιμές 3Δ.