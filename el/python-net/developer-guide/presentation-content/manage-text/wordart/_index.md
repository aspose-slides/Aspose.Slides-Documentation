---
title: Δημιουργία και Εφαρμογή Επιδράσεων WordArt σε Python
linktitle: WordArt
type: docs
weight: 110
url: /el/python-net/wordart/
keywords:
- WordArt
- δημιουργία WordArt
- πρότυπο WordArt
- επίδραση WordArt
- επίδραση σκιάς
- επίδραση εμφάνισης
- επίδραση λάμψης
- μετασχηματισμός WordArt
- 3D επίδραση
- επίδραση εξωτερικής σκιάς
- επίδραση εσωτερικής σκιάς
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε επιδράσεις WordArt στο Aspose.Slides για Python μέσω .NET. Αυτός ο οδηγός βήμα προς βήμα βοηθά τους προγραμματιστές να ενισχύσουν τις παρουσιάσεις με στυλιζαρισμένο, επαγγελματικό κείμενο σε Python."
---
## **Επισκόπηση**

Οι επιδράσεις WordArt σάς επιτρέπουν να προσθέσετε οπτικά ελκυστικό, στιλιζαρισμένο κείμενο στις παρουσιάσεις PowerPoint. Με το Aspose.Slides, οι προγραμματιστές μπορούν προγραμματιστικά να δημιουργούν, προσαρμόζουν και διαχειρίζονται το WordArt όπως στο Microsoft PowerPoint—χωρίς να χρειάζεται να είναι εγκατεστημένο το Office. Αυτό το άρθρο παρέχει μια επισκόπηση της εργασίας με το WordArt, συμπεριλαμβανομένου του πώς να εφαρμόζετε μετασχηματισμούς κειμένου, στυλ γεμίσματος, περιγράμματα, σκιές και άλλες επιλογές μορφοποίησης για να κάνετε το περιεχόμενο της παρουσίασής σας πιο εκφραστικό και ελκυστικό. Το WordArt σας επιτρέπει να αντιμετωπίζετε το κείμενο ως γραφικό αντικείμενο. Αποτελείται από επιδράσεις ή ειδικές τροποποιήσεις που εφαρμόζονται στο κείμενο ώστε να γίνει πιο ελκυστικό ή εμφανές.

**WordArt στο Microsoft PowerPoint**

Για να χρησιμοποιήσετε το WordArt στο Microsoft PowerPoint, πρέπει να επιλέξετε ένα από τα προ‑ορισμένα πρότυπα WordArt. Ένα πρότυπο WordArt είναι ένα σύνολο επιδράσεων που εφαρμόζονται σε κείμενο ή στο σχήμα του. 

**WordArt στο Aspose.Slides**

Στο Aspose.Slides για Python μέσω .NET 20.10, υλοποιήσαμε υποστήριξη για το WordArt και κάναμε βελτιώσεις στη λειτουργία σε επόμενες εκδόσεις του Aspose.Slides για Python μέσω .NET. 

Με το Aspose.Slides για Python μέσω .NET, μπορείτε εύκολα να δημιουργήσετε το δικό σας πρότυπο WordArt (μια επίδραση ή συνδυασμό επιδράσεων) σε Python και να το εφαρμόσετε σε κείμενα. 

## Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο

**Χρήση Aspose.Slides** 

Αρχικά, δημιουργούμε ένα απλό κείμενο χρησιμοποιώντας αυτόν τον κώδικα Python: 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Στη συνέχεια, ορίζουμε το μέγεθος γραμματοσειράς του κειμένου σε μεγαλύτερη τιμή ώστε η επίδραση να γίνει πιο εμφανής μέσω αυτού του κώδικα:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Χρήση Microsoft PowerPoint**

Πηγαίνετε στο μενού επιδράσεων WordArt στο Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Από το μενού στα δεξιά, μπορείτε να επιλέξετε μια προ‑ορισμένη επίδραση WordArt. Από το μενού στα αριστερά, μπορείτε να ορίσετε τις ρυθμίσεις για ένα νέο WordArt. 

Αυτά είναι μερικά από τα διαθέσιμα παραμέτρους ή επιλογές:

![todo:image_alt_text](image-20200930114015-3.png)

**Χρήση Aspose.Slides**

Εδώ, εφαρμόζουμε το χρώμα μοτίβου SmallGrid στο κείμενο και προσθέτουμε ένα ασπρόμαυρο περίγραμμα κειμένου πλάτους 1 χρησιμοποιώντας αυτόν τον κώδικα:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Το αποτέλεσμα του κειμένου:

![todo:image_alt_text](image-20200930114108-4.png)

## Εφαρμογή Άλλων Επιδράσεων WordArt

**Χρήση Microsoft PowerPoint**

