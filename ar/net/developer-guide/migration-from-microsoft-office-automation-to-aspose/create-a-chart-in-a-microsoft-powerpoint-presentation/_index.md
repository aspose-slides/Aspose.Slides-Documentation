---
title: إنشاء مخططات باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: إنشاء مخطط
type: docs
weight: 80
url: /ar/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- إنشاء مخطط
- ترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية أتمتة إنشاء مخططات PowerPoint باستخدام C#. يوضح هذا الدليل خطوة بخطوة لماذا Aspose.Slides for .NET هو بديل أسرع وأكثر قوة لـ Microsoft.Office.Interop."
---

## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء المخططات وتخصيصها في عروض تقديمية Microsoft PowerPoint برمجيًا باستخدام C#. باستخدام Aspose.Slides for .NET، يمكنك أتمتة إنشاء مخططات احترافية تعتمد على البيانات دون الاعتماد على Microsoft Office أو مكتبات Interop. توفر واجهة برمجة التطبيقات مجموعة غنية من الميزات لبناء مخططات الأعمدة، المخططات الدائرية، مخططات الخطوط، وأكثر — مع تحكم كامل في المظهر والبيانات والتخطيط. سواءً كنت تنشئ تقارير أو لوحات معلومات أو عروض أعمال، يساعدك Aspose.Slides على تقديم تصورات عالية الجودة مباشرةً من تطبيقات .NET الخاصة بك.

## **مثال VSTO**

يوضح هذا القسم كيفية إنشاء مخطط في عرض تقديمي Microsoft PowerPoint باستخدام **VSTO (Visual Studio Tools for Office)**. باستخدام VSTO، يمكنك برمجيًا توليد المخططات وتخصيصها من خلال دمج أتمتة PowerPoint وExcel. تُظهر المثال المقدم كيفية إضافة **مخطط أعمدة ثلاثي الأبعاد متجمع**، تعبئته بالبيانات من ورقة عمل Excel، تعديل التنسيق والتخطيط، وحفظ العرض النهائي — كل ذلك من داخل تطبيق .NET.

