---
title: قالب‌بندی نمودارهای ارائه در .NET
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/net/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- لبه گرد
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قالب‌بندی نمودارها را در Aspose.Slides برای .NET بیاموزید و ارائهٔ پاورپوینت خود را با استایل حرفه‌ای و چشم‌نوازی ارتقا دهید."
---
## **مروری کلی**

این مقاله نحوه قالب‌بندی نمودارها در ارائه‌های PowerPoint را با استفاده از Aspose.Slides توضیح می‌دهد. نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، افسانه‌ها، ناحیه‌نقشه و پر کردن دیوارها را شخصی‌سازی کنید تا ظاهر و خوانایی داده‌های نمودار بهبود یابد.

همچنین نحوه تنظیم ویژگی‌های قلم برای متن نمودار، اعمال قالب‌های عددی پیش‌تنظیم‌شده و سفارشی به داده‌های نمودار، و فعال‌سازی گوشه‌های گرد برای ناحیه نمودار را نشان می‌دهد. این مثال‌ها نشان می‌دهند چگونه هم سبک بصری و هم ارائه داده‌های نمودار را در یک ارائه کنترل کنید.

## **قالب‌بندی موجودیت‌های نمودار**
Aspose.Slides برای .NET به توسعه‌دهندگان امکان می‌دهد نمودارهای سفارشی را از ابتدا به اسلایدهای خود اضافه کنند. این مقاله نحوه قالب‌بندی موجودیت‌های مختلف نمودار از جمله محور دسته‌بندی و محور مقدار را توضیح می‌دهد.

Aspose.Slides برای .NET یک API ساده برای مدیریت موجودیت‌های مختلف نمودار و قالب‌بندی آنها با مقادیر سفارشی فراهم می‌کند:

1. یک نمونه از کلاس **Presentation** ایجاد کنید.  
1. مرجع اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (در این مثال از **ChartType.LineWithMarkers** استفاده می‌کنیم).  
1. به **Value Axis** نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:  
   1. تنظیم **Line format** برای خطوط مشبک بزرگ (Major) Value Axis  
   1. تنظیم **Line format** برای خطوط مشبک کوچک (Minor) Value Axis  
   1. تنظیم **Number Format** برای Value Axis  
   1. تنظیم **Min, Max, Major and Minor units** برای Value Axis  
   1. تنظیم **Text Properties** برای داده‌های Value Axis  
   1. تنظیم **Title** برای Value Axis  
   1. تنظیم **Line Format** برای Value Axis  
1. به **Category Axis** نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:  
   1. تنظیم **Line format** برای خطوط مشبک بزرگ (Major) Category Axis  
   1. تنظیم **Line format** برای خطوط مشبک کوچک (Minor) Category Axis  
   1. تنظیم **Text Properties** برای داده‌های Category Axis  
   1. تنظیم **Title** برای Category Axis  
   1. تنظیم **Label Positioning** برای Category Axis  
   1. تنظیم **Rotation Angle** برای برچسب‌های Category Axis  
1. به **Legend** نمودار دسترسی پیدا کنید و **Text Properties** آن را تنظیم کنید  
1. نمایش افسانه‌های نمودار را بدون همپوشانی با نمودار تنظیم کنید  
1. به **Secondary Value Axis** نمودار دسترسی پیدا کنید و ویژگی‌های زیر را تنظیم کنید:  
   1. فعال‌سازی **Value Axis** ثانویه  
   1. تنظیم **Line Format** برای Secondary Value Axis  
   1. تنظیم **Number Format** برای Secondary Value Axis  
   1. تنظیم **Min, Max, Major and Minor units** برای Secondary Value Axis  
1. اکنون سری نمودار اول را روی Secondary Value Axis رسم کنید  
1. رنگ پر کردن دیوار پشت نمودار را تنظیم کنید  
1. رنگ پر کردن ناحیه‌نقشه نمودار را تنظیم کنید  
1. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید  