Από τη διεπαφή του προγράμματος, μπορείτε να εφαρμόσετε αυτές τις επιδράσεις σε κείμενο, μπλοκ κειμένου, σχήμα ή παρόμοιο στοιχείο:

![todo:image_alt_text](image-20200930114129-5.png)

Για παράδειγμα, οι επιδράσεις Σκιά, Αντανάκλαση και Λάμψη μπορούν να εφαρμοστούν σε κείμενο· οι επιδράσεις 3D Format και 3D Rotation μπορούν να εφαρμοστούν σε μπλοκ κειμένου· η ιδιότητα Soft Edges μπορεί να εφαρμοστεί σε αντικείμενο σχήματος (έχει ακόμη αποτέλεσμα όταν δεν έχει οριστεί ιδιότητα 3D Format).

### Εφαρμογή Σκιών

Εδώ, σκοπεύουμε να ορίσουμε τις ιδιότητες μόνο για κείμενο. Εφαρμόζουμε την επίδραση σκιώδους σε κείμενο χρησιμοποιώντας αυτόν τον κώδικα σε Python:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Το API του Aspose.Slides υποστηρίζει τρεις τύπους σκιών: OuterShadow, InnerShadow και PresetShadow.

Με το PresetShadow, μπορείτε να εφαρμόσετε μια σκιά για κείμενο (χρησιμοποιώντας προεπιλεγμένες τιμές).

**Χρήση Microsoft PowerPoint**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε έναν τύπο σκιάς. Να ένα παράδειγμα:

![todo:image_alt_text](image-20200930114225-6.png)

**Χρήση Aspose.Slides**

Το Aspose.Slides επιτρέπει στην πραγματικότητα να εφαρμόσετε δύο τύπους σκιών ταυτόχρονα: InnerShadow και PresetShadow.

**Σημειώσεις:**

- Όταν χρησιμοποιούνται ταυτόχρονα OuterShadow και PresetShadow, εφαρμόζεται μόνο η επίδραση OuterShadow.
- Αν χρησιμοποιηθούν ταυτόχρονα OuterShadow και InnerShadow, η εφαρμοζόμενη ή αποτέλεσμα εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013, η επίδραση διπλασιάζεται. Στο PowerPoint 2007, εφαρμόζεται η επίδραση OuterShadow.

### Εφαρμογή Εμφάνισης σε Κείμενα

Προσθέτουμε εμφάνιση στο κείμενο μέσω αυτού του δείγματος κώδικα σε Python:

```py 
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

### Εφαρμογή Λάμψης σε Κείμενα

Εφαρμόζουμε την επίδραση λάμψης στο κείμενο ώστε να λάμπει ή να ξεχωρίζει χρησιμοποιώντας αυτόν τον κώδικα:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Μπορείτε να αλλάξετε τις παραμέτρους για σκιά, εμφάνιση και λάμψη. Οι ιδιότητες των επιδράσεων ορίζονται ξεχωριστά για κάθε τμήμα του κειμένου. 

{{% /alert %}} 

### Χρήση Μετασχηματισμών στο WordArt

Χρησιμοποιούμε την ιδιότητα Transform (ενσωματωμένη σε ολόκληρο το μπλοκ κειμένου) μέσω αυτού του κώδικα:

```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Το αποτέλεσμα:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Τanto Microsoft PowerPoint όσο και Aspose.Slides για Python μέσω .NET παρέχουν έναν ορισμένο αριθμό προ‑ορισμένων τύπων μετασχηματισμού. 

{{% /alert %}} 

**Χρήση PowerPoint**

Για πρόσβαση στους προ‑ορισμένους τύπους μετασχηματισμού, πηγαίνετε: **Format** -> **TextEffect** -> **Transform**

**Χρήση Aspose.Slides**

Για να επιλέξετε τύπο μετασχηματισμού, χρησιμοποιήστε την απαρίθμηση TextShapeType.

### Εφαρμογή 3D επιδράσεων σε Κείμενα και Σχήματα

Ορίζουμε μια 3D επίδραση σε σχήμα κειμένου χρησιμοποιώντας αυτό το δείγμα κώδικα:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Το αποτέλεσμα του κειμένου και του σχήματός του:

![todo:image_alt_text](image-20200930114816-9.png)

Εφαρμόζουμε μια 3D επίδραση στο κείμενο με αυτόν τον κώδικα Python:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Η εφαρμογή 3D επιδράσεων σε κείμενα ή τα σχήματά τους και οι αλληλεπιδράσεις μεταξύ των επιδράσεων βασίζονται σε ορισμένους κανόνες.

Σκεφτείτε μια σκηνή για ένα κείμενο και το σχήμα που το περιέχει. Η 3D επίδραση περιλαμβάνει αναπαράσταση 3D αντικειμένου και τη σκηνή στην οποία το αντικείμενο τοποθετείται.

