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
description: "Aspose.Slides for .NET을 발견하세요: PowerPoint 및 OpenDocument 형식에서 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 효율화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 보여줍니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 [빈 셀 표시 제어](/slides/ko/net/chart-series/)를 참고하여 빈 셀과 0의 차이 및 사용 가능한 표시 모드의 라인 차트 비교를 확인하십시오.

## **숨겨진 행 및 열에서 데이터 포함**

숨겨진 워크시트 행 및 열의 데이터를 차트가 플롯할지 여부를 제어하려면 [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/)을 사용합니다. `true`로 설정하면 표시된 셀만 플롯하고, `false`로 설정하면 표시된 셀과 숨겨진 셀 모두를 포함합니다. 이 설정은 차트 플롯을 제어하며, 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[샘플 프레젠테이션](hidden-source-data.pptx)에는 첫 번째 슬라이드의 첫 번째 도형으로 열 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`에는 `A1:C4` 범위가 있으며, 3행과 C열이 숨겨져 있지만 해당 셀에는 여전히 값이 들어 있습니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨겨진 열) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (숨겨진 행) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)을 통해 소스 셀에 접근하고 [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/)을 읽어 숨김 상태를 확인합니다. 이 속성은 읽기 전용입니다. 이 파일에서 B2는 표시되고, B3는 숨겨진 행에 속하며, C2는 숨겨진 열에 속합니다; 예제는 각각 `False`, `True`, `True`를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: 포함된 워크북을 [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)으로 유지하고 [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)으로 다시 로드합니다. 모든 셀을 포함할 때는 숨겨진 February 범주까지 복원하기 위해 [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/)도 사용합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 범주 레이블을 새로 고치기에 충분하지 않습니다.

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
            // 숨겨진 범주를 포함하여 전체 소스 범위를 복원합니다.
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

예제는 프레젠테이션을 두 버전으로 저장합니다: 표시된 소매 값(10 및 20)만 포함한 버전과 모든 여섯 값을 포함한 버전. 아래 이미지들은 저장된 프레젠테이션을 다시 연 후 렌더링한 것으로, 두 파일 모두 할당된 플롯 설정을 유지합니다. 행 3과 열 C는 두 포함된 워크북 모두에서 여전히 숨겨져 있습니다.

| 표시된 셀만 (`true`) | 모든 셀 (`false`) |
| --- | --- |
| ![표시된 셀만: 1월과 3월에 대한 소매 값 10 및 20.](hidden_cells_True.png) | ![모든 셀: 1월, 2월, 3월에 대한 소매 및 도매 값.](hidden_cells_False.png) |

값이 들어 있는 숨겨진 셀은 빈 셀과 다릅니다. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)은 누락된 값을 표시하는 방식을 제어하지만, 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예제는 [빈 셀 표시 제어](/slides/ko/net/chart-series/#control-the-display-of-empty-cells)를 참고하십시오.

## **차트 데이터 범위 가져오기**

기존 프레젠테이션에서 워크북 데이터를 업데이트하기 전에 차트가 사용하는 소스 범위를 확인하여 각 차트가 어떤 워크시트 셀을 사용하는지 식별합니다. [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) 메서드는 현재 데이터 범위를 워크시트 한정 수식(예: `Sheet1!$A$1:$D$5`)으로 반환합니다. 여기서 `Sheet1`은 워크시트 이름, `!`는 셀 범위와 구분하고, `$A$1:$D$5`는 절대 행·열 참조를 나타냅니다.

이 메서드는 차트나 워크북을 변경하지 않고 현재 범위를 읽어옵니다. 차트가 워크북을 데이터 소스로 사용하지 않으면 [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)을 발생시킵니다. 자세한 내용은 [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)를 참고하십시오.

이 예제는 프레젠테이션을 열고 각 슬라이드의 도형을 직접 검사하여 차트를 찾습니다. 차트 이름과 소스 범위를 출력합니다. 워크북을 사용하지 않는 차트는 메시지를 출력하고 다음 차트로 넘어갑니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **워크북에서 차트 데이터 읽기 및 쓰기**

Aspose.Slides for .NET은 [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) 및 [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터를 포함)을 읽고 쓸 수 있도록 합니다. **참고** 차트 데이터는 동일한 방식으로 구성되어 있거나 원본과 유사한 구조여야 합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트를 포함한 프레젠테이션을 사용합니다. 포함된 워크북을 스트림으로 읽고 기존 시리즈와 범주를 지운 다음 동일한 워크북을 다시 씁니다. 변경 사항은 메모리에 남으며, 예제는 프레젠테이션을 저장하지 않습니다.

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

수정된 워크북으로 포함된 워크북을 교체하면 차트는 원래 시리즈와 범주 컬렉션을 유지합니다. 이 불일치로 인해 [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/)이 인덱스 범위 오류로 실패할 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 범주를 지우십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형인 차트를 사용합니다. 주석은 워크북 편집이 발생할 위치를 표시합니다; 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리 내에서 레이아웃을 검증합니다.

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

    // 여기에서 워크북 스트림을 수정합니다, 예를 들어 Aspose.Cells를 사용합니다.

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

컬렉션을 지우면 워크북을 다시 쓰기 전에 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 대해 필요한 시리즈와 범주 매핑을 다시 구축한 후 차트를 사용하십시오.

## **워크북 셀에 사용자 정의 숫자 형식 지정**

[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/)을 사용하면 차트에 포함된 워크북에서 숫자 값이 표시되는 방식을 제어할 수 있습니다. 예를 들어, 보고서에서 변환율을 소수점 넷째 자리까지 백분율로, 계수를 소수점 다섯째 자리까지 표시해야 할 수 있습니다. 두 값 모두 계산 및 차트 플롯에 사용할 수 있도록 숫자형으로 유지하십시오.

숫자 형식은 표시 방식을 변경할 뿐, 저장된 값 자체는 변경하지 않습니다. 형식 `0.0000%`는 `0.125`를 `12.5000%`로 표시하지만 저장된 숫자를 `12.5`로 바꾸지는 않습니다. 마찬가지로 `0.00000`은 `0.1234567`을 `0.12346`으로 표시하지만 저장된 값은 반올림되지 않습니다. 사용자 정의 형식이 빈 문자열(`""`)인 경우 [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/)이 대신 사용됩니다.

다음 예제는 열 차트를 만들고 [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)을 통해 셀에 접근합니다. 워크시트 0에서 B2는 변환율, C2는 계수를 포함합니다. 두 셀 모두 차트 값으로 사용됩니다. 예제는 또한 소스 형식에 연결된 값 레이블을 활성화합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

워크북 셀 형식은 차트 축이나 데이터 레이블에 직접 설정된 형식과는 별개입니다. 이 예제에서는 각 레이블이 [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)가 활성화되어 소스 셀의 값을 표시하고, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/)가 `true`이므로 소스 숫자 형식을 따릅니다. 프레젠테이션을 저장하고 다시 연 후 레이블은 `12.5000%`와 `0.12346`을 표시합니다. 수직 축은 자체 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`을 사용하고, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/)가 `false`로 설정됩니다.

