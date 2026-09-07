---
title: Makro VBA
type: docs
weight: 150
url: /pl/python-java/examples/elements/vba-macro/
keywords:
- przykład kodu
- VBA
- makro
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dodawaj, uzyskuj dostęp i usuwaj makra VBA w prezentacjach PowerPoint przy użyciu Aspose.Slides for Python via Java, z jasnymi, praktycznymi przykładami kodu."
---
Ten artykuł pokazuje, jak dodawać, uzyskiwać dostęp i usuwać makra VBA przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Add a VBA Macro**

Utwórz prezentację z projektem VBA i prostym modułem makr.

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

## **Access a VBA Macro**

Pobierz pierwszy moduł z projektu VBA.

```python
import jpide
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

## **Remove a VBA Macro**

Usuń moduł z projektu VBA.

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