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
description: "Узнайте, как добавлять, читать, обновлять и удалять теги и пользовательские данные в Aspose.Slides for PHP via Java, с примерами для презентаций PowerPoint и OpenDocument."
---

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

При том, что *slide* является одним из элементов презентаций, *slide part* содержит содержимое отдельного слайда. Части слайда могут иметь явные связи со многими частями — например, с пользовательскими тегами — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Теги, по сути, представляют собой парные значения строка‑ключ. 

{{% /alert %}} 

## **Получение значений тегов**

В слайдах тег соответствует методам [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) и [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). В этом примере кода показано, как получить значение тега с помощью Aspose.Slides for PHP via Java для [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation):
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

Если вам необходимо классифицировать некоторые презентации по определённому правилу или свойству, то добавление тегов к этим презентациям может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, вы можете создать тег «North American» и назначить в качестве значений соответствующие страны (США, Мексика и Канада). 

В этом примере кода показано, как добавить тег к [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) с использованием Aspose.Slides for PHP via Java:
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


Теги также можно установить для [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide):
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


Или любого отдельного [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape):
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

**Могу ли я удалить все теги из презентации, слайда или формы за одну операцию?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/), которая удаляет все пары ключ‑значение за один раз.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте операцию [Remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) у [коллекции тегов](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/), чтобы удалить тег по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) у [коллекции тегов](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.