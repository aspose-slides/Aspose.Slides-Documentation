---
title: VBA‑макрос
type: docs
weight: 150
url: /ru/python-java/examples/elements/vba-macro/
keywords:
- пример кода
- VBA
- макрос
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Добавьте, получайте доступ и удаляйте VBA‑макросы в презентациях PowerPoint с помощью Aspose.Slides for Python via Java, используя понятные практические примеры кода."
---
Эта статья демонстрирует, как добавить, получить доступ и удалить VBA‑макросы, используя **Aspose.Slides for Python via Java**.

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, затем импортирует API после того, как JVM запущена.

## **Добавить VBA‑макрос**

Создайте презентацию с проектом VBA и простым модулем макросов.

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

## **Получить доступ к VBA‑макросу**

Получите первый модуль из проекта VBA.

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

## **Удалить VBA‑макрос**

Удалите модуль из проекта VBA.

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