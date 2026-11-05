---
title: Форматировать фигуры PowerPoint в .NET
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/net/shape-formatting/
keywords:
- форматировать форму
- форматировать линию
- эффект эскиза
- линия фигуры в виде эскиза
- форматировать стиль соединения
- градиентная заливка
- узорная заливка
- заливка изображением
- текстурная заливка
- сплошная заливка цветом
- прозрачность фигуры
- чёрно‑белая отрисовка фигуры
- оттенки серого для фигуры
- повернуть фигуру
- 3D‑эффект фаски
- 3D‑эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в C# с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT и PPTX с точностью и полным контролем."
---
## **Введение**

Форматируйте фигуры в PowerPoint, регулируя их контуры, заливки и эффекты. Aspose.Slides для .NET позволяет управлять этими настройками программно, включая прозрачность, вращение и 3D‑форматирование.

![Параметры форматирования фигур в PowerPoint](format-shape-powerpoint.png)

Aspose.Slides для .NET предоставляет интерфейсы и свойства, позволяющие форматировать фигуры, используя те же параметры, что доступны в PowerPoint.

## **Форматирование линий**

Используйте [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) для управления контуром фигуры. Этот пример создает незаполненный прямоугольник с синей пунктирной обводкой. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) выбирает составную линию «толстая‑тонкая», а [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) задает её ширину 7 пунктов, а [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) выбирает шаблон пунктировки.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

### **Установить пользовательские шаблоны пунктиров линии**

