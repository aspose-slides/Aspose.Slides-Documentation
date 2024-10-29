---
title: تنسيق المخططات
type: docs
weight: 60
url: /ar/net/chart-formatting/
keywords: "كيانات المخطط، خصائص المخطط، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "تنسيق كيانات المخطط في عروض PowerPoint باستخدام C# أو .NET"
---

## **تنسيق كيانات المخطط**
Aspose.Slides لـ .NET يتيح للمطورين إضافة مخططات مخصصة إلى الشرائح من البداية. تشرح هذه المقالة كيفية تنسيق كيانات المخطط المختلفة بما في ذلك محور الفئة ومحور القيم.

يوفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة لإدارة كيانات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء مثيل من فئة **Presentation**.
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة مخطط مع بيانات افتراضية إلى جانب أي نوع مرغوب (في هذا المثال، سنستخدم ChartType.LineWithMarkers).
1. الوصول إلى محور القيم في المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور القيم
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور القيم
   1. تعيين **تنسيق الرقم** لمحور القيم
   1. تعيين **الوحدات الدنيا والقصوى والرئيسية والثانوية** لمحور القيم
   1. تعيين **خصائص النص** لبيانات محور القيم
   1. تعيين **العنوان** لمحور القيم
   1. تعيين **تنسيق الخط** لمحور القيم
1. الوصول إلى محور الفئة في المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور الفئة
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور الفئة
   1. تعيين **خصائص النص** لبيانات محور الفئة
   1. تعيين **العنوان** لمحور الفئة
   1. تعيين **موضع الملصق** لمحور الفئة
   1. تعيين **زاوية الدوران** لملصقات محور الفئة
1. الوصول إلى أسطورة المخطط وتعيين **خصائص النص** لها
1. عرض أساطير المخطط دون تداخل المخطط
1. الوصول إلى **محور القيم الثانوي** للمخطط وتعيين الخصائص التالية:
   1. تفعيل **محور القيم الثانوي**
   1. تعيين **تنسيق الخط** لمحور القيم الثانوي
   1. تعيين **تنسيق الرقم** لمحور القيم الثانوي
   1. تعيين **الوحدات الدنيا والقصوى والرئيسية والثانوية** لمحور القيم الثانوي
1. الآن رسم السلسلة الأولى من المخطط على محور القيم الثانوي
1. تعيين لون ملء الجدار الخلفي للمخطط
1. تعيين لون ملء منطقة الرسم للمخطط
1. كتابة العرض المعدل إلى ملف PPTX

```c#
// Instantiating presentation// Instantiating presentation
Presentation pres = new Presentation();

// Accessing the first slide
ISlide slide = pres.Slides[0];

// Adding the sample chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "مخطط عينة";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "المحور الأساسي";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting value axis line format : Now Obselete
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "فئة عينة";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **تعيين خصائص الخط للمخطط**
Aspose.Slides لـ .NET يوفر دعمًا لتعيين خصائص الخط المرتبطة بالمخطط. يرجى اتباع الخطوات أدناه لتعيين خصائص الخط للمخطط.

- إنشاء كائن فئة Presentation.
- إضافة المخطط على الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض المعدل.

مثال عينة أدناه.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **تعيين تنسيق الأرقام**
Aspose.Slides لـ .NET يوفر واجهة برمجة تطبيقات بسيطة لإدارة تنسيقات بيانات المخططات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة مخطط مع بيانات افتراضية إلى جانب أي نوع مرغوب (هذا المثال يستخدم **ChartType.ClusteredColumn**).
1. تعيين تنسيق الرقم المسبق من القيم الممكنة.
1. التجول عبر خلية بيانات المخطط في كل سلسلة مخطط وتعيين تنسيق الرقم لبيانات المخطط.
1. حفظ العرض.
1. تعيين تنسيق الرقم المخصص.
1. التجول عبر خلية بيانات المخطط داخل كل سلسلة مخطط وتعيين تنسيق رقم مختلف لبيانات المخطط.
1. حفظ العرض.

```c#
// Instantiate the presentation// Instantiate the presentation
Presentation pres = new Presentation();

// Access the first presentation slide
ISlide slide = pres.Slides[0];

// Adding a defautlt clustered column chart
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accessing the chart series collection
IChartSeriesCollection series = chart.ChartData.Series;

// Setting the preset number format
// Traverse through every chart series
foreach (ChartSeries ser in series)
{
    // Traverse through every data cell in series
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Setting the number format
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Saving presentation
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

القيم الممكنة لتنسيق الأرقام المسبقة جنبًا إلى جنب مع فهرسها والتي يمكن استخدامها موضحة أدناه:

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

## **تعيين حدود مستديرة لمنطقة المخطط**
Aspose.Slides لـ .NET يوفر دعمًا لتعيين منطقة المخطط. تم إضافة الخصائص **IChart.HasRoundedCorners** و **Chart.HasRoundedCorners** في Aspose.Slides.

1. إنشاء كائن فئة `Presentation`.
1. إضافة المخطط على الشريحة.
1. تعيين نوع الملء ولون الملء للمخطط
1. تعيين خاصية الزاوية المستديرة إلى True.
1. حفظ العرض المعدل.

مثال عينة أدناه.

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