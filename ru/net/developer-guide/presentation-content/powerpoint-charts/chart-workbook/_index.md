---
title: Управление рабочими книгами диаграмм в презентациях на .NET
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/net/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кэш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Откройте Aspose.Slides для .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. В ней показано, как считывать и записывать данные диаграмм через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграмм.

Она также охватывает работу с внешними рабочими книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

## **Чтение и запись данных диаграммы из рабочей книги**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/writeworkbookstream/), позволяющие считывать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаковым образом или иметь структуру, аналогичную исходной.

Этот код C# демонстрирует пример операции:

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

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте пузырьковую диаграмму с некоторыми данными.
1. Получите доступ к сериям диаграммы.
1. Установите ячейку рабочей книги в качестве метки данных.
1. Сохраните презентацию.

Этот код C# показывает, как установить ячейку рабочей книги в качестве метки данных диаграммы:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Создаёт экземпляр класса презентации, представляющего файл презентации 

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

Этот код C# демонстрирует операцию, в которой свойство [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) используется для доступа к коллекции листов:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Указание типа источника данных**

Этот код C# показывает, как указать тип для источника данных:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Обнаружение неподдерживаемых встроенных форматов рабочих книг**

Aspose.Slides не поддерживает формат двоичной рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать свойство `EmbeddedWorkbookType` у [IChartData](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Встроенная рабочая книга в формате .xlsb, который не поддерживается.
            continue;
        }

        // Считайте или измените данные рабочей книги диаграммы здесь.
    }
}
```

## **Внешняя рабочая книга**

{{% alert color="primary" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/ru/net/aspose-slides-for-net-19-4-release-notes/) мы реализовали поддержку внешних рабочих книг в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создание внешней рабочей книги**
С помощью методов **`ReadWorkbookStream`** и **`SetExternalWorkbook`** вы можете либо создать внешнюю рабочую книгу с нуля, либо сделать внутреннюю рабочую книгу внешней.

Этот код C# демонстрирует процесс создания внешней рабочей книги:

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

### **Назначение внешней рабочей книги**
С помощью метода **`SetExternalWorkbook`** вы можете присвоить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также можно использовать для обновления пути к внешней рабочей книге (если последняя была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, такие книги всё равно можно использовать в качестве внешнего источника данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Этот код C# показывает, как установить внешнюю рабочую книгу:

```c#
// Путь к каталогу документов.
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

Параметр `ChartData` (в методе `SetExternalWorkbook`) используется для указания, будет ли загружена Excel‑рабочая книга.

* Когда значение `ChartData` установлено в `false`, обновляется только путь к рабочей книге — данные диаграммы не загружаются и не обновляются из целевой рабочей книги. Этот параметр полезен, когда целевая рабочая книга отсутствует или недоступна. 
* Когда значение `ChartData` установлено в `true`, данные диаграммы обновляются из целевой рабочей книги.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Получение пути к внешнему источнику данных рабочей книги диаграммы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для формы диаграммы.
1. Создайте объект для типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
1. Укажите соответствующее условие, исходя из того, что тип источника совпадает с типом внешней рабочей книги.

Этот код C# демонстрирует операцию:

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

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как изменяете содержимое внутренних книг. Если внешнюю рабочую книгу невозможно загрузить, генерируется исключение.

Этот код C# реализует описанный процесс:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Восстановление рабочей книги из кеша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/), настройте её [SpreadsheetOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/spreadsheetoptions/), и установите [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) в `true` перед открытием презентации.

Следующий пример C# открывает презентацию, в которой диаграмма ссылается на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [IChart.ChartData](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/chartdata/) и [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует `InvalidOperationException`. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой альтернативой, потому что кеш может не содержать изменений, внесённых во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, привязана ли конкретная диаграмма к внешней или встроенной рабочей книге?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/datasourcetype/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/externalworkbookpath/); если источник – внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги можно использовать в качестве внешнего источника данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/externalworkbookpath/) и использует её для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/net/)) и связывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит собственную ссылку. Если они указывают на один и тот же файл, его обновление отразится во всех диаграммах при следующей загрузке данных.