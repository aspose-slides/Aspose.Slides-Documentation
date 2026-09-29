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
description: "Aspose.Slides for .NET를 발견하세요: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 통합 문서(workbook)를 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 차트 데이터 소스로 외부 워크북을 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북을 사용할 수 있을 때 차트 데이터를 편집하는 방법을 시연합니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 [Control the Display of Empty Cells](/slides/ko/net/chart-series/)에서 빈 셀과 0의 차이점 및 사용 가능한 표시 모드의 라인 차트 비교를 참조하십시오.

## **숨겨진 행 및 열의 데이터 포함**

[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/plotvisiblecellsonly/)을 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `true`로 설정하면 보이는 셀만 플롯하고, `false`로 설정하면 보이는 셀과 숨겨진 셀 모두를 포함합니다. 이 설정은 차트 플롯에만 영향을 주며, 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[hidden-source-data.pptx](hidden-source-data.pptx)를 다운로드하여 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 첫 번째 도형으로 컬럼 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`에는 `A1:C4` 영역이 소스 범위로 지정되어 있습니다. 3행과 C열은 숨겨져 있지만 해당 셀들은 여전히 값을 가지고 있습니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨겨진 열) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (숨겨진 행) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/chartdataworkbook/)을 통해 소스 셀에 접근하고 [IChartDataCell.IsHidden](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatacell/ishidden/)을 읽어 숨김 상태를 확인합니다. 이 속성은 읽기 전용입니다. 이 파일에서는 B2가 보이며, B3은 숨겨진 행에 속하고, C2는 숨겨진 열에 속합니다; 예제는 각각 `False`, `True`, `True`를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: 포함된 워크북을 [ReadWorkbookStream](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/readworkbookstream/)으로 유지하고 [WriteWorkbookStream](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/writeworkbookstream/)으로 다시 로드합니다. 모든 셀을 포함할 경우 [SetRange](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/setrange/)을 사용하여 숨겨진 February 범주를 포함한 전체 범위를 복원합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 카테고리 레이블을 새로 고치기에 충분하지 않습니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // 포함된 워크북에서 차트 데이터를 새로 고칩니다.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 숨겨진 카테고리를 포함한 전체 소스 범위를 복원합니다.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

예제는 보이는 소매 값(10 및 20)만 포함한 `hidden_cells_True.pptx`와 모든 여섯 값을 포함한 `hidden_cells_False.pptx`를 저장합니다. 아래 이미지는 저장된 프레젠테이션을 다시 연 후 렌더링한 결과이며, 두 파일 모두 할당된 플롯 설정을 유지합니다. 3행과 C열은 두 포함된 워크북 모두에서 숨겨진 상태로 남습니다.

| 보이는 셀만 (`true`) | 모든 셀 (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

값을 포함한 숨겨진 셀은 빈 셀과 다릅니다. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/displayblanksas/)는 누락된 값이 표시되는 방식을 제어하지만 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예제는 [Control the Display of Empty Cells](/slides/ko/net/chart-series/#control-the-display-of-empty-cells)에서 확인하십시오.

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for .NET은 차트 데이터를 포함한 워크북( Aspose.Cells로 편집된 차트 데이터 포함)을 읽고 쓸 수 있는 [ReadWorkbookStream](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/readworkbookstream/) 및 [WriteWorkbookStream](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 메서드를 제공합니다. **참고** 차트 데이터는 동일한 방식으로 구성되어 있거나 원본과 유사한 구조여야 합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `chart.pptx`를 엽니다. 포함된 워크북을 스트림으로 읽고, 기존 시리즈와 카테고리를 지우며, 동일한 워크북을 다시 씁니다. 변경 사항은 메모리에 남아 있으며, 예제는 프레젠테이션을 저장하지 않습니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **워크북 수정 후 차트 레이아웃 검증**

포함된 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈 및 카테고리 컬렉션을 유지합니다. 이 불일치는 [IChart.ValidateChartLayout](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/validatechartlayout/)이 인덱스 범위 초과 오류로 실패하게 만들 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 먼저 삭제하십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 있는 `chart.pptx`가 필요합니다. 주석은 워크북 편집이 발생할 위치를 표시합니다; 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리에서 레이아웃을 검증합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // 워크북 스트림을 여기서 수정합니다. 예를 들어 Aspose.Cells를 사용합니다.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

컬렉션을 비우면 워크북이 다시 쓰이기 전에 오래된 데이터 참조가 제거됩니다. 워크북을 업데이트하기 전에 필요한 시리즈와 카테고리 매핑을 재구성하십시오.

## **워크북 셀을 차트 데이터 레이블로 설정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다. 다음 단계에서는 버블 차트의 레이블을 해당 데이터 워크북의 셀에 연결하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 0부터 시작하는 인덱스로 첫 번째 슬라이드에 접근합니다.  
3. 기본 데이터가 포함된 버블 차트를 추가합니다.  
4. 차트 시리즈에 접근합니다.  
5. 워크북 셀을 데이터 레이블로 설정합니다.  
6. 프레젠테이션을 저장합니다.

이 예제는 최소 한 개의 슬라이드가 있는 `chart2.pptx`를 열고 기본 데이터가 포함된 버블 차트를 추가합니다. 워크시트 0의 셀 A10:A12를 첫 번째 시리즈의 처음 세 레이블에 사용하고, 셀에서 레이블을 사용하도록 활성화한 뒤 결과를 `resultchart.pptx`에 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **워크시트 관리**

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdataworkbook/worksheets/) 속성을 사용하면 차트 워크북에 포함된 워크시트에 접근할 수 있습니다. 이 예제는 기본 데이터가 포함된 원형 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **데이터 소스 유형 지정**

이 예제는 기본 데이터가 포함된 3D 컬럼 차트를 만들고 두 개의 시리즈 이름을 서로 다른 데이터 소스로 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째 이름은 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/datasourcetype/) 열거형을 사용하여 각 이름의 소스를 선택합니다. 결과는 `pres.pptx`에 저장됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **지원되지 않는 포함 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 바이너리 워크북(.xlsb) 형식을 지원하지 않습니다. [IChartData](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/)의 [EmbeddedWorkbookType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) 속성과 [WorkbookType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/workbooktype/) 열거형을 함께 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 `sample.pptx`의 첫 번째 슬라이드에 있는 도형을 검사하고, 차트가 아닌 도형은 건너뛰며, 포함된 .xlsb 워크북이 있는 각 차트에 대해 진단 메시지를 출력합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // 지원되는 차트 워크북 데이터를 여기서 읽거나 수정합니다.
}
```

