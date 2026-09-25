---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε Python
linktitle: WordArt
type: docs
weight: 110
url: /el/python-net/wordart/
keywords:
- WordArt
- Δημιουργία WordArt
- Πρότυπο WordArt
- Εφέ WordArt
- Εφέ σκιάς
- Εφέ ανάκλασης
- Εφέ λάμψης
- Μετασχηματισμός WordArt
- εφέ 3Δ
- Εφέ εξωτερικής σκιάς
- Εφέ εσωτερικής σκιάς
- Python
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για Python μέσω .NET. Αυτός ο οδηγός βήμα προς βήμα βοηθά τους προγραμματιστές να ενισχύσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε Python."
---
## **Επισκόπηση**

Τα εφέ WordArt σας επιτρέπουν να μορφοποιείτε κείμενο με γεμίσματα, περιγράμματα, σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και τρισδιάστατη μορφοποίηση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσαρμόσετε αυτά τα εφέ σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides for Python via .NET, χωρίς εγκατεστημένο το Microsoft Office.

## **Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο**

Τα παρακάτω παραδείγματα δημιουργούν ένα απλό στυλ WordArt ορίζοντας το κείμενο, τη γραμματοσειρά, το γεμιστικό μοτίβο και το περίγραμμα.

Κάθε παράδειγμα δημιουργεί μια νέα παρουσίαση και προσθέτει ένα ορθογώνιο στο πρώτο της διαφάνεια· δεν απαιτείται αρχείο εισόδου. Το πρώτο παράδειγμα ορίζει το κείμενο σε "Aspose.Slides". Η θέση και οι διαστάσεις του σχήματος μετρώνται σε μονάδες (points):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Ορίστε τη γραμματοσειρά σε Arial Black με μέγεθος 36 points ώστε η μορφοποίηση να είναι πιο εμφανής:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Εφαρμόστε ένα μοτίβο [SMALL_GRID](https://reference.aspose.com/slides/el/python-net/aspose.slides/patternstyle/) με σκούρο πορτοκαλί προσκήνιο και λευκό φόντο, μετά προσθέστε ένα μαύρο περίγραμμα κειμένου με πλάτος 1 point:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Το αποτέλεσμα κειμένου:

![Το απλό πρότυπο WordArt](WordArt_template.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

Τα παρακάτω παραδείγματα δείχνουν πώς να εφαρμόσετε σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και τρισδιάστατα εφέ σε κείμενο.

### **Εφαρμογή Εξωτερικών Σκιών**

Μια εξωτερική σκιά προσθέτει βάθος τοποθετώντας μια σκιά πίσω από το κείμενο. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση, την ακτίνα θολώσεως, την κλίμακα και το πλαγίως στρίψιμο.

Αυτό το παράδειγμα καλεί τη [enable_outer_shadow_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) και ορίζει μια μαύρη σκιά με ακτίνα θολώσεως 4 points, κατεύθυνση 230 μοιρών και απόσταση 30 points. Οι τιμές κλίμακας 100 διατηρούν το μέγεθος της σκιάς, ενώ το οριζόντιο σκέλιση την κλίνει κατά 20 μοίρες. Η μετατροπή άλφα θέτει την αδιαφάνεια στο 32%:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Το αποτέλεσμα κειμένου:

![Το εφέ Εξωτερικής Σκιάς](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Όταν χρησιμοποιούνται μαζί εξωτερικές και προκαθορισμένες σκιές, εφαρμόζεται μόνο η εξωτερική σκιά.
- Εάν χρησιμοποιούνται ταυτόχρονα εξωτερικές και εσωτερικές σκιές, το αποτέλεσμα εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται, ενώ στο PowerPoint 2007 εφαρμόζεται μόνο η εξωτερική σκιά.
{{% /alert %}}

### **Εφαρμογή Εφέ Αντανάκλασης**

Μια αντανάκλαση δημιουργεί ένα καθρεπτισμένο αντίγραφο του κειμένου. Ρυθμίστε τη θέση, την κλίμακα, τη θόλωση και την αδιαφάνεια για να ελέγξετε την εμφάνισή της.

Αυτό το παράδειγμα καλεί τη [enable_reflection_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides/effectformat/enable_reflection_effect/) και αναστρέφει την αντανάκλαση κατακόρυφα με κλίμακα -100%. Χρησιμοποιεί ακτίνα θολώσεως 0,5 point και απόσταση 4,72 point. Η αδιαφάνεια μειώνεται από 60% σε 0,9% μεταξύ θέσεων 0% και 60% κατά μήκος της αντανάκλασης:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

Το αποτέλεσμα κειμένου:

![Το εφέ Αντανάκλασης](reflection_effect.png)

### **Εφαρμογή Εφέ Λάμψης**

Η λάμψη προσθέτει ένα απαλό χρωματιστό περίγραμμα γύρω από το κείμενο. Ρυθμίστε το χρώμα, την αδιαφάνεια και την ακτίνα για να ελέγξετε το εφέ.

Αυτό το παράδειγμα καλεί τη [enable_glow_effect](https://reference.aspose.com/slides/el/python-net/aspose.slides/effectformat/enable_glow_effect/) και εφαρμόζει κόκκινη λάμψη με αδιαφάνεια 54% και ακτίνα 7 points:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Το αποτέλεσμα κειμένου:

![Το εφέ Λάμψης](glow_effect.png)

### **Εφαρμογή Μετασχηματισμών WordArt**

Οι μετασχηματισμοί WordArt λυγίζουν, τεντώνονται ή παραμορφώνουν ένα μπλοκ κειμένου.

Ορίστε το [transform](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/transform/) σε [ARCH_UP_POUR](https://reference.aspose.com/slides/el/python-net/aspose.slides/textshapetype/) για να καμπυλώσετε το πλήρες πλαίσιο κειμένου προς τα πάνω:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Το αποτέλεσμα κειμένου:

![Ο μετασχηματισμός WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Το Aspose.Slides for Python via .NET παρέχει ένα σύνολο προκαθορισμένων [transformation types](https://reference.aspose.com/slides/el/python-net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Εφαρμογή 3D Εφέ σε Σχήματα και Κείμενο**

Μπορείτε να εφαρμόσετε 3D εφέ σε ένα σχήμα ή στο κείμενό του. Τα φινέτσα, η εξώθηση, ο φωτισμός και οι ρυθμίσεις κάμερας ελέγχουν την τελική εμφάνιση.

Το παρακάτω παράδειγμα χρησιμοποιεί το [ThreeDFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/) για να προσθέσει κυκλικά φινέτσα, πορτοκαλί εξώθηση και σκούρο κόκκινο περίγραμμα στο ορθογώνιο. Οι διαστάσεις του φινέτσου, το ύψος εξώθησης, το πλάτος και το βάθος του περιγράμματος μετρώνται σε points. Ένα πλαστικό υλικό, ισορροπημένος φωτισμός περιστραμμένος κατά 40 μοίρες γύρω από τον άξονα Z, και μια προοπτική κάμερα καθορίζουν την εμφάνισή του:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Το αποτέλεσμα σχήματος:

![Το 3D εφέ σχήματος](shape_3D_effect.png)

Αυτό το παράδειγμα εφαρμόζει παρόμοια 3D μορφοποίηση στο κείμενο μέσω του [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/three_d_format/). Μικρότερα φινέτσα διαμορφώνουν τις άκρες των γραμμάτων, ενώ η εξώθηση και ο φωτισμός δίνουν βάθος στο κείμενο:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Το αποτέλεσμα κειμένου:

![Το 3D εφέ κειμένου](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Η εφαρμογή 3D εφέ σε κείμενο ή στα σχήματά τους —και η αλληλεπίδραση μεταξύ αυτών των εφέ— διέπεται από συγκεκριμένους κανόνες. Σκεφτείτε μια σκηνή που περιλαμβάνει τόσο το κείμενο όσο και το σχήμα που το περιέχει. Ένα 3D εφέ περιλαμβάνει την 3D αναπαράσταση του αντικειμένου και τη σκηνή στην οποία τοποθετείται.

- Εάν έχει οριστεί σκηνή τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα και η σκηνή του κειμένου αγνοείται.
- Εάν το σχήμα δεν έχει δική του σκηνή αλλά έχει 3D αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Εάν το σχήμα δεν έχει καθόλου 3D εφέ, θεωρείται επίπεδο και το 3D εφέ εφαρμόζεται μόνο στο κείμενο.

Αυτές οι συμπεριφορές σχετίζονται με τις ιδιότητες [ThreeDFormat.light_rig](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/light_rig/) και [ThreeDFormat.camera](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Για να διατηρήσετε το κείμενο επίπεδο και αναγνώσιμο διατηρώντας ταυτόχρονα τη 3D μορφοποίηση του σχήματος, δείτε το [Keep Text Flat on a 3D Shape](/slides/el/python-net/3d-presentation/) για σύγκριση των ρυθμίσεων και ένα πλήρες παράδειγμα Python.

## **Συχνές ερωτήσεις**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοποιές ή γραψιμές (π.χ., Αραβικά, Κινέζικα);**

Ναι, το Aspose.Slides for Python via .NET υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοποιές και γραψιμές. Τα εφέ WordArt όπως σκιά, γεμιστικό και περίγραμμα μπορούν να εφαρμοστούν ανεξαρτήτως της γλώσσας, αν και η διαθεσιμότητα γραμματοποιής και η απόδοση μπορεί να εξαρτώνται από τις γραμματοποιές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του κύριου διαφάνειας (slide master);**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στις κύριες διαφάνειες, συμπεριλαμβανομένων των δεσμευτών τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master θα αντικατοπτριστούν σε όλες τις σχετικές διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Λίγο. Τα εφέ WordArt όπως σκιές, λάμψεις και διαβαθμισμένα γεμίσματα μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδομήσετε διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας τη [Slide.get_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/), ή να αποδομήσετε μεμονωμένα σχήματα χρησιμοποιώντας τη [Shape.get_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_image/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξαγάγετε ολόκληρη την παρουσίαση.