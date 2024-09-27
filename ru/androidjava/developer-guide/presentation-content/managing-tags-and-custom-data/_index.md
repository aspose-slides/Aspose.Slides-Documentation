---
title: Управление метками и пользовательскими данными
type: docs
weight: 300
url: /ru/androidjava/managing-tags-and-custom-data

---

## Хранение данных в файловых презентациях

Файлы PPTX — это элементы с расширением .pptx, которые хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

Слайд является одним из элементов в презентациях, а часть слайда содержит содержание одного слайда. Части слайда могут иметь явные связи с несколькими частями — такими как пользовательские метки — определенными ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователя могут существовать в виде меток ([ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Метки по сути представляют собой пары значений с ключами строк. 

{{% /alert %}} 

## Получение значений меток

В слайдах метка соответствует методам [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) и [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Этот пример кода показывает, как получить значение метки с помощью Aspose.Slides для Android через Java для [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## Добавление меток в презентации

Aspose.Slides позволяет добавлять метки в презентации. Метка обычно состоит из двух предметов: 

- имя пользовательского свойства - `MyTag` 
- значение пользовательского свойства - `My Tag Value`

Если вам нужно классифицировать некоторые презентации на основе конкретного правила или свойства, то вы можете получить выгоду от добавления меток к таким презентациям. Например, если вы хотите категоризировать или объединить все презентации из североамериканских стран, вы можете создать метку "Северная Америка" и затем назначить соответствующие страны (США, Мексика и Канада) в качестве значений. 

Этот пример кода показывает, как добавить метку к [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) с использованием Aspose.Slides для Android через Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Метки также могут быть установлены для [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Или для любого отдельного [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```