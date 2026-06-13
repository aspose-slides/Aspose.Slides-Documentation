---
title: .NET에서 프레젠테이션 차트 형식 지정
linktitle: 차트 형식 지정
type: docs
weight: 60
url: /ko/net/chart-formatting/
keywords:
- 차트 형식 지정
- 차트 서식 지정
- 차트 항목
- 차트 속성
- 차트 설정
- 차트 옵션
- 글꼴 속성
- 둥근 테두리
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 차트 서식 지정 방법을 배우고, 전문적이고 시선을 끄는 스타일링으로 PowerPoint 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 차트를 형식화하는 방법을 설명합니다. 축, 눈금선, 제목, 범례, 플롯 영역 및 배경 채우기와 같은 주요 차트 요소를 사용자 지정하여 차트 데이터의 외관과 가독성을 향상시키는 방법을 보여줍니다.

또한 차트 텍스트의 글꼴 속성을 설정하고, 차트 데이터에 사전 정의 및 사용자 지정 숫자 형식을 적용하며, 차트 영역에 둥근 모서리를 활성화하는 방법도 보여줍니다. 이러한 예제를 통해 프레젠테이션 내 차트의 시각적 스타일과 데이터 표시를 모두 제어하는 방법을 알 수 있습니다.

## **차트 엔터티 형식 지정**
Aspose.Slides for .NET를 사용하면 개발자가 처음부터 슬라이드에 사용자 지정 차트를 추가할 수 있습니다. 이 문서에서는 차트 범주 및 값 축을 포함한 다양한 차트 엔터티를 형식화하는 방법을 설명합니다.

Aspose.Slides for .NET는 다양한 차트 엔터티를 관리하고 사용자 지정 값으로 형식화하기 위한 간단한 API를 제공합니다:

1. **Presentation** 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 얻습니다.
1. 원본 데이터를 사용하여 차트를 추가하고 원하는 유형 중 하나를 선택합니다 (이 예에서는 ChartType.LineWithMarkers를 사용합니다).
1. 차트 Value Axis에 접근하여 다음 속성을 설정합니다:
   1. Value Axis 메이저 그리드 선에 대한 **Line format** 설정
   1. Value Axis 마이너 그리드 선에 대한 **Line format** 설정
   1. Value Axis에 대한 **Number Format** 설정
   1. Value Axis에 대한 **Min, Max, Major and Minor units** 설정
   1. Value Axis 데이터에 대한 **Text Properties** 설정
   1. Value Axis에 대한 **Title** 설정
   1. Value Axis에 대한 **Line Format** 설정
1. 차트 Category Axis에 접근하여 다음 속성을 설정합니다:
   1. Category Axis 메이저 그리드 선에 대한 **Line format** 설정
   1. Category Axis 마이너 그리드 선에 대한 **Line format** 설정
   1. Category Axis 데이터에 대한 **Text Properties** 설정
   1. Category Axis에 대한 **Title** 설정
   1. Category Axis에 대한 **Label Positioning** 설정
   1. Category Axis 레이블에 대한 **Rotation Angle** 설정
1. 차트 Legend에 접근하여 **Text Properties**를 설정합니다.
1. 차트가 겹치지 않도록 차트 Legends를 표시하도록 설정합니다.
1. 차트 **Secondary Value Axis**에 접근하여 다음 속성을 설정합니다:
   1. Secondary **Value Axis**를 활성화합니다.
   1. Secondary Value Axis에 대한 **Line Format** 설정
   1. Secondary Value Axis에 대한 **Number Format** 설정
   1. Secondary Value Axis에 대한 **Min, Max, Major and Minor units** 설정
1. 이제 첫 번째 차트 시리즈를 Secondary Value Axis에 플롯합니다.
1. 차트 뒤쪽 벽 채우기 색을 설정합니다.
1. 차트 플롯 영역 채우기 색을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 기록합니다.

