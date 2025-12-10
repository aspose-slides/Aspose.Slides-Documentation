---
title: تنسيق مخططات العرض التقديمي في .NET
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/net/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخطط
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حد مدور
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides لـ .NET وارتقِ بعرض PowerPoint التقديمي الخاص بك باستخدام تنسيق احترافي وجذاب."
---

## **تنسيق كيانات المخطط**
Aspose.Slides for .NET يتيح للمطورين إضافة مخططات مخصصة إلى شرائحهم من الصفر. يشرح هذا المقال كيفية تنسيق كيانات المخطط المختلفة بما فيها محور الفئة ومحور القيم.

Aspose.Slides for .NET توفر API بسيط لإدارة كيانات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء نسخة من فئة **Presentation**.
1. الحصول على مرجع الشريحة حسب فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (في هذا المثال سنستخدم ChartType.LineWithMarkers).
1. الوصول إلى محور القيم للمخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور القيم.
   1. تعيين **Line format** لخطوط الشبكة الفرعية لمحور القيم.
   1. تعيين **Number Format** لمحور القيم.
   1. تعيين **Min, Max, Major and Minor units** لمحور القيم.
   1. تعيين **Text Properties** لبيانات محور القيم.
   1. تعيين **Title** لمحور القيم.
   1. تعيين **Line Format** لمحور القيم.
1. الوصول إلى محور الفئة للمخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور الفئة.
   1. تعيين **Line format** لخطوط الشبكة الفرعية لمحور الفئة.
   1. تعيين **Text Properties** لبيانات محور الفئة.
   1. تعيين **Title** لمحور الفئة.
   1. تعيين **Label Positioning** لمحور الفئة.
   1. تعيين **Rotation Angle** لتسميات محور الفئة.
1. الوصول إلى وسيلة إيضاح المخطط وتعيين **Text Properties** لها.
1. إظهار وسيلة إيضاح المخطط دون تداخلها مع المخطط.
1. الوصول إلى **Secondary Value Axis** للمخطط وتعيين الخصائص التالية:
   1. تمكين **Value Axis** الثانوي.
   1. تعيين **Line Format** لمحور القيم الثانوي.
   1. تعيين **Number Format** لمحور القيم الثانوي.
   1. تعيين **Min, Max, Major and Minor units** لمحور القيم الثانوي.
1. الآن، رسم السلسلة الأولى للمخطط على محور القيم الثانوي.
1. تعيين لون تعبئة الجدار الخلفي للمخطط.
1. تعيين لون تعبئة منطقة الرسم للمخطط.
1. حفظ العرض التقديمي المعدل إلى ملف PPTX.
```c#
// إنشاء العرض التقديمي// إنشاء العرض التقديمي
Presentation pres = new Presentation();

// الوصول إلى الشريحة الأولى
ISlide slide = pres.Slides[0];

// إضافة المخطط النموذجي
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// تعيين عنوان المخطط
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// تعيين تنسيق خطوط الشبكة الرئيسية لمحور القيم
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// تعيين تنسيق خطوط الشبكة الفرعية لمحور القيم
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// تعيين تنسيق الأرقام لمحور القيم
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// تعيين القيم القصوى والحد الأدنى للمخطط
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// تعيين خصائص نص محور القيم
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// تعيين عنوان محور القيم
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// تعيين تنسيق خط محور القيم : الآن غير صالح
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// تعيين تنسيق خطوط الشبكة الرئيسية لمحور الفئة
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// تعيين تنسيق خطوط الشبكة الفرعية لمحور الفئة
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// تعيين خصائص نص محور الفئة
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// تعيين عنوان الفئة
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// تعيين موضع تسمية محور الفئة
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// تعيين زاوية دوران تسمية محور الفئة
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// تعيين خصائص نص وسيلة الإيضاح
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// إظهار وسيلة إيضاح المخطط دون تداخلها مع المخطط

chart.Legend.Overlay = true;
            
// رسم السلسلة الأولى على محور القيم الثانوي
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// تعيين لون الجدار الخلفي للمخطط
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// تعيين لون منطقة الرسم
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// حفظ العرض التقديمي
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **تعيين خصائص الخط للمخطط**
Aspose.Slides for .NET يوفر دعمًا لتعيين خصائص الخط المتعلقة بالمخطط. يرجى اتباع الخطوات أدناه لتعيين خصائص الخط للمخطط.

- إنشاء كائن من فئة Presentation.
- إضافة مخطط إلى الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض التقديمي المعدل.

مثال نموذجي موضح أدناه.
```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **تعيين التنسيق الرقمي**
Aspose.Slides for .NET يوفر API بسيط لإدارة تنسيق بيانات المخطط:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة حسب فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (هذا المثال يستخدم **ChartType.ClusteredColumn**).
1. تعيين تنسيق الرقم المسبق من القيم المسبقة الممكنة.
1. استعراض خلايا بيانات المخطط في كل سلسلة وتعيين تنسيق رقم البيانات.
1. حفظ العرض التقديمي.
1. تعيين تنسيق رقم مخصص.
1. استعراض خلايا بيانات المخطط داخل كل سلسلة وتعيين تنسيق رقم مختلف لكل منها.
1. حفظ العرض التقديمي.
```c#
// إنشاء العرض التقديمي// إنشاء العرض التقديمي
Presentation pres = new Presentation();

// الوصول إلى الشريحة الأولى للعرض التقديمي
ISlide slide = pres.Slides[0];

// إضافة مخطط عمودي متجمع افتراضي
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// الوصول إلى مجموعة سلاسل المخطط
IChartSeriesCollection series = chart.ChartData.Series;

// تعيين تنسيق الرقم المحدد مسبقًا
// التنقل عبر جميع سلاسل المخطط
foreach (ChartSeries ser in series)
{
    // التنقل عبر كل خلية بيانات في السلسلة
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // تعيين تنسيق الرقم
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// حفظ العرض التقديمي
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


القيم الممكنة لتنسيق الأرقام المسبقة مع الفهرس الخاص بها والتي يمكن استخدامها موضحة أدناه:

|**0**|عام|
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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **تعيين حدود مدورة لمنطقة المخطط**
Aspose.Slides for .NET يوفر دعمًا لتعيين منطقة المخطط. تم إضافة خصائص **IChart.HasRoundedCorners** و **Chart.HasRoundedCorners** في Aspose.Slides.

1. إنشاء كائن من فئة `Presentation`.
1. إضافة مخطط إلى الشريحة.
1. تعيين نوع التعبئة ولون التعبئة للمخطط.
1. تعيين خاصية الزاوية المدورة إلى True.
1. حفظ العرض التقديمي المعدل.
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


## **الأسئلة الشائعة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على الحد غير شفاف؟**  
نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**  
يمكن تقليل حجم الخط، أو إيقاف مكونات التسمية غير الأساسية (مثل الفئات)، أو ضبط إزاحة/موضع التسمية، أو إظهار التسميات فقط لنقاط مختارة إذا لزم الأمر، أو تغيير التنسيق إلى "قيمة + مفتاح".

**هل يمكنني تطبيق تعبئات متدرجة أو نمطية على السلاسل؟**  
نعم. تتوفر عادةً كل من التعبئات الصلبة والمتدرجة/النمطية. في الممارسة العملية، يُنصح باستخدام التدرجات بشكل مقتصد وتجنب الجمع بينهما عندما يقلل ذلك من التباين مع الشبكة والنص.