---
title: Презентация через VBA
type: docs
weight: 250
url: /ru/python-net/presentation-via-vba/
keywords: "Макрос, макросы, VBA, макрос VBA, добавить макрос, удалить макрос, добавить VBA, удалить VBA, извлечь макрос, извлечь VBA, макрос PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавление, удаление и извлечение VBA макросов в презентациях PowerPoint на Python"
---

Пространство имен [Aspose.Slides.Vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) содержит классы и интерфейсы для работы с макросами и кодом VBA.

{{% alert title="Примечание" color="warning" %}} 

Когда вы конвертируете презентацию, содержащую макросы, в другой формат файла (PDF, HTML и т. д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в результирующий файл).

Когда вы добавляете макросы в презентацию или повторно сохраняете презентацию, содержащую макросы, Aspose.Slides просто записывает байты для макросов.

Aspose.Slides **никогда** не выполняет макросы в презентации.

{{% /alert %}}

## **Добавление VBA макросов**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/), который позволяет создавать проекты VBA (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать интерфейс [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) для управления VBA, встроенной в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) для добавления нового проекта VBA.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с проектом VBA.
1. Сохраните презентацию.

Этот код на Python показывает, как добавить макрос VBA с нуля в презентацию:

```python
import aspose.slides as slides

# Создает экземпляр класса презентации
with slides.Presentation() as presentation:
    # Создает новый VBA проект
    presentation.vba_project = slides.vba.VbaProject()

    # Добавляет пустой модуль в проект VBA
    module = presentation.vba_project.modules.add_empty_module("Module")
  
    # Устанавливает исходный код модуля
    module.source_code = "Sub Test(oShape As Shape) MsgBox ""Test"" End Sub"

    # Создает ссылку на <stdole>
    stdoleReference = slides.vba.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Создает ссылку на Office
    officeReference =slides.vba.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Библиотека объектов Microsoft Office 14.0")

    # Добавляет ссылки в проект VBA
    presentation.vba_project.references.add(stdoleReference)
    presentation.vba_project.references.add(officeReference)

            
    # Сохраняет презентацию
    presentation.save("AddVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}} 

Вы можете ознакомиться с **Aspose** [Удалением макросов](https://products.aspose.app/slides/remove-macros), это бесплатное веб-приложение, используемое для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удаление VBA макросов**

Используя свойство [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#properties) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), вы можете удалить VBA макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю Макрос и удалите его.
1. Сохраните измененную презентацию.

Этот код на Python показывает, как удалить VBA макрос:

```python
import aspose.slides as slides

# Загружает презентацию, содержащую макрос
with slides.Presentation(path + "VBA.pptm") as presentation:
    # Получает доступ к Vba модулю и удаляет его  
    presentation.vba_project.modules.remove(presentation.vba_project.modules[0])

    # Сохраняет презентацию
    presentation.save("RemovedVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Извлечение VBA макросов**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Пройдите через все модули, содержащиеся в проекте VBA, чтобы просмотреть макросы.

Этот код на Python показывает, как извлечь VBA макросы из презентации, содержащей макросы:

```python
import aspose.slides as slides

with slides.Presentation(path + "VBA.pptm") as pres:
    if pres.vba_project is not None: # Проверяет содержит ли презентация проект VBA
        for module in pres.vba_project.modules:
            print(module.name)
            print(module.source_code)
```