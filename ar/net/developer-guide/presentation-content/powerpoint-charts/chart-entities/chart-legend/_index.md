---
title: أسطورة المخطط
type: docs
url: /ar/net/chart-legend/
keywords: "أسطورة المخطط, حجم خط الأسطورة, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "تعيين الموقع وحجم الخط لأسطورة المخطط في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

## **تحديد موضع الأسطورة**
من أجل تعيين خصائص الأسطورة. يرجى اتباع الخطوات التالية:

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- الحصول على مرجع الشريحة.
- إضافة مخطط إلى الشريحة.
- تعيين خصائص الأسطورة.
- كتابة العرض التقديمي كملف PPTX.

في المثال الموضح أدناه، قمنا بتعيين الموضع والحجم لأسطورة المخطط.
```c#
// إنشاء مثال من فئة Presentation
Presentation presentation = new Presentation();

// الحصول على مرجع الشريحة
ISlide slide = presentation.Slides[0];

// إضافة مخطط عمود مجمع إلى الشريحة
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// تعيين خصائص الأسطورة
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// كتابة العرض التقديمي إلى القرص
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **تعيين حجم الخط للأسطورة**
تتيح مكتبة Aspose.Slides for .NET للمطورين تعيين حجم الخط للأسطورة. يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة `Presentation`.
- إنشاء المخطط الافتراضي.
- تعيين حجم الخط.
- تعيين قيمة الحد الأدنى للمحور.
- تعيين قيمة الحد الأقصى للمحور.
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


## **تعيين حجم الخط لأسطورة فردية**
تتيح مكتبة Aspose.Slides for .NET للمطورين تعيين حجم الخط لمدخلات الأسطورة الفردية. يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة `Presentation`.
- إنشاء المخطط الافتراضي.
- الوصول إلى مدخل الأسطورة.
- تعيين حجم الخط.
- تعيين قيمة الحد الأدنى للمحور.
- تعيين قيمة الحد الأقصى للمحور.
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


## **الأسئلة المتكررة**

**هل يمكنني تمكين الأسطورة بحيث يخصص المخطط مساحة لها تلقائيًا بدلاً من تغطيتها؟**

نعم. استخدم وضع عدم التراكب ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`); في هذه الحالة، سيقلص مساحة الرسم لتستوعب الأسطورة.

**هل يمكنني إنشاء تسميات أسطورة متعددة الأسطر؟**

نعم. يتم لف التسميات الطويلة تلقائيًا عندما تكون المساحة غير كافية؛ كما يتم دعم فواصل الأسطر القسرية عبر أحرف السطر الجديد في اسم السلسلة.

**كيف أجعل الأسطورة تتبع نظام ألوان سمة العرض التقديمي؟**

لا تقم بتعيين ألوان/تعبئات/خطوط صريحة للأسطورة أو نصها. سيتوارثون ذلك من السمة وسيتم تحديثهم بشكل صحيح عند تغيير التصميم.