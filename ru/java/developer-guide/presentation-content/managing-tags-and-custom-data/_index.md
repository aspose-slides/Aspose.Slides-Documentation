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
- добавление тега
- парные значения
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, считывать, обновлять и удалять теги и пользовательские данные в Aspose.Slides для Java, с примерами для презентаций PowerPoint и OpenDocument."
---

## **Хранение данных в презентационных файлах**

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

Поскольку *слайд* является одним из элементов презентаций, *часть слайда* содержит содержание отдельного слайда. Части слайда могут иметь явные связи со многими частями — например, с пользовательскими тегами, определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 
Теги по сути представляют собой пары строка‑ключ. 
{{% /alert %}} 

## **Получение значений тегов**

В слайдах тег соответствует методам [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) и [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Java для [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation):
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов: 

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, то добавление тегов к этим презентациям может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, вы можете создать тег «North American» и задать соответствующие страны (США, Мексика и Канада) в качестве значений. 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) с помощью Aspose.Slides for Java:
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


## **FAQ**

**Могу ли я удалить все теги из презентации, слайда или фигуры одним действием?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--) , которая удаляет все пары ключ‑значение сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Вызовите операцию [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) у [коллекции тегов](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--) у [коллекции тегов](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/); она возвращает массив всех имён тегов.