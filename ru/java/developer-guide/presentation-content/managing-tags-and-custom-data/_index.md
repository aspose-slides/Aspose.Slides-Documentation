---
title: Управление тегами и пользовательскими данными в презентациях с использованием Java
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/java/managing-tags-and-custom-data/
keywords:
- свойства документа
- тег
- пользовательские данные
- пользовательский XML
- пользовательская XML‑часть
- метаданные XML
- ItemId
- добавить тег
- парные значения
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять тегами и пользовательскими данными XML в презентациях PowerPoint с помощью Aspose.Slides для Java, включая добавление, чтение, обновление, аудит и удаление пользовательских XML‑частей."
---
## **Обзор**

Эта статья объясняет, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Данные, специфичные для презентации, могут храниться в виде тегов или пользовательских XML‑частей. Теги — это простые парные строки «ключ‑значение», тогда как пользовательские XML‑части могут хранить структурированные метаданные и специфичные для приложения XML‑полезные нагрузки.

Aspose.Slides предоставляет API для добавления, чтения, обновления, аудита и удаления пользовательских XML‑частей на уровнях презентации, слайда и фигуры. Пользовательские XML‑части полезны для интеграций, которые сохраняют информацию, такую как идентификаторы управления документами, состояние рабочего процесса, метаданные соответствия, данные привязки шаблона или другие структурированные данные приложения внутри презентации.

## **Хранение данных в файлах презентаций**

Файлы PPTX — файлы с расширением `.pptx` — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Office Open XML определяет структуру пакета и взаимосвязи, используемые для хранения содержимого презентации и связанных данных.

Презентация состоит из нескольких частей, связанных взаимосвязями. Например, часть слайда содержит содержимое одного слайда и может иметь явные взаимосвязи с другими частями, определёнными в ISO/IEC 29500.

Пользовательские данные могут храниться в виде тегов ([ITagCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITagCollection)) или пользовательских XML‑частей ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPartCollection)). Оба доступны через интерфейс [`ICustomData`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}

Теги хранят простые парные строки «ключ‑значение». Пользовательские XML‑части хранят структурированные XML‑данные и могут быть связаны с презентацией, слайдом или фигурой.

{{% /alert %}}

## **Работа с пользовательскими XML‑частями**

Метод [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomData#getCustomXmlParts--) возвращает коллекцию пользовательских XML‑частей, связанных с конкретным объектом презентации. Например:

- `presentation.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные непосредственно с презентацией.
- `slide.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретным слайдом.
- `shape.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретной фигурой.

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) , когда нужно просмотреть все пользовательские XML‑части в презентации независимо от того, к чему они привязаны.

### **Добавление пользовательской XML‑части в презентацию**

Используйте [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) для добавления XML‑данных в коллекцию пользовательских XML‑частей. XML должен быть корректным и непустым.

Следующий пример добавляет структурированные метаданные в коллекцию пользовательских данных уровня презентации:

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

Метод `add` также может принимать XML в виде массива байтов или входного потока, что удобно, когда содержимое XML уже доступно в бинарной форме.

### **Добавление пользовательской XML‑части в слайд или фигуру**

Пользовательские XML‑данные могут быть привязаны к конкретному слайду или фигуре вместо всей презентации. Это полезно, когда метаданные описывают только один объект, например ключ шаблона, внешний идентификатор записи или информацию о привязке.

Следующий пример добавляет одну пользовательскую XML‑часть в слайд и другую — в фигуру:

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

Уровень, на котором добавлена часть, определяет, в чью коллекцию `getCustomData().getCustomXmlParts()` будет включена связь с этой частью. Данные уровня презентации подходят для метаданных, охватывающих весь документ; данные уровня слайда — для информации, принадлежащей конкретному слайду; данные уровня фигуры — для метаданных, привязанных к отдельной фигуре.

### **Перечисление и аудит всех пользовательских XML‑частей**

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) для получения всех пользовательских XML‑частей из презентации. Каждый [`ICustomXmlPart`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPart/) раскрывает свой идентификатор, XML‑содержимое и связанные схемы пространств имён.

Следующий пример выводит список всех пользовательских XML‑частей и их схем пространств имён:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) возвращает XML‑схемы, связанные с пользовательской XML‑частью. Эта информация может быть полезна при аудите презентаций, содержащих XML, полученный из внешних систем.

### **Чтение и обновление XML‑содержимого и ItemId**

Используйте [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) и [`setXmlAsString()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) для работы с XML как строкой UTF‑8, либо [`getXmlData()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPart#getXmlData--) и [`setXmlData()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) для работы с необработанными байтами XML.

