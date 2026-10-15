---
title: Διαχείριση Παραγράφων Κειμένου PowerPoint σε Python
linktitle: Διαχείριση Παραγράφου
type: docs
weight: 40
url: /el/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση κουκίδας
- εισοχή παραγράφου
- κρεμαστή εσοχή
- κουκίδα παραγράφου
- αριθμημένη λίστα
- λίστα με κουκίδες
- ιδιότητες παραγράφου
- εισαγωγή HTML
- κείμενο σε HTML
- παράγραφος σε HTML
- παράγραφος σε εικόνα
- κείμενο σε εικόνα
- εξαγωγή παραγράφου
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε παραγράφους, τμήματα, κουκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφων με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Aspose.Slides for Python via .NET αναπαριστά το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) αποτελεί το δοχείο κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή παραγράφων του.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) αντιπροσωπεύει μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα και στη μορφοποίηση επιπέδου παραγράφου.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) αντιπροσωπεύει μια σειρά κειμένου μέσα σε μια παράγραφο. Κάθε τμήμα μπορεί να έχει τη δική του μορφοποίηση κειμένου και χαρακτήρων.

Μια παράγραφος μπορεί επομένως να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλες μορφοποιήσεις χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Μορφοποίηση Παραγράφων**

Δημιουργήστε παραγράφους στο πλαίσιο κειμένου ενός σχήματος και χρησιμοποιήστε τμήματα για να μορφοποιήσετε μεμονωμένες σειρές κειμένου. Αυτή η ενότητα δείχνει πώς να συνδυάσετε πολλαπλά τμήματα μέσα σε κάθε παράγραφο και να εφαρμόσετε διαφορετικά χρώματα, μεγέθη γραμματοσειράς και στυλ.

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Το παρακάτω παράδειγμα Python δημιουργεί τρεις παραγράφους, καθεμία από τις οποίες περιέχει τρεις σειρές κειμένου στη συλλογή [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). Επαναχρησιμοποιεί την προεπιλεγμένη παράγραφο και το κενό τμήμα της, στη συνέχεια προσθέτει τις υπόλοιπες παραγράφους και τμήματα. Η μορφοποίηση εφαρμόζεται μέσω του [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): το πρώτο τμήμα σε κάθε παράγραφο είναι κόκκινο, έντονο και 15 σημείων· το δεύτερο είναι μπλε, πλάγιο και 18 σημείων. Το τρίτο τμήμα διατηρεί την προεπιλεγμένη μορφοποίησή του:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Δημιουργία Λιστών με Κουκίδες και Αρίθμηση**

Οργανώστε το κείμενο της παραγράφου σε λίστες με σύμβολα, αριθμούς ή προσαρμοσμένες εικόνες. Τα παραδείγματα σε αυτήν την ενότητα καλύπτουν τη μορφοποίηση κουκίδων, τις πολυεπίπεδες λίστες και την προσαρμογή αρχικών αριθμών.

### **Δημιουργία Λίστας με Κουκίδες ή Αρίθμηση**

Οι κουκίδες και η αρίθμηση κάνουν τα σχετικά στοιχεία πιο εύκολα στην ανάγνωση. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Αυτό το παράδειγμα Python προσθέτει μια σύμβολο‑κουκίδα και ένα αριθμημένο στοιχείο στο ίδιο πλαίσιο κειμένου. Το [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) επιλέγει τον τύπο της κουκίδας, ενώ το [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) καθορίζει το σύμβολο και το [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) επιλέγει το στυλ αρίθμησης. Και τα δύο στοιχεία χρησιμοποιούν μαύρες κουκίδες με ύψος 100 % και οριζόντιο περιθώριο παραγράφου 25 σημεία:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Χρήση Εικόνας για Κουκίδες**

Οι εικόνες-κουκίδες σάς επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

