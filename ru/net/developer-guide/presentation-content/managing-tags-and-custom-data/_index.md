---
title: Управление тегами и пользовательскими данными в презентациях на .NET
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/net/managing-tags-and-custom-data/
keywords:
- свойства документа
- тег
- пользовательские данные
- пользовательский XML
- пользовательская XML‑часть
- XML‑метаданные
- ItemId
- добавить тег
- парные значения
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять тегами и пользовательскими XML-данными в презентациях PowerPoint с помощью Aspose.Slides for .NET, включая добавление, чтение, обновление, аудит и удаление пользовательских XML‑частей."
---
## **Обзор**

Эта статья объясняет, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Данные, специфичные для презентации, могут быть сохранены в виде тегов или пользовательских XML‑частей. Теги представляют собой простые парные строки «ключ‑значение», тогда как пользовательские XML‑части могут хранить структурированные метаданные и XML‑полезные нагрузки, специфичные для приложения.

Aspose.Slides предоставляет API для добавления, чтения, обновления, аудита и удаления пользовательских XML‑частей на уровнях презентации, слайда и фигуры. Пользовательские XML‑части полезны для интеграций, которые сохраняют информацию, такую как идентификаторы систем управления документами, состояние рабочего процесса, метаданные соответствия, данные привязки шаблона или другие структурированные данные приложения внутри презентации.

## **Хранение данных в файлах презентаций**

Файлы PPTX — файлы с расширением `.pptx` — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Office Open XML определяет структуру пакета и отношения, используемые для хранения содержимого презентаций и связанных данных.

Презентация состоит из нескольких частей, соединённых отношениями. Например, часть слайда содержит содержимое отдельного слайда и может иметь явные отношения с другими частями, определёнными в ISO/IEC 29500.

Пользовательские данные могут храниться в виде тегов ([ITagCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/itagcollection)) или пользовательских XML‑частей ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpartcollection)). Оба доступны через интерфейс [`ICustomData`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}

Теги хранят простые строковые пары «ключ‑значение». Пользовательские XML‑части хранят структурированные XML‑данные и могут быть связаны с презентацией, слайдом или фигурой.

{{% /alert %}}

## **Работа с пользовательскими XML‑частями**

Свойство [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomdata/customxmlparts/) возвращает коллекцию пользовательских XML‑частей, связанных с конкретным объектом презентации. Например:

- `presentation.CustomData.CustomXmlParts` содержит пользовательские XML‑части, связанные непосредственно с презентацией.
- `slide.CustomData.CustomXmlParts` содержит пользовательские XML‑части, связанные с отдельным слайдом.
- `shape.CustomData.CustomXmlParts` содержит пользовательские XML‑части, связанные с отдельной фигурой.

Используйте [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/allcustomxmlparts/) когда нужно просмотреть все пользовательские XML‑части в презентации независимо от того, к чему они привязаны.

### **Добавление пользовательской XML‑части в презентацию**

Для добавления XML‑данных в коллекцию пользовательских XML‑частей используйте [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpartcollection/add/). XML должен быть корректным и непустым.

Следующий пример добавляет структурированные метаданные в коллекцию пользовательских данных уровня презентации:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Добавление автоматически назначает идентификатор. Устанавливайте конкретный GUID только при необходимости.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Метод `Add` также может принимать XML в виде массива байтов или потока, что полезно, когда XML‑содержимое уже доступно в бинарной форме.

### **Добавление пользовательской XML‑части в слайд или фигуру**

Пользовательские XML‑данные могут быть связаны с конкретным слайдом или фигурой вместо всей презентации. Это полезно, когда метаданные описывают только один объект, например ключ шаблона, внешний идентификатор записи или информацию о привязке.

Следующий пример добавляет одну пользовательскую XML‑часть в слайд и другую — в фигуру:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Уровень, на котором добавлена часть, определяет, в чью коллекцию `CustomData.CustomXmlParts` попадёт связь с этой частью. Данные уровня презентации подходят для метаданных, охватывающих весь документ; данные уровня слайда — для информации, относящейся к конкретному слайду; данные уровня фигуры — для метаданных, привязанных к отдельной фигуре.

### **Список и аудит всех пользовательских XML‑частей**

Для получения всех пользовательских XML‑частей из презентации используйте [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/allcustomxmlparts/). Каждый [`ICustomXmlPart`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpart/) раскрывает свой идентификатор, XML‑содержимое и связанные схемы пространств имён.

Следующий пример выводит список всех пользовательских XML‑частей и их схем пространств имён:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpart/namespaceschemas/) возвращает XML‑схемы, ассоциированные с пользовательской XML‑частью. Эта информация может быть полезна при аудите презентаций, содержащих XML, созданный внешними системами.

### **Чтение и обновление XML‑содержимого и ItemId**

Для работы с XML как строкой UTF‑8 используйте [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpart/xmlasstring/), либо для работы с сырыми байтами — [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpart/xmldata/). Обе свойства можно читать и обновлять.

Свойство [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpart/itemid/) содержит GUID, идентифицирующий пользовательскую XML‑часть в документе Office Open XML. Его также можно изменить, если интеграции требуется новый идентификатор.

