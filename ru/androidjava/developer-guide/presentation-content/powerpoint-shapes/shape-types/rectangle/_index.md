---
title: Прямоугольник
type: docs
weight: 80
url: /androidjava/rectangle/
---

{{% alert color="primary" %}} 

Как и в предыдущих темах, эта также касается добавления фигуры, и на этот раз фигура, которую мы обсудим, это **Прямоугольник**. В этой теме мы описали, как разработчики могут добавлять простые или отформатированные прямоугольники на свои слайды с помощью Aspose.Slides для Android через Java.

{{% /alert %}} 

## **Добавить прямоугольник на слайд**
Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа Прямоугольник с использованием метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили простой прямоугольник на первый слайд презентации.

```java
// Создание экземпляра класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем фигуру типа прямоугольник
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Сохраняем файл PPTX на диск
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавить отформатированный прямоугольник на слайд**
Чтобы добавить отформатированный прямоугольник на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа Прямоугольник с использованием метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Установите [Тип заливки](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) прямоугольника на Сплошной.
- Установите цвет прямоугольника с помощью метода [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) объекта [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat), связанного с объектом [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Установите цвет линий прямоугольника.
- Установите ширину линий прямоугольника.
- Запишите измененную презентацию в файл PPTX.

Вышеуказанные шаги реализуются в приведенном ниже примере.

```java
// Создание экземпляра класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем фигуру типа прямоугольник
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Применяем некоторые настройки к фигуре прямоугольника
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Применяем некоторые настройки к линии прямоугольника
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Сохраняем файл PPTX на диск
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```