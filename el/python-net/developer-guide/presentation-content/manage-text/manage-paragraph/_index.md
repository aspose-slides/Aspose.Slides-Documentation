---
title: "Διαχείριση Παραγράφων Κειμένου PowerPoint σε Python"
linktitle: "Διαχείριση Παραγράφου"
type: docs
weight: 40
url: /el/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
  - "προσθήκη κειμένου"
  - "προσθήκη παραγράφου"
  - "διαχείριση κειμένου"
  - "διαχείριση παραγράφου"
  - "διαχείριση κουκκίδας"
  - "εσοχή παραγράφου"
  - "κρεματή εσοχή"
  - "κουκκίδα παραγράφου"
  - "αριθμημένη λίστα"
  - "λίστα με κουκκίδες"
  - "ιδιότητες παραγράφου"
  - "εισαγωγή HTML"
  - "κείμενο σε HTML"
  - "παράγραφος σε HTML"
  - "παράγραφος σε εικόνα"
  - "κείμενο σε εικόνα"
  - "εξαγωγή παραγράφου"
  - "PowerPoint"
  - "παρουσίαση"
  - "Python"
  - "Aspose.Slides"
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε παραγράφους, τμήματα, κουκκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφων με το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω .NET αναπαριστά το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) αντιπροσωπεύει το περιέκτη κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή παραγράφων του.
* [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) αντιπροσωπεύει μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα και στη διαμόρφωση επιπέδου παραγράφου.
* [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) αντιπροσωπεύει μια ακολουθία κειμένου μέσα σε μια παράγραφο. Κάθε τμήμα μπορεί να έχει τη δική του διαμόρφωση κειμένου και χαρακτήρων.

Μια παράγραφος μπορεί επομένως να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλες μορφοποιήσεις χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Διαμόρφωση Παραγράφων**

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Τα παρακάτω βήματα δημιουργούν ένα πλαίσιο κειμένου με τρεις παραγράφους, καθεμία από τις οποίες περιέχει τρία τμήματα:

1. Δημιουργήστε μια παρουσία κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
5. Χρησιμοποιήστε την προεπιλεγμένη παράγραφο και προσθέστε δύο ακόμη αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) στο πλαίσιο κειμένου.
6. Προσθέστε επαρκή αντικείμενα [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) ώστε κάθε παράγραφος να περιέχει τρία τμήματα. Η προεπιλεγμένη παράγραφος περιέχει ήδη ένα κενό τμήμα.
7. Ορίστε το κείμενο κάθε τμήματος.
8. Εφαρμόστε διαμόρφωση επιπέδου χαρακτήρων μέσω του [Portion.portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/portion_format/).
9. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτό το παράδειγμα Python υλοποιεί τα βήματα:

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

## **Δημιουργία Λιστών με Κουκκίδες και Αρίθμηση**

### **Δημιουργία Λίστας με Κουκκίδες ή Αρίθμηση**

Οι κουκκίδες και η αρίθμηση καθιστούν ευκολότερη την επισκόπηση σχετικών στοιχείων. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [BulletFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/).

