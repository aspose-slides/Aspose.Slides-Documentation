---
title: Δημιουργία 3D εφέ σε παρουσιάσεις χρησιμοποιώντας Python
linktitle: 3D Παρουσίαση
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
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε Python μέσω Java με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσεις και 3D κείμενο."
---
## **Επισκόπηση**

Aspose.Slides for Python via Java μπορεί να δημιουργήσει, να επεξεργαστεί, να διατηρήσει και να αποδώσει 3D μορφοποίηση τύπου PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3D όπως περιστροφή, εξώθηση, κλίση, φωτισμό, υλικό, διαβάθμιση ή γεμίση εικόνας, και 3D κείμενο.

{{% alert color="info" title="Note" %}}

Αυτό το άρθρο αφορά εφέ μορφοποίησης 3D σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων 3D μοντέλου. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαγόμενη 2D έξοδο.

{{% /alert %}}

## **Έννοιες 3D Μορφοποίησης**

Χρησιμοποιήστε τη μέθοδο [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat) για να εφαρμόσετε 3D μορφοποίηση σε ένα σχήμα. Η μέθοδος επιστρέφει το [ThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/), που ελέγχει τη 3D σκηνή για το σχήμα αυτό.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#getThreeDFormat). Αυτό εφαρμόζει 3D μορφοποίηση στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getCamera) | Οπτική γωνία, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε 3D χώρο ή ταιριάξτε μια προεπιλεγμένη περιστροφή 3D του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getLightRig) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο εμφάνισης των φωτεινών σημείων και των σκιών στην 3D επιφάνεια. |
| [getMaterial](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getMaterial) και [setMaterial](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setMaterial) | Υλικό επιφάνειας, π.χ. επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία πιο επίπεδη, μαλακότερη, γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getExtrusionHeight) και [setExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Πόσο πολύ το σχήμα εκτείνεται προς τα πίσω από την εμπρόσθια όψη. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα εμφανώς παχύ 3D αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getExtrusionColor) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή εναρμονίστε το χρώμα των πλευρών με τη γέμιση της εμπρόσθιας όψης. |
| [getDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getDepth) και [setDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setDepth) | Πρόσθετο 3D βάθος που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε το βάθος για σχήματα ή κείμενο, ιδίως μαζί με ρυθμίσεις κλίσης και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getBevelTop) και [getBevelBottom](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getBevelBottom) | Ανυψωμένες ή στρογγυλεμένες άκρες στις εμπρόσθιες και οπίσθιες όψεις. | Προσθέστε μια μαλμένη ή σχηματισμένη άκρη αντί για μια αιχμηρή επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getContourColor) και [getContourWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getContourWidth) και [setContourWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setContourWidth) | Περιγράμματα γύρω από το 3D αντικείμενο. | Τονίστε το σύνορο του αντικειμένου στην αποδοθείσα εικόνα. |

## **Δημιουργία 3D Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν να φαίνεται πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προβολή εμπρός μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρόσθια όψη του και εφαρμόζει 3D μορφοποίηση. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες, και το ύψος εξώθησης είναι 100 points. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG με διπλά τις προεπιλεγμένες διαστάσεις και αποθηκεύει την παρουσίαση ως PPTX.

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

