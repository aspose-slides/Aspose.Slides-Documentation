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
  - διαχείριση κουκκίδας
  - εσοχή παραγράφου
  - κρεματή εσοχή
  - κουκκίδα παραγράφου
  - αριθμημένη λίστα
  - λίστα με κουκκίδες
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
description: "Κατακτήστε τη μορφοποίηση παραγράφων με Aspose.Slides για Python μέσω .NET—βελτιστοποιήστε την ευθυγράμμιση, το διάστημα & το στυλ σε παρουσιάσεις PowerPoint και OpenDocument σε Python για να εντυπωσιάσετε τους θεατές."
---
## **Εισαγωγή**

Aspose.Slides παρέχει τις κλάσεις που χρειάζεστε για εργασία με κείμενο PowerPoint σε Python.

* Το Aspose.Slides παρέχει την κλάση [TextFrame] για τη δημιουργία αντικειμένων πλαισίου κειμένου. Ένα αντικείμενο `TextFrame` μπορεί να περιέχει μία ή περισσότερες παραγράφους (κάθε παράγραφος διαχωρίζεται με επιστροφή καρτέλας).
* Το Aspose.Slides παρέχει την κλάση [Paragraph] για τη δημιουργία αντικειμένων παραγράφου. Ένα αντικείμενο `Paragraph` μπορεί να περιέχει μία ή περισσότερες ενότητες κειμένου.
* Το Aspose.Slides παρέχει την κλάση [Portion] για τη δημιουργία αντικειμένων ενότητας κειμένου και τον καθορισμό των ιδιοτήτων μορφοποίησής τους.

Ένα αντικείμενο `Paragraph` μπορεί να διαχειριστεί κείμενο με διαφορετικές ιδιότητες μορφοποίησης μέσω των υποκείμενων αντικειμένων `Portion`.

## **Προσθήκη Πολλαπλών Παραγράφων που Περιέχουν Πολλαπλές Ενότητες**

Αυτά τα βήματα δείχνουν πώς να προσθέσετε ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους, καθεμία με τρεις ενότητες:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation].
1. Λάβετε μια αναφορά στη στοχευμένη διαφάνεια κατά το ευρετήριο της.
1. Προσθέστε ένα ορθογώνιο [AutoShape] στη διαφάνεια.
1. Λάβετε το [TextFrame] που σχετίζεται με το [AutoShape].
1. Δημιουργήστε δύο αντικείμενα [Paragraph] και προσθέστε τα στη συλλογή παραγράφων του [TextFrame] (μαζί με την προεπιλεγμένη παράγραφο, αυτό δίνει τρεις παραγράφους).
1. Για κάθε παράγραφο, δημιουργήστε τρία αντικείμενα [Portion] και προσθέστε τα στη συλλογή ενοτήτων της παραγράφου.
1. Ορίστε το κείμενο για κάθε ενότητα.
1. Εφαρμόστε την επιθυμητή μορφοποίηση σε κάθε ενότητα κειμένου χρησιμοποιώντας τις ιδιότητες που εκτίθενται από την [Portion].
1. Αποθηκεύστε την τροποποιημένη παρουσία.

Ο παρακάτω κώδικας Python υλοποιεί αυτά τα βήματα:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία αντικειμένου Presentation για τη δημιουργία νέου αρχείου PPTX.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθήκη ορθογώνιου AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Πρόσβαση στο TextFrame του AutoShape.
    text_frame = shape.text_frame

    # Δημιουργία παραγράφων και ενοτήτων· η μορφοποίηση εφαρμόζεται παρακάτω.
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

    # Αποθήκευση του PPTX στο δίσκο.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Σημείων Κουκκίδας Παραγράφου**

