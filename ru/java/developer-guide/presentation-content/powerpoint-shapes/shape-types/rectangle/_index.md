---
title: Добавление прямоугольников в презентации на Java
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/java/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- фигура прямоугольника
- простой прямоугольник
- форматированный прямоугольник
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Улучшите свои презентации PowerPoint, добавляя прямоугольники с помощью Aspose.Slides for Java — легко создавайте и изменяйте фигуры программно."
---

{{% alert color="primary" %}} 

Как и в предыдущих темах, эта также посвящена добавлению фигуры, и в этот раз мы будем рассматривать **Rectangle**. В этой теме мы описали, как разработчики могут добавлять простые или форматированные прямоугольники на свои слайды с помощью Aspose.Slides for Java.

{{% /alert %}} 

## **Добавить прямоугольник на слайд**
Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили простой прямоугольник на первый слайд презентации.
```java
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа эллипс
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Записать файл PPTX на диск
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Добавить форматированный прямоугольник на слайд**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Установите [Fill Type](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) прямоугольника в Solid.
- Установите цвет прямоугольника с помощью метода [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) объекта [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat), связанного с объектом [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- Установите цвет линий прямоугольника.
- Установите толщину линий прямоугольника.
- Запишите изменённую презентацию в файл PPTX.

Эти шаги реализованы в примере, приведённом ниже.
```java
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа эллипса
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Применить некоторое форматирование к фигуре эллипса
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

**Как добавить прямоугольник со скруглёнными углами?**

Используйте тип фигуры с закруглёнными углами [shape type](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/) и настройте радиус скругления в свойствах фигуры; закругление также можно применить к каждому углу отдельно с помощью геометрических корректировок.

**Как залить прямоугольник изображением (текстурой)?**

Выберите тип заливки [picture fill type](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), укажите источник изображения и настройте режимы [растягивания/повторения](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/).

**Можно ли добавить тень и свечение к прямоугольнику?**

Да. Доступны [внешняя/внутренняя тень, свечение и мягкие края](/slides/ru/java/shape-effect/) с регулируемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. Можно [назначить гиперссылку](/slides/ru/java/manage-hyperlinks/) на клик фигуры (переход к слайду, файлу, веб‑адресу или электронной почте).

**Как защитить прямоугольник от перемещения и изменений?**

[Используйте блокировки фигур](/slides/ru/java/applying-protection-to-presentation/): можно запретить перемещение, изменение размеров, выделение или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растр или SVG?**

Да. Вы можете [отрендерить фигуру](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) в изображение заданного размера/масштаба или [экспортировать её как SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) для векторного использования.

**Как быстро получить фактические (эффективные) свойства прямоугольника с учётом темы и наследования?**

[Используйте эффективные свойства фигуры](/slides/ru/java/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.