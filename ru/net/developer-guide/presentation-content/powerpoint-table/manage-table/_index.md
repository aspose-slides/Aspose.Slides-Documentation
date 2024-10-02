---
title: Управление таблицей
type: docs
weight: 10
url: /ru/net/manage-table/
keywords: "Таблица, создать таблицу, доступ к таблице, соотношение сторон таблицы, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Создайте и управляйте таблицей в презентациях PowerPoint на C# или .NET"
---

Таблица в PowerPoint — это эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) проста и легка для восприятия.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), интерфейс [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), класс [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/), интерфейс [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) и другие типы, которые позволяют создавать, обновлять и управлять таблицами в различных типах презентаций.

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд с помощью метода [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Пройдитесь по каждому [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/), чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки в первой строке таблицы.
8. Получите [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) ячейки [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/).
9. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
10. Сохраните измененную презентацию.

Этот код на C# показывает, как создать таблицу в презентации:

```c#
// Создается экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();

// Получает первый слайд
ISlide sld = pres.Slides[0];

// Определяет столбцы с ширинами и строки с высотами
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Добавляет фигуру таблицы на слайд
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Устанавливает формат границ для каждой ячейки
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Объединяет ячейки 1 и 2 строки 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Добавляет текст в объединенную ячейку
tbl.Rows[0][0].TextFrame.Text = "Объединенные ячейки";

// Сохраняет презентацию на диск
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Нумерация в стандартной таблице**

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка в таблице индексируется как 0,0 (столбец 0, строка 0).

Например, ячейки в таблице с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот код на C# показывает, как задать нумерацию для ячеек в таблице:

```c#
// Создается экземпляр класса Presentation, который представляет файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет фигуру таблицы на слайд
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границ для каждой ячейки
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Сохраняет презентацию на диск
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Доступ к существующей таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

2. Получите ссылку на слайд, содержащий таблицу, по его индексу.

3. Создайте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) и установите его в null.

4. Пройдитесь по всем объектам [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), пока не найдете таблицу.

   Если вы подозреваете, что слайд, с которым вы работаете, содержит единственную таблицу, вы можете просто проверить все фигуры, которые он содержит. Когда фигура идентифицируется как таблица, вы можете привести ее к объекту [Table](https://reference.aspose.com/slides/net/aspose.slides/table/). Но если слайд, с которым вы работаете, содержит несколько таблиц, лучше искать нужную таблицу по ее [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/).

5. Используйте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) для работы с таблицей. В приведенном ниже примере мы добавили новую строку в таблицу.

6. Сохраните измененную презентацию.

Этот код на C# показывает, как получить доступ к существующей таблице и работать с ней:

```c#
// Создается экземпляр класса Presentation, который представляет файл PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Инициализирует null TableEx
    ITable tbl = null;

    // Проходит по фигурам и устанавливает ссылку на найденную таблицу
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Устанавливает текст для первого столбца второй строки
    tbl[0, 1].TextFrame.Text = "Новый";

    // Сохраняет измененную презентацию на диск
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд.
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) из таблицы.
5. Получите [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) из [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
6. Выравняйте текст по вертикали.
7. Сохраните изменённую презентацию.

Этот код на C# показывает, как выровнять текст в таблице:

```c#
// Создает экземпляр класса Presentation
Presentation presentation = new Presentation();

// Получает первый слайд
ISlide slide = presentation.Slides[0];

// Определяет столбцы с ширинами и строки с высотами
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Добавляет фигуру таблицы на слайд
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Получает текстовый фрейм
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Создает объект Paragraph для текстового фрейма
IParagraph paragraph = txtFrame.Paragraphs[0];

// Создает объект Portion для параграфа
IPortion portion = paragraph.Portions[0];
portion.Text = "Текст здесь";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Выравнивает текст по вертикали
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Сохраняет презентацию на диск
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Установка форматирования текста на уровне таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Получите объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) из слайда.
4. Установите [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) для текста.
5. Установите [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Установите [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Сохраните изменённую презентацию.

Этот код на C# показывает, как применить ваши предпочтительные параметры форматирования к тексту в таблице:

```c#
// Создает экземпляр класса Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Предположим, что первая фигура на первом слайде — это таблица

// Устанавливает высоту шрифта ячеек таблицы
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Устанавливает выравнивание текста ячеек таблицы и правый отступ в одном вызове
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Устанавливает вертикальный тип текста ячеек таблицы
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Получение свойств стиля таблицы**

Aspose.Slides позволяет получать свойства стиля таблицы, чтобы вы могли использовать эти детали для другой таблицы или в другом месте. Этот код на C# показывает, как получить свойства стиля из предварительно заданного стиля таблицы:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // измените предустановленный стиль по умолчанию
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической фигуры — это соотношение ее размеров в различных измерениях. Aspose.Slides предоставляет свойство `AspectRatioLocked`, чтобы вы могли заблокировать настройки соотношения сторон для таблиц и других фигур.

Этот код на C# показывает, как заблокировать соотношение сторон для таблицы:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Блокировка соотношения сторон установлена: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // инвертировать

    Console.WriteLine($"Блокировка соотношения сторон установлена: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```