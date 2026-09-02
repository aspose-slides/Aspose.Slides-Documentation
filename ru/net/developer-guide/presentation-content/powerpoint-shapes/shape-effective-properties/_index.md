---
title: Получить эффективные свойства фигур из презентаций в .NET
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/net/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- освещение
- фаска формы
- текстовый кадр
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для .NET, чтобы различать локальное, унаследованное и эффективное форматирование фигур в презентациях PowerPoint."
---
## **Понимание локальных, унаследованных и эффективных свойств**

Форматирование PowerPoint может поступать из нескольких источников. Значение, хранящееся непосредственно в объекте, является его **локальным значением**. Если это значение не задано, PowerPoint ищет его в родительских источниках форматирования, таких как значение по умолчанию для абзаца, стиль текста, макет или образец слайда, тема или настройки по умолчанию для всей презентации. Эти значения являются **унаследованными значениями**. Значение, оставшееся после разрешения всей иерархии, — это **эффективное значение** — значение, используемое для отрисовки объекта.

Например, часть текста может не определять собственный размер шрифта. Его локальный [FontHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/fontheight/) тогда равен `float.NaN`, что означает «не задано здесь». Часть может унаследовать высоту от абзаца, стиля текста по умолчанию презентации или другого соответствующего источника. Вызов [GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/geteffective/) для формата части возвращает окончательно разрешённую высоту.

Используйте два типа данных форматирования для разных целей:

- Читайте или изменяйте локальный объект формата, например [IPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/), когда необходимо контролировать, где определено значение.
- Читайте эффективный объект данных, например [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformateffectivedata/), когда требуется окончательный отрисованный результат. Эффективные данные только для чтения.

## **Сравнение локальных, унаследованных и эффективных значений**

Следующий полный пример создаёт форму и задаёт высоту шрифта на уровнях презентации, абзаца и части. На каждом шаге выводятся значения, определённые на этих уровнях, и получаемое эффективное значение для той же части текста. Он также демонстрирует, почему эффективные данные необходимо считывать снова после изменений форматирования.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Определите унаследованные значения на двух разных уровнях.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Локальное значение в части переопределяет оба унаследованных значения.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Изменение унаследованного значения не переопределяет существующее локальное значение.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Очистите локальное значение. Теперь часть снова наследуется от абзаца.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Очистите значение абзаца. Теперь значение берётся из настроек по умолчанию презентации.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Прочитайте эффективные данные после предыдущих изменений.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Приоритет в этом примере: локальное форматирование части, затем форматирование абзаца, затем значение по умолчанию презентации. У других объектов могут быть разные цепочки наследования, но принцип тот же: более конкретное явное значение выигрывает, а [GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/geteffective/) возвращает окончательный результат.

## **Получение эффективных текстовых свойств**

Форматирование текста распределено по нескольким объектам:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/geteffective/) разрешает свойства текстового кадра, такие как отступы, привязка, автоподгонка и вертикальное направление текста.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/ru/net/aspose.slides/itextstyle/geteffective/) разрешает форматирование абзаца для каждого уровня стиля текста.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/geteffective/) разрешает свойства абзаца, такие как выравнивание, отступы и маркеры.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/geteffective/) разрешает свойства символов, такие как высота шрифта, гарнитура, цвет, полужирный и курсив.

Для следующего примера файл `text-formatting.pptx` должен содержать хотя бы один слайд и одну [AutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/) с непустым текстовым кадром. AutoShape может находиться в любой позиции коллекции фигур; код ищет подходящий объект и проверяет его перед использованием.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Получение эффективных 3D‑свойств**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformat/geteffective/) возвращает один объект [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/), который группирует все разрешённые 3D‑настройки. Его свойства [Camera](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/beveltop/) и [BevelBottom](https://reference.aspose.com/slides/ru/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) предоставляют соответствующие эффективные данные. Чтение этих связанных настроек вместе упрощает понимание конечного 3D‑вида формы.

Для этого примера файл `shape-3d.pptx` должен содержать хотя бы одну форму на первом слайде. Примените к этой форме 3D‑камеру, освещение или настройки фаски, если хотите, чтобы вывод содержал значения, отличные от значений по умолчанию.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Получение эффективного форматирования таблицы**

Форматирование таблицы может поступать из стиля таблицы и из форматов, применённых к всей таблице, колонке, строке или отдельной ячейке. При конфликте явно заданных заливок приоритет таков: ячейка, строка, колонка, затем вся таблица. Эффективный формат ячейки — это окончательный формат, используемый для её отрисовки.

Для этого примера файл `table-formatting.pptx` должен содержать хотя бы одну таблицу на первом слайде. Таблица должна иметь хотя бы одну строку и одну колонку. Код ищет объект [ITable](https://reference.aspose.com/slides/ru/net/aspose.slides/itable/) вместо предположения, что `Shapes[0]` является таблицей.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Если вам нужен цвет, а не только тип заливки, сначала проверьте эффективный [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformateffectivedata/filltype/), а затем считайте свойство, соответствующее этому типу — например, [SolidFillColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) для сплошной заливки.

## **Повторное чтение эффективных данных после изменений**

Эффективные данные описывают иерархию форматирования в момент их разрешения. Вызовите `GetEffective` снова после изменения любого элемента, который может участвовать в этой иерархии, включая:

- локальное форматирование объекта;
- значения по умолчанию абзаца или текстового кадра;
- стиль таблицы, таблицу, колонку, строку или формат ячейки;
- форматирование макета или образца слайда;
- данные темы или значения по умолчанию презентации;
- макет или образец, назначенный слайду.

Не храните объект эффективных данных как постоянный снимок. Aspose.Slides может кэшировать некоторые эффективные данные внутри, и последующий вызов `GetEffective` может обновить эти данные. Если нужно сравнить значения до и после изменения, скопируйте необходимые скалярные значения — например, высоту шрифта, цвет, выравнивание или ширину фаски — в свои переменные перед внесением изменений.

Чтобы изменить значение, обновите соответствующий локальный объект формата, а затем вызовите `GetEffective` для проверки результата. Само объекты эффективных данных только для чтения.

## **FAQ**

**Как определить, какой уровень предоставил эффективное значение?**

Эффективные данные содержат только окончательное значение, а не его источник. Проверьте соответствующие локальные объекты, начиная с самого конкретного уровня и двигаясь наружу. Для текста это могут быть часть, абзац, текстовый кадр, макет, образец, тема и значения по умолчанию презентации. Неопределённые значения, такие как `float.NaN` или `null`, указывают, что поиск продолжается на следующем уровне.

**Что происходит, если ни один уровень не задаёт свойство?**

Aspose.Slides разрешает соответствующее значение по умолчанию PowerPoint или библиотеки. Это разрешённое значение появляется в эффективных данных, даже если ни один локальный объект явно его не определил.

**Почему эффективное значение иногда совпадает с локальным?**

Локальное значение победило в расчёте наследования. Это ожидаемо, когда свойство явно установлено в объекте и более специфичное правило его не переопределяет.

**Когда стоит использовать локальные данные вместо эффективных?**

Используйте локальные данные для проверки или редактирования конкретного уровня форматирования. Используйте эффективные данные, когда нужен окончательный вид после применения наследования, правил темы и соответствующих стилей. Полный пример сравнения ([complete comparison example](#compare-local-inherited-and-effective-values)) демонстрирует оба подхода в одном рабочем процессе.