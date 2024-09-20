---
title: Прямоугольник
type: docs
weight: 80
url: /java/rectangle/
---

{{% alert color="primary" %}} 

Как и в предыдущих темах, эта также посвящена добавлению фигуры, и на этот раз мы обсудим фигуру **Прямоугольник**. В этой теме мы описали, как разработчики могут добавлять простые или оформленные прямоугольники в свои слайды с использованием Aspose.Slides для Java.

{{% /alert %}} 

## **Добавление Прямоугольника на Слайд**
Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа Прямоугольник, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили простой прямоугольник на первый слайд презентации.

```java
// Создайте экземпляр класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавьте AutoShape типа эллипс
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Запишите файл PPTX на диск
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление Оформленного Прямоугольника на Слайд**
Чтобы добавить оформленный прямоугольник на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа Прямоугольник, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Установите [Тип Заполнения](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) Прямоугольника на Сплошной.
- Установите Цвет Прямоугольника с помощью метода [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) объекта [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat), связанного с объектом [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- Установите Цвет линий Прямоугольника.
- Установите Ширину линий Прямоугольника.
- Запишите изменённую презентацию в файл PPTX.

Приведённые выше шаги реализованы в следующем примере.

```java
// Создайте экземпляр класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавьте AutoShape типа эллипс
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Примените некоторые форматы к элементу эллипса
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Примените некоторые форматы к линии эллипса
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Запишите файл PPTX на диск
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```