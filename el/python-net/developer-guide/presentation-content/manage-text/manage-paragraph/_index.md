---
title: Διαχείριση παραγράφων κειμένου PowerPoint στην Python
linktitle: Διαχείριση Παραγράφου
type: docs
weight: 40
url: /el/python-net/manage-paragraph/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση κουκίδας
- εσοχή παραγράφου
- κρεματή εσοχή
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
description: "Κατέχετε τη μορφοποίηση παραγράφων με το Aspose.Slides για Python μέσω .NET—βελτιώστε την ευθυγράμμιση, το διάστημα & το στυλ σε παρουσιάσεις PowerPoint και OpenDocument στην Python για να εντυπωσιάζετε το κοινό."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει τις κλάσεις που χρειάζεστε για να εργαστείτε με κείμενο PowerPoint στην Python.

* Το Aspose.Slides παρέχει την κλάση [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) για τη δημιουργία αντικειμένων πλαισίου κειμένου. Ένα αντικείμενο `TextFrame` μπορεί να περιέχει μία ή περισσότερες παραγράφους (κάθε παράγραφος διαχωρίζεται με επιστροφή γραμμής).
* Το Aspose.Slides παρέχει την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) για τη δημιουργία αντικειμένων παραγράφου. Ένα αντικείμενο `Paragraph` μπορεί να περιέχει μία ή περισσότερες πορώσεις κειμένου.
* Το Aspose.Slides παρέχει την κλάση [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) για τη δημιουργία αντικειμένων portion και τον καθορισμό των ιδιοτήτων μορφοποίησής τους.

Ένα αντικείμενο `Paragraph` μπορεί να διαχειριστεί κείμενο με διαφορετικές ιδιότητες μορφοποίησης μέσω των υποκείμενων αντικειμένων `Portion`.

## **Προσθήκη Πολλών Παραγράφων που Περιέχουν Πολλά Portion**

Αυτά τα βήματα δείχνουν πώς να προσθέσετε ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους, η καθεμία με τρία Portion:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά στη στόχο διαφάνεια βάσει του δείκτη της.
1. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) που συσχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).
1. Δημιουργήστε δύο αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και προσθέστε τα στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) (μαζί με την προεπιλεγμένη παράγραφο, αυτό δίνει τρεις παραγράφους).
1. Για κάθε παράγραφο, δημιουργήστε τρία αντικείμενα [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/) και προσθέστε τα στη συλλογή portion της παραγράφου.
1. Ορίστε το κείμενο για κάθε portion.
1. Εφαρμόστε οποιαδήποτε επιθυμητή μορφοποίηση σε κάθε κείμενο portion χρησιμοποιώντας τις ιδιότητες που παρέχει η κλάση [Portion](https://reference.aspose.com/slides/el/python-net/aspose.slides/portion/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation για να δημιουργήσετε ένα νέο αρχείο PPTX.
with slides.Presentation() as presentation:

    # Προσπελάστε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα ορθογώνιο AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Προσπελάστε το TextFrame του AutoShape.
    text_frame = shape.text_frame

    # Δημιουργήστε παραγράφους και portion· η μορφοποίηση εφαρμόζεται παρακάτω.
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
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Αποθηκεύστε το PPTX στο δίσκο.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Κουκίδων Παραγράφων**

Οι λίστες με κουκίδες σας βοηθούν να οργανώνετε και να παρουσιάζετε πληροφορίες γρήγορα και αποτελεσματικά. Οι παράγραφοι με κουκίδες είναι συχνά πιο εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσπελάστε τη διαφάνεια-στόχο με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/).
1. Ορίστε τον τύπο κουκίδας της παραγράφου σε `SYMBOL` και καθορίστε το χαρακτήρα της κουκίδας.
1. Ορίστε το κείμενο της παραγράφου.
1. Ορίστε την εσοχή της κουκίδας για την παράγραφο.
1. Ορίστε το χρώμα της κουκίδας.
1. Ορίστε το μέγεθος (ύψος) της κουκίδας.
1. Προσθέστε την παράγραφο στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Προσθέστε μια δεύτερη παράγραφο και επαναλάβετε τα βήματα 7–12.
1. Αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε μια παρουσίαση.
with slides.Presentation() as presentation:

    # Προσπελάστε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε και προσπελάστε ένα AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Προσπελάστε το πλαίσιο κειμένου του δημιουργημένου AutoShape.
    text_frame = shape.text_frame

    # Αφαιρέστε την προεπιλεγμένη παράγραφο.
    text_frame.paragraphs.remove_at(0)

    # Δημιουργήστε μια παράγραφο.
    paragraph = slides.Paragraph()

    # Ορίστε το στυλ κουκίδας και το σύμβολο της παραγράφου.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Ορίστε το κείμενο της παραγράφου.
    paragraph.text = "Welcome to Aspose.Slides"

    # Ορίστε την εσοχή της κουκίδας.
    paragraph.paragraph_format.indent = 25

    # Ορίστε το χρώμα της κουκίδας.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Ορίστε το ύψος της κουκίδας.
    paragraph.paragraph_format.bullet.height = 100

    # Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
    text_frame.paragraphs.add(paragraph)

    # Δημιουργήστε τη δεύτερη παράγραφο.
    paragraph2 = slides.Paragraph()

    # Ορίστε τον τύπο και το στυλ της κουκίδας της παραγράφου.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Ορίστε το κείμενο της παραγράφου.
    paragraph2.text = "This is numbered bullet"

    # Ορίστε την εσοχή της κουκίδας.
    paragraph2.paragraph_format.indent = 25

    # Ορίστε το χρώμα της κουκίδας.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Ορίστε το ύψος της κουκίδας.
    paragraph2.paragraph_format.bullet.height = 100

    # Προσθέστε τη δεύτερη παράγραφο στο πλαίσιο κειμένου.
    text_frame.paragraphs.add(paragraph2)

    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Κουκίδων Εικόνας**

