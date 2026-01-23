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

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который входит в спецификацию Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях.  

Слайд (*slide*) является одним из элементов презентаций, а *часть слайда* (*slide part*) содержит содержимое одного слайда. Части слайда могут иметь явные связи со множеством частей — например, с пользовательскими тегами — определёнными в ISO/IEC 29500.  

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде тегов ([TagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/)) и CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 
Теги по своей сути представляют собой пары ключ‑значение в виде строк. 
{{% /alert %}} 

## **Получение значений тегов**

В слайдах тег соответствует методам [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getKeywords) и [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setKeywords). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for PHP via Java для [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation):
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


## **Добавление тегов к презентациям**

Aspose.Slides позволяет добавлять теги к презентациям. Тег обычно состоит из двух элементов:
- имя пользовательского свойства — `MyTag`
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать презентации по определённому правилу или свойству, добавление тегов может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, можно создать тег «North American» и указать в качестве значений соответствующие страны (США, Мексика и Канада).

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) с помощью Aspose.Slides for PHP via Java:
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


Теги также можно установить для [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/):
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


Или для любого отдельного [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/):
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Часто задаваемые вопросы**

**Могу ли я удалить все теги из презентации, слайда или фигуры одним действием?**

Да. [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/), которая удаляет все пары ключ‑значение сразу.

**Как удалить отдельный тег по его имени без перебора всей коллекции?**

Воспользуйтесь операцией [remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) на [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/), чтобы удалить тег по его ключу.

**Как получить полный список имён тегов для анализа или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) у [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.