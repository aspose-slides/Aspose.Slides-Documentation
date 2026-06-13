---
title: .NET에서 프레젠테이션의 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/net/chart-series/
keywords:
- 차트 시리즈
- 시리즈 겹침
- 시리즈 색상
- 카테고리 색상
- 시리즈 이름
- 데이터 포인트
- 시리즈 간격
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "실용적인 코드 예제와 모범 사례를 통해 PowerPoint(PPT/PPTX)용 C#에서 차트 시리즈를 관리하고 데이터 프레젠테이션을 향상시키는 방법을 배웁니다."
---
## **개요**

이 문서에서는 Aspose.Slides for .NET에서 [ChartSeries](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartseries/)의 역할을 설명하며, 프레젠테이션 내에서 데이터가 어떻게 구조화되고 시각화되는지에 중점을 둡니다. 이러한 객체는 차트 내에서 개별 데이터 포인트 집합, 카테고리 및 외관 매개변수를 정의하는 기본 요소를 제공합니다. [ChartSeries](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartseries/)를 사용하면 개발자가 기본 데이터 소스를 원활하게 통합하고 정보 표시 방식을 완벽히 제어할 수 있어, 통찰과 분석을 명확히 전달하는 동적이고 데이터 기반의 프레젠테이션을 만들 수 있습니다.

시리즈는 차트에 플롯되는 행 또는 열의 숫자 집합입니다.

