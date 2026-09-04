---
title: Управление свойствами презентации с Python
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
- Язык проверки правописания
- Язык по умолчанию
- PowerPoint
- OpenDocument
- Презентация
- Python
- Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides for Python via .NET и оптимизируйте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Оба этих типа свойств легко доступны и управляются с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами презентации через класс [DocumentProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/). Экземпляр этого класса возвращается свойством [Presentation.document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/document_properties/). Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Примечание" %}}

Обратите внимание, что значения полей **Application** и **Producer** установить нельзя, потому что в этих полях будет отображаться Aspose Ltd. и Aspose.Slides for Python via .NET x.x.x.

{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два вида свойств документа:

- Системные (встроенные) свойства
- Пользовательские свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д. **Пользовательские** свойства определяются пользователем как пары **Имя/Значение**, где и имя, и значение задаются пользователем. С помощью Aspose.Slides for Python via .NET разработчики могут получать доступ к значениям как встроенных, так и пользовательских свойств и изменять их. Microsoft PowerPoint 2007 позволяет управлять свойствами документов файлов презентаций. Достаточно нажать значок Office и выбрать пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007. После выбора пункта **Advanced Properties** откроется диалоговое окно, позволяющее управлять свойствами файла PowerPoint. В **Properties Dialog** вы увидите несколько вкладок: **General, Summary, Statistics, Contents и Custom**. Все эти вкладки позволяют настраивать различную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Чтение публичных свойств из зашифрованной презентации**

Пароль открытия обычно защищает как содержимое презентации, так и свойства документа. Когда презентация зашифрована с помощью [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) со значением `False`, её свойства документа остаются публичными. Приложение может установить [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/only_load_document_properties/) в `True` и прочитать публичные метаданные без указания пароля открытия.

`only_load_document_properties` управляет тем, что загружает Aspose.Slides; он ничего не расшифровывает. Если свойства включены в шифрование, их загрузка без пароля завершится неудачей. Если презентация не зашифрована, опция игнорируется и загружается вся презентация.

Следующий пример проверяет режим загрузки через [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/ru/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) и затем читает встроенные свойства через [Presentation.document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения всегда должны проверять `is_only_document_properties_loaded` перед выполнением операций, требующих полной модели объектов презентации.

{{% alert color="warning" title="Безопасность" %}}
Публичные метаданные могут раскрывать имена авторов, заголовки, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Оставляйте их публичными только в случае, если системы индексации, классификации, поиска или управления документами требуют доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная с `only_load_document_properties`, предназначена для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из такого объекта только с метаданными, потому что публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому их обновление требует правильного пароля открытия и полной загрузки.

Следующий пример открывает презентацию с помощью [LoadOptions.password](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/password/), обновляет публичные встроенные свойства и сохраняет результат. Затем он использует [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/is_encrypted/) для проверки сохранения шифрования и снова открывает публичные метаданные без пароля, чтобы проверить новые значения:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Если приложению не разрешено расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**
Эти свойства, представленные объектом **IDocumentProperties**, включают: **Creator(Author)**, **Description**, **Keywords**, **Created** (дата создания), **Modified** (дата изменения), **Printed** (дата последней печати), **LastModifiedBy**, **SharedDoc** (общий документ?), **PresentationFormat**, **Subject** и **Title**
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего презентацию
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Создать ссылку на объект, связанный с Presentation
    documentProperties = pres.document_properties

    # Отобразить встроенные свойства
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

Изменять встроенные свойства файлов презентаций так же просто, как получать к ним доступ. Достаточно присвоить строковое значение желаемому свойству, и значение будет изменено. В примере ниже показано, как можно изменить встроенные свойства документа презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего презентацию
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Создать ссылку на объект, связанный с Presentation
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

Aspose.Slides for Python via .NET также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, показывающий, как получить доступ и изменить все эти пользовательские свойства презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Создать ссылку на объект document_properties, связанный с Presentation
    documentProperties = presentation.document_properties

    # Доступ и изменение пользовательских свойств
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Отобразить имена и значения пользовательских свойств
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Изменить значения пользовательских свойств
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Сохранить презентацию в файл
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` возвращает значение через одноэлементный список, переданный вторым аргументом, и сохранённое значение приводится к типу элемента, уже находящегося в этом списке. В примере выше используется `[""]`, поэтому читаются строковые свойства; чтобы прочитать свойство, хранящееся как число, передайте числовой заполнитель, например `[0]` — в противном случае вызов бросит `InvalidCastException`.

## **Установка языка проверки правописания**

Aspose.Slides предоставляет свойство `Language_Id` (доступное через класс [PortionFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/)) для установки языка проверки правописания в документе PowerPoint. Язык проверки правописания — это язык, для которого проверяется орфография и грамматика в PowerPoint.

Этот Python‑код показывает, как установить язык проверки правописания для PowerPoint:

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

    # установить Id языка проверки правописания
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Установка языка по умолчанию**

Этот Python‑код показывает, как установить язык по умолчанию для всей презентации PowerPoint:

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

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако вы можете изменить их значения или установить их пустыми, если это допускает конкретное свойство.

**Что происходит, если я добавляю пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Нет необходимости удалять или проверять свойство заранее, так как Aspose.Slides автоматически обновляет его значение.

**Могу ли я получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/get_presentation_info/) и затем [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/read_document_properties/) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). См. [Build a Lightweight Presentation Inventory](/slides/ru/python-net/examine-presentation/) для полного примера отчёта и ограничений, зависящих от формата.

**Могу ли я читать публичные свойства зашифрованной презентации без её пароля открытия?**

Да. Презентация должна быть зашифрована с параметром `encrypt_document_properties`, установленным в `False`, и должна быть загружена с `only_load_document_properties`, установленным в `True`.

**Можно ли обновить зашифрованный файл PPTX в режиме только‑свойств‑документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.