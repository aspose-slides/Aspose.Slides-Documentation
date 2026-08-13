---
title: إنشاء أو تحديث مخططات عروض PowerPoint التقديمية في .NET
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
- مخطط نقطي
- مخطط دائري
- مخطط خطي
- مخطط شجرة خريطة
- مخطط أسهم
- مخطط الصندوق والوشاح
- مخطط قمع
- مخطط شمسي
- مخطط تَوزيع
- مخطط راداري
- مخطط فئات متعددة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET. إضافة وتنسيق وتحرير المخططات مع أمثلة عملية للكود بلغة C#."
---
## **Overview**

توفر هذه المقالة دليلًا شاملاً حول كيفية إنشاء المخططات وتخصيصها باستخدام Aspose.Slides لـ .NET. ستتعلم كيفية إضافة مخطط برمجيًا إلى شريحة، وتعبئته بالبيانات، وتطبيق خيارات تنسيق متنوعة لتتناسب مع متطلبات التصميم الخاصة بك. طوال المقالة، توضح أمثلة الكود المفصلة كل خطوة، بدءًا من تهيئة العرض والكائن المخطط إلى تكوين السلاسل والمحاور والوسائط. باتباع هذا الدليل، ستحصل على فهم قوي لكيفية دمج إنشاء المخططات الديناميكية في تطبيقات .NET الخاصة بك، مما يبسط عملية إنشاء عروض تقديمية مدعومة بالبيانات.

## **Create a Chart**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واستخلاص رؤى قد لا تكون واضحة فورًا من جدول أو ورقة عمل.

**Why Create Charts?**

* تجميع أو تكثيف أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في العرض التقديمي؛  
* كشف الأنماط والاتجاهات في البيانات؛  
* استنتاج اتجاه وزخم البيانات مع مرور الوقت أو بالنسبة لوحدة قياس معينة؛  
* اكتشاف القيم المتطرفة، والشذوذ، والانحرافات، والأخطاء، والبيانات غير المنطقية؛  
* التواصل أو عرض البيانات المعقدة.

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة *Insert* التي توفر قوالب لتصميم أنواع متعددة من المخططات. باستخدام Aspose.Slides، يمكنك إنشاء كل من المخططات العادية (المستندة إلى أنواع المخططات الشائعة) والمخططات المخصصة.

{{% alert color="info" %}} 
استخدم تعداد [ChartType](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/charttype/) الموجود ضمن مساحة الاسم [Aspose.Slides.Charts](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/). القيم في هذا التعداد تتطابق مع أنواع المخططات المختلفة.
{{% /alert %}} 

### **Create Clustered Column Charts**

تشرح هذه الفقرة كيفية إنشاء مخططات الأعمدة المجمعة باستخدام Aspose.Slides لـ .NET. ستتعلم كيفية تهيئة عرض تقديمي، وإضافة مخطط، وتخصيص عناصره مثل العنوان والبيانات والسلاسل والفئات والتنسيق. اتبع الخطوات أدناه لرؤية كيفية إنشاء مخطط عمود مجمع قياسي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط مع بعض البيانات وتحديد النوع `ChartType.ClusteredColumn`.  
4. إضافة عنوان إلى المخطط.  
5. الوصول إلى ورقة بيانات المخطط.  
6. مسح جميع السلاسل والفئات الافتراضية.  
7. إضافة سلاسل وفئات جديدة.  
8. إضافة بيانات مخطط جديدة لسلسلة المخطط.  
9. تطبيق لون تعبئة على سلسلة المخطط.  
10. إضافة تسميات إلى سلسلة المخطط.  
11. حفظ العرض المعدل كملف PPTX.  

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

    // إضافة مخطط أعمدة مجمّع مع البيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // تعيين عنوان المخطط.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // تعيين فهرس ورقة بيانات المخطط.
    int worksheetIndex = 0;

    // الحصول على دفتر بيانات المخطط.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف السلاسل والفئات الافتراضية التي تم إنشاؤها.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // إضافة سلاسل جديدة.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // إضافة فئات جديدة.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // الحصول على السلسلة الأولى للمخطط.
    IChartSeries series = chart.ChartData.Series[0];

    // ملء بيانات السلسلة.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // تعيين لون التعبئة للسلسلة.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // الحصول على السلسلة الثانية للمخطط.
    series = chart.ChartData.Series[1];

    // ملء بيانات السلسلة.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // تعيين لون التعبئة للسلسلة.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // تعيين التسمية الأولى لعرض اسم الفئة.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // تعيين السلسلة لعرض القيمة للتسمية الثالثة.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // حفظ العرض التقديمي على القرص كملف PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

![مخطط العمود المجمّع](clustered_column_chart.png)

### **Create Scatter Charts**

