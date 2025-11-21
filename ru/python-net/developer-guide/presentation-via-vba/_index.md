---
title: Управление проектами VBA в презентациях с помощью Python
linktitle: Презентация через VBA
type: docs
weight: 250
url: /ru/python-net/presentation-via-vba/
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
- Aspose.Slides
description: "Узнайте, как создавать и манипулировать презентациями PowerPoint и OpenDocument через VBA с помощью Aspose.Slides for Python via .NET, чтобы оптимизировать ваш рабочий процесс."
---

## **Обзор**

В этой статье рассматриваются основные возможности Aspose.Slides for Python via .NET для работы с макросами в презентациях PowerPoint. Библиотека предоставляет удобные средства для добавления, удаления и извлечения макросов, что позволяет автоматизировать создание и изменение презентаций.

С помощью Aspose.Slides вы можете:

- Ускорить разработку презентаций — автоматизация рутинных задач сокращает время подготовки материалов.
- Обеспечить гибкость — возможность управлять макросами позволяет адаптировать презентации к конкретным задачам и сценариям.
- Интегрировать данные — простая интеграция с внешними источниками данных помогает поддерживать актуальность содержимого слайдов.
- Упростить сопровождение — централизованное управление макросами облегчает внесение изменений и обновление презентаций.

Статья также содержит практические примеры использования Aspose.Slides для эффективной работы с макросами в PowerPoint.

Пространство имён [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) предоставляет классы для работы с макросами и кодом VBA.

{{% alert title="Note" color="warning" %}}
При конвертации презентации, содержащей макросы, в другой формат (PDF, HTML и др.) Aspose.Slides игнорирует макросы — они не переносятся в выходной файл.

При добавлении макросов в презентацию или повторном сохранении презентации, содержащей макросы, Aspose.Slides записывает байты макроса без изменений.

Aspose.Slides **никогда** не исполняет макросы в презентации.
{{% /alert %}}

## **Добавление макросов VBA**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) для создания проектов VBA (и ссылок на проекты) и редактирования существующих модулей.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) для добавления нового проекта VBA.
1. Добавьте модуль в проект VBA.
1. Установите исходный код модуля.
1. Добавьте ссылку на `<stdole>`.
1. Добавьте ссылку на **Microsoft Office**.
1. Свяжите ссылки с проектом VBA.
1. Сохраните презентацию.

Ниже приведён пример кода на Python, показывающий, как добавить макрос VBA с нуля в презентацию:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:

    # Создайте новый проект VBA.
    presentation.vba_project = slides.vba.VbaProject()

    # Добавьте пустой модуль в проект VBA.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Установите исходный код модуля.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Создайте ссылку на <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Создайте ссылку на Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Добавьте ссылки в проект VBA.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Сохраните презентацию.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```


{{% alert color="primary" %}}
Вы можете попробовать **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), бесплатное веб‑приложение для удаления макросов из документов PowerPoint, Excel и Word.
{{% /alert %}}

## **Удаление макросов VBA**

С помощью свойства [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) можно удалить макрос VBA.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю макроса и удалите его.
1. Сохраните изменённую презентацию.

Ниже показан пример кода на Python, демонстрирующий удаление макроса VBA:
```python
import aspose.slides as slides

# Загрузите презентацию, содержащую макрос.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Получите доступ к VBA модулю.
    vba_module = presentation.vba_project.modules[0]

    # Удалите VBA модуль.
    presentation.vba_project.modules.remove(vba_module)

    # Сохраните презентацию.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```


## **Извлечение макросов VBA**

Используя свойство `modules` класса [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/), можно получить доступ ко всем модулям проекта VBA. Класс [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) позволяет извлечь свойства модуля, такие как имя и код.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
1. Проверьте, содержит ли презентация проект VBA.
1. Пройдитесь по всем модулям проекта VBA, чтобы просмотреть макросы.

Ниже приведён пример кода на Python, показывающий, как извлечь макросы VBA из презентации:
```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Проверьте, содержит ли презентация проект VBA.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```


## **Проверка, защищён ли проект VBA паролем**

С помощью свойства [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) можно определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
1. Проверьте, содержит ли презентация [VBA project](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
1. Проверьте, защищён ли проект VBA паролем, чтобы просмотреть его свойства.
```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Проверьте, содержит ли презентация проект VBA.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```


## **Вопросы и ответы**

**Что происходит с макросами, если я сохраняю презентацию как PPTX?**

Макросы удаляются, поскольку формат PPTX не поддерживает VBA. Чтобы сохранить макросы, выбирайте PPTM, PPSM или POTM.

**Может ли Aspose.Slides выполнять макросы внутри презентации, например, обновлять данные?**

Нет. Библиотека никогда не исполняет код VBA; исполнение возможно только в PowerPoint при соответствующих настройках безопасности.

**Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?**

Да, вы можете получать доступ к существующим [ActiveX controls](/slides/ru/python-net/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.