1. Δημιουργήστε μια παρουσία κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) για μια σύμβολο-κουκκίδα.
7. Ορίστε το [BulletFormat.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/type/) σε [BulletType.SYMBOL](https://reference.aspose.com/slides/el/python-net/aspose.slides/bullettype/) και καθορίστε τον χαρακτήρα της κουκκίδας.
8. Ορίστε το κείμενο της παραγράφου, το εσοχή, το χρώμα και το ύψος της κουκκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Δημιουργήστε μια δεύτερη παράγραφο και ορίστε το [BulletFormat.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/type/) σε [BulletType.NUMBERED](https://reference.aspose.com/slides/el/python-net/aspose.slides/bullettype/).
11. Διαμορφώστε το στυλ αριθμημένης κουκκίδας και προσθέστε την παράγραφο στο πλαίσιο κειμένου.
12. Αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα Python δημιουργεί μια σύμβολο-κουκκίδα και μια αριθμημένη κουκκίδα:

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

### **Χρήση Εικόνων ως Κουκκίδες**

Οι εικόνες-κουκκίδες σάς επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

1. Δημιουργήστε μια παρουσία κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) και αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
4. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
5. Φορτώστε την εικόνα της κουκκίδας και προσθέστε την στη συλλογή εικόνων της παρουσία ως [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/).
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το κείμενό του.
7. Ορίστε το [BulletFormat.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/type/) σε [BulletType.PICTURE](https://reference.aspose.com/slides/el/python-net/aspose.slides/bullettype/).
8. Αναθέστε την εικόνα μέσω του [BulletFormat.picture](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/picture/) και ορίστε το ύψος της κουκκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτό το παράδειγμα Python δημιουργεί μια εικόνα-κουκκίδα:

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

Ορίστε το [ParagraphFormat.depth](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/depth/) για να τοποθετήσετε τις παραγράφους σε διαφορετικά επίπεδα λίστας. Το ανώτερο επίπεδο έχει βάθος `0`.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και αποκτήστε πρόσβαση σε μια διαφάνεια.
2. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) και αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του.
3. Δημιουργήστε τέσσερις παραγράφους και διαμορφώστε τα σύμβολα των κουκκίδων τους.
4. Ορίστε τις τιμές του [ParagraphFormat.depth](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/depth/) σε `0`, `1`, `2` και `3`.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα Python δημιουργεί μια λίστα με τέσσερα επίπεδα κουκκίδων:

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

### **Έναρξη Αριθμού Λίστας από Προσαρμοσμένες Τιμές**

Χρησιμοποιήστε το [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται για μια αριθμημένη παράγραφο.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) σε μια διαφάνεια.
2. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του σχήματος.
3. Δημιουργήστε τρεις αριθμημένες παραγράφους.
4. Ορίστε το [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) σε `2`, `3` και `7` για τις αντίστοιχες παραγράφους.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα Python αντιστοιχίζει έναν προσαρμοσμένο αρχικό αριθμό σε κάθε παράγραφο:

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

## **Έλεγχος Διάταξης Παραγράφων και Ιδιοτήτων Τέλους**

### **Ορισμός Στοίχισης Πρώτης Γραμμής**

Χρησιμοποιήστε την ιδιότητα [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) για να ελέγξετε το εσοχή της πρώτης γραμμής μιας παραγράφου. Η ιδιότητα αυτή μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετατοπίζει την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [ParagraphFormat.margin_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/margin_left/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί πολλές παραγράφους και εφαρμόζει διαφορετικές τιμές [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) για να δείξει πώς η στοίχιση πρώτης γραμμής επηρεάζει τη διάταξη.

1. Δημιουργήστε μια παρουσία κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε πρόσβαση στη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε αρκετές παραγράφους και ορίστε διαφορετικές τιμές [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) για καθεμία.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας δείχνει πώς να ορίσετε εσοχή παραγράφου:

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

### **Ορισμός Κρεματής Στοίχισης**

Η κρεματή στοίχιση είναι διάταξη παραγράφου όπου η πρώτη γραμμή αρχίζει αριστερά από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/). Ορίστε το `indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat.margin_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/margin_left/) καθορίζει τη θέση αριστερά του σώματος της παραγράφου, ενώ το [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε κρεματή στοίχιση, ορίστε μια θετική τιμή στο `margin_left` και μια αρνητική τιμή στο `indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, εγγραφές γλωσσολογικού λεξικού και άλλες παραγράφους όπου οι συρραπτικές γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε μια παρουσία κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε πρόσβαση στη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [ParagraphFormat.margin_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/margin_left/) για κάθε μια.
6. Ορίστε μια αρνητική τιμή [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) για να δημιουργήσετε το εφέ κρεματής στοίχισης.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας δείχνει πώς να ορίσετε κρεματή στοίχιση για μια παράγραφο:

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

### **Ορισμός Ιδιοτήτων Τέλους Παραγράφου**

Η ιδιότητα [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) ελέγχει τη διαμόρφωση του δείκτη τέλους παραγράφου. Το παρακάτω παράδειγμα αναθέτει μέγεθος γραμματοσειράς και λατινική γραμματοσειρά στο δείκτη τέλους της δεύτερης παραγράφου:

1. Φορτώστε μια [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και αποκτήστε πρόσβαση σε μια διαφάνεια.
2. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) και αφαιρέστε την προεπιλεγμένη παράγραφο.
3. Δημιουργήστε δύο παραγράφους και προσθέστε τμήματα κειμένου σε κάθε μία.
4. Δημιουργήστε ένα [PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/) για το δείκτη τέλους της δεύτερης παραγράφου.
5. Ορίστε το [PortionFormat.font_height](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/font_height/) και το [PortionFormat.latin_font](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/latin_font/).
6. Αναθέστε τη διαμόρφωση στο [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) και αποθηκεύστε την παρουσία.

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

## **Καταμέτρηση Απεικονιζόμενων Γραμμών**

Χρησιμοποιήστε το [Paragraph.get_lines_count](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/get_lines_count/) για να μετρήσετε τις γραμμές που κατέχει μια παράγραφος μετά τη διάταξη του κειμένου, συμπεριλαμβανομένης της αυτόματης αναδίπλωσης. Αυτό είναι χρήσιμο όταν ελέγχετε το μήκος και τη διάταξη του κειμένου σε πρότυπα παρουσιάσεων.

Μια παράγραφος είναι ένα στοιχείο του [TextFrame.paragraphs](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/paragraphs/), και μπορεί να καταλαμβάνει πολλές εμφανιζόμενες γραμμές. Μία ρητή αλλαγή γραμμής εντός μιας παραγράφου εξαναγκάζει νέα γραμμή χωρίς να δημιουργεί νέα παράγραφο. Η αυτόματη αναδίπλωση δημιουργεί γραμμές βάσει του διαθέσιμου πλάτους χωρίς να εισάγει ρητές αλλαγές γραμμής στο κείμενο. Συνεπώς, η καταμέτρηση παραγράφων ή χαρακτήρων αλλαγής γραμμής δεν παρέχει τον αριθμό των εμφανιζόμενων γραμμών.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα κειμένου, μετρά τις γραμμές του, περιορίζει το σχήμα και στη συνέχεια αντικαθιστά το κείμενο με μια πιο σύντομη συμβολοσειρά. Η αναδίπλωση είναι ενεργή και η αυτόματη προσαρμογή κειμένου είναι ανενεργή, ώστε το πλάτος του σχήματος να ελέγχει την αναδίπλωση χωρίς να μειώνει αυτόματα το κείμενο ή το μέγεθος του σχήματος. Οι διαστάσεις του σχήματος δίνονται σε σημεία. Τέλος, το παράδειγμα προσθέτει μία ακόμη παράγραφο και αθροίζει τις γραμμές σε όλο το πλαίσιο κειμένου.

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

Με αυτό το κείμενο και αυτές τις διαστάσεις, η σμίκρυνση του σχήματος αυξάνει τον αριθμό γραμμών, ενώ η αντικατάσταση του κειμένου με τη σύντομη συμβολοσειρά τον μειώνει. Οι ακριβείς μετρήσεις μπορεί να διαφέρουν ανάλογα με τη διαθεσιμότητα γραμματοσειρών και τις υποκατάστασες, το μέγεθος γραμματοσειράς, τα περιθώρια, τις εσοχές, την αναδίπλωση και τις ρυθμίσεις αυτόματης προσαρμογής. Χρησιμοποιήστε τις γραμματοσειρές και τις ρυθμίσεις διάταξης που προορίζονται για το περιβάλλον προορισμού όταν ελέγχετε ένα πρότυπο.

Ο μόνος ο αριθμός γραμμών δεν καθορίζει εάν το κείμενο υπερβαίνει το περιέκτη του. Το διαθέσιμο ύψος, το ύψος γραμμών, οι αποστάσεις παραγράφου και γραμμής, καθώς και η συμπεριφορά αυτόματης προσαρμογής είναι επίσης σημαντικά· ακόμη και μία γραμμή μπορεί να ξεπεράσει το διαθέσιμο πλάτος όταν η αναδίπλωση είναι ανενεργή.

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφων**

### **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphcollection/add_from_html/) για να μετατρέψετε markup HTML σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

1. Δημιουργήστε μια παρουσία κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε πρόσβαση σε μια διαφάνεια και προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).
3. Αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
4. Διαβάστε το πηγαίο αρχείο HTML.
5. Περνάτε τη συμβολοσειρά HTML στο [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτό το παράδειγμα Python εισάγει HTML σε ένα πλαίσιο κειμένου:

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

### **Εξαγωγή Κειμένου Παραγράφων σε HTML**

Χρησιμοποιήστε το [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphcollection/export_to_html/) για να εξάγετε μια επιλεγμένη περιοχή παραγράφων ως HTML.

1. Δημιουργήστε μια παρουσία κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την επιθυμητή παρουσία.
2. Αποκτήστε πρόσβαση στη διαφάνεια και βρείτε το [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) που περιέχει το κείμενο.
3. Αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
4. Καλέστε το [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphcollection/export_to_html/) με τον δείκτη της αρχικής παραγράφου και τον αριθμό των παραγράφων προς εξαγωγή.
5. Γράψτε τη ληφθείσα συμβολοσειρά HTML σε αρχείο.

Αυτό το παράδειγμα Python εξάγει όλες τις παραγράφους από το πρώτο σχήμα κειμένου:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Απόδοση Παραγράφου ως Εικόνας**

Το [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) παρέχει τη μέθοδο `get_image` για άμεση απόδοση μιας μεμονωμένης παραγράφου. Η μέθοδος επιστρέφει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/) που μπορείτε να αποθηκεύσετε σε αρχείο ή ροή με το [IImage.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/iimage/save/). Δεν χρειάζεται να αποδώσετε το σχήμα που περιέχει ή να περικόψετε bitmap χειροκίνητα.

