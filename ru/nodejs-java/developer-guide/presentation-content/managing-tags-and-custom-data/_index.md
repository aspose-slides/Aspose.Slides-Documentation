---
title: Управление тегами и пользовательскими данными в презентациях с использованием JavaScript
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/nodejs-java/managing-tags-and-custom-data/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как управлять тегами и пользовательскими XML‑данными в презентациях PowerPoint с помощью Aspose.Slides for Node.js via Java, включая добавление, чтение, обновление, аудит и удаление пользовательских XML‑частей."
---
## **Обзор**

Эта статья объясняет, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Данные, специфичные для презентации, могут храниться в виде тегов или пользовательских XML‑частей. Теги — это простые пары ключ‑значение строк, в то время как пользовательские XML‑части могут хранить структурированные метаданные и XML‑полезные нагрузки, специфичные для приложения.

Aspose.Slides предоставляет API для добавления, чтения, обновления, аудита и удаления пользовательских XML‑частей на уровнях презентации, слайда и фигуры. Пользовательские XML‑части полезны для интеграций, которые сохраняют такие сведения, как идентификаторы управления документами, состояние рабочего процесса, метаданные соответствия, данные привязки шаблона или другие структурированные данные приложения внутри презентации.

## **Хранение данных в файлах презентаций**

Файлы PPTX — файлы с расширением `.pptx` — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Office Open XML определяет структуру пакета и отношения, используемые для хранения содержимого презентации и сопутствующих данных.

Презентация содержит несколько частей, связанных отношениями. Например, часть слайда содержит содержимое одного слайда и может иметь явные отношения к другим частям, определённым в ISO/IEC 29500.

