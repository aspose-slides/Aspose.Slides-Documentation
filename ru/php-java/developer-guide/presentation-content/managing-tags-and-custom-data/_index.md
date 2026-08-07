---
title: Управление тегами и пользовательскими данными в презентациях с использованием PHP
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/php-java/managing-tags-and-custom-data/
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
- PHP
- Aspose.Slides
description: "Узнайте, как управлять тегами и пользовательскими XML‑данными в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java, включая добавление, чтение, обновление, аудит и удаление пользовательских XML‑частей."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Данные, специфичные для презентации, могут быть сохранены в виде тегов или пользовательских XML‑частей. Теги представляют собой простые пары строк «ключ‑значение», тогда как пользовательские XML‑части могут хранить структурированные метаданные и XML‑нагрузки, специфичные для приложения.

Aspose.Slides предоставляет API для добавления, чтения, обновления, аудита и удаления пользовательских XML‑частей на уровнях презентации, слайда и фигуры. Пользовательские XML‑части полезны для интеграций, которые сохраняют информацию, такую как идентификаторы управления документами, состояние рабочего процесса, метаданные соответствия, данные привязки шаблона или другие структурированные данные приложения внутри презентации.

## **Хранение данных в файлах презентаций**

PPTX‑файлы — файлы с расширением `.pptx` — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Office Open XML определяет структуру пакета и отношения, используемые для хранения содержимого презентации и связанных данных.

Презентация содержит несколько частей, соединённых отношениями. Например, часть слайда содержит содержимое одного слайда и может иметь явные отношения к другим частям, определённым в ISO/IEC 29500.