Η μέθοδος `get_image` μπορεί να επιστρέψει `None` εάν η παράγραφος δεν μπορεί να βρεθεί στη γονική συλλογή, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και χρησιμοποιήστε την επιστρεφόμενη εικόνα ως context manager για την απελευθέρωση των πόρων της.

#### **Απόδοση Παραγράφου στην Προεπιλεγμένη Κλίμακα**

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πεδίο κειμένου που περιέχει τρεις παραγράφους.

![The text box with three paragraphs](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα αποδίδει τη δεύτερη παράγραφο σε ένα κανονικό σχήμα κειμένου στην προεπιλεγμένη κλίμακα και αποθηκεύει την επιστρεφόμενη εικόνα σε μορφή PNG:

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

#### **Απόδοση Παραγράφου σε Κελί Πίνακα με Κλιμάκωση**

Προσδιορίστε οριζόντιους και κάθετους συντελεστές κλίμακας στη `get_image` για να ελέγξετε το μέγεθος της αποδομένης παραγράφου. Το ακόλουθο παράδειγμα δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο του κελί με διπλάσιο πλάτος και ύψος από το προεπιλεγμένο, και αποθηκεύει το αποτέλεσμα ως εικόνα PNG:

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

Ένας συντελεστής κλίμακας `1` διατηρεί τον άξονα στην προεπιλεγμένη του διάσταση pixel. Για παράδειγμα, `2` και για τους δύο συντελεστές παράγει μια εικόνα του οποίου το πλάτος και το ύψος είναι περίπου διπλάσιο από τις προεπιλεγμένες διαστάσεις, με αποτέλεσμα τέσσερα φορές περισσότερα pixel. Μεγαλύτεροι συντελεστές συνήθως παράγουν πιο καθαρό κείμενο για ζουμ ή υψηλή ανάλυση, αλλά αυξάνουν επίσης τη χρήση μνήμης και το μέγεθος του αρχείου. Συντελεστές κάτω από `1` παράγουν μικρότερες εικόνες με λιγότερες λεπτομέρειες. Χρησιμοποιήστε ίσους συντελεστές για να διατηρήσετε την αναλογία πλευρών της παραγράφου· διαφορετικοί οριζόντιοι και κάθετοι συντελεστές τεντώνουν το αποτέλεσμα ανεξάρτητα.

Η απόδοση ολόκληρου σχήματος με τη [Shape.get_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/get_image/) παραμένει χρήσιμη όταν η έξοδος πρέπει να περιλαμβάνει τη γέμιση, το περίγραμμα ή άλλο οπτικό περιεχόμενο του σχήματος. Για εικόνα μόνο της παραγράφου, χρησιμοποιήστε `Paragraph.get_image`.

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/wrap_text/) για να απενεργοποιήσετε την αναδίπλωση ώστε οι γραμμές να μην σπάζουν στις άκρες του πλαισίου κειμένου.

**Πώς μπορώ να λάβω το ακριβές όριο εντός της διαφάνειας για μια συγκεκριμένη παράγραφο;**

Χρησιμοποιήστε το [Paragraph.get_rect](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/get_rect/) για να ανακτήσετε το ορθογώνιο περίγραμμα της παραγράφου. Το [Portion.get_rect](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/get_rect/) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης στοίχιση);**

Το [ParagraphFormat.alignment](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/alignment/) είναι ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των μεμονωμένων τμημάτων.

**Μπορώ να ορίσω τη γλώσσα ελέγχου ορθογραφίας για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [PortionFormat.language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/language_id/) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλαπλές γλώσσες.