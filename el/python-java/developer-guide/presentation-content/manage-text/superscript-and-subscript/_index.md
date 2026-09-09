---
title: Διαχείριση Εκθέτη και Υποεκθέτη σε Παρουσιάσεις χρησιμοποιώντας Python μέσω Java
linktitle: Εκθέτης και Υποεκθέτης
type: docs
weight: 80
url: /el/python-java/superscript-and-subscript/
keywords:
- εκθέτης
- υποεκθέτης
- πρόσθηκη εκθέτη
- πρόσθηκη υποεκθέτη
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Κατακτήστε τον εκθέτη και τον υποεκθέτη στο Aspose.Slides για Python μέσω Java και αναβαθμίστε τις παρουσιάσεις σας με επαγγελματική μορφοποίηση κειμένου για μέγιστο αντίκτυπο."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει δυνατότητες ενσωμάτωσης κειμένου εκθέτη και υποεκθέτη στις παρουσιάσεις PowerPoint (PPT, PPTX) και OpenDocument (ODP). Είτε χρειάζεστε να επισημάνετε χημικούς τύπους, μαθηματικές εξισώσεις ή να προσθέσετε υποσημειώσεις, αυτές οι εξειδικευμένες επιλογές μορφοποίησης βοηθούν στη διατήρηση της σαφήνειας και της ακρίβειας. Σε αυτό το άρθρο, θα μάθετε πώς να εφαρμόζετε αβίαστα στυλ εκθέτη και υποεκθέτη και να εξασφαλίζετε επαγγελματικά αποτελέσματα σε κάθε διαφάνεια.

## **Διαχείριση Κειμένου Εκθέτη και Υποεκθέτη**

Μπορείτε να προσθέσετε κείμενο εκθέτη και υποεκθέτη σε οποιοδήποτε τμήμα μιας παραγράφου. Για να εφαρμόσετε αυτή τη μορφοποίηση σε ένα πλαίσιο κειμένου Aspose.Slides, χρησιμοποιήστε τη μέθοδο [setEscapement](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#setEscapement) της κλάσης [PortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/).

Η τιμή escapement κυμαίνεται από -100% (υποεκθέτη) έως 100% (εκθέτης). Για παράδειγμα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Αποκτήστε μια διαφάνεια με βάση τον δείκτη της.
- Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) τύπου [ShapeType.Rectangle](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapetype/#Rectangle) στη διαφάνεια.
- Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) που συνδέεται με το [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/).
- Καθάριστε τις υπάρχουσες παραγράφους.
- Δημιουργήστε μια παράγραφο που θα περιέχει κείμενο εκθέτη και προσθέστε την στη [συλλογή παραγράφων](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParagraphs) του πλαισίου κειμένου.
- Δημιουργήστε ένα τμήμα.
- Χρησιμοποιήστε τη [setEscapement](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#setEscapement) για να ορίσετε μια τιμή από 0 έως 100 για εκθέτη (0 σημαίνει χωρίς εκθέτη).
- Ορίστε το κείμενο του [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) και προσθέστε το στη συλλογή τμημάτων της παραγράφου.
- Δημιουργήστε μια παράγραφο που θα περιέχει κείμενο υποεκθέτη και προσθέστε την στη [συλλογή παραγράφων](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParagraphs) του πλαισίου κειμένου.
- Δημιουργήστε ένα τμήμα.
- Χρησιμοποιήστε τη [setEscapement](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#setEscapement) για να ορίσετε μια τιμή από -100 έως 0 για υποεκθέτη (0 σημαίνει χωρίς υποεκθέτη).
- Ορίστε το κείμενο του [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) και προσθέστε το στη συλλογή τμημάτων της παραγράφου.
- Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα υλοποιεί αυτά τα βήματα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Δημιουργία παρουσίασης.
presentation = Presentation()
try:
    # Ανάκτηση διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Δημιουργία πλαισίου κειμένου.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Δημιουργία παραγράφου για κείμενο εκθέτη.
    superscript_paragraph = Paragraph()

    # Δημιουργία τμήματος με κανονικό κείμενο.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Δημιουργία τμήματος με κείμενο εκθέτη.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Δημιουργία παραγράφου για κείμενο υποεκθέτη.
    subscript_paragraph = Paragraph()

    # Δημιουργία τμήματος με κανονικό κείμενο.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Δημιουργία τμήματος με κείμενο υποεκθέτη.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Προσθήκη των παραγράφων στο πλαίσιο κειμένου.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Θα διατηρηθούν τα εκθέτη και υποεκθέτη κατά την εξαγωγή σε PDF ή άλλες μορφές;**

Ναι, το Aspose.Slides διατηρεί σωστά τη μορφοποίηση εκθέτη και υποεκθέτη κατά την εξαγωγή των παρουσιάσεων σε PDF, PPT/PPTX, εικόνες και άλλες υποστηριζόμενες μορφές. Η εξειδικευμένη μορφοποίηση παραμένει αμετάβλητη σε όλα τα αρχεία εξόδου.

**Μπορούν τα εκθέτη και υποεκθέτη να συνδυαστούν με άλλα στυλ μορφοποίησης όπως έντονη ή πλάγια γραφή;**

Ναι, το Aspose.Slides επιτρέπει το συνδυασμό διαφόρων στυλ κειμένου μέσα σε ένα μόνο τμήμα κειμένου. Μπορείτε να ενεργοποιήσετε έντονη, πλάγια, υπογράμμιση και ταυτόχρονα να εφαρμόσετε εκθέτη ή υποεκθέτη ρυθμίζοντας τις αντίστοιχες ιδιότητες στην [PortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/).

**Λειτουργεί η μορφοποίηση εκθέτη και υποεκθέτη για κείμενο μέσα σε πίνακες, διαγράμματα ή SmartArt;**

Ναι, το Aspose.Slides υποστηρίζει τη μορφοποίηση στα περισσότερα αντικείμενα, συμπεριλαμβανομένων πινάκων και στοιχείων διαγραμμάτων. Όταν εργάζεστε με SmartArt, πρέπει να προσπελάσετε τα κατάλληλα στοιχεία (όπως το [SmartArtNode](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartnode/)) και τα περιέκτητά τους κειμένου, και στη συνέχεια να ρυθμίσετε τις ιδιότητες της [PortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/) με παρόμοιο τρόπο.