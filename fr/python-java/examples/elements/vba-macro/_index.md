---
title: Macro VBA
type: docs
weight: 150
url: /fr/python-java/examples/elements/vba-macro/
keywords:
- exemple de code
- VBA
- macro
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Ajouter, accéder et supprimer des macros VBA dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Python via Java avec des exemples de code clairs et pratiques."
---
Cet article montre comment ajouter, accéder et supprimer des macros VBA en utilisant **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API une fois la JVM en cours d'exécution.

## **Ajouter une macro VBA**

Créez une présentation avec un projet VBA et un module de macro simple.

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

## **Accéder à une macro VBA**

Récupérez le premier module du projet VBA.

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

## **Supprimer une macro VBA**

Supprimez un module du projet VBA.

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