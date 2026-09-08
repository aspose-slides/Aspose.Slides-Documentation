---
title: Βελτιώστε τις παρουσιάσεις σας με AutoFit σε Python
linktitle: Ρυθμίσεις Autofit
type: docs
weight: 30
url: /el/python-java/manage-autofit-settings/
keywords:
- πλαίσιο κειμένου
- αυτοπροσαρμογή
- μη αυτόματη προσαρμογή
- προσαρμογή κειμένου
- σμίκρυνση κειμένου
- αναδίπλωση κειμένου
- αλλαγή μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις ρυθμίσεις AutoFit στο Aspose.Slides για Python μέσω Java, ώστε να βελτιστοποιήσετε την εμφάνιση του κειμένου στις παρουσιάσεις σας PowerPoint και OpenDocument και να βελτιώσετε την αναγνωσιμότητα του περιεχομένου."
---
## **Εισαγωγή**

Από προεπιλογή, όταν προσθέτετε ένα πλαίσιο κειμένου, το Microsoft PowerPoint χρησιμοποιεί τη ρύθμιση **Resize shape to fix text** για το πλαίσιο κειμένου — προσαρμόζει αυτόματα το μέγεθός του ώστε το κείμενό του να χωράει πάντα. 

![Πλαίσιο κειμένου σε PowerPoint](textbox-in-powerpoint.png)

* Όταν το κείμενο στο πλαίσιο κειμένου γίνεται πιο μακρύ ή μεγαλύτερο, το PowerPoint αυτόματα μεγαλώνει το πλαίσιο κειμένου — αυξάνει το ύψος του — ώστε να μπορεί να περιέχει περισσότερο κείμενο. 
* Όταν το κείμενο στο πλαίσιο κειμένου γίνεται πιο σύντομο ή μικρότερο, το PowerPoint αυτόματα μειώνει το πλαίσιο κειμένου — μειώνει το ύψος του — για να αφαιρέσει περιττό χώρο. 

Στο PowerPoint, αυτές είναι οι 4 σημαντικές παράμετροι ή επιλογές που ελέγχουν τη συμπεριφορά autofit για ένα πλαίσιο κειμένου: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![Επιλογές autofit στο PowerPoint](autofit-options-powerpoint.png)

Το Aspose.Slides for Python via Java παρέχει παρόμοιες επιλογές — ορισμένες ιδιότητες στην κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/) — που σας επιτρέπουν να ελέγξετε τη συμπεριφορά autofit για πλαίσια κειμένου σε παρουσιάσεις. 

## **Αλλαγή Μεγέθους Σχήματος για Προσαρμογή Κειμένου**

