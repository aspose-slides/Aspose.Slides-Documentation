---
title: Серия диаграмм
type: docs
url: /ru/net/chart-series/
keywords: "Серии диаграмм, цвет серий, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Серии диаграмм в презентациях PowerPoint на C# или .NET"
---

Серия — это ряд или столбец чисел, отображаемых на диаграмме.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серий диаграммы**

С помощью свойства [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) вы можете указать, насколько столбцы и бары должны перекрываться на 2D диаграмме (диапазон: от -100 до 100). Это свойство применяется ко всем сериям родительской группы серий: это проекция соответствующего свойства группы. Поэтому это свойство доступно только для чтения. 

Используйте свойство `ParentSeriesGroup.Overlap` для записи/чтения, чтобы установить предпочитаемое значение для `Overlap`. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте сгруппированную столбцовую диаграмму на слайд.
1. Получите доступ к первой серии диаграммы.
1. Получите доступ к `ParentSeriesGroup` серии диаграммы и установите предпочитаемое значение перекрытия для серии. 
1. Запишите измененную презентацию в файл PPTX.

Этот код на C# показывает, как установить перекрытие для серии диаграммы:

```c#
using (Presentation presentation = new Presentation())
{
    // Добавляет диаграмму
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.ChartData.Series;
    if (series[0].Overlap == 0)
    {
        // Устанавливает перекрытие серий
        series[0].ParentSeriesGroup.Overlap = -30;
    }

    // Записывает файл презентации на диск
    presentation.Save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
}
```

## **Изменить цвет серии**
Aspose.Slides для .NET позволяет вам изменить цвет серии следующим образом:

1. Создайте экземпляр класса `Presentation`.
1. Добавьте диаграмму на слайд.
1. Получите доступ к серии, цвет которой вы хотите изменить. 
1. Установите предпочитаемый тип заливки и цвет заливки.
1. Сохраните измененную презентацию.

Этот код на C# показывает, как изменить цвет серии:

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.ChartData.Series[0].DataPoints[1];
    
    point.Explosion = 30;
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Blue;

    pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Изменить цвет категории серии**
Aspose.Slides для .NET позволяет вам изменить цвет категории серии следующим образом:

1. Создайте экземпляр класса `Presentation`.
1. Добавьте диаграмму на слайд.
1. Получите доступ к категории серии, цвет которой вы хотите изменить.
1. Установите предпочитаемый тип заливки и цвет заливки.
1. Сохраните измененную презентацию.

Этот код на C# показывает, как изменить цвет категории серии:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];
    
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Blue;

    pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Изменить имя серии** 

По умолчанию имена в легенде для диаграммы — это содержимое ячеек над каждым столбцом или рядом данных. 

В нашем примере (образец изображения), 

* столбцы — это *Серия 1, Серия 2,* и *Серия 3*;
* строки — это *Категория 1, Категория 2, Категория 3,* и *Категория 4.* 

Aspose.Slides для .NET позволяет вам обновить или изменить имя серии в ее данных диаграммы и легенде. 

Этот код на C# показывает, как изменить имя серии в данных диаграммы `ChartDataWorkbook`:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = "Новое имя";
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

Этот код на C# показывает, как изменить имя серии в ее легенде через `Series`:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.ChartData.Series[0];
    
    IStringChartValue name = series.Name;
    name.AsCells[0].Value = "Новое имя";   
}
```

## **Установить цвет заливки серии**

Aspose.Slides для .NET позволяет вам установить автоматический цвет заливки для серий диаграммы внутри области построения следующим образом:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию на основе вашего предпочитаемого типа (в приведенном ниже примере мы использовали `ChartType.ClusteredColumn`).
1. Получите доступ к сериям диаграммы и установите цвет заливки на автоматический.
1. Сохраните презентацию в файл PPTX.

Этот код на C# показывает, как установить автоматический цвет заливки для серии диаграммы:

```c#
using (Presentation presentation = new Presentation())
{
    // Создает сгруппированную столбцовую диаграмму
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Устанавливает формат заливки серий на автоматический
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series[i].GetAutomaticSeriesColor();
    }

    // Записывает файл презентации на диск
    presentation.Save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Установить инвертированные цвета заливки серий диаграммы**
Aspose.Slides позволяет вам установить инвертированные цвета заливки для серий диаграмм внутри области построения следующим образом:

1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию на основе вашего предпочитаемого типа (в приведенном ниже примере мы использовали `ChartType.ClusteredColumn`).
4. Получите доступ к серии диаграммы и установите цвет заливки на инвертированный.
5. Сохраните презентацию в файл PPTX.

Этот код на C# демонстрирует операцию:

```c#
Color inverColor = Color.Red;
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Добавляет новые серии и категории
    chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Серия 1"), chart.Type);
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Категория 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Категория 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Категория 3"));

    // Берет первую серию диаграммы и заполняет ее данными.
    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;
    pres.Save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);               
}
```

## **Установить инвертирование серии, когда значение отрицательное**
Aspose.Slides позволяет вам устанавливать инвертирование через свойства `IChartDataPoint.InvertIfNegative` и `ChartDataPoint.InvertIfNegative`. Когда инвертирование установлено с помощью этих свойств, точка данных инвертирует свои цвета, когда получает отрицательное значение. 

Этот код на C# демонстрирует операцию:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.ChartData.Series;
    chart.ChartData.Series.Clear();

    series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);
    series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -2));
    series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    series[0].InvertIfNegative = false;

    series[0].DataPoints[2].InvertIfNegative = true;

    pres.Save("out.pptx", SaveFormat.Pptx);
}
```

## **Очистить данные конкретных точек данных**
Aspose.Slides для .NET позволяет вам очистить данные `DataPoints` для конкретной серии диаграммы следующим образом:

1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на диаграмму по ее индексу.
4. Переберите все `DataPoints` диаграммы и установите `XValue` и `YValue` в null.
5. Очистите все `DataPoints` для конкретной серии диаграммы.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C# демонстрирует операцию:

```c#
using (Presentation pres = new Presentation("TestChart.pptx"))
{
    ISlide sl = pres.Slides[0];

    IChart chart = (IChart)sl.Shapes[0];

    foreach (IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    chart.ChartData.Series[0].DataPoints.Clear();

    pres.Save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
}
```

## **Установить ширину зазора серии**
Aspose.Slides для .NET позволяет вам установить ширину зазора серии через свойство **`GapWidth`** следующим образом:

1. Создайте экземпляр класса `Presentation`.
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Получите доступ к любой серии диаграммы.
5. Установите свойство `GapWidth`.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C# показывает, как установить ширину зазора серии:

```c#
// Создает пустую презентацию 
Presentation presentation = new Presentation();

// Получает доступ к первому слайду презентации
ISlide slide = presentation.Slides[0];

// Добавляет диаграмму с данными по умолчанию
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 0, 0, 500, 500);

// Устанавливает индекс рабочего листа диаграммы
int defaultWorksheetIndex = 0;

// Получает рабочую книгу данных диаграммы
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Добавляет серии
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.Type);

// Добавляет категории
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Категория 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Категория 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Категория 3"));

// Берет вторую серию диаграммы
IChartSeries series = chart.ChartData.Series[1];

// Заполняет данные серии
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Устанавливает значение GapWidth
series.ParentSeriesGroup.GapWidth = 50;

// Сохраняет презентацию на диск
presentation.Save("GapWidth_out.pptx", SaveFormat.Pptx);
```