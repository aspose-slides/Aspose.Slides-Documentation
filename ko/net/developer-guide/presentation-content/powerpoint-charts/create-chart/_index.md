---
title: .NET에서 PowerPoint 프레젠테이션 차트 만들기 또는 업데이트
linktitle: 차트 만들기 또는 업데이트
type: docs
weight: 10
url: /ko/net/create-chart/
keywords:
- 차트 추가
- 차트 만들기
- 차트 편집
- 차트 변경
- 차트 업데이트
- 산점도 차트
- 원형 차트
- 꺾은선 차트
- 트리맵 차트
- 주식 차트
- 상자 수염 차트
- 퍼널 차트
- 선버스트 차트
- 히스토그램 차트
- 레이더 차트
- 다중 범주 차트
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 차트를 만들고 사용자 지정합니다. C# 실용 코드 예제로 차트를 추가, 서식 지정 및 편집합니다."
---
## **개요**

이 문서는 Aspose.Slides for .NET을 사용하여 차트를 만들고 사용자 지정하는 방법에 대한 포괄적인 가이드를 제공합니다. 프로그래밍 방식으로 슬라이드에 차트를 추가하고, 데이터를 채우며, 특정 디자인 요구 사항에 맞게 다양한 서식 옵션을 적용하는 방법을 배우게 됩니다. 문서 전체에 걸쳐 자세한 코드 예제가 초기화된 프레젠테이션 및 차트 객체부터 시리즈, 축, 범례 구성까지 각 단계를 설명합니다. 이 가이드를 따라하면 .NET 응용 프로그램에 동적 차트 생성을 통합하는 방법을 확실히 이해하게 되어 데이터 기반 프레젠테이션을 만드는 작업을 간소화할 수 있습니다.

## **차트 만들기**

차트는 데이터를 빠르게 시각화하고 표나 스프레드시트에서 즉시 눈에 띄지 않을 수 있는 통찰을 얻는 데 도움을 줍니다.

**왜 차트를 만들까요?**

차트를 사용하면 다음을 할 수 있습니다:

* 프레젠테이션의 단일 슬라이드에 대량의 데이터를 집계, 압축 또는 요약합니다.
* 데이터에서 패턴과 추세를 드러냅니다.
* 시간 경과에 따른 또는 특정 측정 단위에 대한 데이터의 방향과 모멘텀을 추론합니다.
* 이상값, 편차, 오류 및 비논리적 데이터를 식별합니다.
* 복잡한 데이터를 전달하거나 제시합니다.

PowerPoint에서는 *삽입* 기능을 통해 차트를 만들 수 있으며, 이 기능은 다양한 차트 유형을 설계할 수 있는 템플릿을 제공합니다. Aspose.Slides를 사용하면 일반 차트(인기 차트 유형 기반)와 사용자 지정 차트를 모두 만들 수 있습니다.

{{% alert color="info" %}} 

다음 네임스페이스인 [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) 아래에 있는 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 열거형을 사용하십시오. 이 열거형의 값은 서로 다른 차트 유형에 해당합니다.

{{% /alert %}} 

### **클러스터형 열 차트 만들기**

이 섹션에서는 Aspose.Slides for .NET을 사용하여 클러스터형 열 차트를 만드는 방법을 설명합니다. 프레젠테이션을 초기화하고 차트를 추가하며 제목, 데이터, 시리즈, 범주 및 스타일과 같은 요소를 사용자 지정하는 방법을 배우게 됩니다. 아래 단계에 따라 표준 클러스터형 열 차트가 생성되는 과정을 확인하십시오:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 데이터를 포함한 차트를 추가하고 `ChartType.ClusteredColumn` 유형을 지정합니다.
1. 차트에 제목을 추가합니다.
1. 차트의 데이터 워크시트에 액세스합니다.
1. 기본 시리즈와 범주를 모두 제거합니다.
1. 새 시리즈와 범주를 추가합니다.
1. 차트 시리즈에 대한 새 차트 데이터를 추가합니다.
1. 차트 시리즈에 채우기 색을 적용합니다.
1. 차트 시리즈에 레이블을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드에 액세스합니다.
    ISlide slide = presentation.Slides[0];

    // 기본 데이터가 포함된 클러스터형 열 차트를 추가합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // 차트 제목을 설정합니다.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // 차트 데이터 시트의 인덱스를 설정합니다.
    int worksheetIndex = 0;

    // 차트 데이터 워크북을 가져옵니다.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 기본 생성된 시리즈와 범주를 삭제합니다.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 새 시리즈를 추가합니다.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // 새 범주를 추가합니다.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // 첫 번째 차트 시리즈를 가져옵니다.
    IChartSeries series = chart.ChartData.Series[0];

    // 시리즈 데이터를 채웁니다.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // 시리즈의 채우기 색을 설정합니다.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // 두 번째 차트 시리즈를 가져옵니다.
    series = chart.ChartData.Series[1];

    // 시리즈 데이터를 채웁니다.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // 시리즈의 채우기 색을 설정합니다.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // 첫 번째 레이블에 범주 이름을 표시하도록 설정합니다.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // 세 번째 레이블에 값을 표시하도록 시리즈를 설정합니다.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

