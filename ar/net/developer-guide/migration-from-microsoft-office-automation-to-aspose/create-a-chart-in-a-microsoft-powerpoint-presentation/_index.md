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
description: "تعلم كيفية أتمتة إنشاء مخططات PowerPoint في C#. يوضح هذا الدليل خطوة بخطوة لماذا Aspose.Slides لـ .NET هو بديل أسرع وأكثر قوة مقارنة بـ Microsoft.Office.Interop."
---

## **نظرة عامة**

هذا المقال يوضح كيفية إنشاء وتخصيص المخططات في عروض Microsoft PowerPoint بشكل برمجي باستخدام C#. مع Aspose.Slides for .NET، يمكنك أتمتة إنشاء مخططات مهنية مبنية على البيانات دون الاعتماد على Microsoft Office أو مكتبات Interop. توفر الواجهة البرمجية مجموعة غنية من الميزات لإنشاء مخططات عمودية، مخططات دائرية، مخططات خطية، والمزيد — مع تحكم كامل في الشكل والبيانات والتنسيق. سواءً كنت تنشئ تقارير، لوحات معلومات، أو عروض عمل، يساعدك Aspose.Slides على تقديم تصورات عالية الجودة مباشرةً من تطبيقات .NET الخاصة بك.

## **مثال VSTO**

هذا القسم يوضح كيفية إنشاء مخطط في عرض PowerPoint باستخدام **VSTO (Visual Studio Tools for Office)**. باستخدام VSTO، يمكنك توليد وتخصيص المخططات برمجياً من خلال دمج أتمتة PowerPoint وExcel. يوضح المثال كيفية إضافة **مخطط عمودي 3D مجمع**، ملئه ببيانات من ورقة عمل Excel، تعديل التنسيق والتخطيط، وحفظ العرض النهائي — كل ذلك من داخل تطبيق .NET.

1. إنشاء كائن عرض تقديمي في Microsoft PowerPoint.  
2. إضافة شريحة فارغة إلى العرض التقديمي.  
3. إضافة مخطط عمودي 3D مجمع والوصول إليه.  
4. إنشاء مثيل جديد لدفتر عمل Microsoft Excel وتحميل بيانات المخطط.  
5. الوصول إلى ورقة بيانات المخطط باستخدام مثيل دفتر عمل Excel.  
6. تحديد نطاق المخطط في ورقة العمل وإزالة السلسلة 2 والسلسلة 3 من المخطط.  
7. تعديل بيانات فئات المخطط في ورقة بيانات المخطط.  
8. تعديل بيانات السلسلة 1 في ورقة بيانات المخطط.  
9. الوصول إلى عنوان المخطط وتعيين خصائص الخط الخاصة به.  
10. الوصول إلى محور القيم في المخطط وتعيين الوحدة الرئيسية، الوحدة الفرعية، القيمة العظمى، والقيمة الصغرى.  
11. الوصول إلى محور العمق (السلسلة) للمخطط وإزالته — يتم استخدام سلسلة واحدة فقط في هذا المثال.  
12. ضبط زوايا دوران المخطط في اتجاهي X و Y.  
13. حفظ العرض التقديمي.  
14. إغلاق مثيلات Microsoft Excel وPowerPoint.  
```c#
EnsurePowerPointIsRunning(true, true);

// Instantiate a slide object.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Access the first presentation slide.
objSlide = objPres.Slides[1];

// Select the first slide and set its layout.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Add a default chart to the slide.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Access the added chart.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Access the chart data.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Create an instance of the Excel workbook to work with the chart data.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Access the data worksheet for the chart.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Set the data range for the chart.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Apply the specified range to the chart data table.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Set values for categories and respective series data.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Set the chart title.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Access the chart value axis.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Set the values for the axis units.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Access the chart depth axis.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Set the chart rotation.
ppChart.Rotation = 20;   // قيمة Y
ppChart.Elevation = 15;  // قيمة X
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX file.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Close the workbook and presentation.
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

    // حاول الوصول إلى الخاصية Name. إذا تم إلقاء استثناء، ابدأ نسخة جديدة من PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // يتم استخدام blnAddPresentation لضمان تحميل عرض تقديمي.
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

    // يتم استخدام blnAddSlide لضمان وجود شريحة واحدة على الأقل في العرض التقديمي.
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

يوضح المثال التالي كيفية إنشاء مخطط بسيط في عرض PowerPoint باستخدام Aspose.Slides for .NET. ي demonstrates how to add a **مخطط عمودي 3D مجمع**، ملئه ببيانات تجريبية، وتخصيص مظهره. مع بضع أسطر من الشفرة، يمكنك توليد مخططات ديناميكيًا ودمجها في عروضك دون الحاجة إلى Microsoft Office.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. الحصول على مرجع إلى الشريحة الأولى.  
3. إضافة مخطط عمودي 3D مجمع والوصول إليه.  
4. الوصول إلى بيانات المخطط.  
5. إزالة السلاسل غير المستخدمة السلسلة 2 والسلسلة 3.  
6. تعديل فئات المخطط عن طريق تحديث التسميات.  
7. تحديث قيم السلسلة 1.  
8. الوصول إلى عنوان المخطط وتعيين خصائص الخط الخاصة به.  
9. تكوين محور قيم المخطط، بما في ذلك الوحدة الرئيسية، الوحدة الفرعية، القيم العظمى والقيم الصغرى.  
10. ضبط زوايا دوران المخطط على محوري X و Y.  
11. حفظ العرض التقديمي بتنسيق PPTX.  
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

نعم. يدعم Aspose.Slides for .NET مجموعة واسعة من [أنواع المخططات](https://docs.aspose.com/slides/net/create-chart/)، بما في ذلك المخططات الدائرية، المخططات الخطية، المخططات الشريطية، المخططات النقطية، مخططات الفقاعات، وأكثر. يمكنك تحديد نوع المخطط المطلوب باستخدام تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) عند إضافة المخطط.

**هل يمكنني تطبيق أنماط أو سمات مخصصة على المخطط؟**

نعم. يمكنك تخصيص مظهر المخطط بالكامل، بما في ذلك الألوان، الخطوط، التعبئة، الحدود، خطوط الشبكة، والتخطيط. ومع ذلك، تطبيق سمات Office بدقة كما تظهر في PowerPoint يتطلب ضبط الأنماط الفردية يدويًا.

**هل يمكنني تصدير المخطط كصورة منفصلة عن الشريحة؟**

نعم، يتيح لك Aspose.Slides تصدير أي شكل — بما في ذلك المخططات — كصورة منفصلة (مثل PNG أو JPEG) باستخدام طريقة `GetImage` على شكل المخطط [shape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).