---
title: Получить эффективные свойства фигур из презентаций в .NET
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/net/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- система освещения
- фаска фигуры
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

Эта статья объясняет разницу между **локальными** и **эффективными** свойствами. Локальные значения — это значения, которые задаются непосредственно на конкретном уровне форматирования, например:

1. Свойства фрагмента на слайде.  
1. Стиль текста прототипа фигуры в макете или слайде‑шаблоне, если у фигуры‑текстового кадра прототипа есть такой стиль.  
1. Глобальные текстовые настройки в презентации.

Локальные значения могут быть определены или опущены на любом уровне. Когда Aspose.Slides требуется окончательное «как отрендерено» форматирование, он разрешает цепочку наследования и возвращает **эффективные** значения. Получить их можно, вызвав метод `GetEffective` у локального объекта формата.

Следующий пример показывает, как получить эффективные значения. Предполагается, что первая фигура на первом слайде — это [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) с текстовым кадром и как минимум одним фрагментом.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Эффективные данные форматирования представляют текущие вычисленные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных, такие как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformateffectivedata/), могут кэшироваться внутри. Повторный вызов `GetEffective` после изменения родительского или унаследованного форматирования может обновить кэш, и ранее полученный объект может более не отражать прежнее состояние. Если необходимо сохранить эффективные значения для последующего использования, скопируйте требуемые свойства (например, высоту шрифта, цвет заливки, стиль шрифта или выравнивание) в собственный объект данных.
{{% /alert %}}

## **Получение эффективных свойств камеры**

Aspose.Slides позволяет получить эффективные свойства камеры. Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/icameraeffectivedata/) представляет неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/icameraeffectivedata/) раскрывается через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/).

В следующем примере кода показано, как получить эффективные свойства камеры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Получение эффективных свойств системы освещения**

Aspose.Slides позволяет получить эффективные свойства системы освещения. Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ilightrigeffectivedata/) представляет неизменяемый объект, содержащий эффективные свойства системы освещения. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ilightrigeffectivedata/) раскрывается через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/).

В следующем примере кода показано, как получить эффективные свойства системы освещения. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Получение эффективных свойств фаски фигуры**

Aspose.Slides позволяет получить эффективные свойства фаски фигуры. Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapebeveleffectivedata/) представляет неизменяемый объект, содержащий эффективные свойства рельефа фаски фигуры. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapebeveleffectivedata/) раскрывается через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/).

В следующем примере кода показано, как получить эффективные свойства верхней фаски фигуры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Получение эффективных свойств текстового кадра**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового кадра. Интерфейс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformateffectivedata/) содержит эффективные свойства форматирования текстового кадра.

В следующем примере кода показано, как получить эффективные свойства форматирования текстового кадра. Предполагается, что первая фигура на первом слайде — это [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) с текстовым кадром.

```csharp
using Aspose.Slides;

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

## **Получение эффективных свойств текстового стиля**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового стиля. Интерфейс [ITextStyleEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/itextstyleeffectivedata/) содержит эффективные свойства текстового стиля.

В следующем примере кода показано, как получить эффективные свойства текстового стиля. Предполагается, что первая фигура на первом слайде — это [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) с текстовым кадром.

```csharp
using Aspose.Slides;

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

## **Получение эффективного значения высоты шрифта**

С помощью Aspose.Slides вы можете получить эффективную высоту шрифта. Ниже показан код, демонстрирующий, как эффективная высота шрифта фрагмента меняется после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Получение эффективного формата заливки для таблицы**

С помощью Aspose.Slides вы можете получить эффективное форматирование заливки для различных частей таблицы. Интерфейс [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformateffectivedata/) содержит эффективные свойства форматирования заливки. Форматирование ячейки имеет более высокий приоритет, чем форматирование строки; форматирование строки — чем форматирование столбца; форматирование столбца — чем форматирование всей таблицы.

В результате свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/icellformateffectivedata/) используются для отрисовки ячейки таблицы. В следующем примере кода показано, как получить эффективное форматирование заливки для разных частей таблицы. Предполагается, что первая фигура на первом слайде — это [ITable](https://reference.aspose.com/slides/ru/net/aspose.slides/itable/).

```csharp
using Aspose.Slides;

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

### Возвращает ли `GetEffective` моментальный снимок?

Не всегда. Эффективные данные представляют вычисленное форматирование после применения наследования, но некоторые объекты эффективных данных могут кэшироваться внутри. Последующий вызов `GetEffective` может пересчитать форматирование и обновить кэш, поэтому ранее полученный объект не следует рассматривать как долговременный снимок.

### Когда следует снова считывать эффективные свойства?

Вызовите `GetEffective` повторно после изменения локального форматирования, стилей‑родителей, форматирования макета, форматирования шаблона или значений по умолчанию на уровне презентации. Следующий вызов переоценивает иерархию форматирования и возвращает актуальный эффективный результат.

### Влияет ли изменение или удаление макета/шаблона слайда на уже полученные эффективные свойства?

Да, но изменение отразится только при следующем вызове `GetEffective`. Если источник форматирования‑родителя был изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `GetEffective` Aspose.Slides переоценивает дерево форматирования, и полученные шрифты, цвета, размеры или другие значения могут измениться.

### Можно ли изменять значения через объекты эффективных данных?

Нет. Объекты эффективных данных предоставляют только вычисленные значения. Вносите изменения в локальные объекты форматирования, а затем снова получайте эффективные значения.

### Что происходит, если свойство не задано на уровне фигуры, макета/шаблона и глобальных настроек?

Эффективное значение определяется механизмом значений по умолчанию, который включает настройки PowerPoint и Aspose.Slides. Это разрешённое значение становится частью текущих эффективных данных.

### По эффективному значению шрифта можно ли определить, на каком уровне было задано его размер или гарнитура?

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы найти источник, проверьте локальные значения на уровне фрагмента, абзаца, текстового кадра и текстовых стилей в макете, шаблоне и презентации, чтобы увидеть, где появилось первое явное определение.

### Почему эффективные значения иногда выглядят одинаковыми с локальными?

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

### Когда следует использовать эффективные свойства, а когда работать только с локальными?

Используйте эффективные данные, когда нужен результат «как отрендерено» после применения всего наследования, например, для согласования цветов, отступов или размеров. Если необходимо сохранить эти значения независимо от последующих изменений форматирования, скопируйте нужные свойства в собственный объект. Если требуется изменить форматирование на определённом уровне, изменяйте локальные свойства и, при необходимости, снова считывайте эффективные данные для проверки результата.