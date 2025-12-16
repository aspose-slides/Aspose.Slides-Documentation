---
title: "Добавление эллипсов в презентации на Android"
linktitle: "Эллипс"
type: docs
weight: 30
url: /ru/androidjava/ellipse/
keywords:
- эллипс
- фигура
- добавить эллипс
- создать эллипс
- нарисовать эллипс
- форматированный эллипс
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать, форматировать и управлять формой эллипса в Aspose.Slides для Android в презентациях PPT и PPTX — включены примеры кода на Java."
---

{{% alert color="primary" %}} 
В этой теме мы расскажем разработчикам о добавлении фигур‑эллипсов на их слайды с помощью Aspose.Slides for Android via Java. Aspose.Slides for Android via Java предоставляет более простой набор API для рисования различных фигур всего несколькими строками кода.
{{% /alert %}} 

## **Создание эллипса**
Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Ellipse с помощью метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили эллипс на первый слайд
```java
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавить AutoShape типа ellipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Записать файл PPTX на диск
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создание форматированного эллипса**
Чтобы добавить более оформленный эллипс на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Ellipse с помощью метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Установите тип заливки эллипса в Solid.
- Установите цвет эллипса через свойство SolidFillColor.Color объекта [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat), связанного с объектом [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Установите цвет линий эллипса.
- Установите толщину линий эллипса.
- Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили форматированный эллипс на первый слайд презентации.
```java
// Создать экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа эллипса
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Применить некоторое форматирование к фигуре эллипса
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Применить некоторое форматирование к линии эллипса
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Записать файл PPTX на диск
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Как задать точное положение и размер эллипса относительно единиц измерения слайда?**

Координаты и размеры обычно указываются **в пунктах**. Чтобы получить предсказуемый результат, основывайте вычисления на размере слайда и преобразуйте необходимые миллиметры или дюймы в пункты перед присвоением значений.

**Как разместить эллипс над другими объектами или под ними (управление порядком наложения)?**

Отрегулируйте порядок рисования объекта, переместив его на передний план или отправив назад. Это позволяет эллипсу перекрывать другие объекты или раскрывать находящиеся под ним.

**Как анимировать появление или выделение эллипса?**

[Apply](/slides/ru/androidjava/shape-animation/) эффекты входа, выделения или выхода к форме, и настройте триггеры и тайминг, чтобы управлять тем, когда и как будет воспроизводиться анимация.