---
title: Эллипс
type: docs
weight: 30
url: /java/ellipse/
---


{{% alert color="primary" %}} 

В этой теме мы познакомим разработчиков с добавлением эллиптических фигур на их слайды с использованием Aspose.Slides для Java. Aspose.Slides для Java предоставляет более простой набор API для рисования различных форм всего за несколько строк кода.

{{% /alert %}} 

## **Создать эллипс**
Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа Эллипс с помощью метода [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили эллипс на первый слайд.

```java
// Создаем экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавляем автофигуру типа эллипс
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Записываем файл PPTX на диск
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создать форматированный эллипс**
Чтобы добавить более красиво оформленный эллипс на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа Эллипс с помощью метода [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Установите тип заливки Эллипса на Сплошной.
- Установите цвет Эллипса с помощью свойства SolidFillColor.Color, доступного в объекте [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat), связанном с объектом [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- Установите цвет линий Эллипса.
- Установите ширину линий Эллипса.
- Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили форматированный эллипс на первый слайд презентации.

```java
// Создаем экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем автофигуру типа эллипс
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Применяем форматирование к форме эллипса
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Применяем форматирование к линии Эллипса
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Записываем файл PPTX на диск
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```