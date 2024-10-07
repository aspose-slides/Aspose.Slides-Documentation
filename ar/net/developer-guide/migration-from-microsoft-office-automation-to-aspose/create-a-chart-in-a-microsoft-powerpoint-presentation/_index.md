---
title: إنشاء رسم بياني في عرض Microsoft PowerPoint
type: docs
weight: 80
url: /net/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 الرسوم البيانية هي تمثيلات بصرية للبيانات تستخدم على نطاق واسع في العروض التقديمية. توضح هذه المقالة الشيفرة الخاصة بإنشاء رسم بياني في Microsoft PowerPoint برمجيًا باستخدام [VSTO](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) و[Aspose.Slides for .NET](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **إنشاء رسم بياني**
تصف أمثلة الشيفرة أدناه عملية إضافة رسم بياني عمودي مجمع ثلاثي الأبعاد باستخدام VSTO. تقوم بإنشاء حالة عرض، وإضافة رسم بياني افتراضي إليها. ثم تستخدم مصنف Microsoft Excel للوصول إلى بيانات الرسم البياني وتعديلها بالإضافة إلى ضبط خصائص الرسم البياني. وأخيرًا، يتم حفظ العرض.
## **مثال VSTO**
باستخدام VSTO، يتم تنفيذ الخطوات التالية:

1. قم بإنشاء حالة من عرض Microsoft PowerPoint.
1. أضف شريحة فارغة إلى العرض.
1. أضف رسمًا بيانيًا **عموديًا مجمعًا ثلاثي الأبعاد** والوصول إليه.
1. أنشئ حالة جديدة من مصنف Microsoft Excel وقم بتحميل بيانات الرسم البياني.
1. الوصول إلى ورقة بيانات الرسم البياني باستخدام حالة مصنف Microsoft Excel من المصنف.
1. ضبط نطاق الرسم البياني في ورقة العمل وإزالة السلسلتين 2 و3 من الرسم البياني.
1. تعديل فئة بيانات الرسم البياني في ورقة بيانات الرسم البياني.
1. تعديل بيانات السلسلة 1 في ورقة بيانات الرسم البياني.
1. الآن، الوصول إلى عنوان الرسم البياني وضبط خصائص الخط المتعلقة به.
1. الوصول إلى محور قيمة الرسم البياني وضبط الوحدة الرئيسية والوحدات الثانوية والقيمة القصوى والقيم الدنيا.
1. الوصول إلى محور العمق أو محور السلاسل وإزالته حيث في هذا المثال، تستخدم سلسلة واحدة فقط.
1. الآن، اضبط زوايا دوران الرسم البياني في اتجاهي X وY.
1. احفظ العرض.
1. أغلق حالات Microsoft Excel وPowerPoint.

**العرض الناتج، الذي تم إنشاؤه باستخدام VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



```c#
EnsurePowerPointIsRunning(true, true);

//Instantiate slide object
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

//Access the first slide of presentation
objSlide = objPres.Slides[1];

//Select firs slide and set its layout
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

//Add a default chart in slide
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

//Access the added chart
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

//Access the chart data
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

//Create instance to Excel workbook to work with chart data
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

//Accessing the data worksheet for chart
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

//Setting the range of chart
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

//Applying the set range on chart data table
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

//Setting values for categories and respective series data

((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "دراجات";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "إكسسوارات";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "إصلاحات";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "ملابس";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

//Setting chart title
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "مبيعات 2007";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

//Accessing Chart value axis
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

//Setting values axis units
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

//Accessing Chart Depth axis
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

//Setting chart rotation
ppChart.Rotation = 20; //Y-Value
ppChart.Elevation = 15; //X-Value
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX
objPres.SaveAs("C:\\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
//objPres.SaveAs(@"..\..\..\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

//Close Workbook and presentation
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
    //
    //Try accessing the name property. If it causes an exception then
    //start a new instance of PowerPoint
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }
    //
    //blnAddPresentation is used to ensure there is a presentation loaded
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
    //
    //BlnAddSlide is used to ensure there is at least one slide in the
    //presentation
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




## **مثال Aspose.Slides for .NET**
باستخدام Aspose.Slides for .NET، يتم تنفيذ الخطوات التالية:

1. قم بإنشاء حالة من عرض Microsoft PowerPoint.
1. أضف شريحة فارغة إلى العرض.
1. أضف رسمًا بيانيًا **عموديًا مجمعًا ثلاثي الأبعاد** والوصول إليه.
1. الوصول إلى ورقة بيانات الرسم البياني باستخدام حالة مصنف Microsoft Excel من المصنف.
1. إزالة السلسلتين 2 و3 غير المستخدمتين.
1. الوصول إلى فئات الرسم البياني وتعديل الملصقات.
1. الوصول إلى السلسلة 1 وتعديل قيم السلسلة.
1. الآن، الوصول إلى عنوان الرسم البياني وضبط خصائص الخط.
1. الوصول إلى محور قيمة الرسم البياني وضبط الوحدة الرئيسية والوحدات الثانوية والقيمة القصوى والقيم الدنيا.
1. الآن، اضبط زوايا دوران الرسم البياني في اتجاهي X وY.
1. حفظ العرض في تنسيق PPTX.

**العرض الناتج، الذي تم إنشاؤه باستخدام Aspose.Slides**

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

```csharp
//Create empty presentation
using (Presentation pres = new Presentation())
{

    //Accessing first slide
    ISlide slide = pres.Slides[0];

    //Addding default chart
    IChart ppChart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20F, 30F, 400F, 300F);

    //Getting Chart data
    IChartData chartData = ppChart.ChartData;

    //Removing Extra default series
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    //Modifying chart categories names
    chartData.Categories[0].AsCell.Value = "دراجات";
    chartData.Categories[1].AsCell.Value = "إكسسوارات";
    chartData.Categories[2].AsCell.Value = "إصلاحات";
    chartData.Categories[3].AsCell.Value = "ملابس";

    //Setting the index of chart data sheet
    int defaultWorksheetIndex = 0;


    //Getting the chart data worksheet
    IChartDataWorkbook fact = ppChart.ChartData.ChartDataWorkbook;

    //Modifying chart series values for first category
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, 3000));

    //Setting Chart title
    ppChart.HasTitle = true;
    ppChart.ChartTitle.AddTextFrameForOverriding("مبيعات 2007");
    IPortionFormat format = ppChart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;


    ////Setting Axis values
    ppChart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    ppChart.Axes.VerticalAxis.MaxValue = 4000.0F;
    ppChart.Axes.VerticalAxis.MinValue = 0.0F;
    ppChart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    ppChart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    ppChart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    //Setting Chart rotation
    ppChart.Rotation3D.RotationX = 15;
    ppChart.Rotation3D.RotationY = 20;

    //Saving Presentation
    pres.Save("AsposeSampleChart.pptx", SaveFormat.Pptx);
}
```



{{% alert color="primary" %}} 

## **الموارد**
يمكن تنزيل المشاريع والملفات المستخدمة في هذه المقالة من موقعنا الإلكتروني:

- [تحميل العرض الذي تم إنشاؤه بواسطة VSTO](http://docs.aspose.com:8082/docs/download/attachments/87523560/VSTOSampleChart.pptx).
- [تحميل الرسم البياني النموذجي الذي تم إنشاؤه بواسطة Aspose.Slides](http://docs.aspose.com:8082/docs/download/attachments/87523560/AsposeSampleChart.pptx).

{{% /alert %}}