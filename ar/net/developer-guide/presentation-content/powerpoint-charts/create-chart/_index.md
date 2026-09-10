---
title: إنشاء أو تحديث مخططات عروض PowerPoint في .NET
linktitle: إنشاء أو تحديث المخططات
type: docs
weight: 10
url: /ar/net/create-chart/
keywords:
- إضافة مخطط
- إنشاء مخطط
- تحرير مخطط
- تغيير مخطط
- تحديث مخطط
- مخطط مبعثر
- مخطط دائري
- مخطط خطي
- مخطط خريطة شجرية
- مخطط أسهم
- مخطط صندوق وشارب
- مخطط قمعي
- مخطط أشعة شمسية
- مخطط تكراري
- مخطط راداري
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint باستخدام Aspose.Slides لـ .NET. إضافة وتنسيق وتحرير المخططات مع أمثلة عملية على الشيفرة بلغة C#."
---
## **نظرة عامة**

هذا المقال يقدم دليلًا شاملًا حول كيفية إنشاء وتخصيص المخططات باستخدام Aspose.Slides for .NET. ستتعلم كيفية إضافة مخطط إلى شريحة برمجيًا، تعبئته بالبيانات، وتطبيق خيارات تنسيق مختلفة لتتناسب مع متطلبات التصميم الخاصة بك. طوال المقال، توضح أمثلة الشيفرة التفصيلية كل خطوة، بدءًا من تهيئة العرض وكائن المخطط إلى تكوين السلاسل والمحاور والأساطير. باتباع هذا الدليل، ستحصل على فهم قوي لكيفية دمج إنشاء المخططات الديناميكية في تطبيقات .NET الخاصة بك، مما يبسط عملية إنشاء عروض تقديمية مدفوعة بالبيانات.

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واستخلاص رؤى قد لا تكون واضحة فورًا من جدول أو ورقة حساب.

**لماذا إنشاء المخططات؟**

باستخدام المخططات، يمكنك:

* تجميع أو تضييق أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في عرض تقديمي؛
* كشف الأنماط والاتجاهات في البيانات؛
* استنتاج اتجاه وزخم البيانات مع مرور الوقت أو بالنسبة لوحدة قياس معينة؛
* اكتشاف القيم المتطرفة أو الشواذ أو الانحرافات أو الأخطاء أو البيانات غير المنطقية؛
* توصيل أو عرض بيانات معقدة.

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة *Insert* التي توفر قوالب لتصميم أنواع متعددة من المخططات. باستخدام Aspose.Slides، يمكنك إنشاء كل من المخططات العادية (المستندة إلى أنواع المخططات الشائعة) والمخططات المخصصة.

{{% alert color="info" %}} 
استخدم تعداد [ChartType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/charttype/) الموجود ضمن مساحة الاسم [Aspose.Slides.Charts](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/). القيم في هذا التعداد تتطابق مع أنواع مخططات مختلفة.
{{% /alert %}} 

### **إنشاء مخططات عمودية متراصة**

تشرح هذه الفقرة كيفية إنشاء مخططات عمودية متراصة باستخدام Aspose.Slides for .NET. ستتعلم كيفية تهيئة عرض تقديمي، إضافة مخطط، وتخصيص عناصره مثل العنوان والبيانات والسلاسل والفئات والتنسيق. اتبع الخطوات أدناه لرؤية كيفية إنشاء مخطط عمودي متراص قياسي:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات معينة وتحديد النوع `ChartType.ClusteredColumn`.
1. إضافة عنوان إلى المخطط.
1. الوصول إلى ورقة بيانات المخطط.
1. مسح جميع السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. تطبيق لون تعبئة على سلسلة المخطط.
1. إضافة تسميات إلى سلسلة المخطط.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# توضح كيفية إنشاء مخطط عمودي متراص:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation.
    // الوصول إلى الشريحة الأولى.
    // إضافة مخطط عمودي متراص مع بياناته الافتراضية.
    // ضبط عنوان المخطط.
    // تعيين فهرس ورقة بيانات المخطط.
    // الحصول على دفتر عمل بيانات المخطط.
    // حذف السلاسل والفئات المُنشأة افتراضيًا.
    // إضافة سلاسل جديدة.
    // إضافة فئات جديدة.
    // الحصول على السلسلة الأولى للمخطط.
    // تعبئة بيانات السلسلة.
    // تعيين لون التعبئة للسلسلة.
    // الحصول على السلسلة الثانية للمخطط.
    // تعبئة بيانات السلسلة.
    // تعيين لون التعبئة للسلسلة.
    // تعيين التسمية الأولى لعرض اسم الفئة.
    // تعيين السلسلة لعرض القيمة للتسمية الثالثة.
    // حفظ العرض على القرص كملف PPTX.
