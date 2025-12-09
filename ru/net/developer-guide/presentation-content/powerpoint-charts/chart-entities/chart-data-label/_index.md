---
title: Управление подписями данных диаграмм в презентациях на .NET
linktitle: Подпись данных
type: docs
url: /ru/net/chart-data-label/
keywords:
- диаграмма
- подпись данных
- точность данных
- процент
- расстояние подписи
- расположение подписи
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать подписи данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides for .NET для более увлекательных слайдов."
---

Подписи данных на диаграмме отображают сведения о рядах данных диаграммы или отдельных точках данных. Они позволяют читателям быстро идентифицировать ряды данных и делают диаграммы более понятными.

## **Установка точности данных в подписи диаграммы**

Этот код C# показывает, как задать точность данных в подписи диаграммы:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```


## **Отображение процентов в виде подписи**
Aspose.Slides for .NET позволяет устанавливать процентные подписи на отображаемых диаграммах. Этот код C# демонстрирует операцию:
```c#
// Создает экземпляр класса Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// Сохраняет презентацию, содержащую диаграмму
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```


## **Установка знака процента в подписях диаграммы**
Этот код C# показывает, как установить знак процента для подписи диаграммы:
```c#
// Создает экземпляр класса Presentation
Presentation presentation = new Presentation();

// Получает ссылку на слайд по его индексу
ISlide slide = presentation.Slides[0];

// Создает диаграмму PercentsStackedColumn на слайде
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Устанавливает NumberFormatLinkedToSource в false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Получает рабочий лист данных диаграммы
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Добавляет новую серию
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Устанавливает цвет заполнения серии
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Устанавливает свойства LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Добавляет новую серию
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Устанавливает тип заполнения и цвет
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Записывает презентацию на диск
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```


## **Установка расстояния подписи от оси**
Этот код C# показывает, как задать расстояние подписи от категориальной оси при работе с диаграммой, построенной по осям:
```c#
// Создает экземпляр класса Presentation
Presentation presentation = new Presentation();

// Получает ссылку на слайд
ISlide sld = presentation.Slides[0];

// Создает диаграмму на слайде
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Устанавливает расстояние подписи от оси
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Записывает презентацию на диск
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```


## **Регулировка положения подписи**

Когда вы создаёте диаграмму, не зависящую от осей, например круговую диаграмму, подписи данных могут оказаться слишком близко к её краю. В таком случае необходимо скорректировать положение подписи, чтобы линии‑подвязки отображались чётко.

Этот код C# показывает, как отрегулировать положение подписи на круговой диаграмме:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Как предотвратить перекрытие подписей данных на плотных диаграммах?**

Сочетайте автоматическое размещение подписей, линии‑подвязки и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте подписи только для крайних/ключевых точек.

**Как отключить подписи только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением подписей и отключите отображение для значений 0, отрицательных значений или отсутствующих значений согласно заданному правилу.

**Как обеспечить единообразный стиль подписи при экспорте в PDF/изображения?**

Явно задавайте шрифты (семейство, размер) и проверяйте, что шрифт доступен на стороне рендеринга, чтобы избежать его подстановки.