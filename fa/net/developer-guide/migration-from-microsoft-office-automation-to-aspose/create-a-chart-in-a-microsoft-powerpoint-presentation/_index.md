---
title: ایجاد نمودارها با VSTO و Aspose.Slides برای .NET
linktitle: ایجاد نمودار
type: docs
weight: 80
url: /fa/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- ایجاد نمودار
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه ایجاد نمودار PowerPoint را در C# به‌صورت خودکار کنید. این راهنمای گام‌به‌گام نشان می‌دهد چرا Aspose.Slides برای .NET یک جایگزین سریع‌تر و قدرتمندتر نسبت به Microsoft.Office.Interop است."
---
## **مرور کلی**

این مقاله نحوهٔ ایجاد و سفارشی‌سازی نمودارها در ارائه‌های Microsoft PowerPoint را به‌صورت برنامه‌نویسی با C# نشان می‌دهد. با استفاده از Aspose.Slides برای .NET می‌توانید تولید خودکار نمودارهای حرفه‌ای و مبتنی بر داده را بدون نیاز به Microsoft Office یا کتابخانه‌های Interop انجام دهید. این API مجموعه‌ای غنی از ویژگی‌ها برای ساخت نمودارهای ستونی، دایره‌ای، خطی و موارد دیگر فراهم می‌کند — همه با کنترل کامل بر ظاهر، داده و طرح‌بندی. چه در حال تولید گزارش‌ها، داشبوردها یا ارائه‌های تجاری باشید، Aspose.Slides به شما کمک می‌کند تا تجسم‌های با کیفیت بالا را مستقیماً از برنامه‌های .NET خود ارائه کنید.

## **مثال VSTO**

این بخش نشان می‌دهد چگونه می‌توان یک نمودار را در یک ارائه Microsoft PowerPoint با **VSTO (Visual Studio Tools for Office)** ایجاد کرد. با VSTO می‌توانید برنامه‌نویسی کنید تا نمودارها را با ترکیب خودکار PowerPoint و Excel ایجاد و سفارشی کنید. مثال زیر نحوه افزودن یک **نمودار ستونی خوشه‌ای 3 بعدی**، پر کردن آن با داده‌های یک ورک‌شیت Excel، تنظیم قالب‌بندی و طرح‌بندی، و ذخیرهٔ ارائه نهایی را نشان می‌دهد — همه از داخل یک برنامهٔ .NET.

1. یک نمونه از ارائه Microsoft PowerPoint ایجاد کنید.  
2. یک اسلاید خالی به ارائه اضافه کنید.  
3. یک نمودار ستونی خوشه‌ای 3 بعدی افزودن کنید و به آن دسترسی پیدا کنید.  
4. یک نمونه جدید از کتاب کار Microsoft Excel ایجاد کنید و داده‌های نمودار را بارگذاری کنید.  
5. با استفاده از نمونهٔ کتاب کار Excel به ورک‌شیت داده‌های نمودار دسترسی پیدا کنید.  
6. بازهٔ نمودار را در ورک‌شیت تنظیم کنید و سری‌های 2 و 3 را از نمودار حذف کنید.  
7. داده‌های دسته‌بندی نمودار را در ورک‌شیت داده‌های نمودار اصلاح کنید.  
8. داده‌های سری 1 را در ورک‌شیت داده‌های نمودار اصلاح کنید.  
9. به عنوان نمودار دسترسی پیدا کنید و ویژگی‌های مربوط به قلم را تنظیم کنید.  
10. به محور مقدار نمودار دسترسی پیدا کنید و واحد بزرگ، واحد کوچک، حداکثر مقدار و حداقل مقدار را تنظیم کنید.  
11. به محور عمق (سری) نمودار دسترسی پیدا کنید و آن را حذف کنید — فقط یک سری در این مثال استفاده می‌شود.  
12. زوایای چرخش نمودار را در جهت‌های X و Y تنظیم کنید.  
13. ارائه را ذخیره کنید.  
14. نمونه‌های Microsoft Excel و PowerPoint را ببندید.

