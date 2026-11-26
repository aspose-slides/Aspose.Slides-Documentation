---
title: Διαχείριση ελεγκτών ActiveX σε παρουσιάσεις χρησιμοποιώντας Python
linktitle: ActiveX
type: docs
weight: 80
url: /el/python-java/activex/
keywords:
- ActiveX
- έλεγχος ActiveX
- διαχείριση ActiveX
- προσθήκη ActiveX
- τροποποίηση ActiveX
- αναπαραγωγέας πολυμέσων
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Επεξεργασία πλαισίων κειμένου και κουμπιών ActiveX, ενημέρωση προεπισκοπήσεων ελέγχων και επαναχρησιμοποίηση ελέγχου Windows Media Player σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω Java."
---
## **Εισαγωγή**

Οι έλεγχοι ActiveX προσφέρουν σε μια διαφάνεια PowerPoint διαδραστικά στοιχεία όπως πλαίσια κειμένου, κουμπιά εντολών και προγράμματα αναπαραγωγής πολυμέσων. Το Aspose.Slides για Python μέσω Java αποκαλύπτει τους ελέγχους μιας διαφάνειας μέσω του [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Χρησιμοποιήστε αυτή τη συλλογή για να επεξεργαστείτε έναν έλεγχο, να τον μετακινήσετε στη διαφάνεια ή να τον αφαιρέσετε.

## **Λίστα ελέγχων ActiveX και των αποθηκευμένων τους ιδιοτήτων**

Για να ελέγξετε ένα άγνωστο πρότυπο, ανοίξτε το για ανάγνωση και διατρέξτε τους ελέγχους σε κάθε διαφάνεια. Το παράδειγμα καταγράφει τον αριθμό της διαφάνειας, το όνομα του ελέγχου, το [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId) και κάθε ζεύγος κλειδιού‑τιμής στο [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Διαβάζει την παρουσίαση χωρίς να ενεργοποιεί τους ελέγχους, να καλεί συμβάντα ή μακροεντολές, να αλλάζει τιμές ή να αποθηκεύει το αρχείο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

Η επιλεγμένη έξοδος από το `ActiveX.pptm` εμφανίζει ένα πλαίσιο κειμένου και ένα κουμπί εντολής.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Μια κενή συλλογή ιδιοτήτων εμφανίζεται ως `[]`. Για ελέγχους που χρησιμοποιούν δυαδική αποθήκευση, το [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) μπορεί να επιστρέψει `None`, εμφανιζόμενο ως `Properties unavailable`. Εάν χρειάζεστε μόνο τα ονόματα, χρησιμοποιήστε το [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) μετά τον έλεγχο διαθεσιμότητας της συλλογής. Η αναφορά παραθέτει τις ιδιότητες που είναι διαθέσιμες στην παρουσίαση. Ένας έλεγχος μπορεί να υποστηρίζει πρόσθετες ιδιότητες κατά την εκτέλεση.

## **Τροποποίηση ελέγχων ActiveX**

Το παράδειγμα αναμένει μια παρουσίαση με δυνατότητα μακροεντολών που περιέχει ένα πλαίσιο κειμένου με όνομα `TextBox1` και ένα κουμπί εντολής με όνομα `CommandButton1` στην πρώτη διαφάνεια. Χρησιμοποιεί τη [συλλογή ιδιοτήτων ελέγχου](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) για να αλλάξει την τιμή του πλαισίου κειμένου και τη λεζάντα του κουμπιού. Κάθε έλεγχος διαθέτει επίσης μια στατική προεπισκόπηση που μπορεί να εμφανίσει το PowerPoint πριν από την ενεργοποίηση. Παρέχετε ένα PNG για κάθε έλεγχο που εμφανίζει το ενημερωμένο κείμενο και την εμφάνισή του. Το παράδειγμα αντιστοιχίζει αυτές τις εικόνες μέσω του [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

Το παράδειγμα μετακινεί κάθε έλεγχο στην πρώτη διαφάνεια προς τα κάτω κατά 100 μονάδες ορίζοντας το πλαίσιο του με το [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Αποθηκεύει την επεξεργασμένη παρουσίαση σε μορφή PPTM και στη συνέχεια χρησιμοποιεί το [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) για να αποθηκεύσει ένα δεύτερο αντίγραφο με όλους τους ελέγχους ActiveX που έχουν αφαιρεθεί από αυτή τη διαφάνεια.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```
## **Προσθήκη ελέγχου Media Player ActiveX**

Για να επαναχρησιμοποιήσετε έναν ρυθμισμένο έλεγχο Windows Media Player, ξεκινήστε με ένα πρότυπο της πρώτης διαφάνειας που περιέχει έναν παίκτη με όνομα `WindowsMediaPlayer1`. Το [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) αντιγράφει ολόκληρη τη διαφάνεια σε μια νέα παρουσίαση. Το παράδειγμα ορίζει το `URL` του παίκτη στη [συλλογή ιδιοτήτων](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) και αποθηκεύει τη κλωνοποιημένη διαφάνεια ως τη μοναδική διαφάνεια στην έξοδο. Το βίντεο παραμένει εξωτερικό, έτσι επιλέξτε μια διαδρομή που ο παίκτης μπορεί να προσπελάσει κατά την αναπαραγωγή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```
## **Συχνές ερωτήσεις**

**Μπορεί το Aspose.Slides να διατηρήσει τους ελέγχους ActiveX χωρίς να τους εκτελεί;**

Ναι. Το Aspose.Slides μπορεί να διαβάσει και να αποθηκεύσει ελέγχους, συμπεριλαμβανομένων των ιδιοτήτων και των θέσεών τους, χωρίς να τους ενεργοποιήσει.

**Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE;**

Οι έλεγχοι ActiveX επιτρέπουν στους χρήστες να αλληλεπιδρούν με μια διαφάνεια, για παράδειγμα εισάγοντας κείμενο ή πατώντας ένα κουμπί. Ένα [αντικείμενο OLE](/slides/el/python-java/manage-ole/) επιτρέπει σε μια διαφάνεια να περιέχει ή να συνδέεται με περιεχόμενο που διαχειρίζεται μια άλλη εφαρμογή, όπως ένα φύλλο εργασίας Excel.

**Θα ενεργοποιούν ακόμη τα συμβάντα ActiveX τις μακροεντολές VBA αφού αποθηκεύσω μια παρουσίαση με το Aspose.Slides;**

Αποθηκεύστε την παρουσίαση σε μορφή με δυνατότητα μακροεντολών, όπως PPTM, για να διατηρήσετε το έργο VBA της. Το PowerPoint για Windows μπορεί να εκτελέσει τους υπάρχοντες χειριστές συμβάντων όταν οι ρυθμίσεις ασφαλείας του επιτρέπουν τόσο τους ελέγχους ActiveX όσο και τις μακροεντολές.