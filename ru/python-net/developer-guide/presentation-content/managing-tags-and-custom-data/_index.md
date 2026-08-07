---
title: Управление тегами и пользовательскими данными в презентациях с Python
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/python-net/managing-tags-and-custom-data/
keywords:
- свойства документа
- тег
- пользовательские данные
- пользовательский XML
- часть пользовательского XML
- XML‑метаданные
- ItemId
- добавить тег
- парные значения
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять тегами и пользовательскими XML‑данными в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET, включая добавление, чтение, обновление, аудит и удаление пользовательских XML‑частей."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Данные, специфичные для презентации, могут храниться в виде тегов или пользовательских XML‑частей. Теги — простые пары «ключ‑значение» строкового типа, тогда как пользовательские XML‑части могут хранить структурированные метаданные и XML‑полезные нагрузки, специфичные для приложения.

Aspose.Slides предоставляет API для добавления, чтения, обновления, аудита и удаления пользовательских XML‑частей на уровне презентации, слайда и shape. Пользовательские XML‑части полезны для интеграций, где необходимо хранить такие сведения, как идентификаторы систем управления документами, состояние рабочего процесса, метаданные соответствия, данные привязки шаблонов или другие структурированные данные приложения внутри презентации.

## **Хранение данных в файлах презентаций**

Файлы PPTX — файлы с расширением `.pptx` — сохраняются в формате PresentationML, который является частью спецификации Office Open XML. Office Open XML определяет структуру пакета и отношения, используемые для хранения содержимого презентации и связанных данных.

Презентация состоит из нескольких частей, связанных отношениями. Например, часть слайда содержит содержимое одного слайда и может иметь явные отношения с другими частями, определёнными в ISO/IEC 29500.

Пользовательские данные могут храниться в виде тегов ([TagCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/)) или пользовательских XML‑частей ([CustomXmlPartCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpartcollection/)). Оба варианта доступны через класс [`CustomData`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customdata/).

{{% alert color="primary" %}}
Теги хранят простые строковые пары «ключ‑значение». Пользовательские XML‑части хранят структурированные XML‑данные и могут быть ассоциированы с презентацией, слайдом или shape.
{{% /alert %}}

## **Работа с пользовательскими XML‑частями**

Свойство [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customdata/custom_xml_parts/) возвращает коллекцию пользовательских XML‑частей, связанных с конкретным объектом презентации. Например:

- `presentation.custom_data.custom_xml_parts` содержит пользовательские XML‑части, связанные с самой презентацией.
- `slide.custom_data.custom_xml_parts` содержит пользовательские XML‑части, связанные с конкретным слайдом.
- `shape.custom_data.custom_xml_parts` содержит пользовательские XML‑части, связанные с конкретным shape.

Используйте [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/all_custom_xml_parts/) когда необходимо просмотреть все пользовательские XML‑части в презентации независимо от того, к чему они привязаны.

### **Добавление пользовательской XML‑части в презентацию**

Используйте [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpartcollection/add/) для добавления XML‑данных в коллекцию пользовательских XML‑частей. XML должен быть корректным и непустым.

Следующий пример добавляет структурированные метаданные в коллекцию пользовательских данных уровня презентации:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add автоматически назначает идентификатор. Устанавливайте конкретный GUID только при необходимости.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Метод `add` также может принимать XML в виде массива байтов или потока, что полезно, когда XML‑контент уже доступен в бинарной форме.

### **Добавление пользовательской XML‑части в слайд или shape**

Пользовательские XML‑данные могут быть связаны с конкретным слайдом или shape вместо всей презентации. Это удобно, когда метаданные описывают лишь один объект, например, ключ шаблона, внешний идентификатор записи или сведения о привязке.

Следующий пример добавляет одну пользовательскую XML‑часть в слайд и другую — в shape:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Уровень, на котором добавлена часть, определяет, чья коллекция `custom_data.custom_xml_parts` будет содержать связь с этой частью. Данные уровня презентации подходят для метаданных, охватывающих весь документ, данные уровня слайда — для информации, относящейся к конкретному слайду, а данные уровня shape — для метаданных, привязанных к отдельному shape.

### **Список и аудит всех пользовательских XML‑частей**

Используйте [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/all_custom_xml_parts/) для получения всех пользовательских XML‑частей из презентации. Каждый [`CustomXmlPart`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpart/) раскрывает свой идентификатор, XML‑содержимое и связанные схемы пространств имён.

Следующий пример выводит список всех пользовательских XML‑частей и их схем пространств имён:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpart/namespace_schemas/) возвращает XML‑схемы, связанные с пользовательской XML‑частью. Эта информация может быть полезна при аудите презентаций, содержащих XML, созданный внешними системами.

### **Чтение и обновление XML‑содержимого и ItemId**

Используйте [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpart/xml_as_string/) для работы с XML как строкой UTF‑8, либо [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpart/xml_data/) для работы с необработанными байтами XML. Оба свойства могут быть прочитаны и обновлены.

Свойство [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpart/item_id/) содержит GUID, идентифицирующий пользовательскую XML‑часть в документе Office Open XML. Его также можно изменить, если интеграции требуется новый идентификатор.

