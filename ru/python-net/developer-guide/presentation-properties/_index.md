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
- Презентация
- Python
- Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides for Python via .NET и упростите поиск, брендинг и рабочий процесс в ваших файлах PowerPoint."
---

## **О свойствах презентации**

Как мы описали ранее, Aspose.Slides for Python via .NET поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Поэтому разработчики могут получать доступ к обоим типам свойств с помощью API Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/), который представляет свойства документа, связанные с файлом презентации, через свойство [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Разработчики могут использовать свойство [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/), доступное через объект **Presentation**, чтобы получить доступ к свойствам документа презентации, как описано ниже:

{{% alert color="primary" %}} 
Обратите внимание, что вы не можете задавать значения полям **Application** и **Producer**, так как в этих полях будет отображаться Aspose Ltd. и Aspose.Slides for Python via .NET x.x.x. 
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два вида свойств документа:

- Системные (встроенные) свойства
- Пользовательские (настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д. **Пользовательские** свойства – это пары **Имя/Значение**, которые определяются пользователем. С помощью Aspose.Slides for Python via .NET разработчики могут получать доступ и изменять значения как встроенных, так и пользовательских свойств. Microsoft PowerPoint 2007 позволяет управлять свойствами документа презентации. Для этого достаточно нажать значок Office и выбрать пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007. После выбора пункта **Advanced Properties** появится диалоговое окно, позволяющее управлять свойствами документа PowerPoint‑файла. В **Properties Dialog** вы увидите несколько вкладок: **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настраивать различную информацию, связанную с PowerPoint‑файлами. Вкладка **Custom** используется для управления пользовательскими свойствами PowerPoint‑файлов.

## **Доступ к встроенным свойствам**
Эти свойства, доступные через объект **IDocumentProperties**, включают: **Creator(Author)**, **Description**, **Keywords**, **Created** (дата создания), **Modified** (дата изменения), **Printed** (дата последней печати), **LastModifiedBy**, **SharedDoc** (общий документ?), **PresentationFormat**, **Subject** и **Title**  
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

Изменять встроенные свойства файлов презентаций так же просто, как их получать. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации.  
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

    # Получение имени свойства по индексу
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Удаление выбранного свойства
    documentProperties.remove_custom_property(getPropertyName)

    # Сохранение презентации
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Доступ и изменение пользовательских свойств**

Aspose.Slides for Python via .NET также позволяет разработчикам получать доступ к значениям пользовательских свойств. Ниже приведён пример, показывающий, как получить доступ и изменить все эти пользовательские свойства для презентации.  
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Создать ссылку на объект document_properties, связанный с презентацией
    documentProperties = presentation.document_properties

    # Доступ и изменение пользовательских свойств
    for i in range(documentProperties.count_of_custom_properties):
        # Отобразить имена и значения пользовательских свойств
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Изменить значения пользовательских свойств
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Сохранить презентацию в файл
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство `Language_Id` (доступное через класс [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки орфографии — это язык, для которого проверяются правописание и грамматика в PowerPoint.

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

    # set the Id of a proofing language
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

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако вы можете изменить их значения или установить пустое значение, если это допускается конкретным свойством.

**Что происходит, если я добавляю пользовательское свойство, которое уже существует?**

Если вы добавляете пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Удалять или проверять наличие свойства заранее не требуется — Aspose.Slides автоматически обновит значение свойства.

**Могу ли я получить доступ к свойствам презентации без полной загрузки её содержимого?**

Да, вы можете получить доступ к свойствам презентации без полной загрузки, используя метод [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) класса [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/). Затем используйте метод [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) класса [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/), чтобы эффективно читать свойства, экономя память и повышая производительность.