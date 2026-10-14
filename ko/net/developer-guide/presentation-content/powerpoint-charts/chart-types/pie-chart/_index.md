---
title: ".NET에서 프레젠테이션용 파이 차트 맞춤 설정"
linktitle: "파이 차트"
type: docs
url: /ko/net/pie-chart/
keywords:
- "파이 차트"
- "차트 관리"
- "차트 맞춤 설정"
- "차트 옵션"
- "차트 설정"
- "플롯 옵션"
- "슬라이스 색상"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: " .NET에서 Aspose.Slides를 사용해 파이 차트를 만들고 맞춤 설정합니다. 보조 플롯을 구성하고 데이터 레이블을 표시하며 PowerPoint에서 자동 슬라이스 색상을 적용합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 파이 차트를 사용하는 방법을 설명합니다. 파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 파이 차트에 자동 슬라이스 색상을 적용하는 방법을 보여줍니다.

예제에서는 슬라이드에 차트를 추가하고, 시리즈와 레이블 설정을 조정하며, 기본 차트 데이터를 사용자 정의 카테고리와 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 작업에 중점을 둡니다.

## **파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션**

Aspose.Slides for .NET은 파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션을 지원합니다. 이러한 옵션은 보조 플롯의 크기와 두 플롯 간에 데이터 포인트가 어떻게 분할되는지를 제어합니다.

다음 예제는 새 프레젠테이션에서 파이 오브 파이 차트를 만들고 데이터 포인트 값을 레이블로 표시합니다. [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) 속성은 보조 플롯 크기를 메인 플롯의 149%로 설정합니다. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/)은 백분율 기반 분할을 선택하고, [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/)은 임계값을 53%로 설정합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **보조 플롯을 위한 카테고리 선택**

특정 카테고리를 비율에 상관없이 보조 플롯에 그룹화하려면 사용자 지정 분할을 사용합니다. 예를 들어, 매출 보고서에서 온라인과 이벤트를 함께 표시하면 두 채널을 비교할 수 있으며, 이 두 채널은 전체 매출의 35%와 10%를 차지합니다.

[PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/)를 [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/)으로 설정하고 [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/)를 통해 포인트를 선택합니다. 컬렉션의 [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) 메서드는 시리즈의 0 기반 인덱스 또는 데이터 포인트 개체를 허용합니다. 이 예제에서는 인덱스 1이 온라인을 선택하고 인덱스 3이 이벤트를 선택합니다. 파트너는 일시적으로 추가된 후 [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/)로 제외됩니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// 기본 데이터를 채널별 매출 데이터로 교체합니다.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Online을 0 기반 인덱스로, Events를 데이터 포인트 객체로 선택합니다.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Partners를 선택에서 제외하지만 소스 데이터를 삭제하지는 않습니다.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

온라인(35)과 이벤트(10)는 보조 플롯에서 개별 슬라이스로 표시됩니다. 기본 플롯에서는 이 두 항목이 결합된 슬라이스 45와 함께 소매(40) 및 파트너(15)가 표시됩니다. 파트너를 사용자 지정 선택에서 제거하면 기본 플롯에 남아 있지만 차트 소스 데이터에서 카테고리나 값이 제거되지는 않습니다.

다음 이미지는 PowerPoint에서 저장된 프레젠테이션을 보여줍니다:

![보조 플롯에 온라인 및 이벤트가 포함된 파이 오브 파이 차트와 기본 플롯에서 결합된 값 45](pie_of_pie_custom.png)

## **자동 파이 차트 슬라이스 색상 설정**

Aspose.Slides for .NET은 파이 차트 슬라이스에 자동으로 서로 다른 색상을 할당할 수 있습니다. 다음 예제는 중앙에 제목이 있는 파이 차트를 만들고 기본 데이터를 세 개의 분기 카테고리와 해당 값으로 교체합니다. [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) 속성은 값 20, 50, 30을 레이블로 표시하고, [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/)는 각 슬라이스에 고유한 색상을 적용합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Add a centered chart title.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Replace the default data using the first worksheet.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Show values and assign different colors to the slices.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**파이 오브 파이 및 바 오브 파이 변형이 지원되나요?**

예, 라이브러리는 파이 차트에 대한 보조 플롯을 [지원합니다](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), 여기에는 파이 오브 파이와 바 오브 파이 유형이 포함됩니다.

**차트를 이미지(예: PNG)로만 내보낼 수 있나요?**

예, 전체 프레젠테이션을 내보내지 않고 차트를 이미지(예: PNG)로 [내보낼 수 있습니다](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/).