Οι λίστες με κουκκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποτελεσματικά. Οι παράγραφοι με κουκκίδες είναι συχνά πιο ευανάγνωστες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation].
1. Πρόσβαση στη στοχευμένη διαφάνεια κατά το ευρετήριο της.
1. Προσθέστε ένα [AutoShape] στη διαφάνεια.
1. Πρόσβαση στο [TextFrame] του σχήματος.
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame].
1. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph].
1. Ορίστε τον τύπο κουκκίδας της παραγράφου σε `SYMBOL` και καθορίστε το χαρακτήρα της κουκκίδας.
1. Ορίστε το κείμενο της παραγράφου.
1. Ορίστε την εσοχή της κουκκίδας για την παράγραφο.
1. Ορίστε το χρώμα της κουκκίδας.
1. Ορίστε το μέγεθος (ύψος) της κουκκίδας.
1. Προσθέστε την παράγραφο στη συλλογή παραγράφων του [TextFrame].
1. Προσθέστε μια δεύτερη παράγραφο και επαναλάβετε τα βήματα 7–12.
1. Αποθηκεύστε την παρουσία.

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε παραγράφους με κουκκίδες:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία στιγμιοτύπου παρουσίασης.
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

    # Ορισμός του στυλ κουκκίδας και συμβόλου της παραγράφου.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Ορισμός του κειμένου της παραγράφου.
    paragraph.text = "Welcome to Aspose.Slides"

    # Ορισμός εσοχής κουκκίδας.
    paragraph.paragraph_format.indent = 25

    # Ορισμός χρώματος κουκκίδας.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Ορισμός ύψους κουκκίδας.
    paragraph.paragraph_format.bullet.height = 100

    # Προσθήκη της παραγράφου στο πλαίσιο κειμένου.
    text_frame.paragraphs.add(paragraph)

    # Δημιουργία της δεύτερης παραγράφου.
    paragraph2 = slides.Paragraph()

    # Ορισμός του τύπου και του στυλ κουκκίδας της παραγράφου.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Ορισμός του κειμένου της παραγράφου.
    paragraph2.text = "This is numbered bullet"

    # Ορισμός εσοχής κουκκίδας.
    paragraph2.paragraph_format.indent = 25

    # Ορισμός χρώματος κουκκίδας.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Ορισμός ύψους κουκκίδας.
    paragraph2.paragraph_format.bullet.height = 100

    # Προσθήκη της παραγράφου στο πλαίσιο κειμένου.
    text_frame.paragraphs.add(paragraph2)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Εικόνων ως Κουκκίδες**

Οι λίστες με κουκκίδες βοηθούν στην οργάνωση και παρουσίαση πληροφοριών. Οι εικόνες ως κουκκίδες είναι εύκολες στην ανάγνωση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation].
1. Πρόσβαση στη στοχευμένη διαφάνεια κατά το ευρετήριο της.
1. Προσθέστε ένα [AutoShape] στη διαφάνεια.
1. Πρόσβαση στο [TextFrame] του σχήματος.
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame].
1. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph].
1. Φορτώστε μια εικόνα σε ένα [PPImage].
1. Ορίστε τον τύπο κουκκίδας σε [PPImage] και αντιστοιχίστε την εικόνα.
1. Ορίστε το κείμενο της παραγράφου.
1. Ορίστε την εσοχή της παραγράφου για την κουκκίδα.
1. Ορίστε το χρώμα της κουκκίδας.
1. Ορίστε το ύψος της κουκκίδας.
1. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του [TextFrame].
1. Προσθέστε μια δεύτερη παράγραφο και επαναλάβετε τα βήματα 8–12.
1. Αποθηκεύστε την παρουσία.

Αυτός ο κώδικας Python δείχνει πώς να προσθέσετε και να διαχειριστείτε εικόνες ως κουκκίδες:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Φόρτωση της εικόνας κουκκίδας.
    image = draw.Bitmap("bullets.png")
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

    # Ορισμός του τύπου κουκκίδας της παραγράφου σε Εικόνα και αντιστοίχιση της εικόνας.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Ορισμός του ύψους της κουκκίδας.
    paragraph.paragraph_format.bullet.height = 100

    # Προσθήκη της παραγράφου στο πλαίσιο κειμένου.
    text_frame.paragraphs.add(paragraph)

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Αποθήκευση της παρουσίασης ως αρχείο PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Διαχείριση Πολυεπίπεδων Κουκκίδων**

