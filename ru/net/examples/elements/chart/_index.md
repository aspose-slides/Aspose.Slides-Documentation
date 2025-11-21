---
title: Диаграмма
type: docs
weight: 60
url: /ru/net/examples/elements/chart/
keywords:
- пример диаграммы
- добавить диаграмму
- доступ к диаграмме
- удалить диаграмму
- обновить диаграмму
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы на C# с помощью Aspose.Slides: добавляйте данные, форматируйте серии, оси и подписи, меняйте типы и экспортируйте — работает с PPT, PPTX и ODP."
---

Примеры добавления, доступа, удаления и обновления различных типов диаграмм с помощью **Aspose.Slides for .NET**. Приведённые ниже фрагменты демонстрируют базовые операции с диаграммами.

## Добавить диаграмму

Этот метод добавляет простую областную диаграмму на первый слайд.
```csharp
static void Add_Chart()
{
    using var pres = new Presentation();

    // Добавьте простую столбчатую диаграмму на первый слайд
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```


## Доступ к диаграмме

После создания диаграммы вы можете получить её из коллекции фигур.
```csharp
static void Access_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Доступ к первой диаграмме на слайде
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```


## Удалить диаграмму

Следующий код удаляет диаграмму со слайда.
```csharp
static void Remove_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Удалить диаграмму
    slide.Shapes.Remove(chart);
}
```


## Обновить данные диаграммы

Вы можете изменить свойства диаграммы, например заголовок.
```csharp
static void Update_Chart_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Изменить заголовок диаграммы
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
