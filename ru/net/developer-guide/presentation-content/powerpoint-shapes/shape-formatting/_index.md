---
title: Форматирование фигур PowerPoint на C#
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/net/shape-formatting/
keywords:
- формат фигуры
- формат линии
- формат стиля соединения
- градиентная заливка
- заливка узором
- заливка изображением
- заливка текстурой
- сплошная заливка цветом
- прозрачность фигуры
- повернуть фигуру
- 3D-скошенный эффект
- 3D-вращение
- сброс форматирования
- PowerPoint
- презентация
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на C# с помощью Aspose.Slides — задавать стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---

## **Обзор**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, вы можете форматировать фигуры, указывая параметры, контролирующие заполнение их внутренней части.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides для .NET предоставляет интерфейсы и свойства, позволяющие форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Задайте [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) фигуры.
1. Установите толщину линии.
1. Задайте [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код C# демонстрирует, как отформатировать прямоугольный `AutoShape`:
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

![The formatted lines in the presentation](formatted-lines.png)

## **Форматирование стилей соединения**

Вот три варианта типа соединения:

* Круглый
* Срез
* Фаска

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется параметр **Круглый**. Однако, если вы рисуете фигуру с острыми углами, вам может подойти вариант **Срез**.

![The join style in the presentation](join-style-powerpoint.png)

Следующий код C# демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек типа соединения Miter, Bevel и Round:
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

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить к фигуре непрерывный переход цветов. Например, можно задать два или более цветов так, чтобы один плавно переходил в другой.

Вот как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Задайте [FillType] фигуры значение `Gradient`.
1. Добавьте два выбранных вами цвета с определёнными позициями, используя методы `Add` коллекции остановок градиента, доступные через интерфейс [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию как файл PPTX.

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

    // Добавьте две остановки градиента.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Сохраните файл PPTX на диск.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```


Результат:

![The ellipse with gradient fill](gradient-fill.png)

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить к фигуре двухцветный рисунок, такой как точки, полосы, перекрестные штрихи или клетки. Вы можете выбрать пользовательские цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения визуального оформления презентаций. После выбора предопределённого узора вы всё равно можете указать точные цвета, которые он будет использовать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Задайте [FillType] фигуры значение `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Задайте [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) узора.
1. Задайте [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) узора.
1. Сохраните изменённую презентацию как файл PPTX.

```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте автофигуру типа Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Установите тип заливки в Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Установите стиль узора.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Установите фоновые и передние цвета узора.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Сохраните файл PPTX на диск.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```


Результат:

![The rectangle with pattern fill](pattern-fill.png)

## **Заливка изображением**

В PowerPoint заливка изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, эффективно используя его в качестве фона фигуры.

Вот как использовать Aspose.Slides для применения заливки изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Задайте [FillType] фигуры значение `Picture`.
1. Установите режим заливки изображением в `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Назначьте это изображение свойству `Picture.Image` объекта `PictureFillFormat` фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

![The lotus picture](lotus.png)

```c#
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

![The shape with picture fill](picture-fill.png)

### **Повторяющееся изображение в качестве текстуры**

Если вы хотите задать повторяющееся изображение в качестве текстуры и настроить поведение повторения, вы можете использовать следующие свойства интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Устанавливает режим заливки изображения — `Tile` или `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Задает выравнивание плиток внутри фигуры.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Определяет, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Устанавливает горизонтальное смещение плитки (в пунктах) от начала координат фигуры.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Устанавливает вертикальное смещение плитки (в пунктах) от начала координат фигуры.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Определяет горизонтальный масштаб плитки в процентах.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с повторяющейся заливкой изображением и настроить параметры плитки:
```c#
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

        // Присвойте изображение фигуре.
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

![The tile options](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, заполняющий фигуру одним равномерным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку цветом к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Задайте [FillType] фигуры значение `Solid`.
1. Назначьте фигуре желаемый цвет заливки.
1. Сохраните изменённую презентацию как файл PPTX.

```c#
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

![The shape with solid color fill](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошную заливку, градиент, изображение или текстуру к фигурам, вы также можете задать уровень прозрачности, чтобы контролировать непрозрачность заливки. Более высокий уровень прозрачности делает фигуру более полупрозрачной, позволяя видеть фон или находящиеся под ней объекты.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Вот как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Задайте [FillType] фигуры значение `Solid`.
1. Используйте `Color.FromArgb(alpha, baseColor)`, чтобы задать цвет с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

```c#
const int alpha = 128;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
using (Presentation presentation = new Presentation())
{
    // Получите первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавьте сплошную прямоугольную автофигуру.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Добавьте прозрачную прямоугольную автофигуру поверх сплошной фигуры.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Сохраните файл PPTX на диск.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```


Результат:

![The transparent shape](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство `Rotation` фигуры на нужный угол.
1. Сохраните презентацию.

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

![The shape rotation](shape-rotation.png)

## **Добавление 3D‑скошенных эффектов**

Aspose.Slides позволяет применять 3D‑скошенные эффекты к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Чтобы добавить 3D‑скошенные эффекты к фигуре, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Настройте [ThreeDFormat] фигуры, чтобы определить параметры скосов.
1. Сохраните презентацию.

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

    // Сохраните презентацию в файл PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```


Результат:

![The 3D bevel effect](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

Aspose.Slides позволяет применять 3D‑вращения к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Задайте [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) и [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) фигуры, чтобы определить 3D‑вращение.
1. Сохраните презентацию.

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

    // Сохраните презентацию в файл PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```


Результат:

![The 3D rotation effect](3D-rotation-effect.png)

## **Сброс форматирования**

Следующий код C# показывает, как сбросить форматирование слайда и вернуть позицию, размер и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) к их значениям по умолчанию:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Сбросьте каждую фигуру на слайде, которая имеет заполнитель в макете.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть пространства файла, а параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер.

**Как определить фигуры на слайде с одинаковым форматированием, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заполнения, линии и эффекты. Если все соответствующие значения совпадают, считайте их стили одинаковыми и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Могу ли я сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните примеры фигур с нужными стилями в наборе шаблонных слайдов или в файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.