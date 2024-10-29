---
title: Линия
type: docs
weight: 50
url: /ru/androidjava/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides для Android на Java поддерживает добавление различных видов фигур на слайды. В этой теме мы начнем работать с фигурами, добавляя линии на слайды. Используя Aspose.Slides для Android на Java, разработчики могут не только создавать простые линии, но и рисовать некоторые интересные линии на слайдах.

{{% /alert %}} 

## **Создание простой линии**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа линия с помощью метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Сохраните измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили линию на первый слайд презентации.

```java
// Создайте экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавьте автофигуру типа линия
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Сохраните PPTX на диске
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создание линии в форме стрелки**

Aspose.Slides для Android на Java также позволяет разработчикам настраивать некоторые свойства линии, чтобы сделать ее более привлекательной. Давайте попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа линия с помощью метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Установите [Стиль линии](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) на один из стилей, предлагаемых Aspose.Slides для Android на Java.
- Установите ширину линии.
- Установите [Стиль штриха](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) линии на один из стилей, предлагаемых Aspose.Slides для Android на Java.
- Установите [Стиль наконечника стрелки](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) и [Длину](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Стиль наконечника стрелки](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) и [Длину](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) конечной точки линии.
- Сохраните измененную презентацию в файл PPTX.

```java
// Создайте экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавьте автофигуру типа линия
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Примените некоторое форматирование к линии
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Сохраните PPTX на диске
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```