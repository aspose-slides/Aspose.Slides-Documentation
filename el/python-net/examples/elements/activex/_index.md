---
title: ActiveX
type: docs
weight: 200
url: /el/python-net/examples/elements/activex/
keywords:
- ActiveX
- Έλεγχος ActiveX
- Προσθήκη ActiveX
- Πρόσβαση ActiveX
- Κατάργηση ActiveX
- Ιδιότητες ActiveX
- Παραδείγματα κώδικα
- PowerPoint
- Παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να βρείτε, να επεξεργαστείτε και να καταργήσετε ελέγχους ActiveX στην Python με το Aspose.Slides, συμπεριλαμβανομένων των ενημερώσεων ιδιοτήτων για παρουσιάσεις PowerPoint."
---
Δείχνει πώς να προσθέσετε, να αποκτήσετε πρόσβαση, να καταργήσετε και να διαμορφώσετε ελέγχους ActiveX σε μια παρουσίαση χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη ελέγχου ActiveX**

Εισάγετε ένα νέο έλεγχο ActiveX.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Προσθήκη νέου ελέγχου ActiveX (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Πρόσβαση σε έλεγχο ActiveX**

Διαβάστε πληροφορίες από τον πρώτο έλεγχο ActiveX στη διαφάνεια.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Πρόσβαση στον πρώτο έλεγχο ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Εκτύπωση του ονόματος του ελέγχου.
            print(f"Control Name: {control.name}")
```

## **Κατάργηση ελέγχου ActiveX**

Διαγράψτε έναν υπάρχοντα έλεγχο ActiveX από τη διαφάνεια.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Κατάργηση του πρώτου ελέγχου ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Ορισμός ιδιοτήτων ActiveX**

Διαμορφώστε αρκετές ιδιότητες ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι η συλλογή Controls περιέχει τουλάχιστον έναν Control.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```