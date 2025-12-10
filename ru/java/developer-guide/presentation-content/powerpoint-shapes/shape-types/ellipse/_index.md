---
title: Добавление эллипсов в презентации на Java
linktitle: Эллипс
type: docs
weight: 30
url: /ru/java/ellipse/
keywords:
- эллипс
- фигура
- добавить эллипс
- создать эллипс
- нарисовать эллипс
- отформатированный эллипс
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать, форматировать и управлять формами эллипсов в Aspose.Slides для Java в презентациях PPT и PPTX — включены примеры кода на Java."
---

{{% alert color="primary" %}} 

В этом разделе мы расскажем разработчикам о добавлении эллипсных фигур в их слайды с помощью Aspose.Slides for Java. Aspose.Slides for Java предоставляет более простой набор API для рисования различных видов фигур всего в несколько строк кода.

{{% /alert %}} 

## **Создание эллипса**
Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Ellipse, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Сохраните измененную презентацию в файл PPTX.

В примере ниже мы добавили эллипс на первый слайд
```java
// Создать объект класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавить AutoShape типа Ellipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Сохранить файл PPTX на диск
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создание отформатированного эллипса**
Чтобы добавить более отформатированный эллипс на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Ellipse, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Установите тип заливки эллипса в Solid.
- Установите цвет эллипса, используя свойство SolidFillColor.Color, предоставляемое объектом [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) и связанное с объектом [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- Установите цвет контуров эллипса.
- Установите ширину контуров эллипса.
- Сохраните измененную презентацию в файл PPTX.

В примере ниже мы добавили отформатированный эллипс на первый слайд презентации.
```java
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Применить некоторое форматирование к фигуре эллипса
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Применить некоторое форматирование к линии эллипса
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Сохранить файл PPTX на диск
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Как задать точное положение и размер эллипса относительно единиц слайда?**

Координаты и размеры обычно указываются **в пунктах**. Для предсказуемых результатов основывайте свои вычисления на размере слайда и преобразуйте необходимые миллиметры или дюймы в пункты перед присвоением значений.

**Как разместить эллипс над другими объектами или под ними (управление порядком наложения)?**

Отрегулируйте порядок отрисовки объекта, переместив его на передний план или отправив назад. Это позволяет эллипсу накладываться на другие объекты или раскрывать находящиеся под ним.

**Как анимировать появление или акцентирование эллипса?**

[Применить](/slides/ru/java/shape-animation/) эффекты появления, акцентирования или завершения к фигуре и настройте триггеры и тайминг, чтобы определить, когда и как будет воспроизводиться анимация.