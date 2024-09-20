---
title: Эллипс
type: docs
weight: 30
url: /androidjava/ellipse/
---


{{% alert color="primary" %}} 

В этой теме мы познакомим разработчиков с добавлением эллипсов на их слайды с помощью Aspose.Slides для Android на Java. Aspose.Slides для Android на Java предоставляет более простой набор API для рисования различных типов фигур всего в нескольких строках кода.

{{% /alert %}} 

## **Создание эллипса**
Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте Автофигуру типа Эллипс с помощью метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили эллипс на первый слайд.

```java
// Создать экземпляр класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавить Автофигуру типа эллипс
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Записать файл PPTX на диск
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создание отформатированного эллипса**
Чтобы добавить более оформленный эллипс на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте Автофигуру типа Эллипс с помощью метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Установите тип заливки эллипса на Сплошной.
- Установите цвет эллипса с помощью свойства SolidFillColor.Color, как указано в объекте [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat), связанном с объектом [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Установите цвет линий эллипса.
- Установите ширину линий эллипса.
- Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили отформатированный эллипс на первый слайд презентации.

```java
// Создать экземпляр класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить Автофигуру типа эллипс
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Применить форматирование к эллипсу
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Применить форматирование к линиям эллипса
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Записать файл PPTX на диск
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```