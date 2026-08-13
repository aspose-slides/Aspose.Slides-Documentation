---
title: У管理ление тегами и пользовательскими данными в презентациях на Android
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять тегами и пользовательскими XML‑данными в презентациях PowerPoint с помощью Aspose.Slides для Android через Java, включая добавление, чтение, обновление, аудит и удаление пользовательских XML‑частей."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Данные, специфичные для презентации, могут храниться в виде тегов или пользовательских XML‑частей. Теги представляют собой простые пары строк «ключ‑значение», тогда как пользовательские XML‑части могут хранить структурированные метаданные и XML‑полезные нагрузки, специфичные для приложения.

Aspose.Slides предоставляет API для добавления, чтения, обновления, аудита и удаления пользовательских XML‑частей на уровнях презентации, слайда и фигуры. Пользовательские XML‑части полезны для интеграций, которые сохраняют информацию, такую как идентификаторы управления документами, состояние рабочего процесса, метаданные соответствия, данные привязки шаблонов или другие структурированные данные приложения внутри презентации.

## **Хранение данных в файлах презентаций**

Файлы PPTX — файлы с расширением `.pptx` — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Office Open XML определяет структуру пакета и отношения, используемые для хранения содержания презентации и связанных данных.

Презентация содержит несколько частей, связанных отношениями. Например, часть слайда содержит содержимое одного слайда и может иметь явные связи с другими частями, определенными в ISO/IEC 29500.

Пользовательские данные могут храниться в виде тегов ([ITagCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITagCollection)) или пользовательских XML‑частей ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Оба доступны через интерфейс [`ICustomData`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomData/).

{{% alert color="info" %}}
Теги хранят простые пары строк «ключ‑значение». Пользовательские XML‑части хранят структурированные XML‑данные и могут быть связаны с презентацией, слайдом или фигурой.
{{% /alert %}}

## **Работа с пользовательскими XML‑частями**

Метод [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) возвращает коллекцию пользовательских XML‑частей, связанных с конкретным объектом презентации. Например:

- `presentation.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные непосредственно с презентацией.
- `slide.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретным слайдом.
- `shape.getCustomData().getCustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретной фигурой.

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) когда необходимо просмотреть все пользовательские XML‑части в презентации независимо от того, к чему они привязаны.

### **Добавить пользовательскую XML‑часть в презентацию**

Используйте [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) , чтобы добавить XML‑данные в коллекцию пользовательских XML‑частей. XML должен быть корректным и непустым.

Следующий пример добавляет структурированные метаданные в пользовательскую коллекцию данных уровня презентации:

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

    // add автоматически присваивает идентификатор. Устанавливайте конкретный UUID только при необходимости.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Метод `add` также может принимать XML в виде массива байтов или потока ввода, что удобно, когда содержимое XML уже доступно в бинарном виде.

### **Добавить пользовательскую XML‑часть в слайд или фигуру**

Пользовательские XML‑данные могут быть связаны с конкретным слайдом или фигурой вместо всей презентации. Это полезно, когда метаданные описывают лишь один объект, например, ключ шаблона, внешний идентификатор записи или информацию о привязке.

Следующий пример добавляет одну пользовательскую XML‑часть к слайду и другую к фигуре:

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

Уровень, на котором добавлена часть, определяет, чья коллекция `getCustomData().getCustomXmlParts()` будет содержать связь с этой частью. Данные уровня презентации подходят для метаданных, охватывающих весь документ, данные уровня слайда — для информации, относящейся к конкретному слайду, а данные уровня фигуры — для метаданных, привязанных к отдельной фигуре.

### **Список и аудит всех пользовательских XML‑частей**

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) , чтобы получить все пользовательские XML‑части из презентации. Каждый [`ICustomXmlPart`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart/) раскрывает свой идентификатор, содержимое XML и связанные схемы пространств имён.

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

`ICustomXmlPart.getNamespaceSchemas()` возвращает XML‑схемы, связанные с пользовательской частью. Эта информация может быть полезна при аудите презентаций, содержащих XML, созданный внешними системами.

### **Чтение и обновление содержимого XML и ItemId**

Используйте [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) и [`setXmlAsString()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) , чтобы работать с XML как со строкой UTF‑8, либо [`getXmlData()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) и [`setXmlData()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) , чтобы работать с необработанными байтами XML.

