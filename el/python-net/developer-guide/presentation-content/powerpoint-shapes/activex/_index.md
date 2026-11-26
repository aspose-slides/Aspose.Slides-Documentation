---
title: Διαχείριση ελέγχων ActiveX σε παρουσιάσεις με Python
linktitle: ActiveX
type: docs
weight: 80
url: /el/python-net/activex/
keywords:
- ActiveX
- Έλεγχος ActiveX
- διαχείριση ActiveX
- προσθήκη ActiveX
- τροποποίηση ActiveX
- πρόγραμμα αναπαραγωγής μέσων
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Επεξεργασία πλαισίων κειμένου και κουμπιών ActiveX, ενημέρωση προεπισκοπήσεων ελέγχων και επαναχρησιμοποίηση ελέγχου Windows Media Player σε παρουσιάσεις PowerPoint με το Aspose.Slides για Python μέσω .NET."
---
## **Εισαγωγή**

Οι έλεγχοι ActiveX παρέχουν σε μια διαφάνεια PowerPoint διαδραστικά στοιχεία όπως πλαίσια κειμένου, κουμπιά εντολών και προγράμματα αναπαραγωγής πολυμέσων. Το Aspose.Slides για Python μέσω .NET εκθέτει τους ελέγχους μιας διαφάνειας μέσω του [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Χρησιμοποιήστε αυτή τη συλλογή για να επεξεργαστείτε έναν έλεγχο, να τον μετακινήσετε στη διαφάνεια ή να τον αφαιρέσετε.

## **Καταγραφή ελέγχων ActiveX και των αποθηκευμένων ιδιοτήτων τους**

Για να εξετάσετε ένα άγνωστο πρότυπο, ανοίξτε το για ανάγνωση και επαναλάβετε τους ελέγχους σε κάθε διαφάνεια. Το παράδειγμα εμφανίζει τον αριθμό της διαφάνειας, το όνομα του ελέγχου, το [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), και κάθε ζεύγος κλειδί‑τιμή στα [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Διαβάζει την παρουσίαση χωρίς να ενεργοποιεί τους ελέγχους, να καλεί γεγονότα ή μακροεντολές, να αλλάζει τιμές ή να αποθηκεύει το αρχείο.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
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

Μια κενή συλλογή ιδιοτήτων εμφανίζεται ως `[]`. Για ελέγχους που χρησιμοποιούν δυαδική αποθήκευση, το `properties` μπορεί να επιστρέψει `None`, που εμφανίζεται ως `Properties unavailable`. Εάν χρειάζεστε μόνο τα ονόματα, χρησιμοποιήστε το [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) μετά τον έλεγχο για `None`. Η αναφορά καταγράφει τις ιδιότητες που διατίθενται από την παρουσίαση. Ένας έλεγχος ενδέχεται να υποστηρίζει πρόσθετες ιδιότητες κατά την εκτέλεση.

## **Τροποποίηση ελέγχων ActiveX**

Το παράδειγμα προϋποθέτει μια παρουσίαση με δυνατότητα μακροεντολών που περιέχει ένα πλαίσιο κειμένου με όνομα `TextBox1` και ένα κουμπί εντολής με όνομα `CommandButton1` στην πρώτη διαφάνεια. Χρησιμοποιεί τη [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) για να αλλάξει την τιμή του πλαισίου κειμένου και τη λεζάντα του κουμπιού. Κάθε έλεγχος διαθέτει επίσης μια στατική προεπισκόπηση που το PowerPoint μπορεί να εμφανίσει πριν από την ενεργοποίηση. Παρέχετε ένα αρχείο PNG για κάθε έλεγχο που να εμφανίζει το ενημερωμένο κείμενο και την εμφάνισή του. Το παράδειγμα αντιστοιχίζει αυτές τις εικόνες μέσω του [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

Το παράδειγμα μετακινεί κάθε έλεγχο στην πρώτη διαφάνεια προς τα κάτω κατά 100 σημεία αλλάζοντας το [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Αποθηκεύει την επεξεργασμένη παρουσίαση σε μορφή PPTM και, στη συνέχεια, χρησιμοποιεί το [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) για να αποθηκεύσει ένα δεύτερο αντίγραφο με όλους τους ελέγχους ActiveX αφαιρεμένους από τη διαφάνεια.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```
## **Προσθήκη ελέγχου Media Player ActiveX**

Για να επαναχρησιμοποιήσετε έναν ρυθμισμένο έλεγχο Windows Media Player, ξεκινήστε με ένα πρότυπο της πρώτης διαφάνειας που περιέχει έναν αναπαραγωγέα με όνομα `WindowsMediaPlayer1`. Το [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) αντιγράφει ολόκληρη τη διαφάνεια σε μια νέα παρουσίαση. Το παράδειγμα ορίζει τη `URL` του αναπαραγωγέα στη [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) του και αποθηκεύει τη κλωνοποιημένη διαφάνεια ως τη μοναδική διαφάνεια στην έξοδο. Το βίντεο παραμένει εξωτερικό, έτσι επιλέξτε μια διαδρομή που ο αναπαραγωγέας μπορεί να προσπελάσει κατά την αναπαραγωγή.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```
## **Συχνές ερωτήσεις**

**Μπορεί το Aspose.Slides να διατηρήσει τους ελέγχους ActiveX χωρίς να τους εκτελέσει;**

Ναι. Το Aspose.Slides μπορεί να διαβάσει και να αποθηκεύσει τους ελέγχους, συμπεριλαμβανομένων των ιδιοτήτων και των θέσεών τους, χωρίς να τους ενεργοποιήσει.

**Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE;**

Οι έλεγχοι ActiveX επιτρέπουν στους χρήστες να αλληλεπιδρούν με μια διαφάνεια, για παράδειγμα εισάγοντας κείμενο ή κάνοντας κλικ σε ένα κουμπί. Ένα [OLE object](/slides/el/python-net/manage-ole/) επιτρέπει μια διαφάνεια να περιέχει ή να συνδέεται με περιεχόμενο που διαχειρίζεται μια άλλη εφαρμογή, όπως ένα φύλλο εργασίας Excel.

**Θα εξακολουθούν τα γεγονότα ActiveX να ενεργοποιούν μακροεντολές VBA μετά την αποθήκευση μιας παρουσίασης με το Aspose.Slides;**

Αποθηκεύστε την παρουσίαση σε μορφή που υποστηρίζει μακροεντολές, όπως PPTM, για να διατηρήσετε το έργο VBA. Το PowerPoint για Windows μπορεί να εκτελέσει τους υπάρχοντες διαχειριστές γεγονότων όταν οι ρυθμίσεις ασφαλείας του επιτρέπουν τόσο τους ελέγχους ActiveX όσο και τις μακροεντολές.