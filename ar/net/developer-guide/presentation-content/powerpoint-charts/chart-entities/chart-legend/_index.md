---
title: تفسير الرسم البياني
type: docs
url: /net/chart-legend/
keywords: "تفسير الرسم البياني، حجم خط التفسير، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "تعيين موضع وحجم الخط لتفسير الرسم البياني في عروض PowerPoint باستخدام C# أو .NET"
---

## **تعيين موضع التفسير**
لتعيين خصائص التفسير. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- الحصول على مرجع للشريحة.
- إضافة رسم بياني على الشريحة.
- تعيين خصائص التفسير.
- كتابة العرض كملف PPTX.

في المثال المعطى أدناه، قمنا بتعيين الموضع والحجم لتفسير الرسم البياني.

```c#
// إنشاء مثيل من فئة Presentation
Presentation presentation = new Presentation();

// الحصول على مرجع للشريحة
ISlide slide = presentation.Slides[0];

// إضافة رسم بياني عمودي مجمع على الشريحة
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// تعيين خصائص التفسير
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// كتابة العرض إلى القرص
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **تعيين حجم خط التفسير**
يتيح Aspose.Slides لـ .NET للمطورين تعيين حجم خط التفسير. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة `Presentation`.
- إنشاء الرسم البياني الافتراضي.
- تعيين حجم الخط.
- تعيين الحد الأدنى لقيمة المحور.
- تعيين الحد الأقصى لقيمة المحور.
- كتابة العرض إلى القرص.

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


## **تعيين حجم خط تفسير فردي**
يتيح Aspose.Slides لـ .NET للمطورين تعيين حجم خط إدخالات التفسير الفردية. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة `Presentation`.
- إنشاء الرسم البياني الافتراضي.
- الوصول إلى إدخال التفسير.
- تعيين حجم الخط.
- تعيين الحد الأدنى لقيمة المحور.
- تعيين الحد الأقصى لقيمة المحور.
- كتابة العرض إلى القرص.

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