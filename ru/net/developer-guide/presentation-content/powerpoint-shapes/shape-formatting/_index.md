---
title: "Форматирование фигур PowerPoint в .NET"
linktitle: "Форматирование фигур"
type: docs
weight: 20
url: /ru/net/shape-formatting/
keywords:
- "форматирование фигуры"
- "форматирование линии"
- "эффект наброска"
- "линия фигуры в виде наброска"
- "форматирование стиля соединения"
- "градиентная заливка"
- "заполнение узором"
- "заполнение изображением"
- "заполнение текстурой"
- "сплошная заливка цветом"
- "прозрачность фигуры"
- "чёрно-белое отображение фигуры"
- "отображение фигуры в оттенках серого"
- "вращение фигуры"
- "3D‑эффект фаски"
- "3D‑вращение"
- "сброс форматирования"
- "PowerPoint"
- "презентация"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Узнайте, как форматировать фигуры PowerPoint на C# с помощью Aspose.Slides — задавайте стили заливки, контура и эффектов для файлов PPT и PPTX с точностью и полным контролем."
---
## **Введение**

Форматируйте фигуры в PowerPoint, регулируя их контуры, заливки и эффекты. Aspose.Slides for .NET позволяет управлять этими параметрами программно, включая прозрачность, вращение и 3D‑форматирование.

![Параметры форматирования фигур в PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET предоставляет интерфейсы и свойства, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

Используйте [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) для управления контуром фигуры. Этот пример создает незалитый прямоугольник с синим пунктирным контуром. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) выбирает составную линию «толстая‑тонкая», в то время как [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) задает её ширину 7 пунктов, а [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) выбирает тип пунктирной линии.

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

**Результат:**

![Отформатированные линии в презентации](formatted-lines.png)

### **Установка пользовательских шаблонов пунктиров линии**

