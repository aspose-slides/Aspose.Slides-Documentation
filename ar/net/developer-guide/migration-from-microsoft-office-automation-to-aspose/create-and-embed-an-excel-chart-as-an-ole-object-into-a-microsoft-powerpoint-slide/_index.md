---
title: إنشاء وإدراج مخطط Excel ككائن OLE في شريحة Microsoft PowerPoint
type: docs
weight: 70
url: /ar/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

المخططات هي تمثيلات بصرية لبياناتك وتستخدم على نطاق واسع في شرائح العروض التقديمية. ستوضح لك هذه المقالة الكود لإنشاء وإدراج مخطط Excel ككائن OLE في شريحة PowerPoint برمجيًا باستخدام [VSTO](/slides/ar/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) و [Aspose.Slides for .NET](/slides/ar/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **إنشاء وإدراج مخطط Excel**
أمثلة الكود أدناه طويلة ومفصلة لأن المهمة التي تصفها معقدة. ستقوم بإنشاء مصنف Microsoft Excel، إنشاء مخطط ثم إنشاء عرض تقديمي Microsoft PowerPoint الذي ستدرج فيه المخطط. تحتوي كائنات OLE على روابط للمستند الأصلي بحيث يمكن للمستخدم الذي ينقر مرتين على الملف المدسوس فتح الملف وتطبيقه.
## **مثال VSTO**
باستخدام VSTO، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل لكائن Microsoft Excel ApplicationClass.
1. إنشاء مصنف جديد يحتوي على ورقة واحدة.
1. إضافة مخطط إلى الورقة.
1. حفظ المصنف.
1. فتح مصنف Excel الذي يحتوي على الورقة مع بيانات المخطط.
1. الحصول على مجموعة ChartObjects للورقة.
1. الحصول على المخطط للنسخ.
1. إنشاء عرض تقديمي Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. نسخ المخطط من ورقة Excel إلى الحافظة.
1. لصق المخطط في عرض PowerPoint.
1. موضع المخطط على الشريحة.
1. حفظ العرض التقديمي.

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
    // إعلان متغير لمثيل Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // إعلان المتغيرات لبارامترات Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // إعلان المتغيرات لطريقة Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "المبيعات حسب الربع";
    object paramCategoryTitle = "الربع المالي";
    object paramValueTitle = "المليارات";

    try
    {
        // إنشاء مثيل لكائن Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // إنشاء مصنف جديد يحتوي على ورقة واحدة.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // تغيير اسم الورقة.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "مبيعات ربع سنوية";

        // إدراج بعض البيانات للمخطط في الورقة.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    أمريكا الشمالية  1.5     2       1.5     2.5
        //     3    أمريكا الجنوبية  2       1.75    2       2
        //     4    أوروبا      2.25    2       2.5     2
        //     5    آسيا        2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "أمريكا الشمالية");
        SetCellValue(targetSheet, "A3", "أمريكا الجنوبية");
        SetCellValue(targetSheet, "A4", "أوروبا");
        SetCellValue(targetSheet, "A5", "آسيا");

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

        // الحصول على المدى الذي يحتوي على بيانات المخطط.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // الحصول على مجموعة ChartObjects للورقة.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // إضافة مخطط إلى المجموعة.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "مخطط المبيعات";

        // إنشاء مخطط جديد من البيانات.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // حفظ المصنف.
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
            // إغلاق Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // إعلان المتغيرات للاحتفاظ بالإشارات إلى كائنات PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // إعلان المتغيرات للاحتفاظ بالإشارات إلى كائنات Excel.
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
        // إنشاء مثيل لبرنامج PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // إنشاء مثيل لـ Excel.
        excelApplication = new xlNS.ApplicationClass();

        // فتح مصنف Excel الذي يحتوي على الورقة مع بيانات المخطط.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // الحصول على الورقة التي تحتوي على المخطط.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["مبيعات ربع سنوية"]);

        // الحصول على مجموعة ChartObjects للورقة.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // الحصول على المخطط للنسخ.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("مخطط المبيعات"));

        // إنشاء عرض تقديمي PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // إضافة شريحة فارغة إلى العرض التقديمي.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // نسخ المخطط من ورقة Excel إلى الحافظة.
        existingChartObject.Copy();

        // لصق المخطط في عرض PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // موضع المخطط على الشريحة.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // حفظ العرض التقديمي.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // تحرير كائن شريحة PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // إغلاق وتحرير كائن العرض التقديمي.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // إنهاء PowerPoint وتحرير كائن ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // تحرير كائنات Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // إغلاق وتحرير كائن مصنف Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // إنهاء Excel وتحرير كائن ApplicationClass.
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




## **مثال Aspose.Slides for .NET**
باستخدام Aspose.Slides for .NET، يتم تنفيذ الخطوات التالية:

1. إنشاء مصنف باستخدام Aspose.Cells for .NET.
1. إنشاء مخطط Excel.
1. تعيين حجم OLE لمخطط Excel.
1. الحصول على صورة للمخطط.
1. إدراج مخطط Excel ككائن OLE داخل عرض PPTX باستخدام Aspose.Slides for .NET.
1. استبدال صورة الكائن المتغير بالصورة التي تم الحصول عليها في الخطوة 3 للتعامل مع مشكلة تغيير الكائن.
1. كتابة العرض الناتج إلى القرص بتنسيق PPTX.



```c#
//الخطوة - 1: إنشاء مخطط Excel باستخدام Aspose.Cells
//--------------------------------------------------
//إنشاء مصنف
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//إضافة مخطط Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//الخطوة - 2: تعيين حجم OLE للمخطط. باستخدام Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//الخطوة - 3: الحصول على صورة المخطط باستخدام Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//حفظ المصنف إلى التدفق
MemoryStream wbStream = wb.SaveToStream();
//الخطوة - 4  وَ 5
//-----------------------------------------------------------
//الخطوة - 4: إدراج المخطط ككائن OLE داخل عرض .ppt باستخدام Aspose.Slides
//-----------------------------------------------------------
//الخطوة - 5: استبدال صورة الكائن المتغير بالصورة التي تم الحصول عليها في الخطوة 3 للتعامل مع مشكلة تغيير الكائن
//-----------------------------------------------------------
//إنشاء عرض تقديمي
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//إضافة المصنف على الشريحة
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//الخطوة - 6: كتابة العرض الناتج على القرص
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
    //مصفوفة أسماء الخلايا
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //مصفوفة بيانات الخلايا
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //إضافة ورقة عمل جديدة لتعبئة الخلايا بالبيانات
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "ورقة البيانات";
    dataSheet.Name = sheetName;
    //تعبئة ورقة البيانات بالبيانات
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //إضافة ورقة مخطط
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ورقة المخطط";
    //إضافة مخطط في ورقة المخطط مع سلسلة البيانات من ورقة البيانات
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //تعيين ورقة المخطط كعامل نشط
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```