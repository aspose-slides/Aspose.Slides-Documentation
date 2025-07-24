---
title: Управляйте свойствами презентации в Python
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/python-net/presentation-properties/
keywords:
- свойства PowerPoint
- свойства презентации
- свойства документа
- встроенные свойства
- пользовательские свойства
- расширенные свойства
- управление свойствами
- изменение свойств
- метаданные документа
- редактирование метаданных
- язык проверки орфографии
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Освойте работу со свойствами презентаций в Aspose.Slides for Python via .NET и упростите поиск, брендинг и рабочие процессы в ваших файлах PowerPoint."
---


## **Пример в реальном времени**
Попробуйте [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) онлайн-приложение, чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **О свойствах презентации**
Как мы уже описали ранее, Aspose.Slides для Python через .NET поддерживает два типа свойств документа: **Встроенные** и **Пользовательские** свойства. Таким образом, разработчики могут получать доступ к обоим типам свойств с использованием API Aspose.Slides для Python через .NET. Aspose.Slides для Python через .NET предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/), который представляет свойства документа, связанные с файлом презентации через свойство [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Разработчики могут использовать свойство [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/), предоставляемое объектом **Presentation**, для доступа к свойствам документа файлов презентации, как описано ниже:



{{% alert color="primary" %}} 

Обратите внимание, что вы не можете устанавливать значения для полей **Application** и **Producer**, потому что Aspose Ltd. и Aspose.Slides для Python через .NET x.x.x будут отображаться в этих полях.

{{% /alert %}} 


## **Управление свойствами презентации**
Microsoft PowerPoint предоставляет функцию добавления некоторых свойств к файлам презентации. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентации). Существует два типа свойств документа:

- Определенные системой (Встроенные) свойства
- Определенные пользователем (Пользовательские) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок документа, имя автора, статистика документа и так далее. **Пользовательские** свойства — это те, которые определены пользователями в виде пар **Имя/Значение**, где и имя, и значение определяются пользователем. С помощью Aspose.Slides для Python через .NET разработчики могут получать доступ и изменять значения встроенных свойств, а также пользовательских свойств. Microsoft PowerPoint 2007 позволяет управлять свойствами документов файлов презентации. Все, что вам нужно сделать, это щелкнуть значок Office и далее выбрать пункт меню **Подготовка | Свойства | Расширенные свойства** в Microsoft PowerPoint 2007. После того как вы выберете пункт меню **Расширенные свойства**, появится диалоговое окно, позволяющее управлять свойствами документа PowerPoint. В диалоговом окне **Свойства** вы можете видеть, что есть множество вкладок, таких как **Общие, Сводка, Статистика, Содержимое и Пользовательские**. Все эти вкладки позволяют настраивать различные виды информации, связанные с файлами PowerPoint. Вкладка **Пользовательские** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Доступ к встроенным свойствам**
Эти свойства, предоставленные объектом **IDocumentProperties**, включают: **Автор**, **Описание**, **Ключевые слова**, **Дата создания**, **Дата изменения**, **Дата последнего печати**, **Последний сохранитель**, **Ключевые слова**, **Общий документ** (Общий между разными производителями?), **Формат презентации**, **Тема** и **Заголовок**
```py
import aspose.slides as slides

# Создаем экземпляр класса Presentation, представляющего презентацию
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Создаем ссылку на объект, связанный с презентацией
    documentProperties = pres.document_properties

    # Отображаем встроенные свойства
    print("категория : " + documentProperties.category)
    print("Текущий статус : " + documentProperties.content_status)
    print("Дата создания : " + str(documentProperties.created_time))
    print("Автор : " + documentProperties.author)
    print("Описание : " + documentProperties.comments)
    print("Ключевые слова : " + documentProperties.keywords)
    print("Последний изменитель : " + documentProperties.last_saved_by)
    print("Руководитель : " + documentProperties.manager)
    print("Дата изменения : " + str(documentProperties.last_saved_time))
    print("Формат презентации : " + documentProperties.presentation_format)
    print("Дата последней печати : " + str(documentProperties.last_printed))
    print("Общий между производителями : " + str(documentProperties.shared_doc))
    print("Тема : " + documentProperties.subject)
    print("Заголовок : " + documentProperties.title)
```
## **Изменение встроенных свойств**
Изменять встроенные свойства файлов презентации так же просто, как и получать к ним доступ. Вы можете просто присвоить строковое значение любому желаемому свойству, и значение свойства будет изменено. В приведенном ниже примере мы продемонстрировали, как мы можем изменить встроенные свойства документа файла презентации.

```py
import aspose.slides as slides

# Создаем экземпляр класса Presentation, представляющего презентацию
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Создаем ссылку на объект, связанный с презентацией
    documentProperties = presentation.document_properties

    # Устанавливаем встроенные свойства
    documentProperties.author = "Aspose.Slides для .NET"
    documentProperties.title = "Изменение свойств презентации"
    documentProperties.subject = "Тема Aspose"
    documentProperties.comments = "Описание Aspose"
    documentProperties.manager = "Менеджер Aspose"

    # сохраняем вашу презентацию в файл
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление пользовательских свойств презентации**
Aspose.Slides для Python через .NET также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Пример приведен ниже и показывает, как установить пользовательские свойства для презентации.

```py
import aspose.slides as slides

# Создаем экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Получение свойств документа
    documentProperties = presentation.document_properties

    # Добавление пользовательских свойств
    documentProperties.set_custom_property_value("Новое пользовательское", 12)
    documentProperties.set_custom_property_value("Мое имя", "Мудассир")
    documentProperties.set_custom_property_value("Пользовательское", 124)

    # Получение имени свойства по определенному индексу
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Удаление выбранного свойства
    documentProperties.remove_custom_property(getPropertyName)

    # Сохранение презентации
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ и изменение пользовательских свойств**
Aspose.Slides для Python через .NET также позволяет разработчикам получать доступ к значениям пользовательских свойств. Пример приведен ниже и показывает, как вы можете получить доступ и изменить все эти пользовательские свойства для презентации.

```py
import aspose.slides as slides

# Создаем экземпляр класса Presentation, представляющего PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Создаем ссылку на объект document_properties, связанный с презентацией
    documentProperties = presentation.document_properties

    # Доступ и изменение пользовательских свойств
    for i in range(documentProperties.count_of_custom_properties):
        # Отображаем имена и значения пользовательских свойств
        print("Имя пользовательского свойства : " + documentProperties.get_custom_property_name(i))
        print("Значение пользовательского свойства : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Изменяем значения пользовательских свойств
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "Новое значение " + str(i + 1))
    # сохраняем вашу презентацию в файл
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверка, была ли изменена или создана презентация**
Aspose.Slides для Python через .NET предоставляет возможность проверить, была ли изменена или создана презентация. Пример приведен ниже и показывает, как проверить, создана ли или изменена презентация.

```py
import aspose.slides as slides

info =slides.PresentationFactory.instance.get_presentation_info(path + "AccessModifyingProperties.pptx")
props = info.read_document_properties()

print(props.name_of_application)
print(props.app_version)
```

## **Установка языка проверки**

Aspose.Slides предоставляет свойство `Language_Id` (представленное классом [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)), чтобы позволить вам установить язык проверки для документа PowerPoint. Язык проверки - это язык, для которого проверяются правописание и грамматика в PowerPoint.

Этот код Python показывает, как установить язык проверки для PowerPoint:

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

    # Устанавливаем идентификатор языка проверки
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Установка языка по умолчанию**

Этот код Python показывает, как установить язык по умолчанию для целой презентации PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "Новый текст"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```