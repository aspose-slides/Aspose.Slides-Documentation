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
description: "Управляйте ячейками таблиц PowerPoint в C#: определяйте объединённые ячейки, удаляйте границы, разделяйте ячейки и задавайте цвета фона и изображения с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблицы и изменять их в презентациях PowerPoint. В этой статье объясняется, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разделения, изменить цвет фона ячейки и добавить изображение внутрь ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячеек через свойства ячеек и сохранить изменённую презентацию в файл PPTX.

Aspose.Slides использует индексы, начинающиеся с нуля, для доступа к ячейкам таблицы в порядке `(column, row)`.

## **Определить объединённую ячейку таблицы**

Пример открывает существующую презентацию и получает первую фигуру на первом слайде как таблицу. Предполагается, что слайд и фигура существуют и что фигура является таблицей. Затем он перебирает все строки и столбцы и использует [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) для определения ячеек в объединённых областях. Для каждого найденного совпадения выводятся координаты ячейки в порядке `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), а также начальные координаты области, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) и [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

Создайте [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и добавьте таблицу на первый слайд с помощью [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Ширины столбцов, высоты строк и положение таблицы задаются в пунктах. Пример устанавливает все четыре границы ячейки в [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), делая их невидимыми.

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

## **Добавить диагональные границы ячейки**

Используйте [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) для рисования линии из верхнего левого угла в нижний правый и [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) для рисования линии из нижнего левого угла в верхний правый. Диагональ может обозначать заголовок угла; обе диагонали могут образовать X, обозначая ячейку как «не применимо».

Каждая диагональ является [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). В её [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) установите [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) в [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) и выберите [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Установите [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) линии в пунктах.

Пример создаёт три ячейки в одной строке: красную диагональ вниз, синюю диагональ вверх и обе диагонали. Он оставляет верхние, нижние, левый и правый границы ячейки без изменений.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Диагональ — это свойство форматирования, а не разбиение ячейки. Каждая ячейка сохраняет единственный [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); области по обе стороны от диагонали нельзя редактировать независимо.

![Три ячейки таблицы, показывающие красную диагональ из верхнего левого угла в нижний правый, синюю диагональ из нижнего левого угла в верхний правый и обе диагонали, образующие X.](diagonal-cell-borders.png)

*Слева направо: нисходящая диагональ (красная, 3 пт), восходящая диагональ (синяя, 5 пт) и обе диагонали.*

## **Объединить ячейки таблицы**

Используйте [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) для объединения прямоугольного диапазона ячеек таблицы в одну ячейку. Укажите ячейки в левом верхнем и правом нижнем углах диапазона. Последний аргумент управляет тем, может ли объединение включать ячейки за пределами указанного диапазона; `false` сохраняет объединение внутри диапазона.

Пример создаёт таблицу 4 × 4 с колонками и строками по 70 пунктов, затем объединяет четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, в то время как базовая сетка таблицы остаётся четырёхстолбцовой и четырёхстрочной. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её позицию в левом верхнем углу: `table[1, 1]` в этом примере. Другие позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек за пределами диапазона не меняются.

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

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек, расположенных правее. Aspose.Slides следует модели сетки таблиц PowerPoint.

Этот пример создаёт таблицу 4 × 4 с колонками и строками по 70 пунктов и вызывает [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) для ячейки `(1, 1)`. Половина ширины ячейки в 70 пунктов передаётся для создания двух равных по ширине ячеек.

После разделения две половины доступны как `table[1, 1]` и `table[2, 1]`. Сетка таблицы теперь имеет пять столбцов: ячейки, первоначально находившиеся в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте обновлённые индексы столбцов при доступе к ячейкам после разделения.

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

Чтобы подготовить объединённые шаблонные ячейки к заполнению данными, используйте [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) для разделения вдоль существующей границы строки или [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) для разделения вдоль границы столбца.

Аргумент `index` считает строки в верхней части или столбцы в левой части разбиения; он относителен к объединённой области:

- Row split: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Column split: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Пример предполагает, что в презентации первой фигурой на первом слайде является таблица, в которой ячейки `(1, 2)` и `(1, 3)` объединены вертикально. Начиная с нижней позиции, он использует [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) и [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) для определения начала и проверяет оба диапазона. `SplitByRowSpan(1)` затем разделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов вместо этого используйте `SplitByColSpan(1)`.

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

    // Получить результирующие ячейки из таблицы после разбиения.
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

Сетка таблицы и индексы окружающих ячеек остаются неизменными. Получайте результирующие ячейки по их координатам; здесь обе имеют диапазоны 1 и [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) возвращает `False`. Более крупные области могут оставаться частично объединёнными после одного разбиения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пустая, но наследует форматирование ячейки, такое как заливка, границы и отступы. Заполняйте ячейки после разбиения и задавайте требуемое форматирование текста явно.

Сохранённая презентация содержит отдельные ячейки «Product A» и «Product B» с сохранённым форматированием шаблона. См. [Справка по API Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/).

<!-- visual-explanation:manage-cells:start -->
[![Объединённая ячейка в колонке 1, строки 2 и 3 разделяется на Product A и Product B с теми же индексами сетки.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*Разделение по диапазону строк использует существующую границу. Product A и Product B занимают (1, 2) и (1, 3) соответственно.*
<!-- visual-explanation:manage-cells:end -->

### **Разделить ячейку на определённой высоте**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) принимает высоту верхней части в пунктах. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) принимает количество существующих строк сетки в верхней части. Чтобы центрировать ячейку высотой 40 пт в правом столбце, вычтите 40 из фактической высоты ячейки и равномерно распределите оставшееся пространство сверху и снизу.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

Первое разбиение добавляет строку в сетку, оставляя нижние 90 пт в `[1, 1]`. Второе разбиение направлено на эту ячейку и добавляет ещё одну строку под ней. Правый столбец теперь содержит `[1, 0]` — 50 пт (`margin`), `[1, 1]` — 40 пт и `[1, 2]` — 50 пт (`margin`). Левая ячейка охватывает все три строки при своей исходной высоте 140 пт.

![Левая ячейка охватывает полную высоту таблицы рядом с тремя ячейками, где средняя находится в центре.](split-by-height.png)

## **Изменить цвет фона ячейки таблицы**

Этот пример создаёт таблицу со столбцами по 150 пт и строками по 50 пт. Он задаёт [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) как сплошную и [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) как красный для ячейки `(2, 3)`, находящейся в третьем столбце и четвёртой строке.

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

Поместите входное изображение в рабочий каталог перед запуском этого примера. Оно загружает изображение с помощью [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) и добавляет его в коллекцию изображений презентации через [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Затем изображение назначается в виде заливки рисунком ячейки `(0, 0)`, первой ячейки таблицы.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) растягивает изображение, заполняя ячейку, что может изменить её соотношение сторон. Ширины столбцов и высоты строк указываются в пунктах. Загруженное изображение автоматически освобождается оператором `using`.

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

## **Часто задаваемые вопросы**

**Можно ли задать различную толщину линий и стили для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут отличаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки рисунка в качестве фона ячейки?**

Поведение зависит от [режим заполнения](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при размещении плитки плитки пересчитываются.

**Можно ли назначить гиперссылку всему содержимому ячейки?**

[Гиперссылки](/slides/ru/net/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/фигуры. На практике вы назначаете ссылку части текста или всему тексту в ячейке.

**Можно ли задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [части](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) с независимым форматированием — семейство шрифта, стиль, размер и цвет.