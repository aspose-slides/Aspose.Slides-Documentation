---
title: تخصيص المخططات الدائرية في العروض التقديمية في .NET
linktitle: المخطط الدائري
type: docs
url: /ar/net/pie-chart/
keywords:
- مخطط دائري
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص المخططات الدائرية في .NET باستخدام Aspose.Slides. قم بتكوين الرسوم الثانوية، وعرض تسميات البيانات، وتطبيق ألوان شرائح تلقائية في PowerPoint."
---
## **نظرة عامة**

هذه المقالة توضح كيفية العمل مع المخططات الدائرية في Aspose.Slides. تُظهر كيفية تكوين خيارات الرسم الثانوي لمخططات Pie of Pie و Bar of Pie، وكيفية تمكين تلوين الشرائح تلقائيًا لمخطط دائري قياسي.

تركّز الأمثلة على مهام تخصيص المخططات مثل إضافة مخطط إلى شريحة، تعديل إعدادات السلاسل والملصقات، استبدال بيانات المخطط الافتراضية بفئات وقيم مخصصة، وحفظ العرض التقديمي المحدث.

## **خيارات الرسم الثانوي لمخططات Pie of Pie و Bar of Pie**

يدعم Aspose.Slides for .NET خيارات الرسم الثانوي لمخططات Pie of Pie و Bar of Pie. تتحكم هذه الخيارات في حجم الرسم الثانوي وكيفية توزيع نقاط البيانات بين الرسمين.

المثال التالي ينشئ مخطط Pie of Pie في عرض تقديمي جديد ويعرض قيم نقاط البيانات كملصقات. الخاصية [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) تحدد حجم الرسم الثانوي بنسبة 149% من الرسم الرئيسي. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) يختار التقسيم القائم على النسبة المئوية، و[PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) يحدد العتبة إلى 53%.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **تحديد الفئات للرسم الثانوي**

استخدم التقسيم المخصص عندما تريد تجميع فئات معينة في الرسم الثانوي بغض النظر عن قيم النسبة المئوية الخاصة بها. على سبيل المثال، قد يُظهر تقرير مبيعات Online و Events معًا حتى يتمكن القارئ من مقارنة هاتين القناتين، على الرغم من أنهما تمثلان 35% و10% من إجمالي المبيعات.

قم بتعيين [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) إلى [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) واختر النقاط عبر [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). طريقة [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) في المجموعة تقبل إما فهرسًا يبدأ من الصفر داخل السلسلة أو كائن نقطة بيانات. في هذا المثال، الفهرس 1 يحدد Online، والنقطة في الفهرس 3 تحدد Events. يتم إضافة Partners مؤقتًا، ثم استثناؤه باستخدام [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// استبدل البيانات الافتراضية بمبيعات حسب القناة.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// حدد Online بحسب الفهرس الصفري و Events بواسطة كائن نقطة البيانات.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// استبعد Partners من الاختيار دون حذف بياناته المصدر.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

تظهر Online (35) و Events (10) كشرائح منفصلة في الرسم الثانوي. في الرسم الأساسي، يتم تمثيلهما بشريحة موحدة بقيمة 45، إلى جانب Retail (40) و Partners (15). إزالة Partners من الاختيار المخصص يبقيها في الرسم الأساسي؛ ولا يزيل الفئة أو قيمتها من بيانات مصدر المخطط.

الصورة التالية توضح العرض التقديمي المحفوظ في PowerPoint:

![مخطط Pie of Pie مع Online و Events في الرسم الثانوي وقيمتهما المجمعة 45 في الرسم الأساسي](pie_of_pie_custom.png)

## **تعيين ألوان شرائح المخطط الدائري تلقائيًا**

يمكن لـ Aspose.Slides for .NET تعيين ألوان مختلفة تلقائيًا لشرائح المخطط الدائري. المثال التالي ينشئ مخططًا دائريًا بعنوان مركزي ويستبدل البيانات الافتراضية بثلاث فئات ربع سنوية وقيمها. الخاصية [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) تعرض القيم 20 و 50 و 30 كملصقات، بينما [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) تمكّن لونًا مميزًا لكل شريحة.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// إضافة عنوان مخطط مركّز.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// استبدل البيانات الافتراضية باستخدام ورقة العمل الأولى.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// إظهار القيم وتعيين ألوان مختلفة للشرائح.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**هل يتم دعم تنويعات Pie of Pie و Bar of Pie؟**

نعم، المكتبة [يدعم](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) مخططًا ثانويًا للمخططات الدائرية، بما في ذلك نوعي Pie of Pie و Bar of Pie.

**هل يمكنني تصدير المخطط فقط كصورة (على سبيل المثال PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (مثل PNG) دون تصدير العرض التقديمي بالكامل.