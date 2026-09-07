---
title: Macro VBA
type: docs
weight: 150
url: /es/python-java/examples/elements/vba-macro/
keywords:
- ejemplo de código
- VBA
- macro
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Añadir, acceder y eliminar macros VBA en presentaciones de PowerPoint usando Aspose.Slides para Python a través de Java con ejemplos de código claros y prácticos."
---
Este artículo muestra cómo agregar, acceder y eliminar macros VBA usando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y luego importa la API una vez que la JVM está en ejecución.

## **Agregar una macro VBA**

Cree una presentación con un proyecto VBA y un módulo de macro sencillo.

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

## **Acceder a una macro VBA**

Recupere el primer módulo del proyecto VBA.

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

## **Eliminar una macro VBA**

Elimine un módulo del proyecto VBA.

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