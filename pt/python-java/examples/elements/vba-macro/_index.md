---
title: Macro VBA
type: docs
weight: 150
url: /pt/python-java/examples/elements/vba-macro/
keywords:
- exemplo de código
- VBA
- macro
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Adicionar, acessar e remover macros VBA em apresentações PowerPoint usando Aspose.Slides para Python via Java com exemplos de código claros e práticos."
---
Este artigo demonstra como adicionar, acessar e remover macros VBA usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM e, em seguida, importa a API após a JVM estar em execução.

## **Adicionar uma Macro VBA**

Crie uma apresentação com um projeto VBA e um módulo de macro simples.

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

## **Acessar uma Macro VBA**

Recupere o primeiro módulo do projeto VBA.

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

## **Remover uma Macro VBA**

Exclua um módulo do projeto VBA.

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