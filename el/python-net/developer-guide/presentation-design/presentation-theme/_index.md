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
- Πρόσθετη παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- Python
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για Python μέσω .NET για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή εταιρική ταυτότητα."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμίσματος, γραμμών και εφέ. Τα αντικείμενα που είναι ευαίσθητα στο θέμα αναφέρονται σε αυτούς τους κοινά ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, έτσι μια αλλαγή του θέματος μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω της ιδιότητας [Presentation.master_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/master_theme/) . Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω του [MasterThemeManager.override_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/masterthememanager/override_theme/), μια διάταξη μπορεί να παρακάμψει το κληρονομημένο της θέμα μέσω του [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), και μια μεμονωμένη διαφάνεια μπορεί να κάνει το ίδιο. Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παρακατάληψη master, παρακατάληψη διάταξης και παρακατάληψη διαφάνειας.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο κοινές ροές εργασίας με θέματα: επιθεώρηση θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την επίλυση κληρονομικότητας και παρακάμψεων.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/mastertheme/) εκθέτει τις ιδιότητες [color_scheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/mastertheme/font_scheme/), και [format_scheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/mastertheme/format_scheme/) του θέματος. Η επιθεώρηση αυτών των συλλογών πριν από την αλλαγή τους είναι ιδιαίτερα χρήσιμη όταν μια παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρήσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ φόντου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

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

Εάν ένα αρχείο χρησιμοποιεί πολλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού‑θέματος που φαίνεται παρακάτω σε αυτό το άρθρο όταν μπορεί να υπάρξουν παρακάμψεις διάταξης ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι ευαίσθητα στο θέμα μπορούν να αναφέρονται σε λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/python-net/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στο [ColorScheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/colorscheme/) του θέματος, όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε εκείνο το χρώμα θέματος επιλύονται με την νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με την ενημέρωση χρώματος θέματος.

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `ACCENT4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Εάν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, οι μεταγενέστερες αλλαγές στο `accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από την Πρόσθετη Παλέτα**