Следующий пример обновляет XML‑содержимое и идентификатор:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Прочитать текущий XML как текст.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Обновить XML как строку UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData предоставляет тот же XML‑контент в виде необработанных байтов.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Заменить идентификатор, когда это требуется интеграции.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

При присвоении `XmlAsString` или `XmlData` предоставляйте корректный, непустой XML. Используйте тот вариант представления, который соответствует тому, работает ли приложение преимущественно со строками или с бинарными данными.

### **Удаление пользовательской XML‑части**

Aspose.Slides предоставляет несколько способов удаления пользовательских XML‑данных:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpart/remove/) удаляет пользовательскую XML‑часть из презентации.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpartcollection/remove/) удаляет конкретную часть из коллекции пользовательских XML‑частей.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpartcollection/removeat/) удаляет часть по указанному индексу коллекции.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpartcollection/clear/) удаляет все части из конкретной коллекции.

Следующий пример удаляет одну пользовательскую XML‑часть уровня презентации по ссылке:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Если у вас уже есть объект `ICustomXmlPart` и нужно удалить эту часть из презентации, а не из конкретной коллекции, вызовите `customXmlPart.Remove()`.

Вы также можете удалить элемент по индексу:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Очистка всех пользовательских XML‑частей из коллекции**

Используйте `Clear`, когда необходимо удалить все пользовательские XML‑части, связанные с определённым объектом презентации.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` воздействует только на выбранную коллекцию. Например, очистка коллекции слайда не очищает коллекции уровня презентации или уровня фигуры.

Для удаления каждой пользовательской XML‑части в презентации пройдите по `AllCustomXmlParts` и удалите каждую часть:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Работа со связанными или общими пользовательскими XML‑частями**

В презентации Office Open XML одна и та же пользовательская XML‑часть может быть ссылкой из более чем одного объекта презентации. Например, существующий файл может содержать отношения от нескольких слайдов или фигур к одной и той же базовой пользовательской XML‑части.

Общую часть следует рассматривать как один объект данных с несколькими ссылками:

- Обновление `XmlAsString`, `XmlData` или `ItemId` изменяет базовую пользовательскую XML‑часть, поэтому изменение применяется везде, где эта часть используется.
- `ItemId` может использоваться для идентификации одной и той же пользовательской XML‑части при аудите коллекций уровня объектов.
- Удаление части из конкретной коллекции `CustomXmlParts` удаляет её только из этой коллекции. Используйте `ICustomXmlPart.Remove()`, когда сама часть должна быть удалена из презентации.
- Перед удалением или заменой общей части просмотрите коллекции уровня объектов, чтобы определить, ссылаются ли на неё другие слайды или фигуры.

Перегрузки `Add` создают новую пользовательскую XML‑часть из XML‑содержимого; они не принимают уже существующий `ICustomXmlPart`. Поэтому общие отношения обычно встречаются при загрузке презентаций, которые уже их содержат.

Следующий пример проводит аудит коллекций уровня презентации, слайда и фигуры по `ItemId` и сообщает о частях, на которые есть ссылки из более чем одного места:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Такой аудит полезен перед изменением или удалением пользовательских XML‑данных в презентациях, созданных внешними системами, поскольку одна и та же часть метаданных может участвовать в более чем одном отношении.

## **Получение значений тегов**

В Slides тег соответствует свойству `IDocumentProperties.Keywords`. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for .NET для [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов:

- имени пользовательского свойства, например `MyTag`;
- значения пользовательского свойства, например `My Tag Value`.

Если необходимо классифицировать презентации по определённому правилу или свойству, можно добавить соответствующие теги. Например, для категоризации презентаций из стран Северной Америки можно создать тег «North American» и присвоить ему в качестве значения название страны.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) с помощью Aspose.Slides for .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Теги также можно задать для [Slide](https://reference.aspose.com/slides/ru/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Или для отдельной [Shape](https://reference.aspose.com/slides/ru/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Ограничения**

Теги, добавленные через коллекцию `CustomData.Tags`, сохраняются только в файле PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, записанный как тег, не может быть получен из PDF‑файла с тегами.

**Обходное решение**: можно сохранить пользовательский идентификатор в **Alt Text** объекта (например, `shape.AlternativeText = "MyId"`). После экспорта в PDF альтернативный текст может появиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. Коллекция [tag collection](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/) поддерживает операцию [Clear](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/clear/), которая удаляет все парные «ключ‑значение» сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте [Remove(name)](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/) для удаления тега по ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [GetNamesOfTags](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/getnamesoftags/) у коллекции тегов; он вернёт массив всех имён тегов.

**Как найти все пользовательские XML‑части независимо от того, где они хранятся?**

Используйте [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/allcustomxmlparts/) для получения всех пользовательских XML‑частей в презентации.

**Стоит ли использовать `XmlAsString` или `XmlData` для обновления пользовательской XML‑части?**

Применяйте `XmlAsString`, когда приложение работает с текстовым XML в кодировке UTF‑8. Используйте `XmlData`, когда XML уже доступен в виде массива байтов или когда удобнее работать с бинарными данными. Обе свойства представляют одно и то же XML‑содержимое пользовательской части.