Используйте [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) когда предопределённые стили линий не предоставляют нужные длины штрихов и промежутков, например для фирменных контуров или технических схем. Присвоение шаблона автоматически задает [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) в значение [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Элементы массива чередуются между длиной штриха и пробела, начиная со штриха. Каждое значение является кратным ширине линии: `{ 4, 2 }` при ширине 3 пункта даёт штрих длиной 12 пунктов, за которым следует промежуток 6 пунктов. Используйте пары конечных неотрицательных значений для определения полного сегмента штрих‑пробел. В примере используются положительные значения, чтобы каждый штрих и промежуток были видимы.

Этот пример создает пять синих линий одинаковой длины и плоских окончаний. Первые три сравнивают шаблоны при ширине 3 пункта. Четвёртая повторяет первый шаблон при двойной ширине, удваивая длины штрихов и промежутков. Пятая переключается от пользовательского шаблона к сплошной линии.

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

// Вернуть последнюю линию к сплошному стилю.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Чтобы вместо этого вернуться к предопределённому пунктирному стилю, присвойте [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) свойству [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). Выбранный стиль управляет внешним видом линии.

**Результат в PowerPoint, сверху вниз:** **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; и **Solid, 3 pt**.

![Три пользовательских шаблона пунктиров, более широкая линия с использованием первого шаблона и сплошная линия в PowerPoint](custom-dash-patterns.png)


### **Установка окончаний линии**

Используйте [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) для установки концов открытой линии. Перечисление [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) предоставляет три явно определённых стиля окончаний:

- `Flat`: Штрих останавливается в конечной точке.
- `Round`: Полукруглое окончание выходит за пределы конечной точки на половину ширины линии.
- `Square`: Квадратное окончание выходит за пределы конечной точки на половину ширины линии.

Перечисление также включает `NotDefined`, что означает отсутствие явно назначенного стиля окончания.

Окончания отличаются от стрелок, которые добавляют символы к концам линии, и соединений, которые управляют углами между сегментами линии. В этом примере стрелки отключаются через [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) и [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/), чтобы сравнивались только формы окончаний.

Следующий пример создаёт три почти идентичные горизонтальные линии шириной 20 пунктов. Сверху вниз они используют плоские, круглые и квадратные окончания. Их конечные точки имеют одинаковые горизонтальные координаты; круглое и квадратное окончания выходят за границы на 10 пунктов.

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

**Результат в PowerPoint, сверху вниз:** **Flat**, **Round**, и **Square**.

![Плоские, круглые и квадратные окончания на одинаковых толстых линиях в PowerPoint](line-caps.png)

## **Применение эффектов наброска к линиям фигур**

Эффект наброска делает линию фигуры выглядящей как нарисованную от руки. Используйте [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) для доступа к настройкам линии, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) для доступа к настройкам наброска и [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Следующий код C# демонстрирует, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

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

Значение, возвращаемое [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/), представляет настройку, назначенную непосредственно фигуре. Если форматирование линии может наследоваться от темы, шаблона слайда или макета слайда, используйте [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), доступ к [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), и прочтите [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Эффективное значение отражает фактическое форматирование после разрешения наследования. Этот пример требует существующей презентации с хотя бы одной фигурой на первом слайде и выводит оба значения:

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

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Round
* Miter
* Bevel

Стиль соединения управляет тем, как два контура встречаются в угле. Используйте **Round** для скруглённых углов, **Miter** для острых углов или **Bevel** для срезанных углов.

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

### **Ограничение соединений Miter на острых углах**

Используйте [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) вместе с [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) = [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) для ограничения длины острого угла.

Предел — это отношение расстояния между внутренним и внешним углом соединения к ширине линии. Например, значение `8` позволяет длину miter до восьми ширин линии; это не измерение в пунктах. Если угол превышает предел, PowerPoint использует срезанное соединение в этом месте. Больший предел позволяет более острые точки. Настройка влияет только на соединения miter и не меняет внешний вид, когда угол остаётся внутри пределов.

Этот пример создаёт два одинаковых незалитых треугольника с контурами шириной 20 пунктов. Левый треугольник использует предел `2`, правый — `8`. Каждый треугольник шириной 80 пунктов и высотой 160 пунктов, что даёт отношение длины miter к ширине линии около `4.12`. Поэтому PowerPoint срезает левый верхний угол и сохраняет правый.

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

**Результат в PowerPoint:** **Miter limit 2** слева и **miter limit 8** справа.

![Срезанный верх с miter limit 2 и заострённый верх с miter limit 8 в PowerPoint](miter-limits.png)

## **Градиентная заливка**

Градиентная заливка плавно смешивает цвета внутри фигуры. Этот пример заполняет эллипс линейным градиентом под углом 45° от красного к пурпурному с помощью [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). Метод [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) размещает цветовые остановки в позициях 0 и 1 — начале и конце градиента. Очистка существующих остановок гарантирует использование только этих двух цветов.

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

**Результат:**

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Choose a Gradient Rendering Style](/slides/ru/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга, не меняя градиент, сохранённый в презентации.

### **Установка угла линейного градиента**

Используйте [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) для управления ориентацией заливки [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). Угол измеряется в градусах и увеличивается по часовой стрелке: `0` — слева направо, `90` — сверху вниз, `180` — справа налево, `270` — снизу вверх. Поддерживаются дробные углы. Углы вне диапазона `[0, 360)` нормализуются к одному обороту; например, `-45` → `315`, `360` → `0`.

Этот пример создаёт шесть прямоугольников с одинаковыми остановками красного, зелёного и синего цветов в позициях `0`, `0.5` и `1`. Масштабирование отключено, чтобы угол можно было сравнивать независимо от пропорций фигур. Углы слева направо: `0`, `45`, `90` в первой строке и `135`, `180`, `270` во второй.

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

**Результат в PowerPoint:**

![Линейные градиенты под углами 0°, 45° и 90° в верхнем ряду, и 135°, 180° и 270° в нижнем ряду](linear-gradient-angles.png)

### **Масштабирование линейного градиента вместе с фигурой**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) принимает значение [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Установите его явно в `False`, чтобы геометрический угол градиента сохранялся при изменении пропорций фигуры, или в `True`, чтобы градиент масштабировался вместе с шириной и высотой фигуры. При включённом масштабировании видимый угол может отличаться от заданного угла у нелинейных фигур.

Следующий пример использует угол `45` градусов и те же цветовые остановки, что и в сравнениях углов. Левая колонка использует `False`, правая — `True`. Каждая колонка содержит широкий прямоугольник над высоким. Оба начинаются с одинаковых широких размеров; изменение ширины и высоты второго прямоугольника показывает, как заливка реагирует на изменение размера без изменения параметров градиента.

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

**Результат в PowerPoint, слева — масштабирование отключено, справа — включено:**

![Широкие и высокие прямоугольники с 45‑градусным градиентом, сравнение LinearGradientScaled False слева и True справа](linear-gradient-scaling.png)

При отключённом масштабировании диагональные цветовые полосы сохраняют одинаковую ориентацию в обеих фигурах. При включённом они растягиваются вместе с пропорциями фигуры. Это помогает воспроизводить градиент шаблона при адаптации фигуры к другому размеру. На квадрате включение масштабирования не меняет внешний вид 45‑градусного градиента.

Оба параметра — угол и масштабирование — применимы только к линейным градиентам. Они не управляют заливками [GradientShape.Radial] или [GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Комбинация угла с направлением градиента**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) выбирает стиль градиента из перечисления [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/); это не замена числовому углу. Для линейного градиента стили углов могут менять область распределения цветов без изменения [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Сохраняйте направление неизменным при сравнении углов или масштабировании.

Следующий пример последовательно применяет одинаковые параметры в обратном порядке. Два прямоугольника выглядят одинаково: назначение направления до или после угла не меняет результат.

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

Заполнение узором накладывает двухцветный рисунок, например точки, полосы или шахматную сетку. Этот пример использует [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) для выбора узора «решётка». [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) задаёт светло‑серый фон, а [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) — жёлтый цвет узора.

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

**Результат:**

![Прямоугольник с узором заливки](pattern-fill.png)

## **Заполнение изображением**

Заполнение изображением использует картинку внутри фигуры. Пример требует локального изображения и использует [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) для загрузки его в коллекцию изображений презентации. Установка [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) в режим «Tile» повторяет изображение внутри прямоугольника. Исходное изображение показано ниже:

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

**Результат:**

![Фигура с заливкой изображением](picture-fill.png)

### **Повтор изображения как текстура**

Если нужно установить повторяющееся изображение как текстуру и настроить поведение повторения, можно использовать следующие свойства интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) и класса [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Устанавливает режим заливки изображением — `Tile` или `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Определяет выравнивание плиток внутри фигуры.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Определяет, будет ли плитка отражена по горизонтали, вертикали или обоим направлениям.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Задает горизонтальное смещение плитки (в пунктах) от начала координат фигуры.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Задает вертикальное смещение плитки (в пунктах) от начала координат фигуры.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Определяет горизонтальный масштаб плитки в процентах.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Определяет вертикальный масштаб плитки в процентах.

Этот пример требует локального изображения и настраивает [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) для повторения его в 50 % от оригинального размера. Смещения −32 пункта сдвигают плитки горизонтально и вертикально; выравнивание «bottom‑right» и отражение в обоих направлениях определяют расположение повторяющейся текстуры.

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

**Результат:**

![Параметры плитки](tile-options.png)

## **Сплошная заливка цветом**

Сплошная заливка задаёт фигуре один равномерный цвет. Пример устанавливает [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) в режим сплошной заливки и задаёт жёлтый цвет через [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), после чего сохраняет прямоугольник в презентацию.

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

**Результат:**

![Фигура со сплошной заливкой цветом](solid-color-fill.png)

## **Использовать фон слайда как заливку фигуры**

Используйте [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/), когда фигура должна соответствовать фону слайда, например в шаблоне презентации. Сначала задайте [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) в [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/), чтобы убрать любую явную заливку. При такой комбинации фигура использует фон слайда вместо собственного стиля заливки. Включение флага без снятия явной заливки её не удалит.

Это отличается от [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): заливка фоном покрывает объекты за фигурой соответствующей областью фона слайда, тогда как отсутствие заливки оставляет эти объекты видимыми. Градиент остаётся привязанным к слайду, а не начинается заново внутри каждой фигуры.

Следующий пример создаёт фон‑шаблон, наследуемый слайдом, и помещает пурпурную полосу за тремя прямоугольниками. Левая фигура использует фон, средняя — без заливки, правая — переключается с фоновой заливки на явную оранжевую.

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

// Добавить этот объект первым, чтобы он оказался позади прямоугольников.
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

// Отключить заливку фоном перед применением явной заливки.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

**Результат слева направо:** **background fill**, **no fill**, и **explicit fill**. Пурпурная полоса скрыта левой и правой фигурами, но остаётся видимой через среднюю.

![Заполнение фоном, отсутствие заливки и явная оранжевая заливка над пурпурной полосой](background-fill.png)

То же поведение применяется к фону, определённому непосредственно на слайде или унаследованному от макета. Фигура использует разрешённый фон слайда; в примере фон слайда и макета оставлены неопределёнными, поэтому используется фон мастера.

## **Установка прозрачности**

Для сплошной заливки альфа‑компонент цвета управляет непрозрачностью: 0 — полностью прозрачно, 255 — полностью непрозрачно. В примере используется значение альфа = 128 для жёлтого прямоугольника, что делает его приблизительно на 50 % прозрачным, позволяя видеть расположенный под ним объект. Цвет задаётся через [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

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

**Результат:**

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Используйте [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) для вращения фигуры в плоскости слайда. Угол измеряется в градусах; пример вращает прямоугольник на 5 градусов по часовой стрелке и сохраняет презентацию.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

**Результат:**

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D‑эффекта фаски**

Используйте [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) для придания фигуре глубины и фаски. Пример создаёт зелёный эллипс с оранжевым контуром, задаёт [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) = 4 пункта и применяет круглую верхнюю фаску шириной и высотой 6 пунктов через [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Фронтальная ортографическая камера и трёхточечное освещение делают фаску видимой.

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

**Результат:**

![Эффект 3D‑фаски](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

Трёхмерный вид фигуры управляется настройками её камеры. Пример использует [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) с углами широты = 40°, долготы = 35° и революции = 20°. Выбирает изометрическую камеру через [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) и сбалансированное освещение через [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), затем сохраняет отформатированный прямоугольник.

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

**Результат:**

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Управление черно‑белым отображением фигур**

Свойство [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) определяет, как отдельная фигура будет отображаться, когда презентация просматривается или обрабатывается в черно‑белом режиме. Оно не включает черно‑белый режим само по себе и не меняет заливку, контур или другое форматирование фигуры в обычном цветном режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) для выбора нужного поведения. Например, `Automatic` позволяет приложению‑рендереру выбрать способ преобразования, `Gray` и `LightGray` используют оттенки серого, `BlackWhite` — только чёрный и белый, `Black` и `White` — принудительно один цвет, `Color` сохраняет обычные цвета, `Hidden` — исключает фигуру в чёрно‑белом режиме. `NotDefined` означает, что режим не назначен.

Пример создаёт оранжевый прямоугольник и задаёт [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) = `Gray`. Сохранённая фигура сохраняет оранжную заливку для обычного цветного отображения и запрашивает серую окраску у приложений, поддерживающих черно‑белую визуализацию:

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

В обычном цветном режиме прямоугольник остаётся оранжным. При работе в чёрно‑белом режиме он отображается серым, потому что его режим установлен в `Gray`. Это позволяет сохранять полноцветный слайд, одновременно задавая отдельный вид для печати, предварительного просмотра или иных процессов, учитывающих настройки чёрно‑белого отображения.

## **Сброс форматирования**

Используйте [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) для восстановления позиции, размеров и форматирования заполнителей слайда из соответствующих заполнителей макета. Пример требует существующей презентации с заполнителями, связанными с макетом, и сбрасывает каждый слайд перед сохранением. Фигуры без соответствующих заполнителей макета не сбрасываются.

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

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Цвета, стили линий и параметры эффектов обычно добавляют небольшие объёмы данных по сравнению с встроенными изображениями и медиа. Заливка изображениями может увеличить размер файла, поскольку их изображения хранятся в презентации.

**Как обнаружить на слайде фигуры с одинаковым форматированием, чтобы их сгруппировать?**

Сравните ключевые свойства форматирования каждой фигуры — заливку, контур и параметры эффектов. Если все соответствующие значения совпадают, их стили можно считать идентичными и логически сгруппировать, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с требуемыми стилями в шаблонной презентации или файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и примените их форматирование там, где это требуется.