المخططات النقطية (المعروفة أيضًا بمخططات الانتشار أو رسومات x-y) تُستخدم غالبًا للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

استخدم مخطط انتشاري عندما:

* لديك بيانات رقمية مُقترنة.  
* لديك متغيران يتكاملان معًا بشكل جيد.  
* ترغب في تحديد ما إذا كان المتغيران مرتبطين.  
* لديك متغير مستقل لديه قيم متعددة للمتغير التابع.  

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إنشاء مخطط انتشاري افتراضي.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // تعيين فهرس ورقة بيانات المخطط.
    int worksheetIndex = 0;

    // الحصول على دفتر بيانات المخطط.
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

    // حفظ العرض التقديمي على القرص كملف PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

![مخطط الانتشار](scatter_chart.png)

### **Create Pie Charts**

تُعد المخططات الدائرية مثالية لتوضيح علاقة الجزء إلى الكل في البيانات، خاصةً عندما تحتوي البيانات على تسميات فئوية مع قيم رقمية. ومع ذلك، إذا كانت البيانات تحتوي على العديد من الأجزاء أو التسميات، قد ترغب في التفكير في استخدام مخطط شريطي بدلاً من ذلك.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Pie`.  
4. الوصول إلى دفتر بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).  
5. مسح السلاسل والفئات الافتراضية.  
6. إضافة سلاسل وفئات جديدة.  
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.  
8. إضافة نقاط جديدة للمخطط وتطبيق ألوان مخصصة على قطاعات المخطط الدائري.  
9. تعيين تسميات للسلسلة.  
10. تمكين خطوط الربط لتسميات السلسلة.  
11. تعيين زاوية الدوران للمخطط الدائري.  
12. حفظ العرض المعدل كملف PPTX.  

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

    // إضافة مخطط بالبيانات الافتراضية.
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

    // الحصول على دفتر بيانات المخطط.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف السلاسل والفئات الافتراضية التي تم إنشاؤها.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // إضافة فئات جديدة.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // إضافة سلسلة جديدة.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // ملء بيانات السلسلة.
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

    // تعيين السلسلة لعرض خطوط الربط للمخطط.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // تعيين زاوية الدوران لقطاعات المخطط الدائري.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // حفظ العرض التقديمي على القرص كملف PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

![مخطط الدائرة](pie_chart.png)

### **Create Line Charts**

المخططات الخطية (المعروفة أيضًا بالرسوم الخطية) تكون مثالية في الحالات التي تريد فيها إظهار تغير القيم مع مرور الوقت. باستخدام مخطط خطي، يمكنك مقارنة كمية كبيرة من البيانات دفعة واحدة، تتبع التغييرات والاتجاهات مع مرور الوقت، تسليط الضوء على الشذوذ في سلاسل البيانات، وغيرها.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Line`.  
4. الوصول إلى دفتر بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).  
5. مسح السلاسل والفئات الافتراضية.  
6. إضافة سلاسل وفئات جديدة.  
7. إضافة بيانات مخطط جديدة للسلسلة.  
8. حفظ العرض المعدل كملف PPTX.  

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

افتراضيًا، يتم ربط النقاط في المخطط الخطي بخطوط مستمرة مستقيمة. إذا كنت ترغب في ربط النقاط بخطوط متقطعة بدلاً من ذلك، يمكنك تحديد نوع الخط المتقطع المفضل لديك كما يلي:

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

![مخطط الخط](line_chart.png)

### **Create Tree Map Charts**

تُعد مخططات شجرة الخريطة (Tree Map) مثالية لبيانات المبيعات عندما تريد إظهار الحجم النسبي لفئات البيانات وإبراز العناصر ذات المساهمة الكبيرة داخل كل فئة بسرعة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Treemap`.  
4. الوصول إلى دفتر بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).  
5. مسح السلاسل والفئات الافتراضية.  
6. إضافة سلاسل وفئات جديدة.  
7. إضافة بيانات مخطط جديدة للسلسلة.  
8. حفظ العرض المعدل كملف PPTX.  

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

![مخطط شجرة الخريطة](treemap_chart.png)

### **Create Stock Charts**

تُستخدم مخططات الأسهم لعرض البيانات المالية مثل أسعار الفتح والارتفاع والانخفاض والإغلاق، مما يساعد على تحليل اتجاهات السوق وتقلباته. إنها تقدم رؤى أساسية حول أداء السهم، وتساعد المستثمرين والمحللين على اتخاذ قرارات مستنيرة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.OpenHighLowClose`.  
4. الوصول إلى دفتر بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).  
5. مسح السلاسل والفئات الافتراضية.  
6. إضافة سلاسل وفئات جديدة.  
7. إضافة بيانات مخطط جديدة للسلسلة.  
8. تحديد تنسيق HiLowLines.  
9. حفظ العرض المعدل كملف PPTX.  

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

