---
title: VSTO와 Aspose.Slides for .NET을 사용하여 차트 만들기
linktitle: 차트 만들기
type: docs
weight: 80
url: /ko/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- 차트 만들기
- 마이그레이션
- VSTO
- Office 자동화
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "C#에서 PowerPoint 차트 생성을 자동화하는 방법을 배우세요. 이 단계별 가이드는 Aspose.Slides for .NET이 Microsoft.Office.Interop보다 더 빠르고 강력한 대안인 이유를 보여줍니다."
---
## **개요**

이 문서에서는 C#를 사용하여 Microsoft PowerPoint 프레젠테이션에서 차트를 프로그래밍 방식으로 만들고 사용자 지정하는 방법을 보여줍니다. Aspose.Slides for .NET을 사용하면 Microsoft Office나 Interop 라이브러리에 의존하지 않고 전문적이고 데이터 기반의 차트를 자동으로 생성할 수 있습니다. API는 컬럼 차트, 파이 차트, 라인 차트 등을 포함한 풍부한 기능을 제공하며, 외형, 데이터 및 레이아웃을 완전하게 제어할 수 있습니다. 보고서, 대시보드, 비즈니스 프레젠테이션을 생성하든, Aspose.Slides는 .NET 애플리케이션에서 직접 고품질 시각화를 제공하도록 도와줍니다.

## **VSTO 예제**

이 섹션에서는 **VSTO (Visual Studio Tools for Office)** 를 사용하여 Microsoft PowerPoint 프레젠테이션에 차트를 만드는 방법을 시연합니다. VSTO를 활용하면 PowerPoint와 Excel 자동화를 결합해 차트를 프로그래밍 방식으로 생성하고 사용자 지정할 수 있습니다. 아래 예제는 **3D 군집형 컬럼 차트** 를 추가하고 Excel 워크시트에서 데이터를 가져와 차트를 채우고, 서식 및 레이아웃을 조정한 뒤 최종 프레젠테이션을 저장하는 전체 과정을 .NET 애플리케이션 내부에서 수행하는 방법을 보여줍니다.

1. Microsoft PowerPoint 프레젠테이션 인스턴스를 생성합니다.
1. 프레젠테이션에 빈 슬라이드를 추가합니다.
1. 3D 군집형 컬럼 차트를 추가하고 해당 차트에 접근합니다.
1. 새로운 Microsoft Excel 워크북 인스턴스를 만들고 차트 데이터를 로드합니다.
1. Excel 워크북 인스턴스를 사용해 차트 데이터 워크시트에 접근합니다.
1. 워크시트에서 차트 범위를 설정하고 차트에서 시리즈 2와 3을 제거합니다.
1. 차트 데이터 워크시트에서 차트 범주 데이터를 수정합니다.
1. 차트 데이터 워크시트에서 시리즈 1 데이터를 수정합니다.
1. 차트 제목에 접근하고 폰트와 관련된 속성을 설정합니다.
1. 차트의 값 축에 접근해 주 단위, 보조 단위, 최대값 및 최소값을 설정합니다.
1. 차트의 깊이(시리즈) 축에 접근해 제거합니다—이 예제에서는 하나의 시리즈만 사용됩니다.
1. X 및 Y축 방향으로 차트의 회전 각도를 설정합니다.
1. 프레젠테이션을 저장합니다.
1. Microsoft Excel 및 PowerPoint 인스턴스를 닫습니다.

