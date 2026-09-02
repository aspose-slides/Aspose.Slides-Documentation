---
title: Διαχείριση Θεμάτων Παρουσίασης PowerPoint σε Python
linktitle: Θέμα Παρουσίασης
type: docs
weight: 10
url: /el/python-net/presentation-theme/
keywords:
- Θέμα PowerPoint
- Θέμα παρουσίασης
- Θέμα διαφάνειας
- Ορισμός θέματος
- Αλλαγή θέματος
- Διαχείριση θέματος
- Χρώμα θέματος
- Πρόσθετο παλέτο
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τα κύρια θέματα παρουσίασης στο Aspose.Slides για Python μέσω .NET για τη δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με σταθερή εμπορική ταυτοποίηση."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ παρασκηνίου, γεμίσματος, γραμμών και εφέ. Τα αντικείμενα που είναι ευαίσθητα στο θέμα αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώνει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα επιπέδου παρουσίασης είναι διαθέσιμο μέσω της ιδιότητας [Presentation.master_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/master_theme/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω του [MasterThemeManager.override_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/masterthememanager/override_theme/), ένα layout μπορεί να παρακάμψει το κληρονομημένο του θέμα μέσω του [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), και μια μεμονωμένη διαφάνεια μπορεί να κάνει το ίδιο. Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παρακάμψη master, παρακάμψη layout και παρακάμψη διαφάνειας.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο κοινές ροές εργασίας για θέματα: εξέταση ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ παρασκηνίου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την επίλυση κληρονομικότητας και παρακάμψεων.

## **Εξέταση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/mastertheme/) αποκαλύπτει τις ιδιότητες του θέματος **color_scheme**, **font_scheme** και **format_scheme**. Η εξέταση αυτών των συλλογών πριν από την τροποποίησή τους είναι ιδιαίτερα χρήσιμη όταν μια παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρίσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ παρασκηνίου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Εάν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Εξετάστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που εμφανίζεται αργότερα σ’ αυτό το άρθρο όταν ενδέχεται να υπάρχουν παρακάμψεις layout ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι ευαίσθητα στο θέμα μπορούν να αναφέρονται σε λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/python-net/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώριση στο **ColorScheme** του θέματος, όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε αυτό το χρώμα θέματος αντιμετωπίζονται βάσει της νέας τιμής. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με μια ενημέρωση χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί `ACCENT4`, αλλάζει το χρώμα `accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `ACCENT4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Εάν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, οι μετέπειτα αλλαγές στο `accent4` δεν θα επηρεάζουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από το Πρόσθετο Παλέτο**

Το PowerPoint παράγει πιο ανοιχτές και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/python-net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Πιο ανοιχτές και πιο σκούρες παραλλαγές που παράγονται από τα κύρια χρώματα θέματος.

Το παρακάτω παράδειγμα δημιουργεί έξι ορθογώνια βασισμένα στο `ACCENT4`, εφαρμόζει μετασχηματισμούς φωτεινότητας σε πέντε από αυτά και αποθηκεύει το αποτέλεσμα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Εάν το `accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επανυπολογίζονται από τη νέα τιμή του `accent4`.

### **Αντιστοίχηση Τιμών `SchemeColor` σε Θέσεις `ColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/python-net/aspose.slides/schemecolor/) χρησιμοποιεί `TEXT1`, `BACKGROUND1`, `TEXT2` και `BACKGROUND2`, ενώ το **ColorScheme** εκθέτει τις ίδιες θέσεις θέματος ως `dark1`, `light1`, `dark2` και `light2`. Η αντιστοίχηση είναι σταθερή:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιλαμβάνει ένα κύριο σύνολο γραμματοσειρών για επικεφαλίδες και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι ιδιότητες [FontScheme.major](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/fontscheme/major/) και [FontScheme.minor](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/fontscheme/minor/) εκθέτουν αυτά τα σύνολα.

Οι ταυτότητες γραμματοσειρών θέματος συμβατές με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μια επικεφαλίδα που χρησιμοποιεί τη μεγάλη λατινική γραμματοσειρά θέματος και μια γραμμή κυρίως κειμένου που χρησιμοποιεί τη μικρή λατινική γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

Η επικεφαλίδα ακολουθεί τη μεγάλη γραμματοσειρά και το κυρίως κείμενο τη μικρή γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για ταυτότητα θέματος δεν θα αλλάξει αυτόματα όταν αλλάξει το σχήμα γραμματοσειρών θέματος.

Οι μεγάλες και μικρές συλλογές γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλικό, αραβικό, ιαπωνικό, γεωργιανό και Θάνα. Για να εξετάσετε, προσθέσετε, αντικαταστήσετε ή αφαιρέσετε αυτές τις αντιστοιχίσεις, δείτε το [Script-Specific Theme Fonts](/slides/el/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε το [PowerPoint Fonts](/slides/el/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Υπάρχουν δύο κοινές ροές εργασίας, και λύνουν διαφορετικά προβλήματα.

### **Διατήρηση Πηγικού Θέματος κατά τη Μετακίνηση Διαφανειών**

Εάν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον πηγαίο master στην προορισμιακή παρουσίαση με το [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/add_clone/), στη συνέχεια κλωνοποιήστε τη διαφάνεια με το [SlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/add_clone/) και τον κλωνοποιημένο master. Αυτό μεταφέρει τον master, τα layouts του και το σχετικό θέμα μαζί.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγή διαφάνειας πρέπει να φαίνεται ίδια στον προορισμό. Απλή κλωνοποίηση περιεχομένου πάνω σε έναν αδιάσπαστο master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, παρασκήνια και εφέ που καθορίζονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υφιστάμενη Διαφάνεια**

Εάν η διαφάνεια-προορισμός πρέπει να παραμείνει στον τρέχοντα master και layout της, αρχικοποιήστε μια παρακάμψη επιπέδου διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), και [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) αντιγράφουν τα τρία κύρια στοιχεία του θέματος στην παρακάμψη.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Αυτό αλλάζει το θέμα που χρησιμοποιεί η συγκεκριμένη διαφάνεια χωρίς να αλλάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παρακάμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/clear/).