![차트 시리즈 파워포인트](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[IChartSeriesOverlap](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/properties/overlap) 속성은 -100에서 100까지의 범위를 지정하여 2D 차트에서 막대와 열이 겹치는 방식을 제어합니다. 이 속성은 개별 차트 시리즈가 아니라 시리즈 그룹에 연관되어 있으므로 시리즈 수준에서는 읽기 전용입니다. 겹침 값을 구성하려면 `ParentSeriesGroup.Overlap` 읽기/쓰기 속성을 사용하십시오. 이 속성은 해당 그룹의 모든 시리즈에 지정된 겹침을 적용합니다.

아래는 프레젠테이션을 생성하고, 클러스터형 열 차트를 추가하고, 첫 번째 차트 시리즈에 접근하여 겹침 설정을 구성한 다음 결과를 PPTX 파일로 저장하는 C# 예제입니다:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 기본 데이터로 클러스터형 열 차트를 추가합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // 시리즈 겹침을 설정합니다.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // 프레젠테이션 파일을 디스크에 저장합니다.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

결과:

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

Aspose.Slides를 사용하면 차트 시리즈의 채우기 색상을 손쉽게 사용자 정의할 수 있어 특정 데이터 포인트를 강조하고 시각적으로 매력적인 차트를 만들 수 있습니다. 이는 다양한 채우기 유형, 색상 설정 및 기타 고급 스타일 옵션을 지원하는 [IFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/iformat/) 객체를 통해 구현됩니다. 슬라이드에 차트를 추가하고 원하는 시리즈에 접근한 후 해당 시리즈를 가져와 적절한 채우기 색상을 적용하면 됩니다. 단색 채우기 외에도 그라디언트나 패턴 채우기를 활용하여 디자인 유연성을 높일 수 있습니다. 요구 사항에 맞게 색상을 설정한 후 프레젠테이션을 저장하면 업데이트된 모양이 최종 적용됩니다.

다음 C# 코드 예제는 첫 번째 시리즈의 색상을 변경하는 방법을 보여줍니다:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 기본 데이터로 클러스터형 열 차트를 추가합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 첫 번째 시리즈의 색상을 설정합니다.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // 프레젠테이션 파일을 디스크에 저장합니다.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

결과:

![시리즈 색상](series_color.png)

## **시리즈 이름 변경**

Aspose.Slides는 차트 시리즈 이름을 쉽게 수정할 수 있는 방법을 제공하여 데이터를 명확하고 의미 있게 라벨링할 수 있습니다. 차트 데이터의 해당 워크시트 셀에 접근함으로써 개발자는 데이터 표시 방식을 맞춤 설정할 수 있습니다. 이러한 수정은 데이터 컨텍스트에 따라 시리즈 이름을 업데이트하거나 명확히 해야 할 때 특히 유용합니다. 시리즈 이름을 변경한 후에는 프레젠테이션을 저장하여 변경 사항을 유지할 수 있습니다.

아래는 이 과정을 실제로 보여주는 C# 코드 스니펫입니다.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 기본 데이터로 클러스터형 열 차트를 추가합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 첫 번째 시리즈의 이름을 설정합니다.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // 프레젠테이션 파일을 디스크에 저장합니다.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

다음 C# 코드는 시리즈 이름을 변경하는 대체 방법을 보여줍니다:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 기본 데이터로 클러스터형 열 차트를 추가합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 첫 번째 시리즈의 이름을 설정합니다.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // 프레젠테이션 파일을 디스크에 저장합니다.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

결과:

![시리즈 이름](series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

Aspose.Slides for .NET을 사용하면 플롯 영역 내 차트 시리즈의 자동 채우기 색상을 가져올 수 있습니다. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 만든 후, 인덱스로 원하는 슬라이드에 대한 참조를 얻고, 원하는 유형(`ChartType.ClusteredColumn` 등)의 차트를 추가합니다. 차트의 시리즈에 접근하면 자동 채우기 색상을 얻을 수 있습니다.

아래 C# 코드는 이 과정을 자세히 보여줍니다.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 기본 데이터로 클러스터형 열 차트를 추가합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // 시리즈의 자동 채우기 색상을 가져옵니다.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

출력:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **차트 시리즈에 반전 채우기 색상 설정**

데이터 시리즈에 양수와 음수가 모두 포함된 경우, 모든 열이나 막대를 동일한 색상으로만 색칠하면 차트를 읽기 어렵게 만들 수 있습니다. Aspose.Slides for .NET을 사용하면 반전 채우기 색상을 지정할 수 있습니다—즉, 0 이하인 데이터 포인트에 자동으로 적용되는 별도의 채우기로, 음수 값을 한 눈에 돋보이게 합니다. 이 섹션에서는 해당 옵션을 활성화하고 적절한 색상을 선택한 뒤 업데이트된 프레젠테이션을 저장하는 방법을 배웁니다.

다음 코드 예제는 해당 동작을 보여줍니다:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 새 카테고리를 추가합니다.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // 새 시리즈를 추가합니다.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // 시리즈 데이터를 채웁니다.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // 시리즈의 색상 설정을 지정합니다.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

결과:

![반전된 단색 채우기 색상](inverted_solid_fill_color.png)

전체 시리즈가 아니라 단일 데이터 포인트에 대해서도 채우기 색상을 반전시킬 수 있습니다. 원하는 `IChartDataPoint`에 접근하여 해당 `InvertIfNegative` 속성을 true로 설정하면 됩니다.

다음 코드 예제는 이를 수행하는 방법을 보여줍니다:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // 인덱스 2에 해당하는 데이터 포인트가 음수인 경우 색상을 반전시킵니다.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **특정 데이터 포인트 값 지우기**

때때로 차트에 테스트 값, 이상치 또는 오래된 항목이 포함되어 전체 시리즈를 다시 만들지 않고도 제거해야 할 경우가 있습니다. Aspose.Slides for .NET을 사용하면 인덱스로 원하는 데이터 포인트를 지정하여 내용을 지우고, 즉시 플롯을 새로 고쳐 남은 포인트가 이동하고 축이 자동으로 재조정되도록 할 수 있습니다.

다음 코드 예제는 해당 동작을 보여줍니다:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **시리즈 갭 폭 설정**

갭 폭은 인접한 열이나 막대 사이의 빈 공간 양을 제어합니다—갭이 넓을수록 개별 카테고리가 강조되고, 갭이 좁을수록 더 조밀하고 컴팩트한 모습을 제공합니다. Aspose.Slides for .NET을 통해 전체 시리즈에 대해 이 매개변수를 정밀 조정함으로써, 기본 데이터를 변경하지 않고도 프레젠테이션에 필요한 정확한 시각적 균형을 얻을 수 있습니다.

다음 코드 예제는 시리즈의 갭 폭을 설정하는 방법을 보여줍니다:

```cs
ushort gapWidth = 30;

// 빈 프레젠테이션을 생성합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드에 접근합니다.
    ISlide slide = presentation.Slides[0];

    // 기본 데이터가 있는 차트를 추가합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // 프레젠테이션을 디스크에 저장합니다.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // GapWidth 값을 설정합니다.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // 프레젠테이션을 디스크에 저장합니다.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

결과:

![갭 폭](gap_width.png)

## **자주 묻는 질문**

**하나의 차트가 포함할 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides는 추가할 수 있는 시리즈 수에 고정된 제한을 두지 않습니다. 실제 제한은 차트 가독성 및 애플리케이션이 사용할 수 있는 메모리에 따라 결정됩니다.

**클러스터 내 열이 너무 가깝거나 너무 멀리 떨어져 있으면 어떻게 하나요?**

`GapWidth` 설정을 해당 시리즈(또는 상위 시리즈 그룹)에서 조정하십시오. 값을 늘리면 열 사이의 공간이 넓어지고, 값을 감소하면 열이 더 가까워집니다.