---
title: Μορφοποίηση Σχημάτων PowerPoint σε Python
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/python-net/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκέτσου
- γραμμή σχήματος σκέτσου
- μορφοποίηση στυλ σύνδεσης
- γεμισμα διαβάθμισης
- γεμισμα μοτίβου
- γεμισμα εικόνας
- γεμισμα υφής
- γεμισμα στερεού χρώματος
- διαφάνεια σχήματος
- απόδοση σχήματος σε ασπρόμαυρο
- απόδοση σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- εφέ 3Δ απαλότητας
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε Python χρησιμοποιώντας το Aspose.Slides—ορίστε γεμίσματα, γραμμές και στυλ εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Μορφοποιήστε σχήματα στο PowerPoint ρυθμίζοντας τα περιγράμματα, τα γέμισμα και τα εφέ τους. Το Aspose.Slides for Python μέσω .NET σάς επιτρέπει να ελέγχετε αυτές τις ρυθμίσεις προγραμματιστικά, συμπεριλαμβανομένης της διαφάνειας, της περιστροφής και της μορφοποίησης 3Δ.

![Επιλογές μορφοποίησης σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for Python μέσω .NET παρέχει κλάσεις και ιδιότητες που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιήστε [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) για να ελέγξετε το περίγραμμα ενός σχήματος. Αυτό το παράδειγμα δημιουργεί ένα μη γεμάτο ορθογώνιο με μπλε, διακεκομμένο περίγραμμα. Το [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) επιλέγει μια γραμμή με σύνθετο παχύ-λεπτό στυλ, ενώ το [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) ορίζει το πλάτος της σε 7 σημεία και το [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) επιλέγει το μοτίβο διακεκοσμού.

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

### **Ορισμός Προσαρμοσμένων Προτύπων Παύσας Γραμμής**

Χρησιμοποιήστε [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) όταν τα προκαθορισμένα στυλ γραμμών δεν παρέχουν τα μήκη και τα κενά της παύσας που χρειάζεστε, για παράδειγμα για επωνυμογραφημένα περιγράμματα ή τεχνικά διαγράμματα. Η ανάθεση ενός προτύπου ορίζει αυτόματα το [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) σε [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Οι καταχωρίσεις της λίστας εναλλάσονται μεταξύ μήκους παύσας και κενών, ξεκινώντας με παύσα. Κάθε τιμή είναι πολλαπλάσιο του πλάτους της γραμμής: `[4, 2]` σε πλάτος 3 σημείων παράγει παύσα 12 σημείων ακολουθούμενη από κενό 6 σημείων. Χρησιμοποιήστε ζεύγη πεπερασμένων, μη αρνητικών τιμών για να ορίσετε πλήρη τμήματα παύσας-κενών. Το παράδειγμα χρησιμοποιεί θετικές τιμές για να διατηρούν όλες οι παύσες και τα κενά ορατά.

Αυτό το παράδειγμα δημιουργεί πέντε μπλε γραμμές με το ίδιο μήκος και επίπεδα άκρα. Οι πρώτες τρεις συγκρίνουν πρότυπα σε πλάτος 3 σημείων. Η τέταρτη επαναλαμβάνει το πρώτο πρότυπο σε διπλάσιο πλάτος, διπλασιάζοντας τα μήκη της παύσας και του κενού. Η πέμπτη αλλάζει από προσαρμοσμένο πρότυπο σε στερεή γραμμή.

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

    # Επιστρέψτε την τελευταία γραμμή σε στερεό στυλ.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides export.SaveFormat.PPTX)
```

Για να επιστρέψετε σε προεπιλεγμένο διακεκομμένο στυλ, αναθέστε [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) στο [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Το επιλεγμένο στυλ ελέγχει την εμφάνιση της γραμμής.

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **{4, 2}, 3 pt**· **{1, 2}, 3 pt**· **{6, 2, 1, 2}, 3 pt**· **{4, 2}, 6 pt**· και **Solid, 3 pt**.

![Τρία προσαρμοσμένα πρότυπα παύσας, μια πιο παχή γραμμή με το πρώτο πρότυπο, και μια στερεή γραμμή στο PowerPoint](custom-dash-patterns.png)

### **Ορισμός Άκρων Γραμμής**

Χρησιμοποιήστε [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) για να ορίσετε τα άκρα μιας ανοικτής γραμμής. Η απαίτηση [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) παρέχει τρία ρητά στυλ άκρων:

- `FLAT`: Η γραμμή σταματά στο άκρο.
- `ROUND`: Ένα ημικυκλικό άκρο εκτείνεται πέρα από το άκρο κατά το μισό του πλάτους της γραμμής.
- `SQUARE`: Ένα τετράγωνο άκρο εκτείνεται πέρα από το άκρο κατά το μισό του πλάτους της γραμμής.

Η απαίτηση περιλαμβάνει επίσης `NOT_DEFINED`, που σημαίνει ότι δεν έχει οριστεί ρητό στυλ άκρου.

Τα άκρα διαφέρουν από τις κεφαλές βελών, που προσθέτουν σύμβολα στα άκρα των γραμμών, και τις ενώσεις, που ελέγχουν τις γωνίες μεταξύ τμημάτων γραμμής. Αυτό το παράδειγμα απενεργοποιεί τις κεφαλές βελών μέσω του [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) και του [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) ώστε να συγκριθούν μόνο τα σχήματα άκρων.

Το παρακάτω παράδειγμα δημιουργεί τρεις παρόμοιες οριζόντιες γραμμές, 20 σημείων πλάτος. Από πάνω προς τα κάτω, χρησιμοποιούν επίπεδα, στρογγυλεμένα και τετράγωνα άκρα. Τα άκρα τους έχουν τις ίδιες οριζόντιες συντεταγμένες· τα στρογγυλεμένα και τετράγωνα άκρα εκτείνονται 10 σημεία πέρα από κάθε άκρο.

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

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **Flat**, **Round** και **Square**.

![Επίπεδα, στρογγυλεμένα και τετράγωνα άκρα σε παρόμοιες παχιές γραμμές στο PowerPoint](line-caps.png)

## **Εφαρμογή Εφέ Σκέτσου στις Γραμμές Σχήματος**

Ένα εφέ σκέτσου κάνει μια γραμμή σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) για πρόσβαση στις ρυθμίσεις γραμμής, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) για πρόσβαση στις ρυθμίσεις σκέτσου, και [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) για επιλογή τιμής από την απαίτηση [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας Python δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά ανατεθειμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

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

Η τιμή που επιστρέφεται από το [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληθεί από θέμα, κύρια διαφάνεια ή διάταξη διαφάνειας, χρησιμοποιήστε το [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), αποκτήστε πρόσβαση στο [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/), και διαβάστε το [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). Η αποτελεσματική τιμή αντανακλά τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση κληρονομίας. Το παράδειγμα αυτό απαιτεί μια υπάρχουσα παρουσίαση με τουλάχιστον ένα σχήμα στην πρώτη διαφάνεια και εμφανίζει και τις δύο τιμές:

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

## **Μορφοποίηση Στυλ Συνένωσης**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Το στυλ σύνδεσης ελέγχει πώς δύο τμήματα περιγράμματος συναντώνται σε γωνία. Χρησιμοποιήστε **Round** για στρογγυλεμένες γωνίες, **Miter** για οξείς γωνίες ή **Bevel** για επίπεδες γωνίες.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Αυτό το παράδειγμα δημιουργεί τρία μαύρα ορθογώνια με μπλε περιγράμματα 15 σημείων πλάτος. Ορίζει το [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) στις τιμές μιτερ, μπέβελ και ροουντ του [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), αντιστοίχως, για σύγκριση του τρόπου σχεδίασης των γωνιών.

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

### **Περιορισμός Συνδέσμων Γωνίας σε Οξείς Γωνίες**

Χρησιμοποιήστε το [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) μαζί με το [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) ορισμένο σε [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) για να περιορίσετε το πόσο μπορεί να εκτείνεται μια οξεία γωνία.

Το όριο είναι ένας λόγος της απόστασης μεταξύ της εσωτερικής και εξωτερικής γωνίας της σύνδεσης προς το πλάτος της γραμμής. Για παράδειγμα, η τιμή `8` επιτρέπει μήκος μιτερ έως και οκτώ φορές το πλάτος της γραμμής· δεν είναι μέτρηση σε σημεία. Εάν η γωνία υπερβαίνει το όριο, το PowerPoint χρησιμοποιεί μια μπέβελ σύνδεση στη συγκεκριμένη γωνία. Με μεγαλύτερο όριο επιτρέπονται πιο οξείες κορυφές. Η ρύθμιση επηρεάζει μόνο τις μιτερ συνδέσεις και η αλλαγή της δεν έχει ορατό αποτέλεσμα όταν η γωνία παραμένει εντός των δύο ορίων.

Αυτό το παράδειγμα δημιουργεί δύο παρόμοια, μη γεμάτα τρίγωνα με περιγράμματα 20 σημείων πλάτος. Το αριστερό τρίγωνο χρησιμοποιεί όριο `2`, το δεξί `8`. Κάθε τρίγωνο είναι 80 σημείων πλάτος και 160 σημείων ύψος, δίνοντας στην κορυφή του λόγο μήκους μιτερ προς πλάτος γραμμής περίπου `4.12`. Ως αποτέλεσμα, το PowerPoint κάνει μπέβελ την αριστερή κορυφή και διατηρεί την δεξιά.

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

Το αποτέλεσμα στο PowerPoint: **Όριο μιτερ 2** στα αριστερά και **όριο μιτερ 8** στα δεξιά.

![Μπέβελ κορυφή με όριο μιτερ 2 και οξεία κορυφή με όριο μιτερ 8 στο PowerPoint](miter-limits.png)

## **Γεμισμα Διαβάθμισης**

Το γεμισμα διαβάθμισης αναμειγνύει χρώματα σε ένα σχήμα. Αυτό το παράδειγμα γεμίζει μια έλλειψη με γραμμική διαβάθμιση υπό γωνία 45 μοιρών από το κόκκινο στο μοβ χρησιμοποιώντας το [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Η μέθοδος [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) τοποθετεί τα χρώματα στα 0 και 1, στην αρχή και το τέλος της διαβάθμισης. Η αφαίρεση των υπαρχουσών στάσεων διασφαλίζει ότι χρησιμοποιούνται μόνο αυτά τα δύο χρώματα.

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

![Η έλλειψη με γεμισμα διαβάθμισης](gradient-fill.png)

Αν μια διαβάθμιση εμφανίζεται διαφορετικά σε εξαγόμενο εικόνα από ό,τι στο PowerPoint, δείτε την ενότητα [Choose a Gradient Rendering Style](/slides/el/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε το γεμισμα διαβάθμισης που αποθηκεύεται στην παρουσίαση.

### **Ορισμός Γωνίας Γραμμικής Διαβάθμισης**

Χρησιμοποιήστε το [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) για να ελέγξετε τον προσανατολισμό ενός γεμίσματος [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). Η γωνία μετριέται σε μοίρες και αυξάνεται δεξιόστροφα: `0` τρέχει από αριστερά προς δεξιά, `90` από πάνω προς τα κάτω, `180` από δεξιά προς αριστερά, και `270` από κάτω προς πάνω. Υποστηρίζονται δεκαδικές γωνίες. Οι πεπερασμένες γωνίες εκτός του εύρους `[0, 360)` κανονικοποιούνται σε μία στροφή· για παράδειγμα, το `-45` γίνεται `315` και το `360` γίνεται `0`.

Αυτό το παράδειγμα δημιουργεί έξι ορθογώνια με τα ίδια χρώματα κόκκινο, πράσινο και μπλε σε θέσεις `0`, `0.5` και `1`. Η κλίμακα είναι απενεργοποιημένη ώστε η γωνία να συγκριθεί ανεξάρτητα από τις αναλογίες των ορθογωνίων. Οι γωνίες, από αριστερά προς δεξιά, είναι `0`, `45` και `90` στην πρώτη σειρά, και `135`, `180` και `270` στη δεύτερη σειρά.

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

![Γραμμικές διαβάθμιση στις 0, 45 και 90 μοίρες στην πρώτη σειρά, και 135, 180 και 270 μοίρες στη δεύτερη σειρά](linear-gradient-angles.png)

### **Κλιμάκωση Γραμμικής Διαβάθμισης με το Σχήμα**

Το [GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) δέχεται τιμή [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Ορίστε τη ρητά σε `FALSE` για να διατηρείται η γεωμετρική γωνία της διαβάθμισης όταν αλλάζουν οι αναλογίες του σχήματος, ή σε `TRUE` για να κλιμακωθεί η διαβάθμιση με το πλάτος και το ύψος του σχήματος. Με την κλιμάκωση ενεργοποιημένη, η ορατή γωνία μπορεί να διαφέρει από τη καθορισμένη γωνία σε μη τετράγωνο σχήμα.

Το παρακάτω παράδειγμα χρησιμοποιεί γωνία `45` μοιρών και τα ίδια χρώματα όπως στη σύγκριση γωνιών. Η αριστερή στήλη χρησιμοποιεί `FALSE`; η δεξιά `TRUE`. Κάθε στήλη περιέχει ένα πλατύ ορθογώνιο πάνω από ένα ψηλό ορθογώνιο. Και τα δύο ξεκινούν με τις ίδιες πλατιές διαστάσεις· η αλλαγή του πλάτους και του ύψους του δεύτερου ορθογωνίου δείχνει πώς το γεμισμα ανταποκρίνεται στην αλλαγή μεγέθους χωρίς αλλαγή των ρυθμίσεων διαβάθμισης.

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

Το αποτέλεσμα στο PowerPoint, με κλιμάκωση απενεργοποιημένη αριστερά και ενεργοποιημένη δεξιά:

![Πλατιά και ψηλά ορθογώνια με διαβάθμιση 45 μοιρών, συγκρίνοντας linear_gradient_scaled FALSE αριστερά με TRUE δεξιά](linear-gradient-scaling.png)

Με κλιμάκωση απενεργοποιημένη, οι διαγώνιες λωρίδες χρώματος διατηρούν τον ίδιο προσανατολισμό και στα δύο ορθογώνια. Με κλιμάκωση ενεργοποιημένη, οι λωρίδες τεντώνονται με τις αναλογίες του σχήματος. Αυτό βοηθά στην αναπαραγωγή μιας διαβάθμισης προτύπου όταν προσαρμόζεται ένα σχήμα σε διαφορετικό μέγεθος. Σε τετράγωνο σχήμα, η ενεργοποίηση της κλιμάκωσης δεν αλλάζει την εμφάνιση της διαβάθμισης `45` μοιρών.

Τanto η γωνία όσο και η κλιμάκωση εφαρμόζονται στις γραμμικές διαβάθμισεις. Δεν ελέγχουν τα γεμίσματα [GradientShape.RADIAL ή GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Συνδυασμός Γωνίας με Κατεύθυνση Διαβάθμισης**

Το [GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) επιλέγει στυλ διαβάθμισης από την απαίτηση [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); δεν είναι υποκατάστατο αριθμητικής γωνίας. Για μια γραμμική διαβάθμιση, τα στυλ γωνιών μπορούν να αλλάξουν την περιοχή όπου διανέμονται τα χρώματα χωρίς να αλλάζουν το [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Διατηρήστε την κατεύθυνση αμετάβλητη όταν συγκρίνετε γωνίες ή κλιμάκωση.

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

## **Γεμισμα Μοτίβου**

Ένα γεμισμα μοτίβου εφαρμόζει σχέδιο δύο χρωμάτων, όπως κουκκίδες, λωρίδες ή τετράγωνα. Αυτό το παράδειγμα χρησιμοποιεί το [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) για επιλογή μοτίβου πλέγματος. Το [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) παρέχει το ανοιχτό γκρι φόντο, και το [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) το κίτρινο χρώμα του μοτίβου.

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

![Το ορθογώνιο με γεμισμα μοτίβου](pattern-fill.png)

## **Γεμισμα Εικόνας**

Ένα γεμισμα εικόνας χρησιμοποιεί μια εικόνα μέσα σε ένα σχήμα. Αυτό το παράδειγμα απαιτεί μια τοπική εικόνα και χρησιμοποιεί το [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) για να τη φορτώσει στη συλλογή εικόνων της παρουσίασης. Ο καθορισμός του [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) σε λειτουργία παράθεσης επαναλαμβάνει την εικόνα μέσα στο ορθογώνιο. Η πηγαία εικόνα που χρησιμοποιείται φαίνεται παρακάτω:

![Η εικόνα λωτόνου](lotus.png)

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

![Το σχήμα με γεμισμα εικόνας](picture-fill.png)

### **Τοποθέτηση Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια τοποθετημένη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά τοποθέτησης, μπορείτε να χρησιμοποιήσετε τις παρακάτω ιδιότητες της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Ορίζει τη λειτουργία γεμίσματος εικόνας — είτε `TILE` είτε `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Ελέγχει αν το πλακίδιο θα αντιστραφεί οριζόντια, κάθετα ή και τα δύο.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε σημεία) από το αρχικό σημείο του σχήματος.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Αυτό το παράδειγμα απαιτεί μια τοπική εικόνα και ρυθμίζει το [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) ώστε να την επαναλαμβάνει στο 50 % του αρχικού μεγέθους. Οι μετατοπίσεις `-32` σημειών μετατοπίζουν τα πλακίδια οριζόντια και κάθετα· η ευθυγράμμιση κάτω δεξιά και η αντιστροφή και στις δύο κατευθύνσεις καθορίζουν πώς διατάσσεται η επαναλαμβανόμενη υφή.

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

## **Γεμισμα Στερεού Χρώματος**

Ένα στερεό γεμισμα δίνει στο σχήμα ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το παράδειγμα ορίζει το [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε λειτουργία στερεού γεμίσματος και αναθέτει κίτρινο χρώμα μέσω του [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), έπειτα αποθηκεύει το ορθογώνιο στην παρουσίαση.

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

![Το σχήμα με στερεό γεμισμα χρώματος](solid-color-fill.png)

## **Χρήση Φόντου Διαφάνειας ως Γέμισμα Σχήματος**

Χρησιμοποιήστε το [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) όταν ένα σχήμα πρέπει να ταιριάζει με το φόντο της διαφάνειας, για παράδειγμα σε πρότυπο παρουσίασης. Ορίστε πρώτα το [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) σε [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) για να αφαιρέσετε τυχόν ρητό γεμισμα. Με αυτόν τον συνδυασμό, το σχήμα χρησιμοποιεί το φόντο της διαφάνειας αντί για το δικό του γεμισμα. Η ενεργοποίηση της σημαίας από μόνη της δεν αφαιρεί ένα υπάρχον ρητό γεμισμα.

Αυτό διαφέρει από το [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): το γεμισμα φόντου καλύπτει αντικείμενα πίσω από το σχήμα με την αντίστοιχη περιοχή του φόντου της διαφάνειας, ενώ το «χωρίς γεμισμα» αφήνει αυτά τα αντικείμενα ορατά. Μια διαβάθμιση παραμένει ευθυγραμμισμένη με τη διαφάνεια αντί να επανεκκινείται μέσα σε κάθε σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα φόντο κύριου πρότυπου που κληρονομείται από τη διαφάνεια και τοποθετεί μια ματζέντα λωρίδα πίσω από τρία ορθογώνια. Το αριστερό ορθογώνιο χρησιμοποιεί το φόντο, το μεσαίο δεν έχει γεμισμα, και το δεξί εναλλάσσει από γεμισμα φόντου σε ρητό πορτοκαλί γεμισμα.

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

    # Προσθέστε αυτό το αντικείμενο πρώτα ώστε να εμφανίζεται πίσω από τα ορθογώνια.
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

    # Απενεργοποιήστε το γέμισμα φόντου πριν εφαρμόσετε ένα ρητό γέμισμα.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα, από αριστερά προς τα δεξιά: **γεμισμα φόντου**, **χωρίς γεμισμα**, και **ρητό γεμισμα**. Η ματζέντα κρύβεται από τα αριστερά και δεξιά ορθογώνια αλλά παραμένει ορατή μέσα από το μεσαίο.

![Γεμισμα φόντου, χωρίς γεμισμα και ρητό πορτοκαλί γεμισμα πάνω από μια ματζέντα λωτόνου](background-fill.png)

Η ίδια συμπεριφορά ισχύει για φόντο που ορίζεται άμεσα στη διαφάνεια ή κληρονομείται από διάταξη. Το σχήμα χρησιμοποιεί το επιλυμένο φόντο της διαφάνειας· το παράδειγμα αφήνει τόσο το φόντο της διαφάνειας όσο και του layout ακαθόριστα ώστε το κύριο πρότυπο να το παρέχει.

## **Ορισμός Διαφάνειας**

Για ένα στερεό γεμισμα, το αλφα-συστατικό του χρώματος ελέγχει την αδιαφάνεια: 0 είναι πλήρως διαφανές και 255 πλήρως αδιαφανές. Αυτό το παράδειγμα χρησιμοποιεί τιμή αλφα 128 για ένα κίτρινο ορθογώνιο, καθιστώντας το περίπου 50 % διαφανές ώστε το παρακάτω ορθογώνιο να παραμένει ορατό. Το χρώμα ανατίθεται μέσω του [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

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

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Χρησιμοποιήστε το [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) για να περιστρέψετε ένα σχήμα στο επίπεδο της διαφάνειας. Η γωνία μετριέται σε μοίρες· αυτό το παράδειγμα περιστρέφει ένα ορθογώνιο 5 μοίρες δεξιόστροφα και αποθηκεύει την παρουσίαση.

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

## **Προσθήκη 3Δ Εφέ Απαλότητας**

Χρησιμοποιήστε το [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) για να δώσετε βάθος και ακριβές άκρο σε ένα σχήμα. Αυτό το παράδειγμα δημιουργεί μια πράσινη έλλειψη με πορτοκαλί περίγραμμα, ορίζει το [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) σε 4 σημεία, και εφαρμόζει ένα κυκλικό άνω άκρο με πλάτος και ύψος 6 σημείων μέσω του [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Μία κεντρική ορθογραφική κάμερα και τριών σημείων φωτισμός κάνουν το άκρο ορατό.

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

![Το 3Δ εφέ αφαλότητας](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Η τρισδιάστατη όψη ενός σχήματος ελέγχεται από τις ρυθμίσεις της κάμερας. Αυτό το παράδειγμα χρησιμοποιεί το [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) με γωνίες 40, 35 και 20 μοιρών για latitude, longitude και επανάληψη αντίστοιχα. Επιλέγει μια ισομετρική κάμερα μέσω του [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) και ισορροπημένο φωτισμό μέσω του [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), έπειτα αποθηκεύει το μορφοποιημένο ορθογώνιο.

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

![Το 3Δ εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Απόδοσης Μαύρο-Άσπρο για Σχήματα**

Η ιδιότητα [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσίαση εμφανίζεται ή επεξεργάζεται σε λειτουργία μαύρο-άσπρο. Δεν ενεργοποιεί μόνο η λειτουργία μαύρο-άσπρο· δεν αλλάζει το γεμισμα, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την απαίτηση [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, `AUTOMATIC` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, `GRAY` και `LIGHT_GRAY` χρησιμοποιούν γκρι απόχρωση, `BLACK_WHITE` χρησιμοποιεί μόνο μαύρο και λευκό, `BLACK` και `WHITE` επιβάλλουν ένα ενιαίο χρώμα, `COLOR` διατηρεί το κανονικό χρώμα, και `HIDDEN` παραλείπει το σχήμα στη λειτουργία μαύρο-άσπρο. `NOT_DEFINED` σημαίνει ότι δεν έχει εκχωρηθεί λειτουργία επιπέδου σχήματος.

Αυτό το παράδειγμα δημιουργεί ένα πορτοκαλί ορθογώνιο και ορίζει το [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) σε γκρι. Το αποθηκευμένο σχήμα διατηρεί το πορτοκαλί γεμισμα για κανονική χρωματική προβολή και ζητά γκρι χρώμα από εφαρμογές που σέβονται τις ρυθμίσεις προβολής μαύρο-άσπρου:

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

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γεμισμα. Σε διαδικασία προβολής μαύρο-άσπρου, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του είναι ορισμένη σε `GRAY`. Αυτό σάς επιτρέπει να διατηρήσετε μια πλήρη έγχρωμη διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες διαδικασίες που σέβονται τις ρυθμίσεις προβολής μαύρο-άσπρου.

## **Επαναφορά Μορφοποίησης**

Χρησιμοποιήστε το [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) για να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση των δεσμευτικών θέσεων διαφάνειας από τις αντίστοιχες θέσεις διάταξης. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με δεσμευμένες θέσεις διάταξης και επαναφέρει κάθε διαφάνεια πριν την αποθήκευση. Τα σχήματα χωρίς αντίστοιχες θέσεις διάταξης δεν επαναφέρονται.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Τα χρώματα, τα στυλ γραμμών και οι ρυθμίσεις εφέ προσθέτουν γενικά λίγα δεδομένα σε σύγκριση με ενσωματωμένες εικόνες και πολυμέσα. Τα γεμίσματα εικόνας μπορούν να αυξήσουν το μέγεθος του αρχείου επειδή οι εικόνες τους αποθηκεύονται στην παρουσίαση.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος—γεμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ τους ως ίσα και λογικά ομαδοποιήστε τα σχήματα, κάτι που απλουστεύει τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγμα σχημάτων με τα επιθυμητά στυλ σε μια διαφάνεια προτύπου ή ένα αρχείο .POTX. Όταν δημιουργείτε μια νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλ σχήματος που χρειάζεστε και επαναεφαρμόστε τη μορφοποίησή τους όπου απαιτείται.