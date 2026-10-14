---
title: Форматирование фигур PowerPoint в .NET
linktitle: Форматирование формы
type: docs
weight: 20
url: /ru/net/shape-formatting/
keywords:
- формат формы
- формат линии
- эффект наброска
- эскиз линии формы
- стиль соединения
- градиентная заливка
- заполнение узором
- заполнение изображением
- заполнение текстурой
- заполнение сплошным цветом
- прозрачность формы
- черно-белое отображение формы
- отображение формы в градациях серого
- вращение формы
- 3D-эффект фаски
- 3D-эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в C# с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT и PPTX с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять формы на слайды. Поскольку формы состоят из линий, вы можете форматировать их, изменяя или применяя эффекты к контуру. Кроме того, вы можете форматировать формы, задавая параметры, которые контролируют, как заполняются их внутренности.

![формат-формы-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET предоставляет интерфейсы и свойства, позволяющие форматировать формы с теми же параметрами, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для формы. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите [стиль линии](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) формы.
1. Установите ширину линии.
1. Установите [тип штриха](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для формы.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код на C# демонстрирует, как форматировать прямоугольник `AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Прямоугольник.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите цвет заливки для прямоугольной фигуры.
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

## **Применение эффектов эскиза к линиям формы**

Эффект эскиза делает линию формы выглядящей нарисованной от руки. Используйте [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) для доступа к параметрам линии, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) для доступа к настройкам эскиза и [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Следующий код на C# показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

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

Значение, возвращаемое `ISketchFormat.SketchType`, представляет настройку, назначенную непосредственно форме. Если форматирование линии может наследоваться из темы, шаблона или макета слайда, используйте [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), доступ к [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) и читайте [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Эффективное значение отражает фактическое форматирование после разрешения наследования:

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

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Круглая
* Срез
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу формы), используется настройка **Круглая**. Однако, если вы рисуете форму с острыми углами, вам может подойти вариант **Срез**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код на C# демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием параметров соединения Срез, Фаска и Круглая:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте три автофигуры типа Прямоугольник.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Установите цвет заливки для каждой прямоугольной фигуры.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Установите ширину линии.
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить непрерывный переход цветов к форме. Например, вы можете применить два или более цветов так, чтобы один плавно переходил в другой.

Ниже описано, как применить градиентную заливку к форме с помощью Aspose.Slides:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) формы в `Gradient`.
1. Добавьте два желаемых цвета с заданными позициями, используя методы `Add` коллекции градиентных остановок, предоставляемой интерфейсом [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код на C# демонстрирует, как применить эффект градиентной заливки к эллипсу:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Элипс.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Примените градиентное форматирование к элипсу.
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

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. раздел [Choose a Gradient Rendering Style](/slides/ru/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга без изменения градиентной заливки, сохранённой в презентации.

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить двухцветный узор (точки, полосы, перекрёстные штрихи или клетки) к форме. Вы можете выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к формам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого узора вы всё равно можете указать точные цвета, которые он будет использовать.

Ниже описано, как применить заливку узором к форме с помощью Aspose.Slides:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) формы в `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) узора.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код на C# демонстрирует, как применить заливку узором к прямоугольнику:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Прямоугольник.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Установите стиль узора.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Установите фон и передний цвет узора.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Сохраните файл PPTX на диск.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Результат:

![Прямоугольник с заливкой узором](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь формы, эффективно используя его как фон формы.

Ниже показано, как с помощью Aspose.Slides применить заливку изображением к форме:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) формы в `Picture`.
1. Установите режим заливки изображения в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Присвойте это изображение свойству `Picture.Image` объекта `PictureFillFormat` формы.
1. Сохраните изменённую презентацию как файл PPTX.

Предположим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий код на C# демонстрирует, как заполнить форму изображением:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Прямоугольник.
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

![Форма с заливкой изображением](picture-fill.png)

### **Текстура из замощённого изображения**

Если вы хотите установить замощённое изображение в качестве текстуры и настроить поведение замощения, можете использовать следующие свойства интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): задаёт режим заливки изображения — `Tile` или `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): определяет выравнивание плиток внутри формы.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): управляет тем, будет ли плитка отражена горизонтально, вертикально или обеими осями.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): задаёт горизонтальное смещение плитки (в пунктах) от начала формы.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): задаёт вертикальное смещение плитки (в пунктах) от начала формы.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): определяет горизонтальный масштаб плитки в процентах.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольную форму с замощённой заливкой изображения и настроить параметры замощения:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide firstSlide = presentation.Slides[0];

    // Добавьте автофигуру прямоугольника.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Установите тип заливки формы в Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Загрузите изображение и добавьте его в ресурсы презентации.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Назначьте изображение форме.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Настройте режим заливки изображением и свойства замощения.
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

