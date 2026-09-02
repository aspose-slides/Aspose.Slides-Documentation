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
- Εξωτερικό θέμα
- THMX
- Χρώμα θέματος
- Επιπλέον παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- Python
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για Python μέσω .NET για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπής εταιρική ταυτότητα."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμίσματα, γραμμές και εφέ. Τα αντικείμενα που είναι ενήμερα για το θέμα αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα επιπέδου παρουσίασης είναι διαθέσιμο μέσω της ιδιότητας [Presentation.master_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/master_theme/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας κύριος (master) μπορεί να παρακάμψει το θέμα παρουσίασης μέσω του [MasterThemeManager.override_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/masterthememanager/override_theme/), μια διάταξη μπορεί να παρακάμψει το κληρονομημένο της θέμα μέσω του [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), και μια μεμονωμένη διαφάνεια μπορεί να κάνει το ίδιο. Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη διάταξης και παράκαμψη διαφάνειας.

![Συνιστώσες θέματος: χρώματα, γραμματοσειρές, στυλ φόντου και εφέ](theme-constituents.png)

Τα τμήματα παρακάτω παρουσιάζουν τις πιο κοινές ροές εργασίας με θέματα: επιθεώρηση θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονομικότητα και τις παρακάμψεις.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/mastertheme/) εκθέτει τις ιδιότητες [color_scheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/mastertheme/font_scheme/) και [format_scheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/mastertheme/format_scheme/). Η επιθεώρηση αυτών των συλλογών πριν από την αλλαγή τους είναι ιδιαίτερα χρήσιμη όταν μια παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρήσεων στυλ μπορούν να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσα στυλ φόντου, γεμίσματος, γραμμής και εφέ είναι αποθηκευμένα στο θέμα:

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

