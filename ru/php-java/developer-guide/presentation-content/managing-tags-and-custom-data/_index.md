---
title: Управление тегами и пользовательскими данными
type: docs
weight: 300
url: /ru/php-java/upravlenie-tegam-i-polzovatelskimi-dannymi

---

## Хранение данных в файлах презентации

Файлы PPTX — это элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях.

Каждый *слайд* является одним из элементов в презентациях, а *часть слайда* содержит содержимое одного слайда. Часть слайда может иметь явные связи с многими частями—такими как Пользовательские Теги—определенными в ISO/IEC 29500.

Пользовательские данные (специфичные для презентации) или пользователя могут существовать в качестве тегов ([ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Теги по сути представляют собой пары значений с ключом-строкой. 

{{% /alert %}} 

## Получение значений для тегов

В слайдах тег соответствует методам [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) и [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides для PHP через Java для [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation):

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

## Добавление тегов к презентациям

Aspose.Slides позволяет добавлять теги к презентациям. Тег обычно состоит из двух элементов: 

- название пользовательского свойства - `MyTag` 
- значение пользовательского свойства - `My Tag Value`

Если вам нужно классифицировать некоторые презентации на основе конкретного правила или свойства, вы можете извлечь выгоду из добавления тегов к этим презентациям. Например, если вы хотите категоризировать или объединить все презентации из стран Северной Америки, вы можете создать тег Северной Америки и затем назначить соответствующие страны (США, Мексика и Канада) в качестве значений.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) с использованием Aspose.Slides для PHP через Java:

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

Теги также могут быть установлены для [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide):

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

Или для любого отдельного [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape):

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