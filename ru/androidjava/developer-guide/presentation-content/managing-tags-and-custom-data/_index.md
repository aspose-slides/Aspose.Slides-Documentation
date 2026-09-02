---
title: У管理标签和自定义数据在Android上的演示文稿中
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /ru/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять тегами и пользовательскими XML‑данными в презентациях PowerPoint с помощью Aspose.Slides для Android через Java, включая добавление, чтение, обновление, аудит и удаление пользовательских XML‑частей."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Данные, специфичные для презентации, могут быть сохранены в виде тегов или пользовательских XML‑частей. Теги представляют собой простые пары строк «ключ‑значение», тогда как пользовательские XML‑части могут хранить структурированные метаданные и XML‑полезные нагрузки, специфичные для приложений.

Aspose.Slides предоставляет API для добавления, чтения, обновления, аудита и удаления пользовательских XML‑частей на уровнях презентации, слайда и фигуры. Пользовательские XML‑части полезны для интеграций, которым необходимо хранить такие сведения, как идентификаторы систем управления документами, состояние рабочего процесса, метаданные соответствия, данные привязки шаблонов или другие структурированные данные приложения внутри презентации.

## **Хранение данных в файлах презентаций**

Файлы PPTX — файлы с расширением `.pptx` — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Office Open XML определяет структуру пакета и отношения, используемые для хранения содержимого презентации и связанных данных.

Презентация состоит из нескольких частей, соединённых отношениями. Например, часть слайда содержит содержимое одного слайда и может иметь явные отношения с другими частями, определёнными в ISO/IEC 29500.

Пользовательские данные могут храниться в виде тегов ([ITagCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITagCollection)) или пользовательских XML‑частей ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Оба варианта доступны через интерфейс [`ICustomData`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}

Теги хранят простые строковые пары «ключ‑значение». Пользовательские XML‑части хранят структурированные XML‑данные и могут быть ассоциированы с презентацией, слайдом или фигурой.

{{% /alert %}}

## **Работа с пользовательскими XML‑частями**

Метод [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) возвращает коллекцию пользовательских XML‑частей, связанных с конкретным объектом презентации. Например:

- `presentation.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с самой презентацией.
- `slide.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с определённым слайдом.
- `shape.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с определённой фигурой.

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) , когда необходимо просмотреть все пользовательские XML‑части в презентации независимо от того, с чем они связаны.

### **Добавление пользовательской XML‑части в презентацию**

Для добавления XML‑данных в коллекцию пользовательских XML‑частей используйте [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-). XML должен быть корректным и непустым.

Ниже приведён пример, добавляющий структурированные метаданные в коллекцию пользовательских данных уровня презентации:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add автоматически назначает идентификатор. Устанавливайте конкретный UUID только при необходимости.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Метод `add` также может принимать XML в виде массива байтов или потока ввода, что удобно, когда XML‑контент уже доступен в бинарной форме.

### **Добавление пользовательской XML‑части в слайд или фигуру**

Пользовательские XML‑данные можно связать с конкретным слайдом или фигурой, а не со всей презентацией. Это полезно, когда метаданные относятся только к одному объекту, например, к ключу шаблона, внешнему идентификатору записи или информации привязки.

Ниже пример, добавляющий одну пользовательскую XML‑часть в слайд и другую — в фигуру:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Уровень, на котором добавлена часть, определяет, чья коллекция `getCustomData().getCustomXmlParts()` будет содержать связь с этой частью. Данные уровня презентации подходят для метаданных, охватывающих весь документ; данные уровня слайда — для информации, принадлежащей конкретному слайду; данные уровня фигуры — для метаданных, привязанных к отдельной фигуре.

### **Список и аудит всех пользовательских XML‑частей**

Для получения всех пользовательских XML‑частей из презентации используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) . Каждый [`ICustomXmlPart`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart/) предоставляет свой идентификатор, содержимое XML и связанные схемы пространств имён.

Пример, выводящий список всех пользовательских XML‑частей и их схемы пространств имён:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) возвращает XML‑схемы, связанные с пользовательской XML‑частью. Эта информация может быть полезна при аудите презентаций, содержащих XML, созданный внешними системами.

### **Чтение и обновление содержимого XML и ItemId**

Для работы с XML как строкой UTF‑8 используйте [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) и [`setXmlAsString()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-), либо [`getXmlData()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) и [`setXmlData()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) для работы с необработанными байтами XML.

