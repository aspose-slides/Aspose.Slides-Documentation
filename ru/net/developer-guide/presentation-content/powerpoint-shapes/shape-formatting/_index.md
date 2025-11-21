---
title: Форматирование фигур PowerPoint в .NET
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
- заливка картинкой
- заливка текстурой
- заливка сплошным цветом
- прозрачность фигуры
- поворот фигуры
- 3D-скошенный эффект
- 3D-вращение
- сброс форматирования
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на C# с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT и PPTX с точностью и полным контролем."
---

## **Обзор**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать их, изменяя или применяя эффекты к их контурам. Кроме того, вы можете форматировать фигуры, указывая параметры, которые контролируют, как заполняются их внутренности.

![форматирование фигуры PowerPoint](format-shape-powerpoint.png)

Aspose.Slides для .NET предоставляет интерфейсы и свойства, которые позволяют форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) фигуры.
1. Задайте ширину линии.
1. Установите [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) линии.
1. Задайте цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

В следующем коде C# показано, как форматировать прямоугольный `AutoShape`:
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

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Круглый
* Прямой
* С фаской

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), он использует настройку **Round**. Однако, если вы рисуете фигуру с острыми углами, вы можете предпочесть вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

В следующем коде C# показано, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек типов соединения Miter, Bevel и Round:
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

    // Установите ширину линий.
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

Вот как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите для [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) фигуры значение `Gradient`.
1. Добавьте два предпочтительных цвета с указанными позициями, используя методы `Add` коллекции остановок градиента, доступные через интерфейс [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

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

    // Задайте направление градиента.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Добавьте два градиентных узла.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Сохраните файл PPTX на диск.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```


Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заливка узором**

В PowerPoint заливка узором — это параметр форматирования, позволяющий применить к фигуре двухцветный рисунок, например точки, полосы, перекрестные штрихи или шахматку. Вы можете задать пользовательские цвета для переднего и заднего плана узора.

Aspose.Slides предлагает более 45 предопределенных стилей узоров, которые можно применить к фигурам для повышения визуальной привлекательности презентаций. Даже после выбора предопределенного узора вы всё равно можете указать точные цвета, которые он будет использовать.

Вот как применить заливку узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите для [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) фигуры значение `Pattern`.
1. Выберите стиль узора из предопределенных вариантов.
1. Задайте [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) узора.
1. Задайте [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) узора.
1. Сохраните изменённую презентацию в файл PPTX.

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

    // Установите фон и передний цвет узора.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Сохраните файл PPTX на диск.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```


Результат:

![Прямоугольник с заливкой узором](pattern-fill.png)

## **Заливка картинкой**

В PowerPoint заливка картинкой — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, фактически используя изображение как фон фигуры.

Вот как с помощью Aspose.Slides применить заливку картинкой к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите для [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) фигуры значение `Picture`.
1. Задайте режим заливки картинкой `Tile` (или другой предпочтительный режим).
1. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) из изображения, которое хотите использовать.
1. Назначьте это изображение свойству `Picture.Image` объекта `PictureFillFormat` фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Предположим, у нас есть файл "lotus.png" со следующим изображением:

![Изображение лотоса](lotus.png)

В следующем коде C# показано, как заполнить фигуру картинкой:

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

    // Установите режим заливки картинкой.
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

![Фигура с заливкой картинкой](picture-fill.png)

### **Тайловая картинка как текстура**

Если вы хотите установить тайловое изображение в качестве текстуры и настроить поведение тайлинга, вы можете использовать следующие свойства интерфейса [IPictureFillFormat] и класса [PictureFillFormat]:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Задает режим заливки картинкой — `Tile` или `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Указывает выравнивание тайлов внутри фигуры.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Определяет, будет ли тайл отражён по горизонтали, вертикали или обоим способам.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Задает горизонтальное смещение тайла (в пунктах) от начала фигуры.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Задает вертикальное смещение тайла (в пунктах) от начала фигуры.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Определяет горизонтальный масштаб тайла в процентах.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Определяет вертикальный масштаб тайла в процентах.

В следующем примере кода показано, как добавить прямоугольную фигуру с тайловой заливкой картинкой и настроить параметры тайлов:

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

    // Настройте режим заливки картинкой и свойства тайлинга.
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

![Параметры тайлов](tile-options.png)

## **Заливка сплошным цветом**

В PowerPoint заливка сплошным цветом — это параметр форматирования, который заполняет фигуру одним однородным цветом. Этот простой цвет фона используется без градиентов, текстур или узоров.

Чтобы применить заливку сплошным цветом к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите для [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) фигуры значение `Solid`.
1. Назначьте желаемый цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

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

![Фигура со сплошной заливкой](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете к фигурам сплошную заливку, градиент, картинку или текстуру, вы также можете задать уровень прозрачности, чтобы контролировать непрозрачность заливки. Более высокое значение прозрачности делает фигуру более прозрачной, позволяя частично видеть фон или находящиеся под ней объекты.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Вот как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите для [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) фигуры значение `Solid`.
1. Используйте `Color.FromArgb(alpha, baseColor)`, чтобы определить цвет с прозрачностью (компонент `alpha` управляет прозрачностью).
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

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы вращать фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите свойство `Rotation` фигуры в нужный угол.
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

![Вращение фигуры](shape-rotation.png)

## **Добавить 3D-скошенные эффекты**

Aspose.Slides позволяет применять к фигурам 3D-скошенные эффекты, настраивая их свойства [ThreeDFormat].

Чтобы добавить к фигуре 3D-скошенный эффект, выполните следующие действия:

1. Создайте экземпляр класса [Presentation].
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Настройте [ThreeDFormat] фигуры, чтобы задать параметры скосов.
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

    // Сохраните презентацию в виде файла PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```


Результат:

![Эффект 3D-скосов](3D-bevel-effect.png)

## **Добавить 3D-вращение**

Aspose.Slides позволяет применять к фигурам 3D-вращения, настраивая их свойства [ThreeDFormat].

Чтобы применить к фигуре 3D-вращение:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) на слайд.
1. Установите для фигуры свойства [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) и [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), чтобы задать 3D‑вращение.
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

    // Сохраните презентацию в виде файла PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```


Результат:

![Эффект 3D-вращения](3D-rotation-effect.png)

## **Сброс форматирования**

В следующем коде C# показано, как сбросить форматирование слайда и вернуть позицию, размер и форматирование всех фигур с заполнителями на [LayoutSlide] к их настройкам по умолчанию:
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Сбросить каждую фигуру на слайде, имеющую заполнитель в макете.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```


## **Часто задаваемые вопросы**

**Влияет ли форматирование фигур на размер конечного файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть места, а параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не увеличивают размер файла.

**Как определить фигуры на слайде с одинаковым форматированием, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффекты. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Могу ли я сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблон набора слайдов или в файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.