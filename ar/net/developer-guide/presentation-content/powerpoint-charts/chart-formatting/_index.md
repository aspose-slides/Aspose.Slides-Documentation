---
title: تنسيق مخططات العروض التقديمية في .NET
linktitle: تنسيق المخططات
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
- حدود مستديرة
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides لـ .NET وارتقِ بعرض PowerPoint التقديمي باستخدام تنسيق احترافي وجذاب."
---

## **تنسيق كيانات المخطط**
يتيح Aspose.Slides for .NET للمطورين إضافة مخططات مخصصة إلى الشرائح من الصفر. يشرح هذا المقال طريقة تنسيق كيانات المخطط المختلفة بما في ذلك محور الفئة ومحور القيم.

Aspose.Slides for .NET يوفر واجهة برمجة تطبيقات بسيطة لإدارة كيانات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء كائن من الفئة **Presentation**.
1. الحصول على مرجع الشريحة بواسطة فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (في هذا المثال سنستخدم ChartType.LineWithMarkers).
1. الوصول إلى محور القيمة للمخطط وتعيين الخصائص التالية:
   1. ضبط **Line format** لخطوط الشبكة الرئيسية لمحور القيمة
   1. ضبط **Line format** لخطوط الشبكة الثانوية لمحور القيمة
   1. ضبط **Number Format** لمحور القيمة
   1. ضبط **Min, Max, Major and Minor units** لمحور القيمة
   1. ضبط **Text Properties** لبيانات محور القيمة
   1. ضبط **Title** لمحور القيمة
   1. ضبط **Line Format** لمحور القيمة
1. الوصول إلى محور الفئة للمخطط وتعيين الخصائص التالية:
   1. ضبط **Line format** لخطوط الشبكة الرئيسية لمحور الفئة
   1. ضبط **Line format** لخطوط الشبكة الثانوية لمحور الفئة
   1. ضبط **Text Properties** لبيانات محور الفئة
   1. ضبط **Title** لمحور الفئة
   1. ضبط **Label Positioning** لمحور الفئة
   1. ضبط **Rotation Angle** لتسميات محور الفئة
1. الوصول إلى مفتاح المخطط وتعيين **Text Properties** له
1. ضبط إظهار مفتاح المخطط بدون تداخل مع المخطط
1. الوصول إلى **Secondary Value Axis** للمخطط وتعيين الخصائص التالية:
   1. تفعيل **Value Axis** الثانوي
   1. ضبط **Line Format** لـ **Secondary Value Axis**
   1. ضبط **Number Format** لـ **Secondary Value Axis**
   1. ضبط **Min, Max, Major and Minor units** لـ **Secondary Value Axis**