Αν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μη υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που φαίνεται αργότερα σε αυτό το άρθρο όταν μπορεί να υπάρχουν παρακάμψεις διάταξης ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι ενήμερα για το θέμα μπορούν να αναφέρονται σε ένα λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/python-net/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στο [ColorScheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/colorscheme/) του θέματος, όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε αυτό το χρώμα θέματος λύνουν την τιμή τους με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με μια ενημέρωση χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί το `ACCENT4`, αλλάζει το χρώμα `accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο στο `ACCENT4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, οι μεταγενέστερες αλλαγές στο `accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από το Επιπλέον Παλέτο**

Το PowerPoint παράγει πιο ανοιχτές και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρωμάτων. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω της απαρίθμησης [ColorTransformOperation](https://reference.aspose.com/slides/el/python-net/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και πιο ανοιχτές/σκούρες χρώματα που δημιουργούνται από το επιπλέον παλέτο](additional-palette-colors.png)

**1** – Κύρια χρώματα θέματος.

**2** – Πιο ανοιχτές και πιο σκούρες παραλλαγές που προέρχονται από τα κύρια χρώματα θέματος.

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

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα υπολογίζονται εκ νέου από τη νέα τιμή `accent4`.

### **Αντιστοίχιση Τιμών `SchemeColor` σε Θέσεις `ColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/python-net/aspose.slides/schemecolor/) χρησιμοποιεί τα `TEXT1`, `BACKGROUND1`, `TEXT2` και `BACKGROUND2`, ενώ το [ColorScheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/colorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `dark1`, `light1`, `dark2` και `light2`. Η αντιστοίχιση είναι σταθερή:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Αυτές είναι εναλλακτικές ονομασίες για τις ίδιες θέσεις θέματος· δεν πρόκειται για τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιέχει ένα κύριο σύνολο γραμματοσειρών για τις επικεφαλίδες και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι ιδιότητες [FontScheme.major](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/fontscheme/major/) και [FontScheme.minor](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/fontscheme/minor/) εκθέτουν αυτά τα σύνολα.

Οι ταυτοποιητές γραμματοσειρών θέματος συμβατοί με το PowerPoint μπορούν να χρησιμοποιηθούν σε μορφοποίηση κειμένου:

* `+mn-lt` – Σώμα κειμένου Λατινικό (Μικρή Λατινική Γραμματοσειρά)
* `+mj-lt` – Επικεφαλίδα Λατινική (Μεγάλη Λατινική Γραμματοσειρά)
* `+mn-ea` – Σώμα κειμένου Ανατολική Ασία (Μικρή Ασιατική Γραμματοσειρά)
* `+mj-ea` – Επικεφαλίδα Ανατολική Ασία (Μεγάλη Ασιατική Γραμματοσειρά)

Το παρακάτω παράδειγμα δημιουργεί μια επικεφαλίδα που χρησιμοποιεί τη μεγαλύτερη λατινική γραμματοσειρά θέματος και μια γραμμή σώματος που χρησιμοποιεί τη μικρότερη λατινική γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Η επικεφαλίδα ακολουθεί τη μεγάλη γραμματοσειρά και το κυρίως κείμενο τη μικρή γραμματοσειρά. Το κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για ταυτοποιητή θέματος δεν θα αλλάξει αυτόματα όταν το σχήμα γραμματοσειρών θέματος αλλάξει.

Οι μεγάλες και μικρές συλλογές γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλικό, αραβικό, ιαπωνικό, γεωργιανό και θανα. Για επιθεώρηση, προσθήκη, αντικατάσταση ή αφαίρεση αυτών των αντιστοιχίσεων, δείτε [Script-Specific Theme Fonts](/slides/el/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Συμβουλή" %}}

Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [PowerPoint Fonts](/slides/el/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα που σχετίζονται με θέματα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες Εξαρτώμενες από Master**

Χρησιμοποιήστε το [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να αλλάξετε το στυλ κάθε διαφάνειας που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.masters](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/masters/), η οποία υλοποιεί το [MasterSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/), και περάστε το μονοπάτι του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες εργασίες:

1. Δημιουργεί μια νέα master διαφάνεια βασισμένη στον επιλεγμένο master.  
2. Εφαρμόζει το εξωτερικό θέμα στη νέα master.  
3. Αναθέτει τη νέα master σε όλες τις διαφάνειες που προηγουμένως εξαρτώνταν από τον επιλεγμένο master.  
4. Επιστρέφει το νεοδημιουργημένο [IMasterSlide](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasterslide/).

Το παρακάτω παράδειγμα εφαρμόζει ένα εξωτερικό θέμα στις διαφάνειες που εξαρτώνται από τον πρώτο master και αποθηκεύει την παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxexception/) ή μία από τις υποκλάσεις του που σχετίζονται με μορφές. Επικυρώστε τις διαδρομές που παρέχονται από χρήστες, χειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα εφαρμοστεί με επιτυχία.

Μόνον οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master επανατοποθετούνται. Διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα τους. Τα χρώματα, γραμματοσειρές, γεμίσματα, γραμμές, φόντοι και εφέ που είναι ενήμερα για το θέμα λύνωνται με βάση το εξωτερικό θέμα. Τα χρώματα, γραμματοσειρές, γεμίσματα και άλλες άμεσες μορφοποιήσεις που έχουν δοθεί απευθείας ενδέχεται να μείνουν αμετάβλητα. Οι παρακάμψεις σε επίπεδο διάταξης και διαφάνειας μπορούν επίσης να προτεραιοποιηθούν έναντι των τιμών που κληρονομούνται από το νέο master.

Το θέμα μπορεί να αναφέρεται σε γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, προσφέρετέ τες μέσω [custom font sources](/slides/el/python-net/custom-font/), ή ρυθμίστε την [font substitution](/slides/el/python-net/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας σε επίπεδο master: η μέθοδος δέχεται μονοπάτι αρχείου `.thmx` και δεν απαιτεί τη χειροκίνητη δημιουργία παρακάμψεων σε επίπεδο διαφάνειας ή διάταξης.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση Πολλαπλών Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω του [Slide.layout_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/layout_slide/) και του [LayoutSlide.master_slide](https://reference.aspose.com/slides/el/python-net/aspose.slides/layoutslide/master_slide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε τυχόν θέματα, επειδή κάθε κλήση δημιουργεί έναν νέο master στην παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί διαφάνειες από δύο ενότητες για να εντοπίσει τους masters τους και εφαρμόζει διαφορετικό εξωτερικό θέμα σε κάθε ομάδα:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `first_group_master`, και η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `second_group_master`. Διαφάνειες που ανήκουν σε οποιονδήποτε άλλο master δεν επανασχεδιάζονται.

### **Διατήρηση Πηγής Θέματος κατά τη Μετακίνηση Διαφανειών**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον source master στην προοριστική παρουσίαση με το [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/add_clone/), έπειτα κλωνοποιήστε τη διαφάνεια με το [SlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/add_clone/) και τον κλωνοποιημένο master. Αυτό μεταφέρει μαζί του τον master, τις διατάξεις του και το σχετικό θέμα.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να μοιάζει ακριβώς με την προοριστική. Η απλή κλωνοποίηση περιεχομένου σε έναν μη σχετικό master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, φόντους και εφέ που καθορίζονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υφιστάμενη Διαφάνεια**

Αν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχοντα master και διάταξη, αρχικοποιήστε μια παράκαμψη επιπέδου διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) και [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) αντιγράφουν τα τρία κύρια συστατικά του θέματος στην παράκαμψη.

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

Αυτό αλλάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να αλλάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παράκαμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.clear](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/overridetheme/clear/).

### **Εφαρμογή Παρακάμψης Θέματος σε Διάταξη**

Μια παράκαμψη σε επίπεδο διάταξης εφαρμόζεται σε διαφάνειες που χρησιμοποιούν εκείνη τη διάταξη, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παράκαμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίασης όταν πολλές διατάξεις και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παράκαμψη διάταξης όταν μία οικογένεια διατάξεων χρειάζεται διαφορετικό στυλ, και μια παράκαμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Η υπερβολική χρήση παρακάμψεων επιπέδου διαφάνειας κάνει τις μεταγενέστερες παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Φόντου Θέματος**

Τα στυλ φόντου του θέματος αποθηκεύονται στο [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές φόντου στη διεπαφή χρήστη του από τον αριθμό των γεμίσεων που αποθηκεύονται φυσικά σε αυτή τη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσεις θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ φόντου PowerPoint για ένα θέμα παρουσίασης](presentation-design_8.png)

Προτού χρησιμοποιήσετε ένα στυλ φόντου, επιθεωρήστε τη αποθηκευμένη συλλογή και το τρέχον [Background.style_index](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/style_index/). Το `style_index` χρησιμοποιεί το `0` για κανένα θέμα γεμίσματος· οι θετικές τιμές είναι αναφορές σε στυλ φόντου θέματος. Αυτό διαφέρει από την απευθείας πρόσβαση σε μια συλλογή Python, όπου το `[0]` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ φόντου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμίσεων φόντου, αναθέτει μια αναφορά φόντου θέματος στον πρώτο master και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την καταχώρηση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις φόντου στη διάταξη ή στη διαφάνεια. Αν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου του master μπορεί να μην αλλάξει εκείνη τη διαφάνεια. Χρησιμοποιήστε το [Background.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/get_effective/) όταν χρειάζεστε την τελική φόντο μετά την εφαρμογή κληρονομικότητας.

{{% alert color="warning" title="Προειδοποίηση" %}}

Μην αντιμετωπίζετε το `style_index` ως δείκτη μηδενικής βάσης. Αποφύγετε επίσης την σκληρή κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.

{{% /alert %}}

{{% alert color="info" title="Συμβουλή" %}}

Για άμεση μορφοποίηση φόντου και κληρονομικότητα φόντου, δείτε το [Presentation Background](/slides/el/python-net/presentation-background/).

{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές [FormatScheme.fill_styles](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/line_styles/) και [FormatScheme.effect_styles](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/effect_styles/). Τα τυπικά θέματα Office συχνά περιέχουν τρεις κύριες καταχωρήσεις στυλ που αντιστοιχούν οπτικά σε διακριτά, μέτρια και έντονα μορφοποιημένα στυλ, αλλά ο κώδικας πρέπει να επιθεωρεί κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Διακριτά, μέτρια και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές σε Python, ο δείκτης της συλλογής είναι μηδενικής βάσης: το `[0]` είναι το πρώτο αποθηκευμένο στυλ και το `[2]` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτεθειμένη μέσω του [IShapeStyle](https://reference.aspose.com/slides/el/python-net/aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· τα σχήματα με άμεση μορφοποίηση μπορεί να μείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν οι απαιτούμενες καταχωρήσεις στυλ υπάρχουν, αλλάζει το πρώτο στυλ γραμμής, το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ, και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, η πρώτη γραμμή θέματος γίνεται κόκκινη, το τρίτο γέμισμα θέματος γίνεται συμπαγές δάσος πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 μονάδων. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποια θέσεις στυλ αναφέρονται κάθε σχήμα και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και σκιάς](presentation-design_11.png)

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι ορίζεται σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή σχήμα μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Για φόντο, χρησιμοποιήστε το [Background.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/get_effective/), και για γέμισμα, το [FillFormat.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/get_effective/).

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

Χρησιμοποιήστε αποτελεσματικά δεδομένα για διαγνωστικούς σκοπούς απόδοσης, επαλήθευση και συγκρίσεις. Αν επιθεωρήσετε μόνο το [Presentation.master_theme](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/master_theme/), μπορεί να χάσετε έναν master, διάταξη, διαφάνεια ή παράκαμψη σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Επηρεάζει η εφαρμογή εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Το [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) επαναλαμβάνει μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/slidethememanager/) της διαφάνειας και αρχικοποιήστε το θέμα παράκαμψης της. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο ασφαλέστερος τρόπος για να μεταφέρω ένα θέμα από μία παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής εμφάνισής της, κλωνοποιήστε τον source master στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τα [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/add_clone/) και [SlideCollection.add_clone](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/add_clone/). Αυτό διατηρεί τον master, τις διατάξεις και το θέμα μαζί.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) για ένα θέμα διαφάνειας ή διάταξης και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/background/get_effective/) και το [FillFormat.get_effective](https://reference.aspose.com/slides/el/python-net/aspose.slides/fillformat/get_effective/). Αυτά τα APIs επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονομικότητας και παρακάμψεων.