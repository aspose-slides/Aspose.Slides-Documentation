---
title: VbaMacro
type: docs
weight: 150
url: /ru/python-net/examples/elements/vba-macro/
keywords:
- макрос VBA
- добавить макрос VBA
- получить доступ к макросу VBA
- удалить макрос VBA
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Работайте с макросами VBA в Python с помощью Aspose.Slides: добавляйте или редактируйте проекты и модули, подписывайте или удаляйте макросы и сохраняйте презентации в форматах PPT, PPTX и ODP."
---
Иллюстрирует, как добавлять, получать доступ и удалять макросы VBA с помощью **Aspose.Slides for Python via .NET**.

## **Добавить макрос VBA**

Создайте презентацию с проектом VBA и простым модулем макроса.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Инициализировать проект VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Добавить пустой модуль с именем "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Получить доступ к макросу VBA**

Получите первый модуль из проекта VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Удалить макрос VBA**

Удалите модуль из проекта VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Предполагая, что презентация содержит проект VBA и как минимум один модуль.
        module = presentation.vba_project.modules[0]

        # Удалить модуль из проекта.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```