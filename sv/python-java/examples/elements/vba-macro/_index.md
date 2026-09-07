---
title: VBA-makro
type: docs
weight: 150
url: /sv/python-java/examples/elements/vba-macro/
keywords:
- kodexempel
- VBA
- makro
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lägg till, få åtkomst till och ta bort VBA-makron i PowerPoint-presentationer med Aspose.Slides för Python via Java med tydliga, praktiska kodexempel."
---
Den här artikeln visar hur du lägger till, får åtkomst till och tar bort VBA-makron med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:et när JVM körs.

## **Lägg till ett VBA-makro**

Skapa en presentation med ett VBA-projekt och en enkel makromodul.

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

## **Få åtkomst till ett VBA-makro**

Hämta den första modulen från VBA-projektet.

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

## **Ta bort ett VBA-makro**

Ta bort en modul från VBA-projektet.

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