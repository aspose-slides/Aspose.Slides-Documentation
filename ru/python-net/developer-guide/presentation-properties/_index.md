---
title: "Управление свойствами презентации с помощью Python"
linktitle: "Свойства презентации"
type: docs
weight: 70
url: /ru/python-net/presentation-properties/
keywords:
  - "Свойства PowerPoint"
  - "Свойства презентации"
  - "Свойства документа"
  - "Встроенные свойства"
  - "Пользовательские свойства"
  - "Расширенные свойства"
  - "Управление свойствами"
  - "Изменение свойств"
  - "Метаданные документа"
  - "Редактирование метаданных"
  - "Язык проверки орфографии"
  - "Язык по умолчанию"
  - "PowerPoint"
  - "OpenDocument"
  - "презентация"
  - "Python"
  - "Aspose.Slides"
description: "Освойте свойства презентаций в Aspose.Slides for Python via .NET и оптимизируйте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint."
---

## **О свойствах презентации**

Как мы уже описали ранее, Aspose.Slides for Python via .NET поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Поэтому разработчики могут получать доступ к обоим типам свойств с помощью API Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/), который представляет свойства документа, связанные с файлом презентации через свойство [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Разработчики могут использовать свойство [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/), предоставляемое объектом **Presentation**, чтобы получить доступ к свойствам документа презентаций, как описано ниже:

{{% alert color="primary" %}}Обратите внимание, что вы не можете задать значения для полей **Application** и **Producer**, так как вместо них будут отображаться Aspose Ltd. и Aspose.Slides for Python via .NET x.x.x.{{% /alert %}}

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два типа свойств документа:

- Системные (встроенные) свойства
- Пользовательские (кастомные) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как название, имя автора, статистика и т.д. **Пользовательские** свойства — это пары **Имя/Значение**, определяемые пользователем. С помощью Aspose.Slides for Python via .NET разработчики могут получать и изменять как встроенные, так и пользовательские свойства. Microsoft PowerPoint 2007 позволяет управлять свойствами документа презентаций. Достаточно нажать значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007. После выбора пункта **Advanced Properties** появится диалоговое окно, позволяющее управлять свойствами документа PowerPoint. В **Properties Dialog** отображаются вкладки **General, Summary, Statistics, Contents и Custom**. Все эти вкладки позволяют настраивать различную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом **IDocumentProperties**, включают: **Creator(Author)**, **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Общий документ?), **PresentationFormat**, **Subject** и **Title**.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего презентацию
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
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

Изменять встроенные свойства файлов презентаций так же просто, как получать их. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже демонстрируется, как изменить встроенные свойства документа презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего презентацию
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
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

Aspose.Slides for Python via .NET также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже приведён пример, показывающий, как задать пользовательские свойства для презентации.

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

    # Получение имени свойства по заданному индексу
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Удаление выбранного свойства
    documentProperties.remove_custom_property(getPropertyName)

    # Сохранение презентации
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Python via .NET также позволяет разработчикам получать значения пользовательских свойств и изменять их. Ниже пример, показывающий, как получить и изменить все пользовательские свойства презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Создать ссылку на объект document_properties, связанный с презентацией
    documentProperties = presentation.document_properties

    # Доступ и изменение пользовательских свойств
    for i in range(documentProperties.count_of_custom_properties):
        # Вывести имена и значения пользовательских свойств
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Изменить значения пользовательских свойств
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Сохранить презентацию в файл
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство `Language_Id` (предоставляемое классом [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) для установки языка проверки орфографии в документе PowerPoint. Язык проверки орфографии — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот пример на Python показывает, как установить язык проверки орфографии для PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # установить Id языка проверки орфографии
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Установка языка по умолчанию**

Этот пример на Python показывает, как установить язык по умолчанию для всей презентации PowerPoint:

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

## **Онлайн‑пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако вы можете изменить их значения или установить пустую строку, если это допускается конкретным свойством.

**Что произойдет, если я добавлю пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Удалять или проверять существование свойства заранее не требуется — Aspose.Slides автоматически обновит значение свойства.

**Можно ли получить свойства презентации без полного её загрузки?**

Да, свойства презентации можно получить без полной загрузки, используя метод [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) класса [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/). Затем примените метод [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) класса [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/), чтобы эффективно считывать свойства, экономя память и повышая производительность.