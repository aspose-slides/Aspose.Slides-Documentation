---
title: VBA-macro
type: docs
weight: 150
url: /nl/python-java/examples/elements/vba-macro/
keywords:
- codevoorbeeld
- VBA
- macro
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Voeg VBA-macro's toe, benader ze en verwijder ze in PowerPoint-presentaties met Aspose.Slides voor Python via Java, met duidelijke, praktische code-voorbeelden."
---
Dit artikel laat zien hoe u VBA-macro's kunt toevoegen, benaderen en verwijderen met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert vervolgens de API nadat de JVM actief is.

## **Een VBA-macro toevoegen**

Maak een presentatie met een VBA-project en een eenvoudige macro‑module.

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

## **Een VBA-macro benaderen**

Haal de eerste module op uit het VBA-project.

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

## **Een VBA-macro verwijderen**

Verwijder een module uit het VBA-project.

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