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
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε Python με το Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω .NET μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, κλίκες, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και κείμενο 3Δ.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία αυτόνομων αρχείων 3Δ μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη 2Δ έξοδο.
{{% /alert %}}

## **Αρχές Μορφοποίησης 3Δ**

Χρησιμοποιήστε την ιδιότητα [Shape.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/three_d_format/) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η ιδιότητα εκθέτει το [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/), το οποίο ελέγχει τη 3Δ σκηνή για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε την ιδιότητα [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/three_d_format/). Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές ιδιότητες είναι:

| Ιδιότητα | Τι ελέγχει | Πότε να τη χρησιμοποιήσετε |
|---|---|---|
| [camera](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/camera/) | Σημείο θέασης, προκαθορισμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε 3Δ χώρο ή ταιριάξτε με ένα προκαθορισμένο 3Δ περιστροφή του PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/light_rig/) | Προκαθορισμένος φωτισμός, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο με τον οποίο εμφανίζονται οι αντανακλάσεις και οι σκιές στην 3Δ επιφάνεια. |
| [material](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/material/) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακότερη, γυαλιστερή ή μεταλλική. |
| [extrusion_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_height/) | Πόσο μακριά επεκτείνεται το σχήμα προς τα πίσω από την εμπρόσθια όψη. | Μετατρέψτε ένα επίπεδο σχήμα σε εμφανώς παχύ 3Δ αντικείμενο. |
| [extrusion_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_color/) | Χρώμα των εξώθητων πλευρών. | Καταστήστε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το γέμισμα του προσώπου. |
| [depth](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/depth/) | Πρόσθετο 3Δ βάθος που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ιδιαίτερα μαζί με τις ρυθμίσεις κλίκας και υλικού. |
| [bevel_top](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/bevel_top/) και [bevel_bottom](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/bevel_bottom/) | Ανεβασμένα ή στρογγυλεμένα άκρα στις εμπρόσθιες και οπίσθιες όψεις. | Προσθέστε ένα μαλακό ή χτισμένο άκρο αντί για μια αιχμηρή επίπεδη όψη. |
| [contour_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/contour_color/) και [contour_width](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/contour_width/) | Περίγραμμα γύρω από το 3Δ αντικείμενο. | Τονίστε το όριο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία Σχήματος 3Δ**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν να φαίνεται πειστικά 3Δ:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές ευανάγνωστες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρόσθια όψη και εφαρμόζει μορφοποίηση 3Δ. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες, και το ύψος εξώθησης είναι 100 μονάδες. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG στο διπλάσιο των προεπιλεγμένων διαστάσεων και αποθηκεύει την παρουσίαση ως PPTX.

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

Η αποδοθείσα εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3Δ μπλοκ:

![Αποδοθέν ορθογώνιο 3Δ μπλε με λευκό κείμενο 3Δ στην εμπρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3Δ περιστροφή ρυθμίζεται από το παράθυρο 3‑Δ Περιστροφής. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3‑Δ Περιστροφής του PowerPoint με επισημασμένες τις τιμές περιστροφής X, Y, Z](img_02_01.png)

Στο Aspose.Slides, προσπελάστε την κάμερα μέσω του [ThreeDFormat.camera](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/camera/). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική προοπτική εμπρός και ορίζει τις περιστροφές X, Y, Z στα 20, 30 και 40 μοίρες, αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει το 3Δ σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από την εμπρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Χειριστήρια βάθους του PowerPoint αντιστοιχισμένα στο χρώμα εξώθησης και τις ιδιότητες ύψους εξώθησης](img_02_02.png)

Ορίστε το [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_height/) για το πάχος και το [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_color/) για το χρώμα των πλευρών. Αυτό το παράδειγμα δίνει στο ορθογώνιο εξώθηση 100 μονάδων με μωβ πλευρές και περιστρέφει την κάμερα ώστε να αποκαλυφθεί το πάχος. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Η ιδιότητα [ThreeDFormat.depth](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/depth/) ορίζει το βάθος ενός 3Δ σχήματος. Η ιδιότητα [extrusion_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_height/) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβαθμίσεων ή Γεμισμάτων Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε σταθερό χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην εμπρόσθια όψη και να διατηρήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση μπλε‑πορτοκαλί στην εμπρόσθια όψη και σκούρο πορτοκαλί χρώμα στην εξώθηση 150 μονάδων. Οι στάσεις της διαβάθμισης στο 0 και 100 σηματοδοτούν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG στο διπλάσιο των προεπιλεγμένων διαστάσεων:

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