Используйте [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) , когда предопределённые стили линий не предоставляют нужных длин штрихов и промежутков, например для фирменных контуров или технических схем. Назначение шаблона автоматически задаёт [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) в [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Элементы массива чередуются между длинами штрихов и промежутков, начиная со штриха. Каждое значение является кратным ширине линии: `{ 4, 2 }` при ширине 3 пункта дает штрих длиной 12 пунктов, за которым следует промежуток 6 пунктов. Используйте пары конечных, неотрицательных значений для определения полных сегментов штрих‑промежуток. В примере используются положительные значения, чтобы каждый штрих и промежуток были видимы.

Этот пример создает пять синих линий одинаковой длины и плоских концов. Первые три сравнивают шаблоны при ширине 3 пункта. Четвёртая повторяет первый шаблон при двойной ширине, удваивая длину как штрихов, так и промежутков. Пятая переключается с пользовательского шаблона на сплошную линию.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Return the last line to a solid style.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Чтобы вернуться к предопределённому пунктирному стилю, назначьте [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) в [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). Выбранный стиль управляет внешним видом линии.

Результат в PowerPoint сверху вниз: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; и **Solid, 3 pt**.

![Три пользовательских шаблона пунктиров, более широкая линия с использованием первого шаблона и сплошная линия в PowerPoint](custom-dash-patterns.png)

### **Установить типы концов линий**

Используйте [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) для задания окончаний открытой линии. Перечисление [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) предоставляет три явных стиля концов:

- `Flat`: Обводка останавливается в конечной точке.
- `Round`: Полукруглый конец выступает за конечную точку на половину ширины линии.
- `Square`: Квадратный конец выступает за конечную точку на половину ширины линии.

Перечисление также содержит `NotDefined`, что означает отсутствие явно назначенного стиля конца.

Концы отличаются от стрелок, которые добавляют символы к концам линий, и соединений, которые управляют углами между сегментами линии. Этот пример отключает стрелки через [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) и [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/), чтобы сравнивались только формы концов.

Следующий пример создаёт три почти одинаковые горизонтальные линии шириной 20 пунктов. Сверху вниз они используют плоские, круглые и квадратные концы. Их конечные точки имеют одинаковые горизонтальные координаты; круглые и квадратные концы выступают на 10 пунктов за каждую конечную точку.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

Результат в PowerPoint сверху вниз: **Flat**, **Round**, и **Square**.

![Плоские, круглые и квадратные концы на одинаковых толстых линиях в PowerPoint](line-caps.png)

## **Применить эффекты эскиза к линиям фигур**

Эффект эскиза делает линию фигуры похожей на нарисованную от руки. Используйте [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) для доступа к настройкам линии, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) для доступа к настройкам эскиза и [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Следующий код C# показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

Значение, возвращаемое [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться из темы, мастера слайда или макета, используйте [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), доступ к [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) и чтение [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Эффективное значение отражает фактическое форматирование после разрешения наследования. Этот пример требует существующей презентации с хотя бы одной фигурой на первом слайде и выводит оба значения:

```csharp
using System;
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

## **Форматировать стили соединений**

Здесь три варианта типа соединения:

* Круглый
* Скошенный
* Фаска

Стиль соединения управляет тем, как два сегмента контура встречаются в углу. Используйте **Round** для закруглённых углов, **Miter** для острых углов или **Bevel** для сглаженных углов.

![Стиль соединения в презентации](join-style-powerpoint.png)

Этот пример создаёт три чёрных прямоугольника с синими контурами шириной 15 пунктов. Он задаёт [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) значения miter, bevel и round из [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) соответственно, чтобы сравнить, как рисуются углы.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Ограничить соединения Miter на острых углах**

Используйте [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) вместе с [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) установленным на [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), чтобы ограничить, насколько далеко может вытягиваться острый угол.

Ограничение — это отношение расстояния между внутренним и внешним углами соединения к ширине линии. Например, значение `8` допускает длину среза до восьми ширин линии; это не измерение в пунктах. Если угол превышает ограничение, PowerPoint использует фаску в этом месте. Большее ограничение позволяет более острые точки. Настройка влияет только на соединения miter и не имеет видимого эффекта, когда угол остаётся внутри обоих пределов.

Этот пример создаёт два одинаковых незаполненных треугольника с контурами шириной 20 пунктов. Левый треугольник использует ограничение `2`, правый — `8`. Каждый треугольник шириной 80 пунктов и высотой 160 пунктов, что даёт отношение длины среза к ширине линии примерно `4.12`. В результате PowerPoint делает фаску левой вершины и сохраняет острие правой.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

Результат в PowerPoint: **Miter limit 2** слева и **miter limit 8** справа.

![Скос вершины с ограничением miter 2 и остроконечной вершиной с ограничением miter 8 в PowerPoint](miter-limits.png)

## **Градиентная заливка**

Градиентная заливка смешивает цвета внутри фигуры. Этот пример заполняет эллипс линейным градиентом под углом 45 градусов от красного к фиолетовому с помощью [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). Метод [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) размещает цветовые стопы в позициях 0 и 1, в начале и в конце градиента. Очистка существующих стопов гарантирует, что используются только эти два цвета.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Выбрать стиль рендеринга градиента](/slides/ru/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга, не меняя градиентную заливку, хранящуюся в презентации.

### **Установить угол линейного градиента**

Используйте [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) для управления ориентацией заливки [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). Угол измеряется в градусах и возрастает по часовой стрелке: `0` — слева направо, `90` — сверху вниз, `180` — справа налево, `270` — снизу вверх. Поддерживаются дробные углы. Углы за пределами `[0, 360)` нормализуются к одному обороту; например, `-45` становится `315`, а `360` — `0`.

Этот пример создаёт шесть прямоугольников с одинаковыми красными, зелёными и синими стопами в позициях `0`, `0.5` и `1`. Масштабирование отключено, чтобы угол можно было сравнивать независимо от пропорций прямоугольников. Углы слева направо: `0`, `45` и `90` в первой строке, и `135`, `180` и `270` во второй строке.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

Результат в PowerPoint:

![Линейные градиенты при 0, 45 и 90 градусах в верхней строке и 135, 180, 270 градусах в нижней строке](linear-gradient-angles.png)

### **Масштабировать линейный градиент вместе с фигурой**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) принимает значение [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Установите его явно в `False`, чтобы сохранять геометрический угол градиента при изменении пропорций фигуры, или в `True`, чтобы масштабировать градиент вместе с шириной и высотой фигуры. При включённом масштабировании видимый угол может отличаться от заданного угла у несquare‑фигуры.

Следующий пример использует угол `45` градусов и те же цветовые стопы, что и в сравнении углов. Левый столбец использует `False`; правый — `True`. Каждый столбец содержит широкий прямоугольник над высоким. Оба начинаются с одинаковых размеров; изменение ширины и высоты второго прямоугольника демонстрирует, как заливка реагирует на изменение размеров без изменения настроек градиента.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

Результат в PowerPoint, с отключённым масштабированием слева и включённым справа:

![Широкие и высокие прямоугольники с градиентом под 45 градусов, сравнение LinearGradientScaled False слева и True справа](linear-gradient-scaling.png)

При отключённом масштабировании диагональные цветовые полосы сохраняют одинаковую ориентацию в обоих прямоугольниках. При включённом масштабировании полосы растягиваются вместе с пропорциями фигуры. Это помогает воспроизвести градиент шаблона при адаптации фигуры к другому размеру. На квадрате включение масштабирования не меняет внешний вид этого градиента `45` градусов.

Оба параметра — угол и масштабирование — применяются к линейным градиентам. Они не управляют заливками [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Комбинировать угол с направлением градиента**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) выбирает стиль градиента из перечисления [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/); это не заменяет числовой угол. Для линейного градиента стили углов могут изменять область распределения цветов без изменения [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Сохраняйте направление неизменным при сравнении углов или масштабировании.

Следующий пример применяет те же настройки в обратном порядке. Два прямоугольника выглядят одинаково: назначение направления до или после угла не меняет результат.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Заполнение узором**

Заполнение узором применяет двухцветный рисунок, такой как точки, полосы или клетки. Этот пример использует [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) для выбора узора решётки. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) задаёт светло-серый фон, а [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) задаёт жёлтый цвет узора.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

Результат:

![Прямоугольник с узорной заливкой](pattern-fill.png)

## **Заполнение изображением**

Заполнение изображением использует картинку внутри фигуры. Этот пример требует локального изображения и использует [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) для загрузки его в коллекцию изображений презентации. Установка [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) в режим замощения повторяет изображение внутри прямоугольника. Исходное изображение показано ниже:

![Изображение лотоса](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

Результат:

![Фигура с заливкой изображением](picture-fill.png)

### **Замостить изображение как текстуру**

Если требуется задать замощённое изображение как текстуру и настроить поведение замощения, можно использовать следующие свойства интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Задаёт режим заливки изображения — `Tile` или `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Определяет выравнивание плиток внутри фигуры.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Управляет тем, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Определяет горизонтальный масштаб плитки в процентах.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Определяет вертикальный масштаб плитки в процентах.

Этот пример требует локального изображения и конфигурирует [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) для повторения его в размере 50 % от оригинала. Смещения −32 пункта сдвигают плитки горизонтально и вертикально; выравнивание по правому нижнему углу и отражение в обеих направлениях определяют расположение повторяющейся текстуры.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

Результат:

![Параметры замощения](tile-options.png)

## **Заливка сплошным цветом**

Сплошная заливка придаёт фигуре один единый цвет. Этот пример задаёт [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) в режим сплошной заливки и назначает жёлтый цвет через [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), затем сохраняет прямоугольник в презентации.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

Результат:

![Фигура со сплошной заливкой](solid-color-fill.png)

### **Копировать цвета, сохраняя ссылки на тему**

Используйте [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) для копирования определения цвета, включая тип цвета, ссылку на тему и преобразования. Это полезно при переносе цвета заливки между фигурами, которые должны продолжать следовать теме презентации. Метод копирует только цвет: он не копирует тип заливки, контур или другое форматирование фигуры. Настройте явно [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) в целевой фигуре.

Этот пример создаёт три прямоугольника слева направо: исходный, копию с учётом темы и фиксированную RGB‑копию. Исходный использует [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) для ссылки на первый акцентный цвет и добавляет оттенок через [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). RGB‑копия использует эффективный цвет заливки исходника, поэтому все три первоначально выглядят одинаково. Присвоение [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) задаёт фиксированное RGB‑значение и очищает любые существующие преобразования цвета.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Ссылки на тему следуют новому цвету акцента; фиксированное значение RGB не меняется.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Перед изменением темы все три заливки совпадают:

![Исходный, копия CopyFrom и фиксированная RGB копия с одинаковой синей заливкой](color-copy-before.png)

После изменения темы исходный и копия с учётом темы следуют новому акцентному цвету и сохраняют свой оттенок. Фиксированная RGB‑копия остаётся синей:

![Исходный и копия CopyFrom с оранжевыми заливками, тогда как фиксированная RGB копия остаётся синей](color-copy-after.png)

Скопированное определение независимо от источника. Последующее изменение ссылки темы у источника, назначение другого цвета или добавление/удаление его преобразований не меняет целевую фигуру. Изменение темы всё равно влияет на обе фигуры, поскольку каждая независимо ссылается на один и тот же цвет темы.

Сохранение и повторное открытие PPTX сохраняет тип цвета [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), ссылку на тему и коллекцию [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/); определение не преобразуется в RGB.

При копировании между разными контекстами темы, например между презентациями с разными палитрами акцентов, скопированная ссылка разрешается относительно темы назначения. Та же ссылка и преобразования могут поэтому давать другой видимый цвет. См. [Тема презентации](/slides/ru/net/presentation-theme/) для получения дополнительной информации о настройке цветов темы.

## **Использовать фон слайда как заливку фигуры**

Используйте [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) когда фигура должна соответствовать фону слайда, например в шаблоне презентации. Сначала задайте [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) в [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/), чтобы убрать любую явную заливку. При такой комбинации фигура использует фон слайда вместо своей заливки стиля. Включение флага само по себе не удаляет существующую явную заливку.

Это отличается от [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): фоновая заливка покрывает объекты за фигурой соответствующей областью фона слайда, тогда как отсутствие заливки оставляет эти объекты видимыми. Градиент остаётся привязанным к слайду, а не перезапускается внутри каждой фигуры.

Следующий пример создаёт фон‑мастер, наследуемый слайдом, и помещает пурпурную полосу за тремя прямоугольниками. Левый прямоугольник использует фон, средний — без заливки, правый — переключается с фоновой заливки на явную оранжевую.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Наследовать градиент от мастера.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Добавить этот объект первым, чтобы он находился за прямоугольниками.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Отключить фоновую заливку перед применением явной заливки.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Результат слева направо: **background fill**, **no fill**, и **explicit fill**. Пурпурная полоса скрыта левыми и правыми прямоугольниками, но остаётся видимой через средний.

![Фоновая заливка, отсутствие заливки и явная оранжевая заливка над пурпурной полосой](background-fill.png)

То же поведение применимо к фону, определённому непосредственно на слайде или наследуемому из макета. Фигура использует разрешённый фон слайда; пример оставляет фон слайда и макета неопределёнными, чтобы мастер его предоставил.

## **Установить прозрачность**

Для сплошной заливки альфа‑компонент цвета управляет непрозрачностью: 0 — полностью прозрачно, 255 — полностью непрозрачно. Этот пример использует альфа‑значение 128 для жёлтого прямоугольника, делая его примерно на 50 % прозрачным, чтобы нижний прямоугольник оставался видимым. Цвет задаётся через [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Вращать фигуры**

Используйте [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) для вращения фигуры в плоскости слайда. Угол измеряется в градусах; этот пример вращает прямоугольник на 5 градусов по часовой стрелке и сохраняет презентацию.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавить 3D‑эффекты фаски**

Используйте [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) для придания фигуре глубины и фасок. Этот пример создаёт зелёный эллипс с оранжевой обводкой, задаёт [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) в 4 пункта и применяет круглую верхнюю фаску шириной и высотой 6 пунктов через [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Камера с фронтальным видом и трёхточечное освещение делают фаску видимой.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

Результат:

![3D‑эффект фаски](3D-bevel-effect.png)

## **Добавить 3D‑вращения**

3D‑вид фигуры контролируется настройками её камеры. Этот пример использует [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) с углами широты, долготы и оборота — 40°, 35° и 20° соответственно. Выбирается изометрическая камера через [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) и сбалансированное освещение через [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), затем сохраняет отформатированный прямоугольник.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

Результат:

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Управление черно‑белой отрисовкой фигур**

Свойство [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) указывает, как отдельная фигура будет отрисовываться, когда презентация просматривается или обрабатывается в чёрно‑белом режиме. Оно не включает чёрно‑белый режим само по себе и не меняет заливку, линию или другое форматирование фигуры в обычном цветном режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) для выбора нужного поведения. Например, `Automatic` позволяет приложению‑отображателю выбрать преобразование, `Gray` и `LightGray` используют серый цвет, `BlackWhite` — только черный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в чёрно‑белом режиме. `NotDefined` означает, что режим на уровне фигуры не назначен.

Этот пример создаёт оранжевый прямоугольник и задаёт [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) в `Gray`. Сохранённая фигура сохраняет оранжевую заливку для обычного цветного отображения и запрашивает серое отображение в приложениях, которые учитывают настройки чёрно‑белого режима:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

В обычном цветном режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе чёрно‑белого отображения он использует серый цвет, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, задавая отдельный вид для печати, предварительного просмотра или других процессов, учитывающих настройки чёрно‑белого отображения презентации.

## **Сброс форматирования**

Используйте [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) для восстановления позиции, размеров и форматирования заполнителей слайда из соответствующих заполнителей макета. Этот пример требует существующей презентации с заполнителями, связанными с макетом, и сбрасывает каждый слайд перед сохранением. Фигуры без соответствующих заполнителей макета не сбрасываются.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Влияет ли форматирование фигур на окончательный размер файла презентации?**  
Цвета, стили линий и параметры эффектов обычно добавляют мало данных по сравнению с встроенными изображениями и медиа. Заливки изображениями могут увеличить размер файла, поскольку их изображения хранятся в презентации.

**Как обнаружить фигуры на слайде, у которых одинаковое форматирование, чтобы сгруппировать их?**  
Сравните ключевые свойства форматирования каждой фигуры — заливка, линия и параметры эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**  
Да. Сохраните образцы фигур с нужными стилями в шаблоне презентации или файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные фигуры и повторно примените их форматирование там, где требуется.