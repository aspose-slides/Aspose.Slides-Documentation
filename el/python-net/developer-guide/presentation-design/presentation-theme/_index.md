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
- Παρουσίαση
- Python
- Aspose.Slides
description: "Διαχείριση θεμάτων παρουσίασης σε Aspose.Slides για Python μέσω .NET για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή εμπορική ταυτότητα."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει τις ιδιότητες των στοιχείων σχεδίασής του. Όταν επιλέγετε ένα θέμα, επιλέγετε ένα συντονισμένο σύνολο οπτικών στοιχείων και τις ιδιότητές τους.

Στο PowerPoint, ένα θέμα περιλαμβάνει χρώματα, [γραμματοσειρές](/slides/el/python-net/powerpoint-fonts/), [στυλ φόντου](/slides/el/python-net/presentation-background/), και εφέ.

![theme-constituents](theme-constituents.png)

## **Αλλαγή Χρώματος Θέματος**

Ένα θέμα PowerPoint χρησιμοποιεί συγκεκριμένο σύνολο χρωμάτων για διαφορετικά στοιχεία σε μια διαφάνεια. Αν δεν σας αρέσουν τα προεπιλεγμένα, μπορείτε να τα αλλάξετε εφαρμόζοντας νέα χρώματα θέματος. Για να σας επιτρέψει η Aspose.Slides την επιλογή νέου χρώματος θέματος, παρέχει τιμές στην αρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/python-net/aspose.slides/schemecolor/).

Αυτός ο κώδικας Python δείχνει πώς να αλλάξετε το χρώμα έμφασης ενός θέματος:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Μπορείτε να προσδιορίσετε την αποτελεσματική τιμή του προκύπτοντος χρώματος ως εξής:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Η έξοδος του παραδείγματος:
#
# ff8064a2 (Χρώμα [A=255, R=128, G=100, B=162])
```

Για να επιδείξουμε περαιτέρω την αλλαγή χρώματος, δημιουργούμε ένα άλλο στοιχείο, του αναθέτουμε το χρώμα έμφασης από το αρχικό βήμα και, στη συνέχεια, ενημερώνουμε το χρώμα θέματος.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Το νέο χρώμα εφαρμόζεται αυτόματα και στα δύο στοιχεία.

### **Ορισμός Χρώματος Θέματος από την Πρόσθετη Παλέτα**

Όταν εφαρμόζετε μετασχηματισμούς φωτεινότητας στο κύριο χρώμα θέματος (1), δημιουργούνται χρώματα από την πρόσθετη παλέτα (2). Στη συνέχεια μπορείτε να ορίσετε και να αποκτήσετε πρόσβαση σε αυτά τα χρώματα θέματος.

![additional-palette-colors](additional-palette-colors.png)

**1** — Κύρια χρώματα θέματος  
**2** — Χρώματα από την πρόσθετη παλέτα

Αυτός ο κώδικας Python δείχνει πώς τα χρώματα της πρόσθετης παλέτας προέρχονται από το κύριο χρώμα θέματος και στη συνέχεια χρησιμοποιούνται σε σχήματα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Έμφαση 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Έμφαση 4, Φωτεινότερο 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Έμφαση 4, Φωτεινότερο 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Έμφαση 4, Φωτεινότερο 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Έμφαση 4, Σκοτεινότερο 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Έμφαση 4, Σκοτεινότερο 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **Αντιστοίχιση `SchemeColor` σε Χρώματα `ColorScheme`**

Όταν εργάζεστε με [SchemeColor](https://reference.aspose.com/slides/el/python-net/aspose.slides/schemecolor/), ίσως παρατηρήσετε ότι περιέχει τις ακόλουθες τιμές χρώματος θέματος:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1` και `TEXT2`.

Ωστόσο, `Presentation.master_theme.color_scheme` επιστρέφει [ColorScheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/colorscheme/), το οποίο αποκαλύπτει τα αντίστοιχα χρώματα ως:

`dark1`, `dark2`, `light1` και `light2`.

Αυτή η διαφορά είναι μόνο στο ονομαστικό σύστημα. Οι τιμές αναφέρονται στα ίδια slots χρώματος θέματος και η αντιστοίχιση είναι σταθερή:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Δεν υπάρχει δυναμική μετατροπή μεταξύ `TEXT`/`BACKGROUND` και `dark`/`light`. Απλώς είναι εναλλακτικά ονόματα για τα ίδια χρώματα θέματος.

Αυτή η διαφορά ονομασίας προέρχεται από την ορολογία του Microsoft Office. Παλαιότερες εκδόσεις του Office χρησιμοποιούσαν `Dark 1`, `Light 1`, `Dark 2` και `Light 2`, ενώ οι νεότερες εκδόσεις UI εμφανίζουν τα ίδια slots ως `Text 1`, `Background 1`, `Text 2` και `Background 2`.

## **Αλλαγή Γραμματοσειράς Θέματος**

Για να μπορείτε να επιλέγετε γραμματοσειρές για θέματα και άλλους σκοπούς, η Aspose.Slides χρησιμοποιεί τα παρακάτω ειδικά αναγνωριστικά (παρόμοια με αυτά του PowerPoint):