```c#
EnsurePowerPointIsRunning(true, true);

// نمونه‌ای از یک شی اسلاید ایجاد کنید.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// به اولین اسلاید ارائه دسترسی پیدا کنید.
objSlide = objPres.Slides[1];

// اولین اسلاید را انتخاب کنید و طرح‌بندی آن را تنظیم کنید.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// یک نمودار پیش‌فرض به اسلاید اضافه کنید.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// نمودار اضافه‌شده را دسترسی پیدا کنید.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// داده‌های نمودار را دسترسی پیدا کنید.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// یک نمونه از کتاب کار Excel ایجاد کنید تا با داده‌های نمودار کار کنید.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// به ورک‌شیت داده‌های نمودار دسترسی پیدا کنید.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// بازه داده‌ها را برای نمودار تنظیم کنید.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// بازه مشخص‌شده را به جدول داده‌های نمودار اعمال کنید.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// مقدارهای دسته‌ها و داده‌های سری‌های مربوطه را تنظیم کنید.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// عنوان نمودار را تنظیم کنید.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// به محور مقدار نمودار دسترسی پیدا کنید.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// مقادیر واحدهای محور را تنظیم کنید.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// به محور عمق (سری) نمودار دسترسی پیدا کنید.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// چرخش نمودار را تنظیم کنید.
ppChart.Rotation = 20;   // مقدار Y
ppChart.Elevation = 15;  // مقدار X
ppChart.RightAngleAxes = false;

// کتاب‌کار و ارائه را ببندید.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
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

    // سعی کنید به ویژگی Name دسترسی پیدا کنید. اگر استثنایی رخ داد، یک نمونه جدید از PowerPoint را راه‌اندازی کنید.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation برای اطمینان از بارگذاری یک ارائه استفاده می‌شود.
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

    // blnAddSlide برای اطمینان از وجود حداقل یک اسلاید در ارائه استفاده می‌شود.
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

نتیجه:

![نمودار ایجاد شده با VSTO](chart-created-using-VSTO.png)

## **مثال Aspose.Slides برای .NET**

مثال زیر نشان می‌دهد چگونه می‌توان یک نمودار ساده را در یک ارائه PowerPoint با Aspose.Slides برای .NET ایجاد کرد. این کد نحوه افزودن یک **نمودار ستونی خوشه‌ای 3 بعدی**، پر کردن آن با داده‌های نمونه، و سفارشی‌سازی ظاهر آن را نشان می‌دهد. تنها با چند خط کد می‌توانید نمودارها را به‌صورت پویا تولید کرده و بدون استفاده از Microsoft Office در ارائه‌های خود ادغام کنید.

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
2. به اولین اسلاید ارجاع بگیرید.  
3. یک نمودار ستونی خوشه‌ای 3 بعدی افزودن کنید و به آن دسترسی پیدا کنید.  
4. به داده‌های نمودار دسترسی پیدا کنید.  
5. سری‌های استفاده‌نشده 2 و 3 را حذف کنید.  
6. دسته‌بندی‌های نمودار را با به‌روزرسانی برچسب‌ها اصلاح کنید.  
7. مقادیر سری 1 را به‌روزرسانی کنید.  
8. به عنوان نمودار دسترسی پیدا کنید و ویژگی‌های قلم آن را تنظیم کنید.  
9. محور مقدار نمودار را پیکربندی کنید، شامل واحد بزرگ، واحد کوچک، حداکثر و حداقل مقادیر.  
10. زوایای چرخش نمودار را بر محورهاى X و Y تنظیم کنید.  
11. ارائه را در قالب PPTX ذخیره کنید.

```cs
    // یک ارائه خالی ایجاد کنید.
    using (Presentation presentation = new Presentation())
    {
        // به اولین اسلاید دسترسی پیدا کنید.
        ISlide slide = presentation.Slides[0];

        // یک نمودار پیش‌فرض اضافه کنید.
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

        // داده‌های نمودار را دریافت کنید.
        IChartData chartData = chart.ChartData;

        // سری پیش‌فرض اضافی را حذف کنید.
        chartData.Series.RemoveAt(1);
        chartData.Series.RemoveAt(1);

        // نام‌های دسته‌بندی نمودار را اصلاح کنید.
        chartData.Categories[0].AsCell.Value = "Bikes";
        chartData.Categories[1].AsCell.Value = "Accessories";
        chartData.Categories[2].AsCell.Value = "Repairs";
        chartData.Categories[3].AsCell.Value = "Clothing";

        // شاخص ورک‌شیت داده‌های نمودار را تنظیم کنید.
        int worksheetIndex = 0;

        // کتاب‌کار داده‌های نمودار را دریافت کنید.
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // مقدارهای سری‌های نمودار را اصلاح کنید.
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

        // عنوان نمودار را تنظیم کنید.
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
        IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
        format.FontItalic = NullableBool.True;
        format.FontHeight = 18;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.Black;

        // گزینه‌های محور را تنظیم کنید.
        chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
        chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
        chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
        chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

        chart.Axes.VerticalAxis.MaxValue = 4000.0F;
        chart.Axes.VerticalAxis.MinValue = 0.0F;
        chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
        chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
        chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

        // چرخش نمودار را تنظیم کنید.
        chart.Rotation3D.RotationX = 15;
        chart.Rotation3D.RotationY = 20;

        // ارائه را به‌عنوان فایل PPTX ذخیره کنید.
        presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
    }
```

نتیجه:

![نمودار ایجاد شده با Aspose.Slides برای .NET](chart-created-using-aspose-slides.png)

## **پرسش‌های متداول**

**آیا می‌توانم انواع دیگر نمودارها مانند نمودار دایره‌ای، خطی یا میله‌ای را با Aspose.Slides ایجاد کنم؟**

بله. Aspose.Slides برای .NET طیف گسترده‌ای از [انواع نمودار](/slides/fa/net/create-chart/) را پشتیبانی می‌کند، از جمله نمودارهای دایره‌ای، خطی، میله‌ای، پراکندگی، حبابی و موارد دیگر. می‌توانید نوع موردنظر را با استفاده از شمارندهٔ [ChartType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) در هنگام افزودن نمودار مشخص کنید.

**آیا می‌توانم سبک‌ها یا تم‌های سفارشی را به نمودار اعمال کنم؟**

بله. می‌توانید ظاهر نمودار را به‌طور کامل سفارشی کنید، از جمله رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط حاشیه، خطوط شبکه و طرح‌بندی. با این حال، اعمال دقیق تم‌های Office همان‌طور که در PowerPoint دیده می‌شود، نیازمند تنظیم دستی هر سبک به‌صورت جداگانه است.

**آیا می‌توانم نمودار را به‌صورت تصویر جداگانه از اسلاید استخراج کنم؟**

بله، Aspose.Slides به شما امکان می‌دهد هر شکلی شامل نمودارها را به‌عنوان تصویر جداگانه (مثلاً PNG یا JPEG) با استفاده از متد `GetImage` روی [شکل](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) استخراج کنید.