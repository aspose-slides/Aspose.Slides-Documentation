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
- εσοχή παραγράφου
- εναρέθουσα εσοχή
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
description: "Κατακτήστε τη μορφοποίηση παραγράφων με το Aspose.Slides για Python μέσω .NET—βελτιστοποιήστε την ευθυγράμμιση, το διάστιχο & το στυλ σε παρουσιάσεις PowerPoint και OpenDocument σε Python για να προσελκύσετε το κοινό."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει τις κλάσεις που χρειάζεστε για να εργαστείτε με κείμενο PowerPoint σε Python.

* Το Aspose.Slides παρέχει την κλάση [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) για τη δημιουργία αντικειμένων πλαισίου κειμένου. Ένα αντικείμενο `TextFrame` μπορεί να περιέχει μία ή περισσότερες παραγράφους (κάθε παράγραφος χωρίζεται με επιστροφή καρτέλας).
* Το Aspose.Slides παρέχει την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) για τη δημιουργία αντικειμένων παραγράφου. Ένα αντικείμενο `Paragraph` μπορεί να περιέχει ένα ή περισσότερα τμήματα κειμένου.
* Το Aspose.Slides παρέχει την κλάση [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) για τη δημιουργία αντικειμένων τμήματος κειμένου και τον καθορισμό των ιδιοτήτων μορφοποίησής τους.

Ένα αντικείμενο `Paragraph` μπορεί να διαχειρίζεται κείμενο με διαφορετικές ιδιότητες μορφοποίησης μέσω των υποκείμενων αντικειμένων `Portion`.

## **Εγκατάσταση**

```bash
pip install aspose.slides
```

## **Προσθήκη Πολλαπλών Παραγράφων που Περιέχουν Πολλαπλά Τμήματα**

Αυτά τα βήματα δείχνουν πώς να προσθέσετε ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους, η καθεμία με τρία τμήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε αναφορά στη διαφάνεια-στόχο με βάση το δείκτη της.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).
5. Δημιουργήστε δύο αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και προσθέστε τα στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) (μαζί με την προεπιλεγμένη παράγραφο, αυτό δίνει τρεις παραγράφους).
6. Για κάθε παράγραφο, δημιουργήστε τρία αντικείμενα [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) και προσθέστε τα στη συλλογή τμημάτων της παραγράφου.
7. Ορίστε το κείμενο για κάθε τμήμα.
8. Εφαρμόστε τη μορφοποίηση που επιθυμείτε σε κάθε τμήμα κειμένου χρησιμοποιώντας τις ιδιότητες που εκτίθενται από το [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/).
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσία της κλάσης Presentation για τη δημιουργία νέου αρχείου PPTX.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη ενός ορθογώνιου AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Πρόσβαση στο TextFrame του AutoShape.
    text_frame = shape.text_frame

    # Δημιουργία παραγράφων και τμημάτων· η μορφοποίηση εφαρμόζεται παρακάτω.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Αποθήκευση του PPTX στον δίσκο.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Κουκίδων Παραγράφου**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι παραγράφοι με κουκίδες είναι συχνά πιο εύκολα στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια-στόχο με βάση το δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
6. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/).
7. Ορίστε τον τύπο κουκίδας της παραγράφου σε `SYMBOL` και καθορίστε τον χαρακτήρα της κουκίδας.
8. Ορίστε το κείμενο της παραγράφου.
9. Ορίστε την εσοχή της κουκίδας για την παράγραφο.
10. Ορίστε το χρώμα της κουκίδας.
11. Ορίστε το μέγεθος (ύψος) της κουκίδας.
12. Προσθέστε την παράγραφο στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
13. Προσθέστε μια δεύτερη παράγραφο και επαναλάβετε τα βήματα 7–12.
14. Αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσία παρουσίασης.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη και πρόσβαση σε AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου AutoShape.
    text_frame = shape.text_frame

    # Αφαίρεση της προεπιλεγμένης παραγράφου.
    text_frame.paragraphs.remove_at(0)

    # Δημιουργία παραγράφου.
    paragraph = slides.Paragraph()

    # Ορισμός του στυλ κουκίδας και συμβόλου της παραγράφου.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Ορισμός κειμένου παραγράφου.
    paragraph.text = "Welcome to Aspose.Slides"

    # Ορισμός εσοχής κουκίδας.
    paragraph.paragraph_format.indent = 25

    # Ορισμός χρώματος κουκίδας.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # Ορισμός ύψους κουκίδας.
    paragraph.paragraph_format.bullet.height = 100

    # Προσθήκη της παραγράφου στο πλαίσιο κειμένου.
    text_frame.paragraphs.add(paragraph)

    # Δημιουργία της δεύτερης παραγράφου.
    paragraph2 = slides.Paragraph()

    # Ορισμός τύπου και στυλ κουκίδας της παραγράφου.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # Ορισμός κειμένου παραγράφου.
    paragraph2.text = "This is numbered bullet"

    # Ορισμός εσοχής κουκίδας.
    paragraph2.paragraph_format.indent = 25

    # Ορισμός χρώματος κουκίδας.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # Ορισμός ύψους κουκίδας.
    paragraph2.paragraph_format.bullet.height = 100

    # Προσθήκη της παραγράφου στο πλαίσιο κειμένου.
    text_frame.paragraphs.add(paragraph2)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Κουκίδων Εικόνας**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι κουκίδες εικόνας είναι εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια-στόχο με βάση το δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
6. Δημιουργήστε μια παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το κείμενό της.
7. Φορτώστε μια εικόνα και προσθέστε την στη συλλογή εικόνων της παρουσίασης ως [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/).
8. Ορίστε τον τύπο κουκίδας σε `PICTURE` και αναθέστε το [PPImage] στην κουκίδα.
9. Ορίστε το ύψος της κουκίδας.
10. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
11. Αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Φόρτωση της εικόνας της κουκίδας.
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # Προσθήκη και πρόσβαση σε AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Πρόσβαση στο TextFrame του δημιουργημένου AutoShape.
    text_frame = auto_shape.text_frame

    # Αφαίρεση της προεπιλεγμένης παραγράφου.
    text_frame.paragraphs.remove_at(0)

    # Δημιουργία νέας παραγράφου.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Ορισμός του τύπου κουκίδας της παραγράφου σε Εικόνα και ανάθεση της εικόνας.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Ορισμός ύψους κουκίδας.
    paragraph.paragraph_format.bullet.height = 100

    # Προσθήκη της παραγράφου στο πλαίσιο κειμένου.
    text_frame.paragraphs.add(paragraph)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Αποθήκευση της παρουσίασης ως αρχείο PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Διαχείριση Πολυεπίπεδων Κουκίδων**

Οι λίστες με κουκίδες βοηθούν στην οργάνωση και παρουσίαση πληροφοριών γρήγορα και αποδοτικά. Οι πολυεπίπεδες κουκίδες είναι εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια-στόχο με βάση το δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσπελάστε το [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/)‑[TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
6. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το βάθος της σε 0.
7. Δημιουργήστε τη δεύτερη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το βάθος της σε 1.
8. Δημιουργήστε την τρίτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το βάθος της σε 2.
9. Δημιουργήστε την τέταρτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το βάθος της σε 3.
10. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
11. Αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσία παρουσίασης.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]
    
    # Προσθήκη AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Πρόσβαση στο TextFrame του δημιουργημένου AutoShape.
    text_frame = shape.text_frame
    
    # Καθαρισμός της προεπιλεγμένης παραγράφου.
    text_frame.paragraphs.clear()

    # Προσθήκη πρώτης παραγράφου.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορισμός επιπέδου κουκίδας.
    paragraph1.paragraph_format.depth = 0

    # Προσθήκη δεύτερης παραγράφου.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορισμός επιπέδου κουκίδας.
    paragraph2.paragraph_format.depth = 1

    # Προσθήκη τρίτης παραγράφου.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορισμός επιπέδου κουκίδας.
    paragraph3.paragraph_format.depth = 2

    # Προσθήκη τέταρτης παραγράφου.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορισμός επιπέδου κουκίδας.
    paragraph4.paragraph_format.depth = 3

    # Προσθήκη των παραγράφων στη συλλογή.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Παραγράφων με Προσαρμοσμένες Αριθμημένες Λίστες**