```c#
// در حال ایجاد ارائه// در حال ایجاد ارائه
Presentation pres = new Presentation();

// دسترسی به اسلاید اول
ISlide slide = pres.Slides[0];

// افزودن نمودار نمونه
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// تنظیم عنوان نمودار
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// تنظیم قالب خطوط شبکه بزرگ برای محور مقدار
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// تنظیم قالب خطوط شبکه کوچک برای محور مقدار
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// تنظیم قالب عددی محور مقدار
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// تنظیم مقادیر حداکثر و حداقل نمودار
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// تنظیم ویژگی‌های متن محور مقدار
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// تنظیم عنوان محور مقدار
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// تنظیم قالب خط محور مقدار : اکنون منسوخ شده
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// تنظیم قالب خطوط شبکه بزرگ برای محور دسته‌بندی
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// تنظیم قالب خطوط شبکه کوچک برای محور دسته‌بندی
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// تنظیم ویژگی‌های متن محور دسته‌بندی
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// تنظیم عنوان دسته‌بندی
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// تنظیم موقعیت برچسب محور دسته‌بندی
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// تنظیم زاویه چرخش برچسب محور دسته‌بندی
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// تنظیم ویژگی‌های متن افسانه‌ها
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// تنظیم نمایش افسانه‌های نمودار بدون همپوشانی با نمودار

chart.Legend.Overlay = true;
            
// رسم اولین سری بر روی محور مقدار ثانویه
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// تنظیم رنگ دیوار پشت نمودار
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// تنظیم رنگ ناحیه‌نقشه
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// ذخیره ارائه
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **تنظیم ویژگی‌های قلم برای یک نمودار**
Aspose.Slides برای .NET پشتیبانی از تنظیم ویژگی‌های مرتبط با قلم برای نمودار را فراهم می‌کند. لطفاً برای تنظیم ویژگی‌های قلم برای نمودار مراحل زیر را دنبال کنید.

- شیء کلاس **Presentation** را نمونه‌سازی کنید.  
- یک نمودار را به اسلاید اضافه کنید.  
- ارتفاع قلم را تنظیم کنید.  
- ارائه اصلاح‌شده را ذخیره کنید.

یک مثال نمونه در زیر آورده شده است.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```

## **تنظیم قالب عددی**
Aspose.Slides برای .NET یک API ساده برای مدیریت قالب داده‌های نمودار فراهم می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. مرجع اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک نمودار با داده‌های پیش‌فرض به همراه هر نوع دلخواه اضافه کنید (در این مثال از **ChartType.ClusteredColumn** استفاده می‌شود).  
1. قالب عددی پیش‌تنظیم‌شده را از مقادیر ممکن انتخاب کنید.  
1. در هر سری از داده‌های نمودار، سلول‌های داده را پیمایش کرده و قالب عددی داده‌های نمودار را تنظیم کنید.  
1. ارائه را ذخیره کنید.  
1. قالب عددی سفارشی را تنظیم کنید.  
1. در هر سری از داده‌های نمودار، سلول‌های داده را پیمایش کرده و قالب عددی متفاوتی اعمال کنید.  
1. ارائه را ذخیره کنید.

```c#
// نمادسازی ارائه// نمادسازی ارائه
Presentation pres = new Presentation();

// دسترسی به اولین اسلاید ارائه
ISlide slide = pres.Slides[0];

// افزودن یک نمودار ستونی خوشه‌ای پیش‌فرض
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// دسترسی به مجموعهٔ سری‌های نمودار
IChartSeriesCollection series = chart.ChartData.Series;

// تنظیم قالب عددی پیش‌تنظیم‌شده
// پیمایش در هر سری از نمودار
foreach (ChartSeries ser in series)
{
    // پیمایش در هر سلول داده‌ای در سری
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // تنظیم قالب عددی
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// ذخیرهٔ ارائه
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

مقدارهای ممکن قالب عددی پیش‌تنظیم‌شده به همراه شاخص پیش‌تنظیم‌شده‌ای که می‌توانند استفاده شوند، در جدول زیر آمده‌اند:

|**0**|عمومی|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **تنظیم گوشه‌های گرد ناحیه نمودار**
Aspose.Slides برای .NET پشتیبانی از تنظیم ناحیه نمودار را فراهم می‌کند. ویژگی‌های **IChart.HasRoundedCorners** و **Chart.HasRoundedCorners** در Aspose.Slides اضافه شده‌اند.

1. شیء کلاس `Presentation` را نمونه‌سازی کنید.  
1. یک نمودار را به اسلاید اضافه کنید.  
1. نوع پر کردن و رنگ پر کردن نمودار را تنظیم کنید.  
1. ویژگی گوشه‌های گرد را برابر **True** تنظیم کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.

یک مثال نمونه در زیر آورده شده است.

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا می‌توانم پرکننده‌های نیمه‌شفاف برای ستون‌ها/نواحی تنظیم کنم در حالی که حاشیه شفاف باقی می‌ماند؟**

بله. شفافیت پرکننده و خطوط حاشیه به‌طور جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در نمایه‌های متراکم مفید است.

**چگونه می‌توانم با برچسب‌های داده که همپوشانی دارند برخورد کنم؟**

اندازه قلم را کاهش دهید، اجزای غیرضروری برچسب (مانند دسته‌ها) را غیرفعال کنید، جابجایی/موقعیت برچسب را تنظیم کنید، در صورت لزوم فقط برای نقاط انتخاب شده برچسب نشان دهید یا قالب را به «مقدار + افسانه» تغییر دهید.

**آیا می‌توانم پرکننده‌های گرادیان یا الگو را به سری‌ها اعمال کنم؟**

بله. هر دو نوع پرکنندهٔ ثابت و گرادیان/الگو معمولاً در دسترس هستند. در عمل، از گرادیان‌ها به‌صورت محدود استفاده کنید و ترکیب‌هایی که کنتراست را با شبکه و متن کاهش می‌دهند، اجتناب کنید.