Αν θέλετε το κείμενο σε ένα πλαίσιο να ταιριάζει πάντα στο πλαίσιο μετά από αλλαγές, πρέπει να χρησιμοποιήσετε την επιλογή **Resize shape to fix text**. Για να ορίσετε αυτή τη ρύθμιση, χρησιμοποιήστε τη μέθοδο [setAutofitType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setAutofitType) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/)) με το [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/textautofittype/#Shape).

![Ρύθμιση πάντα προσαρμοσμένου κειμένου στο PowerPoint](alwaysfit-setting-powerpoint.png)

Αυτός ο κώδικας Python δείχνει πώς να καθορίσετε ότι ένα κείμενο πρέπει πάντα να ταιριάζει στο πλαίσιο του σε μια παρουσίαση PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αν το κείμενο γίνει πιο μακρύ ή μεγαλύτερο, το πλαίσιο κειμένου θα προσαρμοστεί αυτόματα (αύξηση του ύψους) ώστε όλο το κείμενο να χωράει. Αν το κείμενο γίνει πιο σύντομο, συμβαίνει το αντίστροφο. 

## **Do Not Autofit**

Αν θέλετε ένα πλαίσιο κειμένου ή σχήμα να διατηρεί τις διαστάσεις του ανεξάρτητα από τις αλλαγές στο κείμενο που περιέχει, πρέπει να χρησιμοποιήσετε την επιλογή **Do not Autofit**. Για να ορίσετε αυτή τη ρύθμιση, χρησιμοποιήστε τη μέθοδο [setAutofitType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setAutofitType) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/)) με το [None](https://reference.aspose.com/slides/el/python-java/aspose.slides/textautofittype/#None). 

![Ρύθμιση No Autofit στο PowerPoint](donotautofit-setting-powerpoint.png)

Αυτός ο κώδικας Python δείχνει πώς να καθορίσετε ότι ένα πλαίσιο κειμένου πρέπει πάντα να διατηρεί τις διαστάσεις του σε μια παρουσίαση PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο του, θα ξεχύνεται εκτός. 

## **Shrink Text on Overflow**

Αν ένα κείμενο γίνει πολύ μακρύ για το πλαίσιο του, με την επιλογή **Shrink text on overflow** μπορείτε να ορίσετε ότι το μέγεθος και η απόσταση του κειμένου πρέπει να μειωθούν ώστε να ταιριάζει στο πλαίσιο. Για να ορίσετε αυτή τη ρύθμιση, χρησιμοποιήστε τη μέθοδο [setAutofitType](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setAutofitType) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/)) με το [Normal](https://reference.aspose.com/slides/el/python-java/aspose.slides/textautofittype/#Normal).

![Ρύθμιση Shrink Text on Overflow στο PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Αυτός ο κώδικας Python δείχνει πώς να καθορίσετε ότι ένα κείμενο πρέπει να μειώνεται όταν υπερβαίνει το πλαίσιο σε μια παρουσίαση PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Σημείωση" color="info" %}}

Όταν χρησιμοποιείται η επιλογή **Shrink text on overflow**, η ρύθμιση εφαρμόζεται μόνο όταν το κείμενο γίνει πολύ μακρύ για το πλαίσιο του. 

{{% /alert %}}

## **Wrap Text**

Αν θέλετε το κείμενο σε ένα σχήμα να αναδιπλώνεται μέσα στο σχήμα όταν ξεπερνά το όριο του (μόνο στο πλάτος), πρέπει να χρησιμοποιήσετε την παράμετρο **Wrap text in shape**. Για να ορίσετε αυτή τη ρύθμιση, πρέπει να χρησιμοποιήσετε τη μέθοδο [setWrapText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setWrapText) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/)) με το [NullableBool.True](https://reference.aspose.com/slides/el/python-java/aspose.slides/nullablebool/#True). 

Αυτός ο κώδικας Python δείχνει πώς να χρησιμοποιήσετε τη ρύθμιση Wrap Text σε μια παρουσίαση PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Προειδοποίηση" color="warning" %}} 

Αν χρησιμοποιήσετε τη μέθοδο [setWrapText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setWrapText) με το [NullableBool.False](https://reference.aspose.com/slides/el/python-java/aspose.slides/nullablebool/#False) για ένα σχήμα, όταν το κείμενο μέσα στο σχήμα γίνει πιο μακρύ από το πλάτος του σχήματος, το κείμενο θα εκτείνεται πέρα από τα όρια του σχήματος σε μία γραμμή. 

{{% /alert %}}

## **FAQ**

**Επηρεάζουν τα εσωτερικά περιθώρια του πλαισίου κειμένου το AutoFit;**

Ναι. Το padding (εσωτερικά περιθώρια) μειώνει τη διαθέσιμη περιοχή για κείμενο, οπότε το AutoFit ενεργοποιείται νωρίτερα — μειώνοντας τη γραμματοσειρά ή το μέγεθος σχήματος νωρίτερα. Ελέγξτε και προσαρμόστε τα περιθώρια πριν ρυθμίσετε το AutoFit.

**Πώς αλληλεπιδρά το AutoFit με χειροκίνητες και μαλακές αλλαγές γραμμής;**

Οι αναγκαστικές αλλαγές γραμμής παραμένουν, και το AutoFit προσαρμόζει το μέγεθος γραμματοσειράς και την απόσταση γύρω από αυτές. Η αφαίρεση περιττών αλλαγών γραμμής συχνά μειώνει το πόσο επιθετικά πρέπει να μειώσει το AutoFit το κείμενο.

**Επηρεάζει η αλλαγή της γραμματοσειράς θέματος ή η αλλαγή γραμματοσειράς το αποτέλεσμα του AutoFit;**

Ναι. Η αντικατάσταση με γραμματοσειρά που έχει διαφορετικά μετρικά γλιφών αλλάζει το πλάτος/ύψος του κειμένου, κάτι που μπορεί να αλλάξει το τελικό μέγεθος γραμματοσειράς και τη περιτύλιξη γραμμών. Μετά από οποιαδήποτε αλλαγή ή αντικατάσταση γραμματοσειράς, ελέγξτε εκ νέου τις διαφάνειες.