```c#
EnsurePowerPointIsRunning(true, true);

// 슬라이드 객체를 인스턴스화합니다.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// 첫 번째 프레젠테이션 슬라이드에 접근합니다.
objSlide = objPres.Slides[1];

// 첫 번째 슬라이드를 선택하고 레이아웃을 설정합니다.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// 슬라이드에 기본 차트를 추가합니다.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// 추가된 차트에 접근합니다.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// 차트 데이터에 접근합니다.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// 차트 데이터를 다루기 위해 Excel 워크북 인스턴스를 생성합니다.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// 차트용 데이터 워크시트에 접근합니다.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// 차트의 데이터 범위를 설정합니다.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// 지정된 범위를 차트 데이터 테이블에 적용합니다.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// 범주와 해당 시리즈 데이터의 값을 설정합니다.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// 차트 제목을 설정합니다.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// 차트 값 축에 접근합니다.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// 축 단위 값을 설정합니다.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// 차트 깊이 축에 접근합니다.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// 차트 회전을 설정합니다.
ppChart.Rotation = 20;   // Y-값
ppChart.Elevation = 15;  // X-값
ppChart.RightAngleAxes = false;

// 프레젠테이션을 PPTX 파일로 저장합니다.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// 워크북과 프레젠테이션을 닫습니다.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Name 속성에 접근해 봅니다. 예외가 발생하면 PowerPoint 새 인스턴스를 시작합니다.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation는 프레젠테이션이 로드되었는지 확인하는 데 사용됩니다.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide은 프레젠테이션에 최소 하나의 슬라이드가 있는지 확인하는 데 사용됩니다.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

결과:

![VSTO를 사용하여 만든 차트](chart-created-using-VSTO.png)

## **Aspose.Slides for .NET 예제**

다음 예제는 Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에 간단한 차트를 만드는 방법을 보여줍니다. 이 코드는 **3D 군집형 컬럼 차트** 를 추가하고 샘플 데이터를 채운 뒤 외형을 사용자 지정하는 과정을 설명합니다. 몇 줄의 코드만으로 차트를 동적으로 생성하고 Microsoft Office를 사용하지 않고도 프레젠테이션에 통합할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 첫 번째 슬라이드에 대한 참조를 가져옵니다.
1. 3D 군집형 컬럼 차트를 추가하고 해당 차트에 접근합니다.
1. 차트 데이터를 접근합니다.
1. 사용되지 않는 Series 2와 Series 3을 제거합니다.
1. 레이블을 업데이트하여 차트 범주를 수정합니다.
1. Series 1의 값을 업데이트합니다.
1. 차트 제목에 접근하고 폰트 속성을 설정합니다.
1. 값 축을 구성합니다(주 단위, 보조 단위, 최대값 및 최소값 포함).
1. X 및 Y축에 대한 차트 회전 각도를 설정합니다.
1. 프레젠테이션을 PPTX 형식으로 저장합니다.

```cs
// 빈 프레젠테이션을 생성합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드에 접근합니다.
    ISlide slide = presentation.Slides[0];

    // 기본 차트를 추가합니다.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // 차트 데이터를 가져옵니다.
    IChartData chartData = chart.ChartData;

    // 추가 기본 시리즈를 제거합니다.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // 차트 범주 이름을 수정합니다.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // 차트 데이터 워크시트의 인덱스를 설정합니다.
    int worksheetIndex = 0;

    // 차트 데이터 워크북을 가져옵니다.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 차트 시리즈 값을 수정합니다.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // 차트 제목을 설정합니다.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // 축 옵션을 설정합니다.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // 차트 회전을 설정합니다.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

결과:

![Aspose.Slides for .NET를 사용하여 만든 차트](chart-created-using-aspose-slides.png)

## **FAQ**

**Aspose.Slides를 사용하여 파이, 라인, 바 차트와 같은 다른 유형의 차트를 만들 수 있나요?**

네. Aspose.Slides for .NET은 [차트 유형](/slides/ko/net/create-chart/)을 포함한 다양한 차트 유형을 지원합니다. 차트를 추가할 때 [ChartType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/charttype/) 열거형을 사용해 원하는 차트 유형을 지정할 수 있습니다.

**차트에 사용자 정의 스타일이나 테마를 적용할 수 있나요?**

네. 색상, 폰트, 채우기, 외곽선, 눈금선 및 레이아웃 등 차트의 외형을 완전히 사용자 지정할 수 있습니다. 다만 PowerPoint에서 제공하는 Office 테마를 그대로 적용하려면 개별 스타일을 수동으로 설정해야 합니다.

**슬라이드와 별도로 차트를 이미지 파일로 내보낼 수 있나요?**

네, Aspose.Slides는 차트를 포함한 모든 형태를 `GetImage` 메서드를 사용해 별도의 이미지(PNG, JPEG 등)로 내보낼 수 있습니다. 이 메서드는 차트 [shape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/)에 적용됩니다.