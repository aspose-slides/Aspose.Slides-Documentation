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
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσμων σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω Java, χρησιμοποιώντας παραδείγματα Python."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο της παρουσίασης με έναν ιστότοπο ή μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Άνοιγμα ιστότοπου από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Πλοήγηση σε άλλη διαφάντα, για παράδειγμα από έναν πίνακα περιεχομένων.

Aspose.Slides for Python via Java σας επιτρέπει να προσθέσετε αυτούς τους συνδέσμους, να ελέγξετε την εμφάνιση και τον ήχο τους, να ενημερώσετε τις ιδιότητές τους και να τους αφαιρέσετε. Τα παρακάτω παραδείγματα δείχνουν πώς να δουλέψετε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να έχετε πρόσβαση σε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με τον [δωρεάν online επεξεργαστή Aspose PowerPoint](https://products.aspose.app/slides/el/editor).
{{% /alert %}} 

## **Προσθήκη URL Υπερσυνδέσμων**

Μπορείτε να εκχωρήσετε ένα URL ιστότοπου σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο εκχωρείτε τον υπερσύνδεσμο καθορίζει την περιοχή κλικ: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

### **Προσθήκη URL Υπερσυνδέσμων σε Κείμενο**

Για να συνδέσετε κείμενο με έναν ιστότοπο, περάστε ένα [Hyperlink](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/) στη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/#setHyperlinkClick) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ-ενεργό.

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

### **Προσθήκη URL Υπερσυνδέσμων σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικ-ενεργό, καλέστε τη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setHyperlinkClick) του. Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο και όχι σε τμήμα κειμένου μέσα σε αυτό.

Η ίδια προσέγγιση ισχύει για πλαίσια εικόνας, ήχου και βίντεο: εκχωρήστε τον υπερσύνδεσμο στο πλαίσιο και, αν χρειάζεται, καλέστε τη [setTooltip](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setTooltip).

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικ-ενεργό:

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

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε μια συγκεκριμένη διαφάντα. Το παρακάτω παράδειγμα χρησιμοποιεί τη [setInternalHyperlinkClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάντα με τη δεύτερη διαφάντα.

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

### **Χρώμα**

Η μέθοδος [setColorSource](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setColorSource) του [Hyperlink](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/) καθορίζει αν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Η δυνατότητα αυτή εισήχθη στο PowerPoint 2019· οι παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάντα. Ο πρώτος χρησιμοποιεί γεμίσμα κειμένου κόκκινο, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

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

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να σταματήσει έναν ήχο που ήδη παίζει. Χρησιμοποιήστε τις παρακάτω μεθόδους για να ρυθμίσετε αυτές τις συμπεριφορές:

- [Hyperlink.setSound](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setSound) ορίζει τον ήχο που συνδέεται με τον υπερσύνδεσμο.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) ελέγχει αν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου σε Υπερσύνδεσμο**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συσχετίζει με ένα κουμπί στην πρώτη διαφάντα. Η κλικ στο κουμπί αναπαράγει τον ήχο και μεταβαίνει στην επόμενη διαφάντα. Ένα δεύτερο σχήμα στην ίδια διαφάντα σταματά τον προηγούμενο ήχο όταν κλικάρεται, χωρίς να εκτελεί ενέργεια πλοήγησης.

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

#### **Εξαγωγή Ήχου από Υπερσύνδεσμο**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο του πρώτου σχήματος σε μνήμη μέσω των [getSound](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#getSound) και [getBinaryData](https://reference.aspose.com/slides/el/python-java/aspose.slides/audio/#getBinaryData).

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

### **Tooltip και Ρυθμίσεις Αλληλεπίδρασης**

Μπορείτε να καλέσετε τις παρακάτω μεθόδους του [Hyperlink](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/) μετά την εκχώρηση ενός υπερσυνδέσμου σε κείμενο ή σχήμα:

- [setTooltip](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setTooltip) ορίζει το κείμενο που μπορεί να εμφανίσει ο θεατής ως υπόδειξη για τον σύνδεσμο.
- [setTargetFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setTargetFrame) καθορίζει το πλαίσιο προορισμού μέσα σε ένα γονικό HTML frameset, όταν εφαρμόζεται.
- [setHistory](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setHistory) ελέγχει αν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα προβληθέντων υπερσυνδέσμων.
- [setHighlightClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#setHighlightClick) ελέγχει αν ο υπερσύνδεσμος επισημαίνεται όταν κλικάρεται.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε το [getAnyHyperlinks](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) για να συλλέξετε κοντέινερ υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα τροποποιήσετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάντα. Για αφαίρεση μόνο ενός τύπου, καλέστε μόνο το [removeHyperlinkClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) ή το [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί το αντίστοιχο mouse‑over.

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

Για μη υπconditionalα αφαίρεση, το [removeAllHyperlinks](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο εύρος με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Αποθέματος Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, καταγράψτε τις διαδραστικές ενέργειές της καθώς και τους διαδικτυακούς συνδέσμους. Το [getAnyHyperlinks](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) επιστρέφει κοντέινερ υπερσυνδέσμων, όπως αντικείμενα [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) και [PortionFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/portionformat/), όχι μια επίπεδη λίστα URL. Εξετάστε τόσο το [getHyperlinkClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getHyperlinkClick) όσο και το [getHyperlinkMouseOver](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getHyperlinkMouseOver) σε κάθε κοντέινερ. Είναι ανεξάρτητα: το ίδιο κοντέινερ μπορεί να εκθέτει και τις δύο ενέργειες, οπότε μια πλήρης αναφορά χρειάζεται έως και δύο γραμμές ανά κοντέινερ.

Η σάρωση μόνο σε επίπεδο σχήματος μπορεί να χάσει συνδέσμους που είναι προσκολλημένοι σε τμήματα κειμένου. Ερωτήστε το κατάλληλο εύρος αντί αυτού και διατηρήστε τα επιστρεφόμενα κοντέινερ ώστε να μπορείτε να τα ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους αργότερα.

### **Ερώτηση Ευρών Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/) είναι διαθέσιμη μέσω των [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getHyperlinkQueries) και [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/#getHyperlinkQueries). Κάθε ευρύς υποστηρίζει τις ίδιες ερωτήσεις:

- [getHyperlinkClicks](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) επιστρέφει κοντέινερ με ενέργεια κλικ.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) επιστρέφει κοντέινερ με ενέργεια mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) επιστρέφει κοντέινερ με μία ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με έναν εξωτερικό σύνδεσμο κλικ, έναν σύνδεσμο αρχείου mouse‑over, εσωτερική πλοήγηση διαφάνειας, έναν σύνδεσμο κειμένου mouse‑over και μια ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι τρεις ερωτήσεις λειτουργούν σε κάθε ευρύς· οι μετρήσεις περιγράφουν κοντέινερ, όχι συνολικές ενέργειες. Το ευρύ πλαισίου κειμένου εξαιρεί τους συνδέσμους του περιβάλλοντος σχήματος.

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

Για αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας αναφέρουν τρία κοντέινερ κλικ, δύο κοντέινερ mouse‑over και τρία κοντέινερ με μία από τις δύο ενέργειες. Η ερώτηση πλαισίου κειμένου αναφέρει ένα κοντέινερ σε κάθε κατηγορία.

### **Κατηγοριοποίηση Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [Hyperlink.getActionType](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#getActionType) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερο από πλοήγηση ιστού:

| Τιμή | Σημασία για έλεγχο |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάντα. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Λήξη τρέχουσας εκδήλωσης ή εκκίνηση προσαρμοσμένης εκδήλωσης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Εκκίνηση προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από URL ιστού. |
| `StartStopMedia` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Καμία ενέργεια πλοήγησης ή άγνωστη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε εξωτερικούς προορισμούς από το [getExternalUrl](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#getExternalUrl) και συγκεκριμένους εσωτερικούς προορισμούς από το [getTargetSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#getTargetSlide). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το κοντέινερ δεν έχει ενέργεια. Διατηρήστε την τιμή που επιστρέφει το [getExternalUrlOriginal](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε το tooltip που επιστρέφει το [getTooltip](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlink/#getTooltip) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Το παρακάτω παράδειγμα Python διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιεί το αρχείο που δημιουργήθηκε προηγουμένως), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για επανέλεγχο και των δύο τύπων ενεργοποίησης. Συλλέγει κοντέινερ πριν τις αλλαγές και χρησιμοποιεί ισότητα αναφοράς για να αποφύγει διπλή επεξεργασία του ίδιου αντικειμένου. Οι ερωτήσεις παρουσίασης καλύπτουν τις κανονικές διαφάνειες· για απογραφή σε όλο το πακέτο, ερωτούν ρητά και τα master, layout, notes και τα master σημειώσεων/εκτυπώσεων όταν υπάρχουν.

Η αναφορά καταγράφει ένα δείκτη διαφάνειας που ξεκινά από το 1 και το [getSlideId](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getSlideId) όπου είναι διαθέσιμο. Το [getSlide](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getSlide) παρέχει τη διαφάντα ιδιοκτήτη για υποστηριζόμενα κοντέινερ. Τα master, layout και notes δεν έχουν κανονικό δείκτη διαφάνειας και τα προσδιορίζουμε με το ευρύ τους. Τα κοντέινερ σχήματος και μορφοποίησης τμημάτων κειμένου επισημαίνονται ξεχωριστά· άλλοι τύποι διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε κοντέινερ παίρνει ένα αναγνωριστικό τοπικής αναφοράς ώστε οι δύο του δράσεις να συσχετιστούν. Η αναφορά αποθηκεύει τους τύπους ενεργειών ως ακέραιες σταθερές του Java enum.

Αυτή η σκόπιμα περιοριστική πολιτική επιτρέπει μόνο απόλυτα HTTPS URLs και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείου, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Οι απορρίψεις είναι αποφάσεις πολιτικής, όχι ασφαλιστική απόφαση του Aspose.Slides. Το HTTPS από μόνο του δεν εγγυάται εμπιστοσύνη· προσθέστε λίστες επιτρεπόμενων hosts και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URLs. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί δράσεις.

Για αποκατάσταση, ο [getHyperlinkManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getHyperlinkManager) του κοντέινερ υποστηρίζει το [setExternalHyperlinkClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), το [removeHyperlinkClick](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) και το [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή HTTPS σελίδα προορισμού· οι άλλοι απαγορευμένοι κλικ και mouse‑over αφαιρούνται αυτόνομα. Ορίστε `replace_external_clicks` σε `False` για να αφαιρέσετε όλες τις παραβιάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή πριν την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια συντηρητική πολιτική ελέγχου PDF: σημαδάνει ενέργειες mouse‑over και οτιδήποτε εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα σε διαφάντα ως ενδεχόμενα μη υποστηριζόμενα. Είναι μια υπόδειξη ελέγχου, όχι δοκιμή ικανότητας ή εγγύηση ότι οι μη σημειωμένοι σύνδεσμοι θα παραμείνουν μετά την εξαγωγή. Οι υποστηριζόμενες εξαγωγές σε [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/python-java/convert-powerpoint-to-html/) ενδέχεται να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προβολέα. Raster [images](/slides/el/python-java/convert-powerpoint-to-png/) και [video](/slides/el/python-java/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαδάνετε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

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

Με το παραπάνω αρχείο εισόδου, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος αρχείου mouse‑over και το κλικ μακροεντολής αφαιρούνται, ενώ τα HTTPS links και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εκτυπώνει μηδέν απαγορευμένες ενέργειες. Ένα αρχείο εισόδου με απαγορευμένο εξωτερικό URL κλικ επίσης ενεργοποιεί το κλαδί αντικατάστασης. Ένα κοντέινερ με επιτρεπόμενο κλικ και απαγορευμένο mouse‑over διατηρεί το κλικ του.

Αυτή η επιλεκτική καθαριότητα διαφέρει από το [removeAllHyperlinks](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), το οποίο αφαιρεί και τους δύο τύπους ενεργοποίησης σε όλο το επιλεγμένο εύρος ανεξάρτητα από πολιτική. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες των υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα VBA projects, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο, και δεν επικυρώνει εξαγόμενο PDF ή HTML αρχείο.

## **FAQ**

**Πώς μπορώ να συνδέσω σε μια ενότητα ή στην πρώτη της διαφάντα;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μια μεμονωμένη διαφάντα. Για πλοήγηση σε ενότητα, συνδέστε στην πρώτη διαφάντα της ενότητας.

**Μπορώ να προσθέσω υπερσύνδεσμο σε στοιχεία master διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία master διαφάνειας και layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά την παρουσίαση στις διαφάνειες που χρησιμοποιούν το αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές PDF και HTML μπορεί να διατηρήσουν τους υπερσυνδέσμους· raster εικόνες και βίντεο όχι. Δείτε τις παρατηρήσεις εξαγωγής στο [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).