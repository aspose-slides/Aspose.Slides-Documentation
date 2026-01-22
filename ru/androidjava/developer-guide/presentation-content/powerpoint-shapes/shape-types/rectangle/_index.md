---
title: Добавление прямоугольников в презентации на Android
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/androidjava/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- прямоугольная фигура
- простой прямоугольник
- форматированный прямоугольник
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Улучшите свои презентации PowerPoint, добавляя прямоугольники с помощью Aspose.Slides для Android через Java — легко создавайте и изменяйте фигуры программно."
---

{{% alert color="primary" %}} 

Как и в предыдущих темах, эта тоже посвящена добавлению фигуры, и на этот раз мы будем рассматривать **Rectangle**. В этой теме мы описали, как разработчики могут добавлять простые или форматированные прямоугольники в свои слайды, используя Aspose.Slides for Android через Java.

{{% /alert %}} 

## **Добавление прямоугольника на слайд**
Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили простой прямоугольник на первый слайд презентации.
```java
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа эллипса
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Записать файл PPTX на диск
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Добавление форматированного прямоугольника на слайд**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Установите [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) прямоугольника в Solid.
- Установите цвет прямоугольника с помощью метода [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) объекта [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat), связанного с объектом [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Установите цвет линий прямоугольника.
- Установите толщину линий прямоугольника.
- Запишите изменённую презентацию в файл PPTX.

Вышеописанные шаги реализованы в примере ниже.
```java
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа эллипса
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Применить некоторое форматирование к форме эллипса
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Применить некоторое форматирование к линии эллипса
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Записать файл PPTX на диск
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Как добавить прямоугольник с закруглёнными углами?**

Используйте тип фигуры с закруглёнными углами [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) и настройте радиус закругления в свойствах фигуры; закругление можно также применять к каждому углу отдельно с помощью геометрических настроек.

**Как залить прямоугольник изображением (текстурой)?**

Выберите тип заливки [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), укажите источник изображения и настройте [режимы растяжения/мозаики](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/).

**Можно ли добавить к прямоугольнику тень и свечение?**

Да. Доступны [внешняя/внутренняя тень, свечение и мягкие края](/slides/ru/androidjava/shape-effect/) с настраиваемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. [Назначьте гиперссылку](/slides/ru/androidjava/manage-hyperlinks/) при щелчке по фигуре (переход к слайду, файлу, веб‑адресу или email).

**Как защитить прямоугольник от перемещения и изменений?**

Используйте блокировки фигур: можно запретить перемещение, изменение размеров, выделение или редактирование текста, чтобы сохранить расположение.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [отрендерить фигуру](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) в изображение заданного размера/масштаба или [экспортировать её как SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) для векторного использования.

**Как быстро получить реальные (эффективные) свойства прямоугольника с учётом темы и наследования?**

[Используйте эффективные свойства фигуры](/slides/ru/androidjava/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.