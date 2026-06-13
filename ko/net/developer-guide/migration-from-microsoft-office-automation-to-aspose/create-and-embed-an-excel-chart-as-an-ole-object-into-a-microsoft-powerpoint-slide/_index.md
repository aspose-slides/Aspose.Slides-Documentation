---
title: VSTO 및 Aspose.Slides for .NET을 사용하여 Excel 차트를 OLE 개체로 만들고 삽입하기
linktitle: Excel 차트를 OLE 개체로 만들고 삽입하기
type: docs
weight: 70
url: /ko/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- 차트 만들기
- Excel 차트 삽입
- OLE 개체
- 마이그레이션
- VSTO
- Office 자동화
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office 자동화에서 Aspose.Slides for .NET으로 마이그레이션하고 C#에서 Excel 차트를 OLE 개체로 PowerPoint(PPT, PPTX) 슬라이드에 삽입합니다."
---
{{% alert color="primary" %}} 

 차트는 데이터의 시각적 표현이며 프레젠테이션 슬라이드에서 널리 사용됩니다. 이 문서에서는 [VSTO](/slides/ko/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) 및 [Aspose.Slides for .NET](/slides/ko/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)를 사용하여 Excel 차트를 OLE 개체로 PowerPoint 슬라이드에 프로그래밍 방식으로 생성하고 삽입하는 코드를 보여줍니다.

{{% /alert %}} 
## **Excel 차트 만들기 및 삽입**
아래 두 개의 코드 예제는 작업이 복잡하기 때문에 길고 자세합니다. Microsoft Excel 통합 문서를 만들고 차트를 생성한 다음 차트를 삽입할 Microsoft PowerPoint 프레젠테이션을 만듭니다. OLE 개체는 원본 문서에 대한 링크를 포함하므로 사용자가 삽입된 파일을 더블 클릭하면 파일과 해당 애플리케이션이 실행됩니다.
## **VSTO 예제**
VSTO를 사용하여 다음 단계가 수행됩니다:

1. Microsoft Excel ApplicationClass 개체의 인스턴스를 생성합니다.
2. 시트가 하나 있는 새 통합 문서를 만듭니다.
3. 시트에 차트를 추가합니다.
4. 통합 문서를 저장합니다.
5. 차트 데이터가 있는 워크시트를 포함한 Excel 통합 문서를 엽니다.
6. 시트의 ChartObjects 컬렉션을 가져옵니다.
7. 복사할 차트를 가져옵니다.
8. Microsoft PowerPoint 프레젠테이션을 생성합니다.
9. 프레젠테이션에 빈 슬라이드를 추가합니다.
10. Excel 워크시트에서 차트를 클립보드로 복사합니다.
11. 차트를 PowerPoint 프레젠테이션에 붙여넣습니다.
12. 슬라이드에 차트의 위치를 지정합니다.
13. 프레젠테이션을 저장합니다.

```c#
CreateNewChartInExcel();
UseCopyPaste();
```

```c#
static void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)
{
    targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);
}
```

