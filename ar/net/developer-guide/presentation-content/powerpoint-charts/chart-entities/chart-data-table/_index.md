---
title: جدول بيانات الرسم البياني
type: docs
url: /net/chart-data-table/
keywords: "خصائص الخط، جدول بيانات الرسم البياني، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "تعيين خصائص الخط لجدول بيانات الرسم البياني في عروض PowerPoint باستخدام C# أو .NET"
---

## **تعيين خصائص الخط لجدول بيانات الرسم البياني**
يوفر Aspose.Slides لـ .NET دعمًا لتغيير لون الفئات في سلسلة الألوان.

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. أضف الرسم البياني إلى الشريحة.
1. قم بتعيين جدول الرسم البياني.
1. قم بتعيين ارتفاع الخط.
1. احفظ العرض المعدل.

 يوجد أدناه مثال توضيحي.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```