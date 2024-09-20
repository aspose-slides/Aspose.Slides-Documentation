---
title: Линия
type: docs
weight: 50
url: /java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides для Java поддерживает добавление различных видов фигур на слайды. В этой теме мы начнем работать с фигурами, добавляя линии на слайды. Используя Aspose.Slides для Java, разработчики могут не только создавать простые линии, но и рисовать некоторые изысканные линии на слайдах.

{{% /alert %}} 

## **Создать простую линию**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа линия, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Сохраните измененную презентацию в виде файла PPTX.

В приведенном ниже примере мы добавили линию на первый слайд презентации.

```java
// Создать экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавить автофигуру типа линия
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Записать PPTX на диск
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создать линию в форме стрелки**

Aspose.Slides для Java также позволяет разработчикам настраивать некоторые свойства линии, чтобы она выглядела более привлекательно. Давайте попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа линия, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Установите [стиль линии](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) на один из стилей, предлагаемых Aspose.Slides для Java.
- Установите ширину линии.
- Установите [стиль штриха](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) линии на один из стилей, предлагаемых Aspose.Slides для Java.
- Установите [стиль наконечника стрелки](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) и [длину](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [стиль наконечника стрелки](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) и [длину](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) конечной точки линии.
- Сохраните измененную презентацию в виде файла PPTX.

```java
// Создать экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить автофигуру типа линия
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Применить форматирование к линии
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Записать PPTX на диск
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```