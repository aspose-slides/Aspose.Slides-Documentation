---
title: Управление тегами и пользовательскими данными в презентациях на Android
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/androidjava/managing-tags-and-custom-data
keywords:
- свойства документа
- тег
- пользовательские данные
- добавить тег
- парные значения
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Добавляйте, читайте, обновляйте и удаляйте теги и пользовательские данные в Aspose.Slides для Android, с примерами на Java для презентаций PowerPoint и OpenDocument."
---

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

Поскольку *слайд* является одним из элементов презентаций, *часть слайда* (slide part) содержит содержимое отдельного слайда. Части слайда могут иметь явные связи со многими другими частями — например, с пользовательскими тегами (User Defined Tags) — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Теги по сути являются парами «строка‑ключ».
{{% /alert %}} 

## **Получение значений тегов**

В слайдах тег соответствует методам [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) и [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides для Android через Java для [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation):
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Добавление тегов к презентациям**

Aspose.Slides позволяет добавлять теги к презентациям. Тег обычно состоит из двух элементов:

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если вам необходимо классифицировать некоторые презентации по определённому правилу или свойству, добавление тегов к этим презентациям может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, вы можете создать тег «North American» и назначить соответствующие страны (США, Мексика и Канада) в качестве значений. 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) с помощью Aspose.Slides для Android через Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


Теги также можно установить для [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide):
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


## **FAQ**

**Могу ли я удалить все теги из презентации, слайда или фигуры за одну операцию?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#clear--) , которая удаляет все пары ключ‑значение сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Выполните операцию [remove(name)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) на [коллекции тегов](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) , чтобы удалить тег по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) у [коллекции тегов](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) ; она возвращает массив всех имён тегов.