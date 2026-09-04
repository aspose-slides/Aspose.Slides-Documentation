---
title: Κύρια διαφάνεια
type: docs
weight: 30
url: /el/python-java/examples/elements/master-slide/
keywords:
- παράδειγμα κώδικα
- κύρια διαφάνεια
- προσθήκη κύριας διαφάνειας
- πρόσβαση στην κύρια διαφάνεια
- αφαίρεση κύριας διαφάνειας
- μη χρησιμοποιημένη κύρια διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχείριση κύριων διαφανειών με Aspose.Slides για Python μέσω Java: δημιουργία, πρόσβαση, αφαίρεση και καθαρισμός των masters σε παρουσιάσεις PowerPoint και OpenDocument."
---
Οι κύριες διαφάνειες αποτελούν το ανώτερο επίπεδο της ιεραρχίας κληρονομικότητας διαφανειών στο PowerPoint. Μια **master slide** ορίζει κοινά στοιχεία σχεδίασης όπως φόντα, λογότυπα και μορφοποίηση κειμένου. Οι **layout slides** κληρονομούν από τις master slides, και οι **normal slides** κληρονομούν από τις layout slides.

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε, τροποποιήσετε και διαχειριστείτε τις master slides χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Εγκατάσταση](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, μετά εισάγει το API αφού η JVM είναι σε λειτουργία.

## **Προσθήκη master slide**

Αυτό το παράδειγμα δείχνει πώς να δημιουργήσετε μια νέα master slide κλωνοποιώντας την προεπιλεγμένη. Στη συνέχεια προσθέτει μια λωρίδα με το όνομα της εταιρείας σε όλες τις διαφάνειες μέσω κληρονομιάς layout.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Κλωνοποιήστε την προεπιλεγμένη master διαφάνεια.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Προσθέστε μια λωρίδα με το όνομα της εταιρείας στην κορυφή της master διαφάνειας.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Αντιστοιχίστε τη νέα master διαφάνεια σε μια layout διαφάνεια.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Αντιστοιχίστε τη layout διαφάνεια στην πρώτη διαφάνεια της παρουσίασης.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Οι master slides προσφέρουν έναν τρόπο να εφαρμόζονται συνεπές branding ή κοινά στοιχεία σχεδίασης σε όλες τις διαφάνειες. Οι αλλαγές που γίνονται σε ένα master εμφανίζονται αυτόματα στις εξαρτημένες layout και normal διαφάνειες.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Τα σχήματα και η μορφοποίηση που προστίθενται σε μια master slide κληρονομούνται από τις layout slides και, με τη σειρά τους, από όλες τις normal διαφάνειες που χρησιμοποιούν αυτές τις διατάξεις. Η παρακάτω εικόνα δείχνει πώς ένα πλαίσιο κειμένου που προστέθηκε σε μια master slide αποδίδεται αυτόματα στη τελική διαφάνεια.
{{% /alert %}}

![Παράδειγμα κληρονομίας master](master-slide-banner.png)

## **Πρόσβαση σε master slide**

Μπορείτε να έχετε πρόσβαση στις master slides μέσω της συλλογής master του παρουσίασης. Αυτό το παράδειγμα ανακτά την πρώτη master slide και αλλάζει τον τύπο του φόντου της.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Αφαίρεση master slide**

Μια master slide μπορεί να αφαιρεθεί κατά δείκτη ή με αναφορά μετά τη μη χρήση της. Αυτό το παράδειγμα αντιστοιχίζει μια κλωνοποιημένη master slide στην παρουσίαση και στη συνέχεια αφαιρεί την αρχική master με χρήση δείκτη.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpire.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Αφαιρέστε την αχρησιμοποίητη αρχική master διαφάνεια με δείκτη.
    presentation.getMasters().removeAt(0)

    # Εναλλακτικά, αφαιρέστε μια αχρησιμοποίητη master διαφάνεια με αναφορά:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Αφαίρεση μη χρησιμοποιούμενων master slides**

Ορισμένες παρουσιάσεις περιέχουν master slides που δεν χρησιμοποιούνται. Η αφαίρεση αυτών των διαφανειών μπορεί να βοηθήσει στη μείωση του μεγέθους του αρχείου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Αφαιρέστε όλες τις αχρησιμοποίητες master διαφάνειες, συμπεριλαμβανομένων εκείνων που έχουν σημειωθεί ως Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```