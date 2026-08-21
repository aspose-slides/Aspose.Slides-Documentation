---
title: "Форматирование фигур PowerPoint в .NET"
linktitle: "Форматирование фигур"
type: docs
weight: 20
url: /ru/net/shape-formatting/
keywords:
- "форматирование фигуры"
- "форматирование линии"
- "эффект эскиза"
- "линия фигуры в стиле эскиза"
- "форматирование стиля соединения"
- "градиентная заливка"
- "заполнение шаблоном"
- "заполнение изображением"
- "заполнение текстурой"
- "сплошная заливка цветом"
- "прозрачность фигуры"
- "чёрно‑белая отрисовка фигуры"
- "отображение фигуры в оттенках серого"
- "поворачивать фигуру"
- "3D‑эффект фаски"
- "3D‑эффект вращения"
- "сброс форматирования"
- "PowerPoint"
- "презентация"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Узнайте, как форматировать фигуры PowerPoint на C# с помощью Aspose.Slides — задавать стили заливки, линий и эффектов для файлов PPT и PPTX с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать их, изменяя или применяя эффекты к их контуру. Кроме того, вы можете форматировать фигуры, указывая параметры, которые контролируют, как заполняются их внутренности.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET предоставляет интерфейсы и свойства, которые позволяют форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/ru/net/aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [dash style](https://reference.aspose.com/slides/ru/net/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код C# демонстрирует, как отформатировать прямоугольный `AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите цвет заливки для фигуры прямоугольника.
    shape.FillFormat.FillType = FillType.NoFill;

    // Примените форматирование к линиям прямоугольника.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Установите цвет линии прямоугольника.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Сохраните файл PPTX на диск.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Результат:

![Форматированные линии в презентации](formatted-lines.png)

## **Применение эффектов эскиза к линиям фигур**

Эффект эскиза делает линию фигуры выглядящей нарисованной от руки. Используйте [IShape.LineFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/lineformat/) для доступа к настройкам линии, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ilineformat/sketchformat/) для доступа к настройкам эскиза и [ISketchFormat.SketchType](https://reference.aspose.com/slides/ru/net/aspose.slides/isketchformat/sketchtype/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/net/aspose.slides/linesketchtype/).

Следующий код C# показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/ru/net/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/ru/net/aspose.slides/linesketchtype/):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

Значение, возвращаемое `ISketchFormat.SketchType`, представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться от темы, шаблона мастера или макета слайда, используйте [ILineFormat.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/ilineformat/geteffective/), доступ к [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ilineformateffectivedata/sketchformat/) и чтение [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/ru/net/aspose.slides/isketchformateffectivedata/sketchtype/). Эффективное значение отражает фактическое применённое форматирование после разрешения наследования:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Форматирование стилей соединения**

Вот три варианта типа соединения:

* Круглое
* Срез
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), он использует настройку **Круглое**. Однако, если вы рисуете фигуру с острыми углами, вам может подойти вариант **Срез**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код C# демонстрирует, как были созданы три прямоугольника (как показано на изображении выше) с использованием настроек типа соединения Срез, Фаска и Круглое:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте три автофигуры типа Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Установите цвет заливки для каждой фигуры прямоугольника.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Установите толщину линии.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Установите цвет линии для каждого прямоугольника.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Установите стиль соединения.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Добавьте текст к каждому прямоугольнику.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Сохраните файл PPTX на диск.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применять к фигуре плавный переход нескольких цветов. Например, вы можете задать два и более цветов так, чтобы один постепенно переходил в другой.