데이터 레이블을 독립적으로 포맷하려면 해당 레이블의 소스 연결 플래그를 `false`로 설정하고 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/)을 지정하십시오. 이는 워크북 셀의 형식은 변경하지 않습니다. 예를 들어, 독립 레이블 형식 `0.00`은 첫 번째 값을 `0.13`으로 표시하지만 B2는 여전히 `12.5000%`를 표시합니다. 직접 레이블 포맷에 대한 내용은 [Chart Data Labels](/slides/ko/net/chart-data-label/#set-percentage-sign-with-chart-data-labels)를 참고하십시오.

아래 이미지는 프레젠테이션을 저장한 뒤 다시 연 후 렌더링한 것입니다:

![소스 연결 레이블이 12.5000%와 0.12346을 표시하고, 독립적으로 포맷된 수치 축을 가진 열 차트.](custom-cell-formats.png)

## **워크북 셀을 차트 데이터 레이블로 지정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 기본 데이터가 있는 버블 차트를 추가합니다. 워크시트 0의 A10:A12 셀을 첫 번째 시리즈의 처음 세 레이블로 사용하고, 셀에서 레이블을 활성화한 뒤 업데이트된 프레젠테이션을 저장합니다.

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) 속성은 차트 워크북에 포함된 워크시트에 접근할 수 있게 합니다. 이 예제는 기본 데이터가 있는 파이 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

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

시리즈 포인트 값은 숫자 리터럴로 직접 저장될 수도 있습니다. 전체 예제는 [Set Series Values Using Numeric Literals](/slides/ko/net/chart-series/#set-series-values-using-numeric-literals)를 참고하십시오. 포인트 값의 소스 유형은 차트의 내부 또는 외부 워크북 구성과 별개이며, 숫자 리터럴을 사용한다고 해서 포함된 워크북이 자동으로 제거되는 것은 아닙니다.

이 예제는 기본 데이터가 있는 3D 열 차트를 만들고 두 시리즈 이름을 서로 다른 데이터 소스로 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째 이름은 워크시트 0의 C1 셀을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) 열거형은 각 이름의 소스를 선택합니다. 예제는 업데이트된 시리즈 이름을 포함한 프레젠테이션을 저장합니다.

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

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) 속성을 [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/)와 함께 사용하고 [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) 열거형을 활용하면 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에서 도형을 검사하고, 차트가 아닌 도형은 건너뛰며, 포함된 .xlsb 워크북이 있는 각 차트에 대해 진단 메시지를 출력합니다.

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

