---
title: Эллипс
type: docs
weight: 30
url: /ru/net/ellipse/
keywords: "Эллипс, фигура PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Создать эллипс в презентации PowerPoint на C# или .NET"
---

## **Создать эллипс**
В этом разделе мы расскажем разработчикам, как добавить эллиптические фигуры на слайды с помощью Aspose.Slides для .NET. Aspose.Slides для .NET предоставляет упрощённый набор API для рисования разных видов фигур всего в несколько строк кода. Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. Получите ссылку на слайд, используя его Index
3. Добавьте AutoShape типа Ellipse, используя метод AddAutoShape, доступный через объект IShapes
4. Запишите изменённую презентацию в файл PPTX

В примере ниже мы добавили эллипс на первый слайд.
```c#
// Создать экземпляр класса Prseetation, представляющего PPTX
using (Presentation pres = new Presentation())
{

    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить autoshape типа ellipse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Сохранить файл PPTX на диск
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Создать отформатированный эллипс**
Чтобы добавить более оформленный эллипс на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. Получите ссылку на слайд, используя его Index
3. Добавьте AutoShape типа Ellipse, используя метод AddAutoShape, доступный через объект IShapes
4. Установите тип заливки эллипса в Solid
5. Установите цвет эллипса, используя свойство SolidFillColor.Color, доступное через объект FillFormat, связанный с объектом IShape
6. Установите цвет линий эллипса
7. Установите ширину линий эллипса
8. Запишите изменённую презентацию в файл PPTX

В примере ниже мы добавили отформатированный эллипс на первый слайд презентации.
```c#
 // Создать экземпляр класса Presentation, представляющего PPTX
 using (Presentation pres = new Presentation())
 {
 
     // Получить первый слайд
     ISlide sld = pres.Slides[0];
 
     // Добавить autoshape типа Ellipse
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     // Применить некоторое форматирование к фигуре-эллипсу
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // Применить некоторое форматирование к линии эллипса
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     // Записать файл PPTX на диск
     pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
 }
```


## **FAQ**

**Как задать точные позицию и размер эллипса относительно единиц измерения слайда?**

Координаты и размеры обычно указываются **в точках**. Для предсказуемых результатов рассчитывайте значения исходя из размера слайда и преобразуйте необходимые миллиметры или дюймы в точки перед их назначением.

**Как разместить эллипс выше или ниже других объектов (управление порядком наложения)?**

Отрегулируйте порядок рисования объекта, переместив его на передний план или отправив назад. Это позволяет эллипсу перекрывать другие объекты или показывать те, что находятся под ним.

**Как анимировать появление или акцентирование эллипса?**

[Применить](/slides/ru/net/shape-animation/) эффекты входа, акцента или выхода к фигуре и настроить триггеры и тайминг, чтобы определить, когда и как будет воспроизводиться анимация.