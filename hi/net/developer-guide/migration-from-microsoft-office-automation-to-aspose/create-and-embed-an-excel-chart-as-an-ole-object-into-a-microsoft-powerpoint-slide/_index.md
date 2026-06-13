---
title: VSTO और Aspose.Slides for .NET का उपयोग करके Excel चार्ट को OLE ऑब्जेक्ट के रूप में बनाना और एम्बेड करना
linktitle: Excel चार्ट को OLE ऑब्जेक्ट के रूप में बनाना और एम्बेड करना
type: docs
weight: 70
url: /hi/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- चार्ट बनाना
- Excel चार्ट एम्बेड करना
- OLE ऑब्जेक्ट
- माइग्रेशन
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for .NET में माइग्रेट करें और C# में PowerPoint (PPT, PPTX) स्लाइड्स में Excel चार्ट को OLE ऑब्जेक्ट के रूप में एम्बेड करें।"
---
{{% alert color="primary" %}} 
चार्ट आपके डेटा के दृश्य प्रतिनिधित्व हैं और प्रस्तुति स्लाइड्स में व्यापक रूप से उपयोग होते हैं। इस लेख में आप कोड देखेंगे जो प्रोग्रामेटिक रूप से [VSTO](/slides/hi/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) और [Aspose.Slides for .NET](/slides/hi/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) का उपयोग करके Excel चार्ट को OLE ऑब्जेक्ट के रूप में PowerPoint स्लाइड में बनाता और एम्बेड करता है।
{{% /alert %}} 
## **Excel चार्ट बनाना और एम्बेड करना**
नीचे दो कोड उदाहरण लम्बे और विस्तृत हैं क्योंकि वे जिस कार्य का वर्णन कर रहे हैं वह जटिल है। आप एक Microsoft Excel वर्कबुक बनाते हैं, एक चार्ट बनाते हैं और फिर वह Microsoft PowerPoint प्रस्तुति बनाते हैं जिसमें आप चार्ट को एम्बेड करेंगे। OLE ऑब्जेक्ट्स में मूल दस्तावेज़ के लिंक होते हैं इसलिए जब उपयोगकर्ता एम्बेडेड फ़ाइल पर डबल‑क्लिक करता है तो वह फ़ाइल और उसका अनुप्रयोग लॉन्च हो जाता है।
## **VSTO उदाहरण**
Using VSTO, the following steps are performed:

1. Microsoft Excel ApplicationClass ऑब्जेक्ट का एक इंस्टेंस बनाएं।
1. एक नई वर्कबुक बनाएं जिसमें एक शीट हो।
1. शीट में चार्ट जोड़ें।
1. वर्कबुक को सेव करें।
1. चार्ट डेटा वाली शीट वाला Excel वर्कबुक खोलें।
1. शीट के लिए ChartObjects कलेक्शन प्राप्त करें।
1. कॉपी करने के लिए चार्ट प्राप्त करें।
1. Microsoft PowerPoint प्रस्तुति बनाएं।
1. प्रस्तुति में एक खाली स्लाइड जोड़ें।
1. Excel वर्कशीट से चार्ट को क्लिपबोर्ड में कॉपी करें।
1. चार्ट को PowerPoint प्रस्तुति में पेस्ट करें।
1. स्लाइड पर चार्ट का स्थान निर्धारित करें।
1. प्रस्तुति को सेव करें।

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
    // Excel ApplicationClass इंस्टेंस के लिए एक वेरिएबल घोषित करें।
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Workbooks.Open मेथड पैरामीटर्स के लिए वेरिएबल्स घोषित करें।
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Chart.ChartWizard मेथड के लिए वेरिएबल्स घोषित करें।
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Excel ApplicationClass ऑब्जेक्ट का एक इंस्टेंस बनाएं।
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // एक नई वर्कबुक बनाएं जिसमें 1 शीट हो।
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // शीट का नाम बदलें।
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // शीट में चार्ट के लिए कुछ डेटा डालें।
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

        // चार्ट डेटा रखने वाली रेंज प्राप्त करें।
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // शीट के लिए ChartObjects कलेक्शन प्राप्त करें।
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // कलेक्शन में एक चार्ट जोड़ें।
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // डेटा से एक नया चार्ट बनाएं।
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // वर्कबुक को सेव करें।
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
            // Excel को बंद करें।
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // PowerPoint ऑब्जेक्ट्स के रेफ़रेंस रखने वाले वेरिएबल्स घोषित करें।
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Excel ऑब्जेक्ट्स के रेफ़रेंस रखने वाले वेरिएबल्स घोषित करें।
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
        // PowerPoint का एक इंस्टेंस बनाएं।
        powerpointApplication = new pptNS.ApplicationClass();

        // Excel का एक इंस्टेंस बनाएं।
        excelApplication = new xlNS.ApplicationClass();

        // चार्ट डेटा वाली वर्कशीट शामिल करने वाली Excel वर्कबुक खोलें।
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // चार्ट वाली वर्कशीट प्राप्त करें।
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // शीट के लिए ChartObjects कलेक्शन प्राप्त करें।
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // कॉपी करने के लिए चार्ट प्राप्त करें।
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // PowerPoint प्रस्तुति बनाएं।
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // प्रस्तुति में एक खाली स्लाइड जोड़ें।
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Excel वर्कशीट से चार्ट को क्लिपबोर्ड में कॉपी करें।
        existingChartObject.Copy();

        // चार्ट को PowerPoint प्रस्तुति में पेस्ट करें।
        shapeRange = pptSlide.Shapes.Paste();

        // स्लाइड पर चार्ट की स्थिति निर्धारित करें।
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // प्रस्तुति को सेव करें।
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // PowerPoint स्लाइड ऑब्जेक्ट को रिलीज़ करें।
        shapeRange = null;
        pptSlide = null;

        // Presentation ऑब्जेक्ट को बंद करें और रिलीज़ करें।
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // PowerPoint को बंद करें और ApplicationClass ऑब्जेक्ट को रिलीज़ करें।
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Excel ऑब्जेक्ट्स को रिलीज़ करें।
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Excel Workbook ऑब्जेक्ट को बंद करें और रिलीज़ करें।
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Excel को बंद करें और ApplicationClass ऑब्जेक्ट को रिलीज़ करें।
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

