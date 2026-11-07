---
title: Управление текстовыми полями в презентациях на .NET
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/net/manage-textbox/
keywords:
- текстовое поле
- текстовый кадр
- добавить текст
- обновить текст
- создать текстовое поле
- проверить текстовое поле
- добавить столбец текста
- добавить гиперссылку
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте, определяйте, форматируйте и обновляйте текстовые поля в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for .NET."
---
## **Введение**

В Aspose.Slides for .NET текст слайдов хранится в текстовых кадрах, которые принадлежат фигурам. Интерфейс [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) представляет наиболее распространённую форму, содержащую текст, и раскрывает его через свойство [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Каждая автофигура реализует [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), но не каждая фигура является автофигурой или поддерживает текстовый кадр. При обработке существующей презентации следует проверять, реализует ли фигура `IAutoShape`, прежде чем обращаться к её тексту.
{{% /alert %}}

## **Создать текстовое поле на слайде**

Чтобы создать текстовое поле, добавьте автофигуру на слайд, поместите текст в её текстовый кадр и сохраните презентацию. Ниже приведён пример, создающий прямоугольное текстовое поле:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Координаты и размеры, передаваемые в [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/), измеряются в пунктах. Метод [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) инициализирует текстовый кадр переданным текстом.

## **Проверка, является ли форма текстовым полем**

Используйте свойство [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) для определения, считается ли автофигура текстовым полем. Это полезно, когда презентация содержит как текстовые, так и чисто графические автофигуры.

![Текстовое поле и фигура](istextbox.png)

Ниже приводится пример, проверяющий каждую автофигуру в презентации:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Только что добавленная автофигура не считается текстовым полем, пока в ней не окажется непустой текст. Вы можете задать текст через [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) или [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). Добавление или присвоение пустой строки оставляет `IsTextBox` со значением `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Первые два вызова выводят `True`; последние два — `False`.

## **Найти форму, владеющую текстовым фреймом**

Общий код обработки текста может получать объект [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) без информации, в какой презентации он находится. Используйте только для чтения свойство [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/), чтобы вернуться к владеющей [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).

Для текстового кадра, принадлежащего автофигуре или другой фигуре с текстом, `ParentShape` содержит владельца, а [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) равно `null`. Проверяйте полученное значение перед доступом к нему. Чтобы определить и владельцев фигур, и ячеек таблиц, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/net/search-and-replace-text/).

## **Получить прямоугольник текста формы**

Начиная с Aspose.Slides for .NET 26.11, метод [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) возвращает область текста, определённую геометрией родительской формы. Его координаты и размеры указаны в пунктах относительно левого верхнего угла этой формы. Например, у эллипса прямоугольник текста меньше, чем его внешние границы.

Этот прямоугольник описывает форму, а не отрисованные символы. Изменение текста или отступов кадра не превращает его в измерение занятого текста. Для измерения отрисованного текста используйте [paragraph bounds](/slides/ru/net/paragraph-bounds/) или [portion bounds](/slides/ru/net/portion-bounds/).

После [установки Aspose.Slides for .NET](/slides/ru/net/installation/) 26.11 или более новой версии запустите этот пример, чтобы нарисовать геометрический прямоугольник текста красным. Фигуры не вращаются и не сгруппированы, поэтому добавление их позиционных X/Y достаточно для размещения наложения на слайде.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

Для фигур размером 200 × 100 пунктов прямоугольник возвращает `(0, 0, 200, 100)`; эллипс — примерно `(29.289, 14.645, 141.421, 70.711)`. Метод также читает объявленный прямоугольник текста пользовательской геометрии. Он не учитывает вращение в пространстве слайда или трансформацию группы; эти параметры нужно применять отдельно при позиционировании наложения. Текстовый кадр без геометрической формы, например кадр ячейки таблицы, может вызвать `InvalidOperationException`.

## **Добавить столбцы в текстовое поле**

Свойство [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) делит текстовый кадр на столбцы, а [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) задаёт промежуток между столбцами в пунктах. Оба параметра принадлежат [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) и могут быть изменены через текстовый кадр существующего текстового поля. Текст перераспределяется между столбцами внутри одной формы; он не переходит в другую форму.

Ниже пример, создающий текстовое поле с тремя столбцами и отступом 10 пунктов между столбцами, сохраняющий презентацию и читающий сохранённые настройки из выходного файла:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Извлечь текст из отдельных столбцов**

Используйте [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/), чтобы получить текст, назначенный каждому визуальному столбцу в существующем текстовом кадре. Метод возвращает одну строку для каждого столбца в порядке чтения по столбцам. Текстовый кадр с одним столбцом возвращает массив из одного элемента, а пустой столбец представляется пустой строкой. Строки содержат только обычный текст; форматирование на уровне порций не сохраняется.

Это полезно, когда необходимо:

- Извлечь текст, сохранив порядок чтения по столбцам.
- Проиндексировать или сравнить содержимое слайдов с несколькими столбцами.
- Экспортировать каждый столбец в отдельный файл, поле базы данных или другое место.
- Проанализировать, как текст перераспределяется после изменения [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), шрифта или размера текстового кадра.

Метод сообщает о тексте, распределённом в текущем [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/); он не переносит текст автоматически между отдельными формами или текстовыми полями. Распределение по столбцам может зависеть от доступных шрифтов и других настроек макета текста, поэтому убедитесь, что необходимые шрифты доступны, когда важна согласованность результатов.

Ниже пример, загружающий презентацию, находящий первую автофигуру с несколькими столбцами и текстовым кадром, считывающий её количество столбцов и записывающий текст каждого столбца в отдельный файл. Фигуры без текстового кадра пропускаются.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Обновить текст**

Чтобы обновить текст во всей презентации, пройдитесь по слайдам и фигурам, выберите автофигуры и отредактируйте их текстовые порции. Работа на уровне порций позволяет изменять как текст, так и форматирование символов.

Ниже пример, заменяющий каждое вхождение `years` на `months` в тексте автофигур и делают каждую затронутую порцию полужирной:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Этот обход обновляет текст только в автофигурах. Текст, хранящийся в таблицах, диаграммах, SmartArt или сгруппированных фигурах, требует отдельного обхода соответствующих коллекций.

## **Добавить текстовое поле с гиперссылкой**

Гиперссылка может быть назначена конкретной текстовой порции, поэтому только этот текст будет вести себя как кликабельная ссылка. Используйте [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) для связывания порции с внешним URL.

Ниже пример, создающий связанный текст и сохраняющий его в презентацию:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**В чём разница между текстовым полем и заполнителем текста на слайде‑образце или макете?**

[placeholder](/slides/ru/net/manage-placeholder/) может наследовать своё положение и форматирование от [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) или [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). Обычное текстовое поле является независимой фигурой на том слайде, где оно создано, и не получает поведения заполнителя при изменении макета.

**Как заменить текст, не затронув текст в диаграммах, таблицах или SmartArt?**

Ограничьте обход фигурами, реализующими [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), как показано в примере «Update Text». Диаграммы, таблицы и SmartArt хранят текст в собственных моделях объектов, поэтому они не изменятся в результате этого цикла.