---
title: Прямоугольник
type: docs
weight: 80
url: /ru/nodejs-java/rectangle/
---

{{% alert color="primary" %}} 

Как и в предыдущих темах, эта также посвящена добавлению фигуры, и на этот раз мы будем рассматривать **Rectangle**. В этой теме мы описали, как разработчики могут добавлять простые или отформатированные прямоугольники в свои слайды, используя Aspose.Slides for Node.js via Java.

{{% /alert %}} 

## **Добавить прямоугольник на слайд**
Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) , предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Сохраните изменённую презентацию в файл PPTX.

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


## **Добавить отформатированный прямоугольник на слайд**
Чтобы добавить отформатированный прямоугольник на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) , предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Установите [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) прямоугольника в значение Solid.
- Задайте цвет прямоугольника с помощью метода [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-), предоставляемого объектом [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat), связанного с объектом [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- Установите цвет линий прямоугольника.
- Установите толщину линий прямоугольника.
- Сохраните изменённую презентацию в файл PPTX.

Вышеприведённые шаги реализованы в примере ниже.
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

Используйте тип фигуры с закруглёнными углами [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) и отрегулируйте радиус скругления в свойствах фигуры; скругление также может быть применено к каждому углу отдельным образом с помощью геометрических корректировок.

**Как заполнить прямоугольник изображением (текстурой)?**

Выберите тип заливки [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), укажите источник изображения и настройте режимы [stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/).

**Может ли прямоугольник иметь тень и свечение?**

Да. Доступны [Outer/inner shadow, glow, and soft edges](/slides/ru/nodejs-java/shape-effect/) с настраиваемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. Можно [Assign a hyperlink](/slides/ru/nodejs-java/manage-hyperlinks/) к щелчку по фигуре (переход к слайду, файлу, веб‑адресу или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**

[Use shape locks](/slides/ru/nodejs-java/applying-protection-to-presentation/): вы можете запретить перемещение, изменение размера, выделение или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [render the shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) в изображение заданного размера/масштаба или [export it as SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) для использования векторного формата.

**Как быстро получить фактические (effective) свойства прямоугольника с учётом темы и наследования?**

[Use the shape’s effective properties](/slides/ru/nodejs-java/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.