### **외부 워크북 만들기**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) 및 [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)을 사용하여 포함된 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결할 수 있습니다.

이 예제는 기본 데이터가 있는 파이 차트를 만들고 워크북을 내보냅니다. 출력 스트림을 닫은 후 외부 워크북을 차트 데이터 소스로 할당하고 링크된 프레젠테이션을 저장합니다.

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 메서드를 사용하면 외부 워크북을 차트의 데이터 소스로 할당할 수 있습니다. 이 메서드는 외부 워크북의 경로가 변경된 경우(파일이 이동된 경우) 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수는 있습니다. 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

이 예제는 워크시트 `Sheet1`에 B1에 시리즈 이름, A2:A4에 범주 이름, B2:B4에 숫자 값을 포함한 외부 워크북을 사용합니다. 파이 차트를 만들고 워크북을 연결한 뒤 [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/)을 사용해 A1:B4를 하나의 시리즈와 세 개의 범주에 매핑합니다. 링크된 차트와 함께 프레젠테이션을 저장합니다.

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)의 `updateChartData` 매개변수는 워크북 로드 여부를 제어합니다.

* `updateChartData`가 `false`이면 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으므로 워크북이 없어도 작동합니다.
* `updateChartData`가 `true`이면 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData`를 `false`로 설정하고 자리표시자 URL을 할당합니다. 파이 차트의 기본 데이터를 유지하고 사용할 수 없는 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

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

차트가 연결된 워크북을 확인하려면 차트가 외부 데이터 소스를 사용하는지 확인하고 해당 워크북 경로를 가져옵니다.

이 예제는 외부 워크북에 연결된 차트가 있는 프레젠테이션의 첫 번째 슬라이드에서 첫 번째 도형을 검사합니다. 차트가 외부 워크북에 연결된 경우 [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/)을 콘솔에 출력한 뒤 프레젠테이션 복사본을 저장합니다.

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

이 예제는 첫 번째 슬라이드의 첫 번째 도형인 차트를 사용하며, 접근 가능한 외부 워크북에 연결됩니다. 첫 번째 시리즈의 첫 번째 데이터 포인트 값을 100으로 설정하고 업데이트된 프레젠테이션을 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일도 업데이트되므로 원본 워크북을 보존하려면 복사본을 사용하십시오.

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

## **소스 워크북에서 차트 데이터 새로 고침**

Aspose.Slides for .NET 26.11은 단일 차트에 대한 [IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/)와 프레젠테이션 전체에 대한 [IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/)를 추가했습니다. 소스 워크북 값이 변경된 후에 사용하십시오. 외부 워크북은 접근 가능하고 지원되는 형식이어야 합니다.

[Aspose.Slides for .NET](/slides/ko/net/installation/) 26.11 이상이 설치된 환경에서 이 예제는 `charts.pptx`의 첫 번째 슬라이드에 있는 첫 번째 차트를 새로 고칩니다. 소스 워크북이 사용 가능해야 합니다. 업데이트된 차트 데이터를 유지하려면 결과를 저장하십시오.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
var chart = presentation.Slides[0].Shapes.OfType<IChart>().FirstOrDefault();
if (chart == null)
{
    Console.WriteLine("The first slide must contain a chart.");
    return;
}

chart.ChartData.RefreshData();
presentation.Save("refreshed-chart.pptx", SaveFormat.Pptx);
```

모든 차트를 새로 고치려면 별도의 프레젠테이션 인스턴스를 사용합니다. `false`를 전달하면 새로 고침 실패가 호출자에게 전파되며, 이미 새로 고친 차트는 롤백되지 않습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

매개변수 기본값은 `true`이며, [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/)는 실패한 차트를 건너뛰고 나머지를 계속 진행합니다. 개별 차트 결과를 반환하지 않으므로 완료된 호출이 모든 차트가 새로 고쳐졌음을 보장하지는 않습니다. 각각의 실패 차트를 식별해야 하면 개별 [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) 호출을 사용하십시오.

새로 고침은 소스 데이터를 다시 로드합니다. 이는 수식 계산, 차트 레이아웃 검증, OLE 미리 보기 업데이트와는 별개입니다. 메모리 내에서 새로 고침을 확인하려면 셀 기반 실시간 값을 검사하십시오. [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/)은 프레젠테이션을 저장하고 다시 열 때까지 이전에 저장된 차트를 설명할 수 있습니다.

