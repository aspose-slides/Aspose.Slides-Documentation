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
description: "Узнайте, как генерировать и изменять презентации PowerPoint и OpenDocument через VBA с помощью Aspose.Slides for Python via .NET для оптимизации вашего рабочего процесса."
---

## **Обзор**

В этой статье рассматриваются основные возможности Aspose.Slides for Python via .NET для работы с макросами в презентациях PowerPoint. Библиотека предоставляет удобные инструменты для добавления, удаления и извлечения макросов, что позволяет автоматизировать создание и модификацию презентаций.

С помощью Aspose.Slides вы можете:

- Ускорить разработку презентаций — автоматизация рутинных задач сокращает время, необходимое для подготовки материалов.
- Обеспечить гибкость — возможность управлять макросами позволяет адаптировать презентации под конкретные задачи и сценарии.
- Интегрировать данные — простая интеграция с внешними источниками данных помогает поддерживать содержимое слайдов в актуальном состоянии.
- Упростить обслуживание — централизованное управление макросами упрощает внесение изменений и обновление презентаций.

В статье представлены практические примеры того, как использовать Aspose.Slides для эффективной работы с макросами в PowerPoint.

Пространство имён [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) предоставляет классы для работы с макросами и кодом VBA.

{{% alert title="Примечание" color="warning" %}}

При конвертации презентации, содержащей макросы, в другой формат (PDF, HTML и т.д.) Aspose.Slides игнорирует макросы — они не переносятся в выходной файл.

При добавлении макросов в презентацию или повторном сохранении презентации, содержащей макросы, Aspose.Slides записывает байты макроса без изменений.

Aspose.Slides **никогда** не выполняет макросы в презентации.

{{% /alert %}}

## **Добавление макросов VBA**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) для создания проектов VBA (и ссылок на проекты) и редактирования существующих модулей.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) для добавления нового проекта VBA.
3. Добавьте модуль в проект VBA.
4. Задайте исходный код модуля.
5. Добавьте ссылку на `<stdole>`.
6. Добавьте ссылку на **Microsoft Office**.
7. Свяжите ссылки с проектом VBA.
8. Сохраните презентацию.

Ниже показан пример кода на Python, демонстрирующий, как добавить макрос VBA с нуля в презентацию:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Create a new VBA project.
    presentation.vba_project = slides.vba.VbaProject()

    # Add an empty module to the VBA project.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Set the module source code.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Create a reference to <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Create a reference to Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Add the references to the VBA project.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Save the presentation.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

Вы можете попробовать **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), бесплатное веб‑приложение для удаления макросов из документов PowerPoint, Excel и Word.

{{% /alert %}}

## **Удаление макросов VBA**

С помощью свойства [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) вы можете удалить макрос VBA.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Получите доступ к модулю макроса и удалите его.
3. Сохраните изменённую презентацию.

Ниже показан пример кода на Python, демонстрирующий, как удалить макрос VBA:

```python
import aspose.slides as slides

# Load the presentation that contains the macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Access the VBA module.
    vba_module = presentation.vba_project.modules[0]

    # Remove the VBA module.
    presentation.vba_project.modules.remove(vba_module)

    # Save the presentation.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Извлечение макросов VBA**

Используя свойство `modules` в классе [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) вы можете получить доступ ко всем модулям проекта VBA. Класс [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) позволяет извлекать свойства модуля, такие как имя и код.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Пройдитесь по всем модулям проекта VBA, чтобы просмотреть макросы.

Ниже показан пример кода на Python, демонстрирующий, как извлечь макросы VBA из презентации:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Проверка, защищён ли проект VBA паролем**

С помощью свойства [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) можно определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA‑проект](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
3. Убедитесь, что проект VBA защищён паролем, чтобы просмотреть его свойства.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **Часто задаваемые вопросы**

**Что происходит с макросами, если я сохраняю презентацию как PPTX?**

Макросы будут удалены, поскольку формат PPTX не поддерживает VBA. Чтобы сохранить макросы, выбирайте PPTM, PPSM или POTM.

**Может ли Aspose.Slides выполнять макросы внутри презентации, например, обновлять данные?**

Нет. Библиотека никогда не исполняет код VBA; выполнение возможно только внутри PowerPoint при соответствующих настройках безопасности.

**Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?**

Да, вы можете получить доступ к существующим [элементам управления ActiveX](/slides/ru/python-net/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.