using (Presentation presentation = new Presentation())
{
    // Access the first slide.
    ISlide slide = presentation.Slides[0];

    // Add a clustered column chart with its default data.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Set the chart title.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Set the index of the chart data sheet.
    int worksheetIndex = 0;

    // Get the chart data workbook.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Delete the default generated series and categories.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Add new series.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Add new categories.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Get the first chart series.
    IChartSeries series = chart.ChartData.Series[0];

    // Populate the series data.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Set the fill color for the series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Get the second chart series.
    series = chart.ChartData.Series[1];

    // Populate the series data.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Set the fill color for the series.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Set the first label to show the category name.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Set the series to show the value for the third label.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Save the presentation to disk as a PPTX file.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط العمود المتراص](clustered_column_chart.png)

### **إنشاء مخططات مبعثرة**

تُستخدم مخططات المبخرة (المعروفة أيضًا بالمخططات المبعثرة أو مخططات x-y) غالبًا للتحقق من وجود أنماط أو إظهار الترابط بين متغيرين.

استخدم مخططًا مبثرًا عندما:

* لديك بيانات عددية مزدوجة.
* لديك متغيران يتماسان معًا.
* تريد معرفة ما إذا كان المتغيران مرتبطين.
* لديك متغير مستقل له قيم متعددة بالنسبة لمتغير تابع.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط مبثر مع مجموعة مختلفة من العلامات:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إنشاء مخطط تبعثر افتراضي.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // تعيين فهرس ورقة بيانات المخطط.
    int worksheetIndex = 0;

    // الحصول على دفتر عمل بيانات المخطط.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف السلسلة الافتراضية.
    chart.ChartData.Series.Clear();

    // إضافة سلاسل جديدة.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // الحصول على السلسلة الأولى للمخطط.
    IChartSeries series = chart.ChartData.Series[0];

    // إضافة نقطة جديدة (1:3) إلى السلسلة.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // إضافة نقطة جديدة (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // تغيير نوع السلسلة.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // تغيير علامة سلسلة المخطط.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // الحصول على السلسلة الثانية للمخطط.
    series = chart.ChartData.Series[1];

    // إضافة نقطة جديدة (5:2) إلى سلسلة المخطط.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // إضافة نقطة جديدة (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // إضافة نقطة جديدة (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // إضافة نقطة جديدة (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // تغيير علامة سلسلة المخطط.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // حفظ العرض على القرص كملف PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط مبثر](scatter_chart.png)

### **إنشاء مخططات دائرية**

تُعد المخططات الدائرية مثالية لإظهار العلاقة بين الجزء والكامل في البيانات، خاصةً عندما تحتوي البيانات على تسميات فئوية ذات قيم عددية. ومع ذلك، إذا كانت بياناتك تحتوي على العديد من الأجزاء أو التسميات، قد تفضل استخدام مخطط شريطي بدلاً من ذلك.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Pie`.
1. الوصول إلى دفتر عمل بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. إضافة نقاط جديدة للمخطط وتطبيق ألوان مخصصة على قطاعات المخطط الدائري.
1. ضبط تسميات السلاسل.
1. تمكين خطوط القادة لتسميات السلاسل.
1. ضبط زاوية الدوران للمخطط الدائري.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط دائري:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة مخطط مع بياناته الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // تعيين عنوان المخطط.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // تعيين السلسلة الأولى لعرض القيم.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // تعيين فهرس ورقة بيانات المخطط.
    int worksheetIndex = 0;

    // الحصول على دفتر عمل بيانات المخطط.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف السلاسل والفئات المُنشأة افتراضيًا.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // إضافة فئات جديدة.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // إضافة سلسلة جديدة.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // تعبئة بيانات السلسلة.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // تعيين لون القطاع.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // تعيين حد القطاع.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // تعيين حد القطاع.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // تعيين حد القطاع.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // إنشاء تسميات مخصصة لكل فئة في السلسلة الجديدة.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // تعيين السلسلة لعرض خطوط القادة للمخطط.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // تعيين زاوية الدوران لقطاعات المخطط الدائري.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // حفظ العرض على القرص كملف PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط دائري](pie_chart.png)

### **إنشاء مخططات خطية**

تُستخدم المخططات الخطية (المعروفة أيضًا بالمخططات البيانية الخطية) بشكل أساسي عندما تريد إظهار تغيّر القيم مع مرور الوقت. باستخدام مخطط خطي، يمكنك مقارنة كمية كبيرة من البيانات دفعة واحدة، تتبع التغييرات والاتجاهات بمرور الوقت، تسليط الضوء على الشذوذ في سلاسل البيانات، وأكثر.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Line`.
1. الوصول إلى دفتر عمل بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط خطي:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

افتراضيًا، يتم ربط النقاط في المخطط الخطي بخطوط مستمرة مستقيمة. إذا أردت ربط النقاط بخطوط متقطعة، يمكنك تحديد نوع الخط المتقطع المفضّل كما يلي:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

النتيجة:

![مخطط خطي](line_chart.png)

### **إنشاء مخططات شجرية**

تُستخدم المخططات الشجرية لعرض بيانات المبيعات عندما تريد إظهار الحجم النسبي لفئات البيانات وسحب الانتباه سريعًا إلى العناصر التي تُشكل مساهمات كبيرة داخل كل فئة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Treemap`.
1. الوصول إلى دفتر عمل بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط شجري:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // الفرع 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // الفرع 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط شجري](treemap_chart.png)

### **إنشاء مخططات أسهم**

تُستخدم مخططات الأسهم لعرض البيانات المالية مثل أسعار الفتح والارتفاع والانخفاض والإغلاق، مما يساعد على تحليل اتجاهات السوق وتقلباته. توفر هذه المخططات رؤى أساسية حول أداء الأسهم، مما يساعد المستثمرين والمحللين على اتخاذ قرارات مستنيرة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.OpenHighLowClose`.
1. الوصول إلى دفتر عمل بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. تحديد تنسيق HiLowLines.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط أسهم:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط أسهم](stock_chart.png)

