---
title: "Линия"
type: docs
weight: 50
url: /ru/net/Line/
keywords: "Линия, фигура PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Добавить линию в презентацию PowerPoint на C# или .NET"
---

Aspose.Slides for .NET поддерживает добавление разных видов фигур на слайды. В этой теме мы начнём работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides for .NET разработчики могут не только создавать простые линии, но и рисовать на слайдах некоторые сложные линии.

## **Создать простую линию**
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line, используя метод [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index), предоставляемый объектом Shapes.
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```c#
// Создайте экземпляр класса PresentationEx, представляющий файл PPTX
using (Presentation pres = new Presentation())
{
    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить автофигуру типа line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Записать PPTX на диск
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Создать линию со стрелкой**
Aspose.Slides for .NET также позволяет разработчикам настраивать некоторые свойства линии, чтобы она выглядела более привлекательно. Попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line, используя метод AddAutoShape, предоставляемый объектом Shapes.
- Установите стиль линии (Line Style) в один из стилей, предлагаемых Aspose.Slides for .NET.
- Установите ширину (Width) линии.
- Установите [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) линии в один из стилей, предлагаемых Aspose.Slides for .NET.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) и длину (Length) начальной точки линии.
- Установите Arrow Head Style и длину (Length) конечной точки линии.
- Запишите изменённую презентацию в файл PPTX.
```c#
// Создайте экземпляр класса PresentationEx, представляющий файл PPTX
using (Presentation pres = new Presentation())
{

    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить автофигуру типа line
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Применить некоторое форматирование к линии
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) автоматически не становится соединителем. Чтобы она «прилипала» к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) и [соответствующие API](/slides/ru/net/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и трудно определить окончательные значения?**

[Читайте эффективные свойства](/slides/ru/net/shape-effective-properties/) через классы [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Могу ли я заблокировать линию от изменения (перемещения, изменения размера)?**

    //Записать PPTX на диск
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) автоматически не превращается в соединитель. Чтобы она «прилипала» к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) и [соответствующие API](/slides/ru/net/connector/) для соединений.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Прочитайте вычисленные свойства](/slides/ru/net/shape-effective-properties/) через интерфейсы [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/) и [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Can I lock a line against editing (moving, resizing)?**

Да. Фигуры предоставляют [объекты блокировки](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/), которые позволяют вам [запретить операции редактирования](/slides/ru/net/applying-protection-to-presentation/).
