---
title: Диаграмма
type: docs
weight: 60
url: /ru/net/examples/elements/chart/
keywords:
- диаграмма
- добавить диаграмму
- доступ к диаграмме
- удалить диаграмму
- обновить диаграмму
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Освойте работу с диаграммами в Aspose.Slides for .NET: создавайте, форматируйте, привязывайте данные и экспортируйте диаграммы в PPT, PPTX и ODP с примерами на C#."
---
Примеры добавления, доступа, удаления и обновления различных типов диаграмм с помощью **Aspose.Slides for .NET**. Приведённые ниже фрагменты демонстрируют базовые операции с диаграммами.

## **Добавить диаграмму**

Этот метод добавляет простую площадную диаграмму на первый слайд.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Добавьте простую площадную диаграмму на первый слайд.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Получить диаграмму**

После создания диаграммы вы можете получить её через коллекцию фигур.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Доступ к первой диаграмме на слайде.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Удалить диаграмму**

Следующий код удаляет диаграмму со слайда.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Удалить диаграмму.
    slide.Shapes.Remove(chart);
}
```

## **Обновить данные диаграммы**

Вы можете изменить свойства диаграммы, например заголовок.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Изменить заголовок диаграммы.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```