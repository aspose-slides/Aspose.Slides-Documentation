---
title: Управление VBA проектами в презентациях с помощью Python
linktitle: Презентация через VBA
type: docs
weight: 250
url: /ru/python-net/presentation-via-vba/
keywords:
- макрос
- VBA
- VBA макрос
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
description: "Узнайте, как создавать и управлять презентациями PowerPoint и OpenDocument через VBA с помощью Aspose.Slides для Python через .NET, чтобы оптимизировать ваш рабочий процесс."
---

## **Обзор**

Эта статья рассматривает основные возможности Aspose.Slides для Python через .NET по работе с макросами в презентациях PowerPoint. Библиотека предоставляет удобные инструменты для добавления, удаления и извлечения макросов, что позволяет автоматизировать создание и изменение презентаций.

- Ускорьте разработку презентаций — автоматизация рутинных задач сокращает время, необходимое для подготовки материалов.
- Обеспечьте гибкость — возможность управлять макросами позволяет адаптировать презентации под конкретные задачи и сценарии.
- Интегрируйте данные — простая интеграция с внешними источниками данных помогает поддерживать актуальность содержимого слайдов.
- Упростите обслуживание — централизованное управление макросами облегчает внесение изменений и обновление презентаций.

В статье также представлены практические примеры того, как использовать Aspose.Slides для эффективной работы с макросами в PowerPoint.

Пространство имён aspose.slides.vba предоставляет классы для работы с макросами и кодом VBA.

{{% alert title="Note" color="warning" %}}
При конвертации презентации, содержащей макросы, в другой формат (PDF, HTML и т.д.), Aspose.Slides игнорирует макросы — они не передаются в файл вывода.

Когда вы добавляете макросы в презентацию или сохраняете заново презентацию, содержащую макросы, Aspose.Slides записывает байты макросов без изменений.

Aspose.Slides **никогда** не выполняет макросы в презентации.
{{% /alert %}}

## **Добавление VBA макросов**

Aspose.Slides предоставляет класс VbaProject для создания VBA проектов (и ссылок на проекты) и редактирования существующих модулей.

1. Создайте экземпляр класса Presentation.  
2. Используйте конструктор VbaProject для добавления нового VBA проекта.  
3. Добавьте модуль в VBA проект.  
4. Установите исходный код модуля.  
5. Добавьте ссылку на `<stdole>`.  
6. Добавьте ссылку на **Microsoft Office**.  
7. Свяжите ссылки с VBA проектом.  
8. Сохраните презентацию.

Следующий пример на Python показывает, как добавить VBA макрос с нуля в презентацию:

```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:

    # Создайте новый VBA проект.
    presentation.vba_project = slides.vba.VbaProject()

    # Добавьте пустой модуль в VBA проект.
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

    # Добавьте ссылки в VBA проект.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Сохраните презентацию.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
Возможно, вы захотите попробовать **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), бесплатное веб‑приложение для удаления макросов из документов PowerPoint, Excel и Word.
{{% /alert %}}

## **Удаление VBA макросов**

Используя свойство vba_project класса Presentation, вы можете удалить VBA макрос.

1. Создайте экземпляр класса Presentation и загрузите презентацию, содержащую макрос.  
2. Получите доступ к модулю макроса и удалите его.  
3. Сохраните изменённую презентацию.

Следующий пример на Python показывает, как удалить VBA макрос:

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

## **Извлечение VBA макросов**

Используя свойство `modules` в классе VbaProject, вы можете получить доступ ко всем модулям VBA проекта. Класс VbaModule можно использовать для извлечения свойств модуля, таких как имя и код.

1. Создайте экземпляр класса Presentation и загрузите презентацию, содержащую макрос.  
2. Проверьте, содержит ли презентация VBA проект.  
3. Пройдите по всем модулям VBA проекта, чтобы просмотреть макросы.

Следующий пример на Python показывает, как извлечь VBA макросы из презентации:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Проверьте, содержит ли презентация VBA проект.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Проверка, защищён ли VBA проект паролем**

Используя свойство VbaProject.is_password_protected, вы можете определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса Presentation и загрузите презентацию, содержащую макрос.  
2. Проверьте, содержит ли презентация VBA проект.  
3. Проверьте, защищён ли VBA проект паролем, чтобы просмотреть его свойства.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Проверьте, содержит ли презентация VBA проект.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **Часто задаваемые вопросы**

**Что происходит с макросами, если я сохраняю презентацию как PPTX?**

Макросы будут удалены, так как PPTX не поддерживает VBA. Чтобы сохранить макросы, выберите PPTM, PPSM или POTM.

**Может ли Aspose.Slides запускать макросы внутри презентации, например, для обновления данных?**

Нет. Библиотека никогда не выполняет VBA‑код; выполнение возможно только внутри PowerPoint при соответствующих настройках безопасности.

**Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?**

Да, вы можете обращаться к существующим [ActiveX controls](/slides/ru/python-net/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.