![Параметры замощения](tile-options.png)

## **Заливка сплошным цветом**

В PowerPoint заливка сплошным цветом — это параметр форматирования, который заполняет форму одним, одинаковым цветом. Этот однотонный фон применяется без градиентов, текстур или узоров.

Чтобы применить заливку сплошным цветом к форме с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) формы в `Solid`.
1. Задайте желаемый цвет заливки для формы.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код на C# демонстрирует, как применить заливку сплошным цветом к прямоугольнику в слайде PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
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

![Форма со сплошной заливкой цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении заливки сплошным цветом, градиентом, изображением или текстурой к формам вы также можете задать уровень прозрачности, контролирующий непрозрачность заливки. Более высокое значение прозрачности делает форму более полупрозрачной, позволяя фону или вложенным объектам частично просвечивать.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) формы в `Solid`.
1. Используйте `Color.FromArgb(alpha, baseColor)`, чтобы задать цвет с прозрачностью (компонент `alpha` управляет уровнем прозрачности).
1. Сохраните презентацию.

Следующий код на C# демонстрирует, как применить прозрачный цвет заливки к прямоугольнику:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру сплошного прямоугольника.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте автофигуру прозрачного прямоугольника поверх сплошного.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Сохраните файл PPTX на диск.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Результат:

![Прозрачная форма](shape-transparency.png)

## **Вращение форм**

Aspose.Slides позволяет вращать формы в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть форму на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство `Rotation` формы в нужный угол.
1. Сохраните презентацию.

Следующий код на C# демонстрирует, как повернуть форму на 5 градусов:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Поверните форму на 5 градусов.
    shape.Rotation = 5;

    // Сохраните файл PPTX на диск.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Результат:

![Вращение формы](shape-rotation.png)

## **Добавление 3D‑эффектов фаски**

Aspose.Slides позволяет применять 3D‑эффекты фаски к формам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Чтобы добавить 3D‑эффекты фаски к форме, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Настройте свойство [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) формы, задав параметры фаски.
1. Сохраните презентацию.

Следующий код на C# показывает, как применить 3D‑эффекты фаски к форме:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте форму на слайд.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Установите свойства ThreeDFormat формы.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Сохраните презентацию в виде файла PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Результат:

![Эффект 3D‑фаски](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

Aspose.Slides позволяет применять 3D‑вращения к формам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к форме:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойства [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) и [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) формы, определяя 3D‑вращение.
1. Сохраните презентацию.

Следующий код на C# демонстрирует, как применить 3D‑вращения к форме:

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

    // Сохраните презентацию в виде файла PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Результат:

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Управление черно‑белым отображением форм**

Свойство [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) определяет, как отдельная форма отображается, когда презентация просматривается или обрабатывается в черно‑белом режиме. Оно не включает режим черно‑белого отображения само по себе и не меняет заливку, контур или другие параметры форматирования формы в обычном цветном режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) для выбора нужного поведения. Например, `Automatic` позволяет приложению‑отображателю выбрать способ конвертации, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` оставляет только чёрный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` скрывает форму в черно‑белом режиме. `NotDefined` означает, что режим для формы не задан.

Следующий код на C# создаёт цветную форму и делает её серой при отображении в черно‑белом режиме:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Сохраните оранжевую заливку в цветном режиме, но отобразите форму с серой окраской в черно‑белом режиме.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

В обычном цветном режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе черно‑белого отображения он будет отображаться серым, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, одновременно определяя отдельный вид для печати, предварительного просмотра или других процессов, учитывающих настройки черно‑белого отображения презентации.

## **Сброс форматирования**

Следующий код на C# показывает, как сбросить форматирование слайда и вернуть положение, размер и параметры всех форм с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) к их значениям по умолчанию:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Сбросить каждую форму на слайде, у которой есть заполнитель в макете.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Влияет ли форматирование форм на конечный размер файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть места, а параметры форм, такие как цвета, эффекты и градиенты, сохраняются как метаданные и почти не увеличивают размер файла.

**Как обнаружить формы на слайде с одинаковым форматированием, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой формы — параметры заливки, линии и эффектов. Если все соответствующие значения совпадают, считайте их стили одинаковыми и логически группируйте такие формы, что упростит последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей форм в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы форм с нужными стилями в шаблоне презентации или файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные формы и повторно примените их форматирование там, где требуется.