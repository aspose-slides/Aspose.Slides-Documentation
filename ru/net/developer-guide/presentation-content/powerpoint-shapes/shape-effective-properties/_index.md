---
title: Получить эффективные свойства фигур из презентаций в .NET
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/net/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- световая установка
- скос фигуры
- текстовый кадр
- текстовый стиль
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для .NET вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint."
---
## **Обзор**

Эта статья объясняет различие между **local** и **effective** свойствами. Локальные значения — это значения, которые задаются непосредственно на конкретном уровне форматирования, например:

1. Свойства части (portion) на слайде.  
1. Стили текста прототипа формы на макете или образце слайда, если у формы текстового кадра части есть такие стили.  
1. Глобальные настройки текста в презентации.

Локальные значения могут быть заданы или опущены на любом уровне. Когда Aspose.Slides требуется окончательное «как отображено» форматирование, он разрешает цепочку наследования и возвращает **effective** значения. Получить их можно, вызвав метод `GetEffective` у локального объекта формата.

Следующий пример показывает, как получить эффективные значения. Предполагается, что первая фигура на первом слайде представляет собой [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) с текстовым кадром и как минимум одной частью.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Эффективные данные форматирования представляют текущие рассчитанные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных, такие как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformateffectivedata/), могут кешироваться внутри. Повторный вызов `GetEffective` после изменения родительского или унаследованного форматирования может обновить кешированные данные, и ранее полученный объект может больше не соответствовать прежнему состоянию. Если необходимо сохранить эффективные значения для дальнейшего использования, скопируйте нужные свойства, такие как высота шрифта, цвет заливки, стиль шрифта или выравнивание, в свой собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получать эффективные свойства камеры. Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/icameraeffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/icameraeffectivedata/) предоставляется через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/).

Следующий пример кода демонстрирует, как получить эффективные свойства камеры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Получить эффективные свойства световой установки**

Aspose.Slides позволяет получать эффективные свойства световой установки. Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ilightrigeffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства световой установки. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ilightrigeffectivedata/) предоставляется через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/).

Следующий пример кода демонстрирует, как получить эффективные свойства световой установки. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Получить эффективные свойства скосов фигуры**

Aspose.Slides позволяет получать эффективные свойства скосов фигуры. Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapebeveleffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства рельефа грани фигуры. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapebeveleffectivedata/) предоставляется через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/).

Следующий пример кода демонстрирует, как получить эффективные свойства верхнего скоса фигуры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Получить эффективные свойства текстового кадра**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового кадра. Интерфейс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformateffectivedata/) содержит эффективные свойства форматирования текстового кадра.

Следующий пример кода демонстрирует, как получить эффективные свойства форматирования текстового кадра. Предполагается, что первая фигура на первом слайде представляет собой [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) с текстовым кадром.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Получить эффективные свойства текстового стиля**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового стиля. Интерфейс [ITextStyleEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/itextstyleeffectivedata/) содержит эффективные свойства текстового стиля.

Следующий пример кода демонстрирует, как получить эффективные свойства текстового стиля. Предполагается, что первая фигура на первом слайде представляет собой [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) с текстовым кадром.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Получить значение эффективной высоты шрифта**

С помощью Aspose.Slides вы можете получить эффективную высоту шрифта. Следующий код демонстрирует, как меняется эффективная высота шрифта части после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Получить эффективный формат заливки для таблицы**

С помощью Aspose.Slides вы можете получить эффективное форматирование заливки для различных частей таблицы. Интерфейс [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformateffectivedata/) содержит эффективные свойства форматирования заливки. Форматирование ячейки имеет более высокий приоритет, чем форматирование строки, форматирование строки — выше, чем форматирование столбца, а форматирование столбца — выше, чем форматирование всей таблицы.

В результате свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/icellformateffectivedata/) используются при отрисовке ячейки таблицы. Следующий пример кода показывает, как получить эффективное форматирование заливки для различных частей таблицы. Предполагается, что первая фигура на первом слайде представляет собой [ITable](https://reference.aspose.com/slides/ru/net/aspose.slides/itable/).

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

**Возвращает ли `GetEffective` моментальный снимок?**

Не всегда. Эффективные данные представляют рассчитанное форматирование после применения наследования, но некоторые объекты эффективных данных могут кешироваться внутри. Последующий вызов `GetEffective` может пересчитать форматирование и обновить кешированные данные, поэтому ранее полученный объект не следует рассматривать как постоянный снимок.

**Когда следует снова считывать эффективные свойства?**

Вызовите `GetEffective` снова после изменения локального форматирования, родительских стилей, форматирования макета, форматирования образца или параметров по умолчанию презентации. Следующий вызов переоценивает иерархию форматирования и возвращает текущее эффективное значение.

**Влияет ли изменение или удаление макета/образца слайда на уже полученные эффективные свойства?**

Да, но изменение отразится только при следующем вызове `GetEffective`. Если источник родительского форматирования изменён или удалён, ранее получённые эффективные данные могут стать устаревшими. После нового вызова `GetEffective` Aspose.Slides переоценивает дерево форматирования, и полученные шрифты, цвета, размеры или другие значения могут измениться.

**Можно ли изменять значения через объекты эффективных данных?**

Нет. Объекты эффективных данных только предоставляют вычисленные значения. Вносите изменения в локальные объекты форматирования, а затем вновь получайте эффективные значения.

**Что происходит, если свойство не задано ни на уровне фигуры, ни в макете/образце, ни в глобальных настройках?**

Эффективное значение определяется механизмом по умолчанию, который включает настройки PowerPoint и Aspose.Slides. Это разрешённое значение становится частью текущих эффективных данных.

**По эффективному значению шрифта можно ли определить, какой уровень предоставил размер или гарнитуру?**

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы выяснить источник, проверьте локальные значения на уровне части, абзаца, текстового кадра и текстовых стилей на уровнях макета, образца и презентации, чтобы увидеть, где впервые было явно задано.

**Почему иногда эффективные значения выглядят одинаково с локальными?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте эффективные данные, когда нужен результат «как отображено» после применения всего наследования, например для согласования цветов, отступов или размеров. Если необходимо сохранить эти значения независимо от последующих изменений форматирования, скопируйте требуемые свойства в свой объект. Если нужно изменить форматирование на конкретном уровне, изменяйте локальные свойства и, при необходимости, снова считывайте эффективные данные для проверки результата.