```c#
static void CreateNewChartInExcel()
{
    // Excel ApplicationClass 인스턴스에 대한 변수를 선언합니다.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Workbooks.Open 메서드 매개변수에 대한 변수를 선언합니다.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Chart.ChartWizard 메서드에 대한 변수를 선언합니다.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Excel ApplicationClass 객체의 인스턴스를 생성합니다.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // 시트가 1개인 새 통합 문서를 생성합니다.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // 시트 이름을 변경합니다.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // 시트에 차트용 데이터를 삽입합니다.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    N. America  1.5     2       1.5     2.5
        //     3    S. America  2       1.75    2       2
        //     4    Europe      2.25    2       2.5     2
        //     5    Asia        2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "N. America");
        SetCellValue(targetSheet, "A3", "S. America");
        SetCellValue(targetSheet, "A4", "Europe");
        SetCellValue(targetSheet, "A5", "Asia");

        SetCellValue(targetSheet, "B1", "Q1");
        SetCellValue(targetSheet, "B2", 1.5);
        SetCellValue(targetSheet, "B3", 2);
        SetCellValue(targetSheet, "B4", 2.25);
        SetCellValue(targetSheet, "B5", 2.5);

        SetCellValue(targetSheet, "C1", "Q2");
        SetCellValue(targetSheet, "C2", 2);
        SetCellValue(targetSheet, "C3", 1.75);
        SetCellValue(targetSheet, "C4", 2);
        SetCellValue(targetSheet, "C5", 2.5);

        SetCellValue(targetSheet, "D1", "Q3");
        SetCellValue(targetSheet, "D2", 1.5);
        SetCellValue(targetSheet, "D3", 2);
        SetCellValue(targetSheet, "D4", 2.5);
        SetCellValue(targetSheet, "D5", 2);

        SetCellValue(targetSheet, "E1", "Q4");
        SetCellValue(targetSheet, "E2", 2.5);
        SetCellValue(targetSheet, "E3", 2);
        SetCellValue(targetSheet, "E4", 2);
        SetCellValue(targetSheet, "E5", 2.75);

        // 차트 데이터를 포함하는 범위를 가져옵니다.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // 시트에 대한 ChartObjects 컬렉션을 가져옵니다.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // 컬렉션에 차트를 추가합니다.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // 데이터로 새로운 차트를 생성합니다.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // 통합 문서를 저장합니다.
        newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (excelApplication != null)
        {
            // Excel을 종료합니다.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // PowerPoint 개체에 대한 참조를 보유할 변수를 선언합니다.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Excel 개체에 대한 참조를 보유할 변수를 선언합니다.
    xlNS.ApplicationClass excelApplication = null;
    xlNS.Workbook excelWorkBook = null;
    xlNS.Worksheet targetSheet = null;
    xlNS.ChartObjects chartObjects = null;
    xlNS.ChartObject existingChartObject = null;

    string paramPresentationPath = Application.StartupPath + @"\ChartTest.pptx";
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    try
    {
        // PowerPoint 인스턴스를 생성합니다.
        powerpointApplication = new pptNS.ApplicationClass();

        // Excel 인스턴스를 생성합니다.
        excelApplication = new xlNS.ApplicationClass();

        // 차트 데이터가 있는 워크시트가 포함된 Excel 통합 문서를 엽니다.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // 차트를 포함하는 워크시트를 가져옵니다.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // 시트에 대한 ChartObjects 컬렉션을 가져옵니다.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // 복사할 차트를 가져옵니다.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // PowerPoint 프레젠테이션을 생성합니다.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // 프레젠테이션에 빈 슬라이드를 추가합니다.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Excel 워크시트에서 차트를 클립보드로 복사합니다.
        existingChartObject.Copy();

        // 차트를 PowerPoint 프레젠테이션에 붙여넣습니다.
        shapeRange = pptSlide.Shapes.Paste();

        // 슬라이드에 차트 위치를 지정합니다.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // 프레젠테이션을 저장합니다.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // PowerPoint 슬라이드 개체를 해제합니다.
        shapeRange = null;
        pptSlide = null;

        // Presentation 개체를 닫고 해제합니다.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // PowerPoint를 종료하고 ApplicationClass 개체를 해제합니다.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Excel 개체들을 해제합니다.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Excel 워크북 개체를 닫고 해제합니다.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Excel을 종료하고 ApplicationClass 개체를 해제합니다.
        if (excelApplication != null)
        {
            excelApplication.Quit();
            excelApplication = null;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
```




## **Aspose.Slides for .NET 예제**
Aspose.Slides for .NET를 사용하여 다음 단계가 수행됩니다:

1. Aspose.Cells for .NET를 사용하여 통합 문서를 생성합니다.
2. Microsoft Excel 차트를 생성합니다.
3. Excel 차트의 OLE 크기를 설정합니다.
4. 차트의 이미지를 가져옵니다.
5. Aspose.Slides for .NET를 사용하여 Excel 차트를 PPTX 프레젠테이션 내부에 OLE 개체로 삽입합니다.
6. 객체가 변경된 문제를 해결하기 위해 단계 3에서 얻은 이미지로 객체 변경된 이미지를 교체합니다.
7. 출력 프레젠테이션을 PPTX 형식으로 디스크에 저장합니다.



```c#
//Step - 1: Aspose.Cells를 사용하여 Excel 차트 만들기
//--------------------------------------------------
//워크북 생성
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Excel 차트 추가
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Step - 2: 차트의 OLE 크기를 설정합니다. Aspose.Cells 사용
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Step - 3: Aspose.Cells로 차트 이미지를 가져옵니다
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//워크북을 스트림에 저장
MemoryStream wbStream = wb.SaveToStream();
//Step - 4  및 5
//-----------------------------------------------------------
//Step - 4: Aspose.Slides를 사용하여 .ppt 프레젠테이션 안에 차트를 OLE 개체로 삽입합니다
//-----------------------------------------------------------
//Step - 5: 객체가 변경된 이미지를 3단계에서 얻은 이미지로 교체하여 Object Changed 문제를 해결합니다
//-----------------------------------------------------------
//프레젠테이션 생성
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//슬라이드에 워크북 추가
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Step - 6: 출력 프레젠테이션을 디스크에 씁니다
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] chartOleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage image = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = image;
    }
}
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //셀 이름 배열
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //셀 데이터 배열
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //데이터로 셀을 채우기 위해 새 워크시트 추가
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //DataSheet에 데이터를 채웁니다
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //차트 시트 추가
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //DataSheet에서 데이터 계열로 ChartSheet에 차트 추가
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //ChartSheet를 활성 시트로 설정
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```