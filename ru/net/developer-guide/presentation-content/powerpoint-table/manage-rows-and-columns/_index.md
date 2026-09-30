---
title: Управление строками и столбцами в таблицах PowerPoint в .NET
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/net/manage-rows-and-columns/
keywords:
- строка таблицы
- столбец таблицы
- первая строка
- заголовок таблицы
- клонировать строку
- клонировать столбец
- скопировать строку
- скопировать столбец
- удалить строку
- удалить столбец
- форматирование текста строки
- форматирование текста столбца
- стиль таблицы
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте строками и столбцами таблиц в PowerPoint с помощью Aspose.Slides для .NET и ускоряйте редактирование презентаций и обновление данных."
---
## **Введение**

Aspose.Slides for .NET позволяет управлять структурой таблицы и её форматированием в презентациях PowerPoint с помощью класса [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) и интерфейса [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) . Вы можете назначить строку заголовка, клонировать или удалять строки и столбцы, а также применять форматирование текста к всей строке или столбцу.

В этой статье объясняются эти операции с примерами на C#. Также показано, как получить предустановку стиля таблицы, чтобы её можно было повторно использовать. Индексы строк и столбцов таблицы начинаются с нуля.

## **Управление высотой строки**

Используйте [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) для установки минимальной высоты строки в пунктах. Это нижняя граница, а не фиксированная высота. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) возвращает фактическую высоту и является только для чтения. Доступ к строке осуществляется через [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

Пример загружает файл [row-height-input.pptx](row-height-input.pptx), в котором таблица находится в первой фигуре на первом слайде. Первая строка начинается с 70 пунктов. Ячейки используют шрифт Arial размером 18 пунктов, перенос текста и отступы сверху и снизу по 6 пунктов; более длинный текст во втором столбце переносится на несколько строк. Пример увеличивает минимум до 100 пунктов, затем уменьшает его до 20 пунктов, выводит фактическую высоту после каждого изменения и сохраняет оба результата.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

При использованной презентации увеличение минимума добавляет пространство к строке. Уменьшение удаляет это дополнительное пространство, но фактическая высота остаётся больше 20 пунктов, поскольку текст и отступы ячеек требуют больше места. Снижение только минимума не может заставить строку стать ниже пространства, необходимого её содержимому.

Несколько факторов влияют на фактическую высоту:

- **Текст и размер шрифта:** более длинный текст, явные разрывы строк или более крупный шрифт могут требовать больше вертикального пространства.
- **Перенос и ширина столбца:** при включённом переносе более узкая [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) может приводить к большему количеству строк. Более широкий столбец может уменьшить требуемое вертикальное пространство.
- **Отступы ячеек:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) и [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) добавляют вертикальное пространство. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) и [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) уменьшают доступную ширину для текста и могут вызвать дополнительный перенос.

Для этой таблицы без объединённых ячеек ячейка, требующая наибольшего вертикального пространства, определяет ограничение снизу для всей строки. Чтобы сделать строку короче, возможно, потребуется сократить текст, уменьшить размер шрифта или отступы, либо расширить столбец.

Изображения ниже показывают одну и ту же таблицу в одинаковом масштабе. В данном запуске фактические высоты составили 70, 100 и 55,2 пункта: последняя строка осталась выше своего минимума в 20 пунктов. Точные измерения текста могут варьироваться в зависимости от доступных в вашей системе шрифтов. Скачайте сохранённые результаты: [increased minimum](row-height-increased.pptx) и [decreased minimum](row-height-decreased.pptx).

| Исходный: минимум 70 пт, фактическая 70 пт | Увеличенный: минимум 100 пт, фактическая 100 пт | Уменьшенный: минимум 20 пт, фактическая 55.2 пт |
| --- | --- | --- |
| ![Исходная таблица с первой строкой высотой 70 пунктов.](row-height-before.png) | ![Таблица после увеличения минимума первой строки до 100 пунктов.](row-height-increased.png) | ![Таблица после уменьшения минимума первой строки до 20 пунктов; переносимый текст удерживает строку выше минимума.](row-height-decreased.png) |

