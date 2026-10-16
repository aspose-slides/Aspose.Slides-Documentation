---
title: إنشاء أو تحديث مخططات عرض تقديمي PowerPoint في .NET
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
- مخطط شجرة خريطة
- مخطط أسهم
- مخطط صندوق ووصل
- مخطط قمعي
- مخطط شمسية
- مخطط هيستوجرام
- مخطط راداري
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint باستخدام Aspose.Slides for .NET. إضافة، تنسيق، وتحرير المخططات مع أمثلة عملية للكود بلغة C#."
---
## **نظرة عامة**

هذه المقالة توفر دليلًا شاملًا حول كيفية إنشاء وتخصيص المخططات باستخدام Aspose.Slides for .NET. ستتعلم كيفية إضافة مخطط إلى شريحة برمجيًا، وتعبئته بالبيانات، وتطبيق خيارات تنسيق مختلفة لتتناسب مع متطلبات التصميم الخاصة بك. طوال المقالة، توضح أمثلة الكود المفصلة كل خطوة، بدءًا من تهيئة العرض وكائن المخطط إلى تكوين السلاسل والمحاور والأساطير. باتباع هذا الدليل، ستحصل على فهم قوي لكيفية دمج إنشاء المخططات الديناميكية في تطبيقات .NET الخاصة بك، مما يبسط عملية إنشاء عروض تقديمية مدفوعة بالبيانات.

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واكتساب رؤى قد لا تكون واضحة على الفور من جدول أو ورقة عمل.

**لماذا إنشاء المخططات؟**

باستخدام المخططات، يمكنك:

* تجميع أو تلخيص أو تلخيص كميات كبيرة من البيانات في شريحة واحدة من العرض التقديمي؛
* كشف الأنماط والاتجاهات في البيانات؛
* استنتاج الاتجاه والزخم للبيانات مع مرور الوقت أو بالنسبة لوحدة قياس معينة؛
* اكتشاف القيم الشاذة أو الأخطاء أو البيانات غير المنطقية؛
* التواصل أو عرض البيانات المعقدة.

في PowerPoint، يمكنك إنشاء المخططات من خلال وظيفة *Insert* التي توفر قوالب لتصميم أنماط متعددة من المخططات. باستخدام Aspose.Slides، يمكنك إنشاء كلًا من المخططات العادية (المستندة إلى أنواع مخططات شائعة) والمخططات المخصصة.

