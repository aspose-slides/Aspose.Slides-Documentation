---
title: Excel 차트를 생성하고 프레젠테이션에 OLE 객체로 삽입하기
type: docs
weight: 50
url: /ko/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 객체
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "C#/.NET을 사용하여 Excel 차트를 생성하고 PowerPoint 및 OpenDocument 프레젠테이션에 OLE 객체로 삽입합니다. 단계별 가이드와 코드 샘플을 제공합니다."
---
## **배경**

PowerPoint에서 편집 가능한 차트를 사용하여 데이터를 그래픽으로 표시하는 것은 일반적인 방법입니다. Aspose는 .NET용 Aspose.Cells를 사용하여 Excel 차트를 생성하는 것을 지원하며, 이러한 차트를 Aspose.Slides for .NET을 통해 OLE 객체로 PowerPoint 슬라이드에 삽입할 수 있습니다. 이 문서에서는 필요한 단계들을 설명하고 Aspose.Cells와 Aspose.Slides를 사용하여 Excel 차트를 생성하고 OLE 객체로 PowerPoint 프레젠테이션에 삽입하는 C# 코드 샘플을 제공합니다.

## **필수 단계**

PowerPoint 슬라이드에 Excel 차트를 OLE 객체로 생성하고 삽입하려면 다음 순서대로 단계를 수행해야 합니다:

1. Aspose.Cells를 사용하여 Excel 차트를 생성합니다.
1. Aspose.Cells를 사용하여 Excel 차트의 OLE 크기를 설정합니다.
1. Aspose.Cells를 사용하여 Excel 차트의 이미지를 가져옵니다.
1. Aspose.Slides를 사용하여 Excel 차트를 PPTX 프레젠테이션에 OLE 객체로 삽입합니다.
1. 3단계에서 얻은 이미지로 "EMBEDDED OLE OBJECT" 이미지를 교체하여 [객체 미리보기 문제](/slides/ko/net/object-preview-issue-when-adding-oleobjectframe/)를 해결합니다.
1. 프레젠테이션을 PPTX 형식으로 디스크에 저장합니다.

## **필수 단계 구현**

위 단계들의 C# 구현은 다음과 같습니다:

```cs
// Step - 1: Aspose.Cells를 사용하여 Excel 차트를 생성합니다.
// ---------------------------------------------------
// Create a workbook.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Add an Excel chart.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Step - 2: Aspose.Cells를 사용하여 차트의 OLE 크기를 설정합니다.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Step - 3: Aspose.Cells로 차트 이미지를 가져옵니다.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Save the workbook to a stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Step - 4 AND 5
// ==============
 // Step - 4: Aspose.Slides를 사용하여 차트를 .ppt 프레젠테이션 내부에 OLE 객체로 삽입합니다.
// ------------------------------------------------------------------------------------------
 // Step - 5: "EMBEDDED OLE OBJECT" 이미지를 3단계에서 얻은 이미지로 교체하여 객체 미리보기 문제를 해결합니다.
// --------------------------------------------------------------------------------------------------------------------
 // Create a presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // 워크북을 슬라이드에 추가합니다.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Step - 6: 출력 프레젠테이션을 디스크에 저장합니다.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // 셀 이름 배열.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // 셀 데이터 배열.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // 데이터로 셀을 채우기 위해 새 워크시트를 추가합니다.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // 데이터 시트를 데이터로 채웁니다.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // 차트 시트를 추가합니다.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // 데이터 시트의 데이터 계열을 사용하여 차트 시트에 차트를 추가합니다.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // 차트 시트를 활성 시트로 설정합니다.
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

위 방법으로 생성된 프레젠테이션에는 Excel 차트가 OLE 객체로 포함되며, OLE 객체 프레임을 더블 클릭하면 차트를 활성화할 수 있습니다.

## **결론**

.NET용 Aspose.Cells와 Aspose.Slides를 함께 사용하면 Aspose.Cells에서 지원하는 모든 Excel 차트를 생성하고 차트를 PowerPoint 슬라이드에 OLE 객체로 삽입할 수 있습니다. Excel 차트의 OLE 크기도 정의할 수 있습니다. 최종 사용자는 다른 OLE 객체와 마찬가지로 Excel 차트를 편집할 수 있습니다.

## **관련 섹션**

- [PPTX 차트 크기 조정 작업 솔루션](/slides/ko/net/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame 추가 시 객체 미리보기 문제](/slides/ko/net/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint 추가 기능을 사용하여 OLE 객체를 자동으로 업데이트](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)