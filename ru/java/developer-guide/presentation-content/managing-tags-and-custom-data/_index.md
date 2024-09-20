---
title: Управление тегами и пользовательскими данными
type: docs
weight: 300
url: /java/managing-tags-and-custom-data

---

## Хранение данных в презентационных файлах

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях.

Слайд является одним из элементов презентаций, а часть слайда содержит контент одного слайда. Часть слайда может иметь явные отношения ко многим частям — таким как пользовательские теги — определенные стандартом ISO/IEC 29500.

Пользовательские данные (специфичные для презентации) или пользователя могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Теги по сути являются парами значений с ключом-строкой.

{{% /alert %}} 

## Получение значений тегов

В слайдах тег соответствует методам [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) и [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides для Java для [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## Добавление тегов в презентации

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов: 

- имя пользовательского свойства - `MyTag` 
- значение пользовательского свойства - `My Tag Value`

Если вам нужно классифицировать некоторые презентации на основе определенного правила или свойства, то вы можете получить выгоду от добавления тегов к этим презентациям. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, вы можете создать тег Северной Америки и затем назначить соответствующие страны (США, Мексика и Канада) как значения.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) с использованием Aspose.Slides для Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Теги также могут быть установлены для [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Или для любого отдельного [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape):

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