### **Εφαρμογή Παρακάμψης Θέματος σε Layout**

Μια παρακάμψη επιπέδου layout εφαρμόζεται σε διαφάνειες που χρησιμοποιούν εκείνο το layout, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακάμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/layoutslidethememanager/):

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Χρησιμοποιήστε ένα θέμα master ή παρουσίασης όταν πολλές διαφάνειες και layouts πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παρακάμψη layout όταν μια οικογένεια layout χρειάζεται διαφορετικό στυλ, και μια παρακάμψη διαφάνειας μόνο για αληθινές εξαιρέσεις. Οι υπερβολικές παρακάμψεις επιπέδου διαφάνειας κάνουν τις μεταγενέστερες παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Παρασκηνίου Θέματος**

Τα γεμίσματα παρασκηνίου του θέματος αποθηκεύονται στο **FormatScheme.background_fill_styles**. Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές παρασκηνίου στη διεπαφή του από τον αριθμό των ορισμών γεμίσματος που αποθηκεύονται φυσικά σε αυτή τη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ παρασκηνίου, εξετάστε τη συλλογή που αποθηκεύεται και την τρέχουσα τιμή του [Background.style_index](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/style_index/). Το `style_index` χρησιμοποιεί το `0` για καμία θεματική γέμιση· οι θετικές τιμές είναι αναφορές σε στυλ παρασκηνίου θέματος. Αυτό διαφέρει από τον δείκτη μιας Python συλλογής, όπου το `[0]` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος παρασκηνίου.

Το παρακάτω παράδειγμα αναφέρει τον αριθμό των διαθέσιμων γεμισμάτων παρασκηνίου, εκχωρεί μια θεματική αναφορά παρασκηνίου στον πρώτο master και αποθηκεύει την παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Το ορατό αποτέλεσμα εξαρτάται από την καταχώριση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις παρασκηνίου στο layout ή στη διαφάνεια. Εάν μια διαφάνεια χρησιμοποιεί το δικό της παρασκήνιο, η αλλαγή μόνο του παρασκηνίου του master μπορεί να μην την επηρεάσει. Χρησιμοποιήστε το [Background.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/get_effective/) όταν χρειάζεστε το τελικό παρασκήνιο μετά την εφαρμογή της κληρονομικότητας.

{{% alert color="warning" title="Warning" %}}

Μην αντιμετωπίζετε το `style_index` ως δείκτη μηδενικής βάσης. Επίσης, αποφύγετε την σκληρή κωδικοποίηση αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Για άμεση μορφοποίηση παρασκηνίου και κληρονομικότητα παρασκηνίου, δείτε το [Presentation Background](/slides/el/python-net/presentation-background/).

{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές **FormatScheme.fill_styles**, **FormatScheme.line_styles** και **FormatScheme.effect_styles**. Τα τυπικά θέματα Office συχνά περιέχουν τρία κύρια στοιχεία στυλ που αντιστοιχούν οπτικά σε ήπια, μετριασμένα και έντονα φορμάτ, αλλά ο κώδικας πρέπει να ελέγχει κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές σε Python, ο δείκτης συλλογής είναι μηδενικός: το `[0]` είναι το πρώτο αποθηκευμένο στυλ και το `[2]` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστό ζήτημα, εκτεθειμένο μέσω του [IShapeStyle](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει την ύπαρξη των απαιτούμενων καταχωρίσεων στυλ, αλλάζει το πρώτο στυλ γραμμής, το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θέματος γίνεται συμπαγές δάσος πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξαρτάται ακόμη από το ποια θέσεις στυλ αναφέρονται κάθε σχήμα και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Οι ακατέργαστες αντικειμενικές εμφανίσεις του θέματος σας λένε τι είναι ορισμένο σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί στην πραγματικότητα μια διαφάνεια ή ένα σχήμα μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Για ένα παρασκήνιο, χρησιμοποιήστε το [Background.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/get_effective/), και για ένα γέμισμα, το [FillFormat.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/get_effective/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το παρασκήνιο και το γέμισμα του πρώτου σχήματος από μια διαφάνεια:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικά αποδοχής, επικύρωση και συγκρίσεις. Εάν εξετάζετε μόνο το [Presentation.master_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/master_theme/), μπορείτε να χάσετε μια παρακάμψη master, layout, διαφάνειας ή σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/slidethememanager/) της διαφάνειας και αρχικοποιήστε την παρακάμψη θέματος. Η αλλαγή παραμένει τοπική σε εκείνη τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποια είναι η πιο ασφαλής μέθοδος για μεταφορά θέματος από μία παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε τον πηγαίο master στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τις μεθόδους [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/add_clone/) και [SlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/add_clone/). Αυτό διατηρεί μαζί τον master, τα layouts και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) για ένα θέμα διαφάνειας ή layout και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/get_effective/) και το [FillFormat.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/get_effective/). Αυτές οι API επιστρέφουν τις τιμές που έχουν επιλυθεί μετά την εφαρμογή της κληρονομικότητας και των παρακάμψεων.