Метод [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) возвращает UUID, идентифицирующий пользовательскую XML‑часть в документе Office Open XML. При необходимости новой идентификации используйте [`setItemId()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) .

Пример, обновляющий содержимое XML и идентификатор:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Прочитать текущий XML как текст.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Обновить XML как строку UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData предоставляет тот же XML‑контент в виде необработанных байтов.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Заменить идентификатор, если это требуется интеграции.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

При вызове `setXmlAsString` или `setXmlData` передавайте корректный, непустой XML. Выбирайте один из вариантов в зависимости от того, работает ли приложение преимущественно со строками или с байтовыми данными.

### **Удаление пользовательской XML‑части**

Aspose.Slides предоставляет несколько способов удаления пользовательских XML‑данных:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#remove--) удаляет пользовательскую XML‑часть из презентации.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) удаляет конкретную часть из коллекции пользовательских XML‑частей.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) удаляет часть по заданному индексу в коллекции.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) удаляет все части из конкретной коллекции.

Пример, удаляющий одну пользовательскую XML‑часть уровня презентации по ссылке:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если у вас уже есть объект `ICustomXmlPart` и нужно удалить эту часть из презентации, а не из конкретной коллекции, вызовите `customXmlPart.remove()`.

Удалить элемент можно и по индексу:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Очистка всех пользовательских XML‑частей в коллекции**

Используйте `clear`, когда необходимо удалить все пользовательские XML‑части, связанные с определённым объектом презентации.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` влияет только на выбранную коллекцию. Например, очистка коллекции слайда не затрагивает коллекцию уровня презентации или уровня фигуры.

Чтобы удалить каждую пользовательскую XML‑часть в презентации, пройдите по `getAllCustomXmlParts()` и удалите каждую часть:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Обработка связанных или общих пользовательских XML‑частей**

В презентации Office Open XML одна и та же пользовательская XML‑часть может быть указана более чем одним объектом презентации. Например, существующий файл может содержать отношения от нескольких слайдов или фигур к одной и той же пользовательской XML‑части.

Общую часть следует рассматривать как один объект данных с несколькими ссылками:

- Обновление её через `setXmlAsString`, `setXmlData` или `setItemId` меняет базовую пользовательскую XML‑часть, поэтому изменение применяется во всех местах её использования.
- `getItemId()` можно использовать для идентификации одной и той же пользовательской XML‑части при аудите коллекций уровней объектов.
- Удаление части из конкретной коллекции `getCustomXmlParts()` удаляет её только из этой коллекции. Чтобы полностью удалить часть из презентации, используйте `ICustomXmlPart.remove()`.
- Перед удалением или заменой общей части проверьте коллекции уровней объектов, чтобы понять, ссылаются ли на неё другие слайды или фигуры.

Перегрузки `add` создают новую пользовательскую XML‑часть из XML‑контента; они не принимают уже существующий `ICustomXmlPart`. Поэтому общие отношения обычно встречаются при загрузке презентаций, уже содержащих такие связи.

Пример, выполняющий аудит коллекций уровней презентации, слайда и фигуры по `ItemId` и выводящий части, указанные более чем в одном месте:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Такой аудит полезен перед изменением или удалением пользовательских XML‑данных в презентациях, созданных внешними системами, поскольку одна и та же метаданная часть может участвовать в нескольких отношениях.

## **Получение значений тегов**

В Slides тег соответствует методу `IDocumentProperties.getKeywords()`. Ниже пример кода, показывающий, как получить значение тега с помощью Aspose.Slides for Android via Java для [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов:

- имени пользовательского свойства, например `MyTag`;
- значения пользовательского свойства, например `My Tag Value`.

Если необходимо классифицировать презентации по определённому правилу или свойству, можно добавить соответствующие теги. Например, для категоризации презентаций стран Северной Америки можно создать тег `NorthAmerica` и задать в качестве значения название страны.

Пример кода, показывающий, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation) с помощью Aspose.Slides for Android via Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Теги также можно задавать для [Slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Или для отдельной [Shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IAutoShape):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Ограничения**

Теги, добавленные через коллекцию `getCustomData().getTags()`, сохраняются только в файле PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, заданный как тег, нельзя получить из PDF‑файла с тегами.

**Обходное решение**: можно сохранить пользовательский идентификатор в **Alt Text** объекта (например, `shape.setAlternativeText("MyId")`). После экспорта в PDF альтернативный текст может появиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. Коллекция [tag collection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/#clear--) , которая удаляет все пары ключ‑значение сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Вызовите [remove(name)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) у [tag collection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/) для удаления тега по ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) у [tag collection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/) — он вернёт массив всех имён тегов.

**Как найти все пользовательские XML‑части независимо от места их хранения?**

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) для получения всех пользовательских XML‑частей в презентации.

**Что использовать: `getXmlAsString`/`setXmlAsString` или `getXmlData`/`setXmlData` для обновления пользовательской XML‑части?**

Применяйте `getXmlAsString` и `setXmlAsString`, когда приложение работает с текстовым XML в кодировке UTF‑8. Используйте `getXmlData` и `setXmlData`, когда XML уже доступен как массив байтов или когда удобнее работать с бинарными данными. Оба варианта ссылаются на один и тот же XML‑контент пользовательской части.