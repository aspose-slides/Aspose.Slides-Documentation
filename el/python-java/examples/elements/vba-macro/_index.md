---
title: Μακροεντολή VBA
type: docs
weight: 150
url: /el/python-java/examples/elements/vba-macro/
keywords:
- παράδειγμα κώδικα
- VBA
- μακροεντολή
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Προσθέστε, αποκτήστε πρόσβαση και αφαιρέστε μακροεντολές VBA σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω Java με σαφή, πρακτικά παραδείγματα κώδικα."
---
Αυτό το άρθρο παρουσιάζει πώς να προσθέσετε, να αποκτήσετε πρόσβαση και να αφαιρέσετε μακροεντολές VBA χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Εγκατάσταση](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και στη συνέχεια εισάγει το API αφού η JVM είναι σε λειτουργία.

## **Προσθήκη μακροεντολής VBA**

Δημιουργήστε μια παρουσίαση με ένα έργο VBA και μια απλή μονάδα μακροεντολής.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')
finally:
    presentation.dispose()
```

## **Πρόσβαση σε μακροεντολή VBA**

Ανακτήστε την πρώτη μονάδα από το έργο VBA.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    first_module = presentation.getVbaProject().getModules().get_Item(0)
finally:
    presentation.dispose()
```

## **Αφαίρεση μακροεντολής VBA**

Διαγράψτε μια μονάδα από το έργο VBA.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    presentation.getVbaProject().getModules().remove(module)
finally:
    presentation.dispose()
```