```c#
// 프레젠테이션 인스턴스화// 프레젠테이션 인스턴스화
Presentation pres = new Presentation();

// Accessing the first slide
// 첫 번째 슬라이드에 접근
ISlide slide = pres.Slides[0];

// Adding the sample chart
// 샘플 차트 추가
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
// 차트 제목 설정
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
// 값 축의 주요 눈금선 형식 설정
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
// 값 축의 보조 눈금선 형식 설정
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
// 값 축 숫자 형식 설정
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
// 차트 최대·최소값 설정
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
// 값 축 텍스트 속성 설정
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
// 값 축 제목 설정
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting value axis line format : Now Obselete
// 값 축 선 형식 설정 : 이제 사용되지 않음
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
// 카테고리 축의 주요 눈금선 형식 설정
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
// 카테고리 축의 보조 눈금선 형식 설정
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
// 카테고리 축 텍스트 속성 설정
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
// 카테고리 제목 설정
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
// 카테고리 축 레이블 위치 설정
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
// 카테고리 축 레이블 회전 각도 설정
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
// 범례 텍스트 속성 설정
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart
// 차트와 겹치지 않게 범례 표시

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// 보조 값 축에 첫 번째 시리즈 플로팅
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
// 차트 뒤쪽 벽 색상 설정
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
// 플롯 영역 색상 설정
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
// 프레젠테이션 저장
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **차트에 대한 글꼴 속성 설정**
Aspose.Slides for .NET는 차트에 대한 글꼴 관련 속성을 설정하는 기능을 제공합니다. 차트의 글꼴 속성을 설정하려면 아래 단계를 따르세요.

- Presentation 클래스 객체를 인스턴스화합니다.
- 슬라이드에 차트를 추가합니다.
- 글꼴 높이를 설정합니다.
- 수정된 프레젠테이션을 저장합니다.

아래 예제가 제공됩니다.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```

## **숫자 형식 설정**
Aspose.Slides for .NET는 차트 데이터 형식을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 얻습니다.
1. 기본 데이터를 사용하여 차트를 추가하고 원하는 유형 중 하나를 선택합니다 (이 예에서는 **ChartType.ClusteredColumn**을 사용합니다).
1. 가능한 사전 정의 값 중에서 사전 정의 숫자 형식을 설정합니다.
1. 모든 차트 시리즈의 차트 데이터 셀을 순회하면서 차트 데이터 숫자 형식을 설정합니다.
1. 프레젠테이션을 저장합니다.
1. 사용자 지정 숫자 형식을 설정합니다.
1. 모든 차트 시리즈 내부의 차트 데이터 셀을 순회하면서 다른 차트 데이터 숫자 형식을 설정합니다.
1. 프레젠테이션을 저장합니다.

```c#
// 프레젠테이션 인스턴스화// 프레젠테이션 인스턴스화
Presentation pres = new Presentation();

// 첫 번째 프레젠테이션 슬라이드에 접근
ISlide slide = pres.Slides[0];

// 기본 클러스터드 컬럼 차트 추가
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// 차트 시리즈 컬렉션에 접근
IChartSeriesCollection series = chart.ChartData.Series;

// 사전 정의 숫자 형식 설정
// 모든 차트 시리즈 순회
foreach (ChartSeries ser in series)
{
    // 시리즈의 모든 데이터 셀 순회
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // 숫자 형식 설정
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// 프레젠테이션 저장
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

가능한 사전 정의 숫자 형식 값과 해당 인덱스는 아래와 같습니다:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **차트 영역 둥근 테두리 설정**
Aspose.Slides for .NET는 차트 영역을 설정하는 기능을 제공합니다. **IChart.HasRoundedCorners** 및 **Chart.HasRoundedCorners** 속성이 Aspose.Slides에 추가되었습니다.

1. `Presentation` 클래스 객체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트의 채우기 유형과 채우기 색을 설정합니다.
1. 둥근 모서리 속성을 True로 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

아래 예제가 제공됩니다.

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**열/영역에 반투명 채우기를 적용하면서 테두리는 불투명하게 유지할 수 있나요?**

예. 채우기 투명도와 외곽선은 별도로 구성됩니다. 이는 복잡한 시각화에서 격자와 데이터의 가독성을 높이는 데 유용합니다.

**레이블이 겹칠 때 어떻게 처리해야 하나요?**

글꼴 크기를 줄이거나, 불필요한 레이블 구성 요소(예: 카테고리)를 비활성화하고, 레이블 오프셋/위치를 설정하며, 필요하면 선택된 포인트에만 레이블을 표시하거나 “값 + 범례” 형식으로 전환합니다.

**시리즈에 그라디언트나 패턴 채우기를 적용할 수 있나요?**

예. 일반적으로 단색 및 그라디언트/패턴 채우기가 제공됩니다. 실무에서는 그라디언트를 제한적으로 사용하고, 격자와 텍스트 대비를 낮추는 조합은 피하십시오.