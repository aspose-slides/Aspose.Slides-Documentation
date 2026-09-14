---
title: Διαχείριση Γραμματοσειρών σε Παρουσιάσεις Χρησιμοποιώντας Python μέσω Java
linktitle: Διαχείριση Γραμματοσειρών
type: docs
weight: 10
url: /el/python-java/manage-fonts/
keywords:
- διαχείριση γραμματοσειρών
- ιδιότητες γραμματοσειράς
- παράγραφος
- μορφοποίηση κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Έλεγχος γραμματοσειρών σε Python μέσω Java με Aspose.Slides: ενσωμάτωση, αντικατάσταση και φόρτωση προσαρμοσμένων γραμματοσειρών για να διασφαλιστεί ότι οι παρουσιάσεις PPT, PPTX και ODP παραμένουν καθαρές, ασφαλείς για την επωνυμία και συνεπείς."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε τις ιδιότητες γραμματοσειράς στο κείμενο μιας παρουσίασης απευθείας από τον κώδικά σας. Μπορείτε να έχετε πρόσβαση στο κείμενο των διαφανειών μέσω σχημάτων, πλαισίων κειμένου, παραγράφων και τμημάτων, και στη συνέχεια να εφαρμόσετε μορφοποίηση στο επιλεγμένο κείμενο.

Αυτό το άρθρο εξηγεί πώς να διαμορφώσετε τις ιδιότητες γραμματοσειράς για υπάρχον κείμενο σε μια παρουσίαση, συμπεριλαμβανομένων της οικογένειας γραμματοσειράς, των εντονα (bold) και πλάγια (italic) στυλ, της στοίχισης παραγράφου και του χρώματος γραμματοσειράς. Επίσης δείχνει πώς να δημιουργήσετε ένα πλαίσιο κειμένου, να προσθέσετε κείμενο σε αυτό και να ορίσετε ιδιότητες γραμματοσειράς όπως οικογένεια γραμματοσειράς, έντονη, πλάγια, υπογράμμιση, μέγεθος γραμματοσειράς και χρώμα, πριν αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX.

## **Διαχείριση Ιδιοτήτων Σχετικών με τη Γραμματοσειρά**
{{% alert color="info" title="Σημείωση" %}} 

Οι παρουσιάσεις συνήθως περιέχουν τόσο κείμενο όσο και εικόνες. Το κείμενο μπορεί να μορφοποιηθεί με διάφορους τρόπους, είτε για να τονίσει συγκεκριμένα τμήματα και λέξεις είτε για να συμμορφωθεί με εταιρικά στυλ. Η μορφοποίηση του κειμένου βοηθά τους χρήστες να διαφοροποιούν την εμφάνιση και την αίσθηση του περιεχομένου της παρουσίασης. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides for Python via Java για να διαμορφώσετε τις ιδιότητες γραμματοσειράς των παραγράφων κειμένου στις διαφάνειες.
{{% /alert %}} 

