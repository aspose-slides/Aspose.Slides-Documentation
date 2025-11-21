---
title: Управление строками и столбцами
type: docs
weight: 20
url: /ru/net/manage-rows-and-columns/
keywords: "Таблица, строки и столбцы таблицы, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Управляйте строками и столбцами таблицы в презентациях PowerPoint на C# или .NET"
---

Чтобы позволить вам управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Таблица](https://reference.aspose.com/slides/net/aspose.slides/table/) , интерфейс [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) и многие другие типы. 

## **Установить первую строку как заголовок**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию. 
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) и установите его в null. 
4. Переберите все объекты [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) в поисках нужной таблицы. 
5. Установите первую строку таблицы как её заголовок. 

Этот C#‑код показывает, как установить первую строку таблицы в качестве заголовка:
```c#
// Создаёт экземпляр класса Presentation
Presentation pres = new Presentation("table.pptx");

// Получает первый слайд
ISlide sld = pres.Slides[0];

// Инициализирует null TableEx
ITable tbl = null;

// Перебирает формы и задаёт ссылку на таблицу
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Устанавливает первую строку таблицы как её заголовок
tbl.FirstRow = true;

// Сохраняет презентацию на диск
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Клонировать строку или столбец таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`. 
4. Определите массив `rowHeight`. 
5. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд с помощью метода [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. Клонируйте строку таблицы. 
7. Клонируйте столбец таблицы. 
8. Сохраните изменённую презентацию. 

Этот C#‑код показывает, как клонировать строку или столбец таблицы PowerPoint:
```c#
 // Создаёт экземпляр класса Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Получает первый слайд
    ISlide sld = presentation.Slides[0];

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Добавляет форму таблицы на слайд
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Добавляет текст в ячейку 1 строки 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Добавляет текст в ячейку 2 строки 1
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Клонирует строку 1 в конец таблицы
    table.Rows.AddClone(table.Rows[0], false);

    // Добавляет текст в ячейку 1 строки 2
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Добавляет текст в ячейку 2 строки 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Клонирует строку 2 как 4-ю строку таблицы
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Клонирует первый столбец в конец
    table.Columns.AddClone(table.Columns[0], false);

    // Клонирует второй столбец на позицию 4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Сохраняет презентацию на диск 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Удалить строку или столбец из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`. 
4. Определите массив `rowHeight`. 
5. Добавьте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) на слайд с помощью метода [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. Удалите строку таблицы. 
7. Удалите столбец таблицы. 
8. Сохраните изменённую презентацию. 

Этот C#‑код показывает, как удалить строку или столбец из таблицы:
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


## **Установить форматирование текста на уровне строк таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Получите доступ к нужному объекту [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) со слайда. 
4. Установите для ячеек первой строки свойство [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/). 
5. Установите для ячеек первой строки свойства [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/). 
6. Установите для ячеек второй строки свойство [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/). 
7. Сохраните изменённую презентацию. 

Этот C#‑код демонстрирует операцию.
```c#
// Создаёт экземпляр класса Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Предположим, что первая фигура на первом слайде — это таблица

// Устанавливает высоту шрифта ячеек первой строки
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Устанавливает выравнивание текста ячеек первой строки и правый отступ
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


## **Установить форматирование текста на уровне столбцов таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Получите доступ к нужному объекту [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) со слайда. 
4. Установите для ячеек первого столбца свойство [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/). 
5. Установите для ячеек первого столбца свойства [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/). 
6. Установите для ячеек второго столбца свойство [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/). 
7. Сохраните изменённую презентацию. 

Этот C#‑код демонстрирует операцию: 
```c#
// Создаёт экземпляр класса Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Предположим, что первая фигура на первом слайде — это таблица

// Задаёт высоту шрифта ячеек первого столбца
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Задаёт выравнивание текста ячеек первого столбца и правый отступ одним вызовом
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Задаёт вертикальный тип текста ячеек второго столбца
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Сохраняет презентацию на диск
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Получить свойства стиля таблицы**

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы использовать эти данные для другой таблицы или в другом месте. Этот C#‑код показывает, как получить свойства стиля из предустановленного стиля таблицы: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // изменить предустановленную тему стиля по умолчанию
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/главного шаблона, при этом вы всё равно можете переопределять заливку, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заполните строки таблицы в нужном порядке.

**Можно ли использовать чередующиеся (полосатые) столбцы, оставив пользовательские цвета в отдельных ячейках?**

Да. Включите чередование столбцов, затем переопределите отдельные ячейки локальным форматированием; форматирование уровня ячейки имеет приоритет над стилем таблицы.