Пользовательские данные могут быть сохранены в виде тегов ([TagCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/)) или пользовательских XML‑частей ([CustomXmlPartCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpartcollection/)). Оба доступны через класс [`CustomData`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Теги хранят простые парные строки «ключ‑значение». Пользовательские XML‑части хранят структурированные данные XML и могут быть связаны с презентацией, слайдом или фигурой.
{{% /alert %}}

## **Работа с пользовательскими XML‑частями**

Метод [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customdata/#getCustomXmlParts) возвращает коллекцию пользовательских XML‑частей, связанных с конкретным объектом презентации. Например:

- `$presentation->getCustomData()->getCustomXmlParts()` содержит пользовательские XML‑части, связанные непосредственно с презентацией.
- `$slide->getCustomData()->getCustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретным слайдом.
- `$shape->getCustomData()->getCustomXmlParts()` содержит пользовательские XML‑части, связанные с конкретной фигурой.

Используйте [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getAllCustomXmlParts), когда необходимо просмотреть все пользовательские XML‑части в презентации, независимо от того, с чем они связаны.

### **Добавить пользовательскую XML‑часть в презентацию**

Используйте [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpartcollection/#add) для добавления XML‑данных в коллекцию пользовательских XML‑частей. XML должен быть корректным и непустым.

В следующем примере добавляются структурированные метаданные в коллекцию пользовательских данных уровня презентации:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add автоматически назначает идентификатор. Устанавливайте конкретный UUID только при необходимости.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Метод `add` также может принимать XML в виде массива байтов или входного потока, что удобно, когда содержимое XML уже доступно в бинарной форме.

### **Добавить пользовательскую XML‑часть в слайд или фигуру**

Пользовательские XML‑данные могут быть связаны с конкретным слайдом или фигурой, а не со всей презентацией. Это полезно, когда метаданные описывают только один объект, например, ключ шаблона, внешний идентификатор записи или информацию о привязке.

В следующем примере добавляется одна пользовательская XML‑часть к слайду и другая к фигуре:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Уровень, на котором добавлена часть, определяет, чья коллекция `getCustomData()->getCustomXmlParts()` будет содержать связь с этой частью. Данные уровня презентации подходят для метаданных, охватывающих весь документ, данные уровня слайда — для информации, принадлежащей конкретному слайду, а данные уровня фигуры — для метаданных, связанных с отдельной фигурой.

### **Список и аудит всех пользовательских XML‑частей**

Используйте [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getAllCustomXmlParts) для получения всех пользовательских XML‑частей из презентации. Каждый [`CustomXmlPart`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpart/) предоставляет свой идентификатор, содержимое XML и связанные схемы пространств имён.

В следующем примере перечисляются все пользовательские XML‑части и их схемы пространств имён:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

`CustomXmlPart::getNamespaceSchemas()` возвращает XML‑схемы, ассоциированные с пользовательской XML‑частью. Эта информация может быть полезна при аудите презентаций, содержащих XML, созданный внешними системами.

### **Чтение и обновление содержимого XML и ItemId**

Используйте [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpart/#getXmlAsString) и [`setXmlAsString()`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpart/#setXmlAsString) для работы с XML в виде строки UTF‑8, либо [`getXmlData()`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpart/#getXmlData) и [`setXmlData()`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpart/#setXmlData) для работы с необработанными байтами XML.

Метод `CustomXmlPart::getItemId()` возвращает UUID, который идентифицирует пользовательскую XML‑часть в документе Office Open XML. Используйте `setItemId()`, когда интеграции требуется новый идентификатор.

В следующем примере обновляются содержимое XML и идентификатор:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Прочитать текущий XML как текст.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Обновить XML как строку UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData предоставляет тот же XML‑контент в виде необработанных байтов.
    $customXmlData = $customXmlPart->getXmlData();

    // Заменить идентификатор, когда требуется интеграция.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

При вызове `setXmlAsString` или `setXmlData` предоставляйте корректный, непустой XML. Используйте один из вариантов в зависимости от того, работает ли приложение в основном со строками или с байтовыми данными.

### **Удаление пользовательской XML‑части**

Aspose.Slides предоставляет несколько способов удаления пользовательских XML‑данных:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpart/#remove) удаляет пользовательскую XML‑часть из презентации.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpartcollection/#remove) удаляет конкретную часть из коллекции пользовательских XML‑частей.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpartcollection/#removeAt) удаляет часть по указанному индексу в коллекции.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpartcollection/#clear) удаляет все части из конкретной коллекции.

В следующем примере удаляется одна пользовательская XML‑часть уровня презентации по ссылке:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Если у вас уже есть `CustomXmlPart` и вы хотите удалить эту часть из презентации, а не обращаться к конкретной коллекции, вызовите `$customXmlPart->remove()`.

Также можно удалить элемент по индексу:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Очистка всех пользовательских XML‑частей в коллекции**

Используйте `clear`, когда необходимо удалить все пользовательские XML‑части, связанные с определённым объектом презентации.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` влияет только на выбранную коллекцию. Например, очистка коллекции слайда не затрагивает коллекции уровня презентации или уровня фигуры.

Чтобы удалить все пользовательские XML‑части в презентации, пройдитесь по `getAllCustomXmlParts()` и удалите каждую часть:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Работа со связанными или общими пользовательскими XML‑частями**

В презентации Office Open XML одна и та же пользовательская XML‑часть может быть ссылкой из более чем одного объекта презентации. Например, существующий файл может содержать отношения от нескольких слайдов или фигур к одной и той же базовой пользовательской XML‑части.

Общую часть следует рассматривать как один объект данных с несколькими ссылками:

- Обновление её с помощью `setXmlAsString`, `setXmlData` или `setItemId` изменяет базовую пользовательскую XML‑часть, поэтому изменение применяется во всех местах, где эта часть используется.
- `getItemId()` можно использовать для идентификации одной и той же пользовательской XML‑части при аудите коллекций на уровне объектов.
- Удаление части из конкретной коллекции `getCustomXmlParts()` удаляет её из этой коллекции. Используйте `CustomXmlPart::remove()`, если сама часть должна быть удалена из презентации.
- Перед удалением или заменой общей части проверьте коллекции на уровне объектов, чтобы определить, ссылаются ли на неё другие слайды или фигуры.

Перегрузки `add` создают новую пользовательскую XML‑часть из XML‑содержимого; они не принимают существующий `CustomXmlPart`. Поэтому общие отношения обычно встречаются при загрузке презентаций, которые уже их содержат.

В следующем примере аудит проводится над коллекциями уровня презентации, слайда и фигуры по `ItemId` и выводятся части, на которые ссылаются более чем из одного места:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Такой аудит полезен перед изменением или удалением пользовательских XML‑данных в презентациях, созданных внешними системами, поскольку одна и та же часть метаданных может участвовать более чем в одной связи.

## **Получение значений тегов**

В слайдах тег соответствует методу `DocumentProperties::getKeywords()`. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for PHP via Java для [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Добавление тегов к презентациям**

Aspose.Slides позволяет добавлять теги к презентациям. Тег обычно состоит из двух элементов:

- имя пользовательского свойства, например, `MyTag`;
- значение пользовательского свойства, например, `My Tag Value`.

Если необходимо классифицировать презентации по определённому правилу или свойству, можно добавить соответствующие теги. Например, если вы хотите классифицировать презентации из стран Северной Америки, можно создать тег North American и установить в качестве значения соответствующую страну.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) с использованием Aspose.Slides for PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Теги также можно установить для [Slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Или для отдельного [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Ограничения**

Теги, добавленные через коллекцию `getCustomData()->getTags()`, хранятся только в файле PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, назначенный как тег, невозможно получить из PDF с тегами.

**Обходное решение**: Вы можете сохранять пользовательский идентификатор в **Alt Text** объекта (например, `$shape->setAlternativeText("MyId")`). После экспорта в PDF Alt Text может появиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/#clear), которая удаляет все парные ключ‑значение единовременно.

**Как удалить один тег по его имени без итерации по всей коллекции?**

Используйте [remove(name)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/#remove) на [коллекции тегов](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/), чтобы удалить тег по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Используйте [getNamesOfTags](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/#getNamesOfTags) на [коллекции тегов](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.

**Как найти все пользовательские XML‑части независимо от места их хранения?**

Используйте [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getAllCustomXmlParts) для получения всех пользовательских XML‑частей в презентации.

**Стоит ли использовать `getXmlAsString`/`setXmlAsString` или `getXmlData`/`setXmlData` для обновления пользовательской XML‑части?**

Используйте `getXmlAsString` и `setXmlAsString`, когда приложение работает с XML‑текстом в кодировке UTF‑8. Используйте `getXmlData` и `setXmlData`, когда XML уже доступен в виде массива байтов или когда удобнее обработка в бинарном виде. Оба представления относятся к содержимому XML одной и той же пользовательской XML‑части.