---
title: สร้างและฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ด้วย VSTO และ Aspose.Slides สำหรับ .NET
linktitle: สร้างและฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE
type: docs
weight: 70
url: /th/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- สร้างแผนภูมิ
- ฝังแผนภูมิ Excel
- อ็อบเจ็กต์ OLE
- การย้ายข้อมูล
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ .NET และฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ลงในสไลด์ PowerPoint (PPT, PPTX) ด้วย C#."
---
{{% alert color="info" %}} 

แผนภูมิเป็นการแสดงภาพข้อมูลของคุณและใช้กันอย่างแพร่หลายในการนำเสนอในสไลด์ บทความนี้จะแสดงโค้ดเพื่อสร้างและฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ในสไลด์ PowerPoint อย่างอัตโนมัติโดยใช้ [VSTO](/slides/th/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)และ[Aspose.Slides for .NET](/slides/th/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **สร้างและฝังแผนภูมิ Excel**
ตัวอย่างโค้ดสองชุดด้านล่างค่อนข้างยาวและละเอียดเนื่องจากงานที่อธิบายมีความซับซ้อน คุณจะสร้าง Microsoft Excel workbook, สร้างแผนภูมิและจากนั้นสร้าง Microsoft PowerPoint presentation ที่คุณจะฝังแผนภูมิเข้าไป อ็อบเจ็กต์ OLE จะมีลิงก์ไปยังเอกสารต้นฉบับ ดังนั้นผู้ใช้ที่ดับเบิลคลิกไฟล์ที่ฝังไว้จะเปิดไฟล์และแอปพลิเคชันของมัน
## **ตัวอย่าง VSTO**
โดยใช้ VSTO ขั้นตอนต่อไปนี้จะถูกดำเนินการ:

1. สร้างอินสแตนซ์ของอ็อบเจ็กต์ Microsoft Excel ApplicationClass
1. สร้าง workbook ใหม่ที่มีแผ่นงานหนึ่งแผ่น
1. เพิ่มแผนภูมิลงในแผ่นงาน
1. บันทึก workbook
1. เปิด Excel workbook ที่มีแผ่นงานที่มีข้อมูลแผนภูมิ
1. ดึงคอลเลกชัน ChartObjects ของแผ่นงาน
1. ดึงแผนภูมิที่ต้องการคัดลอก
1. สร้าง Microsoft PowerPoint presentation
1. เพิ่มสไลด์เปล่าลงใน presentation
1. คัดลอกแผนภูมิจากแผ่นงาน Excel ไปยังคลิปบอร์ด
1. วางแผนภูมิลงใน PowerPoint presentation
1. กำหนดตำแหน่งแผนภูมิบนสไลด์
1. บันทึก presentation

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
    // ประกาศตัวแปรสำหรับอินสแตนซ์ของ Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // ประกาศตัวแปรสำหรับพารามิเตอร์ของเมธอด Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // ประกาศตัวแปรสำหรับเมธอด Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // สร้างอินสแตนซ์ของอ็อบเจ็กต์ Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // สร้าง workbook ใหม่ที่มีแผ่นงานหนึ่งแผ่น.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // เปลี่ยนชื่อของแผ่นงาน.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // แทรกข้อมูลบางส่วนสำหรับแผนภูมิลงในแผ่นงาน.
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

        // ดึงช่วงที่บรรจุข้อมูลแผนภูมิ.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // ดึงคอลเลกชัน ChartObjects สำหรับแผ่นงาน.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // เพิ่มแผนภูมิลงในคอลเลกชัน.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // สร้างแผนภูมิใหม่จากข้อมูล.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // บันทึก workbook.
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
            // ปิด Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // ประกาศตัวแปรเพื่อเก็บการอ้างอิงไปยังอ็อบเจ็กต์ PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // ประกาศตัวแปรเพื่อเก็บการอ้างอิงไปยังอ็อบเจ็กต์ Excel.
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
        // สร้างอินสแตนซ์ของ PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // สร้างอินสแตนซ์ของ Excel.
        excelApplication = new xlNS.ApplicationClass();

        // เปิด Excel workbook ที่มีแผ่นงานที่ประกอบด้วยข้อมูลแผนภูมิ.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // ดึงแผ่นงานที่มีแผนภูมิ.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // ดึงคอลเลกชัน ChartObjects สำหรับแผ่นงาน.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // ดึงแผนภูมิที่จะคัดลอก.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // สร้าง PowerPoint presentation.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // เพิ่มสไลด์เปล่าลงใน presentation.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // คัดลอกแผนภูมิจากแผ่นงาน Excel ไปยังคลิปบอร์ด.
        existingChartObject.Copy();

        // วางแผนภูมิลงใน PowerPoint presentation.
        shapeRange = pptSlide.Shapes.Paste();

        // กำหนดตำแหน่งแผนภูมิบนสไลด์.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // บันทึก presentation.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // ปล่อยอ็อบเจ็กต์สไลด์ PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // ปิดและปล่อยอ็อบเจ็กต์ Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // ออกจาก PowerPoint และปล่อยอ็อบเจ็กต์ ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // ปล่อยอ็อบเจ็กต์ Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // ปิดและปล่อยอ็อบเจ็กต์ Excel Workbook.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // ออกจาก Excel และปล่อยอ็อบเจ็กต์ ApplicationClass.
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




## **ตัวอย่าง Aspose.Slides for .NET**
โดยใช้ Aspose.Slides for .NET ขั้นตอนต่อไปนี้จะถูกดำเนินการ:

1. สร้าง workbook ด้วย Aspose.Cells for .NET
1. สร้างแผนภูมิ Microsoft Excel
1. กำหนดขนาด OLE ของแผนภูมิ Excel
1. ดึงภาพของแผนภูมิ
1. ฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE ภายในการนำเสนอ PPTX โดยใช้ Aspose.Slides for .NET
1. แทนที่ภาพของวัตถุที่เปลี่ยนแปลงด้วยภาพที่ได้รับในขั้นตอนที่ 3 เพื่อจัดการปัญหาวัตถุที่เปลี่ยนแปลง
1. บันทึกการนำเสนอผลลัพธ์ลงดิสก์ในรูปแบบ PPTX



```c#
using System.Drawing;
using Aspose.Slides;

//Step - 1: สร้างแผนภูมิ Excel ด้วย Aspose.Cells
//--------------------------------------------------
//Create a workbook
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Add an excel chart
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Step - 2: ตั้งค่าขนาด OLE ของแผนภูมิ โดยใช้ Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Step - 3: รับภาพของแผนภูมิด้วย Aspose.Cells
//-----------------------------------------------------------
MemoryStream chartImageStream = new MemoryStream();
wb.Worksheets[chartSheetIndex].Charts[0].ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
Bitmap imgChart = new Bitmap(chartImageStream);
//Save the workbook to stream
MemoryStream wbStream = wb.SaveToStream();
//Step - 4  AND 5
//-----------------------------------------------------------
//Step - 4: ฝังแผนภูมิเป็นอ็อบเจ็กต์ OLE ภายในการนำเสนอ .ppt โดยใช้ Aspose.Slides
//-----------------------------------------------------------
//Step - 5: แทนที่ภาพของวัตถุที่เปลี่ยนแปลงด้วยภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ไขปัญหา Object Changed Issue
//-----------------------------------------------------------
//Create a presentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Add the workbook on slide
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Step - 6: เขียนการนำเสนอผลลัพธ์ลงดิสก์
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

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
    //อาเรย์ของชื่อเซลล์
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //อาเรย์ของข้อมูลเซลล์
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //เพิ่มเวิร์กชีตใหม่เพื่อใส่ข้อมูลลงในเซลล์
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //ใส่ข้อมูลลงใน DataSheet
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //เพิ่มชีตแผนภูมิ
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //เพิ่มแผนภูมิใน ChartSheet ด้วยชุดข้อมูลจาก DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //ตั้งค่า ChartSheet ให้เป็นชีตที่ทำงานอยู่
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```