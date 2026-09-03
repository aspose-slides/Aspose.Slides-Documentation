---
title: Управление текстовыми блоками в презентациях в .NET
linktitle: Управление текстовым блоком
type: docs
weight: 20
url: /ru/net/manage-textbox/
keywords:
- текстовый блок
- текстовый кадр
- добавить текст
- обновить текст
- создать текстовый блок
- проверить текстовый блок
- добавить колонку текста
- добавить гиперссылку
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте, идентифицируйте, форматируйте и обновляйте текстовые блоки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET."
---
## **Введение**

В Aspose.Slides for .NET текст слайдов хранится в текстовых кадрах, которые принадлежат фигурам. Интерфейс [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) представляет наиболее распространённую фигуру, содержащую текст, и предоставляет доступ к её тексту через свойство [IAutoShape.TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Каждая автофигура реализует [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/), но не каждая фигура является автофигурой или поддерживает текстовый кадр. При обработке существующей презентации проверьте, реализует ли фигура `IAutoShape`, прежде чем обращаться к её тексту.
{{% /alert %}}

## **Создание текстового блока на слайде**

Чтобы создать текстовый блок, добавьте автофигуру на слайд, добавьте текст в её текстовый кадр и сохраните презентацию. Следующий пример создаёт прямоугольный текстовый блок:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Координаты и размеры, передаваемые в [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addautoshape/), измеряются в пунктах. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/addtextframe/) инициализирует текстовый кадр переданным текстом.

## **Проверка, является ли фигура текстовым блоком**

Используйте свойство [AutoShape.IsTextBox](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/istextbox/) для определения, рассматривается ли автофигура как текстовый блок. Это полезно, когда презентация содержит как фигуры с текстом, так и чисто графические автофигуры.

![Текстовый блок и фигура](istextbox.png)

Следующий пример проверяет каждую автофигуру в презентации:

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

Новую автофигуру не считают текстовым блоком, пока в ней не будет непустого текста. Вы можете задать этот текст через [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/addtextframe/) или [ITextFrame.Text](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/text/). Добавление или присвоение пустой строки оставляет `IsTextBox` равным `false`:

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

## **Нахождение фигуры, владеющей текстовым кадром**

Общий код обработки текста может получать [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) без информации, какая презентация его содержит. Используйте только для чтения свойство [ITextFrame.ParentShape](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/parentshape/) для перехода к владелецу [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/).

Для текстового кадра, принадлежащего автофигуре или другой фигуре с текстом, `ParentShape` содержит владельца, а [ITextFrame.ParentCell](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/parentcell/) равно `null`. Проверьте возвращаемое значение перед доступом к нему. Чтобы определить как фигуру, так и ячейку таблицы‑владельца, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/net/search-and-replace-text/).

## **Добавление колонок в текстовый блок**

Свойство [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/columncount/) делит текстовый кадр на колонки, а [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/columnspacing/) задаёт промежуток между колонками в пунктах. Оба параметра принадлежат [ITextFrameFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/) и могут быть изменены через текстовый кадр существующего текстового блока. Текст переflows внутри колонок одной фигуры; он не продолжается в другой фигуре.

Следующий пример создаёт трёхколоночный текстовый блок с 10 пунктами между колонками, сохраняет презентацию и считывает сохранённые настройки из выходного файла:

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

## **Извлечение текста из отдельных колонок**

Используйте [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/splittextbycolumns/) для получения текста, присвоенного каждой визуальной колонке в существующем текстовом кадре. Метод возвращает одну строку для каждой колонки в порядке чтения по колонкам. Текстовый кадр с одной колонкой возвращает массив из одного элемента, а пустая колонка представлена пустой строкой. Строки содержат только обычный текст; форматирование уровней части не сохраняется.

Это полезно, когда нужно:

- Извлечь текст, сохранив порядок чтения по колонкам.
- Проиндексировать или сравнить содержимое слайдов с несколькими колонками.
- Экспортировать каждую колонку в отдельный файл, поле базы данных или другое место.
- Проанализировать, как текст перераспределяется после изменения [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/columnspacing/), шрифта или размера текстового кадра.

Метод сообщает о тексте, распределённом внутри текущего [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/); он не переносит текст автоматически между отдельными фигурами или текстовыми блоками. Распределение колонок может зависеть от доступных шрифтов и других настроек верстки, поэтому убедитесь, что требуемые шрифты доступны, когда важна консистентность результатов.

Следующий пример загружает презентацию, ищет первую автофигуру с несколькими колонками и текстовым кадром, считывает её текущий счётчик колонок и записывает текст каждой колонки в отдельный файл. Фигуры без текстового кадра пропускаются.

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

## **Обновление текста**

Чтобы обновить текст во всей презентации, переберите слайды и фигуры, выберите автофигуры и отредактируйте их части текста. Работа на уровне части позволяет изменять как сам текст, так и форматирование символов.

Следующий пример заменяет каждое вхождение `years` на `months` в тексте автофигур и делает каждую затронутую часть жирной:

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

Этот обход обновляет текст только в автофигурах. Текст, хранящийся в таблицах, диаграммах, SmartArt или групповых фигурах, требует обхода соответствующих коллекций этих объектов.

## **Добавление текстового блока со ссылкой**

Гиперссылка может быть назначена конкретной части текста, так что только эта часть будет кликабельна. Используйте [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) для связывания части с внешним URL.

Следующий пример создаёт связанный текст и сохраняет его в презентацию:

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

**В чём разница между текстовым блоком и заполнителем текста на мастер‑слайде или шаблоне?**

[Заполнитель](/slides/ru/net/manage-placeholder/) может наследовать своё положение и форматирование от [главного слайда](https://reference.aspose.com/slides/ru/net/aspose.slides/masterslide/) или [шаблона слайда](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutslide/). Обычный текстовый блок — это независимая фигура на том слайде, где он был создан, и не получает поведения заполнителя при изменении шаблона.

**Как заменить текст, не затрагивая текст в диаграммах, таблицах или SmartArt?**

Ограничьте обход фигурами, реализующими [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/), как показано в примере «Обновление текста». Диаграммы, таблицы и SmartArt хранят текст в собственных моделях объектов, поэтому они не изменяются этим циклом.