---
title: .NET에서 프레젠테이션의 3D 차트 사용자 지정
linktitle: 3D 차트
type: docs
url: /ko/net/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 프레젠테이션에 3D 차트를 만들고, 회전, 높이 비율, 차트 깊이 및 시리즈 간 간격을 C# 예제로 조정합니다."
---
## **개요**

Aspose.Slides for .NET를 사용하면 [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) 속성을 통해 3D 차트의 보기를 사용자 지정할 수 있습니다. 이 문서에서는 회전, 높이 비율, 깊이, 직각 축 및 시리즈 간 간격을 조정하고 프레젠테이션을 PPTX 형식으로 저장하는 방법을 보여줍니다.

## **3D 차트의 회전 및 깊이 설정**

아래 예제는 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)을 생성하고 [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/)을 사용하여 첫 번째 슬라이드에 누적 3D 컬럼 차트를 추가합니다. 기본 시리즈와 범주를 각각 세 개의 값을 가진 두 개의 시리즈로 교체합니다. 워크시트 인덱스 `0`은 차트의 첫 데이터 워크시트를 식별하고; 행 `0`은 시리즈 이름을, 열 `0`은 범주 레이블을 포함합니다.

[RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) 및 [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) 속성은 차트의 회전을 각각 40도와 270도로 설정합니다. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/)은 차트 깊이를 너비의 150%로 설정하고, [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/)은 원근 대신 직각 축을 사용하도록 합니다. 결과 프레젠테이션에는 이러한 3D 보기 설정이 적용된 차트가 포함됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **3D 차트 표면에 그림 채우기 적용**

3D 차트에는 독립적으로 채울 수 있는 세 개의 표면이 있습니다: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/), 그리고 [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). 선택한 표면의 [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)을 `Picture`로 설정하고 이미지를 할당합니다. [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/)와 표면의 [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/)을 모두 `Stretch`로 설정하여 이미지 한 장이 표면 전체에 맞도록 합니다.

[arrow.png](arrow.png) 파일을 작업 디렉터리에 저장합니다. 예제에서는 차트를 회전하고 수직 축의 최대 값을 높여 바닥이 열 사이에 보이도록 합니다. 그런 다음 슬라이드를 두 번 복제하고 각각 다른 표면에 화살표를 적용합니다. 세 차트 모두 동일한 데이터, 시점 및 배경을 유지합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint에서 세 슬라이드는 다음과 같이 표시됩니다.

| 측면 | 뒷면 | 바닥 |
| --- | --- | --- |
| ![차트의 측면 벽을 따라 가리키는 화살표](side-wall.png) | ![뒷벽을 가로질러 오른쪽을 가리키는 화살표](back-wall.png) | ![열 사이 바닥을 가로질러 오른쪽을 가리키는 화살표](floor.png) |

## **3D 차트의 높이 비율 조정**

[IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/)를 사용하여 3D 차트의 높이를 너비의 백분율로 설정합니다. 이를 통해 슬라이드에서 차트 객체의 크기를 변경하지 않고 3D 장면의 비율을 조정할 수 있습니다.

다음 예제는 기본 데이터(시리즈 3개, 카테고리 4개)를 사용하여 [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 차트를 생성합니다. 높이 비율을 각각 50%, 100%, 200%로 설정한 세 개의 프레젠테이션을 저장합니다. 차트의 위치, 너비 및 높이는 고정된 채 유지됩니다. 데이터, 회전, 깊이, 시리즈 간 간격 및 서식은 세 파일 모두 동일하며, 높이 백분율만 변경됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

다음 이미지들은 Microsoft PowerPoint를 사용해 생성된 프레젠테이션에서 내보낸 것입니다. 작은 비율은 평평한 장면을 만들고, 큰 비율은 동일한 차트 객체 내에서 더 높은 장면을 만듭니다. PowerPoint는 장면에 맞게 축 눈금 간격 및 레이블 배치를 조정할 수도 있습니다.

| 높이: 50% | 높이: 100% | 높이: 200% |
| --- | --- | --- |
| ![너비의 50%로 높이가 설정된 3D 컬럼 차트](height_percent_50.png) | ![너비의 100%로 높이가 설정된 3D 컬럼 차트](height_percent_100.png) | ![너비의 200%로 높이가 설정된 3D 컬럼 차트](height_percent_200.png) |

이러한 속성은 차트의 다양한 측면을 제어합니다:

| 속성 | 효과 |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | 3D 장면의 높이를 너비의 백분율로 나타냅니다. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | 슬라이드에서 차트 객체의 높이(포인트 단위)입니다. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 3D 장면의 깊이를 너비의 백분율로 나타냅니다. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 깊이 축을 따라 시리즈 간 간격을 마커 너비의 백분율로 표시합니다. |

높이 설정은 실린더, 원뿔 및 피라미드 변형을 포함한 3D 컬럼 및 막대 차트와 3D 선, 면, 파이 및 표면 차트에 영향을 줍니다. 위 비교에서는 검증된 `Column3D` 유형을 사용했습니다. 이 설정은 2D `ClusteredColumn` 차트나 `BubbleWith3D` 차트의 모양을 변경하지 않으며, 이러한 이름은 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 열거형의 멤버입니다. 다른 차트 모양 설정에 대해서는 [Chart Formatting](/slides/ko/net/chart-formatting/)을 참조하십시오.

## **시리즈 간 간격 조정**

[IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/)를 사용하여 3D 차트의 깊이 축을 따라 데이터 시리즈 간 거리를 마커 너비의 백분율로 제어합니다. **0에서 500**까지의 값을 사용할 수 있으며, `0`은 간격을 제거하고 값이 클수록 간격이 증가합니다. 차트 깊이가 고정된 경우, 간격을 늘리면 깊이 축을 따라 마커가 더 얇아집니다.

[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/)을 통해 그룹에 접근합니다. 이 설정은 해당 그룹에 포함된 모든 시리즈에 적용되며, 접근에 사용된 시리즈에만 한정되지 않습니다. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/)는 읽기 전용이며 부모 그룹의 설정을 반영합니다.