![مخطط السهم](stock_chart.png)

### **Create Box and Whisker Charts**

تُستخدم مخططات الصندوق والوشاح (Box and Whisker) لعرض توزيع البيانات من خلال تلخيص المقاييس الإحصائية الرئيسية مثل الوسيط، والرباعيات، والقيم المتطرفة المحتملة. وهي مفيدة بشكل خاص في تحليل البيانات الاستكشافي والدراسات الإحصائية لفهم تباين البيانات بسرعة وتحديد أي شذوذ.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.BoxAndWhisker`.  
4. الوصول إلى دفتر بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).  
5. مسح السلاسل والفئات الافتراضية.  
6. إضافة سلاسل وفئات جديدة.  
7. إضافة بيانات مخطط جديدة للسلسلة.  
8. حفظ العرض المعدل كملف PPTX.  

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

### **Create Funnel Charts**

تُستخدم مخططات القمع لتصور العمليات التي تتضمن مراحل متتالية، حيث يقل حجم البيانات مع التقدم من خطوة إلى أخرى. وهي مفيدة بشكل خاص لتحليل معدلات التحويل، وتحديد عنق الزجاجة، وتتبع كفاءة عمليات المبيعات أو التسويق.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Funnel`.  
4. حفظ العرض المعدل كملف PPTX.  

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

![مخطط القمع](funnel_chart.png)

### **Create Sunburst Charts**

