---
title: VBA makro
type: docs
weight: 150
url: /cs/python-java/examples/elements/vba-macro/
keywords:
- příklad kódu
- VBA
- makro
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Přidávejte, přistupujte a odstraňujte VBA makra v prezentacích PowerPoint pomocí Aspose.Slides for Python via Java s jasnými a praktickými příklady kódu."
---
Tento článek ukazuje, jak pomocí **Aspose.Slides for Python via Java** přidávat, přistupovat k a odstraňovat VBA makra.

Balíček nainstalujte podle popisu v [Instalace](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a poté po spuštění JVM importuje API.

## **Přidat VBA makro**

Vytvořte prezentaci s VBA projektem a jednoduchým modulem makra.

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

## **Přístup k VBA makru**

Získejte první modul z VBA projektu.

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

## **Odstranit VBA makro**

Odstraňte modul z VBA projektu.

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