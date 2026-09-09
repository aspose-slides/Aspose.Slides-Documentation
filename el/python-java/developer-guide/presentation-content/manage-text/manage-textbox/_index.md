---
title: "Διαχείριση πλαισίων κειμένου σε παρουσιάσεις με Python μέσω Java"
linktitle: "Διαχείριση πλαισίου κειμένου"
type: docs
weight: 20
url: /el/python-java/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσύνδεσμου
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργία, αναγνώριση, μορφοποίηση και ενημέρωση πλαισίων κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για Python μέσω Java."
---
## **Εισαγωγή**

Στο Aspose.Slides για Python μέσω Java, το κείμενο των διαφανειών αποθηκεύεται σε πλαίσια κειμένου που ανήκουν σε σχήματα. Η κλάση [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) αντιπροσωπεύει το πιο κοινό σχήμα που φέρει κείμενο και εκθέτει το κείμενό του μέσω της μεθόδου [AutoShape.getTextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Κάθε αυτόματο σχήμα κληρονομεί από το [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/), αλλά δεν είναι κάθε σχήμα αυτόματο σχήμα ή υποστηρίζει πλαίσιο κειμένου. Όταν επεξεργάζεστε μια υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι ένα στιγμιότυπο του [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) πριν προσπελάσετε το κείμενό του.

{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε μια διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου, προσθέστε ένα αυτόματο σχήμα σε μια διαφάνεια, προσθέστε κείμενο στο πλαίσιο κειμένου του και αποθηκεύστε την παρουσίαση. Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο πλαίσιο κειμένου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Οι συντεταγμένες και οι διαστάσεις που περνιούνται στη μέθοδο [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addAutoShape) μετρώνται σε σημεία. Η μέθοδος [AutoShape.addTextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#addTextFrame) αρχικοποιεί το πλαίσιο κειμένου με το παρεχόμενο κείμενο.

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Χρησιμοποιήστε τη μέθοδο [AutoShape.isTextBox](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#isTextBox) για να προσδιορίσετε εάν ένα αυτόματο σχήμα αντιμετωπίζεται ως πλαίσιο κειμένου. Αυτό είναι χρήσιμο όταν μια παρουσίαση περιέχει τόσο σχήματα που φέρουν κείμενο όσο και καθαρά γραφικά αυτόματα σχήματα.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Το παρακάτω παράδειγμα εξετάζει κάθε αυτόματο σχήμα σε μια παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Ένα νεοπροστιθέμενο αυτόματο σχήμα δεν θεωρείται πλαίσιο κειμένου μέχρι να περιέχει μη κενό κείμενο. Μπορείτε να δώσετε αυτό το κείμενο μέσω [AutoShape.addTextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#addTextFrame) ή [TextFrame.setText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#setText). Η προσθήκη ή ανάθεση μιας κενής συμβολοσειράς αφήνει τη μέθοδο [AutoShape.isTextBox](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/#isTextBox) να επιστρέφει `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Οι δύο πρώτες κλήσεις εκτυπώνουν `True`; οι δύο τελευταίες εκτυπώνουν `False`.

## **Εύρεση του σχήματος που κατέχει ένα πλαίσιο κειμένου**

Ο γενικός κώδικας επεξεργασίας κειμένου μπορεί να λάβει ένα [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) χωρίς να γνωρίζει ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε τη μόνο-ανάγνωση μέθοδο [TextFrame.getParentShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentShape) για να πλοηγηθείτε πίσω στο κυρίαρχο του [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/).

Για ένα πλαίσιο κειμένου που ανήκει σε αυτόματο σχήμα ή σε άλλο σχήμα που φέρει κείμενο, η μέθοδος [TextFrame.getParentShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentShape) επιστρέφει τον κάτοχο και η μέθοδος [TextFrame.getParentCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getParentCell) επιστρέφει `None`. Ελέγξτε την επιστρεφόμενη τιμή πριν την προσπελάσετε. Για να αναγνωρίσετε τόσο τους κατόχους σχήματος όσο και των κελιών πίνακα, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/python-java/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Η μέθοδος [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setColumnCount) διαιρεί το πλαίσιο κειμένου σε στήλες, ενώ η μέθοδος [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setColumnSpacing) ορίζει το κενό μεταξύ των στηλών σε σημεία. Και οι δύο ρυθμίσεις ανήκουν στο [TextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/) και μπορούν να μεταβληθούν μέσω του πλαισίου κειμένου ενός υπάρχοντος πλαισίου κειμένου. Το κείμενο αναδιατάσσεται μεταξύ των στηλών μέσα στο ίδιο σχήμα· δεν συνεχίζεται σε διαφορετικό σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο κειμένου τριών στηλών με 10 σημεία μεταξύ των στηλών, αποθηκεύει την παρουσίαση και διαβάζει τις αποθηκευμένες ρυθμίσεις από το αρχείο εξόδου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Ανάκτηση κειμένου από επιμέρους στήλες**

Χρησιμοποιήστε τη μέθοδο [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#splitTextByColumns) για να λάβετε το κείμενο που έχει αντιστοιχιστεί σε κάθε οπτική στήλη ενός υπάρχοντος πλαισίου κειμένου. Η μέθοδος επιστρέφει μία συμβολοσειρά για κάθε στήλη, με σειρά ανάγνωσης βάσει στήλης. Ένα πλαίσιο κειμένου μονής στήλης παράγει έναν πίνακα με ένα στοιχείο, ενώ μια κενή στήλη αντιπροσωπεύεται από μια κενή συμβολοσειρά. Οι συμβολοσειρές περιέχουν μόνο απλό κείμενο· η μορφοποίηση επιπέδου τμήματος δεν διατηρείται.

Αυτό είναι χρήσιμο όταν χρειάζεται:

- Να εξαγάγετε κείμενο διατηρώντας τη σειρά ανάγνωσης βάσει στήλης.
- Να δημιουργήσετε ευρετήριο ή να συγκρίνετε το περιεχόμενο διαφανειών πολλαπλών στηλών.
- Να εξάγετε κάθε στήλη σε ξεχωριστό αρχείο, πεδίο βάσης δεδομένων ή άλλο προορισμό.
- Να ελέγξετε πώς το κείμενο ανακατανέμεται μετά την αλλαγή του αριθμού στηλών με τη μέθοδο [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setColumnCount), του διαστήματος με τη μέθοδο [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setColumnSpacing), της γραμματοσειράς ή του μεγέθους του πλαισίου κειμένου.

Η μέθοδος αναφέρει το κείμενο που διανέμεται εντός του τρέχοντος [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/); δεν ροπίζει αυτόματα κείμενο μεταξύ ξεχωριστών σχημάτων ή πλαισίων κειμένου. Η κατανομή των στηλών μπορεί να εξαρτάται από τις διαθέσιμες γραμματοσειρές και άλλες ρυθμίσεις διάταξης κειμένου, οπότε βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες όταν η συνέπεια των αποτελεσμάτων είναι σημαντική.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, βρίσκει το πρώτο αυτόματο σχήμα πολλαπλών στηλών με πλαίσιο κειμένου, διαβάζει τον διαμορφωμένο αριθμό στηλών και γράφει το κείμενο από κάθε στήλη σε ξεχωριστό αρχείο. Τα σχήματα που δεν παρέχουν πλαίσιο κειμένου παραλείπονται.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Ενημέρωση κειμένου**

Για να ενημερώσετε το κείμενο σε όλη την παρουσίαση, διατρέξτε τις διαφάνειες και τα σχήματα, επιλέξτε τα αυτόματα σχήματα και, στη συνέχεια, επεξεργαστείτε τα τμήματα κειμένου τους. Η εργασία σε επίπεδο τμήματος σάς επιτρέπει να αλλάξετε τόσο το κείμενο όσο και τη μορφοποίηση χαρακτήρων.

Το παρακάτω παράδειγμα αντικαθιστά κάθε εμφάνιση του `years` με το `months` σε κείμενο αυτόματου σχήματος και κάνει κάθε επηρεασμένο τμήμα έντονο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αυτή η σάρωση ενημερώνει το κείμενο μόνο σε αυτόματα σχήματα. Το κείμενο που αποθηκεύεται σε πίνακες, γραφήματα, SmartArt ή ομαδοποιημένα σχήματα απαιτεί σάρωση των συλλογών των αντίστοιχων αντικειμένων.

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο**

Ένας υπερσύνδεσμος μπορεί να ανατεθεί σε συγκεκριμένο τμήμα κειμένου, ώστε μόνο αυτό το κείμενο να λειτουργεί ως κλικαρίσιμος σύνδεσμος. Χρησιμοποιήστε τη μέθοδο [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) για να συσχετίσετε το τμήμα με ένα εξωτερικό URL.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με σύνδεσμο και το αποθηκεύει σε μια παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου κειμένου και ενός σύμβολου κράτησης θέσης κειμένου σε κύρια ή διαφάνεια διάταξης;**

Ένα [placeholder](/slides/el/python-java/manage-placeholder/) μπορεί να κληρονομήσει τη θέση και τη μορφοποίηση του από μια [master slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslide/) ή [layout slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/layoutslide/). Ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο σχήμα στη διαφάνεια όπου δημιουργήθηκε και δεν αποκτά τη συμπεριφορά του σύμβολου κράτησης θέσης όταν η διάταξη αλλάζει.

**Πώς μπορώ να αντικαταστήσω κείμενο χωρίς να αλλάξω το κείμενο σε γραφήματα, πίνακες ή SmartArt;**

Περιορίστε τη σάρωση σε σχήματα που είναι στιγμιότυπα του [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/), όπως φαίνεται στο παράδειγμα Ενημέρωσης Κειμένου. Τα γραφήματα, οι πίνακες και το SmartArt αποθηκεύουν κείμενο στα δικά τους μοντέλα αντικειμένων, επομένως δεν τροποποιούνται από αυτόν τον βρόχο.