Οι λίστες με κουκκίδες βοηθούν στην οργάνωση και παρουσίαση πληροφοριών. Οι πολυεπίπεδες κουκκίδες είναι εύκολες στην ανάγνωση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation].
1. Πρόσβαση στη στοχευμένη διαφάνεια κατά το ευρετήριο της.
1. Προσθέστε ένα [AutoShape] στη διαφάνεια.
1. Πρόσβαση στο [AutoShape]’s [TextFrame].
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame].
1. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph] και ορίστε το βάθος της σε 0.
1. Δημιουργήστε τη δεύτερη παράγραφο χρησιμοποιώντας την κλάση [Paragraph] και ορίστε το βάθος της σε 1.
1. Δημιουργήστε την τρίτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph] και ορίστε το βάθος της σε 2.
1. Δημιουργήστε την τέταρτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph] και ορίστε το βάθος της σε 3.
1. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του [TextFrame].
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να προσθέσετε και να διαχειριστείτε πολυεπίπεδες κουκκίδες:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Δημιουργία στιγμιοτύπου παρουσίασης.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]
    
    # Προσθήκη AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Πρόσβαση στο TextFrame του δημιουργημένου AutoShape.
    text_frame = auto_shape.text_frame
    
    # Καθαρισμός της προεπιλεγμένης παραγράφου.
    text_frame.paragraphs.clear()

    # Προσθήκη της πρώτης παραγράφου.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορισμός επιπέδου κουκκίδας.
    paragraph1.paragraph_format.depth = 0

    # Προσθήκη της δεύτερης παραγράφου.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορισμός επιπέδου κουκκίδας.
    paragraph2.paragraph_format.depth = 1

    # Προσθήκη της τρίτης παραγράφου.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορισμός επιπέδου κουκκίδας.
    paragraph3.paragraph_format.depth = 2

    # Προσθήκη της τέταρτης παραγράφου.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ορισμός επιπέδου κουκκίδας.
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

Η κλάση [BulletFormat] παρέχει την ιδιότητα `numbered_bullet_start_with` (και άλλες) για τον έλεγχο προσαρμοσμένης αρίθμησης και μορφοποίησης παραγράφων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation].
1. Πρόσβαση στη διαφάνεια που θα περιέχει τις παραγράφους.
1. Προσθέστε ένα [AutoShape] στη διαφάνεια.
1. Πρόσβαση στο [TextFrame] του σχήματος.
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame].
1. Δημιουργήστε την πρώτη [Paragraph] και ορίστε `numbered_bullet_start_with` σε 2.
1. Δημιουργήστε τη δεύτερη [Paragraph] και ορίστε `numbered_bullet_start_with` σε 3.
1. Δημιουργήστε την τρίτη [Paragraph] και ορίστε `numbered_bullet_start_with` σε 7.
1. Προσθέστε τις παραγράφους στη συλλογή του [TextFrame].
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να προσθέσετε και να διαχειριστείτε παραγράφους με προσαρμοσμένη αρίθμηση και μορφοποίηση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Προσθήκη και πρόσβαση σε AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Πρόσβαση στο TextFrame του δημιουργημένου AutoShape.
    text_frame = shape.text_frame

    # Αφαίρεση της προεπιλεγμένης υπάρχουσας παραγράφου.
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

Χρησιμοποιήστε την ιδιότητα [ParagraphFormat.indent] για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η ιδιότητα μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Θετική τιμή μετατοπίζει τη πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε [ParagraphFormat.margin_left] όταν χρειάζεστε μετακίνηση ολόκληρης της παραγράφου. Χρησιμοποιήστε [ParagraphFormat.indent] όταν χρειάζεστε μόνο τη μετακίνηση της πρώτης γραμμής.

Το παρακάτω παράδειγμα δημιουργεί πολλές παραγράφους και εφαρμόζει διαφορετικές τιμές `indent` για να δείξει πώς η εσοχή πρώτης γραμμής επηρεάζει τη διάταξη.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation].
2. Πρόσβαση στη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape] στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame] στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε αρκετές παραγράφους και ορίστε διαφορετικές τιμές [indent] για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας δείχνει πώς να ορίσετε εσοχή παραγράφου:

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

Κρεματή εσοχή είναι μια διάταξη παραγράφου όπου η πρώτη γραμμή αρχίζει πιο αριστερά από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [ParagraphFormat.indent]. Ορίστε `indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat.margin_left] ορίζει τη θέση του αριστερού περιθωρίου του σώματος της παραγράφου, ενώ το [ParagraphFormat.indent] ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για κρεματή εσοχή, ορίστε μια θετική τιμή για `margin_left` και μια αρνητική τιμή για `indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, λήμματα γλωσσάριου και άλλες παραγράφους όπου οι γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου και όχι κάτω από τον πρώτο χαρακτήρα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation].
2. Πρόσβαση στη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape] στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame] στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [margin_left] για κάθε μία.
6. Ορίστε μια αρνητική τιμή [indent] για να δημιουργήσετε το εφέ κρεματής εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας δείχνει πώς να ορίσετε κρεματή εσοχή για μια παράγραφο:

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