결과:

![클러스터형 열 차트](clustered_column_chart.png)

### **산점도 차트 만들기**

산점도 차트(산점도 또는 x‑y 그래프라고도 함)는 두 변수 간의 패턴을 확인하거나 상관관계를 보여줄 때 자주 사용됩니다.

다음 경우에 산점도 차트를 사용하십시오:

* 쌍으로 된 숫자 데이터가 있는 경우.
* 서로 잘 짝을 이루는 두 변수가 있는 경우.
* 두 변수가 관련이 있는지 확인하고 싶은 경우.
* 종속 변수에 대해 여러 값이 있는 독립 변수가 있는 경우.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드에 액세스합니다.
    ISlide slide = presentation.Slides[0];

    // 기본 산점도 차트를 생성합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // 차트 데이터 시트의 인덱스를 설정합니다.
    int worksheetIndex = 0;

    // 차트 데이터 워크북을 가져옵니다.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 기본 시리즈를 삭제합니다.
    chart.ChartData.Series.Clear();

    // 새 시리즈를 추가합니다.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // 첫 번째 차트 시리즈를 가져옵니다.
    IChartSeries series = chart.ChartData.Series[0];

    // 시리즈에 새 포인트 (1:3)를 추가합니다.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // 새 포인트 (2:10)를 추가합니다.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // 시리즈 유형을 변경합니다.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // 차트 시리즈 마커를 변경합니다.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // 두 번째 차트 시리즈를 가져옵니다.
    series = chart.ChartData.Series[1];

    // 차트 시리즈에 새 포인트 (5:2)를 추가합니다.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // 새 포인트 (3:1)를 추가합니다.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // 새 포인트 (2:2)를 추가합니다.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // 새 포인트 (5:1)를 추가합니다.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // 차트 시리즈 마커를 변경합니다.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

결과:

![산점도 차트](scatter_chart.png)

### **원형 차트 만들기**

원형 차트는 특히 데이터에 수치값이 있는 범주형 라벨이 포함된 경우 전체 대비 부분 관계를 표시하는 데 가장 적합합니다. 그러나 데이터에 많은 부분이나 라벨이 포함된 경우 막대 차트를 고려하는 것이 좋습니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터를 사용하여 차트를 추가하고 `ChartType.Pie` 유형을 지정합니다.
1. 차트의 데이터 워크북([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))에 액세스합니다.
1. 기본 시리즈와 범주를 제거합니다.
1. 새 시리즈와 범주를 추가합니다.
1. 차트 시리즈에 대한 새 차트 데이터를 추가합니다.
1. 차트에 새 포인트를 추가하고 원형 차트 섹터에 사용자 지정 색을 적용합니다.
1. 시리즈에 레이블을 설정합니다.
1. 시리즈 레이블에 리더 라인을 활성화합니다.
1. 원형 차트의 회전 각도를 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드에 액세스합니다.
    ISlide slide = presentation.Slides[0];

    // 기본 데이터가 포함된 차트를 추가합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // 차트 제목을 설정합니다.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // 첫 번째 시리즈에 값을 표시하도록 설정합니다.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // 차트 데이터 시트의 인덱스를 설정합니다.
    int worksheetIndex = 0;

    // 차트 데이터 워크북을 가져옵니다.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 기본 생성된 시리즈와 범주를 삭제합니다.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 새 범주를 추가합니다.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // 새 시리즈를 추가합니다.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // 시리즈 데이터를 채웁니다.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // 섹터 색상을 설정합니다.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // 섹터 테두리를 설정합니다.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // 섹터 테두리를 설정합니다.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // 섹터 테두리를 설정합니다.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // 새 시리즈의 각 범주에 대한 사용자 지정 레이블을 생성합니다.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // 시리즈에 차트용 리더 라인을 표시하도록 설정합니다.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // 파이 차트 섹터의 회전 각도를 설정합니다.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