{{% alert color="info" title="Note" %}}
Use the [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeration under the [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) namespace. The values in this enumeration correspond to different chart types.
{{% /alert %}}

### **إنشاء مخططات عمودية متجمعة**

هذا المثال يستخدم [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) لإنشاء مخطط عمودي متجمع يقارن سلسلتين عبر ثلاث فئات. تستخدم السلسلة ألوان ملء حمراء وخضراء، وتظهر التسميات الفردية أسماء الفئات وأسماء السلاسل والقيم. يشير فهرس ورقة العمل 0 إلى أول ورقة في دفتر العمل المدمج للمخطط.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

النتيجة:

![The Clustered Column chart](clustered_column_chart.png)

### **إنشاء مخططات مبعثرة**

المخططات المبعثرة (المعروفة أيضًا باسم scatter plots أو x-y graphs) تُستخدم عادة للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

استخدم مخططًا مبثراً عندما:

* لديك بيانات عددية مقترنة.
* لديك متغيران يتناسقان معًا.
* تريد تحديد ما إذا كان المتغيران مرتبطين.
* لديك متغير مستقل له قيم متعددة للمتغير التابع.

هذا المثال يرسم مجموعتين من قيم x-y. تستخدم السلسلة الأولى خطوطًا مستقيمة مع علامات نجمة، بينما تستخدم الثانية خطوطًا ملساء مع علامات دائرة؛ كلاهما يستخدم [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) بقيمة 10. تتحكم خاصية [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) في شكل العلامة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

النتيجة:

![The Scatter chart](scatter_chart.png)

### **إنشاء مخططات دائرية**

المخططات الدائرية تُستخدم بشكل أفضل لإظهار العلاقة بين الجزء والكامل في البيانات، خاصةً عندما تحتوي البيانات على تسميات تصنيفية مع قيم رقمية. ومع ذلك، إذا كانت بياناتك تحتوي على العديد من الأجزاء أو التسميات، قد ترغب في النظر في استخدام مخطط شريطي بدلاً من ذلك.

هذا المثال ينشئ مخططًا دائريًا بثلاث قيم ربع سنوية. كل شريحة لها تعبئة وحدود مخصصة، وتعرض التسميات تركيبات مختلفة من القيم والنسب المئوية ومعلومات السلسلة. تحدد خاصية [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) الزاوية الأولى لتبدأ عند 180 درجة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

النتيجة:

![The Pie chart](pie_chart.png)

لتحسين قابلية قراءة التسميات خارج الدائرة، راجع [Format Leader Lines](/slides/ar/net/chart-data-label/#format-leader-lines) للحصول على مثال يحدد موضع التسميات ويخصص لون الخطوط وعرضها وشفافيتها ونمط الشرط.

### **إنشاء مخططات خطية**

المخططات الخطية (المعروفة أيضًا باسم line graphs) تُستخدم بشكل أفضل في الحالات التي تريد فيها إظهار تغير القيمة مع الوقت. باستخدام مخطط خطي، يمكنك مقارنة كمية كبيرة من البيانات مرة واحدة، تتبع التغييرات والاتجاهات عبر الزمن، تسليط الضوء على الشذوذ في سلاسل البيانات، والمزيد.

هذا المثال يستخدم [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) لإنشاء مخطط خطي بالسلسلة والفئات الافتراضية، ثم يحفظ العرض التقديمي كملف PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

افتراضيًا، يتم ربط النقاط في المخطط الخطي بخطوط مستقيمة مستمرة. إذا رغبت في ربط النقاط بخطوط متقطعة بدلاً من ذلك، عيّن [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) إلى قيمة من [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

النتيجة:

![The Line chart](line_chart.png)

### **إنشاء مخططات شجرة**

مخططات شجرة (Tree map) تُستخدم بشكل أفضل لبيانات المبيعات عندما تريد إظهار الحجم النسبي لفئات البيانات وجذب الانتباه بسرعة إلى العناصر التي تساهم بشكل كبير داخل كل فئة.

هذا المثال ينشئ شجرة تحتوي على ثمان أوراق مجمعة في أربع سيقان وفرعين. تُخصص الطريقة [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) السيقان على المستوى التجميعي 1 والفروع على المستوى 2. تحدد القيم أحجام المستطيلات النسبية، بينما تسميات الفئات والتسميات المتداخلة للأصل تحدد الهرمية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// الفرع 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// الفرع 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

النتيجة:

![The Treemap chart](treemap_chart.png)

### **إنشاء مخططات شلالية**

المخطط الشلالي يُظهر كيف تساهم التغييرات الإيجابية والسلبية في القيمة النهائية. على سبيل المثال، يمكن أن يبدأ تحليل الربح بالإيرادات، يطرح التكاليف، ويضيف دخلًا آخر. الأعمدة المتغيرة تطفو بين القيم الجارية السابقة والجديدة، بينما تمتد أعمدة الإجمال من الصفر إلى القيمة المتراكمة.

المثال التالي يستخدم مبالغ بالآلاف من الدولارات الأمريكية:

| الفئة | قيمة دفتر العمل | نوع العمود |
| --- | ---: | --- |
| Revenue | 1000 | Increase |
| Cost of sales | -400 | Decrease |
| Gross profit | 600 | Intermediate total |
| Operating expenses | -200 | Decrease |
| Other income | 50 | Increase |
| Net profit | 450 | Final total |

لتمييز نقطة كإجمالي متوسط أو نهائي، عيّن خاصية [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) إلى `true`. قدّم المبلغ المتراكم الفعلي في خلية دفتر العمل الخاصة بتلك النقطة: `600` للربح الإجمالي (`1000 - 400`) و`450` للربح الصافي (`600 - 200 + 50`). لا تحسب الخاصية القيمة أو تملأ الخلية؛ لا تستخدم الصفر كعنصر نائب ولا تُضيف تغييرًا آخر لنقطة إجمالي. تُظهر العمود الإجمالي القيمة المتراكمة دون إضافتها مرة أخرى إلى القيمة الجارية.

هذا المثال الكامل بلغة C# ينشئ مخططًا باستخدام عضو `Waterfall` من [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)، ي clears البيانات الافتراضية، ويملأ دفتر العمل المدمج. يحدد فهرس ورقة العمل `0` أول ورقة؛ العمود A يحتوي على أسماء الفئات والعمود B يحتوي على القيم. تُضاف كل خلية قيمة باستخدام [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/). تُحدد مؤشرات النقاط ذات القاعدة الصفرية `2` و`5` الإجماليات المتوسطة والنهائية. تمكين [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) يُظهر المبالغ على الأعمدة. لا يلزم وجود عرض تقديمي أو دفتر عمل كمدخل.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// النقطة الثالثة والسادسة تمثل إجماليات، ليست تغييرات إضافية.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

عيّن الخاصية [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) على مستوى السلسلة إلى `true` لإظهار الخطوط التي تربط الأعمدة المتتالية وتسهيل متابعة القيمة الجارية. لإخفاء هذه الخطوط، استبدل التعيين في المثال بـ `series.ShowConnectorLines = false;` قبل الحفظ. هذا يغيّر فقط ظهور الخطوط، لا البيانات أو الإجماليات.

العرض التقديمي المحفوظ يُظهر الربح الإجمالي 600 والربح الصافي 450، مع رسم كلا الإجماليين من الصفر:

![Waterfall chart showing revenue, costs, gross profit of 600, and net profit of 450, with value labels and connector lines](waterfall_chart.png)

### **إنشاء مخططات أسهم**

مخططات الأسهم تُستخدم لعرض البيانات المالية مثل أسعار الفتح، والارتفاع، والانخفاض، والإغلاق، مما يساعد على تحليل اتجاهات السوق وتقلبه. توفر رؤى أساسية حول أداء السهم، وتساعد المستثمرين والمحللين على اتخاذ قرارات مستنيرة.

هذا المثال ينشئ مخططًا من نوع open-high-low-close بأربع سلاسل بهذا الترتيب وثلاث فئات. تُفعّل الخاصية [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) أشرطة الصعود/الهبط، وتتحكم [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) في خطوط الارتفاع‑الانخفاض التي تُظهر نطاق الأسعار، بينما تُخفى خطوط السلسلة الفردية وخطوط الشبكة الأفقية الصغرى.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

النتيجة:

![The Stock chart](stock_chart.png)

### **إنشاء مخططات صندوقية ووصلية**

المخططات الصندوقية والوصلية تُستخدم لعرض توزيع البيانات من خلال تلخيص مقاييس إحصائية رئيسية، مثل الوسيط، والرباعيات، والقيم الشاذة المحتملة. وهي مفيدة بشكل خاص في تحليل البيانات الاستكشافي والدراسات الإحصائية لتفهّم تباين البيانات بسرعة وتحديد أي شذوذ.

هذا المثال ينشئ مخططًا صندوقيًا ووصليًا من ست قيم. تُحدّد الخاصية [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) طريقة حساب الرباعيات الحصرية. يُفعّل المثال أيضًا خطوط المتوسط، وعلامات المتوسط، والنقاط الداخلية، ونقاط القيم الشاذة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **إنشاء مخططات قمعية**

المخططات القمعية تُستخدم لتصوير العمليات التي تتضمن مراحل متتالية، حيث يندفع حجم البيانات كلما تقدم من خطوة إلى أخرى. وهي مفيدة بشكل خاص لتحليل معدلات التحويل، وتحديد اختناقات العملية، وتتبع كفاءة عمليات المبيعات أو التسويق.

هذا المثال يستخدم [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) لإضافة مخطط قمع إلى الشريحة الأولى من عرض تقديمي موجود. يستبدل البيانات الافتراضية بست فئات وقيم تتراوح بين 50 و500، ثم يحفظ العرض المحدث. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

النتيجة:

![The Funnel chart](funnel_chart.png)

### **إنشاء مخططات شمسية**

المخططات الشمسیة تُستخدم لتصویر البیانات الھیراрکیة، حیث تُظهر المستويات كحلقات متحدة المركز. تساعد على توضيح علاقات الجزء إلى الكل وتكون مثالية لتمثيل الفئات المتداخلة والفرعية بشكل واضح ومختصر.

هذا المثال ينشئ مخططًا شمسيًا بثمانی أوراق مجمعة في أربع سیقان وفرعين. تُعيّن الطريقة [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) السيقان على المستوى التجميعي 1 والفروع على المستوى 2. تحدد تسميات الفئات القطاعات، وتحدد القيم أحجامها النسبية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// الفرع 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// الفرع 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

النتيجة:

![The Sunburst chart](sunburst_chart.png)

### **إنشاء مخططات هيستوجرام**

مخططات الهيستوجرام تُظهر كيف يتم توزيع القيم العددية عبر الفواصل (الصناديق). لتقارير شهرية حول أوقات معالجة الطلبات، استخدم عرض صندوق ثابت وحدودًا ثابتة للحفاظ على توحيد الفواصل وتسهيل مقارنة التوزيعات.

عيّن الخاصية الأفقية [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) إلى وضع من [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/). تُطبق [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) فقط على `ByBinWidth`؛ وتُطبق [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) فقط على `ByNumberOfBins`. استخدم `Automatic` لترك المخطط يختار الصناديق تلقائيًا.

#### **استخدام عرض صندوق ثابت**

هذا المثال يجمع أوقات المعالجة في فواصل زمنية مدتها 10 دقائق، مع صناديق منفصلة للأوقات التي تبلغ 10 دقائق أو أقل وللأوقات فوق 40 دقيقة. فعّل هذه الصناديق باستخدام [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) و[IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/). عند تقديم حدود صندق [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) و[OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/) صريحة، عيّن [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) و[IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) إلى `false`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

العرض المقدم في PowerPoint يُظهر عدد الصناديق **3, 4, 4, 4, and 2**. تشمل الصندوق تحت التدفق القيم `5, 10, 10`، لذا فإن حدوده شاملة. يضم الصندوق فوق التدفق القيم `41, 50` فقط، لذا فإن حدوده حصرية؛ تظل القيم المتساوية مع `40` في الفاصل السابق. الصناديق الداخلية تحتوي على قيم أكبر من حدها الأدنى وأقل من أو تساوي حدها العلوي.

![Histogram with 10-minute bins and explicit underflow and overflow thresholds](histogram_bin_width.png)

#### **تحديد عدد الصناديق**

للحصول على مستوى تفصيل ثابت بدلاً من فواصل ثابتة، اطلب خمس صناديق لنفس البيانات. هذا المثال يترك صناديق تحت التدفق وفوق التدفق معطلة. يحدد المخطط العرض بناءً على نطاق البيانات، لذا قد تتغير الحدود بين التقارير.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

الصناديق الخمس لديها عدد **4, 4, 4, 4, and 1**. قارن هذا التوزيع بالنتيجة ذات العرض الثابت أعلاه: القيم المدخلة هي نفسها، لكن الحدود تختلف.

![Histogram with five bins calculated from the same data](histogram_bin_count.png)

### **إنشاء مخططات رادارية**

المخططات الرادارية تُستخدم لعرض بيانات متعددة المتغيرات في صيغة ثنائية الأبعاد، مما يسمح بمقارنة عدة متغيرات في آنٍ واحد بسهولة. وهي مفيدة بشكل خاص لتحديد الأنماط والقوى والضعف عبر مجموعة من مؤشرات الأداء أو السمات.

هذا المثال يستخدم [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) لإنشاء مخطط راداري بالسلسلة والفئات الافتراضية، ثم يحفظ العرض التقديمي كملف PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

النتيجة:

![The Radar chart](radar_chart.png)

### **إنشاء مخططات متعددة الفئات**

المخططات متعددة الفئات تُستخدم لعرض بيانات تشمل أكثر من تجميع تصنيفي، مما يتيح مقارنة القيم عبر أبعاد متعددة في آنٍ واحد. إنها مفيدة بشكل خاص عندما تحتاج إلى تحليل الاتجاهات والعلاقات داخل مجموعات بيانات معقدة ومتعددة الطبقات.

هذا المثال ينشئ مخطط عمودي متجمع بثماني فئات مرتبة في أربع أزواج. تُعطي الطريقة [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) لكل زوج تسمية مشتركة على المستوى التجميعي 1، منتجةً محور فئات يحتوي على تسميات فردية ومجموعات.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

النتيجة:

![The multi category chart](multi_category_chart.png)

### **إنشاء مخططات خريطة**

مخططات الخريطة تُستخدم لتصور البيانات الجغرافية عن طريق ربط المعلومات بمواقع محددة مثل دول، ولايات، أو مدن. وهي مفيدة بشكل خاص لتحليل الاتجاهات الإقليمية، والبيانات الديموغرافية، والتوزيعات المكانية بطريقة واضحة وجذابة بصريًا.

هذا المثال يستخدم [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) لإنشاء مخطط خريطة بالبيانات الجغرافية الافتراضية ويحفظه للعرض في PowerPoint.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

النتيجة:

![The Map chart](map_chart.png)

{{% alert color="info" title="Note" %}}
The picture above shows the saved presentation opened in PowerPoint. Aspose.Slides writes the map chart and its data correctly, but it does not draw map charts itself: when a slide holding one is rendered to an image or converted to PDF or SVG, the chart area comes out blank. Other shapes on the same slide are unaffected.
{{% /alert %}}

### **إنشاء مخططات مركبة**

المخطط المركب (أو مخطط الجمع) يجمع نوعي مخطط أو أكثر في رسم بياني واحد. يتيح هذا المخطط إبراز أو مقارنة أو فحص الفروق بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![The combination chart](combination_chart.png)

هذا المثال يجمع سلسلتين عموديتين متجمعتين مع سلسلة خطية عبر أربع فئات. تستخدم الأعمدة المحور العمودي الأساسي، بينما يضع [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) الخط على محور عمودي ثانوي على اليمين. تقوم الدوال المساعدة بتكوين العنوان، والأسطورة، وتسميات المحاور، وخطوط الشبكة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **تحديث المخططات**

تمكنك Aspose.Slides for .NET من تحديث مخططات PowerPoint عن طريق تعديل بيانات المخطط، التنسيق، والأنماط. تُبسّط هذه الوظيفة عملية إبقاء العروض التقديمية محدثة بمحتوى ديناميكي وتضمن أن المخططات تعكس بدقة البيانات الحالية والمعايير البصرية.

هذا المثال يُحدّث المخطط المسمى "My chart" في الشريحة الأولى من عرض تقديمي موجود. يتطلب سلسلتين عموديتين بثلاث نقاط بيانات لكل منهما، مع تسميات فئات في العمود A وأسماء سلاسل في الصف الأول من ورقة العمل الأولى. يستخدم المثال [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) لتغيير خلايا دفتر العمل، يحدّث قيم السلاسل، يضيف سلسلة ثالثة، ويغيّر المخطط إلى أسطوانات متجمعة عبر [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **تحديد نطاق البيانات لمخطط**

للتفحص النطاق المستخدم بالفعل من قبل مخطط موجود، راجع [Retrieve a Chart's Data Range](/slides/ar/net/chart-workbook/#retrieve-a-charts-data-range).

توفر Aspose.Slides for .NET مرونة تعريف نطاق بيانات محدد من ورقة عمل كمصدر لبيانات مخططك. يعني هذا أنك يمكنك ربط جزء من ورقة العمل مباشرة بالمخطط، مما يسمح لك بالتحكم في الخلايا التي تُساهم في سلاسل المخطط وفئاته. وبالتالي، يمكنك تحديث ومزامنة مخططاتك بسهولة مع أحدث تغييرات البيانات في ورقة العمل، لضمان أن عروض PowerPoint تعكس معلومات دقيقة ومحدّثة.

هذا المثال يستخدم [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) لتعيين مصدر بيانات المخطط المسمى "My chart" في الشريحة الأولى من عرض تقديمي موجود إلى `Sheet1!A1:B4`. يجب أن يحتوي دفتر عمل المخطط على تلك الورقة ونطاق مُعبأ برأس سلسلة في الصف الأول، وتسميات فئات في العمود A، وثلاث قيم في العمود B.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **استخدام العلامات الافتراضية في المخططات**

عند استخدام العلامات الافتراضية في المخططات، يحصل كل سلسلة مخطط على رمز علامة افتراضية مختلف تلقائيًا.

هذا المثال يستخدم [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) لإنشاء مخطط بسلسلتين خطيتين وأساطير. تحتفظ إعدادات [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) بالرموز التي تم تعيينها تلقائيًا. تشمل السلسلة الأولى قيمة سلبية وقيمة مفقودة تمثَّل بـ `null`، بينما تحتوي السلسلة الثانية على قيمة لكل فئة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **الأسئلة المتكررة**

**ما هي أنواع المخططات التي يدعمها Aspose.Slides for .NET؟**

يدعم Aspose.Slides for .NET مجموعة واسعة من أنواع المخططات، بما في ذلك المخططات الشريطية، الخطية، الدائرية، المساحية، المبعثرة، الهيستوجرام، الرادارية، والعديد غيرها. تتيح لك هذه المرونة اختيار النوع الأنسب لتصوير البيانات الخاصة بك.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، أولاً تقوم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)، تسترجع الشريحة المطلوبة باستخدام فهرسها، ثم تستدعي الطريقة لإضافة مخطط مع تحديد نوع المخطط والبيانات الأولية. يدمج هذا العملية المخطط مباشرة في العرض التقديمي.

**كيف يمكنني تحديث البيانات المعروضة في مخطط؟**

يمكنك تحديث بيانات المخطط بالوصول إلى دفتر بياناته ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))، مسح أي سلاسل وفئات افتراضية، ثم إضافة البيانات المخصصة الخاصة بك. يتيح لك ذلك تحديث المخطط برمجيًا ليعكس أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، يوفر Aspose.Slides for .NET خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، الأساطير، وعناصر التنسيق الأخرى لتكييف مظهر المخطط مع متطلبات التصميم الخاصة بك.