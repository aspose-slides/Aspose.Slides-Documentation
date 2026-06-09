---
title: Διαχείριση Σειρών και Στηλών σε Πίνακες PowerPoint με Python
linktitle: Σειρές και Στήλες
type: docs
weight: 20
url: /el/python-net/manage-rows-and-columns/
keywords:
- σειρά πίνακα
- στήλη πίνακα
- πρώτη σειρά
- κεφαλίδα πίνακα
- κλωνοποίηση σειράς
- κλωνοποίηση στήλης
- αντιγραφή σειράς
- αντιγραφή στήλης
- αφαίρεση σειράς
- αφαίρεση στήλης
- μορφοποίηση κειμένου σειράς
- μορφοποίηση κειμένου στήλης
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τις σειρές και τις στήλες των πινάκων σε PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET και επιταχύνετε την επεξεργασία παρουσιάσεων και την ενημέρωση δεδομένων."
---
## **Overview**

Αυτό το άρθρο δείχνει πώς να διαχειριστείτε τις σειρές και τις στήλες πίνακα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python. Θα μάθετε πώς να προσθέτετε, να εισάγετε, να κλωνοποιείτε και να διαγράφετε σειρές ή στήλες, να σημειώνετε την πρώτη σειρά ως κεφαλίδα, να προσαρμόζετε το μέγεθος και τη διάταξη, και να εφαρμόζετε μορφοποίηση κειμένου και στυλ σε επίπεδο σειράς ή στήλης. Κάθε εργασία παρουσιάζεται με συμπαγή, αυτόνομα αποσπάσματα κώδικα βασισμένα στο API του [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) , ώστε να μπορείτε γρήγορα να εντοπίσετε έναν πίνακα σε μια διαφάνεια και να αναδιαμορφώσετε τη δομή του ώστε να ταιριάζει στο σχέδιό σας.

## **Set the First Row as a Header**

Σημειώστε την πρώτη σειρά του πίνακα ως κεφαλίδα για να διακρίνετε σαφώς τους τίτλους των στηλών από τα δεδομένα. Στο Aspose.Slides για Python, απλώς ενεργοποιήστε την επιλογή *First Row* του πίνακα για να εφαρμόσετε τη μορφοποίηση κεφαλίδας που ορίζεται από το επιλεγμένο στυλ πίνακα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
1. Πρόσβαση στη διαφάνεια με βάση το δείκτη της.
1. Διασχίστε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) για να βρείτε τον σχετικό πίνακα.
1. Ορίστε την πρώτη σειρά του πίνακα ως κεφαλίδα.

