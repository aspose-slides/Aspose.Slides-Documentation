---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε Python μέσω Java
linktitle: Διαχείριση Υπερσυνδέσμων
type: docs
weight: 20
url: /el/python-java/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσυνδέσμου
- δημιουργία υπερσυνδέσμου
- μορφοποίηση υπερσυνδέσμου
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- υπερσύνδεσμος κειμένου
- υπερσύνδεσμος διαφάνειας
- υπερσύνδεσμος σχήματος
- υπερσύνδεσμος εικόνας
- υπερσύνδεσμος βίντεο
- μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσμων σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για Python μέσω Java, χρησιμοποιώντας παραδείγματα Python."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο μιας παρουσίασης με μια ιστοσελίδα ή με μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Άνοιγμα μιας ιστοσελίδας από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Πλοήγηση σε άλλη διαφάνεια, για παράδειγμα από πίνακα περιεχομένων.

Το Aspose.Slides for Python via Java σάς επιτρέπει να προσθέτετε αυτούς τους συνδέσμους, να ελέγχετε την εμφάνιση και τον ήχο τους, να ενημερώνετε τις ιδιότητές τους και να τους αφαιρείτε. Τα παραδείγματα παρακάτω δείχνουν πώς να εργαστείτε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να έχετε πρόσβαση σε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}

Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με το [free online Aspose PowerPoint editor](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **Προσθήκη Υπερσυνδέσμων URL**

Μπορείτε να αντιστοιχίσετε ένα URL ιστοσελίδας σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αντιστοιχίζετε τον υπερσύνδεσμο καθορίζει την περιοχή κλικ: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

Για παρουσιάσεις που περιέχουν σχετικούς υπερσυνδέσμους, δείτε το [Manage the Hyperlink Base](/slides/el/python-java/presentation-properties/#manage-the-hyperlink-base) για ανάγνωση, αλλαγή ή διαγραφή της βάσης σε επίπεδο εγγράφου.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με μια ιστοσελίδα, περάστε ένα [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) στη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ-δύσκολο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Προσθήκη Υπερσυνδέσμων URL σε Σχήματα και Πλαίσια Πολυμέσων**

Καλέστε τη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) στο ορθογώνιο για να κάνετε ολόκληρη την περιοχή του κλικ-δυνατή. Χρησιμοποιήστε τη μέθοδο [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) για να εμφανίσετε στους αναγνώστες μια υπόδειξη σχετικά με τον προορισμό όταν αιωρούνται πάνω από το ορθογώνιο. Και οι δύο μέθοδοι ισχύουν επίσης για εικόνες, ήχους και βίντεο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί τη μέθοδο [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Μορφοποίηση Υπερσυνδέσμων**

Μπορείτε να αλλάξετε το χρώμα του συνδεδεμένου κειμένου, να παίξετε ή να σταματήσετε έναν ήχο όταν ένας αναγνώστης ενεργοποιήσει έναν σύνδεσμο, και να ορίσετε το tooltip που εμφανίζεται όταν αιωρείται.

### **Χρώμα**

Η μέθοδος [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) του [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) καθορίζει εάν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Αυτή η δυνατότητα εισήχθη στο PowerPoint 2019· οι παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Σε αυτό το παράδειγμα, το [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) κάνει τον πρώτο σύνδεσμο να χρησιμοποιεί το κόκκινο γέμισμα του τμήματος κειμένου. Ο δεύτερος σύνδεσμος διατηρεί το χρώμα υπερσυνδέσμου της παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ήχος**

Ένας υπερσύνδεσμος μπορεί να παίξει ήχο όταν ενεργοποιηθεί ή να σταματήσει ήχο που ήδη παίζει. Χρησιμοποιήστε τις παρακάτω μεθόδους για να ρυθμίσετε αυτές τις συμπεριφορές:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) καθορίζει τον ήχο που σχετίζεται με τον υπερσύνδεσμο.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) ελέγχει εάν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου Υπερσυνδέσμου**