## **Διαχείριση Μορφής Τέλους Ενότητας Παραγράφου**

Όταν χρειάζεται να ελέγξετε τη μορφοποίηση του «τέλους» μιας παραγράφου (η μορφοποίηση που εφαρμόζεται μετά την τελευταία ενότητα κειμένου), χρησιμοποιήστε την ιδιότητα `end_paragraph_portion_format`. Το παρακάτω παράδειγμα εφαρμόζει μια μεγαλύτερη γραμματοσειρά Times New Roman στο τέλος της δεύτερης παραγράφου.

1. Δημιουργήστε ή ανοίξτε ένα αρχείο [Presentation].
1. Λάβετε τη στοχευμένη διαφάνεια κατά το ευρετήριο.
1. Προσθέστε ένα ορθογώνιο [AutoShape] στη διαφάνεια.
1. Χρησιμοποιήστε το [TextFrame] του σχήματος και δημιουργήστε δύο παραγράφους.
1. Δημιουργήστε ένα [PortionFormat] ορισμένο σε 48 pt Times New Roman και εφαρμόστε το ως μορφή τέλους ενότητας παραγράφου.
1. Αντιστοιχίστε το στην ιδιότητα `end_paragraph_portion_format` της παραγράφου (εφαρμόζεται στο τέλος της δεύτερης παραγράφου).
1. Γράψτε την τροποποιημένη παρουσία ως αρχείο PPTX.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε τη μορφή τέλους παραγράφου για τη δεύτερη παράγραφο:

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

## **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για εισαγωγή HTML κειμένου σε παραγράφους.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation].
1. Πρόσβαση στη στοχευμένη διαφάνεια κατά το ευρετήριο.
1. Προσθέστε ένα [AutoShape] στη διαφάνεια.
1. Πρόσβαση στο [TextFrame] του [AutoShape].
1. Αφαιρέστε την προεπιλεγμένη παράγραφο από το [TextFrame].
1. Διαβάστε το πηγαίο αρχείο HTML.
1. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph].
1. Προσθέστε το περιεχόμενο HTML στη συλλογή παραγράφων του [TextFrame].
1. Αποθηκεύστε την τροποποιημένη παρουσία.

Ο παρακάτω κώδικας Python υλοποιεί αυτά τα βήματα για εισαγωγή HTML κειμένου σε παραγράφους.

```python
import aspose.slides as slides

# Δημιουργία κενής παρουσίασης.
with slides.Presentation() as presentation:

    # Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Προσθήκη AutoShape για τη φιλοξενία του περιεχομένου HTML.
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

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για εξαγωγή κειμένου σε HTML.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation] και φορτώστε την στοχευμένη παρουσία.
1. Πρόσβαση στη ζητούμενη διαφάνεια κατά το ευρετήριο.
1. Επιλέξτε το σχήμα που περιέχει το κείμενο προς εξαγωγή.
1. Πρόσβαση στο [TextFrame] του σχήματος.
1. Ανοίξτε ένα ροή αρχείου για να γράψετε την έξοδο HTML.
1. Καθορίστε το αρχικό ευρετήριο και εξάγετε τις απαιτούμενες παραγράφους.

Αυτό το παράδειγμα Python δείχνει πώς να εξάγετε το κείμενο παραγράφου σε HTML.

```python
import aspose.slides as slides

# Φόρτωση του αρχείου παρουσίασης.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης.
    slide = presentation.slides[0]

    # Δείκτης στόχου σχήματος.
    index = 0

    # Πρόσβαση στο σχήμα με βάση το δείκτη.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Εγγραφή δεδομένων παραγράφων σε HTML παρέχοντας το αρχικό δείκτη παραγράφου και το συνολικό αριθμό παραγράφων για εξαγωγή.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Αποθήκευση Παραγράφου ως Εικόνας**

