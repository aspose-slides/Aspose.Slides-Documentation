---
title: Управление ячейками таблиц в презентациях на .NET
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/net/manage-cells/
keywords:
- ячейка таблицы
- объединение ячеек
- удаление границы
- разделение ячейки
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте ячейками таблиц PowerPoint в C#: определяйте объединённые ячейки, удаляйте границы, разделяйте ячейки и устанавливайте цвета фона и изображения с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблиц в презентациях PowerPoint и изменять их. В этой статье объясняется, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разбиения, изменить цвет фона ячейки и добавить изображение внутрь ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячейки через свойства ячейки и сохранить изменённую презентацию в файл PPTX.

Aspose.Slides использует индексы, начинающиеся с нуля, для доступа к ячейкам таблицы в порядке `(column, row)`.

## **Определить объединённую ячейку таблицы**

В примере открывается существующая презентация и первый объект на первом слайде берётся как таблица. Предполагается, что слайд и объект существуют и что объект является таблицей. Затем происходит перебор всех строк и столбцов, и используется [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) для определения ячеек в объединённых областях. Для каждого совпадения выводятся координаты ячейки в порядке `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), а также начальные координаты области: [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) и [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Удалить границы ячеек таблицы**

Создайте [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и добавьте таблицу на первый слайд с помощью [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Ширины столбцов, высоты строк и позиция таблицы указываются в пунктах. В примере всем четырём границам ячеек задаётся [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), делая их невидимыми.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Объединить ячейки таблицы**

Используйте [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) чтобы объединить прямоугольный диапазон ячеек таблицы в одну ячейку. Укажите ячейки в левом верхнем и правом нижнем углах диапазона. Последний аргумент определяет, может ли объединение включать ячейки за пределами указанного диапазона; `false` сохраняет объединение внутри этого диапазона.

В примере создаётся таблица 4×4 с колоннами и строками по 70 пунктов, затем объединяются четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, в то время как базовая сетка таблицы остаётся четырёхколоночной и четырёхстрочной. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её позицию в левом верхнем углу: `table[1, 1]` в этом примере. Остальные позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек за пределами диапазона не меняются.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Разделить ячейки таблицы**

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек, расположенных справа. Aspose.Slides следует модели сетки таблиц PowerPoint.

В этом примере создаётся таблица 4×4 с колоннами и строками по 70 пунктов и вызывается [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) для ячейки `(1, 1)`. Половина ширины ячейки (70 пунктов) передаётся для создания двух ячеек одинаковой ширины.

После этого разделения две половины доступны как `table[1, 1]` и `table[2, 1]`. Сетка таблицы теперь состоит из пяти столбцов: ячейки, ранее находившиеся в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте обновлённые индексы столбцов при доступе к ячейкам после разделения.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Разделить объединённые ячейки по строке или столбцу**

Чтобы подготовить объединённые шаблонные ячейки к заполнению данными, используйте [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) для разреза по существующей границе строки или [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) для разреза по границе столбца.

Аргумент `index` считает строки в верхней части или столбцы в левой части разреза; он относится к объединённой области:

- Row split: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Column split: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

В примере ожидается, что в презентации первая форма на первом слайде будет таблицей, в которой ячейки `(1, 2)` и `(1, 3)` объединены вертикально. Начиная с нижней позиции, используются [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) и [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) для определения начала и проверяются оба охвата. `SplitByRowSpan(1)` затем разделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте `SplitByColSpan(1)`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Получить результирующие ячейки из таблицы после разделения.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

Сетка таблицы и окружающие индексы ячеек остаются без изменений. Получите результирующие ячейки по их координатам; здесь обе имеют охваты 1, и [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) выводит `False`. Более крупные области могут оставаться частично объединёнными после одного разреза.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пуста, но наследует форматирование ячейки, такое как заливка, границы и отступы. После разделения заполните ячейки и явно задайте требуемое форматирование текста.

Сохранённая презентация содержит отдельные ячейки «Product A» и «Product B» с сохранённым форматированием шаблонных ячеек. См. [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) для деталей.

## **Изменить цвет фона ячейки таблицы**

В этом примере создаётся таблица с колоннами по 150 пунктов и строками по 50 пунктов. Для ячейки `(2, 3)`, находящейся в третьем столбце и четвёртой строке, задаётся [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) — solid и [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) — red.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Добавить изображение внутрь ячейки таблицы**

Поместите входное изображение в рабочий каталог перед запуском примера. Оно загружается с помощью [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) и добавляется в коллекцию изображений презентации через [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Затем изображение назначается в качестве заливки картинки ячейки `(0, 0)`, первой ячейки таблицы.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) растягивает изображение, заполняя ячейку, что может изменить её соотношение сторон. Ширины колонн и высоты строк указаны в пунктах. Загруженное изображение автоматически освобождается по завершении блока using.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Могу ли я задать различную толщину и стиль линий для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки как фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при замостке плитки пересчитываются.

**Могу ли я присвоить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/net/manage-hyperlinks/) задаются на уровне текста (portion) внутри текстового фрейма ячейки или на уровне всей таблицы/объекта. На практике ссылка присваивается отдельной части или всему тексту в ячейке.

**Могу ли я задать разные шрифты в одной ячейке?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) с независимым форматированием — семейство шрифта, стиль, размер и цвет.