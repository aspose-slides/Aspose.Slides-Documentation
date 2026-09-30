---
title: تخصيص وسوم المخطط في العروض التقديمية باستخدام .NET
linktitle: وسمة المخطط
type: docs
url: /ar/net/chart-legend/
keywords:
- وسمة المخطط
- موضع الوسمة
- حجم الخط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تخصيص وسوم المخطط باستخدام Aspose.Slides for .NET لتحسين عروض PowerPoint التقديمية عبر تنسيق وسوم مخصص."
---
## **نظرة عامة**

توفر Aspose.Slides for .NET خيارات لتخصيص وسوم المخطط في عروض PowerPoint التقديمية. توضح هذه المقالة كيفية تحديد موضع وحجم الوسم، وضبط حجم الخط للوسم بالكامل، وتنسيق مدخل وسمة فردي، وإخفاء أو استعادة المدخلات المحددة.

تغطي الأسئلة المتكررة السلوكيات ذات الصلة، بما في ذلك تخصيص مساحة للوسم، وعرض تسميات متعددة الأسطر، وراثة التنسيق من سمة العرض التقديمي.

## **تحديد موضع الوسم**

استخدم خصائص [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) و [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) للوسم لتحديد موقعه وحجمه كنسب من أبعاد المخطط.

ينشئ هذا المثال عرضًا تقديميًا ويضيف مخطط أعمدة متجمّع مع بيانات افتراضية إلى الشريحة الأولى. تقسيم إزاحات وأبعاد الوسم المطلوبة على عرض وارتفاع المخطط يحولها إلى قيم نسبية: يتم إزاحة الوسم 50 نقطة من الزاوية العليا اليسرى للمخطط ويصبح حجمه 100 × 100 نقطة.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **ضبط حجم خط وسمة**

استخدم [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) للوسم للوصول إلى تنسيق النص الخاص به واضبط [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) بالنقاط.

ينشئ هذا المثال مخططًا ببيانات افتراضية ويضبط نص الوسم إلى 20 نقطة. كما يقوم بتعطيل الحدود التلقائية للمحور الرأسي ويضبط نطاقه من -5 إلى 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **ضبط حجم خط مدخل وسمة فردي**

استخدم مجموعة [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) للوسم للوصول إلى تنسيق مدخل محدد. مؤشرات المدخلات تبدأ من الصفر، لذا فالمؤشر `1` يشير إلى المدخل الثاني.

ينشئ هذا المثال مخطط أعمدة متجمّع حيث تشمل البيانات الافتراضية على الأقل سلسلتين. يقوم بتنسيق المدخل الثاني للوسم بنص عريض، مائل، ولون أزرق بحجم 20 نقطة.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **إخفاء مدخلات وسمة فردية**

لإزالة سلسلة مساعدة من الوسم مع إبقاء بياناتها مرئية، اضبط [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) إلى `true` عبر [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). هذا يخفي فقط مدخل الوسم المحدد؛ ولا يزيل السلسلة أو نقاط بياناتها. بينما ضبط [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) إلى `false` يخفي الوسم بأكمله.

ينشئ المثال أدناه مخطط أعمدة متجمّع مع عدة سلاسل باستخدام بيانات افتراضية. يخفي مدخل الوسم للسلسلة الثانية (المؤشر `1`) ويحفظ العرض التقديمي. ثم يستعيد المدخل بضبط `Hide` إلى `false` ويحفظ نسخة ثانية. تظل الأعمدة مرئية في كلا الملفين.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// استعادة نفس المدخل دون تغيير بيانات المخطط.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

تظهر المقارنة أدناه نفس المخطط مع جميع مدخلات الوسم مرئية ومع إخفاء المدخل الثاني. تظل أعمدة السلسلة الثانية دون تغيير.

![مقارنة مخطط مع جميع مدخلات الوسم مرئية ومع إخفاء السلسلة 2 من الوسم؛ تظل جميع الأعمدة مرئية.](hide-legend-entry.png)

في مخططات الأعمدة والشرائح والخطوط، تحدد مدخلات الوسم السلاسل. بالنسبة لمخططات الفطيرة، تحدد النقاط البيانات الفردية (القطاعات)، لذا استخدم [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) على القطاع المحدد بدلاً من ذلك. توثّق واجهة برمجة التطبيقات هذه الخاصية للبيانات للنقاط لأنواع المخططات `Pie`، `Pie3D`، `ExplodedPie`، `ExplodedPie3D`، `PieOfPie`، و `BarOfPie`. لا تفترض أنها تنطبق على مخططات الدونات، التي لا تُدرج في تلك القائمة.

## **الأسئلة المتكررة**

**هل يمكنني جعل المخطط يحجز مساحة للوسم بدلاً من تغطيته؟**  
نعم. اضبط [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) إلى `false` لحجز مساحة للوسم بدلاً من السماح له بتغطية منطقة الرسم.

**هل يمكنني إنشاء تسميات وسمة متعددة الأسطر؟**  
نعم. يمكن أن تُلتف التسميات الطويلة عندما يكون العرض المتاح غير كافٍ. يمكنك أيضًا استخدام أحرف السطر الجديد في أسماء السلاسل لطلب فواصل أسطر.

**كيف أجعل الوسم يتبع نظام ألوان سمة العرض التقديمي؟**  
اترك ألوان، تعبئات، وخطوط الوسم غير محددة حتى يتمكن من وراثة تنسيق السمة. التنسيق الصريح يتجاوز إعدادات السمة المقابلة.