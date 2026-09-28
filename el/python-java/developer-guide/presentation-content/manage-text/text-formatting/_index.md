---
title: Διαμόρφωση Κειμένου Παρουσίασης σε Python μέσω Java
linktitle: Μορφοποίηση Κειμένου
type: docs
weight: 50
url: /el/python-java/text-formatting/
keywords:
- ευθυγράμμιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμής
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- καρτέλες κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαμορφώστε και εφαρμόστε στυλ σε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Προσαρμόστε γραμματοσειρές, χρώματα, ευθυγράμμιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Καλύπτει τα χρώματα φόντου, τη διαφάνεια, το διάστημα χαρακτήρων, τις ιδιότητες της γραμματοσειράς, την περιστροφή, το διάστημα παραγράφων, τη συμπεριφορά αυτόματης προσαρμογής, την αγκύρωση κειμένου, τις θέσεις διαστημάτων (tab stops) και τις ρυθμίσεις γλώσσας.

Εκτός εάν αναφέρεται διαφορετικά, τα παραδείγματα χρησιμοποιούν το [sample.pptx](sample.pptx). Το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα πλαίσιο κειμένου, και η πρώτη παράγραφος του περιέχει το κείμενο που φαίνεται παρακάτω. Οι δείκτες των διαφανειών και των σχημάτων είναι μηδενική βάση. Τα παραδείγματα που επιλέγουν έντονες περιοχές χρησιμοποιούν αποτελεσματική μορφοποίηση, συμπεριλαμβανομένης της κληρονομημένης έντονης μορφοποίησης:

![Δείγμα κειμένου](sample_text.png)