결과:

![원형 차트](pie_chart.png)

### **꺾은선 차트 만들기**

꺾은선 차트(라인 그래프라고도 함)는 시간에 따른 값 변화를 보여줄 때 가장 적합합니다. 꺾은선 차트를 사용하면 한 번에 많은 데이터를 비교하고, 시간에 따른 변화와 추세를 추적하며, 데이터 시리즈의 이상 현상을 강조할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터를 사용하여 차트를 추가하고 `ChartType.Line` 유형을 지정합니다.
1. 차트의 데이터 워크북([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))에 액세스합니다.
1. 기본 시리즈와 범주를 제거합니다.
1. 새 시리즈와 범주를 추가합니다.
1. 차트 시리즈에 대한 새 차트 데이터를 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

기본적으로 꺾은선 차트의 포인트는 직선으로 연결됩니다. 포인트를 대시선으로 연결하려면 다음과 같이 원하는 대시 유형을 지정할 수 있습니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

결과:

![꺾은선 차트](line_chart.png)

### **트리맵 차트 만들기**

트리맵 차트는 각 범주 내에서 큰 기여자를 빠르게 강조하면서 데이터 카테고리의 상대적인 크기를 표시할 때 가장 적합합니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터를 사용하여 차트를 추가하고 `ChartType.Treemap` 유형을 지정합니다.
1. 차트의 데이터 워크북([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))에 액세스합니다.
1. 기본 시리즈와 범주를 제거합니다.
1. 새 시리즈와 범주를 추가합니다.
1. 차트 시리즈에 대한 새 차트 데이터를 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // 브랜치 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // 브랜치 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

결과:

![트리맵 차트](treemap_chart.png)

### **주식 차트 만들기**

주식 차트는 시가, 고가, 저가 및 종가와 같은 금융 데이터를 표시하여 시장 추세와 변동성을 분석하는 데 사용됩니다. 이러한 차트는 주식 성과에 대한 핵심 통찰을 제공하여 투자자와 분석가가 정보에 입각한 결정을 내리는 데 도움을 줍니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터를 사용하여 차트를 추가하고 `ChartType.OpenHighLowClose` 유형을 지정합니다.
1. 차트의 데이터 워크북([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))에 액세스합니다.
1. 기본 시리즈와 범주를 제거합니다.
1. 새 시리즈와 범주를 추가합니다.
1. 차트 시리즈에 대한 새 차트 데이터를 추가합니다.
1. HiLowLines 형식을 지정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

결과:

![주식 차트](stock_chart.png)

### **상자 수염 차트 만들기**

상자 수염 차트는 중앙값, 사분위수 및 잠재적 이상값과 같은 핵심 통계 측정값을 요약하여 데이터 분포를 표시합니다. 탐색적 데이터 분석 및 통계 연구에서 데이터 변동성을 빠르게 파악하고 이상을 식별하는 데 특히 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터를 사용하여 차트를 추가하고 `ChartType.BoxAndWhisker` 유형을 지정합니다.
1. 차트의 데이터 워크북([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))에 액세스합니다.
1. 기본 시리즈와 범주를 제거합니다.
1. 새 시리즈와 범주를 추가합니다.
1. 차트 시리즈에 대한 새 차트 데이터를 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **퍼널 차트 만들기**

퍼널 차트는 단계가 순차적으로 진행되면서 데이터 양이 감소하는 프로세스를 시각화하는 데 사용됩니다. 전환율 분석, 병목 현상 식별 및 영업 또는 마케팅 프로세스 효율성 추적에 특히 도움이 됩니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터를 사용하여 차트를 추가하고 `ChartType.Funnel` 유형을 지정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

결과:

![퍼널 차트](funnel_chart.png)

### **선버스트 차트 만들기**

