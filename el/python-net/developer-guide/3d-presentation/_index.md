---
title: Δημιουργία 3Δ εφέ σε παρουσιάσεις χρησιμοποιώντας Python
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
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε Python με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Aspose.Slides for Python via .NET μπορεί να δημιουργεί, επεξεργάζεται, διατηρεί και αποδίδει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, λοξιές, φωτισμό, υλικό, διαβάθμιση ή γεμίσεις εικόνας και κείμενο 3Δ.

{{% alert color="primary" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων 3Δ μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη 2Δ έξοδο.
{{% /alert %}}

## **Έννοιες Μορφοποίησης 3Δ**

Χρησιμοποιήστε την ιδιότητα [Shape.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/three_d_format/) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η ιδιότητα εκθέτει την [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/), η οποία ελέγχει τη σκηνή 3Δ για αυτό το σχήμα.

Για κείμενο, χρησιμοποιήστε την ιδιότητα [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/three_d_format/). Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές ιδιότητες είναι:

| Ιδιότητα | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [camera](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/camera/) | Οπτική γωνία, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε χώρο 3Δ ή ταιριάξτε με προεπιλεγμένη περιστροφή 3Δ του PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/light_rig/) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε την εμφάνιση των αντανακλάσεων και των σκιών στην επιφάνεια 3Δ. |
| [material](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/material/) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακή, γυαλιστερή ή μεταλλική. |
| [extrusion_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_height/) | Πόσο μακριά το σχήμα επεκτείνεται προς τα πίσω από την εμπρόσθια όψη. | Μετατρέψτε ένα επίπεδο σχήμα σε ορατό παχύ 3Δ αντικείμενο. |
| [extrusion_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_color/) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με την γεμιστική εμπρόσθια. |
| [depth](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/depth/) | Επιπλέον βάθος 3Δ που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ειδικά μαζί με ρυθμίσεις λοξιάς και υλικού. |
| [bevel_top](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/bevel_top/) και [bevel_bottom](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/bevel_bottom/) | Ανεγερμένες ή στρογγυλεμένες άκρες στις εμπρόσθιες και πίσω όψεις. | Προσθέστε μια μαλακωμένη ή μορφοποιημένη άκρη αντί για μια έντονη επίπεδη όψη. |
| [contour_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/contour_color/) και [contour_width](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/contour_width/) | Περίγραμμα γύρω από το 3Δ αντικείμενο. | Δώστε έμφαση στο όριο του αντικειμένου στην αποδιδόμενη έξοδο. |

## **Δημιουργία 3Δ Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων προτού φαίνεται πειστικά 3Δ:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρόσθια όψη του, εφαρμόζει μορφοποίηση 3Δ, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

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

Η αποδοθείσα εικόνα της διαφάνειας δείχνει το ορθογώνιο ως παχύ 3Δ μπλοκ:

![Απόδοση μπλε 3Δ ορθογωνίου με λευκό 3Δ κείμενο στην εμπρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3Δ περιστροφή ρυθμίζεται από το παράθυρο 3-D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3-D Rotation του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και την περιστροφή μέσω του [ThreeDFormat.camera](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία 2Δ του σχήματος στη διαφάνεια. Αλλάζει την 3Δ οπτική που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από την εμπρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτή την ορατή πάχος, ενώ ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint συνδεδεμένοι με τις ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Ορίστε το [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_height/) για το πάχος και το [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_color/) για το χρώμα των πλευρών:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Χρησιμοποιήστε το [ThreeDFormat.depth](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/depth/) όταν χρειάζεται να δουλέψετε άμεσα με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με λοξιά, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/extrusion_height/) είναι η πιο σαφής ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση Διαβάθμισης ή Γεμισμάτων Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην εμπρόσθια όψη και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει γεμιστικό διαβάθμισης στο σχήμα και σκούρο χρώμα εξώθησης στις πλευρές:

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

![Απόδοση 3Δ ορθογωνίου με γεμιστικό διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αντιστοιχίστε την στο γέμισμα του σχήματος:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![Απόδοση 3Δ ορθογωνίου με γέμισμα φωτογραφίας στην εμπρόσθια όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γεμιστικό μοτίβου, εφαρμόζει μετασχηματισμό WordArt και ρυθμίζει τις ρυθμίσεις 3Δ στο [TextFrameFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/):

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

![Απόδοση 3Δ κειμένου με καμπυλωτό μετασχηματισμό WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ όταν αποθηκεύεται σε μορφές PowerPoint όπως PPTX. Όταν γίνεται απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η σκηνή 3Δ rasterizes ή σχεδιάζεται στην έξοδο ως αποτέλεσμα 2Δ. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/python-net/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/python-net/convert-powerpoint-to-html/), ή δημιουργείτε frames για [video conversion](/slides/el/python-net/convert-powerpoint-to-video/).

Διατηρήστε τα ακόλουθα σημεία στο νου:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό της κάμερας, του φωτισμού, του υλικού, της εξώθησης, του γεμίσματος και της κλιμάκωσης της διαφάνειας.
- Αν χρειάζεται να εξετάσετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/python-net/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σε διαδραστικές 3Δ σκηνές που ο θεατής μπορεί να περιστρέψει. Στο PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3Δ μοντέλου και 3Δ εφέ;**

Ένα 3Δ μοντέλο είναι ένα ανεξάρτητο 3Δ αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3Δ εφέ είναι μορφοποίηση που εφαρμόζεται σε κανονικό σχήμα ή κείμενο PowerPoint, όπως περιστροφή, εξώθηση, λοξιά, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει 3Δ εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ορατό 3Δ σχήμα;**

Το ελάχιστο είναι να ορίσετε περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, επίσης ορίστε φωτισμό και υλικό ώστε οι αποδοθέντες πόλοι να έχουν καθαρές αντανακλάσεις και σκιές.

**Μπορώ να εφαρμόσω 3Δ εφέ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/three_d_format/) για το σώμα του σχήματος και το [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/three_d_format/) για το κείμενο.

**Θα εμφανίζονται τα 3Δ εφέ όταν εξάγονται σε εικόνες, PDF, HTML ή frames βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3Δ εφέ όταν παράγει εικόνες διαφανειών, PDF, HTML και frames για μετατροπή σε βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι επεξεργάσιμο 3Δ αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3Δ τιμές μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τις APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/python-net/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λοξιάς και σχετικών 3Δ τιμών.