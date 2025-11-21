---
title: Управление тегами и пользовательскими данными
type: docs
weight: 300
url: /ru/nodejs-java/managing-tags-and-custom-data
---

## **Хранение данных в файлах презентаций**

Файлы PPTX — файлы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

*Слайд* является одним из элементов презентаций, *часть слайда* содержит содержимое отдельного слайда. Части слайда могут иметь явные отношения со многими частями — например, с пользовательскими тегами, определёнными в ISO/IEC 29500. 

Пользовательские данные (конкретные для презентации) или пользователь могут существовать в виде тегов ([TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TagCollection)) и CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 

Теги представляют собой пары «строка‑ключ‑значение». 

{{% /alert %}} 

## **Получение значений тегов**

В слайдах тег соответствует методам [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) и [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Node.js via Java для [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation):
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

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов: 

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, добавление тегов может быть полезным. Например, если нужно сгруппировать все презентации из стран Северной Америки, можно создать тег «North American» и задать соответствующие страны (США, Мехико и Канаду) в качестве значений. 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) с помощью Aspose.Slides for Node.js via Java:
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


Теги также можно задавать для [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide):
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


Или для любого отдельного [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape):
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


## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/clear/), которая удаляет все пары ключ‑значение сразу.

**Как удалить один тег по имени без перебора всей коллекции?**

Используйте операцию [remove(name)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [getNamesOfTags](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) у [коллекции тегов](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/); она возвращает массив всех имён тегов.