---
title: Управление тегами и пользовательскими данными в презентациях с использованием Python
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/python-java/managing-tags-and-custom-data/
keywords:
- свойства документа
- тег
- пользовательские данные
- пользовательский XML
- часть пользовательского XML
- метаданные XML
- ItemId
- добавить тег
- парные значения
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять тегами и пользовательскими данными XML в презентациях PowerPoint с помощью Aspose.Slides для Python через Java, включая добавление, чтение, обновление, аудит и удаление пользовательских XML‑частей."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Данные, специфичные для презентации, могут храниться в виде тегов или пользовательских XML‑частей. Теги — это простые пары ключ‑значение в виде строк, тогда как пользовательские XML‑части могут содержать структурированные метаданные и XML‑полезные нагрузки, специфичные для приложения.

Aspose.Slides предоставляет API для добавления, чтения, обновления, аудита и удаления пользовательских XML‑частей на уровнях презентации, слайда и фигуры. Пользовательские XML‑части полезны для интеграций, где необходимо хранить такие сведения, как идентификаторы систем управления документами, состояние рабочего процесса, метаданные соответствия, данные привязки шаблона или другие структурированные данные приложения внутри презентации.

## **Хранение данных в файлах презентаций**

Файлы PPTX — файлы с расширением `.pptx` — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Office Open XML определяет структуру пакета и отношения, используемые для хранения содержимого презентации и связанных данных.

Презентация состоит из нескольких частей, соединённых отношениями. Например, часть слайда содержит содержимое одного слайда и может иметь явные отношения с другими частями, определёнными в ISO/IEC 29500.