이 설정은 실린더, 원뿔 및 피라미드 변형을 포함한 3D 컬럼 및 막대 차트와 3D 선 및 면 차트에 영향을 줍니다. 모양은 시리즈가 깊이 방향으로 배열되었는지, 클러스터형인지, 누적형인지에 따라 달라집니다. 별도 시리즈 간 간격을 명확히 비교하려면 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 열거형의 `ChartType.Column3D`를 사용하십시오.

| 속성 | 효과 |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | 깊이 축을 따라 시리즈 간 간격을 마커 너비의 백분율로 표시합니다. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | 인접한 막대 또는 컬럼 클러스터 사이 간격을 막대 또는 컬럼 너비의 백분율로 나타냅니다. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 전체 차트 깊이를 차트 너비의 백분율로 나타냅니다. |

다음 자체 포함 예제는 기본 차트 데이터(시리즈 3개, 카테고리 4개)를 사용합니다. 데이터, 회전, 간격 너비 및 차트 깊이가 동일한 두 프레젠테이션을 저장하며, 간격 깊이만 변경됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

다음 이미지들은 Microsoft PowerPoint를 사용해 생성된 프레젠테이션에서 내보낸 것입니다.

| 간격 깊이: 0% | 간격 깊이: 500% |
| --- | --- |
| ![깊이 축을 따라 시리즈 간 간격이 없는 3D 컬럼 차트](gap_depth_0.png) | ![깊이 축을 따라 시리즈 간 500% 간격이 있는 3D 컬럼 차트](gap_depth_500.png) |

## **3D 시리즈 유형 및 막대 모양 변경**

클러스터형 실린더 차트에서 첫 번째 시리즈는 실린더 모양의 막대로 시작합니다. 예제는 각 변경 전후에 [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) 및 [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/)을 읽습니다.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| 첫 시리즈에 대한 변경 | `Type` | `Bar3DShape` |
| --- | --- | --- |
| 차트 생성 | `ClusteredCylinder` | `Cylinder` |
| `Type`을 `ClusteredCone`으로 설정 | `ClusteredCone` | `Cone` |
| `Bar3DShape`을 `Box`으로 설정 | `ClusteredColumn3D` | `Box` |

`Box`로 모양을 설정하면 시리즈 유형도 `ClusteredColumn3D`로 변경됩니다. 코드에서 시리즈 유형에 따라 분기하는 경우, 모양을 변경한 후 `series.Type`을 읽어야 합니다. 할당 전에 캐시된 값은 여전히 `ClusteredCone` 분기를 선택합니다.

![PowerPoint 비교 이미지로, 첫 시리즈가 왼쪽부터 실린더, 원뿔, 사각형 컬럼으로 표시됨](series-shapes.png)

## **FAQ**

**Aspose.Slides에서 어떤 차트 유형이 3D 모드를 지원합니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D와 같은 컬럼 차트의 3D 변형을 비롯해 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 열거형에 노출된 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참조에 있는 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 멤버를 확인하십시오.

**보고서나 웹용으로 3D 차트의 래스터 이미지를 얻을 수 있나요?**

예. 차트를 [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)으로 이미지로 내보내거나 [전체 슬라이드 렌더링](/slides/ko/net/convert-powerpoint-to-png/)을 통해 PNG 또는 JPEG와 같은 형식으로 저장할 수 있습니다. 이는 래스터 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드 또는 웹 페이지에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 구축하고 렌더링하는 성능은 어떻습니까?**

성능은 데이터 양과 시각적 복잡도에 따라 달라집니다. 최상의 결과를 얻으려면 3D 효과를 최소화하고, 벽과 플롯 영역에 무거운 텍스처를 피하고, 가능하면 시리즈당 데이터 포인트 수를 제한하며, 대상 디스플레이 또는 인쇄 요구에 맞는 해상도와 크기의 출력으로 렌더링하십시오.