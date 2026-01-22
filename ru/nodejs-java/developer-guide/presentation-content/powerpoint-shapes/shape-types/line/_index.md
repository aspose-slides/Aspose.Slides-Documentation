---
title: Добавить линейные фигуры в презентации на JavaScript
linktitle: Линия
type: docs
weight: 50
url: /ru/nodejs-java/line/
keywords:
- линия
- создать линию
- добавить линию
- простая линия
- настроить линию
- персонализировать линию
- стиль штриха
- наконечник стрелки
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint с помощью JavaScript и Aspose.Slides для Node.js. Откройте свойства, методы и примеры."
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java поддерживает добавление различных видов фигур на слайды. В этой теме мы начнём работать с фигурами, добавляя линии на слайды. С помощью Aspose.Slides for Node.js via Java разработчики могут не только создавать простые линии, но и рисовать на слайдах некоторые декоративные линии.

{{% /alert %}} 

## **Создать простую линию**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) объекта [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Сохраните изменённую презентацию как файл PPTX.

В примере ниже мы добавили линию на первый слайд презентации.
```javascript
// Создать экземпляр класса PresentationEx, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа line
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Записать PPTX на диск
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Создать линию со стрелкой**

Aspose.Slides for Node.js via Java также позволяет разработчикам настраивать некоторые свойства линии, чтобы она выглядела более привлекательно. Попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) объекта [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Установите [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) в один из стилей, предлагаемых Aspose.Slides for Node.js via Java.
- Установите ширину линии.
- Установите [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) линии в один из стилей, предлагаемых Aspose.Slides for Node.js via Java.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) конечной точки линии.
- Сохраните изменённую презентацию как файл PPTX.

```javascript
// Создать экземпляр класса PresentationEx, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа line
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Применить некоторое форматирование к линии
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Записать PPTX на диск
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Могу ли я преобразовать обычную линию в соединитель, чтобы она «прилипала» к фигурам?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/)) автоматически не превращается в соединитель. Чтобы она «прилипала» к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) и [соответствующие API](/slides/ru/nodejs-java/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и трудно определить окончательные значения?**

[Прочитайте эффективные свойства](/slides/ru/nodejs-java/shape-effective-properties/) через классы `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — они уже учитывают наследование и стили темы.

**Могу ли я заблокировать линию от редактирования (перемещения, изменения размера)?**

Да. Фигуры предоставляют [объекты блокировки](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/), которые позволяют запрещать операции редактирования.