Σε αυτό το τμήμα, θα εξετάσουμε δύο παραδείγματα που δείχνουν πώς να αποθηκεύσετε μια παράγραφο κειμένου, που αντιπροσωπεύεται από την κλάση [Paragraph], ως εικόνα. Και τα δύο παραδείγματα περιλαμβάνουν την λήψη της εικόνας ενός σχήματος που περιέχει την παράγραφο χρησιμοποιώντας τις μεθόδους `get_image` της κλάσης [Shape], τον υπολογισμό των ορίων της παραγράφου μέσα στο σχήμα, και την εξαγωγή της ως bitmap εικόνα. Αυτές οι προσεγγίσεις σας επιτρέπουν να εξάγετε συγκεκριμένα τμήματα κειμένου από παρουσιάσεις PowerPoint και να τα αποθηκεύετε ως ξεχωριστές εικόνες, χρήσιμες για περαιτέρω χρήση.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πεδίο κειμένου που περιέχει τρεις παραγράφους.

![Το πεδίο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

**Παράδειγμα 1**

Σε αυτό το παράδειγμα, λαμβάνουμε τη δεύτερη παράγραφο ως εικόνα. Για να το πετύχουμε, εξάγουμε την εικόνα του σχήματος από την πρώτη διαφάνεια της παρουσίασης και στη συνέχεια υπολογίζουμε τα όρια της δεύτερης παραγράφου στο πλαίσιο κειμένου του σχήματος. Η παράγραφος έπειτα επανασχεδιάζεται σε μια νέα bitmap εικόνα, η οποία αποθηκεύεται σε μορφή PNG. Αυτή η μέθοδος είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να αποθηκεύσετε μια συγκεκριμένη παράγραφο ως ξεχωριστή εικόνα διατηρώντας τις ακριβείς διαστάσεις και μορφοποίηση του κειμένου.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Αποθήκευση του σχήματος στη μνήμη ως bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Δημιουργία bitmap σχήματος από τη μνήμη.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Υπολογισμός των ορίων της δεύτερης παραγράφου.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Υπολογισμός των συντεταγμένων και του μεγέθους για την έξοδο εικόνας (ελάχιστο μέγεθος - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Κοπή του bitmap σχήματος για λήψη μόνο του bitmap της παραγράφου.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

**Παράδειγμα 2**

Σε αυτό το παράδειγμα, επεκτείνουμε την προηγούμενη προσέγγιση προσθέτοντας παράγοντες κλίμακας στην εικόνα της παραγράφου. Το σχήμα εξάγεται από την παρουσίαση και αποθηκεύεται ως εικόνα με παράγοντα κλίμακας `2`. Αυτό επιτρέπει υψηλότερη ανάλυση στην εξαγωγή της παραγράφου. Τα όρια της παραγράφου υπολογίζονται λαμβάνοντας υπόψη την κλίμακα. Η κλίμακα είναι ιδιαίτερα χρήσιμη όταν απαιτείται πιο λεπτομερής εικόνα, π.χ. για χρήση σε υψηλής ποιότητας έντυπο υλικό.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Αποθήκευση του σχήματος στη μνήμη ως bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Δημιουργία bitmap σχήματος από τη μνήμη.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Υπολογισμός των ορίων της δεύτερης παραγράφου.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Υπολογισμός των συντεταγμένων και του μεγέθους για την εικόνα εξόδου (ελάχιστο μέγεθος - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Κοπή του bitmap σχήματος για λήψη μόνο του bitmap της παραγράφου.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **Συχνές Ερωτήσεις (FAQ)**

**Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Χρησιμοποιήστε τη ρύθμιση αναδίπλωσης του πλαισίου κειμένου ([wrap_text]) για να απενεργοποιήσετε την αναδίπλωση, ώστε οι γραμμές να μην σπάνε στις άκρες του πλαισίου.

**Πώς μπορώ να λάβω τα ακριβή όρια στην διαφάνεια ενός συγκεκριμένου παραγράφου;**

Μπορείτε να ανακτήσετε το ορθογώνιο περιγράμματα της παραγράφου (και ακόμη και μιας μεμονωμένης ενότητας) για να γνωρίζετε τη συγκεκριμένη θέση και το μέγεθός της στη διαφάνεια.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά/δεξιά/κέντρο/πλήρης στοίχιση);**

Το [Alignment] είναι ρύθμιση σε επίπεδο παραγράφου στο [ParagraphFormat]· εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των μεμονωμένων ενοτήτων.

**Μπορώ να ορίσω γλώσσα ελέγχου ορθογραφίας μόνο για μέρος μιας παραγράφου (π.χ. μία λέξη);**

Ναι. Η γλώσσα ορίζεται σε επίπεδο ενότητας ([PortionFormat.language_id]), επομένως μπορούν να συνυπάρχουν πολλαπλές γλώσσες μέσα στην ίδια παράγραφο.