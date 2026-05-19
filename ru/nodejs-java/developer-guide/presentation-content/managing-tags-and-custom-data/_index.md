---
title: Управление тегами и пользовательскими данными в презентациях с использованием JavaScript
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/nodejs-java/managing-tags-and-custom-data/
keywords:
- свойства документа
- тег
- пользовательские данные
- добавить тег
- парные значения
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как добавлять, читать, обновлять и удалять теги и пользовательские данные в Aspose.Slides for Node.js, с примерами для презентаций PowerPoint и OpenDocument."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Кратко описывается, как данные хранятся в файлах PPTX, отмечается, что специфичные для презентации данные могут существовать в виде тегов и пользовательских XML‑частей, и поясняется, что теги представляют собой парные строки «ключ‑значение».

Также показано, как считывать значения тегов и как добавлять теги к презентации, отдельному слайду или фигуре. Кроме того, статья охватывает типичные задачи управления тегами, такие как очистка всех тегов, удаление тега по имени и получение списка имён тегов.

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — сохраняются в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

С учётом того, что *слайд* является одним из элементов презентаций, *часть слайда* содержит содержимое отдельного слайда. Части слайда могут иметь явные связи со многими другими частями — например, пользовательскими тегами — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователь могут быть представлены тегами ([TagCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/TagCollection)) и пользовательскими XML‑частями ([CustomXmlPartCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 

Теги по существу являются строковыми парами «ключ‑значение». 

{{% /alert %}} 

## **Получение значений тегов**

В Slides тег соответствует методам [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) и [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Node.js via Java для [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги к презентациям. Тег обычно состоит из двух элементов: 

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, добавление тегов может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, можно создать тег «North American» и указать в качестве значений соответствующие страны (США, Мексика и Канада). 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation) с помощью Aspose.Slides for Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Теги также можно задать для [Slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Или для любой отдельной [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/AutoShape):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ограничения**

Теги, добавленные через коллекцию пользовательских данных `getCustomData().getTags()`, хранятся только внутри файла PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, назначенный как тег, не может быть получен из тегированного PDF.

**Обходное решение**: можно сохранить пользовательский идентификатор в **Alt Text** объекта (например, `shape.setAlternativeText("MyId")`). После экспорта в PDF Alt Text может появиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. [tag collection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/clear/), которая удаляет все пары «ключ‑значение» сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте операцию [remove(name)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) у [tag collection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.