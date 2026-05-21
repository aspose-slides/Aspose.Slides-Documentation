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
## **Обзор**

Эта статья объясняет, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Кратко описывается, как данные хранятся в файлах PPTX, отмечается, что данные, специфичные для презентации, могут существовать в виде тегов и пользовательских XML‑частей, и теги описываются как парные строки «ключ‑значение».

Также показано, как читать значения тегов и как добавлять теги в презентацию, отдельный слайд или форму. Кроме того, в статье рассматриваются распространённые задачи управления тегами, такие как очистка всех тегов, удаление тега по имени и получение списка имён тегов.

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях.

При этом *slide* (слайд) является одним из элементов презентации, а *slide part* (часть слайда) содержит содержимое отдельного слайда. Части слайдов могут иметь явные связи со многими частями — например, пользовательскими тегами, определёнными в ISO/IEC 29500.

Пользовательские данные (специфичные для презентации) могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITagCollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Теги по сути являются парами строк «ключ‑значение». 
{{% /alert %}} 

## **Получение значений тегов**

В Slides тег соответствует методам [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IDocumentProperties#getKeywords--) и [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Java для [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation):

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

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, добавление тегов может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, можно создать тег «North American» и задать в качестве значений соответствующие страны (США, Мексика и Канада).

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) с помощью Aspose.Slides for Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Теги также можно установить для [Slide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Или для любой отдельной [Shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape):

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

### **Ограничения**

Теги, добавленные через коллекцию пользовательских данных с помощью `getCustomData().getTags()`, хранятся только внутри файла PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, присвоенный как тег, не может быть получен из PDF с тегами.

**Обходной путь**: можно сохранить пользовательский идентификатор в **Alt Text** объекта (например, `shape.setAlternativeText("MyId")`). После экспорта в PDF Alt Text может появиться в структуре тегов PDF.

## **Часто задаваемые вопросы**

**Могу ли я удалить все теги из презентации, слайда или формы одной операцией?**

Да. [Tag collection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/#clear--) , которая удаляет все пары ключ‑значение сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте операцию [Remove(name)](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) у [tag collection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/#getNamesOfTags--) у [tag collection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tagcollection/); он возвращает массив всех имён тегов.