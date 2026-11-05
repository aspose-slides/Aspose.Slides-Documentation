---
title: Μορφοποίηση Σχημάτων PowerPoint σε Python
linktitle: Μορφοποίηση Σχημάτων
type: docs
weight: 20
url: /el/python-net/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκέτσας
- γραμμή σχήματος σκέτσας
- μορφοποίηση στυλ σύνδεσης
- γέμιση διαβάθμισης
- γέμιση μοτίβου
- γέμιση εικόνας
- γέμιση υφής
- συμπαγής γέμιση χρώματος
- διαφάνεια σχήματος
- αποτύπωση σχήματος ασπρόμαυρου
- αποτύπωση σχήματος σε κλίμακα του γκρι
- περιστροφή σχήματος
- εφέ 3D φρεσκας
- εφέ 3D περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Python χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Διαμορφώστε σχήματα στο PowerPoint προσαρμόζοντας τα περιγράμματα, τις γεμίσεις και τα εφέ τους. Το Aspose.Slides for Python μέσω .NET σας επιτρέπει να ελέγχετε αυτές τις ρυθμίσεις προγραμματιστικά, συμπεριλαμβανομένης της διαφάνειας, της περιστροφής και της 3Δ μορφοποίησης.

![Επιλογές μορφοποίησης σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for Python μέσω .NET παρέχει κλάσεις και ιδιότητες που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιήστε [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) για να ελέγξετε το περίγραμμα ενός σχήματος. Αυτό το παράδειγμα δημιουργεί ένα άσπρο ορθογώνιο με μπλε, διακεκομμένο περίγραμμα. Το [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) επιλέγει μια γραμμή σύνθεσης παχιά‑λεπτή, ενώ το [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) ορίζει το πλάτος της σε 7 σημεία και το [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) επιλέγει το μοτίμο διακεκομμένης γραμμής.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

### **Ορισμός Προσαρμοσμένων Μοτίβων Διακεκομμένων Γραμμών**

Χρησιμοποιήστε [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) όταν τα προεπιλεγμένα στυλ γραμμής δεν παρέχουν τα μήκη και τα κενά που χρειάζεστε, π.χ. για εταιρικά περιγράμματα ή τεχνικά διαγράμματα. Η ανάθεση ενός μοτίβου ορίζει αυτόματα το [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) σε [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Οι καταχωρίσεις της λίστας εναλλάσσονται μεταξύ μήκους γραμμής και κενών, ξεκινώντας με γραμμή. Κάθε τιμή είναι πολλαπλάσιο του πλάτους της γραμμής: `[4, 2]` με πλάτος 3 σημείων παράγει γραμμή 12 σημείων και κενό 6 σημείων. Χρησιμοποιήστε ζεύγη πεπερασμένων, μη αρνητικών τιμών για να ορίσετε πλήρη τμήματα γραμμής‑κενό. Το παράδειγμα χρησιμοποιεί θετικές τιμές ώστε κάθε γραμμή και κενό να είναι ορατά.

Αυτό το παράδειγμα δημιουργεί πέντε μπλε γραμμές ίδιου μήκους και επίπεδων άκρων. Οι πρώτες τρεις συγκρίνουν μοτίβα με πλάτος 3 σημείων. Η τέταρτη επαναλαμβάνει το πρώτο μοτίβο με διπλάσιο πλάτος, αυξάνοντας τόσο τη γραμμή όσο και το κενό. Η πέμπτη αλλάζει από προσαρμοσμένο μοτίβο σε συμπαγή γραμμή.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Επιστρέψτε την τελευταία γραμμή σε συμπαγό στυλ.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Για να επιστρέψετε σε προεπιλεγμένο διακεκομμένο στυλ, αντιστοιχίστε το [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) στο [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Το επιλεγμένο στυλ ελέγχει την εμφάνιση της γραμμής.

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **{4, 2}, 3 pt**· **{1, 2}, 3 pt**· **{6, 2, 1, 2}, 3 pt**· **{4, 2}, 6 pt**· και **Solid, 3 pt**.

![Τρία προσαρμοσμένα μοτίβα διακεκομμένης γραμμής, μια πιο πλατιά γραμμή με το πρώτο μοτίβο και μια συμπαγή γραμμή στο PowerPoint](custom-dash-patterns.png)

### **Ορισμός Άκρων Γραμμής**

Χρησιμοποιήστε [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) για να ορίσετε τα άκρα μιας ανοιχτής γραμμής. Η απαρίθμηση [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) παρέχει τρία ρητά στυλ άκρων:

- `FLAT`: Η γραμμή σταματά στο άκρο.
- `ROUND`: Ένα ημικύκλιο άκρο εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.
- `SQUARE`: Ένα τετράγωνο άκρο εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.

Η απαρίθμηση περιλαμβάνει επίσης το `NOT_DEFINED`, που σημαίνει ότι δεν έχει οριστεί ρητά κάποιο στυλ άκρου.

Τα άκρα διαφέρουν από τις κεφαλές βέλους, που προσθέτουν σύμβολα στα άκρα, και από τις συνδέσεις, που ελέγχουν τις γωνίες μεταξύ τμημάτων γραμμής. Αυτό το παράδειγμα απενεργοποιεί τις κεφαλές βέλους μέσω των [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) και [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) ώστε να συγκριθούν μόνο τα σχήματα άκρων.

Το ακόλουθο παράδειγμα δημιουργεί τρεις οριζόντιες γραμμές με τα ίδια χαρακτηριστικά, πλάτους 20 σημείων. Από πάνω προς τα κάτω, χρησιμοποιούν επίπεδα, στρογγυλεμένα και τετράγωνα άκρα. Τα άκρα τους έχουν τις ίδιες οριζόντιες συντεταγμένες· τα στρογγυλεμένα και τετράγωνα άκρα εκτείνονται 10 σημεία πέρα από κάθε άκρο.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **Flat**, **Round**, και **Square**.

![Επίπεδα, στρογγυλεμένα και τετράγωνα άκρα σε πανομοιότυπες παχιές γραμμές στο PowerPoint](line-caps.png)

## **Εφαρμογή Εφέ Σκέτσας σε Γραμμές Σχήματος**

Ένα εφέ σκέτσας κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) για πρόσβαση στις ρυθμίσεις γραμμής, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) για πρόσβαση στις ρυθμίσεις σκέτσας, και [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) για επιλογή τιμής από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά εκχωρημένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Η τιμή που επιστρέφει το [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) αντιπροσωπεύει τη ρύθμιση που έχει εκχωρηθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από θέμα, κύρια διαφάνεια ή διάταξη, χρησιμοποιήστε το [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), προσπελάστε το [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/) και διαβάστε το [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά αφού επιλυθεί η κληρονομικότητα. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με τουλάχιστον ένα σχήμα στην πρώτη διαφάνεια και εκτυπώνει και τις δύο τιμές:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Μορφοποίηση Στυλ Συμμετρίας (Join Styles)**

Ακολουθούν οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Το στυλ σύνδεσης ελέγχει πώς δύο τμήματα περιγράμματος συναντώνται σε γωνία. Χρησιμοποιήστε **Round** για στρογγυλεμένες γωνίες, **Miter** για αιχμηρές γωνίες ή **Bevel** για επίπεδες γωνίες.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Αυτό το παράδειγμα δημιουργεί τρία μαύρα ορθογώνια με μπλε περιγράμματα πλάτους 15 σημείων. Ορίζει το [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) σε miter, bevel και round τιμές της [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), αντίστοιχα, ώστε να συγκριθεί η σχεδίαση των γωνιών.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Περιορισμός Σύνδεσεων Miter σε Αιχμηρές Γωνίες**

Χρησιμοποιήστε το [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) μαζί με το [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) ορισμένο σε [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) για να περιορίσετε το πόσο μπορεί να εκτείνεται μια αιχμηρή γωνία.

Το όριο είναι ένας λόγος της απόστασης μεταξύ των εσωτερικών και εξωτερικών γωνιών της σύνδεσης προς το πλάτος της γραμμής. Για παράδειγμα, η τιμή `8` επιτρέπει μήκος miter έως και οκτώ φορές το πλάτος της γραμμής· δεν είναι μέτρηση σε σημεία. Εάν η γωνία υπερβεί το όριο, το PowerPoint χρησιμοποιεί μια καμπυλωτή (beveled) σύνδεση σε εκείνη τη γωνία. Μεγαλύτερο όριο επιτρέπει πιο αιχμηρά σημεία. Η ρύθμιση επηρεάζει μόνο τις συνδέσεις miter και δεν έχει ορατό αποτέλεσμα όταν η γωνία παραμείνει εντός των ορίων.

Αυτό το παράδειγμα δημιουργεί δύο όμοια, αδιάβατα τρίγωνα με περιγράμματα πλάτους 20 σημείων. Το αριστερό τρίγωνο χρησιμοποιεί όριο `2`, και το δεξιό `8`. Κάθε τρίγωνο έχει πλάτος 80 σημείων και ύψος 160 σημείων, δίνοντας στην κορυφή του λόγο μήκους miter προς πλάτος γραμμής περίπου `4.12`. Συνεπώς, το PowerPoint καμπυλώνει την αριστερή κορυφή και διατηρεί την δεξιά.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα στο PowerPoint: **Miter limit 2** στα αριστερά και **miter limit 8** στα δεξιά.

![Μια καμπυλωτή κορυφή με όριο miter 2 και μια αιχμηρή κορυφή με όριο miter 8 στο PowerPoint](miter-limits.png)

## **Γέμιση Διαβάθμισης (Gradient Fill)**

Μια γέμιση διαβάθμισης αναμειγνύει χρώματα διαμέσου ενός σχήματος. Αυτό το παράδειγμα γεμίζει μια έλλειψη με γραμμική διαβάθμιση υπό γωνία 45 μοιρών από κόκκινο σε μωβ χρησιμοποιώντας το [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Η μέθοδος [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) τοποθετεί τα χρώματα στα 0 και 1, την αρχή και το τέλος της διαβάθμισης. Η εκκαθάριση των υπαρχόντων διαστημάτων εξασφαλίζει ότι χρησιμοποιούνται μόνο αυτά τα δύο χρώματα.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η έλλειψη με γέμιση διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε εξαγόμενο εικόνα από ό,τι στο PowerPoint, δείτε το [Choose a Gradient Rendering Style](/slides/el/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε τη αποθηκευμένη διαβάθμιση στην παρουσίαση.

### **Ορισμός Γωνίας Γραμμικής Διαβάθμισης**

Χρησιμοποιήστε το [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) για έλεγχο του προσανατολισμού μιας γέμισης [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). Η γωνία μετριέται σε μοίρες και αυξάνει δεξιόστροφα: `0` από τα αριστερά προς τα δεξιά, `90` από πάνω προς τα κάτω, `180` από τα δεξιά προς τα αριστερά, και `270` από το κάτω προς το πάνω. Υποστηρίζονται κλασματικές γωνίες. Οι πεπερασμένες γωνίες εκτός του εύρους `[0, 360)` κανονικοποιούνται σε μία πλήρη περιστροφή· π.χ. `-45` γίνεται `315` και `360` γίνεται `0`.

Αυτό το παράδειγμα δημιουργεί έξι ορθογώνια με τα ίδια κόκκινα, πράσινα και μπλε σημεία στα `0`, `0.5` και `1`. Η κλιμάκωση είναι ανενεργή ώστε η γωνία να συγκρίνεται ανεξάρτητα από τις αναλογίες των ορθογώνιων. Οι γωνίες, από αριστερά προς δεξιά, είναι `0`, `45` και `90` στην πρώτη σειρά, και `135`, `180` και `270` στη δεύτερη σειρά.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα στο PowerPoint:

![Γραμμικές διαβάθμιση στις γωνίες 0, 45 και 90 μοίρες στην επάνω σειρά, και 135, 180 και 270 μοίρες στην κάτω σειρά](linear-gradient-angles.png)

### **Κλιμάκωση Γραμμικής Διαβάθμισης με το Σχήμα**

Το [GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) δέχεται τιμή τύπου [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Ορίστε το ρητά σε `FALSE` για να διατηρείται η γεωμετρική γωνία της διαβάθμισης όταν αλλάζουν οι αναλογίες του σχήματος, ή σε `TRUE` για κλιμάκωση της διαβάθμισης με το πλάτος και το ύψος του σχήματος. Με την κλιμάκωση ενεργοποιημένη, η ορατή γωνία μπορεί να διαφέρει από την καθορισμένη γωνία σε μη τετράγωνο σχήμα.

Το παρακάτω παράδειγμα χρησιμοποιεί γωνία `45` μοιρών και τα ίδια χρώματα όπως στην σύγκριση γωνιών. Η αριστερή στήλη χρησιμοποιεί `FALSE`; η δεξιά `TRUE`. Κάθε στήλη περιλαμβάνει ένα πλατύ ορθογώνιο πάνω από ένα ψηλό ορθογώνιο. Και τα δύο ξεκινούν με τις ίδιες πλατιές διαστάσεις· η αλλαγή του πλάτους και του ύψους του δεύτερου ορθογωνίου δείχνει πώς η γέμιση αντιδρά στην αλλαγή μεγέθους χωρίς αλλαγή των ρυθμίσεων διαβάθμισης.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα στο PowerPoint, με κλιμάκωση ανενεργή στα αριστερά και ενεργή στα δεξιά:

![Πλατιά και ψηλά ορθογώνια με γέμιση 45 μοιρών, συγκρίνοντας linear_gradient_scaled FALSE στα αριστερά με TRUE στα δεξιά](linear-gradient-scaling.png)

Με κλιμάκωση ανενεργή, οι διαγώνιες λωρίδες χρώματος διατηρούν τον ίδιο προσανατολισμό και στα δύο ορθογώνια. Με κλιμάκωση ενεργή, οι λωρίδες τεντώνονται με τις αναλογίες του σχήματος. Αυτό βοηθά στην επαναδημιουργία μιας διαβάθμισης προτύπου όταν προσαρμόζετε ένα σχήμα σε διαφορετικό μέγεθος. Σε τετράγωνο σχήμα, η ενεργοποίηση της κλιμάκωσης δεν αλλάζει την εμφάνιση αυτής της διαβάθμισης `45` μοιρών.

Τanto η γωνία όσο και η κλιμάκωση ισχύουν για γραμμικές διαβάθμιση. Δεν ελέγχουν γεμίσεις [GradientShape.RADIAL ή GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Συνδυασμός Γωνίας με Κατεύθυνση Διαβάθμισης**

Το [GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) επιλέγει στυλ διαβάθμισης από την απαρίθμηση [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); δεν αποτελεί υποκατάστατο αριθμητικής γωνίας. Για γραμμική διαβάθμιση, τα στυλ γωνιών μπορούν να αλλάξουν την περιοχή κατανομής χρωμάτων χωρίς αλλαγή του [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Διατηρήστε την κατεύθυνση αμετάβλητη όταν συγκρίνετε γωνίες ή κλιμάκωση.

Το παρακάτω παράδειγμα εφαρμόζει τις ίδιες ρυθμίσεις με αντίστροφη σειρά. Τα δύο ορθογώνια έχουν την ίδια εμφάνιση: η ανάθεση της κατεύθυνσης πριν ή μετά τη γωνία δεν αλλάζει το αποτέλεσμα.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Γέμιση Κανονισμού (Pattern Fill)**

Μια γέμιση κανονισμού εφαρμόζει σχέδιο δύο χρωμάτων, όπως σημεία, λωρίδες ή σκαλοπάτια. Αυτό το παράδειγμα χρησιμοποιεί το [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) για επιλογή μοτίβου πλέγματος. Το [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) παρέχει το ανοιχτό γκρι φόντο, και το [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) το κίτρινο χρώμα του μοτίβου.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμιση κανονισμού](pattern-fill.png)

## **Γέμιση Εικόνας (Picture Fill)**

Μια γέμιση εικόνας χρησιμοποιεί μια εικόνα εντός ενός σχήματος. Αυτό το παράδειγμα απαιτεί τοπική εικόνα και χρησιμοποιεί το [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) για να τη φορτώσει στη συλλογή εικόνων της παρουσίασης. Ορίζοντας το [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) σε tiled mode, η εικόνα επαναλαμβάνεται μέσα στο ορθογώνιο. Η πηγαία εικόνα που χρησιμοποιείται εμφανίζεται παρακάτω:

![Η εικόνα λωτό](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το σχήμα με γέμιση εικόνας](picture-fill.png)

### **Επένδυση Εικόνας σε Υφασμάτωση (Tile Picture As Texture)**

Εάν θέλετε να ορίσετε μια επενδυμένη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της επένδυσης, μπορείτε να χρησιμοποιήσετε τις ακόλουθες ιδιότητες της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Ορίζει τη λειτουργία γέμισης εικόνας — είτε `TILE` είτε `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων εντός του σχήματος.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Ελέγχει εάν το πλακίδιο αναστρέφεται οριζόντια, κάθετα ή και τα δύο.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Καθορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Καθορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Αυτό το παράδειγμα απαιτεί τοπική εικόνα και διαμορφώνει το [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) ώστε να την επαναλαμβάνει στο 50 % του αρχικού μεγέθους. Οι μετατοπίσεις −32 σημείων μετακινούν τα πλακίδια οριζόντια και κάθετα· η ευθυγράμμιση κάτω‑δεξιά και η αναστροφή και στις δύο κατευθύνσεις καθορίζουν πώς διατάσσεται η επαναλαμβανόμενη υφή.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Συμπαγής Γέμιση Χρώματος (Solid Color Fill)**

Μια συμπαγής γέμιση δίνει σε ένα σχήμα ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το παράδειγμα ορίζει το [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε λειτουργία συμπαγούς γέμισης και αναθέτει κίτρινο μέσω του [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), στη συνέχεια αποθηκεύει το ορθογώνιο στην παρουσίαση.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το σχήμα με συμπαγή γέμιση χρώματος](solid-color-fill.png)

### **Αντιγραφή Χρωμάτων Διατηρώντας Αναφορές Θέματος**

Χρησιμοποιήστε το [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) για να αντιγράψετε έναν ορισμό χρώματος, συμπεριλαμβανομένου του τύπου χρώματος, της αναφοράς θέματος και των μετασχηματισμών. Αυτό είναι χρήσιμο όταν μεταφέρετε χρώμα γέμισης μεταξύ σχημάτων που πρέπει να συνεχίσουν να ακολουθούν το θέμα της παρουσίασης. Η μέθοδος αντιγράφει μόνο το χρώμα: δεν αντιγράφει τον τύπο γέμισης, το περίγραμμα ή άλλες μορφοποιήσεις σχήματος. Ορίστε ρητά το [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) του προορισμού.

Αυτό το παράδειγμα δημιουργεί τρία ορθογώνια, από αριστερά προς τα δεξιά: την πηγή, ένα αντίγραφο που σέβεται το θέμα και ένα σταθερό αντίγραφο RGB. Η πηγή χρησιμοποιεί το [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) για αναφορά στο πρώτο χρώμα έμφασης και προσθέτει ατονισμό μέσω του [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/). Το αντίγραφο RGB χρησιμοποιεί το αποτελεσματικό χρώμα γέμισης της πηγής ώστε και τα τρία αρχικά να φαίνονται όμοια. Η ανάθεση του [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) ορίζει σταθερή τιμή RGB και διαγράφει τυχόν υπάρχοντες μετασχηματισμούς χρώματος.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # Οι αναφορές θέματος ακολουθούν το νέο χρώμα έμφασης· η σταθερή τιμή RGB δεν το κάνει.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

Πριν την αλλαγή θέματος, όλα τα γέμιση ταιριάζουν:

![Πηγή, προορισμός copy_from και προορισμός σταθερού RGB με ταυτόσημη γεμίση μπλε](color-copy-before.png)

Μετά την αλλαγή θέματος, η πηγή και το αντίγραφο που σέβεται το θέμα ακολουθούν το νέο χρώμα έμφασης και διατηρούν τον ατονισμό τους. Το σταθερό RGB αντίγραφο παραμένει μπλε:

![Πηγή και copy_from προορισμός με γέμισμα πορτοκαλί, ενώ το σταθερό RGB προορισμό παραμένει μπλε](color-copy-after.png)

Ο αντιγραμμένος ορισμός είναι ανεξάρτητος από την πηγή. Μεταγενέστερη αλλαγή της αναφοράς θέματος της πηγής, ανάθεση άλλου χρώματος ή προσθήκη/αφαίρεση των μετασχηματισμών δεν αλλάζει τον προορισμό. Μία αλλαγή θέματος εξακολουθεί να επηρεάζει και τα δύο σχήματα επειδή κάθε ένα αναφέρεται ανεξάρτητα στο ίδιο χρώμα θέματος.

Η αποθήκευση και επαναφόρτωση του PPTX διατηρούν το [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/), την αναφορά θέματος και τη συλλογή [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) του αντιγραμμένου χρώματος· δεν τα μετατρέπει σε RGB.

Κατά την αντιγραφή μεταξύ διαφορετικών συμφραζομένων θέματος, όπως παρουσιάσεις με διαφορετικές παλέτες έμφασης, η αντιγραμμένη αναφορά λύνει το θέμα του προορισμού. Η ίδια αναφορά και οι μετασχηματισμοί μπορούν επομένως να παράγουν διαφορετικό ορατό χρώμα. Δείτε το [Presentation Theme](/slides/el/python-net/presentation-theme/) για περισσότερα σχετικά με τη διαμόρφωση χρωμάτων θέματος.

## **Χρήση Υποβάθρου Διαφάνειας ως Γέμιση Σχήματος**

Χρησιμοποιήστε το [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) όταν ένα σχήμα πρέπει να ταιριάζει με το υπέρβαθρο της διαφάνειας, π.χ. σε πρότυπο παρουσίασης. Ορίστε το [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) πρώτα για να αφαιρέσετε τυχόν ρητή γέμιση. Με αυτόν τον συνδυασμό, το σχήμα χρησιμοποιεί το υπέρβαθρο της διαφάνειας αντί για τη δική του γέμιση. Η ενεργοποίηση της σημαίας μόνη της δεν αφαιρεί υπάρχουσα ρητή γέμιση.

Αυτό διαφέρει από το [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): η γέμιση υπέρβαθρου καλύπτει αντικείμενα πίσω από το σχήμα με το αντίστοιχο τμήμα του υπέρβαθρου της διαφάνειας, ενώ η μη γέμιση αφήνει αυτά τα αντικείμενα ορατά. Μια διαβάθμιση παραμένει ευθυγραμμισμένη με τη διαφάνεια αντί να ξεκινά ξανά μέσα σε κάθε σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα κεντρικό υπέρβαθρο κληρονομημένο από τη διαφάνεια της διαφάνειας και τοποθετεί μια φούξια λωρίδα πίσω από τρία ορθογώνια. Το αριστερό ορθογώνιο χρησιμοποιεί το υπέρβαθρο, το μεσαίο δεν έχει γέμιση, και το δεξιό εναλλάσσει από γέμιση υπέρβαθρου σε ρητή πορτοκαλί γέμιση.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Κληρονομεί τη διαβάθμιση από το κύριο πρότυπο.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Προσθήκη αυτού του αντικειμένου πρώτα ώστε να εμφανίζεται πίσω από τα ορθογώνια.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Απενεργοποίηση γέμισης υποβάθρου πριν εφαρμοστεί ρητή γέμιση.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα, από αριστερά προς δεξιά: **γέμιση υπέρβαθρου**, **χωρίς γέμιση**, και **ρητή γέμιση**. Η φούξια λωρίδα κρύβεται από τα αριστερά και δεξιά ορθογώνια αλλά παραμένει ορατή μέσω του μεσαίου ορθογωνίου.

![Γέμιση υπέρβαθρου, χωρίς γέμιση και ρητή πορτοκαλί γέμιση πάνω από φούξια λωρίδα](background-fill.png)

Η ίδια συμπεριφορά ισχύει για υπέρβαθρο ορισμένο άμεσα στη διαφάνεια ή κληρονομημένο από διάταξη. Το σχήμα χρησιμοποιεί το διαφάνειο που έχει λυθεί· το παράδειγμα αφήνει τόσο τη διαφάνεια της διαφάνειας όσο και της διάταξης ακαθόριστες ώστε ο κύριος να την παρέχει.

## **Ορισμός Διαφάνειας**

Για μια συμπαγή γέμιση, το αλφα‑συστατικό του χρώματος ελέγχει την αδιαφάνεια: 0 είναι πλήρως διαυγές και 255 πλήρως αδιαφανές. Αυτό το παράδειγμα χρησιμοποιεί τιμή αλφα 128 για ένα κίτρινο ορθογώνιο, κάνοντάς το περίπου 50 % διαυγές ώστε το ορθογώνιο που βρίσκεται από κάτω να παραμένει ορατό. Το χρώμα ανατίθεται μέσω του [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το διαυγές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Χρησιμοποιήστε το [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) για να περιστρέψετε ένα σχήμα στην επίπεδη του διαφάνειας. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα περιστρέφει ένα ορθογώνιο κατά 5 μοίρες δεξιόστροφα και αποθηκεύει την παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Πρόσθεση Εφέ 3D Φρεσκας (Bevel)**

Χρησιμοποιήστε το [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) για να δώσετε σε ένα σχήμα βάθος και φρεσκές άκρες. Αυτό το παράδειγμα δημιουργεί μια πράσινη έλλειψη με πορτοκαλί περίγραμμα, ορίζει το [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) σε 4 σημεία και εφαρμόζει φρεσκά κορυφή κυκλικής μορφής με πλάτος και ύψος 6 σημείων μέσω του [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Μια εφαπτόμενη ορθογραφική κάμερα και τριών‑σημείων φωτισμός κάνουν τη φρεσκά ορατή.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το εφέ 3D φρεσκας](3D-bevel-effect.png)

## **Πρόσθεση Εφέ 3D Περιστροφής**

Η 3Δ άποψη ενός σχήματος ελέγχεται από τις ρυθμίσεις της κάμερας. Αυτό το παράδειγμα χρησιμοποιεί το [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) με γωνίες latitude, longitude και revolution 40, 35 και 20 μοιρών, αντίστοιχα. Επιλέγει ισομετρική κάμερα μέσω του [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) και ισορροπημένο φωτισμό μέσω του [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), στη συνέχεια αποθηκεύει το μορφοποιημένο ορθογώνιο.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Το εφέ 3D περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Ασπρόμαυρης Απόδοσης για Σχήματα**

Η ιδιότητα [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσίαση προβάλλεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί μόνο την ασπρόμαυρη προβολή, και δεν αλλάζει τη γέμιση, το περίγραμμα ή άλλες μορφοποιήσεις του σχήματος σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, `AUTOMATIC` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, `GRAY` και `LIGHT_GRAY` χρησιμοποιούν γκρι χρωματισμό, `BLACK_WHITE` χρησιμοποιεί μόνο μαύρο και άσπρο, `BLACK` και `WHITE` επιβάλλουν ένα ενιαίο χρώμα, `COLOR` διατηρεί το κανονικό χρώμα, και `HIDDEN` παραλείπει το σχήμα σε ασπρόμαυρη λειτουργία. `NOT_DEFINED` σημαίνει ότι δεν έχει εκχωρηθεί λειτουργία επιπέδου σχήματος.

Αυτό το παράδειγμα δημιουργεί ένα πορτοκαλί ορθογώνιο και ορίζει το [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) σε γκρι. Το αποθηκευμένο σχήμα διατηρεί το πορτοκαλί γέμιση για κανονική χρωματική εμφάνιση και ζητά γκρι χρωματισμό από εφαρμογές που τηρούν τις ρυθμίσεις ασπρόμαυρης προβολής:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμιση. Σε ροή εργασίας ασπρόμαυρης προβολής, χρησιμοποιεί γκρι χρωματισμό επειδή η λειτουργία του είναι ορισμένη σε `GRAY`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρη‑χρωμη διαφάνεια ενώ ορίζετε ξεχωριστή εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές που τηρούν τις ρυθμίσεις ασπρόμαυρης προβολής της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Χρησιμοποιήστε το [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) για να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση των σύμβολων θέσης της διαφάνειας από τα αντίστοιχα σύμβολα θέσης της διάταξης. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με σύμβολα θέσης συνδεδεμένα σε διάταξη και επαναφέρει κάθε διαφάνεια πριν την αποθήκευση. Τα σχήματα χωρίς αντίστοιχο σύμβολο θέσης διάταξης δεν επαναφέρονται.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις (FAQ)**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Τα χρώματα, τα στυλ γραμμής και οι ρυθμίσεις εφέ συνήθως προσθέτουν μικρή ποσότητα δεδομένων σε σύγκριση με τις ενσωματωμένες εικόνες και πολυμέσα. Οι γέμιση εικόνας μπορούν να αυξήσουν το μέγεθος του αρχείου επειδή οι εικόνες τους αποθηκεύονται στην παρουσίαση.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος—γέμιση, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε το στυλ τους ως ίδιο και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε μια παρουσίαση‑πρότυπο ή αρχείο .POTX. Κατά τη δημιουργία νέας παρουσίασης, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και επαναεφαρμόστε τη μορφοποίησή τους όπου απαιτείται.