## **Aspose.Slides for .NET उदाहरण**
Using Aspose.Slides for .NET, the following steps are performed:

1. Aspose.Cells for .NET का उपयोग करके एक वर्कबुक बनाएं।
1. एक Microsoft Excel चार्ट बनाएं।
1. Excel चार्ट का OLE आकार सेट करें।
1. चार्ट की एक इमेज प्राप्त करें।
1. Aspose.Slides for .NET का उपयोग करके Excel चार्ट को PPTX प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करें।
1. ऑब्जेक्ट बदला गया इमेज को चरण 3 में प्राप्त इमेज से बदलें ताकि ऑब्जेक्ट बदलने की समस्या को हल किया जा सके।
1. आउटपुट प्रस्तुति को PPTX फॉर्मेट में डिस्क पर लिखें।

```c#
//Step - 1: Aspose.Cells का उपयोग करके एक्सेल चार्ट बनाएं
//--------------------------------------------------
//एक वर्कबुक बनाएं
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Add an excel chart
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Step - 2: चार्ट का OLE आकार सेट करें. Aspose.Cells का उपयोग करके
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Step - 3: चार्ट की छवि Aspose.Cells से प्राप्त करें
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Save the workbook to stream
MemoryStream wbStream = wb.SaveToStream();
//Step - 4  AND 5
//-----------------------------------------------------------
//Step - 4: Aspose.Slides का उपयोग करके .ppt प्रस्तुति में चार्ट को OLE ऑब्जेक्ट के रूप में एम्बेड करें
//-----------------------------------------------------------
//Step - 5: ऑब्जेक्ट परिवर्तन समस्या को हल करने के लिए चरण 3 में प्राप्त छवि से ऑब्जेक्ट बदलती छवि को बदलें
//-----------------------------------------------------------
//एक प्रस्तुति बनाएं
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//स्लाइड पर वर्कबुक जोड़ें
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Step - 6: आउटपुट प्रस्तुति को डिस्क पर लिखें
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
    //सेल नामों की ऐरे
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //सेल डेटा की ऐरे
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //डेटा से सेल भरने के लिए एक नई वर्कशीट जोड़ें
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //DataSheet में डेटा भरें
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //एक चार्ट शीट जोड़ें
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //DataSheet से डेटा सीरीज़ के साथ ChartSheet में एक चार्ट जोड़ें
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //ChartSheet को सक्रिय शीट सेट करें
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```