Η παραγόμενη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3D μπλοκ:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το πλαίσιο 3‑D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στη περιστροφή που ορίζετε μέσω του API της κάμερας.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Στο Aspose.Slides, αποκτήστε πρόσβαση στην κάμερα μέσω του [ThreeDFormat.getCamera](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getCamera). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει μια ορθογώνια προβολή εμπρός και ορίζει τις περιστροφές X, Y, Z στα 20, 30 και 40 μοίρες αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει τη 3D οπτική γωνία που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ, επεκτείνοντάς το πίσω από την εμπρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, ενώ ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Χρησιμοποιήστε το [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setExtrusionHeight) για να ορίσετε το πάχος και το [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#getExtrusionColor) για πρόσβαση στο χρώμα των πλευρών. Αυτό το παράδειγμα δίνει στο ορθογώνιο εξώθηση 100 points με μωβ πλευρές και περιστρέφει την κάμερα ώστε να εμφανιστεί το πάχος. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Η μέθοδος [ThreeDFormat.setDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setDepth) ορίζει το βάθος ενός 3D σχήματος. Η μέθοδος [setExtrusionHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/threedformat/#setExtrusionHeight) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβαθμίσεων ή Γέμισης Εικόνας με 3D Εφέ**

Η 3D μορφοποίηση είναι ανεξάρτητη από τη γέμιση του σχήματος. Μπορείτε να εφαρμόσετε μονή χρώμα, διαβάθμιση, μοτίβο ή γέμιση εικόνας στην εμπρόσθια όψη και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει μια διαβάθμιση από μπλε σε πορτοκαλί στην εμπρόσθια όψη και χρώμα σκούρο πορτοκαλί στην εξώθηση 150 points. Οι στάσεις διαβάθμισης στα 0 και 100 σηματοδοτούν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλά τις προεπιλεγμένες διαστάσεις:

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

Η παραγόμενη έξοδος διατηρεί τη διαβάθμιση στην εμπρόσθια όψη και αποδίδει την εξώθηση ξεχωριστά:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Για χρήση γέμισης εικόνας, προσθέστε την εικόνα στην παρουσίαση και αντιστοιχίστε την στη γέμιση του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα "image.jpg" στον κατάλογο εργασίας. Τεντώνει την εικόνα ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εξώθηση 150 points και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

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

Η εικόνα αποδίδεται στην εμπρόσθια όψη, ενώ η εξώθηση αποδίδεται ως η 3D πλευρική επιφάνεια:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Εφαρμογή 3D Μορφοποίησης σε Κείμενο**

Η 3D μορφοποίηση σχήματος επηρεάζει το σώμα του σχήματος. Η 3D μορφοποίηση κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί‑άσπρο, εφαρμόζει ένα αρχικό τόξο και διαμορφώνει ρυθμίσεις 3D μέσω του [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#getThreeDFormat). Το ύψος εξώθησης και το βάθος είναι σε points, και η περιστροφή φωτός σε μοίρες. Η γέμιση και το περίγραμμα του σχήματος κρύβονται ώστε να είναι ορατό μόνο το κείμενο. Το παράδειγμα αποδίδει μια εικόνα PNG με διπλά τις προεπιλεγμένες διαστάσεις διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

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

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Διατήρηση Κειμένου Επίπεδου σε 3D Σχήμα**

Για να παραμείνει το κείμενο ευανάγνωστο ενώ διατηρείται η 3D εμφάνιση του σχήματος, καλέστε το [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setKeepTextFlat) μέσω του [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getTextFrameFormat). Όταν η τιμή είναι `True`, το κείμενο παραμένει εκτός της 3D σκηνής. Όταν είναι `False`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3D προσανατολισμό.

Αυτή η ρύθμιση δεν αφαιρεί τη 3D μορφοποίηση του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat). Επίσης διαφέρει από την κοινή περιστροφή. Η μέθοδος [Shape.setRotation](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setRotation) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ η [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setRotationAngle) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός 3D σκηνής δεν επαναφέρει καμία από αυτές τις γωνίες.

Το παρακάτω αυτοσχέδιο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το αντιγράφει δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια 3D μορφοποίηση· μόνο η ρύθμιση κειμένου διαφέρει: `False` στα αριστερά και `True` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 40 points. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG με διπλά τις προεπιλεγμένες διαστάσεις.

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

Στα αριστερά, το κείμενο ακολουθεί τον 3D προσανατολισμό. Στα δεξιά, παραμένει επίπεδο και πιο εύκολο στην ανάγνωση. Και τα δύο ορθογώνια διατηρούν την ίδια ορατή εξώθηση και 3D προσανατολισμό.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη 3D μορφοποίηση όταν αποθηκεύει σε μορφές PowerPoint όπως PPTX. Όταν αποδίδει ή εξάγει σε μορφές σταθερής διάταξης, η 3D σκηνή ραστεροποιείται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/python-java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/python-java/convert-powerpoint-to-html/), ή δημιουργείτε πλαίσια για [μετατροπή βίντεο](/slides/el/python-java/convert-powerpoint-to-video/).

Να θυμάστε τα εξής:

- Οι εξαγώμενες εικόνες και PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γέμισης και κλιμάκωσης της διαφάνειας.
- Εάν χρειάζεστε να ελέγξετε κληρονομημένες ή θεματικές τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/python-java/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη 3D μορφοποίηση PowerPoint. Σε αυτές τις μορφές το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3D ρυθμίσεις.

## **ΣΥΝΗΘΕΣΕΙΣ (FAQ)**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει τα 3D εφέ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγώμενες εικόνες, PDF ή HTML σελίδες διαδραστικές 3D σκηνές που ο θεατής μπορεί να περιστρέψει. Σε PPTX, η 3D μορφοποίηση παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3D μοντέλου και 3D εφέ;**

Ένα 3D μοντέλο είναι ξεχωριστό 3D αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, κλίση, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει 3D εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Το ελάχιστο είναι να ορίσετε περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδοθείσες όψεις να έχουν σαφή ανάγνωση φωτεινών σημείων και σκιών.

**Μπορώ να εφαρμόσω 3D εφέ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getThreeDFormat) για το σώμα του σχήματος και το [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#getThreeDFormat) για το κείμενο.

**Θα εμφανιστούν τα 3D εφέ κατά την εξαγωγή σε εικόνες, PDF, HTML ή πλαίσια βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3D εφέ όταν παράγει εικόνες διαφανειών, PDF, HTML και πλαίσια που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγώμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την κληρονόμηση και τις θεματικές ρυθμίσεις;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/python-java/shape-effective-properties/) για να διαβάσετε τελικές τιμές κάμερας, φωτισμού, κλίσης και σχετικών 3D τιμών.