## **외부 워크북**

Aspose.Slides는 차트의 데이터 소스로 외부 워크북을 사용하는 것을 지원합니다.

### **외부 워크북 생성**

[ReadWorkbookStream](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/readworkbookstream/) 및 [SetExternalWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/setexternalworkbook/)을 사용하여 포함된 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터가 포함된 원형 차트를 만들고 워크북을 `externalWorkbook1.xlsx`에 쓰고, 출력 스트림을 닫은 뒤 파일을 차트 데이터 소스로 할당합니다. 연결된 프레젠테이션은 `externalWorkbook.pptx`에 저장됩니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **외부 워크북 설정**

[SetExternalWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북의 경로가 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수는 있습니다. 외부 워크북에 대한 상대 경로를 제공하면 자동으로 절대 경로로 변환됩니다.

이 예제는 작업 디렉터리에 `externalWorkbook.xlsx`가 있어야 합니다. 해당 워크시트 `Sheet1`에는 B1에 시리즈 이름, A2:A4에 카테고리 이름, B2:B4에 숫자 값이 들어 있어야 합니다. 예제는 원형 차트를 만들고, 워크북을 연결한 뒤 [SetRange](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/setrange/)을 사용하여 A1:B4를 하나의 시리즈와 세 개의 카테고리로 매핑합니다. 결과는 `Presentation_with_externalWorkbook.pptx`에 저장됩니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

[SetExternalWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/setexternalworkbook/)의 `updateChartData` 매개변수는 워크북이 로드되는지를 제어합니다.

* `updateChartData`가 `false`이면 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되지 않으며, 워크북이 없어도 작동합니다.  
* `updateChartData`가 `true`이면 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData`를 `false`로 설정한 채 자리표시자 URL을 할당합니다. 기본 데이터가 유지된 원형 차트를 그대로 두고, 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **차트의 외부 데이터 소스 워크북 경로 가져오기**

차트에 연결된 워크북을 확인하려면 먼저 차트가 외부 데이터 소스를 사용하는지 확인합니다. 사용한다면 아래 단계에 따라 워크북 경로를 가져올 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 0부터 시작하는 인덱스로 첫 번째 슬라이드에 접근합니다.  
3. 첫 번째 도형이 차트인지 확인합니다.  
4. 차트 데이터 소스 유형을 읽습니다.  
5. 소스가 외부 워크북인 경우 경로를 읽어옵니다.

이 예제는 앞서 만든 `externalWorkbook.pptx`를 열고 첫 번째 슬라이드의 첫 번째 도형을 검사합니다. 해당 도형이 외부 워크북에 연결된 차트라면 [ExternalWorkbookPath](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/externalworkbookpath/)을 콘솔에 출력하고, 프레젠테이션 복사본을 `Result.pptx`에 저장합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **차트 데이터 편집**

외부 워크북의 데이터를 내부 워크북과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없는 경우 예외가 발생합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `presentation.pptx`와 접근 가능한 외부 워크북이 필요합니다. 첫 번째 시리즈의 첫 번째 데이터 포인트에 해당하는 셀 기반 값을 100으로 설정하고, 결과를 `presentation_out.pptx`에 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트되므로 원본 워크북을 보존하려면 복사본을 사용하십시오.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **차트 캐시에서 워크북 복구**

차트가 누락되었거나 사용할 수 없는 외부 워크북을 사용하고 있는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/)을 생성하고, 해당 [SpreadsheetOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/spreadsheetoptions/)를 구성한 뒤, [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/)를 `true`로 설정한 후 프레젠테이션을 엽니다.

다음 C# 예제는 첫 번째 슬라이드의 첫 번째 도형이 사용할 수 없는 외부 워크북을 참조하는 `presentation.pptx`를 열고, 복구된 데이터를 [IChart.ChartData](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/chartdata/)와 [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdata/chartdataworkbook/)를 통해 접근합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // 여기에서 복구된 워크북 데이터를 읽거나 수정합니다.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

외부 워크북이 사용할 수 없고 복구가 비활성화된 경우 Aspose.Slides는 [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)을 발생시킵니다. 캐시된 차트 데이터를 사용하는 것이 허용 가능한 대체 방법일 때만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 적용된 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 아니면 포함된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트는 [data source type](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/datasourcetype/)과 [external workbook 경로](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/externalworkbookpath/)를 가지고 있습니다; 소스가 외부 워크북이면 전체 경로를 읽어 외부 파일이 사용 중인지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 있는 워크북을 사용할 수 있나요?**

예, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서는 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스 용도로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

프레젠테이션은 [external file에 대한 링크](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/externalworkbookpath/)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 워크북을 변경하지 않으려면 복사본을 사용하십시오.

**외부 파일이 비밀번호로 보호된 경우 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받아들이지 않습니다. 일반적인 방법은 미리 보호를 해제하거나 [Aspose.Cells](https://reference.aspose.com/cells/net/)와 같이 복호화된 복사본을 만든 뒤 해당 복사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키면 해당 파일을 업데이트했을 때 다음 데이터 로드 시 각 차트에 반영됩니다.