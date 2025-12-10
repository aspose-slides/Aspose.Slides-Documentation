---
title: Управление таблицами презентаций в .NET
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/net/manage-table/
keywords:
- добавление таблицы
- создание таблицы
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
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для .NET. Откройте простые примеры кода C# для упрощения работы с таблицами."
---

Таблица в PowerPoint — эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) проста и легко понимается.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , интерфейс [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , класс [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) , интерфейс [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) и другие типы, которые позволяют создавать, обновлять и управлять таблицами во всех типах презентаций. 

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд с помощью метода [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) .
6. Пройдите по каждому [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) , чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы. 
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) у [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) .
9. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) .
10. Сохраните изменённую презентацию.

Этот код C# показывает, как создать таблицу в презентации:
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();

// Получает первый слайд
ISlide sld = pres.Slides[0];

// Определяет столбцы с шириной и строки с высотой
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Добавляет форму таблицы на слайд
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Задает формат границы для каждой ячейки
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
// Объединяет ячейки 1 и 2 первой строки
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Добавляет текст в объединённую ячейку
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Сохраняет презентацию на диск
pres.Save("table.pptx", SaveFormat.Pptx);
```


## **Нумерация в стандартной таблице**

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка таблицы имеет индекс 0,0 (столбец 0, строка 0). 

Например, ячейки таблицы с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот код C# показывает, как указать нумерацию ячеек в таблице:
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет форму таблицы на слайд
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Задает формат границы для каждой ячейки
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Получите ссылку на слайд, содержащий таблицу, по его индексу. 
3. Создайте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) и присвойте ему null.
4. Пройдите по всем объектам [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) до тех пор, пока не будет найдена таблица.

   Если вы подозреваете, что рассматриваемый слайд содержит одну таблицу, вы можете просто проверить все его фигуры. Когда фигура определяется как таблица, её можно привести к объекту [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) . Но если на слайде несколько таблиц, лучше искать нужную таблицу по её [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) .

5. Используйте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) для работы с таблицей. В примере ниже мы добавили новую строку в таблицу.
6. Сохраните изменённую презентацию.

Этот код C# показывает, как получить доступ к существующей таблице и работать с ней:
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Инициализирует null TableEx
    ITable tbl = null;

    // Перебирает формы и задает ссылку на найденную таблицу
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Устанавливает текст для первого столбца второй строки
    tbl[0, 1].TextFrame.Text = "New";

    // Сохраняет изменённую презентацию на диск
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд. 
4. Получите доступ к объекту [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) из таблицы. 
5. Получите доступ к [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) в [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) .
6. Выравняйте текст по вертикали.
7. Сохраните изменённую презентацию.

Этот код C# показывает, как выравнивать текст в таблице:
```c#
// Создаёт экземпляр класса Presentation
Presentation presentation = new Presentation();

// Получает первый слайд 
ISlide slide = presentation.Slides[0];

// Определяет столбцы с ширинами и строки с высотами
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Добавляет форму таблицы на слайд
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Получает объект TextFrame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Создаёт объект Paragraph для TextFrame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Создаёт объект Portion для абзаца
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
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
3. Получите объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) со слайда.
4. Установите [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) для текста. 
5. Установите [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) .
6. Установите [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) .
7. Сохраните изменённую презентацию. 

Этот код C# показывает, как применить выбранные параметры форматирования к тексту в таблице:
```c#
// Создаёт экземпляр класса Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Предположим, что первая фигура на первом слайде является таблицей

// Задает высоту шрифта ячеек таблицы
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Задаёт выравнивание текста ячеек таблицы и правый отступ в одном вызове
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Задаёт вертикальный тип текста ячеек таблицы
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Получение свойств стиля таблицы**

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы использовать их для другой таблицы или в другом месте. Этот код C# показывает, как получить свойства стиля из предустановленного стиля таблицы: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // изменить тему предустановленного стиля по умолчанию 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической фигуры — это отношение её размеров в разных измерениях. Aspose.Slides предоставляет свойство `AspectRatioLocked`, позволяющее заблокировать настройку соотношения сторон для таблиц и других фигур. 

Этот код C# показывает, как заблокировать соотношение сторон для таблицы:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // инвертировать

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица имеет свойство [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) , а у абзацев есть [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) . Использование обоих гарантирует правильный порядок RTL и рендеринг внутри ячеек.

**Как предотвратить перемещение или изменение размера таблицы пользователями в конечном файле?**

Используйте [shape locks](/slides/ru/net/applying-protection-to-presentation/) для отключения перемещения, изменения размера, выбора и т.д. Эти блокировки также применяются к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) для ячейки; изображение покроет область ячейки в соответствии с выбранным режимом (растягивание или плитка).