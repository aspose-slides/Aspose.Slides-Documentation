---
title: Δημιουργία 3Δ Εφέ σε Παρουσιάσεις με Python
linktitle: 3Δ Παρουσίαση
type: docs
weight: 232
url: /el/python-net/3d-presentation/
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
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο του PowerPoint σε Python με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Aspose.Slides for Python via .NET μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3Δ τύπου PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, λοξότμηση, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, καθώς και 3Δ κείμενο.

{{% alert color="info" title="Σημείωση" %}}

Αυτό το άρθρο αφορά εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο του PowerPoint. Δεν αφορά εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων 3Δ μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη 2Δ έξοδο.

{{% /alert %}}

## **Έννοιες Μορφοποίησης 3Δ**

Χρησιμοποιήστε την ιδιότητα [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η ιδιότητα αποκαλύπτει το [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/), το οποίο ελέγχει τη σκηνή 3Δ για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε την ιδιότητα [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές ιδιότητες είναι:

| Ιδιότητα | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Προοπτική, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στο 3Δ χώρο ή ταιριάξτε μια προεπιλογή περιστροφής 3Δ του PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε πώς εμφανίζονται οι αντανακλάσεις και οι σκιές στην επιφάνεια 3Δ. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε τη γεωμετρία να φαίνεται πιο επίπεδη, μαλακότερη, γυαλιστερή ή μεταλλική. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Πόσο πολύ το σχήμα εκτείνεται προς τα πίσω από την πρόσοψη του. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3Δ αντικείμενο. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Χρώμα των εξωθημένων πλευρών. | Καταστήστε το βάθος ορατό ή εναρμονίστε το χρώμα των πλευρών με το γέμισμα της πρόσοψης. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | Επιπλέον 3Δ βάθος που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ιδιαίτερα μαζί με τις ρυθμίσεις λοξότμησης και υλικού. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) και [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Ανυψωμένες ή στρογγυλεμένες άκρες στην πρόσοψη και στην πίσω πλευρά. | Προσθέστε μια μαλακιά ή διαμορφωμένη άκρη αντί για μια αιχμηρή επίπεδη επιφάνεια. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) και [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Περίγραμμα γύρω από το 3Δ αντικείμενο. | Τονίστε το όριο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία 3Δ Σχήματος**

Ένα σχήμα συνήθως απαιτεί τέσσερα είδη ρυθμίσεων προτού φαίνεται πειστικά τρισδιάστατο:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προβολή από μπροστά μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τα πρόσοψη και τις πλευρές αναγνώσιμα.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην πρόσοψή του και εφαρμόζει μορφοποίηση 3Δ. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 100 μονάδες. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG με διπλάσιες από προεπιλογή διαστάσεις και αποθηκεύει την παρουσίαση ως PPTX.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

Η αποδοθείσα εικόνα της διαφάνειας παρουσιάζει το ορθογώνιο ως ένα παχύ 3Δ μπλοκ:

![Αποδοθείσα μπλε 3Δ ορθογώνιο με λευκό 3Δ κείμενο στην πρόσοψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η περιστροφή 3Δ ρυθμίζεται από το πάνελ 3‑Δ Περιστροφή. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στη περιστροφή που ορίζετε μέσω του API της κάμερας.

![Πάνελ 3‑Δ Περιστροφή του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, αποκτήστε πρόσβαση στην κάμερα μέσω του [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική προβολή από μπροστά και ορίζει τις περιστροφές X, Y, Z στα 20, 30 και 40 μοίρες αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής αντιλαμβάνεται το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει την 3Δ προοπτική που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

### **Αντιγραφή Προσανατολισμού Κάμερας από Σχέδιο Προτύπου**

Για να ταιριάξετε τον προσανατολισμό ενός σχήματος προτύπου, αντιγράψτε το προεπιλεγμένο [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) και διαβάστε την περιστροφή του με το [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). Το παράδειγμα ανοίγει το `template.pptx` και αντιγράφει τον προσανατολισμό κάμερας από το πρώτο σχήμα της πρώτης διαφάνειας στο δεύτερο σχήμα. Και τα δύο σχήματα έχουν ήδη 3Δ φωτισμό, ενώ το δεύτερο σχήμα δεν έχει ρητή περιστροφή κάμερας.

Οι γωνίες είναι σε μοίρες. Οι δείκτες `0`, `1` και `2` αντιστοιχούν στο γεωγραφικό πλάτος, το γεωγραφικό μήκος και την περιδέραια αντίστοιχα. Περνάστε τα στο [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) με αυτή τη σειρά. Αν η πηγή δεν έχει ρητή περιστροφή, το `get_rotation` επιστρέφει `None`, οπότε αφήστε τις γωνίες προορισμού ακαθορισμένες. Αν η πηγή ορίζει όλες τις τρεις γωνίες στο μηδέν, αντιγράψτε αυτά τα μηδενικά.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

Όταν ξανανοιώσετε το `camera-copy.pptx` στο PowerPoint, και τα δύο σχήματα έχουν το ίδιο προεπιλεγμένο κάμερας και περιστροφή. Το βέλος στα δεξιά χρησιμοποιεί τον προσανατολισμό που αντιγράφηκε από το ορθογώνιο στα αριστερά. Και τα δύο σχήματα χρησιμοποιούν το ίδιο φωτισμό και βάθος εξώθησης.

![Μπλε 3Δ ορθογώνιο και δεξί βέλος με ταυτοπαθή προσανατολισμό κάμερας, προβολή από επάνω και δεξιά](camera-orientation.png)

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντας το πίσω από την πρόσοψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτήν τη ορατή πάχος, ενώ ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint αντιστοιχισμένοι σε ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Ορίστε το [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) για το πάχος και το [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) για το χρώμα των πλευρών. Αυτό το παράδειγμα δίνει στο ορθογώνιο εξώθηση 100 μονάδων με μοβ πλευρές και περιστρέφει την κάμερα για να αποδείξει το πάχος. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Η ιδιότητα [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) ορίζει το βάθος ενός 3Δ σχήματος. Η ιδιότητα [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβάθμισης ή Γεμίσματος Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην πρόσοψη και να συνεχίσετε να χρησιμοποιείτε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση από μπλε σε πορτοκαλί στην πρόσοψη και ένα σκούρο πορτοκαλί χρώμα στην εξώθηση 150 μονάδων. Οι στάσεις διαβάθμισης στο 0 και 100 σηματοδοτούν την έναρξη και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλάσιες από προεπιλογή διαστάσεις:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

Η αποδοθείσα έξοδος διατηρεί τη διαβάθμιση στην πρόσοψη και αποδίδει την εξώθηση ξεχωριστά:

![Αποδοθείσα 3Δ ορθογώνιο με διαβάθμιση γέμισμα μπλε‑πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας αντί αυτού, προσθέστε την εικόνα στην παρουσίαση και αναθέστε την στο γέμισμα του σχήματος. Αυτό το παράδειγμα απαιτεί υπάρχον αρχείο με όνομα «image.jpg» στον τρέχοντα φάκελο. Τονίζει την εικόνα ώστε να καλύψει το ορθογώνιο, εφαρμόζει εξώθηση 150 μονάδων και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Η εικόνα αποδίδεται στην πρόσοψη, ενώ η εξώθηση αποδίδεται ως η 3Δ πλευρική επιφάνεια:

![Αποδοθείσα 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην πρόσοψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το επόμενο παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί‑λευκό, εφαρμόζει ένα τόξο προς τα πάνω και διαμορφώνει τις ρυθμίσεις 3Δ μέσω του [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Το ύψος εξώθησης και το βάθος είναι σε μονάδες, και η περιστροφή του φωτός είναι σε μοίρες. Το γέμισμα και το περίγραμμα του σχήματος κρύβονται ώστε να είναι ορατό μόνο το κείμενο. Το παράδειγμα αποδίδει μια εικόνα PNG με διπλάσιες από προεπιλογή διαστάσεις διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

Το κείμενο αποδίδεται ως καμπύλες, εξωθήσεις 3Δ γράμματα:

![Αποδοθείσα 3Δ κείμενο με τόξο WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση Επίπεδου Κειμένου σε 3Δ Σχήμα**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείται η 3Δ εμφάνιση του σχήματος, ορίστε το [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) μέσω του [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). Όταν η τιμή είναι `True`, το κείμενο παραμένει εκτός της σκηνής 3Δ. Όταν είναι `False`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3Δ προσανατολισμό.

Αυτή η ρύθμιση δεν αφαιρεί τη μορφοποίηση 3Δ του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν διαμορφωμένα μέσω του [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/). Είναι επίσης διαφορετικό από την απλή περιστροφή. Η [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ η [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου εντός του πλαισίου του. Η διατήρηση του κειμένου εκτός της σκηνής 3Δ δεν επαναφέρει καμία από αυτές τις γωνίες.

Το παρακάτω αυτό-συνεπές παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια μορφοποίηση 3Δ· μόνο η ρύθμιση κειμένου διαφέρει: `False` στα αριστερά και `True` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες, και το ύψος εξώθησης είναι 40 μονάδες. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG με διπλάσιες από προεπιλογή διαστάσεις.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

Στα αριστερά, το κείμενο ακολουθεί τον 3Δ προσανατολισμό. Στα δεξιά, μένει επίπεδο και πιο εύκολο στην ανάγνωση. Και τα δύο ορθογώνια διατηρούν το ίδιο ορατό βάθος εξώθησης και τον ίδιο 3Δ προσανατολισμό.

![Δύο 3Δ ορθογώνια με keep_text_flat: False στα αριστερά, True στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ όταν αποθηκεύει σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές στατικού περιεχομένου, η σκηνή 3Δ ρεναριστά ή σχεδιάζεται στην έξοδο ως 2Δ αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/python-net/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/python-net/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/python-net/convert-powerpoint-to-video/).

Λάβετε υπόψη τα εξής:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης διαφάνειας.
- Αν χρειάζεστε να ελέγξετε κληρονομημένες ή βάσει θέματος τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/python-net/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σελίδες διαδραστικές 3Δ σκηνές που ο θεατής να μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3Δ μοντέλου και ενός 3Δ εφέ;**

Ένα 3Δ μοντέλο είναι ένα ξεχωριστό 3Δ αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3Δ εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξότμηση, φωτισμός και υλικό. Το άρθρο αυτό καλύπτει 3Δ εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3Δ σχήμα;**

Ελάχιστα, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης ένα φωτιστικό σύστημα και υλικό ώστε οι αποδοθείσες όψεις να έχουν καθαρές αντανακλάσεις και σκιές.

**Μπορώ να εφαρμόσω 3Δ εφέ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) για το σώμα του σχήματος και το [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) για το κείμενο.

**Θα εμφανιστούν τα 3Δ εφέ όταν εξάγονται σε εικόνες, PDF, HTML ή βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3Δ εφέ όταν παράγει εικόνες διαφανειών, PDF, HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3Δ αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3Δ τιμές μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/python-net/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λοξότμησης και σχετικών 3Δ τιμών.