- **+mn-lt** — Γραμματοσειρά σώματος Latin (Minor Latin Font)
- **+mj-lt** — Γραμματοσειρά κεφαλίδας Latin (Major Latin Font)
- **+mn-ea** — Γραμματοσειρά σώματος Ανατολικής Ασίας (Minor East Asian Font)
- **+mj-ea** — Γραμματοσειρά κεφαλίδας Ανατολικής Ασίας (Major East Asian Font)

Αυτός ο κώδικας Python δείχνει πώς να αντιστοιχίσετε τη γραμματοσειρά Latin σε στοιχείο θέματος:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Αυτό το παράδειγμα Python δείχνει πώς να αλλάξετε τη γραμματοσειρά θέματος της παρουσίασης:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Όλα τα πλαίσια κειμένου θα ενημερωθούν στη νέα γραμματοσειρά.

{{% alert color="primary" title="ΣΥΜΒΟΥΛΗ" %}}
Για περισσότερες πληροφορίες, δείτε [Κύριες Γραμματοσειρές PowerPoint με Python](/slides/el/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Αλλαγή Στυλ Φόντου Θέματος**

Από προεπιλογή, το PowerPoint παρέχει 12 προκαθορισμένα φόντα, αλλά μια τυπική παρουσίαση αποθηκεύει μόνο 3 από αυτά.

![todo:image_alt_text](presentation-design_8.png)

Για παράδειγμα, αφού αποθηκεύσετε μια παρουσίαση στο PowerPoint, μπορείτε να εκτελέσετε τον παρακάτω κώδικα Python για να προσδιορίσετε πόσα προκαθορισμένα φόντα περιέχει:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Χρησιμοποιώντας την ιδιότητα `background_fill_styles` από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/), μπορείτε να προσθέσετε ή να προσπελάσετε στυλ φόντου σε ένα θέμα PowerPoint.
{{% /alert %}}

Αυτό το παράδειγμα Python δείχνει πώς να ορίσετε το φόντο της παρουσίασης:

```python
presentation.masters[0].background.style_index = 2  # 0 δηλώνει χωρίς γέμισμα· η αρίθμηση ξεκινά από 1.
```

{{% alert color="primary" title="ΣΥΜΒΟΥΛΗ" %}}
Για περισσότερες πληροφορίες, δείτε [Διαχείριση Φόντων Παρουσίασης σε Python](/slides/el/python-net/presentation-background/).
{{% /alert %}}

## **Αλλαγή Εφέ Θέματος**

Ένα θέμα PowerPoint περιλαμβάνει συνήθως τρεις τιμές σε κάθε σειρά στυλ. Αυτές οι σειρές συνδυάζονται σε τρία επίπεδα εφέ: λεπτό, μετριοπαφές και έντονα. Για παράδειγμα, εδώ είναι το αποτέλεσμα όταν αυτά τα εφέ εφαρμόζονται σε ένα συγκεκριμένο σχήμα:

![todo:image_alt_text](presentation-design_10.png)

Χρησιμοποιώντας τις τρεις ιδιότητες—`FillStyles`, `LineStyles` και `EffectStyles`—από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/formatscheme/), μπορείτε να τροποποιήσετε στοιχεία θέματος (ακόμη πιο ευέλικτα από το PowerPoint).

Αυτός ο κώδικας Python δείχνει πώς να αλλάξετε ένα εφέ θέματος τροποποιώντας τμήματα αυτών των στοιχείων:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Οι αλλαγές που προκύπτουν περιλαμβάνουν ενημερώσεις στο χρώμα γεμίσματος, τύπο γεμίσματος, εφέ σκιάς και άλλες ιδιότητες:

![todo:image_alt_text](presentation-design_11.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω το master;**

Ναι. Η Aspose.Slides υποστηρίζει παραμετροποίηση θέματος σε επίπεδο διαφάνειας, ώστε να μπορείτε να εφαρμόσετε τοπικό θέμα μόνο σε αυτή τη διαφάνεια διατηρώντας αμετάβλητο το master theme (μέσω του [SlideThemeManager](https://reference.aspose.com/slides/el/python-net/aspose.slides.theme/slidethememanager/)).

**Ποιος είναι ο ασφαλέστερος τρόπος για να μεταφέρω ένα θέμα από μια παρουσίαση σε άλλη;**

[Clone slides](/slides/el/python-net/clone-slides/) μαζί με το master τους στην προοριστική παρουσίαση. Αυτό διατηρεί το αρχικό master, τις διατάξεις και το συσχετισμένο θέμα ώστε η εμφάνιση να παραμένει συνεπής.

**Πώς μπορώ να δω τις «αποτελεσματικές» τιμές μετά από όλες τις κληρονομήσεις και υπερκαλύψεις;**

Χρησιμοποιήστε τις «αποτελεσματικές» προβολές του API [/slides/el/python-net/shape-effective-properties/] για θέμα/χρώμα/γραμματοσειρά/εφέ. Αυτές επιστρέφουν τις επιλυμένες, τελικές ιδιότητες μετά την εφαρμογή του master και τυχόν τοπικών υπερκαλύψεων.