### **إنشاء مخططات صندوق وشارب**

تُستخدم مخططات الصندوق والشارب لعرض توزيع البيانات عبر تلخيص مقاييس إحصائية رئيسية مثل الوسيط والربعيات والقيم المتطرفة المحتملة. إنها مفيدة بشكل خاص في التحليل الاستكشافي للبيانات والدراسات الإحصائية لفهم تباين البيانات بسرعة وتحديد أي شذوذ.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.BoxAndWhisker`.
1. الوصول إلى دفتر عمل بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط صندوق وشارب:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **إنشاء مخططات قمعية**

تُستخدم مخططات القمع لتصوير عمليات تتضمن مراحل متتابعة، حيث ينخفض حجم البيانات مع الانتقال من خطوة إلى أخرى. إنها مفيدة بشكل خاص لتحليل معدلات التحويل، تحديد العوائق، وتتبع كفاءة عمليات البيع أو التسويق.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Funnel`.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط قمعي:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط قمعي](funnel_chart.png)

### **إنشاء مخططات أشعة شمسية**

تُستخدم مخططات أشعة الشمسة لتصوير البيانات الهرمية، حيث تُعرض المستويات كحلقات متحدة المركز. تساعد على توضيح علاقات الجزء إلى الكل وتعتبر مثالية لتمثيل الفئات المتداخلة والفرعية بطريقة واضحة ومُدمجة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Sunburst`.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط أشعة شمسية:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // الفرع 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // الفرع 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط أشعة شمسية](sunburst_chart.png)

### **إنشاء مخططات تكرارية**

تُستخدم المخططات التكرارية لتمثيل توزيع البيانات العددية عن طريق تجميع القيم في فواصل أو صناديق. إنها مفيدة لتحديد أنماط البيانات مثل التكرار والإنحياز والانتشار، وكذلك لاكتشاف القيم المتطرفة في مجموعة البيانات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات معينة وتحديد النوع `ChartType.Histogram`.
1. الوصول إلى دفتر عمل بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط تكراري:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط تكراري](histogram_chart.png)

### **إنشاء مخططات رادار**

تُستخدم مخططات الرادار لعرض بيانات متعددة المتغيرات في تنسيق ثنائي الأبعاد، مما يسمح بالمقارنة السهلة لعدة متغيّرات في آن واحد. إنها مفيدة لتحديد الأنماط والقوة والضعف عبر مقاييس أداء أو صفات متعددة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات معينة وتحديد النوع `ChartType.Radar`.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط رادار:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط رادار](radar_chart.png)

### **إنشاء مخططات متعددة الفئات**

تُستخدم مخططات متعددة الفئات لعرض بيانات تشمل أكثر من تجميع فئوي واحد، مما يتيح مقارنة القيم عبر أبعاد متعددة في آن واحد. إنها مفيدة عندما تحتاج إلى تحليل الاتجاهات والعلاقات داخل مجموعات بيانات معقدة ومتعددة الطبقات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.ClusteredColumn`.
1. الوصول إلى دفتر عمل بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط متعدد الفئات:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // إضافة سلسلة.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // حفظ العرض مع المخطط.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط متعدد الفئات](multi_category_chart.png)

