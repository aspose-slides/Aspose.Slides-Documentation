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
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---
## **Чтение и запись данных диаграммы из рабочей книги**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/writeworkbookstream/), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаковым способом или иметь структуру, похожую на исходную.

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

## **Установить ячейку рабочей книги как метку данных диаграммы**
1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить пузырьковую диаграмму с некоторыми данными.
1. Получить доступ к серии диаграммы.
1. Установить ячейку рабочей книги в качестве метки данных.
1. Сохранить презентацию.

Этот код на C# показывает, как установить ячейку рабочей книги в качестве метки данных диаграммы:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Создаёт экземпляр класса Presentation, представляющего файл презентации 

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
Этот код на C# демонстрирует операцию, в которой свойство [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) используется для доступа к коллекции листов:

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
Этот код на C# показывает, как указать тип для источника данных:

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

## **Обнаружение неподдерживаемых встроенных форматов рабочей книги**
Aspose.Slides не поддерживает бинарный формат рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать свойство `EmbeddedWorkbookType` в `IChartData` вместе с перечислением `WorkbookType`, чтобы обнаружить неподдерживаемые форматы и пропустить такие диаграммы.

```csharp
using (var presentation = new Presentation("pres.pptx"))
{
    foreach (var shape in presentation.Slides[0].Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Встроенная рабочая книга в формате .xlsb, который не поддерживается.
            continue;
        }

        // Читайте или изменяйте данные рабочей книги диаграммы здесь.
    }
}
```

## **Внешняя рабочая книга**
{{% alert color="primary" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/ru/net/aspose-slides-for-net-19-4-release-notes/) мы реализовали поддержку внешних рабочих книг в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создание внешней рабочей книги**
С помощью методов **`ReadWorkbookStream`** и **`SetExternalWorkbook`** вы можете создать внешнюю рабочую книгу с нуля или преобразовать внутреннюю рабочую книгу во внешнюю.

Этот код на C# демонстрирует процесс создания внешней рабочей книги:

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

### **Установка внешней рабочей книги**
С помощью метода **`SetExternalWorkbook`** вы можете назначить внешнюю рабочую книгу диаграмме в качестве источника данных. Этот метод также можно использовать для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, вы всё равно можете использовать такие книги в качестве внешнего источника данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Этот код на C# показывает, как установить внешнюю рабочую книгу:

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

* Когда значение `ChartData` установлено в `false`, обновляется только путь к рабочей книге — данные диаграммы не будут загружены или обновлены из целевой рабочей книги. Это параметр полезен, когда целевая рабочая книга отсутствует или недоступна. 
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

### **Получить путь к внешней рабочей книге-источнику данных диаграммы**
1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Создать объект для фигуры диаграммы.
1. Создать объект для типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
1. Указать соответствующее условие, основываясь на совпадении типа источника с типом внешней рабочей книги.

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

### **Редактирование данных диаграммы**
Вы можете редактировать данные во внешних рабочих книгах так же, как меняете содержимое внутренних книг. Если внешнюю рабочую книгу не удалось загрузить, выбрасывается исключение.

Этот код на C# реализует описанный процесс:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**  
Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/datasourcetype/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/externalworkbookpath/); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они сохраняются?**  
Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако имейте в виду, что презентация сохраняет абсолютный путь в файле PPTX.

**Могу ли я использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**  
Да, такие рабочие книги могут использоваться в качестве внешнего источника данных. Однако редактирование удалённых рабочих книг непосредственно из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**  
Нет. Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/externalworkbookpath/) и использует её для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**  
Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/net/)) и связывают с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**  
Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла отразится во всех диаграммах при следующей загрузке данных.