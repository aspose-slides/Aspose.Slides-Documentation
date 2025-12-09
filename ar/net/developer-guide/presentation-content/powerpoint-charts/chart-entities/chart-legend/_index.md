---
title: تخصيص وسيلة إيضاح المخططات في العروض التقديمية في .NET
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
description: "خصص وسيلة إيضاح المخطط باستخدام Aspose.Slides for .NET لتحسين عروض PowerPoint التقديمية بتنسيق مخصص."
---

## **موضع وسيلة الإيضاح**
لتعيين خصائص وسيلة الإيضاح، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- الحصول على مرجع الشريحة.
- إضافة مخطط إلى الشريحة.
- تعيين خصائص وسيلة الإيضاح.
- كتابة العرض التقديمي كملف PPTX.

في المثال المرفق أدناه، قمنا بتعيين الموضع والحجم لوسيلة إيضاح المخطط.
```c#
// إنشاء نسخة من فئة Presentation
Presentation presentation = new Presentation();

// الحصول على مرجع الشريحة
ISlide slide = presentation.Slides[0];

// إضافة مخطط عمود مجمع إلى الشريحة
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// تعيين خصائص وسيلة الإيضاح
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// كتابة العرض التقديمي إلى القرص
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **تعيين حجم خط وسيلة الإيضاح**
تسمح مكتبة Aspose.Slides for .NET للمطورين بتعيين حجم خط وسيلة الإيضاح. يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة `Presentation`.
- إنشاء المخطط الافتراضي.
- تعيين حجم الخط.
- تعيين قيمة المحور الأدنى.
- تعيين قيمة المحور الأعلى.
- كتابة العرض التقديمي إلى القرص.
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


## **تعيين حجم خط كل عنصر في وسيلة الإيضاح**
تسمح مكتبة Aspose.Slides for .NET للمطورين بتعيين حجم خط كل عنصر من عناصر وسيلة الإيضاح. يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة `Presentation`.
- إنشاء المخطط الافتراضي.
- الوصول إلى عنصر وسيلة الإيضاح.
- تعيين حجم الخط.
- تعيين قيمة المحور الأدنى.
- تعيين قيمة المحور الأعلى.
- كتابة العرض التقديمي إلى القرص.
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

**هل يمكنني تمكين وسيلة الإيضاح بحيث يخصص المخطط مساحة لها تلقائيًا بدلاً من وضعها فوقه؟**
نعم. استخدم وضع عدم التراكب ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`); في هذه الحالة، سيقلص مساحة الرسم لتناسب وسيلة الإيضاح.

**هل يمكنني إنشاء تسميات وسيلة إيضاح متعددة الأسطر؟**
نعم. يتم لف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ كما يتم دعم فواصل الأسطر القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل وسيلة الإيضاح تتبع مخطط ألوان سمة العرض التقديمي؟**
لا تقم بتعيين ألوان/تعبئات/خطوط صريحة لوسيلة الإيضاح أو نصها. سيتوارثون ذلك من السمة وسيتم تحديثهم بشكل صحيح عند تغيير التصميم.