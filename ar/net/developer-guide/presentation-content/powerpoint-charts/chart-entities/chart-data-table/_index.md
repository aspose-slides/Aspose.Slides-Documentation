---
title: تخصيص جداول بيانات المخططات في العروض التقديمية في .NET
linktitle: جدول البيانات
type: docs
url: /ar/net/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تخصيص خطوط جدول بيانات المخطط، والحدود، ومفاتيح الوسيلة الإعلامية في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET و C#."
---
## **نظرة عامة**

Aspose.Slides for .NET يتيح لك عرض جدول بيانات المخطط وتخصيص تنسيق نصه، الحدود، ومفاتيح الوسيلة الإعلامية. تشرح هذه المقالة كيفية تمكين الجدول، تنسيق النص، التحكم في كل نوع من الحدود، وإظهار أو إخفاء مفاتيح الوسيلة الإعلامية. تقوم الأمثلة بحفظ المخططات المكوّنة في ملفات PPTX.

## **تعيين خصائص الخط**

لعرض جدول بيانات المخطط، اضبط [HasDataTable](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chart/hasdatatable/) إلى `true`. استخدم [ChartDataTable](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chart/chartdatatable/) للوصول إلى الجدول وتكوين تنسيق نصه.

1. حمّل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/).
1. أضف مخطط عمودي مجمع إلى الشريحة الأولى.
1. فعّل جدول بيانات المخطط.
1. فعّل النص الغامق باستخدام [FontBold](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/fontbold/) واضبط [FontHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/fontheight/) إلى `20` للنص بحجم 20 نقطة.
1. احفظ العرض التقديمي المعدل.

المثال التالي يتطلب وجود `test.pptx` في الدليل العامل مع وجود شريحة واحدة على الأقل. يضيف مخططًا ببيانات افتراضية في الموقع (50, 50)، بعرض 600 نقطة وارتفاع 400 نقطة. يحتوي ملف `output.pptx` المحفوظ على المخطط مع تمكين جدول البيانات وتطبيق إعدادات الخط المحددة.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **تخصيص حدود جدول البيانات**

فعّل الجدول باستخدام [IChart.HasDataTable](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/hasdatatable/) وكن على اتصال به عبر [IChart.ChartDataTable](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/chartdatatable/). يمكنك التحكم في ثلاثة أنواع من الحدود بشكل مستقل:

- [HasBorderHorizontal](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatatable/hasborderhorizontal/) يتحكم في حدود الخلايا الأفقية.
- [HasBorderVertical](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatatable/hasbordervertical/) يتحكم في حدود الخلايا العمودية.
- [HasBorderOutline](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatatable/hasborderoutline/) يتحكم في الحد الخارجي للجدول.

اضبط كل خاصية إلى `true` لعرض حدودها أو إلى `false` لإخفائها. المثال التالي ينشئ مخطط عمودي مجمع ببيانات افتراضية، يعرض الحدود الأفقية والحد الخارجي، ويخفي الحدود العمودية. لا يتطلب ملف إدخال. يتم تحديد موقع وحجم المخطط بالنقاط.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

المقارنة أدناه تستخدم نفس بيانات المخطط وإعداد مفتاح الوسيلة الإعلامية في جميع الحالات الأربعة. تبدأ بجميع الحدود مفعلة، ويعطل كل متغير متبقي خاصية حد واحدة فقط. المتغير الموجود أسفل اليسار يطابق إعدادات الحدود في المثال.

![جداول بيانات المخطط مع تمكين جميع الحدود، بدون حدود أفقية، بدون حدود عمودية، وبدون الحد الخارجي](data-table-borders.png)

## **إظهار أو إخفاء مفاتيح الوسيلة الإعلامية**

مفاتيح الوسيلة الإعلامية هي علامات ملونة صغيرة بجانب أسماء السلاسل في جدول البيانات. تساعد القراء على مطابقة كل صف في الجدول مع سلسلة المخطط. اضبط [ShowLegendKey](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatatable/showlegendkey/) إلى `true` لعرض هذه العلامات أو إلى `false` لإخفائها.

الوسيلة الإعلامية المنفصلة للمخطط تُتحكم فيها عبر [IChart.HasLegend](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/haslegend/). هذه الإعدادات مستقلة: إخفاء الوسيلة الإعلامية المنفصلة لا يخفي المفاتيح داخل جدول البيانات، وإخفاء مفاتيح الجدول لا يخفي الوسيلة الإعلامية المنفصلة.

المثال التالي ينشئ مخططًا ببيانات افتراضية، يفعّل جدول بياناته، ويظهر مفاتيح الوسيلة الإعلامية داخله مع إخفاء الوسيلة الإعلامية المنفصلة. جميع حدود الجدول مفعلة صراحة. لا يلزم وجود عرض تقديمي مدخل. لإخفاء مفاتيح الجدول فقط، غيّر `dataTable.ShowLegendKey` إلى `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

المقارنة أدناه تُظهر نفس الجدول مع مفاتيح الوسيلة الإعلامية مفعلة ومُعطلة. تظل جميع الحدود مفعلة، وتُخفى الوسيلة الإعلامية المنفصلة للمخطط في الحالتين.

![جداول بيانات المخطط مع إظهار مفاتيح الوسيلة الإعلامية على اليسار وإخفاؤها على اليمين](data-table-legend-keys.png)

## **التعليمات المتداولة**

**هل يمكنني إظهار مفاتيح الوسيلة الإعلامية في جدول بيانات المخطط؟**

نعم. اضبط [ShowLegendKey](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/datatable/showlegendkey/) إلى `true` لعرض مفاتيح الوسيلة الإعلامية أو إلى `false` لإخفائها.

**هل سيتم الحفاظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. Aspose.Slides يقوم برندرة المخطط وجدول البيانات الظاهر كجزء من الشريحة عند تصديره إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، أو [صور](/slides/ar/net/convert-powerpoint-to-png/).

**هل يمكنني العمل مع جداول البيانات في المخططات التي تم تحميلها من قالب؟**

نعم. للمخطط المحمل من عرض تقديمي أو قالب موجود، استخدم [HasDataTable](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chart/hasdatatable/) للتحقق أو تعديل ما إذا كان جدول البيانات يظهر.

**كيف يمكن العثور على المخططات التي تم تمكين جدول بيانات لها؟**

قم بالتكرار عبر الأشكال في كل شريحة، حدد المخططات، وتحقق من خاصية [HasDataTable](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chart/hasdatatable/). القيمة `true` تشير إلى أن جدول البيانات مُمَكّن.