## **Установить первую строку как заголовок**

Используйте свойство [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) для пометки первой строки как заголовка. Её внешний вид зависит от применённого к таблице стиля.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Получите доступ к таблице, хранящейся как первая фигура на слайде.
4. Включите форматирование заголовка для её первой строки.
5. Сохраните изменённую презентацию.

Для примера требуется файл `table.pptx` с таблицей в первой фигуре первого слайда. Он включает форматирование заголовка для первой строки и сохраняет файл `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Клонировать строку или столбец таблицы**

Клонируйте строки или столбцы, чтобы повторно использовать их содержимое и форматирование. Вы можете добавить копию в конец таблицы или вставить её в определённую позицию.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Задайте ширины столбцов и высоты строк.
4. Добавьте таблицу методом [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Клонируйте необходимые строки.
6. Клонируйте необходимые столбцы.
7. Сохраните изменённую презентацию.

Для примера требуется файл `Test.pptx` с как минимум одним слайдом. Он создаёт таблицу из трёх столбцов и пяти строк с размерами, указанными в пунктах. Затем добавляет копии первой строки и первого столбца, после чего вставляет копии второй строки и второго столбца в индекс 3 (четвёртая позиция). В результате таблица содержит семь строк и пять столбцов. Параметр `false` отключает клонирование в соседние объединённые строки или столбцы; в этой таблице нет объединённых ячеек.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Удалить строку или столбец из таблицы**

Удалите строки или столбцы, которые больше не нужны в таблице. При удалении элемента индексы последующих строк или столбцов смещаются.

1. Создайте презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Задайте ширины столбцов и высоты строк.
4. Добавьте таблицу методом [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Удалите вторую строку и второй столбец.
6. Сохраните изменённую презентацию.

Данный пример создаёт таблицу 3 × 3 и удаляет строку и столбец с индексом 1, оставляя таблицу 2 × 2 в файле `TestTable_out.pptx`. Размеры указаны в пунктах. Параметр `false` отключает удаление соседних объединённых строк или столбцов; в этой таблице нет объединённых ячеек.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Установить форматирование текста на уровне строк таблицы**

Применяйте форматирование текста к целой строке, чтобы ячейки оставались согласованными. Вы можете задавать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Получите доступ к таблице на первом слайде.
3. Установите [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) для первой строки.
4. Установите [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) для первой строки.
5. Установите [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) для второй строки.
6. Сохраните изменённую презентацию.

Для примера требуется файл `table.pptx` с таблицей в первой фигуре первого слайда и минимум двумя строками. Он применяет 25‑пунктовый текст, выравнивание по правому краю и правый абзацный отступ 20 пунктов к первой строке, затем задаёт вертикальный текст во второй строке.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Установить форматирование текста на уровне столбцов таблицы**

Применяйте форматирование текста к целому столбцу, чтобы ячейки оставались согласованными. Вы можете задавать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Получите доступ к таблице на первом слайде.
3. Установите [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) для первого столбца.
4. Установите [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) для первого столбца.
5. Установите [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) для второго столбца.
6. Сохраните изменённую презентацию.

Для примера требуется файл `table.pptx` с таблицей в первой фигуре первого слайда и минимум двумя столбцами. Он применяет 25‑пунктовый текст, выравнивание по правому краю и правый абзацный отступ 20 пунктов к первому столбцу, затем задаёт вертикальный текст во втором столбце.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Получить свойства стиля таблицы**

Используйте свойство [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) для получения предустановки, применённой к таблице, и повторного её использования в другой таблице. Это определяет предустановку, а не отдельные переопределения форматирования ячеек.

Пример создаёт таблицу, применяет [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), считывает предустановку обратно, выводит `DarkStyle1` и сохраняет таблицу в файле `table.pptx`.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/основного шаблона, и вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, в таблицах Aspose.Slides нет встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заново заполните строки таблицы в нужном порядке.

**Можно ли использовать чередующиеся (полосатые) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите чередование столбцов, затем переопределите конкретные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет над стилем таблицы.