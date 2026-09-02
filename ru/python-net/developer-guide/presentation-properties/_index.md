---
title: Управление свойствами презентации с помощью Python
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/python-net/presentation-properties/
keywords:
- Свойства PowerPoint
- Свойства презентации
- Свойства документа
- Встроенные свойства
- Пользовательские свойства
- Расширенные свойства
- Управление свойствами
- Изменение свойств
- Метаданные документа
- Редактирование метаданных
- Язык проверки орфографии
- Язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides for Python via .NET и оптимизируйте поиск, брендинг и рабочие процессы в ваших файлах PowerPoint."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Оба типа свойств могут быть легко получены и управляемы с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами презентации через класс [DocumentProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/). Экземпляр этого класса возвращается свойством [Presentation.document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/document_properties/). Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Note" %}}
Обратите внимание, что вы не можете задавать значения для полей **Application** и **Producer**, потому что в этих полях будут отображаться Aspose Ltd. и Aspose.Slides for Python via .NET x.x.x.
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два типа свойств документа:

- Системные (Встроенные) свойства
- Пользовательские свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д. **Пользовательские** свойства – это пары **Имя/Значение**, определяемые пользователем. С помощью Aspose.Slides for Python via .NET разработчики могут получать и изменять значения как встроенных, так и пользовательских свойств. Microsoft PowerPoint 2007 позволяет управлять свойствами документов презентаций. Достаточно нажать значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007. После выбора **Advanced Properties** откроется диалоговое окно, позволяющее управлять свойствами файла PowerPoint. В **Properties Dialog** вы увидите несколько вкладок: **General, Summary, Statistics, Contents и Custom**. Все эти вкладки позволяют настраивать различную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Доступ к встроенным свойствам**
Эти свойства, представленные объектом **IDocumentProperties**, включают: **Creator(Author)**, **Description**, **Keywords**, **Created** (дата создания), **Modified** (дата изменения), **Printed** (дата последней печати), **LastModifiedBy**, **SharedDoc** (общий доступ между различными производителями?), **PresentationFormat**, **Subject** и **Title**.
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего презентацию
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Создать ссылку на объект, связанный с презентацией
    documentProperties = pres.document_properties

    # Вывести встроенные свойства
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Изменение встроенных свойств**

Изменять встроенные свойства файлов презентаций так же просто, как их получать. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего презентацию
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Создать ссылку на объект, связанный с презентацией
    documentProperties = presentation.document_properties

    # Установить встроенные свойства
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Сохранить презентацию в файл
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление пользовательских свойств презентации**

Aspose.Slides for Python via .NET также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже приведён пример, показывающий, как установить пользовательские свойства для презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Получение свойств документа
    documentProperties = presentation.document_properties

    # Добавление пользовательских свойств
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Получение имени свойства по определённому индексу
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Удаление выбранного свойства
    documentProperties.remove_custom_property(getPropertyName)

    # Сохранение презентации
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Python via .NET также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, показывающий, как получить и изменить все эти пользовательские свойства для презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Создать ссылку на объект document_properties, связанный с презентацией
    documentProperties = presentation.document_properties

    # Доступ и изменение пользовательских свойств
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Показать имена и значения пользовательских свойств
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Изменить значения пользовательских свойств
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Сохранить презентацию в файл
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` возвращает значение через одноэлементный список, переданный вторым аргументом, и сохранённое значение приводится к типу элемента, уже находящегося в этом списке. В примере используется `[""]`, поэтому читаются строковые свойства; чтобы прочитать свойство, сохранённое как число, передайте числовой плейсхолдер, например `[0]` — иначе вызов бросит `InvalidCastException`.

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство `Language_Id` (представленное классом [PortionFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/)) для установки языка проверки орфографии в документе PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот код на Python демонстрирует, как установить язык проверки орфографии для PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # установить идентификатор языка проверки
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Установка языка по умолчанию**

Этот код на Python демонстрирует, как установить язык по умолчанию для всей презентации PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Живой пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **Часто задаваемые вопросы**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и не могут быть полностью удалены. Однако вы можете изменить их значения или установить пустое значение, если это допускается для конкретного свойства.

**Что происходит, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Не требуется предварительно удалять или проверять свойство, так как Aspose.Slides автоматически обновляет его значение.

**Могу ли я получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) и затем [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/read_document_properties/) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). См. пример полного отчёта и ограничения форматов в разделе [Build a Lightweight Presentation Inventory](/slides/ru/python-net/examine-presentation/).