### **إنشاء مخططات خريطة**

تُستخدم مخططات الخريطة لتصوير البيانات الجغرافية عبر ربط المعلومات بمواقع محددة مثل الدول أو الولايات أو المدن. إنها مفيدة لتحليل الاتجاهات الإقليمية، البيانات الديموغرافية، والتوزيعات المكانية بطريقة واضحة وجذابة بصريًا.

هذا الشيفرة C# يوضح كيفية إنشاء مخطط خريطة:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![مخطط خريطة](map_chart.png)

{{% alert color="info" %}} 
الصورة أعلاه تُظهر العرض المحفوظ مفتوحًا في PowerPoint. Aspose.Slides يكتب مخطط الخريطة وبياناته بشكل صحيح، لكنه لا يرسم مخططات الخريطة نفسه: عندما يتم تحويل شريحة تحتوي على أحدها إلى صورة أو إلى PDF أو SVG، يصبح منطقة المخطط فارغة. الأشكال الأخرى على نفس الشريحة لا تتأثر.
{{% /alert %}} 

### **إنشاء مخططات مدمجة**

المخطط المدمج (أو مخطط الجمع) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح هذا المخطط إبراز أو مقارنة أو فحص الاختلافات بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![مخطط مدمج](combination_chart.png)

الكود C# التالي يُظهر كيفية إنشاء المخطط المدمج المعروض أعلاه في عرض PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // يضبط عنوان المخطط
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // يضبط أسطورة المخطط
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // يحذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // يضيف فئات جديدة
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // إضافة السلسلة الأولى
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // يضبط المحور الأفقي
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // يضبط المحور الرأسي
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // يضبط لون خطوط الشبكة العمودية الرئيسية
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // يضبط المحور الأفقي الثانوي
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // يضبط المحور الرأسي الثانوي
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **تحديث المخططات**

