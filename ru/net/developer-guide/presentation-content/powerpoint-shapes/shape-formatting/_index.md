---
title: Форматирование фигур PowerPoint в .NET
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/net/shape-formatting/
keywords:
  - формат фигуры
  - формат линии
  - скетч-эффект
  - скетч-линию фигуры
  - стиль соединения
  - градиентная заливка
  - заливка шаблоном
  - заливка изображением
  - заливка текстурой
  - заливка сплошным цветом
  - прозрачность фигуры
  - поворот фигуры
  - эффект 3D-скоса
  - эффект 3D-вращения
  - сброс форматирования
  - PowerPoint
  - презентация
  - .NET
  - C#
  - Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на C# с помощью Aspose.Slides — задавайте стили заполнения, линии и эффектов для файлов PPT и PPTX с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, фигуры можно форматировать, указывая параметры, контролирующие заполнение их внутренностей.

![формат-формы-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET предоставляет интерфейсы и свойства, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже приведена последовательность действий:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/ru/net/aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [dash style](https://reference.aspose.com/slides/ru/net/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код C# демонстрирует, как отформатировать прямоугольник `AutoShape`:

```c#
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

![Отформатированные линии в презентации](formatted-lines.png)

## **Применить эффекты скетча к линиям фигур**

Эффект скетча делает линию фигуры выглядящей нарисованной от руки. Используйте [IShape.LineFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/lineformat/) для доступа к настройкам линии, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ilineformat/sketchformat/) для доступа к настройкам скетча и [ISketchFormat.SketchType](https://reference.aspose.com/slides/ru/net/aspose.slides/isketchformat/sketchtype/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/net/aspose.slides/linesketchtype/).

Следующий код C# показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/ru/net/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/ru/net/aspose.slides/linesketchtype/):

```csharp
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

Значение, возвращаемое `ISketchFormat.SketchType`, представляет настройку, присвоенную непосредственно фигуре. Если форматирование линии может наследоваться от темы, шаблона мастера или макета слайда, используйте [ILineFormat.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/ilineformat/geteffective/), доступ к [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ilineformateffectivedata/sketchformat/), и прочитайте [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/ru/net/aspose.slides/isketchformateffectivedata/sketchtype/). Эффективное значение отражает фактическое форматирование после разрешения наследования:

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется параметр **Round**. Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код C# демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек соединения Miter, Bevel и Round:

```c#
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применять к фигуре плавный переход цветов. Например, можно задать два или более цветов так, чтобы один постепенно переходил в другой.

Как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) фигуры в `Gradient`.
1. Добавьте два желаемых цвета с определёнными позициями, используя методы `Add` коллекции градиентных остановок, доступные через интерфейс [IGradientFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код C# демонстрирует, как применить эффект градиентной заливки к эллипсу:

```c#
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

    // Добавьте две точки градиента.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Сохраните файл PPTX на диск.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка шаблоном**

В PowerPoint заливка шаблоном — это параметр форматирования, позволяющий применить двухцветный узор (точки, полосы, перекрёстные линии или шахматы) к фигуре. Вы можете задать свои цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей шаблонов, которые можно применять к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого шаблона вы всё равно можете указать точные цвета, которые он будет использовать.

Как применить заливку шаблоном к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) фигуры в `Pattern`.
1. Выберите стиль шаблона из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/ru/net/aspose.slides/ipatternformat/backcolor/) шаблона.
1. Установите [Foreground Color](https://reference.aspose.com/slides/ru/net/aspose.slides/ipatternformat/forecolor/) шаблона.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код C# демонстрирует, как применить заливку шаблоном к прямоугольнику:

```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заполнения в Pattern.
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

![Прямоугольник с заливкой шаблоном](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, эффективно используя его в качестве фона фигуры.

Как использовать Aspose.Slides для применения заливки изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) фигуры в `Picture`.
1. Установите режим заливки изображением в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Присвойте это изображение свойству `Picture.Image` формата `PictureFillFormat` фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

Предположим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий код C# демонстрирует, как заполнить фигуру изображением:

```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Установите тип заполнения в Picture.
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

### **Повторять изображение как текстуру**

Если нужно установить повторяющееся изображение в качестве текстуры и настроить поведение повторения, можно использовать следующие свойства интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/picturefillmode/): задаёт режим заливки изображением — `Tile` или `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tilealignment/): определяет выравнивание плиток внутри фигуры.
- [TileFlip](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tileflip/): управляет отражением плитки по горизонтали, вертикали или обоим направлениям.
- [TileOffsetX](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tileoffsetx/): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [TileOffsetY](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tileoffsety/): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [TileScaleX](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tilescalex/): определяет горизонтальный масштаб плитки в процентах.
- [TileScaleY](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/tilescaley/): определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить фигуру‑прямоугольник с повторяющейся заливкой изображением и настроить параметры плитки:

```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide firstSlide = presentation.Slides[0];

    // Добавьте автофигуру прямоугольника.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Установите тип заполнения фигуры в Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Загрузите изображение и добавьте его в ресурсы презентации.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Присвойте изображение фигуре.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Настройте режим заливки изображением и свойства плитки.
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

