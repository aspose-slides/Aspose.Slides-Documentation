---
title: Управление таблицами презентации в .NET
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/net/manage-table/
keywords:
- добавить таблицу
- создать таблицу
- доступ к таблице
- соотношение сторон
- выравнивание текста
- форматирование текста
- стиль таблицы
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для .NET. Откройте простые примеры кода на C#, чтобы оптимизировать работу с таблицами."
---
## **Введение**

Таблицы в PowerPoint упорядочивают информацию в строки и столбцы, упрощая чтение и сравнение значений.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , интерфейс [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , класс [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) , интерфейс [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) , а также другие типы, позволяющие создавать, обновлять и управлять таблицами в презентациях.

## **Создание таблицы с нуля**

Создайте таблицу, указав её позицию, ширины столбцов и высоты строк. После добавления её на слайд вы можете форматировать границы ячеек, объединять ячейки и вставлять текст.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Определите массив ширин столбцов в пунктах.
4. Определите массив высот строк в пунктах.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд с помощью метода [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) .
6. Итерируйте каждый [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) , чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые два ячейки первой строки таблицы.
8. Получите доступ к объединённой ячейке через её свойство [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) .
9. Установите текст в объединённой ячейке.
10. Сохраните изменённую презентацию.

Пример ниже создаёт таблицу с тремя столбцами и пятью строками в точке (100, 50). Он применяет красные границы шириной 5 пунктов, объединяет первые два ячейки в первой строке и сохраняет результат как `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Нумерация в стандартной таблице**

В стандартной таблице индексы ячеек начинаются с нуля и используют порядок (столбец, строка). Первая ячейка имеет индекс (0, 0).

Например, ячейки таблицы с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот пример создаёт таблицу 4 × 4, показанную выше, с шириной столбцов и высотой строк 70 пунктов и красными границами ячеек шириной 5 пунктов. Координаты показывают индексы ячеек; пример оставляет ячейки пустыми и сохраняет таблицу как `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Доступ к существующей таблице**

Таблицы хранятся в коллекции фигур слайда. Пройдитесь по фигурам, чтобы найти таблицу, затем используйте интерфейс [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , чтобы читать или обновлять её ячейки.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на слайд, содержащий таблицу, по его индексу.
3. Итерируйте объекты [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) , останавливаясь, когда найдёте таблицу. Если слайд содержит несколько таблиц, используйте [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) , чтобы определить нужную.
4. Обновите текст в целевой ячейке.
5. Сохраните изменённую презентацию.

Пример ниже открывает `UpdateExistingTable.pptx` и находит первую таблицу на первом слайде. Он устанавливает значение ячейки в столбце 0, строка 1 в `New` и сохраняет результат как `table1_out.pptx`. Входные данные должны содержать минимум один слайд, а первая таблица на этом слайде должна иметь минимум один столбец и две строки.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Чтобы изменить высоту строки в существующей таблице и понять, почему её фактическая высота может превышать запрошенный минимум, см. [Управление высотой строк](/slides/ru/net/manage-rows-and-columns/#control-row-height).

## **Найти ячейку, владеющую текстовым фреймом**

Когда общий код обработки текста получает [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) из таблицы, используйте свойство [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) , чтобы получить владеющую [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) . Для текстового фрейма ячейки таблицы свойство [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) установлено, а [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) имеет значение `null`, хотя сама таблица является фигурой.

Координаты ячейки доступны через только для чтения свойства [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) и [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) . Свойство [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) также только для чтения: оно предоставляет навигацию к владельцу, но не меняет владение. Всегда проверяйте возвращённую ячейку на `null` перед использованием.

Для полного примера, определяющего владельцев ячеек таблицы и фигур, включая фигуры, связанные с узлами SmartArt, см. [Поиск и замена текста](/slides/ru/net/search-and-replace-text/) .

## **Выравнивание текста в таблице**

Вы можете управлять вертикальной привязкой и направлением текста отдельных ячеек таблицы. Пример в этом разделе центрирует текст в первой ячейке и вращает его на 270 градусов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд.
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) из таблицы.
5. Получите первый [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) и задайте его текст и цвет.
6. Установите свойства ячейки [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) и [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) .
7. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 4 × 4 с шириной столбцов 120 пунктов и высотой строк 100 пунктов. Он форматирует текст в ячейке (0, 0), добавляет значения в остальные ячейки первой строки и сохраняет результат как `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Установка форматирования текста на уровне таблицы**

Используйте [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) , чтобы применить форматирование текста ко всем ячейкам таблицы. Его перегрузки принимают форматирование части, абзаца и текстового фрейма, поэтому вы можете задавать эти свойства без итерации по отдельным ячейкам.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Получите объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) слайда.
4. Установите [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) для текста.
5. Задайте [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) .
6. Установите [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) .
7. Сохраните изменённую презентацию.

Пример ниже открывает `table.pptx`, который должен содержать минимум один слайд с таблицей в качестве первой фигуры. Он задаёт размер шрифта 25 пунктов, выравнивает абзацы по правому краю с правым отступом 20 пунктов и делает текст вертикальным. Отформатированная презентация сохраняется как `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Получение свойств стиля таблицы**

Используйте [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) , чтобы прочитать или назначить предустановленный стиль таблицы. Этот пример применяет [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) к одной таблице, выводит имя предустановки и назначает тот же стиль второй таблице. Обе таблицы сохраняются в `table-style.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Блокировка коэффициента пропорций таблицы**

Коэффициент пропорций таблицы — это отношение её ширины к высоте. Используйте [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) , чтобы заблокировать это отношение для таблицы.

Пример ниже открывает `pres.pptx`, который должен содержать минимум один слайд с таблицей в качестве первой фигуры. Он выводит текущее состояние блокировки, включается блокировка коэффициента пропорций, выводит обновлённое состояние (`True`) и сохраняет результат как `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет свойство [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) , а у абзацев есть [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) . Использование обоих обеспечивает правильный порядок RTL и корректное отображение внутри ячеек.

**Как я могу предотвратить перемещение или изменение размера таблицы в конечном файле?**

Используйте [блокировки фигур](/slides/ru/net/applying-protection-to-presentation/) , чтобы отключить перемещение, изменение размера, выделение и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [заполнение картинкой](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) для ячейки; изображение покрывает область ячейки в соответствии с выбранным режимом (растянуть или повторить).