Το παράδειγμα απαιτεί το αρχείο `bullets.png` στο τρέχον φάκελο. Αυτό το παράδειγμα Python προσθέτει μια εικόνα στη συλλογή εικόνων της παρουσίασης ως [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) και τη χρησιμοποιεί ως κουκίδα παραγράφου. Ορίζει το [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) για χρήση εικόνας‑κουκίδας και ορίζει την εικόνα μέσω του [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). Το [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) τίθεται σε 100 % ώστε το μέγεθος της κουκίδας να σχετίζεται με το κείμενο της παραγράφου:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Δημιουργία Πολυεπίπεδης Λίστας**

Ορίστε το [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) για να τοποθετήσετε τις παραγράφους σε διαφορετικά επίπεδα λίστας. Το ανώτερο επίπεδο έχει βάθος `0`.

Αυτό το παράδειγμα Python αντιστοιχεί τιμές [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) από 0 έως 3 σε τέσσερις παραγράφους, δημιουργώντας ιεραρχία μέσα σε ένα πλαίσιο κειμένου. Κάθε παράγραφος χρησιμοποιεί σύμβολο‑κουκίδα, με το [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) να εναλλάσσεται μεταξύ στρογγυλής κουκίδας και παύλας για να διακρίνει τα γειτονικά επίπεδα:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Έναρξη Αριθμημένων Στοιχείων Λίστας με Προσαρμοσμένες Τιμές**

