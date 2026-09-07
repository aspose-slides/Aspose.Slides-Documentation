---
title: "VBA-Makro"
type: docs
weight: 150
url: /de/python-java/examples/elements/vba-macro/
keywords:
- "Codebeispiel"
- VBA
- Makro
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "VBA-Makros in PowerPoint-Präsentationen mit Aspose.Slides für Python via Java hinzufügen, darauf zugreifen und entfernen – mit klaren, praxisnahen Codebeispielen."
---
Dieser Artikel zeigt, wie man VBA‑Makros mit **Aspose.Slides for Python via Java** hinzufügt, darauf zugreift und sie entfernt.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jedes Beispiel importiert `asposeslides`, bevor die JVM gestartet wird, und importiert dann die API, nachdem die JVM läuft.

## **VBA‑Makro hinzufügen**

Erstellen Sie eine Präsentation mit einem VBA‑Projekt und einem einfachen Makromodul.

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

## **Auf ein VBA‑Makro zugreifen**

Rufen Sie das erste Modul aus dem VBA‑Projekt ab.

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

## **VBA‑Makro entfernen**

Löschen Sie ein Modul aus dem VBA‑Projekt.

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