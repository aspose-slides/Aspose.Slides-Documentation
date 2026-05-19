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
- добавить тег
- парные значения
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как добавлять, считывать, обновлять и удалять теги и пользовательские данные в Aspose.Slides для PHP через Java, с примерами для презентаций PowerPoint и OpenDocument."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Кратко описывается, как данные сохраняются в файлах PPTX, отмечается, что презентационно‑специфичные данные могут существовать в виде тегов и пользовательских XML‑частей, а также определяется тег как пара строк «ключ‑значение».

Также показывается, как считывать значения тегов и как добавить теги к презентации, отдельному слайду или фигуре. Кроме того, статья охватывает типичные задачи управления тегами, такие как очистка всех тегов, удаление тега по имени и получение списка имён тегов.

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — сохраняются в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

Слайд — один из элементов презентаций, а *часть слайда* (slide part) содержит содержимое отдельного слайда. Части слайда могут иметь явные отношения со множеством других частей — например, пользовательскими тегами — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде тегов ([TagCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/)) и CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}}Теги представляют собой пары строк «ключ‑значение».{{% /alert %}} 

## **Получение значений тегов**

В slides тег соответствует методам [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getKeywords) и [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#setKeywords). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for PHP via Java для [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов: 

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, вы можете воспользоваться тегами. Например, если вы хотите собрать все презентации из стран Северной Америки, можно создать тег «North American» и задать соответствующие страны (США, Мексика, Канада) в качестве значений. 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation) с помощью Aspose.Slides for PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Теги также можно задать для [Slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Или любой отдельной [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ограничения**

Теги, добавленные через коллекцию пользовательских данных с помощью `getCustomData()->getTags()`, сохраняются только внутри файла PowerPoint. Они **не** передаются в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, заданный как тег, нельзя получить из PDF‑файла с тегами.

**Обходной путь**: можно сохранить пользовательский идентификатор в **Alt Text** объекта (например, `$shape->setAlternativeText("MyId")`). После экспорта в PDF Alt Text может появиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/clear/), которая удаляет все пары ключ‑значение сразу.

**Как удалить отдельный тег по имени без перебора всей коллекции?**

Используйте операцию [remove(name)](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/remove/) на [коллекции тегов](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/getnamesoftags/) у [коллекции тегов](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.