Χρησιμοποιήστε το [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται σε μια αριθμημένη παράγραφο.

Αυτό το παράδειγμα Python θέτει το [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) για χρήση αρίθμησης σε τρεις παραγράφους και ορίζει τιμές [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 2, 3 και 7. Η αρχική τιμή ρυθμίζεται ξεχωριστά για κάθε παράγραφο, επιτρέποντας στα εμφανιζόμενα νούμερα να παραλείπουν τιμές:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Έλεγχος Διάταξης Παραγράφων και Ιδιοτήτων Καταληκτικού Σχήματος**

Ρυθμίστε τα περιθώρια και τις εσοχές της παραγράφου για να ελέγξετε τη θέση της πρώτης γραμμής και των γραμμών αναδίπλωσης. Μπορείτε επίσης να μορφοποιήσετε το σημάδι τέλους παραγράφου ξεχωριστά από τα ορατά τμήματα κειμένου.

### **Ορισμός Εσοχής Πρώτης Γραμμής**

Χρησιμοποιήστε την ιδιότητα [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Η ιδιότητα αυτή μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετακινεί την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δίνει τρεις παραγράφους το ίδιο [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 20 σημείων και τιμές [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 0, 20 και 40 σημείων. Οι πρώτες γραμμές αρχίζουν σε προοδευτικά μεγαλύτερες αποστάσεις, ενώ οι γραμμές αναδίπλωσης διατηρούν το ίδιο αριστερό περιθώριο:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Ορισμός Κρεμαστής Εσοχής**

Η κρεμαστή εσοχή είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή ξεκινά αριστερά των υπολοίπων γραμμών. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Ορίστε το `indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) ορίζει τη θέση αριστερά του σώματος της παραγράφου, ενώ το [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε κρεμαστή εσοχή, ορίστε μια θετική τιμή για `margin_left` και μια αρνητική τιμή για `indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, αναφορές, εγγραφές γλωσσολογίου και άλλες παραγράφους όπου οι γραμμές αναδίπλωσης πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου και όχι κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

Το παρακάτω παράδειγμα Python συνδυάζει τιμές [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 40 και 60 σημείων με τιμές [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) -20 και -30 σημείων. Σε κάθε παράγραφο, η πρώτη γραμμή αρχίζει αριστερά των γραμμών αναδίπλωσης· η δεύτερη παράγραφος έχει πιο βαθιά κρεμαστή εσοχή:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Ορισμός Ιδιοτήτων Τέλους Εκτέλεσης Παραγράφου**

Η ιδιότητα [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) ελέγχει τη μορφοποίηση του σημείου τέλους παραγράφου. Το παράδειγμα φορτώνει το `Test.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια, και δημιουργεί ένα [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) με [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) 48 σημείων και [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) ορισμένο σε Times New Roman. Αυτό το φορμά εφαρμόζεται στο σημείο τέλους της δεύτερης παραγράφου, αφήνοντας τα ορατά τμήματα κειμένου αμετάβλητα:

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Καταμέτρηση Σχεδόν Εμφανισμένων Γραμμών**

Για κανόνες παραγράφου που επηρεάζουν την αυτόματη αναδίπλωση και την στίξη στο τέλος των γραμμών, δείτε το [Control Line Breaking](/slides/el/python-net/text-formatting/#control-line-breaking) και το [Control Hanging Punctuation](/slides/el/python-net/text-formatting/#control-hanging-punctuation).

Χρησιμοποιήστε το [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) για να μετρήσετε τις γραμμές που καταλαμβάνει μια παράγραφος μετά την διάταξη του κειμένου, συμπεριλαμβανομένης της αυτόματης αναδίπλωσης. Αυτό είναι χρήσιμο όταν ελέγχετε το μήκος κειμένου και τη διάταξη σε πρότυπα παρουσιάσεων.

Μια παράγραφος είναι ένα αντικείμενο στη [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), και μπορεί να καταλαμβάνει πολλές εμφανισμένες γραμμές. Μια ρητή αλλαγή γραμμής μέσα σε μια παράγραφο εξαναγκάζει νέα γραμμή χωρίς να δημιουργεί επιπλέον παράγραφο. Η αυτόματη αναδίπλωση δημιουργεί γραμμές βάσει του διαθέσιμου πλάτους χωρίς να εισάγει ρητές αλλαγές γραμμής στο κείμενο. Συνεπώς η καταμέτρηση παραγράφων ή χαρακτήρων αλλαγής γραμμής δεν δίνει τον αριθμό των εμφανιζόμενων γραμμών.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα κειμένου, μετρά τις γραμμές του, στενεύει το σχήμα και στη συνέχεια αντικαθιστά το κείμενο με μια σύντομη συμβολοσειρά. Το παράδειγμα ενεργοποιεί το [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) και απενεργοποιεί το [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ώστε το πλάτος του σχήματος να ελέγχει την αναδίπλωση χωρίς αυτόματη σμίκρυνση του κειμένου ή αλλαγή του μεγέθους του σχήματος. Κάθε μέτρηση χρησιμοποιεί το [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Οι διαστάσεις του σχήματος εκφράζονται σε σημεία. Τέλος, το παράδειγμα προσθέτει άλλη μια παράγραφο και αθροίζει τα πλήθη γραμμών σε όλο το πλαίσιο κειμένου.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Με αυτά τα κείμενα και τις διαστάσεις, η μείωση του πλάτους του σχήματος αυξάνει τον αριθμό των γραμμών, ενώ η αντικατάσταση του κειμένου με τη σύντομη συμβολοσειρά τον μειώνει. Οι ακριβείς μετρήσεις μπορεί να διαφέρουν ανάλογα με τη διαθεσιμότητα και αντικατάσταση γραμματοσειρών, το μέγεθος γραμματοσειράς, τα περιθώρια, την εσοχή, την αναδίπλωση και τις ρυθμίσεις autofit. Χρησιμοποιήστε τις γραμματοσειρές και τις ρυθμίσεις διάταξης που προορίζονται για το στοχευόμενο περιβάλλον όταν ελέγχετε ένα πρότυπο.

Ο μόνος αριθμός γραμμών δεν καθορίζει αν το κείμενο υπερβαίνει το δοχείο του. Υπάρχουν επίσης το διαθέσιμο ύψος, τα ύψη γραμμών, η απόσταση παραγράφων και γραμμών, και η συμπεριφορά autofit· ακόμη και μια μόνο γραμμή μπορεί να ξεπεράσει το διαθέσιμο πλάτος όταν η αναδίπλωση είναι απενεργοποιημένη.

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφων**

Χρησιμοποιήστε HTML για να εισάγετε κείμενο σε μια παρουσίαση ή να εξάγετε υπάρχουσες παραγράφους για χρήση εκτός αυτής. Αυτή η ενότητα δείχνει επίσης πώς να αποδίδετε μεμονωμένες παραγράφους ως εικόνες, συμπεριλαμβανομένων παραγράφων σε κελιά πινάκων.

### **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) για να μετατρέψετε σήμανση HTML σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

Αυτό το παράδειγμα Python διαβάζει HTML από το `file.html` στο τρέχον φάκελο και το περνά στο [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Καθαρίζει την προεπιλεγμένη παράγραφο του πλαισίου κειμένου ώστε το πλαίσιο να περιέχει μόνο το εισαγόμενο περιεχόμενο. Το ορθογώνιο σχήμα αφήνει περιθώριο 10 σημείων σε κάθε πλευρά της διαφάνειας:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Χρησιμοποιήστε το [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) για να εξάγετε ένα επιλεγμένο εύρος παραγράφων ως HTML. Όταν επαναχρησιμοποιείτε κείμενο παρουσίασης σε ιστότοπο, ίσως θέλετε να διατηρήσετε την τοπική ένταση χωρίς να μεταφέρετε τις γραμματοσειρές, το μέγεθος ή τα στυλ του πλαισίου κειμένου της παρουσίασης. Ορίστε το [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) για να ελέγξετε πόσο μακριά ακολουθεί ο εξαγωγέας την κληρονομιά μορφοποίησης.

Κατεβάστε τη [the sample presentation](text-inheritance.pptx) και τοποθετήστε την στον φάκελο εργασίας της εφαρμογής. Η πρώτη της διαφάνεια περιέχει ένα σχήμα κειμένου με το κείμενο «Inherited text; explicit red 18pt». Η είσοδος χρησιμοποιεί σκόπιμα πολλά επίπεδα μορφοποίησης:

- Η προεπιλεγμένη τεχνοτροπία κειμένου της παρουσίασης παρέχει Calibri και μέγεθος 28 pt.
- Η τεχνοτροπία πρώτου επιπέδου του πλαισίου κειμένου παρέχει μπλε κείμενο και πλάγια γραφή.
- Η παράγραφος ορίζει ρητά έντονο κείμενο.
- Το δεύτερο τμήμα, «explicit red 18pt», ορίζει ρητά κόκκινο κείμενο και μέγεθος 18 pt.

Το παρακάτω πλήρες παράδειγμα εξάγει τις ίδιες παραγράφους τρεις φορές. Περνά το [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) στη μέθοδο εξαγωγής και γράφει κάθε αποτέλεσμα σε ξεχωριστό αρχείο HTML UTF‑8:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

Το δημιουργημένο HTML περιέχει το ακόλουθο CSS για το πρώτο τμήμα, «Inherited text; ». Ο πίνακας παραθέτει τις σχετικές δηλώσεις· άλλες δημιουργημένες ιδιότητες παραλείπονται για σαφήνεια.

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Μπλε, έντονο, πλάγιο κείμενο 28 pt σε Calibri, εφόσον η γραμματοσειρά είναι διαθέσιμη. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Μπλε, έντονο, πλάγιο κείμενο· η περιβάλλουσα σελίδα ή ο περιηγητής παρέχουν τη γραμματοσειρά και το μέγεθος. |
| `ParagraphOnly.html` | `font-weight:bold` | Έντονο κείμενο· η περιβάλλουσα σελίδα ή ο περιηγητής παρέχουν τη γραμματοσειρά, το μέγεθος, το χρώμα και το πλάγιο στυλ. |

Το δεύτερο τμήμα διατηρεί `color:#ff0000`, `font-size:18pt` και `font-weight:bold` σε όλα τα τρία αποτελέσματα. Διατηρεί επίσης πλάγια γραφή στα `ALL` και `TEXT_BOX`, αλλά όχι στο `PARAGRAPH_ONLY`. Ο περιορισμός κληρονομιάς επομένως δεν αφαιρεί τη μορφοποίηση που έχει οριστεί ρητά σε μια παράγραφο ή τμήμα.

Ανοίξτε τα αρχεία στον ίδιο περιηγητή για να τα συγκρίνετε. Στις δύο περιορισμένες λειτουργίες, οι παραλειπόμενες ιδιότητες CSS επιλύονται από τα στυλ της σελίδας προορισμού ή τις προεπιλογές του περιηγητή, οπότε η τελική εμφάνιση εξαρτάται από το πού χρησιμοποιείται το HTML.

### **Απόδοση Παραγράφου ως Εικόνας**

Το [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) αποδίδει άμεσα μια μεμονωμένη παράγραφο και επιστρέφει ένα [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο ή ροή με το [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Δεν χρειάζεται να αποδώσετε το περιβάλλον σχήμα ή να περικόψετε εικόνα χειροκίνητα.

Το [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) μπορεί να επιστρέψει `None` εάν η παράγραφος δεν βρεθεί στη συλλογή γονέα, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και απελευθερώστε την εικόνα μετά τη χρήση.

#### **Απόδοση Παραγράφου στην Προεπιλεγμένη Κλίμακα**

Το παράδειγμα χρησιμοποιεί το `sample.pptx`, μια παρουσίαση με μία διαφάνεια της οποίας το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![The text box with three paragraphs](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα επιλέγει τη δεύτερη παράγραφο με δείκτη 1 και καλεί το [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) χωρίς παραμέτρους κλίμακας. Ελέγχει ότι το σχήμα περιέχει την απαιτούμενη παράγραφο και ότι η απόδοση επιστρέφει εικόνα πριν καλέσει το [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) για αποθήκευση σε μορφή PNG. Ο διαχειριστής περιεχομένου απελευθερώνει τους πόρους της εικόνας μετά τη χρήση.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Το αποτέλεσμα:

![The paragraph image](paragraph_to_image_output.png)

#### **Απόδοση Παραγράφου σε Κελί Πίνακα με Κλίμακα**

Χρησιμοποιήστε την υπερφόρτωση του [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) που δέχεται παραμέτρους `scale_x` και `scale_y` για να ορίσετε τους οριζόντιους και κάθετους συντελεστές κλίμακας. Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο του κελί με διπλάσιο πλάτος και ύψος από την προεπιλεγμένη, και αποθηκεύει το αποτέλεσμα σε εικόνα PNG.

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Συντελεστής κλίμακας `1` διατηρεί τον άξονα στο προεπιλεγμένο μέγεθος εικονοστοιχείων. Για παράδειγμα, `2` και για τους δύο παράγοντες παράγει εικόνα του οποίου το πλάτος και το ύψος είναι περίπου δυο φορές οι προεπιλεγμένες διαστάσεις, με αποτέλεσμα τέσσερα φορές περισσότερα εικονοστοιχεία. Μεγαλύτεροι παράγοντες γενικά παράγουν πιο καθαρό κείμενο για μεγέθυνση ή υψηλή ανάλυση, αλλά επίσης αυξάνουν τη χρήση μνήμης και το μέγεθος αρχείου. Παράγοντες κάτω από `1` παράγουν μικρότερες εικόνες με λιγότερες λεπτομέρειες. Χρησιμοποιήστε ίσους παράγοντες για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κάθετοι παράγοντες τεντώνουν το αποτέλεσμα ανεξάρτητα.

Η απόδοση ολόκληρου σχήματος με το [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) παραμένει χρήσιμη όταν το αποτέλεσμα πρέπει να περιλαμβάνει το γέμισμα, το περίγραμμα ή άλλο οπτικό πλαίσιο του σχήματος. Για εικόνα μόνο παραγράφου, χρησιμοποιήστε το [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) για να απενεργοποιήσετε την αναδίπλωση ώστε οι γραμμές να μην σπάζουν στα άκρα του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τα ακριβή όρια εντός της διαφάνειας για μια συγκεκριμένη παράγραφο;**

Χρησιμοποιήστε το [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) για να ανακτήσετε το ορθογώνιο περιθώριο της παραγράφου. Το [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης ευθυγράμμιση);**

Η [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) είναι ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των μεμονωμένων τμημάτων.

Για κάθετες ευθυγραμμίσεις τμημάτων με διαφορετικά μεγέθη γραμματοσειράς μέσα σε κάθε γραμμή, δείτε το [Align Fonts Within a Line](/slides/el/python-net/text-formatting/#align-fonts-within-a-line).

**Μπορώ να ορίσω τη γλώσσα επιβολής για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλές γλώσσες.