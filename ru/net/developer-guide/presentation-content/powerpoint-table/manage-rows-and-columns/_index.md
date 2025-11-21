---
title: Управление строками и столбцами в таблицах PowerPoint на .NET
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
- копировать строку
- копировать столбец
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

Для управления строками и столбцами таблицы в презентации PowerPoint Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), интерфейс [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) и множество других типов. 

## **Установить первую строку как заголовок**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию. 
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) и установите его в null. 
4. Пройдите по всем объектам [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) для поиска нужной таблицы. 
5. Установите первую строку таблицы в качестве её заголовка. 

Этот код на C# показывает, как установить первую строку таблицы в качестве заголовка:
```c#
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("table.pptx");

// Получает первый слайд
ISlide sld = pres.Slides[0];

// Инициализирует объект TableEx как null
ITable tbl = null;

// Перебирает формы и задает ссылку на таблицу
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Устанавливает первую строку таблицы как заголовок
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

Этот код на C# показывает, как клонировать строку или столбец таблицы PowerPoint:
```c#
 // Создает экземпляр класса Presentation
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

    // Клонирует строку 2 как 4‑ю строку таблицы
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

Этот код на C# показывает, как удалить строку или столбец из таблицы:
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
3. Получите нужный объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) со слайда. 
4. Установите свойство [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) у ячеек первой строки. 
5. Задайте свойства [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) у ячеек первой строки. 
6. Установите свойство [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) у ячеек второй строки. 
7. Сохраните изменённую презентацию. 

Этот код на C# демонстрирует выполнение операции.
```c#
 // Создает экземпляр класса Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Предположим, что первая фигура на первом слайде — таблица

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
3. Получите нужный объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) со слайда. 
4. Установите свойство [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) у ячеек первого столбца. 
5. Задайте свойства [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) и [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) у ячеек первого столбца. 
6. Установите свойство [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) у ячеек второго столбца. 
7. Сохраните изменённую презентацию. 

Этот код на C# демонстрирует выполнение операции: 
```c#
 // Creates an instance of the Presentation class
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Предположим, что первая фигура на первом слайде — таблица

// Устанавливает высоту шрифта ячеек первого столбца
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Устанавливает выравнивание текста ячеек первого столбца и правый отступ в одном вызове
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

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы использовать эти данные для другой таблицы или в другом месте. Этот код на C# показывает, как получить свойства стиля из предустановленного стиля таблицы: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // изменить предустановленную тему стиля по умолчанию 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **Вопросы и ответы**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/мастера, и при этом вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заново заполните строки таблицы в нужном порядке.

**Можно ли иметь чередующиеся (полосатые) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите чередующиеся столбцы, затем переопределите отдельные ячейки локальным форматированием; форматирование уровня ячейки имеет приоритет над стилем таблицы.