- Όταν η σκηνή ορίζεται τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει υψηλότερη προτεραιότητα — η σκηνή του κειμένου αγνοείται.
- Όταν το σχήμα δεν διαθέτει δική του σκηνή αλλά έχει 3D αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Διαφορετικά — όταν το σχήμα αρχικά δεν έχει 3D επίδραση — το σχήμα είναι επίπεδο και η 3D επίδραση εφαρμόζεται μόνο στο κείμενο.

Οι περιγραφές συνδέονται με τις ιδιότητες [ThreeDFormat.LightRig](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/) και [ThreeDFormat.Camera](https://reference.aspose.com/slides/el/python-net/aspose.slides/threedformat/). 

{{% /alert %}} 

## **Εφαρμογή Εξωτερικών Σκιών σε Κείμενα**
Το Aspose.Slides για Python μέσω .NET παρέχει τις κλάσεις [**IOuterShadow**](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/ioutershadow/) και [**IInnerShadow**](https://reference.aspose.com/slides/el/python-net/aspose.slides.effects/iinnershadow/) που σας επιτρέπουν να εφαρμόσετε σκιές σε κείμενο που είναι μέσα σε TextFrame. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα AutoShape τύπου Rectangle στη διαφάνεια.
4. Πρόσβαση στο TextFrame που συσχετίζεται με το AutoShape.
5. Ορίστε το FillType του AutoShape σε NoFill.
6. Δημιουργήστε ένα αντικείμενο της κλάσης OuterShadow
7. Ορίστε το BlurRadius της σκιάς.
8. Ορίστε την Direction της σκιάς.
9. Ορίστε το Distance της σκιάς.
10. Ορίστε το RectanglelAlign σε TopLeft.
11. Ορίστε το PresetColor της σκιάς σε Black.
12. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Αυτό το παράδειγμα κώδικα σε Python — υλοποίηση των παραπάνω βημάτων — δείχνει πώς να εφαρμόσετε την εξωτερική σκιώδη επίδραση σε κείμενο:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Αποκτήστε την αναφορά της διαφάνειας
    sld = pres.slides[0]

    # Προσθέστε ένα AutoShape τύπου Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Προσθέστε TextFrame στο Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Απενεργοποιήστε τη γέμιση σχήματος σε περίπτωση που θέλουμε να πάρουμε τη σκιά του κειμένου
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Προσθέστε εξωτερική σκιά και ορίστε όλες τις απαραίτητες παραμέτρους
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Write την παρουσίαση στο δίσκο
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Εφαρμογή Εσωτερικής Σκιάς σε Σχήματα**
Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά της διαφάνειας.
3. Προσθέστε ένα AutoShape τύπου Rectangle.
4. Ενεργοποιήστε το InnerShadowEffect.
5. Ορίστε όλες τις απαιτούμενες παραμέτρους.
6. Ορίστε το ColorType σε Scheme.
7. Ορίστε το Scheme Color.
8. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).

Αυτό το παράδειγμα κώδικα (βασισμένο στα παραπάνω βήματα) δείχνει πώς να προσθέσετε σύνδεσμο μεταξύ δύο σχημάτων σε Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Αποκτήστε την αναφορά μιας διαφάνειας
    slide = presentation.slides[0]

    # Προσθέστε ένα AutoShape τύπου Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Προσθέστε TextFrame στο Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Ενεργοποιήστε inner_shadow_effect
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Ορίστε όλες τις απαραίτητες παραμέτρους
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Ορίστε ColorType ως Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Ορίστε Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Αποθηκεύστε την παρουσίαση
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Μπορώ να χρησιμοποιήσω τις επιδράσεις WordArt με διαφορετικές γραμματοσειρές ή γραφές (π.χ., Αραβικά, Κινέζικα);**

Ναι, το Aspose.Slides υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και γραφές. Οι επιδράσεις WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξαρτήτως γλώσσας, αν και η διαθεσιμότητα της γραμματοσειράς και η απόδοση μπορεί να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω τις επιδράσεις WordArt σε στοιχεία του master της διαφάνειας;**

Ναι, μπορείτε να εφαρμόσετε τις επιδράσεις WordArt σε σχήματα στις master διαφάνειες, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master θα αντικατοπτρίζονται σε όλες τις σχετικές διαφάνειες.

**Επηρεάζουν οι επιδράσεις WordArt το μέγεθος του αρχείου παρουσίασης;**

Ελαφρώς. Οι επιδράσεις WordArt όπως σκιές, λάμψεις και διαβαθμίσεις γεμίσματος μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των επιδράσεων WordArt χωρίς αποθήκευση της παρουσίασης;**

Ναι, μπορείτε να αποδώσετε διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας τη μέθοδο `get_image` από τις κλάσεις [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) ή [Slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.