---
title: Рабочая тетрадь диаграмм
type: docs
weight: 70
url: /net/chart-workbook/
keywords: "Рабочая тетрадь диаграмм, данные диаграммы, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Рабочая тетрадь диаграмм в презентации PowerPoint на C# или .NET"
---

## **Установить данные диаграммы из рабочей тетради**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/), которые позволяют читать и записывать рабочие тетради данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Обратите внимание**, что данные диаграммы должны быть организованы таким же образом или иметь структуру, аналогичную исходной.

Этот код на C# демонстрирует пример операции:

```c#
using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

## **Установить ячейку рабочей тетради в качестве метки данных диаграммы**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте пузырьковую диаграмму с некоторыми данными.
1. Получите доступ к сериям диаграммы.
1. Установите ячейку рабочей тетради в качестве метки данных.
1. Сохраните презентацию.

Этот код на C# показывает, как установить ячейку рабочей тетради в качестве метки данных диаграммы:

```c#
string lbl0 = "Значение ячейки метки 0";
string lbl1 = "Значение ячейки метки 1";
string lbl2 = "Значение ячейки метки 2";

// Создает класс презентации, который представляет файл презентации 

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Управление листами**

Этот код на C# демонстрирует операцию, где свойство [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) используется для доступа к коллекции листов:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Указать тип источника данных**

Этот код на C# показывает, как указать тип для источника данных:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "ЛитералСтрока";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "НоваяЯчейка");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Внешняя рабочая тетрадь**

{{% alert color="primary" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/) мы реализовали поддержку внешних рабочих тетрадей как источника данных для диаграмм.
{{% /alert %}} 

### **Создать внешнюю рабочую тетрадь**
Используя методы **`ReadWorkbookStream`** и **`SetExternalWorkbook`**, вы можете либо создать внешнюю рабочую тетрадь с нуля, либо сделать внутреннюю рабочую тетрадь внешней.

Этот код на C# демонстрирует процесс создания внешней рабочей тетради:

```c#
using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Установить внешнюю рабочую тетрадь**
Используя метод **`SetExternalWorkbook`**, вы можете назначить внешнюю рабочую тетрадь диаграмме в качестве источника данных. Этот метод также может быть использован для обновления пути к внешней рабочей тетради (если последняя была перемещена).

Хотя вы не можете редактировать данные в рабочих тетрадях, хранящихся в удаленных местах или ресурсах, вы все равно можете использовать такие рабочие тетради в качестве внешнего источника данных. Если предоставлен относительный путь для внешней рабочей тетради, он автоматически преобразуется в полный путь.

Этот код на C# показывает, как установить внешнюю рабочую тетрадь:

```c#
// Путь к директории документов.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

Параметр `ChartData` (в методе `SetExternalWorkbook`) используется для указания, будет ли загружена рабочая тетрадь Excel или нет. 

* Когда значение `ChartData` установлено в `false`, обновляется только путь к рабочей тетради — данные диаграммы не будут загружены или обновлены из целевой рабочей тетради. Вам может понадобиться использовать эту настройку, когда целевая рабочая тетрадь отсутствует или недоступна. 
* Когда значение `ChartData` установлено в `true`, данные диаграммы обновляются из целевой рабочей тетради.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Получить путь к рабочей тетради источника внешних данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для формы диаграммы.
1. Создайте объект для типа источника (`ChartDataSourceType`), который представляет источник данных диаграммы.
1. Укажите соответствующее условие на основе того, что тип источника одинаков с типом источника данных внешней рабочей тетради.

Этот код на C# демонстрирует операцию:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Сохраняет презентацию
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Редактировать данные диаграммы**

Вы можете редактировать данные во внешних рабочих тетрадях так же, как и изменять содержимое внутренних рабочих тетрадей. Когда внешняя рабочая тетрадь не может быть загружена, возникает исключение.

Этот код на C# является реализацией описанного процесса:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```