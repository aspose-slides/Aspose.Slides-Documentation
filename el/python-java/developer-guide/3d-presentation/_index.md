---
title: Δημιουργία 3Δ Εφέ σε Παρουσιάσεις με Python
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

Aspose.Slides for Python via Java μπορεί να δημιουργήσει, επεξεργαστεί, διατηρήσει και αποδώσει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, λοξά, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και κείμενο 3Δ.

{{% alert color="info" title="Note" %}}
This article is about 3D formatting effects on PowerPoint shapes and text. It is not about inserting or editing standalone 3D model files. When you export a slide to an image, PDF, or HTML, Aspose.Slides renders those 3D effects into the exported 2D output.
{{% /alert %}}

## **Έννοιες Μορφοποίησης 3Δ**

Χρησιμοποιήστε τη μέθοδο [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η μέθοδος επιστρέφει το [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), το οποίο ελέγχει τη σκηνή 3Δ για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Σημείο θέασης, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε χώρο 3Δ ή ταιριάξτε μια προεπιλεγμένη περιστροφή 3Δ του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε την εμφάνιση των φωτεινών σημείων και των σκιών στην επιφάνεια 3Δ. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία πιο επίπεδη, πιο μαλακή, πιο γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από τη μπροστινή πλευρά του. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3Δ αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Χρώμα των εξωτερικά εκθεισμένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με τη γέμιση του μπροστά. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Επιπλέον βάθος 3Δ που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ειδικά μαζί με ρυθμίσεις λοξά και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Ανασηκωμένα ή στρογγυλεμένα άκρα στις μπροστινές και πίσω πλευρές. | Προσθέστε ένα απαλυνόμενο ή αψυγμένο άκρο αντί για μια αιχμηρή επίπεδη πλευρά. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Περίγραμμα γύρω από το αντικείμενο 3Δ. | Τονίστε το όριο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία 3Δ Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις κατηγορίες ρυθμίσεων πριν φαίνεται πειστικά 3Δ:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη πρόσοψη ενδέχεται να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις πλευρές και τις όψεις αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει πώς αποδίδεται το φως.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρόσθια πλευρά του και εφαρμόζει μορφοποίηση 3Δ. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 100 μονάδες. Το παράδειγμα αποδίδει τη διαφάνειά σε εικόνα PNG με διπλάσια προεπιλεγμένα διαμέτρα και αποθηκεύει την παρουσίαση ως PPTX.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

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

Η αποδοθείσα εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3Δ μπλοκ:

![Αποδιδόμενο μπλε 3Δ ορθογώνιο με λευκό 3Δ κείμενο στην εμπρόσθια πλευρά](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η περιστροφή 3Δ ρυθμίζεται από το παράθυρο 3‑D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3‑D Rotation του PowerPoint με επισημασμένες τιμές περιστροφής X, Y, Z](img_02_01.png)

Στο Aspose.Slides, προσπελάστε την κάμερα μέσω του [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική άποψη πρόσοψης και ορίζει τις περιστροφές X, Y, Z στα 20, 30 και 40 μοίρες αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

### **Αντιγραφή Προσανατολισμού Κάμερας από Σχήμα Προτύπου**

Για να ταιριάξετε τον προσανατολισμό ενός σχήματος προτύπου, διαβάστε την προεπιλογή κάμερας με το [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) και τις γωνίες περιστροφής με το [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). Το παράδειγμα ανοίγει το `template.pptx` και αντιγράφει τον προσανατολισμό κάμερας από το πρώτο σχήμα της πρώτης διαφάνειας στο δεύτερο σχήμα. Και τα δύο σχήματα έχουν ήδη 3Δ φωτισμό, ενώ το δεύτερο σχήμα δεν έχει ρητή περιστροφή κάμερας.

Οι γωνίες είναι σε μοίρες. Δείκτης `0` είναι γεωγραφικό πλάτος, δείκτης `1` είναι γεωγραφικό μήκος, και δείκτης `2` είναι επανάληψη. Περάστε τα στη μέθοδο [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) με αυτή τη σειρά. Αν η πηγή επιστρέψει `None`, δεν υπάρχει ρητή περιστροφή, οπότε αφήστε τις γωνίες του δεύτερου σχήματος ακαθόριστες. Μια ρητή περιστροφή `(0, 0, 0)` επιστρέφει τρία μηδενικά και πρέπει να αντιγραφεί.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Όταν ανοίξετε ξανά το `camera-copy.pptx` στο PowerPoint, το βέλος δεξιά έχει την ίδια προεπιλογή κάμερας και περιστροφή με το ορθογώνιο αριστερά. Και τα δύο σχήματα χρησιμοποιούν τον ίδιο φωτισμό και βάθος εξώθησης.

![Μπλε 3Δ ορθογώνιο και δεξιό βέλος με αντίστοιχο προσανατολισμό κάμερας, προβλήματα από πάνω και δεξιά](camera-orientation.png)

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντας το από την εμπρόσθια πλευρά. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτήν την ορατή πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint χαρτογραφημένοι σε ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Χρησιμοποιήστε τη μέθοδο [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) για να ορίσετε το πάχος και τη μέθοδο [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) για πρόσβαση στο χρώμα των πλευρών. Αυτό το παράδειγμα δίνει σε ένα ορθογώνιο εξώθηση 100 μονάδες με μοβ πλευρές και περιστρέφει την κάμερα για να αποκαλύψει το πάχος. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Η μέθοδος [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) ορίζει το βάθος ενός 3Δ σχήματος. Η μέθοδος [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβάθμισης ή Γεμίσματος Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε στερεό χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην εμπρόσθια πλευρά και να διατηρήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση από μπλε σε πορτοκαλί στην εμπρόσθια πλευρά και σκούρο πορτοκαλί χρώμα στην εξώθηση 150 μονάδων. Τα σημεία διαβάθμισης στο 0 και 100 σηματοδοτούν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλάσια προεπιλεγμένα διαμέτρα:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

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

Το αποδοθέν αποτέλεσμα διατηρεί τη διαβάθμιση στην εμπρόσθια πλευρά και αποδίδει την εξώθηση ξεχωριστά:

![Αποδιδόμενο 3Δ ορθογώνιο με διαβάθμιση μπλε‑πορτοκαλί και εξώθηση πορτοκαλί](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε την στο γέμισμα του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα “image.jpg” στον τρέχοντα φάκελο. Τεντώνει την εικόνα ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εξώθηση 150 μονάδων και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Η εικόνα αποδίδεται στην εμπρόσθια πλευρά, ενώ η εξώθηση αποδίδεται ως η 3Δ πλευρική επιφάνεια:

![Αποδιδόμενο 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην εμπρόσθια πλευρά και εξώθηση πορτοκαλί](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ παρόμοια με WordArt, όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πορτοκαλί‑λευκό πλέγμα, εφαρμόζει ένα αρχι φακό προς τα πάνω και διαμορφώνει ρυθμίσεις 3Δ μέσω του [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Το ύψος εξώθησης και το βάθος είναι σε μονάδες, και η περιστροφή φωτός σε μοίρες. Το γέμισμα σχήματος και το περίγραμμα κρύβονται ώστε να είναι ορατό μόνο το κείμενο. Το παράδειγμα αποδίδει εικόνα PNG με διπλάσια προεπιλεγμένα διαμέτρα της διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

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

![Αποδιδόμενο 3Δ κείμενο με αρχι φάση WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση Κειμένου Επίπεδου σε 3Δ Σχήμα**

Για να παραμείνει το κείμενο ευανάγνωστο ενώ διατηρείται η 3Δ εμφάνιση του σχήματος, καλέστε το [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) μέσω του [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). Όταν η τιμή είναι `True`, το κείμενο παραμένει εκτός της 3Δ σκηνής. Όταν είναι `False`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3Δ προσανατολισμό.

Αυτή η ρύθμιση δεν αφαιρεί τη μορφοποίηση 3Δ του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). Είναι επίσης διαφορετικό από την κοινή περιστροφή. Το [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ το [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της 3Δ σκηνής δεν επαναφέρει καμία από αυτές τις γωνίες.

Το παρακάτω αυτόματο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια μορφοποίηση 3Δ· μόνο η ρύθμιση κειμένου διαφέρει: `False` αριστερά και `True` δεξιά. Οι γωνίες κάμερας είναι σε μοίρες και το ύψος εξώθησης 40 μονάδες. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG με διπλάσια προεπιλεγμένα διαμέτρα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Στα αριστερά, το κείμενο ακολουθεί τον 3Δ προσανατολισμό. Στα δεξιά, παραμένει επίπεδο και πιο εύκολο στην ανάγνωση. Και τα δύο ορθογώνια διατηρούν την ίδια ορατή εξώθηση και 3Δ προσανατολισμό.

![Δύο πλάσι 3Δ ορθογώνια: κείμενο ακολουθεί τον 3Δ προσανατολισμό στα αριστερά και παραμένει επίπεδο στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές στατικών σελίδων, η 3Δ σκηνή ραστεριάζεται ή σχεδιάζεται στην έξοδο ως 2Δ αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/python-java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/python-java/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [μετατροπή βίντεο](/slides/el/python-java/convert-powerpoint-to-video/).

Κρατήστε αυτά τα σημεία στο μυαλό:

- Οι εξαγόμενες εικόνες και PDF δεν είναι διαδραστικές. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης διαφάνειας.
- Αν χρειάζεται να ελέγξετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/python-java/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν δημιουργεί διαδραστικές 3Δ σκηνές σε εξαγόμενες εικόνες, PDF ή σελίδες HTML που ο θεατής να μπορεί να περιστρέφει. Σε PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3Δ μοντέλου και 3Δ εφέ;**

Ένα 3Δ μοντέλο είναι ένα ξεχωριστό 3Δ αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3Δ εφέ είναι μορφοποίηση που εφαρμόζεται σε κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξό, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει 3Δ εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ορατό 3Δ σχήμα;**

Στο ελάχιστο, ορίστε περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδοθείσες όψεις να έχουν καθαρά φωτισμούς και σκιές.

**Μπορώ να εφαρμόσω εφέ 3Δ σε σχήματα και κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) για το σώμα του σχήματος και το [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) για το κείμενο.

**Θα εμφανιστούν τα εφέ 3Δ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα εφέ 3Δ όταν παράγει εικόνες διαφανειών, PDF, HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3Δ αντικείμενο.

**Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την κληρονομικότητα και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα API αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/python-java/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λοξού και σχετικών 3Δ τιμών.