Как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите для фигуры свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) в значение `Gradient`.
1. Добавьте два желаемых цвета с определёнными позициями, используя методы `Add` коллекции градиентных остановок, доступной через интерфейс [IGradientFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код C# демонстрирует, как применить градиентный эффект к эллипсу:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Примените градиентное форматирование к эллипсу.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Установите направление градиента.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Добавьте две градиентные остановки.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Сохраните файл PPTX на диск.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка шаблоном**

В PowerPoint заливка шаблоном — это параметр форматирования, позволяющий применить к фигуре двухцветный узор (точки, полосы, перекрестные штрихи, шахматные клетки и т.д.). Вы можете выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей шаблонов, которые можно применять к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого шаблона вы всё равно можете указать точные цвета, которые он будет использовать.

Как применить шаблонную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите для фигуры свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) в значение `Pattern`.
1. Выберите стиль шаблона из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/ru/net/aspose.slides/ipatternformat/backcolor/) шаблона.
1. Установите [Foreground Color](https://reference.aspose.com/slides/ru/net/aspose.slides/ipatternformat/forecolor/) шаблона.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код C# демонстрирует, как применить шаблонную заливку к прямоугольнику:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Установите стиль шаблона.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Установите цвета фона и переднего плана шаблона.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Сохраните файл PPTX на диск.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Результат:

![Прямоугольник с шаблонной заливкой](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, эффективно используя его как фон фигуры.

Как с помощью Aspose.Slides применить заливку изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите для фигуры свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) в значение `Picture`.
1. Установите режим заливки изображением в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Назначьте это изображение свойству `Picture.Image` объекта `PictureFillFormat` фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Допустим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий код C# демонстрирует, как заполнить фигуру изображением:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Установите тип заливки в Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Установите режим заливки изображением.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Загрузите изображение и добавьте его в ресурсы презентации.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Установите изображение.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Сохраните файл PPTX на диск.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Результат:

![Фигура с заливкой изображением](picture-fill.png)

### **Тайловое изображение в качестве текстуры**

Если вы хотите установить тайловое изображение в качестве текстуры и настроить поведение тайлинга, можете использовать следующие свойства интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/picturefillmode/): Устанавливает режим заливки изображением — `Tile` или `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tilealignment/): Определяет выравнивание тайлов внутри фигуры.
- [TileFlip](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tileflip/): Управляет тем, будет ли тайл отражён по горизонтали, вертикали или обоим направлениям.
- [TileOffsetX](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tileoffsetx/): Задаёт горизонтальное смещение тайла (в пунктах) от начала фигуры.
- [TileOffsetY](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tileoffsety/): Задаёт вертикальное смещение тайла (в пунктах) от начала фигуры.
- [TileScaleX](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tilescalex/): Определяет горизонтальный масштаб тайла в процентах.
- [TileScaleY](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tilescaley/): Определяет вертикальный масштаб тайла в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с тайловой заливкой изображением и настроить параметры тайлинга:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide firstSlide = presentation.Slides[0];

    // Добавьте автофигуру прямоугольника.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Установите тип заливки фигуры в Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Загрузите изображение и добавьте его в ресурсы презентации.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Назначьте изображение фигуре.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Настройте режим заливки изображением и свойства тайлинга.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Сохраните файл PPTX на диск.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Результат:

![Параметры тайлинга](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, заполняющий фигуру одним равномерным цветом. Этот простой фон применяется без градиентов, текстур или шаблонов.

Чтобы применить сплошную заливку цветом к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) фигуры в значение `Solid`.
1. Назначьте желаемый цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код C# демонстрирует, как применить сплошную заливку цветом к прямоугольнику в слайде PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Установите цвет заливки.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Сохраните файл PPTX на диск.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Результат:

![Фигура со сплошной заливкой цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении сплошной, градиентной, изображённой или текстурной заливки к фигурам можно также задавать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более «прозрачной» выглядит фигура, позволяя видеть фон или подлежащие объекты.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) в значение `Solid`.
1. Используйте `Color.FromArgb(alpha, baseColor)`, чтобы задать цвет с прозрачностью (компонент `alpha` контролирует прозрачность).
1. Сохраните презентацию.

Следующий код C# демонстрирует, как применить прозрачный цвет заливки к прямоугольнику:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте сплошную автофигуру прямоугольника.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте прозрачную автофигуру прямоугольника поверх сплошной фигуры.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Сохраните файл PPTX на диск.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы вращать фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство `Rotation` фигуры в нужный угол.
1. Сохраните презентацию.

Следующий код C# демонстрирует, как вращать фигуру на 5 градусов:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Поверните фигуру на 5 градусов.
    shape.Rotation = 5;

    // Сохраните файл PPTX на диск.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D‑эффектов фаски**

Aspose.Slides позволяет применять 3D‑эффекты фаски к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/).

Чтобы добавить 3D‑эффекты фаски к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Настройте свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/) фигуры, определяя параметры фаски.
1. Сохраните презентацию.

Следующий код C# показывает, как применить 3D‑эффекты фаски к фигуре:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте фигуру на слайд.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Установите свойства ThreeDFormat фигуры.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Сохраните презентацию как файл PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Результат:

![3D‑эффект фаски](3D-bevel-effect.png)

## **Добавление 3D‑эффектов вращения**

Aspose.Slides позволяет применять 3D‑эффекты вращения к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойства [CameraType](https://reference.aspose.com/slides/ru/net/aspose.slides/icamera/cameratype/) и [LightType](https://reference.aspose.com/slides/ru/net/aspose.slides/ilightrig/lighttype/) фигуры, определяя 3D‑вращение.
1. Сохраните презентацию.

Следующий код C# демонстрирует, как применить 3D‑эффекты вращения к фигуре:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Сохраните презентацию как файл PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Результат:

![3D‑эффект вращения](3D-rotation-effect.png)

## **Управление черно‑белой отрисовкой фигур**

Свойство [IShape.BlackWhiteMode](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/blackwhitemode/) определяет, как отдельная фигура отображается, когда презентация просматривается или обрабатывается в чёрно‑белом режиме. Оно не включает черно‑белый режим само по себе и не изменяет заливку, линию или другие параметры фигур в обычном цветовом режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/ru/net/aspose.slides/blackwhitemode/) для выбора желаемого поведения. Например, `Automatic` позволяет приложению‑просмотрщику выбрать способ конвертации, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` использует только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в чёрно‑белом режиме. `NotDefined` означает, что режим на уровне фигуры не задан.

Следующий код C# создаёт цветную фигуру и заставляет её отображаться серой в чёрно‑белом режиме просмотра:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

В обычном цветовом режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе отображения в чёрно‑белом режиме он использует серый цвет, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, определяя при этом отдельный вид для печати, предпросмотра или других процессов, учитывающих настройки чёрно‑белого отображения презентации.

## **Сброс форматирования**

Следующий код C# показывает, как сбросить форматирование слайда и вернуть позицию, размер и параметры всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutslide/) к их значениям по умолчанию:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Сбросить каждую фигуру на слайде, у которой есть заполнитель в макете.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Влияет ли форматирование фигур на размер конечного файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть пространства файла, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер.

**Как определить фигуры на слайде с одинаковым форматированием, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как идентичные и логически группируйте такие фигуры, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните примеры фигур с нужными стилями в шаблонном наборе слайдов или файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные фигуры и повторно примените их форматирование там, где это требуется.