1. الآن ارسم السلسلة الأولى للمخطط على **Secondary Value Axis**
1. ضبط لون تعبئة الجدار الخلفي للمخطط
1. ضبط لون تعبئة منطقة الرسم للمخطط
1. احفظ العرض المعدل إلى ملف PPTX
```c#
// إنشاء العرض التقديمي// إنشاء العرض التقديمي
Presentation pres = new Presentation();

// Accessing the first slide
// الوصول إلى الشريحة الأولى
ISlide slide = pres.Slides[0];

// Adding the sample chart
// إضافة المخطط النموذجي
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
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

// Setting Major grid lines format for value axis
// تعيين تنسيق خطوط الشبكة الرئيسية لمحور القيم
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
// تعيين تنسيق خطوط الشبكة الثانوية لمحور القيم
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
// تعيين تنسيق أرقام محور القيم
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
// تعيين القيم القصوى والحد الأدنى للمخطط
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
// تعيين خصائص نص محور القيم
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
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

// Setting value axis line format : Now Obselete
// تعيين تنسيق خط محور القيم : الآن غير صالح
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
// تعيين تنسيق خطوط الشبكة الرئيسية لمحور الفئة
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
// تعيين تنسيق خطوط الشبكة الثانوية لمحور الفئة
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
// تعيين خصائص نص محور الفئة
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
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

// Setting category axis lable position
// تعيين موضع تسمية محور الفئة
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
// تعيين زاوية دوران تسمية محور الفئة
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
// تعيين خصائص نص وسيلة الإيضاح
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart
// تحديد إظهار وسائط الإيضاح للمخطط دون تداخل مع المخطط

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// رسم السلسلة الأولى على محور القيم الثانوي
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
// تعيين لون الجدار الخلفي للمخطط
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
// تعيين لون منطقة الرسم
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
// حفظ العرض التقديمي
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **ضبط خصائص الخط للمخطط**
Aspose.Slides for .NET يوفر دعمًا لضبط خصائص الخط المتعلقة بالمخطط. يرجى اتباع الخطوات أدناه لضبط خصائص الخط للمخطط.

- إنشاء كائن من الفئة Presentation.
- إضافة مخطط إلى الشريحة.
- ضبط ارتفاع الخط.
- حفظ العرض المعدل.

المثال النموذجي أدناه.
```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **ضبط تنسيق الأرقام**
Aspose.Slides for .NET يوفر واجهة برمجة تطبيقات بسيطة لإدارة تنسيق بيانات المخطط:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة بواسطة فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (هذا المثال يستخدم **ChartType.ClusteredColumn**).
1. ضبط تنسيق الأرقام المسبق من القيم المسبقة الممكنة.
1. التنقل عبر خلية بيانات المخطط في كل سلسلة من المخططات وضبط تنسيق أرقام بيانات المخطط.
1. حفظ العرض.
1. ضبط تنسيق الأرقام المخصص.
1. التنقل عبر خلية بيانات المخطط داخل كل سلسلة وضبط تنسيق رقم مختلف لبيانات المخطط.
1. حفظ العرض.
```c#
// إنشاء العرض التقديمي// إنشاء العرض التقديمي
Presentation pres = new Presentation();

// الوصول إلى شريحة العرض الأولى
ISlide slide = pres.Slides[0];

// إضافة مخطط عمود مجمع افتراضي
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// الوصول إلى مجموعة سلاسل المخطط
IChartSeriesCollection series = chart.ChartData.Series;

// تعيين تنسيق الأرقام المسبق
// التجوال عبر كل سلسلة في المخطط
foreach (ChartSeries ser in series)
{
    // التجوال عبر كل خلية بيانات في السلسلة
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // تعيين تنسيق الرقم
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// حفظ العرض التقديمي
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


القيم الممكنة لتنسيق الأرقام المسبق مع مؤشراتها التي يمكن استخدامها موضحة أدناه:

|**0**|General|
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

## **ضبط حدود المنطقة المرسومة للمخطط المستديرة**
Aspose.Slides for .NET يوفر دعمًا لضبط منطقة المخطط. تم إضافة الخصائص **IChart.HasRoundedCorners** و **Chart.HasRoundedCorners** في Aspose.Slides.

1. إنشاء كائن من الفئة `Presentation`.
1. إضافة مخطط إلى الشريحة.
1. ضبط نوع التعبئة ولون التعبئة للمخطط
1. ضبط خاصية الزوايا المستديرة إلى True.
1. حفظ العرض المعدل.

المثال النموذجي أدناه.
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


## **الأسئلة المتكررة**

**هل يمكنني ضبط تعبئة شبه شفافة للأعمدة/المناطق مع الحفاظ على الحد غير شفاف؟**

نعم. يتم تكوين شفافية التعبئة والحد الخارجي بشكل منفصل. هذا مفيد لتحسين قابلية القراءة للشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، وتعطيل مكونات التسمية غير الأساسية (مثل الفئات)، وضبط إزاحة/موضع التسمية، إظهار التسميات فقط للنقاط المحددة إذا لزم الأمر، أو تغيير التنسيق إلى "value + legend".

**هل يمكنني تطبيق تعبئة متدرجة أو بنمط على السلاسل؟**

نعم. عادةً ما تكون كل من التعبئات الصلبة والمتدرجة/النمطية متاحة. في الممارسة العملية، استخدم التدرجات بشكل معتدل وتجنب الجمع بينهما ما يقلل من التباين مع الشبكة والنص.