Aspose.Slides for .NET يتيح لك تحديث مخططات PowerPoint عن طريق تعديل بيانات المخطط، التنسيق، والتصميم. تُبسّط هذه الخاصية عملية الحفاظ على العروض محدثة بمحتوى ديناميكي وتضمن أن المخططات تعكس بدقة البيانات الحالية والمعايير البصرية.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) التي تمثل العرض الذي يحتوي على مخطط.
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. تصفح جميع الأشكال للعثور على المخطط.
1. الوصول إلى ورقة بيانات المخطط.
1. تعديل سلسلة بيانات المخطط عبر تغيير قيم السلسلة.
1. إضافة سلسلة جديدة وتعبئة بياناتها.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية تحديث مخطط:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // الوصول إلى الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // تعيين فهرس ورقة بيانات المخطط.
            int worksheetIndex = 0;

            // الحصول على دفتر عمل بيانات المخطط.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // تغيير أسماء فئات المخطط.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // الحصول على السلسلة الأولى للمخطط.
            IChartSeries series = chart.ChartData.Series[0];

            // تحديث بيانات السلسلة.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // تعديل اسم السلسلة.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // الحصول على السلسلة الثانية للمخطط.
            series = chart.ChartData.Series[1];

            // تحديث بيانات السلسلة.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // تعديل اسم السلسلة.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // إضافة سلسلة جديدة.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // ملء بيانات السلسلة.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // حفظ العرض مع المخطط.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **تعيين نطاق البيانات لمخطط**

Aspose.Slides for .NET يوفر لك المرونة لتحديد نطاق بيانات معين من ورقة عمل كمصدر لبيانات مخططك. هذا يعني أنه يمكنك ربط جزء من ورقة العمل مباشرةً بالمخطط، مما يتيح لك التحكم في الخلايا التي تُساهم في سلاسل ومجموعات المخطط. نتيجة لذلك، يمكنك بسهولة تحديث ومزامنة مخططاتك مع أحدث تغييرات البيانات في ورقة العمل، مما يضمن أن عروض PowerPoint تعكس معلومات دقيقة ومحدثة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) التي تمثل العرض الذي يحتوي على مخطط.
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. تصفح جميع الأشكال للعثور على المخطط.
1. الوصول إلى بيانات المخطط وتعيين النطاق.
1. حفظ العرض المعدل كملف PPTX.

هذا الشيفرة C# يوضح كيفية تعيين نطاق البيانات لمخطط:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // الوصول إلى الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **استخدام العلامات الافتراضية في المخططات**

عند استخدام العلامات الافتراضية في المخططات، يحصل كل سلسلة مخطط على رمز علامة افتراضي مختلف تلقائيًا.

هذا الشيفرة C# يوضح كيفية تعيين علامة سلسلة المخطط تلقائيًا:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // تعبئة بيانات السلسلة.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة الشائعة**

**ما هي أنواع المخططات التي يدعمها Aspose.Slides for .NET؟**

Aspose.Slides for .NET يدعم مجموعة واسعة من أنواع المخططات، بما في ذلك الشريطية، الخطية، الدائرية، المساحية، المبعثرة، التكرارية، الرادارية، والعديد غيرها. هذه المرونة تسمح لك باختيار النوع الأنسب لتصوير بياناتك.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، أولاً تنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)، تسترجع الشريحة المطلوبة باستخدام فهرسها، ثم تستدعي الطريقة لإضافة مخطط مع تحديد نوع المخطط والبيانات الأولية. بهذه الطريقة يندمج المخطط مباشرةً في العرض.

**كيف يمكنني تحديث البيانات المعروضة في مخطط؟**

يمكنك تحديث بيانات المخطط عبر الوصول إلى دفتر عمل البيانات الخاص به ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/))، مسح السلاسل والفئات الافتراضية، ثم إضافة بياناتك المخصّصة. يتيح لك ذلك تحديث المخطط برمجيًا ليعكس أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، Aspose.Slides for .NET يوفر خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، الأساطير، والعناصر التنسيقية الأخرى لتلائم المتطلبات التصميمية الخاصة بك.