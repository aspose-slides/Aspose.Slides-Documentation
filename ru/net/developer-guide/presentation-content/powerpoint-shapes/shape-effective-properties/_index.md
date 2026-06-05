---
title: Получить эффективные свойства фигур из презентаций в .NET
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/net/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- световое оборудование
- фаска фигуры
- текстовый фрейм
- стиль текста
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

Эта тема объясняет разницу между **локальными** и **эффективными** свойствами. Локальные значения — это значения, задаваемые напрямую на определённом уровне форматирования, например:

1. Свойства части (portion) на слайде.
1. Стили текста прототипной формы на макете или мастер‑слайде, если у формы текстового фрейма части есть такой стиль.
1. Глобальные настройки текста в презентации.

Локальные значения могут быть заданы или отсутствовать на любом уровне. Когда Aspose.Slides требует окончательное форматирование «как при отображении», он разрешает цепочку наследования и возвращает **эффективные** значения. Получить их можно, вызвав метод `GetEffective` у локального объекта формата.

Следующий пример показывает, как получить эффективные значения. Предполагается, что первая фигура на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) с текстовым фреймом и как минимум одной частью.

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
Данные эффективного форматирования представляют текущие вычисленные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных, такие как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformateffectivedata/), могут кэшироваться внутри. Повторный вызов `GetEffective` после изменения родительского или унаследованного форматирования может обновить кэшированные данные, и ранее полученный объект более не будет представлять прежнее состояние. Если необходимо сохранить эффективные значения для последующего использования, скопируйте требуемые свойства, например высоту шрифта, цвет заливки, стиль шрифта или выравнивание, в свой собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получить эффективные свойства камеры. Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/icameraeffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/icameraeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/).

Следующий пример кода показывает, как получить эффективные свойства камеры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

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

## **Получить эффективные свойства светового устройства**

Aspose.Slides позволяет получить эффективные свойства светового устройства. Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ilightrigeffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства светового устройства. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ilightrigeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/).

Следующий пример кода показывает, как получить эффективные свойства светового устройства. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Получить эффективные свойства фаски фигуры**

Aspose.Slides позволяет получить эффективные свойства фаски фигуры. Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapebeveleffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства рельефа грани для фигуры. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapebeveleffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/).

Следующий пример кода показывает, как получить эффективные свойства верхней фаски фигуры. Предполагается, że первая фигура на первом слайде имеет 3D‑форматирование.

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

## **Получить эффективные свойства текстового фрейма**

С помощью Aspose.Slides можно получить эффективные свойства текстового фрейма. Интерфейс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformateffectivedata/) содержит свойства эффективного форматирования текстового фрейма.

Следующий пример кода показывает, как получить эффективные свойства форматирования текстового фрейма. Предполагается, что первая фигура на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) с текстовым фреймом.

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

## **Получить эффективные свойства стиля текста**

С помощью Aspose.Slides можно получить эффективные свойства стиля текста. Интерфейс [ITextStyleEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/itextstyleeffectivedata/) содержит свойства эффективного стиля текста.

Следующий пример кода показывает, как получить эффективные свойства стиля текста. Предполагается, что первая фигура на первом слайде является [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) с текстовым фреймом.

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

С помощью Aspose.Slides можно получить эффективную высоту шрифта. Следующий код демонстрирует, как эффективная высота шрифта части изменяется после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

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

С помощью Aspose.Slides можно получить эффективное форматирование заливки для разных частей таблицы. Интерфейс [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformateffectivedata/) содержит свойства эффективного форматирования заливки. Форматирование ячейки имеет более высокий приоритет, чем форматирование строки, форматирование строки — выше, чем форматирование столбца, а форматирование столбца — выше, чем форматирование всей таблицы.

В результате свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/icellformateffectivedata/) используются при отрисовке ячейки таблицы. Следующий пример кода показывает, как получить эффективное форматирование заливки для разных частей таблицы. Предполагается, что первая фигура на первом слайде является [ITable](https://reference.aspose.com/slides/ru/net/aspose.slides/itable/).

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

**Возвращает ли `GetEffective` снимок?**

Не всегда. Данные эффективного форматирования представляют вычисленное форматирование после применения наследования, но некоторые объекты эффективных данных могут кешироваться внутри. Последующий вызов `GetEffective` может пересчитать форматирование и обновить кешированные данные, поэтому ранее полученный объект не следует рассматривать как постоянный снимок.

**Когда следует снова считывать эффективные свойства?**

Вызовите `GetEffective` повторно после изменения локального форматирования, стилей‑родителей, форматирования макета, форматирования мастера или настроек по умолчанию уровня презентации. Следующий вызов переоценивает иерархию форматирования и возвращает текущий эффективный результат.

**Влияет ли изменение или удаление слайда‑макета/мастера на уже полученные эффективные свойства?**

Да, но изменение отразится при следующем вызове `GetEffective`. Если источник родительского форматирования изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `GetEffective` Aspose.Slides переоценивает дерево форматирования, и полученные шрифты, цвета, размеры или другие значения могут измениться.

**Можно ли изменять значения через объекты эффективных данных?**

Нет. Объекты эффективных данных предоставляют только вычисленные значения. Вносите изменения в локальные объекты форматирования, а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне фигуры, макета/мастера и глобальных настроек?**

Эффективное значение определяется механизмом значений по умолчанию, включающим настройки PowerPoint и Aspose.Slides. Это разрешённое значение становится частью текущих эффективных данных.

**Можно ли по эффективному значению шрифта определить, с какого уровня было получено значение размера или типа шрифта?**

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы определить источник, проверьте локальные значения в части, абзаце, текстовом фрейме и стилях текста на уровнях макета, мастера и презентации, чтобы увидеть, где появляется первое явное определение.

**Почему иногда эффективные значения совпадают с локальными?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте эффективные данные, когда нужен результат «как при отображении» после применения всего наследования, например для согласования цветов, отступов или размеров. Если необходимо сохранять эти значения независимо от последующих изменений форматирования, скопируйте требуемые свойства в свой объект. Если нужно изменить форматирование на определённом уровне, измените локальные свойства и, при необходимости, снова считайте эффективные данные, чтобы проверить результат.