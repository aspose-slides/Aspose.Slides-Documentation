---
title: ".NET에서 프레젠테이션의 차트 워크북 관리"
linktitle: "차트 워크북"
type: docs
weight: 70
url: /ko/net/chart-workbook/
keywords:
- 차트 워크북
- 차트 데이터
- 워크북 셀
- 데이터 레이블
- 워크시트
- 데이터 소스
- 외부 워크북
- 외부 데이터
- 차트 캐시
- 워크북 복구
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 발견하세요: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 간소화합니다."
---
## **Overview**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 시연합니다.

## **Read and Write Chart Data from a Workbook**
Aspose.Slides는 [ReadWorkbookStream](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/readworkbookstream/) 및 [WriteWorkbookStream](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터를 포함함)을 읽고 쓸 수 있습니다. **Note** 차트 데이터는 원본과 동일한 방식으로 구성되어 있거나 구조가 유사해야 합니다.

다음 C# 코드가 샘플 작업을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

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

### **Validate Chart Layout After Workbook Modification**

수정된 워크북으로 내장 워크북을 교체하면 차트는 원래의 시리즈 및 카테고리 컬렉션을 유지합니다. 이 불일치는 [IChart.ValidateChartLayout](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/validatechartlayout/)이 인덱스 범위 초과 오류로 실패하게 만들 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 삭제하십시오.

```csharp
// 워크북 스트림을 수정한 후 (예: Aspose.Cells 사용)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// 기존 데이터 참조를 지웁니다.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

컬렉션을 삭제하면 차트 데이터 구조가 새 워크북과 일치하게 되어 `ValidateChartLayout`이 오류 없이 완료됩니다.

## **Set a WorkBook Cell as a Chart Data Label**
1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
1. 일부 데이터를 포함한 버블 차트를 추가합니다.  
1. 차트 시리즈에 접근합니다.  
1. 워크북 셀을 데이터 레이블로 설정합니다.  
1. 프레젠테이션을 저장합니다.

다음 C# 코드가 워크북 셀을 차트 데이터 레이블로 설정하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다 

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

## **Manage Worksheets**

다음 C# 코드는 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) 속성을 사용해 워크시트 컬렉션에 접근하는 작업을 시연합니다:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Specify the Data Source Type**

다음 C# 코드는 데이터 소스 유형을 지정하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides는 일부 차트에 삽입될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [IChartData](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/)의 `EmbeddedWorkbookType` 속성과 [WorkbookType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

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
            // 내장 워크북이 .xlsb 형식이며, 지원되지 않습니다.
            continue;
        }

        // 여기서 차트 워크북 데이터를 읽거나 수정합니다.
    }
}
```

## **External Workbook**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/ko/net/aspose-slides-for-net-19-4-release-notes/)에서 차트의 데이터 소스로 외부 워크북을 지원하도록 구현했습니다. 
{{% /alert %}} 

### **Create an External Workbook**
**`ReadWorkbookStream`** 및 **`SetExternalWorkbook`** 메서드를 사용하면 새 외부 워크북을 처음부터 만들거나 내부 워크북을 외부 워크북으로 전환할 수 있습니다.

다음 C# 코드가 외부 워크북 생성 과정을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

### **Set an External Workbook**
**`SetExternalWorkbook`** 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북의 경로가 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

다음 C# 코드가 외부 워크북을 설정하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// 문서 디렉터리 경로.
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

`SetExternalWorkbook` 메서드의 `ChartData` 매개변수는 Excel 워크북을 로드할지 여부를 지정하는 데 사용됩니다.

* `ChartData` 값을 `false` 로 설정하면 워크북 경로만 업데이트되고 차트 데이터는 로드되거나 업데이트되지 않습니다. 대상 워크북이 존재하지 않거나 사용할 수 없는 경우에 이 설정을 사용할 수 있습니다.  
* `ChartData` 값을 `true` 로 설정하면 차트 데이터가 대상 워크북에서 업데이트됩니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Get the External Data Source Workbook Path of a Chart**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
1. 차트 모양에 대한 객체를 생성합니다.  
1. 차트 데이터 소스를 나타내는 `ChartDataSourceType` 객체를 생성합니다.  
1. 외부 워크북 데이터 소스 유형과 동일한 소스 유형에 따라 관련 조건을 지정합니다.

다음 C# 코드가 해당 작업을 시연합니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // 프레젠테이션을 저장합니다
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Edit Chart Data**

외부 워크북의 데이터는 내부 워크북의 내용을 수정하듯이 편집할 수 있습니다. 외부 워크북을 로드할 수 없으면 예외가 발생합니다.

다음 C# 코드는 설명된 프로세스의 구현 예시입니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Recover a Workbook from the Chart Cache**

차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용하는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 복구할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/)를 생성하고, 해당 [SpreadsheetOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/spreadsheetoptions/)를 구성한 뒤, [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/)를 `true` 로 설정한 뒤 프레젠테이션을 엽니다.

다음 C# 예제는 사용 불가능한 외부 워크북을 참조하는 차트가 포함된 프레젠테이션을 열고, [IChart.ChartData](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/chartdata/)와 [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/chartdataworkbook/)를 통해 복구된 데이터에 접근하는 방법을 보여줍니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

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

외부 워크북을 사용할 수 없고 복구가 비활성화된 경우, Aspose.Slides는 `InvalidOperationException`을 발생시킵니다. 캐시된 차트 데이터를 사용해도 되는 경우에만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 내장 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [데이터 소스 유형](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/datasourcetype/)과 [외부 워크북 경로](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/externalworkbookpath/)가 있습니다. 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용 중인지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이식성을 높이지만, 프레젠테이션 파일(PPTX)에는 절대 경로가 저장된다는 점을 유념하십시오.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

예, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 다만 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스 역할만 수행합니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

아니요. 프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/externalworkbookpath/)만 저장하고, 저장 시 외부 파일 자체는 수정되지 않습니다.

**외부 파일이 비밀번호로 보호된 경우 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호 입력을 지원하지 않습니다. 일반적인 방법은 미리 보호를 해제하거나, [Aspose.Cells](/cells/net/) 등을 사용해 복호화된 사본을 만든 후 해당 사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모든 차트가 동일한 파일을 가리키면 해당 파일을 업데이트했을 때 다음 데이터 로드 시 각 차트에 반영됩니다.