Το PowerPoint παράγει προς τα πιο ανοιχτά και πιο σκούρα παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρωμάτων. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/python-net/aspose.slides/colortransformoperation/) .

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Πιο ανοιχτές και πιο σκοτεινές παραλλαγές παραγόμενες από τα κύρια χρώματα θέματος.

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

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Εάν το `accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επαναϋπολογίζονται από τη νέα τιμή `accent4`.

### **Αντιστοίχιση Τιμών `SchemeColor` σε Θέσεις `ColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/python-net/aspose.slides/schemecolor/) χρησιμοποιεί `TEXT1`, `BACKGROUND1`, `TEXT2` και `BACKGROUND2`, ενώ το [ColorScheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/colorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `dark1`, `light1`, `dark2` και `light2`. Η αντιστοίχηση είναι σταθερή:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιλαμβάνει ένα κύριο σύνολο γραμματοσειρών για επικεφαλίδες και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι ιδιότητες [FontScheme.major](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/fontscheme/major/) και [FontScheme.minor](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/fontscheme/minor/) εκθέτουν αυτά τα σύνολα.

Αναγνωριστικά γραμματοσειρών θέματος συμβατά με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μια επικεφαλίδα που χρησιμοποιεί τη μεγάλη λατινική γραμματοσειρά θέματος και μια γραμμή κειμένου που χρησιμοποιεί τη μικρή λατινική γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Η επικεφαλίδα ακολουθεί τη μεγάλη γραμματοσειρά και το κυρίως κείμενο την μικρή γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για αναγνωριστικό θέματος δεν θα αλλάξει αυτόματα όταν αλλάζει το σχήμα γραμματοσειρών θέματος.

{{% alert color="info" title="Tip" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [PowerPoint Fonts](/slides/el/python-net/powerpoint-fonts/) .
{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Υπάρχουν δύο κοινές ροές εργασίας, και λύνουν διαφορετικά προβλήματα.

### **Διατήρηση Πηγαίου Θέματος Κατά τη Μετακίνηση Διαφανειών**

Εάν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχεδιασμό, κλωνοποιήστε τον πηγαίο master στην προοριστική παρουσίαση με το [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/add_clone/) , στη συνέχεια κλωνοποιήστε τη διαφάνεια με το [SlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/add_clone/) και τον κλωνοποιημένο master. Αυτό μεταφέρει μαζί του τον master, τις διατάξεις του και το σχετικό θέμα.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να διατηρηθεί ίδια στην προοριστική παρουσίαση. Η απλή κλωνοποίηση περιεχομένου σε έναν ανεξάρτητο master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, φόντους και εφέ που καθοδηγούνται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρχουσα Διαφάνεια**

Εάν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχοντα master και διάταξή της, αρχικοποιήστε μια παρακατάληψη σε επίπεδο διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), και [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) αντιγράφουν τα τρία κύρια στοιχεία του θέματος στην παρακατάληψη.

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

Αυτό αλλάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να αλλάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παρακατάληψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/clear/) .

### **Εφαρμογή Παρακατάληψης Θέματος σε Διάταξη**

Μια παρακατάληψη σε επίπεδο διάταξης εφαρμόζεται στις διαφάνειες που χρησιμοποιούν αυτήν τη διάταξη, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακατάληψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/layoutslidethememanager/) της διάταξης:

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

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίασης όταν πολλά layout και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παρακατάληψη διάταξης όταν μια οικογένεια διατάξεων χρειάζεται διαφορετικό στυλ, και μια παρακατάληψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Υπερβολικές παρακατάληψεις σε επίπεδο διαφάνειας κάνουν τις μεταγενέστερες παγκόσμιες αλλαγές θέματος πιο δύσκολο να προβλεφθούν.

## **Ενημέρωση Στυλ Φόντου Θέματος**

Τα γέμισματα φόντου του θέματος αποθηκεύονται στο [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) . Το PowerPoint μπορεί να εμφανίζει περισσότερες επιλογές φόντου στη διεπαφή του από τον αριθμό των ορισμών γεμίσματος που είναι φυσικά αποθηκευμένοι σε αυτή τη συλλογή, επειδή η UI μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ φόντου, επιθεωρήστε τη συλλογή που είναι αποθηκευμένη και το τρέχον [Background.style_index](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/style_index/) . `style_index` χρησιμοποιεί το `0` για κανένα θεματικό γέμισμα· θετικές τιμές είναι αναφορές στυλ φόντου θέματος. Αυτό διαφέρει από την ευρετηρίαση μιας συλλογής Python άμεσα, όπου το `[0]` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος φόντου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων φόντου, αντιστοιχίζει μια θεματική αναφορά φόντου στον πρώτο master και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την καταχώρηση θέματος στην οποία αναφέρεται ο master και από τυχόν παρακάμψεις φόντου στο επίπεδο διάταξης ή διαφάνειας. Εάν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου του master μπορεί να μην αλλάξει αυτή τη διαφάνεια. Χρησιμοποιήστε το [Background.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/get_effective/) όταν χρειάζεστε το τελικό φόντο μετά την εφαρμογή κληρονομικότητας.

{{% alert color="warning" title="Warning" %}}
Μην αντιμετωπίζετε το `style_index` ως δείκτη συλλογής βασισμένο στο μηδέν. Επίσης, αποφύγετε την σκληρή κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Για άμεση μορφοποίηση φόντου και κληρονομικότητα φόντου, δείτε το [Presentation Background](/slides/el/python-net/presentation-background/) .
{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές [FormatScheme.fill_styles](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/line_styles/), και [FormatScheme.effect_styles](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/effect_styles/) . Τα τυπικά θέματα Office συχνά περιλαμβάνουν τρεις κύριες καταχωρήσεις στυλ που αντιστοιχούν οπτικά σε ήπια, μετρίως έντονα και έντονα μορφοποίηση, αλλά ο κώδικας θα πρέπει να ελέγχει κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές σε Python, ο δείκτης της συλλογής είναι μηδενικός: το `[0]` είναι το πρώτο αποθηκευμένο στυλ και το `[2]` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτεθειμένη μέσω του [IShapeStyle](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishapestyle/) . Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει ότι οι απαιτούμενες καταχωρήσεις στυλ υπάρχουν, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ, και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής του θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος του θέματος γίνεται πυκνό δάσος πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 points. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποια θέσεις στυλ κάθε σχήμα αναφέρει και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι είναι ορισμένο σε συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή σχήμα μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) . Για ένα φόντο, χρησιμοποιήστε το [Background.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/get_effective/) , και για ένα γέμισμα, το [FillFormat.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/get_effective/) .

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το φόντο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

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

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικές απεικονίσεις, επικύρωση και συγκρίσεις. Εάν επιθεωρήσετε μόνο το [Presentation.master_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/master_theme/) , μπορείτε να χάσετε έναν master, διάταξη, διαφάνεια ή παρακάμψη σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω ένα θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω το master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/slidethememanager/) της διαφάνειας και αρχικοποιήστε το παρακάτω θέμα. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα.

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρω ένα θέμα από μια παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε τον πηγαίο master στον προορισμό και κλωνοποιήστε τη διαφάνεια με εκείνο τον master χρησιμοποιώντας τα [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/add_clone/) και [SlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/add_clone/) . Αυτό διατηρεί μαζί τον master, τις διατάξεις και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) για ένα θέμα διαφάνειας ή διάταξης και τις αντίστοιχες μεθόδους αποτελεσματικών‑δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/get_effective/) και το [FillFormat.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/get_effective/) . Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονομικότητας και παρακάμψεων.