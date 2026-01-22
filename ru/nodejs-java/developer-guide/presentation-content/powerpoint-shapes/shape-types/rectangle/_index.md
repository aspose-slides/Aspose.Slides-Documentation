---
title: Добавление прямоугольников в презентации на JavaScript
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/nodejs-java/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- фигура прямоугольника
- простой прямоугольник
- форматированный прямоугольник
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Улучшите ваши презентации PowerPoint, добавляя прямоугольники с помощью JavaScript и Aspose.Slides для Node.js — легко создавайте и изменяйте фигуры программно."
---

{{% alert color="primary" %}} 

Как и в предыдущих темах, эта тоже посвящена добавлению фигуры, и на этот раз мы будем обсуждать **Rectangle**. В этой теме мы описали, как разработчики могут добавлять простые или форматированные прямоугольники в свои слайды, используя Aspose.Slides for Node.js через Java.

{{% /alert %}} 

## **Добавить прямоугольник на слайд**
Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) , предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили простой прямоугольник на первый слайд презентации.
```javascript
// Создать экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа эллипса
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Сохранить файл PPTX на диск
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Добавить форматированный прямоугольник на слайд**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) , предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Установите [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) прямоугольника в Solid.
- Установите цвет прямоугольника, используя метод [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) , предоставляемый объектом [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat), связанным с объектом [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- Установите цвет линий прямоугольника.
- Установите толщину линий прямоугольника.
- Запишите изменённую презентацию в файл PPTX.

Вышеуказанные шаги реализованы в приведённом ниже примере.
```javascript
// Создать экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить AutoShape типа эллипса
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Применить некоторое форматирование к фигуре эллипса
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Применить некоторое форматирование к линии эллипса
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Сохранить файл PPTX на диск
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Как добавить прямоугольник со скруглёнными углами?**

Используйте тип фигуры с закруглёнными углами [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) и отрегулируйте радиус угла в свойствах фигуры; скругление также можно применить к каждому углу отдельно с помощью геометрических корректировок.

**Как заполнить прямоугольник изображением (текстурой)?**

Выберите тип заливки картинкой [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), укажите источник изображения и настройте режимы [stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/).

**Может ли прямоугольник иметь тень и свечение?**

Да. Доступны [внешняя/внутренняя тень, свечение и мягкие края](/slides/ru/nodejs-java/shape-effect/) с настраиваемыми параметрами.

**Можно ли превратить прямоугольник в кнопку со ссылкой?**

Да. [Назначьте гиперссылку](/slides/ru/nodejs-java/manage-hyperlinks/) на клик по фигуре (переход к слайду, файлу, веб-адресу или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**

Используйте блокировки фигуры: можно запретить перемещение, изменение размера, выделение или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [отрисовать фигуру](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) в изображение с заданным размером/масштабом или [экспортировать её как SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) для векторного использования.

**Как быстро получить фактические (эффективные) свойства прямоугольника с учётом темы и наследования?**

[Используйте эффективные свойства фигуры](/slides/ru/nodejs-java/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.