تُستخدم مخططات الشمسية (Sunburst) لتصوير البيانات الهرمية، حيث تُعرض المستويات كحلقات متحدة المركز. تساعد في توضيح علاقات الجزء إلى الكل وتعد مثالية لتمثيل الفئات الفرعية والفرعية المتداخلة بشكل واضح ومختصر.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.Sunburst`.  
4. حفظ العرض المعدل كملف PPTX.  

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

![مخطط الشمسية](sunburst_chart.png)

### **Create Histogram Charts**

تُستخدم مخططات التوزيع (Histogram) لتمثيل توزيع البيانات العددية من خلال تجميع القيم في نطاقات أو فواصل. وهي مفيدة خصوصًا لتحديد أنماط البيانات مثل التكرار، والإنحراف، والانتشار، واكتشاف القيم المتطرفة في مجموعة البيانات.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط مع بعض البيانات وتحديد النوع `ChartType.Histogram`.  
4. الوصول إلى دفتر بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).  
5. مسح السلاسل والفئات الافتراضية.  
6. إضافة سلاسل وفئات جديدة.  
7. حفظ العرض المعدل كملف PPTX.  

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

![مخطط التوزيع](histogram_chart.png)

### **Create Radar Charts**

تُستخدم مخططات الرادار لعرض البيانات المتعددة المتغيرات في تنسيق ثنائي الأبعاد، مما يسمح بمقارنة عدة متغيرات في آن واحد بسهولة. وهي مفيدة بشكل خاص لتحديد الأنماط، والنقاط القوية والضعيفة عبر مقاييس أو سمات أداء متعددة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط مع بعض البيانات وتحديد النوع `ChartType.Radar`.  
4. حفظ العرض المعدل كملف PPTX.  

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

![مخطط الرادار](radar_chart.png)

### **Create Multi-Category Charts**

تُستخدم مخططات الفئات المتعددة لعرض بيانات تشمل أكثر من تجميع فئوي واحد، مما يتيح مقارنة القيم عبر أبعاد متعددة في آن واحد. وهي مفيدة بشكل خاص عندما تحتاج إلى تحليل الاتجاهات والعلاقات داخل مجموعات بيانات معقدة ومتعددة الطبقات.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. إضافة مخطط ببيانات افتراضية وتحديد النوع `ChartType.ClusteredColumn`.  
4. الوصول إلى دفتر بيانات المخطط ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/)).  
5. مسح السلاسل والفئات الافتراضية.  
6. إضافة سلاسل وفئات جديدة.  
7. إضافة بيانات مخطط جديدة للسلسلة.  
8. حفظ العرض المعدل كملف PPTX.  

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

    // حفظ العرض التقديمي مع المخطط.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

![مخطط الفئات المتعددة](multi_category_chart.png)

### **Create Map Charts**

تُستخدم مخططات الخريطة لتصوير البيانات الجغرافية من خلال ربط المعلومات بمواقع محددة مثل البلدان أو الولايات أو المدن. وهي مفيدة بشكل خاص لتحليل الاتجاهات الإقليمية، والبيانات الديموغرافية، والتوزيعات المكانية بطريقة واضحة وجذابة بصريًا.

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

![مخطط الخريطة](map_chart.png)

{{% alert color="info" %}} 
الصورة أعلاه تظهر العرض التقديمي المحفوظ المفتوح في PowerPoint. تقوم Aspose.Slides بكتابة مخطط الخريطة وبياناته بشكل صحيح، لكنها لا تقوم برسم مخططات الخريطة نفسها: عندما يتم تحويل شريحة تحتوي على مخطط إلى صورة أو تحويلها إلى PDF أو SVG، يصبح مجال المخطط فارغًا. الأشكال الأخرى على نفس الشريحة لا تتأثر.
{{% /alert %}} 

### **Create Combination Charts**

مخطط مركب (أو مخطط مدمج) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح لك هذا المخطط إبراز أو مقارنة أو فحص الاختلافات بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![مخطط مركب](combination_chart.png)

الكود التالي يوضح كيفية إنشاء المخطط المركب المعروض أعلاه في عرض PowerPoint:

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

    // تعيين عنوان المخطط
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // تعيين وسيلة إيضاح المخطط
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // حذف السلاسل والفئات الافتراضية التي تم إنشاؤها
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // إضافة فئات جديدة
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
    // تعيين المحور الأفقي
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // تعيين المحور العمودي
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // تعيين لون خطوط الشبكة العمودية الرئيسية
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // تعيين المحور الأفقي الثانوي
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // تعيين المحور العمودي الثانوي
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

## **Update Charts**

تمكنك Aspose.Slides لـ .NET من تحديث مخططات PowerPoint عن طريق تعديل بيانات المخطط، والتنسيق، والتصميم. تُبسط هذه الوظيفة عملية الحفاظ على التحديث المستمر للعروض التقديمية بالمحتوى الديناميكي وتضمن أن المخططات تعكس البيانات الحالية والمعايير البصرية بدقة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) التي تمثل العرض التقديمي الذي يحتوي على مخطط.  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. المرور عبر جميع الأشكال للعثور على المخطط.  
4. الوصول إلى ورقة بيانات المخطط.  
5. تعديل سلاسل بيانات المخطط عن طريق تغيير قيم السلاسل.  
6. إضافة سلسلة جديدة وتعبئة بياناتها.  
7. حفظ العرض المعدل كملف PPTX.  

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

            // الحصول على دفتر بيانات المخطط.
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

    // حفظ العرض التقديمي مع المخطط.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Set Data Range for a Chart**

تمكنك Aspose.Slides لـ .NET من تعريف نطاق بيانات محدد من ورقة العمل كمصدر لبيانات المخطط الخاص بك. يعني ذلك أنه يمكنك ربط جزء من ورقة العمل مباشرةً بالمخطط، مما يتيح لك التحكم في الخلايا التي تساهم في سلاسل المخطط وفئاته. ونتيجة لذلك، يمكنك بسهولة تحديث ومزامنة مخططاتك مع أحدث تغييرات البيانات في ورقة العمل، لضمان أن عروض PowerPoint تعكس المعلومات الحالية والدقيقة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) التي تمثل العرض التقديمي الذي يحتوي على مخطط.  
2. الحصول على مرجع لشريحة باستخدام فهرستها.  
3. المرور عبر جميع الأشكال للعثور على المخطط.  
4. الوصول إلى بيانات المخطط وتحديد النطاق.  
5. حفظ العرض المعدل كملف PPTX.  

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

## **Use Default Markers in Charts**

عند استخدام العلامات الافتراضية في المخططات، تحصل كل سلسلة مخطط على رمز علامة افتراضية مختلف تلقائيًا.

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

    // ملء بيانات السلسلة.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### What chart types are supported by Aspose.Slides for .NET?

يدعم Aspose.Slides لـ .NET مجموعة واسعة من أنواع المخططات، بما في ذلك المخططات الشريطية، الخطية، الدائرية، المساحية، النقطية، التوزيعية، الرادارية، والعديد غيرها. هذه المرونة تسمح لك باختيار النوع الأنسب لتصوير بياناتك.

### How do I add a new chart to a slide?

لإضافة مخطط، أولًا تقوم بإنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)، تستخرج الشريحة المطلوبة باستخدام فهرستها، ثم تستدعي الطريقة لإضافة مخطط مع تحديد نوع المخطط والبيانات الأولية. يدمج ذلك المخطط مباشرةً في عرضك التقديمي.

### How can I update the data displayed in a chart?

يمكنك تحديث بيانات المخطط عن طريق الوصول إلى دفتر بياناته ([IChartDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartdataworkbook/))، مسح السلاسل والفئات الافتراضية، ثم إضافة البيانات المخصصة الخاصة بك. يتيح لك ذلك تحديث المخطط برمجيًا لتعكس أحدث البيانات.

### Is it possible to customize the appearance of the chart?

نعم، يوفر Aspose.Slides لـ .NET خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، الوسائط، وعناصر التنسيق الأخرى لتكييف مظهر المخطط مع متطلبات التصميم الخاصة بك.