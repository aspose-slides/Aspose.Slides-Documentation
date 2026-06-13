---
title: สร้างและฝังแผนภูมิ Excel เป็น OLE Object โดยใช้ VSTO และ Aspose.Slides for .NET
linktitle: สร้างและฝังแผนภูมิ Excel เป็น OLE Objects
type: docs
weight: 70
url: /th/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- สร้างแผนภูมิ
- ฝังแผนภูมิ Excel
- วัตถุ OLE
- การย้าย
- VSTO
- ระบบอัตโนมัติของ Office
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ย้ายจากระบบอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides for .NET และฝังแผนภูมิ Excel เป็นวัตถุ OLE ลงในสไลด์ PowerPoint (PPT, PPTX) ด้วย C#."
---
{{% alert color="primary" %}} 

 แผนภูมิคือการแสดงภาพข้อมูลของคุณและถูกใช้กันอย่างแพร่หลายในสไลด์การนำเสนอ บทความนี้จะแสดงโค้ดเพื่อสร้างและฝังแผนภูมิ Excel เป็น OLE Object ในสไลด์ Microsoft PowerPoint อย่างอัตโนมัติโดยใช้ [VSTO](/slides/th/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) และ [Aspose.Slides for .NET](/slides/th/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **สร้างและฝังแผนภูมิ Excel**
ตัวอย่างโค้ดสองชุดด้านล่างยาวและละเอียดเนื่องจากงานที่อธิบายนั้นซับซ้อน คุณจะสร้างเวิร์กบุ๊ค Microsoft Excel, สร้างแผนภูมิ แล้วสร้างพรีเซนเทชัน Microsoft PowerPoint ที่คุณจะฝังแผนภูมิลงไป OLE Object มีลิงก์ไปยังเอกสารต้นฉบับ ดังนั้นผู้ใช้ที่ดับเบิลคลิกไฟล์ที่ฝังไว้จะเปิดไฟล์และแอปพลิเคชันของมัน
## **ตัวอย่าง VSTO**
ใช้ VSTO ขั้นตอนต่อไปนี้จะถูกดำเนินการ:

1. สร้างอินสแตนซ์ของอ็อบเจกต์ Microsoft Excel ApplicationClass
1. สร้างเวิร์กบุ๊คใหม่ที่มีชีตหนึ่งชีต
1. เพิ่มแผนภูมิเข้าในชีต
1. บันทึกเวิร์กบุ๊ค
1. เปิดเวิร์กบุ๊ค Excel ที่มีชีตพร้อมข้อมูลแผนภูมิ
1. รับคอลเลกชัน ChartObjects สำหรับชีตนั้น
1. รับแผนภูมิที่จะคัดลอก
1. สร้างพรีเซนเทชัน Microsoft PowerPoint
1. เพิ่มสไลด์เปล่าลงในพรีเซนเทชัน
1. คัดลอกแผนภูมิจากชีต Excel ไปยังคลิปบอร์ด
1. วางแผนภูมิลงในพรีเซนเทชัน PowerPoint
1. กำหนดตำแหน่งแผนภูมิบนสไลด์
1. บันทึกพรีเซนเทชัน

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
        // สร้างอินสแตนซ์ของอ็อบเจกต์ Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // สร้างเวิร์กบุ๊คใหม่ที่มีชีตหนึ่งชีต.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // เปลี่ยนชื่อของชีต.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // แทรกข้อมูลบางส่วนสำหรับแผนภูมิลงในชีต.
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

        // รับช่วงที่เก็บข้อมูลแผนภูมิ.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // รับคอลเลกชัน ChartObjects สำหรับชีต.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // เพิ่มแผนภูมิลงในคอลเลกชัน.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // สร้างแผนภูมิใหม่จากข้อมูล.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // บันทึกเวิร์กบุ๊ค.
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
    // ประกาศตัวแปรเพื่อเก็บอ้างอิงถึงอ็อบเจกต์ของ PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // ประกาศตัวแปรเพื่อเก็บอ้างอิงถึงอ็อบเจกต์ของ Excel.
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

        // เปิดเวิร์กบุ๊ค Excel ที่มีชีตที่มีข้อมูลแผนภูมิ.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // ดึงชีตที่มีแผนภูมิ.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // ดึงคอลเลกชัน ChartObjects ของชีต.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // ดึงแผนภูมิที่ต้องการคัดลอก.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // สร้างพรีเซนเทชัน PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // เพิ่มสไลด์เปล่าลงในพรีเซนเทชัน.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // คัดลอกแผนภูมิจากชีต Excel ไปยังคลิปบอร์ด.
        existingChartObject.Copy();

        // วางแผนภูมิลงในพรีเซนเทชัน PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // กำหนดตำแหน่งแผนภูมิบนสไลด์.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // บันทึกพรีเซนเทชัน.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // ปล่อยอ็อบเจกต์สไลด์ของ PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // ปิดและปล่อยอ็อบเจกต์ Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // ปิด PowerPoint และปล่อยอ็อบเจกต์ ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // ปล่อยอ็อบเจกต์ Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // ปิดและปล่อยอ็อบเจกต์ Workbook ของ Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // ปิด Excel และปล่อยอ็อบเจกต์ ApplicationClass.
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
ใช้ Aspose.Slides for .NET ขั้นตอนต่อไปนี้จะถูกดำเนินการ:

1. สร้างเวิร์กบุ๊คโดยใช้ Aspose.Cells for .NET
1. สร้างแผนภูมิ Microsoft Excel
1. ตั้งค่า Size ของ OLE สำหรับแผนภูมิ Excel
1. รับภาพของแผนภูมิ
1. ฝังแผนภูมิ Excel เป็น OLE Object ภายในพรีเซนเทชัน PPTX ด้วย Aspose.Slides for .NET
1. แทนที่ภาพวัตถุที่เปลี่ยนแปลงด้วยภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ไขปัญหา object changed
1. เขียนพรีเซนเทชันผลลัพธ์ลงดิสก์ในรูปแบบ PPTX



```c#
//ขั้นตอน - 1: สร้างแผนภูมิ excel using Aspose.Cells
//--------------------------------------------------
//สร้างเวิร์กบุ๊ค
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Add an excel chart
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//ขั้นตอน - 2: ตั้งค่า OLE size ของแผนภูมิโดยใช้ Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//ขั้นตอน - 3: รับภาพของแผนภูมิด้วย Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//บันทึกเวิร์กบุ๊คลงสตรีม
MemoryStream wbStream = wb.SaveToStream();
//ขั้นตอน - 4 และ 5
//-----------------------------------------------------------
//ขั้นตอน - 4: ฝังแผนภูมิเป็น OLE object ภายใน .ppt presentation using Aspose.Slides
//-----------------------------------------------------------
//ขั้นตอน - 5: แทนที่ภาพที่เปลี่ยนแปลงของวัตถุด้วยภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ไขปัญหา Object Changed Issue
//-----------------------------------------------------------
//สร้างพรีเซนเทชัน
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//เพิ่มเวิร์กบุ๊คลงสไลด์
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//ขั้นตอน - 6: เขียนพรีเซนเทชันผลลัพธ์ลงดิสก์
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
    //อาร์เรย์ของชื่อเซลล์
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //อาร์เรย์ของข้อมูลเซลล์
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //เพิ่มแผ่นงานใหม่เพื่อใส่ข้อมูลลงในเซลล์
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
    //เพิ่มแผ่นงานแผนภูมิ
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //เพิ่มแผนภูมิใน ChartSheet โดยใช้ชุดข้อมูลจาก DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //ตั้งค่า ChartSheet ให้เป็นแผ่นงานที่ทำงานอยู่
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```