Метод [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPart#getItemId--) возвращает UUID, который идентифицирует пользовательскую XML‑часть в документе Office Open XML. Используйте [`setItemId()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) когда интеграции требуется новый идентификатор.

Следующий пример обновляет XML‑содержимое и идентификатор:

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

При вызове `setXmlAsString` или `setXmlData` передавайте корректный, непустой XML. Выбирайте одно представление или другое в зависимости от того, работает ли приложение преимущественно со строками или с байтовыми данными.

### **Удаление пользовательской XML‑части**

Aspose.Slides предоставляет несколько способов удаления пользовательских XML‑данных:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPart#remove--) удаляет пользовательскую XML‑часть из презентации.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) удаляет конкретную часть из коллекции пользовательских XML‑частей.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) удаляет часть по указанному индексу коллекции.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPartCollection#clear--) удаляет все части из конкретной коллекции.

Следующий пример удаляет одну пользовательскую XML‑часть уровня презентации по ссылке:

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

Если у вас уже есть `ICustomXmlPart` и вы хотите удалить эту часть из презентации, а не из конкретной коллекции, вызовите `customXmlPart.remove()`.

Можно также удалить элемент по индексу:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Очистка всех пользовательских XML‑частей в коллекции**

Используйте `clear`, когда следует удалить все пользовательские XML‑части, связанные с определённым объектом презентации.

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

`clear` влияет только на выбранную коллекцию. Например, очистка коллекции слайда не затрагивает коллекции уровня презентации или фигуры.

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

### **Работа со связанными или общими пользовательскими XML‑частями**

В презентации Office Open XML одна и та же пользовательская XML‑часть может быть ссылкой из более чем одного объекта презентации. Например, существующий файл может содержать взаимосвязи из нескольких слайдов или фигур к одной и той же базовой пользовательской XML‑части.

Общую часть следует рассматривать как один объект данных с множеством ссылок:

- Обновление её с помощью `setXmlAsString`, `setXmlData` или `setItemId` изменяет базовую пользовательскую XML‑часть, поэтому изменение применяется во всех местах её использования.
- `getItemId()` можно использовать для идентификации одной и той же пользовательской XML‑части при аудите коллекций на уровне объектов.
- Удаление части из конкретной коллекции `getCustomXmlParts()` удаляет её только из этой коллекции. Используйте `ICustomXmlPart.remove()` когда нужно удалить саму часть из презентации.
- Перед удалением или заменой общей части проверьте коллекции на уровне объектов, чтобы определить, ссылаются ли на неё другие слайды или фигуры.

Перегрузки `add` создают новую пользовательскую XML‑часть из XML‑контента; они не принимают уже существующий `ICustomXmlPart`. Поэтому общие взаимосвязи чаще всего встречаются при загрузке презентаций, которые уже их содержат.

Следующий пример проводит аудит коллекций уровня презентации, слайда и фигуры по `ItemId` и сообщает о частях, на которые ссылаются более чем один объект:

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

Такой аудит полезен перед изменением или удалением пользовательских XML‑данных в презентациях, созданных внешними системами, поскольку одна и та же метаданные часть может участвовать в нескольких взаимосвязях.

## **Получение значений тегов**

В Slides тег соответствует методу `IDocumentProperties.getKeywords()`. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Java для [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation):

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

Если вам нужно классифицировать презентации по определённому правилу или свойству, вы можете добавить соответствующие теги. Например, если вы хотите классифицировать презентации из стран Северной Америки, можно создать тег «NorthAmerican» и задать в качестве значения соответствующую страну.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) с использованием Aspose.Slides for Java:

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

Теги также можно установить для [Slide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlide):

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

Или для отдельной [Shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape):

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

Теги, добавленные через коллекцию `getCustomData().getTags()`, хранятся только в файле PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, заданный как тег, нельзя получить из PDF‑файла с тегами.

**Обходной путь**: можно сохранить пользовательский идентификатор в **Alt Text** объекта (например, `shape.setAlternativeText("MyId")`). После экспорта в PDF альтернативный текст может появиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. Коллекция [tag collection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/#clear--) , которая удаляет все парные ключ‑значение сразу.

**Как удалить один тег по имени без перебора всей коллекции?**

Используйте [remove(name)](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) у [tag collection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/) , чтобы удалить тег по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/#getNamesOfTags--) у [tag collection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/) ; он вернёт массив всех имён тегов.

**Как найти все пользовательские XML‑части независимо от их места хранения?**

Воспользуйтесь [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) для получения всех пользовательских XML‑частей в презентации.

**Что использовать для обновления пользовательской XML‑части: `getXmlAsString`/`setXmlAsString` или `getXmlData`/`setXmlData`?**

Используйте `getXmlAsString` и `setXmlAsString`, когда приложение работает с UTF‑8 текстом XML. Используйте `getXmlData` и `setXmlData`, когда XML уже доступен как массив байтов или когда более удобна работа с бинарными данными. Оба представления относятся к одному и тому же XML‑содержимому пользовательской части.