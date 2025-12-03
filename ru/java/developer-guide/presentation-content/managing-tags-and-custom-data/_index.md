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
- добавить тег
- парные значения
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, читать, обновлять и удалять теги и пользовательские данные в Aspose.Slides для Java, с примерами для презентаций PowerPoint и OpenDocument."
---

## Хранение данных в файлах презентаций

Файлы PPTX — объекты с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

Слайд (*slide*) является одним из элементов презентаций, часть слайда (*slide part*) содержит содержимое отдельного слайда. Части слайда могут иметь явные связи со многими частями — например, с пользовательскими тегами — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 
Теги представляют собой пары «ключ‑строка». 
{{% /alert %}} 

## Получение значений тегов

В слайдах тег соответствует методам [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) и [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Java для [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation):
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

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать некоторые презентации согласно определённому правилу или свойству, вы можете воспользоваться тегами. Например, чтобы сгруппировать все презентации из стран Северной Америки, можно создать тег «North American» и назначить в качестве значений соответствующие страны (США, Мексика и Канада). 

Этот пример кода демонстрирует, как добавить тег к [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) с помощью Aspose.Slides for Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


Теги также можно задать для [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide):
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


Или для отдельного [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape):
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


## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. [Tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--) , которая удаляет все пары ключ‑значение одновременно. 

**Как удалить отдельный тег по его имени без обхода всей коллекции?**

Вызовите метод [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) у [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) для удаления тега по ключу. 

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--) у [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/); он возвращает массив всех имён тегов.