```python
import aspose.slides as slides

# Δημιουργία αντικειμένου της κλάσης Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Διαπέραση των σχημάτων και λήψη αναφοράς στον πίνακα.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Ορισμός της πρώτης σειράς του πίνακα ως κεφαλίδα.
    table.first_row = True
    
    # Αποθήκευση της παρουσίασης σε δίσκο.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone a Table Row or Column**

Κλωνοποιήστε οποιαδήποτε σειρά ή στήλη πίνακα και εισάγετε το αντίγραφο στη ζητούμενη θέση μέσα στον πίνακα. Το αντίγραφο διατηρεί το περιεχόμενο των κελιών, τη μορφοποίηση και τα μεγέθη, ώστε να μπορείτε να επεκτείνετε τις διατάξεις γρήγορα και σταθερά.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
1. Πρόσβαση στη διαφάνεια με βάση το δείκτη της.
1. Ορίστε έναν πίνακα με πλάτη στηλών.
1. Ορίστε έναν πίνακα με ύψη σειρών.
1. Προσθέστε έναν [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) στη διαφάνεια χρησιμοποιώντας `add_table(x, y, column_widths, row_heights)`.
1. Κλωνοποιήστε μια σειρά πίνακα.
1. Κλωνοποιήστε μια στήλη πίνακα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
 import aspose.slides as slides

# Δημιουργία αντικειμένου της κλάσης Presentation.
with slides.Presentation() as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Ορισμός πλάτους στηλών και ύψους σειρών.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Προσθήκη πίνακα στη διαφάνεια.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Προσθήκη κειμένου στη σειρά 1, στήλη 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Προσθήκη κειμένου στη σειρά 2, στήλη 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Κλωνοποίηση της σειράς 1 στο τέλος του πίνακα.
    table.rows.add_clone(table.rows[0], False)

    # Προσθήκη κειμένου στη σειρά 1, στήλη 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Προσθήκη κειμένου στη σειρά 2, στήλη 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Κλωνοποίηση της σειράς 2 ως 4η σειρά του πίνακα.
    table.rows.insert_clone(3,table.rows[1], False)

    # Αντιγραφή της πρώτης στήλης στο τέλος.
    table.columns.add_clone(table.columns[0], False)

    # Κλωνοποίηση της δεύτερης στήλης στο δείκτη 3 (τη 4η θέση).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Αποθήκευση της παρουσίασης σε δίσκο.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove a Row or Column from a Table**

Απλοποιήστε έναν πίνακα αφαιρώντας οποιαδήποτε σειρά ή στήλη με βάση το δείκτη χρησιμοποιώντας το Aspose.Slides για Python — η διάταξη προσαρμόζεται αυτόματα διατηρώντας τη μορφοποίηση των υπολοίπων κελιών. Αυτό είναι χρήσιμο για την απλοποίηση πλέγματων δεδομένων ή τη διαγραφή θέσεων κράτησης χωρίς την ανακατασκευή του πίνακα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
1. Πρόσβαση στη διαφάνεια με βάση το δείκτη της.
1. Ορίστε έναν πίνακα με πλάτη στηλών.
1. Ορίστε έναν πίνακα με ύψη σειρών.
1. Προσθέστε ένα ITable στη διαφάνεια χρησιμοποιώντας `add_table(x, y, column_widths, row_heights)`.
1. Αφαιρέστε τη σειρά του πίνακα.
1. Αφαιρέστε τη στήλη του πίνακα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting at the Table Row Level**

Εφαρμόστε συνεπή στυλ κειμένου σε ολόκληρη τη σειρά του πίνακα με ένα βήμα. Με το Aspose.Slides για Python, μπορείτε να ορίσετε την οικογένεια γραμματοσειράς, το μέγεθος, το βάρος, το χρώμα και την στοίχιση για όλα τα κελιά της σειράς μονομιάς, ώστε να διατηρείτε τις επικεφαλίδες ή τις λωρίδες δεδομένων ομοιόμορφες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
1. Πρόσβαση στη διαφάνεια με βάση το δείκτη της.
1. Πρόσβαση στο σχετικό αντικείμενο [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) στη διαφάνεια.
1. Ορίστε το ύψος γραμματοσειράς για τα κελιά της πρώτης σειράς.
1. Ορίστε τη στοίχιση και το δεξί περιθώριο για τα κελιά της πρώτης σειράς.
1. Ορίστε τον κάθετο τύπο κειμένου για τα κελιά της δεύτερης σειράς.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import aspose.slides as slides

# Δημιουργία αντικειμένου της κλάσης Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Ορισμός ύψους γραμματοσειράς για τα κελιά της πρώτης σειράς.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Ορισμός στοίχισης κειμένου και δεξίου περιθωρίου για τα κελιά της πρώτης σειράς.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Ορισμός κάθετου τύπου κειμένου για τα κελιά της δεύτερης σειράς.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Αποθήκευση της παρουσίασης σε δίσκο.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting at the Table Column Level**

Εφαρμόστε συνεπή στυλ κειμένου σε ολόκληρη τη στήλη του πίνακα μονομιάς. Με το Aspose.Slides για Python, μπορείτε να ορίσετε την οικογένεια γραμματοσειράς, το μέγεθος, το βάρος, το χρώμα και την στοίχιση για όλα τα κελιά μιας στήλης, ώστε να δημιουργήσετε ομοιόμορφες κάθετες λωρίδες για επικεφαλίδες ή δεδομένα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και φορτώστε την παρουσίαση.
1. Πρόσβαση στη διαφάνεια με βάση το δείκτη της.
1. Πρόσβαση στο σχετικό αντικείμενο [Table](https://reference.aspose.com/slides/el/python-net/aspose.slides/table/) στη διαφάνεια.
1. Ορίστε το ύψος γραμματοσειράς για τα κελιά της πρώτης στήλης.
1. Ορίστε τη στοίχιση και το δεξί περιθώριο για τα κελιά της πρώτης στήλης.
1. Ορίστε τον κάθετο τύπο κειμένου για τα κελιά της δεύτερης στήλης.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import aspose.slides as slides

# Δημιουργία αντικειμένου της κλάσης Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Ορισμός ύψους γραμματοσειράς για τα κελιά της πρώτης στήλης.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Ορισμός στοίχισης κειμένου και δεξιού περιθωρίου για τα κελιά της πρώτης στήλης.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Ορισμός κάθετου τύπου κειμένου για τα κελιά της δεύτερης στήλης.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Αποθήκευση της παρουσίασης σε δίσκο.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Get Table Style Properties**

Το Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ ενός πίνακα ώστε να τις χρησιμοποιήσετε ξανά για άλλο πίνακα ή αλλού. Ο παρακάτω κώδικας Python δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προκαθορισμένο στυλ πίνακα:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that’s already created?**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/κύριου, και μπορείτε ακόμη να αντικαταστήσετε τα γέμισμα, τα πλαίσια και τα χρώματα κειμένου πάνω από αυτό το θέμα.

**Can I sort table rows like in Excel?**

Όχι, οι πίνακες του Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε πρώτα τα δεδομένα στη μνήμη και, στη συνέχεια, επανασυμπληρώστε τις σειρές του πίνακα με αυτή τη σειρά.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

Ναι. Ενεργοποιήστε τις λωρίδες στις στήλες, στη συνέχεια αντικαταστήστε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση σε επίπεδο κελιού έχει προτεραιότητα πάνω από το στυλ του πίνακα.