### **워크북 없이 캐시된 차트 값 읽기**

.NET 26.11에서는 캐시된 값 접근자를 사용해 워크북을 열지 않고도 차트에 저장된 값을 읽을 수 있습니다. 이는 연결된 파일이 없을 때 마지막 저장된 데이터를 필요로 할 때 유용합니다. 아래 복구 옵션과는 다릅니다.

| 객체 | 캐시 접근자 |
| --- | --- |
| 일반 시리즈 데이터 포인트 | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| 산점도 또는 버블 데이터 포인트 | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| 버블 데이터 포인트 | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| 차트 범주 | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

각 접근자는 [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/)를 반환합니다. [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/)는 저장된 객체를 노출하고, [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/)은 텍스트를 제공하며, [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/)는 값이 없거나 숫자가 아니면 `NaN`을 반환합니다. 캐시는 없거나 오래될 수 있으며, 저장되지 않은 새 차트에도 존재하지 않을 수 있습니다. 모든 필드가 존재하거나 숫자를 포함한다고 가정하지 마십시오.

이 예제는 차트를 포함한 저장된 프레젠테이션 `cached-chart.pptx`에서 위 모든 필드를 읽습니다. 외부 워크북이 없더라도 [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)이나 실시간 워크북 셀에 접근하지 않으므로 문제가 없습니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("cached-chart.pptx");
foreach (var slide in presentation.Slides)
foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
        continue;

    foreach (var category in chart.ChartData.Categories)
        PrintCache("Category", category.CachedValue);

    foreach (var series in chart.ChartData.Series)
    foreach (var point in series.DataPoints)
    {
        PrintCache("Value", point.CachedValue);
        PrintCache("X", point.CachedXValue);
        PrintCache("Y", point.CachedYValue);
        PrintCache("Bubble size", point.CachedBubbleSize);
    }
}

static void PrintCache(string name, ICachedChartValue value)
{
    var number = value.ToDouble();
    if (value.Data == null)
        Console.WriteLine($"{name}: no cached value");
    else if (double.IsNaN(number))
        Console.WriteLine($"{name}: {value} (not numeric)");
    else
        Console.WriteLine($"{name}: {number}");
}
```

현재 소스 데이터가 필요하면 새로 고침을 사용하고, 저장된 스냅샷만 충분하면 캐시 읽기를 사용하십시오. 캐시는 워크북의 전체 복사본이 아니며 마지막 업데이트 이후의 변경 사항을 제공하지 않습니다.

### **차트 캐시에서 워크북 복구**

외부 워크북이 없거나 접근할 수 없는 차트의 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터에서 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)를 생성하고, 그 [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/)을 설정한 뒤, [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/)를 `true`로 지정하고 프레젠테이션을 엽니다.

다음 C# 예제는 첫 번째 슬라이드 첫 번째 도형인 차트가 접근할 수 없는 외부 워크북을 참조하고 있을 때 워크북 데이터를 복구합니다. 복구된 데이터는 [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/)와 [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)를 통해 접근합니다.

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

    // 여기서 복구된 워크북 데이터를 읽거나 수정합니다.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

코드가 외부 워크북에 접근하려고 할 때 워크북이 없고 복구가 비활성화된 경우 Aspose.Slides는 [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)을 발생시킵니다. 캐시된 차트 데이터를 사용할 수 있는 경우에만 복구를 활성화하십시오. 캐시는 외부 워크북이 마지막으로 업데이트된 이후의 변경 사항을 포함하지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 포함된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트는 [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/)과 [external workbook path](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)를 가지고 있습니다. 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용 중인지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되나요? 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 PPTX 파일에 절대 경로를 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 공유/리소스에 있는 워크북을 사용할 수 있나요?**

예. 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스로만 사용할 수 있습니다.

**Aspose.Slides가 프레젠테이션 저장 시 외부 XLSX 파일을 덮어쓰나요?**

프레젠테이션은 [external file link](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 워크북을 그대로 유지해야 한다면 복사본을 사용하십시오.

**외부 파일이 비밀번호로 보호되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 링크 시 비밀번호를 받아들이지 않습니다. 일반적인 방법은 미리 보호를 제거하거나 [Aspose.Cells](https://reference.aspose.com/cells/net/) 등으로 복호화된 복사본을 만든 뒤 해당 복사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 동일 파일을 가리키면 해당 파일을 업데이트할 때마다 모든 차트에 반영됩니다.