Следующий пример обновляет XML‑содержимое и идентификатор:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Прочитать текущее XML как текст.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Обновить XML как строку UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data предоставляет тот же XML‑контент в виде необработанных байтов.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Заменить идентификатор, когда это требуется интеграции.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

При присвоении `xml_as_string` или `xml_data` предоставляйте корректный, непустой XML. Используйте один из вариантов в зависимости от того, работает ли приложение преимущественно со строками или с байтовыми данными.

### **Удаление пользовательской XML‑части**

Aspose.Slides предоставляет несколько способов удаления пользовательских XML‑данных:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpart/remove/) удаляет пользовательскую XML‑часть из презентации.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpartcollection/remove/) удаляет конкретную часть из коллекции пользовательских XML‑частей.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpartcollection/remove_at/) удаляет часть по заданному индексу в коллекции.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/customxmlpartcollection/clear/) удаляет все части из конкретной коллекции.

Следующий пример удаляет одну пользовательскую XML‑часть уровня презентации по ссылке:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Если у вас уже есть объект `CustomXmlPart` и вы хотите удалить эту часть из презентации, а не из определённой коллекции, вызовите `custom_xml_part.remove()`.

Вы также можете удалить элемент по индексу:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Очистка всех пользовательских XML‑частей в коллекции**

Используйте `clear`, когда необходимо удалить все пользовательские XML‑части, связанные с определённым объектом презентации.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` влияет только на выбранную коллекцию. Например, очистка коллекции слайда не очищает коллекции уровня презентации или shape.

Чтобы удалить каждую пользовательскую XML‑часть в презентации, пройдитесь по `all_custom_xml_parts` и удалите каждую часть:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Работа со связанными или общими пользовательскими XML‑частями**

В презентации Office Open XML одна и та же пользовательская XML‑часть может быть упомянута более чем одним объектом презентации. Например, существующий файл может содержать отношения от нескольких слайдов или shape к одной и той же базовой пользовательской XML‑части.

Общая часть должна рассматриваться как один объект данных с несколькими ссылками:

- Обновление её `xml_as_string`, `xml_data` или `item_id` меняет базовую пользовательскую XML‑часть, поэтому изменение применяется во всех местах, где она упомянута.
- `item_id` можно использовать для идентификации одной и той же пользовательской XML‑части при аудите коллекций объектов.
- Удаление части из конкретной коллекции `custom_xml_parts` удаляет её только из этой коллекции. Используйте `CustomXmlPart.remove()` когда нужно удалить саму часть из презентации.
- Перед удалением или заменой общей части проверьте коллекции объектов, чтобы определить, ссылаются ли на неё другие слайды или shape.

Перегруженные варианты `add` создают новую пользовательскую XML‑часть из XML‑контента; они не принимают существующий `CustomXmlPart`. Поэтому общие отношения чаще всего встречаются при загрузке презентаций, уже содержащих такие связи.

Следующий пример аудирует коллекции уровня презентации, слайда и shape по `item_id` и сообщает о частях, упомянутых более чем в одном месте:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Такой аудит полезен перед изменением или удалением пользовательских XML‑данных в презентациях, созданных внешними системами, поскольку одна и та же метаданные часть может участвовать в нескольких отношениях.

## **Получение значений тегов**

В Slides тег соответствует свойству `DocumentProperties.keywords`. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Python via .NET для [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов:

- имени пользовательского свойства, например `MyTag`;
- значения пользовательского свойства, например `My Tag Value`.

Если необходимо классифицировать презентации по определённому правилу или свойству, можно добавить соответствующие теги. Например, чтобы категоризировать презентации из стран Северной Америки, можно создать тег “NorthAmerican” и задать соответствующую страну в качестве его значения.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) с помощью Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Теги можно также установить для [Slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Или для отдельного [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Ограничения**

Теги, добавленные через коллекцию `custom_data.tags`, хранятся только в файле PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, присвоенный как тег, нельзя получить из PDF‑файла с тегами.

**Обходной путь**: можно сохранить пользовательский идентификатор в **Alt Text** объекта (например, `shape.alternative_text = "MyId"`). После экспорта в PDF Alt Text может появиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все теги из презентации, слайда или shape одной операцией?**

Да. Коллекция [tag collection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/clear/), которая удаляет все пары «ключ‑значение» сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте [remove(name)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/) для удаления тега по ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [get_names_of_tags](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/get_names_of_tags/) у [tag collection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.

**Как найти все пользовательские XML‑части независимо от места их хранения?**

Используйте [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/all_custom_xml_parts/) для получения всех пользовательских XML‑частей в презентации.

**Что лучше использовать для обновления пользовательской XML‑части: `xml_as_string` или `xml_data`?**

Используйте `xml_as_string`, когда приложение работает с текстом XML в кодировке UTF‑8. Используйте `xml_data`, когда XML уже доступен в виде массива байтов или когда удобнее работать с бинарными данными. Оба свойства представляют одно и то же XML‑содержимое пользовательской части.