선버스트 차트는 계층형 데이터를 시각화하며, 레벨을 동심원 형태의 링으로 표시합니다. 부분 대 전체 관계를 설명하는 데 유용하며, 중첩된 카테고리와 하위 카테고리를 명확하고 컴팩트하게 나타낼 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터를 사용하여 차트를 추가하고 `ChartType.Sunburst` 유형을 지정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // 브랜치 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // 브랜치 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

결과:

![선버스트 차트](sunburst_chart.png)

### **히스토그램 차트 만들기**

히스토그램 차트는 값을 구간이나 빈으로 그룹화하여 수치 데이터의 분포를 나타내는 데 사용됩니다. 빈도, 왜도, 분산과 같은 데이터 패턴을 식별하고 데이터 집합에서 이상값을 감지하는 데 특히 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 일부 데이터를 사용하여 차트를 추가하고 `ChartType.Histogram` 유형을 지정합니다.
1. 차트 데이터 워크북([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))에 액세스합니다.
1. 기본 시리즈와 범주를 제거합니다.
1. 새 시리즈와 범주를 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

결과:

![히스토그램 차트](histogram_chart.png)

### **레이더 차트 만들기**

레이더 차트는 다변량 데이터를 2차원 형식으로 표시하여 여러 변수를 동시에 비교할 수 있게 합니다. 여러 성능 지표나 속성 전반에 걸친 패턴, 강점 및 약점을 식별하는 데 특히 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 일부 데이터를 사용하여 차트를 추가하고 `ChartType.Radar` 유형을 지정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

결과:

![레이더 차트](radar_chart.png)

### **다중 범주 차트 만들기**

다중 범주 차트는 하나 이상의 범주 그룹이 포함된 데이터를 표시하여 여러 차원을 동시에 비교할 수 있도록 합니다. 복잡하고 다층적인 데이터 세트 내에서 추세와 관계를 분석해야 할 때 특히 도움이 됩니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터를 사용하여 차트를 추가하고 `ChartType.ClusteredColumn` 유형을 지정합니다.
1. 차트 데이터 워크북([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))에 액세스합니다.
1. 기본 시리즈와 범주를 제거합니다.
1. 새 시리즈와 범주를 추가합니다.
1. 차트 시리즈에 대한 새 차트 데이터를 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // 시리즈를 추가합니다.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // 차트와 함께 프레젠테이션을 저장합니다.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

결과:

![다중 범주 차트](multi_category_chart.png)

### **맵 차트 만들기**

맵 차트는 국가, 주, 도시와 같은 특정 위치에 정보를 매핑하여 지리 데이터를 시각화하는 데 사용됩니다. 지역별 추세, 인구 통계 데이터 및 공간 분포를 명확하고 시각적으로 매력적인 방식으로 분석하는 데 특히 유용합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

결과:

![맵 차트](map_chart.png)

{{% alert color="info" %}} 

위 그림은 PowerPoint에서 연 저장된 프레젠테이션을 연 모습입니다. Aspose.Slides는 맵 차트와 해당 데이터를 올바르게 기록하지만, 자체적으로 맵 차트를 그리지는 않습니다. 슬라이드에 맵 차트가 포함된 경우 이미지를 렌더링하거나 PDF 또는 SVG로 변환하면 차트 영역이 비어 있습니다. 동일 슬라이드의 다른 도형은 영향을 받지 않습니다.

{{% /alert %}} 

### **복합 차트 만들기**

복합 차트(또는 콤보 차트)는 하나의 그래프에 두 개 이상의 차트 유형을 결합합니다. 이 차트를 사용하면 두 개 이상의 데이터 집합 간의 차이를 강조, 비교 또는 조사하여 관계를 파악할 수 있습니다.

![복합 차트](combination_chart.png)

다음 C# 코드에서는 위에 표시된 복합 차트를 PowerPoint 프레젠테이션에 만드는 방법을 보여줍니다:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // 차트 제목을 설정합니다
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // 차트 범례를 설정합니다
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // 기본 생성된 시리즈와 범주를 삭제합니다
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 새 범주를 추가합니다
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // 첫 번째 시리즈를 추가합니다
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // 수평축을 설정합니다
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // 수직축을 설정합니다
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // 수직 주요 눈금선 색상을 설정합니다
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // 보조 수평축을 설정합니다
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // 보조 수직축을 설정합니다
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **차트 업데이트**

