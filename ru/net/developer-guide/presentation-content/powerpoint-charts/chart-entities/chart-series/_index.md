---
title: Управление сериями диаграмм в C#
linktitle: Серии диаграммы
type: docs
url: /ru/net/chart-series/
keywords:
- серия диаграмм
- перекрытие серии
- цвет серии
- цвет категории
- имя серии
- точка данных
- промежуток серии
- PowerPoint
- презентация
- C#
- .NET
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм в C# для PowerPoint (PPT/PPTX) с практическими примерами кода и рекомендациями по улучшению ваших данных в презентациях."
---

## **Обзор**

Эта статья описывает роль [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) в Aspose.Slides для .NET, фокусируясь на структуре и визуализации данных в презентациях. Эти объекты предоставляют базовые элементы, определяющие отдельные наборы точек данных, категории и параметры отображения в диаграмме. Работая с [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/), разработчики могут без проблем интегрировать исходные источники данных и полностью контролировать отображение информации, создавая динамичные, основанные на данных презентации, которые явно передают инсайты и анализ.

Серия — это строка или столбец чисел, отображаемых на диаграмме.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка перекрытия серий диаграммы**

Свойство [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) управляет тем, как столбцы и колонны перекрываются в 2D‑диаграмме, задавая диапазон от -100 до 100. Поскольку это свойство связано с группой серий, а не с отдельной серией диаграммы, на уровне серии оно доступно только для чтения. Чтобы настроить значения перекрытия, используйте свойство `ParentSeriesGroup.Overlap` с возможностью чтения‑записи, которое применяет указанное перекрытие ко всем сериям в этой группе.

Ниже приведён пример на C#, показывающий, как создать презентацию, добавить сгруппированную столбчатую диаграмму, получить доступ к первой серии диаграммы, настроить параметр перекрытия и затем сохранить результат в файл PPTX:
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Установите перекрытие серии.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Сохраните файл презентации на диск.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


Результат:

![The series overlap](series_overlap.png)

## **Изменение цвета заливки серии**

Aspose.Slides упрощает настройку цветов заливки серий диаграмм, позволяя выделять отдельные точки данных и создавать визуально привлекательные диаграммы. Это достигается с помощью объекта [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/), который поддерживает различные типы заливок, конфигурации цветов и другие продвинутые параметры стиля. После добавления диаграммы на слайд и получения доступа к нужной серии просто получите серию и примените соответствующий цвет заливки. Помимо сплошных заливок, вы также можете использовать градиентные или шаблонные заливки для большей гибкости дизайна. После задания цветов в соответствии с требованиями сохраните презентацию, чтобы завершить обновлённый вид.

Ниже пример кода на C#, показывающий, как изменить цвет первой серии:
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Установите цвет первой серии.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Сохраните файл презентации на диск.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


Результат:

![The color of the series](series_color.png)

## **Изменение названия серии** 

Aspose.Slides предоставляет простой способ изменить названия серий диаграмм, упрощая маркировку данных понятным и значимым образом. Получая доступ к соответствующей ячейке листа в данных диаграммы, разработчики могут настроить представление данных. Такое изменение особенно полезно, когда названия серий необходимо обновить или уточнить в контексте данных. После переименования серии презентацию можно сохранить, чтобы зафиксировать изменения.

Ниже фрагмент кода на C#, демонстрирующий этот процесс в действии.
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Установите имя первой серии.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Сохраните файл презентации на диск.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Следующий код на C# показывает альтернативный способ изменить название серии:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Установите имя первой серии.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Сохраните файл презентации на диск.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Результат:

![The series name](series_name.png)

## **Получение автоматического цвета заливки серии** 

Aspose.Slides для .NET позволяет получить автоматический цвет заливки серии диаграммы в области построения. После создания экземпляра класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) вы можете получить ссылку на нужный слайд по индексу, затем добавить диаграмму выбранного типа (например, `ChartType.ClusteredColumn`). Получив доступ к сериям в диаграмме, вы можете получить автоматический цвет заливки.

Код на C# ниже подробно демонстрирует этот процесс.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Добавьте сгруппированную столбчатую диаграмму с данными по умолчанию.
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


## **Установка инвертированного цвета заливки для серии диаграммы** 

Если в вашей серии данных присутствуют как положительные, так и отрицательные значения, единообразная заливка всех столбцов или полос может затруднить восприятие диаграммы. Aspose.Slides для .NET позволяет назначить инвертированный цвет заливки — отдельную заливку, автоматически применяемую к точкам данных, находящимся ниже нуля, — чтобы отрицательные значения сразу бросались в глаза. В этом разделе вы узнаете, как включить эту опцию, выбрать подходящий цвет и сохранить обновлённую презентацию.

Ниже пример кода, демонстрирующий эту операцию:
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Добавьте новые категории.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Добавьте новую серию.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Заполните данные серии.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Установите параметры цвета для серии.
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

Можно инвертировать цвет заливки для отдельной точки данных, а не всей серии. Просто получайте доступ к нужному `IChartDataPoint` и установите его свойство `InvertIfNegative` в true.

Ниже пример кода, показывающий, как это сделать:
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


## **Очистка значений конкретных точек данных** 

Иногда в диаграмме присутствуют тестовые значения, выбросы или устаревшие записи, которые необходимо удалить без перестроения всей серии. Aspose.Slides для .NET позволяет обратиться к любой точке данных по индексу, очистить её содержимое и мгновенно обновить график, чтобы оставшиеся точки сместились, а оси автоматически пересчитали масштаб.

Ниже пример кода, демонстрирующий эту операцию:
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


## **Установка ширины промежутка серии** 

Ширина промежутка контролирует количество пустого пространства между соседними столбцами или полосами — более широкие промежутки подчёркивают отдельные категории, а более узкие создают более плотный, компактный вид. С помощью Aspose.Slides для .NET вы можете точно настроить этот параметр для всей серии, достигая необходимого визуального баланса в презентации без изменения исходных данных.

Ниже пример кода, показывающий, как установить ширину промежутка для серии:
```cs
ushort gapWidth = 30;

// Создайте пустую презентацию.
using (Presentation presentation = new Presentation())
{
    // Доступ к первому слайду.
    ISlide slide = presentation.Slides[0];

    // Добавьте диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Сохраните презентацию на диск.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Установите значение GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Сохраните презентацию на диск.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


Результат:

![The gap width](gap_width.png)

## **FAQ**

**Существует ли ограничение на количество серий, которые может содержать одна диаграмма?**

Aspose.Slides не накладывает фиксированного ограничения на количество добавляемых серий. Практический лимит определяется читаемостью диаграммы и доступной оперативной памятью вашего приложения.

**Что делать, если столбцы внутри кластера находятся слишком близко друг к другу или слишком далеко друг от друга?**

Отрегулируйте параметр `GapWidth` для этой серии (или её родительской группы серий). Увеличение значения расширит пространство между столбцами, а уменьшение — сблизит их.