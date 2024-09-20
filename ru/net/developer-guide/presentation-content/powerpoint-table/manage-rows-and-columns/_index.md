---
title: Управление строками и столбцами
type: docs
weight: 20
url: /net/manage-rows-and-columns/
keywords: "Таблица, строки и столбцы таблицы, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Управление строками и столбцами таблицы в презентациях PowerPoint на C# или .NET"

---

Чтобы управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), интерфейс [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) и многие другие типы.

## **Установить первую строку в качестве заголовка**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Создайте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) и установите его в null.
4. Переберите все объекты [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), чтобы найти соответствующую таблицу.
5. Установите первую строку таблицы в качестве заголовка.

Этот код на C# демонстрирует, как установить первую строку таблицы в качестве заголовка:

```c#
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("table.pptx");

// Получает первый слайд
ISlide sld = pres.Slides[0];

// Инициализирует пустой объект TableEx
ITable tbl = null;

// Перебирает фигуры и устанавливает ссылку на таблицу
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Устанавливает первую строку таблицы в качестве заголовка
tbl.FirstRow = true;

// Сохраняет презентацию на диск
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Клонировать строку или столбец таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд через метод [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Клонируйте строку таблицы.
7. Клонируйте столбец таблицы.
8. Сохраните модифицированную презентацию.

Этот код на C# демонстрирует, как клонировать строку или столбец таблицы PowerPoint:

```c#
// Создает экземпляр класса Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Получает первый слайд
    ISlide sld = presentation.Slides[0];

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Добавляет фигуру таблицы на слайд
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Добавляет текст в ячейку строки 1, столбец 1
    table[0, 0].TextFrame.Text = "Ячейка 1 строки 1";

    // Добавляет текст в ячейку строки 1, столбец 2
    table[1, 0].TextFrame.Text = "Ячейка 2 строки 1";

    // Клонирует строку 1 в конец таблицы
    table.Rows.AddClone(table.Rows[0], false);

    // Добавляет текст в ячейку строки 2, столбец 1
    table[0, 1].TextFrame.Text = "Ячейка 1 строки 2";

    // Добавляет текст в ячейку строки 2, столбец 2
    table[1, 1].TextFrame.Text = "Ячейка 2 строки 2";

    // Клонирует строку 2 как 4-ю строку таблицы
    table.Rows.InsertClone(3, table.Rows[1], false);

    // Клонирует первый столбец в конец
    table.Columns.AddClone(table.Columns[0], false);

    // Клонирует 2-й столбец по индексу 4-го столбца
    table.Columns.InsertClone(3, table.Columns[1], false);
    
    // Сохраняет презентацию на диск 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Удалить строку или столбец из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд через метод [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Удалите строку таблицы.
7. Удалите столбец таблицы.
8. Сохраните модифицированную презентацию.

Этот код на C# демонстрирует, как удалить строку или столбец из таблицы:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Установить форматирование текста на уровне строки таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к соответствующему объекту [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайде.
4. Установите [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) ячеек первой строки.
5. Установите [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) ячеек первой строки.
6. Установите [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) ячеек второй строки.
7. Сохраните модифицированную презентацию.

Этот код на C# демонстрирует операцию.

```c#
// Создает экземпляр класса Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Предположим, что первый элемент на первом слайде - это таблица

// Устанавливает высоту шрифта ячеек первой строки
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Устанавливает выравнивание текста и правый отступ для ячеек первой строки
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Устанавливает вертикальный тип текста ячеек второй строки
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Сохраняет презентацию на диск
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Установить форматирование текста на уровне столбца таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к соответствующему объекту [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайде.
4. Установите [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) ячеек первого столбца.
5. Установите [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) ячеек первого столбца.
6. Установите [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) ячеек второго столбца.
7. Сохраните модифицированную презентацию.

Этот код на C# демонстрирует операцию:

```c#
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Предположим, что первый элемент на первом слайде - это таблица

// Устанавливает высоту шрифта ячеек первого столбца
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Устанавливает выравнивание текста и правый отступ для ячеек первого столбца за один вызов
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Устанавливает вертикальный тип текста ячеек второго столбца
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Сохраняет презентацию на диск
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Получить свойства стиля таблицы**

Aspose.Slides позволяет вам получать свойства стиля для таблицы, чтобы вы могли использовать эти детали для другой таблицы или в другом месте. Этот код на C# показывает, как получить свойства стиля из предустановленного стиля таблицы:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // изменяет предустановленный стиль по умолчанию
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```