Το κουμπί στην πρώτη διαφάνεια χρησιμοποιεί το [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) για να παίξει ήχο από `sampleaudio.wav` όταν ο αναγνώστης κάνει κλικ για προχωρήσει. Στη δεύτερη διαφάνεια, ένα ξεχωριστό κουμπί χρησιμοποιεί το [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) για να σταματήσει την αναπαραγωγή και να διατηρήσει τον αναγνώστη σε αυτή τη διαφάνεια.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Εξαγωγή Ήχου Υπερσυνδέσμου**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο του υπερσυνδέσμου του πρώτου σχήματος στη μνήμη μέσω των [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) και [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Ρυθμίσεις Tooltip και Αλληλεπίδρασης**

Μπορείτε να καλέσετε τις ακόλουθες μεθόδους του [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) αφού αντιστοιχίσετε έναν υπερσύνδεσμο σε κείμενο ή σχήμα:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) ορίζει το κείμενο που ένας θεατής μπορεί να εμφανίσει ως υπόδειξη για το σύνδεσμο.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) καθορίζει το πλαίσιο-στόχο μέσα σε ένα γονικό HTML frameset, όταν ισχύει.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) ελέγχει εάν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβαλόντων υπερσυνδέσμων.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) ελέγχει εάν ο υπερσύνδεσμος επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε το [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) για να συλλέξετε containers υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν κάνετε αλλαγές. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) ή το [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί το αντίστοιχο mouse‑over.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Για απεριόριστη αφαίρεση, το [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) αφαιρεί και τις δύο ενέργειες ενεργοποίησης στο επιλεγμένο πεδίο με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Καθαρισμός Υπερσυνδέσμων Πριν την Αντικατάσταση Κειμένου SmartArt**

Όταν αντικαθιστάτε μια παράγραφο σε έναν υπάρχοντα κόμβο SmartArt, ο καθαρισμός των τμημάτων κειμένου του μπορεί να αφήσει ενεργό έναν παλιό υπερσύνδεσμο. Ανακτήστε την παράγραφο μέσω του [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getTextFrame). Πριν καθαρίσετε τα τμήματά της, καλέστε το [getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) στο πλαίσιο κειμένου του σχήματος κόμβου που εμφανίζει την παράγραφο, μετά καλέστε το [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) στο αντικείμενο που επιστρέφεται. Αυτό αφαιρεί κάθε υπερσύνδεσμο σε εκείνο το πλαίσιο, συμπεριλαμβανομένων των συνδέσμων στις άλλες παραγράφους του.

Το παράδειγμα υποθέτει ότι το τρίτο σχήμα στην πρώτη διαφάνεια του `SmartArtHyperlink.pptx` είναι γραφικό SmartArt. Αντικαθιστά την πρώτη παράγραφο του τέταρτου κόμβου. Σε αυτήν την παρουσίαση, το πρώτο σχήμα του κόμβου εμφανίζει αυτήν την παράγραφο.

Μετά την προσθήκη και των δύο τμημάτων, το παράδειγμα διαβάζει τη αποτελεσματική μορφοποίηση τους με το [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective). Στη μορφοποίηση αυτή, το `getHyperlinkClick` επιστρέφει το νέο υπερσύνδεσμο για το πρώτο τμήμα και `None` για το δεύτερο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Portion, Presentation

presentation = Presentation("SmartArtHyperlink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    smart_art = slide.getShapes().get_Item(2)
    node = smart_art.getAllNodes().get_Item(3)
    paragraph = node.getTextFrame().getParagraphs().get_Item(0)

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks()
    paragraph.getPortions().clear()

    link = Portion("New reference")
    link.getPortionFormat().setHyperlinkClick(Hyperlink("https://example.com/new"))
    paragraph.getPortions().add(link)
    text = Portion(" (updated)")
    paragraph.getPortions().add(text)

    print(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl())  # https://example.com/new
    print(text.getPortionFormat().getEffective().getHyperlinkClick())  # Κανένα
finally:
    presentation.dispose()
```

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, καταγράψτε τις διαδραστικές ενέργειές της καθώς και τους διαδικτυακούς συνδέσμους. Το [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) επιστρέφει containers υπερσυνδέσμων, όπως τα αντικείμενα [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) και [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/), όχι μια επίπεδη λίστα URL συμβολοσειρών. Εξετάστε τόσο το [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) όσο και το [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) σε κάθε container. Είναι ανεξάρτητα: ο ίδιος container μπορεί να εκθέτει και τις δύο ενέργειες, έτσι ένας πλήρης αναφοράς χρειάζεται έως και δύο γραμμές ανά container.

Η σάρωση μόνο των υπερσυνδέσμων επιπέδου σχήματος μπορεί να παραλείψει συνδέσμους που είναι συνδεδεμένοι με τμήματα κειμένου. Κάντε ερώτημα στο κατάλληλο πεδίο αντ' αυτού, και διατηρήστε τα containers που επιστρέφονται ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Ερώτημα Πεδίων Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) είναι διαθέσιμη μέσω των μεθόδων [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) και [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries). Κάθε πεδίο υποστηρίζει τις ίδιες ερωτήσεις:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) επιστρέφει containers με ενέργεια κλικ.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) επιστρέφει containers με ενέργεια mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) επιστρέφει containers με μία ή και τις δύο ενέργειες.

Αυτό το παράδειγμα αντιστοιχίζει ενέργειες κλικ και mouse‑over σε ένα σχήμα και το κείμενό του, και μια ενέργεια μακροεντολής σε ένα ξεχωριστό κουμπί. Συγκρίνει τον αριθμό των containers που επιστρέφει το [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) με τους μετρητές για κάθε τύπο ενεργοποίησης. Ένα ερώτημα πλαισίου κειμένου μετρά μόνο συνδέσμους στο κείμενο. Οι δικές του ενέργειες του σχήματος εμφανίζονται στα ερωτήματα διαφάνειας και παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για αυτό το παράδειγμα, τα ερωτήματα παρουσίασης και διαφάνειας αναφέρουν τρία containers κλικ, δύο containers mouse‑over και τρία containers με οποιαδήποτε ενέργεια. Το ερώτημα πλαισίου κειμένου αναφέρει ένα container σε κάθε κατηγορία.

### **Κατηγοριοποίηση Ενεργειών και Προορισμών**

Χρησιμοποιήστε τη μέθοδο [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από την πλοήγηση στο web:

| Τιμές | Σημαίνων για ένα audit |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, λυόμενη στο πλαίσιο παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Λήξη τρέχουσας παρουσίασης ή εκκίνηση προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Εκκίνηση προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από τα web URLs. |
| `StartStopMedia` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Καμία ενέργεια πλοήγησης ή μη αναγνωρισμένη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε τους εξωτερικούς προορισμούς μέσω του [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) και τους συγκεκριμένους εσωτερικούς προορισμούς μέσω του [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι ο container δεν έχει ενέργεια. Διατηρήστε την τιμή που επιστρέφεται από το [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε το tooltip που επιστρέφεται από το [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Αυτό το παράδειγμα ανοίγει την παρουσίαση από το προηγούμενο παράδειγμα και γράφει ένα αρχείο JSON ανά ενέργεια. Χρησιμοποιεί το [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) για να συλλέξει containers σε κανονικές διαφάνειες, master, layout και σημειώσεις, συμπεριλαμβανομένων των master σημειώσεων και handout όταν υπάρχουν. Χρησιμοποιεί ισότητα αναφοράς για να μετρήσει κάθε container μία φορά, εφαρμόζει την παρακάτω πολιτική, και ανοίγει ξανά την αποθηκευμένη παρουσίαση για να ελέγξει τόσο τις ενέργειες κλικ όσο και mouse‑over.

Η αναφορά καταγράφει έναν αριθμό διαφάνειας με βάση το 1 και το [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) όταν είναι διαθέσιμο. Η μέθοδος [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) παρέχει τη διαφάνεια ιδιοκτήτη για υποστηριζόμενα containers. Τα master, layout και notes δεν έχουν κανονικό αριθμό διαφάνειας και ταυτοποιούνται με το πεδίο τους. Τα containers σχήματος και τα containers μορφοποίησης τμημάτων κειμένου ετικετοποιούνται ξεχωριστά· άλλοι τύποι containers διατηρούν το όνομα του τύπου χρόνου εκτέλεσης. Κάθε container λαμβάνει ένα τοπικό ID αναφοράς ώστε οι δύο ενέργειές του να μπορούν να συσχετιστούν. Η αναφορά αποθηκεύει τους τύπους ενεργειών ως ακέραιους σταθερούς που ορίζονται από την Java enumeration.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα URLs HTTPS και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι απόφαση ασφαλείας του Aspose.Slides. Το μόνο HTTPS δεν εγγυάται εμπιστοσύνη: προσθέστε λευκές λίστες κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URLs. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, το [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) του container υποστηρίζει τα [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) και [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προορισμού HTTPS· οι άλλοι απαγορευμένοι κλικ και mouse‑over αφαιρούνται ανεξάρτητα. Ορίστε `replace_external_clicks` σε `False` για να αφαιρέσετε όλες τις παραβιάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης ιδιοκτησίας εφαρμογής πριν από την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια συντηρητική πολιτική ελέγχου PDF: σημαδεύει τις ενέργειες mouse‑over και οτιδήποτε άλλο εκτός από έναν εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως πιθανώς μη υποστηριζόμενο. Είναι υπόδειγμα ελέγχου, όχι δοκιμή δυνατότητας ή εγγύηση ότι τα μη σημειωμένα links θα διατηρηθούν κατά την εξαγωγή. Τα υποστηριζόμενα [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/python-java/convert-powerpoint-to-html/) εξαγωγές μπορεί να διατηρήσουν τους υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προβολέα. Τα raster [images](/slides/el/python-java/convert-powerpoint-to-png/) και [video](/slides/el/python-java/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαδέψτε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Με τα δεδομένα που δημιουργήθηκαν παραπάνω, η αναφορά περιέχει πέντε σειρές ενεργειών. Ο σύνδεσμος mouse‑over του αρχείου και ο κλικ μακροεντολής αφαιρούνται, ενώ οι σύνδεσμοι HTTPS και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εμφανίζει μηδέν απαγορευμένες ενέργειες. Ένα εισαγόμενο αρχείο που περιέχει απαγορευμένο εξωτερικό URL κλικ ενεργοποιεί επίσης τον κλάδο αντικατάστασης. Ένα container με επιτρεπόμενο κλικ και απαγορευμένο mouse‑over διατηρεί το κλικ του.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), το οποίο αφαιρεί και τους δύο τύπους ενεργοποίησης σε όλο το επιλεγμένο πεδίο ανεξάρτητα από την πολιτική. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα έργα VBA, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο, και δεν επικυρώνει ένα εξαχθέν PDF ή HTML αρχείο.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να συνδέσω σε μια ενότητα ή στην πρώτη διαφάνειά της;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε ενότητα, συνδέστε στην πρώτη διαφάνεια της ενότητας.

**Μπορώ να προσθέσω υπερσύνδεσμο σε στοιχεία master διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία του master διαφάνειας και των layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά τη διάρκεια της παρουσίασης στις διαφάνειες που χρησιμοποιούν το αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές PDF και HTML μπορεί να διατηρήσουν υπερσυνδέσμους· οι raster εικόνες και βίντεο δεν μπορούν. Δείτε τις παραμέτρους εξαγωγής στο [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).