![Параметры плитки](tile-options.png)

## **Заливка сплошным цветом**

В PowerPoint сплошная цветовая заливка — это параметр форматирования, который заполняет фигуру одним однородным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную цветовую заливку к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) фигуры в `Solid`.
1. Задайте предпочтительный цвет заливки для фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код C# демонстрирует, как применить сплошную цветовую заливку к прямоугольнику в слайде PowerPoint:

```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заполнения в Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Установите цвет заполнения.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Сохраните файл PPTX на диск.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Результат:

![Фигура со сплошной цветовой заливкой](solid-color-fill.png)

## **Установить прозрачность**

В PowerPoint, применяя сплошную заливку, градиент, изображение или текстуру к фигурам, можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Более высокое значение прозрачности делает фигуру более прозрачной, позволяя частично видеть фон или находящиеся под ней объекты.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) в `Solid`.
1. Используйте `Color.FromArgb(alpha, baseColor)`, чтобы определить цвет с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Следующий код C# демонстрирует, как применить прозрачный цвет заливки к прямоугольнику:

```c#
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

## **Поворот фигур**

Aspose.Slides позволяет поворачивать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство `Rotation` фигуры в нужный угол.
1. Сохраните презентацию.

Следующий код C# демонстрирует, как повернуть фигуру на 5 градусов:

```c#
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

![Поворот фигуры](shape-rotation.png)

## **Добавить 3D-скосы**

Aspose.Slides позволяет применять 3D‑скосы к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/).

Чтобы добавить 3D‑скосы к фигуре, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Настройте свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/) фигуры, задав параметры скоса.
1. Сохраните презентацию.

Следующий код C# показывает, как применить 3D‑скосы к фигуре:

```c#
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

![Эффект 3D‑скосов](3D-bevel-effect.png)

## **Добавить 3D‑вращение**

Aspose.Slides позволяет применять 3D‑вращение к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойства [CameraType](https://reference.aspose.com/slides/ru/net/aspose.slides/icamera/cameratype/) и [LightType](https://reference.aspose.com/slides/ru/net/aspose.slides/ilightrig/lighttype/) фигуры, определяя 3D‑вращение.
1. Сохраните презентацию.

Следующий код C# демонстрирует, как применить 3D‑вращение к фигуре:

```c#
// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Сохраните презентацию как файл PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Результат:

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Сброс форматирования**

Следующий код C# показывает, как сбросить форматирование слайда и вернуть позицию, размер и форматирование всех фигур‑заместителей на [LayoutSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutslide/) к их значениям по умолчанию:

```c#
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

**Влияет ли форматирование фигур на итоговый размер файла презентации?**

Только незначительно. Основную часть объёма занимают встроенные изображения и мультимедиа, тогда как параметры фигур, такие как цвета, эффекты и градиенты, сохраняются как метаданные и практически не увеличивают размер файла.

**Как определить фигуры на слайде, у которых одинаковое форматирование, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заполнения, линии и эффектов. Если все соответствующие значения совпадают, считается, что их стили идентичны, и такие фигуры можно логически сгруппировать, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонном наборе слайдов или в файле шаблона `.POTX`. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.