Οι λίστες με κουκίδες εικόνας βοηθούν να οργανώνετε και να παρουσιάζετε πληροφορίες γρήγορα και αποτελεσματικά. Οι κουκίδες εικόνας είναι εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσπελάστε τη διαφάνεια-στόχο με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/).
1. Φορτώστε μια εικόνα σε ένα [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/).
1. Ορίστε τον τύπο κουκίδας σε [PPImage](https://reference.aspose.com/slides/el/python-net/aspose.slides/ppimage/) και αντιστοιχίστε την εικόνα.
1. Ορίστε το κείμενο της παραγράφου.
1. Ορίστε την εσοχή της παραγράφου για την κουκίδα.
1. Ορίστε το χρώμα της κουκίδας.
1. Ορίστε το ύψος της κουκίδας.
1. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Προσθέστε μια δεύτερη παράγραφο και επαναλάβετε τα βήματα 8–12.
1. Αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Προσπελάστε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Φορτώστε την εικόνα της κουκίδας.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Προσθέστε και προσπελάστε ένα AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Προσπελάστε το TextFrame του δημιουργημένου AutoShape.
    text_frame = auto_shape.text_frame

    # Αφαιρέστε την προεπιλεγμένη παράγραφο.
    text_frame.paragraphs.remove_at(0)

    # Δημιουργήστε μια νέα παράγραφο.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Ορίστε τον τύπο κουκίδας της παραγράφου σε Εικόνα και αντιστοιχίστε την εικόνα.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Ορίστε το ύψος της κουκίδας.
    paragraph.paragraph_format.bullet.height = 100

    # Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
    text_frame.paragraphs.add(paragraph)

    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Αποθηκεύστε την παρουσίαση ως αρχείο PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Διαχείριση Πολυεπίπεδων Κουκίδων**

Οι λίστες με πολλαπλά επίπεδα κουκίδων βοηθούν να οργανώνετε και να παρουσιάζετε πληροφορίες γρήγορα και αποτελεσματικά. Οι πολυεπίπεδες κουκίδες είναι εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσπελάστε τη διαφάνεια-στόχο με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Προσπελάστε το [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το βάθος της σε 0.
1. Δημιουργήστε τη δεύτερη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το βάθος της σε 1.
1. Δημιουργήστε την τρίτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το βάθος της σε 2.
1. Δημιουργήστε την τέταρτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε το βάθος της σε 3.
1. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργήστε ένα αντικείμενο παρουσίασης.
with slides.Presentation() as presentation:

    # Προσπελάστε την πρώτη διαφάνεια.
    slide = presentation.slides[0]
    
    # Προσθέστε ένα AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Προσπελάστε το TextFrame του δημιουργημένου AutoShape.
    text_frame = auto_shape.text_frame
    
    # Απομακρύνετε την προεπιλεγμένη παράγραφο.
    text_frame.paragraphs.clear()

    # Προσθέστε την πρώτη παράγραφο.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορίστε το επίπεδο της κουκίδας.
    paragraph1.paragraph_format.depth = 0

    # Προσθέστε τη δεύτερη παράγραφο.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορίστε το επίπεδο της κουκίδας.
    paragraph2.paragraph_format.depth = 1

    # Προσθέστε την τρίτη παράγραφο.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορίστε το επίπεδο της κουκίδας.
    paragraph3.paragraph_format.depth = 2

    # Προσθέστε την τέταρτη παράγραφο.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορίστε το επίπεδο της κουκίδας.
    paragraph4.paragraph_format.depth = 3

    # Προσθέστε τις παραγράφους στη συλλογή.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Παραγράφων με Προσαρμοσμένες Αριθμημένες Λίστες**

Η κλάση [BulletFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/) παρέχει την ιδιότητα `numbered_bullet_start_with` (και άλλες) για τον έλεγχο προσαρμοσμένης αρίθμησης και μορφοποίησης των παραγράφων.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσπελάστε τη διαφάνεια που θα περιέχει τις παραγράφους.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Δημιουργήστε την πρώτη [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε `numbered_bullet_start_with` σε 2.
1. Δημιουργήστε τη δεύτερη [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε `numbered_bullet_start_with` σε 3.
1. Δημιουργήστε την τρίτη [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) και ορίστε `numbered_bullet_start_with` σε 7.
1. Προσθέστε τις παραγράφους στη συλλογή του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Προσθέστε και προσπελάστε ένα AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Προσπελάστε το TextFrame του δημιουργημένου AutoShape.
    text_frame = shape.text_frame

    # Αφαιρέστε την προεπιλεγμένη υπάρχουσα παράγραφο.
    text_frame.paragraphs.remove_at(0)

    # Δημιουργήστε το πρώτο αριθμημένο στοιχείο (έναρξη στο 2, επίπεδο βάθους 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Δημιουργήστε το δεύτερο αριθμημένο στοιχείο (έναρξη στο 3, επίπεδο βάθους 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Δημιουργήστε το τρίτο αριθμημένο στοιχείο (έναρξη στο 7, επίπεδο βάθους 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ορισμός Εσοχής Πρώτης Γραμμής για Παράγραφο**

Χρησιμοποιήστε την ιδιότητα [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) για τον έλεγχο της εσοχής της πρώτης γραμμής μιας παραγράφου. Αυτή η ιδιότητα μετατοπίζει μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετακινεί την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε [ParagraphFormat.margin_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/margin_left/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) όταν χρειάζεται να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί αρκετές παραγράφους και εφαρμόζει διαφορετικές τιμές `indent` για να δείξει πώς η εσοχή πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
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

## **Ορισμός Κρεματής Εσοχής για Παράγραφο**

Η κρεματή εσοχή είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή ξεκινά αριστερότερα από τις υπόλοιπες γραμμές. Στο Aspose.Slides, μπορείτε να δημιουργήσετε αυτό το εφέ με την ιδιότητα [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/). Ορίστε `indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή προς τα αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat.margin_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/margin_left/) ορίζεται η αριστερή θέση του σώματος της παραγράφου, ενώ το [ParagraphFormat.indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε κρεματή εσοχή, ορίστε μια θετική τιμή στο `margin_left` και μια αρνητική τιμή στο `indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, αναφορές, όρους γλωσσάριου και άλλες παραγράφους όπου οι αναδιπλωμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια-στόχο.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [margin_left](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/margin_left/) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή [indent](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/indent/) για να δημιουργήσετε το εφέ της κρεματής εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```py
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

![Η κρεματή εσοχή των παραγράφων](hanging_indent.png)

## **Διαχείριση Μορφοποίησης Portion στο Τέλος της Παραγράφου**

Όταν χρειάζεται να ελέγξετε τη μορφοποίηση του «τέλους» μιας παραγράφου (η μορφοποίηση που εφαρμόζεται μετά το τελευταίο κείμενο portion), χρησιμοποιήστε την ιδιότητα `end_paragraph_portion_format`. Το παρακάτω παράδειγμα εφαρμόζει μεγαλύτερη γραμματοσειρά Times New Roman στο τέλος της δεύτερης παραγράφου.

1. Δημιουργήστε ή ανοίξτε ένα αρχείο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Αποκτήστε τη διαφάνεια-στόχο κατά δείκτη.
1. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος και δημιουργήστε δύο παραγράφους.
1. Δημιουργήστε ένα [PortionFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/) 48‑pt Times New Roman και εφαρμόστε το ως μορφοποίηση τέλους παραγράφου.
1. Εκχωρήστε το στην `end_paragraph_portion_format` της παραγράφου (εφαρμόζεται στο τέλος της δεύτερης παραγράφου).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

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

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για εισαγωγή κειμένου HTML σε παραγράφους.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Προσπελάστε τη διαφάνεια-στόχο με το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/) στη διαφάνεια.
1. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/).
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Διαβάστε το αρχείο πηγής HTML.
1. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/).
1. Προσθέστε το περιεχόμενο HTML στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import aspose.slides as slides

# Δημιουργήστε ένα κενό αντικείμενο Presentation.
with slides.Presentation() as presentation:

    # Προσπελάστε την πρώτη διαφάνεια της παρουσίασης.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Προσθέστε ένα AutoShape για να φιλοξενήσει το περιεχόμενο HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Καθαρίστε όλες τις παραγράφους στο προστιθέμενο πλαίσιο κειμένου.
    shape.text_frame.paragraphs.clear()

    # Φορτώστε το αρχείο HTML.
    with open("file.html", "rt") as html_stream:
        # Προσθέστε το κείμενο από το αρχείο HTML στο πλαίσιο κειμένου.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Αποθηκεύστε την παρουσίαση.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για εξαγωγή κειμένου σε HTML.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσίαση-στόχο.
1. Προσπελάστε τη ζητούμενη διαφάνεια με το δείκτη της.
1. Επιλέξτε το σχήμα που περιέχει το κείμενο προς εξαγωγή.
1. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) του σχήματος.
1. Ανοίξτε μια ροή αρχείου για να γράψετε την έξοδο HTML.
1. Καθορίστε τον αρχικό δείκτη και εξάγετε τις απαιτούμενες παραγράφους.

```python
import aspose.slides as slides

# Φορτώστε το αρχείο παρουσίασης.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Προσπελάστε την πρώτη διαφάνεια της παρουσίασης.
    slide = presentation.slides[0]

    # Δείκτης του στόχου σχήματος.
    index = 0

    # Προσπελάστε το σχήμα με βάση το δείκτη.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Γράψτε τα δεδομένα της παραγράφου σε HTML παρέχοντας τον αρχικό δείκτη παραγράφου και τον συνολικό αριθμό παραγράφων προς εξαγωγή.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Αποθήκευση Παραγράφου ως Εικόνα**

Σε αυτήν την ενότητα, θα εξετάσουμε δύο παραδείγματα που δείχνουν πώς να αποθηκεύσετε μια παράγραφο κειμένου, εκπροσωπούμενη από την κλάση [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/), ως εικόνα. Και τα δύο παραδείγματα περιλαμβάνουν λήψη της εικόνας ενός σχήματος που περιέχει την παράγραφο χρησιμοποιώντας τις μεθόδους `get_image` της κλάσης [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/), υπολογισμό των ορίων της παραγράφου μέσα στο σχήμα και εξαγωγή της ως bitmap εικόνας. Αυτές οι προσεγγίσεις επιτρέπουν την εξαγωγή συγκεκριμένων τμημάτων του κειμένου από παρουσιάσεις PowerPoint και την αποθήκευσή τους ως ξεχωριστές εικόνες, χρήσιμες για περαιτέρω χρήση σε διάφορα σενάρια.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

**Παράδειγμα 1**

Σε αυτό το παράδειγμα, λαμβάνουμε τη δεύτερη παράγραφο ως εικόνα. Για να το κάνουμε αυτό, εξάγουμε την εικόνα του σχήματος από την πρώτη διαφάνεια της παρουσίασης και στη συνέχεια υπολογίζουμε τα όρια της δεύτερης παραγράφου στο πλαίσιο κειμένου του σχήματος. Η παράγραφος στη συνέχεια σχεδιάζεται εκ νέου σε μια νέα bitmap εικόνα, η οποία αποθηκεύεται σε μορφή PNG. Αυτή η μέθοδος είναι ιδιαίτερα χρήσιμη όταν πρέπει να αποθηκεύσετε μια συγκεκριμένη παράγραφο ως ξεχωριστή εικόνα διατηρώντας τις ακριβείς διαστάσεις και τη μορφοποίηση του κειμένου.

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

    # Υπολογίστε τις συντεταγμένες και το μέγεθος για την εικόνα εξόδου (ελάχιστο μέγεθος - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Κόψτε το bitmap του σχήματος ώστε να πάρετε μόνο το bitmap της παραγράφου.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

**Παράδειγμα 2**

Σε αυτό το παράδειγμα, επεκτείνουμε την προηγούμενη προσέγγιση προσθέτοντας παράγοντες κλιμάκωσης στην εικόνα της παραγράφου. Το σχήμα εξάγεται από την παρουσίαση και αποθηκεύεται ως εικόνα με παράγοντα κλιμάκωσης `2`. Αυτό επιτρέπει την παραγωγή εικόνας υψηλότερης ανάλυσης κατά την εξαγωγή της παραγράφου. Τα όρια της παραγράφου υπολογίζονται έπειτα λαμβάνοντας υπόψη την κλίμακα. Η κλιμάκωση μπορεί να είναι ιδιαίτερα χρήσιμη όταν απαιτείται πιο λεπτομερής εικόνα, για παράδειγμα για χρήση σε υψηλής ποιότητας έντυπο υλικό.

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

    # Κόψτε το bitmap του σχήματος ώστε να πάρετε μόνο το bitmap της παραγράφου.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς τη συστροφή γραμμής μέσα σε ένα TextFrame;**

Ναι. Χρησιμοποιήστε τη ρύθμιση περιτύλιξης του πλαισίου κειμένου ([wrap_text](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframeformat/wrap_text/)) για να απενεργοποιήσετε το περιτύλιγμα, ώστε οι γραμμές να μην σπάζουν στα άκρα του πλαισίου.

**Πώς μπορώ να λάβω τα ακριβή όρια μιας συγκεκριμένης παραγράφου στην διαφάνεια;**

Μπορείτε να ανακτήσετε το ορθογώνιο περιορισμού της παραγράφου (και ακόμη και ενός μεμονωμένου portion) για να γνωρίζετε τη θέση και το μέγεθός της στην διαφάνεια.

**Πού ελέγχεται η στοίχιση της παραγράφου (αριστερά/δεξιά/κέντρο/ομοιόμορφα);**

Η [Alignment](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/alignment/) είναι ρύθμιση επιπέδου παραγράφου στην [ParagraphFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/); εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των μεμονωμένων portion.

**Μπορώ να ορίσω γλώσσα ελέγχου ορθογραφίας μόνο για μέρος μιας παραγράφου (π.χ. μια λέξη);**

Ναι. Η γλώσσα ορίζεται στο επίπεδο portion ([PortionFormat.language_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/portionformat/language_id/)), έτσι ώστε να μπορούν να συνυπάρχουν πολλές γλώσσες μέσα σε μία παράγραφο.