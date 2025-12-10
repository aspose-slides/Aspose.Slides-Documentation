---
title: Таблица
type: docs
weight: 120
url: /ru/net/examples/elements/table/
keywords:
- пример таблицы
- добавить таблицу
- доступ к таблице
- удалить таблицу
- объединить ячейки
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и форматируйте таблицы в C# с помощью Aspose.Slides: вставляйте данные, объединяйте ячейки, оформляйте границы, выравнивайте содержимое и импортируйте/экспортируйте файлы PPT, PPTX и ODP."
---

Примеры добавления таблиц, доступа к ним, удаления их и объединения ячеек с использованием **Aspose.Slides for .NET**.

## **Добавление таблицы**
Создайте простую таблицу из двух строк и двух столбцов.
```csharp
static void Add_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```


## **Доступ к таблице**
Получите первую форму таблицы на слайде.
```csharp
static void Access_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Доступ к первой таблице на слайде
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```


## **Удаление таблицы**
Удалите таблицу со слайда.
```csharp
static void Remove_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```


## **Объединение ячеек таблицы**
Объедините соседние ячейки таблицы в одну ячейку.
```csharp
static void Merge_Table_Cells()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```
