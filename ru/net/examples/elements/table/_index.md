---
title: Таблица
type: docs
weight: 120
url: /ru/net/examples/elements/table/
keywords:
- таблица
- добавить таблицу
- доступ к таблице
- удалить таблицу
- объединить ячейки
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работа с таблицами в Aspose.Slides for .NET: создание, форматирование, объединение ячеек, применение стилей, импорт данных и экспорт с примерами на C# для PPT, PPTX и ODP."
---
Примеры добавления таблиц, доступа к ним, удаления и объединения ячеек с использованием **Aspose.Slides for .NET**.

## **Add a Table**

Создайте простую таблицу с двумя строками и двумя столбцами.

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **Access a Table**

Получите первую форму таблицы на слайде.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Получить первую таблицу на слайде.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Remove a Table**

Удалите таблицу со слайда.

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **Merge Table Cells**

Объедините соседние ячейки таблицы в одну ячейку.

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```