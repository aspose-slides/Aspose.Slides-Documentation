---
title: Линия
type: docs
weight: 50
url: /ru/nodejs-java/Line/
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java поддерживает добавление различных видов фигур на слайды. В этой теме мы начнём работать с фигурами, добавляя линии на слайды. С помощью Aspose.Slides for Node.js via Java разработчики могут не только создавать простые линии, но и рисовать некоторые декоративные линии на слайдах.

{{% /alert %}} 

## **Создать простую линию**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) объекта [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```javascript
// Создайте экземпляр класса PresentationEx, который представляет файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получите первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавьте AutoShape типа line
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Сохраните PPTX на диск
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Создать линию в виде стрелки**

Aspose.Slides for Node.js via Java также позволяет разработчикам настраивать некоторые свойства линии, чтобы она выглядела более привлекательно. Давайте попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) объекта [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Установите [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) в один из стилей, предлагаемых Aspose.Slides for Node.js via Java.
- Установите ширину линии.
- Установите [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) линии в один из стилей, предлагаемых Aspose.Slides for Node.js via Java.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) конечной точки линии.
- Запишите изменённую презентацию в файл PPTX.
```javascript
// Создайте экземпляр класса PresentationEx, который представляет файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получите первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавьте AutoShape типа line
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Примените некоторое форматирование к линии
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Сохраните PPTX на диск
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Могу ли я преобразовать обычную линию в соединитель, чтобы она «привязывалась» к объектам?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/)) не преобразуется автоматически в соединитель. Чтобы привязать её к объектам, используйте специализированный тип [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) и [соответствующие API](/slides/ru/nodejs-java/connector/) для соединений.

**Что делать, если свойства линии унаследованы из темы и трудно определить окончательные значения?**

Прочитайте [эффективные свойства](/slides/ru/nodejs-java/shape-effective-properties/) через классы `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — они уже учитывают наследование и стили темы.

**Могу ли я заблокировать линию от редактирования (перемещения, изменения размеров)?**

Да. Фигуры предоставляют [объекты блокировки](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/), позволяющие [запретить операции редактирования](/slides/ru/nodejs-java/applying-protection-to-presentation/).