Η κλάση [BulletFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/) παρέχει την ιδιότητα `numbered_bullet_start_with` (και άλλες) για τον έλεγχο προσαρμοσμένης αρίθμησης και μορφοποίησης των παραγράφων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια που θα περιέχει τις παραγράφους.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
6. Δημιουργήστε την πρώτη [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε `numbered_bullet_start_with` σε 2.
7. Δημιουργήστε τη δεύτερη [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε `numbered_bullet_start_with` σε 3.
8. Δημιουργήστε την τρίτη [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε `numbered_bullet_start_with` σε 7.
9. Προσθέστε τις παραγράφους στη συλλογή του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
10. Αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Προσθήκη και πρόσβαση σε AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Πρόσβαση στο TextFrame του δημιουργημένου AutoShape.
    text_frame = shape.text_frame

    # Αφαίρεση της υπάρχουσας προεπιλεγμένης παραγράφου.
    text_frame.paragraphs.remove_at(0)

    # Δημιουργία του πρώτου αριθμημένου στοιχείου (αρχίζει από 2, επίπεδο βάθους 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Δημιουργία του δεύτερου αριθμημένου στοιχείου (αρχίζει από 3, επίπεδο βάθους 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Δημιουργία του τρίτου αριθμημένου στοιχείου (αρχίζει από 7, επίπεδο βάθους 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Εσοχής Πρώτης Γραμμής για Παράγραφο**

Χρησιμοποιήστε την ιδιότητα [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η ιδιότητα μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετακινεί την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [ParagraphFormat.margin_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/margin_left/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παράδειγμα παρακάτω δημιουργεί πολλές παραγράφους και εφαρμόζει διαφορετικές τιμές `indent` ώστε να δείξει πώς η εσοχή πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια-στόχο.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές [indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η εσοχή πρώτης γραμμής των παραγράφων](first_line_indent.png)

## **Ορισμός Εναρέθουσας Εσοχής για Παράγραφο**

Η εναρέθουσα εσοχή είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή ξεκινά αριστερότερα από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/). Ορίστε το `indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή προς τα αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat.margin_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/margin_left/) καθορίζει τη θέση του αριστερού περιθωρίου του σώματος της παραγράφου, ενώ το [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) καθορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε εναρέθουσα εσοχή, ορίστε μια θετική τιμή στο `margin_left` και μια αρνητική τιμή στο `indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, εγγραφές γλωσσολογίου και άλλες παραγράφους όπου οι τυλιγμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια-στόχο.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή στο [margin_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/margin_left/) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή στο [indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) για να δημιουργήσετε το εφέ εναρέθουσας εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η εναρέθουσα εσοχή των παραγράφων](hanging_indent.png)

## **Διαχείριση Μορφής Τμήματος Τέλους Παραγράφου**

Όταν χρειάζεται να ελέγξετε τη μορφοποίηση του «τέλους» μιας παραγράφου (η μορφοποίηση που εφαρμόζεται μετά το τελευταίο τμήμα κειμένου), χρησιμοποιήστε την ιδιότητα `end_paragraph_portion_format`. Το παρακάτω παράδειγμα εφαρμόζει μια μεγαλύτερη γραμματοσειρά Times New Roman στο τέλος της δεύτερης παραγράφου.

1. Δημιουργήστε ή ανοίξτε ένα αρχείο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Αποκτήστε τη διαφάνεια-στόχο με βάση το δείκτη.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Χρησιμοποιήστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος και δημιουργήστε δύο παραγράφους.
5. Δημιουργήστε ένα [PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/) με μέγεθος 48 pt Times New Roman και εφαρμόστε το ως μορφή τμήματος τέλους παραγράφου.
6. Αναθέστε το στο `end_paragraph_portion_format` της παραγράφου (εφαρμόζεται στο τέλος της δεύτερης παραγράφου).
7. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# Αφαίρεση της προεπιλεγμένης παραγράφου.
	shape.text_frame.paragraphs.clear()

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Εισαγωγή Κειμένου HTML σε Παραγράφους**

Το Aspose.Slides παρέχει ενισχυμένη υποστήριξη για την εισαγωγή κειμένου HTML σε παραγράφους.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια-στόχο με βάση το δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
6. Διαβάστε το αρχικό αρχείο HTML.
7. Προσθέστε το περιεχόμενο HTML στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import aspose.slides as slides

# Δημιουργήστε μια κενή παρουσία της κλάσης Presentation.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Προσθήκη AutoShape για την ενσωμάτωση του περιεχομένου HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Καθαρισμός όλων των παραγράφων στο προστεθειμένο πλαίσιο κειμένου.
    shape.text_frame.paragraphs.clear()

    # Φόρτωση του αρχείου HTML.
    with open("file.html", "rt") as html_stream:
        # Προσθήκη κειμένου από το αρχείο HTML στο πλαίσιο κειμένου.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Αποθήκευση της παρουσίασης.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Το Aspose.Slides παρέχει ενισχυμένη υποστήριξη για την εξαγωγή κειμένου σε HTML.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την στοχευμένη παρουσίαση.
2. Προσπελάστε τη διαφάνεια που επιθυμείτε με βάση το δείκτη.
3. Επιλέξτε το σχήμα που περιέχει το κείμενο προς εξαγωγή.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
5. Ανοίξτε μια ροή αρχείου για να γράψετε το αποτέλεσμα HTML.
6. Καθορίστε τον αρχικό δείκτη και εξάγετε τις απαιτούμενες παραγράφους.

```python
import aspose.slides as slides

# Φορτώστε το αρχείο παρουσίασης.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης.
    slide = presentation.slides[0]

    # Δείκτης στόχου σχήματος.
    index = 0

    # Πρόσβαση στο σχήμα με βάση το δείκτη.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Γράψτε τα δεδομένα παραγράφων σε HTML παρέχοντας το αρχικό δείκτη παραγράφου και τον συνολικό αριθμό παραγράφων προς εξαγωγή.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Αποθήκευση Παραγράφου ως Εικόνα**

Σε αυτήν την ενότητα, θα εξετάσουμε δύο παραδείγματα που δείχνουν πώς να αποθηκεύσετε μια παράγραφο κειμένου, που αντιπροσωπεύεται από την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/), ως εικόνα. Και τα δύο παραδείγματα περιλαμβάνουν την λήψη της εικόνας ενός σχήματος που περιέχει την παράγραφο χρησιμοποιώντας τις μεθόδους `get_image` της κλάσης [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/), τον υπολογισμό των ορίων της παραγράφου μέσα στο σχήμα και την εξαγωγή της ως bitmap εικόνα. Αυτές οι προσεγγίσεις σάς επιτρέπουν να εξάγετε συγκεκριμένα τμήματα κειμένου από παρουσιάσεις PowerPoint και να τα αποθηκεύσετε ως ξεχωριστές εικόνες, χρήσιμες για περαιτέρω χρήση σε διάφορα σενάρια.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx που περιέχει μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου με τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

**Παράδειγμα 1**

Σε αυτό το παράδειγμα, λαμβάνουμε τη δεύτερη παράγραφο ως εικόνα. Για να το κάνουμε αυτό, εξάγουμε την εικόνα του σχήματος από την πρώτη διαφάνεια της παρουσίασης και, στη συνέχεια, υπολογίζουμε τα όρια της δεύτερης παραγράφου στο πλαίσιο κειμένου του σχήματος. Η παράγραφο έπειτα ξανασχεδιάζεται πάνω σε ένα νέο bitmap, το οποίο αποθηκεύεται σε μορφή PNG. Αυτή η μέθοδος είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να αποθηκεύσετε μια συγκεκριμένη παράγραφο ως ξεχωριστή εικόνα, διατηρώντας τις ακριβείς διαστάσεις και μορφοποίηση του κειμένου.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Αποθηκεύστε το σχήμα στη μνήμη ως bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Δημιουργήστε ένα bitmap σχήματος από τη μνήμη.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Υπολογίστε τα όρια της δεύτερης παραγράφου.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Υπολογίστε τις συντεταγμένες και το μέγεθος για την έξοδο εικόνας (ελάχιστο μέγεθος - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Περικοπή του bitmap σχήματος ώστε να ληφθεί μόνο το bitmap της παραγράφου.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

**Παράδειγμα 2**

Σε αυτό το παράδειγμα, επεκτείνουμε την προηγούμενη προσέγγιση προσθέτοντας συντελεστές κλιμάκωσης στην εικόνα της παραγράφου. Το σχήμα εξάγεται από την παρουσίαση και αποθηκεύεται ως εικόνα με συντελεστή κλίμακας `2`. Αυτό επιτρέπει εξαγωγή με υψηλότερη ανάλυση. Τα όρια της παραγράφου υπολογίζονται λαμβάνοντας υπόψη την κλίμακα. Η κλιμάκωση μπορεί να είναι χρήσιμη όταν απαιτείται πιο λεπτομερής εικόνα, π.χ. για χρήση σε υψηλής ποιότητας έντυπο υλικό.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Αποθηκεύστε το σχήμα στη μνήμη ως bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Δημιουργήστε ένα bitmap σχήματος από τη μνήμη.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Υπολογίστε τα όρια της δεύτερης παραγράφου.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Υπολογίστε τις συντεταγμένες και το μέγεθος για την εικόνα εξόδου (ελάχιστο μέγεθος - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Περικόψτε το bitmap σχήματος ώστε να λαμβάνετε μόνο το bitmap της παραγράφου.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **Συχνές Ερωτήσεις**

### Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση κειμένου μέσα σε ένα πλαίσιο κειμένου;

Ναι. Χρησιμοποιήστε τη ρύθμιση αναδίπλωσης του πλαισίου κειμένου ([wrap_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/wrap_text/)) για να απενεργοποιήσετε την αναδίπλωση, ώστε οι γραμμές να μην σπάζουν στις άκρες του πλαισίου.

### Πώς μπορώ να λάβω τα ακριβή όρια σε διαφάνεια μιας συγκεκριμένης παραγράφου;

Μπορείτε να ανακτήσετε το ορθογώνιο περιορισμού της παραγράφου (και ακόμη και ενός μεμονωμένου τμήματος) για να γνωρίζετε τη ακριβή θέση και το μέγεθός της στη διαφάνεια.

### Πού ελέγχεται η στοίχιση της παραγράφου (αριστερά/δεξιά/κέντρο/δικαιολογημένα);

Το [Alignment](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/alignment/) είναι ρύθμιση επιπέδου παραγράφου στην [ParagraphFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/); εφαρμόζεται σε όλη την παράγραφο ανεξάρτητα από τη μορφοποίηση των μεμονωμένων τμημάτων.

### Μπορώ να ορίσω γλώσσα ελέγχου ορθογραφίας μόνο για μέρος μιας παραγράφου (π.χ., μία λέξη);

Ναι. Η γλώσσα ορίζεται σε επίπεδο τμήματος ([PortionFormat.language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/language_id/)), έτσι ώστε να μπορούν να συνυπάρχουν πολλαπλές γλώσσες μέσα σε μία παράγραφο.