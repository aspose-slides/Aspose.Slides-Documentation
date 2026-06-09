---
title: VbaMacro
type: docs
weight: 150
url: /el/python-net/examples/elements/vba-macro/
keywords:
- μακροεντολή VBA
- προσθήκη μακροεντολής VBA
- πρόσβαση σε μακροεντολή VBA
- αφαίρεση μακροεντολής VBA
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εργαστείτε με μακροεντολές VBA σε Python χρησιμοποιώντας το Aspose.Slides: προσθέστε ή επεξεργαστείτε έργα και μονάδες, υπογράψτε ή αφαιρέστε μακροεντολές και αποθηκεύστε παρουσιάσεις σε PPT, PPTX και ODP."
---
Παρουσιάζει πώς να προσθέσετε, να αποκτήσετε πρόσβαση και να αφαιρέσετε μακροεντολές VBA χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη μακροεντολής VBA**

Δημιουργήστε μια παρουσίαση με ένα έργο VBA και μια απλή μονάδα μακροεντολών.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Αρχικοποιήστε ένα έργο VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Προσθέστε μια κενή μονάδα με όνομα "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Πρόσβαση σε μακροεντολή VBA**

Ανακτήστε την πρώτη μονάδα από το έργο VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Αφαίρεση μακροεντολής VBA**

Διαγράψτε μια μονάδα από το έργο VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Υποθέτουμε ότι η παρουσίαση περιέχει ένα έργο VBA και τουλάχιστον μία μονάδα.
        module = presentation.vba_project.modules[0]

        # Αφαιρέστε τη μονάδα από το έργο.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```