Για να βρείτε και να επισημάνετε κυριολεκτικό κείμενο ή αντιστοιχίες κανονικής έκφρασης, δείτε [Search and Replace Text](/slides/el/python-java/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

Χρησιμοποιήστε [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) για να ορίσετε το προεπιλεγμένο χρώμα επισήμανσης για μια παράγραφο, ή χρησιμοποιήστε [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#getHighlightColor) για μεμονωμένες περιοχές κειμένου.

Το ακόλουθο παράδειγμα ορίζει ανοιχτόγκρι επισήμανση ως προεπιλογή για την πρώτη παράγραφο. Οι συγκεκριμένες χρωματικές επισήμανσεις σε μεμονωμένες περιοχές έχουν προτεραιότητα έναντι αυτής της προεπιλογής:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

Ο κώδικας παρακάτω δείχνει πώς να ορίσετε το χρώμα φόντου για **περιφέρειες κειμένου με έντονη γραμματοσειρά**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Ορίστε το χρώμα επισήμανσης για τη περιοχή κειμένου.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι γκρι περιοχές κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Χρησιμοποιήστε [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setAlignment) για να ορίσετε την ευθυγράμμιση παραγράφου μέσα σε ένα πλαίσιο κειμένου. Η τιμή μπορεί να είναι κεντραρισμένη, αριστερά, δεξιά, στοιχισμένη και ούτω καθεξής.

Το ακόλουθο παράδειγμα κώδικα δείχνει πώς να ευθυγραμμίσετε την παράγραφο **στην κεντρική**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ορίστε την ευθυγράμμιση της παραγράφου στο κέντρο.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Η ευθυγραμμισμένη παράγραφος](aligned_paragraph.png)

## **Ορισμός Διαφάνειας για Κείμενο**

Η διαφάνεια του κειμένου ελέγχεται μέσω του αλφαβήτου (alpha) του χρώματος που ανατίθεται στο [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#getFillFormat). Στα παρακάτω παραδείγματα, `alpha = 50` είναι μια τιμή καναλιού ARGB στην κλίμακα 0–255, όχι ποσοστό διαφάνειας.

Ο κώδικας παρακάτω δείχνει πώς να εφαρμόσετε διαφάνεια στην **ολοκλήρη παράγραφο**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ορίστε το χρώμα γεμίσματος του κειμένου σε διαφανές χρώμα.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

Το ακόλουθο παράδειγμα κώδικα δείχνει πώς να εφαρμόσετε διαφάνεια σε **περιφέρειες κειμένου με έντονη γραμματοσειρά**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Ορίστε τη διαφάνεια της περιοχής κειμένου.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι διαφανείς περιοχές κειμένου](transparent_text_portions.png)

## **Ορισμός Διαστήματος Χαρακτήρων για Κείμενο**

Χρησιμοποιήστε [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setSpacing) για να αυξήσετε ή να μειώσετε το διάστημα μεταξύ χαρακτήρων σε ένα πλαίσιο κειμένου. Τα παραδείγματα προσθέτουν 3 σημεία διαστήματος· οι αρνητικές τιμές συμπιέζουν το κείμενο.

Ο παρακάτω κώδικας Python δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων στην **ολόκληρη παράγραφο**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Επέκταση διαστήματος χαρακτήρων.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

Ο κώδικας παρακάτω δείχνει πώς να αυξήσετε το διάστημα χαρακτήρων σε **περιφέρειες κειμένου με έντονη γραμματοσειρά**:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
            portion.getPortionFormat().setSpacing(3) # Επέκταση διαστήματος χαρακτήρων.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στις περιοχές κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

Σε ορισμένες περιπτώσεις, το κείμενο που αποδίδει το Aspose.Slides μπορεί να φαίνεται ελαφρώς πιο στενό από το ίδιο κείμενο που εμφανίζεται στο PowerPoint. Αυτό μπορεί να συμβαίνει επειδή το PowerPoint αγνοεί τα δεδομένα kerning για ορισμένες γραμματοσειρές, ακόμη και όταν η γραμματοσειρά περιέχει έγκυρα δεδομένα kerning και το kerning είναι ενεργοποιημένο στις ρυθμίσεις του PowerPoint.

Για να φέρετε το αποτέλεσμα πιο κοντά σε αυτό του PowerPoint, μπορείτε να απενεργοποιήσετε το kerning για περιοχές κειμένου που χρησιμοποιούν τη συγκεκριμένη γραμματοσειρά. Ορίστε [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) σε τιμή μεγαλύτερη από το πραγματικό μέγεθος γραμματοσειράς. Το παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Ελέγχει τα αποτελεσματικά ονόματα γραμματοσειρών, συμπεριλαμβανομένων των κληρονομημένων, και θέτει ένα όριο 100 σημείων για τις περιοχές που χρησιμοποιούν το Roboto. Αυτό απενεργοποιεί το kerning για τις αντίστοιχες περιοχές με μέγεθος γραμματοσειράς κάτω από 100 σημεία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για τις περιοχές κειμένου που είναι κάτω από το όριο, αυτή η ρύθμιση εμποδίζει το kerning και μπορεί να βοηθήσει την απόδοση του Aspose.Slides να ταιριάζει με την οπτική έξοδο του PowerPoint για γραμματοσειρές που επηρεάζονται από αυτή τη συμπεριφορά εξειδικευμένη του PowerPoint.

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Οι ιδιότητες της γραμματοσειράς μπορούν να οριστούν στο επίπεδο παραγράφου μέσω του [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ή σε μεμονωμένες περιοχές μέσω του [PortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/).

Το παρακάτω παράδειγμα ορίζει τη προεπιλεγμένη γραμματοσειρά της πρώτης παραγράφου σε Times New Roman 12 σημείων με έντονη, πλάγια και υπογράμμιση με κουκκίδες. Η ρητή μορφοποίηση σε μεμονωμένες περιοχές έχει προτεραιότητα έναντι αυτών των προεπιλογών:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

Το παρακάτω παράδειγμα εφαρμόζει Times New Roman 13 σημεία, πλάγια μορφοποίηση και υπογράμμιση με κουκκίδες σε περιοχές των οποίων η αποτελεσματική μορφοποίηση είναι έντονη:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Ορίστε τις ιδιότητες γραμματοσειράς για τη περιοχή κειμένου.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για περιοχές κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

Χρησιμοποιήστε [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setTextVerticalType) για να θέσετε προρυθμισμένη προσανατολισμό κειμένου μέσα σε σχήμα.

Το παρακάτω παράδειγμα κώδικα ορίζει τον προσανατολισμό κειμένου στο σχήμα σε [TextVerticalType.Vertical270](https://reference.aspose.com/slides/el/python-java/aspose.slides/textverticaltype/), που περιστρέφει το κείμενο **90 μοίρες αριστερόστροφα**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Η περιστροφή κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

Χρησιμοποιήστε [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setRotationAngle) για να ορίσετε προσαρμοσμένη γωνία περιστροφής για ένα [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/).

Ο κώδικας παρακάτω περιστρέφει το πλαίσιο κειμένου κατά 3 μοίρες δεξιόστροφα μέσα στο σχήμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμής Παραγράφων**

Το Aspose.Slides παρέχει [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setSpaceBefore) και [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setSpaceWithin) για έλεγχο του διαστήματος παραγράφων. Αυτές οι ιδιότητες χρησιμοποιούνται ως εξής:

* Χρησιμοποιήστε θετική τιμή για να ορίσετε το διάστημα γραμμής ως ποσοστό του ύψους της γραμμής.
* Χρησιμοποιήστε αρνητική τιμή για να ορίσετε το διάστημα γραμμής σε σημεία.

Το παρακάτω παράδειγμα ορίζει εσωτερικό διάστημα στην πρώτη παράγραφο στο 200 % του ύψους της γραμμής (διπλό διάστημα):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Το διάστημα γραμμής μέσα στην παράγραφο](line_spacing.png)

## **Έλεγχος Σπάσιμος Γραμμής**

Οι κανόνες σπασίματος γραμμής της παραγράφου είναι χρήσιμοι σε στενά τμήματα κειμένου και παρουσιάσεις που συνδυάζουν λατινικό και κινεζικό κείμενο. Οι παρακάτω μέθοδοι ανήκουν στο [ParagraphFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/), επομένως εφαρμόζονται σε ολόκληρη την παράγραφο:

- [setLatinLineBreak](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) ελέγχει τους κανόνες σπασίματος για λατινικά. Σε μεικτό κείμενο, η αλλαγή του μπορεί επίσης να αλλάξει το σημείο όπου τυλίγεται το γειτονικό ανατολικο-ασιατικό κείμενο και η στίξη.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ελέγχει τους κανόνες σπασίματος για ανατολικο-ασιατικό κείμενο, συμπεριλαμβανομένων των περιορισμών χαρακτήρων στην αρχή και το τέλος μιας γραμμής.

Αυτοί οι κανόνες δεν αντικαθιστούν το [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setWrapText), το οποίο ενεργοποιεί την αυτόματη αναδίπλωση μέσα στο πλαίσιο κειμένου. Επηρεάζουν τη διάταξη όταν πραγματοποιείται αναδίπλωση· δεν εισάγουν χαρακτήρες διακοπής γραμμής. Μια ρητή διακοπή γραμμής αναγκάζει νέα γραμμή στην παράγραφο ανεξάρτητα από το διαθέσιμο πλάτος.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα στενό μπλοκ κειμένου που περιέχει κινέζικα και λατινικά. Θέτει ρητά και τις δύο επιλογές σπασίματος και αποθηκεύει το «line_breaking.pptx». Για να πειραματιστείτε με κάποιον από τους κανόνες, αλλάξτε την αντίστοιχη τιμή ενώ διατηρείτε την άλλη σταθερή. Το παράδειγμα χρησιμοποιεί Arial 24 σημεία και SimSun με πλάτος πλαισίου 160 σημεία και μηδενικά οριζόντια περιθώρια πλαισίου κειμένου. Το [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setAutofitType) καλείται με [TextAutofitType.None_](https://reference.aspose.com/slides/el/python-java/aspose.slides/textautofittype/) ώστε το μέγεθος του κειμένου και οι διαστάσεις του πλαισίου να παραμείνουν σταθερές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Έλεγχος Κρεματής Στίξης**

Το [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) επιτρέπει σε επιλέξιμη στίξη να εκτείνεται πέρα από τη δεξιά άκρη της γραμμής κειμένου αντί να καταλάβει την επόμενη γραμμή. Εφαρμόζεται σε ολόκληρη την παράγραφο και διαφέρει από το κρεματό εσοχή.

Το παρακάτω αυτόνομο παράδειγμα ενεργοποιεί κρεματή στίξη σε πλαίσιο κειμένου πλάτους 100 σημεία και αποθηκεύει το «hanging_punctuation.pptx». Με Arial 24 σημεία και μηδενικά οριζόντια περιθώρια, η τελική τελεία παραμένει μετά τη λέξη «sentence» και εκτείνεται πέρα από τη δεξιά άκρη του κειμένου. Ορίστε την ιδιότητα σε [NullableBool.False_](https://reference.aspose.com/slides/el/python-java/aspose.slides/nullablebool/) για σύγκριση: με αυτές τις ρυθμίσεις, η τελεία καταλαμβάνει ξεχωριστή γραμμή. Η αναδίπλωση είναι ενεργοποιημένη και η αυτόματη προσαρμογή είναι απενεργοποιημένη για να διατηρηθεί το διαθέσιμο πλάτος σταθερό.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Δεν μπορεί να κρεμαστεί κάθε σήμα στίξης. Το οπτικό αποτέλεσμα εξαρτάται από τη διαθεσιμότητα γραμματοσειρών και τη διάταξη: η αλλαγή γραμματοσειράς, διαθέσιμου πλάτους, περιθωρίων ή ρυθμίσεων autofit μπορεί να αφαιρέσει τη διακριτή διαφορά.

## **Ορισμός Τύπου Autofit για Πλαίσια Κειμένου**

Το [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setAutofitType) καθορίζει πώς συμπεριφέρεται το κείμενο όταν υπερβαίνει τα όρια του περιέκτη του. Χρησιμοποιήστε το για να ελέγξετε αν το κείμενο μειώνεται, υπερέχει ή αλλάζει το μέγεθος του σχήματος αυτόματα. Το παρακάτω παράδειγμα ρυθμίζει το σχήμα ώστε να αλλάζει μέγεθος ώστε να ταιριάζει στο κείμενο και αποθηκεύει το αποτέλεσμα στο «autofit_type.pptx».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για να μετρήσετε τις γραμμές μετά την αυτόματη αναδίπλωση και να δείτε πώς η αλλαγή του κειμένου ή του πλάτους του σχήματος επηρεάζει το αποτέλεσμα, δείτε το [Count Rendered Lines](/slides/el/python-java/manage-paragraph/). Η μόνο η μέτρηση γραμμών δεν υποδεικνύει αν το κείμενο υπερέχει του περιέκτη του.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

Το [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setAnchoringType) ορίζει πώς τοποθετείται κατακόρυφα το κείμενο μέσα σε σχήμα, π.χ. στην κορυφή, στο κέντρο ή στο κάτω μέρος. Το παρακάτω παράδειγμα αγκυροβολεί το κείμενο στο κάτω μέρος του πρώτου σχήματος και αποθηκεύει το αποτέλεσμα στο «text_anchor.pptx».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Καρτέλων Κειμένου**

Χρησιμοποιήστε [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) και [ParagraphFormat.getTabs](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#getTabs) για να ρυθμίσετε τα σταθμεία καρτέλας σε μια παράγραφο. Το παρακάτω παράδειγμα ορίζει το προεπιλεγμένο διάστημα καρτέλας στα 100 σημεία και προσθέτει αριστερώς ευθυγραμμισμένο σταθμό στις 30 σημεία. Αυτές οι ρυθμίσεις επηρεάζουν το κείμενο που περιέχει χαρακτήρες καρτέλας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι καρτέλες της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Διόρθωσης**

Το Aspose.Slides παρέχει [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#setLanguageId), που επιτρέπει τον ορισμό της γλώσσας διόρθωσης για μια περιοχή κειμένου. Η γλώσσα διόρθωσης καθορίζει τη γλώσσα που χρησιμοποιείται για ορθογραφικούς και γραμματικούς ελέγχους στο PowerPoint.

Το παρακάτω παράδειγμα απαιτεί το «presentation.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον μία παράγραφο. Αντικαθιστά το περιεχόμενο της πρώτης παραγράφου με «1。», ορίζει το SimSun ως γραμματοσειρά του και αναθέτει τη γλώσσα διόρθωσης Απλοποιημένων Κινέζων (`zh-CN`). Αποθηκεύει το αποτέλεσμα στο «proofing_language.pptx»:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Ορίστε το Id μιας γλώσσας διόρθωσης.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Χρησιμοποιήστε [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) για να ορίσετε την προεπιλεγμένη γλώσσα κειμένου κατά τη φόρτωση ή δημιουργία παρουσίασης. Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με αγγλικά ΗΠΑ ως προεπιλεγμένη γλώσσα κειμένου, προσθέτει ένα πλαίσιο κειμένου και εκτυπώνει `en-US` για την πρώτη περιοχή κειμένου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθέστε ένα σχήμα ορθογώνιο με κείμενο.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Ελέγξτε τη γλώσσα της πρώτης περιοχής.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

Για να εφαρμόσετε προεπιλεγμένη μορφοποίηση κειμένου σε επίπεδο παρουσίασης, χρησιμοποιήστε [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Το παρακάτω παράδειγμα ορίζει γραμματοσειρά 14 σημείων με έντονη γραφή ως προεπιλογή για παραγράφους κορυφαίου επιπέδου σε νέα παρουσίαση και το αποθηκεύει στο «default_text_style.pptx». Το κείμενο μπορεί να κληρονομήσει αυτές τις προεπιλογές εκτός εάν πιο συγκεκριμένη μορφοποίηση τις αντικαταστήσει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Αποκτήστε τη μορφοποίηση παραγράφου πρώτου επιπέδου.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Εξαγωγή Κειμένου με Επίδραση Όλων σε Κεφαλαία (All‑Caps)**

Στο PowerPoint, η εφαρμογή του εφέ **All Caps** κάνει το κείμενο να εμφανίζεται με κεφαλαία γράμματα στη διαφάνεια ακόμη και όταν αρχικά πληκτρολογήθηκε με πεζά. Όταν ανακτάτε μια τέτοια περιοχή κειμένου με το Aspose.Slides, η βιβλιοθήκη επιστρέφει το κείμενο ακριβώς όπως εισήχθηκε. Για να ταιριάξετε το εμφανιζόμενο κείμενο, ελέγξτε το [TextCapType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textcaptype/) και μετατρέψτε τη επιστρεφόμενη συμβολοσειρά σε κεφαλαία όταν η τιμή είναι `All`.

Αυτό το παράδειγμα απαιτεί το «sample2.pptx» με ένα πλαίσιο κειμένου ως πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη περιοχή της πρώτης παραγράφου περιέχει το «Hello, Aspose!» με εφαρμοσμένο το εφέ All Caps, όπως φαίνεται παρακάτω.

![Η επίδραση All Caps](all_caps_effect.png)

Ο κώδικας παρακάτω δείχνει πώς να εξάγετε το κείμενο με το εφέ **All Caps** εφαρμοσμένο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Έξοδος:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **ΣΥΝΗΘΕΣΕΙΣ (FAQ)**

**Πώς μπορώ να τροποποιήσω κείμενο σε πίνακα σε μια διαφάνεια;**

Για να τροποποιήσετε κείμενο σε πίνακα σε μια διαφάνεια, χρησιμοποιήστε το [Table](https://reference.aspose.com/slides/el/python-java/aspose.slides/table/). Περιηγηθείτε στα κελιά και ενημερώστε κάθε κελί μέσω του [Cell.getTextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/cell/#getTextFrame) και τη μορφοποίηση παραγράφου μέσω του [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Πώς μπορώ να εφαρμόσω χρώμα διαβάθμισης σε κείμενο σε μια διαφάνεια PowerPoint;**

Για να εφαρμόσετε χρώμα διαβάθμισης σε κείμενο, χρησιμοποιήστε το [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseportionformat/#getFillFormat). Ορίστε το [FillFormat.setFillType](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#setFillType) σε [FillType.Gradient](https://reference.aspose.com/slides/el/python-java/aspose.slides/filltype/) και ρυθμίστε τις στάσεις διαβάθμισης, την κατεύθυνση και τη διαφάνεια.