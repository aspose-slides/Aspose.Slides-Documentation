---
title: Управление проектами VBA в презентациях с использованием Python
linktitle: Презентация через VBA
type: docs
weight: 250
url: /ru/python-java/presentation-via-vba/
keywords:
- макрос
- VBA
- макрос VBA
- добавить макрос
- удалить макрос
- извлечь макрос
- добавить VBA
- удалить VBA
- извлечь VBA
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как создавать и управлять презентациями PowerPoint и OpenDocument с помощью VBA, используя Aspose.Slides для Python через Java, чтобы оптимизировать ваш рабочий процесс."
---
## **Введение**

Aspose.Slides предоставляет классы и интерфейсы для работы с макросами и кодом VBA.

{{% alert title="Warning" color="warning" %}} 

При преобразовании презентации, содержащей макросы, в другой формат файла (PDF, HTML и т.д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в полученный файл).

Если вы добавляете макросы в презентацию или сохраняете презентацию, содержащую макросы, Aspose.Slides просто записывает байты макросов.

Aspose.Slides **никогда** не запускает макросы в презентации.

{{% /alert %}}

## **Добавление макросов VBA**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/ru/python-java/aspose.slides/vbaproject/), который позволяет создавать проекты VBA (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать класс [VbaProject](https://reference.aspose.com/slides/ru/python-java/aspose.slides/vbaproject/) для управления VBA, встроенным в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/ru/python-java/aspose.slides/vbaproject/#vbaproject) для добавления нового проекта VBA.
3. Добавьте модуль в проект VBA.
4. Установите исходный код модуля.
5. Добавьте ссылки на `stdole`.
6. Добавьте ссылки на **Microsoft Office**.
7. Свяжите ссылки с проектом VBA.
8. Сохраните презентацию.

Этот код на Python показывает, как добавить макрос VBA с нуля в презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Создать новый проект VBA.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Добавить пустой модуль и задать его исходный код.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Создать ссылки на stdole и Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Добавить ссылки в проект VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Сохранить презентацию.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Возможно, вам будет интересен **Aspose** [Macro Remover](https://products.aspose.app/slides/ru/remove-macros), бесплатное веб‑приложение для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удаление макросов VBA**

С помощью метода [getVbaProject](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getvbaproject) класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) можно удалить макрос VBA.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Получите модуль макроса и удалите его.
3. Сохраните изменённую презентацию.

Этот код на Python показывает, как удалить макрос VBA:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Загрузить презентацию, содержащую макрос.
presentation = Presentation("VBA.pptm")
try:
    # Получить доступ к модулю VBA и удалить его.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Сохранить презентацию.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Извлечение макросов VBA**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Пройдитесь по всем модулям, содержащимся в проекте VBA, чтобы просмотреть макросы.

Этот код на Python показывает, как извлечь макросы VBA из презентации, содержащей макросы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Загрузить презентацию, содержащую макрос.
presentation = Presentation("VBA.pptm")
try:
    # Проверить, содержит ли презентация проект VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Проверка, защищён ли проект VBA паролем**

С помощью метода [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/ru/python-java/aspose.slides/vbaproject/#ispasswordprotected) можно определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA project](https://reference.aspose.com/slides/ru/python-java/aspose.slides/vbaproject/).
3. Проверьте, защищён ли проект VBA паролем, чтобы просмотреть его свойства.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Проверить, содержит ли презентация проект VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**Что происходит с макросами, если я сохраняю презентацию как PPTX?**

Макросы будут удалены, потому что формат PPTX не поддерживает VBA. Чтобы сохранить макросы, выбирайте PPTM, PPSM или POTM.

**Может ли Aspose.Slides выполнять макросы внутри презентации, например, обновлять данные?**

Нет. Библиотека никогда не выполняет код VBA; выполнение возможно только в PowerPoint при соответствующих настройках безопасности.

**Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?**

Да, вы можете обращаться к существующим [ActiveX controls](/slides/ru/python-java/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.