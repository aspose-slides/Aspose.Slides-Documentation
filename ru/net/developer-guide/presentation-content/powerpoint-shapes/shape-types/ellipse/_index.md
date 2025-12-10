---
title: Добавление эллипсов в презентации на .NET
linktitle: Эллипс
type: docs
weight: 30
url: /ru/net/ellipse/
keywords:
- эллипс
- фигура
- добавить эллипс
- создать эллипс
- нарисовать эллипс
- отформатированный эллипс
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать, форматировать и управлять фигурами‑эллипсами в Aspose.Slides для .NET в презентациях PPT и PPTX — включены примеры кода на C#."
---

## **Создать эллипс**
В этом разделе мы познакомим разработчиков с добавлением эллипсов на слайды с помощью Aspose.Slides для .NET. Aspose.Slides для .NET предоставляет упрощённый набор API для рисования различных фигур всего несколькими строками кода. Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. Получите ссылку на слайд, используя его индекс
1. Добавьте AutoShape типа Ellipse, используя метод AddAutoShape, предоставляемый объектом IShapes
1. Сохраните изменённую презентацию в файл PPTX

В приведённом ниже примере мы добавили эллипс на первый слайд.
```c#
// Создайте экземпляр класса Presentation, представляющего PPTX
using (Presentation pres = new Presentation())
{

    // Получите первый слайд
    ISlide sld = pres.Slides[0];

    // Добавьте AutoShape типа Ellipse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Сохраните файл PPTX на диск
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```




## **Создать отформатированный эллипс**
Чтобы добавить более отформатированный эллипс на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте AutoShape типа Ellipse, используя метод AddAutoShape, предоставляемый объектом IShapes.
1. Установите тип заливки эллипса в Solid.
1. Задайте цвет эллипса с помощью свойства SolidFillColor.Color, предоставляемого объектом FillFormat, связанным с объектом IShape.
1. Установите цвет линий эллипса.
1. Установите толщину линий эллипса.
1. Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили отформатированный эллипс на первый слайд презентации.
```c#
 // Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of ellipse type
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Apply some formatting to ellipse shape
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Apply some formatting to the line of Ellipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Write the PPTX file to disk
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Как задать точное положение и размер эллипса относительно единиц измерения слайда?**

Координаты и размеры обычно указываются **в пунктах**. Чтобы получить предсказуемые результаты, основывайте вычисления на размере слайда и преобразуйте требуемые миллиметры или дюймы в пункты перед присвоением значений.

**Как разместить эллипс поверх или под другими объектами (управление порядком наложения)?**

Измените порядок отрисовки объекта, переместив его на передний план или отправив назад. Это позволяет эллипсу перекрывать другие объекты или раскрывать находящиеся под ним.

**Как анимировать появление или акцентирование эллипса?**

[Apply](/slides/ru/net/shape-animation/) входные, акцентирующие или выходные эффекты к фигуре и настройте триггеры и тайминг, чтобы определить, когда и как анимация будет воспроизводиться.