Пользовательские данные могут храниться в виде тегов ([TagCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tagcollection/)) или пользовательских XML‑частей ([CustomXmlPartCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpartcollection/)). Оба доступны через класс [CustomData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Note" %}}
Теги хранят простые строковые пары ключ‑значение. Пользовательские XML‑части хранят структурированные XML‑данные и могут быть связаны с презентацией, слайдом или фигурой.
{{% /alert %}}

## **Работа с пользовательскими XML‑частями**

Метод [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customdata/#getCustomXmlParts) возвращает коллекцию пользовательских XML‑частей, связанных с конкретным объектом презентации. Например:

- Коллекция [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customdata/#getCustomXmlParts) презентации содержит пользовательские XML‑части, связанные непосредственно с презентацией.
- Коллекция [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customdata/#getCustomXmlParts) слайда содержит пользовательские XML‑части, связанные с конкретным слайдом.
- Коллекция [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customdata/#getCustomXmlParts) фигуры содержит пользовательские XML‑части, связанные с конкретной фигурой.

Используйте [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getAllCustomXmlParts), когда нужно просмотреть все пользовательские XML‑части в презентации, независимо от того, к чему они привязаны.

### **Добавление пользовательской XML‑части в презентацию**

Для добавления XML‑данных в коллекцию пользовательских XML‑частей используйте [CustomXmlPartCollection.add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpartcollection/#add). XML должен быть корректным и непустым.

Следующий пример добавляет структурированные метаданные в коллекцию пользовательских данных уровня презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add присваивает идентификатор автоматически. Устанавливайте конкретный UUID только при необходимости.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Метод [add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpartcollection/#add) также может принимать XML в виде массива байтов или входного потока, что удобно, когда XML‑содержимое уже доступно в бинарной форме.

### **Добавление пользовательской XML‑части в слайд или фигуру**

Пользовательский XML может быть привязан к конкретному слайду или фигуре, а не ко всей презентации. Это полезно, когда метаданные описывают только один объект, например ключ шаблона, внешний идентификатор записи или информацию о привязке.

Следующий пример добавляет одну пользовательскую XML‑часть в слайд и другую — в фигуру:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Уровень, на котором добавляется часть, определяет, чья коллекция [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customdata/#getCustomXmlParts) будет содержать отношение к этой части. Данные уровня презентации подходят для метаданных, охватывающих весь документ; данные уровня слайда — для информации, принадлежащей конкретному слайду; данные уровня фигуры — для метаданных, связанных с отдельной фигурой.

### **Список и аудит всех пользовательских XML‑частей**

Для получения всех пользовательских XML‑частей из презентации используйте [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getAllCustomXmlParts). Каждый [CustomXmlPart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/) раскрывает свой идентификатор, XML‑содержимое и связанные схемы пространств имён.

Следующий пример выводит список всех пользовательских XML‑частей и их схем пространств имён:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) возвращает схемы XML, связанные с пользовательской XML‑частью. Эта информация может быть полезна при аудите презентаций, содержащих XML, полученный из внешних систем.

### **Чтение и обновление содержимого XML и ItemId**

Для работы с XML в виде строки UTF‑8 используйте [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#getXmlAsString) и [setXmlAsString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlAsString); для работы с сырыми байтами — [getXmlData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#getXmlData) и [setXmlData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlData).

Метод [CustomXmlPart.getItemId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#getItemId) возвращает UUID, идентифицирующий пользовательскую XML‑часть в документе Office Open XML. Используйте [setItemId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setItemId), когда интеграции требуется новый идентификатор.

Следующий пример обновляет содержимое XML и идентификатор:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Прочитать текущий XML как текст.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Обновить XML как строку UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData возвращает тот же XML‑содержимое в виде необработанных байтов.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Заменить идентификатор, когда это требуется интеграции.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

При вызове [setXmlAsString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlAsString) или [setXmlData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlData) предоставляйте корректный, непустой XML. Выбирайте одно представление или другое в зависимости от того, работает ли приложение преимущественно со строками или с байтовыми данными.

### **Удаление пользовательской XML‑части**

Aspose.Slides предоставляет несколько способов удаления пользовательских XML‑данных:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#remove) удаляет пользовательскую XML‑часть из презентации.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpartcollection/#remove) удаляет конкретную часть из коллекции пользовательских XML‑частей.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpartcollection/#removeAt) удаляет часть по указанному индексу в коллекции.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpartcollection/#clear) удаляет все части из конкретной коллекции.

Следующий пример удаляет одну пользовательскую XML‑часть уровня презентации по ссылке:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Если у вас уже есть объект [CustomXmlPart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/) и нужно удалить его из презентации, а не из конкретной коллекции, вызовите [CustomXmlPart.remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#remove).

Вы также можете удалить элемент по индексу:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Очистка всех пользовательских XML‑частей в коллекции**

Используйте [clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpartcollection/#clear), когда необходимо удалить все пользовательские XML‑части, связанные с определённым объектом презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpartcollection/#clear) влияет только на выбранную коллекцию. Например, очистка коллекции слайда не затрагивает коллекции уровня презентации или фигуры.

Чтобы удалить каждую пользовательскую XML‑часть в презентации, пройдите по результату [getAllCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getAllCustomXmlParts) и удалите каждую часть:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Работа с связанными или общими пользовательскими XML‑частями**

В презентации Office Open XML одна и та же пользовательская XML‑часть может быть ссылкой из более чем одного объекта презентации. Например, существующий файл может содержать отношения из нескольких слайдов или фигур к одной и той же пользовательской XML‑части.

Общую часть следует рассматривать как один объект данных с несколькими ссылками:

- Обновление её с помощью [setXmlAsString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlData) или [setItemId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setItemId) изменяет базовую XML‑часть, поэтому изменение применится везде, где она используется.
- [getItemId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#getItemId) можно использовать для идентификации одной и той же пользовательской XML‑части при аудите коллекций уровня объектов.
- Удаление части из конкретной коллекции [getCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customdata/#getCustomXmlParts) удаляет её только из этой коллекции. Используйте [CustomXmlPart.remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#remove), когда необходимо удалить саму часть из презентации.
- Перед удалением или заменой общей части проверьте коллекции уровня объектов, чтобы определить, ссылаются ли на неё другие слайды или фигуры.

Перегрузки [add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpartcollection/#add) создают новую пользовательскую XML‑часть из содержимого XML; они не принимают уже существующий объект [CustomXmlPart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/). Поэтому общие отношения обычно встречаются при загрузке презентаций, которые уже их содержат.

Следующий пример аудирует коллекции уровня презентации, слайда и фигуры по `ItemId` и выводит части, на которые ссылаются более чем из одного места:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Этот тип аудита полезен перед изменением или удалением пользовательских XML‑данных в презентациях, созданных внешними системами, потому что одна и та же метаданные часть может участвовать в нескольких отношениях.

## **Получение значений тегов**

В Slides тег соответствует методу [DocumentProperties.getKeywords](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#getKeywords). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Python via Java для [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Добавление тегов к презентациям**

Aspose.Slides позволяет добавлять теги к презентациям. Тег обычно состоит из двух элементов:

- имени пользовательского свойства, например `MyTag`;
- значения пользовательского свойства, например `My Tag Value`.

Если необходимо классифицировать презентации по определённому правилу или свойству, можно добавить соответствующие теги. Например, чтобы классифицировать презентации стран Северной Америки, создайте тег `NorthAmerican` и задайте в качестве значения соответствующую страну.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) с использованием Aspose.Slides for Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Теги можно также задать для [Slide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Или для отдельной [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Ограничения**

Теги, добавленные через коллекцию [CustomData.getTags](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customdata/#getTags), сохраняются только в файле PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, заданный как тег, нельзя получить из помеченного PDF‑файла.

**Обходной путь**: можно сохранить пользовательский идентификатор в **Alt Text** объекта (например, [Shape.setAlternativeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#setAlternativeText) со значением `"MyId"`). После экспорта в PDF Alt Text может появиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. Коллекция [tag collection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tagcollection/#clear), которая удаляет все пары ключ‑значение сразу.

**Как удалить единичный тег по его имени без перебора всей коллекции?**

Используйте [remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tagcollection/#remove) у [tag collection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tagcollection/#getNamesOfTags) у [tag collection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tagcollection/); он вернёт массив всех имён тегов.

**Как найти все пользовательские XML‑части независимо от их места хранения?**

Используйте [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getAllCustomXmlParts) для получения всех пользовательских XML‑частей в презентации.

**Стоит ли использовать [getXmlAsString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlAsString) или [getXmlData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlData) для обновления пользовательской XML‑части?**

Используйте [getXmlAsString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#getXmlAsString) и [setXmlAsString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlAsString), когда приложение работает с текстовым XML в кодировке UTF‑8. Используйте [getXmlData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#getXmlData) и [setXmlData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/customxmlpart/#setXmlData), когда XML уже доступен в виде массива байтов или когда предпочтительна бинарная обработка. Оба представления относятся к одному и тому же содержимому пользовательской XML‑части.