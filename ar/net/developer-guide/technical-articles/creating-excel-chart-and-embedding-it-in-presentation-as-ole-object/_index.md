---
title: إنشاء مخطط Excel وتضمينه في العرض التقديمي ككائن OLE
type: docs
weight: 50
url: /ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

في شرائح PowerPoint، يُعتبر استخدام المخططات القابلة للتعديل لعرض البيانات بشكل رسومي نشاطًا شائعًا. توفر Aspose دعمًا لإنشاء مخططات Excel باستخدام Aspose.Cells لـ .NET، ومن ثم يمكن تضمين هذه المخططات ككائن OLE في شريحة PowerPoint من خلال Aspose.Slides لـ .NET. تغطي هذه المقالة الخطوات المطلوبة مع التنفيذ في C# و VB.NET لإنشاء وتضمين مخطط MS Excel ككائن OLE في العرض التقديمي لـ PowerPoint باستخدام Aspose.Cells لـ .NET و Aspose.Slides لـ .NET.

{{% /alert %}} 
## **الخطوات المطلوبة**
تتطلب سلسلة الخطوات التالية إنشاء وتضمين مخطط Excel ككائن OLE في شريحة PowerPoint:

1. إنشاء مخطط Excel باستخدام Aspose.Cells لـ .NET.
2. تعيين حجم OLE لمخطط Excel باستخدام Aspose.Cells لـ .NET.
3. الحصول على صورة لمخطط Excel باستخدام Aspose.Cells لـ .NET.
4. تضمين مخطط Excel ككائن OLE داخل العرض التقديمي PPTX باستخدام Aspose.Slides لـ .NET.
5. استبدال صورة الكائن المتغير بالصورة التي تم الحصول عليها في الخطوة 3 لمعالجة مشكلة تغيير الكائن.
6. كتابة العرض التقديمي الناتج إلى القرص بتنسيق PPTX.

## **تنفيذ الخطوات المطلوبة**
يتم تنفيذ الخطوات أعلاه في C# و Visual Basic كما يلي:

```c#
// الخطوة - 1: إنشاء مخطط Excel باستخدام Aspose.Cells
//--------------------------------------------------
// إنشاء مصنف
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
// إضافة مخطط Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
// الخطوة - 2: تعيين حجم OLE للمخطط باستخدام Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
// الخطوة - 3: الحصول على صورة المخطط باستخدام Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
// حفظ المصنف إلى الدفق
MemoryStream wbStream = wb.SaveToStream();
// الخطوة - 4 و 5
//-----------------------------------------------------------
// الخطوة - 4: تضمين المخطط ككائن OLE داخل العرض التقديمي .ppt باستخدام Aspose.Slides
//-----------------------------------------------------------
// الخطوة - 5: استبدال صورة الكائن المتغير بالصورة التي تم الحصول عليها في الخطوة 3 لمعالجة مشكلة تغيير الكائن
//-----------------------------------------------------------
// إنشاء عرض تقديمي
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
// إضافة المصنف على الشريحة
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
// الخطوة - 6: كتابة العرض التقديمي الناتج على القرص
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    // مصفوفة من أسماء الخلايا
    string[] cellsName = new string[] 
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    // مصفوفة من قيم الخلايا
    int[] cellsValue = new int[] 
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    // إضافة ورقة عمل جديدة لملء الخلايا بالبيانات
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    // ملء DataSheet بالبيانات
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    // إضافة ورقة مخطط
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    // إضافة مخطط في ChartSheet مع سلسلة البيانات من DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    // تعيين ChartSheet كورقة نشطة
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```

```c#
static void AddExcelChartInPresentation(Presentation pres, ISlide sld, Stream wbStream, Bitmap imgChart)
{
    float oleWidth = pres.SlideSize.Size.Width;
    float oleHeight = pres.SlideSize.Size.Height;

    byte[] chartOleData = new byte[wbStream.Length];
    wbStream.Position = 0;
    wbStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oof = sld.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage ppImage = pres.Images.AddImage(imageStream);

        oof.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

{{% alert color="primary" %}} 

سيحمل العرض التقديمي الذي تم إنشاؤه من خلال الطريقة أعلاه مخطط Excel ككائن OLE يمكن تفعيله عن طريق النقر المزدوج فوق إطار كائن OLE.

{{% /alert %}} 
## **الخاتمة**
{{% alert color="primary" %}} 

من خلال استخدام Aspose.Cells لـ .NET جنبًا إلى جنب مع Aspose.Slides لـ .NET، يمكننا إنشاء أي من مخططات Excel المدعومة من قبل Aspose.Cells لـ .NET وتضمين المخطط الذي تم إنشاؤه ككائن OLE في شريحة PowerPoint. يمكن أيضًا تحديد حجم OLE لمخطط Excel. يمكن لمستخدمي النهاية تعديل مخطط Excel مثل أي كائن OLE آخر.

{{% /alert %}} 
## **الأقسام ذات الصلة**
[حل عملي لتعديل حجم المخطط](/slides/ar/net/working-solution-for-chart-resizing-in-pptx/)[مشكلة الكائن المتغير](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)