1. إنشاء نسخة من عرض تقديمي Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض.
1. إضافة مخطط أعمدة ثلاثي الأبعاد متجمع والوصول إليه.
1. إنشاء نسخة جديدة من مصنف Microsoft Excel وتحميل بيانات المخطط.
1. الوصول إلى ورقة بيانات المخطط باستخدام نسخة مصنف Excel.
1. تحديد نطاق المخطط في ورقة العمل وحذف السلسلة 2 و3 من المخطط.
1. تعديل بيانات فئات المخطط في ورقة بيانات المخطط.
1. تعديل بيانات السلسلة 1 في ورقة بيانات المخطط.
1. الوصول إلى عنوان المخطط وتعيين خصائص الخط الخاصة به.
1. الوصول إلى المحور القيمي للمخطط وتعيين الوحدة الكبرى، الوحدة الصغرى، القيمة القصوى، والقيمة الدنيا.
1. الوصول إلى محور العمق (السلسلة) للمخطط وإزالته — تُستخدم سلسلة واحدة فقط في هذا المثال.
1. تعيين زوايا دوران المخطط في اتجاهي X وY.
1. حفظ العرض التقديمي.
1. إغلاق نسختي Microsoft Excel وPowerPoint.
```c#
EnsurePowerPointIsRunning(true, true);

// إنشاء كائن شريحة.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// الوصول إلى الشريحة الأولى في العرض التقديمي.
objSlide = objPres.Slides[1];

// اختيار الشريحة الأولى وتعيين تخطيطها.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// إضافة مخطط افتراضي إلى الشريحة.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// الوصول إلى المخطط المضاف.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// الوصول إلى بيانات المخطط.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// إنشاء نسخة من مصنف Excel للعمل مع بيانات المخطط.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// الوصول إلى ورقة العمل الخاصة بالبيانات للمخطط.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// تحديد نطاق البيانات للمخطط.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// تطبيق النطاق المحدد على جدول بيانات المخطط.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// تعيين القيم للفئات وبيانات السلاسل المقابلة.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// تعيين عنوان المخطط.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// الوصول إلى محور القيم للمخطط.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// تحديد القيم لوحدات المحور.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// الوصول إلى محور العمق للمخطط.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// تعيين دوران المخطط.
ppChart.Rotation = 20;   // قيمة Y
ppChart.Elevation = 15;  // قيمة X
ppChart.RightAngleAxes = false;

// حفظ العرض التقديمي كملف PPTX.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// إغلاق مصنف Excel والعرض التقديمي.
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

    // حاول الوصول إلى خاصية Name. إذا رُميت استثناءً، ابدأ نسخة جديدة من PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // يُستخدم blnAddPresentation لضمان تحميل عرض تقديمي.
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

    // يُستخدم blnAddSlide لضمان وجود شريحة واحدة على الأقل في العرض التقديمي.
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


النتيجة:

![المخطط الذي تم إنشاؤه باستخدام VSTO](chart-created-using-VSTO.png)

## **مثال Aspose.Slides for .NET**

يوضح المثال التالي كيفية إنشاء مخطط بسيط في عرض تقديمي PowerPoint باستخدام Aspose.Slides for .NET. يُظهر هذا الشيفرة كيفية إضافة **مخطط أعمدة ثلاثي الأبعاد متجمع**، تعبئته ببيانات نموذجية، وتخصيص مظهره. باستخدام بضع أسطر من الشيفرة فقط، يمكنك توليد مخططات ديناميكيًا ودمجها في عروضك دون الحاجة إلى Microsoft Office.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة الأولى.
1. إضافة مخطط أعمدة ثلاثي الأبعاد متجمع والوصول إليه.
1. الوصول إلى بيانات المخطط.
1. إزالة السلسلتين غير المستخدمتين Series 2 وSeries 3.
1. تعديل فئات المخطط بتحديث التسميات.
1. تحديث قيم Series 1.
1. الوصول إلى عنوان المخطط وتعيين خصائص الخط الخاصة به.
1. تكوين محور القيم للمخطط، بما في ذلك الوحدة الكبرى، الوحدة الصغرى، القيم القصوى، والقيم الدنيا.
1. تعيين زوايا دوران المخطط على محوري X وY.
1. حفظ العرض التقديمي بصيغة PPTX.
```cs
// إنشاء عرض تقديمي فارغ.
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة مخطط افتراضي.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // الحصول على بيانات المخطط.
    IChartData chartData = chart.ChartData;

    // إزالة السلسلة الافتراضية الإضافية.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // تعديل أسماء فئات المخطط.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // تعيين فهرس ورقة عمل بيانات المخطط.
    int worksheetIndex = 0;

    // الحصول على دفتر عمل بيانات المخطط.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // تعديل قيم سلاسل المخطط.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // تعيين عنوان المخطط.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // تعيين خيارات المحور.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // تعيين دوران المخطط.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // حفظ العرض التقديمي كملف PPTX.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![المخطط الذي تم إنشاؤه باستخدام Aspose.Slides for .NET](chart-created-using-aspose-slides.png)

## **الأسئلة الشائعة**

**هل يمكنني إنشاء أنواع أخرى من المخططات مثل المخططات الدائرية أو الخطية أو الشريطية باستخدام Aspose.Slides؟**

نعم. يدعم Aspose.Slides for .NET مجموعة واسعة من [أنواع المخططات](https://docs.aspose.com/slides/net/create-chart/)، بما في ذلك المخططات الدائرية، المخططات الخطية، المخططات الشريطية، المخططات المتناثرة، مخططات الفقاعات، وأكثر. يمكنك تحديد نوع المخطط المطلوب باستخدام تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) عند إضافة المخطط.

**هل يمكنني تطبيق أنماط أو سمات مخصصة على المخطط؟**

نعم. يمكنك تخصيص مظهر المخطط بالكامل، بما في ذلك الألوان، الخطوط، التعبئات، الحدود، خطوط الشبكة، والتخطيط. ومع ذلك، تطبيق سمات Office بدقة كما تظهر في PowerPoint يتطلب ضبط الأنماط الفردية يدويًا.

**هل يمكنني تصدير المخطط كصورة منفصلة عن الشريحة؟**

نعم، يتيح Aspose.Slides تصدير أي شكل — بما في ذلك المخططات — كصورة منفصلة (مثل PNG أو JPEG) باستخدام طريقة `GetImage` على [shape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).