Метод [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) возвращает UUID, идентифицирующий пользовательскую XML‑часть в документе Office Open XML. Используйте [`setItemId()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) , когда интеграции требуется новый идентификатор.

Следующий пример обновляет содержимое XML и идентификатор:

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

    // Обновить XML в виде строки UTF-8.
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

При вызове `setXmlAsString` или `setXmlData` предоставляйте корректный, непустой XML. Выбирайте одну из представлений в зависимости от того, работает ли приложение преимущественно со строками или с байтовыми данными.

### **Удалить пользовательскую XML‑часть**

Aspose.Slides предоставляет несколько способов удаления пользовательских XML‑данных:

- `ICustomXmlPart.remove` удаляет пользовательскую XML‑часть из презентации.
- `ICustomXmlPartCollection.remove` удаляет конкретную часть из коллекции пользовательских XML‑частей.
- `ICustomXmlPartCollection.removeAt` удаляет часть по указанному индексу в коллекции.
- `ICustomXmlPartCollection.clear` удаляет все части из конкретной коллекции.

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

Если у вас уже есть `ICustomXmlPart` и вы хотите удалить эту часть из презентации, а не работать с конкретной коллекцией, вызовите `customXmlPart.remove()`.

Также можно удалить элемент по индексу:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Очистить все пользовательские XML‑части из коллекции**

Используйте `clear`, когда необходимо удалить все пользовательские XML‑части, связанные с конкретным объектом презентации.

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

`clear` влияет только на выбранную коллекцию. Например, очистка коллекции слайда не очищает коллекции уровня презентации или уровня фигуры.

Чтобы удалить все пользовательские XML‑части в презентации, пройдитесь по `getAllCustomXmlParts()` и удалите каждую часть:

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

В презентации Office Open XML одна и та же пользовательская XML‑часть может быть связана более чем с одним объектом презентации. Например, существующий файл может содержать отношения от нескольких слайдов или фигур к одной и той же базовой пользовательской XML‑части.

Общую часть следует рассматривать как один объект данных с несколькими ссылками:

- Обновление её с помощью `setXmlAsString`, `setXmlData` или `setItemId` изменяет базовую пользовательскую XML‑часть, поэтому изменение применяется везде, где эта часть используется.
- `getItemId()` можно использовать для идентификации одной и той же пользовательской XML‑части при аудите коллекций на уровне объектов.
- Удаление части из конкретной коллекции `getCustomXmlParts()` удаляет её только из этой коллекции. Используйте `ICustomXmlPart.remove()`, когда нужно удалить саму часть из презентации.
- Перед удалением или заменой общей части проверьте коллекции на уровне объектов, чтобы определить, ссылаются ли на неё другие слайды или фигуры.

Перегрузки `add` создают новую пользовательскую XML‑часть из содержимого XML; они не принимают существующий `ICustomXmlPart`. Поэтому общие связи обычно встречаются при загрузке презентаций, которые уже их содержат.

Следующий пример аудита коллекций уровня презентации, слайда и фигуры по `ItemId` и отчёта о частях, на которые ссылаются более чем из одного места:

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

Такой аудит полезен перед изменением или удалением пользовательских XML‑данных в презентациях, созданных внешними системами, поскольку одна и та же метаданные часть может участвовать в более чем одной связи.

## **Получение значений тегов**

В Slides тег соответствует методу `IDocumentProperties.getKeywords()`. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides для Android через Java для [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation):

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

- имени пользовательского свойства, например, `MyTag`;
- значения пользовательского свойства, например, `My Tag Value`.

Если необходимо классифицировать презентации по определённому правилу или свойству, можно добавить теги для этой цели. Например, если вы хотите классифицировать презентации из стран Северной Америки, можно создать тег North American и задать соответствующую страну как его значение.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation) , используя Aspose.Slides для Android через Java:

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

Теги также можно задать для [Slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlide):

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

Теги, добавленные через коллекцию `getCustomData().getTags()`, сохраняются только в файле PowerPoint. При экспорте презентации в PDF они **не** переносятся в структуру тегов PDF. Следовательно, пользовательский идентификатор, назначенный как тег, нельзя получить из PDF с тегами.

**Обходной путь**: Можно сохранить пользовательский идентификатор в **Alt Text** объекта (например, `shape.setAlternativeText("MyId")`). После экспорта в PDF Alt Text может появиться в структуре тегов PDF.

## **FAQ**

**Могу ли я удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/#clear--) , которая удаляет все пары ключ‑значение сразу.

**Как удалить отдельный тег по его имени без перебора всей коллекции?**

Используйте [remove(name)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) у [коллекции тегов](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/) , чтобы удалить тег по его ключу.

**Как получить полный список имён тегов для анализа или фильтрации?**

Используйте [getNamesOfTags](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) у [коллекции тегов](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tagcollection/) ; он возвращает массив всех имён тегов.

**Как найти все пользовательские XML‑части независимо от места их хранения?**

Используйте [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) , чтобы получить все пользовательские XML‑части в презентации.

**Стоит ли использовать `getXmlAsString`/`setXmlAsString` или `getXmlData`/`setXmlData` для обновления пользовательской XML‑части?**

Используйте `getXmlAsString` и `setXmlAsString`, когда приложение работает с текстом XML в кодировке UTF‑8. Используйте `getXmlData` и `setXmlData`, когда XML уже доступен в виде массива байтов или когда более удобно работать с бинарными данными. Оба представления относятся к содержимому одной и той же пользовательской XML‑части.