Пользовательские данные могут храниться в виде тегов ([TagCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/)) или пользовательских XML‑частей ([CustomXmlPartCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customxmlpartcollection/)). Оба доступны через класс [`CustomData`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Теги хранят простые строковые пары ключ‑значение. Пользовательские XML‑части хранят структурированные XML‑данные и могут быть связаны с презентацией, слайдом или фигурой.
{{% /alert %}}

## **Работа с пользовательскими XML-частями**

Метод `getCustomXmlParts()` класса [`CustomData`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customdata/) возвращает коллекцию пользовательских XML‑частей, связанных с конкретным объектом презентации. Например:

- `presentation.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с самой презентацией.
- `slide.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретным слайдом.
- `shape.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретной фигурой.

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), когда нужно просмотреть все пользовательские XML‑части в презентации независимо от того, с чем они ассоциированы.

### **Добавление пользовательской XML-части в презентацию**

Используйте метод `add` коллекции [`CustomXmlPartCollection`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customxmlpartcollection/) для добавления XML‑данных в коллекцию пользовательских XML‑частей. XML должен быть действительным и непустым.

Следующий пример добавляет структурированные метаданные в коллекцию пользовательских данных уровня презентации:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add автоматически назначает идентификатор. Устанавливайте конкретный UUID только при необходимости.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Метод `add` также может принимать XML в виде массива байтов, что удобно, когда XML‑содержимое уже доступно в бинарной форме.

### **Добавление пользовательской XML-части в слайд или фигуру**

Пользовательские XML‑данные могут быть связаны с конкретным слайдом или фигурой вместо всей презентации. Это полезно, когда метаданные описывают только один объект, например, ключ шаблона, внешний идентификатор записи или информацию о привязке.

Следующий пример добавляет одну пользовательскую XML‑часть в слайд и другую — в фигуру:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Уровень, на котором добавлена часть, определяет, чья коллекция `getCustomData().getCustomXmlParts()` будет содержать связь с этой частью. Данные уровня презентации подходят для метаданных, охватывающих весь документ, данные уровня слайда — для информации, относящейся к конкретному слайду, а данные уровня фигуры — для метаданных, привязанных к отдельной фигуре.

### **Список и аудит всех пользовательских XML-частей**

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) для получения всех пользовательских XML‑частей из презентации. Каждый объект [`CustomXmlPart`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customxmlpart/) раскрывает свой идентификатор, XML‑содержимое и связанные схемы пространств имён.

Следующий пример выводит список всех пользовательских XML‑частей и их схем пространств имён:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customxmlpart/) возвращает XML‑схемы, ассоциированные с пользовательской XML‑частью. Эта информация может быть полезна при аудите презентаций, содержащих XML, созданный внешними системами.

### **Чтение и обновление XML‑содержимого и ItemId**

Используйте `getXmlAsString()` и `setXmlAsString()` из [`CustomXmlPart`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customxmlpart/) для работы с XML как строкой UTF‑8, либо `getXmlData()` и `setXmlData()` для работы с сырыми байтами XML.

Метод `getItemId()` возвращает UUID, идентифицирующий пользовательскую XML‑часть в документе Office Open XML. Метод `setItemId()` применяется, когда интеграции требуется новый идентификатор.

Следующий пример обновляет XML‑содержимое и идентификатор:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Прочитать текущий XML как текст.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Обновить XML в виде строки UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData предоставляет тот же XML‑контент в виде необработанных байтов.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Заменить идентификатор, если это требуется интеграции.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

При вызове `setXmlAsString` или `setXmlData` передайте действительный, непустой XML. Используйте тот вариант представления, который соответствует тому, работает ли приложение в основном со строками или с байтовыми данными.

### **Удаление пользовательской XML-части**

Aspose.Slides предоставляет несколько способов удаления пользовательских XML‑данных:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customxmlpart/) удаляет пользовательскую XML‑часть из презентации.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customxmlpartcollection/) удаляет конкретную часть из коллекции пользовательских XML‑частей.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customxmlpartcollection/) удаляет часть по указанному индексу в коллекции.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/customxmlpartcollection/) удаляет все части из конкретной коллекции.

Следующий пример удаляет одну пользовательскую XML‑часть уровня презентации по ссылке:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если у вас уже есть объект `CustomXmlPart` и вы хотите удалить эту часть из презентации, а не обращаться к конкретной коллекции, вызовите `customXmlPart.remove()`.

Вы также можете удалить элемент по индексу:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Очистка всех пользовательских XML-частей из коллекции**

Используйте `clear`, когда необходимо удалить все пользовательские XML‑части, связанные с определённым объектом презентации.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` влияет только на выбранную коллекцию. Например, очистка коллекции слайда не затрагивает коллекции уровня презентации или уровня фигуры.

Чтобы удалить каждую пользовательскую XML‑часть в презентации, пройдитесь по `getAllCustomXmlParts()` и удалите каждую часть:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Обработка связанных или общих пользовательских XML-частей**

В презентации Office Open XML одна и та же пользовательская XML‑часть может быть сослано из более чем одного объекта презентации. Например, существующий файл может содержать отношения от нескольких слайдов или фигур к одной и той же базовой пользовательской XML‑части.

Общую часть следует рассматривать как один объект данных с множеством ссылок:

- Обновление её с помощью `setXmlAsString`, `setXmlData` или `setItemId` изменяет базовую пользовательскую XML‑часть, поэтому изменение применяется во всех местах, где она используется.
- `getItemId()` можно использовать для идентификации одной и той же пользовательской XML‑части при аудите коллекций объектов.
- Удаление части из конкретной коллекции `getCustomXmlParts()` удаляет её только из этой коллекции. Используйте `CustomXmlPart.remove()` когда необходимо удалить саму часть из презентации.
- Перед удалением или заменой общей части проверьте коллекции уровней объектов, чтобы определить, ссылаются ли на неё другие слайды или фигуры.

Перегрузки `add` создают новую пользовательскую XML‑часть из XML‑содержимого; они не принимают существующий `CustomXmlPart`. Поэтому общие отношения чаще всего встречаются при загрузке презентаций, которые уже их содержат.

Следующий пример аудирует коллекции уровня презентации, слайда и фигуры по `ItemId` и сообщает о частях, на которые ссылаются более чем один объект:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Такой аудит полезен перед изменением или удалением пользовательских XML‑данных в презентациях, созданных внешними системами, поскольку одна и та же метаданные часть может участвовать в нескольких отношениях.

## **Получение значений тегов**

В Slides тег соответствует методу `DocumentProperties.getKeywords()`. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Node.js via Java для [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Добавление тегов к презентациям**

Aspose.Slides позволяет добавлять теги к презентациям. Тег обычно состоит из двух элементов:

- имени пользовательского свойства, например `MyTag`;
- значения пользовательского свойства, например `My Tag Value`.

Если необходимо классифицировать презентации по определённому правилу или свойству, можно добавить соответствующие теги. Например, для категоризации презентаций стран Северной Америки можно создать тег «NorthAmerican» и задать в качестве значения соответствующую страну.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) с помощью Aspose.Slides for Node.js via Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Теги также могут быть заданы для [Slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Или для отдельной [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Ограничения**

Теги, добавленные через коллекцию `getCustomData().getTags()`, сохраняются только в файле PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, заданный как тег, нельзя получить из PDF с тегами.

**Обходной путь**: можно сохранить пользовательский идентификатор в **альтернативном тексте** объекта (например, `shape.setAlternativeText("MyId")`). После экспорта в PDF альтернативный текст может появиться в структуре тегов PDF.

## **Часто задаваемые вопросы**

**Могу ли я удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. Коллекция [tag collection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/), которая удаляет все пары ключ‑значение сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Вызовите `remove(name)` у [tag collection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/), чтобы удалить тег по ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите `getNamesOfTags()` у [tag collection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.

**Как найти все пользовательские XML‑части, независимо от места их хранения?**

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) для получения всех пользовательских XML‑частей в презентации.

**Стоит ли использовать `getXmlAsString`/`setXmlAsString` или `getXmlData`/`setXmlData` для обновления пользовательской XML‑части?**

Используйте `getXmlAsString` и `setXmlAsString`, когда приложение работает с текстом XML в кодировке UTF‑8. Используйте `getXmlData` и `setXmlData`, когда XML уже доступен как массив байтов или когда более удобно работать с бинарными данными. Оба варианта представляют одинаковое XML‑содержимое одной пользовательской XML‑части.