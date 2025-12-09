---
title: Управление данными серий диаграмм в презентациях на .NET
linktitle: Серии данных
type: docs
url: /ru/net/chart-series/
keywords:
- серии диаграмм
- перекрытие серий
- цвет серии
- цвет категории
- имя серии
- точка данных
- зазор серии
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм в C# для PowerPoint (PPT/PPTX) с практическими примерами кода и лучшими практиками для улучшения ваших презентаций данных."
---

## **Обзор**

Эта статья описывает роль [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) в Aspose.Slides for .NET, сосредотачиваясь на том, как данные структурируются и визуализируются в презентациях. Эти объекты предоставляют базовые элементы, определяющие отдельные наборы точек данных, категории и параметры отображения в диаграмме. Работая с [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/), разработчики могут без проблем интегрировать источники данных и полностью контролировать способ отображения информации, создавая динамичные, основанные на данных презентации, которые чётко передают выводы и анализ.

Ряд — это строка или столбец чисел, построенных в диаграмме.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

Свойство [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) управляет тем, как столбцы и бары перекрываются в 2D‑диаграмме, задавая диапазон от -100 до 100. Поскольку это свойство относится к группе серий, а не к отдельной серии, оно только для чтения на уровне серии. Чтобы задать значение перекрытия, используйте свойство `ParentSeriesGroup.Overlap` — чтение/запись, которое применяет указанный уровень перекрытия ко всем сериям в группе.

Ниже приведён пример на C#, демонстрирующий создание презентации, добавление сгруппированной столбчатой диаграммы, доступ к первой серии, настройку перекрытия и сохранение результата в файл PPTX:
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Установить перекрытие серии.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Сохранить файл презентации на диск.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


Результат:

![The series overlap](series_overlap.png)

## **Изменить цвет заливки серии**

Aspose.Slides упрощает настройку цветов заливки серий диаграмм, позволяя выделять отдельные точки данных и создавать визуально привлекательные диаграммы. Это достигается через объект [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/), который поддерживает различные типы заливки, конфигурации цветов и другие продвинутые параметры стиля. После добавления диаграммы на слайд и получения нужной серии достаточно получить объект серии и применить соответствующий цвет заливки. Помимо сплошных заливок, можно использовать градиентные или узорные заливки для большей гибкости дизайна. После установки цветов согласно требованиям сохраните презентацию, чтобы зафиксировать изменения.

Следующий пример на C# показывает, как изменить цвет первой серии:
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Установить цвет первой серии.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Сохранить файл презентации на диск.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


Результат:

![The color of the series](series_color.png)

## **Изменить название серии** 

Aspose.Slides предоставляет простой способ изменить названия серий диаграмм, упрощая маркировку данных понятным и значимым способом. Получив доступ к соответствующей ячейке листа в данных диаграммы, разработчики могут настроить отображение данных. Такое изменение особенно полезно, когда названия серий нужно обновить или уточнить в зависимости от контекста данных. После переименования серии презентацию можно сохранить, чтобы изменения сохранились.

Ниже приведён фрагмент кода на C#, демонстрирующий процесс:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Установить имя первой серии.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Сохранить файл презентации на диск.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Следующий пример на C# показывает альтернативный способ изменения названия серии:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Установить имя первой серии.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Сохранить файл презентации на диск.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Результат:

![The series name](series_name.png)

## **Получить автоматический цвет заливки серии**

Aspose.Slides for .NET позволяет получить автоматический цвет заливки серии диаграммы в области построения. После создания экземпляра класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) можно получить ссылку на нужный слайд по индексу, затем добавить диаграмму выбранного типа (например, `ChartType.ClusteredColumn`). Получив доступ к сериям диаграммы, можно извлечь автоматический цвет заливки.

Пример кода на C# ниже подробно демонстрирует этот процесс.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Получить цвет заливки серии.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```


Вывод:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **Установить инвертированный цвет заливки для серии диаграммы**

Если ваша серия содержит как положительные, так и отрицательные значения, одинаковая заливка всех столбцов или баров может затруднить восприятие. Aspose.Slides for .NET позволяет задать инвертированный цвет заливки — отдельную заливку, автоматически применяемую к точкам данных ниже нуля, чтобы отрицательные значения сразу выделялись. В этом разделе вы узнаете, как включить эту опцию, выбрать подходящий цвет и сохранить обновлённую презентацию.

Следующий пример кода демонстрирует действие:
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Добавить новые категории.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Добавить новую серию.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Заполнить данные серии.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Установить параметры цвета для серии.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```


Результат:

![The inverted solid fill color](inverted_solid_fill_color.png)

Можно инвертировать цвет заливки для отдельной точки данных, а не всей серии. Просто получите нужный `IChartDataPoint` и установите его свойство `InvertIfNegative` в true.

Следующий пример кода показывает, как это сделать:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Инвертировать цвет, если точка данных с индексом 2 отрицательная.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **Очистить значения конкретной точки данных**

Иногда в диаграмме остаются тестовые значения, выбросы или устаревшие записи, которые нужно удалить без пересоздания всей серии. Aspose.Slides for .NET позволяет выбрать любую точку данных по индексу, очистить её содержимое и мгновенно обновить построение, чтобы оставшиеся точки сместились, а оси автоматически пересчитали масштаб.

Следующий пример кода демонстрирует операцию:
```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```


## **Установить ширину промежутка между сериями**

Ширина промежутка управляет количеством пустого пространства между соседними столбцами или барами — большие промежутки подчёркивают отдельные категории, а узкие — создают более плотный вид. С помощью Aspose.Slides for .NET вы можете точно настроить этот параметр для всей серии, достигая нужного визуального баланса без изменения исходных данных.

Следующий пример кода показывает, как задать ширину промежутка для серии:
```cs
ushort gapWidth = 30;

// Создать пустую презентацию.
using (Presentation presentation = new Presentation())
{
    // Получить первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавить диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Сохранить презентацию на диск.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Установить значение GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Сохранить презентацию на диск.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


Результат:

![The gap width](gap_width.png)

## **FAQ**

**Существует ли ограничение на количество серий в одной диаграмме?**

Aspose.Slides не накладывает фиксированного ограничения на количество добавляемых серий. Практический предел определяется читабельностью диаграммы и объёмом доступной памяти вашего приложения.

**Что делать, если столбцы внутри кластера находятся слишком близко или слишком далеко друг от друга?**

Отрегулируйте параметр `GapWidth` для этой серии (или её родительской группы). Увеличение значения расширит пространство между столбцами, а уменьшение — сократит его.