Aspose.Slides for .NET은 차트 데이터를 수정하고 서식 및 스타일을 변경하여 PowerPoint 차트를 업데이트할 수 있게 합니다. 이 기능을 사용하면 동적 콘텐츠로 프레젠테이션을 최신 상태로 유지하고 차트가 현재 데이터와 시각적 표준을 정확히 반영하도록 할 수 있습니다.

1. 차트를 포함하는 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 모든 도형을 순회하여 차트를 찾습니다.
1. 차트의 데이터 워크시트에 액세스합니다.
1. 시리즈 값을 변경하여 차트 데이터 시리즈를 수정합니다.
1. 새 시리즈를 추가하고 데이터를 채웁니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 첫 번째 슬라이드에 액세스합니다.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // 차트 데이터 시트의 인덱스를 설정합니다.
            int worksheetIndex = 0;

            // 차트 데이터 워크북을 가져옵니다.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // 차트 카테고리 이름을 변경합니다.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // 첫 번째 차트 시리즈를 가져옵니다.
            IChartSeries series = chart.ChartData.Series[0];

            // 시리즈 데이터를 업데이트합니다.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // 시리즈 이름을 수정합니다.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // 두 번째 차트 시리즈를 가져옵니다.
            series = chart.ChartData.Series[1];

            // 시리즈 데이터를 업데이트합니다.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // 시리즈 이름을 수정합니다.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // 새 시리즈를 추가합니다.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // 시리즈 데이터를 채웁니다.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // 차트가 포함된 프레젠테이션을 저장합니다.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **차트 데이터 범위 설정**

기존 차트가 사용하고 있는 범위를 확인하려면 [Retrieve a Chart's Data Range](/slides/ko/net/chart-workbook/#retrieve-a-charts-data-range)을 참조하십시오.

Aspose.Slides for .NET은 워크시트의 특정 데이터 범위를 차트 데이터의 소스로 정의할 수 있는 유연성을 제공합니다. 즉, 워크시트의 일부분을 차트에 직접 매핑하여 어느 셀이 차트의 시리즈와 범주에 기여하는지 제어할 수 있습니다. 이를 통해 워크시트의 최신 데이터 변경 사항을 차트에 쉽게 반영하고 동기화할 수 있어 PowerPoint 프레젠테이션이 최신 정확한 정보를 반영하도록 할 수 있습니다.

1. 차트를 포함하는 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 모든 도형을 순회하여 차트를 찾습니다.
1. 차트 데이터를 액세스하고 범위를 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 첫 번째 슬라이드에 액세스합니다.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **차트 기본 마커 사용**

차트에 기본 마커를 사용하면 각 차트 시리즈에 자동으로 서로 다른 기본 마커 기호가 할당됩니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // 시리즈 데이터를 채웁니다.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Aspose.Slides for .NET에서 지원되는 차트 유형은 무엇입니까?**

Aspose.Slides for .NET은 막대, 꺾은선, 원형, 영역, 산점도, 히스토그램, 레이더 등 다양한 차트 유형을 지원합니다. 이 유연성을 통해 데이터 시각화 요구에 가장 적합한 차트 유형을 선택할 수 있습니다.

**슬라이드에 새 차트를 추가하려면 어떻게 해야 합니까?**

새 차트를 추가하려면 먼저 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스의 인스턴스를 만든 다음, 인덱스를 사용해 원하는 슬라이드를 가져오고, 차트를 추가하는 메서드를 호출하면서 차트 유형과 초기 데이터를 지정합니다. 이 과정으로 차트가 프레젠테이션에 직접 통합됩니다.

**차트에 표시되는 데이터를 어떻게 업데이트합니까?**

차트의 데이터를 업데이트하려면 차트의 데이터 워크북([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))에 액세스하고, 기본 시리즈와 범주를 제거한 뒤 사용자 지정 데이터를 추가하면 됩니다. 이를 통해 차트를 프로그래밍 방식으로 최신 데이터에 맞게 새로 고칠 수 있습니다.

**차트의 모양을 사용자 지정할 수 있나요?**

네, Aspose.Slides for .NET은 광범위한 사용자 지정 옵션을 제공합니다. 색상, 글꼴, 레이블, 범례 및 기타 서식 요소를 수정하여 차트를 특정 디자인 요구 사항에 맞게 조정할 수 있습니다.