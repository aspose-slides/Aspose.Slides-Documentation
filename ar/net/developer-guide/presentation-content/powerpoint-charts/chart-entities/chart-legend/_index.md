---
title: تخصيص وسائط إيضاح المخططات في العروض التقديمية باستخدام .NET
linktitle: وسيلة إيضاح المخطط
type: docs
url: /ar/net/chart-legend/
keywords:
- وسيلة إيضاح المخطط
- موضع وسيلة الإيضاح
- حجم الخط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بتخصيص وسائط إيضاح المخططات باستخدام Aspose.Slides for .NET لتحسين عروض PowerPoint التقديمية مع تنسيق وسيلة إيضاح مخصص."
---

## **تموضع وسيلة الإيضاح**
لتعيين خصائص وسيلة الإيضاح. يرجى اتباع الخطوات أدناه:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- الحصول على مرجع الشريحة.
- إضافة مخطط إلى الشريحة.
- تعيين خصائص وسيلة الإيضاح.
- كتابة العرض التقديمي كملف PPTX.

في المثال المرفق أدناه، قمنا بتعيين الموضع والحجم لوسيلة إيضاح المخطط.
```c#
// إنشاء كائن من فئة Presentation
Presentation presentation = new Presentation();

// الحصول على مرجع الشريحة
ISlide slide = presentation.Slides[0];

// إضافة مخطط عمودي مجمع إلى الشريحة
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// تعيين خصائص وسيلة الإيضاح
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// حفظ العرض التقديمي إلى القرص
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **تعيين حجم الخط لوسيلة الإيضاح**
تتيح مكتبة Aspose.Slides للـ .NET للمطورين إمكانية تعيين حجم الخط لوسيلة الإيضاح. يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من الفئة `Presentation` .
- إنشاء المخطط الافتراضي.
- تعيين حجم الخط.
- تعيين قيمة المحور الدنيا.
- تعيين قيمة المحور القصوى.
- حفظ العرض التقديمي على القرص.
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **تعيين حجم الخط لوسيلة إيضاح فردية**
تتيح مكتبة Aspose.Slides للـ .NET للمطورين إمكانية تعيين حجم الخط لمدخلات وسيلة الإيضاح الفردية. يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من الفئة `Presentation` .
- إنشاء المخطط الافتراضي.
- الوصول إلى مدخل وسيلة الإيضاح.
- تعيين حجم الخط.
- تعيين قيمة المحور الدنيا.
- تعيين قيمة المحور القصوى.
- حفظ العرض التقديمي على القرص.
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يمكنني تمكين وسيلة الإيضاح بحيث يخصص المخطط مساحة لها تلقائيًا بدلاً من تغطيتها؟**
نعم. استخدم وضع عدم التراكب ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`); في هذه الحالة، سيصغر مساحة الرسم لتستوعب وسيلة الإيضاح.

**هل يمكنني إنشاء تسميات وسيلة إيضاح متعددة الأسطر؟**
نعم. تُلف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ كما يتم دعم الفواصل الإلزامية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل وسيلة الإيضاح تتبع نظام ألوان سمة العرض التقديمي؟**
لا تقم بتعيين ألوان/ملء/خطوط صريحة لوسيلة الإيضاح أو نصها. ستُستمد هذه القيم من السمة وتُحدث بشكل صحيح عند تغيير التصميم.