---
title: .NET에서 프레젠테이션의 차트 워크북 관리
linktitle: 차트 워크북
type: docs
weight: 70
url: /ko/net/chart-workbook/
keywords:
- 차트 워크북
- 차트 데이터
- 워크북 셀
- 데이터 레이블
- 워크시트
- 데이터 원본
- 외부 워크북
- 외부 데이터
- 차트 캐시
- 워크북 복구
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 발견하세요: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 원본 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 원본으로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 시연합니다.

## **워크북에서 차트 데이터 읽기 및 쓰기**
Aspose.Slides는 [ReadWorkbookStream](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/readworkbookstream/) 및 [WriteWorkbookStream](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터 포함)을 읽고 쓸 수 있게 합니다. **참고** 차트 데이터는 동일한 방식으로 구성되어 있거나 원본과 유사한 구조를 가져야 합니다.

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

## **워크북 셀을 차트 데이터 레이블로 설정**
1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 데이터가 포함된 버블 차트를 추가합니다.  
4. 차트 시리즈에 접근합니다.  
5. 워크북 셀을 데이터 레이블로 설정합니다.  
6. 프레젠테이션을 저장합니다.  

이 C# 코드는 워크북 셀을 차트 데이터 레이블로 설정하는 방법을 보여줍니다:

```c#
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

## **워크시트 관리**
이 C# 코드는 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) 속성을 사용하여 워크시트 컬렉션에 접근하는 작업을 보여줍니다:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **데이터 원본 유형 지정**
이 C# 코드는 데이터 원본의 유형을 지정하는 방법을 보여줍니다:

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

## **지원되지 않는 포함된 워크북 형식 감지**
Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. `[EmbeddedWorkbookType]` 속성을 [IChartData](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/)와 함께 사용하고, [WorkbookType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/workbooktype/) 열거형을 이용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다.

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
            // 포함된 워크북이 .xlsb 형식이며, 지원되지 않습니다.
            continue;
        }

        // 여기서 차트 워크북 데이터를 읽거나 수정합니다.
    }
}
```

## **외부 워크북**
{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/ko/net/aspose-slides-for-net-19-4-release-notes/)에서 차트의 데이터 원본으로 외부 워크북 지원을 구현했습니다.
{{% /alert %}} 

### **외부 워크북 만들기**
**`ReadWorkbookStream`** 및 **`SetExternalWorkbook`** 메서드를 사용하면 새 외부 워크북을 처음부터 만들거나 내부 워크북을 외부 워크북으로 전환할 수 있습니다.

이 C# 코드는 외부 워크북 생성 프로세스를 시연합니다:

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

### **외부 워크북 설정**
**`SetExternalWorkbook`** 메서드를 사용하면 외부 워크북을 차트의 데이터 원본으로 할당할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 이러한 워크북을 외부 데이터 원본으로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로를 제공하면 자동으로 전체 경로로 변환됩니다.

이 C# 코드는 외부 워크북을 설정하는 방법을 보여줍니다:

```c#
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

`SetExternalWorkbook` 메서드 아래의 `ChartData` 매개변수는 Excel 워크북을 로드할지 여부를 지정하는 데 사용됩니다.

- `ChartData` 값을 `false` 로 설정하면 워크북 경로만 업데이트되고—차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않습니다. 대상 워크북이 존재하지 않거나 사용할 수 없는 상황에서 이 설정을 사용할 수 있습니다.  
- `ChartData` 값을 `true` 로 설정하면 차트 데이터가 대상 워크북에서 업데이트됩니다.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **차트의 외부 데이터 원본 워크북 경로 가져오기**
1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 차트 도형에 대한 객체를 생성합니다.  
4. 차트의 데이터 원본을 나타내는 소스(`ChartDataSourceType`) 유형 객체를 생성합니다.  
5. 외부 워크북 데이터 원본 유형과 동일한 소스 유형인지에 따라 관련 조건을 지정합니다.  

이 C# 코드는 해당 작업을 시연합니다:

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
    
    // 프레젠테이션을 저장합니다
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **차트 데이터 편집**
외부 워크북의 데이터를 내부 워크북의 내용 변경 방식과 동일하게 편집할 수 있습니다. 외부 워크북을 로드할 수 없는 경우 예외가 발생합니다.

이 C# 코드는 위에서 설명한 프로세스의 구현 예시입니다:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **차트 캐시에서 워크북 복구**
차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용하고 있는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 복원할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/)를 생성하고, 해당 옵션의 [SpreadsheetOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/spreadsheetoptions/)를 구성한 뒤, [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/)를 `true` 로 설정한 뒤 프레젠테이션을 엽니다.

다음 C# 예제는 사용할 수 없는 외부 워크북을 참조하는 차트를 가진 프레젠테이션을 열고, [IChart.ChartData](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/chartdata/)와 [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/chartdataworkbook/)를 통해 복구된 데이터를 액세스하는 방법을 보여줍니다:

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

외부 워크북을 사용할 수 없고 복구가 비활성화된 경우, Aspose.Slides는 `InvalidOperationException`을 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방안인 경우에만 복구를 활성화하세요. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지 혹은 포함된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트에는 [데이터 원본 유형](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/datasourcetype/)과 [외부 워크북 경로](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/externalworkbookpath/)이 있습니다. 원본이 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있음을 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 이는 프로젝트 이식성을 높여 주지만, PPTX 파일에는 절대 경로가 저장된다는 점을 유념하세요.

**네트워크 리소스/공유에 위치한 워크북을 사용할 수 있나요?**

예, 이러한 워크북을 외부 데이터 원본으로 사용할 수 있습니다. 하지만 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 원본으로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

아니요. 프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/externalworkbookpath/)만 저장하고, 데이터를 읽을 때 이 링크를 사용합니다. 프레젠테이션 저장 시 외부 파일 자체는 수정되지 않습니다.

**외부 파일이 비밀번호로 보호되어 있는 경우 어떻게 해야 하나요?**

Aspose.Slides는 링크 연결 시 비밀번호를 지원하지 않습니다. 일반적인 접근 방식은 미리 보호를 해제하거나, 복호화된 복사본(예: [Aspose.Cells](/cells/net/) 사용)을 만든 뒤 해당 복사본에 링크하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 동일한 파일을 가리키면 해당 파일이 업데이트될 때마다 다음 번 데이터 로드 시 각 차트에 반영됩니다.