Για τη διαχείριση των ιδιοτήτων γραμματοσειράς μιας παραγράφου χρησιμοποιώντας το Aspose.Slides for Python via Java:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Αποκτήστε αναφορά σε μια διαφάνεια χρησιμοποιώντας το δείκτη της.
1. Προβάλετε τα σχήματα [Placeholder](https://reference.aspose.com/slides/el/python-java/aspose.slides/placeholder/) στη διαφάνεια ως [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/).
1. Αποκτήστε το [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/) από το [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) που εκτίθεται από το [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/).
1. Στοιχίστε την παράγραφο.
1. Προβάλετε το κείμενο [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) μιας [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/).
1. Ορίστε τη γραμματοσειρά χρησιμοποιώντας το [FontData](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontdata/) και ορίστε το **Font** του κειμένου [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) αναλόγως.
   1. Ορίστε τη γραμματοσειρά σε έντονη.
   1. Ορίστε τη γραμματοσειρά σε πλάγια.
1. Ορίστε το χρώμα γραμματοσειράς χρησιμοποιώντας το [FillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/) που εκτίθεται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω. Παίρνει μια ανεπεξέργαστη παρουσίαση και μορφοποιεί τις γραμματοσειρές σε μία από τις διαφάνειες. Τα παρακάτω στιγμιότυπα οθόνης δείχνουν το αρχείο εισόδου και πώς τα αποσπάσματα κώδικα το τροποποιούν. Ο κώδικας αλλάζει τη γραμματοσειρά, το χρώμα και το στυλ της γραμματοσειράς.

|![Κείμενο στην αρχική παρουσίαση](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Σχήμα: Το κείμενο στο αρχικό αρχείο**|

|![Κείμενο με ενημερωμένη μορφοποίηση γραμματοσειράς](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Σχήμα: Το ίδιο κείμενο με ενημερωμένη μορφοποίηση**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Φόρτωση της παρουσίασης.
presentation = Presentation("FontProperties.pptx")
try:
    # Πρόσβαση στην πρώτη διαφάνεια και στα πλαίσια κειμένου των πρώτων δύο placeholders.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Πρόσβαση στην πρώτη παράγραφο σε κάθε πλαίσιο κειμένου.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Πρόσβαση στο πρώτο τμήμα σε κάθε παράγραφο.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Ορισμός και ανάθεση νέων γραμματοσειρών.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Ορισμός των γραμματοσειρών σε έντονη και πλάγια.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Ορισμός των χρωμάτων γραμματοσειράς.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Αποθήκευση της παρουσίασης.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Ιδιοτήτων Γραμματοσειράς Κειμένου**
{{% alert color="info" title="Σημείωση" %}} 

Όπως αναφέρεται στην **Διαχείριση Ιδιοτήτων Σχετικών με τη Γραμματοσειρά**, ένα [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) χρησιμοποιείται για να συγκρατεί κείμενο με παρόμοιο στυλ μορφοποίησης σε μια παράγραφο. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides for Python via Java για να δημιουργήσετε ένα πλαίσιο κειμένου με κάποιο κείμενο και, στη συνέχεια, να ορίσετε μια συγκεκριμένη γραμματοσειρά και διάφορες άλλες ιδιότητες γραμματοσειράς.
{{% /alert %}} 

Για να δημιουργήσετε ένα πλαίσιο κειμένου και να ορίσετε τις ιδιότητες γραμματοσειράς του κειμένου σε αυτό:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/) τύπου **Rectangle** στη διαφάνεια.
1. Αφαιρέστε το στυλ γεμίσματος που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/).
1. Προβάλετε το [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) του [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/).
1. Προσθέστε κάποιο κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/).
1. Προβάλετε το αντικείμενο [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/) που σχετίζεται με το [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/).
1. Ορίστε τη γραμματοσειρά που θα χρησιμοποιηθεί για το [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/).
1. Ορίστε άλλες ιδιότητες γραμματοσειράς όπως έντονη, πλάγια, υπογράμμιση, χρώμα και ύψος χρησιμοποιώντας τις σχετικές ιδιότητες που εκτίθενται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/portion/).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω.

|![Κείμενο με εφαρμοσμένα χαρακτηριστικά γραμματοσειράς](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Σχήμα: Κείμενο με ορισμένες ιδιότητες γραμματοσειράς που έχουν οριστεί από το Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Λάβετε την πρώτη διαφάνεια και προσθέστε ένα ορθογώνιο.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Αφαιρέστε τη γέμιση του σχήματος.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Προσθέστε κείμενο στο πλαίσιο κειμένου του σχήματος.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Ορίστε την οικογένεια γραμματοσειράς.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Ορίστε έντονη, πλάγια, υπογράμμιση και μέγεθος γραμματοσειράς.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Ορίστε το χρώμα της γραμματοσειράς.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Αποθηκεύστε την παρουσίαση.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```