Αποδοθέν 3Δ ορθογώνιο με γέμισμα διαβάθμισης μπλε‑πορτοκαλί και πορτοκαλί εξώθηση:

![Αποδοθέν 3Δ ορθογώνιο με γέμισμα διαβάθμισης μπλε-πορτοκαλί και πορτοκαλή εξώθηση](img_02_03.png)

Για χρήση γεμίσματος εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε τη στο γέμισμα του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα "image.jpg" στον φάκελο εργασίας. Τεντώνεται η εικόνα ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εξώθηση 150 μονάδων και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

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

Αποδοθέν 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην εμπρόσθια όψη και πορτοκαλή εξώθηση:

![Αποδοθέν 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην εμπρόσθια όψη και πορτοκαλή εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ παρόμοια με WordArt, όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί‑λευκό, εφαρμόζει καμπύλη προς τα πάνω και διαμορφώνει ρυθμίσεις 3Δ μέσω του [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/three_d_format/). Το ύψος εξώθησης και το βάθος είναι σε μονάδες, και η περιστροφή του φωτός σε μοίρες. Το γέμισμα και η γραμμή του σχήματος είναι κρυμμένα ώστε να είναι ορατό μόνο το κείμενο. Το παράδειγμα αποδίδει εικόνα PNG στο διπλάσιο των προεπιλεγμένων διαστάσεων της διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

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

Αποδοθέν 3Δ κείμενο με κοίλη μεταμόρφωση WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση:

![Αποδοθέν 3Δ κείμενο με κοίλη μεταμόρφωση WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση του Κειμένου Επίπεδου σε Σχήμα 3Δ**

Για να διατηρήσετε το κείμενο ευανάγνωστο ενώ διατηρείτε την 3Δ εμφάνιση του σχήματος, ορίστε το [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/keep_text_flat/) μέσω του [TextFrame.text_frame_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/text_frame_format/). Όταν η τιμή είναι `True`, το κείμενο παραμένει έξω από τη 3Δ σκηνή. Όταν είναι `False`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί την 3Δ προσανατολισμό.

Αυτή η ρύθμιση δεν αφαιρεί τη μορφοποίηση 3Δ του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [Shape.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/three_d_format/). Είναι επίσης διαφορετικό από τη συνηθισμένη περιστροφή. Η [Shape.rotation](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/rotation/) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ η [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/rotation_angle/) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου έξω από τη 3Δ σκηνή δεν επαναφέρει καμία από αυτές τις γωνίες.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια μορφοποίηση 3Δ· μόνο η ρύθμιση κειμένου διαφέρει: `False` στα αριστερά και `True` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες, και το ύψος εξώθησης είναι 40 μονάδες. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG στο διπλάσιο των προεπιλεγμένων διαστάσεων.

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

Δύο 3Δ ορθογώνια δίπλα‑δίπλα: keep_text_flat είναι False στα αριστερά και True στα δεξιά:

![Δύο 3Δ ορθογώνια δίπλα-δίπλα: keep_text_flat είναι False στα αριστερά και True στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερού διατάκτου, η 3Δ σκηνή rasterizes ή σχεδιάζεται στην έξοδο ως 2Δ αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/python-net/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/python-net/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/python-net/convert-powerpoint-to-video/).

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης της διαφάνειας.
- Αν χρειάζεστε να εξετάσετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/python-net/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3Δ ρυθμίσεις.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει τα 3Δ εφέ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή σελίδες HTML διαδραστικές 3Δ σκηνές που ένας θεατής μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3Δ μοντέλου και 3Δ εφέ;**

Ένα 3Δ μοντέλο είναι ένα ξεχωριστό 3Δ αντικείμενο που εισάγεται στην παρουσίαση. Ένα 3Δ εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, κλίκη, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει 3Δ εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3Δ σχήμα;**

Ως ελάχιστο, ορίστε περιστροφή της κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδοθείσες όψεις να έχουν σαφή αντανακλάσεις και σκιές.

**Μπορώ να εφαρμόσω 3Δ εφέ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/three_d_format/) για το σώμα του σχήματος και το [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/three_d_format/) για το κείμενο.

**Θα εμφανιστούν τα 3Δ εφέ όταν εξάγονται σε εικόνες, PDF, HTML ή πλαίσια βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3Δ εφέ όταν παράγει εικόνες διαφανειών, έξοδο PDF, έξοδο HTML και πλαίσια που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3Δ αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3Δ τιμές μετά την κληρονόμηση και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/python-net/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, κλίκας και σχετιζόμενων 3Δ τιμών.